using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmBlueprintList
    {

        public event BPSelectedEventHandler BPSelected;

        public delegate void BPSelectedEventHandler(string bpName);

        private class NodeTag
        {
            public string FilterField { get; set; }
            public int? FilterValue { get; set; }
            public NodeTag(string @field, int? value)
            {
                FilterField = @field;
                FilterValue = value;
            }
        }

        private bool FirstFormLoad;

        public frmBlueprintList()
        {

            FirstFormLoad = true;

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            lblIntro.Text = "Expand the tree to locate a Blueprint." + Environment.NewLine + "Double-Click on it to load it into the main window." + Environment.NewLine + "This window will remain open unless you click Close.";

            // Load settings, which will fire handler to set top nodes for the saved options
            InitForm();

            // Load the tree
            SetTopNodes();

            FirstFormLoad = false;

        }

        // Loads settings on the form
        private void InitForm()
        {

            {
                ref var withBlock = ref SettingsVariables.UserBPViewerSettings;
                // Load saved settings
                switch (withBlock.BlueprintTypeSelection ?? "")
                {
                    case var @case when @case == (rbtnBPAll.Text ?? ""):
                        {
                            rbtnBPAll.Checked = true;
                            break;
                        }
                    case var case1 when case1 == (rbtnBPOwnedBlueprints.Text ?? ""):
                        {
                            rbtnBPOwnedBlueprints.Checked = true;
                            break;
                        }
                    case var case2 when case2 == (rbtnBPFavoriteBlueprints.Text ?? ""):
                        {
                            rbtnBPFavoriteBlueprints.Checked = true;
                            break;
                        }
                    case var case3 when case3 == (rbtnBPShipBlueprints.Text ?? ""):
                        {
                            rbtnBPShipBlueprints.Checked = true;
                            break;
                        }
                    case var case4 when case4 == (rbtnBPDroneBlueprints.Text ?? ""):
                        {
                            rbtnBPDroneBlueprints.Checked = true;
                            break;
                        }
                    case var case5 when case5 == (rbtnBPAmmoChargeBlueprints.Text ?? ""):
                        {
                            rbtnBPAmmoChargeBlueprints.Checked = true;
                            break;
                        }
                    case var case6 when case6 == (rbtnBPModuleBlueprints.Text ?? ""):
                        {
                            rbtnBPModuleBlueprints.Checked = true;
                            break;
                        }
                    case var case7 when case7 == (rbtnBPComponentBlueprints.Text ?? ""):
                        {
                            rbtnBPComponentBlueprints.Checked = true;
                            break;
                        }
                    case var case8 when case8 == (rbtnBPStructureBlueprints.Text ?? ""):
                        {
                            rbtnBPStructureBlueprints.Checked = true;
                            break;
                        }
                    case var case9 when case9 == (rbtnBPSubsystemBlueprints.Text ?? ""):
                        {
                            rbtnBPSubsystemBlueprints.Checked = true;
                            break;
                        }
                    case var case10 when case10 == (rbtnBPRigBlueprints.Text ?? ""):
                        {
                            rbtnBPRigBlueprints.Checked = true;
                            break;
                        }
                    case var case11 when case11 == (rbtnBPBoosterBlueprints.Text ?? ""):
                        {
                            rbtnBPBoosterBlueprints.Checked = true;
                            break;
                        }
                    case var case12 when case12 == (rbtnBPMiscBlueprints.Text ?? ""):
                        {
                            rbtnBPMiscBlueprints.Checked = true;
                            break;
                        }
                    case var case13 when case13 == (rbtnBPDeployableBlueprints.Text ?? ""):
                        {
                            rbtnBPDeployableBlueprints.Checked = true;
                            break;
                        }
                    case var case14 when case14 == (rbtnBPCelestialsBlueprints.Text ?? ""):
                        {
                            rbtnBPCelestialsBlueprints.Checked = true;
                            break;
                        }
                    case var case15 when case15 == (rbtnBPStructureRigsBlueprints.Text ?? ""):
                        {
                            rbtnBPStructureRigsBlueprints.Checked = true;
                            break;
                        }
                    case var case16 when case16 == (rbtnBPReactionBlueprints.Text ?? ""):
                        {
                            rbtnBPReactionBlueprints.Checked = true;
                            break;
                        }
                }

                chkBPNPCBPOs.Checked = withBlock.BPNPCBPOsCheck;

                chkBPTech1.Checked = withBlock.Tech1Check;
                chkBPTech2.Checked = withBlock.Tech2Check;
                chkBPTech3.Checked = withBlock.Tech3Check;
                chkBPNavy.Checked = withBlock.TechFactionCheck;
                chkBPStory.Checked = withBlock.TechStorylineCheck;
                chkBPPirate.Checked = withBlock.TechPirateCheck;

                // chkBPIncludeIgnoredBPs.Checked = .IncludeIgnoredBPs

                chkBPSmall.Checked = withBlock.SmallCheck;
                chkBPMedium.Checked = withBlock.MediumCheck;
                chkBPLarge.Checked = withBlock.LargeCheck;
                chkBPXLarge.Checked = withBlock.XLCheck;

            }

        }

        // Saves settings for form to XML
        private void btnReactionsSaveSettings_Click(object sender, EventArgs e)
        {
            BPViewerSettings TempSettings = default;
            var Settings = new ProgramSettings();

            if (rbtnBPAll.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPAll.Text;
            }
            else if (rbtnBPOwnedBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPOwnedBlueprints.Text;
            }
            else if (rbtnBPFavoriteBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPFavoriteBlueprints.Text;
            }
            else if (rbtnBPShipBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPShipBlueprints.Text;
            }
            else if (rbtnBPDroneBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPDroneBlueprints.Text;
            }
            else if (rbtnBPAmmoChargeBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPAmmoChargeBlueprints.Text;
            }
            else if (rbtnBPModuleBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPModuleBlueprints.Text;
            }
            else if (rbtnBPComponentBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPComponentBlueprints.Text;
            }
            else if (rbtnBPStructureBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPStructureBlueprints.Text;
            }
            else if (rbtnBPSubsystemBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPSubsystemBlueprints.Text;
            }
            else if (rbtnBPRigBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPRigBlueprints.Text;
            }
            else if (rbtnBPBoosterBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPBoosterBlueprints.Text;
            }
            else if (rbtnBPMiscBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPMiscBlueprints.Text;
            }
            else if (rbtnBPCelestialsBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPCelestialsBlueprints.Text;
            }
            else if (rbtnBPDeployableBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPDeployableBlueprints.Text;
            }
            else if (rbtnBPStructureRigsBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPStructureRigsBlueprints.Text;
            }
            else if (rbtnBPReactionBlueprints.Checked)
            {
                TempSettings.BlueprintTypeSelection = rbtnBPReactionBlueprints.Text;
            }

            TempSettings.BPNPCBPOsCheck = chkBPNPCBPOs.Checked;

            TempSettings.Tech1Check = chkBPTech1.Checked;
            TempSettings.Tech2Check = chkBPTech2.Checked;
            TempSettings.Tech3Check = chkBPTech3.Checked;
            TempSettings.TechStorylineCheck = chkBPStory.Checked;
            TempSettings.TechFactionCheck = chkBPNavy.Checked;
            TempSettings.TechPirateCheck = chkBPPirate.Checked;

            // .IncludeIgnoredBPs = chkBPIncludeIgnoredBPs.Checked

            TempSettings.SmallCheck = chkBPSmall.Checked;
            TempSettings.MediumCheck = chkBPMedium.Checked;
            TempSettings.LargeCheck = chkBPLarge.Checked;
            TempSettings.XLCheck = chkBPXLarge.Checked;

            Settings.SaveBPViewerSettings(TempSettings);

            SettingsVariables.UserBPViewerSettings = TempSettings;

            Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

        }

        // I'd like to try and find some way of merging PopulateNode and SetTopNodes, but I don't think there's a simple way
        private void SetTopNodes()
        {
            treBlueprintTreeView.Nodes.Clear();
            using (var con = new SQLiteConnection(Public_Variables.EVEDB.DBREf().ConnectionString))
            {
                var com = con.CreateCommand();
                com.CommandText = BuildBPQuery("ITEM_CATEGORY", "", default);

                con.Open();
                using (var reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string readCategory = reader["ITEM_CATEGORY"].ToString();
                        var newNode = new TreeNode(readCategory);
                        newNode.Tag = new NodeTag("ITEM_CATEGORY", Conversions.ToInteger(reader["FilterID"]));
                        treBlueprintTreeView.Nodes.Add(newNode);
                        newNode.Nodes.Add(new TreeNode()); // dummy node to show the + mark
                    }
                }
            }

            // If there is only one node, expand it to show the subnodes for usability
            if (treBlueprintTreeView.Nodes.Count == 1)
            {
                treBlueprintTreeView.Nodes[0].Expand();
            }
        }

        private void treBlueprintTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            PopulateNode(e.Node);
        }

        private string GetDisplayLevel(string parentLevel)
        {
            switch (parentLevel ?? "")
            {
                case "ITEM_CATEGORY":
                    {
                        return "ITEM_GROUP";
                    }
                case "ITEM_GROUP":
                    {
                        return "MARKET_GROUP";
                    }
                case "MARKET_GROUP":
                    {
                        return "BLUEPRINT_NAME";
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException($"Value of {nameof(parentLevel)} is invalid: {parentLevel}");
                    }
            }
        }

        // I'd like to try and find some way of merging PopulateNode and SetTopNodes, but I don't think there's a simple way
        private void PopulateNode(TreeNode thisNode)
        {
            thisNode.Nodes.Clear();
            NodeTag filterLevel = (NodeTag)thisNode.Tag;
            string displayLevel = GetDisplayLevel(filterLevel.FilterField);

            using (var con = new SQLiteConnection(Public_Variables.EVEDB.DBREf().ConnectionString))
            {
                var com = con.CreateCommand();
                int ItemGroupID = 0;
                if (!string.IsNullOrEmpty(thisNode.Name))
                {
                    ItemGroupID = Conversions.ToInteger(thisNode.Name);
                }
                com.CommandText = BuildBPQuery(displayLevel, filterLevel.FilterField, filterLevel.FilterValue, ItemGroupID);

                con.Open();
                using (var reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var newNode = new TreeNode(reader[displayLevel].ToString());
                        newNode.Tag = new NodeTag(displayLevel, Conversions.ToInteger(reader["FilterID"]));
                        newNode.Name = reader["ITEM_GROUP_ID"].ToString(); // Store the group id
                        thisNode.Nodes.Add(newNode);
                        if (displayLevel != "BLUEPRINT_NAME")
                        {
                            newNode.Nodes.Add(new TreeNode()); // dummy node to show the + mark
                        }
                    }
                }
                con.Close();
            }
        }

        private string BuildBPQuery(string displayLevel, string filterColumnName, int? filterColumnValue, int ItemGroupID = 0)
        {

            string levelFilter = "";
            if (!string.IsNullOrEmpty(filterColumnName) & filterColumnValue.HasValue)
            {
                levelFilter = $"AND {filterColumnName}_ID = {filterColumnValue}";
            }

            // Ignore flag
            string IgnoreFilter = "";
            // If chkBPIncludeIgnoredBPs.Checked = False Then
            // IgnoreFilter = " AND IGNORE = 0 "
            // End If

            // Text search
            string TextFilter = "";
            if (!string.IsNullOrEmpty(Strings.Trim(txtBPItemFilter.Text)))
            {
                TextFilter = " AND BLUEPRINT_NAME LIKE '%" + Public_Variables.FormatDBString(Strings.Trim(txtBPItemFilter.Text)) + "%' ";
            }

            string NPCBPOFilter = "";
            if (chkBPNPCBPOs.Checked)
            {
                NPCBPOFilter = " AND i2.marketGroupID IS NOT NULL AND b.ITEM_TYPE <> 2 ";
            }

            string ItemGroupFilter = "";
            if (ItemGroupID != 0)
            {
                ItemGroupFilter = "AND ITEM_GROUP_ID = " + ItemGroupID.ToString() + " ";
            }

            string query = $@"SELECT ITEM_GROUP_ID, b.{displayLevel}, {(displayLevel == "BLUEPRINT_NAME" ? "0" : $"{displayLevel}_ID")} AS FilterID
            FROM ALL_BLUEPRINTS b
            JOIN INVENTORY_TYPES i ON b.ITEM_ID = i.typeID {GetExtraJoinFilter()}
            JOIN INVENTORY_TYPES i2 ON b.BLUEPRINT_ID = i2.typeID
            {GetOwnedJoin()}
            WHERE MARKET_GROUP IS NOT NULL
            {ItemGroupFilter}
            {GetSizeGroupFilter()}
            {GetItemTypesFilter()}
            {levelFilter}
            {IgnoreFilter}
            {TextFilter}
            {NPCBPOFilter}
            GROUP BY b.{displayLevel}, FilterID";

            return query;

        }

        private string GetExtraJoinFilter()
        {
            string ReturnString = "";
            ReturnString = Public_Variables.GetBlueprintSQLWhereQuery(rbtnBPAmmoChargeBlueprints.Checked, rbtnBPDroneBlueprints.Checked, rbtnBPModuleBlueprints.Checked, rbtnBPShipBlueprints.Checked, rbtnBPSubsystemBlueprints.Checked, rbtnBPBoosterBlueprints.Checked, rbtnBPComponentBlueprints.Checked, rbtnBPMiscBlueprints.Checked, rbtnBPDeployableBlueprints.Checked, rbtnBPCelestialsBlueprints.Checked, rbtnBPStructureBlueprints.Checked, rbtnBPStructureRigsBlueprints.Checked, rbtnBPStructureModuleBlueprints.Checked, rbtnBPReactionBlueprints.Checked, rbtnBPRigBlueprints.Checked);
            if (!string.IsNullOrEmpty(ReturnString))
            {
                ReturnString = "AND " + ReturnString;
            }

            return ReturnString;
        }

        private string GetOwnedJoin()
        {
            string ownedJoin = "";
            string baseJoin = $"JOIN OWNED_BLUEPRINTS o ON b.BLUEPRINT_ID = o.BLUEPRINT_ID ";
            string ownedFilter = "";
            // See what ID we use for character bps
            long TempID = 0L;
            if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar)
            {
                // Use the ID sent
                TempID = Public_Variables.SelectedCharacter.ID;
            }
            else
            {
                TempID = Public_Variables.CommonLoadBPsID;
            }

            ownedFilter = $" AND o.OWNED <> 0 AND o.USER_ID = {TempID}";

            if (rbtnBPOwnedBlueprints.Checked)
            {
                ownedJoin = $"{baseJoin} {ownedFilter}";
            }
            else if (rbtnBPFavoriteBlueprints.Checked)
            {
                ownedJoin = $"{baseJoin} {ownedFilter} AND o.FAVORITE = 1";
            }

            return ownedJoin;
        }

        private string GetSizeGroupFilter()
        {
            string sizeGroupFilter = "";
            var sizeLimit = new List<string>();

            if (chkBPSmall.Checked)
            {
                sizeLimit.Add("S");
            }

            if (chkBPMedium.Checked)
            {
                sizeLimit.Add("M");
            }

            if (chkBPLarge.Checked)
            {
                sizeLimit.Add("L");
            }

            if (chkBPXLarge.Checked)
            {
                sizeLimit.Add("XL");
            }

            if (sizeLimit.Count > 0)
            {
                string sizeGroupString = sizeLimit.Select(x => $"'{x}'").Aggregate((prev, @this) => $"{prev}, {@this}");
                sizeGroupFilter = $"AND b.SIZE_GROUP IN ({sizeGroupString})";
            }
            return sizeGroupFilter;
        }

        private string GetItemTypesFilter()
        {

            var itemTypes = new List<ItemType>();
            string itemTypesFilter = "''";

            if (chkBPTech1.Checked)
            {
                itemTypes.Add(ItemType.Tech1);
            }

            if (chkBPTech2.Checked)
            {
                itemTypes.Add(ItemType.Tech2);
            }

            if (chkBPTech3.Checked)
            {
                itemTypes.Add(ItemType.Tech3);
            }

            if (chkBPStory.Checked)
            {
                itemTypes.Add(ItemType.Storyline);
            }

            if (chkBPPirate.Checked)
            {
                itemTypes.Add(ItemType.Pirate);
            }

            if (chkBPNavy.Checked)
            {
                itemTypes.Add(ItemType.Navy);
            }

            if (itemTypes.Count > 0)
            {

                string itemTypesString = itemTypes.Select(it => ((int)it).ToString()).Aggregate((prev, @this) => $"{prev}, {@this}");
                itemTypesFilter = $"AND b.ITEM_TYPE IN ({itemTypesString})";
            }

            return itemTypesFilter;
        }

        // Changed to use after select to allow single click loading
        // Private Sub treBlueprintTreeView_DoubleClick(sender As Object, e As EventArgs) Handles treBlueprintTreeView.DoubleClick
        // 'If (treBlueprintTreeView.SelectedNode Is Nothing) Then
        // '    Return
        // 'End If
        // '' Only load if the final node (bp) in the tree
        // 'If treBlueprintTreeView.SelectedNode.Nodes.Count = 0 Then
        // '    RaiseEvent BPSelected(treBlueprintTreeView.SelectedNode.Text)
        // 'End If
        // End Sub

        // After select allows loading the bp selected after the event fires
        private void treBlueprintTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treBlueprintTreeView.SelectedNode is null)
            {
                return;
            }
            // Only load if the final node (bp) in the tree
            if (treBlueprintTreeView.SelectedNode.Nodes.Count == 0)
            {
                BPSelected?.Invoke(treBlueprintTreeView.SelectedNode.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetSelectors(bool T1, bool T2, bool T3, bool Storyline, bool NavyFaction, bool PirateFaction)
        {
            if (!FirstFormLoad)
            {
                chkBPTech1.Enabled = T1;
                chkBPTech2.Enabled = T2;
                chkBPTech3.Enabled = T3;
                chkBPNavy.Enabled = NavyFaction;
                chkBPPirate.Enabled = PirateFaction;
                chkBPStory.Enabled = Storyline;

                // Make sure we have something checked
                EnsureBPTechCheck();
                // Load the New data
                SetTopNodes();
            }
        }

        // Makes sure we have a tech checked for blueprints
        private void EnsureBPTechCheck()
        {
            if (chkBPTech1.Enabled & chkBPTech1.Checked)
            {
                return;
            }
            else if (chkBPTech2.Enabled & chkBPTech2.Checked)
            {
                return;
            }
            else if (chkBPTech3.Enabled & chkBPTech3.Checked)
            {
                return;
            }
            else if (chkBPNavy.Enabled & chkBPNavy.Checked)
            {
                return;
            }
            else if (chkBPPirate.Enabled & chkBPPirate.Checked)
            {
                return;
            }
            else if (chkBPStory.Enabled & chkBPStory.Checked)
            {
                return;
            }

            // If here, then none are checked that are enabled, find the first one enabled and check it
            if (chkBPTech1.Enabled)
            {
                chkBPTech1.Checked = true;
                return;
            }
            else if (chkBPTech2.Enabled)
            {
                chkBPTech2.Checked = true;
                return;
            }
            else if (chkBPTech3.Enabled)
            {
                chkBPTech3.Checked = true;
                return;
            }
            else if (chkBPNavy.Enabled)
            {
                chkBPNavy.Checked = true;
                return;
            }
            else if (chkBPPirate.Enabled)
            {
                chkBPPirate.Checked = true;
                return;
            }
            else if (chkBPStory.Enabled)
            {
                chkBPStory.Checked = true;
                return;
            }

        }

        #region Click Events

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, true, true, true, true);
        }

        private void rbBPOwned_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, true, true, true, true);
        }

        private void chkBPIncludeIgnoredBPs_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, true, true, true, true);
        }

        private void rbtnShipBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, true, false, true, true);
        }

        private void rbtnModuleBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, false, true, true, false);
        }

        private void rbtnDroneBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, false, false, false, true);
        }

        private void rbtnComponentBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, false, false, false, false, false);
        }

        private void rbtnSubsystemBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(false, false, true, false, false, false);
        }

        private void rbtnToolBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, false, false, false, false, false);
        }

        private void rbtnAmmoChargeBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, false, false, false, false);
        }

        private void rbtnRigBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, false, false, false, false);
        }

        private void rbtnStructureBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, false, false, false, false, true);
        }

        private void rbtnBoosterBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, false, false, false, false, false);
        }

        private void rbtnBPDeployableBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, false, false, false, false);
        }

        private void rbtnBPStationPartsBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, false, false, false, false, false);
        }

        private void rbtnBPStationModulesBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, false, false, false, false, false);
        }

        private void rbtnBPCelestialBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, false, false, false, false, false);
        }

        private void rbtnBPFavoriteBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            ResetSelectors(true, true, true, true, true, true);
        }

        private void chkbpTech1_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkbpTech2_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkbpTech3_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkBPNavy_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkBPPirate_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkBPStory_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkBPSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkBPMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkBPLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void chkBPXLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                SetTopNodes();
            }
        }

        private void btnClearItemFilter_Click(object sender, EventArgs e)
        {
            txtBPItemFilter.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetTopNodes();
        }

        private void chkBPNPCBPOs_CheckedChanged(object sender, EventArgs e)
        {
            SetTopNodes();
        }

        #endregion

    }


    /// <summary>
/// Item Type Definitions - These are set by Cwittofur based on existing data
/// </summary>
    enum ItemType
    {
        Tech1 = 1,
        Tech2 = 2,
        Tech3 = 14,
        Storyline = 3,
        Pirate = 15,
        Navy = 16
    }
}