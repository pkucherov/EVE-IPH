using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmReprocessingPlant
    {

        private int ItemsColumnClicked;
        private SortOrder ItemsColumnSortType;
        private int OutputColumnClicked;
        private SortOrder OutputColumnSortType;

        // Ore processing skills
        private ControlsCollection m_ControlsCollection;
        private CheckBox[] ProcessingCheckBoxes;
        private Label[] ProcessingLabels;
        private ComboBox[] ProcessingCombos;

        private int[] CheckedItems;

        private Materials MaterialOutput = new Materials(); // Save globally for easy exporting

        private List<RefineItem> CheckedRefineItems = new List<RefineItem>();
        private bool IgnoreChecks;
        private long RefineItemtoFind;

        private struct RefineItem
        {
            public long ItemID;
            public bool BuildItem; // True, we refine it regardless, False we do not regardless. If not in list, we don't do anything differently
        }

        // Predicate for finding the BuildBuyItem in full list
        private bool FindBPBBItem(RefineItem Item)
        {
            if (RefineItemtoFind == Item.ItemID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public frmReprocessingPlant()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            m_ControlsCollection = new ControlsCollection(this);

            // Set up grids
            // Width is now 570, scrollbar is 21  27
            lstItemstoRefine.Columns.Add("Material", 200, HorizontalAlignment.Left); // add 25 for check
            lstItemstoRefine.Columns.Add("Quantity", 51, HorizontalAlignment.Right);
            lstItemstoRefine.Columns.Add("Total Cost", 100, HorizontalAlignment.Right);
            lstItemstoRefine.Columns.Add("Rate", 43, HorizontalAlignment.Right);
            lstItemstoRefine.Columns.Add("Refined Value", 100, HorizontalAlignment.Right);
            lstItemstoRefine.Columns.Add("% Return", 55, HorizontalAlignment.Right);
            lstItemstoRefine.Columns.Add("Material Group", 0, HorizontalAlignment.Right); // Hidden
            lstItemstoRefine.Columns.Add("Item ID", 0, HorizontalAlignment.Right); // Hidden

            lstRefineOutput.Columns.Add("Material", 200, HorizontalAlignment.Left);
            lstRefineOutput.Columns.Add("Quantity", 90, HorizontalAlignment.Right);
            lstRefineOutput.Columns.Add("Cost Per Item", 77, HorizontalAlignment.Right);
            lstRefineOutput.Columns.Add("Total Cost", 105, HorizontalAlignment.Right);
            lstRefineOutput.Columns.Add("Total Volume", 77, HorizontalAlignment.Right);

            IgnoreChecks = true;
            chkToggle.Checked = true; // Default
            IgnoreChecks = false;

            ProcessingCheckBoxes = (CheckBox[])ControlArrayUtils.getControlArray(this, MyControls, "chkOreProcessing");
            ProcessingLabels = (Label[])ControlArrayUtils.getControlArray(this, MyControls, "lblOreProcessing");
            ProcessingCombos = (ComboBox[])ControlArrayUtils.getControlArray(this, MyControls, "cmbOreProcessing");

            // Load all the skills
            cmbReprocessing.Text = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3385L).ToString();
            cmbReprocessingEff.Text = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3389L).ToString();
            cmbScrapMetalProcessing.Text = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(12196L).ToString();

            int TempSkillLevel;
            for (int i = 1, loopTo = ProcessingCheckBoxes.Count() - 1; i <= loopTo; i++)
            {
                TempSkillLevel = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(Public_Variables.SelectedCharacter.Skills.GetSkillTypeID(ProcessingLabels[i].Text));
                if (TempSkillLevel != 0)
                {
                    ProcessingCombos[i].Text = TempSkillLevel.ToString();
                    ProcessingCheckBoxes[i].Checked = true;
                }
                else
                {
                    ProcessingCombos[i].Text = "0";
                    ProcessingCheckBoxes[i].Checked = false;
                }
            }

            var AttribLookup = new EVEAttributes();
            var Defaults = new ProgramSettings();
            switch (SettingsVariables.UserApplicationSettings.RefiningImplantValue)
            {
                case var @case when @case == AttribLookup.GetAttribute(Defaults.RBeanCounterName + "1", ItemAttributes.refiningYieldMutator) / 100d:
                    {
                        cmbBeanCounterRefining.Text = Defaults.RBeanCounterName + "1";
                        break;
                    }
                case var case1 when case1 == AttribLookup.GetAttribute(Defaults.RBeanCounterName + "2", ItemAttributes.refiningYieldMutator) / 100d:
                    {
                        cmbBeanCounterRefining.Text = Defaults.RBeanCounterName + "2";
                        break;
                    }
                case var case2 when case2 == AttribLookup.GetAttribute(Defaults.RBeanCounterName + "4", ItemAttributes.refiningYieldMutator) / 100d:
                    {
                        cmbBeanCounterRefining.Text = Defaults.RBeanCounterName + "4";
                        break;
                    }

                default:
                    {
                        cmbBeanCounterRefining.Text = Public_Variables.None;
                        break;
                    }
            }

            chkRecursiveRefine.Checked = SettingsVariables.UserApplicationSettings.RefineDrillDown;

            // Update the ore processing skills
            UpdateProcessingSkills();

            InitializeReprocessingFacility();
            RefreshRefiningRates();

            ItemsColumnClicked = 1;
            ItemsColumnSortType = SortOrder.Ascending;
            OutputColumnClicked = 1;
            OutputColumnSortType = SortOrder.Ascending;

        }

        public void InitializeReprocessingFacility()
        {
            // Load the facility
            Form argControlForm = this;
            ReprocessingFacility.InitializeControl(Public_Variables.SelectedCharacter.ID, ProgramLocation.ReprocessingPlant, ProductionType.Reprocessing, ref argControlForm);
        }

        #region Object Events

        public Collection MyControls
        {
            get
            {
                return m_ControlsCollection.Controls;
            }
        }

        private void OreCheckProcessing_CheckedChanged(object sender, EventArgs e)
        {


            UpdateProcessingSkillBoxes(Conversions.ToInteger(((CheckBox)sender).Name.Substring(16)), ((CheckBox)sender).Checked);
        }

        private void UpdateProcessingSkillBoxes(int Index, bool Checked)
        {
            ProcessingCombos[Index].Enabled = Checked;
            ProcessingLabels[Index].Enabled = Checked;
        }

        // Updates the processing skills (enable, disable) depending on the refining skills selected
        private void UpdateProcessingSkills()
        {

            if (Public_Variables.FirstLoad)
            {
                return;
            }

            // Set them all false first
            for (int i = 1, loopTo = ProcessingCheckBoxes.Count() - 1; i <= loopTo; i++)
                ProcessingCheckBoxes[i].Enabled = false;

            for (int i = 1, loopTo1 = ProcessingCombos.Count() - 1; i <= loopTo1; i++)
                ProcessingCombos[i].Enabled = false;

            for (int i = 1, loopTo2 = ProcessingLabels.Count() - 1; i <= loopTo2; i++)
                ProcessingLabels[i].Enabled = false;

            if (cmbReprocessing.Text == "4" | cmbReprocessing.Text == "5")
            {
                // Simple - Veld, Scordite, Pyroxeres, and Plag
                EnableOreProcessingGroup(1, true);
            }

            if (cmbReprocessing.Text == "5")
            {
                // Coherent - Hemo, Hedbergite, Jaspet, Kernite, Omber
                EnableOreProcessingGroup(2, true);
            }

            if (cmbReprocessingEff.Text == "4" | cmbReprocessingEff.Text == "5")
            {
                // Variegated - Crokite, Dark Ochre, Gneiss
                EnableOreProcessingGroup(3, true);
            }

            if (cmbReprocessingEff.Text == "5")
            {
                // Complex - Ark, Bisot, Spod
                EnableOreProcessingGroup(4, true);
                // Mercoxit
                EnableOreProcessingGroup(6, true);
                // Moon mining
                EnableOreProcessingGroup(7, true);
                EnableOreProcessingGroup(8, true);
                EnableOreProcessingGroup(9, true);
                EnableOreProcessingGroup(10, true);
                EnableOreProcessingGroup(11, true);
                // Trig mining
                EnableOreProcessingGroup(5, true);
            }

            if (cmbReprocessing.Text == "4")
            {
                cmbReprocessingEff.Enabled = true;
            }

            // Ice
            if (cmbReprocessingEff.Enabled & cmbReprocessingEff.Text == "5")
            {
                EnableOreProcessingGroup(12, true);
            }

        }

        // Changes the ore processing skill group to enabled or disabled
        private void EnableOreProcessingGroup(int Index, bool EnableObject)
        {
            if (ProcessingCheckBoxes[Index].Checked & EnableObject)
            {
                // Ok to enable
                ProcessingCombos[Index].Enabled = true;
                ProcessingLabels[Index].Enabled = true;
            }
            else
            {
                // Don't enable
                ProcessingCombos[Index].Enabled = false;
                ProcessingLabels[Index].Enabled = false;
            }

            ProcessingCheckBoxes[Index].Enabled = EnableObject;

        }

        private void lstItemstoRefine_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = lstItemstoRefine;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ItemsColumnClicked, ref ItemsColumnSortType);
        }

        private void lstRefineOutput_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = lstRefineOutput;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref OutputColumnClicked, ref OutputColumnSortType);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void lstItemstoRefine_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!IgnoreChecks)
            {
                RefineItem TempItem;
                TempItem.BuildItem = e.Item.Checked;
                TempItem.ItemID = Conversions.ToInteger(e.Item.SubItems[7].Text);

                var FoundItem = GetItemInCheckedList(TempItem.ItemID);

                // See if the item checked is in the list, if so, update the temp, remove the old items and replace
                if (FoundItem.ItemID != 0L)
                {
                    // In list, so just remove and re-add
                    CheckedRefineItems.Remove(FoundItem);
                    // Add the item with current info
                    CheckedRefineItems.Add(TempItem);
                }
                else
                {
                    // New item to add, now add the item that was toggled
                    CheckedRefineItems.Add(TempItem);
                }

            }
        }

        // Look in the checked item list and see if we check this item or leave it checked
        private bool GetCheckforItem(long ItemID)
        {
            var FoundItem = GetItemInCheckedList(ItemID);

            if (FoundItem.ItemID != 0L)
            {
                return FoundItem.BuildItem;
            }
            else
            {
                return true;
            }
        }

        private RefineItem GetItemInCheckedList(long ItemID)
        {
            RefineItem FoundItem;
            RefineItemtoFind = ItemID;
            FoundItem = CheckedRefineItems.Find(FindBPBBItem);

            if (FoundItem.ItemID != 0L)
            {
                return FoundItem;
            }
            else
            {
                return default;
            }
        }

        private void chkToggle_CheckedChanged(object sender, EventArgs e)
        {
            bool CheckValue;
            if (chkToggle.Checked)
            {
                chkToggle.Text = "Uncheck All Items";
                CheckValue = true;
            }
            else
            {
                chkToggle.Text = "Check All Items";
                CheckValue = false;
            }

            if (!IgnoreChecks)
            {
                foreach (ListViewItem item in lstItemstoRefine.Items)
                    item.Checked = CheckValue;
            }
        }

        #endregion

        private void btnShowAssets_Click(object sender, EventArgs e)
        {

            // Make sure it's not disposed
            if (Public_Variables.frmRefineryAssets == null)
            {
                // Make new form
                Public_Variables.frmRefineryAssets = new frmAssetsViewer(AssetWindow.Refinery);
            }
            else if (Public_Variables.frmRefineryAssets.IsDisposed)
            {
                // Make new form
                Public_Variables.frmRefineryAssets = new frmAssetsViewer(AssetWindow.Refinery);
            }

            // Now open the Asset List
            Public_Variables.frmRefineryAssets.Show();
            Public_Variables.frmRefineryAssets.Focus();

            Application.DoEvents();

        }

        private void btnCopyPasteAssets_Click(object sender, EventArgs e)
        {
            var f1 = new frmCopyandPaste(Public_Variables.CopyPasteWindowType.Materials, Public_Variables.CopyPasteWindowLocation.RefineMaterials);

            f1.ShowDialog();

            // Update with new materials
            if (!string.IsNullOrEmpty(Public_Variables.CopyPasteRefineryMaterialText))
            {
                RefreshMaterialList(Public_Variables.ImportCopyPasteText(Public_Variables.CopyPasteRefineryMaterialText));
            }

            f1.Dispose();

        }

        private void btnSelectAssets_Click(object sender, EventArgs e)
        {
            // They update assets already by pressing on the safe
            Public_Variables.CopyPasteRefineryMaterialText = ""; // Reset this
            RefreshMaterialList();
        }

        // Refines all materials in the item list and updates the item list with return amount of refining and the output list of materials
        private void btnReprocess_Click(object sender, EventArgs e)
        {
            Reprocess();
        }

        private void btnReprocess2_Click(object sender, EventArgs e)
        {
            Reprocess();
        }

        private void Reprocess()
        {
            var ReprocessedMaterials = new Materials();
            double ReprocessedCost;
            var ReprocessingUsage = default(double);
            double TotalReprocessingUsage = 0d;
            double ItemCost;
            ListViewItem ItemlstViewRow;
            double TotalItemListValue = 0d;

            if (lstItemstoRefine.CheckedItems.Count == 0)
            {
                Interaction.MsgBox("No items selected to refine.", Constants.vbExclamation, Application.ProductName);
                return;
            }

            // Reset the output
            MaterialOutput = new Materials();

            // Read through the list, refine each material 
            lstItemstoRefine.BeginUpdate();

            foreach (ListViewItem Item in lstItemstoRefine.Items)
            {
                if (Item.Checked)
                {

                    double ReprocessingYield = 0d;

                    TotalItemListValue += Conversions.ToDouble(Item.SubItems[2].Text);
                    string ItemGroup = Item.SubItems[6].Text;

                    // Refine the item
                    {
                        var withBlock = Item.SubItems;
                        ReprocessMaterial(Conversions.ToInteger(withBlock[7].Text), withBlock[0].Text, Conversions.ToInteger(withBlock[1].Text), withBlock[6].Text, chkRecursiveRefine.Checked, ref ReprocessedMaterials, ref ReprocessingYield, ref ReprocessingUsage);
                    }

                    // Save the processing cost
                    TotalReprocessingUsage += ReprocessingUsage;

                    // Update the refine rate to the current row, refined cost, and loss % of the refine
                    Item.SubItems[3].Text = Strings.FormatPercent(ReprocessingYield, 1);
                    ReprocessedCost = ReprocessedMaterials.GetTotalMaterialsCost();
                    Item.SubItems[4].Text = Strings.FormatNumber(ReprocessedCost, 2);
                    ItemCost = Conversions.ToDouble(Item.SubItems[2].Text);
                    if (ItemCost == 0d)
                    {
                        Item.SubItems[5].Text = Strings.FormatPercent(1, 1);
                    }
                    else
                    {
                        Item.SubItems[5].Text = Strings.FormatPercent(ReprocessedCost / ItemCost, 1);
                    }

                    // Add the materials to the main material list
                    MaterialOutput.InsertMaterialList(ReprocessedMaterials.GetMaterialList());
                    Application.DoEvents();
                }
                else
                {
                    // Clear the output data 
                    Item.SubItems[3].Text = "";
                    Item.SubItems[4].Text = "";
                    Item.SubItems[5].Text = "";
                }
            }
            lstItemstoRefine.EndUpdate();

            // Update the total usage for doing this refining
            ReprocessingFacility.GetSelectedFacility().FacilityUsage = TotalReprocessingUsage;

            // Now update the main output list
            lstRefineOutput.Items.Clear();
            lstRefineOutput.BeginUpdate();
            foreach (var mat in MaterialOutput.GetMaterialList())
            {
                ItemlstViewRow = new ListViewItem(mat.GetMaterialName());
                ItemlstViewRow.SubItems.Add(Strings.FormatNumber(mat.GetQuantity(), 0));
                ItemlstViewRow.SubItems.Add(Strings.FormatNumber(mat.GetCostPerItem(), 2));
                ItemlstViewRow.SubItems.Add(Strings.FormatNumber(mat.GetTotalCost(), 2));
                ItemlstViewRow.SubItems.Add(Strings.FormatNumber(mat.GetTotalVolume(), 2));
                lstRefineOutput.Items.Add(ItemlstViewRow);
            }
            lstRefineOutput.EndUpdate();

            // Update the total values for the two lists and rate
            double TotalValue = MaterialOutput.GetTotalMaterialsCost() - TotalReprocessingUsage;  // Subtract usage first
            lblListTotalValueOutput.Text = Strings.FormatNumber(TotalItemListValue, 2); // Total value of the items reprocessed
            lblReturnRatePercentOutput.Text = Strings.FormatPercent(TotalValue / TotalItemListValue, 1); // Amount of stuff recieved / total value of stuff reprocessed
            lblReprocessingValueOutput.Text = Strings.FormatNumber(TotalValue, 2); // Total value of stuff reprocessed minus usage
            lblReprocessingVolumeOutput.Text = Strings.FormatNumber(MaterialOutput.GetTotalVolume(), 2); // Total volume of output stuff

            // Sort the  list
            ListView argRefListView = lstRefineOutput;
            Public_Variables.ListViewColumnSorter(OutputColumnClicked, ref argRefListView, ref OutputColumnClicked, ref OutputColumnSortType);

            Application.DoEvents();

        }

        private void ReprocessMaterial(long ItemID, string ItemName, long ItemQuantity, string ItemGroup, bool RecursiveRefine, ref Materials MaterialOutputs, ref double ReprocessingYieldOutput, ref double ReprocessingFees)
        {
            var BFI = new Public_Variables.BrokerFeeInfo();
            var TempOutputs = new Materials();
            var RecursiveOutput = new Materials();
            var UpdatedOutputs = new Materials();
            var ReprocessingYield = default(double);
            var ReprocessingUsage = default(double);
            double LocalReprocessingUsage = 0d;

            // These will only set up base refine rates, we need to adjust with the rig updated rates
            var Attriblookup = new EVEAttributes();
            double ImplantValue = Attriblookup.GetAttribute(cmbBeanCounterRefining.Text, ItemAttributes.refiningYieldMutator) / 100d;
            var ReprocessingStation = new ReprocessingPlant(ReprocessingFacility.GetFacility(ProductionType.Reprocessing), ImplantValue);

            // Update the material modifier based on the type of ore
            if (ItemGroup.Contains("Moon"))
            {
                ReprocessingStation.GetFacilility().MaterialMultiplier = ReprocessingStation.GetFacilility().MoonOreFacilityRefineRate;
            }
            else if (ItemGroup == "Ore")
            {
                ReprocessingStation.GetFacilility().MaterialMultiplier = ReprocessingStation.GetFacilility().OreFacilityRefineRate;
            }
            else if (ItemGroup == "Ice")
            {
                ReprocessingStation.GetFacilility().MaterialMultiplier = ReprocessingStation.GetFacilility().IceFacilityRefineRate;
            }
            else if (ItemGroup == "Scrap")
            {
                ReprocessingStation.GetFacilility().MaterialMultiplier = ReprocessingStation.GetFacilility().ScrapmetalRefineRate;
            }

            int RefineryEfficency = 0;

            if (cmbReprocessingEff.Enabled == true)
            {
                RefineryEfficency = Conversions.ToInteger(cmbReprocessingEff.Text);
            }

            // Refine the first item
            List<string> argRefinedMineralsList = null;
            TempOutputs = ReprocessingStation.Reprocess(ItemID, Conversions.ToInteger(cmbReprocessing.Text), RefineryEfficency, GetProcessingSkill(ItemName, ItemGroup), ItemQuantity, false, BFI, ref ReprocessingYield, ref ReprocessingUsage, RefinedMineralsList: ref argRefinedMineralsList);
            LocalReprocessingUsage = ReprocessingUsage;

            // If the items returned can be further refined, and we want to recursively refine, then send again
            if (RecursiveRefine)
            {
                // For each refined item, see if it can be refined further
                SQLiteDataReader rsRefine;

                foreach (var Mat in TempOutputs.GetMaterialList())
                {
                    Public_Variables.DBCommand = new SQLiteCommand("SELECT 'X' FROM REPROCESSING WHERE ITEM_ID = " + Mat.GetMaterialTypeID().ToString(), Public_Variables.EVEDB.DBREf());
                    rsRefine = Public_Variables.DBCommand.ExecuteReader();
                    rsRefine.Read();

                    if (rsRefine.HasRows)
                    {
                        // Refine the item again and add it's materials to the main list
                        ReprocessMaterial(Mat.GetMaterialTypeID(), Mat.GetMaterialName(), Mat.GetQuantity(), ItemGroup, chkRecursiveRefine.Checked, ref RecursiveOutput, ref ReprocessingYield, ref ReprocessingUsage);
                        // Add the final refined output to the main list
                        UpdatedOutputs.InsertMaterialList(RecursiveOutput.GetMaterialList());
                        // Save usage
                        LocalReprocessingUsage += ReprocessingUsage;
                    }
                    else
                    {
                        UpdatedOutputs.InsertMaterial(Mat);
                    }
                }
                TempOutputs = UpdatedOutputs;
            }

            MaterialOutputs = TempOutputs;
            ReprocessingYieldOutput = ReprocessingYield;
            ReprocessingFees = LocalReprocessingUsage;

        }

        // Updates the refine list if we are sent materials or if not, looking up in the DB for assets
        public void RefreshMaterialList(Materials PasteMaterialList = null)
        {
            string SQL = "";
            SQLiteDataReader readerItems;
            ListViewItem ItemlstViewRow;
            var CleanMaterialList = new Materials();
            var TempMaterialList = new Materials();
            Material TempMaterial;

            Application.UseWaitCursor = true;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            if (PasteMaterialList == null & !string.IsNullOrEmpty(Public_Variables.CopyPasteRefineryMaterialText))
            {
                // They refreshed prices most likely so use the original copy paste list they set
                PasteMaterialList = Public_Variables.ImportCopyPasteText(Public_Variables.CopyPasteRefineryMaterialText);
            }

            string IDString = "";

            if (PasteMaterialList == null)
            {
                // Read all the assets into the list as selected
                // Set the ID string we will use to update
                if (SettingsVariables.UserAssetWindowRefinerySettings.AssetType == "Both")
                {
                    IDString = Public_Variables.SelectedCharacter.ID.ToString() + "," + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString();
                }
                else if (SettingsVariables.UserAssetWindowRefinerySettings.AssetType == "Personal")
                {
                    IDString = Public_Variables.SelectedCharacter.ID.ToString();
                }
                else if (SettingsVariables.UserAssetWindowRefinerySettings.AssetType == "Corporation")
                {
                    IDString = Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString();
                }

                // Build the where clause to look up data
                string AssetLocationFlagList = "";
                // First look up the location and flagID pairs - unique ID of asset locations
                SQL = "SELECT LocationID, FlagID FROM ASSET_LOCATIONS WHERE EnumAssetType = " + ((int)AssetWindow.Refinery).ToString() + " AND ID IN (" + IDString + ")";
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerItems = Public_Variables.DBCommand.ExecuteReader();

                while (readerItems.Read())
                {
                    if (readerItems.GetInt32(1) == -4 | readerItems.GetInt64(0) > 1000000000000L)
                    {
                        // If the flag is the base location, then we want all items at the location id
                        AssetLocationFlagList += "(LocationID = " + readerItems.GetInt64(0).ToString() + ") OR ";
                    }
                    else
                    {
                        AssetLocationFlagList += "(LocationID = " + readerItems.GetInt64(0).ToString() + " AND Flag = " + readerItems.GetInt32(1).ToString() + ") OR ";
                    }
                }

                readerItems.Close();

                if (string.IsNullOrEmpty(AssetLocationFlagList))
                {
                    Interaction.MsgBox("You do not have an asset location selected", Constants.vbInformation, Application.ProductName);
                    Application.UseWaitCursor = false;
                    Cursor = Cursors.Default;
                    Application.DoEvents();
                    return;
                }
                else
                {
                    // Strip the last OR
                    AssetLocationFlagList = AssetLocationFlagList.Substring(0, Strings.Len(AssetLocationFlagList) - 4);
                }

                // Now get all the assets from the checked locations
                SQL = "SELECT IT.typeID, IT.typeName, SUM(Quantity), CASE WHEN IT.volume IS NULL THEN 1 ELSE IT.volume END FROM ";
                SQL += "ASSETS, INVENTORY_TYPES AS IT ";
                SQL += "WHERE (" + AssetLocationFlagList + ") ";
                SQL += "AND IT.typeID = ASSETS.TypeID ";
                SQL += "AND ID IN (" + IDString + ") ";
                SQL += "GROUP BY IT.typeID, IT.typeName, IT.volume ";

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerItems = Public_Variables.DBCommand.ExecuteReader();

                while (readerItems.Read())
                {
                    // Add each material to the temp list
                    {
                        ref var withBlock = ref readerItems;
                        TempMaterial = new Material(withBlock.GetInt64(0), withBlock.GetString(1), "", withBlock.GetInt64(2), withBlock.GetDouble(3), 0d, "", "");
                    }

                    TempMaterialList.InsertMaterial(TempMaterial);

                }
            }
            else
            {
                TempMaterialList = PasteMaterialList;
            }

            // First, only add items to the list that we can refine - filter out all the other junk
            foreach (var Mat in TempMaterialList.GetMaterialList())
            {
                SQL = "SELECT ITEM_ID, BELT_TYPE FROM REPROCESSING LEFT JOIN ORES ON REPROCESSING.ITEM_ID = ORES.ORE_ID ";
                SQL += "WHERE ITEM_ID =" + Mat.GetMaterialTypeID().ToString() + " GROUP BY ITEM_ID, BELT_TYPE ";
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerItems = Public_Variables.DBCommand.ExecuteReader();

                if (readerItems.Read())
                {
                    // Adjust GroupName for item type to set the refine rate with
                    if (!(readerItems.GetValue(1) is DBNull))
                    {
                        Mat.GroupName = readerItems.GetString(1);
                    }
                    else
                    {
                        Mat.GroupName = "Scrap";
                    }
                    // Found - add to list
                    CleanMaterialList.InsertMaterial(Mat);
                }
            }

            // Read through the list and insert the items, quantity, total value of the items
            IgnoreChecks = true;
            lstItemstoRefine.Items.Clear();
            lstItemstoRefine.BeginUpdate();
            lstItemstoRefine.Enabled = false;
            foreach (var ProcessMat in CleanMaterialList.GetMaterialList())
            {
                ItemlstViewRow = new ListViewItem(ProcessMat.GetMaterialName());
                ItemlstViewRow.SubItems.Add(Strings.FormatNumber(ProcessMat.GetQuantity(), 0));
                ItemlstViewRow.SubItems.Add(Strings.FormatNumber(ProcessMat.GetTotalCost(), 2));
                ItemlstViewRow.SubItems.Add("-");
                ItemlstViewRow.SubItems.Add("-");
                ItemlstViewRow.SubItems.Add("-");
                ItemlstViewRow.SubItems.Add(ProcessMat.GroupName);
                ItemlstViewRow.SubItems.Add(ProcessMat.GetMaterialTypeID().ToString());
                // Check the row if in not in the list
                ItemlstViewRow.Checked = GetCheckforItem(ProcessMat.GetMaterialTypeID());
                lstItemstoRefine.Items.Add(ItemlstViewRow);
                Application.DoEvents();
            }
            lstItemstoRefine.EndUpdate();
            lstItemstoRefine.Enabled = true;
            IgnoreChecks = false;

            // Sort the  list
            ListView argRefListView = lstItemstoRefine;
            var argListPrevColumnSortOrder = SortOrder.Ascending;
            Public_Variables.ListViewColumnSorter(ItemsColumnClicked, ref argRefListView, ref ItemsColumnClicked, ref argListPrevColumnSortOrder);

            Application.UseWaitCursor = false;
            Cursor = Cursors.Default;
            // Play notification sound
            Public_Variables.PlayNotifySound();
            Application.DoEvents();

        }

        public void RefreshRefiningRates()
        {
            {
                var withBlock = ReprocessingFacility.GetSelectedFacility();
                // These are bases rate without processing skills or implant
                lblOreRate.Text = Strings.FormatPercent(withBlock.OreFacilityRefineRate, 2);
                lblMoonRate.Text = Strings.FormatPercent(withBlock.MoonOreFacilityRefineRate, 2);
                lblIceRate.Text = Strings.FormatPercent(withBlock.IceFacilityRefineRate, 2);
                lblScrapRate.Text = Strings.FormatPercent(withBlock.ScrapmetalRefineRate, 2);
            }
        }

        // Returns the ore processing skill level on the screen for the ore name sent
        private int GetProcessingSkill(string ItemName, string ItemGroup)
        {
            if (ItemGroup == "Ice")
            {
                return Conversions.ToInteger(cmbOreProcessing12.Text);
            }
            else if (ItemGroup == "Scrap")
            {
                return Conversions.ToInteger(cmbScrapMetalProcessing.Text);
            }

            // It's an ore, so just return the processing value
            return Public_Variables.GetFormOreProcessingSkill(ItemName, ProcessingLabels, ProcessingCombos);

        }

        private void chkRecursiveRefine_CheckedChanged(object sender, EventArgs e)
        {

            SettingsVariables.UserApplicationSettings.RefineDrillDown = chkRecursiveRefine.Checked;
            // Save it
            SettingsVariables.AllSettings.SaveApplicationSettings(SettingsVariables.UserApplicationSettings);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void ClearItems()
        {
            lstItemstoRefine.Items.Clear();
            lstRefineOutput.Items.Clear();

            lblListTotalValueOutput.Text = "-";
            lblReturnRatePercentOutput.Text = "-";
            lblReprocessingValueOutput.Text = "-";
            lblReprocessingVolumeOutput.Text = "-";

        }

        private void btnCopyOutput_Click(object sender, EventArgs e)
        {
            CopyOutput();
        }

        private void btnCopyOutput2_Click(object sender, EventArgs e)
        {
            CopyOutput();
        }

        private void CopyOutput()
        {
            var ClipboardData = new DataObject();

            MaterialOutput.SortMaterialListByQuantity();

            // Paste to clipboard
            Public_Variables.CopyTextToClipboard(MaterialOutput.GetClipboardList(SettingsVariables.UserApplicationSettings.DataExportFormat, false, false, false, false));

        }

        private void frmReprocessingPlant_Disposed(object sender, EventArgs e)
        {
            Public_Variables.ReprocessingPlantOpen = false;
        }

        private void cmbRefining_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToInteger(cmbReprocessing.Text) >= 4)
            {
                cmbReprocessingEff.Enabled = true;
            }
            else
            {
                cmbReprocessingEff.Enabled = false;
            }
            // Update the ore processing skills
            UpdateProcessingSkills();
        }

        private void cmbRefineryEff_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the ore processing skills
            UpdateProcessingSkills();
        }

    }
}