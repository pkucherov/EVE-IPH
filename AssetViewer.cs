using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    // Types of Asset windows
    public enum AssetWindow
    {
        DefaultView = 0,
        ManufacturingTab = 1,
        ShoppingList = 2,
        Refinery = 3
    }

    public partial class AssetViewer
    {
        private bool ToggleAllOpen;
        private bool UpdatingChecks;
        private bool RefreshAssetButton;

        private AssetWindowSettings SelectedSettings;

        // The saved location ids
        private List<Public_Variables.LocationInfo> SavedLocationIDs;

        private readonly ControlsCollection m_ControlsCollection;
        private readonly CheckBox[] TechCheckBoxes = new CheckBox[7];
        private bool UpdateAllTechChecks = true; // Whether to update all Tech checks in items or not
        private bool FirstPriceShipTypesComboLoad;
        private bool FirstPriceChargeTypesComboLoad;

        // For checks that are enabled
        private bool PriceCheckT1Enabled;
        private bool PriceCheckT2Enabled;
        private bool PriceCheckT3Enabled;
        private bool PriceCheckT4Enabled;
        private bool PriceCheckT5Enabled;
        private bool PriceCheckT6Enabled;

        // Where the form was loaded from
        private AssetWindow WindowForm;

        private TreeNode AnchorNode;

        // Private AssetTreeTest As TriStateTreeView
        // For drawing checkboxes
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        #region Special processing for tree checks
        [StructLayout(LayoutKind.Sequential)]
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref TVITEM lParam);

        private void HideRootCheckBox(TreeNode node)
        {
            var tvi = new TVITEM()
            {
                hItem = node.Handle,
                mask = TVIF_STATE,
                stateMask = TVIS_STATEIMAGEMASK,
                state = 0
            };
            SendMessage(AssetTree.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }

        private void AssetTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // Don't show the top node with a check box
            if (e.Node.Parent is null)
            {
                HideRootCheckBox(e.Node);
            }

            // For high, mid, rigs, and low slots on ships, don't show check boxes
            if (e.Node.Text.Contains("power slot") | e.Node.Text.Contains("Personal Assets") | e.Node.Text.Contains("Corporation Assets"))
            {
                HideRootCheckBox(e.Node);
            }

            // Don't show a checkbox on any nodes without children
            if (e.Node.Nodes.Count == 0)
            {
                HideRootCheckBox(e.Node);
            }

            e.DrawDefault = true;

        }

        public Collection MyControls
        {
            get
            {
                return m_ControlsCollection.Controls;
            }
        }

        #endregion

        public AssetViewer()
        {

            // This call is required by the designer.
            InitializeComponent();

        }

        public void InitializeControl(AssetWindow AssetType, Character AssetCharacter)
        {
            WindowForm = AssetType;

            // Mark where the window is attached - can have multiple open
            switch (AssetType)
            {
                case AssetWindow.DefaultView:
                    {
                        Text = "Default Asset Viewer";
                        SelectedSettings = SettingsVariables.UserAssetWindowDefaultSettings;
                        break;
                    }
                case AssetWindow.ManufacturingTab:
                    {
                        Text = "Manufacturing Asset Viewer";
                        SelectedSettings = SettingsVariables.UserAssetWindowManufacturingTabSettings;
                        break;
                    }
                case AssetWindow.ShoppingList:
                    {
                        Text = "Shopping List Assets";
                        SelectedSettings = SettingsVariables.UserAssetWindowShoppingListSettings;
                        break;
                    }
                case AssetWindow.Refinery:
                    {
                        Text = "Refinery Assets";
                        SelectedSettings = SettingsVariables.UserAssetWindowRefinerySettings;
                        break;
                    }
            }

            // For this window, get the asset locations saved for the character
            SavedLocationIDs = AssetCharacter.Assets.GetAssetLocationIDs(WindowForm, AssetCharacter.ID, AssetCharacter.CharacterCorporation);

            // For the disabling of the price update form
            PriceCheckT1Enabled = true;
            PriceCheckT2Enabled = true;
            PriceCheckT3Enabled = true;
            PriceCheckT4Enabled = true;
            PriceCheckT5Enabled = true;
            PriceCheckT6Enabled = true;

            AssetTree.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            AssetTree.CheckBoxes = true;

            InitForm();

            // If we have no assets, then refresh the table to show that
            if (Public_Variables.SelectedCharacter.GetAssets().GetAssetCount() == 0L)
            {
                RefreshTree();
            }

        }

        // Initialize the form based on user settings
        private void InitForm()
        {

            Application.DoEvents();

            Public_Variables.FirstLoad = true;

            btnToggleExpand.Visible = true;
            btnToggleRetract.Visible = false;

            Timer1.Interval = 1000; // 1 second
            Timer1.Enabled = true;

            FirstPriceChargeTypesComboLoad = true;
            FirstPriceShipTypesComboLoad = true;

            btnScanCorpAssets.Enabled = false;
            btnScanPersonalAssets.Enabled = false;

            // Get Region check boxes (note index starts at 1)
            TechCheckBoxes[1] = chkItemsT1;
            TechCheckBoxes[2] = chkItemsT2;
            TechCheckBoxes[3] = chkItemsT3;
            TechCheckBoxes[4] = chkItemsT4;
            TechCheckBoxes[5] = chkItemsT5;
            TechCheckBoxes[6] = chkItemsT6;

            // Main form
            switch (SelectedSettings.AssetType ?? "")
            {
                case var @case when @case == (rbtnAllAssets.Text ?? ""):
                    {
                        rbtnAllAssets.Checked = true;
                        break;
                    }
                case var case1 when case1 == (rbtnPersonalAssets.Text ?? ""):
                    {
                        rbtnPersonalAssets.Checked = true;
                        break;
                    }
                case var case2 when case2 == (rbtnCorpAssets.Text ?? ""):
                    {
                        rbtnCorpAssets.Checked = true;
                        break;
                    }
            }

            if (SelectedSettings.SortbyName)
            {
                rbtnSortName.Checked = true;
            }
            else
            {
                rbtnSortQuantity.Checked = true;
            }

            lblReloadCorpAssets.Text = "---";
            lblReloadPersonalAssets.Text = "---";

            if (SettingsVariables.UserApplicationSettings.ShowToolTips)
            {
                ttMain.SetToolTip(btnToggleExpand, "Expand all Assets");
                ttMain.SetToolTip(btnToggleRetract, "Retract all Assets");
                ttMain.SetToolTip(chkToggle, "Check/Uncheck all Assets");
            }

            // Search settings form
            if (SelectedSettings.AllItems)
            {
                rbtnAllItems.Checked = true;
            }
            else
            {
                rbtnBPMats.Checked = true;
            }

            txtItemFilter.Text = SelectedSettings.ItemFilterText;

            // Load the search settings
            {
                ref var withBlock = ref SelectedSettings;
                chkMaterialResearchEqPrices.Checked = withBlock.AllRawMats;

                chkAdvancedProtectiveTechnology.Checked = withBlock.AdvancedProtectiveTechnology;
                chkGas.Checked = withBlock.Gas;
                chkIceProducts.Checked = withBlock.IceProducts;
                chkMolecularForgingTools.Checked = withBlock.MolecularForgingTools;
                chkFactionMaterials.Checked = withBlock.FactionMaterials;
                chkNamedComponents.Checked = withBlock.NamedComponents;
                chkMinerals.Checked = withBlock.Minerals;
                chkPlanetary.Checked = withBlock.Planetary;
                chkRawMaterials.Checked = withBlock.RawMaterials;
                chkSalvage.Checked = withBlock.Salvage;
                chkMisc.Checked = withBlock.Misc;
                chkBPCs.Checked = withBlock.BPCs;

                chkAdvancedMats.Checked = withBlock.AdvancedMoonMats;
                chkBoosterMats.Checked = withBlock.BoosterMats;
                chkMolecularForgedMaterials.Checked = withBlock.MolecularForgedMats;
                chkPolymers.Checked = withBlock.Polymers;
                chkProcessedMats.Checked = withBlock.ProcessedMoonMats;
                chkRawMoonMats.Checked = withBlock.RawMoonMats;

                chkAncientRelics.Checked = withBlock.AncientRelics;
                chkDatacores.Checked = withBlock.Datacores;
                chkDecryptors.Checked = withBlock.Decryptors;
                chkRDb.Checked = withBlock.RDB;

                chkManufacturedItems.Checked = withBlock.AllManufacturedItems;

                chkShips.Checked = withBlock.Ships;
                chkCharges.Checked = withBlock.Charges;
                chkModules.Checked = withBlock.Modules;
                chkDrones.Checked = withBlock.Drones;
                chkRigs.Checked = withBlock.Rigs;
                chkSubsystems.Checked = withBlock.Subsystems;
                chkDeployables.Checked = withBlock.Deployables;
                chkBoosters.Checked = withBlock.Boosters;
                chkStructures.Checked = withBlock.Structures;
                chkStructureRigs.Checked = withBlock.StructureRigs;
                chkCelestials.Checked = withBlock.Celestials;
                chkStructureModules.Checked = withBlock.StructureModules;
                chkImplants.Checked = withBlock.Implants;

                chkCapT2Components.Checked = withBlock.AdvancedCapComponents;
                chkAdvancedComponents.Checked = withBlock.AdvancedComponents;
                chkFuelBlocks.Checked = withBlock.FuelBlocks;
                chkProtectiveComponents.Checked = withBlock.ProtectiveComponents;
                chkRAM.Checked = withBlock.RAM;
                chkNobuild.Checked = withBlock.NoBuildItems;
                chkCapitalShipComponents.Checked = withBlock.CapitalShipComponents;
                chkStructureComponents.Checked = withBlock.StructureComponents;
                chkSubsystemComponents.Checked = withBlock.SubsystemComponents;

                chkItemsT1.Checked = withBlock.T1;
                chkItemsT2.Checked = withBlock.T2;
                chkItemsT3.Checked = withBlock.T3;
                chkItemsT4.Checked = withBlock.Storyline;
                chkItemsT5.Checked = withBlock.Faction;
                chkItemsT6.Checked = withBlock.Pirate;
            }

            Public_Variables.FirstLoad = false;

            // Everything will be just normal at first - add to settings for the format they save? Also, check the locations they have checked only TODO-AV!
            ToggleAllOpen = false;
            Application.DoEvents();

        }

        // Returns true if an selected item is checked
        private bool ItemsChecked()
        {

            if (chkAdvancedProtectiveTechnology.Checked)
                return true;
            if (chkGas.Checked)
                return true;
            if (chkIceProducts.Checked)
                return true;
            if (chkMolecularForgingTools.Checked)
                return true;
            if (chkFactionMaterials.Checked)
                return true;
            if (chkNamedComponents.Checked)
                return true;
            if (chkMinerals.Checked)
                return true;
            if (chkPlanetary.Checked)
                return true;
            if (chkRawMaterials.Checked)
                return true;
            if (chkSalvage.Checked)
                return true;
            if (chkMisc.Checked)
                return true;
            if (chkBPCs.Checked)
                return true;

            if (chkAdvancedMats.Checked)
                return true;
            if (chkBoosterMats.Checked)
                return true;
            if (chkMolecularForgedMaterials.Checked)
                return true;
            if (chkPolymers.Checked)
                return true;
            if (chkProcessedMats.Checked)
                return true;
            if (chkRawMoonMats.Checked)
                return true;

            if (chkAncientRelics.Checked)
                return true;
            if (chkDatacores.Checked)
                return true;
            if (chkDecryptors.Checked)
                return true;
            if (chkRDb.Checked)
                return true;

            if (chkShips.Checked)
                return true;
            if (chkCharges.Checked)
                return true;
            if (chkModules.Checked)
                return true;
            if (chkDrones.Checked)
                return true;
            if (chkRigs.Checked)
                return true;
            if (chkSubsystems.Checked)
                return true;
            if (chkDeployables.Checked)
                return true;
            if (chkBoosters.Checked)
                return true;
            if (chkStructures.Checked)
                return true;
            if (chkStructureRigs.Checked)
                return true;
            if (chkCelestials.Checked)
                return true;
            if (chkStructureModules.Checked)
                return true;
            if (chkImplants.Checked)
                return true;

            if (chkCapT2Components.Checked)
                return true;
            if (chkAdvancedComponents.Checked)
                return true;
            if (chkFuelBlocks.Checked)
                return true;
            if (chkProtectiveComponents.Checked)
                return true;
            if (chkRAM.Checked)
                return true;
            if (chkCapitalShipComponents.Checked)
                return true;
            if (chkStructureComponents.Checked)
                return true;
            if (chkSubsystemComponents.Checked)
                return true;

            // If we got here, nothing checked
            return false;

        }

        // Main function that refresh's the tree
        public void RefreshTree()
        {
            var BaseNode = new TreeNode();
            var SortOption = default(SortType);
            List<long> SearchItemList;
            bool OnlyBPCs; // Pass through if the BPIDs we sent need to only be shown if a copy

            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Make sure they have an item selected
            if (!ItemsChecked() & !rbtnAllItems.Checked)
            {
                Interaction.MsgBox("You must select an item category to display.", Constants.vbExclamation, Application.ProductName);
                tabMain.SelectedTab = tabSearchSettings;
                Cursor = Cursors.Default;
                Application.UseWaitCursor = false;
                return;
            }

            // Set the tree object
            AssetTree.Update();
            AssetTree.Nodes.Clear();

            if (rbtnSortName.Checked)
            {
                SortOption = SortType.Name;
            }
            else if (rbtnSortQuantity.Checked)
            {
                SortOption = SortType.Quantity;
            }

            // Get the list based on options selected, if not all or if all, they have a text item to search
            if (rbtnBPMats.Checked | !string.IsNullOrEmpty(Strings.Trim(txtItemFilter.Text)))
            {
                SearchItemList = GetSearchItemsList(rbtnAllItems.Checked);
            }
            else
            {
                SearchItemList = new List<long>();
            } // set to a blank list

            // Set OnlyBPCs
            if (chkBPCs.Checked & rbtnBPMats.Checked)
            {
                OnlyBPCs = true;
            }
            else
            {
                OnlyBPCs = false;
            }

            // Add the base node
            AnchorNode = AssetTree.Nodes.Add("Asset List");
            Application.DoEvents();

            // If we get nothing back from the search item list, then just clear the assets and exit - we have no items to display
            if (SearchItemList == null)
            {
                AssetTree.EndUpdate();
                AssetTree.Refresh();

                Application.UseWaitCursor = false;
                Application.DoEvents();
                Interaction.MsgBox("No items found.", Constants.vbInformation, Application.ProductName);
                Refresh();
                return;
            }

            // Get the base node of the full tree (may want to save these options globally so we don't need to load them every time)
            if (rbtnPersonalAssets.Checked | rbtnAllAssets.Checked)
            {
                BaseNode = Public_Variables.SelectedCharacter.GetAssets().GetAssetTreeAnchorNode(SortOption, SearchItemList, "Personal Assets", Public_Variables.SelectedCharacter.ID, SavedLocationIDs, ref OnlyBPCs);
                // Need to add it to the tree but as a clone
                AnchorNode.Nodes.Add((TreeNode)BaseNode.Clone());
            }
            if (rbtnCorpAssets.Checked | rbtnAllAssets.Checked)
            {
                BaseNode = Public_Variables.SelectedCharacter.CharacterCorporation.GetAssets().GetAssetTreeAnchorNode(SortOption, SearchItemList, "Corporation Assets", Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID, SavedLocationIDs, ref OnlyBPCs);
                // Need to add it to the tree but as a clone
                AnchorNode.Nodes.Add((TreeNode)BaseNode.Clone());
            }

            // Update
            AssetTree.EndUpdate();
            AssetTree.Refresh();

            // Open up the top node and the personal/corp nodes. Plus reset toggle since we just reloaded
            ToggleAllOpen = false;
            AnchorNode.Expand();
            AssetTree.Nodes[0].Nodes[0].Expand();
            if (rbtnAllAssets.Checked)
            {
                AssetTree.Nodes[0].Nodes[1].Expand();
            }

            // Expand all parents for check boxes that have values checked
            var argBaseTree = AssetTree;
            ExpandCheckedNodes(AssetTree.Nodes[0].Nodes, ref argBaseTree);
            AssetTree = argBaseTree;

            // Scroll to top
            AssetTree.TopNode = AssetTree.Nodes[0];

            Cursor = Cursors.Default;
            Application.DoEvents();

        }

        private void ExpandCheckedNodes(TreeNodeCollection NodeSet, ref TreeView BaseTree)
        {

            foreach (TreeNode node in NodeSet)
                FindCheckedNode(node, ref BaseTree);

        }

        private void FindCheckedNode(TreeNode SentNode, ref TreeView BaseTree)
        {

            foreach (TreeNode tn in SentNode.Nodes)
            {
                if (tn.Checked == true)
                {
                    BaseTree.SelectedNode = tn;
                    BaseTree.SelectedNode.Parent.Expand();
                }
                FindCheckedNode(tn, ref BaseTree);
            }
        }

        // Gets TypeIDs for items we only want to see in the asset tree from stuff we can set a price for
        private List<long> GetSearchItemsList(bool SearchAllItems)
        {
            var ItemIDList = new List<long>();
            SQLiteDataReader readerMats;
            string SQL;
            string TechSQL = "";
            bool TechChecked = false;
            bool ItemChecked = false;

            // Working
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // If we want all items, look in inventory types with links to groups/categories
            if (SearchAllItems)
            {
                // Get the item id from prices, since these are items we can set a price for and will be used in building items
                SQL = "SELECT typeID AS ITEM_ID FROM INVENTORY_TYPES, INVENTORY_GROUPS, INVENTORY_CATEGORIES ";
                SQL += "WHERE INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID ";
                SQL += "AND INVENTORY_GROUPS.categoryID = INVENTORY_CATEGORIES.categoryID ";

                // Search based on text
                if (!string.IsNullOrEmpty(txtItemFilter.Text))
                {
                    SQL += " AND typeName LIKE '%" + Public_Variables.FormatDBString(Strings.Trim(txtItemFilter.Text)) + "%' ";
                }

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                readerMats = Public_Variables.DBCommand.ExecuteReader();

                // Fill list
                while (readerMats.Read())
                    ItemIDList.Add(readerMats.GetInt64(0));

                readerMats.Close();
            }

            else
            {
                // Want just building materials (from prices)
                // Get the item id from prices, since these are items we can set a price for and will be used in building items
                SQL = "SELECT ITEM_ID FROM ITEM_PRICES, INVENTORY_TYPES";
                SQL += " WHERE ITEM_PRICES.ITEM_ID = INVENTORY_TYPES.typeID AND (";

                string GroupSQL = Public_Variables.GetItemPriceGroupListSQL(chkAdvancedComponents, chkAdvancedMats, chkAdvancedProtectiveTechnology, chkAncientRelics, chkBoosterMats, chkBoosters, chkBPCs, chkCapitalShipComponents, chkCapT2Components, chkCelestials, chkCharges, chkDatacores, chkDecryptors, chkDeployables, chkDrones, chkFactionMaterials, chkFuelBlocks, chkGas, chkIceProducts, chkImplants, chkMinerals, chkMisc, chkModules, chkMolecularForgedMaterials, chkMolecularForgingTools, chkNamedComponents, chkPlanetary, chkPolymers, chkProcessedMats, chkProtectiveComponents, chkRAM, chkRawMaterials, chkRawMoonMats, chkRDb, chkRigs, chkSalvage, chkShips, chkStructureComponents, chkStructureModules, chkStructureRigs, chkStructures, chkSubsystemComponents, chkSubsystems, cmbPriceChargeTypes, cmbPriceShipTypes, chkItemsT1, PriceCheckT1Enabled, chkItemsT2, PriceCheckT2Enabled, chkItemsT3, PriceCheckT3Enabled, chkItemsT4, PriceCheckT4Enabled, chkItemsT5, PriceCheckT5Enabled, chkItemsT6, PriceCheckT6Enabled, chkNobuild);

                // Leave function if no items checked
                if (!string.IsNullOrEmpty(GroupSQL))
                {
                    SQL += GroupSQL + ")";
                    // Search based on text
                    if (!string.IsNullOrEmpty(txtItemFilter.Text))
                    {
                        SQL += " AND ITEM_NAME LIKE '%" + Public_Variables.FormatDBString(Strings.Trim(txtItemFilter.Text)) + "%' ";
                    }

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerMats = Public_Variables.DBCommand.ExecuteReader();

                    // Fill list
                    while (readerMats.Read())
                        ItemIDList.Add(readerMats.GetInt64(0));

                    readerMats.Close();

                }

                // Blueprint Copies
                if (chkBPCs.Checked & !SearchAllItems)
                {
                    // Look up the typeIDs for all BPs and add them to the list
                    SQL = "SELECT BLUEPRINT_ID, ITEM_NAME FROM ALL_BLUEPRINTS ";
                    // Search based on text
                    if (!string.IsNullOrEmpty(txtItemFilter.Text))
                    {
                        SQL += " WHERE ITEM_NAME LIKE '%" + Public_Variables.FormatDBString(Strings.Trim(txtItemFilter.Text)) + "%' ";
                    }

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerMats = Public_Variables.DBCommand.ExecuteReader();

                    // Fill list
                    while (readerMats.Read())
                        ItemIDList.Add(readerMats.GetInt64(0));

                    readerMats.Close();

                }

            }

            Cursor = Cursors.Default;
            Application.DoEvents();

            // If we have no items to return, then return nothing not a blank list
            if (ItemIDList.Count == 0)
            {
                return null;
            }
            else
            {
                return ItemIDList;
            }

        }

        // Just loads the assets from API then DB
        private void ScanForAssets(Public_Variables.ScanType BPScanType)
        {

            // New scan, so run update and reload assets
            if (BPScanType == Public_Variables.ScanType.Personal)
            {
                Public_Variables.SelectedCharacter.GetAssets().LoadAssets(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, true);
            }
            else
            {
                Public_Variables.SelectedCharacter.CharacterCorporation.GetAssets().LoadAssets(Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID, Public_Variables.SelectedCharacter.CharacterTokenData, true);
            }

            // Reload the tree
            RefreshTree();

        }

        // Will use CAK and scan for bps in the user's items and store a temp table of these bps for loading in the grid
        private void btnScanPersonalBPs_Click(object sender, EventArgs e)
        {

            RefreshAssetButton = true;
            Cursor = Cursors.WaitCursor;
            if (rbtnAllAssets.Checked == false)
            {
                rbtnPersonalAssets.Checked = true;
            }

            Application.DoEvents();

            if (Public_Variables.SelectedCharacter.AssetsAccess)
            {
                ScanForAssets(Public_Variables.ScanType.Personal);
            }
            else
            {
                Interaction.MsgBox("You have not enabled access to Assets with this key.", Constants.vbExclamation, Application.ProductName);
            }

            Cursor = Cursors.Default;
            Application.DoEvents();

            RefreshAssetButton = false;

        }

        // Will use CAK and scan for bps in the corps items and store a temp table of these bps for loading in the grid
        private void btnScanCorpBPs_Click(object sender, EventArgs e)
        {

            RefreshAssetButton = true;
            Cursor = Cursors.WaitCursor;
            if (rbtnAllAssets.Checked == false)
            {
                rbtnCorpAssets.Checked = true;
            }

            Application.DoEvents();

            if (Public_Variables.SelectedCharacter.CharacterCorporation.AssetAccess)
            {
                ScanForAssets(Public_Variables.ScanType.Corporation);
            }
            else
            {
                Interaction.MsgBox("You do not have a corporation key installed with access to Assets.", Constants.vbExclamation, Application.ProductName);
            }

            Cursor = Cursors.Default;
            Application.DoEvents();

            RefreshAssetButton = false;

        }

        // Displays the time remaining on refreshing assets
        private void Timer1_Tick(object sender, EventArgs e)
        {
            long TempTime;

            // On each tick just update the labels
            if (Public_Variables.SelectedCharacter.AssetsAccess)
            {
                TempTime = DateAndTime.DateDiff(DateInterval.Second, DateTime.UtcNow, Public_Variables.SelectedCharacter.GetAssets().CachedUntil);
                if (TempTime <= 0L)
                {
                    lblReloadPersonalAssets.Text = "Now";
                }
                else
                {
                    lblReloadPersonalAssets.Text = Public_Variables.FormatTimeToComplete(TempTime);
                }
            }
            else
            {
                lblReloadPersonalAssets.Text = "No Access";
            }

            if (lblReloadPersonalAssets.Text == "Now")
            {
                // Enable refresh button
                btnScanPersonalAssets.Enabled = true;
            }
            else
            {
                btnScanPersonalAssets.Enabled = false;
            }

            if (Public_Variables.SelectedCharacter.CharacterCorporation.AssetAccess)
            {
                TempTime = DateAndTime.DateDiff(DateInterval.Second, DateTime.UtcNow, Public_Variables.SelectedCharacter.CharacterCorporation.GetAssets().CachedUntil);
                if (TempTime <= 0L)
                {
                    lblReloadCorpAssets.Text = "Now";
                }
                else
                {
                    lblReloadCorpAssets.Text = Public_Variables.FormatTimeToComplete(TempTime);
                }
            }
            else
            {
                lblReloadCorpAssets.Text = "No Access";
            }

            if (lblReloadCorpAssets.Text == "Now")
            {
                // Enable refresh button
                btnScanCorpAssets.Enabled = true;
            }
            else
            {
                btnScanCorpAssets.Enabled = false;
            }
        }

        // Saves the settings on the Selected Items Form for later loading
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {

            SaveWindowSettings();

        }

        // Saves the main settings for the general form
        private void btnSaveMainSettings_Click(object sender, EventArgs e)
        {

            SaveWindowSettings();

        }

        // Saves the settings on both tabs for the asset window
        private void SaveWindowSettings()
        {
            AssetWindowSettings TempSettings = default;
            var TempLocationIDs = new List<long>();
            string SQL;

            TempSettings.SortbyName = rbtnSortName.Checked;

            if (rbtnAllAssets.Checked)
            {
                TempSettings.AssetType = rbtnAllAssets.Text;
            }
            else if (rbtnPersonalAssets.Checked)
            {
                TempSettings.AssetType = rbtnPersonalAssets.Text;
            }
            else if (rbtnCorpAssets.Checked)
            {
                TempSettings.AssetType = rbtnCorpAssets.Text;
            }

            if (rbtnAllItems.Checked)
            {
                TempSettings.AllItems = true;
            }
            else
            {
                TempSettings.AllItems = false;
            }

            TempSettings.AllRawMats = chkMaterialResearchEqPrices.Checked;

            TempSettings.AdvancedProtectiveTechnology = chkAdvancedProtectiveTechnology.Checked;
            TempSettings.Gas = chkGas.Checked;
            TempSettings.IceProducts = chkIceProducts.Checked;
            TempSettings.MolecularForgingTools = chkMolecularForgingTools.Checked;
            TempSettings.FactionMaterials = chkFactionMaterials.Checked;
            TempSettings.NamedComponents = chkNamedComponents.Checked;
            TempSettings.Minerals = chkMinerals.Checked;
            TempSettings.Planetary = chkPlanetary.Checked;
            TempSettings.RawMaterials = chkRawMaterials.Checked;
            TempSettings.Salvage = chkSalvage.Checked;
            TempSettings.Misc = chkMisc.Checked;
            TempSettings.BPCs = chkBPCs.Checked;

            TempSettings.AdvancedMoonMats = chkAdvancedMats.Checked;
            TempSettings.BoosterMats = chkBoosterMats.Checked;
            TempSettings.MolecularForgedMats = chkMolecularForgedMaterials.Checked;
            TempSettings.Polymers = chkPolymers.Checked;
            TempSettings.ProcessedMoonMats = chkProcessedMats.Checked;
            TempSettings.RawMoonMats = chkRawMoonMats.Checked;

            TempSettings.AncientRelics = chkAncientRelics.Checked;
            TempSettings.Datacores = chkDatacores.Checked;
            TempSettings.Decryptors = chkDecryptors.Checked;
            TempSettings.RDB = chkRDb.Checked;

            TempSettings.AllManufacturedItems = chkManufacturedItems.Checked;

            TempSettings.Ships = chkShips.Checked;
            TempSettings.Charges = chkCharges.Checked;
            TempSettings.Modules = chkModules.Checked;
            TempSettings.Drones = chkDrones.Checked;
            TempSettings.Rigs = chkRigs.Checked;
            TempSettings.Subsystems = chkSubsystems.Checked;
            TempSettings.Deployables = chkDeployables.Checked;
            TempSettings.Boosters = chkBoosters.Checked;
            TempSettings.Structures = chkStructures.Checked;
            TempSettings.StructureRigs = chkStructureRigs.Checked;
            TempSettings.Celestials = chkCelestials.Checked;
            TempSettings.StructureModules = chkStructureModules.Checked;
            TempSettings.Implants = chkImplants.Checked;

            TempSettings.AdvancedCapComponents = chkCapT2Components.Checked;
            TempSettings.AdvancedComponents = chkAdvancedComponents.Checked;
            TempSettings.FuelBlocks = chkFuelBlocks.Checked;
            TempSettings.ProtectiveComponents = chkProtectiveComponents.Checked;
            TempSettings.RAM = chkRAM.Checked;
            TempSettings.NoBuildItems = chkNobuild.Checked;
            TempSettings.CapitalShipComponents = chkCapitalShipComponents.Checked;
            TempSettings.StructureComponents = chkStructureComponents.Checked;
            TempSettings.SubsystemComponents = chkSubsystemComponents.Checked;

            TempSettings.T1 = chkItemsT1.Checked;
            TempSettings.T2 = chkItemsT2.Checked;
            TempSettings.T3 = chkItemsT3.Checked;
            TempSettings.Storyline = chkItemsT4.Checked;
            TempSettings.Faction = chkItemsT5.Checked;
            TempSettings.Pirate = chkItemsT6.Checked;

            // Finally get all the locations from the checked data move from saved
            SavedLocationIDs = GetCheckedLocations(AssetTree.Nodes[0]);

            // Since a lot of locations will bog down the settings loading, store in a table for this character and corporation
            Public_Variables.EVEDB.BeginSQLiteTransaction();

            // First clear out any records in there for both the account and corp assets on the account
            SQL = "DELETE FROM ASSET_LOCATIONS WHERE EnumAssetType = " + ((int)WindowForm).ToString();
            SQL += " AND ID IN (" + Public_Variables.SelectedCharacter.ID.ToString() + "," + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString() + ")";
            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

            for (int i = 0, loopTo = SavedLocationIDs.Count - 1; i <= loopTo; i++)
            {
                SQL = "INSERT INTO ASSET_LOCATIONS (EnumAssetType, ID, LocationID, FlagID) VALUES ";
                SQL += "(" + ((int)WindowForm).ToString() + "," + SavedLocationIDs[i].AccountID.ToString() + "," + SavedLocationIDs[i].LocationID.ToString() + "," + SavedLocationIDs[i].FlagID.ToString() + ")";
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
            }


            Public_Variables.EVEDB.CommitSQLiteTransaction();

            // Save the data in the XML file
            SettingsVariables.AllSettings.SaveAssetWindowSettings(TempSettings, WindowForm);

            // Save the data to the local variable
            switch (WindowForm)
            {
                case AssetWindow.DefaultView:
                    {
                        SettingsVariables.UserAssetWindowDefaultSettings = TempSettings;
                        break;
                    }
                case AssetWindow.ManufacturingTab:
                    {
                        SettingsVariables.UserAssetWindowManufacturingTabSettings = TempSettings;
                        break;
                    }
                case AssetWindow.ShoppingList:
                    {
                        SettingsVariables.UserAssetWindowShoppingListSettings = TempSettings;
                        break;
                    }
                case AssetWindow.Refinery:
                    {
                        SettingsVariables.UserAssetWindowRefinerySettings = TempSettings;
                        break;
                    }
            }

            Interaction.MsgBox("Asset Window Settings Saved", Constants.vbInformation, Application.ProductName);
            btnSaveSettings.Focus();
            Application.UseWaitCursor = false;

        }

        // Gets all the checked locations in the tree
        private List<Public_Variables.LocationInfo> GetCheckedLocations(TreeNode SentNode)
        {
            var LocationIDList = new List<Public_Variables.LocationInfo>();
            var RList = new List<Public_Variables.LocationInfo>();

            foreach (TreeNode SubNode in SentNode.Nodes)
            {
                if (!(SubNode.Tag == null))
                {
                    var TempPair = new Public_Variables.LocationInfo();
                    TempPair = (Public_Variables.LocationInfo)SubNode.Tag;

                    if (SubNode.Checked & TempPair.LocationID != -1)
                    {
                        // SubNode tag is a location pair
                        LocationIDList.Add((Public_Variables.LocationInfo)SubNode.Tag);
                    }

                    if (SubNode.Nodes.Count > 0)
                    {
                        RList = GetCheckedLocations(SubNode);
                    }

                    if (RList.Count != 0)
                    {
                        // Add to main list
                        LocationIDList.AddRange(RList);
                    }
                }
            }

            return LocationIDList;

        }

        #region Click Events

        private void btnCloseAssets_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void btnToggleExpand_Click(object sender, EventArgs e)
        {

        }

        private void btnToggleRetract_Click(object sender, EventArgs e)
        {

        }

        private void txtItemFilter_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtItemFilter, e);
            if (e.KeyCode == Keys.Enter)
            {
                RefreshTree();
            }
        }

        private void btnRefreshMain_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void rbtnCorpAssets_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCorpAssets.Checked & !Public_Variables.FirstLoad & !RefreshAssetButton)
            {
                RefreshTree();
            }
        }

        private void rbtnPersonalAssets_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPersonalAssets.Checked & !Public_Variables.FirstLoad & !RefreshAssetButton)
            {
                RefreshTree();
            }
        }

        private void btnAllAssets_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAllAssets.Checked & !Public_Variables.FirstLoad & !RefreshAssetButton)
            {
                RefreshTree();
            }
        }

        private void rbtnSortQuantity_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSortQuantity.Checked & !Public_Variables.FirstLoad)
            {
                RefreshTree();
            }
        }

        private void rbtnSortName_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSortName.Checked & !Public_Variables.FirstLoad)
            {
                RefreshTree();
            }
        }

        private void btnResetItemFilter_Click(object sender, EventArgs e)
        {
            txtItemFilter.Text = "";
            chkManufacturedItems.Checked = true;
            chkMaterialResearchEqPrices.Checked = true;
        }

        private void chkRawMaterialItems_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllRawItems();
        }

        private void chkManufacturedItems_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllManufacturedItems();
        }

        // Checks or unchecks just the prices for raw material items
        private void CheckAllRawItems()
        {

            UpdatingChecks = false;

            // Check all item boxes and do not run updates
            if (chkMaterialResearchEqPrices.Checked == true)
            {
                chkAdvancedProtectiveTechnology.Checked = true;
                chkGas.Checked = true;
                chkIceProducts.Checked = true;
                chkMolecularForgingTools.Checked = true;
                chkFactionMaterials.Checked = true;
                chkNamedComponents.Checked = true;
                chkMinerals.Checked = true;
                chkPlanetary.Checked = true;
                chkRawMaterials.Checked = true;
                chkSalvage.Checked = true;
                chkMisc.Checked = true;
                chkBPCs.Checked = true;

                chkAdvancedMats.Checked = true;
                chkBoosterMats.Checked = true;
                chkMolecularForgedMaterials.Checked = true;
                chkPolymers.Checked = true;
                chkProcessedMats.Checked = true;
                chkRawMoonMats.Checked = true;

                chkAncientRelics.Checked = true;
                chkDatacores.Checked = true;
                chkDecryptors.Checked = true;
                chkRDb.Checked = true;
            }

            else // Turn off all item checks
            {
                chkAdvancedProtectiveTechnology.Checked = false;
                chkGas.Checked = false;
                chkIceProducts.Checked = false;
                chkMolecularForgingTools.Checked = false;
                chkFactionMaterials.Checked = false;
                chkNamedComponents.Checked = false;
                chkMinerals.Checked = false;
                chkPlanetary.Checked = false;
                chkRawMaterials.Checked = false;
                chkSalvage.Checked = false;
                chkMisc.Checked = false;
                chkBPCs.Checked = false;

                chkAdvancedMats.Checked = false;
                chkBoosterMats.Checked = false;
                chkMolecularForgedMaterials.Checked = false;
                chkPolymers.Checked = false;
                chkProcessedMats.Checked = false;
                chkRawMoonMats.Checked = false;

                chkAncientRelics.Checked = false;
                chkDatacores.Checked = false;
                chkDecryptors.Checked = false;
                chkRDb.Checked = false;
            }

            UpdatingChecks = true;

        }

        // Checks or unchecks just the prices for manufactured items
        private void CheckAllManufacturedItems()
        {

            UpdatingChecks = false;

            // Check all item boxes and do not run updates
            if (chkManufacturedItems.Checked == true)
            {
                chkShips.Checked = true;
                chkCharges.Checked = true;
                chkModules.Checked = true;
                chkDrones.Checked = true;
                chkRigs.Checked = true;
                chkSubsystems.Checked = true;
                chkDeployables.Checked = true;
                chkBoosters.Checked = true;
                chkStructures.Checked = true;
                chkStructureRigs.Checked = true;
                chkCelestials.Checked = true;
                chkStructureModules.Checked = true;
                chkImplants.Checked = true;

                chkCapT2Components.Checked = true;
                chkAdvancedComponents.Checked = true;
                chkFuelBlocks.Checked = true;
                chkProtectiveComponents.Checked = true;
                chkRAM.Checked = true;
                chkCapitalShipComponents.Checked = true;
                chkStructureComponents.Checked = true;
                chkSubsystemComponents.Checked = true;
            }

            else // Turn off all item checks
            {
                chkShips.Checked = false;
                chkCharges.Checked = false;
                chkModules.Checked = false;
                chkDrones.Checked = false;
                chkRigs.Checked = false;
                chkSubsystems.Checked = false;
                chkDeployables.Checked = false;
                chkBoosters.Checked = false;
                chkStructures.Checked = false;
                chkStructureRigs.Checked = false;
                chkCelestials.Checked = false;
                chkStructureModules.Checked = false;
                chkImplants.Checked = false;

                chkCapT2Components.Checked = false;
                chkAdvancedComponents.Checked = false;
                chkFuelBlocks.Checked = false;
                chkProtectiveComponents.Checked = false;
                chkRAM.Checked = false;
                chkCapitalShipComponents.Checked = false;
                chkStructureComponents.Checked = false;
                chkSubsystemComponents.Checked = false;

            }

            UpdatingChecks = true;

        }

        // Makes sure a tech is enabled and checked for items that require tech based on saved values, not current due to disabling form
        private bool CheckTechChecks()
        {

            if (PriceCheckT1Enabled)
            {
                if (TechCheckBoxes[1].Checked)
                {
                    return true;
                }
            }

            if (PriceCheckT2Enabled)
            {
                if (TechCheckBoxes[2].Checked)
                {
                    return true;
                }
            }

            if (PriceCheckT3Enabled)
            {
                if (TechCheckBoxes[3].Checked)
                {
                    return true;
                }
            }

            if (PriceCheckT4Enabled)
            {
                if (TechCheckBoxes[4].Checked)
                {
                    return true;
                }
            }

            if (PriceCheckT5Enabled)
            {
                if (TechCheckBoxes[5].Checked)
                {
                    return true;
                }
            }

            if (PriceCheckT6Enabled)
            {
                if (TechCheckBoxes[6].Checked)
                {
                    return true;
                }
            }

            return false;

        }

        // Updates the T1, T2 and T3 check boxes depending on item selections
        private void UpdateTechChecks()
        {
            bool T1 = false;
            bool T2 = false;
            bool T3 = false;
            bool Storyline = false;
            bool Navy = false;
            bool Pirate = false;

            bool ItemsSelected = false;
            int i;
            bool TechChecks = false;

            // For check all 
            if (!UpdatingChecks & UpdateAllTechChecks)
            {
                UpdateAllTechChecks = false;
                // Check all and leave
                var loopTo = TechCheckBoxes.Length - 1;
                for (i = 1; i <= loopTo; i++)
                {
                    TechCheckBoxes[i].Enabled = true;
                    // Check this one and leave
                    TechCheckBoxes[i].Checked = true;
                }
                return;
            }

            // Check each item checked and set the check boxes accordingly
            if (chkShips.Checked)
            {
                T1 = true;
                T2 = true;
                T3 = true;
                Navy = true;
                Pirate = true;
                ItemsSelected = true;
            }

            if (chkModules.Checked)
            {
                T1 = true;
                T2 = true;
                Navy = true;
                Storyline = true;
                ItemsSelected = true;
            }

            if (chkSubsystems.Checked)
            {
                T3 = true;
                ItemsSelected = true;
            }

            if (chkDrones.Checked)
            {
                T1 = true;
                T2 = true;
                ItemsSelected = true;
            }

            if (chkRigs.Checked)
            {
                T1 = true;
                T2 = true;
                ItemsSelected = true;
            }

            if (chkBoosters.Checked)
            {
                T1 = true;
                ItemsSelected = true;
            }

            if (chkStructures.Checked)
            {
                T1 = true;
                ItemsSelected = true;
            }

            if (chkCharges.Checked)
            {
                T1 = true;
                T2 = true;
                ItemsSelected = true;
            }

            // If none are checked, then uncheck and un-enable all
            if (ItemsSelected)
            {

                // Enable the Checks
                if (T1)
                {
                    chkItemsT1.Enabled = true;
                }
                else
                {
                    chkItemsT1.Enabled = false;
                }

                if (T2)
                {
                    chkItemsT2.Enabled = true;
                }
                else
                {
                    chkItemsT2.Enabled = false;
                }

                if (T3)
                {
                    chkItemsT3.Enabled = true;
                }
                else
                {
                    chkItemsT3.Enabled = false;
                }

                if (Storyline)
                {
                    chkItemsT4.Enabled = true;
                }
                else
                {
                    chkItemsT4.Enabled = false;
                }

                if (Navy)
                {
                    chkItemsT5.Enabled = true;
                }
                else
                {
                    chkItemsT5.Enabled = false;
                }

                if (Pirate)
                {
                    chkItemsT6.Enabled = true;
                }
                else
                {
                    chkItemsT6.Enabled = false;
                }

                // Make sure we have at le=t one checked
                var loopTo1 = TechCheckBoxes.Length - 1;
                for (i = 1; i <= loopTo1; i++)
                {
                    if (TechCheckBoxes[i].Enabled)
                    {
                        if (TechCheckBoxes[i].Checked)
                        {
                            TechChecks = true;
                            // Found one enabled and checked, so leave for
                            break;
                        }
                    }
                }

                if (!TechChecks)
                {
                    // Need to check at le=t one
                    var loopTo2 = TechCheckBoxes.Length - 1;
                    for (i = 1; i <= loopTo2; i++)
                    {
                        if (TechCheckBoxes[i].Enabled)
                        {
                            // Check this one and leave
                            TechCheckBoxes[i].Checked = true;
                        }
                    }
                }
            }

            else
            {
                chkItemsT1.Enabled = false;
                chkItemsT2.Enabled = false;
                chkItemsT3.Enabled = false;
                chkItemsT4.Enabled = false;
                chkItemsT5.Enabled = false;
                chkItemsT6.Enabled = false;
            }

            // Save status of the Tech check boxes
            PriceCheckT1Enabled = chkItemsT1.Enabled;
            PriceCheckT2Enabled = chkItemsT2.Enabled;
            PriceCheckT3Enabled = chkItemsT3.Enabled;
            PriceCheckT4Enabled = chkItemsT4.Enabled;
            PriceCheckT5Enabled = chkItemsT5.Enabled;
            PriceCheckT6Enabled = chkItemsT6.Enabled;

        }

        private void cmbPriceShipTypes_DropDown(object sender, EventArgs e)
        {
            if (FirstPriceShipTypesComboLoad)
            {
                LoadPriceShipTypes();
                FirstPriceShipTypesComboLoad = false;
            }
        }

        private void cmbPriceChargeTypes_DropDown(object sender, EventArgs e)
        {
            if (FirstPriceChargeTypesComboLoad)
            {
                LoadPriceChargeTypes();
                FirstPriceChargeTypesComboLoad = false;
            }
        }

        private void LoadPriceShipTypes()
        {
            string SQL;
            SQLiteDataReader readerShipType;

            // Load the select systems combobox with systems
            SQL = "SELECT groupName from inventory_types, inventory_groups, inventory_categories ";
            SQL += "WHERE  inventory_types.groupID = inventory_groups.groupID ";
            SQL += "AND inventory_groups.categoryID = inventory_categories.categoryID ";
            SQL += "AND categoryname = 'Ship' AND groupName NOT IN ('Rookie ship','Prototype Exploration Ship') ";
            SQL += "AND inventory_types.published <> 0 and inventory_groups.published <> 0 and inventory_categories.published <> 0 ";
            SQL += "GROUP BY groupName ";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerShipType = Public_Variables.DBCommand.ExecuteReader();

            cmbPriceShipTypes.Items.Add("All Ship Types");

            while (readerShipType.Read())
                cmbPriceShipTypes.Items.Add(readerShipType.GetString(0));

            readerShipType.Close();

            cmbPriceShipTypes.Text = "All Ship Types";

        }

        private void LoadPriceChargeTypes()
        {
            string SQL;
            SQLiteDataReader readerChargeType;

            // Load the select systems combobox with systems
            SQL = "SELECT groupName from inventory_types, inventory_groups, inventory_categories ";
            SQL += "WHERE  inventory_types.groupID = inventory_groups.groupID ";
            SQL += "AND inventory_groups.categoryID = inventory_categories.categoryID ";
            SQL += "AND categoryname = 'Charge' ";
            SQL += "AND inventory_types.published <> 0 and inventory_groups.published <> 0 and inventory_categories.published <> 0 ";
            SQL += "GROUP BY groupName ";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerChargeType = Public_Variables.DBCommand.ExecuteReader();

            cmbPriceChargeTypes.Items.Add("All Charge Types");

            while (readerChargeType.Read())
                cmbPriceChargeTypes.Items.Add(readerChargeType.GetString(0));

            readerChargeType.Close();

            cmbPriceChargeTypes.Text = "All Charge Types";

        }

        private void chkBoosters_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTechChecks();
        }

        private void chkRigs_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTechChecks();
        }

        private void chkShips_CheckedChanged(object sender, EventArgs e)
        {

            if (chkShips.Checked == true)
            {
                cmbPriceShipTypes.Enabled = true;
            }
            else if (chkShips.Checked == false)
            {
                cmbPriceShipTypes.Enabled = false;
            }

            UpdateTechChecks();

        }

        private void chkModules_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTechChecks();
        }

        private void chkDrones_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTechChecks();
        }

        private void chkCharges_CheckedChanged(object sender, EventArgs e)
        {

            if (chkCharges.Checked == true)
            {
                cmbPriceChargeTypes.Enabled = true;
            }
            else if (chkCharges.Checked == false)
            {
                cmbPriceChargeTypes.Enabled = false;
            }

            UpdateTechChecks();

        }

        private void chkSubsystems_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTechChecks();
        }

        private void chkStructures_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTechChecks();
        }

        private void rbtnAllItems_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAllItems.Checked)
            {
                // Don't enable checks
                gbRawMaterials.Enabled = false;
                gbManufacturedItems.Enabled = false;
            }
        }

        private void rbtnBPMats_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBPMats.Checked)
            {
                // Enable checks
                gbRawMaterials.Enabled = true;
                gbManufacturedItems.Enabled = true;
                UpdateTechChecks();
            }
        }

        #endregion

    }
}