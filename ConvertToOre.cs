using System;
using System.Collections.Generic;
using System.Data.SQLite;
using LpSolveDotNet;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public class ConvertToOre
    {
        private ReprocessingPlant Refinery;
        private ConversionToOreSettings OreConversionSettings;

        private struct OreDetails
        {
            public int ID;
            public string Name;
            public string BaseName; // Instead of Compressed Dense Veldspar, just Veldspar
            public string Group;
            public double RefineRate;
            public double Volume;
            public double Price;
            public double MinimizeOnValue;
            public Materials RefinedOreList;
            public int RefineUnits;
        }

        public ConvertToOre(ref IndustryFacility RefineryStation, ConversionToOreSettings ConversionSettings)
        {
            Refinery = new ReprocessingPlant(RefineryStation, SettingsVariables.UserApplicationSettings.RefiningImplantValue);
            OreConversionSettings = ConversionSettings;
        }

        // Replaces any minerals or ice products with the best ore or ice based on settings
        public Materials GetOresfromMinerals(Materials BuildMaterialList, ref Materials ExcessMaterials, ref double ReprocessingUsage)
        {
            string SQL = "";
            string SelectionSQL = "";
            SQLiteDataReader rsOre;

            LpSolve OreLP;
            lpsolve_return OreLPReturn;
            int[] OreColumns;
            double[] MineralRows;
            double[] Outputs;
            long OutputQuantity;
            Material TempMaterial;

            // For inserting into final LP matrix later 
            var OreData = new Dictionary<int, OreDetails>();
            int OreColumnIndex = 0;
            int ColumnIndex = 0;
            var TempOre = default(OreDetails);
            int ProcessingSkill;
            var RefinedItemsList = new List<string>(); // For setting up the rows for LP Solve and making sure no rows are empty
            List<string> ReturnRefinedItemsList;

            // Conversion Settings has the ores we want to use, so just get the refine values
            {
                ref var withBlock = ref OreConversionSettings;
                foreach (var Ore in withBlock.SelectedOres)
                {
                    SQL = "SELECT ORES.ORE_ID, ORE_NAME, UNITS_TO_REFINE, ORE_VOLUME, PRICE, ";
                    SQL += "CASE WHEN ITEM_GROUP = 'Ice' THEN CASE WHEN SUBSTR(ORE_NAME,1,10) ='Compressed' THEN SUBSTR(ORE_NAME,12) ELSE ORE_NAME END ELSE ITEM_GROUP END AS ORE_GROUP ";
                    SQL += "FROM ORES, ORE_LOCATIONS, ITEM_PRICES WHERE ORES.ORE_ID = ITEM_PRICES.ITEM_ID ";
                    SQL += "AND ORE_GROUP = '" + Ore.OreName + "' ";
                    // Check Variants for ore only
                    if (Ore.OreGroup == "Ore")
                    {
                        SQL += "AND HIGH_YIELD_ORE IN (";
                        if (withBlock.OreVariant0)
                        {
                            SQL += "0,";
                        }
                        if (withBlock.OreVariant5)
                        {
                            SQL += "1,";
                        }
                        if (withBlock.OreVariant10)
                        {
                            SQL += "2,";
                        }
                        // Strip the last comma
                        SQL = SQL.Substring(0, Strings.Len(SQL) - 1) + ") ";
                    }

                    if (Ore.OreGroup == "Ice" & withBlock.CompressedIce | Ore.OreGroup == "Ore" & withBlock.CompressedOre)
                    {
                        SQL += "AND ORE_NAME LIKE 'Compressed%' ";
                    }
                    else
                    {
                        SQL += "AND ORE_NAME NOT LIKE 'Compressed%' ";
                    }

                    SQL += "GROUP BY ORES.ORE_ID, ORE_NAME, UNITS_TO_REFINE, ORE_VOLUME, PRICE, ORE_GROUP";

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsOre = Public_Variables.DBCommand.ExecuteReader();

                    while (rsOre.Read())
                    {
                        TempOre.ID = rsOre.GetInt32(0);
                        TempOre.Name = rsOre.GetString(1);
                        TempOre.RefineUnits = rsOre.GetInt32(2);
                        TempOre.Volume = rsOre.GetDouble(3);
                        TempOre.Price = rsOre.GetDouble(4);
                        TempOre.Group = Ore.OreGroup;
                        TempOre.BaseName = Ore.OreName;
                        ProcessingSkill = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(Public_Variables.GetOreProcessingSkillName(Ore.OreName));
                        // Set the refining rate based on ice or ore
                        if (Ore.OreGroup == "Ice")
                        {
                            TempOre.RefineRate = Refinery.GetFacilility().IceFacilityRefineRate;
                        }
                        else
                        {
                            TempOre.RefineRate = Refinery.GetFacilility().OreFacilityRefineRate;
                        }

                        Refinery.GetFacilility().MaterialMultiplier = TempOre.RefineRate;

                        ReturnRefinedItemsList = new List<string>();

                        // Refine but use a double for material quantities to get partial refining value to be more exact
                        double argTotalYield = (double)default;
                        double argReprocessingFees = (double)default;
                        TempOre.RefinedOreList = Refinery.Reprocess(TempOre.ID, Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3385L), Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3389L), ProcessingSkill, TempOre.RefineUnits, false, new Public_Variables.BrokerFeeInfo(), ref argTotalYield, ref argReprocessingFees, true, ref ReturnRefinedItemsList);

                        // For Ice, if the isotopes don't exist in the returned list for what we need in the material list, don't add it
                        if (Ore.OreGroup == "Ice" & !(BuildMaterialList.SearchListbyName("Isotopes") == null))
                        {
                            foreach (var Item in ReturnRefinedItemsList)
                            {
                                if (Item.Contains("Isotopes"))
                                {
                                    // Check it
                                    if (BuildMaterialList.SearchListbyName(Item, true) == null)
                                    {
                                        goto NextOre;
                                    }
                                }
                            }
                        }

                        // Save the value for use in minimize
                        switch (OreConversionSettings.MinimizeOn ?? "")
                        {
                            case "Refine Price":
                                {
                                    TempOre.MinimizeOnValue = TempOre.RefinedOreList.GetTotalMaterialsCost();
                                    break;
                                }
                            case "Ore/Ice Price":
                                {
                                    TempOre.MinimizeOnValue = rsOre.GetDouble(4);
                                    break;
                                }
                            case "Ore/Ice Volume":
                                {
                                    TempOre.MinimizeOnValue = rsOre.GetDouble(3);
                                    break;
                                }
                        }

                        // Add any refined minerals to the list not already added
                        foreach (var Item in ReturnRefinedItemsList)
                        {
                            if (!RefinedItemsList.Contains(Item) & !withBlock.IgnoreItems.Contains(Item))
                            {
                                RefinedItemsList.Add(Item);
                            }
                        }

                        OreColumnIndex += 1;
                        OreData.Add(OreColumnIndex, TempOre);
                    }

                NextOre:
                    ;

                    rsOre.Close();
                }
            }

            if (OreData.Count == 0)
            {
                // If no ores match what we need, then just return the main list
                return BuildMaterialList;
            }

            // Initialize model
            LpSolve.Init();
            OreLP = LpSolve.make_lp(0, OreData.Count - 1);

            OreColumnIndex = 1;

            // Start with adding the column names
            var loopTo = OreData.Count;
            for (OreColumnIndex = 1; OreColumnIndex <= loopTo; OreColumnIndex++)
                OreLP.set_col_name(OreColumnIndex, OreData[OreColumnIndex].Name);

            // Add the rows
            OreLP.set_add_rowmode(true); // makes building the model faster if it is done rows by row

            // Number of rows is based on any items in the refined items list
            OreColumns = new int[OreData.Count];
            MineralRows = new double[OreData.Count];
            Outputs = new double[OreData.Count];

            // Loop through each refined item and search each ore data refined list for the value and add it to the row
            foreach (var Item in RefinedItemsList)
            {
                ColumnIndex = 0; // Reset the row column index each new item
                var loopTo1 = OreData.Count;
                for (OreColumnIndex = 1; OreColumnIndex <= loopTo1; OreColumnIndex++)
                {
                    OreColumns[ColumnIndex] = ColumnIndex + 1;
                    MineralRows[ColumnIndex] = OreData[OreColumnIndex].RefinedOreList.SearchListbyName(Item).GetDQuantity(); // Search for the value and add
                    ColumnIndex += 1;
                }

                TempMaterial = BuildMaterialList.SearchListbyName(Item);

                // Add the rows to lpsolve after looking up the value needed
                if (!(TempMaterial == null))
                {
                    OreLP.add_constraintex(ColumnIndex, MineralRows, OreColumns, lpsolve_constr_types.GE, TempMaterial.GetQuantity());
                }
            }

            OreLP.set_add_rowmode(false); // rowmode should be turned off again when done building the model

            // Now set the objective function to minimize on
            ColumnIndex = 0; // Reset the row column index each new item
            var loopTo2 = OreData.Count;
            for (OreColumnIndex = 1; OreColumnIndex <= loopTo2; OreColumnIndex++)
            {
                OreColumns[ColumnIndex] = ColumnIndex + 1;
                MineralRows[ColumnIndex] = OreData[OreColumnIndex].MinimizeOnValue; // Search for the value and add
                ColumnIndex += 1;
            }

            OreLP.set_obj_fnex(ColumnIndex, MineralRows, OreColumns); // Add the minimize row to lpsolve 
            OreLP.set_minim(); // Set the object direction to minimize

            // Let lpsolve calculate a solution
            OreLPReturn = OreLP.solve();

            OreLP.get_variables(Outputs); // Get the output values for each column name

            // Process for returning the final new list with ores
            Material MatLookup;
            var RefinedMaterials = new Materials();
            double ReturnRefineryFee = 0d;

            // Now, for each refined item we converted, remove it from the material list sent
            foreach (var Item in RefinedItemsList)
            {
                // Save the original amounts
                MatLookup = BuildMaterialList.SearchListbyName(Item);
                ExcessMaterials.InsertMaterial(MatLookup);
                BuildMaterialList.RemoveMaterial(MatLookup);
            }

            // Add all the items we converted in LP Solve
            for (int CI = 1, loopTo3 = OreData.Count; CI <= loopTo3; CI++)
            {
                {
                    var withBlock1 = OreData[CI];
                    OutputQuantity = (long)Math.Round(Math.Ceiling(Outputs[CI - 1])) * withBlock1.RefineUnits;
                    if (OutputQuantity != 0L)
                    {
                        BuildMaterialList.InsertMaterial(new Material(withBlock1.ID, withBlock1.Name, withBlock1.Group, OutputQuantity, withBlock1.Volume, withBlock1.Price, "", ""));

                        // Refine this to calculate excess minerals
                        if (withBlock1.Group == "Ice")
                        {
                            ProcessingSkill = Public_Variables.SelectedCharacter.Skills.GetSkillLevel("Ice Processing");
                        }
                        else
                        {
                            ProcessingSkill = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(withBlock1.BaseName + " Processing");
                        }

                        // Set the correct refining rate
                        Refinery.GetFacilility().MaterialMultiplier = withBlock1.RefineRate;

                        // Insert the refined materials for totals later
                        double argTotalYield1 = (double)default;
                        List<string> argRefinedMineralsList = null;
                        RefinedMaterials.InsertMaterialList(Refinery.Reprocess(withBlock1.ID, Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3385L), Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3389L), ProcessingSkill, OutputQuantity, false, new Public_Variables.BrokerFeeInfo(), ref argTotalYield1, ref ReturnRefineryFee, RefinedMineralsList: ref argRefinedMineralsList).GetMaterialList());
                        // Get the total cost to refine
                        ReprocessingUsage += ReturnRefineryFee;

                    }
                }
            }

            // Finaly adjust the excess materials
            // Refined materials from this ore we solved for should be greater than or equal to what is needed, so just subtract all minerals from the totals needed
            foreach (var mat in ExcessMaterials.GetMaterialList())
            {
                MatLookup = RefinedMaterials.SearchListbyName(mat.GetMaterialName());
                if (!(MatLookup == null))
                {
                    // Adjust the quantity in the excess material list
                    mat.SetQuantity(MatLookup.GetQuantity() - mat.GetQuantity());
                }
            }

            return BuildMaterialList;

        }

    }
}