using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class MarketPriceInterface
    {

        private long TypeIDToFind; // For searching a price list
        private int PriceHistoryUpdateCount; // For counting price history updates
        private int PriceOrdersUpdateCount; // for counting price updates
        private ToolStripProgressBar RefProgressBar;

        private bool TrackingRecords;

        public MarketPriceInterface(ref ToolStripProgressBar SentPG)
        {
            RefProgressBar = SentPG;
            PriceHistoryUpdateCount = 0;
            TrackingRecords = false;
        }

        // For updating market prices and history
        public struct ItemRegionPairs
        {
            public long ItemID;
            public long RegionID;
        }

        public enum MarketPriceCacheType
        {
            History = 0,
            Orders = 1
        }

        // Updates all the price history from ESI
        public bool UpdateESIPriceHistory(List<long> SentTypeIDs, long UpdateRegionID)
        {
            var Pairs = new List<ItemRegionPairs>();
            bool ReturnValue = true;
            var Threads = new ThreadingArray();

            // If the last time we called for history update was one minute, then reset the last date called and calls per minute counter
            if (DateAndTime.DateDiff(DateInterval.Second, Public_Variables.LastMarketHistoryUpdate, DateTime.Now) > 60L)
            {
                Public_Variables.MarketHistoryCallsPerMinute = 0;
                Public_Variables.LastMarketHistoryUpdate = DateTime.Now;
            }

            // Build the pairs
            for (int i = 0, loopTo = SentTypeIDs.Count - 1; i <= loopTo; i++)
            {
                // Only add data we want to query
                var TempPair = new ItemRegionPairs();
                TempPair.ItemID = SentTypeIDs[i];
                TempPair.RegionID = UpdateRegionID;
                if (UpdatableMarketData(TempPair, MarketPriceCacheType.History))
                {
                    // Check if we reached the max per calls and then don't add anything else
                    if (Public_Variables.MarketHistoryCallsPerMinute < Public_Variables.MaxMarketHistoryCallsPerMinute)
                    {
                        Pairs.Add(TempPair);
                        Public_Variables.MarketHistoryCallsPerMinute += 1;
                    }
                    else
                    {
                        // Can't do more than max calls
                        break;
                    }
                }
            }

            try
            {
                if (Pairs.Count > 0)
                {
                    var ESIData = new ESI();
                    int NumberofThreads = 0;
                    // How many records per thread do we need?
                    int Splits = (int)Math.Round(Math.Ceiling(Pairs.Count / (double)ESIData.GetMaximumConnections()));
                    if (Splits == 1)
                    {
                        // If the return is 1, then we have less than the max connections
                        // so just set up enough pairs for 1 run each
                        NumberofThreads = Pairs.Count;
                    }
                    else
                    {
                        NumberofThreads = ESIData.GetMaximumConnections();
                    }

                    // For processing
                    var ThreadPairs = new List<List<ItemRegionPairs>>();
                    var TempPairs = new List<ItemRegionPairs>();
                    int PairMarker = 0;
                    int j = 0;

                    // Cut up the pairs into chunks of split count and put them into the threadpairs list for threading later
                    for (int i = 0, loopTo1 = NumberofThreads - 1; i <= loopTo1; i++)
                    {
                        var loopTo2 = Pairs.Count - 1;
                        for (j = PairMarker; j <= loopTo2; j++)
                        {
                            if (j < Splits * (i + 1))
                            {
                                TempPairs.Add(Pairs[j]);
                            }
                            else
                            {
                                break;
                            }
                        }
                        ThreadPairs.Add(TempPairs);
                        TempPairs = new List<ItemRegionPairs>();
                        PairMarker = j;
                        if (j == Pairs.Count)
                        {
                            break;
                        }
                    }

                    // Start a transaction here to speed up processing in the updates
                    Public_Variables.EVEDB.BeginSQLiteTransaction();

                    // Reset the value of the progress bar
                    if (!(RefProgressBar == null))
                    {
                        RefProgressBar.Visible = true;
                        RefProgressBar.Value = 0;
                        PriceHistoryUpdateCount = 0;
                        RefProgressBar.Maximum = Pairs.Count;
                    }
                    Application.DoEvents();

                    // Call this manually if it's just one item to update
                    if (ThreadPairs.Count == 1)
                    {
                        UpdateMarketHistory(ThreadPairs[0]);
                    }
                    else
                    {
                        // Call each thread for the pairs
                        for (int i = 0, loopTo3 = ThreadPairs.Count - 1; i <= loopTo3; i++)
                        {
                            var UPHThread = new Thread(UpdateMarketHistory);
                            UPHThread.Start(ThreadPairs[i]);
                            // Save the thread if we need to kill it
                            Threads.AddThread(UPHThread);
                        }

                        // Now loop until all the threads are done
                        ReturnValue = WaitforUpdatetoComplete(ref Threads, ref Public_Variables.CancelManufacturingTabCalc, ref PriceHistoryUpdateCount, Pairs.Count);

                    }

                    // Make sure all threads are not running
                    Threads.StopAllThreads();
                    // Reset the error handler
                    Public_Variables.ESIErrorHandler = new ESIErrorProcessor();

                    // Finish updating the DB
                    Public_Variables.EVEDB.CommitSQLiteTransaction();

                    if (!(RefProgressBar == null))
                    {
                        RefProgressBar.Visible = false;
                    }
                    Application.DoEvents();
                }
            }

            catch (Exception ex)
            {
                Application.DoEvents();
            }

            return ReturnValue;

        }

        // For use with threading to speed up the ESI calls
        private void UpdateMarketHistory(object PairsList)
        {
            bool PricesUpdated;
            var TotalTimes = new List<double>();
            var DownloadTime = new List<double>();
            var ProcessingTime = new List<double>();
            var ESIHistory = new ESI();
            var ESIData = new ESI();

            List<ItemRegionPairs> Pairs = (List<ItemRegionPairs>)PairsList;

            try
            {
                for (int i = 0, loopTo = Pairs.Count - 1; i <= loopTo; i++)
                {

                    // Update the prices then check limiting if needed - Note, the internets suggests opening new threads with new db connections but I can't do transactions in each thread, which slows it down and this seems to work fine.
                    PricesUpdated = ESIData.UpdateMarketHistory(ref Public_Variables.EVEDB, Pairs[i].ItemID, Pairs[i].RegionID);

                    // Increment the count for reach record
                    PriceHistoryUpdateCount += 1;
                }
            }
            catch (Exception ex)
            {
                Application.DoEvents();
            }

        }

        // Uses ESI to update market prices from CCP
        public bool UpdateESIMarketOrders(List<Public_Variables.TypeIDRegion> CacheItems)
        {
            bool ReturnValue = true;
            var Pairs = new List<ItemRegionPairs>();
            var Threads = new ThreadingArray();
            var RegionIDList = new List<string>();

            Public_Variables.CancelUpdatePrices = false;

            // Build the pairs
            for (int i = 0, loopTo = CacheItems.Count - 1; i <= loopTo; i++)
            {
                var TempPair = new ItemRegionPairs();
                TempPair.ItemID = Conversions.ToLong(CacheItems[i].TypeIDs[0]);
                TempPair.RegionID = Conversions.ToLong(CacheItems[i].RegionString);
                // Make sure they are ready to update by cache
                if (UpdatableMarketData(TempPair, MarketPriceCacheType.Orders))
                {
                    // Save all the region IDs and check for one remaining at end for unknown stations
                    if (!RegionIDList.Contains(TempPair.RegionID.ToString()))
                    {
                        RegionIDList.Add(TempPair.RegionID.ToString());
                    }
                    Pairs.Add(TempPair);
                }
            }

            if (Pairs.Count > 0)
            {
                var ESIData = new ESI();
                int NumberofThreads = 0;
                // How many records per thread do we need?
                int Splits = (int)Math.Round(Math.Ceiling(Pairs.Count / (double)ESIData.GetMaximumConnections()));
                if (Splits == 1)
                {
                    // If the return is 1, then we have less than the max connections
                    // so just set up enough pairs for 1 run each
                    NumberofThreads = Pairs.Count;
                }
                else
                {
                    NumberofThreads = ESIData.GetMaximumConnections();
                }

                // For processing
                var ThreadPairs = new List<List<ItemRegionPairs>>();
                var TempPairs = new List<ItemRegionPairs>();
                int PairMarker = 0;
                int j = 0;

                // Cut up the pairs into chunks of split count and put them into the threadpairs list for threading later
                for (int i = 0, loopTo1 = NumberofThreads - 1; i <= loopTo1; i++)
                {
                    var loopTo2 = Pairs.Count - 1;
                    for (j = PairMarker; j <= loopTo2; j++)
                    {
                        if (j < Splits * (i + 1))
                        {
                            TempPairs.Add(Pairs[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    ThreadPairs.Add(TempPairs);
                    TempPairs = new List<ItemRegionPairs>();
                    PairMarker = j;
                    if (j == Pairs.Count)
                    {
                        break;
                    }
                }

                // Start a transaction here to speed up processing in the updates
                Public_Variables.EVEDB.BeginSQLiteTransaction();

                // Reset the value of the progress bar
                if (!(RefProgressBar == null))
                {
                    RefProgressBar.Visible = true;
                    RefProgressBar.Value = 0;
                    PriceHistoryUpdateCount = 0;
                    RefProgressBar.Maximum = Pairs.Count;
                }
                Application.DoEvents();

                // Call this manually if it's just one item to update
                if (ThreadPairs.Count == 1)
                {
                    UpdateMarketOrders(ThreadPairs[0]);
                }
                else
                {
                    // Call each thread for the pairs
                    for (int i = 0, loopTo3 = ThreadPairs.Count - 1; i <= loopTo3; i++)
                    {
                        var UPHThread = new Thread(UpdateMarketOrders);
                        UPHThread.Start(ThreadPairs[i]);
                        // Save the thread if we need to kill it
                        Threads.AddThread(UPHThread);
                    }

                    // Now loop until all the threads are done
                    ReturnValue = WaitforUpdatetoComplete(ref Threads, ref Public_Variables.CancelUpdatePrices, ref PriceOrdersUpdateCount, Pairs.Count);

                }

                // Make sure all threads are not running
                Threads.StopAllThreads();
                // Reset the error handler
                Public_Variables.ESIErrorHandler = new ESIErrorProcessor();

                // Finally, update any location data on structures we imported without region or system ID
                var UpdateIDs = new List<long>();
                SQLiteDataReader rsUpdate;
                Public_Variables.DBCommand = new SQLiteCommand("SELECT DISTINCT LOCATION_ID FROM MARKET_ORDERS WHERE REGION_ID = 0", Public_Variables.EVEDB.DBREf());
                rsUpdate = Public_Variables.DBCommand.ExecuteReader();

                while (rsUpdate.Read())
                    UpdateIDs.Add(rsUpdate.GetInt64(0));

                rsUpdate.Close();

                // Now with this list, run the structures update
                var SP = new StructureProcessor();
                string TempRegionID = "";
                SP.UpdateStructuresData(UpdateIDs, Public_Variables.SelectedCharacter.CharacterTokenData, RefProgressBar);

                foreach (var ID in UpdateIDs)
                {
                    Public_Variables.DBCommand = new SQLiteCommand("SELECT REGION_ID, SOLAR_SYSTEM_ID FROM STATIONS WHERE STATION_ID =" + ID.ToString(), Public_Variables.EVEDB.DBREf());
                    rsUpdate = Public_Variables.DBCommand.ExecuteReader();

                    if (rsUpdate.Read())
                    {
                        TempRegionID = rsUpdate.GetInt64(0).ToString();
                        if (TempRegionID == "0" & RegionIDList.Count == 1)
                        {
                            // They only wanted prices from one region and we have an unknown structure, so at least save the region ID we set the query up for
                            TempRegionID = RegionIDList[0];
                        }
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format("UPDATE MARKET_ORDERS SET REGION_ID = {0}, SOLAR_SYSTEM_ID = {1} WHERE LOCATION_ID = {2}", TempRegionID, rsUpdate.GetInt64(1), ID));
                    }

                    rsUpdate.Close();
                }

                // Finish updating the DB
                Public_Variables.EVEDB.CommitSQLiteTransaction();

                if (!(RefProgressBar == null))
                {
                    RefProgressBar.Visible = false;
                }
                Application.DoEvents();
            }

            return ReturnValue;

        }

        private bool WaitforUpdatetoComplete(ref ThreadingArray ThreadsArray, ref bool CancelUpdate, ref int Counter, int MaxValue)
        {
            var StartTime = Public_Variables.NoDate;
            bool Counting = false;
            bool StillWorking = false;

            while (Counter < MaxValue)
            {
                // Now loop until all the threads are done
                StillWorking = !ThreadsArray.Complete();

                // Update the progress bar with data from each thread
                IncrementToolStripProgressBar(Counter);
                Application.DoEvents();

                if (!StillWorking)
                {
                    break;
                }

                // If we are at the last 20 records, start a timer for finishing in case it hangs
                if (MaxValue - Counter <= 20 & !Counting)
                {
                    StartTime = DateTime.Now;
                    Counting = true;
                    TrackingRecords = true;
                }

                // Check if we need to leave
                if (CancelUpdate | StartTime != Public_Variables.NoDate & DateAndTime.DateDiff(DateInterval.Second, StartTime, DateTime.Now) >= 30L)
                {
                    ThreadsArray.StopAllThreads();
                    // Reset the error handler
                    Public_Variables.ESIErrorHandler = new ESIErrorProcessor();
                    if (CancelUpdate)
                    {
                        return true; // They wanted this so don't error
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        // Threading call to speed up the ESI calls for market orders
        private void UpdateMarketOrders(object PairsList)
        {
            bool PricesUpdated;
            var TotalTimes = new List<double>();
            var DownloadTime = new List<double>();
            var ProcessingTime = new List<double>();
            var ESIData = new ESI();

            List<ItemRegionPairs> Pairs = (List<ItemRegionPairs>)PairsList;

            try
            {
                for (int i = 0, loopTo = Pairs.Count - 1; i <= loopTo; i++)
                {

                    // Update the prices then check limiting if needed 
                    PricesUpdated = ESIData.UpdateMarketOrders(ref Public_Variables.EVEDB, Pairs[i].ItemID, Pairs[i].RegionID, false, true);

                    // Now that we updated it, for each record, update the total record count for the progressbar on frmMain
                    PriceOrdersUpdateCount += 1;
                }
            }
            catch (Exception ex)
            {
                Application.DoEvents();
            }

        }

        // Sees if the typid and region sent is ready to be updated by a cache date look up
        public bool UpdatableMarketData(ItemRegionPairs Item, MarketPriceCacheType CacheType)
        {
            string SQL;
            string TableName;
            SQLiteDataReader rsCache;
            DateTime Cachedate;

            // First look up the cache date to see if it's time to run the update
            if (CacheType == MarketPriceCacheType.History)
            {
                TableName = "MARKET_HISTORY_UPDATE_CACHE";
            }
            else if (CacheType == MarketPriceCacheType.Orders)
            {
                TableName = "MARKET_ORDERS_UPDATE_CACHE";
            }
            else
            {
                return false;
            }

            SQL = "SELECT CACHE_DATE FROM " + TableName + " WHERE TYPE_ID = " + Item.ItemID.ToString() + " AND REGION_ID = " + Item.RegionID.ToString();
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsCache = Public_Variables.DBCommand.ExecuteReader();

            Cachedate = Public_Variables.ProcessCacheDate(ref rsCache);

            rsCache.Close();

            if (Cachedate <= DateTime.UtcNow)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Updates the class referenced toolbar 
        private void IncrementToolStripProgressBar(int inValue)
        {

            if (RefProgressBar == null)
            {
                return;
            }

            // Updates the value in the progressbar for a smooth progress (slows procesing a little)
            if (inValue <= RefProgressBar.Maximum - 1 & inValue != 0)
            {
                RefProgressBar.Value = inValue;
                RefProgressBar.Value = inValue - 1;
                RefProgressBar.Value = inValue;
            }
            else
            {
                RefProgressBar.Value = inValue;
            }

        }

    }
}