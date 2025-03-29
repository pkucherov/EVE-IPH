using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

using Newtonsoft.Json;

namespace EVE_Isk_per_Hour
{

    // Class for querying data from EVE Markterer prices


    public class EVEMarketer : ICloneable
    {

        private Public_Variables.MyError ErrorData;

        private struct PriceQuery
        {
            public string ItemList;
            public List<long> Items;
            public string PriceLocation;
            public string PriceLocationHeader;
        }

        private string RegionOrSystemToFind;

        // Predicate for searching a list of pricequery
        private bool FindPriceQuery(PriceQuery ItemPrice)
        {
            if ((ItemPrice.PriceLocation ?? "") == (RegionOrSystemToFind ?? ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Function takes an array of strings for Regions and a TypeID list, returns an array of EVE Marketeer prices
        public List<EVEMarketerPrice> GetPrices(List<PriceItem> TypeIDList)
        {
            var PriceRecords = new List<EVEMarketerPrice>();
            EVEMarketerPrice TempRecord;
            var PriceOutput = new List<EMType>();
            string EVEMarketerMainQuery = "https://api.evemarketer.com/ec/marketstat/json?";

            var ProcessQueryList = new List<PriceQuery>();
            var FinalQueryList = new List<PriceQuery>();
            var FindPQ = new PriceQuery();
            var InsertPQ = new PriceQuery();

            string ItemListHeader = "typeid=";
            string RegionHeader = "&regionlimit=";
            string SystemHeader = "&usesystem=";
            string RegionSystemUsed = "";
            string PriceLocationHeaderUsed = "";

            // Set up for each region/system and item combos to be queried
            foreach (var Item in TypeIDList)
            {
                // Search the main query list for the region, if there add typeid to the list, else add new list 
                if (string.IsNullOrEmpty(Item.SystemID))
                {
                    RegionSystemUsed = Item.RegionID;
                    PriceLocationHeaderUsed = RegionHeader;
                }
                else
                {
                    RegionSystemUsed = Item.SystemID;
                    PriceLocationHeaderUsed = SystemHeader;
                }

                RegionOrSystemToFind = RegionSystemUsed;
                FindPQ = ProcessQueryList.Find(FindPriceQuery);
                if (string.IsNullOrEmpty(FindPQ.PriceLocation))
                {
                    // Add it
                    InsertPQ.PriceLocation = RegionSystemUsed;
                    InsertPQ.PriceLocationHeader = PriceLocationHeaderUsed;
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
                if (Strings.Len(EVEMarketerMainQuery + FindPQ.ItemList + FindPQ.PriceLocationHeader + FindPQ.PriceLocation) > 1900 | FindPQ.Items.Count >= 100)
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
                    // https://api.evemarketer.com/ec/marketstat/json?typeid=34,35&usesystem=30002659

                    string Output = Public_Variables.GetJSONFile(EVEMarketerMainQuery + Record.ItemList.Substring(0, Strings.Len(Record.ItemList) - 1) + Record.PriceLocationHeader + Record.PriceLocation, "EVE Marketer Prices");
                    // Parse the out put into the object and process
                    PriceOutput = JsonConvert.DeserializeObject<List<EMType>>(Output);

                    if (Public_Variables.PriceUpdateDown)
                    {
                        return PriceRecords;
                    }

                    if (!(PriceOutput == null))
                    {
                        foreach (var Price in PriceOutput)
                        {
                            TempRecord = new EVEMarketerPrice();
                            TempRecord.TypeID = Price.buy.forQuery.types[0];
                            TempRecord.PriceLocation = Conversions.ToLong(Record.PriceLocation);
                            TempRecord.BuyAvgPrice = Price.buy.avg;
                            TempRecord.BuyMaxPrice = Price.buy.max;
                            TempRecord.BuyMedian = Price.buy.median;
                            TempRecord.BuyMinPrice = Price.buy.min;
                            TempRecord.BuyPercentile = Price.buy.fivePercent;
                            TempRecord.BuyStdDev = Price.buy.stdDev;
                            TempRecord.BuyVolume = Price.buy.volume;
                            TempRecord.BuyWeightedAveragePrice = Price.buy.wavg;
                            TempRecord.BuyVariance = Price.buy.variance;

                            TempRecord.SellAvgPrice = Price.sell.avg;
                            TempRecord.SellMaxPrice = Price.sell.max;
                            TempRecord.SellMedian = Price.sell.median;
                            TempRecord.SellMinPrice = Price.sell.min;
                            TempRecord.SellPercentile = Price.sell.fivePercent;
                            TempRecord.SellStdDev = Price.sell.stdDev;
                            TempRecord.SellVolume = Price.sell.volume;
                            TempRecord.SellWeightedAveragePrice = Price.sell.wavg;
                            TempRecord.SellVariance = Price.sell.variance;

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

    public struct EVEMarketerPrice
    {
        public long TypeID;
        public double BuyVolume;
        public double BuyWeightedAveragePrice;
        public double BuyAvgPrice;
        public double BuyMaxPrice;
        public double BuyMinPrice;
        public double BuyStdDev;
        public double BuyMedian;
        public double BuyPercentile;
        public double BuyVariance;
        public double SellVolume;
        public double SellWeightedAveragePrice;
        public double SellAvgPrice;
        public double SellMaxPrice;
        public double SellMinPrice;
        public double SellStdDev;
        public double SellMedian;
        public double SellPercentile;
        public double SellVariance;
        public long PriceLocation;
        public bool Errored;
    }

    public class PriceItem : ICloneable
    {

        public long TypeID;
        public bool Manufacture;
        public string RegionID;
        public string SystemID;
        public string StructureID;
        public string GroupName;
        public double PriceModifier;
        public string PriceType;
        public bool JitaPerimeterPrice;

        public object Clone()
        {
            var CopyOfMe = new PriceItem();

            CopyOfMe.TypeID = TypeID;
            CopyOfMe.Manufacture = Manufacture;
            CopyOfMe.RegionID = RegionID;
            CopyOfMe.SystemID = SystemID;
            CopyOfMe.StructureID = StructureID;
            CopyOfMe.GroupName = GroupName;
            CopyOfMe.PriceModifier = PriceModifier;
            CopyOfMe.PriceType = PriceType;
            CopyOfMe.JitaPerimeterPrice = JitaPerimeterPrice;

            return CopyOfMe;

        }
    }

    public class EMforQuery
    {
        [JsonProperty("bid")]
        public string bid;
        [JsonProperty("types")]
        public List<int> types;
        [JsonProperty("regions")]
        public List<int> regions;
        [JsonProperty("systems")]
        public List<int> systems;
        [JsonProperty("hours")]
        public int hours;
        [JsonProperty("minq")]
        public int minq;
    }

    public class EMTypeStat
    {
        [JsonProperty("forQuery")]
        public EMforQuery forQuery;
        [JsonProperty("volume")]
        public long volume;
        [JsonProperty("wavg")]
        public double wavg;
        [JsonProperty("avg")]
        public double avg;
        [JsonProperty("min")]
        public double min;
        [JsonProperty("max")]
        public double max;
        [JsonProperty("variance")]
        public double variance;
        [JsonProperty("stdDev")]
        public double stdDev;
        [JsonProperty("median")]
        public double median;
        [JsonProperty("fivePercent")]
        public double fivePercent;
        [JsonProperty("highToLow")]
        public bool highToLow;
        [JsonProperty("generated")]
        public long generated;
    }

    public class EMType
    {
        [JsonProperty("buy")]
        public EMTypeStat buy;
        [JsonProperty("sell")]
        public EMTypeStat sell;
    }
}