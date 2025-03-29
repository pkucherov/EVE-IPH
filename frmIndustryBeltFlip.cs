using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmIndustryBeltFlip
    {

        private int Ore1ColumnClicked;
        private SortOrder Ore1ColumnSortOrder;
        private int Mineral1ColumnClicked;
        private SortOrder Mineral1ColumnSortOrder;
        private int Ore2ColumnClicked;
        private SortOrder Ore2ColumnSortOrder;
        private int Mineral2ColumnClicked;
        private SortOrder Mineral2ColumnSortOrder;
        private int Ore3ColumnClicked;
        private SortOrder Ore3ColumnSortOrder;
        private int Mineral3ColumnClicked;
        private SortOrder Mineral3ColumnSortOrder;
        private int Ore4ColumnClicked;
        private SortOrder Ore4ColumnSortOrder;
        private int Mineral4ColumnClicked;
        private SortOrder Mineral4ColumnSortOrder;
        private int Ore5ColumnClicked;
        private SortOrder Ore5ColumnSortOrder;
        private int Mineral5ColumnClicked;
        private SortOrder Mineral5ColumnSortOrder;

        private bool FirstLoad;

        private Public_Variables.BrokerFeeInfo BFI = new Public_Variables.BrokerFeeInfo();
        private ReprocessingPlant ReprocessingStation;

        public frmIndustryBeltFlip()
        {

            FirstLoad = true;
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            LoadSettings();

            InitializeReprocessingFacility();

            Ore1ColumnClicked = 0;
            Ore1ColumnSortOrder = SortOrder.None;
            Mineral1ColumnClicked = 0;
            Mineral1ColumnSortOrder = SortOrder.None;
            Ore2ColumnClicked = 0;
            Ore2ColumnSortOrder = SortOrder.None;
            Mineral2ColumnClicked = 0;
            Mineral2ColumnSortOrder = SortOrder.None;
            Ore3ColumnClicked = 0;
            Ore3ColumnSortOrder = SortOrder.None;
            Mineral3ColumnClicked = 0;
            Mineral3ColumnSortOrder = SortOrder.None;
            Ore4ColumnClicked = 0;
            Ore4ColumnSortOrder = SortOrder.None;
            Mineral4ColumnClicked = 0;
            Mineral4ColumnSortOrder = SortOrder.None;
            Ore5ColumnClicked = 0;
            Ore5ColumnSortOrder = SortOrder.None;
            Mineral5ColumnClicked = 0;
            Mineral5ColumnSortOrder = SortOrder.None;

        }

        public void InitializeReprocessingFacility()
        {
            // Load the mining tab refinery
            Form argControlForm = this;
            ReprocessingFacility.InitializeControl(Public_Variables.SelectedCharacter.ID, ProgramLocation.SovBelts, ProductionType.Reprocessing, ref argControlForm);
        }

        private void frmIndustryBeltFlip_Shown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            LoadAllTables();

            Cursor = Cursors.Default;
            FirstLoad = false;

        }

        private void LoadSettings()
        {

            // Miner settings
            txtCycleTime.Text = Strings.FormatNumber(SettingsVariables.UserIndustryFlipBeltSettings.CycleTime);
            txtm3perCycle.Text = Strings.FormatNumber(SettingsVariables.UserIndustryFlipBeltSettings.m3perCycle);
            cmbNumMiners.Text = SettingsVariables.UserIndustryFlipBeltSettings.NumMiners.ToString();
            chkCompressOre.Checked = SettingsVariables.UserIndustryFlipBeltSettings.CompressOre;
            chkIPHperMiner.Checked = SettingsVariables.UserIndustryFlipBeltSettings.IPHperMiner;

            if (string.IsNullOrEmpty(SettingsVariables.UserIndustryFlipBeltSettings.TrueSec) | (SettingsVariables.UserIndustryFlipBeltSettings.TrueSec ?? "") == (rbtn0percent.Text ?? ""))
            {
                rbtn0percent.Checked = true;
            }
            else if ((SettingsVariables.UserIndustryFlipBeltSettings.TrueSec ?? "") == (rbtn5percent.Text ?? ""))
            {
                rbtn5percent.Checked = true;
            }
            else if ((SettingsVariables.UserIndustryFlipBeltSettings.TrueSec ?? "") == (rbtn10percent.Text ?? ""))
            {
                rbtn10percent.Checked = true;
            }

            // m3/hr/miner =  m3 per cycle / cycletime * 3600
            lblm3perhrperminer.Text = Strings.FormatNumber(Conversions.ToDouble(txtm3perCycle.Text) / Conversions.ToDouble(txtCycleTime.Text) * 3600d, 2);

            // Tax settings
            switch (SettingsVariables.UserIndustryFlipBeltSettings.IncludeBrokerFees)
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
            chkIncludeTaxes.Checked = SettingsVariables.UserIndustryFlipBeltSettings.IncludeTaxes;
            txtBrokerFeeRate.Text = Strings.FormatPercent(SettingsVariables.UserIndustryFlipBeltSettings.BrokerFeeRate, 1);

            if (SettingsVariables.UserApplicationSettings.ShowToolTips)
            {
                ttMain.SetToolTip(rbtn0percent, "No Bonus Ores");
                ttMain.SetToolTip(rbtn5percent, "5% Ore Variants in Large, Enormous, or Colossal Belts");
                ttMain.SetToolTip(rbtn10percent, "10% Ore Variants in Large, Enormous, or Colossal Belts");
            }

        }

        private bool CheckEnteredData()
        {

            if (!string.IsNullOrEmpty(Strings.Trim(cmbNumMiners.Text)))
            {
                if (!Information.IsNumeric(cmbNumMiners.Text))
                {
                    Interaction.MsgBox("Invalid Number of Miners value", Constants.vbExclamation, Application.ProductName);
                    cmbNumMiners.Focus();
                    tabIndustryBelts.SelectedTab = tabSummary;
                    return false;
                }
            }
            else
            {
                Interaction.MsgBox("Please enter a Number of Miners value", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                tabIndustryBelts.SelectedTab = tabSummary;
                return false;
            }

            if (Conversions.ToInteger(cmbNumMiners.Text) > 101)
            {
                Interaction.MsgBox("Maximum miners is 100", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                tabIndustryBelts.SelectedTab = tabSummary;
                return false;
            }

            if (Conversions.ToInteger(cmbNumMiners.Text) <= 0)
            {
                Interaction.MsgBox("Number of miners must be greater than 0", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                tabIndustryBelts.SelectedTab = tabSummary;
                return false;
            }

            if (!string.IsNullOrEmpty(Strings.Trim(txtCycleTime.Text)))
            {
                if (!Information.IsNumeric(txtCycleTime.Text))
                {
                    Interaction.MsgBox("Invalid Cycle Time value", Constants.vbExclamation, Application.ProductName);
                    txtCycleTime.Focus();
                    tabIndustryBelts.SelectedTab = tabSummary;
                    return false;
                }
            }
            else
            {
                Interaction.MsgBox("Please enter a Cycle Time value", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                tabIndustryBelts.SelectedTab = tabSummary;
                return false;
            }

            if (Conversions.ToDouble(txtCycleTime.Text) <= 0d)
            {
                Interaction.MsgBox("Cycle time must be greater than 0", Constants.vbExclamation, Application.ProductName);
                txtm3perCycle.Focus();
                tabIndustryBelts.SelectedTab = tabSummary;
                return false;
            }

            if (!string.IsNullOrEmpty(Strings.Trim(txtm3perCycle.Text)))
            {
                if (!Information.IsNumeric(txtm3perCycle.Text))
                {
                    Interaction.MsgBox("Invalid m3 per Cycle value", Constants.vbExclamation, Application.ProductName);
                    txtm3perCycle.Focus();
                    tabIndustryBelts.SelectedTab = tabSummary;
                    return false;
                }
            }
            else
            {
                Interaction.MsgBox("Please enter a m3 per Cycle value", Constants.vbExclamation, Application.ProductName);
                cmbNumMiners.Focus();
                tabIndustryBelts.SelectedTab = tabSummary;
                return false;
            }

            if (Conversions.ToDouble(txtm3perCycle.Text) <= 0d)
            {
                Interaction.MsgBox("m3 per Cycle value must be greater than 0", Constants.vbExclamation, Application.ProductName);
                txtm3perCycle.Focus();
                tabIndustryBelts.SelectedTab = tabSummary;
                return false;
            }

            return true;

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            IndustryFlipBeltSettings TempSettings = default;
            var Settings = new ProgramSettings();

            if (!CheckEnteredData())
            {
                return;
            }

            TempSettings.CompressOre = chkCompressOre.Checked;
            TempSettings.IPHperMiner = chkIPHperMiner.Checked;
            TempSettings.CycleTime = Conversions.ToDouble(txtCycleTime.Text);
            TempSettings.m3perCycle = Conversions.ToDouble(txtm3perCycle.Text);
            TempSettings.NumMiners = Conversions.ToInteger(cmbNumMiners.Text);

            TempSettings.IncludeTaxes = chkIncludeTaxes.Checked;
            TempSettings.IncludeBrokerFees = (int)chkBrokerFees.CheckState;
            TempSettings.BrokerFeeRate = Public_Variables.FormatManualPercentEntry(txtBrokerFeeRate.Text);

            if (rbtn0percent.Checked)
            {
                TempSettings.TrueSec = rbtn0percent.Text;
            }
            else if (rbtn5percent.Checked)
            {
                TempSettings.TrueSec = rbtn5percent.Text;
            }
            else if (rbtn10percent.Checked)
            {
                TempSettings.TrueSec = rbtn10percent.Text;
            }

            // Save it in the Application settings
            Settings.SaveApplicationSettings(SettingsVariables.UserApplicationSettings);

            // Save the data in the XML file
            Settings.SaveIndustryFlipBeltSettings(TempSettings);

            // Save the data to the local variable
            SettingsVariables.UserIndustryFlipBeltSettings = TempSettings;

            // Refresh tables
            LoadAllTables();

            Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllTables();
        }

        public void LoadAllTables()
        {

            FirstLoad = true;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            if (!CheckEnteredData())
            {
                FirstLoad = false;
                Cursor = Cursors.Default;
                Application.DoEvents();
                return;
            }

            BFI = Public_Variables.GetBrokerFeeData(chkBrokerFees, txtBrokerFeeRate);

            ReprocessingStation = new ReprocessingPlant(ReprocessingFacility.GetFacility(ProductionType.Reprocessing), SettingsVariables.UserApplicationSettings.RefiningImplantValue);

            // Make sure to refine ore
            ReprocessingStation.GetFacilility().MaterialMultiplier = ReprocessingStation.GetFacilility().OreFacilityRefineRate;
            // Update the label to show the base refine bonus with rigs
            ReprocessingFacility.UpdateRefineYieldLabel(ReprocessingStation.GetFacilility().OreFacilityRefineRate);

            // Calc the m3 per hr per miner first
            // m3/hr/miner =  m3 per cycle / cycletime * 3600
            lblm3perhrperminer.Text = Strings.FormatNumber(Conversions.ToDouble(txtm3perCycle.Text) / Conversions.ToDouble(txtCycleTime.Text) * 3600d, 2);

            // Small
            LoadBeltTable(Public_Variables.BeltType.Small);
            DisplayBeltMinerals(Public_Variables.BeltType.Small);

            // Moderate
            LoadBeltTable(Public_Variables.BeltType.Medium);
            DisplayBeltMinerals(Public_Variables.BeltType.Medium);

            // Large
            LoadBeltTable(Public_Variables.BeltType.Large);
            DisplayBeltMinerals(Public_Variables.BeltType.Large);

            // Extra Large
            LoadBeltTable(Public_Variables.BeltType.Enormous);
            DisplayBeltMinerals(Public_Variables.BeltType.Enormous);

            // Giant
            LoadBeltTable(Public_Variables.BeltType.Colossal);
            DisplayBeltMinerals(Public_Variables.BeltType.Colossal);

            FirstLoad = false;
            Cursor = Cursors.Default;
            Application.DoEvents();

        }

        private void LoadBeltTable(Public_Variables.BeltType Belt)
        {
            string SQL;
            SQLiteDataReader readerBelts;
            ListViewItem lstOreRow;
            ListView CurrentList = null;

            if (!CheckEnteredData())
            {
                Cursor = Cursors.Default;
                Application.DoEvents();
                return;
            }

            SQL = "SELECT ORE, AMOUNT, NUMBER_ASTEROIDS FROM INDUSTRY_UPGRADE_BELTS ";
            SQL += "WHERE ( BELT_NAME = ";

            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        SQL += "'Small' ";
                        CurrentList = lstOresLevel1;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        SQL += "'Medium' ";
                        CurrentList = lstOresLevel2;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        SQL += "'Large' ";
                        CurrentList = lstOresLevel3;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        SQL += "'Enormous' ";
                        CurrentList = lstOresLevel4;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        SQL += "'Colossal' ";
                        CurrentList = lstOresLevel5;
                        break;
                    }
            }

            SQL += ") ";

            // Select ore type based on truesec bonus
            if (rbtn0percent.Checked | Belt == Public_Variables.BeltType.Small | Belt == Public_Variables.BeltType.Medium) // Small and Medium belts are always base ores
            {
                SQL += "AND TRUESEC_BONUS = 0 ";
            }
            else if (rbtn5percent.Checked)
            {
                SQL += "AND TRUESEC_BONUS = 5 ";
            }
            else if (rbtn10percent.Checked)
            {
                SQL += "AND TRUESEC_BONUS = 10 ";
            }

            SQL += "ORDER BY ORE";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerBelts = Public_Variables.DBCommand.ExecuteReader();

            CurrentList.Items.Clear();
            CurrentList.BeginUpdate();

            while (readerBelts.Read())
            {
                lstOreRow = new ListViewItem("");
                // The remaining columns are subitems
                lstOreRow.SubItems.Add(readerBelts.GetString(0));
                lstOreRow.SubItems.Add(readerBelts.GetInt32(2).ToString());
                lstOreRow.SubItems.Add(Strings.FormatNumber(readerBelts.GetInt32(1), 0));

                // All records are initially checked
                lstOreRow.Checked = GetOreCheckValue(readerBelts.GetString(0), Belt);
                CurrentList.Items.Add(lstOreRow);
            }

            CurrentList.EndUpdate();

        }

        // Set ore checks by the type of belt sent and ore
        private bool GetOreCheckValue(string OreName, Public_Variables.BeltType Belt)
        {
            var Settings = default(IndustryBeltOreChecks);
            var ReturnValue = default(bool);

            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        Settings = SettingsVariables.UserIndustryFlipBeltOreCheckSettings1;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        Settings = SettingsVariables.UserIndustryFlipBeltOreCheckSettings2;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        Settings = SettingsVariables.UserIndustryFlipBeltOreCheckSettings3;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        Settings = SettingsVariables.UserIndustryFlipBeltOreCheckSettings4;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        Settings = SettingsVariables.UserIndustryFlipBeltOreCheckSettings5;
                        break;
                    }
            }

            switch (OreName ?? "")
            {
                case "Plagioclase":
                    {
                        ReturnValue = Settings.Plagioclase;
                        break;
                    }
                case "Spodumain":
                    {
                        ReturnValue = Settings.Spodumain;
                        break;
                    }
                case "Kernite":
                    {
                        ReturnValue = Settings.Kernite;
                        break;
                    }
                case "Hedbergite":
                    {
                        ReturnValue = Settings.Hedbergite;
                        break;
                    }
                case "Arkonor":
                    {
                        ReturnValue = Settings.Arkonor;
                        break;
                    }
                case "Bistot":
                    {
                        ReturnValue = Settings.Bistot;
                        break;
                    }
                case "Pyroxeres":
                    {
                        ReturnValue = Settings.Pyroxeres;
                        break;
                    }
                case "Crokite":
                    {
                        ReturnValue = Settings.Crokite;
                        break;
                    }
                case "Jaspet":
                    {
                        ReturnValue = Settings.Jaspet;
                        break;
                    }
                case "Omber":
                    {
                        ReturnValue = Settings.Omber;
                        break;
                    }
                case "Scordite":
                    {
                        ReturnValue = Settings.Scordite;
                        break;
                    }
                case "Gneiss":
                    {
                        ReturnValue = Settings.Gneiss;
                        break;
                    }
                case "Veldspar":
                    {
                        ReturnValue = Settings.Veldspar;
                        break;
                    }
                case "Hemorphite":
                    {
                        ReturnValue = Settings.Hemorphite;
                        break;
                    }
                case "Dark Ochre":
                    {
                        ReturnValue = Settings.DarkOchre;
                        break;
                    }
                case "Mercoxit":
                    {
                        ReturnValue = Settings.Mercoxit;
                        break;
                    }
                case "Crimson Arkonor":
                    {
                        ReturnValue = Settings.CrimsonArkonor;
                        break;
                    }
                case "Prime Arkonor":
                    {
                        ReturnValue = Settings.PrimeArkonor;
                        break;
                    }
                case "Triclinic Bistot":
                    {
                        ReturnValue = Settings.TriclinicBistot;
                        break;
                    }
                case "Monoclinic Bistot":
                    {
                        ReturnValue = Settings.MonoclinicBistot;
                        break;
                    }
                case "Sharp Crokite":
                    {
                        ReturnValue = Settings.SharpCrokite;
                        break;
                    }
                case "Crystalline Crokite":
                    {
                        ReturnValue = Settings.CrystallineCrokite;
                        break;
                    }
                case "Onyx Ochre":
                    {
                        ReturnValue = Settings.OnyxOchre;
                        break;
                    }
                case "Obsidian Ochre":
                    {
                        ReturnValue = Settings.ObsidianOchre;
                        break;
                    }
                case "Vitric Hedbergite":
                    {
                        ReturnValue = Settings.VitricHedbergite;
                        break;
                    }
                case "Glazed Hedbergite":
                    {
                        ReturnValue = Settings.GlazedHedbergite;
                        break;
                    }
                case "Vivid Hemorphite":
                    {
                        ReturnValue = Settings.VividHemorphite;
                        break;
                    }
                case "Radiant Hemorphite":
                    {
                        ReturnValue = Settings.RadiantHemorphite;
                        break;
                    }
                case "Pure Jaspet":
                    {
                        ReturnValue = Settings.PureJaspet;
                        break;
                    }
                case "Pristine Jaspet":
                    {
                        ReturnValue = Settings.PristineJaspet;
                        break;
                    }
                case "Luminous Kernite":
                    {
                        ReturnValue = Settings.LuminousKernite;
                        break;
                    }
                case "Fiery Kernite":
                    {
                        ReturnValue = Settings.FieryKernite;
                        break;
                    }
                case "Azure Plagioclase":
                    {
                        ReturnValue = Settings.AzurePlagioclase;
                        break;
                    }
                case "Rich Plagioclase":
                    {
                        ReturnValue = Settings.RichPlagioclase;
                        break;
                    }
                case "Solid Pyroxeres":
                    {
                        ReturnValue = Settings.SolidPyroxeres;
                        break;
                    }
                case "Viscous Pyroxeres":
                    {
                        ReturnValue = Settings.ViscousPyroxeres;
                        break;
                    }
                case "Condensed Scordite":
                    {
                        ReturnValue = Settings.CondensedScordite;
                        break;
                    }
                case "Massive Scordite":
                    {
                        ReturnValue = Settings.MassiveScordite;
                        break;
                    }
                case "Bright Spodumain":
                    {
                        ReturnValue = Settings.BrightSpodumain;
                        break;
                    }
                case "Gleaming Spodumain":
                    {
                        ReturnValue = Settings.GleamingSpodumain;
                        break;
                    }
                case "Concentrated Veldspar":
                    {
                        ReturnValue = Settings.ConcentratedVeldspar;
                        break;
                    }
                case "Dense Veldspar":
                    {
                        ReturnValue = Settings.DenseVeldspar;
                        break;
                    }
                case "Iridescent Gneiss":
                    {
                        ReturnValue = Settings.IridescentGneiss;
                        break;
                    }
                case "Prismatic Gneiss":
                    {
                        ReturnValue = Settings.PrismaticGneiss;
                        break;
                    }
                case "Silvery Omber":
                    {
                        ReturnValue = Settings.SilveryOmber;
                        break;
                    }
                case "Golden Omber":
                    {
                        ReturnValue = Settings.GoldenOmber;
                        break;
                    }
                case "Magma Mercoxit":
                    {
                        ReturnValue = Settings.MagmaMercoxit;
                        break;
                    }
                case "Vitreous Mercoxit":
                    {
                        ReturnValue = Settings.VitreousMercoxit;
                        break;
                    }
            }

            return ReturnValue;

        }

        // Refines the belt sent and loads the appropriate table
        private void DisplayBeltMinerals(Public_Variables.BeltType Belt)
        {
            string SQL = "";
            SQLiteDataReader readerBelts;
            ListViewItem lstOreRow = null;
            ListView CurrentOreList = null;
            ListView CurrentMineralList = null;

            Label TotalIskLabelForm = null;
            Label HrsToFlipForm = null;
            Label IPHForm = null;
            Label TotalVolumeForm = null;

            Label TotalIskLabelSum = null;
            Label HrsToFlipSum = null;
            Label IPHSum = null;
            Label TotalVolumeSum = null;
            ListView.CheckedListViewItemCollection checkedItems;
            var TotalRefinedMinerals = new Materials();
            double TotalCost = 0d;
            var OutputNumber = default(double);
            string OreName;

            double BeltVolume;
            double CompressedVolume;
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

            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        SQL += "'Small' ";
                        CurrentOreList = lstOresLevel1;
                        CurrentMineralList = lstMineralsLevel1;

                        TotalIskLabelForm = lblTotalIskLevel1;
                        HrsToFlipForm = lblTotalHourstoFlip1;
                        IPHForm = lblIPH1;
                        TotalVolumeForm = lblTotalBeltVolume1;

                        TotalIskLabelSum = lblTotalIskLevel1Sum;
                        HrsToFlipSum = lblTotalHourstoFlip1Sum;
                        IPHSum = lblTotalIPH1Sum;
                        TotalVolumeSum = lblTotalBeltVolume1Sum;
                        break;
                    }

                case Public_Variables.BeltType.Medium:
                    {
                        SQL += "'Medium' ";
                        CurrentOreList = lstOresLevel2;
                        CurrentMineralList = lstMineralsLevel2;

                        TotalIskLabelForm = lblTotalIskLevel2;
                        HrsToFlipForm = lblTotalHourstoFlip2;
                        IPHForm = lblIPH2;
                        TotalVolumeForm = lblTotalBeltVolume2;

                        TotalIskLabelSum = lblTotalIskLevel2Sum;
                        HrsToFlipSum = lblTotalHourstoFlip2Sum;
                        IPHSum = lblTotalIPH2Sum;
                        TotalVolumeSum = lblTotalBeltVolume2Sum;
                        break;
                    }

                case Public_Variables.BeltType.Large:
                    {
                        SQL += "'Large' ";
                        CurrentOreList = lstOresLevel3;
                        CurrentMineralList = lstMineralsLevel3;

                        TotalIskLabelForm = lblTotalIskLevel3;
                        HrsToFlipForm = lblTotalHourstoFlip3;
                        IPHForm = lblIPH3;
                        TotalVolumeForm = lblTotalBeltVolume3;

                        TotalIskLabelSum = lblTotalIskLevel3Sum;
                        HrsToFlipSum = lblTotalHourstoFlip3Sum;
                        IPHSum = lblTotalIPH3Sum;
                        TotalVolumeSum = lblTotalBeltVolume3Sum;
                        break;
                    }

                case Public_Variables.BeltType.Enormous:
                    {
                        SQL += "'Extra Large' ";
                        CurrentOreList = lstOresLevel4;
                        CurrentMineralList = lstMineralsLevel4;

                        TotalIskLabelForm = lblTotalIskLevel4;
                        HrsToFlipForm = lblTotalHourstoFlip4;
                        IPHForm = lblIPH4;
                        TotalVolumeForm = lblTotalBeltVolume4;

                        TotalIskLabelSum = lblTotalIskLevel4Sum;
                        HrsToFlipSum = lblTotalHourstoFlip4Sum;
                        IPHSum = lblTotalIPH4Sum;
                        TotalVolumeSum = lblTotalBeltVolume4Sum;
                        break;
                    }

                case Public_Variables.BeltType.Colossal:
                    {
                        SQL += "'Giant' ";
                        CurrentOreList = lstOresLevel5;
                        CurrentMineralList = lstMineralsLevel5;

                        TotalIskLabelForm = lblTotalIskLevel5;
                        HrsToFlipForm = lblTotalHourstoFlip5;
                        IPHForm = lblIPH5;
                        TotalVolumeForm = lblTotalBeltVolume5;

                        TotalIskLabelSum = lblTotalIskLevel5Sum;
                        HrsToFlipSum = lblTotalHourstoFlip5Sum;
                        IPHSum = lblTotalIPH5Sum;
                        TotalVolumeSum = lblTotalBeltVolume5Sum;
                        break;
                    }

            }

            // Just work with the ones that are checked
            checkedItems = CurrentOreList.CheckedItems;

            if (checkedItems.Count > 0)
            {
                // Update each item based on inputs
                foreach (ListViewItem item in checkedItems)
                {
                    OreName = item.SubItems[1].Text;
                    SQL = "SELECT typeID from INVENTORY_TYPES WHERE typeName = '" + OreName + "'";

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerBelts = Public_Variables.DBCommand.ExecuteReader();

                    if (readerBelts.Read())
                    {
                        // Refine each ore in the ore list, store refined minerals
                        List<string> argRefinedMineralsList = null;
                        RefinedMaterials = ReprocessingStation.Reprocess(readerBelts.GetInt64(0), Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3385L), Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3389L), Public_Variables.SelectedCharacter.Skills.GetSkillLevel(OreName + " Processing"), Conversions.ToDouble(item.SubItems[3].Text), chkIncludeTaxes.Checked, BFI, ref OutputNumber, ref SingleRefiningUsage, RefinedMineralsList: ref argRefinedMineralsList);
                        TotalRefiningUsage += SingleRefiningUsage;

                        // Store the refined materials
                        TotalRefinedMinerals.InsertMaterialList(RefinedMaterials.GetMaterialList());

                        if (chkCompressOre.Checked == false)
                        {
                            // Save the total cost separate so we take into account taxes and fees
                            TotalCost = TotalCost + RefinedMaterials.GetTotalMaterialsCost();
                        }
                        else
                        {
                            SQLiteDataReader readerOre;
                            double OreUnitPrice;
                            int TotalCompressedUnits;

                            // First, get the unit price and volume for the compressed ore
                            SQL = "SELECT PRICE FROM ITEM_PRICES WHERE ITEM_NAME LIKE 'Compressed " + OreName + "'";
                            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                            readerOre = Public_Variables.DBCommand.ExecuteReader();

                            if (readerOre.Read())
                            {
                                OreUnitPrice = readerOre.GetDouble(0);
                                TotalCompressedUnits = (int)Math.Round(Math.Floor(Conversions.ToInteger(item.SubItems[3].Text) / 100d));
                                // Calc total cost, assume all mined and then compressed
                                TotalCost = TotalCost + OreUnitPrice * TotalCompressedUnits;
                            }

                            readerOre.Close();

                        }

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

                CurrentMineralList.BeginUpdate();
                CurrentMineralList.Items.Clear();

                // Now that we've refined all the ores, put the minerals into minerals list
                for (int i = 0, loopTo = TotalRefinedMinerals.GetMaterialList().Count - 1; i <= loopTo; i++)
                {
                    lstOreRow = new ListViewItem(TotalRefinedMinerals.GetMaterialList()[i].GetMaterialName());
                    // The remaining columns are subitems
                    lstOreRow.SubItems.Add(Strings.FormatNumber(TotalRefinedMinerals.GetMaterialList()[i].GetQuantity(), 0));
                    lstOreRow.SubItems.Add(Strings.FormatNumber(TotalRefinedMinerals.GetMaterialList()[i].GetTotalCost(), 2));
                    CurrentMineralList.Items.Add(lstOreRow);
                }

                CurrentMineralList.EndUpdate();

                TotalIskLabelForm.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost(), 2) + " ISK";
                TotalIskLabelSum.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost(), 2) + " ISK";

                CompressedVolume = GetTotalVolume(Belt, chkCompressOre.Checked);
                BeltVolume = GetTotalVolume(Belt, false);

                TotalVolumeSum.Text = Strings.FormatNumber(CompressedVolume, 2);
                TotalVolumeForm.Text = Strings.FormatNumber(CompressedVolume, 2);

                TimeToFlip = BeltVolume / (Conversions.ToDouble(lblm3perhrperminer.Text) * Conversions.ToInteger(cmbNumMiners.Text)) * 3600d;
                TimeToFlipPer = BeltVolume / Conversions.ToDouble(lblm3perhrperminer.Text) * 3600d;

                HrsToFlipForm.Text = Public_Variables.FormatIPHTime(TimeToFlip);
                HrsToFlipSum.Text = Public_Variables.FormatIPHTime(TimeToFlip);

                if (chkIPHperMiner.Checked == true)
                {
                    IPHForm.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost() / (TimeToFlipPer / 3600d), 2);
                    IPHSum.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost() / (TimeToFlipPer / 3600d), 2);
                }
                else
                {
                    IPHForm.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost() / (TimeToFlip / 3600d), 2);
                    IPHSum.Text = Strings.FormatNumber(TotalRefinedMinerals.GetTotalMaterialsCost() / (TimeToFlip / 3600d), 2);
                }
            }

            else
            {
                // Nothing checked so clear
                CurrentMineralList.Items.Clear();
            }

            Cursor = Cursors.Default;
            Application.DoEvents();

        }

        // Returns the total volume compressed or regular for the belt sent
        private double GetTotalVolume(Public_Variables.BeltType Belt, bool Compress)
        {
            string SQL = "";
            SQLiteDataReader readerBelts;
            ListView CurrentOreList = null;
            ListView.CheckedListViewItemCollection checkedItems;
            string OreName;
            long OreUnits;
            double OreVolume;
            var TotalOreVolume = default(double);

            double CompressedBlockVolume;
            var CompressedBlocks = default(long);
            long UnitsToCompress;

            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        CurrentOreList = lstOresLevel1;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        CurrentOreList = lstOresLevel2;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        CurrentOreList = lstOresLevel3;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        CurrentOreList = lstOresLevel4;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        CurrentOreList = lstOresLevel5;
                        break;
                    }
            }

            // Just work with the ones that are checked
            checkedItems = CurrentOreList.CheckedItems;

            if (checkedItems.Count > 0)
            {
                // For each row of ore, look up the volume and compressed volume. Then total volume + leftover amount
                foreach (ListViewItem item in checkedItems)
                {

                    OreName = item.SubItems[1].Text;
                    OreUnits = Conversions.ToInteger(item.SubItems[3].Text);

                    SQL = "SELECT ORE_VOLUME ";
                    SQL += "FROM ORES WHERE BELT_TYPE = 'Ore' ";
                    if (Compress)
                    {
                        SQL += "AND ORE_NAME ='Compressed " + OreName + "'";
                    }
                    else
                    {
                        SQL += "AND ORE_NAME = '" + OreName + "'";
                    }
                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerBelts = Public_Variables.DBCommand.ExecuteReader();

                    if (readerBelts.Read())
                    {
                        // Get all the base values
                        OreVolume = readerBelts.GetDouble(0);
                        UnitsToCompress = 100L; // Always 100 now
                    }
                    else
                    {
                        return 0d;
                    }

                    readerBelts.Close();

                    if (Compress)
                    {
                        // Compressed ORE
                        CompressedBlocks = (long)Math.Round(Math.Floor(OreUnits / (double)UnitsToCompress));
                        CompressedBlockVolume = OreVolume;
                        // Reset the total ore units so we can look up the rest
                        OreUnits = OreUnits - UnitsToCompress * CompressedBlocks;
                    }

                    else // Only use the total ore volume
                    {
                        CompressedBlockVolume = 0d;
                    }

                    TotalOreVolume = TotalOreVolume + CompressedBlockVolume * CompressedBlocks + OreVolume * OreUnits;

                }

            }

            return TotalOreVolume;

        }

        private void SaveSelectedOres(Public_Variables.BeltType Belt)
        {
            IndustryBeltOreChecks TempSettings = default;
            var Settings = new ProgramSettings();
            var SavedSettings = new IndustryBeltOreChecks();
            var OreList = new ListView();

            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        OreList = lstOresLevel1;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        OreList = lstOresLevel2;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        OreList = lstOresLevel3;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        OreList = lstOresLevel4;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        OreList = lstOresLevel5;
                        break;
                    }
            }

            // Reset them all to default settings first if not found
            TempSettings = SettingsVariables.AllSettings.SetDefaultIndustryBeltOreChecksSettings(Belt);

            // Loop through the ore list and save the value
            for (int i = 0, loopTo = OreList.Items.Count - 1; i <= loopTo; i++)
            {
                switch (OreList.Items[i].SubItems[1].Text ?? "")
                {
                    case "Plagioclase":
                        {
                            TempSettings.Plagioclase = OreList.Items[i].Checked;
                            break;
                        }
                    case "Spodumain":
                        {
                            TempSettings.Spodumain = OreList.Items[i].Checked;
                            break;
                        }
                    case "Kernite":
                        {
                            TempSettings.Kernite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Hedbergite":
                        {
                            TempSettings.Hedbergite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Arkonor":
                        {
                            TempSettings.Arkonor = OreList.Items[i].Checked;
                            break;
                        }
                    case "Bistot":
                        {
                            TempSettings.Bistot = OreList.Items[i].Checked;
                            break;
                        }
                    case "Pyroxeres":
                        {
                            TempSettings.Pyroxeres = OreList.Items[i].Checked;
                            break;
                        }
                    case "Crokite":
                        {
                            TempSettings.Crokite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Jaspet":
                        {
                            TempSettings.Jaspet = OreList.Items[i].Checked;
                            break;
                        }
                    case "Omber":
                        {
                            TempSettings.Omber = OreList.Items[i].Checked;
                            break;
                        }
                    case "Scordite":
                        {
                            TempSettings.Scordite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Gneiss":
                        {
                            TempSettings.Gneiss = OreList.Items[i].Checked;
                            break;
                        }
                    case "Veldspar":
                        {
                            TempSettings.Veldspar = OreList.Items[i].Checked;
                            break;
                        }
                    case "Hemorphite":
                        {
                            TempSettings.Hemorphite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Dark Ochre":
                        {
                            TempSettings.DarkOchre = OreList.Items[i].Checked;
                            break;
                        }
                    case "Mercoxit":
                        {
                            TempSettings.Mercoxit = OreList.Items[i].Checked;
                            break;
                        }
                    case "Crimson Arkonor":
                        {
                            TempSettings.CrimsonArkonor = OreList.Items[i].Checked;
                            break;
                        }
                    case "Prime Arkonor":
                        {
                            TempSettings.PrimeArkonor = OreList.Items[i].Checked;
                            break;
                        }
                    case "Triclinic Bistot":
                        {
                            TempSettings.TriclinicBistot = OreList.Items[i].Checked;
                            break;
                        }
                    case "Monoclinic Bistot":
                        {
                            TempSettings.MonoclinicBistot = OreList.Items[i].Checked;
                            break;
                        }
                    case "Sharp Crokite":
                        {
                            TempSettings.SharpCrokite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Crystalline Crokite":
                        {
                            TempSettings.CrystallineCrokite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Onyx Ochre":
                        {
                            TempSettings.OnyxOchre = OreList.Items[i].Checked;
                            break;
                        }
                    case "Obsidian Ochre":
                        {
                            TempSettings.ObsidianOchre = OreList.Items[i].Checked;
                            break;
                        }
                    case "Vitric Hedbergite":
                        {
                            TempSettings.VitricHedbergite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Glazed Hedbergite":
                        {
                            TempSettings.GlazedHedbergite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Vivid Hemorphite":
                        {
                            TempSettings.VividHemorphite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Radiant Hemorphite":
                        {
                            TempSettings.RadiantHemorphite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Pure Jaspet":
                        {
                            TempSettings.PureJaspet = OreList.Items[i].Checked;
                            break;
                        }
                    case "Pristine Jaspet":
                        {
                            TempSettings.PristineJaspet = OreList.Items[i].Checked;
                            break;
                        }
                    case "Luminous Kernite":
                        {
                            TempSettings.LuminousKernite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Fiery Kernite":
                        {
                            TempSettings.FieryKernite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Azure Plagioclase":
                        {
                            TempSettings.AzurePlagioclase = OreList.Items[i].Checked;
                            break;
                        }
                    case "Rich Plagioclase":
                        {
                            TempSettings.RichPlagioclase = OreList.Items[i].Checked;
                            break;
                        }
                    case "Solid Pyroxeres":
                        {
                            TempSettings.SolidPyroxeres = OreList.Items[i].Checked;
                            break;
                        }
                    case "Viscous Pyroxeres":
                        {
                            TempSettings.ViscousPyroxeres = OreList.Items[i].Checked;
                            break;
                        }
                    case "Condensed Scordite":
                        {
                            TempSettings.CondensedScordite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Massive Scordite":
                        {
                            TempSettings.MassiveScordite = OreList.Items[i].Checked;
                            break;
                        }
                    case "Bright Spodumain":
                        {
                            TempSettings.BrightSpodumain = OreList.Items[i].Checked;
                            break;
                        }
                    case "Gleaming Spodumain":
                        {
                            TempSettings.GleamingSpodumain = OreList.Items[i].Checked;
                            break;
                        }
                    case "Concentrated Veldspar":
                        {
                            TempSettings.ConcentratedVeldspar = OreList.Items[i].Checked;
                            break;
                        }
                    case "Dense Veldspar":
                        {
                            TempSettings.DenseVeldspar = OreList.Items[i].Checked;
                            break;
                        }
                    case "Iridescent Gneiss":
                        {
                            TempSettings.IridescentGneiss = OreList.Items[i].Checked;
                            break;
                        }
                    case "Prismatic Gneiss":
                        {
                            TempSettings.PrismaticGneiss = OreList.Items[i].Checked;
                            break;
                        }
                    case "Silvery Omber":
                        {
                            TempSettings.SilveryOmber = OreList.Items[i].Checked;
                            break;
                        }
                    case "Golden Omber":
                        {
                            TempSettings.GoldenOmber = OreList.Items[i].Checked;
                            break;
                        }
                    case "Magma Mercoxit":
                        {
                            TempSettings.MagmaMercoxit = OreList.Items[i].Checked;
                            break;
                        }
                    case "Vitreous Mercoxit":
                        {
                            TempSettings.VitreousMercoxit = OreList.Items[i].Checked;
                            break;
                        }
                }
            }

            // Save the data in the XML file
            Settings.SaveIndustryBeltOreChecksSettings(TempSettings, Belt);

            // Save them locally
            switch (Belt)
            {
                case Public_Variables.BeltType.Small:
                    {
                        SettingsVariables.UserIndustryFlipBeltOreCheckSettings1 = TempSettings;
                        break;
                    }
                case Public_Variables.BeltType.Medium:
                    {
                        SettingsVariables.UserIndustryFlipBeltOreCheckSettings2 = TempSettings;
                        break;
                    }
                case Public_Variables.BeltType.Large:
                    {
                        SettingsVariables.UserIndustryFlipBeltOreCheckSettings3 = TempSettings;
                        break;
                    }
                case Public_Variables.BeltType.Enormous:
                    {
                        SettingsVariables.UserIndustryFlipBeltOreCheckSettings4 = TempSettings;
                        break;
                    }
                case Public_Variables.BeltType.Colossal:
                    {
                        SettingsVariables.UserIndustryFlipBeltOreCheckSettings5 = TempSettings;
                        break;
                    }
            }

            Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

        }

        #region Event Functions

        private void cmbNumMiners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                LoadAllTables();
            }
        }

        private void txtCycleTime_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtCycleTime, e);
            if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Tab & !FirstLoad)
            {
                LoadAllTables();
            }
        }

        private void Options_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPriceChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                LoadAllTables();
            }
        }

        private void btnSaveSettingsSmall_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name.Contains("Small"))
            {
                SaveSelectedOres(Public_Variables.BeltType.Small);
            }
            else if (((Button)sender).Name.Contains("Medium"))
            {
                SaveSelectedOres(Public_Variables.BeltType.Medium);
            }
            else if (((Button)sender).Name.Contains("Large"))
            {
                SaveSelectedOres(Public_Variables.BeltType.Large);
            }
            else if (((Button)sender).Name.Contains("XLarge"))
            {
                SaveSelectedOres(Public_Variables.BeltType.Enormous);
            }
            else if (((Button)sender).Name.Contains("Giant"))
            {
                SaveSelectedOres(Public_Variables.BeltType.Colossal);
            }
        }

        private void lstOresLevel1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstOresLevel1;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Ore1ColumnClicked, ref Ore1ColumnSortOrder);
            lstOresLevel1 = argRefListView;
        }

        private void lstMineralsLevel1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstMineralsLevel1;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Mineral1ColumnClicked, ref Mineral1ColumnSortOrder);
            lstMineralsLevel1 = argRefListView;
        }

        private void lstOresLevel1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView s = (ListView)sender;

            if (!FirstLoad & s.ContainsFocus)
            {
                DisplayBeltMinerals(Public_Variables.BeltType.Small);
            }
        }

        private void lstOresLevel2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstOresLevel2;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Ore2ColumnClicked, ref Ore2ColumnSortOrder);
            lstOresLevel2 = argRefListView;
        }

        private void lstMineralsLevel2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstMineralsLevel2;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Mineral2ColumnClicked, ref Mineral2ColumnSortOrder);
            lstMineralsLevel2 = argRefListView;
        }

        private void lstOresLevel2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView s = (ListView)sender;

            if (!FirstLoad & s.ContainsFocus)
            {
                DisplayBeltMinerals(Public_Variables.BeltType.Medium);
            }
        }

        private void lstOresLevel3_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstOresLevel3;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Ore3ColumnClicked, ref Ore3ColumnSortOrder);
            lstOresLevel3 = argRefListView;
        }

        private void lstMineralsLevel3_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstMineralsLevel3;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Mineral3ColumnClicked, ref Mineral3ColumnSortOrder);
            lstMineralsLevel3 = argRefListView;
        }

        private void lstOresLevel3_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView s = (ListView)sender;

            if (!FirstLoad & s.ContainsFocus)
            {
                DisplayBeltMinerals(Public_Variables.BeltType.Large);
            }
        }

        private void lstOresLevel4_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstOresLevel4;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Ore4ColumnClicked, ref Ore4ColumnSortOrder);
            lstOresLevel4 = argRefListView;
        }

        private void lstMineralsLevel4_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstMineralsLevel4;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Mineral4ColumnClicked, ref Mineral4ColumnSortOrder);
            lstMineralsLevel4 = argRefListView;
        }

        private void lstOresLevel4_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView s = (ListView)sender;

            if (!FirstLoad & s.ContainsFocus)
            {
                DisplayBeltMinerals(Public_Variables.BeltType.Enormous);
            }
        }

        private void lstOresLevel5_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstOresLevel5;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Ore5ColumnClicked, ref Ore5ColumnSortOrder);
            lstOresLevel5 = argRefListView;
        }

        private void lstMineralsLevel5_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstMineralsLevel5;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref Mineral5ColumnClicked, ref Mineral5ColumnSortOrder);
            lstMineralsLevel5 = argRefListView;
        }

        private void lstOresLevel5_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView s = (ListView)sender;

            if (!FirstLoad & s.ContainsFocus)
            {
                DisplayBeltMinerals(Public_Variables.BeltType.Colossal);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
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

        private void frmIndustryBeltFlip_Disposed(object sender, EventArgs e)
        {
            Public_Variables.OreBeltFlipOpen = false;
        }

        #endregion

    }
}