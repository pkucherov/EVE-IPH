using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public class StructureProcessor
    {

        private int StructureCount;

        public struct StructureStationInformation
        {
            public long ID;
            public string Name;
            public long RegionID;
            public long SystemID;
        }

        public struct StructureIDTokenEntryFlag
        {
            public long StructureID;
            public SavedTokenData TokenData;
            public bool ManualEntry;
            public ToolStripProgressBar RefPG;
        }

        // Updates the stations table with upwell structure data for the list of IDs sent and returns a set of name/ID pairs using threading
        public void UpdateStructuresData(List<long> StructureIDs, SavedTokenData CharacterTokenData, ToolStripProgressBar refPG)
        {

            try
            {
                var Threads = new ThreadingArray();
                var ESIData = new ESI();

                // For processing
                var ThreadData = new List<StructureIDTokenEntryFlag>();
                var QueryData = new StructureIDTokenEntryFlag();
                int PairMarker = 0;
                var SP = new StructureProcessor();

                // Load all the query data
                foreach (var SID in StructureIDs)
                {
                    QueryData.StructureID = SID;
                    QueryData.TokenData = CharacterTokenData;
                    QueryData.ManualEntry = false;
                    QueryData.RefPG = refPG;
                    ThreadData.Add(QueryData);
                    Application.DoEvents();
                }

                // Call this manually if it's just one item to update
                if (ThreadData.Count == 1)
                {
                    var TempPair = new StructureIDTokenEntryFlag();
                    TempPair = ThreadData[0];
                    ThreadData = new List<StructureIDTokenEntryFlag>();
                    ThreadData.Add(TempPair);
                    UpdateStructureData(ThreadData[0]);
                }
                else
                {
                    // Reset the value of the progress bar for counting structures
                    if (!(refPG == null))
                    {
                        refPG.Visible = true;
                        refPG.Value = 0;
                        StructureCount = 0;
                        refPG.Maximum = StructureIDs.Count;
                    }

                    // Call each thread for the pairs
                    for (int i = 0, loopTo = ThreadData.Count - 1; i <= loopTo; i++)
                    {
                        var UPHThread = new Thread(UpdateStructureData);
                        UPHThread.Start(ThreadData[i]);
                        // Save the thread if we need to kill it
                        Threads.AddThread(UPHThread);
                    }

                    bool Stillworking = true;
                    int PrevCount = 0;
                    var StartTime = DateTime.Now;

                    while (!Threads.Complete())
                    {
                        // Update the progress bar with current count every time we check (only if we finished at least one run)
                        if (StructureCount > PrevCount)
                        {
                            IncrementToolStripProgressBar(StructureCount, ref refPG);
                        }
                        PrevCount = StructureCount;
                        Application.DoEvents();

                        // Check if we need to leave - cancel pressed or 2 minutes passed
                        if (Public_Variables.CancelUpdatePrices | StartTime != Public_Variables.NoDate & DateAndTime.DateDiff(DateInterval.Second, StartTime, DateTime.Now) >= 120L)
                        {
                            Threads.StopAllThreads();
                            // Reset the error handler
                            Public_Variables.ESIErrorHandler = new ESIErrorProcessor();
                            if (Public_Variables.CancelUpdatePrices)
                            {
                                return;
                            }
                        }
                    }

                    // Make sure all threads are not running
                    Threads.StopAllThreads();
                    // Reset the error handler
                    Public_Variables.ESIErrorHandler = new ESIErrorProcessor();

                }
            }

            catch (Exception ex)
            {
                Public_Variables.ESIErrorHandler.ProcessException(ex, ESIErrorProcessor.ESIErrorLocation.PrivateAuthData, false);
            }

        }

        // For use with threading to update structure data
        public void UpdateStructureData(object Data)
        {
            StructureIDTokenEntryFlag StructureInfo;

            StructureInfo = (StructureIDTokenEntryFlag)Data;

            UpdateStructureData(StructureInfo.StructureID, StructureInfo.TokenData, StructureInfo.ManualEntry);

        }

        // To update data for one structure
        public void UpdateStructureData(long StructureID, SavedTokenData TokenData, bool ManualEntry, bool SupressError = true, bool IgnoreCacheDate = false)
        {
            string SQL = "";
            SQLiteDataReader rsData;
            var API = new ESI();
            var EVEStructure = new ESIUniverseStructure();
            var CacheDate = default(DateTime);
            int ManuallyAddedCode;

            if (!IgnoreCacheDate)
            {
                // Get the cache date of the facility ID
                SQL = "SELECT CACHE_DATE, STATION_NAME FROM STATIONS WHERE STATION_ID = " + StructureID.ToString();
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsData = Public_Variables.DBCommand.ExecuteReader();

                if (rsData.Read())
                {
                    // See if we update it
                    if (!(rsData.GetValue(0) is DBNull))
                    {
                        if (DateAndTime.DateValue(rsData.GetString(0)) > DateTime.UtcNow)
                        {
                            // Doesn't need update
                            return;
                        }
                    }
                }

                rsData.Close();

            }

            if (ManualEntry)
            {
                ManuallyAddedCode = -1;
            }
            else
            {
                ManuallyAddedCode = 0;
            }

            try
            {
                // Look up the facility and save it in the STATIONS table
                EVEStructure = API.GetStructureData(StructureID, TokenData, ref CacheDate, SupressError);

                StructureCount += 1;

                // Look up the manual saved code and save it if we update the data
                SQL = "SELECT MANUAL_ENTRY FROM STATIONS WHERE STATION_ID = " + StructureID.ToString();
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsData = Public_Variables.DBCommand.ExecuteReader();

                // Reset the data if it's in the table and we aren't setting to true in this call
                if (rsData.Read() & ManuallyAddedCode == 0)
                {
                    ManuallyAddedCode = rsData.GetInt32(0);
                }

                rsData.Close();

                // Delete the record, if there, then add new data
                Public_Variables.EVEDB.ExecuteNonQuerySQL("DELETE FROM STATIONS WHERE STATION_ID = " + StructureID.ToString());

                if (!(EVEStructure == null))
                {
                    // Lookup the data for the upwell structure from static tables
                    SQL = "SELECT solarSystemID, security, regionID FROM SOLAR_SYSTEMS WHERE solarSystemID = " + EVEStructure.solar_system_id.ToString();
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsData = Public_Variables.DBCommand.ExecuteReader();
                    rsData.Read();

                    if (rsData.HasRows)
                    {
                        SQL = "INSERT INTO STATIONS VALUES ({0},'{1}',{2},{3},{4},{5},{6},0,0,'{7}',{8})";
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(SQL, StructureID, Public_Variables.FormatDBString(EVEStructure.name), EVEStructure.type_id, rsData.GetInt32(0), rsData.GetDouble(1), rsData.GetInt32(2), EVEStructure.owner_id, Strings.Format(CacheDate, Public_Variables.SQLiteDateFormat), ManuallyAddedCode));

                    }
                    rsData.Close();
                }

                else
                {
                    // Insert it as unknown so we don't look it up again for a day
                    SQL = "INSERT INTO STATIONS VALUES ({0},'{1}',{2},{3},{4},{5},{6},0,0,'{7}',{8})";
                    // Check the structure each day - set cache to now + 1
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(SQL, StructureID, "Unknown Structure", 0, 0, 0, 0, 0, Strings.Format(DateAndTime.DateAdd(DateInterval.Day, 1d, DateTime.UtcNow), Public_Variables.SQLiteDateFormat), ManuallyAddedCode));
                }
            }

            catch (ThreadAbortException X)
            {
                // Just continue as normal
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("An error occured when importing structure data: " + ex.Message, Constants.vbInformation, Application.ProductName);
            }

        }

        // Returns the ID, Name, region and system IDs for a structure or station ID sent. If refresh true, then refresh the data 
        public StructureStationInformation GetStationInformation(long StructureID, SavedTokenData CharacterTokenData, bool RefreshData)
        {
            var ReturnData = new StructureStationInformation();

            ReturnData.ID = StructureID;

            // Update the data if it's a structure
            if (StructureID > Public_Variables.MaxStationID & RefreshData)
            {
                UpdateStructureData(StructureID, CharacterTokenData, false);
            }

            string SQL;
            SQLiteDataReader rsStations;

            // Get the region and system id from the location of the station or structure
            SQL = "SELECT STATION_ID, STATION_NAME, SOLAR_SYSTEM_ID, REGION_ID FROM STATIONS WHERE STATION_ID = " + StructureID.ToString();
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsStations = Public_Variables.DBCommand.ExecuteReader();

            while (rsStations.Read())
            {
                ReturnData.ID = rsStations.GetInt64(0);
                ReturnData.Name = rsStations.GetString(1);
                ReturnData.SystemID = rsStations.GetInt64(2);
                ReturnData.RegionID = rsStations.GetInt64(3);
            }

            rsStations.Close();

            return ReturnData;

        }

        // Updates the class referenced toolbar 
        private void IncrementToolStripProgressBar(int inValue, ref ToolStripProgressBar PG)
        {

            if (PG == null)
            {
                return;
            }

            // Updates the value in the progressbar for a smooth progress (slows procesing a little)
            if (inValue <= PG.Maximum - 1 & inValue != 0)
            {
                PG.Value = inValue;
                PG.Value = inValue - 1;
                PG.Value = inValue;
            }
            else
            {
                PG.Value = inValue;
            }

        }

    }
}