using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmConversiontoOreSettings
    {
        private bool FirstFormLoad;
        private bool Reset;
        private bool OresChecked;
        private string OretoFind;
        public ProgramLocation SelectedLocation;

        private ControlsCollection m_ControlsCollection;
        private CheckBox[] OreCheckBoxes;
        private Label[] OreLabels;
        private CheckBox[] IgnoreChecks;
        private Label[] IgnoreLabels;

        public frmConversiontoOreSettings()
        {

            FirstFormLoad = true;
            Reset = false;

            // This call is required by the designer.
            InitializeComponent();

            // Settings
            {
                ref var withBlock = ref SettingsVariables.UserConversiontoOreSettings;
                switch (withBlock.ConversionType ?? "")
                {
                    case var @case when @case == (rbtnConversionNone.Text ?? ""):
                        {
                            rbtnConversionNone.Checked = true;
                            break;
                        }
                    case var case1 when case1 == (rbtnConversionOre.Text ?? ""):
                        {
                            rbtnConversionOre.Checked = true;
                            break;
                        }
                    case var case2 when case2 == (rbtnConversionIce.Text ?? ""):
                        {
                            rbtnConversionIce.Checked = true;
                            break;
                        }
                    case var case3 when case3 == (rbtnConversionOreIce.Text ?? ""):
                        {
                            rbtnConversionOreIce.Checked = true;
                            break;
                        }
                }

                chkCompressedOre.Checked = withBlock.CompressedOre;
                chkCompressedIce.Checked = withBlock.CompressedIce;

                switch (withBlock.MinimizeOn ?? "")
                {
                    case var case4 when case4 == (rbtnRefinePrice.Text ?? ""):
                        {
                            rbtnRefinePrice.Checked = true;
                            break;
                        }
                    case var case5 when case5 == (rbtnOrePrice.Text ?? ""):
                        {
                            rbtnOrePrice.Checked = true;
                            break;
                        }
                    case var case6 when case6 == (rbtnOreVolume.Text ?? ""):
                        {
                            rbtnOreVolume.Checked = true;
                            break;
                        }
                }

                chkHighSec.Checked = withBlock.HighSec;
                chkLowSec.Checked = withBlock.LowSec;
                chkNullSec.Checked = withBlock.NullSec;

                chkUseBaseOre.Checked = withBlock.OreVariant0;
                chkUse5percent.Checked = withBlock.OreVariant5;
                chkUse10percent.Checked = withBlock.OreVariant10;

                chkAmarr.Checked = withBlock.Amarr;
                chkCaldari.Checked = withBlock.Caldari;
                chkGallente.Checked = withBlock.Gallente;
                chkMinmatar.Checked = withBlock.Minmatar;

                chkC1.Checked = withBlock.C1;
                chkC2.Checked = withBlock.C2;
                chkC3.Checked = withBlock.C3;
                chkC4.Checked = withBlock.C4;
                chkC5.Checked = withBlock.C5;
                chkC6.Checked = withBlock.C6;

                gbWHClasses.Enabled = chkWH.Checked;

            }

            m_ControlsCollection = new ControlsCollection(this);
            // Get Region check boxes (note index starts at 1)
            OreCheckBoxes = (CheckBox[])ControlArrayUtils.getControlArray(this, MyControls, "chkOre");
            OreLabels = (Label[])ControlArrayUtils.getControlArray(this, MyControls, "lblOre");
            IgnoreChecks = (CheckBox[])ControlArrayUtils.getControlArray(this, MyControls, "chkIgnore");
            IgnoreLabels = (Label[])ControlArrayUtils.getControlArray(this, MyControls, "lblIgnore");

            RefreshOreList();

            FirstFormLoad = false;

        }

        ~frmConversiontoOreSettings()
        {
        }

        public Collection MyControls
        {
            get
            {
                return m_ControlsCollection.Controls;
            }
        }

        // Refreshes the Ore list based on the options selected 
        private void RefreshOreList()
        {
            string SQL = "";
            string SQLOre = "";
            string SQLIce = "";
            SQLiteDataReader rsOres;
            var OreList = new List<OreType>();

            // Check to make sure they have the right stuff checked
            if (Public_Variables.FirstLoad)
            {
                return;
            }
            if (!CheckMiningEntryData())
            {
                return;
            }

            if (rbtnConversionNone.Checked == false)
            {
                OreType TempOreType;

                // First determine what type of stuff we are mining
                SQL = "SELECT CASE WHEN groupname = 'Ice' THEN CASE WHEN SUBSTR(ORE_NAME,1,10) ='Compressed' THEN SUBSTR(ORE_NAME,12) ELSE ORE_NAME END ELSE groupName END AS ORE, ";
                SQL += "CASE WHEN groupName = 'Ice' THEN 'Ice' ELSE 'Ore' END as ORE_GROUP FROM ORES, ORE_LOCATIONS, INVENTORY_GROUPS, INVENTORY_TYPES ";
                SQL += "WHERE ORES.ORE_ID = ORE_LOCATIONS.ORE_ID AND ORES.ORE_ID = INVENTORY_TYPES.typeID AND INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID AND ";

                // Ore Type
                if (rbtnConversionOre.Checked | rbtnConversionOreIce.Checked)
                {
                    SQLOre = "(BELT_TYPE = 'Ore' AND HIGH_YIELD_ORE IN (";
                    // Add the variant flag with this
                    if (chkUseBaseOre.Checked)
                    {
                        SQLOre += "0,";
                    }
                    if (chkUse5percent.Checked)
                    {
                        SQLOre += "1,";
                    }
                    if (chkUse10percent.Checked)
                    {
                        SQLOre += "2,";
                    }
                    SQLOre = SQLOre.Substring(0, Strings.Len(SQLOre) - 1) + ")) ";
                }

                if (rbtnConversionIce.Checked | rbtnConversionOreIce.Checked)
                {
                    SQLIce = "(BELT_TYPE = 'Ice' AND HIGH_YIELD_ORE =-1) ";
                }

                // Combine with OR if ore/ice checked
                if (rbtnConversionOreIce.Checked)
                {
                    // Need to combine both
                    SQL += "(" + SQLOre + " OR " + SQLIce + ") ";
                }
                else if (rbtnConversionIce.Checked)
                {
                    SQL += SQLIce;
                }
                else
                {
                    SQL += SQLOre;
                }

                if (chkCompressedIce.Checked & chkCompressedIce.Enabled | chkCompressedOre.Checked & chkCompressedOre.Enabled)
                {
                    SQL += "AND COMPRESSED = 1 ";
                }
                else
                {
                    SQL += "AND COMPRESSED = 0 ";
                }

                SQL += "AND SYSTEM_SECURITY IN (";
                if (chkHighSec.Checked)
                {
                    SQL += "'High Sec',";
                }
                if (chkLowSec.Checked)
                {
                    SQL += "'Low Sec',";
                }
                if (chkNullSec.Checked)
                {
                    SQL += "'Null Sec',";
                }

                // If WH checked, then add the classes
                if (chkWH.Checked == true & chkWH.Enabled)
                {
                    if (chkC1.Checked & chkC1.Enabled)
                    {
                        SQL += "'C1',";
                    }
                    if (chkC2.Checked & chkC2.Enabled)
                    {
                        SQL += "'C2',";
                    }
                    if (chkC3.Checked & chkC3.Enabled)
                    {
                        SQL += "'C3',";
                    }
                    if (chkC4.Checked & chkC4.Enabled)
                    {
                        SQL += "'C4',";
                    }
                    if (chkC5.Checked & chkC5.Enabled)
                    {
                        SQL += "'C5',";
                    }
                    if (chkC6.Checked & chkC6.Enabled)
                    {
                        SQL += "'C6',";
                    }
                }
                SQL = SQL.Substring(0, Strings.Len(SQL) - 1) + ") ";

                // Now determine what space we are looking at
                SQL += "AND SPACE IN (";

                if (chkAmarr.Checked)
                {
                    SQL += "'Amarr',";
                }
                if (chkCaldari.Checked)
                {
                    SQL += "'Caldari',";
                }
                if (chkGallente.Checked)
                {
                    SQL += "'Gallente',";
                }
                if (chkMinmatar.Checked)
                {
                    SQL += "'Minmatar',";
                }
                if (chkTriglavian.Checked)
                {
                    SQL += "'Triglavian',";
                }
                if (chkWH.Checked)
                {
                    SQL += "'WH',";
                }
                SQL = SQL.Substring(0, Strings.Len(SQL) - 1) + ") ";

                SQL += "GROUP BY ORE, ORE_GROUP";

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsOres = Public_Variables.DBCommand.ExecuteReader();

                while (rsOres.Read())
                {
                    TempOreType.OreName = rsOres.GetString(0);
                    TempOreType.OreGroup = rsOres.GetString(1);
                    OreList.Add(TempOreType);
                }
            }

            // Update all the ore checks and adjust the orelist depending on overrides
            UpdateOreChecks(ref OreList);

            // If they have nothing checked, let them know
            if (!OresChecked & !rbtnConversionNone.Checked)
            {
                Interaction.MsgBox("No ores selected", Constants.vbExclamation, Application.ProductName);
            }

        }

        // Checks all the data entered
        private bool CheckMiningEntryData()
        {

            // Check the location
            if (chkHighSec.Checked == false & chkLowSec.Checked == false & chkNullSec.Checked == false)
            {
                // Can't query any ore
                Interaction.MsgBox("You must select an System Security", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            // Check the Space types
            if (chkAmarr.Checked == false & chkCaldari.Checked == false & chkGallente.Checked == false & chkMinmatar.Checked == false & chkWH.Checked == false & chkTriglavian.Checked == false)
            {
                // Can't query any ore
                Interaction.MsgBox("You must select an Ore Location", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            if (chkWH.Checked == true & chkWH.Enabled == true & chkC1.Checked == false & chkC2.Checked == false & chkC3.Checked == false & chkC4.Checked == false & chkC5.Checked == false & chkC6.Checked == false)
            {
                // Can't query any ore
                Interaction.MsgBox("You must select a Wormhole Class", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            // If ore or ore/ice is checked, then need to have a variant selected
            if (gbOreVariants.Enabled == true & chkUseBaseOre.Checked == false & chkUse5percent.Checked == false & chkUse10percent.Checked == false)
            {
                Interaction.MsgBox("You must select a Ore Variant", Constants.vbExclamation, Application.ProductName);
                return false;
            }

            return true;

        }

        private void UpdateOreChecks(ref List<OreType> SentOres)
        {
            OreType FoundItem;

            FirstFormLoad = true; // pause check updates
            OresChecked = false;
            SettingsVariables.UserConversiontoOreSettings.SelectedOres = new List<OreType>(); // Reset and add each ore to the list when selected
            SettingsVariables.UserConversiontoOreSettings.IgnoreItems = new List<string>(); // Reset this too

            // Clear all checks
            for (int i = 1, loopTo = OreCheckBoxes.Count() - 1; i <= loopTo; i++)
                OreCheckBoxes[i].Checked = false;

            {
                ref var withBlock = ref SettingsVariables.UserConversiontoOreSettings;
                if (SentOres.Count != 0)
                {
                    for (int i = 1, loopTo1 = OreLabels.Count() - 1; i <= loopTo1; i++)
                    {
                        OretoFind = OreLabels[i].Text;
                        FoundItem.OreName = "";
                        FoundItem = SentOres.Find(FindOre);
                        if (!string.IsNullOrEmpty(FoundItem.OreName))
                        {
                            // Set the checks for selected ores first
                            OreCheckBoxes[i].Checked = true;
                            withBlock.SelectedOres.Add(FoundItem);
                            OresChecked = true;
                        }
                    }

                    // Now do overrides - if it's checked from the selected options, reset the override value
                    for (int i = 0, loopTo2 = withBlock.OverrideChecks.Count() - 1; i <= loopTo2; i++)
                    {
                        if (withBlock.OverrideChecks[i] != SettingsVariables.AllSettings.DefaultOverrideValue)
                        {
                            if (Conversions.ToInteger(OreCheckBoxes[i + 1].Checked) != withBlock.OverrideChecks[i])
                            {
                                // The override value is different than what is checked through query, so set it to the override value
                                OreCheckBoxes[i + 1].Checked = Conversions.ToBoolean(withBlock.OverrideChecks[i]);
                            }
                            else
                            {
                                // Its the same as the checked value from query, so reset the override check to default
                                withBlock.OverrideChecks[i] = SettingsVariables.AllSettings.DefaultOverrideValue;
                            }
                            // Save ore info
                            FoundItem.OreName = OreLabels[i + 1].Text;
                            if (i + 1 >= 25)
                            {
                                FoundItem.OreGroup = "Ice";
                            }
                            else
                            {
                                FoundItem.OreGroup = "Ore";
                            }
                            // If checked add it to the list, else remove it
                            if (OreCheckBoxes[i + 1].Checked)
                            {
                                withBlock.SelectedOres.Add(FoundItem);
                                OresChecked = true;
                            }
                            else
                            {
                                withBlock.SelectedOres.Remove(FoundItem);
                            }
                        }
                    }

                    // Update ignore checks too
                    for (int i = 0, loopTo3 = withBlock.IgnoreRefinedItems.Count() - 1; i <= loopTo3; i++)
                    {
                        IgnoreChecks[i + 1].Checked = Conversions.ToBoolean(withBlock.IgnoreRefinedItems[i]);
                        if (IgnoreChecks[i + 1].Checked)
                        {
                            withBlock.IgnoreItems.Add(IgnoreLabels[i + 1].Text);
                        }
                    }

                }
            }

            FirstFormLoad = false;

        }

        // Predicate for finding the ore in the selected list
        public bool FindOre(OreType Ore)
        {
            if ((OretoFind ?? "") == (Ore.OreName ?? ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateSettings(bool SaveChanges = false)
        {
            ConversionToOreSettings TempSettings = default;
            var Settings = new ProgramSettings();

            if (rbtnConversionNone.Checked)
            {
                TempSettings.ConversionType = rbtnConversionNone.Text;
            }
            else if (rbtnConversionOre.Checked)
            {
                TempSettings.ConversionType = rbtnConversionOre.Text;
            }
            else if (rbtnConversionIce.Checked)
            {
                TempSettings.ConversionType = rbtnConversionIce.Text;
            }
            else if (rbtnConversionOreIce.Checked)
            {
                TempSettings.ConversionType = rbtnConversionOreIce.Text;
            }

            if (rbtnRefinePrice.Checked)
            {
                TempSettings.MinimizeOn = rbtnRefinePrice.Text;
            }
            else if (rbtnOreVolume.Checked)
            {
                TempSettings.MinimizeOn = rbtnOreVolume.Text;
            }
            else if (rbtnOrePrice.Checked)
            {
                TempSettings.MinimizeOn = rbtnOrePrice.Text;
            }

            TempSettings.CompressedIce = chkCompressedIce.Checked;
            TempSettings.CompressedOre = chkCompressedOre.Checked;

            TempSettings.HighSec = chkHighSec.Checked;
            TempSettings.LowSec = chkLowSec.Checked;
            TempSettings.NullSec = chkNullSec.Checked;

            TempSettings.Amarr = chkAmarr.Checked;
            TempSettings.Caldari = chkCaldari.Checked;
            TempSettings.Gallente = chkGallente.Checked;
            TempSettings.Minmatar = chkMinmatar.Checked;
            TempSettings.Wormhole = chkWH.Checked;
            TempSettings.Triglavian = chkTriglavian.Checked;

            TempSettings.C1 = chkC1.Checked;
            TempSettings.C2 = chkC2.Checked;
            TempSettings.C3 = chkC3.Checked;
            TempSettings.C4 = chkC4.Checked;
            TempSettings.C5 = chkC5.Checked;
            TempSettings.C6 = chkC6.Checked;

            TempSettings.OreVariant0 = chkUseBaseOre.Checked;
            TempSettings.OreVariant5 = chkUse5percent.Checked;
            TempSettings.OreVariant10 = chkUse10percent.Checked;

            // Override Checks is already set each time one is checked
            TempSettings.OverrideChecks = SettingsVariables.UserConversiontoOreSettings.OverrideChecks;
            TempSettings.SelectedOres = SettingsVariables.UserConversiontoOreSettings.SelectedOres;
            TempSettings.IgnoreRefinedItems = SettingsVariables.UserConversiontoOreSettings.IgnoreRefinedItems;
            TempSettings.IgnoreItems = SettingsVariables.UserConversiontoOreSettings.IgnoreItems;

            // Save the data to the local variable
            SettingsVariables.UserConversiontoOreSettings = TempSettings;

            if (SaveChanges)
            {
                // Save the data in the XML file
                Settings.SaveConversionToOreSettings(TempSettings);
                Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);
            }

        }

        private void UpdateSettingsRefresh()
        {
            // Always update the current settings locally, then refresh the ore/ice checks
            if (!FirstFormLoad & !Public_Variables.FirstLoad)
            {
                UpdateSettings();
                RefreshOreList();
                // Load the bp on bp tab
                if (!(Public_Variables.SelectedBlueprint == null) & SelectedLocation == ProgramLocation.BlueprintTab)
                {
                    {
                        ref var withBlock = ref Public_Variables.SelectedBlueprint;
                        My.MyProject.Forms.frmMain.UpdateBPGrids(withBlock.GetTypeID(), withBlock.GetTechLevel(), false, withBlock.GetItemGroupID(), withBlock.GetItemCategoryID(), Public_Variables.SentFromLocation.BlueprintTab);
                    }
                }
            }
        }

        #region Click events

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            UpdateSettings(true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clear the ignore and overrides, then reload the form
            SettingsVariables.UserConversiontoOreSettings.OverrideChecks = new int[36];
            SettingsVariables.UserConversiontoOreSettings.IgnoreRefinedItems = new int[15];

            for (int i = 0; i <= 35; i++)
                SettingsVariables.UserConversiontoOreSettings.OverrideChecks[i] = 1;

            for (int i = 0; i <= 14; i++)
                SettingsVariables.UserConversiontoOreSettings.IgnoreRefinedItems[i] = 0;

            Reset = true;
            for (int i = 1, loopTo = IgnoreChecks.Count() - 1; i <= loopTo; i++)
                IgnoreChecks[i].Checked = false;
            Reset = false;

            UpdateSettingsRefresh();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void chkWH_CheckedChanged(object sender, EventArgs e)
        {
            gbWHClasses.Enabled = chkWH.Checked;
            UpdateSettingsRefresh();
        }

        private void RadioOption_Changed(object sender, EventArgs e)
        {

            // Always update the current settings locally, then refresh the ore/ice checks
            if (((RadioButton)sender).Checked)
            {
                UpdateSettingsRefresh();
            }

        }

        private void CheckOption_Changed(object sender, EventArgs e)
        {

            // Always update the current settings locally, then refresh the ore/ice checks
            UpdateSettingsRefresh();

        }

        private void OreLabels_Click(object sender, EventArgs e)
        {



            // Find the index and toggle the check
            if (!FirstFormLoad)
            {
                int Index = Conversions.ToInteger(((Label)sender).Name.ToString().Substring(6));
                // Check the index
                OreCheckBoxes[Index].Checked = !OreCheckBoxes[Index].Checked;
            }
        }

        private void OreIce_CheckedChanged(object sender, EventArgs e)
        {

            if (!FirstFormLoad)
            {
                // Get the check number then update the override list
                CheckBox SelectedCheckbox = (CheckBox)sender;

                // They manually updated the check so change it here
                SettingsVariables.UserConversiontoOreSettings.OverrideChecks[Conversions.ToInteger(SelectedCheckbox.Name.ToString().Substring(6)) - 1] = Conversions.ToInteger(SelectedCheckbox.Checked);
                UpdateSettingsRefresh();
            }
        }

        private void IgnoreLabels_Click(object sender, EventArgs e)
        {

            // Find the index and toggle the check
            if (!FirstFormLoad)
            {
                int Index = Conversions.ToInteger(((Label)sender).Name.ToString().Substring(9));
                // Check the index
                IgnoreChecks[Index].Checked = !IgnoreChecks[Index].Checked;
            }
        }

        private void IgnoreChecks_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                // Get the check number then update the override list
                CheckBox SelectedCheck = (CheckBox)sender;
                int Index = Conversions.ToInteger(SelectedCheck.Name.ToString().Substring(9)) - 1;

                if (!Reset)
                {
                    // They manually updated an ignore check
                    SettingsVariables.UserConversiontoOreSettings.IgnoreRefinedItems[Conversions.ToInteger(SelectedCheck.Name.ToString().Substring(9)) - 1] = Conversions.ToInteger(SelectedCheck.Checked);
                    UpdateSettingsRefresh();
                }
            }
        }

        private void rbtnConversionOreIce_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConversionOreIce.Checked)
            {
                EnableObjects(true, true);
            }
        }

        private void rbtnConversionIce_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConversionIce.Checked)
            {
                EnableObjects(false, true);
            }
        }

        private void rbtnConversionOre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConversionOre.Checked)
            {
                EnableObjects(true, false);
            }
        }

        private void rbtnConversionNone_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConversionNone.Checked)
            {
                EnableObjects(false, false);
            }
        }

        private void EnableObjects(bool Ore, bool Ice)
        {

            // Disable first
            chkCompressedIce.Enabled = false;
            chkCompressedOre.Enabled = false;
            gbSystemSecurity.Enabled = false;
            gbMineOreLoc.Enabled = false;
            gbOreVariants.Enabled = false;
            // cmbNullAnomLevel.Enabled = False

            gbWHClasses.Enabled = false;

            chkWH.Enabled = false;
            chkTriglavian.Enabled = false;

            if (Ore)
            {
                gbSystemSecurity.Enabled = true;
                gbOreVariants.Enabled = true;
                chkCompressedOre.Enabled = true;
                // cmbNullAnomLevel.Enabled = True
                chkWH.Enabled = true;
                chkTriglavian.Enabled = true;

                if (chkWH.Checked)
                {
                    gbWHClasses.Enabled = true;
                }
                gbMineOreLoc.Enabled = true;
            }

            if (Ice)
            {
                chkCompressedIce.Enabled = true;
                gbSystemSecurity.Enabled = true;
                gbMineOreLoc.Enabled = true;
            }

            // Always update the current settings locally, then refresh the ore/ice checks
            UpdateSettingsRefresh();

            gbIgnoreMinerals.Enabled = Ore;
            gbIgnoreIceProducts.Enabled = Ice;

            // Finally, tabs
            tabPageIce.Enabled = Ice;
            tabPageOres.Enabled = Ore;

        }

        private void chkNullSec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNullSec.Checked)
            {
                chkWH.Enabled = true;
                chkTriglavian.Enabled = true;
            }
            else
            {
                chkWH.Enabled = false;
                chkTriglavian.Enabled = false;
            }

            if (chkWH.Checked)
            {
                gbWHClasses.Enabled = true;
            }
            else
            {
                gbWHClasses.Enabled = false;
            }

            UpdateSettingsRefresh();

        }

        #endregion

    }
}