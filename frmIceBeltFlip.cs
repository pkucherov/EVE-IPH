using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmIceBeltFlip
    {
        private int IceColumnClicked;
        private SortOrder IceColumnSortOrder;
        private int ProductColumnClicked;
        private SortOrder ProductColumnSortOrder;

        private bool FirstLoad;
        private ReprocessingPlant ReprocessingStation;
        private double BeltTotalValue;

        private enum IceLocationID
        {
            Highsec = 0,
            Lowsec = 1,
            NullWeak = 2,
            NullStrong = 3
        }

        public frmIceBeltFlip()
        {
            FirstLoad = true;

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            LoadSettings();

            InitializeReprocessingFacility();

            IceColumnClicked = 0;
            IceColumnSortOrder = SortOrder.None;
            ProductColumnClicked = 0;
            ProductColumnSortOrder = SortOrder.None;

            FirstLoad = false;

        }

        public void InitializeReprocessingFacility()
        {
            // Load the mining tab refinery
            Form argControlForm = this;
            ReprocessingFacility.InitializeControl(Public_Variables.SelectedCharacter.ID, ProgramLocation.IceBelts, ProductionType.Reprocessing, ref argControlForm);
        }

        private void frmIceBeltFlip_Shown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            LoadIceTable();

            Cursor = Cursors.Default;
            FirstLoad = false;

        }

        private void LoadSettings()
        {
            // Miner settings
            txtCycleTime.Text = Strings.FormatNumber(SettingsVariables.UserIceBeltFlipSettings.CycleTime);
            txtm3perCycle.Text = Strings.FormatNumber(SettingsVariables.UserIceBeltFlipSettings.m3perCycle);
            cmbNumMiners.Text = SettingsVariables.UserIceBeltFlipSettings.NumMiners.ToString();
            chkCompressIce.Checked = SettingsVariables.UserIceBeltFlipSettings.CompressOre;
            chkIPHperMiner.Checked = SettingsVariables.UserIceBeltFlipSettings.IPHperMiner;

            if (string.IsNullOrEmpty(SettingsVariables.UserIceBeltFlipSettings.SystemSecurity) | (SettingsVariables.UserIceBeltFlipSettings.SystemSecurity ?? "") == (rbtnHighsec.Text ?? ""))
            {
                rbtnHighsec.Checked = true;
            }
            else if ((SettingsVariables.UserIceBeltFlipSettings.SystemSecurity ?? "") == (rbtnLowsec.Text ?? ""))
            {
                rbtnLowsec.Checked = true;
            }
            else if ((SettingsVariables.UserIceBeltFlipSettings.SystemSecurity ?? "") == (rbtnNullWeak.Text ?? ""))
            {
                rbtnNullWeak.Checked = true;
            }
            else if ((SettingsVariables.UserIceBeltFlipSettings.SystemSecurity ?? "") == (rbtnNullStrong.Text ?? ""))
            {
                rbtnNullStrong.Checked = true;
            }

            // m3/hr/miner =  m3 per cycle / cycletime * 3600
            lblm3perhrperminer.Text = Strings.FormatNumber(Conversions.ToDouble(txtm3perCycle.Text) / Conversions.ToDouble(txtCycleTime.Text) * 3600d, 2);

            // Tax settings
            switch (SettingsVariables.UserIceBeltFlipSettings.IncludeBrokerFees)
            {
                case 2:
                    {
                        chkBrokerFees.CheckState = CheckState.Indeterminate;
                        txtBrokerFeeRate.Visible = true;
                        break;
                    }
                case 1:
                    {
                        chkBrokerFees.CheckState = CheckState.Checked;
                        break;
                    }
                case 0:
                    {
                        chkBrokerFees.CheckState = CheckState.Unchecked;
                        break;
                    }
            }

            chkIncludeTaxes.Checked = SettingsVariables.UserIceBeltFlipSettings.IncludeTaxes;
            txtBrokerFeeRate.Text = Strings.FormatPercent(SettingsVariables.UserIceBeltFlipSettings.BrokerFeeRate, 1);

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            IceBeltFlipSettings TempSettings = default;
            var Settings = new ProgramSettings();

            if (!CheckEnteredData())
            {
                return;
            }

            TempSettings.CompressOre = chkCompressIce.Checked;
            TempSettings.IPHperMiner = chkIPHperMiner.Checked;
            TempSettings.CycleTime = Conversions.ToDouble(txtCycleTime.Text);
            TempSettings.m3perCycle = Conversions.ToDouble(txtm3perCycle.Text);
            TempSettings.NumMiners = Conversions.ToInteger(cmbNumMiners.Text);

            TempSettings.IncludeTaxes = chkIncludeTaxes.Checked;
            TempSettings.IncludeBrokerFees = (int)chkBrokerFees.CheckState;
            TempSettings.BrokerFeeRate = Public_Variables.FormatManualPercentEntry(txtBrokerFeeRate.Text);

            if (rbtnHighsec.Checked)
            {
                TempSettings.SystemSecurity = rbtnHighsec.Text;
            }
            else if (rbtnLowsec.Checked)
            {
                TempSettings.SystemSecurity = rbtnLowsec.Text;
            }
            else if (rbtnNullWeak.Checked)
            {
                TempSettings.SystemSecurity = rbtnNullWeak.Text;
            }
            else if (rbtnNullStrong.Checked)
            {
                TempSettings.SystemSecurity = rbtnNullStrong.Text;
            }

            if (rbtnAmarr.Checked)
            {
                TempSettings.Space = rbtnAmarr.Text;
            }
            else if (rbtnCaldari.Checked)
            {
                TempSettings.Space = rbtnCaldari.Text;
            }
            else if (rbtnGallente.Checked)
            {
                TempSettings.Space = rbtnGallente.Text;
            }
            else if (rbtnMinmatar.Checked)
            {
                TempSettings.Space = rbtnMinmatar.Text;
            }

            // Save it in the Application settings
            Settings.SaveApplicationSettings(SettingsVariables.UserApplicationSettings);

            // Save the data in the XML file
            Settings.SaveIceBeltFlipSettings(TempSettings);

            // Save the data to the local variable
            SettingsVariables.UserIceBeltFlipSettings = TempSettings;

            Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

        }

        private void btnSaveChecks_Click(object sender, EventArgs e)
        {
            IceBeltCheckSettings TempSettings = default;
            var Settings = new ProgramSettings();
            var SavedSettings = new IceBeltCheckSettings();

            // Reset them all to default settings first if not found
            TempSettings = SettingsVariables.AllSettings.SetDefaultIceBeltChecksSettings();

            // Loop through the ore list and save the value
            for (int i = 0, loopTo = lstIce.Items.Count - 1; i <= loopTo; i++)
            {
                switch (lstIce.Items[i].SubItems[1].Text ?? "")
                {
                    case "Blue Ice":
                        {
                            TempSettings.BlueIce = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Clear Icicle":
                        {
                            TempSettings.ClearIcicle = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Dark Glitter":
                        {
                            TempSettings.DarkGlitter = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Enriched Clear Icicle":
                        {
                            TempSettings.EnrichedClearIcicle = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Gelidus":
                        {
                            TempSettings.Gelidus = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Glacial Mass":
                        {
                            TempSettings.GlacialMass = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Glare Crust":
                        {
                            TempSettings.GlareCrust = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Krystallos":
                        {
                            TempSettings.Krystallos = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Pristine White Glaze":
                        {
                            TempSettings.PristineWhiteGlaze = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Smooth Glacia lMass":
                        {
                            TempSettings.SmoothGlacialMass = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Thick Blue Ice":
                        {
                            TempSettings.ThickBlueIce = lstIce.Items[i].Checked;
                            break;
                        }
                    case "White Glaze":
                        {
                            TempSettings.WhiteGlaze = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Blue Ice":
                        {
                            TempSettings.CompressedBlueIce = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Clear Icicle":
                        {
                            TempSettings.CompressedClearIcicle = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Dark Glitter":
                        {
                            TempSettings.CompressedDarkGlitter = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Enriched Clear Icicle":
                        {
                            TempSettings.CompressedEnrichedClearIcicle = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Gelidus":
                        {
                            TempSettings.CompressedGelidus = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Glacial Mass":
                        {
                            TempSettings.CompressedGlacialMass = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Glare Crust":
                        {
                            TempSettings.CompressedGlareCrust = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Krystallos":
                        {
                            TempSettings.CompressedKrystallos = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Pristine White Glaze":
                        {
                            TempSettings.CompressedPristineWhiteGlaze = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Smooth Glacial Mass":
                        {
                            TempSettings.CompressedSmoothGlacialMass = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed Thick Blue Ice":
                        {
                            TempSettings.CompressedThickBlueIce = lstIce.Items[i].Checked;
                            break;
                        }
                    case "Compressed White Glaze":
                        {
                            TempSettings.CompressedWhiteGlaze = lstIce.Items[i].Checked;
                            break;
                        }
                }
            }

            // Save the data in the XML file
            Settings.SaveIceBeltChecksSettings(TempSettings);

            // Save them locally
            SettingsVariables.UserIceBeltCheckSettings = TempSettings;

            Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

        }

        private void RefineIce()
        {
            string SQL = "";
            SQLiteDataReader readerBelts;
            ListViewItem lstOreRow = null;
            ListView.CheckedListViewItemCollection checkedItems;
            var TotalRefinedMinerals = new Materials();
            var TotalCost = default(double);
            var OutputNumber = default(double);
            string IceName;

            double BeltVolume;
            double TimeToFlip;
            double TimeToFlipPer;

            var RefinedMaterials = new Materials();
            double TotalRefiningUsage = 0d;
            double SingleRefiningUsage = 0d;

            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            if (!CheckEnteredData())
            {
                Cursor = Cursors.Default;
                Application.DoEvents();
                return;
            }

            var BFI = new Public_Variables.BrokerFeeInfo();
            BFI = Public_Variables.GetBrokerFeeData(chkBrokerFees, txtBrokerFeeRate);

            ReprocessingStation = new ReprocessingPlant(ReprocessingFacility.GetFacility(ProductionType.Reprocessing), SettingsVariables.UserApplicationSettings.RefiningImplantValue);

            // Make sure to refine ice
            ReprocessingStation.GetFacilility().MaterialMultiplier = ReprocessingStation.GetFacilility().IceFacilityRefineRate;
            // Update the label to show the base refine bonus with rigs
            ReprocessingFacility.UpdateRefineYieldLabel(ReprocessingStation.GetFacilility().IceFacilityRefineRate);

            // Just work with the ones that are checked
            checkedItems = lstIce.CheckedItems;

            if (checkedItems.Count > 0)
            {
                // Update each item based on inputs
                foreach (ListViewItem item in checkedItems)
                {
                    IceName = item.SubItems[1].Text;
                    SQL = "SELECT typeID from INVENTORY_TYPES WHERE typeName = '" + IceName + "'";

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerBelts = Public_Variables.DBCommand.ExecuteReader();

                    if (readerBelts.Read())
                    {
                        // Refine each ore in the ore list, store refined minerals
                        List<string> argRefinedMineralsList = null;
                        RefinedMaterials = ReprocessingStation.Reprocess(readerBelts.GetInt64(0), Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3385L), Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3389L), Public_Variables.SelectedCharacter.Skills.GetSkillLevel("Ice Processing"), Conversions.ToDouble(item.SubItems[2].Text), chkIncludeTaxes.Checked, BFI, ref OutputNumber, ref SingleRefiningUsage, RefinedMineralsList: ref argRefinedMineralsList);
                        TotalRefiningUsage += SingleRefiningUsage;

                        // Store the refined materials
                        TotalRefinedMinerals.InsertMaterialList(RefinedMaterials.GetMaterialList());
                        // Save the total cost separate so we take into account taxes and fees
                        TotalCost = TotalCost + RefinedMaterials.GetTotalMaterialsCost();

                        // Apply taxes and fees
                        TotalCost = Public_Variables.AdjustPriceforTaxesandFees(TotalCost, chkIncludeTaxes.Checked, Public_Variables.GetBrokerFeeData(chkBrokerFees, txtBrokerFeeRate));

                        // Reset the value of the refined materials
                        TotalRefinedMinerals.ResetTotalValue(TotalCost);

                    }
                    readerBelts.Close();
                    Public_Variables.DBCommand = null;

                }

                // Update the total usage for doing this refining
                ReprocessingFacility.GetSelectedFacility().FacilityUsage = TotalRefiningUsage;

                // Sort the list
                TotalRefinedMinerals.SortMaterialListByQuantity();

                lstIceProducts.BeginUpdate();
                lstIceProducts.Items.Clear();

                // Now that we've refined all the ores, put the minerals into minerals list
                for (int i = 0, loopTo = TotalRefinedMinerals.GetMaterialList().Count - 1; i <= loopTo; i++)
                {
                    lstOreRow = new ListViewItem(TotalRefinedMinerals.GetMaterialList()[i].GetMaterialName());
                    // The remaining columns are subitems
                    lstOreRow.SubItems.Add(Strings.FormatNumber(TotalRefinedMinerals.GetMaterialList()[i].GetQuantity(), 0));
                    lstOreRow.SubItems.Add(Strings.FormatNumber(TotalRefinedMinerals.GetMaterialList()[i].GetTotalCost(), 2));
                    lstIceProducts.Items.Add(lstOreRow);
                }

                lstIceProducts.EndUpdate();

                // Belt Values
                BeltVolume = GetTotalVolume();
                lblTotalBeltVolume.Text = Strings.FormatNumber(BeltVolume, 2);

                TimeToFlip = BeltVolume / (Conversions.ToDouble(lblm3perhrperminer.Text) * Conversions.ToInteger(cmbNumMiners.Text)) * 3600d;
                TimeToFlipPer = BeltVolume / Conversions.ToDouble(lblm3perhrperminer.Text) * 3600d;
                lblTotalHourstoFlip.Text = Public_Variables.FormatIPHTime(TimeToFlip);

                if (chkIPHperMiner.Checked == true)
                {
                    lblBeltIPH.Text = Strings.FormatNumber(BeltTotalValue / (TimeToFlipPer / 3600d), 2);
                }
                else
                {
                    lblBeltIPH.Text = Strings.FormatNumber(BeltTotalValue / (TimeToFlip / 3600d), 2);
                }

                // Refine values
                lblTotalRefineValue.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost(), 2);
                lblTotalRefineVolume.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalVolume(), 2);

                if (chkIPHperMiner.Checked == true)
                {
                    lblRefineIPH.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost() / (TimeToFlipPer / 3600d), 2);
                }
                else
                {
                    lblRefineIPH.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost() / (TimeToFlip / 3600d), 2);
                }
            }

            else
            {
                // Nothing checked so clear
                lstIceProducts.Items.Clear();
            }

            Cursor = Cursors.Default;
            Application.DoEvents();


        }

        private void LoadIceTable()
        {
            string SQL;
            SQLiteDataReader readerBelts;
            ListViewItem lstRow;
            string SpaceRaceIDSQL;
            string LocationID;

            if (!CheckEnteredData())
            {
                Cursor = Cursors.Default;
                Application.DoEvents();
                return;
            }

            BeltTotalValue = 0d;

            SpaceRaceIDSQL = " AND RACE_ID = ";
            if (rbtnAmarr.Checked)
            {
                SpaceRaceIDSQL += "4";
            }
            else if (rbtnCaldari.Checked)
            {
                SpaceRaceIDSQL += "1";
            }
            else if (rbtnGallente.Checked)
            {
                SpaceRaceIDSQL += "8";
            }
            else if (rbtnMinmatar.Checked)
            {
                SpaceRaceIDSQL += "2";
            }

            LocationID = " AND LOCATION_ID =";
            if (rbtnHighsec.Checked)
            {
                LocationID += ((int)IceLocationID.Highsec).ToString();
            }
            else if (rbtnLowsec.Checked)
            {
                LocationID += ((int)IceLocationID.Lowsec).ToString();
            }
            else if (rbtnNullWeak.Checked)
            {
                LocationID += ((int)IceLocationID.NullWeak).ToString();
            }
            else if (rbtnNullStrong.Checked)
            {
                LocationID += ((int)IceLocationID.NullStrong).ToString();
            }

            SQL = "SELECT typeName, AMOUNT, PRICE FROM ICE_BELTS, INVENTORY_TYPES LEFT JOIN ITEM_PRICES_FACT ON ITEM_ID = ICE_ID ";
            SQL += " WHERE ICE_ID = typeID " + SpaceRaceIDSQL + LocationID;
            if (chkCompressIce.Checked)
            {
                SQL += " AND COMPRESSED = 1";
            }
            else
            {
                SQL += " AND COMPRESSED = 0";
            }
            SQL += " ORDER BY typeName";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerBelts = Public_Variables.DBCommand.ExecuteReader();

            lstIce.Items.Clear();
            lstIce.BeginUpdate();

            while (readerBelts.Read())
            {
                lstRow = new ListViewItem("");
                // The remaining columns are subitems
                lstRow.SubItems.Add(readerBelts.GetString(0));
                lstRow.SubItems.Add(Strings.FormatNumber(readerBelts.GetInt32(1), 0));
                lstRow.SubItems.Add(Strings.FormatNumber(readerBelts.GetDouble(2), 2));
                lstRow.Checked = GetIceCheckValue(readerBelts.GetString(0)); // Set Check
                lstIce.Items.Add(lstRow);

                // Save the total value for the belt
                BeltTotalValue += readerBelts.GetDouble(2) * readerBelts.GetInt32(1);
            }

            lstIce.EndUpdate();

            lblTotalBeltValue.Text = Strings.FormatNumber(BeltTotalValue, 2);

            // Refresh this m3/hr/miner =  m3 per cycle / cycletime * 3600
            lblm3perhrperminer.Text = Strings.FormatNumber(Conversions.ToDouble(txtm3perCycle.Text) / Conversions.ToDouble(txtCycleTime.Text) * 3600d, 2);

        }

        // Called from Manufacturing Facility
        public void RefreshGrids()
        {
            LoadIceTable();
            RefineIce();
        }

        // Set ice checks by the type of ice
        private bool GetIceCheckValue(string IceName)
        {
            var Settings = SettingsVariables.UserIceBeltCheckSettings;
            var ReturnValue = default(bool);

            switch (IceName ?? "")
            {
                case "Blue Ice":
                    {
                        ReturnValue = Settings.BlueIce;
                        break;
                    }
                case "Clear Icicle":
                    {
                        ReturnValue = Settings.ClearIcicle;
                        break;
                    }
                case "Dark Glitter":
                    {
                        ReturnValue = Settings.DarkGlitter;
                        break;
                    }
                case "Enriched Clear Icicle":
                    {
                        ReturnValue = Settings.EnrichedClearIcicle;
                        break;
                    }
                case "Gelidus":
                    {
                        ReturnValue = Settings.Gelidus;
                        break;
                    }
                case "Glacial Mass":
                    {
                        ReturnValue = Settings.GlacialMass;
                        break;
                    }
                case "Glare Crust":
                    {
                        ReturnValue = Settings.GlareCrust;
                        break;
                    }
                case "Krystallos":
                    {
                        ReturnValue = Settings.Krystallos;
                        break;
                    }
                case "Pristine White Glaze":
                    {
                        ReturnValue = Settings.PristineWhiteGlaze;
                        break;
                    }
                case "Smooth Glacial Mass":
                    {
                        ReturnValue = Settings.SmoothGlacialMass;
                        break;
                    }
                case "Thick Blue Ice":
                    {
                        ReturnValue = Settings.ThickBlueIce;
                        break;
                    }
                case "White Glaze":
                    {
                        ReturnValue = Settings.CompressedWhiteGlaze;
                        break;
                    }
                case "Compressed Blue Ice":
                    {
                        ReturnValue = Settings.CompressedBlueIce;
                        break;
                    }
                case "Compressed Clear Icicle":
                    {
                        ReturnValue = Settings.CompressedClearIcicle;
                        break;
                    }
                case "Compressed Dark Glitter":
                    {
                        ReturnValue = Settings.CompressedDarkGlitter;
                        break;
                    }
                case "Compressed Enriched Clear Icicle":
                    {
                        ReturnValue = Settings.CompressedEnrichedClearIcicle;
                        break;
                    }
                case "Compressed Gelidus":
                    {
                        ReturnValue = Settings.CompressedGelidus;
                        break;
                    }
                case "Compressed Glacial Mass":
                    {
                        ReturnValue = Settings.CompressedGlacialMass;
                        break;
                    }
                case "Compressed Glare Crust":
                    {
                        ReturnValue = Settings.CompressedGlareCrust;
                        break;
                    }
                case "Compressed Krystallos":
                    {
                        ReturnValue = Settings.CompressedKrystallos;
                        break;
                    }
                case "Compressed Pristine White Glaze":
                    {
                        ReturnValue = Settings.CompressedPristineWhiteGlaze;
                        break;
                    }
                case "Compressed Smooth Glacial Mass":
                    {
                        ReturnValue = Settings.CompressedSmoothGlacialMass;
                        break;
                    }
                case "Compressed Thick Blue Ice":
                    {
                        ReturnValue = Settings.CompressedThickBlueIce;
                        break;
                    }
                case "Compressed White Glaze":
                    {
                        ReturnValue = Settings.CompressedWhiteGlaze;
                        break;
                    }
            }

            return ReturnValue;

        }

        private bool CheckEnteredData()
        {

            if (!string.IsNullOrEmpty(Strings.Trim(cmbNumMiners.Text)))
            {
                if (!Information.IsNumeric(cmbNumMiners.Text))
                {
                    Interaction.MsgBox("Invalid Number of Miners value", Constants.vbExclamation, Application.ProductName);
                    cmbNumMiners.Focus();
                    return false;
                }
            }
            else
            {
                Interaction.MsgBox("Please enter a Number of Miners value", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                return false;
            }

            if (Conversions.ToInteger(cmbNumMiners.Text) > 101)
            {
                Interaction.MsgBox("Maximum miners is 100", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                return false;
            }

            if (Conversions.ToInteger(cmbNumMiners.Text) <= 0)
            {
                Interaction.MsgBox("Number of miners must be greater than 0", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(Strings.Trim(txtCycleTime.Text)))
            {
                if (!Information.IsNumeric(txtCycleTime.Text))
                {
                    Interaction.MsgBox("Invalid Cycle Time value", Constants.vbExclamation, Application.ProductName);
                    txtCycleTime.Focus();
                    return false;
                }
            }
            else
            {
                Interaction.MsgBox("Please enter a Cycle Time value", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                return false;
            }

            if (Conversions.ToDouble(txtCycleTime.Text) <= 0d)
            {
                Interaction.MsgBox("Cycle time must be greater than 0", Constants.vbExclamation, Application.ProductName);
                txtm3perCycle.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(Strings.Trim(txtm3perCycle.Text)))
            {
                if (!Information.IsNumeric(txtm3perCycle.Text))
                {
                    Interaction.MsgBox("Invalid m3 per Cycle value", Constants.vbExclamation, Application.ProductName);
                    txtm3perCycle.Focus();
                    return false;
                }
            }
            else
            {
                Interaction.MsgBox("Please enter a m3 per Cycle value", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                return false;
            }

            if (Conversions.ToDouble(txtm3perCycle.Text) <= 0d)
            {
                Interaction.MsgBox("m3 per Cycle value must be greater than 0", Constants.vbExclamation, Application.ProductName);
                txtm3perCycle.Focus();
            }

            return true;

        }

        // Returns the total volume compressed or regular for the belt sent
        private double GetTotalVolume()
        {
            string SQL = "";
            SQLiteDataReader readerBelts;
            ListView.CheckedListViewItemCollection checkedItems;
            string IceName;
            long IceUnits;
            double IceVolume;
            double TotalIceVolume = 0d;

            // Just work with the ones that are checked
            checkedItems = lstIce.CheckedItems;

            if (checkedItems.Count > 0)
            {
                // For each row of Ice, look up the volume and total
                foreach (ListViewItem item in checkedItems)
                {

                    IceName = item.SubItems[1].Text;
                    IceUnits = Conversions.ToInteger(item.SubItems[2].Text);

                    SQL = "SELECT ORE_VOLUME FROM ORES WHERE BELT_TYPE = 'Ice' ";
                    SQL += "AND ORE_NAME = '" + IceName + "'";
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerBelts = Public_Variables.DBCommand.ExecuteReader();

                    if (readerBelts.Read())
                    {
                        // Get all the base values
                        IceVolume = readerBelts.GetDouble(0);
                    }
                    else
                    {
                        return 0d;
                    }

                    readerBelts.Close();

                    TotalIceVolume = TotalIceVolume + IceVolume * IceUnits;

                }

            }

            return TotalIceVolume;

        }

        #region Object Processing

        private void cmbNumMiners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                RefreshGrids();
            }
        }

        private void TextBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Tab & !FirstLoad)
            {
                RefreshGrids();
            }
        }

        private void Text_LostFocus(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                RefreshGrids();
            }
        }

        private void listIce_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstIce;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref IceColumnClicked, ref IceColumnSortOrder);
            lstIce = argRefListView;
        }

        private void lstIceProducts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstIceProducts;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ProductColumnClicked, ref ProductColumnSortOrder);
            lstIceProducts = argRefListView;
        }

        private void listIce_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView s = (ListView)sender;

            if (!FirstLoad & s.ContainsFocus)
            {
                RefineIce();
            }
        }

        private void btnCloseSmall_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnRefine_Click(object sender, EventArgs e)
        {
            RefineIce();
        }

        private void rbtnCheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & ((RadioButton)sender).Checked == true)
            {
                RefreshGrids();
            }
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                RefreshGrids();
            }
        }

        private void chkBrokerFees_Click(object sender, EventArgs e)
        {
            if (chkBrokerFees.Checked & chkBrokerFees.CheckState == CheckState.Indeterminate) // Show rate box
            {
                txtBrokerFeeRate.Visible = true;
            }
            else
            {
                txtBrokerFeeRate.Visible = false;
            }
        }

        private void txtBrokerFeeRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBrokerFeeRate.Text = Public_Variables.GetFormattedPercentEntry(txtBrokerFeeRate);
            }
        }

        private void txtBrokerFeeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers, decimal, percent or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPercentChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void txtBrokerFeeRate_GotFocus(object sender, EventArgs e)
        {
            txtBrokerFeeRate.SelectAll();
        }

        private void txtBrokerFeeRate_LostFocus(object sender, EventArgs e)
        {
            txtBrokerFeeRate.Text = Public_Variables.GetFormattedPercentEntry(txtBrokerFeeRate);
        }

        private void frmIceBeltFlip_Disposed(object sender, EventArgs e)
        {
            Public_Variables.IceBeltFlipOpen = false;
        }

        #endregion

    }
}