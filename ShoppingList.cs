using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class ShoppingList : ICloneable
    {

        // Master Lists of materials to display. These are single lists that are updated when deleting quantity or full items
        private List<ShoppingListItem> TotalItemList; // This is the total list of items, with orginal values - not updated
        private Materials TotalBuyList; // Buy mats
        private BuiltItemList TotalBuildList; // Build mats (components)
        private Materials TotalInventionMats; // All Invention/RE materials used
        private Materials TotalCopyMats; // All the copy materials needed to make copies to invent

        // Use onhandlist of materials so we can keep track of user entries (of calculations they make based on mats on hand) 
        public Materials OnHandMatList = new Materials();
        public Materials OnHandComponentList = new Materials();

        // Price data
        private double AdditionalCosts; // For any additional costs added on the shopping list form
        private double MaterialsBrokerFee; // For the total broker fee for buying the materials in the list
        private double TotalListUsage; // Total of all usage values for the items in the list
        private double TotalListMarketPrice; // Total market price of everything in the list
        private double TotalListCost; // Total cost of everything in the list mats (with invention/copy costs) + usage + taxes + fees
        private double TotalListBuildTime; // Total time to build the items in the list in seconds
        private double TotalListInventionCost; // Total of all the invention materials in the list
        private double TotalListCopyCost; // Total of all the copy materials in the list

        protected ShoppingListItem ItemToFind;
        protected string ProfitItemtoFind;

        public ShoppingList()
        {

            Clear();

        }

        public void Clear()
        {

            TotalItemList = new List<ShoppingListItem>();

            TotalBuildList = new BuiltItemList();
            TotalBuyList = new Materials();

            TotalInventionMats = new Materials();
            TotalCopyMats = new Materials();

            AdditionalCosts = 0d;
            MaterialsBrokerFee = 0d;
            TotalListUsage = 0d;
            TotalListMarketPrice = 0d;
            TotalListCost = 0d;

            ItemToFind = null;

            // Reset onhand mats lists
            OnHandMatList = new Materials();
            OnHandComponentList = new Materials();

        }

        #region Update Shopping List Functions

        // Removes or updates the item quantity and all mats associated with that item from the full list - i.e. Anshar
        public void UpdateShoppingItemQuantity(ShoppingListItem SentItem, long UpdateItemQuantity)
        {
            ShoppingListItem FoundItem;
            BuiltItem FoundBuildItem;
            var TempBuiltItem = new BuiltItem();
            long UpdatedRunQuantity;
            var BuiltComponents = new BuiltItemList();

            // First, see if there are any other items in the list, if this is the only one and the quantity is 0 then just clear all lists and leave
            if (UpdateItemQuantity <= 0L & TotalItemList.Count == 1 & (TotalItemList[0].Name ?? "") == (SentItem.Name ?? ""))
            {
                Clear();
                return;
            }

            // Look for the item
            ItemToFind = SentItem;
            FoundItem = TotalItemList.Find(FindItem);

            // Remove or update quantity for materials, built items, RE and invention mats
            // Check the component list of the BP first, if we are building it, then update the number for built items, else we are buying it and update that
            if (FoundItem is not null)
            {
                // Look at built items first, then check materials only
                if (!(FoundItem.BPBuiltItems == null))
                {
                    {
                        ref var withBlock = ref FoundItem.BPBuiltItems;
                        for (int i = 0, loopTo = withBlock.GetBuiltItemList().Count - 1; i <= loopTo; i++)
                        {
                            // Make sure the item exists (might have been deleted already in the main list) before updating
                            // Find the built item in the build list for this item
                            TotalBuildList.SetItemToFind(withBlock.GetBuiltItemList()[i]);
                            FoundBuildItem = TotalBuildList.GetBuiltItemList().Find(TotalBuildList.FindBuiltItem);

                            if (FoundBuildItem is not null)
                            {
                                // Copy current built item info
                                TempBuiltItem = new BuiltItem();
                                TempBuiltItem = (BuiltItem)FoundBuildItem.Clone();

                                // Use group name as facility location
                                var UpdateMaterial = new Material(TempBuiltItem.ItemTypeID, TempBuiltItem.ItemName, TempBuiltItem.ManufacturingFacility.FacilityName, TempBuiltItem.ItemQuantity, TempBuiltItem.ItemVolume, 0d, TempBuiltItem.BuildME.ToString(), TempBuiltItem.BuildTE.ToString(), true);

                                // Figure out how many runs we need to do of this component item for the updated quantity of the main item
                                long argRefMatQuantity = 0L;
                                UpdatedRunQuantity = GetUpdatedQuantity("Build", FoundItem, UpdateItemQuantity, UpdateMaterial, true, TempBuiltItem.PortionSize, RefMatQuantity: ref argRefMatQuantity);

                                // Update built item name with runs we did to get this quantity
                                TempBuiltItem.ItemName = Public_Variables.UpdateItemNamewithRuns(TempBuiltItem.ItemName, (long)Math.Round(Math.Ceiling(UpdatedRunQuantity / (double)TempBuiltItem.PortionSize)));

                                // Need to update to the quantity sent in the built item list
                                UpdateShoppingBuiltItemQuantity(ref TempBuiltItem, UpdatedRunQuantity);

                            }
                        }
                    }
                }

                // Now look at the materials
                if (!(FoundItem.BPMaterialList == null))
                {
                    {
                        ref var withBlock1 = ref FoundItem.BPMaterialList;
                        for (int i = 0, loopTo1 = withBlock1.GetMaterialList().Count - 1; i <= loopTo1; i++)
                        {
                            // Look at buy items
                            if (withBlock1.GetMaterialList()[i].GetBuildItem() == false)
                            {
                                // Make sure the item exists (might have been deleted already in the main list) before updating
                                if (!(TotalBuyList.SearchListbyName(withBlock1.GetMaterialList()[i].GetMaterialName()) == null))
                                {
                                    long argRefMatQuantity1 = 0L;
                                    UpdatedRunQuantity = GetUpdatedQuantity("Buy", FoundItem, UpdateItemQuantity, withBlock1.GetMaterialList()[i], true, RefMatQuantity: ref argRefMatQuantity1);
                                    // Need to update to the quantity sent in the Buy list
                                    UpdateShoppingBuyQuantity(withBlock1.GetMaterialList()[i].GetMaterialName(), UpdatedRunQuantity);
                                }
                            }

                            // Update the quantity of the material in the total list too, but needs to be for each individual material
                            long x = GetNewMatQuantity(FoundItem, IndustryActivities.Manufacturing, withBlock1.GetMaterialList()[i], UpdateItemQuantity);
                            withBlock1.GetMaterialList()[i].SetQuantity(x);
                        }
                    }
                }

                // Update Buy List with invention mats
                if (!(FoundItem.InventionMaterials == null))
                {
                    if (!(FoundItem.InventionMaterials.GetMaterialList() == null))
                    {
                        {
                            ref var withBlock2 = ref FoundItem.InventionMaterials; // Update all base materials for this item first
                            var TempInventionMaterials = new Materials();
                            for (int i = 0, loopTo2 = withBlock2.GetMaterialList().Count - 1; i <= loopTo2; i++)
                            {
                                // Make sure the material exists (might have been deleted already in the main list) before updating
                                if (!(TotalBuyList.SearchListbyName(withBlock2.GetMaterialList()[i].GetMaterialName()) == null))
                                {
                                    // Need to update to the quantity sent in the Buy List
                                    long argRefMatQuantity2 = 0L;
                                    UpdatedRunQuantity = GetUpdatedQuantity("Invention", FoundItem, UpdateItemQuantity, withBlock2.GetMaterialList()[i], true, RefMatQuantity: ref argRefMatQuantity2);

                                    UpdateShoppingBuyQuantity(withBlock2.GetMaterialList()[i].GetMaterialName(), UpdatedRunQuantity);
                                    // Update this material in the item's invention list for copy/paste function
                                    if (UpdatedRunQuantity > 0L)
                                    {
                                        // Need to copy, remove, update, then add to update the volumes and prices of the material lists
                                        Material TempMat;
                                        TempMat = (Material)TotalInventionMats.SearchListbyName(withBlock2.GetMaterialList()[i].GetMaterialName()).Clone();
                                        TempInventionMaterials.InsertMaterial(TempMat);
                                    }
                                }
                            }

                            // Reset the Invention Materials for this item
                            FoundItem.InventionMaterials = TempInventionMaterials;

                        }
                    }
                }

                // Update buy list with copy materials
                if (!(FoundItem.CopyMaterials == null))
                {
                    if (!(FoundItem.CopyMaterials.GetMaterialList() == null))
                    {
                        {
                            ref var withBlock3 = ref FoundItem.CopyMaterials; // Update all base materials for this item first
                            var TempCopyMaterials = new Materials();
                            for (int i = 0, loopTo3 = withBlock3.GetMaterialList().Count - 1; i <= loopTo3; i++)
                            {
                                // Make sure the material exists (might have been deleted already in the main list) before updating
                                if (!(TotalBuyList.SearchListbyName(withBlock3.GetMaterialList()[i].GetMaterialName()) == null))
                                {
                                    // Need to update to the quantity sent in the Buy List
                                    long argRefMatQuantity3 = 0L;
                                    UpdatedRunQuantity = GetUpdatedQuantity("Copying", FoundItem, UpdateItemQuantity, withBlock3.GetMaterialList()[i], true, RefMatQuantity: ref argRefMatQuantity3);

                                    UpdateShoppingBuyQuantity(withBlock3.GetMaterialList()[i].GetMaterialName(), UpdatedRunQuantity);
                                    // Update this material in the item's invention list for copy/paste function
                                    if (UpdatedRunQuantity <= 0L)
                                    {
                                        TotalCopyMats.RemoveMaterial(withBlock3.GetMaterialList()[i]);
                                    }
                                    else
                                    {
                                        // Need to copy, remove, update, then add to update the volumes and prices of the material lists
                                        Material TempMat;
                                        TempMat = (Material)TotalCopyMats.SearchListbyName(withBlock3.GetMaterialList()[i].GetMaterialName()).Clone();
                                        TempCopyMaterials.InsertMaterial(TempMat);
                                    }
                                }
                            }

                            // Reset the Invention Materials for this item
                            FoundItem.CopyMaterials = TempCopyMaterials;

                        }
                    }
                }

                // Need to increment or decrement the new item quantity and volume, the rest of the mats and components will be updated above
                if (UpdateItemQuantity == 0L)
                {
                    TotalItemList.Remove(FoundItem);
                }
                else
                {
                    // This is simplistic but the easiest way to get an approximate value for a change in the shopping list - won't be exact!
                    FoundItem.BuildVolume = FoundItem.BuildVolume / FoundItem.Runs * UpdateItemQuantity;
                    // FoundItem.TotalMaterialCost = FoundItem.TotalMaterialCost / FoundItem.Quantity * UpdateItemQuantity
                    FoundItem.TotalUsage = FoundItem.TotalUsage / FoundItem.Runs * UpdateItemQuantity;
                    FoundItem.TotalItemMarketCost = FoundItem.TotalItemMarketCost / FoundItem.Runs * UpdateItemQuantity;
                    FoundItem.TotalBuildTime = FoundItem.TotalBuildTime / FoundItem.Runs * UpdateItemQuantity;
                    // Update the invention jobs if they update this later
                    if (FoundItem.InventionJobs != 0L)
                    {
                        FoundItem.InventionJobs = (int)Math.Round(Math.Ceiling(FoundItem.AvgInvRunsforSuccess * Math.Ceiling(UpdateItemQuantity / (double)FoundItem.InventedRunsPerBP)));
                        // How many bps do we need to make?
                        FoundItem.NumBPs = (int)Math.Round(Math.Ceiling(UpdateItemQuantity / (double)FoundItem.InventedRunsPerBP));
                    }
                    // Finally update the quantity
                    FoundItem.Runs = UpdateItemQuantity;
                }
            }

        }

        // Removes or updates a built item quantity from the build list and its materials from the material list - i.e. remove particle accelerator and raw mats from item - Hammerhead II
        public void UpdateShoppingBuiltItemQuantity(ref BuiltItem SentItem, long UpdateItemQuantity)
        {
            BuiltItem FoundItem;
            var UpdatedQuantity = default(long); // This is the final mat quantity for updating the shopping buy/build list ammount
            var RefMatQuantity = default(long); // This is the reference for materials we send in the update quantity - will be the mat quantity for that built item

            var UpdateItem = new BuiltItem();
            var UpdateItemMatList = new Materials();
            var UpdateBuiltItemMatList = new Materials();
            var UpdateBuildList = new List<BuiltItem>();
            var RefBuildList = new List<BuiltItem>();
            Material InsertMat;
            var InsertBuiltItem = new BuiltItem();
            var BuiltComponentList = new List<BuiltItem>();
            var ShoppingItem = new ShoppingListItem();
            Material UpdateMaterial;

            string SQL = "";
            SQLiteDataReader rsMatCheck;

            Application.DoEvents();

            // Task here: Update build list with correct quantity, and then the buy list with the correct material quantities

            // First look up the item and the mats used to build it in the saved list
            TotalBuildList.SetItemToFind(SentItem);
            FoundItem = TotalBuildList.GetBuiltItemList().Find(TotalBuildList.FindBuiltItem);

            // Update the materials in the built list, take total number, divide mats by it and then multiply by quantity sent
            if (!(FoundItem == null))
            {
                {
                    ref var withBlock = ref FoundItem.BuildMaterials;
                    for (int i = 0, loopTo = withBlock.GetMaterialList().Count - 1; i <= loopTo; i++)
                    {
                        // Make sure the item exists (might have been deleted already in the main list) before updating
                        if (!(TotalBuyList.SearchListbyName(withBlock.GetMaterialList()[i].GetMaterialName()) == null))
                        {
                            // Make sure the material is part of the build materials for the built item
                            // Look up mat quantities for this BP
                            SQL = "SELECT 'X' FROM ALL_BLUEPRINT_MATERIALS ";
                            SQL += "WHERE PRODUCT_ID = " + FoundItem.ItemTypeID + " AND MATERIAL_ID = " + withBlock.GetMaterialList()[i].GetMaterialTypeID() + " AND ACTIVITY IN (1,11)";

                            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                            rsMatCheck = Public_Variables.DBCommand.ExecuteReader();

                            if (rsMatCheck.HasRows)
                            {
                                // Set the values we need to get updated quantity
                                ShoppingItem.Name = FoundItem.ItemName;
                                ShoppingItem.TypeID = FoundItem.ItemTypeID;
                                ShoppingItem.ManufacturingFacility = FoundItem.ManufacturingFacility;
                                ShoppingItem.IncludeActivityCost = FoundItem.IncludeActivityCost;
                                ShoppingItem.IncludeActivityTime = FoundItem.IncludeActivityTime;
                                ShoppingItem.IncludeActivityUsage = FoundItem.IncludeActivityUsage;
                                ShoppingItem.ItemME = FoundItem.BuildME;
                                ShoppingItem.ItemTE = FoundItem.BuildTE;
                                ShoppingItem.Runs = FoundItem.ItemQuantity;
                                ShoppingItem.PortionSize = FoundItem.PortionSize;

                                // Blank these out for now if we use them later
                                ShoppingItem.InventionJobs = 0L;
                                ShoppingItem.InventedRunsPerBP = 0;
                                ShoppingItem.AvgInvRunsforSuccess = 0d;
                                ShoppingItem.NumBPs = 1; // Built items (components) are always one bp for now

                                UpdateMaterial = (Material)withBlock.GetMaterialList()[i].Clone();

                                // Get the new quantity for each material to build this item - which will be in the buy list
                                UpdatedQuantity = GetUpdatedQuantity("Buy", ShoppingItem, UpdateItemQuantity, UpdateMaterial, false, 1L, ref RefMatQuantity);

                                // Need to update to the quantity sent in the Buy List
                                UpdateShoppingBuyQuantity(withBlock.GetMaterialList()[i].GetMaterialName(), UpdatedQuantity);

                                // Save the updated materials for the build list with the difference
                                if (UpdatedQuantity > 0L)
                                {
                                    {
                                        var withBlock1 = withBlock.GetMaterialList()[i];
                                        // Need to save the new value we want for this item, not the new quantity, to update the other lists with 
                                        InsertMat = new Material(withBlock1.GetMaterialTypeID(), withBlock1.GetMaterialName(), withBlock1.GroupName, RefMatQuantity, withBlock1.GetTotalVolume(), 0d, "", "");
                                    }

                                    UpdateItemMatList.InsertMaterial(InsertMat);

                                }
                            }

                            rsMatCheck.Close();

                        }
                    }
                }

                // Now update the materials from any component items that this item may have built for the found item
                for (int i = 0, loopTo1 = FoundItem.ComponentBuildList.Count - 1; i <= loopTo1; i++)
                {
                    var RefBuiltItem = new BuiltItem();

                    // Look up how many runs of the component we need
                    if (UpdateItemQuantity == 0L)
                    {
                        // Need to update the quantity in the build list to delete the total we needed here - so what's in build list now minus this quantity
                        var FoundBuildItem = new BuiltItem();
                        // Look up current built items
                        TotalBuildList.SetItemToFind(FoundItem.ComponentBuildList[i]);
                        FoundBuildItem = TotalBuildList.GetBuiltItemList().Find(TotalBuildList.FindBuiltItem);

                        if (FoundBuildItem is not null)
                        {
                            UpdatedQuantity = FoundBuildItem.ItemQuantity - FoundItem.ComponentBuildList[i].ItemQuantity;
                        }
                        else
                        {
                            UpdatedQuantity = 0L;
                        }

                        if (UpdatedQuantity < 0L)
                        {
                            UpdatedQuantity = 0L;
                        }
                    }

                    else
                    {
                        // Need to calculate the new amount
                        SQL = "SELECT QUANTITY FROM ALL_BLUEPRINT_MATERIALS ";
                        SQL += "WHERE BLUEPRINT_ID = " + FoundItem.BPTypeID;
                        SQL += " AND ACTIVITY IN (1,11)";
                        SQL += " AND MATERIAL_ID = " + FoundItem.ComponentBuildList[i].ItemTypeID;

                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                        rsMatCheck = Public_Variables.DBCommand.ExecuteReader();

                        if (rsMatCheck.Read())
                        {
                            // Now adjust the quantity based on the ME bonus and runs for the original bp
                            long Runs = (int)Math.Round(Math.Ceiling(UpdateItemQuantity / (double)FoundItem.PortionSize));
                            double MEBonus = GetMEBonus(FoundItem.BuildME, FoundItem.ManufacturingFacility.MaterialMultiplier);
                            long TempBuildQuantity = 0L;

                            RefBuiltItem = (BuiltItem)FoundItem.ComponentBuildList[i].Clone();

                            BuiltItem FoundbuiltItem;
                            long ListmatQuantity;
                            TotalBuildList.SetItemToFind(RefBuiltItem);

                            FoundbuiltItem = TotalBuildList.GetBuiltItemList().Find(TotalBuildList.FindBuiltItem);

                            if (FoundbuiltItem is not null)
                            {
                                ListmatQuantity = FoundbuiltItem.ItemQuantity;
                            }
                            else
                            {
                                ListmatQuantity = 0L;
                            }

                            TempBuildQuantity = (long)Math.Round(Math.Max(Runs, Math.Ceiling(Math.Round(Runs * rsMatCheck.GetInt64(0) * MEBonus, 2))));

                            // Figure out what we needed prior to update
                            long OldMatQuantity = (long)Math.Round(Math.Max(SentItem.BPRuns, Math.Ceiling(Math.Round(SentItem.BPRuns * rsMatCheck.GetInt64(0) * MEBonus, 2))));

                            // Remove what was in the list prior (old mat quantity)
                            UpdatedQuantity = ListmatQuantity - OldMatQuantity;

                            if (UpdatedQuantity < 0L)
                            {
                                UpdatedQuantity = 0L;
                            }

                            // Add what we need now
                            UpdatedQuantity += TempBuildQuantity;

                            // UpdatedQuantity = GetUpdatedQuantity("Buy", FoundItem, UpdateItemQuantity, UpdateMaterial, False, 1, RefMatQuantity)

                            // Save what we need in the sent item reference
                            RefBuiltItem.ItemQuantity = TempBuildQuantity;
                            RefBuiltItem.BPRuns = (long)Math.Round(Math.Ceiling(TempBuildQuantity / (double)RefBuiltItem.PortionSize));
                            RefBuiltItem.ItemName = Public_Variables.UpdateItemNamewithRuns(RefBuiltItem.ItemName, RefBuiltItem.BPRuns);

                            rsMatCheck.Close();

                        }
                    }

                    // Update this component in the main built item list with the new quantity
                    var tmp = FoundItem.ComponentBuildList;
                    var argSentItem = tmp[i];
                    UpdateShoppingBuiltItemQuantity(ref argSentItem, UpdatedQuantity);
                    tmp[i] = argSentItem;

                    // Add the item with the new quantity to the reference build list
                    UpdateBuildList.Add(RefBuiltItem);

                }

                // Save the base data
                UpdateItem = new BuiltItem();
                UpdateItem = (BuiltItem)FoundItem.Clone();
                long BPRuns = (long)Math.Round(Math.Ceiling(UpdateItemQuantity / (double)FoundItem.PortionSize));

                // Update built item name with runs we did to get this quantity
                UpdateItem.ItemName = Public_Variables.UpdateItemNamewithRuns(UpdateItem.ItemName, BPRuns);

                // Update the new built list quantity and runs
                UpdateItem.ItemQuantity = UpdateItemQuantity;
                UpdateItem.BPRuns = BPRuns;
                // Update the new built list material list, with updated quantities
                UpdateItem.BuildMaterials = UpdateItemMatList;
                // Update the component build list as well with updated quantities
                UpdateItem.ComponentBuildList = UpdateBuildList;

                // Update the data of the build list item
                TotalBuildList.RemoveBuiltItem(FoundItem); // Remove the old one

                if (UpdateItemQuantity != 0L)
                {
                    TotalBuildList.AddBuiltItem(UpdateItem); // Add the updated one
                }

                // Update the sent item reference list
                SentItem.ComponentBuildList = RefBuildList;

            }

        }

        // Removes or updates the quantity of material in all lists of materials. i.e. Tritanium
        public void UpdateShoppingBuyQuantity(string SentItemName, long Quantity)
        {

            if (!(TotalBuyList == null))
            {
                if (!(TotalBuyList.GetMaterialList() == null))
                {

                    if (Quantity <= 0L)
                    {
                        // We just delete the item (all quantity) from the total materials list
                        TotalBuyList.RemoveMaterial(TotalBuyList.SearchListbyName(SentItemName));
                        // Also remove from the total copy and invention lists
                        TotalInventionMats.RemoveMaterial(TotalInventionMats.SearchListbyName(SentItemName));
                        TotalCopyMats.RemoveMaterial(TotalCopyMats.SearchListbyName(SentItemName));
                    }
                    else
                    {
                        Material TempMaterial;
                        var FindMaterial = TotalBuyList.SearchListbyName(SentItemName);
                        // Catch if item isn't in the list to what was sent
                        if (!(FindMaterial == null))
                        {
                            TempMaterial = (Material)FindMaterial.Clone();
                            TotalBuyList.RemoveMaterial(TempMaterial);

                            // Set the new quantity
                            TempMaterial.SetQuantity(Quantity);

                            // Re-add so the prices are updated
                            TotalBuyList.InsertMaterial(TempMaterial);
                        }

                        // Update Invention mats (if there)
                        FindMaterial = TotalInventionMats.SearchListbyName(SentItemName);

                        // Catch if item isn't in the list to what was sent
                        if (!(FindMaterial == null))
                        {
                            TempMaterial = (Material)FindMaterial.Clone();
                            TotalInventionMats.RemoveMaterial(TempMaterial);

                            // Set the new quantity
                            TempMaterial.SetQuantity(Quantity);

                            // Re-add so the prices are updated
                            TotalInventionMats.InsertMaterial(TempMaterial);
                        }

                        // Update Copy mats (if there)
                        FindMaterial = TotalCopyMats.SearchListbyName(SentItemName);

                        // Catch if item isn't in the list to what was sent
                        if (!(FindMaterial == null))
                        {
                            TempMaterial = (Material)FindMaterial.Clone();
                            TotalCopyMats.RemoveMaterial(TempMaterial);

                            // Set the new quantity
                            TempMaterial.SetQuantity(Quantity);

                            // Re-add so the prices are updated
                            TotalCopyMats.InsertMaterial(TempMaterial);
                        }

                    }
                }
            }

        }

        // Calculates the MEBonus based on inputs
        private double GetMEBonus(double ItemME, double FacilityMEModifier)
        {
            return (1d - ItemME / 100d) * FacilityMEModifier;
        }

        // Calculates the updated item quantity for updating lists
        // ProcessingType = Invention/RE/Build/Buy
        // CurrentItem = the current item in the shopping list for reference of old values
        // NewMaterialQuantity = new quantity of the current item (not runs) we want to update
        // UpdateMaterial = material of the item we are updating the quantity of based on the new item quantity
        // UpdateMaterialPortionSize = portion size of the bp for the update material
        // BuiltComponents = ref of any built components for the update material to save
        // ShoppingItem = flag if it's a built item (uses quantity) or a main shopping item from the list (uses runs for quantity)
        private long GetUpdatedQuantity(string ProcessingType, ShoppingListItem CurrentItem, long NewMaterialQuantity, Material UpdateMaterial, bool ShoppingItem, [Optional, DefaultParameterValue(1L)] long UpdateMaterialPortionSize, [Optional, DefaultParameterValue(0L)] ref long RefMatQuantity)
        {
            long UpdatedQuantity = 0L;
            long OnHandMats;
            var ListMatQuantity = default(long);
            int NumInventionJobs;
            long NewMatQuantity = 0L;
            long OldMatQuantity = 0L;

            // Set up the ME bonus and then calculate the new material quantity
            double MEBonus = 0d;
            long SingleRunQuantity = 0L;
            long ItemBPRuns = 0L;

            SQLiteDataReader rsMatQuantity;
            string SQL;
            string ActivitySQL;
            string ProductIDSQL;

            // Set how many runs of the main item bp are we going to do
            if (ShoppingItem)
            {
                ItemBPRuns = NewMaterialQuantity;
            }
            else
            {
                ItemBPRuns = (long)Math.Round(Math.Ceiling(NewMaterialQuantity / (double)CurrentItem.PortionSize));
            }

            switch (ProcessingType ?? "")
            {
                case "Invention":
                    {
                        ProductIDSQL = CurrentItem.BlueprintTypeID.ToString();
                        ActivitySQL = " AND ACTIVITY = 8";
                        break;
                    }
                case "Copying":
                    {
                        ProductIDSQL = CurrentItem.BlueprintTypeID.ToString();
                        ActivitySQL = " AND ACTIVITY = 5";
                        break;
                    }

                default:
                    {
                        ProductIDSQL = CurrentItem.TypeID.ToString();
                        ActivitySQL = " AND ACTIVITY IN (1,11)";
                        break;
                    }
            }

            // Look up the single run quantity for the material
            SQL = "SELECT QUANTITY FROM ALL_BLUEPRINT_MATERIALS LEFT OUTER JOIN ALL_BLUEPRINTS ON ALL_BLUEPRINTS.ITEM_ID = ALL_BLUEPRINT_MATERIALS.MATERIAL_ID ";
            SQL += "WHERE PRODUCT_ID = " + ProductIDSQL + " AND MATERIAL_ID = " + UpdateMaterial.GetMaterialTypeID();
            SQL += ActivitySQL;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsMatQuantity = Public_Variables.DBCommand.ExecuteReader();

            if (rsMatQuantity.Read())
            {
                SingleRunQuantity = rsMatQuantity.GetInt64(0);
                rsMatQuantity.Close();
            }
            else
            {
                // This item isn't required to build this bp, so exit
                rsMatQuantity.Close();
                RefMatQuantity = 0L;
                return UpdateMaterial.GetQuantity();
            }

            // Calc out final mat quantity
            if (ProcessingType == "Invention" | ProcessingType == "Copying")
            {

                ListMatQuantity = TotalBuyList.SearchListbyName(UpdateMaterial.GetMaterialName()).GetQuantity();

                // For invention materials, find out how many mats we need by calcuating the new value from the item runs and invention jobs per item
                if (NewMaterialQuantity <= 0L)
                {
                    // Easy case, just remove the update material quantity (add the negative)
                    NewMatQuantity = 0L;
                }
                else
                {
                    // Here, we need to figure out how many items per run to remove (3 inv mats per job, and remove 2 items, then remove 6 invention mats)
                    NumInventionJobs = (int)Math.Round(Math.Ceiling(CurrentItem.AvgInvRunsforSuccess * Math.Ceiling(ItemBPRuns / (double)CurrentItem.InventedRunsPerBP)));

                    // Update quantity based on invention calculations
                    NewMatQuantity = NumInventionJobs * SingleRunQuantity;
                    RefMatQuantity = NewMatQuantity;
                }
            }

            else if (ProcessingType == "Buy" | ProcessingType == "Build")
            {
                int UpdatedItemNumBPs = 0;

                // Figure out how many bps for the component we need 
                if (CurrentItem.InventionJobs != 0L)
                {
                    if (NewMaterialQuantity != 0L)
                    {
                        // Calc how many bps we will need based off of invention
                        UpdatedItemNumBPs = (int)Math.Round(Math.Ceiling(ItemBPRuns / (double)CurrentItem.InventedRunsPerBP));
                    }
                    else
                    {
                        // Deleting, so need the original amount and bps
                        UpdatedItemNumBPs = CurrentItem.NumBPs;
                    }
                }
                else
                {
                    // This isn't invented so just use the number of blueprints
                    UpdatedItemNumBPs = CurrentItem.NumBPs;

                    // Make sure we aren't building more bps than the quantity
                    if (UpdatedItemNumBPs > NewMaterialQuantity & NewMaterialQuantity != 0L)
                    {
                        UpdatedItemNumBPs = (int)NewMaterialQuantity;
                    }

                }

                long TempItemRuns = 0L;

                if (NewMaterialQuantity == 0L)
                {
                    // Deleting so use the original numbers to figure out what to remove later
                    TempItemRuns = CurrentItem.Runs;
                }
                else
                {
                    TempItemRuns = ItemBPRuns;
                }

                // Set the minimum per bp, shouldn't go over the runs per bp since the user sends in the total numbps they need
                int RunsPerLine = (int)Math.Round(Math.Floor(TempItemRuns / (double)UpdatedItemNumBPs));
                // Add these extra runs evenly (until gone) for each bp on runs per line
                int ExtraRuns = (int)(TempItemRuns - RunsPerLine * UpdatedItemNumBPs);

                // To track how many runs we have used in the batch setup
                long RunTracker = 0L;
                int AdjRunsperBP;
                // List to use later to calc values
                var BlueprintsRunList = new List<int>();

                // Fill a list of runs per bp
                for (int i = 0, loopTo = UpdatedItemNumBPs - 1; i <= loopTo; i++)
                {
                    // As we add the runs, adjust with extra runs proportionally until they are gone
                    if (ExtraRuns != 0)
                    {
                        // Since it's a fraction of a total batch run, this will always just be one until gone ** not right?
                        AdjRunsperBP = RunsPerLine + 1;
                        ExtraRuns = ExtraRuns - 1; // Adjust extra
                    }
                    else
                    {
                        // No extra runs, so just add the original runs now
                        AdjRunsperBP = RunsPerLine;
                    }

                    // Add the bp runs to the list to run
                    BlueprintsRunList.Add(AdjRunsperBP);

                }

                // Set the ME of the main item to calculate how many runs we need of the component
                MEBonus = GetMEBonus(CurrentItem.ItemME, CurrentItem.ManufacturingFacility.MaterialMultiplier);

                // Get the quantity from the correct list so we have the right total materials of all items using this material
                if (ProcessingType == "Buy")
                {
                    ListMatQuantity = TotalBuyList.SearchListbyName(UpdateMaterial.GetMaterialName()).GetQuantity();
                    // Figure out what we needed prior to update
                    long OldRuns;
                    if (ShoppingItem)
                    {
                        OldRuns = CurrentItem.Runs;
                    }
                    else
                    {
                        OldRuns = (long)Math.Round(Math.Ceiling(CurrentItem.Runs / (double)CurrentItem.PortionSize));
                    }

                    OldMatQuantity = (long)Math.Round(Math.Max(OldRuns, Math.Ceiling(Math.Round(OldRuns * SingleRunQuantity * MEBonus, 2))));
                }

                else if (ProcessingType == "Build")
                {
                    var TempBuildItem = new BuiltItem();
                    TempBuildItem.ItemTypeID = UpdateMaterial.GetMaterialTypeID();
                    TempBuildItem.BuildME = Conversions.ToInteger(UpdateMaterial.GetItemME());
                    TempBuildItem.ManufacturingFacility.FacilityName = UpdateMaterial.GroupName;

                    TotalBuildList.SetItemToFind(TempBuildItem);

                    BuiltItem FoundBuiltItem;
                    FoundBuiltItem = TotalBuildList.GetBuiltItemList().Find(TotalBuildList.FindBuiltItem);
                    if (FoundBuiltItem is not null)
                    {
                        ListMatQuantity = FoundBuiltItem.ItemQuantity;
                    }
                    else
                    {
                        ListMatQuantity = 0L;
                    }

                    // Figure out what we needed prior to update - adjust ME bonus for each blueprint need, not the total
                    // If Not ShoppingItem Then
                    OldMatQuantity = (long)Math.Round(Math.Max(CurrentItem.Runs, Math.Ceiling(Math.Round(CurrentItem.Runs * SingleRunQuantity * MEBonus, 2))));
                    // Else
                    // For i = 0 To BlueprintsRunList.Count - 1
                    // OldMatQuantity += CLng(Math.Max(BlueprintsRunList(i), Math.Ceiling(Math.Round(BlueprintsRunList(i) * SingleRunQuantity * MEBonus, 2))))
                    // Next
                    // End If

                }

                if (NewMaterialQuantity != 0L)
                {
                    // Now for each bp, calc the runs with the ME value - only do this for buy
                    if (ProcessingType == "Buy")
                    {
                        for (int i = 0, loopTo1 = BlueprintsRunList.Count - 1; i <= loopTo1; i++)
                            // Set the quantity required = max(runs,ceil(round(runs * baseQuantity * materialModifier,2)) and sum for each bp
                            NewMatQuantity += (long)Math.Round(Math.Max(BlueprintsRunList[i], Math.Ceiling(Math.Round(BlueprintsRunList[i] * SingleRunQuantity * MEBonus, 2))));
                    }
                    else
                    {
                        // Default to 1 run for build items to match the main blueprint function - this is the quantity of the new material for the item runs
                        NewMatQuantity = (long)Math.Round(Math.Max(TempItemRuns, Math.Ceiling(Math.Round(TempItemRuns * SingleRunQuantity * MEBonus, 2))));
                    }
                }

                else
                {
                    // Deleting, so no need to calculate, just reduce from what was in list for this item already
                    NewMatQuantity = 0L;
                }

                // Set the mat quantity for reference
                RefMatQuantity = NewMatQuantity;

            }

            // Update with onhand mats functionality
            if (UpdateMaterial.GetBuildItem()) // Building
            {
                // If entered, use this as the quantity to update to reflect that the user already entered a updated value
                OnHandMats = GetOnHandComponentQuantity(UpdateMaterial.GetMaterialName());
            }
            else // Buying
            {
                // If entered, use this as the quantity to update to reflect that the user already entered a updated value
                OnHandMats = GetOnHandMaterialQuantity(UpdateMaterial.GetMaterialName());
            }

            if (OnHandMats != 0L)
            {
                UpdatedQuantity = NewMatQuantity - OnHandMats;
            }
            else
            {
                UpdatedQuantity = NewMatQuantity;
            } // Quantity we need now

            // Decrease the mats in the shopping list from what we needed before then add what we need now
            UpdatedQuantity = ListMatQuantity - OldMatQuantity + UpdatedQuantity;

            // If the update caused it go below zero, reset
            if (UpdatedQuantity < 0L)
            {
                UpdatedQuantity = 0L;
            }

            return UpdatedQuantity;

        }

        private long GetNewMatQuantity(ShoppingListItem ItemData, IndustryActivities Activity, Material UpdateMaterial, long NewQuantity)
        {
            // Set up the ME bonus and then calculate the new material quantity
            double MEBonus = 0d;
            long SingleRunQuantity = 0L;
            SQLiteDataReader rsMatQuantity;
            string SQL;

            if (NewQuantity == 0L)
            {
                return 0L;
            }

            // Look up the cost for the material
            if (Activity == IndustryActivities.Invention | Activity == IndustryActivities.Copying)
            {
                SQL = "SELECT QUANTITY FROM ALL_BLUEPRINT_MATERIALS WHERE PRODUCT_ID = " + ItemData.BlueprintTypeID + " AND MATERIAL_ID = " + UpdateMaterial.GetMaterialTypeID();
                SQL += " AND ACTIVITY = 8";
            }
            else
            {
                SQL = "SELECT QUANTITY FROM ALL_BLUEPRINT_MATERIALS WHERE PRODUCT_ID = " + ItemData.TypeID + " AND MATERIAL_ID = " + UpdateMaterial.GetMaterialTypeID();
                SQL += " AND ACTIVITY IN (1,11)";
            }

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsMatQuantity = Public_Variables.DBCommand.ExecuteReader();
            rsMatQuantity.Read();

            SingleRunQuantity = rsMatQuantity.GetInt64(0);

            rsMatQuantity.Close();

            MEBonus = (1d - ItemData.ItemME / 100d) * ItemData.ManufacturingFacility.MaterialMultiplier;

            // Figure out how many bps we need now and apply the ME bonus for each bp and sum up
            int NewNumBPs;
            int NewRunsperBP;

            if (ItemData.InventionJobs != 0L)
            {
                if (ItemData.NumBPs == 1)
                {
                    NewNumBPs = (int)Math.Round(Math.Ceiling(NewQuantity / (double)ItemData.InventedRunsPerBP));
                }
                else
                {
                    NewNumBPs = (int)Math.Round(Math.Ceiling(NewQuantity / (ItemData.Runs / (double)ItemData.NumBPs)));
                }

                NewRunsperBP = (int)Math.Round(Math.Ceiling(NewQuantity / (double)NewNumBPs));
            }
            else
            {
                // This isn't invented so just use the number of blueprints
                NewNumBPs = ItemData.NumBPs;

                NewRunsperBP = (int)Math.Round(Math.Ceiling(NewQuantity / (double)NewNumBPs));

                // Make sure we aren't building more bps than the quantity
                if (NewNumBPs > NewQuantity)
                {
                    NewNumBPs = (int)NewQuantity;
                }

            }

            long NewMatQuantity = 0L;

            // For each bp, apply the me bonus and add up
            for (int i = 1, loopTo = NewNumBPs; i <= loopTo; i++)
                // Set the quantity: required = max(runs,ceil(round(runs * baseQuantity * materialModifier,2))
                NewMatQuantity += (long)Math.Round(Math.Max(NewRunsperBP, Math.Ceiling(Math.Round(NewRunsperBP * SingleRunQuantity * MEBonus, 2))));

            return NewMatQuantity;

        }

        #endregion

        // Inserts a full shopping list item into the list
        public void InsertShoppingItem(ShoppingListItem SentItem, BuiltItemList SentBuildList, Materials SentBuyList)
        {
            var FoundItem = new ShoppingListItem();
            var TempMats = new Materials();
            var TempItems = new BuiltItemList();
            var SearchBuiltItems = new BuiltItemList();

            // Look for the item
            ItemToFind = SentItem;
            FoundItem = TotalItemList.Find(FindItem);

            if (FoundItem is not null)
            {
                // If it's already in the list, then remove it, and add the sent items to it, then re-add
                TotalItemList.Remove(FoundItem);

                // Add the new data to this item
                // Increment items
                FoundItem.Runs = FoundItem.Runs + SentItem.Runs;
                FoundItem.BuildVolume = FoundItem.BuildVolume + SentItem.BuildVolume;
                FoundItem.TotalUsage = FoundItem.TotalUsage + SentItem.TotalUsage;
                FoundItem.TotalItemMarketCost = FoundItem.TotalItemMarketCost + SentItem.TotalItemMarketCost;
                FoundItem.TotalBuildTime = FoundItem.TotalBuildTime + SentItem.TotalBuildTime;
                FoundItem.NumBPs = FoundItem.NumBPs + SentItem.NumBPs; // Need to add the set of numbps used to the current
                FoundItem.InventionJobs = FoundItem.InventionJobs + SentItem.InventionJobs;

                // Increment BP Mat List
                if (!(SentItem.BPMaterialList == null))
                {
                    TempMats = new Materials();
                    TempMats = (Materials)FoundItem.BPMaterialList.Clone();
                    if (!(SentItem.BPMaterialList == null))
                    {
                        TempMats.InsertMaterialList(SentItem.BPMaterialList.GetMaterialList());
                    }

                    FoundItem.BPMaterialList = (Materials)TempMats.Clone();
                }
                else
                {
                    FoundItem.BPMaterialList = new Materials();
                    FoundItem.BPMaterialList = (Materials)FoundItem.BPMaterialList.Clone();
                }

                // Increment BP Build List
                if (!(SentItem.BPBuiltItems == null))
                {
                    TempItems = new BuiltItemList();
                    TempItems = (BuiltItemList)FoundItem.BPBuiltItems.Clone();
                    if (!(SentItem.BPBuiltItems == null))
                    {
                        for (int i = 0, loopTo = SentItem.BPBuiltItems.GetBuiltItemList().Count - 1; i <= loopTo; i++)
                            TempItems.AddBuiltItem(SentItem.BPBuiltItems.GetBuiltItemList()[i]);
                    }

                    FoundItem.BPBuiltItems = (BuiltItemList)TempItems.Clone();
                }
                else
                {
                    FoundItem.BPBuiltItems = new BuiltItemList();
                    FoundItem.BPBuiltItems = (BuiltItemList)FoundItem.BPBuiltItems.Clone();
                }

                // Update invention mats
                if (!(SentItem.InventionMaterials == null))
                {
                    FoundItem.InventionMaterials.InsertMaterialList(SentItem.InventionMaterials.GetMaterialList());
                }

                // Update copy mats
                if (!(SentItem.CopyMaterials == null))
                {
                    FoundItem.CopyMaterials.InsertMaterialList(SentItem.CopyMaterials.GetMaterialList());

                }

                // Now re-add, not a new item so number of items the same
                TotalItemList.Add(FoundItem);
            }

            else // Just add it
            {
                TotalItemList.Add(SentItem);
            }

            // Total Buy
            if (!(SentBuyList == null))
            {
                if (!(SentBuyList.GetMaterialList() == null))
                {
                    TotalBuyList.InsertMaterialList(SentBuyList.GetMaterialList());
                }
            }

            // Total Build - Need to rebuild every component as if we are only using one bp to get the numbers exact
            if (!(SentBuildList == null))
            {
                if (!(SentBuildList.GetBuiltItemList() == null))
                {
                    // Loop through everything and find all the items to update
                    for (int i = 0, loopTo1 = SentBuildList.GetBuiltItemList().Count - 1; i <= loopTo1; i++)
                    {
                        var FoundBuildItem = new BuiltItem();
                        // Look up current built items
                        TotalBuildList.SetItemToFind((BuiltItem)SentBuildList.GetBuiltItemList()[i].Clone());
                        FoundBuildItem = TotalBuildList.GetBuiltItemList().Find(TotalBuildList.FindBuiltItem);

                        // Rebuild with new quantity
                        if (FoundBuildItem is not null)
                        {
                            // With this item, update the quantity and rebuild for new materials list
                            {
                                var withBlock = SentBuildList.GetBuiltItemList()[i];
                                // Re-run with new quantity
                                int NewRuns = (int)Math.Round(Math.Ceiling((FoundBuildItem.ItemQuantity + withBlock.ItemQuantity) / (double)FoundBuildItem.PortionSize));


                                List<Public_Variables.BuildBuyItem> argBuildBuyList = null;
                                IndustryFacility argBPReprocessingFacility = null;
                                var TempBP = new Blueprint(withBlock.BPTypeID, NewRuns, withBlock.BuildME, withBlock.BuildTE, 1, SettingsVariables.UserBPTabSettings.ProductionLines, Public_Variables.SelectedCharacter, SettingsVariables.UserApplicationSettings, false, 0d, withBlock.ManufacturingFacility, withBlock.ManufacturingFacility, withBlock.ManufacturingFacility, withBlock.ManufacturingFacility, true, SettingsVariables.UserBPTabSettings.BuildT2T3Materials, true, BuildBuyList: ref argBuildBuyList, BPReprocessingFacility: ref argBPReprocessingFacility);

                                Public_Variables.BrokerFeeInfo BFI;
                                BFI.IncludeFee = (Public_Variables.BrokerFeeType)SettingsVariables.UserBPTabSettings.IncludeFees;
                                BFI.FixedRate = SettingsVariables.UserBPTabSettings.BrokerFeeRate;

                                TempBP.BuildItems(SettingsVariables.UserBPTabSettings.IncludeTaxes, BFI, true, SettingsVariables.UserBPTabSettings.IgnoreMinerals, SettingsVariables.UserBPTabSettings.IgnoreT1Item);

                                var InsertBuildItem = new BuiltItem();

                                InsertBuildItem.BuildMaterials = TempBP.GetRawMaterials();
                                InsertBuildItem.BPTypeID = TempBP.GetTypeID();
                                InsertBuildItem.ItemTypeID = TempBP.GetItemID();
                                InsertBuildItem.ItemName = Public_Variables.UpdateItemNamewithRuns(TempBP.GetItemName(), NewRuns);
                                InsertBuildItem.ItemQuantity = FoundBuildItem.ItemQuantity + withBlock.ItemQuantity;
                                InsertBuildItem.BuildME = TempBP.GetME();
                                InsertBuildItem.BuildTE = TempBP.GetTE();
                                InsertBuildItem.ItemVolume = TempBP.GetTotalItemVolume();
                                InsertBuildItem.BuildMaterials = TempBP.GetRawMaterials();
                                InsertBuildItem.ManufacturingFacility = TempBP.GetManufacturingFacility();
                                InsertBuildItem.IncludeActivityCost = TempBP.GetManufacturingFacility().IncludeActivityCost;
                                InsertBuildItem.IncludeActivityTime = TempBP.GetManufacturingFacility().IncludeActivityTime;
                                InsertBuildItem.IncludeActivityUsage = TempBP.GetManufacturingFacility().IncludeActivityUsage;
                                InsertBuildItem.PortionSize = TempBP.GetPortionSize();

                                // Remove the old record
                                TotalBuildList.RemoveBuiltItem(FoundBuildItem);
                                // Now add the updated item
                                TotalBuildList.AddBuiltItem(InsertBuildItem);

                            }
                        }
                        else
                        {
                            // Just add the new item
                            TotalBuildList.AddBuiltItem(SentBuildList.GetBuiltItemList()[i]);
                        }
                    }
                }
            }

            // Invention Materials
            if (!(SentItem.InventionMaterials == null))
            {
                TotalInventionMats.InsertMaterialList(SentItem.InventionMaterials.GetMaterialList());
            }

            // Copy Materials
            if (!(SentItem.CopyMaterials == null))
            {
                TotalCopyMats.InsertMaterialList(SentItem.CopyMaterials.GetMaterialList());
            }

            ItemToFind = null;

        }

        // Will update all the prices in the shopping list
        public void UpdateListPrices()
        {
            var TempBuyList = new Materials(); // Buy mats
            var TempBuildList = new BuiltItemList(); // Build mats (components)
            var TempInventionMats = new Materials(); // All Invention materials used
            var TempCopyMats = new Materials(); // All the copy materials used
            var TempBPMatList = new Materials(); // For the Total Item List

            Material TransferMaterial;
            BuiltItem TransferBuiltItem;

            // Basically take the materials from the current lists and put them into new lists with 0 prices to get them updated

            // Item List
            for (int i = 0, loopTo = TotalItemList.Count - 1; i <= loopTo; i++)
            {
                for (int j = 0, loopTo1 = TotalItemList[i].BPMaterialList.GetMaterialList().Count - 1; j <= loopTo1; j++)
                {
                    {
                        var withBlock = TotalItemList[i].BPMaterialList.GetMaterialList()[j];
                        TransferMaterial = new Material(withBlock.GetMaterialTypeID(), withBlock.GetMaterialName(), withBlock.GroupName, withBlock.GetQuantity(), withBlock.GetVolume(), 0d, withBlock.GetItemME(), withBlock.GetItemTE(), withBlock.GetBuildItem(), withBlock.GetItemType());
                    }

                    // Add to the temp list
                    TempBPMatList.InsertMaterial(TransferMaterial);
                }

                // Reset each BPMaterial list on each item
                TotalItemList[i].BPMaterialList = TempBPMatList;
            }

            // Buy List
            if (!(TotalBuyList.GetMaterialList() == null))
            {
                for (int i = 0, loopTo2 = TotalBuyList.GetMaterialList().Count - 1; i <= loopTo2; i++)
                {
                    {
                        var withBlock1 = TotalBuyList.GetMaterialList()[i];
                        TransferMaterial = new Material(withBlock1.GetMaterialTypeID(), withBlock1.GetMaterialName(), withBlock1.GroupName, withBlock1.GetQuantity(), withBlock1.GetVolume(), 0d, withBlock1.GetItemME(), withBlock1.GetItemTE(), withBlock1.GetBuildItem(), withBlock1.GetItemType());
                    }

                    // Add the material with new price to list
                    TempBuyList.InsertMaterial(TransferMaterial);

                }
            }

            // Reset List
            TotalBuyList = TempBuyList;

            // Invention List
            if (!(TotalInventionMats.GetMaterialList() == null))
            {
                for (int i = 0, loopTo3 = TotalInventionMats.GetMaterialList().Count - 1; i <= loopTo3; i++)
                {
                    {
                        var withBlock2 = TotalInventionMats.GetMaterialList()[i];
                        TransferMaterial = new Material(withBlock2.GetMaterialTypeID(), withBlock2.GetMaterialName(), withBlock2.GroupName, withBlock2.GetQuantity(), withBlock2.GetVolume(), 0d, withBlock2.GetItemME(), withBlock2.GetItemTE(), withBlock2.GetBuildItem(), withBlock2.GetItemType());
                    }

                    // Add the material with new price to list
                    TempInventionMats.InsertMaterial(TransferMaterial);

                }
            }

            // Reset List
            TotalInventionMats = TempInventionMats;

            // Copy List
            if (!(TotalCopyMats.GetMaterialList() == null))
            {
                for (int i = 0, loopTo4 = TotalCopyMats.GetMaterialList().Count - 1; i <= loopTo4; i++)
                {
                    {
                        var withBlock3 = TotalCopyMats.GetMaterialList()[i];
                        TransferMaterial = new Material(withBlock3.GetMaterialTypeID(), withBlock3.GetMaterialName(), withBlock3.GroupName, withBlock3.GetQuantity(), withBlock3.GetVolume(), 0d, withBlock3.GetItemME(), withBlock3.GetItemTE(), withBlock3.GetBuildItem(), withBlock3.GetItemType());
                    }

                    // Add the material with new price to list
                    TempCopyMats.InsertMaterial(TransferMaterial);

                }
            }

            // Reset List
            TotalCopyMats = TempCopyMats;

            // Build Item List
            if (TotalBuildList.GetBuiltItemList().Count != 0)
            {
                for (int i = 0, loopTo5 = TotalBuildList.GetBuiltItemList().Count - 1; i <= loopTo5; i++)
                {
                    // Copy the old data and reset the materials
                    TransferBuiltItem = new BuiltItem();
                    TransferBuiltItem = (BuiltItem)TotalBuildList.GetBuiltItemList()[i].Clone();
                    TransferBuiltItem.BuildMaterials = new Materials();

                    // Get the new material prices
                    if (!(TotalBuildList.GetBuiltItemList()[i].BuildMaterials.GetMaterialList() == null))
                    {
                        for (int j = 0, loopTo6 = TotalBuildList.GetBuiltItemList()[i].BuildMaterials.GetMaterialList().Count - 1; j <= loopTo6; j++)
                        {
                            {
                                var withBlock4 = TotalBuildList.GetBuiltItemList()[i].BuildMaterials.GetMaterialList()[j];
                                TransferMaterial = new Material(withBlock4.GetMaterialTypeID(), withBlock4.GetMaterialName(), withBlock4.GroupName, withBlock4.GetQuantity(), withBlock4.GetVolume(), 0d, withBlock4.GetItemME(), withBlock4.GetItemTE(), withBlock4.GetBuildItem(), withBlock4.GetItemType());
                            }
                            // Insert the mat to the item list
                            TransferBuiltItem.BuildMaterials.InsertMaterial(TransferMaterial);
                        }
                    }

                    // Add to the temp list
                    TempBuildList.AddBuiltItem(TransferBuiltItem);
                }
            }

            // Reset the list
            TotalBuildList = TempBuildList;

        }

        // Exports the shoppinglist data in CSV format if true, ignores the price volume if true, and sorts the raw mats by the order given
        public string GetClipboardList(string ExportFormat, bool IgnorePriceVolume, string[] MaterialNamesSortOrder, string[] ItemNamesSortOrder, string[] BuildItemsSortOrder, bool IncludeLinks)
        {
            int i;
            string OutputText = "";
            string TempListText;

            var FullBuildList = new Materials();
            var FullBuyList = new Materials();
            var FullItemList = new Materials();

            var TempMatList = new Materials();

            var InventionMatList = new Materials();
            var REMatList = new Materials();

            bool IncludeInventionMats = false;
            bool IncludeREMats = false;

            // Full output lists
            FullBuildList = GetFullBuildMaterialList(); // GetFullBuildList uses BuildItem and Volume for the facility ME value
            FullBuyList = (Materials)TotalBuyList.Clone();
            FullItemList = GetFullItemList();

            // Add the Invention mats to buy
            InventionMatList = GetFullInventionList();
            if (!(InventionMatList.GetMaterialList() == null))
            {
                IncludeInventionMats = true;
                // Remove the invention materials from the buy list so we can separate them in the output
                FullBuyList.RemoveMaterialList(InventionMatList.GetMaterialList());
                // Update the total though as if the materials were in the full list for price purposes
                FullBuyList.AddTotalValue(InventionMatList.GetTotalMaterialsCost());
                FullBuyList.AddTotalVolume(InventionMatList.GetTotalVolume());
            }

            // Sort the Item List by order sent (this is based on how they sorted in the grid)
            // Item sort order Name, Quantity, ME, Num BPs, Build Type, Decryptor, and Relic
            var loopTo = ItemNamesSortOrder.Count() - 1;
            for (i = 0; i <= loopTo; i++)
            {
                // Parse the sort order fields
                string[] ItemColumns = ItemNamesSortOrder[i].Split(new char[] { '|' });

                // For each item, find it in the current buy list and replace
                // Item sort order Name, Quantity, ME, Num BPs, Build Type, Decryptor/Relic, Location
                for (int j = 0, loopTo1 = FullItemList.GetMaterialList().Count - 1; j <= loopTo1; j++)
                {
                    {
                        var withBlock = FullItemList.GetMaterialList()[j]; // GroupName stores the build type Decryptor/Relic in item type
                                                                           // Split out the Build Type, Decryptor, NumBps, and Relic
                        string[] GroupNameItems = withBlock.GroupName.Split(new char[] { '|' });
                        string ItemName = "";
                        string RelicName = "";

                        if (ItemColumns[0].Contains("("))
                        {
                            ItemName = ItemColumns[0].Substring(0, Strings.InStr(ItemColumns[0], "(") - 2);
                            RelicName = ItemColumns[0].Substring(Strings.InStr(ItemColumns[0], "("), Strings.InStr(ItemColumns[0], ")") - Strings.InStr(ItemColumns[0], "(") - 1);
                        }
                        else
                        {
                            ItemName = ItemColumns[0];
                        }

                        if ((ItemName ?? "") == (withBlock.GetMaterialName() ?? "") & Conversions.ToLong(ItemColumns[1]) == withBlock.GetQuantity() & (ItemColumns[2] ?? "") == (withBlock.GetItemME() ?? "") & (ItemColumns[4] ?? "") == (GroupNameItems[0] ?? "") & (ItemColumns[5] ?? "") == (GroupNameItems[1] ?? "") & (ItemColumns[3] ?? "") == (GroupNameItems[2] ?? "") & (RelicName ?? "") == (GroupNameItems[3] ?? "") & (ItemColumns[6] ?? "") == (GroupNameItems[4] ?? ""))

                        {
                            // Found it, so insert into temp list
                            TempMatList.InsertMaterial(FullItemList.GetMaterialList()[j]);
                            break;
                        }
                    }
                }
            }

            FullItemList = (Materials)TempMatList.Clone();
            TempMatList = new Materials();

            // Get the Shopping list for items
            if (!(FullItemList == null) & (ExportFormat ?? "") != Public_Variables.MultiBuyDataExport)
            {
                TempListText = FullItemList.GetClipboardList(ExportFormat, IgnorePriceVolume, true, true, SettingsVariables.UserApplicationSettings.IncludeInGameLinksinCopyText);
                if (TempListText != "No items in List")
                {
                    OutputText = "Shopping List for: " + Constants.vbCrLf;
                    OutputText = OutputText + TempListText;
                    // Spacer
                    OutputText = OutputText + Constants.vbCrLf;
                }
            }

            // Invention materials (If they exist)
            if (IncludeInventionMats)
            {
                // Add Invention mats if there are any
                TempListText = InventionMatList.GetClipboardList(ExportFormat, false, false, false, SettingsVariables.UserApplicationSettings.IncludeInGameLinksinCopyText);
                if (TempListText != "No items in List" & (ExportFormat ?? "") != Public_Variables.MultiBuyDataExport)
                {
                    OutputText = OutputText + "Estimated Invention Materials: " + Constants.vbCrLf;
                    OutputText = OutputText + TempListText;
                    // Spacer
                    OutputText = OutputText + Constants.vbCrLf;
                }
                else if ((ExportFormat ?? "") == Public_Variables.MultiBuyDataExport)
                {
                    OutputText = OutputText + TempListText;
                }
            }

            // RE Materials (If they exist)
            if (IncludeREMats)
            {
                // Add RE mats if there are any
                TempListText = REMatList.GetClipboardList(ExportFormat, false, false, false, SettingsVariables.UserApplicationSettings.IncludeInGameLinksinCopyText);
                if (TempListText != "No items in List" & (ExportFormat ?? "") != Public_Variables.MultiBuyDataExport)
                {
                    OutputText = OutputText + "Estimated RE Materials: " + Constants.vbCrLf;
                    OutputText = OutputText + TempListText;
                    // Spacer
                    OutputText = OutputText + Constants.vbCrLf;
                }
                else if ((ExportFormat ?? "") == Public_Variables.MultiBuyDataExport)
                {
                    OutputText = OutputText + TempListText;
                }
            }

            // Sort the Build List by order sent (this is based on how they sorted in the grid)        
            // Build item sort order - Name, Quantity, and ME
            if ((ExportFormat ?? "") != Public_Variables.MultiBuyDataExport)
            {
                var loopTo2 = BuildItemsSortOrder.Count() - 1;
                for (i = 0; i <= loopTo2; i++)
                {
                    // For each item, find it in the current buy list and replace
                    for (int j = 0, loopTo3 = FullBuildList.GetMaterialList().Count - 1; j <= loopTo3; j++)
                    {
                        // Parse the sort order fields
                        string[] ItemColumns = BuildItemsSortOrder[i].Split(new char[] { '|' });

                        {
                            var withBlock1 = FullBuildList.GetMaterialList()[j]; // Mat group stores the build type and meta is in item type
                            if ((ItemColumns[0] ?? "") == (withBlock1.GetMaterialName() ?? "") & Conversions.ToLong(ItemColumns[1]) == withBlock1.GetQuantity() & (ItemColumns[2] ?? "") == (withBlock1.GetItemME() ?? ""))
                            {
                                // Found it, so insert into temp list
                                TempMatList.InsertMaterial(FullBuildList.GetMaterialList()[j]);
                                break;
                            }
                        }
                    }
                }

                FullBuildList = (Materials)TempMatList.Clone();
                TempMatList = new Materials();

                // Output the Build List - list the ME for each - assume no decryptor or relic
                if (!(FullBuildList == null))
                {
                    TempListText = FullBuildList.GetClipboardList(ExportFormat, true, true, false, SettingsVariables.UserApplicationSettings.IncludeInGameLinksinCopyText);
                    if (TempListText != "No items in List" & (ExportFormat ?? "") != Public_Variables.MultiBuyDataExport)
                    {
                        OutputText = OutputText + "Build Items List: " + Constants.vbCrLf;
                        OutputText = OutputText + TempListText;
                        // Spacer
                        OutputText = OutputText + Constants.vbCrLf;
                    }
                    else if ((ExportFormat ?? "") == Public_Variables.MultiBuyDataExport)
                    {
                        OutputText = OutputText + TempListText;
                    }
                }
            }

            // Now sort the buy material list by the order sent in the grid
            // Material sort order - Just Name
            var loopTo4 = MaterialNamesSortOrder.Count() - 1;
            for (i = 0; i <= loopTo4; i++)
            {
                // For each item, find it in the current buy list and replace
                for (int j = 0, loopTo5 = FullBuyList.GetMaterialList().Count - 1; j <= loopTo5; j++)
                {
                    if ((MaterialNamesSortOrder[i] ?? "") == (FullBuyList.GetMaterialList()[j].GetMaterialName() ?? ""))
                    {
                        // Found it, so insert into temp list
                        TempMatList.InsertMaterial(FullBuyList.GetMaterialList()[j]);
                        break;
                    }
                }
            }

            FullBuyList = (Materials)TempMatList.Clone();
            TempMatList = new Materials();

            // Output the Buy list, add the price and volume to it - in Buy lists don't list ME
            if (!(FullBuyList == null))
            {
                TempListText = FullBuyList.GetClipboardList(ExportFormat, false, false, false, SettingsVariables.UserApplicationSettings.IncludeInGameLinksinCopyText);
                if (TempListText != "No materials in List" & (ExportFormat ?? "") != Public_Variables.MultiBuyDataExport)
                {
                    OutputText = OutputText + "Buy Materials List: " + Constants.vbCrLf;
                    OutputText = OutputText + TempListText;
                    // Spacer
                    OutputText = OutputText + Constants.vbCrLf;
                }
                else if ((ExportFormat ?? "") == Public_Variables.MultiBuyDataExport)
                {
                    OutputText = OutputText + TempListText;
                }
            }

            // Add total build volume to end - Make sure we get quantity and not runs, so use portion size
            if ((ExportFormat ?? "") == Public_Variables.CSVDataExport)
            {
                OutputText = OutputText + "Total Volume of Built Item(s):," + FullItemList.GetTotalVolume().ToString() + ",m3";
            }
            else if ((ExportFormat ?? "") == Public_Variables.SSVDataExport)
            {
                OutputText = OutputText + "Total Volume of Built Item(s):;" + FullItemList.GetTotalVolume().ToString() + ";m3";
            }
            else if ((ExportFormat ?? "") == Public_Variables.DefaultTextDataExport)
            {
                OutputText = OutputText + "Total Volume of Built Item(s): " + Strings.FormatNumber(FullItemList.GetTotalVolume(), 2) + " m3";
            }

            return OutputText;

        }

        // Returns the total number of items in the list
        public long GetNumShoppingItems()
        {
            return TotalItemList.Count;
        }

        // Returns the full list of build items as materials
        public Materials GetFullBuildMaterialList()
        {
            var ReturnBuildItems = new Materials();
            Material TempMat;
            BuiltItem TempBuiltItem;

            // Go through all the built items and insert the materials
            for (int j = 0, loopTo = TotalBuildList.GetBuiltItemList().Count - 1; j <= loopTo; j++)
            {
                if (!(TotalBuildList.GetBuiltItemList()[j] == null))
                {
                    TempBuiltItem = TotalBuildList.GetBuiltItemList()[j];
                    // Use Volume for the facility ME value, since this isn't used (also ignore total volume)
                    TempMat = new Material(TempBuiltItem.ItemTypeID, TempBuiltItem.ItemName, "Built Item", TempBuiltItem.ItemQuantity, TempBuiltItem.ManufacturingFacility.MaterialMultiplier, 0d, TempBuiltItem.BuildME.ToString(), TempBuiltItem.BuildTE.ToString());

                    ReturnBuildItems.InsertMaterial(TempMat);

                }
            }

            // Sort
            ReturnBuildItems.SortMaterialListByQuantity();

            return ReturnBuildItems;

        }

        public BuiltItemList GetFullBuildList()
        {
            // Sort it first - quantity descending
            TotalBuildList.GetBuiltItemList().Sort((x, y) => y.ItemQuantity.CompareTo(x.ItemQuantity));

            return TotalBuildList;

        }

        // Returns the full built item list as a built item
        public BuiltItemList GetFullBuiltItemList()
        {
            return TotalBuildList;
        }

        // Returns the list of buy materials
        public Materials GetFullBuyList()
        {

            if (!(TotalBuyList.GetMaterialList() == null))
            {
                // Sort
                TotalBuyList.SortMaterialListByQuantity();
            }

            return TotalBuyList;

        }

        // Returns the list of Invention items and quantity
        public Materials GetFullInventionList()
        {
            var TempInventionMats = new Materials();

            for (int i = 0, loopTo = TotalItemList.Count - 1; i <= loopTo; i++)
            {
                if (TotalItemList[i].TechLevel != 1 & !(TotalItemList[i].InventionMaterials == null))
                {
                    TempInventionMats.InsertMaterialList(TotalItemList[i].InventionMaterials.GetMaterialList());
                }
            }

            return TempInventionMats;

        }

        // Returns the list of Invention items and quantity
        public Materials GetFullCopyList()
        {
            var TempCopyMats = new Materials();

            for (int i = 0, loopTo = TotalItemList.Count - 1; i <= loopTo; i++)
            {
                if (TotalItemList[i].TechLevel == 2 & !(TotalItemList[i].CopyMaterials == null))
                {
                    TempCopyMats.InsertMaterialList(TotalItemList[i].CopyMaterials.GetMaterialList());
                }
            }

            return TempCopyMats;

        }

        // Returns the full list of Items we want to build in the shopping list
        public Materials GetFullItemList()
        {
            Material TempMat;
            var ReturnMaterials = new Materials();

            for (int i = 0, loopTo = TotalItemList.Count - 1; i <= loopTo; i++)
            {
                {
                    var withBlock = TotalItemList[i];
                    // Item sort order is Build Type, Decryptor, NumBps, and Relic for the group name
                    TempMat = new Material(withBlock.TypeID, withBlock.Name, withBlock.BuildType + "|" + withBlock.Decryptor + "|" + withBlock.NumBPs.ToString() + "|" + withBlock.Relic + "|" + withBlock.ManufacturingFacility.FacilityName, withBlock.Runs, withBlock.BuildVolume / withBlock.Runs / withBlock.PortionSize, 0d, withBlock.ItemME.ToString(), withBlock.ItemTE.ToString());
                }
                ReturnMaterials.InsertMaterial(TempMat);
            }

            return ReturnMaterials;

        }

        // Returns the full shopping list as a list of shopping list items
        public List<ShoppingListItem> GetFullShoppingList()
        {
            return TotalItemList;
        }

        // Sets the additional costs for this list
        public void SetAdditionalCosts(double AddlCosts)
        {
            AdditionalCosts = AddlCosts;
        }

        // Sets all the price data for the shopping list after updates
        public void SetPriceData(Public_Variables.BrokerFeeInfo BrokerFeeData, bool IncludeUsage, List<Public_Variables.ItemBuyType> ItemBuyTypeList)
        {

            // First, Total up all the material costs, build time and market prices from the items we have and then add to total costs
            TotalListBuildTime = 0d;
            TotalListMarketPrice = 0d;
            for (int i = 0, loopTo = Public_Variables.TotalShoppingList.TotalItemList.Count - 1; i <= loopTo; i++)
            {
                TotalListBuildTime += Public_Variables.TotalShoppingList.TotalItemList[i].TotalBuildTime;
                TotalListMarketPrice += Public_Variables.TotalShoppingList.TotalItemList[i].TotalItemMarketCost;
            }

            // Use the master lists for these
            TotalListInventionCost = Public_Variables.TotalShoppingList.TotalInventionMats.GetTotalMaterialsCost();
            TotalListCopyCost = Public_Variables.TotalShoppingList.TotalCopyMats.GetTotalMaterialsCost();

            // The only fee that applies when shopping is either a buy order or directly buying - Broker fees are all that apply during a buy order
            MaterialsBrokerFee = 0d; // Reset
            MaterialsBrokerFee = CalculateBrokersFees(ItemBuyTypeList, BrokerFeeData);

            // Total usage
            TotalListUsage = 0d; // Reset
            if (IncludeUsage)
            {
                // Read through all the items in the list and sum up each usage value
                for (int i = 0, loopTo1 = Public_Variables.TotalShoppingList.TotalItemList.Count - 1; i <= loopTo1; i++)
                    TotalListUsage += Public_Variables.TotalShoppingList.TotalItemList[i].TotalUsage;
            }

            // Set the total cost of materials (includes copy and invention mats) plus usage, the broker fee for the materials, and additional costs
            TotalListCost = TotalBuyList.GetTotalMaterialsCost() + MaterialsBrokerFee + TotalListUsage + AdditionalCosts;

        }

        // Gets the broker fees based on user options that determine if each item is bought from market or through orders
        private double CalculateBrokersFees(List<Public_Variables.ItemBuyType> ItemList, Public_Variables.BrokerFeeInfo BrokerData)
        {
            double TotalBrokersFee = 0d;

            // Loop through the buy list and check the item list to see if we apply brokers fees or not
            if (!(TotalBuyList.GetMaterialList() == null) & !(ItemList == null))
            {
                for (int i = 0, loopTo = TotalBuyList.GetMaterialList().Count - 1; i <= loopTo; i++)
                {
                    for (int j = 0, loopTo1 = ItemList.Count - 1; j <= loopTo1; j++)
                    {
                        if ((TotalBuyList.GetMaterialList()[i].GetMaterialName() ?? "") == (ItemList[j].ItemName ?? ""))
                        {
                            if (ItemList[j].BuyType == "Buy Order")
                            {
                                // Apply broker fee
                                TotalBrokersFee += Public_Variables.GetSalesBrokerFee(TotalBuyList.GetMaterialList()[i].GetTotalCost(), BrokerData);
                            }
                        }
                    }
                }
            }

            return TotalBrokersFee;

        }

        // Returns the total profit of the items made with raw mats in the list
        public double GetTotalProfit()
        {
            return TotalListMarketPrice - TotalListCost;
        }

        // Returns the total IPH (approx) for the items in the list
        public double GetTotalIPH()
        {
            return GetTotalProfit() / TotalListBuildTime * 3600d; // Isk per second then multiply it by seconds per hour for IPH
        }

        // Returns the total fees to set up sell orders for the total value of buy materials
        public double GetTotalMaterialsBrokersFees()
        {
            return MaterialsBrokerFee;
        }

        // Returns the total cost of the list
        public double GetTotalCost()
        {
            return TotalListCost;
        }

        // Returns the total invention cost of materials
        public double GetTotalInventionCosts()
        {
            return TotalListInventionCost;
        }

        // Returns the total copy cost of materials
        public double GetTotalCopyCosts()
        {
            return TotalListCopyCost;
        }

        // Returns the total volume of the buy items
        public double GetTotalVolume()
        {
            return TotalBuyList.GetTotalVolume();
        }

        // Returns the total volume of built items in the shopping list
        public double GetBuiltItemVolume()
        {
            double TotalVolume = 0d;

            for (int i = 0, loopTo = TotalItemList.Count - 1; i <= loopTo; i++)
                TotalVolume += TotalItemList[i].BuildVolume;

            return TotalVolume;

        }

        // Returns the total usage of the shopping list items
        public double GetTotalUsage()
        {
            return TotalListUsage;
        }

        // Predicate for finding the item in full list
        public bool FindItem(ShoppingListItem Item)
        {
            if (ShopListItemsEqual(Item, ItemToFind))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Predicate to compare two shopping list items
        private bool ShopListItemsEqual(ShoppingListItem Item1, ShoppingListItem Item2)
        {
            if (Item1.ItemME != Item2.ItemME)
            {
                return false;
            }
            if ((Item1.Name ?? "") != (Item2.Name ?? ""))
            {
                return false;
            }
            if ((Item1.BuildType ?? "") != (Item2.BuildType ?? ""))
            {
                return false;
            }
            if ((Item1.Decryptor ?? "") != (Item2.Decryptor ?? ""))
            {
                return false;
            }
            if ((Item1.Relic ?? "") != (Item2.Relic ?? ""))
            {
                return false;
            }
            // If Item1.NumBPs <> Item2.NumBPs Then
            // Return False
            // End If
            if ((Item1.ManufacturingFacility.FacilityName ?? "") != (Item2.ManufacturingFacility.FacilityName ?? ""))
            {
                return false;
            }

            return true;

        }

        // Looks up a material and returns the quantity of the users entry (on hand) or zero if not found
        private long GetOnHandMaterialQuantity(string MaterialName)
        {

            if (!(OnHandMatList.GetMaterialList() == null))
            {
                for (int i = 0, loopTo = OnHandMatList.GetMaterialList().Count - 1; i <= loopTo; i++)
                {
                    if ((OnHandMatList.GetMaterialList()[0].GetMaterialName() ?? "") == (MaterialName ?? ""))
                    {
                        return OnHandMatList.GetMaterialList()[0].GetQuantity();
                    }
                }
            }
            // not found
            return 0L;

        }

        // Looks up a component and returns the quantity of the user's entry (on hand) or zero if not found
        private long GetOnHandComponentQuantity(string ComponentName)
        {

            if (!(OnHandComponentList.GetMaterialList() == null))
            {
                for (int i = 0, loopTo = OnHandComponentList.GetMaterialList().Count - 1; i <= loopTo; i++)
                {
                    if ((OnHandComponentList.GetMaterialList()[0].GetMaterialName() ?? "") == (ComponentName ?? ""))
                    {
                        return OnHandComponentList.GetMaterialList()[0].GetQuantity();
                    }
                }
            }
            // not found
            return 0L;

        }

        // For doing a deep copy of a shopping list
        public object Clone()
        {
            var CopyOfMe = new ShoppingList();
            var BuyList = new Materials();

            CopyOfMe.TotalItemList = TotalItemList;
            CopyOfMe.TotalBuyList = (Materials)TotalBuyList.Clone();
            CopyOfMe.TotalBuildList = (BuiltItemList)TotalBuildList.Clone();
            CopyOfMe.TotalInventionMats = TotalInventionMats;
            CopyOfMe.TotalCopyMats = (Materials)TotalCopyMats.Clone();
            CopyOfMe.OnHandMatList = (Materials)OnHandMatList.Clone();
            CopyOfMe.OnHandComponentList = (Materials)OnHandComponentList.Clone();
            CopyOfMe.AdditionalCosts = AdditionalCosts;
            CopyOfMe.MaterialsBrokerFee = MaterialsBrokerFee;

            return CopyOfMe;

        }

    }

    public class ShoppingListItem
    {
        public long BlueprintTypeID; // BP Type ID
        public long TypeID; // TypeID for the item 
        public long Runs; // Number of runs of the main items (not quantity)
        public string Name; // Item we want to shop for * Key Value
        public string BuildType; // Component / Raw / Build/Buy * Key Value
        public double ItemME; // The ME of the Shopping item * Key Value
        public double ItemTE;
        public int TechLevel; // T1, T2, or T3
        public double BuildVolume; // Volume of the built item
        public long PortionSize; // Portion size of one run of this blueprint

        public string Decryptor; // If it's invented or RE'd, then store the Relic or Decryptor name here * Key value
        public string Relic; // Relic used for T3

        public Materials InventionMaterials = new Materials(); // The List of Invention materials needed to build the T2 item
        public Materials CopyMaterials = new Materials(); // List of materials used to make the copies to invent
        public double AvgInvRunsforSuccess; // How many Invention/RE runs we need for success - used to calculate correct changes in list for mats
        public long InventionJobs; // How many jobs did we do
        public int InventedRunsPerBP; // Number of runs for each bp in NumBPs (helps with determining invention changes later)

        public int NumBPs; // Number of BPs used to build item

        public Materials BPMaterialList = new Materials(); // This is the list of items on the Blueprint so we have a record of what they are building - it is not updated
        public BuiltItemList BPBuiltItems = new BuiltItemList(); // List of items we build for this bp - not updated

        // Set the component facility (use BP tab for now)
        public IndustryFacility ManufacturingFacility;
        public IndustryFacility ComponentManufacturingFacility;
        public IndustryFacility ReactionFacility;

        // Ignore Variables
        public bool IgnoredInvention;
        public bool IgnoredMinerals;
        public bool IgnoredT1BaseItem;

        public bool IncludeActivityCost;
        public bool IncludeActivityTime;
        public bool IncludeActivityUsage;

        // Saved price variables for this item - can be updated when quantity updated
        // Public TotalMaterialCost As Double ' This is the cost of all the materials to build the item (does not include usage, item taxes or item fees) and invention and copy costs
        public double TotalUsage; // Includes Manufacturing, Components, Invention, and Copying usage
        public double TotalItemMarketCost; // This is the market cost of the items in the list
        public double TotalBuildTime; // Total time to build the items for the given type of building

        public ShoppingListItem()
        {

            BlueprintTypeID = 0L;
            TypeID = 0L;
            Runs = 0L;
            Name = "";
            BuildType = "";
            ItemME = 0d;
            ItemTE = 0d;
            TechLevel = 0;
            BuildVolume = 0d;
            PortionSize = 0L;

            Decryptor = "";
            Relic = "";

            InventionMaterials = new Materials();
            CopyMaterials = new Materials();
            AvgInvRunsforSuccess = 0d;
            InventedRunsPerBP = 0;
            InventionJobs = 0L;

            NumBPs = 0;

            BPMaterialList = null;
            BPBuiltItems = null;

            ManufacturingFacility = new IndustryFacility();
            ComponentManufacturingFacility = new IndustryFacility();
            ReactionFacility = new IndustryFacility();

            IgnoredInvention = false;
            IgnoredMinerals = false;
            IgnoredT1BaseItem = false;

            IncludeActivityCost = false;
            IncludeActivityTime = false;
            IncludeActivityUsage = false;

        }

    }

    public class BuiltItemList : ICloneable
    {

        private List<BuiltItem> ItemList; // List of all the items and materials
        private double TotalCost; // Total cost of the list

        private BuiltItem ItemToFind;

        public BuiltItemList()
        {
            ItemList = new List<BuiltItem>();
            ItemToFind = null;
            TotalCost = 0d;
        }

        // For doing a deep copy of Materials
        public object Clone()
        {
            var CopyOfMe = new BuiltItemList();
            BuiltItem TempItem;

            for (int i = 0, loopTo = ItemList.Count - 1; i <= loopTo; i++)
            {
                TempItem = (BuiltItem)ItemList[i].Clone();
                CopyOfMe.AddBuiltItem(TempItem);
            }

            CopyOfMe.TotalCost = TotalCost;

            return CopyOfMe;

        }

        // Adds a sent built item to the main list, updating quantities for same items
        public void AddBuiltItem(BuiltItem SentItem)
        {
            var FoundItem = new BuiltItem();
            var ComponentFoundItem = new BuiltItem();
            var CombinedMaterials = new Materials();
            BuiltItem AddItem = (BuiltItem)SentItem.Clone();

            // Search the list to see if the item exists
            ItemToFind = AddItem;
            FoundItem = ItemList.Find(FindBuiltItem);

            if (FoundItem is not null)
            {
                // Exists, so update the quantity and materials
                // Remove the item from the list we are updating
                ItemList.Remove(FoundItem);

                // Get the runs of this blueprint to set the right amount of build materials needed
                long Runs = (long)Math.Round(Math.Ceiling((FoundItem.ItemQuantity + AddItem.ItemQuantity) / (double)AddItem.PortionSize));

                // Combine the materials
                CombinedMaterials.InsertMaterialList(AddItem.BuildMaterials.GetMaterialList());
                CombinedMaterials.InsertMaterialList(FoundItem.BuildMaterials.GetMaterialList());

                AddItem.BuildMaterials = (Materials)CombinedMaterials.Clone();

                var BuiltComponentList = new List<BuiltItem>();

                // Combine the built item lists by updating the quantity and saving
                foreach (var AddItemBI in AddItem.ComponentBuildList)
                {
                    // Find the item in the current list, if found, update the built item quantity, else, add it
                    ItemToFind = AddItemBI;
                    ComponentFoundItem = FoundItem.ComponentBuildList.Find(FindBuiltItem);
                    if (ComponentFoundItem is not null)
                    {
                        var TempComponent = new BuiltItem();
                        TempComponent = (BuiltItem)ComponentFoundItem.Clone();
                        TempComponent.ItemQuantity = ComponentFoundItem.ItemQuantity + AddItemBI.ItemQuantity;
                        // Add updated quantity
                        BuiltComponentList.Add(TempComponent);
                    }
                    else
                    {
                        // not found, add it
                        BuiltComponentList.Add(AddItemBI);
                    }
                }

                // Add all the combined components
                AddItem.ComponentBuildList = BuiltComponentList;

                // Update the quantities
                AddItem.ItemQuantity = AddItem.ItemQuantity + FoundItem.ItemQuantity;
                AddItem.UsedQuantity = AddItem.UsedQuantity + FoundItem.UsedQuantity;
                AddItem.BPRuns = Runs;
                AddItem.PortionSize = AddItem.PortionSize;

                AddItem.ItemName = Public_Variables.UpdateItemNamewithRuns(AddItem.ItemName, Runs);

                // Cost
                TotalCost = TotalCost + AddItem.TotalBuildCost;

                // Re-add the item
                ItemList.Add(AddItem);
            }

            else
            {
                // Add the item to the list
                ItemList.Add(AddItem);
            }

        }

        // Removes an item from the list in the quantity sent
        public void RemoveBuiltItem(BuiltItem RemoveItem)
        {
            var FoundItem = new BuiltItem();
            var CombinedMaterials = new Materials();

            // Search the list to see if the item exists
            ItemToFind = RemoveItem;
            FoundItem = ItemList.Find(FindBuiltItem);

            if (FoundItem is not null)
            {
                if (FoundItem.ItemQuantity == RemoveItem.ItemQuantity)
                {
                    // Just remove it
                    ItemList.Remove(RemoveItem);
                }
                else
                {
                    // Remove the found item and update
                    ItemList.Remove(FoundItem);

                    // Update quantity and materials
                    FoundItem.ItemQuantity = FoundItem.ItemQuantity - RemoveItem.ItemQuantity;
                    FoundItem.BuildMaterials.RemoveMaterialList(RemoveItem.BuildMaterials.GetMaterialList());

                    // Add the updated item to the list
                    ItemList.Add(FoundItem);

                }

                // Update cost
                TotalCost = TotalCost - RemoveItem.TotalBuildCost;

            }

        }

        // Returns the list of all built items only
        public List<BuiltItem> GetBuiltItemList()
        {
            return ItemList;
        }

        // Returns the total cost of the list
        public double GetTotalCost()
        {
            return TotalCost;
        }

        // So outside functions can use the find predecate
        public void SetItemToFind(BuiltItem FindItem)
        {
            ItemToFind = FindItem;
        }

        // Predicate for finding a component item in the list
        public bool FindBuiltItem(BuiltItem Item)
        {
            if (Item.ItemTypeID == ItemToFind.ItemTypeID & Item.BuildME == ItemToFind.BuildME & (Item.ManufacturingFacility.FacilityName ?? "") == (ItemToFind.ManufacturingFacility.FacilityName ?? ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Function takes an item name and returns an array of all the items with that same name (could have different MEs)
        public BuiltItemList FindBuiltItems(string ItemName)
        {
            var ReturnList = new BuiltItemList();

            for (int i = 0, loopTo = ItemList.Count - 1; i <= loopTo; i++)
            {
                if ((Public_Variables.RemoveItemNameRuns(ItemList[i].ItemName) ?? "") == (ItemName ?? ""))
                {
                    ReturnList.AddBuiltItem(ItemList[i]);
                }
            }

            return ReturnList;

        }

    }

    public class BuiltItem : ICloneable
    {

        public long BPTypeID;
        public long ItemTypeID;
        public string ItemName;
        public long ItemQuantity;
        public decimal UsedQuantity; // For stuff with portion sizes
        public double ItemVolume;
        public int BuildME;
        public int BuildTE;
        public Materials BuildMaterials;
        public List<BuiltItem> ComponentBuildList; // This item may also have build able items
        public long BPRuns; // How many runs of this item to get the item quantity
        public long PortionSize;

        // These fields are for shopping list update functions
        public IndustryFacility ManufacturingFacility = new IndustryFacility();

        public bool IncludeActivityCost;
        public bool IncludeActivityTime;
        public bool IncludeActivityUsage;

        public double TotalBuildCost;
        public double TotalExcessSellBuildCost;

        public BuiltItem()
        {
            ItemTypeID = 0L;
            ItemName = "";
            ItemQuantity = 0L;
            UsedQuantity = 0m;
            ItemVolume = 0d;
            BuildME = 0;
            BuildMaterials = new Materials();
            ComponentBuildList = new List<BuiltItem>();
            BPRuns = 0L;
            PortionSize = 0L;

            ManufacturingFacility = new IndustryFacility();

            IncludeActivityCost = false;
            IncludeActivityTime = false;
            IncludeActivityUsage = false;

            TotalBuildCost = 0d;
            TotalExcessSellBuildCost = 0d;

        }

        // For doing a deep copy of Materials
        public object Clone()
        {
            var CopyOfMe = new BuiltItem();
            CopyOfMe.BPTypeID = BPTypeID;
            CopyOfMe.ItemTypeID = ItemTypeID;
            CopyOfMe.ItemName = ItemName;
            CopyOfMe.ItemQuantity = ItemQuantity;
            CopyOfMe.UsedQuantity = UsedQuantity;
            CopyOfMe.ItemVolume = ItemVolume;
            CopyOfMe.BuildME = BuildME;
            CopyOfMe.BuildTE = BuildTE;
            CopyOfMe.BuildMaterials = (Materials)BuildMaterials.Clone();
            CopyOfMe.BPRuns = BPRuns;
            CopyOfMe.PortionSize = PortionSize;
            CopyOfMe.ManufacturingFacility = (IndustryFacility)ManufacturingFacility.Clone();
            CopyOfMe.IncludeActivityUsage = IncludeActivityUsage;
            CopyOfMe.IncludeActivityTime = IncludeActivityTime;
            CopyOfMe.IncludeActivityCost = IncludeActivityCost;
            CopyOfMe.TotalBuildCost = TotalBuildCost;
            CopyOfMe.TotalExcessSellBuildCost = TotalExcessSellBuildCost;
            CopyOfMe.ComponentBuildList = new List<BuiltItem>();
            // Clone each built item in the list
            foreach (var BI in ComponentBuildList)
                CopyOfMe.ComponentBuildList.Add((BuiltItem)BI.Clone());
            return CopyOfMe;
        }

    }
}