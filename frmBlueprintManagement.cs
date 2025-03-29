using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmBlueprintManagement
    {
        private bool cmbBPTypeFilterLoaded;
        private bool FirstLoad;
        private string SelectedType;

        private bool DataEntered;
        private bool TabPressed;

        // Inline grid row update variables
        private ListViewItem CurrentRow;
        private ListViewItem PreviousRow;
        private ListViewItem NextRow;

        private ListViewItem NextCellRow;
        private ListViewItem PreviousCellRow;

        private ListViewItem.ListViewSubItem CurrentCell;
        private ListViewItem.ListViewSubItem PreviousCell;
        private ListViewItem.ListViewSubItem NextCell;

        private bool MEUpdate;
        private bool TEUpdate;
        private bool FavoriteUpdate;
        private bool OwnedTypeUpdate;
        private bool IgnoredBPUpdate;
        private bool BPTypeUpdate;

        private int BPColumnClicked;
        private SortOrder BPColumnSortOrder;

        private const string SelectTypeText = "Select Type";

        private struct BlueprintAsset
        {
            public long TypeID;
            public int BPType;
        }

        #region ObjectSection

        private void lstBPs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = lstBPs;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref BPColumnClicked, ref BPColumnSortOrder);
        }

        private void lstBPs_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstBPs.SelectedIndices.Count != 0)
            {
                // Put the selected BP ME/TE in the boxes when clicked
                txtBPME.Text = lstBPs.SelectedItems[0].SubItems[5].Text;
                txtBPTE.Text = lstBPs.SelectedItems[0].SubItems[6].Text;
            }

        }

        private void txtBPME_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedMETEChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtBPPE_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedMETEChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtBPME_TextChanged(object sender, EventArgs e)
        {
            var argMETETextBox = txtBPME;
            Public_Variables.VerifyMETEEntry(ref argMETETextBox, "ME");
            txtBPME = argMETETextBox;
        }

        private void txtBPTE_TextChanged(object sender, EventArgs e)
        {
            var argMETETextBox = txtBPTE;
            Public_Variables.VerifyMETEEntry(ref argMETETextBox, "TE");
            txtBPTE = argMETETextBox;
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtBPSearch.Text = "";
            UpdateBlueprintGrid(true);
        }

        private void rbtnOwned_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnOwned.Checked)
            {
                // Disable both scan types
                btnScanPersonalBPs.Enabled = false;
                btnScanCorpBPs.Enabled = false;
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(false);
            }
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnAllBPs.Checked)
            {
                SetScanEnableButtons();
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(false);
            }
        }

        private void rbtnFavorites_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnFavorites.Checked)
            {
                SetScanEnableButtons();
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(false);
            }
        }

        private void rbtnIgnored_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnIgnored.Checked)
            {
                SetScanEnableButtons();
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(false);
            }
        }

        private void rbtnScannedPersonalBPs_CheckedChanged(object sender, EventArgs e)
        {

            // Disable scan button
            if (rbtnScannedPersonalBPs.Checked)
            {
                btnScanPersonalBPs.Enabled = false;
                btnScanCorpBPs.Enabled = false;
            }
            else
            {
                SetScanEnableButtons();
            }

            if (!FirstLoad & rbtnScannedPersonalBPs.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(false);
            }

        }

        private void rbtnScannedCorpBPs_CheckedChanged(object sender, EventArgs e)
        {
            // Disable scan button
            if (rbtnScannedCorpBPs.Checked)
            {
                btnScanPersonalBPs.Enabled = false;
                btnScanCorpBPs.Enabled = false;
            }
            else
            {
                SetScanEnableButtons();
            }

            if (!FirstLoad & rbtnScannedCorpBPs.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(false);
            }

        }

        private void rbtnMarkasOwned_CheckedChanged(object sender, EventArgs e)
        {
            chkMarkasFavorite.Enabled = true;
            chkMarkasIgnored.Enabled = true;
            chkEnableMETE.Enabled = true;

            if (!chkEnableMETE.Checked)
            {
                EnableMETE(false);
            }
            else
            {
                EnableMETE(true);
            }

        }

        private void rbtnMarkasUnowned_CheckedChanged(object sender, EventArgs e)
        {
            chkMarkasFavorite.Enabled = true;
            chkMarkasIgnored.Enabled = true;

            if (rbtnMarkasUnowned.Checked == true)
            {
                EnableMETE(false);
                chkEnableMETE.Enabled = false;
            }
            else
            {
                if (!chkEnableMETE.Checked)
                {
                    EnableMETE(false);
                }
                chkEnableMETE.Enabled = true;
            }
        }

        private void rbtnRemoveAllSettings_CheckedChanged(object sender, EventArgs e)
        {
            chkMarkasFavorite.Enabled = false;
            chkMarkasIgnored.Enabled = false;
            chkEnableMETE.Enabled = false;
            EnableMETE(false);
        }

        private void ResetTypeCmbFillGrid()
        {
            if (!FirstLoad)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void chkBPT1_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPT2_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPT3_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPStoryline_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPNavyFaction_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPPirateFaction_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPSmall_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPMedium_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPXL_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkBPLarge_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void rbtnShipBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnShipBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnModuleBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnModuleBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnDroneBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnDroneBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnAmmoChargeBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnAmmoChargeBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnRigBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnRigBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnComponentBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnComponentBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnSubsystemBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnSubsystemBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnStructureBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnStructureBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnStructureModulesBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnStructureModulesBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnCelestialBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnCelestialsBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnStationPartsBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnStructureRigsBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnDeployableBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnDeployableBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnReactionBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnReactionBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnAllBPTypes_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnAllBPTypes.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnBoosterBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnBoosterBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnToolBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnMiscBlueprints.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnBPAllBPtypes_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnShowAllBPtypes.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnBPOnlyBPO_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnOnlyBPO.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnBPOnlyCopies_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnOnlyCopies.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void rbtnOnlyInventedBPCs_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnOnlyInventedBPCs.Checked)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void chkNotOwned_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void chkNotIgnored_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                cmbBPTypeFilterLoaded = false;
                cmbBPTypeFilter.Text = SelectTypeText;
                UpdateBlueprintGrid(true);
            }
        }

        private void chkRaceAmarr_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkRaceCaldari_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkRaceGallente_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkRaceMinmatar_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkRacePirate_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void chkRaceOther_CheckedChanged(object sender, EventArgs e)
        {
            ResetTypeCmbFillGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateBlueprintGrid(true);
        }

        private void cmbBPTypeFilter_DropDown(object sender, EventArgs e)
        {
            if (!cmbBPTypeFilterLoaded & (SelectedType ?? "") != (cmbBPTypeFilter.Text ?? ""))
            {
                LoadBPTypes();
                cmbBPTypeFilterLoaded = true;
            }
        }

        private void cmbBPTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((SelectedType ?? "") != (cmbBPTypeFilter.Text ?? "") & (cmbBPTypeFilter.Text ?? "") != SelectTypeText)
            {
                UpdateBlueprintGrid(true);
                SelectedType = cmbBPTypeFilter.Text;
                cmbBPTypeFilterLoaded = false;
            }
        }

        private void txtBPSearch_GotFocus(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                txtBPSearch.SelectAll();
            }
        }

        private void txtBPSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // Call ProcessCutCopyPasteSelect(txtBPSearch, e)
            if (e.KeyCode == Keys.Enter)
            {
                UpdateBlueprintGrid(true);
            }
        }

        // Calls grid update based on text entered
        private void btnBPSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Strings.Trim(txtBPSearch.Text)))
            {
                Interaction.MsgBox("Must enter a search item", Constants.vbExclamation, Text);
                txtBPSearch.Focus();
                return;
            }

            UpdateBlueprintGrid(true);

            txtBPSearch.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void chkEnableMETE_CheckedChanged(object sender, EventArgs e)
        {
            EnableMETE(chkEnableMETE.Checked);
        }

        private void EnableMETE(bool Value)
        {
            // if true it enables, false disables
            lblBPME.Enabled = Value;
            lblBPTE.Enabled = Value;
            txtBPME.Enabled = Value;
            txtBPTE.Enabled = Value;
        }

        #endregion

        public frmBlueprintManagement()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            FirstLoad = true;
            DataEntered = false;
            TabPressed = false;

            // Add the colums to the list
            lstBPs.Columns.Add("", 25, HorizontalAlignment.Center); // -2 is autosize, but check boxes set to 25
            lstBPs.Columns.Add("BPTypeID", 0, HorizontalAlignment.Left); // Hidden
            lstBPs.Columns.Add("Blueprint Group", 260, HorizontalAlignment.Left);
            lstBPs.Columns.Add("Blueprint Name", 300, HorizontalAlignment.Left);
            lstBPs.Columns.Add("Tech", 52, HorizontalAlignment.Center);
            lstBPs.Columns.Add("ME", 40, HorizontalAlignment.Center);
            lstBPs.Columns.Add("TE", 40, HorizontalAlignment.Center);
            lstBPs.Columns.Add("Owned", 50, HorizontalAlignment.Center);
            lstBPs.Columns.Add("BP Type", 78, HorizontalAlignment.Center);
            lstBPs.Columns.Add("Fav", 48, HorizontalAlignment.Center);
            lstBPs.Columns.Add("Ignored", 48, HorizontalAlignment.Center);
            lstBPs.Columns.Add("Runs", 55, HorizontalAlignment.Center);
            // lstBPs.Columns.Add("Quantity", 51, HorizontalAlignment.Right) ' This is different than the API value
            lstBPs.Columns.Add("Additional Costs", 88, HorizontalAlignment.Right);
            lstBPs.Columns.Add("Scanned", 0, HorizontalAlignment.Center); // Hidden

            SetScanEnableButtons();

            ttBPManage.SetToolTip(btnBackupBPs, "Exports all Blueprint Data to a csv format for all user APIs");
            ttBPManage.SetToolTip(btnLoadBPs, "Loads exported Blueprint Data from csv format");
            ttBPManage.SetToolTip(rbtnRemoveAllSettings, "Removes all saved blueprint data for selected blueprints");

        }

        private void SetScanEnableButtons()
        {

            // Tool Tip for Scan button
            if (Public_Variables.SelectedCharacter.AssetsAccess == false)
            {
                ttBPManage.SetToolTip(grpScanAssets, "Scanning Assets only available with correct key access");
                // Disable
                btnScanPersonalBPs.Enabled = false;
            }
            else
            {
                ttBPManage.SetToolTip(btnScanPersonalBPs, "Assets refresh every 6 Hours");
                btnScanPersonalBPs.Enabled = true;
            }

            if (Public_Variables.SelectedCharacter.CharacterCorporation.AssetAccess == false)
            {
                ttBPManage.SetToolTip(grpScanAssets, "Scanning Assets only available with correct key access");
                // Disable
                btnScanCorpBPs.Enabled = false;
            }
            else
            {
                ttBPManage.SetToolTip(btnScanCorpBPs, "Assets refresh every 6 Hours");
                btnScanCorpBPs.Enabled = true;
            }

        }

        private void frmBlueprintManagement_Shown(object sender, EventArgs e)
        {

            Application.DoEvents();

            if (FirstLoad)
            {
                InitForm();
            }

            FirstLoad = false;

        }

        private void InitForm()
        {

            cmbBPTypeFilterLoaded = false;
            cmbBPTypeFilter.Text = SelectTypeText;
            FirstLoad = true;

            // Race Checks
            chkRaceAmarr.Checked = true;
            chkRaceCaldari.Checked = true;
            chkRaceGallente.Checked = true;
            chkRaceMinmatar.Checked = true;
            chkRacePirate.Checked = true;
            chkRaceOther.Checked = true;

            // Set the checks
            chkBPNavyFaction.Checked = true;
            chkBPPirateFaction.Checked = true;
            chkBPStoryline.Checked = true;
            chkBPT1.Checked = true;
            chkBPT2.Checked = true;
            chkBPT3.Checked = true;

            txtBPME.Text = "0";
            txtBPTE.Text = "0";

            rbtnAllBPs.Checked = true;
            rbtnAllBPTypes.Checked = true;
            rbtnMarkasOwned.Checked = true;

            rbtnShowAllBPtypes.Checked = true;

            txtBPSearch.Text = "";

            // Start out not checking this incase people accidently hit it
            chkEnableMETE.Checked = false;
            EnableMETE(false);

            FirstLoad = false;

            UpdateBlueprintGrid(false);

        }

        // Updates the blueprint grid with a list of bps
        private void UpdateBlueprintGrid(bool CheckAllItems)
        {
            string SQL = "";
            string SQL1 = "";
            SQLiteDataReader readerBP;
            SQLiteDataReader rsLookup;
            int ScannedValue;
            long BPUserID;

            ListViewItem BPList;

            // Get the selection clause from options on screen
            SQL = BuildBPSelectQuery();

            if (string.IsNullOrEmpty(SQL))
            {
                // No valid query so just show nothing
                lstBPs.Items.Clear();
                return;
            }

            // Make sure to set the USER ID for the owned blueprint query
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());

            if (rbtnScannedCorpBPs.Checked)
            {
                // Set the correct ID
                BPUserID = Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID;
            }
            else
            {
                BPUserID = Public_Variables.GetBPUserID(Public_Variables.SelectedCharacter.ID);
            }

            Public_Variables.DBCommand.Parameters.AddWithValue("@USERBP_USERID", BPUserID); // need to search for corp ID too
            Public_Variables.DBCommand.Parameters.AddWithValue("@USERBP_CORPID", Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString());
            readerBP = Public_Variables.DBCommand.ExecuteReader();

            lstBPs.Visible = false;
            Cursor = Cursors.WaitCursor;

            // Disable buttons till done
            gbBPFilter.Enabled = false;
            gbUpdateOptions.Enabled = false;
            grpScanAssets.Enabled = false;
            txtBPEdit.Visible = false;
            cmbEdit.Visible = false;

            Refresh();
            Application.DoEvents();

            lstBPs.Items.Clear();
            // Disable sorting because it will crawl after we update if there are too many records
            lstBPs.ListViewItemSorter = null;
            lstBPs.BeginUpdate();

            // Add the records
            while (readerBP.Read())
            {

                Application.DoEvents();

                BPList = new ListViewItem("");
                // The remaining columns are subitems  
                // 0-BP_ID, 1-BLUEPRINT_GROUP, 2-BLUEPRINT_NAME, 3-ITEM_GROUP_ID, 4-ITEM_GROUP, 5-ITEM_CATEGORY_ID, 
                // 6-ITEM_CATEGORY, 7-ITEM_ID, 8-ITEM_NAME, 9-ME, 10-TE, 11-USERID, 12-ITEM_TYPE, 13-RACE_ID, 14-OWNED, 15-SCANNED 
                // 16-BP_TYPE, 17-UNIQUE_BP_ITEM_ID, 18-FAVORITE, 19-VOLUME, 20-MARKET_GROUP_ID, 21-ADDITIONAL_COSTS, 
                // 22-LOCATION_ID, 23-QUANTITY, 24-FLAG_ID, 25-RUNS, 26-IGNORE, 27-TECH_LEVEL

                BPList.SubItems.Add(readerBP.GetInt64(0).ToString()); // BP ID
                BPList.SubItems.Add(readerBP.GetString(1)); // BP Group
                BPList.SubItems.Add(readerBP.GetString(2)); // BP Name

                // 1, 2, 14 are T1, T2, T3
                // 3 is Storyline
                // 15 is Pirate Faction
                // 16 is Navy Faction
                switch (readerBP.GetInt32(12))
                {
                    case 1:
                        {
                            BPList.SubItems.Add("T1");
                            break;
                        }
                    case 2:
                        {
                            BPList.SubItems.Add("T2");
                            break;
                        }
                    case 14:
                        {
                            BPList.SubItems.Add("T3");
                            break;
                        }
                    case 3:
                        {
                            BPList.SubItems.Add("Storyline");
                            break;
                        }
                    case 15:
                        {
                            BPList.SubItems.Add("Pirate");
                            break;
                        }
                    case 16:
                        {
                            BPList.SubItems.Add("Navy");
                            break;
                        }

                    default:
                        {
                            BPList.SubItems.Add(Public_Variables.Unknown);
                            break;
                        }
                }

                BPList.SubItems.Add(readerBP.GetDouble(9).ToString()); // ME
                BPList.SubItems.Add(readerBP.GetDouble(10).ToString()); // TE

                SetOwnedFlagandColors(ref BPList, Conversions.ToBoolean(readerBP.GetValue(14))); // 14 = Owned

                // BP Type
                BPList.SubItems.Add(Public_Variables.GetBPTypeString(readerBP.GetInt32(16)));

                if (readerBP.GetInt32(18) == 0)
                {
                    BPList.SubItems.Add(Public_Variables.No); // Favorite
                }
                else
                {
                    BPList.SubItems.Add(Public_Variables.Yes);
                } // Favorite

                if (readerBP.GetInt32(26) == 0)
                {
                    BPList.SubItems.Add(Public_Variables.No); // Ignored
                }
                else
                {
                    BPList.SubItems.Add(Public_Variables.Yes);
                } // Ignored

                // If they don't own it, look it up, else use the API data
                if (Conversions.ToInteger(readerBP.GetValue(14)) == 0)
                {
                    // Set runs for bpcs, or unlimited for bpo
                    if ((readerBP.GetInt32(16) == (int)Public_Variables.BPType.Copy | readerBP.GetInt32(16) == (int)Public_Variables.BPType.InventedBPC | readerBP.GetInt32(16) == (int)Public_Variables.BPType.NotOwned) & readerBP.GetInt32(27) != 1)
                    {
                        // If T2/T3 invented - look up base runs for the bpc assuming no decryptors, else get the value stored
                        if (readerBP.GetInt32(27) == 2)
                        {
                            SQL = "SELECT quantity FROM INDUSTRY_ACTIVITY_PRODUCTS WHERE productTypeID = " + readerBP.GetInt64(0).ToString() + " AND activityID = 8";
                        }
                        else // T3
                        {
                            long BPIDLookup;
                            BPIDLookup = Public_Variables.GetInventItemTypeID(readerBP.GetInt64(0), "Wrecked");
                            SQL = "SELECT quantity FROM INDUSTRY_ACTIVITY_PRODUCTS WHERE blueprintTypeID = " + BPIDLookup.ToString() + " AND activityID = 8 ";
                            SQL += "AND productTypeID = " + readerBP.GetInt64(0).ToString();
                        }

                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                        rsLookup = Public_Variables.DBCommand.ExecuteReader();

                        if (rsLookup.Read())
                        {
                            BPList.SubItems.Add(rsLookup.GetInt32(0).ToString());
                        }
                        else
                        {
                            BPList.SubItems.Add(Public_Variables.Unknown);
                        }

                        rsLookup.Close();
                        rsLookup = null;
                    }
                    else if (readerBP.GetInt32(16) == (int)Public_Variables.BPType.NotOwned)
                    {
                        // Get max runs from all_blueprints for unowned bps
                        SQL = "SELECT MAX_PRODUCTION_LIMIT FROM ALL_BLUEPRINTS WHERE BLUEPRINT_ID = " + readerBP.GetInt64(0).ToString();
                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                        rsLookup = Public_Variables.DBCommand.ExecuteReader();

                        if (rsLookup.Read())
                        {
                            BPList.SubItems.Add(rsLookup.GetInt32(0).ToString());
                        }
                        else
                        {
                            BPList.SubItems.Add(Public_Variables.Unknown);
                        }

                        rsLookup.Close();
                        rsLookup = null;
                    }

                    else if (Conversions.ToInteger(readerBP.GetValue(16)) == (int)Public_Variables.BPType.Original)
                    {
                        // BPO's are unlimited runs
                        BPList.SubItems.Add(Public_Variables.Unlimited);
                    }
                }
                else if (readerBP.GetInt32(25) == -1) // Get from API store for T1 BPCs
                {
                    BPList.SubItems.Add(Public_Variables.Unlimited);
                }
                else
                {
                    BPList.SubItems.Add(readerBP.GetInt32(25).ToString());
                }

                // For now, quantity is 1 until I can do multi-bp processing where we would group common ME/TE Bps
                // BPList.SubItems.Add("1")
                BPList.SubItems.Add(Strings.FormatNumber(readerBP.GetDouble(21), 2)); // Additional Costs

                ScannedValue = readerBP.GetInt32(15);

                if (ScannedValue == 0)
                {
                    BPList.BackColor = Color.White;
                }
                else if (Public_Variables.SelectedCharacter.ID == readerBP.GetInt32(11) | readerBP.GetInt32(11) == Public_Variables.CommonLoadBPsID)
                {
                    BPList.BackColor = Color.BlanchedAlmond;
                }
                else // must be corp
                {
                    BPList.BackColor = Color.LightGreen;
                }

                BPList.SubItems.Add((readerBP.IsDBNull(15) ? 0 : readerBP.GetInt32(15)).ToString()); // Scanned

                if (CheckAllItems)
                {
                    BPList.Checked = true;
                }
                else
                {
                    BPList.Checked = false;
                }

                lstBPs.Items.Add(BPList);

            }

            // Now sort this
            SortOrder TempType;
            if (BPColumnSortOrder == SortOrder.Ascending)
            {
                TempType = SortOrder.Descending;
            }
            else
            {
                TempType = SortOrder.Ascending;
            }
            ListView argRefListView = lstBPs;
            Public_Variables.ListViewColumnSorter(BPColumnClicked, ref argRefListView, ref BPColumnClicked, ref TempType);
            lstBPs.EndUpdate();

            if (CheckAllItems)
            {
                btnSelectAll.Text = "Uncheck All";
            }
            else
            {
                btnSelectAll.Text = "Select All";
            }

            readerBP.Close();
            readerBP = null;
            Public_Variables.DBCommand = null;

            lstBPs.Visible = true;
            Cursor = Cursors.Default;
            gbBPFilter.Enabled = true;
            gbUpdateOptions.Enabled = true;
            grpScanAssets.Enabled = true;
            SelectedType = ""; // Reset this on each load
            Application.DoEvents();

            return;

        }

        // Sets the referenced list view owned colors and back color
        private void SetOwnedFlagandColors(ref ListViewItem ListSubitem, bool OwnedBP)
        {
            if (OwnedBP) // 14 = Owned
            {
                ListSubitem.SubItems.Add(Public_Variables.Yes);
                ListSubitem.ForeColor = Color.Blue;
            }
            else
            {
                ListSubitem.SubItems.Add(Public_Variables.No);
                ListSubitem.ForeColor = Color.Black;
                ListSubitem.BackColor = Color.White;
            }
        }

        // Builds the query for the select list
        private string BuildBPSelectQuery()
        {
            string BuildBPSelectQueryRet = default;
            string SQL = "";
            string ScannedAdd = "";
            string WhereClause = "";
            string RaceClause = "";
            string TempRace = "";
            string SQLItemType = "";
            string TextClause = "";
            string ComboType = "";
            string Copies = "";
            string SizesClause = "";

            // Base query
            SQL = "SELECT * FROM " + Public_Variables.USER_BLUEPRINTS;

            // Find what type of blueprint we want
            WhereClause = Public_Variables.GetBlueprintSQLWhereQuery(rbtnAmmoChargeBlueprints.Checked, rbtnDroneBlueprints.Checked, rbtnModuleBlueprints.Checked, rbtnShipBlueprints.Checked, rbtnSubsystemBlueprints.Checked, rbtnBoosterBlueprints.Checked, rbtnComponentBlueprints.Checked, rbtnMiscBlueprints.Checked, rbtnDeployableBlueprints.Checked, rbtnCelestialsBlueprints.Checked, rbtnStructureBlueprints.Checked, rbtnStructureRigsBlueprints.Checked, rbtnStructureModulesBlueprints.Checked, rbtnReactionBlueprints.Checked, rbtnRigBlueprints.Checked);
            if (!string.IsNullOrEmpty(WhereClause))
            {
                WhereClause = "WHERE " + WhereClause;
            }

            string TempClause = "";

            if (rbtnOwned.Checked)
            {
                // Ignore scanned BP's
                TempClause = "OWNED <> 0 ";
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE " + TempClause;
                }
                else
                {
                    WhereClause += "AND " + TempClause;
                }
            }
            else if (rbtnScannedPersonalBPs.Checked)
            {
                long CharID = 0L;
                if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar)
                {
                    // Use the ID sent
                    CharID = Public_Variables.SelectedCharacter.ID;
                }
                else
                {
                    CharID = Public_Variables.CommonLoadBPsID;
                }
                TempClause = "USER_ID = " + CharID + " AND SCANNED <> 0 ";
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE " + TempClause;
                }
                else
                {
                    WhereClause += "AND " + TempClause;
                }
            }
            else if (rbtnScannedCorpBPs.Checked)
            {
                // Include corp scanned
                TempClause = "USER_ID =" + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID + " AND SCANNED <> 0 ";
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE " + TempClause;
                }
                else
                {
                    WhereClause += " AND " + TempClause;
                }
            }
            else if (rbtnFavorites.Checked)
            {
                // Favorites for the user
                TempClause = "FAVORITE = 1 ";
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE " + TempClause;
                }
                else
                {
                    WhereClause += "AND " + TempClause;
                }
            }
            else if (rbtnIgnored.Checked)
            {
                // All ignored
                TempClause = "IGNORE = 1 ";
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE " + TempClause;
                }
                else
                {
                    WhereClause += "AND " + TempClause;
                }
            }

            // Add not owned if checked
            if (chkNotOwned.Checked)
            {
                TempClause = "OWNED = 0 ";
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE " + TempClause;
                }
                else
                {
                    WhereClause += "AND " + TempClause;
                }
            }

            // Add not Ignored if checked
            if (chkNotIgnored.Checked)
            {
                TempClause = "IGNORE = 0 ";
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE " + TempClause;
                }
                else
                {
                    WhereClause += "AND " + TempClause;
                }
            }

            // Item Type Definitions - These are set by me based on existing data
            // 1, 2, 14 are T1, T2, T3
            // 3 is Storyline
            // 15 is Pirate Faction
            // 16 is Navy Faction

            // Check Tech version
            if (chkBPT1.Enabled)
            {
                // Only a Subsystem so T3
                if (chkBPT1.Checked)
                {
                    SQLItemType = SQLItemType + "1,";
                }
            }

            if (chkBPT2.Enabled)
            {
                if (chkBPT2.Checked)
                {
                    SQLItemType = SQLItemType + "2,";
                }
            }

            if (chkBPT3.Enabled)
            {
                if (chkBPT3.Checked)
                {
                    SQLItemType = SQLItemType + "14,";
                }
            }

            if (chkBPStoryline.Enabled)
            {
                if (chkBPStoryline.Checked)
                {
                    SQLItemType = SQLItemType + "3,";
                }
            }

            if (chkBPPirateFaction.Enabled)
            {
                if (chkBPPirateFaction.Checked)
                {
                    SQLItemType = SQLItemType + "15,";
                }
            }

            if (chkBPNavyFaction.Enabled)
            {
                if (chkBPNavyFaction.Checked)
                {
                    SQLItemType = SQLItemType + "16,";
                }
            }

            // Add Item Type
            if (!string.IsNullOrEmpty(SQLItemType))
            {
                SQLItemType = "ITEM_TYPE IN (" + SQLItemType.Substring(0, SQLItemType.Length - 1) + ") ";
            }
            else
            {
                // They need to have at least one. If not, just return nothing
                BuildBPSelectQueryRet = "";
                return BuildBPSelectQueryRet;
            }

            // Determine what race we are looking at
            if (chkRaceAmarr.Checked)
            {
                TempRace = TempRace + "4,";
            }
            if (chkRaceCaldari.Checked)
            {
                TempRace = TempRace + "1,";
            }
            if (chkRaceMinmatar.Checked)
            {
                TempRace = TempRace + "2,";
            }
            if (chkRaceGallente.Checked)
            {
                TempRace = TempRace + "8,";
            }
            if (chkRacePirate.Checked)
            {
                TempRace = TempRace + "15,";
            }
            if (chkRaceOther.Checked)
            {
                TempRace = TempRace + "0,";
            }

            if (!string.IsNullOrEmpty(TempRace))
            {
                TempRace = "(" + TempRace.Substring(0, Strings.Len(TempRace) - 1) + ")";
                RaceClause = "AND (RACE_ID IN " + TempRace + ") ";
            }
            else
            {
                // They need to have at least one. If not, just return nothing
                BuildBPSelectQueryRet = "";
                return BuildBPSelectQueryRet;
            }

            // Finally add on text if they added it
            if (!string.IsNullOrEmpty(Strings.Trim(txtBPSearch.Text)))
            {
                TextClause = TextClause + "AND " + Public_Variables.GetSearchText(txtBPSearch.Text, "BLUEPRINT_NAME", "BLUEPRINT_GROUP");
            }

            // If they select a type of item, set that
            if ((Strings.Trim(cmbBPTypeFilter.Text) ?? "") != SelectTypeText)
            {
                ComboType = "And ITEM_GROUP ='" + Public_Variables.FormatDBString(Strings.Trim(cmbBPTypeFilter.Text)) + "' ";
            }

            // See if they want BPOs, Copies, or Invented BPCs
            if (rbtnOnlyBPO.Checked)
            {
                Copies = " AND BP_TYPE IN (" + ((int)Public_Variables.BPType.Original).ToString() + ",0) "; // Only BPO's
            }
            else if (rbtnOnlyCopies.Checked)
            {
                Copies = " AND BP_TYPE IN (" + ((int)Public_Variables.BPType.Copy).ToString() + ",0) "; // Only Copies
            }
            else if (rbtnOnlyInventedBPCs.Checked)
            {
                Copies = " AND BP_TYPE IN (" + ((int)Public_Variables.BPType.InventedBPC).ToString() + ",0) "; // Only invented bpcs
            }

            SizesClause = "";

            // Finally add the sizes
            if (chkBPSmall.Checked) // Light
            {
                SizesClause = SizesClause + "'S',";
            }

            if (chkBPMedium.Checked) // Medium
            {
                SizesClause = SizesClause + "'M',";
            }

            if (chkBPLarge.Checked) // Heavy
            {
                SizesClause = SizesClause + "'L',";
            }

            if (chkBPXL.Checked) // Fighters
            {
                SizesClause = SizesClause + "'XL',";
            }

            if (!string.IsNullOrEmpty(SizesClause))
            {
                SizesClause = " AND SIZE_GROUP IN (" + SizesClause.Substring(0, Strings.Len(SizesClause) - 1) + ") ";
            }

            // No where clause means we are selecting all
            if (!string.IsNullOrEmpty(WhereClause))
            {
                SQL += WhereClause + "AND " + SQLItemType + RaceClause + TextClause + ComboType + Copies + SizesClause + " ORDER BY BLUEPRINT_GROUP, BLUEPRINT_NAME";
            }
            else
            {
                SQL += "WHERE " + SQLItemType + RaceClause + TextClause + ComboType + Copies + SizesClause + " ORDER BY BLUEPRINT_GROUP, BLUEPRINT_NAME";
            }

            BuildBPSelectQueryRet = SQL;
            return BuildBPSelectQueryRet;

        }

        // Builds the where clause for the calc screen based on Tech and Group selections
        private string BuildWhereClause()
        {
            string WhereClause = "";
            string SQLItemType = "";
            string SQL = "";
            string Copies = "";
            string TempRace = "";
            string RaceClause = "";
            string SizesClause = "";

            WhereClause = Public_Variables.GetBlueprintSQLWhereQuery(rbtnAmmoChargeBlueprints.Checked, rbtnDroneBlueprints.Checked, rbtnModuleBlueprints.Checked, rbtnShipBlueprints.Checked, rbtnSubsystemBlueprints.Checked, rbtnBoosterBlueprints.Checked, rbtnComponentBlueprints.Checked, rbtnMiscBlueprints.Checked, rbtnDeployableBlueprints.Checked, rbtnCelestialsBlueprints.Checked, rbtnStructureBlueprints.Checked, rbtnStructureRigsBlueprints.Checked, rbtnStructureModulesBlueprints.Checked, rbtnReactionBlueprints.Checked, rbtnRigBlueprints.Checked);

            // Item Type Definitions - These are set by me based on existing data
            // 1, 2, 14 are T1, T2, T3
            // 3 is Storyline
            // 15 is Pirate Faction
            // 16 is Navy Faction

            // Check Tech version
            if (chkBPT1.Enabled)
            {
                // Only a Subsystem so T3
                if (chkBPT1.Checked)
                {
                    SQLItemType = SQLItemType + "1,";
                }
            }

            if (chkBPT2.Enabled)
            {
                if (chkBPT2.Checked)
                {
                    SQLItemType = SQLItemType + "2,";
                }
            }

            if (chkBPT3.Enabled)
            {
                if (chkBPT3.Checked)
                {
                    SQLItemType = SQLItemType + "14,";
                }
            }

            if (chkBPStoryline.Enabled)
            {
                if (chkBPStoryline.Checked)
                {
                    SQLItemType = SQLItemType + "3,";
                }
            }

            if (chkBPPirateFaction.Enabled)
            {
                if (chkBPPirateFaction.Checked)
                {
                    SQLItemType = SQLItemType + "15,";
                }
            }

            if (chkBPNavyFaction.Enabled)
            {
                if (chkBPNavyFaction.Checked)
                {
                    SQLItemType = SQLItemType + "16,";
                }
            }

            // Add Item Type
            if (!string.IsNullOrEmpty(SQLItemType))
            {
                SQLItemType = "ITEM_TYPE IN (" + SQLItemType.Substring(0, SQLItemType.Length - 1) + ")";
            }
            else
            {
                return "";
            }

            // Adjust where clause
            if (!string.IsNullOrEmpty(WhereClause) & !string.IsNullOrEmpty(SQLItemType))
            {
                WhereClause = "WHERE (" + WhereClause + ") AND (" + SQLItemType + ")";
            }
            else if (!string.IsNullOrEmpty(SQLItemType))
            {
                // They want all items with these techs
                WhereClause = "WHERE (" + SQLItemType + ")";
            }

            // Determine what race we are looking at
            if (chkRaceAmarr.Checked)
            {
                TempRace = TempRace + "4,";
            }
            if (chkRaceCaldari.Checked)
            {
                TempRace = TempRace + "1,";
            }
            if (chkRaceMinmatar.Checked)
            {
                TempRace = TempRace + "2,";
            }
            if (chkRaceGallente.Checked)
            {
                TempRace = TempRace + "8,";
            }
            if (chkRacePirate.Checked)
            {
                TempRace = TempRace + "15,";
            }
            if (chkRaceOther.Checked)
            {
                TempRace = TempRace + "0,";
            }

            if (!string.IsNullOrEmpty(TempRace))
            {
                TempRace = "(" + TempRace.Substring(0, Strings.Len(TempRace) - 1) + ")";
                RaceClause = "AND (RACE_ID IN " + TempRace + ") ";
            }
            else
            {
                // They need to have at least one. If not, just return nothing
                return "";
            }

            // See if they want copies
            if (rbtnOnlyBPO.Checked)
            {
                Copies = " AND BP_TYPE <> " + ((int)Public_Variables.BPType.Copy).ToString() + " ";  // Only BPO's or Unknown
            }
            else if (rbtnOnlyCopies.Checked)
            {
                Copies = " AND BP_TYPE = " + ((int)Public_Variables.BPType.Copy).ToString() + " "; // Only Copies
            }

            // Finally add the sizes
            if (chkBPSmall.Checked) // Light
            {
                SizesClause = SizesClause + "'S',";
            }

            if (chkBPMedium.Checked) // Medium
            {
                SizesClause = SizesClause + "'M',";
            }

            if (chkBPLarge.Checked) // Heavy
            {
                SizesClause = SizesClause + "'L',";
            }

            if (chkBPXL.Checked) // Fighters
            {
                SizesClause = SizesClause + "'XL',";
            }

            if (!string.IsNullOrEmpty(SizesClause))
            {
                SizesClause = " AND SIZE_GROUP IN (" + SizesClause.Substring(0, Strings.Len(SizesClause) - 1) + ") ";
            }

            return WhereClause + Copies + RaceClause + SizesClause;

        }

        // Loads the cmbBPTypeFilter object with types based on the radio button selected - Ie, Drones will load Drone types (Small, Medium, Heavy...etc)
        private void LoadBPTypes()
        {
            string SQL;
            string WhereClause = "";
            SQLiteDataReader readerTypes;
            var BPUserID = default(long);

            cmbBPTypeFilter.Text = SelectTypeText;
            SQL = "SELECT ITEM_GROUP FROM " + Public_Variables.USER_BLUEPRINTS;

            WhereClause = BuildWhereClause();

            if (string.IsNullOrEmpty(WhereClause))
            {
                // They didn't select anything, just clear and exit
                cmbBPTypeFilter.Items.Clear();
                cmbBPTypeFilter.Text = SelectTypeText;
                return;
            }

            // See if we are looking at User Owned blueprints or All
            if (rbtnOwned.Checked)
            {
                // Ignore scanned BP's
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE (USER_ID =" + Public_Variables.SelectedCharacter.ID + "OR USER_ID = " + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID + ") AND OWNED <> 0  ";
                }
                else
                {
                    WhereClause += " AND USER_ID =" + Public_Variables.SelectedCharacter.ID + " AND OWNED <> 0  ";
                }

                // Set the correct ID
                BPUserID = Public_Variables.SelectedCharacter.ID;
            }

            else if (rbtnScannedPersonalBPs.Checked)
            {
                // Include all BP's
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE USER_ID = " + Public_Variables.SelectedCharacter.ID + " AND SCANNED <> 0 ";
                }
                else
                {
                    WhereClause += " AND USER_ID = " + Public_Variables.SelectedCharacter.ID + " AND SCANNED <> 0 ";
                }

                // Set the correct ID
                BPUserID = Public_Variables.SelectedCharacter.ID;
            }

            else if (rbtnScannedCorpBPs.Checked)
            {
                // Include corp scanned
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = "WHERE USER_ID =" + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID + " AND SCANNED <> 0 ";
                }
                else
                {
                    WhereClause += " AND USER_ID =" + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID + " AND SCANNED <> 0 ";
                }

                // Set the correct ID
                BPUserID = Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID;

            }

            SQL += WhereClause + " AND IGNORE = 0 GROUP BY ITEM_GROUP";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());

            Public_Variables.DBCommand.Parameters.AddWithValue("@USERBP_USERID", Public_Variables.GetBPUserID(BPUserID)); // need to search for corp ID too
            Public_Variables.DBCommand.Parameters.AddWithValue("@USERBP_CORPID", Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString());
            readerTypes = Public_Variables.DBCommand.ExecuteReader();

            cmbBPTypeFilter.Items.Clear();
            // Add Select Type to top
            cmbBPTypeFilter.Items.Add(SelectTypeText);
            // Add rest
            while (readerTypes.Read())
                cmbBPTypeFilter.Items.Add(readerTypes.GetString(0));

            readerTypes.Close();
            readerTypes = null;
            Public_Variables.DBCommand = null;

        }

        // Checks the ME and TE boxes to make sure they are ok and errors if not
        private bool CorrectMETE()
        {

            if (!Information.IsNumeric(txtBPME.Text) | string.IsNullOrEmpty(Strings.Trim(txtBPME.Text)))
            {
                Interaction.MsgBox("Invalid ME Value", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            if (!Information.IsNumeric(txtBPTE.Text) | string.IsNullOrEmpty(Strings.Trim(txtBPTE.Text)))
            {
                Interaction.MsgBox("Invalid TE Value", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            if (Conversion.Val(txtBPME.Text) > 10d)
            {
                Interaction.MsgBox("ME value cannot be greater than 10", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            if (Conversion.Val(txtBPTE.Text) > 20d)
            {
                Interaction.MsgBox("TE value cannot be greater than 20", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            if (Conversion.Val(txtBPME.Text) < 0d)
            {
                Interaction.MsgBox("ME value cannot be less than zero", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            if (Conversion.Val(txtBPTE.Text) < 0d)
            {
                Interaction.MsgBox("TE value cannot be less than zero", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            return true;

        }

        // Will use CAK and scan for bps in the user's items and store a temp table of these bps for loading in the grid
        private void btnScanPersonalBPs_Click(object sender, EventArgs e)
        {

            if (Public_Variables.SelectedCharacter.BlueprintsAccess)
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();
                Cursor = Cursors.WaitCursor;
                Public_Variables.SelectedCharacter.GetBlueprints().LoadBlueprints(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, Public_Variables.ScanType.Personal, true);
                Interaction.MsgBox("Blueprints Loaded", Constants.vbInformation, Application.ProductName);
                rbtnScannedPersonalBPs.Checked = true; // Auto load
                Cursor = Cursors.Default;
                Application.UseWaitCursor = false;
                Refresh();
                Application.DoEvents();
            }
            else
            {
                Interaction.MsgBox("You do not have the scope: " + ESI.ESICharacterBlueprintsScope + " registered for this application. Please update your developer scopes.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Will use CAK and scan for bps in the corps items and store a temp table of these bps for loading in the grid
        private void btnScanCorpBPs_Click(object sender, EventArgs e)
        {

            if (Public_Variables.SelectedCharacter.CharacterCorporation.BlueprintsAccess)
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();
                Cursor = Cursors.WaitCursor;
                Public_Variables.SelectedCharacter.CharacterCorporation.GetBlueprints().LoadBlueprints(Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID, Public_Variables.SelectedCharacter.CharacterTokenData, Public_Variables.ScanType.Corporation, true);
                Interaction.MsgBox("Blueprints Loaded", Constants.vbInformation, Application.ProductName);
                rbtnScannedCorpBPs.Checked = true; // Auto load
                Cursor = Cursors.Default;
                Application.UseWaitCursor = false;
                Refresh();
                Application.DoEvents();
            }
            else
            {
                Interaction.MsgBox("You do not have the scope: " + ESI.ESICorporationBlueprintsScope + @" registered for this application. Please 
your developer scopes.", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Clears all the checked items in grid
        private void btnReset_Click(object sender, EventArgs e)
        {
            InitForm();
        }

        // Checks all the items in the grid
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            ListViewItem item;
            ListView.ListViewItemCollection items;

            // Change to toggle "Select All" or "Uncheck All"
            if (btnSelectAll.Text == "Select All")
            {
                btnSelectAll.Text = "Uncheck All";
                items = lstBPs.Items;
                lstBPs.BeginUpdate();
                foreach (ListViewItem currentItem in items)
                {
                    item = currentItem;
                    item.Checked = true;
                }
                lstBPs.EndUpdate();
            }
            else
            {
                btnSelectAll.Text = "Select All";
                items = lstBPs.Items;
                lstBPs.BeginUpdate();
                foreach (ListViewItem currentItem1 in items)
                {
                    item = currentItem1;
                    item.Checked = false;
                }
                lstBPs.EndUpdate();
            }
        }

        // Updates selected items in the grid
        private void btnUpdateSelected_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems;
            var TempBPType = default(Public_Variables.BPType);

            int TempME;
            int TempTE;

            // Make sure the ME/TE boxes are good
            if (!CorrectMETE())
            {
                return;
            }

            // Make sure they actually have something selected
            if (lstBPs.CheckedItems.Count == 0)
            {
                Interaction.MsgBox("No Blueprints are Checked", Constants.vbExclamation, Text);
                return;
            }

            Cursor = Cursors.WaitCursor;

            // Just work with the ones that are checked
            checkedItems = lstBPs.CheckedItems;

            // Update each item based on inputs
            foreach (ListViewItem item in checkedItems)
            {

                // Select the BP type of using update selected and marking owned
                if (rbtnMarkasOwned.Checked & (item.SubItems[7].Text ?? "") != Public_Variables.Yes)
                {
                    // Save all BPs as copies if they aren't already owned - they can update if they want to, all items can have bpcs and it doesn't affect processing so this is easier
                    TempBPType = Public_Variables.BPType.Copy;
                }
                else if (rbtnMarkasUnowned.Checked)
                {
                    TempBPType = Public_Variables.BPType.NotOwned;
                }
                else
                {
                    // Set it to what they had in the grid
                    switch (item.SubItems[8].Text ?? "")
                    {
                        case Public_Variables.BPO:
                            {
                                TempBPType = Public_Variables.BPType.Original;
                                break;
                            }
                        case Public_Variables.BPC:
                            {
                                TempBPType = Public_Variables.BPType.Copy;
                                break;
                            }
                        case Public_Variables.InventedBPC:
                            {
                                TempBPType = Public_Variables.BPType.InventedBPC;
                                break;
                            }
                        case Public_Variables.Unknown:
                            {
                                TempBPType = Public_Variables.BPType.NotOwned;
                                break;
                            }
                    }
                }

                // Need to add selected blueprints to the character blueprints table, and set the ME and TE's as given or as stored
                if (chkEnableMETE.Checked == false | chkEnableMETE.Enabled == false)
                {
                    // Need to use the values in the grid, not the text boxes
                    TempME = Conversions.ToInteger(item.SubItems[5].Text);
                    TempTE = Conversions.ToInteger(item.SubItems[6].Text);
                }
                else
                {
                    // Use what they put in text
                    TempME = Conversions.ToInteger(txtBPME.Text);
                    TempTE = Conversions.ToInteger(txtBPTE.Text);
                }

                Public_Variables.UpdateBPinDB((int)Math.Round(Conversions.ToDouble(item.SubItems[1].Text)), TempME, TempTE, TempBPType, Conversions.ToInteger(item.SubItems[5].Text), Conversions.ToInteger(item.SubItems[6].Text), chkMarkasFavorite.Checked, chkMarkasIgnored.Checked, 0d, rbtnRemoveAllSettings.Checked);

            }

            // Refresh grid
            UpdateBlueprintGrid(false);

            txtBPME.Text = "0";
            txtBPTE.Text = "0";

            // Done
            rbtnMarkasOwned.Checked = true;
            Cursor = Cursors.Default;

            Interaction.MsgBox("Blueprints Updated", Constants.vbInformation, Text);

        }

        // Deletes all blueprints that are owned or scanned
        private void btnResetAll_Click(object sender, EventArgs e)
        {
            MsgBoxResult Response;

            Response = Interaction.MsgBox("This will reset all blueprints for this character" + Environment.NewLine + "deleting all scanned data and stored ME/TE values." + Environment.NewLine + Environment.NewLine + "Are you sure you want to do this?", Constants.vbYesNo, Application.ProductName);

            if (Response == Constants.vbYes)
            {
                Public_Variables.ResetAllBPData();

                UpdateBlueprintGrid(true);
            }

        }

        // Output full list of BPs, order by BP name, in CSV
        private void btnBackupBPs_Click(object sender, EventArgs e)
        {
            StreamWriter MyStream;
            string FileName;

            // Save file name with date
            FileName = "Blueprints Backup - " + Strings.Format(DateTime.Now, "MMddyyyy") + " - " + Public_Variables.SelectedCharacter.Name + ".csv";

            // Show the dialog
            SaveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            SaveFileDialog.FilterIndex = 1;
            SaveFileDialog.RestoreDirectory = true;
            SaveFileDialog.FileName = FileName;

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MyStream = File.CreateText(SaveFileDialog.FileName);

                    if (MyStream is not null)
                    {
                        // Pull all the blueprints, including not owned and output data for character and the character's corp
                        WriteDatatoFile(ref MyStream, Public_Variables.SelectedCharacter.ID, true, false);
                        WriteDatatoFile(ref MyStream, Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID, false, true);
                        MyStream.Flush();
                        MyStream.Close();

                        Interaction.MsgBox("Blueprints Backed Up", Constants.vbInformation, Application.ProductName);

                    }
                }
                catch
                {
                    Interaction.MsgBox(Information.Err().Description, Constants.vbExclamation, Application.ProductName);
                }
            }

        }

        private void WriteDatatoFile(ref StreamWriter MyStream, long API_ID, bool PrintHeader, bool IgnoreNonOwned)
        {
            string OutputText;

            string SQL;
            SQLiteDataReader readerBP;

            // Pull all the blueprints, including not owned and output data
            SQL = "SELECT * FROM " + Public_Variables.USER_BLUEPRINTS + " ORDER BY BLUEPRINT_GROUP, BLUEPRINT_NAME";
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());

            Public_Variables.DBCommand.Parameters.AddWithValue("@USERBP_USERID", Public_Variables.GetBPUserID(API_ID)); // need to search for corp ID too
            Public_Variables.DBCommand.Parameters.AddWithValue("@USERBP_CORPID", Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID.ToString());
            readerBP = Public_Variables.DBCommand.ExecuteReader();

            // 0-BP_ID, 1-BLUEPRINT_GROUP, 2-BLUEPRINT_NAME, 3-ITEM_GROUP_ID, 4-ITEM_GROUP, 5-ITEM_CATEGORY_ID, 
            // 6-ITEM_CATEGORY, 7-ITEM_ID, 8-ITEM_NAME, 9-ME, 10-TE, 11-USERID, 12-ITEM_TYPE, 13-RACE_ID, 14-OWNED, 15-SCANNED 
            // 16-BP_TYPE, 17-UNIQUE_BP_ITEM_ID, 18-FAVORITE, 19-VOLUME, 20-MARKET_GROUP_ID, 21-ADDITIONAL_COSTS, 
            // 22-LOCATION_ID, 23-QUANTITY, 24-FLAG_ID, 25-RUNS, 26-IGNORE, 27-TECH_LEVEL

            // Output the columns first
            if (PrintHeader)
            {
                OutputText = "API ID, Location ID, Item ID, Blueprint ID, Blueprint Group, Blueprint Name, ";
                OutputText = OutputText + "Quantity, Flag ID, ME, TE, Runs, BP Type, Owned, Scanned, Favorite, Additional Costs" + Environment.NewLine;
                MyStream.Write(OutputText);
            }

            while (readerBP.Read())
            {
                if (IgnoreNonOwned & readerBP.GetInt64(14) != 0L | !IgnoreNonOwned)
                {
                    OutputText = Conversions.ToLong(readerBP.GetValue(11)) + ","; // ID
                    OutputText = OutputText + Conversions.ToLong(readerBP.GetValue(22)) + ","; // Location Id
                    OutputText = OutputText + Conversions.ToLong(readerBP.GetValue(7)) + ","; // Item Id
                    OutputText = OutputText + Conversions.ToLong(readerBP.GetValue(0)) + ","; // BP ID
                    OutputText = OutputText + readerBP.GetString(1) + ","; // BP Group
                    OutputText = OutputText + readerBP.GetString(2) + ","; // BP Name
                    OutputText = OutputText + Conversions.ToLong(readerBP.GetValue(23)) + ","; // Quantity
                    OutputText = OutputText + Conversions.ToLong(readerBP.GetValue(24)) + ","; // Flag ID
                    OutputText = OutputText + Conversions.ToInteger(readerBP.GetValue(9)) + ","; // ME
                    OutputText = OutputText + Conversions.ToInteger(readerBP.GetValue(10)) + ","; // TE
                    OutputText = OutputText + Conversions.ToInteger(readerBP.GetValue(25)) + ","; // Runs
                    OutputText = OutputText + Public_Variables.GetBPTypeString(readerBP.GetInt32(16)) + ","; // BP Type
                    if (Math.Abs(Conversions.ToInteger(readerBP.GetValue(14))) == 1) // Owned
                    {
                        OutputText = OutputText + "True,";
                    }
                    else
                    {
                        OutputText = OutputText + "False,";
                    }

                    if (Conversions.ToInteger(readerBP.GetValue(15)) == 1 | Conversions.ToInteger(readerBP.GetValue(15)) == 2) // Scanned
                    {
                        OutputText = OutputText + "True,";
                    }
                    else
                    {
                        OutputText = OutputText + "False,";
                    }

                    // Favorites
                    if (Conversions.ToInteger(readerBP.GetValue(18)) == 1)
                    {
                        OutputText = OutputText + "True,";
                    }
                    else
                    {
                        OutputText = OutputText + "False,";
                    }
                    OutputText = OutputText + Conversions.ToDouble(readerBP.GetValue(21));  // Additional Costs

                    MyStream.Write(OutputText + Environment.NewLine);
                }
            }

        }

        // Loads BPs from a full list
        private void btnLoadBPs_Click(object sender, EventArgs e)
        {
            string SQL;
            StreamReader BPStream = null;
            var openFileDialog1 = new OpenFileDialog();
            string Line;
            string[] ParsedLine;

            // openFileDialog1.InitialDirectory = "c:\"
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FileName = "*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Public_Variables.EVEDB.BeginSQLiteTransaction();
                do
                {
                    try
                    {
                        BPStream = new StreamReader(openFileDialog1.FileName);

                        if (BPStream is not null)
                        {
                            // Read the file line by line here, start with headers
                            Line = BPStream.ReadLine();
                            Line = BPStream.ReadLine(); // First line of data

                            if (Line is not null)
                            {
                                // Start the session and delete all the records out of the table for this user
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
                                Public_Variables.EVEDB.ExecuteNonQuerySQL("DELETE FROM OWNED_BLUEPRINTS WHERE USER_ID IN (" + TempID + "," + Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID + ")");
                            }
                            else
                            {
                                // Leave loop
                                break;
                            }

                            Application.UseWaitCursor = true;

                            while (Line is not null)
                            {
                                lstBPs.Enabled = false;
                                gbBPFilter.Enabled = false;
                                gbUpdateOptions.Enabled = false;
                                Application.DoEvents();
                                // Format is: 0-API ID, 1-Location ID, 2-Item ID, 3-Blueprint ID, 4-Blueprint Group, 5-Blueprint Name, 
                                // 6-Quantity, 7-Flag ID, 8-ME, 9-TE, 10-Runs, 11-BP Type, 12-Owned, 13-Scanned, 14-Favorite, 15-Additional Costs

                                // Parse it
                                ParsedLine = Line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                // Only load BP's that are marked as something other than 'Unowned'
                                if ((ParsedLine[11] ?? "") != Public_Variables.UnownedBP)
                                {
                                    SQL = "INSERT INTO OWNED_BLUEPRINTS VALUES (";
                                    // See what ID we use for character bps
                                    long TempID = 0L;
                                    if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar)
                                    {
                                        // Use the ID sent
                                        SQL += ParsedLine[0] + ","; // API ID
                                    }
                                    else
                                    {
                                        SQL += Public_Variables.CommonLoadBPsID + ",";
                                    } // API ID

                                    SQL += ParsedLine[1] + ","; // Location ID
                                    SQL += ParsedLine[2] + ","; // Item ID
                                    SQL += ParsedLine[3] + ","; // Blueprint ID
                                    SQL += "'" + Public_Variables.FormatDBString(ParsedLine[5]) + "',"; // Blueprint Name
                                    SQL += ParsedLine[6] + ","; // Quantity
                                    SQL += ParsedLine[7] + ","; // Flag ID
                                    SQL += ParsedLine[8] + ","; // ME
                                    SQL += ParsedLine[9] + ","; // TE
                                    SQL += ParsedLine[10] + ","; // Runs

                                    Public_Variables.BPType TempBPType;
                                    bool TempOwned;
                                    bool TempScanned;

                                    // BP Type 
                                    TempBPType = Public_Variables.GetBPType(ParsedLine[11]);
                                    // Owned
                                    TempOwned = Conversions.ToBoolean(Strings.UCase(ParsedLine[12]));
                                    // Scanned
                                    TempScanned = Conversions.ToBoolean(Strings.UCase(ParsedLine[13]));

                                    if (!TempOwned)
                                    {
                                        // Set the bp type regardless
                                        TempBPType = Public_Variables.BPType.NotOwned;
                                    }

                                    // BP Type SQL
                                    SQL += ((int)TempBPType).ToString() + ",";
                                    // Owned SQL
                                    if (TempOwned)
                                    {
                                        if (TempScanned)
                                        {
                                            SQL += "1,";
                                        }
                                        else
                                        {
                                            SQL += "-1,";
                                        }
                                    }
                                    else
                                    {
                                        SQL += "0,";
                                    }

                                    // Scanned SQL
                                    if (TempScanned)
                                    {
                                        if (Conversions.ToLong(ParsedLine[0]) == Public_Variables.SelectedCharacter.CharacterCorporation.CorporationID)
                                        {
                                            SQL += "2,"; // Corp BP
                                        }
                                        else
                                        {
                                            SQL += "1,";
                                        }
                                    }
                                    else
                                    {
                                        SQL += "0,";
                                    }

                                    // Favorite
                                    if (Strings.UCase(ParsedLine[14]) == "TRUE")
                                    {
                                        SQL += "1,";
                                    }
                                    else
                                    {
                                        SQL += "0,";
                                    }

                                    SQL += ParsedLine[15]; // Additional Costs
                                    SQL += ")";

                                    // Insert the record
                                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                                }

                                Line = BPStream.ReadLine(); // Read next line

                            }

                            Public_Variables.EVEDB.CommitSQLiteTransaction();

                            Application.UseWaitCursor = false;
                            Interaction.MsgBox("Blueprints Loaded", Constants.vbInformation, Application.ProductName);

                        }
                    }
                    catch (Exception Ex)
                    {
                        Application.UseWaitCursor = false;
                        Public_Variables.EVEDB.RollbackSQLiteTransaction();
                        MessageBox.Show("Cannot read file from disk. Original error: " + Ex.Message);
                    }
                    finally
                    {
                        // Check this again, since we need to make sure we didn't throw an exception on open.
                        if (BPStream is not null)
                        {
                            BPStream.Close();
                        }
                    }
                }
                while (false);
            }

            Application.UseWaitCursor = false;
            lstBPs.Enabled = true;
            gbBPFilter.Enabled = true;
            gbUpdateOptions.Enabled = true;

            UpdateBlueprintGrid(true);
            Application.DoEvents();

        }

        #region InlineListUpdates

        private void lstBPs_MouseClick(object sender, MouseEventArgs e)
        {
            int iSubIndex = 0;

            // Hide the text box when a new line is selected
            txtBPEdit.Hide();

            CurrentRow = lstBPs.GetItemAt(e.X, e.Y);     // which listviewitem was clicked

            if (CurrentRow is null)
            {
                return;
            }

            CurrentCell = CurrentRow.GetSubItemAt(e.X, e.Y);  // which subitem was clicked

            // Determine where the previous and next item boxes will be based on what they clicked - used in tab event handling
            SetNextandPreviousCells();

            // See which column has been clicked
            iSubIndex = CurrentRow.SubItems.IndexOf(CurrentCell);

            // Set the columns that can be edited, just ME and TE
            if (iSubIndex == 5 | iSubIndex == 6)
            {

                if (iSubIndex == 5)
                {
                    MEUpdate = true;
                }
                else
                {
                    MEUpdate = false;
                }

                if (iSubIndex == 6)
                {
                    TEUpdate = true;
                }
                else
                {
                    TEUpdate = false;
                }

                FavoriteUpdate = false;
                IgnoredBPUpdate = false;
                OwnedTypeUpdate = false;

                ShowEditBoxes();
            }

            else if (iSubIndex == 8) // Owned Type
            {

                MEUpdate = false;
                TEUpdate = false;
                FavoriteUpdate = false;
                IgnoredBPUpdate = false;
                OwnedTypeUpdate = true;

                ShowEditBoxes();
            }

            else if (iSubIndex == 9) // Favorite
            {

                MEUpdate = false;
                TEUpdate = false;
                FavoriteUpdate = true;
                IgnoredBPUpdate = false;
                OwnedTypeUpdate = false;

                ShowEditBoxes();
            }

            else if (iSubIndex == 10) // Ignored
            {

                MEUpdate = false;
                TEUpdate = false;
                FavoriteUpdate = false;
                IgnoredBPUpdate = true;
                OwnedTypeUpdate = false;

                ShowEditBoxes();
            }

            else
            {
                // Not updatable so leave
                return;
            }

        }

        private void ProcessKeyDownBPEdit(Keys SentKey)
        {
            string SQL = "";
            int MEValue;
            int TEValue;
            string FavoriteValue;
            string OwnedTypeValue;
            string IgnoredValue;
            Public_Variables.BPType TempBPType;
            Public_Variables.BPType UpdatedBPType;

            bool SetasFavorite;
            bool SetasIgnore;

            // Change blank entry to 0
            if (string.IsNullOrEmpty(Strings.Trim(txtBPEdit.Text)))
            {
                txtBPEdit.Text = "0";
            }

            // If they hit enter or tab away, mark the BP as owned in the DB with the values entered
            if ((SentKey == Keys.Enter | SentKey == Keys.ShiftKey | SentKey == Keys.Tab) & DataEntered)
            {

                // Check the input first
                if (!Information.IsNumeric(txtBPEdit.Text) & MEUpdate)
                {
                    Interaction.MsgBox("Invalid ME Value", Constants.vbExclamation);
                    return;
                }

                if (!Information.IsNumeric(txtBPEdit.Text) & TEUpdate)
                {
                    Interaction.MsgBox("Invalid TE Value", Constants.vbExclamation);
                    return;
                }

                // Save the data, Save as no scan, but BPO, BP Type
                if (MEUpdate)
                {
                    MEValue = Conversions.ToInteger(txtBPEdit.Text);
                }
                else
                {
                    MEValue = Conversions.ToInteger(CurrentRow.SubItems[5].Text);
                }

                if (TEUpdate)
                {
                    TEValue = Conversions.ToInteger(txtBPEdit.Text);
                }
                else
                {
                    TEValue = Conversions.ToInteger(CurrentRow.SubItems[6].Text);
                }

                if (OwnedTypeUpdate)
                {
                    OwnedTypeValue = cmbEdit.Text;
                }
                else
                {
                    OwnedTypeValue = CurrentRow.SubItems[8].Text;
                }

                if (FavoriteUpdate)
                {
                    FavoriteValue = cmbEdit.Text;
                }
                else
                {
                    FavoriteValue = CurrentRow.SubItems[9].Text;
                }

                if ((FavoriteValue ?? "") == Public_Variables.Yes)
                {
                    SetasFavorite = true;
                }
                else
                {
                    SetasFavorite = false;
                }

                if (IgnoredBPUpdate)
                {
                    IgnoredValue = cmbEdit.Text;
                }
                else
                {
                    IgnoredValue = CurrentRow.SubItems[10].Text;
                }

                if ((IgnoredValue ?? "") == Public_Variables.Yes)
                {
                    SetasIgnore = true;
                }
                else
                {
                    SetasIgnore = false;
                }

                // Check the numbers, if they are the same, then don't mark as owned
                if (MEValue == Conversions.ToInteger(CurrentRow.SubItems[5].Text) & TEValue == Conversions.ToInteger(CurrentRow.SubItems[6].Text) & (OwnedTypeValue ?? "") == (CurrentRow.SubItems[8].Text ?? "") & (FavoriteValue ?? "") == (CurrentRow.SubItems[9].Text ?? "") & (IgnoredValue ?? "") == (CurrentRow.SubItems[10].Text ?? ""))



                {
                    // Skip down
                    goto Tabs;
                }

                // Set the bp type to make sure we set the owned flag correctly
                TempBPType = Public_Variables.GetBPType(OwnedTypeValue);

                var TempRuns = default(int);

                UpdatedBPType = Public_Variables.UpdateBPinDB(Conversions.ToLong(CurrentRow.SubItems[1].Text), MEValue, TEValue, TempBPType, Conversions.ToInteger(CurrentRow.SubItems[5].Text), Conversions.ToInteger(CurrentRow.SubItems[6].Text), SetasFavorite, SetasIgnore);

                Public_Variables.PlayNotifySound();

                // Reset text they entered if tabbed
                if (SentKey == Keys.ShiftKey | SentKey == Keys.Tab)
                {
                    txtBPEdit.Text = "";
                }

                // Update the data in the current row
                CurrentRow.SubItems[8].Text = Public_Variables.GetBPTypeString(UpdatedBPType);
                if (UpdatedBPType == Public_Variables.BPType.NotOwned | CurrentRow.SubItems[2].Text.Contains("Reaction Formulas")) // Reactions are always set to 0
                {
                    // Update the ME/TE to 0 
                    CurrentRow.SubItems[5].Text = "0";
                    CurrentRow.SubItems[6].Text = "0";
                }
                else
                {
                    CurrentRow.SubItems[5].Text = MEValue.ToString();
                    CurrentRow.SubItems[6].Text = TEValue.ToString();
                }

                if (TempRuns == -1)
                {
                    CurrentRow.SubItems[11].Text = Public_Variables.Unlimited;
                }
                else
                {
                    CurrentRow.SubItems[11].Text = TempRuns.ToString();
                }

                CurrentRow.SubItems[9].Text = FavoriteValue;
                CurrentRow.SubItems[10].Text = IgnoredValue;

                // Since they selected the row, update the ME/TE boxes with new data
                txtBPME.Text = MEValue.ToString();
                txtBPTE.Text = TEValue.ToString();

                // Mark as owned and change color
                SetOwnedFlagandColors(ref CurrentRow, Conversions.ToBoolean(UpdatedBPType));

                if (UpdatedBPType == Public_Variables.BPType.NotOwned) // 14 = Owned
                {
                    CurrentRow.SubItems[7].Text = Public_Variables.No;
                    CurrentRow.ForeColor = Color.Black;
                    CurrentRow.BackColor = Color.White;
                }
                else
                {
                    CurrentRow.SubItems[7].Text = Public_Variables.Yes;
                    CurrentRow.ForeColor = Color.Blue;
                }

                if (SentKey == Keys.Enter)
                {
                    // Just refresh and select the current row
                    CurrentRow.Selected = true;
                    txtBPEdit.Visible = false;
                    cmbEdit.Visible = false;
                }

                // Data updated, so reset
                DataEntered = false;

            }

        Tabs:
            ;

            // If they hit tab, then tab to the next cell
            if (SentKey == Keys.Tab)
            {
                CurrentCell = NextCell;
                // Reset these each time
                SetNextandPreviousCells("Next");
                if (CurrentRow.Index == 0)
                {
                    // Scroll to top
                    lstBPs.Items[0].Selected = true;
                    lstBPs.EnsureVisible(0);
                    lstBPs.Update();
                }
                else
                {
                    // Make sure the row is visible
                    lstBPs.EnsureVisible(CurrentRow.Index);
                }
                // Show the text box
                ShowEditBoxes();
            }

            // If shift+tab, then go to the previous cell 
            if (SentKey == Keys.ShiftKey)
            {
                CurrentCell = PreviousCell;
                // Reset these each time
                SetNextandPreviousCells("Previous");
                if (CurrentRow.Index == lstBPs.Items.Count - 1)
                {
                    // Scroll to bottom
                    lstBPs.Items[lstBPs.Items.Count - 1].Selected = true;
                    lstBPs.EnsureVisible(lstBPs.Items.Count - 1);
                    lstBPs.Update();
                }
                else
                {
                    // Make sure the row is visible
                    lstBPs.EnsureVisible(CurrentRow.Index);
                }
                // Show the text box
                ShowEditBoxes();
            }

        }

        // Determines where the previous and next item boxes will be based on what they clicked - used in tab event handling
        private void SetNextandPreviousCells(string CellType = "")
        {
            int iSubIndex = 0;

            // Normal Row
            if (CellType == "Next")
            {
                CurrentRow = NextCellRow;
            }
            else if (CellType == "Previous")
            {
                CurrentRow = PreviousCellRow;
            }

            // Get index of column
            iSubIndex = CurrentRow.SubItems.IndexOf(CurrentCell);

            // Get next and previous rows. If at end, wrap to top. If at top, wrap to bottom
            if (lstBPs.Items.Count == 1)
            {
                NextRow = CurrentRow;
                PreviousRow = CurrentRow;
            }
            else if (CurrentRow.Index != lstBPs.Items.Count - 1 & CurrentRow.Index != 0)
            {
                // Not the last line, so set the next and previous
                NextRow = lstBPs.Items[CurrentRow.Index + 1];
                PreviousRow = lstBPs.Items[CurrentRow.Index - 1];
            }
            else if (CurrentRow.Index == 0)
            {
                NextRow = lstBPs.Items[CurrentRow.Index + 1];
                // Wrap to bottom
                PreviousRow = lstBPs.Items[lstBPs.Items.Count - 1];
            }
            else if (CurrentRow.Index == lstBPs.Items.Count - 1)
            {
                // Need to wrap up to top
                NextRow = lstBPs.Items[0];
                PreviousRow = lstBPs.Items[CurrentRow.Index - 1];
            }

            // ME box is selected
            if (iSubIndex == 5)
            {
                // Set the next and previous ME boxes (subitems)
                NextCell = CurrentRow.SubItems[6]; // On Same Line 
                NextCellRow = CurrentRow;
                PreviousCell = PreviousRow.SubItems[10]; // On previous line 
                PreviousCellRow = PreviousRow;
                MEUpdate = true;
                TEUpdate = false;
                FavoriteUpdate = false;
                IgnoredBPUpdate = false;
                OwnedTypeUpdate = false;
            }
            else if (iSubIndex == 6) // TE box is selected
            {
                // Set the next and previous ME or favorite boxes (subitems)
                NextCell = CurrentRow.SubItems[8]; // On same line 
                NextCellRow = CurrentRow;
                PreviousCell = CurrentRow.SubItems[5]; // On same line 
                PreviousCellRow = CurrentRow;
                MEUpdate = false;
                TEUpdate = true;
                FavoriteUpdate = false;
                IgnoredBPUpdate = false;
                OwnedTypeUpdate = false;
            }
            else if (iSubIndex == 8) // Owned Type combo
            {
                // Set the next and previous ME boxes (subitems)
                NextCell = CurrentRow.SubItems[9]; // On On same line 
                NextCellRow = CurrentRow;
                PreviousCell = CurrentRow.SubItems[6]; // On same line 
                PreviousCellRow = CurrentRow;
                MEUpdate = false;
                TEUpdate = false;
                FavoriteUpdate = false;
                IgnoredBPUpdate = false;
                OwnedTypeUpdate = true;
            }
            else if (iSubIndex == 9) // Favorite combo
            {
                // Set the next and previous ME boxes (subitems)
                NextCell = CurrentRow.SubItems[10]; // On same line
                NextCellRow = CurrentRow;
                PreviousCell = CurrentRow.SubItems[8]; // On same line 
                PreviousCellRow = CurrentRow;
                MEUpdate = false;
                TEUpdate = false;
                FavoriteUpdate = true;
                IgnoredBPUpdate = false;
                OwnedTypeUpdate = false;
            }
            else if (iSubIndex == 10) // Ignore combo
            {
                // Set the next and previous ME boxes (subitems)
                NextCell = NextRow.SubItems[5]; // On next line 
                NextCellRow = NextRow;
                PreviousCell = CurrentRow.SubItems[9]; // On same line 
                PreviousCellRow = CurrentRow;
                MEUpdate = false;
                TEUpdate = false;
                FavoriteUpdate = false;
                IgnoredBPUpdate = true;
                OwnedTypeUpdate = false;
            }
            else
            {
                NextCell = null;
                PreviousCell = null;
                CurrentCell = null;
            }

        }

        private void ShowEditBoxes()
        {
            int lLeft = 0;
            int lWidth = 0;

            // Get size of column and location
            lLeft = CurrentCell.Bounds.Left + 2;
            lWidth = CurrentCell.Bounds.Width;

            if (MEUpdate | TEUpdate)
            {
                {
                    var withBlock = txtBPEdit;
                    withBlock.Hide();
                    withBlock.SetBounds(lLeft + lstBPs.Left, CurrentCell.Bounds.Top + lstBPs.Top, lWidth, CurrentCell.Bounds.Height);
                    withBlock.Text = CurrentCell.Text;
                    withBlock.Show();
                    withBlock.TextAlign = HorizontalAlignment.Center;
                    withBlock.Focus();
                }
                cmbEdit.Visible = false;
            }
            else // OwnedType/Favorites/Ignore
            {
                {
                    var withBlock1 = cmbEdit;
                    if (OwnedTypeUpdate)
                    {
                        withBlock1.Items.Clear();
                        if (CurrentRow.SubItems[4].Text == "T1" | CurrentRow.SubItems[4].Text == "T2")
                        {
                            withBlock1.Items.Add(Public_Variables.BPO); // Only T1 and T2 have BPOs
                        }

                        if (CurrentRow.SubItems[4].Text == "T2" | CurrentRow.SubItems[4].Text == "T3")
                        {
                            // Invented BPCs are T2, T3 
                            withBlock1.Items.Add(Public_Variables.InventedBPC);
                        }

                        if (CurrentRow.SubItems[4].Text != "T3")
                        {
                            withBlock1.Items.Add(Public_Variables.BPC); // Copies from BPOs, which are T1 and T2 only
                        }
                        withBlock1.Items.Add(Public_Variables.UnownedBP);
                    }
                    else // Favorite / Ignore
                    {
                        withBlock1.Items.Clear();
                        withBlock1.Items.Add(Public_Variables.Yes);
                        withBlock1.Items.Add(Public_Variables.No);
                    }

                    withBlock1.Hide();
                    withBlock1.SetBounds(lLeft + lstBPs.Left, CurrentCell.Bounds.Top + lstBPs.Top, lWidth, CurrentCell.Bounds.Height);
                    withBlock1.Text = CurrentCell.Text;
                    DataEntered = false; // We just updated so reset
                    withBlock1.Show();
                    withBlock1.Focus();

                }
                txtBPEdit.Visible = false;
            }

        }

        // Processes the tab function in the text box for the grid. This overrides the default tabbing between controls
        protected override bool ProcessTabKey(bool TabForward)
        {
            var ac = ActiveControl;

            TabPressed = true;

            if (TabForward)
            {
                if (ReferenceEquals(ac, txtBPEdit) | ReferenceEquals(ac, cmbEdit))
                {
                    ProcessKeyDownBPEdit(Keys.Tab);
                    return true;
                }
            }
            else if (ReferenceEquals(ac, txtBPEdit) | ReferenceEquals(ac, cmbEdit))
            {
                // This is Shift + Tab but just send Shift for ease of processing
                ProcessKeyDownBPEdit(Keys.ShiftKey);
                return true;
            }

            return base.ProcessTabKey(TabForward);

        }

        // Detects Scroll event and hides boxes
        private void lstBPs_ProcMsg(Message m)
        {
            txtBPEdit.Hide();
            cmbEdit.Hide();
        }

        private void txtBPEdit_GotFocus(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                txtBPEdit.SelectAll();
            }
        }

        private void txtBPEdit_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtBPEdit, e);
            if (e.KeyCode == Keys.Enter)
            {
                ProcessKeyDownBPEdit(Keys.Enter);
            }
        }

        private void txtBPEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Make sure it's the right format for ME/TE
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedMETEChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
                else
                {
                    DataEntered = true;
                }
            }

        }

        private void txtBPEdit_LostFocus(object sender, EventArgs e)
        {
            // Lost focus some other way than tabbing
            if (!TabPressed)
            {
                ProcessKeyDownBPEdit(Keys.Enter);
            }
            TabPressed = false; // Reset
            txtBPEdit.Visible = false;
        }

        private void txtBPEdit_TextChanged(object sender, EventArgs e)
        {
            if (MEUpdate)
            {
                var argMETETextBox = txtBPEdit;
                Public_Variables.VerifyMETEEntry(ref argMETETextBox, "ME");
                txtBPEdit = argMETETextBox;
            }
            else
            {
                var argMETETextBox1 = txtBPEdit;
                Public_Variables.VerifyMETEEntry(ref argMETETextBox1, "TE");
                txtBPEdit = argMETETextBox1;
            }
        }

        private void cmbEdit_LostFocus(object sender, EventArgs e)
        {
            // Lost focus some other way than tabbing
            if (!TabPressed)
            {
                ProcessKeyDownBPEdit(Keys.Enter);
            }
            TabPressed = false; // Reset
            cmbEdit.Visible = false;
        }

        private void cmbEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataEntered = true;
        }

        #endregion

    }
}