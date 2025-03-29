using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public struct RefinedMaterial
    {

    }

    class ReprocessingPlant
    {

        private double ImplantBonus;
        private IndustryFacility ReprocessingFacility;

        public ReprocessingPlant(IndustryFacility SentReprocessingFacility, double ReprocessingImplantBonus)
        {

            ReprocessingFacility = SentReprocessingFacility;
            ImplantBonus = ReprocessingImplantBonus;

        }

        public IndustryFacility GetFacilility()
        {
            return ReprocessingFacility;
        }

        public Materials Reprocess(long ItemID, int ReprocessingSkill, int ReprocessingEfficiencySkill, int ProcessingSkill, double TotalQuantity, bool IncludeTax, Public_Variables.BrokerFeeInfo BrokerFeeData, ref double TotalYield, ref double ReprocessingFees, [Optional, DefaultParameterValue(false)] bool MintoOreFormat, [Optional] ref List<string> RefinedMineralsList)
        {
            long RefineBatches; // Number of batches of refine units we can refine from total

            string SQL;
            SQLiteDataReader readerRefine;

            var RefinedMats = new Materials();
            Material RefinedMat;
            long NewMaterialQuantity;
            double DoubleNewMaterialQuantity;

            double TempCost = 0d;
            double AdjustedCost = 0d;
            double ModStationTaxRate = 0d;
            bool ScrapReprocessing;

            // Find the units to refine for ore
            SQL = "SELECT UNITS_TO_REFINE FROM ORES WHERE ORE_ID =" + ItemID;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerRefine = Public_Variables.DBCommand.ExecuteReader();

            if (readerRefine.Read())
            {
                // Process into batches
                RefineBatches = (long)Math.Round(Math.Floor(TotalQuantity / Conversions.ToLong(readerRefine.GetValue(0))));
                if (RefineBatches == 0L)
                {
                    // Can't reprocess if there arne't enough units to refine
                    return RefinedMats;
                }
                ScrapReprocessing = false;
            }
            else
            {
                // Not an ore or ice, so must be scrapmetal processing
                SQL = "SELECT UNITS_TO_REPROCESS FROM REPROCESSING WHERE ITEM_ID =" + ItemID;
                readerRefine.Close();
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerRefine = Public_Variables.DBCommand.ExecuteReader();

                if (readerRefine.Read())
                {
                    RefineBatches = (long)Math.Round(Math.Floor(TotalQuantity / Conversions.ToLong(readerRefine.GetValue(0))));
                }
                else
                {
                    RefineBatches = (long)Math.Round(TotalQuantity);
                }
                ScrapReprocessing = true;
            }

            readerRefine.Close();

            // Reprocessing Rate for Ore & Ice (including Compressed)
            // Upwells - ReprocessingYield = (50+ RigModifier × (1 + SecurityModifier)) × (1 + StructureModifier)×(1+(0.03×R))×(1+(0.02×Re))×(1+(0.02×Op))×(1+Im)
            // Station - ReprocessingYield = StationEquipment x (1 + Processing skill x 0.03) x (1 + Processing Efficiency skill x 0.02) x (1 + Ore Processing skill x 0.02) x (1 + Processing Implant)
            // The implantModifier is 1.01, 1.02 and 1.04 for RX-801, RX-802 and RX-804 respectively.

            if (ScrapReprocessing)
            {
                // Base Station Equipment x (1 + Scrapmetal Processing x 0.02) - scrapmetal processing is only modifier that applies
                // **** GET THE VALUES FROM ATTTRIBUTES - change to take an override processing skill or look it up if null based on the item
                TotalYield = ReprocessingFacility.BaseME * (1d + 0.02d * ProcessingSkill);
            }
            else
            {
                TotalYield = ReprocessingFacility.MaterialMultiplier * (1d + 0.03d * ReprocessingSkill) * (1d + 0.02d * ReprocessingEfficiencySkill) * (1d + 0.02d * ProcessingSkill) * (1d + ImplantBonus);
            }

            // Can't get better than 100%
            if (TotalYield > 1d)
            {
                TotalYield = 1d;
            }

            // Add the base material
            if (MintoOreFormat)
            {

                // Get all the materials that could come from refining ores, even if zero, and add them to the list
                SQL = "SELECT typeID, typeName, groupName, volume, CASE WHEN REFINED_MATERIAL_QUANTITY IS NULL THEN 0 ELSE REFINED_MATERIAL_QUANTITY END AS QUANTITY, PRICE ";
                SQL += "FROM INVENTORY_TYPES, INVENTORY_GROUPS, ITEM_PRICES LEFT JOIN REPROCESSING ON REPROCESSING.REFINED_MATERIAL_ID = INVENTORY_TYPES.typeID ";
                SQL += "AND REPROCESSING.ITEM_ID = " + ItemID + " WHERE INVENTORY_TYPES.groupID IN (18,423) AND INVENTORY_TYPES.typeID = ITEM_PRICES.ITEM_ID ";
                SQL += "AND typeID NOT IN (27029,48927) AND INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID ORDER BY typeID";

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerRefine = Public_Variables.DBCommand.ExecuteReader();

                while (readerRefine.Read())
                {
                    DoubleNewMaterialQuantity = Conversions.ToLong(readerRefine.GetValue(4)) * RefineBatches * TotalYield;

                    RefinedMat = new Material(readerRefine.GetInt64(0), readerRefine.GetString(1), readerRefine.GetString(2), DoubleNewMaterialQuantity, readerRefine.GetDouble(3), readerRefine.IsDBNull(5) ? 0d : readerRefine.GetDouble(5), "", "");

                    RefinedMats.InsertMaterial(RefinedMat);

                    // If this has a quantity, then add the mineral name to the list for use
                    if (DoubleNewMaterialQuantity != 0d)
                    {
                        RefinedMineralsList.Add(readerRefine.GetString(1));
                    }

                }
            }

            else
            {
                // Get the Mats that will come from refining 1 batch
                SQL = "SELECT REPROCESSING.REFINED_MATERIAL_ID, REPROCESSING.REFINED_MATERIAL, REPROCESSING.REFINED_MATERIAL_GROUP, ";
                SQL += "REPROCESSING.REFINED_MATERIAL_VOLUME, REPROCESSING.REFINED_MATERIAL_QUANTITY, ITEM_PRICES.PRICE ";
                SQL += "FROM REPROCESSING, ITEM_PRICES ";
                SQL += "WHERE REPROCESSING.ITEM_ID= " + ItemID + " ";
                SQL += "AND REPROCESSING.REFINED_MATERIAL_ID = ITEM_PRICES.ITEM_ID ";

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerRefine = Public_Variables.DBCommand.ExecuteReader();

                while (readerRefine.Read())
                {
                    // Calculate the refine amount based on yield
                    if (ScrapReprocessing)
                    {
                        NewMaterialQuantity = (long)Math.Round(Math.Floor(Conversions.ToLong(readerRefine.GetValue(4)) * RefineBatches * TotalYield));
                    }
                    else
                    {
                        NewMaterialQuantity = (long)Math.Round(Math.Floor(Conversions.ToLong(readerRefine.GetValue(4)) * RefineBatches * TotalYield));
                    }

                    RefinedMat = new Material(readerRefine.GetInt64(0), readerRefine.GetString(1), readerRefine.GetString(2), NewMaterialQuantity, readerRefine.GetDouble(3), readerRefine.IsDBNull(5) ? 0d : readerRefine.GetDouble(5), "", "");

                    RefinedMats.InsertMaterial(RefinedMat);

                }

            }

            readerRefine.Close();

            double RefinedMatQuantity;
            double SingleReprocessingFee;
            ReprocessingFees = 0d;

            if (ReprocessingFacility.IncludeActivityUsage)
            {
                // Subtract the station's refine tax - or usage
                foreach (var RefinedMaterial in RefinedMats.GetMaterialList())
                {
                    SQL = "SELECT ADJUSTED_PRICE FROM ITEM_PRICES WHERE ITEM_ID = " + RefinedMaterial.GetMaterialTypeID();
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerRefine = Public_Variables.DBCommand.ExecuteReader();
                    readerRefine.Read();
                    if (MintoOreFormat)
                    {
                        RefinedMatQuantity = RefinedMaterial.GetDQuantity();
                    }
                    else
                    {
                        RefinedMatQuantity = RefinedMaterial.GetQuantity();
                    }
                    if (RefinedMatQuantity > 0d)
                    {
                        SingleReprocessingFee = readerRefine.GetDouble(0) * RefinedMatQuantity * ReprocessingFacility.TaxRate;
                        ReprocessingFees += SingleReprocessingFee;
                        // Adjust the station tax on the material - get the total adjusted price times tax rate minus total cost (save total)
                        TempCost = RefinedMaterial.GetTotalCost() - SingleReprocessingFee;
                        RefinedMaterial.SetTotalCost(TempCost);
                        AdjustedCost += TempCost;
                    }
                    readerRefine.Close();
                }

                // Update the total cost for the list
                RefinedMats.ResetTotalValue(AdjustedCost);
            }

            // Finally adjust the taxes
            if (IncludeTax)
            {
                RefinedMats.AdjustTaxedPrice(Public_Variables.GetSalesTax(RefinedMats.GetTotalMaterialsCost()));
            }

            // Broker fee data
            RefinedMats.AdjustTaxedPrice(Public_Variables.GetSalesBrokerFee(RefinedMats.GetTotalMaterialsCost(), BrokerFeeData));

            return RefinedMats;

        }

    }
}