using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

using Newtonsoft.Json;

namespace EVE_Isk_per_Hour
{

    // Class for querying data from Fuzzworks prices


    public class FuzzworksMarket : ICloneable
    {

        private Public_Variables.MyError ErrorData;

        private struct PriceQuery
        {
            public string ItemList;
            public List<long> Items;
            public string PriceLocation;
            public string RegionOrSystemHeader;
        }

        private string PriceLocationToFind;

        // Predicate for searching a list of pricequery
        private bool FindPriceQuery(PriceQuery ItemPrice)
        {
            if ((ItemPrice.PriceLocation ?? "") == (PriceLocationToFind ?? ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Function takes an array of strings for Regions and a TypeID list, returns an array of prices from Fuzzworks
        public List<FuzzworksMarketPrice> GetPrices(List<PriceItem> TypeIDList)
        {
            var PriceRecords = new List<FuzzworksMarketPrice>();
            FuzzworksMarketPrice TempRecord;
            var PriceOutput = new Dictionary<long, FuzzworksMarketType>();
            string FuzzworksMarketMainQuery = "https://market.fuzzwork.co.uk/aggregates/?";

            var ProcessQueryList = new List<PriceQuery>();
            var FinalQueryList = new List<PriceQuery>();
            var FindPQ = new PriceQuery();
            var InsertPQ = new PriceQuery();

            string ItemListHeader = "types=";
            string RegionHeader = "region=";
            string SystemHeader = "system=";
            string StationHeader = "station=";
            string PriceLocationUsed = "";
            string PriceLocationHeaderUsed = "";

            // Set up for each region/system and item combos to be queried
            foreach (var Item in TypeIDList)
            {
                // Search the main query list for the region, if there add typeid to the list, else add new list 
                PriceLocationHeaderUsed = RegionHeader; // Always use region header for now
                if (string.IsNullOrEmpty(Item.SystemID))
                {
                    PriceLocationUsed = Item.RegionID;
                }
                else
                {
                    PriceLocationUsed = Item.SystemID;
                }

                PriceLocationToFind = PriceLocationUsed;
                FindPQ = ProcessQueryList.Find(FindPriceQuery);
                if (string.IsNullOrEmpty(FindPQ.PriceLocation))
                {
                    // Add it
                    InsertPQ.PriceLocation = PriceLocationUsed;
                    InsertPQ.RegionOrSystemHeader = PriceLocationHeaderUsed;
                    InsertPQ.ItemList = ItemListHeader + Item.TypeID.ToString() + ",";
                    InsertPQ.Items = new List<long>();
                    InsertPQ.Items.Add(Item.TypeID); // for counting
                    FindPQ = InsertPQ; // set them to the same now
                    ProcessQueryList.Add(InsertPQ);
                }
                else
                {
                    // Found, so update
                    ProcessQueryList.Remove(FindPQ);
                    FindPQ.ItemList += Item.TypeID.ToString() + ",";
                    FindPQ.Items.Add(Item.TypeID);
                    ProcessQueryList.Add(FindPQ);
                }

                // if Len(EVEMarketerMainQuery & ItemList & RegionOrSystem) > 1900 (will get a too long error at 2000) or over 100 items at a time
                if (Strings.Len(FuzzworksMarketMainQuery + FindPQ.RegionOrSystemHeader + FindPQ.PriceLocation + FindPQ.ItemList) > 1900 | FindPQ.Items.Count >= 100)
                {
                    ProcessQueryList.Remove(FindPQ); // remove from process list
                                                     // Insert the item to the final list
                    FinalQueryList.Add(FindPQ);
                }
            }

            // Add whatever is left in the process lists
            FinalQueryList.AddRange(ProcessQueryList);

            Public_Variables.PriceUpdateDown = false;

            var ErrorCode = default(int);
            foreach (var Record in FinalQueryList)
            {
                try
                {
                    // Example get
                    // https://market.fuzzwork.co.uk/aggregates/?region=10000002&types=34,35,36,37,38,39,40

                    string Output = Public_Variables.GetJSONFile(FuzzworksMarketMainQuery + Record.RegionOrSystemHeader + Record.PriceLocation + "&" + Record.ItemList.Substring(0, Strings.Len(Record.ItemList) - 1), "Fuzzwork Market Prices");
                    // Parse the out put into the object and process
                    PriceOutput = JsonConvert.DeserializeObject<Dictionary<long, FuzzworksMarketType>>(Output);

                    if (Public_Variables.PriceUpdateDown)
                    {
                        return PriceRecords;
                    }

                    if (!(PriceOutput == null))
                    {
                        foreach (var Price in PriceOutput)
                        {
                            {
                                var withBlock = Price.Value;
                                TempRecord = new FuzzworksMarketPrice();
                                TempRecord.TypeID = Price.Key;
                                TempRecord.PriceLocation = Conversions.ToLong(Record.PriceLocation);

                                TempRecord.BuyMaxPrice = withBlock.buy.max;
                                TempRecord.BuyMedian = withBlock.buy.median;
                                TempRecord.BuyMinPrice = withBlock.buy.min;
                                TempRecord.BuyPercentile = withBlock.buy.percentile;
                                TempRecord.BuyStdDev = withBlock.buy.stddev;
                                TempRecord.BuyVolume = withBlock.buy.volume;
                                TempRecord.BuyWeightedAveragePrice = withBlock.buy.weightedAverage;

                                TempRecord.SellMaxPrice = withBlock.sell.max;
                                TempRecord.SellMedian = withBlock.sell.median;
                                TempRecord.SellMinPrice = withBlock.sell.min;
                                TempRecord.SellPercentile = withBlock.sell.percentile;
                                TempRecord.SellStdDev = withBlock.sell.stddev;
                                TempRecord.SellVolume = withBlock.sell.volume;
                                TempRecord.SellWeightedAveragePrice = withBlock.sell.weightedAverage;
                            }

                            // Add the record
                            PriceRecords.Add(TempRecord);

                            Application.DoEvents();
                        }
                    }
                }

                catch (Exception ex)
                {
                    // Determine if it's a 4xx error (my error) or 5xx (server error)
                    // Get the first digit
                    string ErrMsg = ex.Message;

                    if (Strings.InStr(ErrMsg, "(") != 0)
                    {
                        // It has an error code
                        if (Information.IsNumeric(ErrMsg.Substring(Strings.InStr(ErrMsg, "("), 1)))
                        {
                            ErrorCode = Conversions.ToInteger(ErrMsg.Substring(Strings.InStr(ErrMsg, "("), 1));
                        }
                        else
                        {
                            // No clue what it is
                            // Message box and then exit
                            ErrorData.Description = ErrMsg + Constants.vbCrLf + " In: " + ex.Source + Constants.vbCrLf + " With: " + ex.Data.ToString() + Constants.vbCrLf;
                            ErrorData.Number = ErrorCode;
                            return null;
                        }
                    }
                    else
                    {
                        // No clue what it is
                        // Message box and then exit
                        ErrorData.Description = ErrMsg + Constants.vbCrLf + " In: " + ex.Source + Constants.vbCrLf + " With: " + ex.Data.ToString() + Constants.vbCrLf;
                        ErrorData.Number = ErrorCode;
                        return null;
                    }

                    // If we error, that means one of the item list has errored. Probably a bad request for an item
                    // that isn't in the EVE Marketer DB. If bad request (4xx error) then try and run it with 1 per batch and weed out the errors
                    // If the TypeIDBatchCount isn't 1, then re-run
                    if (ErrorCode == 4)
                    {
                        // Message box and then exit
                        ErrorData.Description = ex.Message;
                        ErrorData.Number = ErrorCode;
                        return null;
                    }
                    else if (ErrorCode == 5) // The server is down or something
                    {
                        // Message box and then exit
                        ErrorData.Description = ex.Message;
                        ErrorData.Number = ErrorCode;
                        return null;
                    }

                }

            }

            return PriceRecords;

            return default;

        }

        // Allow the users to access the error data returned if an error occurs for processing outside class
        public Public_Variables.MyError GetErrorData()
        {
            return ErrorData;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }

    public struct FuzzworksMarketPrice
    {
        public long TypeID;
        public long PriceLocation;
        public double BuyVolume;
        public double BuyWeightedAveragePrice;
        public double BuyMaxPrice;
        public double BuyMinPrice;
        public double BuyStdDev;
        public double BuyMedian;
        public double BuyPercentile;
        public double SellVolume;
        public double SellWeightedAveragePrice;
        public double SellMaxPrice;
        public double SellMinPrice;
        public double SellStdDev;
        public double SellMedian;
        public double SellPercentile;
    }

    public class FuzzworksMarketTypeStat
    {
        [JsonProperty("weightedAverage")]
        public double weightedAverage;
        [JsonProperty("max")]
        public double max;
        [JsonProperty("min")]
        public double min;
        [JsonProperty("stddev")]
        public double stddev;
        [JsonProperty("median")]
        public double median;
        [JsonProperty("volume")]
        public double volume;
        [JsonProperty("orderCount")]
        public double orderCount;
        [JsonProperty("percentile")]
        public double percentile;
    }

    public class FuzzworksMarketType
    {
        [JsonProperty("buy")]
        public FuzzworksMarketTypeStat buy;
        [JsonProperty("sell")]
        public FuzzworksMarketTypeStat sell;
    }
}