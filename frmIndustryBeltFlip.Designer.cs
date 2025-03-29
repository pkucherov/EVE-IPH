using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmIndustryBeltFlip : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndustryBeltFlip));
            lstOresLevel1 = new ListView();
            lstOresLevel1.ColumnClick += new ColumnClickEventHandler(lstOresLevel1_ColumnClick);
            lstOresLevel1.ItemChecked += new ItemCheckedEventHandler(lstOresLevel1_ItemChecked);
            checkboxSmall = new ColumnHeader();
            orenameSmall = new ColumnHeader();
            numberroidsSmall = new ColumnHeader();
            unitsSmall = new ColumnHeader();
            lstMineralsLevel1 = new ListView();
            lstMineralsLevel1.ColumnClick += new ColumnClickEventHandler(lstMineralsLevel1_ColumnClick);
            mineralsSmall = new ColumnHeader();
            minsunitsSmall = new ColumnHeader();
            totaliskSmall = new ColumnHeader();
            lblSmallBeltOreComp = new Label();
            lblBeltTotalIskLevel1Sum = new Label();
            lblTotalIskLevel1Sum = new Label();
            gbMineTaxBroker = new GroupBox();
            txtBrokerFeeRate = new TextBox();
            txtBrokerFeeRate.KeyDown += new KeyEventHandler(txtBrokerFeeRate_KeyDown);
            txtBrokerFeeRate.KeyPress += new KeyPressEventHandler(txtBrokerFeeRate_KeyPress);
            txtBrokerFeeRate.GotFocus += new EventHandler(txtBrokerFeeRate_GotFocus);
            txtBrokerFeeRate.LostFocus += new EventHandler(txtBrokerFeeRate_LostFocus);
            chkIPHperMiner = new CheckBox();
            chkIPHperMiner.CheckedChanged += new EventHandler(Selection_CheckedChanged);
            chkCompressOre = new CheckBox();
            chkCompressOre.CheckedChanged += new EventHandler(Selection_CheckedChanged);
            chkIncludeTaxes = new CheckBox();
            chkIncludeTaxes.CheckedChanged += new EventHandler(Selection_CheckedChanged);
            chkBrokerFees = new CheckBox();
            chkBrokerFees.CheckedChanged += new EventHandler(Selection_CheckedChanged);
            chkBrokerFees.Click += new EventHandler(chkBrokerFees_Click);
            lblTotalBeltVolume1Sum = new Label();
            lblBeltVolume1Sum = new Label();
            lblTotalHourstoFlip1Sum = new Label();
            lblHourstoFlip1Sum = new Label();
            lblTotalIPH1Sum = new Label();
            lblIPH1Sum = new Label();
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            lblCycleTime = new Label();
            txtCycleTime = new TextBox();
            txtCycleTime.KeyDown += new KeyEventHandler(txtCycleTime_KeyDown);
            txtCycleTime.KeyPress += new KeyPressEventHandler(Options_KeyPress);
            lblm3perCycle = new Label();
            txtm3perCycle = new TextBox();
            txtm3perCycle.KeyDown += new KeyEventHandler(txtCycleTime_KeyDown);
            txtm3perCycle.KeyPress += new KeyPressEventHandler(Options_KeyPress);
            lblNumMiners = new Label();
            cmbNumMiners = new ComboBox();
            cmbNumMiners.SelectedIndexChanged += new EventHandler(cmbNumMiners_SelectedIndexChanged);
            cmbNumMiners.KeyDown += new KeyEventHandler(txtCycleTime_KeyDown);
            cmbNumMiners.KeyPress += new KeyPressEventHandler(Options_KeyPress);
            lblm3perhrperminer1 = new Label();
            lblm3perhrperminer = new Label();
            tabIndustryBelts = new TabControl();
            tabSummary = new TabPage();
            gbGiant = new GroupBox();
            lblTotalBeltVolume4Sum = new Label();
            lblTotalHourstoFlip4Sum = new Label();
            lblIPH4Sum = new Label();
            lblBeltVolume4Sum = new Label();
            lblHourstoFlip4Sum = new Label();
            lblTotalIskLevel4Sum = new Label();
            lblBeltTotalIskLevel4Sum = new Label();
            lblTotalIPH4Sum = new Label();
            gbExtraLarge = new GroupBox();
            lblTotalBeltVolume5Sum = new Label();
            lblTotalIPH5Sum = new Label();
            lblIPH5Sum = new Label();
            lblBeltTotalIskLevel5Sum = new Label();
            lblTotalHourstoFlip5Sum = new Label();
            lblTotalIskLevel5Sum = new Label();
            lblBeltVolume5Sum = new Label();
            lblHourstoFlip5Sum = new Label();
            gbLarge = new GroupBox();
            lblTotalBeltVolume3Sum = new Label();
            lblIPH3Sum = new Label();
            lblTotalHourstoFlip3Sum = new Label();
            lblTotalIPH3Sum = new Label();
            lblHourstoFlip3Sum = new Label();
            lblBeltVolume3Sum = new Label();
            lblTotalIskLevel3Sum = new Label();
            lblBeltTotalIskLevel3Sum = new Label();
            gbModerate = new GroupBox();
            lblTotalBeltVolume2Sum = new Label();
            lblIPH2Sum = new Label();
            lblTotalHourstoFlip2Sum = new Label();
            lblTotalIPH2Sum = new Label();
            lblHourstoFlip2Sum = new Label();
            lblBeltVolume2Sum = new Label();
            lblTotalIskLevel2Sum = new Label();
            lblBeltTotalIskLevel2Sum = new Label();
            gbSmall = new GroupBox();
            gbSummarySettings = new GroupBox();
            ReprocessingFacility = new ManufacturingFacility();
            gbTruesec = new GroupBox();
            rbtn10percent = new RadioButton();
            rbtn10percent.CheckedChanged += new EventHandler(Selection_CheckedChanged);
            rbtn0percent = new RadioButton();
            rbtn0percent.CheckedChanged += new EventHandler(Selection_CheckedChanged);
            rbtn5percent = new RadioButton();
            rbtn5percent.CheckedChanged += new EventHandler(Selection_CheckedChanged);
            btnRefine = new Button();
            btnRefine.Click += new EventHandler(btnRefresh_Click);
            tabSmall = new TabPage();
            btnCloseSmall = new Button();
            btnCloseSmall.Click += new EventHandler(btnClose_Click);
            btnSaveSettingsSmall = new Button();
            btnSaveSettingsSmall.Click += new EventHandler(btnSaveSettingsSmall_Click);
            gbSum1 = new GroupBox();
            lblTotalIPH1 = new Label();
            lblTotalBeltVolume1 = new Label();
            lblBeltTotalIsk1 = new Label();
            lblTotalHourstoFlip1 = new Label();
            lblTotalIskLevel1 = new Label();
            lblIPH1 = new Label();
            lblTotalBeltVol1 = new Label();
            lblHourstoFlip1 = new Label();
            lblSmallBeltMineralComp = new Label();
            tabMedium = new TabPage();
            btnCloseMedium = new Button();
            btnCloseMedium.Click += new EventHandler(btnClose_Click);
            btnSaveSettingsMedium = new Button();
            btnSaveSettingsMedium.Click += new EventHandler(btnSaveSettingsSmall_Click);
            gbSum2 = new GroupBox();
            lblTotalIPH2 = new Label();
            lblTotalBeltVolume2 = new Label();
            lblBeltTotalIsk2 = new Label();
            lblTotalHourstoFlip2 = new Label();
            lblTotalIskLevel2 = new Label();
            lblIPH2 = new Label();
            lblTotalBeltVol2 = new Label();
            lblHourstoFlip2 = new Label();
            lstMineralsLevel2 = new ListView();
            lstMineralsLevel2.ColumnClick += new ColumnClickEventHandler(lstMineralsLevel2_ColumnClick);
            mineralsMedium = new ColumnHeader();
            minsunitsMedium = new ColumnHeader();
            totaliskMedium = new ColumnHeader();
            lstOresLevel2 = new ListView();
            lstOresLevel2.ColumnClick += new ColumnClickEventHandler(lstOresLevel2_ColumnClick);
            lstOresLevel2.ItemChecked += new ItemCheckedEventHandler(lstOresLevel2_ItemChecked);
            checkboxMedium = new ColumnHeader();
            orenameMedium = new ColumnHeader();
            numberroidsMedium = new ColumnHeader();
            unitsMedium = new ColumnHeader();
            lblMediumBeltMineralComp = new Label();
            lblMediumBeltOreComp = new Label();
            tabLarge = new TabPage();
            btnCloseLarge = new Button();
            btnCloseLarge.Click += new EventHandler(btnClose_Click);
            btnSaveSettingsLarge = new Button();
            btnSaveSettingsLarge.Click += new EventHandler(btnSaveSettingsSmall_Click);
            gbSum3 = new GroupBox();
            lblTotalIPH3 = new Label();
            lblTotalBeltVolume3 = new Label();
            lblBeltTotalIsk3 = new Label();
            lblTotalHourstoFlip3 = new Label();
            lblTotalIskLevel3 = new Label();
            lblIPH3 = new Label();
            lblTotalBeltVol3 = new Label();
            lblHourstoFlip3 = new Label();
            lblLargeBeltMineralComp = new Label();
            lstOresLevel3 = new ListView();
            lstOresLevel3.ColumnClick += new ColumnClickEventHandler(lstOresLevel3_ColumnClick);
            lstOresLevel3.ItemChecked += new ItemCheckedEventHandler(lstOresLevel3_ItemChecked);
            checkboxLarge = new ColumnHeader();
            orenameLarge = new ColumnHeader();
            numberroidsLarge = new ColumnHeader();
            unitsLarge = new ColumnHeader();
            lstMineralsLevel3 = new ListView();
            lstMineralsLevel3.ColumnClick += new ColumnClickEventHandler(lstMineralsLevel3_ColumnClick);
            mineralsLarge = new ColumnHeader();
            minsunitsLarge = new ColumnHeader();
            totaliskLarge = new ColumnHeader();
            lblLargeBeltOreComp = new Label();
            tabEnormous = new TabPage();
            btnCloseXL = new Button();
            btnCloseXL.Click += new EventHandler(btnClose_Click);
            btnSaveSettingsXLarge = new Button();
            btnSaveSettingsXLarge.Click += new EventHandler(btnSaveSettingsSmall_Click);
            gbSum4 = new GroupBox();
            lblTotalIPH4 = new Label();
            lblTotalBeltVolume4 = new Label();
            lblBeltTotalIsk4 = new Label();
            lblTotalHourstoFlip4 = new Label();
            lblTotalIskLevel4 = new Label();
            lblIPH4 = new Label();
            lblTotalBeltVol4 = new Label();
            lblHourstoFlip4 = new Label();
            lblXLBeltMineralComp = new Label();
            lstOresLevel4 = new ListView();
            lstOresLevel4.ColumnClick += new ColumnClickEventHandler(lstOresLevel4_ColumnClick);
            lstOresLevel4.ItemChecked += new ItemCheckedEventHandler(lstOresLevel4_ItemChecked);
            checkboxXL = new ColumnHeader();
            orenameXL = new ColumnHeader();
            numberroidsXL = new ColumnHeader();
            unitsXL = new ColumnHeader();
            lstMineralsLevel4 = new ListView();
            lstMineralsLevel4.ColumnClick += new ColumnClickEventHandler(lstMineralsLevel4_ColumnClick);
            mineralsXL = new ColumnHeader();
            minsunitsXL = new ColumnHeader();
            totaliskXL = new ColumnHeader();
            lblXLBeltOreComp = new Label();
            tabColossal = new TabPage();
            btnCloseGiant = new Button();
            btnCloseGiant.Click += new EventHandler(btnClose_Click);
            btnSaveSettingsGiant = new Button();
            btnSaveSettingsGiant.Click += new EventHandler(btnSaveSettingsSmall_Click);
            gbSum5 = new GroupBox();
            lblTotalIPH5 = new Label();
            lblTotalBeltVolume5 = new Label();
            lblBeltTotalIsk5 = new Label();
            lblTotalHourstoFlip5 = new Label();
            lblTotalIskLevel5 = new Label();
            lblIPH5 = new Label();
            lblTotalBeltVol5 = new Label();
            lblHourstoFlip5 = new Label();
            lblGiantBeltMineralComp = new Label();
            lstOresLevel5 = new ListView();
            lstOresLevel5.ColumnClick += new ColumnClickEventHandler(lstOresLevel5_ColumnClick);
            lstOresLevel5.ItemChecked += new ItemCheckedEventHandler(lstOresLevel5_ItemChecked);
            checkboxGiant = new ColumnHeader();
            orenameGiant = new ColumnHeader();
            numberroidsGiant = new ColumnHeader();
            unitsGiant = new ColumnHeader();
            lstMineralsLevel5 = new ListView();
            lstMineralsLevel5.ColumnClick += new ColumnClickEventHandler(lstMineralsLevel5_ColumnClick);
            mineralsGiant = new ColumnHeader();
            minsunitsGiant = new ColumnHeader();
            totaliskGiant = new ColumnHeader();
            lblGiantBeltOreComp = new Label();
            ttMain = new ToolTip(components);
            gbMineTaxBroker.SuspendLayout();
            tabIndustryBelts.SuspendLayout();
            tabSummary.SuspendLayout();
            gbGiant.SuspendLayout();
            gbExtraLarge.SuspendLayout();
            gbLarge.SuspendLayout();
            gbModerate.SuspendLayout();
            gbSmall.SuspendLayout();
            gbSummarySettings.SuspendLayout();
            gbTruesec.SuspendLayout();
            tabSmall.SuspendLayout();
            gbSum1.SuspendLayout();
            tabMedium.SuspendLayout();
            gbSum2.SuspendLayout();
            tabLarge.SuspendLayout();
            gbSum3.SuspendLayout();
            tabEnormous.SuspendLayout();
            gbSum4.SuspendLayout();
            tabColossal.SuspendLayout();
            gbSum5.SuspendLayout();
            SuspendLayout();
            // 
            // lstOresLevel1
            // 
            lstOresLevel1.CheckBoxes = true;
            lstOresLevel1.Columns.AddRange(new ColumnHeader[] { checkboxSmall, orenameSmall, numberroidsSmall, unitsSmall });
            lstOresLevel1.FullRowSelect = true;
            lstOresLevel1.GridLines = true;
            lstOresLevel1.HideSelection = false;
            lstOresLevel1.Location = new Point(6, 30);
            lstOresLevel1.MultiSelect = false;
            lstOresLevel1.Name = "lstOresLevel1";
            lstOresLevel1.Size = new Size(235, 322);
            lstOresLevel1.TabIndex = 6;
            lstOresLevel1.UseCompatibleStateImageBehavior = false;
            lstOresLevel1.View = View.Details;
            // 
            // checkboxSmall
            // 
            checkboxSmall.Text = "";
            checkboxSmall.Width = 25;
            // 
            // orenameSmall
            // 
            orenameSmall.Text = "Ore";
            orenameSmall.Width = 100;
            // 
            // numberroidsSmall
            // 
            numberroidsSmall.Text = "Rocks";
            numberroidsSmall.TextAlign = HorizontalAlignment.Center;
            numberroidsSmall.Width = 43;
            // 
            // unitsSmall
            // 
            unitsSmall.Text = "Units";
            unitsSmall.TextAlign = HorizontalAlignment.Right;
            unitsSmall.Width = 63;
            // 
            // lstMineralsLevel1
            // 
            lstMineralsLevel1.Columns.AddRange(new ColumnHeader[] { mineralsSmall, minsunitsSmall, totaliskSmall });
            lstMineralsLevel1.FullRowSelect = true;
            lstMineralsLevel1.GridLines = true;
            lstMineralsLevel1.HideSelection = false;
            lstMineralsLevel1.Location = new Point(247, 30);
            lstMineralsLevel1.MultiSelect = false;
            lstMineralsLevel1.Name = "lstMineralsLevel1";
            lstMineralsLevel1.Size = new Size(243, 165);
            lstMineralsLevel1.TabIndex = 11;
            lstMineralsLevel1.UseCompatibleStateImageBehavior = false;
            lstMineralsLevel1.View = View.Details;
            // 
            // mineralsSmall
            // 
            mineralsSmall.Text = "Mineral";
            mineralsSmall.Width = 57;
            // 
            // minsunitsSmall
            // 
            minsunitsSmall.Text = "Units";
            minsunitsSmall.TextAlign = HorizontalAlignment.Right;
            minsunitsSmall.Width = 79;
            // 
            // totaliskSmall
            // 
            totaliskSmall.Text = "Total Isk";
            totaliskSmall.TextAlign = HorizontalAlignment.Right;
            totaliskSmall.Width = 103;
            // 
            // lblSmallBeltOreComp
            // 
            lblSmallBeltOreComp.AutoSize = true;
            lblSmallBeltOreComp.Location = new Point(71, 15);
            lblSmallBeltOreComp.Name = "lblSmallBeltOreComp";
            lblSmallBeltOreComp.Size = new Size(105, 13);
            lblSmallBeltOreComp.TabIndex = 12;
            lblSmallBeltOreComp.Text = "Belt Ore Composition";
            lblSmallBeltOreComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBeltTotalIskLevel1Sum
            // 
            lblBeltTotalIskLevel1Sum.AutoSize = true;
            lblBeltTotalIskLevel1Sum.Location = new Point(16, 23);
            lblBeltTotalIskLevel1Sum.Name = "lblBeltTotalIskLevel1Sum";
            lblBeltTotalIskLevel1Sum.Size = new Size(72, 13);
            lblBeltTotalIskLevel1Sum.TabIndex = 13;
            lblBeltTotalIskLevel1Sum.Text = "Belt Total Isk:";
            lblBeltTotalIskLevel1Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalIskLevel1Sum
            // 
            lblTotalIskLevel1Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel1Sum.Location = new Point(91, 20);
            lblTotalIskLevel1Sum.Name = "lblTotalIskLevel1Sum";
            lblTotalIskLevel1Sum.Size = new Size(127, 18);
            lblTotalIskLevel1Sum.TabIndex = 14;
            lblTotalIskLevel1Sum.Text = "100,000.00";
            lblTotalIskLevel1Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbMineTaxBroker
            // 
            gbMineTaxBroker.Controls.Add(txtBrokerFeeRate);
            gbMineTaxBroker.Controls.Add(chkIPHperMiner);
            gbMineTaxBroker.Controls.Add(chkCompressOre);
            gbMineTaxBroker.Controls.Add(chkIncludeTaxes);
            gbMineTaxBroker.Controls.Add(chkBrokerFees);
            gbMineTaxBroker.Location = new Point(269, 5);
            gbMineTaxBroker.Name = "gbMineTaxBroker";
            gbMineTaxBroker.Size = new Size(211, 55);
            gbMineTaxBroker.TabIndex = 16;
            gbMineTaxBroker.TabStop = false;
            gbMineTaxBroker.Text = "Options:";
            // 
            // txtBrokerFeeRate
            // 
            txtBrokerFeeRate.Location = new Point(64, 31);
            txtBrokerFeeRate.Name = "txtBrokerFeeRate";
            txtBrokerFeeRate.Size = new Size(48, 20);
            txtBrokerFeeRate.TabIndex = 41;
            txtBrokerFeeRate.TabStop = false;
            txtBrokerFeeRate.Visible = false;
            // 
            // chkIPHperMiner
            // 
            chkIPHperMiner.AutoSize = true;
            chkIPHperMiner.Checked = true;
            chkIPHperMiner.CheckState = CheckState.Checked;
            chkIPHperMiner.Location = new Point(118, 15);
            chkIPHperMiner.Name = "chkIPHperMiner";
            chkIPHperMiner.Size = new Size(91, 17);
            chkIPHperMiner.TabIndex = 9;
            chkIPHperMiner.Text = "IPH per Miner";
            chkIPHperMiner.UseVisualStyleBackColor = true;
            // 
            // chkCompressOre
            // 
            chkCompressOre.AutoSize = true;
            chkCompressOre.Checked = true;
            chkCompressOre.CheckState = CheckState.Checked;
            chkCompressOre.Location = new Point(9, 15);
            chkCompressOre.Name = "chkCompressOre";
            chkCompressOre.Size = new Size(92, 17);
            chkCompressOre.TabIndex = 8;
            chkCompressOre.Text = "Compress Ore";
            chkCompressOre.UseVisualStyleBackColor = true;
            // 
            // chkIncludeTaxes
            // 
            chkIncludeTaxes.AutoSize = true;
            chkIncludeTaxes.Checked = true;
            chkIncludeTaxes.CheckState = CheckState.Checked;
            chkIncludeTaxes.Location = new Point(118, 33);
            chkIncludeTaxes.Name = "chkIncludeTaxes";
            chkIncludeTaxes.Size = new Size(55, 17);
            chkIncludeTaxes.TabIndex = 11;
            chkIncludeTaxes.Text = "Taxes";
            chkIncludeTaxes.UseVisualStyleBackColor = true;
            // 
            // chkBrokerFees
            // 
            chkBrokerFees.AutoSize = true;
            chkBrokerFees.Checked = true;
            chkBrokerFees.CheckState = CheckState.Checked;
            chkBrokerFees.Location = new Point(9, 33);
            chkBrokerFees.Name = "chkBrokerFees";
            chkBrokerFees.Size = new Size(49, 17);
            chkBrokerFees.TabIndex = 10;
            chkBrokerFees.Text = "Fees";
            chkBrokerFees.ThreeState = true;
            chkBrokerFees.UseVisualStyleBackColor = true;
            // 
            // lblTotalBeltVolume1Sum
            // 
            lblTotalBeltVolume1Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume1Sum.Location = new Point(339, 42);
            lblTotalBeltVolume1Sum.Name = "lblTotalBeltVolume1Sum";
            lblTotalBeltVolume1Sum.Size = new Size(127, 18);
            lblTotalBeltVolume1Sum.TabIndex = 47;
            lblTotalBeltVolume1Sum.Text = "100,000.00";
            lblTotalBeltVolume1Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltVolume1Sum
            // 
            lblBeltVolume1Sum.AutoSize = true;
            lblBeltVolume1Sum.Location = new Point(243, 45);
            lblBeltVolume1Sum.Name = "lblBeltVolume1Sum";
            lblBeltVolume1Sum.Size = new Size(92, 13);
            lblBeltVolume1Sum.TabIndex = 46;
            lblBeltVolume1Sum.Text = "Total Ore Volume:";
            lblBeltVolume1Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip1Sum
            // 
            lblTotalHourstoFlip1Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip1Sum.Location = new Point(91, 42);
            lblTotalHourstoFlip1Sum.Name = "lblTotalHourstoFlip1Sum";
            lblTotalHourstoFlip1Sum.Size = new Size(127, 18);
            lblTotalHourstoFlip1Sum.TabIndex = 49;
            lblTotalHourstoFlip1Sum.Text = "100,000.00";
            lblTotalHourstoFlip1Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHourstoFlip1Sum
            // 
            lblHourstoFlip1Sum.AutoSize = true;
            lblHourstoFlip1Sum.Location = new Point(16, 45);
            lblHourstoFlip1Sum.Name = "lblHourstoFlip1Sum";
            lblHourstoFlip1Sum.Size = new Size(69, 13);
            lblHourstoFlip1Sum.TabIndex = 48;
            lblHourstoFlip1Sum.Text = "Hours to Flip:";
            lblHourstoFlip1Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalIPH1Sum
            // 
            lblTotalIPH1Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIPH1Sum.Location = new Point(339, 20);
            lblTotalIPH1Sum.Name = "lblTotalIPH1Sum";
            lblTotalIPH1Sum.Size = new Size(127, 18);
            lblTotalIPH1Sum.TabIndex = 51;
            lblTotalIPH1Sum.Text = "100,000.00";
            lblTotalIPH1Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH1Sum
            // 
            lblIPH1Sum.AutoSize = true;
            lblIPH1Sum.Location = new Point(268, 23);
            lblIPH1Sum.Name = "lblIPH1Sum";
            lblIPH1Sum.Size = new Size(68, 13);
            lblIPH1Sum.TabIndex = 50;
            lblIPH1Sum.Text = "Isk per Hour:";
            lblIPH1Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(192, 588);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(113, 28);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(93, 58);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(81, 28);
            btnSaveSettings.TabIndex = 4;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // lblCycleTime
            // 
            lblCycleTime.AutoSize = true;
            lblCycleTime.Location = new Point(90, 16);
            lblCycleTime.Name = "lblCycleTime";
            lblCycleTime.Size = new Size(62, 13);
            lblCycleTime.TabIndex = 111;
            lblCycleTime.Text = "Cycle Time:";
            // 
            // txtCycleTime
            // 
            txtCycleTime.Location = new Point(93, 31);
            txtCycleTime.Name = "txtCycleTime";
            txtCycleTime.Size = new Size(81, 20);
            txtCycleTime.TabIndex = 1;
            txtCycleTime.Text = "104.67";
            txtCycleTime.TextAlign = HorizontalAlignment.Center;
            // 
            // lblm3perCycle
            // 
            lblm3perCycle.AutoSize = true;
            lblm3perCycle.Location = new Point(174, 15);
            lblm3perCycle.Name = "lblm3perCycle";
            lblm3perCycle.Size = new Size(71, 13);
            lblm3perCycle.TabIndex = 113;
            lblm3perCycle.Text = "m3 per Cycle:";
            // 
            // txtm3perCycle
            // 
            txtm3perCycle.Location = new Point(177, 31);
            txtm3perCycle.Name = "txtm3perCycle";
            txtm3perCycle.Size = new Size(81, 20);
            txtm3perCycle.TabIndex = 2;
            txtm3perCycle.Text = "5833.11";
            txtm3perCycle.TextAlign = HorizontalAlignment.Center;
            // 
            // lblNumMiners
            // 
            lblNumMiners.AutoSize = true;
            lblNumMiners.Location = new Point(9, 16);
            lblNumMiners.Name = "lblNumMiners";
            lblNumMiners.Size = new Size(66, 13);
            lblNumMiners.TabIndex = 115;
            lblNumMiners.Text = "Num Miners:";
            // 
            // cmbNumMiners
            // 
            cmbNumMiners.FormattingEnabled = true;
            cmbNumMiners.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbNumMiners.Location = new Point(9, 31);
            cmbNumMiners.Name = "cmbNumMiners";
            cmbNumMiners.Size = new Size(81, 21);
            cmbNumMiners.TabIndex = 0;
            cmbNumMiners.Text = "10";
            // 
            // lblm3perhrperminer1
            // 
            lblm3perhrperminer1.AutoSize = true;
            lblm3perhrperminer1.Location = new Point(9, 161);
            lblm3perhrperminer1.Name = "lblm3perhrperminer1";
            lblm3perhrperminer1.Size = new Size(68, 13);
            lblm3perhrperminer1.TabIndex = 121;
            lblm3perhrperminer1.Text = "m3/hr/miner:";
            // 
            // lblm3perhrperminer
            // 
            lblm3perhrperminer.BorderStyle = BorderStyle.FixedSingle;
            lblm3perhrperminer.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblm3perhrperminer.Location = new Point(76, 158);
            lblm3perhrperminer.Name = "lblm3perhrperminer";
            lblm3perhrperminer.Size = new Size(98, 18);
            lblm3perhrperminer.TabIndex = 122;
            lblm3perhrperminer.Text = "999,999.00";
            lblm3perhrperminer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabIndustryBelts
            // 
            tabIndustryBelts.Controls.Add(tabSummary);
            tabIndustryBelts.Controls.Add(tabSmall);
            tabIndustryBelts.Controls.Add(tabMedium);
            tabIndustryBelts.Controls.Add(tabLarge);
            tabIndustryBelts.Controls.Add(tabEnormous);
            tabIndustryBelts.Controls.Add(tabColossal);
            tabIndustryBelts.Location = new Point(7, 12);
            tabIndustryBelts.Name = "tabIndustryBelts";
            tabIndustryBelts.SelectedIndex = 0;
            tabIndustryBelts.Size = new Size(504, 647);
            tabIndustryBelts.TabIndex = 139;
            // 
            // tabSummary
            // 
            tabSummary.Controls.Add(gbGiant);
            tabSummary.Controls.Add(gbExtraLarge);
            tabSummary.Controls.Add(gbLarge);
            tabSummary.Controls.Add(gbModerate);
            tabSummary.Controls.Add(gbSmall);
            tabSummary.Controls.Add(gbSummarySettings);
            tabSummary.Controls.Add(btnClose);
            tabSummary.Location = new Point(4, 22);
            tabSummary.Name = "tabSummary";
            tabSummary.Padding = new Padding(3);
            tabSummary.Size = new Size(496, 621);
            tabSummary.TabIndex = 0;
            tabSummary.Text = "Summary";
            tabSummary.UseVisualStyleBackColor = true;
            // 
            // gbGiant
            // 
            gbGiant.Controls.Add(lblTotalBeltVolume4Sum);
            gbGiant.Controls.Add(lblTotalHourstoFlip4Sum);
            gbGiant.Controls.Add(lblIPH4Sum);
            gbGiant.Controls.Add(lblBeltVolume4Sum);
            gbGiant.Controls.Add(lblHourstoFlip4Sum);
            gbGiant.Controls.Add(lblTotalIskLevel4Sum);
            gbGiant.Controls.Add(lblBeltTotalIskLevel4Sum);
            gbGiant.Controls.Add(lblTotalIPH4Sum);
            gbGiant.Location = new Point(8, 430);
            gbGiant.Name = "gbGiant";
            gbGiant.Size = new Size(484, 75);
            gbGiant.TabIndex = 143;
            gbGiant.TabStop = false;
            gbGiant.Text = "Extra-Large Belt - Level 4";
            // 
            // lblTotalBeltVolume4Sum
            // 
            lblTotalBeltVolume4Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume4Sum.Location = new Point(339, 42);
            lblTotalBeltVolume4Sum.Name = "lblTotalBeltVolume4Sum";
            lblTotalBeltVolume4Sum.Size = new Size(127, 18);
            lblTotalBeltVolume4Sum.TabIndex = 47;
            lblTotalBeltVolume4Sum.Text = "100,000.00";
            lblTotalBeltVolume4Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalHourstoFlip4Sum
            // 
            lblTotalHourstoFlip4Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip4Sum.Location = new Point(91, 42);
            lblTotalHourstoFlip4Sum.Name = "lblTotalHourstoFlip4Sum";
            lblTotalHourstoFlip4Sum.Size = new Size(127, 18);
            lblTotalHourstoFlip4Sum.TabIndex = 49;
            lblTotalHourstoFlip4Sum.Text = "100,000.00";
            lblTotalHourstoFlip4Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH4Sum
            // 
            lblIPH4Sum.AutoSize = true;
            lblIPH4Sum.Location = new Point(268, 23);
            lblIPH4Sum.Name = "lblIPH4Sum";
            lblIPH4Sum.Size = new Size(68, 13);
            lblIPH4Sum.TabIndex = 50;
            lblIPH4Sum.Text = "Isk per Hour:";
            lblIPH4Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBeltVolume4Sum
            // 
            lblBeltVolume4Sum.AutoSize = true;
            lblBeltVolume4Sum.Location = new Point(243, 45);
            lblBeltVolume4Sum.Name = "lblBeltVolume4Sum";
            lblBeltVolume4Sum.Size = new Size(92, 13);
            lblBeltVolume4Sum.TabIndex = 46;
            lblBeltVolume4Sum.Text = "Total Ore Volume:";
            lblBeltVolume4Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHourstoFlip4Sum
            // 
            lblHourstoFlip4Sum.AutoSize = true;
            lblHourstoFlip4Sum.Location = new Point(16, 45);
            lblHourstoFlip4Sum.Name = "lblHourstoFlip4Sum";
            lblHourstoFlip4Sum.Size = new Size(69, 13);
            lblHourstoFlip4Sum.TabIndex = 48;
            lblHourstoFlip4Sum.Text = "Hours to Flip:";
            lblHourstoFlip4Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalIskLevel4Sum
            // 
            lblTotalIskLevel4Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel4Sum.Location = new Point(91, 20);
            lblTotalIskLevel4Sum.Name = "lblTotalIskLevel4Sum";
            lblTotalIskLevel4Sum.Size = new Size(127, 18);
            lblTotalIskLevel4Sum.TabIndex = 14;
            lblTotalIskLevel4Sum.Text = "100,000.00";
            lblTotalIskLevel4Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltTotalIskLevel4Sum
            // 
            lblBeltTotalIskLevel4Sum.AutoSize = true;
            lblBeltTotalIskLevel4Sum.Location = new Point(16, 23);
            lblBeltTotalIskLevel4Sum.Name = "lblBeltTotalIskLevel4Sum";
            lblBeltTotalIskLevel4Sum.Size = new Size(72, 13);
            lblBeltTotalIskLevel4Sum.TabIndex = 13;
            lblBeltTotalIskLevel4Sum.Text = "Belt Total Isk:";
            lblBeltTotalIskLevel4Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalIPH4Sum
            // 
            lblTotalIPH4Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIPH4Sum.Location = new Point(339, 20);
            lblTotalIPH4Sum.Name = "lblTotalIPH4Sum";
            lblTotalIPH4Sum.Size = new Size(127, 18);
            lblTotalIPH4Sum.TabIndex = 51;
            lblTotalIPH4Sum.Text = "100,000.00";
            lblTotalIPH4Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbExtraLarge
            // 
            gbExtraLarge.Controls.Add(lblTotalBeltVolume5Sum);
            gbExtraLarge.Controls.Add(lblTotalIPH5Sum);
            gbExtraLarge.Controls.Add(lblIPH5Sum);
            gbExtraLarge.Controls.Add(lblBeltTotalIskLevel5Sum);
            gbExtraLarge.Controls.Add(lblTotalHourstoFlip5Sum);
            gbExtraLarge.Controls.Add(lblTotalIskLevel5Sum);
            gbExtraLarge.Controls.Add(lblBeltVolume5Sum);
            gbExtraLarge.Controls.Add(lblHourstoFlip5Sum);
            gbExtraLarge.Location = new Point(8, 509);
            gbExtraLarge.Name = "gbExtraLarge";
            gbExtraLarge.Size = new Size(484, 75);
            gbExtraLarge.TabIndex = 142;
            gbExtraLarge.TabStop = false;
            gbExtraLarge.Text = "Giant Belt - Level 5";
            // 
            // lblTotalBeltVolume5Sum
            // 
            lblTotalBeltVolume5Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume5Sum.Location = new Point(339, 42);
            lblTotalBeltVolume5Sum.Name = "lblTotalBeltVolume5Sum";
            lblTotalBeltVolume5Sum.Size = new Size(127, 18);
            lblTotalBeltVolume5Sum.TabIndex = 47;
            lblTotalBeltVolume5Sum.Text = "100,000.00";
            lblTotalBeltVolume5Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIPH5Sum
            // 
            lblTotalIPH5Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIPH5Sum.Location = new Point(339, 20);
            lblTotalIPH5Sum.Name = "lblTotalIPH5Sum";
            lblTotalIPH5Sum.Size = new Size(127, 18);
            lblTotalIPH5Sum.TabIndex = 51;
            lblTotalIPH5Sum.Text = "100,000.00";
            lblTotalIPH5Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH5Sum
            // 
            lblIPH5Sum.AutoSize = true;
            lblIPH5Sum.Location = new Point(269, 23);
            lblIPH5Sum.Name = "lblIPH5Sum";
            lblIPH5Sum.Size = new Size(68, 13);
            lblIPH5Sum.TabIndex = 50;
            lblIPH5Sum.Text = "Isk per Hour:";
            lblIPH5Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBeltTotalIskLevel5Sum
            // 
            lblBeltTotalIskLevel5Sum.AutoSize = true;
            lblBeltTotalIskLevel5Sum.Location = new Point(16, 23);
            lblBeltTotalIskLevel5Sum.Name = "lblBeltTotalIskLevel5Sum";
            lblBeltTotalIskLevel5Sum.Size = new Size(72, 13);
            lblBeltTotalIskLevel5Sum.TabIndex = 13;
            lblBeltTotalIskLevel5Sum.Text = "Belt Total Isk:";
            lblBeltTotalIskLevel5Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip5Sum
            // 
            lblTotalHourstoFlip5Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip5Sum.Location = new Point(91, 42);
            lblTotalHourstoFlip5Sum.Name = "lblTotalHourstoFlip5Sum";
            lblTotalHourstoFlip5Sum.Size = new Size(127, 18);
            lblTotalHourstoFlip5Sum.TabIndex = 49;
            lblTotalHourstoFlip5Sum.Text = "100,000.00";
            lblTotalHourstoFlip5Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIskLevel5Sum
            // 
            lblTotalIskLevel5Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel5Sum.Location = new Point(91, 20);
            lblTotalIskLevel5Sum.Name = "lblTotalIskLevel5Sum";
            lblTotalIskLevel5Sum.Size = new Size(127, 18);
            lblTotalIskLevel5Sum.TabIndex = 14;
            lblTotalIskLevel5Sum.Text = "100,000.00";
            lblTotalIskLevel5Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltVolume5Sum
            // 
            lblBeltVolume5Sum.AutoSize = true;
            lblBeltVolume5Sum.Location = new Point(244, 45);
            lblBeltVolume5Sum.Name = "lblBeltVolume5Sum";
            lblBeltVolume5Sum.Size = new Size(92, 13);
            lblBeltVolume5Sum.TabIndex = 46;
            lblBeltVolume5Sum.Text = "Total Ore Volume:";
            lblBeltVolume5Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHourstoFlip5Sum
            // 
            lblHourstoFlip5Sum.AutoSize = true;
            lblHourstoFlip5Sum.Location = new Point(16, 45);
            lblHourstoFlip5Sum.Name = "lblHourstoFlip5Sum";
            lblHourstoFlip5Sum.Size = new Size(69, 13);
            lblHourstoFlip5Sum.TabIndex = 48;
            lblHourstoFlip5Sum.Text = "Hours to Flip:";
            lblHourstoFlip5Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbLarge
            // 
            gbLarge.Controls.Add(lblTotalBeltVolume3Sum);
            gbLarge.Controls.Add(lblIPH3Sum);
            gbLarge.Controls.Add(lblTotalHourstoFlip3Sum);
            gbLarge.Controls.Add(lblTotalIPH3Sum);
            gbLarge.Controls.Add(lblHourstoFlip3Sum);
            gbLarge.Controls.Add(lblBeltVolume3Sum);
            gbLarge.Controls.Add(lblTotalIskLevel3Sum);
            gbLarge.Controls.Add(lblBeltTotalIskLevel3Sum);
            gbLarge.Location = new Point(8, 351);
            gbLarge.Name = "gbLarge";
            gbLarge.Size = new Size(484, 75);
            gbLarge.TabIndex = 142;
            gbLarge.TabStop = false;
            gbLarge.Text = "Large Belt - Level 3";
            // 
            // lblTotalBeltVolume3Sum
            // 
            lblTotalBeltVolume3Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume3Sum.Location = new Point(339, 42);
            lblTotalBeltVolume3Sum.Name = "lblTotalBeltVolume3Sum";
            lblTotalBeltVolume3Sum.Size = new Size(127, 18);
            lblTotalBeltVolume3Sum.TabIndex = 47;
            lblTotalBeltVolume3Sum.Text = "100,000.00";
            lblTotalBeltVolume3Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH3Sum
            // 
            lblIPH3Sum.AutoSize = true;
            lblIPH3Sum.Location = new Point(268, 23);
            lblIPH3Sum.Name = "lblIPH3Sum";
            lblIPH3Sum.Size = new Size(68, 13);
            lblIPH3Sum.TabIndex = 50;
            lblIPH3Sum.Text = "Isk per Hour:";
            lblIPH3Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip3Sum
            // 
            lblTotalHourstoFlip3Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip3Sum.Location = new Point(91, 42);
            lblTotalHourstoFlip3Sum.Name = "lblTotalHourstoFlip3Sum";
            lblTotalHourstoFlip3Sum.Size = new Size(127, 18);
            lblTotalHourstoFlip3Sum.TabIndex = 49;
            lblTotalHourstoFlip3Sum.Text = "100,000.00";
            lblTotalHourstoFlip3Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIPH3Sum
            // 
            lblTotalIPH3Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIPH3Sum.Location = new Point(339, 20);
            lblTotalIPH3Sum.Name = "lblTotalIPH3Sum";
            lblTotalIPH3Sum.Size = new Size(127, 18);
            lblTotalIPH3Sum.TabIndex = 51;
            lblTotalIPH3Sum.Text = "100,000.00";
            lblTotalIPH3Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHourstoFlip3Sum
            // 
            lblHourstoFlip3Sum.AutoSize = true;
            lblHourstoFlip3Sum.Location = new Point(16, 45);
            lblHourstoFlip3Sum.Name = "lblHourstoFlip3Sum";
            lblHourstoFlip3Sum.Size = new Size(69, 13);
            lblHourstoFlip3Sum.TabIndex = 48;
            lblHourstoFlip3Sum.Text = "Hours to Flip:";
            lblHourstoFlip3Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBeltVolume3Sum
            // 
            lblBeltVolume3Sum.AutoSize = true;
            lblBeltVolume3Sum.Location = new Point(243, 45);
            lblBeltVolume3Sum.Name = "lblBeltVolume3Sum";
            lblBeltVolume3Sum.Size = new Size(92, 13);
            lblBeltVolume3Sum.TabIndex = 46;
            lblBeltVolume3Sum.Text = "Total Ore Volume:";
            lblBeltVolume3Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalIskLevel3Sum
            // 
            lblTotalIskLevel3Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel3Sum.Location = new Point(91, 20);
            lblTotalIskLevel3Sum.Name = "lblTotalIskLevel3Sum";
            lblTotalIskLevel3Sum.Size = new Size(127, 18);
            lblTotalIskLevel3Sum.TabIndex = 14;
            lblTotalIskLevel3Sum.Text = "100,000.00";
            lblTotalIskLevel3Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltTotalIskLevel3Sum
            // 
            lblBeltTotalIskLevel3Sum.AutoSize = true;
            lblBeltTotalIskLevel3Sum.Location = new Point(16, 23);
            lblBeltTotalIskLevel3Sum.Name = "lblBeltTotalIskLevel3Sum";
            lblBeltTotalIskLevel3Sum.Size = new Size(72, 13);
            lblBeltTotalIskLevel3Sum.TabIndex = 13;
            lblBeltTotalIskLevel3Sum.Text = "Belt Total Isk:";
            lblBeltTotalIskLevel3Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbModerate
            // 
            gbModerate.Controls.Add(lblTotalBeltVolume2Sum);
            gbModerate.Controls.Add(lblIPH2Sum);
            gbModerate.Controls.Add(lblTotalHourstoFlip2Sum);
            gbModerate.Controls.Add(lblTotalIPH2Sum);
            gbModerate.Controls.Add(lblHourstoFlip2Sum);
            gbModerate.Controls.Add(lblBeltVolume2Sum);
            gbModerate.Controls.Add(lblTotalIskLevel2Sum);
            gbModerate.Controls.Add(lblBeltTotalIskLevel2Sum);
            gbModerate.Location = new Point(8, 272);
            gbModerate.Name = "gbModerate";
            gbModerate.Size = new Size(484, 75);
            gbModerate.TabIndex = 141;
            gbModerate.TabStop = false;
            gbModerate.Text = "Moderate Belt - Level 2";
            // 
            // lblTotalBeltVolume2Sum
            // 
            lblTotalBeltVolume2Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume2Sum.Location = new Point(339, 42);
            lblTotalBeltVolume2Sum.Name = "lblTotalBeltVolume2Sum";
            lblTotalBeltVolume2Sum.Size = new Size(127, 18);
            lblTotalBeltVolume2Sum.TabIndex = 47;
            lblTotalBeltVolume2Sum.Text = "100,000.00";
            lblTotalBeltVolume2Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH2Sum
            // 
            lblIPH2Sum.AutoSize = true;
            lblIPH2Sum.Location = new Point(268, 23);
            lblIPH2Sum.Name = "lblIPH2Sum";
            lblIPH2Sum.Size = new Size(68, 13);
            lblIPH2Sum.TabIndex = 50;
            lblIPH2Sum.Text = "Isk per Hour:";
            lblIPH2Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip2Sum
            // 
            lblTotalHourstoFlip2Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip2Sum.Location = new Point(91, 42);
            lblTotalHourstoFlip2Sum.Name = "lblTotalHourstoFlip2Sum";
            lblTotalHourstoFlip2Sum.Size = new Size(127, 18);
            lblTotalHourstoFlip2Sum.TabIndex = 49;
            lblTotalHourstoFlip2Sum.Text = "100,000.00";
            lblTotalHourstoFlip2Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIPH2Sum
            // 
            lblTotalIPH2Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIPH2Sum.Location = new Point(339, 20);
            lblTotalIPH2Sum.Name = "lblTotalIPH2Sum";
            lblTotalIPH2Sum.Size = new Size(127, 18);
            lblTotalIPH2Sum.TabIndex = 51;
            lblTotalIPH2Sum.Text = "100,000.00";
            lblTotalIPH2Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHourstoFlip2Sum
            // 
            lblHourstoFlip2Sum.AutoSize = true;
            lblHourstoFlip2Sum.Location = new Point(16, 45);
            lblHourstoFlip2Sum.Name = "lblHourstoFlip2Sum";
            lblHourstoFlip2Sum.Size = new Size(69, 13);
            lblHourstoFlip2Sum.TabIndex = 48;
            lblHourstoFlip2Sum.Text = "Hours to Flip:";
            lblHourstoFlip2Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBeltVolume2Sum
            // 
            lblBeltVolume2Sum.AutoSize = true;
            lblBeltVolume2Sum.Location = new Point(243, 45);
            lblBeltVolume2Sum.Name = "lblBeltVolume2Sum";
            lblBeltVolume2Sum.Size = new Size(92, 13);
            lblBeltVolume2Sum.TabIndex = 46;
            lblBeltVolume2Sum.Text = "Total Ore Volume:";
            lblBeltVolume2Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalIskLevel2Sum
            // 
            lblTotalIskLevel2Sum.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel2Sum.Location = new Point(91, 20);
            lblTotalIskLevel2Sum.Name = "lblTotalIskLevel2Sum";
            lblTotalIskLevel2Sum.Size = new Size(127, 18);
            lblTotalIskLevel2Sum.TabIndex = 14;
            lblTotalIskLevel2Sum.Text = "100,000.00";
            lblTotalIskLevel2Sum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltTotalIskLevel2Sum
            // 
            lblBeltTotalIskLevel2Sum.AutoSize = true;
            lblBeltTotalIskLevel2Sum.Location = new Point(16, 23);
            lblBeltTotalIskLevel2Sum.Name = "lblBeltTotalIskLevel2Sum";
            lblBeltTotalIskLevel2Sum.Size = new Size(72, 13);
            lblBeltTotalIskLevel2Sum.TabIndex = 13;
            lblBeltTotalIskLevel2Sum.Text = "Belt Total Isk:";
            lblBeltTotalIskLevel2Sum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbSmall
            // 
            gbSmall.Controls.Add(lblTotalBeltVolume1Sum);
            gbSmall.Controls.Add(lblIPH1Sum);
            gbSmall.Controls.Add(lblTotalHourstoFlip1Sum);
            gbSmall.Controls.Add(lblTotalIPH1Sum);
            gbSmall.Controls.Add(lblHourstoFlip1Sum);
            gbSmall.Controls.Add(lblBeltVolume1Sum);
            gbSmall.Controls.Add(lblTotalIskLevel1Sum);
            gbSmall.Controls.Add(lblBeltTotalIskLevel1Sum);
            gbSmall.Location = new Point(6, 193);
            gbSmall.Name = "gbSmall";
            gbSmall.Size = new Size(484, 75);
            gbSmall.TabIndex = 140;
            gbSmall.TabStop = false;
            gbSmall.Text = "Small Belt - Level 1";
            // 
            // gbSummarySettings
            // 
            gbSummarySettings.Controls.Add(ReprocessingFacility);
            gbSummarySettings.Controls.Add(gbTruesec);
            gbSummarySettings.Controls.Add(btnRefine);
            gbSummarySettings.Controls.Add(gbMineTaxBroker);
            gbSummarySettings.Controls.Add(lblCycleTime);
            gbSummarySettings.Controls.Add(txtCycleTime);
            gbSummarySettings.Controls.Add(txtm3perCycle);
            gbSummarySettings.Controls.Add(btnSaveSettings);
            gbSummarySettings.Controls.Add(lblm3perCycle);
            gbSummarySettings.Controls.Add(cmbNumMiners);
            gbSummarySettings.Controls.Add(lblNumMiners);
            gbSummarySettings.Controls.Add(lblm3perhrperminer);
            gbSummarySettings.Controls.Add(lblm3perhrperminer1);
            gbSummarySettings.Location = new Point(6, 6);
            gbSummarySettings.Name = "gbSummarySettings";
            gbSummarySettings.Size = new Size(484, 183);
            gbSummarySettings.TabIndex = 139;
            gbSummarySettings.TabStop = false;
            gbSummarySettings.Text = "Settings";
            // 
            // ReprocessingFacility
            // 
            ReprocessingFacility.BackColor = Color.Transparent;
            ReprocessingFacility.Location = new Point(177, 66);
            ReprocessingFacility.Name = "ReprocessingFacility";
            ReprocessingFacility.Size = new Size(303, 108);
            ReprocessingFacility.TabIndex = 124;
            // 
            // gbTruesec
            // 
            gbTruesec.Controls.Add(rbtn10percent);
            gbTruesec.Controls.Add(rbtn0percent);
            gbTruesec.Controls.Add(rbtn5percent);
            gbTruesec.Location = new Point(9, 91);
            gbTruesec.Name = "gbTruesec";
            gbTruesec.Size = new Size(165, 64);
            gbTruesec.TabIndex = 128;
            gbTruesec.TabStop = false;
            gbTruesec.Text = "System Truesec:";
            // 
            // rbtn10percent
            // 
            rbtn10percent.AutoSize = true;
            rbtn10percent.Location = new Point(12, 43);
            rbtn10percent.Name = "rbtn10percent";
            rbtn10percent.Size = new Size(88, 17);
            rbtn10percent.TabIndex = 127;
            rbtn10percent.TabStop = true;
            rbtn10percent.Text = "-0.85 to -1.00";
            rbtn10percent.UseVisualStyleBackColor = true;
            // 
            // rbtn0percent
            // 
            rbtn0percent.AutoSize = true;
            rbtn0percent.Location = new Point(12, 13);
            rbtn0percent.Name = "rbtn0percent";
            rbtn0percent.Size = new Size(88, 17);
            rbtn0percent.TabIndex = 125;
            rbtn0percent.TabStop = true;
            rbtn0percent.Text = "-0.00 to -0.44";
            rbtn0percent.UseVisualStyleBackColor = true;
            // 
            // rbtn5percent
            // 
            rbtn5percent.AutoSize = true;
            rbtn5percent.Location = new Point(12, 28);
            rbtn5percent.Name = "rbtn5percent";
            rbtn5percent.Size = new Size(88, 17);
            rbtn5percent.TabIndex = 126;
            rbtn5percent.TabStop = true;
            rbtn5percent.Text = "-0.45 to -0.84";
            rbtn5percent.UseVisualStyleBackColor = true;
            // 
            // btnRefine
            // 
            btnRefine.Location = new Point(9, 58);
            btnRefine.Name = "btnRefine";
            btnRefine.Size = new Size(81, 28);
            btnRefine.TabIndex = 3;
            btnRefine.Text = "Refine";
            btnRefine.UseVisualStyleBackColor = true;
            // 
            // tabSmall
            // 
            tabSmall.Controls.Add(btnCloseSmall);
            tabSmall.Controls.Add(btnSaveSettingsSmall);
            tabSmall.Controls.Add(gbSum1);
            tabSmall.Controls.Add(lblSmallBeltMineralComp);
            tabSmall.Controls.Add(lstOresLevel1);
            tabSmall.Controls.Add(lstMineralsLevel1);
            tabSmall.Controls.Add(lblSmallBeltOreComp);
            tabSmall.Location = new Point(4, 22);
            tabSmall.Name = "tabSmall";
            tabSmall.Padding = new Padding(3);
            tabSmall.Size = new Size(496, 621);
            tabSmall.TabIndex = 1;
            tabSmall.Text = "Small Belt";
            tabSmall.UseVisualStyleBackColor = true;
            // 
            // btnCloseSmall
            // 
            btnCloseSmall.Location = new Point(374, 324);
            btnCloseSmall.Name = "btnCloseSmall";
            btnCloseSmall.Size = new Size(113, 28);
            btnCloseSmall.TabIndex = 14;
            btnCloseSmall.Text = "Close";
            btnCloseSmall.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettingsSmall
            // 
            btnSaveSettingsSmall.Location = new Point(248, 324);
            btnSaveSettingsSmall.Name = "btnSaveSettingsSmall";
            btnSaveSettingsSmall.Size = new Size(113, 28);
            btnSaveSettingsSmall.TabIndex = 13;
            btnSaveSettingsSmall.Text = "Save Selected Ores";
            btnSaveSettingsSmall.UseVisualStyleBackColor = true;
            // 
            // gbSum1
            // 
            gbSum1.Controls.Add(lblTotalIPH1);
            gbSum1.Controls.Add(lblTotalBeltVolume1);
            gbSum1.Controls.Add(lblBeltTotalIsk1);
            gbSum1.Controls.Add(lblTotalHourstoFlip1);
            gbSum1.Controls.Add(lblTotalIskLevel1);
            gbSum1.Controls.Add(lblIPH1);
            gbSum1.Controls.Add(lblTotalBeltVol1);
            gbSum1.Controls.Add(lblHourstoFlip1);
            gbSum1.Location = new Point(247, 201);
            gbSum1.Name = "gbSum1";
            gbSum1.Size = new Size(243, 117);
            gbSum1.TabIndex = 77;
            gbSum1.TabStop = false;
            // 
            // lblTotalIPH1
            // 
            lblTotalIPH1.AutoSize = true;
            lblTotalIPH1.Location = new Point(18, 65);
            lblTotalIPH1.Name = "lblTotalIPH1";
            lblTotalIPH1.Size = new Size(68, 13);
            lblTotalIPH1.TabIndex = 61;
            lblTotalIPH1.Text = "Isk per Hour:";
            lblTotalIPH1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalBeltVolume1
            // 
            lblTotalBeltVolume1.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume1.Location = new Point(97, 84);
            lblTotalBeltVolume1.Name = "lblTotalBeltVolume1";
            lblTotalBeltVolume1.Size = new Size(127, 18);
            lblTotalBeltVolume1.TabIndex = 60;
            lblTotalBeltVolume1.Text = "100,000.00";
            lblTotalBeltVolume1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltTotalIsk1
            // 
            lblBeltTotalIsk1.AutoSize = true;
            lblBeltTotalIsk1.Location = new Point(18, 21);
            lblBeltTotalIsk1.Name = "lblBeltTotalIsk1";
            lblBeltTotalIsk1.Size = new Size(72, 13);
            lblBeltTotalIsk1.TabIndex = 52;
            lblBeltTotalIsk1.Text = "Belt Total Isk:";
            lblBeltTotalIsk1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip1
            // 
            lblTotalHourstoFlip1.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip1.Location = new Point(97, 40);
            lblTotalHourstoFlip1.Name = "lblTotalHourstoFlip1";
            lblTotalHourstoFlip1.Size = new Size(127, 18);
            lblTotalHourstoFlip1.TabIndex = 57;
            lblTotalHourstoFlip1.Text = "100,000.00";
            lblTotalHourstoFlip1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIskLevel1
            // 
            lblTotalIskLevel1.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel1.Location = new Point(97, 18);
            lblTotalIskLevel1.Name = "lblTotalIskLevel1";
            lblTotalIskLevel1.Size = new Size(127, 18);
            lblTotalIskLevel1.TabIndex = 53;
            lblTotalIskLevel1.Text = "100,000.00";
            lblTotalIskLevel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH1
            // 
            lblIPH1.BorderStyle = BorderStyle.FixedSingle;
            lblIPH1.Location = new Point(97, 62);
            lblIPH1.Name = "lblIPH1";
            lblIPH1.Size = new Size(127, 18);
            lblIPH1.TabIndex = 59;
            lblIPH1.Text = "100,000.00";
            lblIPH1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBeltVol1
            // 
            lblTotalBeltVol1.AutoSize = true;
            lblTotalBeltVol1.Location = new Point(18, 87);
            lblTotalBeltVol1.Name = "lblTotalBeltVol1";
            lblTotalBeltVol1.Size = new Size(73, 13);
            lblTotalBeltVol1.TabIndex = 54;
            lblTotalBeltVol1.Text = "Belt Total Vol:";
            lblTotalBeltVol1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHourstoFlip1
            // 
            lblHourstoFlip1.AutoSize = true;
            lblHourstoFlip1.Location = new Point(18, 43);
            lblHourstoFlip1.Name = "lblHourstoFlip1";
            lblHourstoFlip1.Size = new Size(69, 13);
            lblHourstoFlip1.TabIndex = 56;
            lblHourstoFlip1.Text = "Hours to Flip:";
            lblHourstoFlip1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSmallBeltMineralComp
            // 
            lblSmallBeltMineralComp.AutoSize = true;
            lblSmallBeltMineralComp.Location = new Point(307, 15);
            lblSmallBeltMineralComp.Name = "lblSmallBeltMineralComp";
            lblSmallBeltMineralComp.Size = new Size(122, 13);
            lblSmallBeltMineralComp.TabIndex = 60;
            lblSmallBeltMineralComp.Text = "Belt Mineral Composition";
            lblSmallBeltMineralComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabMedium
            // 
            tabMedium.Controls.Add(btnCloseMedium);
            tabMedium.Controls.Add(btnSaveSettingsMedium);
            tabMedium.Controls.Add(gbSum2);
            tabMedium.Controls.Add(lstMineralsLevel2);
            tabMedium.Controls.Add(lstOresLevel2);
            tabMedium.Controls.Add(lblMediumBeltMineralComp);
            tabMedium.Controls.Add(lblMediumBeltOreComp);
            tabMedium.Location = new Point(4, 22);
            tabMedium.Name = "tabMedium";
            tabMedium.Size = new Size(496, 621);
            tabMedium.TabIndex = 2;
            tabMedium.Text = "Medium Belt";
            tabMedium.UseVisualStyleBackColor = true;
            // 
            // btnCloseMedium
            // 
            btnCloseMedium.Location = new Point(374, 324);
            btnCloseMedium.Name = "btnCloseMedium";
            btnCloseMedium.Size = new Size(113, 28);
            btnCloseMedium.TabIndex = 16;
            btnCloseMedium.Text = "Close";
            btnCloseMedium.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettingsMedium
            // 
            btnSaveSettingsMedium.Location = new Point(248, 324);
            btnSaveSettingsMedium.Name = "btnSaveSettingsMedium";
            btnSaveSettingsMedium.Size = new Size(113, 28);
            btnSaveSettingsMedium.TabIndex = 15;
            btnSaveSettingsMedium.Text = "Save Selected Ores";
            btnSaveSettingsMedium.UseVisualStyleBackColor = true;
            // 
            // gbSum2
            // 
            gbSum2.Controls.Add(lblTotalIPH2);
            gbSum2.Controls.Add(lblTotalBeltVolume2);
            gbSum2.Controls.Add(lblBeltTotalIsk2);
            gbSum2.Controls.Add(lblTotalHourstoFlip2);
            gbSum2.Controls.Add(lblTotalIskLevel2);
            gbSum2.Controls.Add(lblIPH2);
            gbSum2.Controls.Add(lblTotalBeltVol2);
            gbSum2.Controls.Add(lblHourstoFlip2);
            gbSum2.Location = new Point(247, 201);
            gbSum2.Name = "gbSum2";
            gbSum2.Size = new Size(243, 117);
            gbSum2.TabIndex = 77;
            gbSum2.TabStop = false;
            // 
            // lblTotalIPH2
            // 
            lblTotalIPH2.AutoSize = true;
            lblTotalIPH2.Location = new Point(18, 65);
            lblTotalIPH2.Name = "lblTotalIPH2";
            lblTotalIPH2.Size = new Size(68, 13);
            lblTotalIPH2.TabIndex = 61;
            lblTotalIPH2.Text = "Isk per Hour:";
            lblTotalIPH2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalBeltVolume2
            // 
            lblTotalBeltVolume2.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume2.Location = new Point(97, 84);
            lblTotalBeltVolume2.Name = "lblTotalBeltVolume2";
            lblTotalBeltVolume2.Size = new Size(127, 18);
            lblTotalBeltVolume2.TabIndex = 60;
            lblTotalBeltVolume2.Text = "100,000.00";
            lblTotalBeltVolume2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltTotalIsk2
            // 
            lblBeltTotalIsk2.AutoSize = true;
            lblBeltTotalIsk2.Location = new Point(18, 21);
            lblBeltTotalIsk2.Name = "lblBeltTotalIsk2";
            lblBeltTotalIsk2.Size = new Size(72, 13);
            lblBeltTotalIsk2.TabIndex = 52;
            lblBeltTotalIsk2.Text = "Belt Total Isk:";
            lblBeltTotalIsk2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip2
            // 
            lblTotalHourstoFlip2.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip2.Location = new Point(97, 40);
            lblTotalHourstoFlip2.Name = "lblTotalHourstoFlip2";
            lblTotalHourstoFlip2.Size = new Size(127, 18);
            lblTotalHourstoFlip2.TabIndex = 57;
            lblTotalHourstoFlip2.Text = "100,000.00";
            lblTotalHourstoFlip2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIskLevel2
            // 
            lblTotalIskLevel2.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel2.Location = new Point(97, 18);
            lblTotalIskLevel2.Name = "lblTotalIskLevel2";
            lblTotalIskLevel2.Size = new Size(127, 18);
            lblTotalIskLevel2.TabIndex = 53;
            lblTotalIskLevel2.Text = "100,000.00";
            lblTotalIskLevel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH2
            // 
            lblIPH2.BorderStyle = BorderStyle.FixedSingle;
            lblIPH2.Location = new Point(97, 62);
            lblIPH2.Name = "lblIPH2";
            lblIPH2.Size = new Size(127, 18);
            lblIPH2.TabIndex = 59;
            lblIPH2.Text = "100,000.00";
            lblIPH2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBeltVol2
            // 
            lblTotalBeltVol2.AutoSize = true;
            lblTotalBeltVol2.Location = new Point(18, 87);
            lblTotalBeltVol2.Name = "lblTotalBeltVol2";
            lblTotalBeltVol2.Size = new Size(73, 13);
            lblTotalBeltVol2.TabIndex = 54;
            lblTotalBeltVol2.Text = "Belt Total Vol:";
            lblTotalBeltVol2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHourstoFlip2
            // 
            lblHourstoFlip2.AutoSize = true;
            lblHourstoFlip2.Location = new Point(18, 43);
            lblHourstoFlip2.Name = "lblHourstoFlip2";
            lblHourstoFlip2.Size = new Size(69, 13);
            lblHourstoFlip2.TabIndex = 56;
            lblHourstoFlip2.Text = "Hours to Flip:";
            lblHourstoFlip2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lstMineralsLevel2
            // 
            lstMineralsLevel2.Columns.AddRange(new ColumnHeader[] { mineralsMedium, minsunitsMedium, totaliskMedium });
            lstMineralsLevel2.FullRowSelect = true;
            lstMineralsLevel2.GridLines = true;
            lstMineralsLevel2.HideSelection = false;
            lstMineralsLevel2.Location = new Point(247, 30);
            lstMineralsLevel2.MultiSelect = false;
            lstMineralsLevel2.Name = "lstMineralsLevel2";
            lstMineralsLevel2.Size = new Size(243, 165);
            lstMineralsLevel2.TabIndex = 64;
            lstMineralsLevel2.UseCompatibleStateImageBehavior = false;
            lstMineralsLevel2.View = View.Details;
            // 
            // mineralsMedium
            // 
            mineralsMedium.Text = "Mineral";
            mineralsMedium.Width = 57;
            // 
            // minsunitsMedium
            // 
            minsunitsMedium.Text = "Units";
            minsunitsMedium.TextAlign = HorizontalAlignment.Right;
            minsunitsMedium.Width = 79;
            // 
            // totaliskMedium
            // 
            totaliskMedium.Text = "Total Isk";
            totaliskMedium.TextAlign = HorizontalAlignment.Right;
            totaliskMedium.Width = 103;
            // 
            // lstOresLevel2
            // 
            lstOresLevel2.CheckBoxes = true;
            lstOresLevel2.Columns.AddRange(new ColumnHeader[] { checkboxMedium, orenameMedium, numberroidsMedium, unitsMedium });
            lstOresLevel2.FullRowSelect = true;
            lstOresLevel2.GridLines = true;
            lstOresLevel2.HideSelection = false;
            lstOresLevel2.Location = new Point(6, 30);
            lstOresLevel2.MultiSelect = false;
            lstOresLevel2.Name = "lstOresLevel2";
            lstOresLevel2.Size = new Size(235, 322);
            lstOresLevel2.TabIndex = 63;
            lstOresLevel2.UseCompatibleStateImageBehavior = false;
            lstOresLevel2.View = View.Details;
            // 
            // checkboxMedium
            // 
            checkboxMedium.Text = "";
            checkboxMedium.Width = 25;
            // 
            // orenameMedium
            // 
            orenameMedium.Text = "Ore";
            orenameMedium.Width = 100;
            // 
            // numberroidsMedium
            // 
            numberroidsMedium.Text = "Rocks";
            numberroidsMedium.TextAlign = HorizontalAlignment.Center;
            numberroidsMedium.Width = 43;
            // 
            // unitsMedium
            // 
            unitsMedium.Text = "Units";
            unitsMedium.TextAlign = HorizontalAlignment.Right;
            unitsMedium.Width = 63;
            // 
            // lblMediumBeltMineralComp
            // 
            lblMediumBeltMineralComp.AutoSize = true;
            lblMediumBeltMineralComp.Location = new Point(307, 15);
            lblMediumBeltMineralComp.Name = "lblMediumBeltMineralComp";
            lblMediumBeltMineralComp.Size = new Size(122, 13);
            lblMediumBeltMineralComp.TabIndex = 62;
            lblMediumBeltMineralComp.Text = "Belt Mineral Composition";
            lblMediumBeltMineralComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMediumBeltOreComp
            // 
            lblMediumBeltOreComp.AutoSize = true;
            lblMediumBeltOreComp.Location = new Point(71, 15);
            lblMediumBeltOreComp.Name = "lblMediumBeltOreComp";
            lblMediumBeltOreComp.Size = new Size(105, 13);
            lblMediumBeltOreComp.TabIndex = 61;
            lblMediumBeltOreComp.Text = "Belt Ore Composition";
            lblMediumBeltOreComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabLarge
            // 
            tabLarge.Controls.Add(btnCloseLarge);
            tabLarge.Controls.Add(btnSaveSettingsLarge);
            tabLarge.Controls.Add(gbSum3);
            tabLarge.Controls.Add(lblLargeBeltMineralComp);
            tabLarge.Controls.Add(lstOresLevel3);
            tabLarge.Controls.Add(lstMineralsLevel3);
            tabLarge.Controls.Add(lblLargeBeltOreComp);
            tabLarge.Location = new Point(4, 22);
            tabLarge.Name = "tabLarge";
            tabLarge.Size = new Size(496, 621);
            tabLarge.TabIndex = 3;
            tabLarge.Text = "Large Belt";
            tabLarge.UseVisualStyleBackColor = true;
            // 
            // btnCloseLarge
            // 
            btnCloseLarge.Location = new Point(374, 324);
            btnCloseLarge.Name = "btnCloseLarge";
            btnCloseLarge.Size = new Size(113, 28);
            btnCloseLarge.TabIndex = 18;
            btnCloseLarge.Text = "Close";
            btnCloseLarge.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettingsLarge
            // 
            btnSaveSettingsLarge.Location = new Point(248, 324);
            btnSaveSettingsLarge.Name = "btnSaveSettingsLarge";
            btnSaveSettingsLarge.Size = new Size(113, 28);
            btnSaveSettingsLarge.TabIndex = 17;
            btnSaveSettingsLarge.Text = "Save Selected Ores";
            btnSaveSettingsLarge.UseVisualStyleBackColor = true;
            // 
            // gbSum3
            // 
            gbSum3.Controls.Add(lblTotalIPH3);
            gbSum3.Controls.Add(lblTotalBeltVolume3);
            gbSum3.Controls.Add(lblBeltTotalIsk3);
            gbSum3.Controls.Add(lblTotalHourstoFlip3);
            gbSum3.Controls.Add(lblTotalIskLevel3);
            gbSum3.Controls.Add(lblIPH3);
            gbSum3.Controls.Add(lblTotalBeltVol3);
            gbSum3.Controls.Add(lblHourstoFlip3);
            gbSum3.Location = new Point(247, 201);
            gbSum3.Name = "gbSum3";
            gbSum3.Size = new Size(243, 117);
            gbSum3.TabIndex = 77;
            gbSum3.TabStop = false;
            // 
            // lblTotalIPH3
            // 
            lblTotalIPH3.AutoSize = true;
            lblTotalIPH3.Location = new Point(18, 65);
            lblTotalIPH3.Name = "lblTotalIPH3";
            lblTotalIPH3.Size = new Size(68, 13);
            lblTotalIPH3.TabIndex = 61;
            lblTotalIPH3.Text = "Isk per Hour:";
            lblTotalIPH3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalBeltVolume3
            // 
            lblTotalBeltVolume3.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume3.Location = new Point(97, 84);
            lblTotalBeltVolume3.Name = "lblTotalBeltVolume3";
            lblTotalBeltVolume3.Size = new Size(127, 18);
            lblTotalBeltVolume3.TabIndex = 60;
            lblTotalBeltVolume3.Text = "100,000.00";
            lblTotalBeltVolume3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltTotalIsk3
            // 
            lblBeltTotalIsk3.AutoSize = true;
            lblBeltTotalIsk3.Location = new Point(18, 21);
            lblBeltTotalIsk3.Name = "lblBeltTotalIsk3";
            lblBeltTotalIsk3.Size = new Size(72, 13);
            lblBeltTotalIsk3.TabIndex = 52;
            lblBeltTotalIsk3.Text = "Belt Total Isk:";
            lblBeltTotalIsk3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip3
            // 
            lblTotalHourstoFlip3.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip3.Location = new Point(97, 40);
            lblTotalHourstoFlip3.Name = "lblTotalHourstoFlip3";
            lblTotalHourstoFlip3.Size = new Size(127, 18);
            lblTotalHourstoFlip3.TabIndex = 57;
            lblTotalHourstoFlip3.Text = "100,000.00";
            lblTotalHourstoFlip3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIskLevel3
            // 
            lblTotalIskLevel3.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel3.Location = new Point(97, 18);
            lblTotalIskLevel3.Name = "lblTotalIskLevel3";
            lblTotalIskLevel3.Size = new Size(127, 18);
            lblTotalIskLevel3.TabIndex = 53;
            lblTotalIskLevel3.Text = "100,000.00";
            lblTotalIskLevel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH3
            // 
            lblIPH3.BorderStyle = BorderStyle.FixedSingle;
            lblIPH3.Location = new Point(97, 62);
            lblIPH3.Name = "lblIPH3";
            lblIPH3.Size = new Size(127, 18);
            lblIPH3.TabIndex = 59;
            lblIPH3.Text = "100,000.00";
            lblIPH3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBeltVol3
            // 
            lblTotalBeltVol3.AutoSize = true;
            lblTotalBeltVol3.Location = new Point(18, 87);
            lblTotalBeltVol3.Name = "lblTotalBeltVol3";
            lblTotalBeltVol3.Size = new Size(73, 13);
            lblTotalBeltVol3.TabIndex = 54;
            lblTotalBeltVol3.Text = "Belt Total Vol:";
            lblTotalBeltVol3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHourstoFlip3
            // 
            lblHourstoFlip3.AutoSize = true;
            lblHourstoFlip3.Location = new Point(18, 43);
            lblHourstoFlip3.Name = "lblHourstoFlip3";
            lblHourstoFlip3.Size = new Size(69, 13);
            lblHourstoFlip3.TabIndex = 56;
            lblHourstoFlip3.Text = "Hours to Flip:";
            lblHourstoFlip3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLargeBeltMineralComp
            // 
            lblLargeBeltMineralComp.AutoSize = true;
            lblLargeBeltMineralComp.Location = new Point(307, 15);
            lblLargeBeltMineralComp.Name = "lblLargeBeltMineralComp";
            lblLargeBeltMineralComp.Size = new Size(122, 13);
            lblLargeBeltMineralComp.TabIndex = 65;
            lblLargeBeltMineralComp.Text = "Belt Mineral Composition";
            lblLargeBeltMineralComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // lstOresLevel3
            // 
            lstOresLevel3.CheckBoxes = true;
            lstOresLevel3.Columns.AddRange(new ColumnHeader[] { checkboxLarge, orenameLarge, numberroidsLarge, unitsLarge });
            lstOresLevel3.FullRowSelect = true;
            lstOresLevel3.GridLines = true;
            lstOresLevel3.HideSelection = false;
            lstOresLevel3.Location = new Point(6, 30);
            lstOresLevel3.MultiSelect = false;
            lstOresLevel3.Name = "lstOresLevel3";
            lstOresLevel3.Size = new Size(235, 322);
            lstOresLevel3.TabIndex = 62;
            lstOresLevel3.UseCompatibleStateImageBehavior = false;
            lstOresLevel3.View = View.Details;
            // 
            // checkboxLarge
            // 
            checkboxLarge.Text = "";
            checkboxLarge.Width = 25;
            // 
            // orenameLarge
            // 
            orenameLarge.Text = "Ore";
            orenameLarge.Width = 100;
            // 
            // numberroidsLarge
            // 
            numberroidsLarge.Text = "Rocks";
            numberroidsLarge.TextAlign = HorizontalAlignment.Center;
            numberroidsLarge.Width = 43;
            // 
            // unitsLarge
            // 
            unitsLarge.Text = "Units";
            unitsLarge.TextAlign = HorizontalAlignment.Right;
            unitsLarge.Width = 63;
            // 
            // lstMineralsLevel3
            // 
            lstMineralsLevel3.Columns.AddRange(new ColumnHeader[] { mineralsLarge, minsunitsLarge, totaliskLarge });
            lstMineralsLevel3.FullRowSelect = true;
            lstMineralsLevel3.GridLines = true;
            lstMineralsLevel3.HideSelection = false;
            lstMineralsLevel3.Location = new Point(247, 30);
            lstMineralsLevel3.MultiSelect = false;
            lstMineralsLevel3.Name = "lstMineralsLevel3";
            lstMineralsLevel3.Size = new Size(243, 165);
            lstMineralsLevel3.TabIndex = 63;
            lstMineralsLevel3.UseCompatibleStateImageBehavior = false;
            lstMineralsLevel3.View = View.Details;
            // 
            // mineralsLarge
            // 
            mineralsLarge.Text = "Mineral";
            mineralsLarge.Width = 57;
            // 
            // minsunitsLarge
            // 
            minsunitsLarge.Text = "Units";
            minsunitsLarge.TextAlign = HorizontalAlignment.Right;
            minsunitsLarge.Width = 79;
            // 
            // totaliskLarge
            // 
            totaliskLarge.Text = "Total Isk";
            totaliskLarge.TextAlign = HorizontalAlignment.Right;
            totaliskLarge.Width = 103;
            // 
            // lblLargeBeltOreComp
            // 
            lblLargeBeltOreComp.AutoSize = true;
            lblLargeBeltOreComp.Location = new Point(71, 15);
            lblLargeBeltOreComp.Name = "lblLargeBeltOreComp";
            lblLargeBeltOreComp.Size = new Size(105, 13);
            lblLargeBeltOreComp.TabIndex = 64;
            lblLargeBeltOreComp.Text = "Belt Ore Composition";
            lblLargeBeltOreComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabEnormous
            // 
            tabEnormous.Controls.Add(btnCloseXL);
            tabEnormous.Controls.Add(btnSaveSettingsXLarge);
            tabEnormous.Controls.Add(gbSum4);
            tabEnormous.Controls.Add(lblXLBeltMineralComp);
            tabEnormous.Controls.Add(lstOresLevel4);
            tabEnormous.Controls.Add(lstMineralsLevel4);
            tabEnormous.Controls.Add(lblXLBeltOreComp);
            tabEnormous.Location = new Point(4, 22);
            tabEnormous.Name = "tabEnormous";
            tabEnormous.Size = new Size(496, 621);
            tabEnormous.TabIndex = 5;
            tabEnormous.Text = "Enormous Belt";
            tabEnormous.UseVisualStyleBackColor = true;
            // 
            // btnCloseXL
            // 
            btnCloseXL.Location = new Point(374, 324);
            btnCloseXL.Name = "btnCloseXL";
            btnCloseXL.Size = new Size(113, 28);
            btnCloseXL.TabIndex = 20;
            btnCloseXL.Text = "Close";
            btnCloseXL.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettingsXLarge
            // 
            btnSaveSettingsXLarge.Location = new Point(248, 324);
            btnSaveSettingsXLarge.Name = "btnSaveSettingsXLarge";
            btnSaveSettingsXLarge.Size = new Size(113, 28);
            btnSaveSettingsXLarge.TabIndex = 19;
            btnSaveSettingsXLarge.Text = "Save Selected Ores";
            btnSaveSettingsXLarge.UseVisualStyleBackColor = true;
            // 
            // gbSum4
            // 
            gbSum4.Controls.Add(lblTotalIPH4);
            gbSum4.Controls.Add(lblTotalBeltVolume4);
            gbSum4.Controls.Add(lblBeltTotalIsk4);
            gbSum4.Controls.Add(lblTotalHourstoFlip4);
            gbSum4.Controls.Add(lblTotalIskLevel4);
            gbSum4.Controls.Add(lblIPH4);
            gbSum4.Controls.Add(lblTotalBeltVol4);
            gbSum4.Controls.Add(lblHourstoFlip4);
            gbSum4.Location = new Point(247, 201);
            gbSum4.Name = "gbSum4";
            gbSum4.Size = new Size(243, 117);
            gbSum4.TabIndex = 77;
            gbSum4.TabStop = false;
            // 
            // lblTotalIPH4
            // 
            lblTotalIPH4.AutoSize = true;
            lblTotalIPH4.Location = new Point(18, 65);
            lblTotalIPH4.Name = "lblTotalIPH4";
            lblTotalIPH4.Size = new Size(68, 13);
            lblTotalIPH4.TabIndex = 61;
            lblTotalIPH4.Text = "Isk per Hour:";
            lblTotalIPH4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalBeltVolume4
            // 
            lblTotalBeltVolume4.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume4.Location = new Point(97, 84);
            lblTotalBeltVolume4.Name = "lblTotalBeltVolume4";
            lblTotalBeltVolume4.Size = new Size(127, 18);
            lblTotalBeltVolume4.TabIndex = 60;
            lblTotalBeltVolume4.Text = "100,000.00";
            lblTotalBeltVolume4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltTotalIsk4
            // 
            lblBeltTotalIsk4.AutoSize = true;
            lblBeltTotalIsk4.Location = new Point(18, 21);
            lblBeltTotalIsk4.Name = "lblBeltTotalIsk4";
            lblBeltTotalIsk4.Size = new Size(72, 13);
            lblBeltTotalIsk4.TabIndex = 52;
            lblBeltTotalIsk4.Text = "Belt Total Isk:";
            lblBeltTotalIsk4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip4
            // 
            lblTotalHourstoFlip4.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip4.Location = new Point(97, 40);
            lblTotalHourstoFlip4.Name = "lblTotalHourstoFlip4";
            lblTotalHourstoFlip4.Size = new Size(127, 18);
            lblTotalHourstoFlip4.TabIndex = 57;
            lblTotalHourstoFlip4.Text = "100,000.00";
            lblTotalHourstoFlip4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIskLevel4
            // 
            lblTotalIskLevel4.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel4.Location = new Point(97, 18);
            lblTotalIskLevel4.Name = "lblTotalIskLevel4";
            lblTotalIskLevel4.Size = new Size(127, 18);
            lblTotalIskLevel4.TabIndex = 53;
            lblTotalIskLevel4.Text = "100,000.00";
            lblTotalIskLevel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH4
            // 
            lblIPH4.BorderStyle = BorderStyle.FixedSingle;
            lblIPH4.Location = new Point(97, 62);
            lblIPH4.Name = "lblIPH4";
            lblIPH4.Size = new Size(127, 18);
            lblIPH4.TabIndex = 59;
            lblIPH4.Text = "100,000.00";
            lblIPH4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBeltVol4
            // 
            lblTotalBeltVol4.AutoSize = true;
            lblTotalBeltVol4.Location = new Point(18, 87);
            lblTotalBeltVol4.Name = "lblTotalBeltVol4";
            lblTotalBeltVol4.Size = new Size(73, 13);
            lblTotalBeltVol4.TabIndex = 54;
            lblTotalBeltVol4.Text = "Belt Total Vol:";
            lblTotalBeltVol4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHourstoFlip4
            // 
            lblHourstoFlip4.AutoSize = true;
            lblHourstoFlip4.Location = new Point(18, 43);
            lblHourstoFlip4.Name = "lblHourstoFlip4";
            lblHourstoFlip4.Size = new Size(69, 13);
            lblHourstoFlip4.TabIndex = 56;
            lblHourstoFlip4.Text = "Hours to Flip:";
            lblHourstoFlip4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblXLBeltMineralComp
            // 
            lblXLBeltMineralComp.AutoSize = true;
            lblXLBeltMineralComp.Location = new Point(307, 15);
            lblXLBeltMineralComp.Name = "lblXLBeltMineralComp";
            lblXLBeltMineralComp.Size = new Size(122, 13);
            lblXLBeltMineralComp.TabIndex = 70;
            lblXLBeltMineralComp.Text = "Belt Mineral Composition";
            lblXLBeltMineralComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // lstOresLevel4
            // 
            lstOresLevel4.CheckBoxes = true;
            lstOresLevel4.Columns.AddRange(new ColumnHeader[] { checkboxXL, orenameXL, numberroidsXL, unitsXL });
            lstOresLevel4.FullRowSelect = true;
            lstOresLevel4.GridLines = true;
            lstOresLevel4.HideSelection = false;
            lstOresLevel4.Location = new Point(6, 30);
            lstOresLevel4.MultiSelect = false;
            lstOresLevel4.Name = "lstOresLevel4";
            lstOresLevel4.Size = new Size(235, 322);
            lstOresLevel4.TabIndex = 67;
            lstOresLevel4.UseCompatibleStateImageBehavior = false;
            lstOresLevel4.View = View.Details;
            // 
            // checkboxXL
            // 
            checkboxXL.Text = "";
            checkboxXL.Width = 25;
            // 
            // orenameXL
            // 
            orenameXL.Text = "Ore";
            orenameXL.Width = 100;
            // 
            // numberroidsXL
            // 
            numberroidsXL.Text = "Rocks";
            numberroidsXL.TextAlign = HorizontalAlignment.Center;
            numberroidsXL.Width = 43;
            // 
            // unitsXL
            // 
            unitsXL.Text = "Units";
            unitsXL.TextAlign = HorizontalAlignment.Right;
            unitsXL.Width = 63;
            // 
            // lstMineralsLevel4
            // 
            lstMineralsLevel4.Columns.AddRange(new ColumnHeader[] { mineralsXL, minsunitsXL, totaliskXL });
            lstMineralsLevel4.FullRowSelect = true;
            lstMineralsLevel4.GridLines = true;
            lstMineralsLevel4.HideSelection = false;
            lstMineralsLevel4.Location = new Point(247, 30);
            lstMineralsLevel4.MultiSelect = false;
            lstMineralsLevel4.Name = "lstMineralsLevel4";
            lstMineralsLevel4.Size = new Size(243, 165);
            lstMineralsLevel4.TabIndex = 68;
            lstMineralsLevel4.UseCompatibleStateImageBehavior = false;
            lstMineralsLevel4.View = View.Details;
            // 
            // mineralsXL
            // 
            mineralsXL.Text = "Mineral";
            mineralsXL.Width = 57;
            // 
            // minsunitsXL
            // 
            minsunitsXL.Text = "Units";
            minsunitsXL.TextAlign = HorizontalAlignment.Right;
            minsunitsXL.Width = 79;
            // 
            // totaliskXL
            // 
            totaliskXL.Text = "Total Isk";
            totaliskXL.TextAlign = HorizontalAlignment.Right;
            totaliskXL.Width = 103;
            // 
            // lblXLBeltOreComp
            // 
            lblXLBeltOreComp.AutoSize = true;
            lblXLBeltOreComp.Location = new Point(71, 15);
            lblXLBeltOreComp.Name = "lblXLBeltOreComp";
            lblXLBeltOreComp.Size = new Size(105, 13);
            lblXLBeltOreComp.TabIndex = 69;
            lblXLBeltOreComp.Text = "Belt Ore Composition";
            lblXLBeltOreComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabColossal
            // 
            tabColossal.Controls.Add(btnCloseGiant);
            tabColossal.Controls.Add(btnSaveSettingsGiant);
            tabColossal.Controls.Add(gbSum5);
            tabColossal.Controls.Add(lblGiantBeltMineralComp);
            tabColossal.Controls.Add(lstOresLevel5);
            tabColossal.Controls.Add(lstMineralsLevel5);
            tabColossal.Controls.Add(lblGiantBeltOreComp);
            tabColossal.Location = new Point(4, 22);
            tabColossal.Name = "tabColossal";
            tabColossal.Size = new Size(496, 621);
            tabColossal.TabIndex = 4;
            tabColossal.Text = "Colossal Belt";
            tabColossal.UseVisualStyleBackColor = true;
            // 
            // btnCloseGiant
            // 
            btnCloseGiant.Location = new Point(374, 324);
            btnCloseGiant.Name = "btnCloseGiant";
            btnCloseGiant.Size = new Size(113, 28);
            btnCloseGiant.TabIndex = 22;
            btnCloseGiant.Text = "Close";
            btnCloseGiant.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettingsGiant
            // 
            btnSaveSettingsGiant.Location = new Point(248, 324);
            btnSaveSettingsGiant.Name = "btnSaveSettingsGiant";
            btnSaveSettingsGiant.Size = new Size(113, 28);
            btnSaveSettingsGiant.TabIndex = 21;
            btnSaveSettingsGiant.Text = "Save Selected Ores";
            btnSaveSettingsGiant.UseVisualStyleBackColor = true;
            // 
            // gbSum5
            // 
            gbSum5.Controls.Add(lblTotalIPH5);
            gbSum5.Controls.Add(lblTotalBeltVolume5);
            gbSum5.Controls.Add(lblBeltTotalIsk5);
            gbSum5.Controls.Add(lblTotalHourstoFlip5);
            gbSum5.Controls.Add(lblTotalIskLevel5);
            gbSum5.Controls.Add(lblIPH5);
            gbSum5.Controls.Add(lblTotalBeltVol5);
            gbSum5.Controls.Add(lblHourstoFlip5);
            gbSum5.Location = new Point(247, 201);
            gbSum5.Name = "gbSum5";
            gbSum5.Size = new Size(243, 117);
            gbSum5.TabIndex = 76;
            gbSum5.TabStop = false;
            // 
            // lblTotalIPH5
            // 
            lblTotalIPH5.AutoSize = true;
            lblTotalIPH5.Location = new Point(18, 65);
            lblTotalIPH5.Name = "lblTotalIPH5";
            lblTotalIPH5.Size = new Size(68, 13);
            lblTotalIPH5.TabIndex = 61;
            lblTotalIPH5.Text = "Isk per Hour:";
            lblTotalIPH5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalBeltVolume5
            // 
            lblTotalBeltVolume5.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume5.Location = new Point(97, 84);
            lblTotalBeltVolume5.Name = "lblTotalBeltVolume5";
            lblTotalBeltVolume5.Size = new Size(127, 18);
            lblTotalBeltVolume5.TabIndex = 60;
            lblTotalBeltVolume5.Text = "100,000.00";
            lblTotalBeltVolume5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBeltTotalIsk5
            // 
            lblBeltTotalIsk5.AutoSize = true;
            lblBeltTotalIsk5.Location = new Point(18, 21);
            lblBeltTotalIsk5.Name = "lblBeltTotalIsk5";
            lblBeltTotalIsk5.Size = new Size(72, 13);
            lblBeltTotalIsk5.TabIndex = 52;
            lblBeltTotalIsk5.Text = "Belt Total Isk:";
            lblBeltTotalIsk5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip5
            // 
            lblTotalHourstoFlip5.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip5.Location = new Point(97, 40);
            lblTotalHourstoFlip5.Name = "lblTotalHourstoFlip5";
            lblTotalHourstoFlip5.Size = new Size(127, 18);
            lblTotalHourstoFlip5.TabIndex = 57;
            lblTotalHourstoFlip5.Text = "100,000.00";
            lblTotalHourstoFlip5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIskLevel5
            // 
            lblTotalIskLevel5.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIskLevel5.Location = new Point(97, 18);
            lblTotalIskLevel5.Name = "lblTotalIskLevel5";
            lblTotalIskLevel5.Size = new Size(127, 18);
            lblTotalIskLevel5.TabIndex = 53;
            lblTotalIskLevel5.Text = "100,000.00";
            lblTotalIskLevel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblIPH5
            // 
            lblIPH5.BorderStyle = BorderStyle.FixedSingle;
            lblIPH5.Location = new Point(97, 62);
            lblIPH5.Name = "lblIPH5";
            lblIPH5.Size = new Size(127, 18);
            lblIPH5.TabIndex = 59;
            lblIPH5.Text = "100,000.00";
            lblIPH5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBeltVol5
            // 
            lblTotalBeltVol5.AutoSize = true;
            lblTotalBeltVol5.Location = new Point(18, 87);
            lblTotalBeltVol5.Name = "lblTotalBeltVol5";
            lblTotalBeltVol5.Size = new Size(73, 13);
            lblTotalBeltVol5.TabIndex = 54;
            lblTotalBeltVol5.Text = "Belt Total Vol:";
            lblTotalBeltVol5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHourstoFlip5
            // 
            lblHourstoFlip5.AutoSize = true;
            lblHourstoFlip5.Location = new Point(18, 43);
            lblHourstoFlip5.Name = "lblHourstoFlip5";
            lblHourstoFlip5.Size = new Size(69, 13);
            lblHourstoFlip5.TabIndex = 56;
            lblHourstoFlip5.Text = "Hours to Flip:";
            lblHourstoFlip5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGiantBeltMineralComp
            // 
            lblGiantBeltMineralComp.AutoSize = true;
            lblGiantBeltMineralComp.Location = new Point(307, 15);
            lblGiantBeltMineralComp.Name = "lblGiantBeltMineralComp";
            lblGiantBeltMineralComp.Size = new Size(122, 13);
            lblGiantBeltMineralComp.TabIndex = 75;
            lblGiantBeltMineralComp.Text = "Belt Mineral Composition";
            lblGiantBeltMineralComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // lstOresLevel5
            // 
            lstOresLevel5.CheckBoxes = true;
            lstOresLevel5.Columns.AddRange(new ColumnHeader[] { checkboxGiant, orenameGiant, numberroidsGiant, unitsGiant });
            lstOresLevel5.FullRowSelect = true;
            lstOresLevel5.GridLines = true;
            lstOresLevel5.HideSelection = false;
            lstOresLevel5.Location = new Point(6, 30);
            lstOresLevel5.MultiSelect = false;
            lstOresLevel5.Name = "lstOresLevel5";
            lstOresLevel5.Size = new Size(235, 322);
            lstOresLevel5.TabIndex = 72;
            lstOresLevel5.UseCompatibleStateImageBehavior = false;
            lstOresLevel5.View = View.Details;
            // 
            // checkboxGiant
            // 
            checkboxGiant.Text = "";
            checkboxGiant.Width = 25;
            // 
            // orenameGiant
            // 
            orenameGiant.Text = "Ore";
            orenameGiant.Width = 100;
            // 
            // numberroidsGiant
            // 
            numberroidsGiant.Text = "Rocks";
            numberroidsGiant.TextAlign = HorizontalAlignment.Center;
            numberroidsGiant.Width = 43;
            // 
            // unitsGiant
            // 
            unitsGiant.Text = "Units";
            unitsGiant.TextAlign = HorizontalAlignment.Right;
            unitsGiant.Width = 63;
            // 
            // lstMineralsLevel5
            // 
            lstMineralsLevel5.Columns.AddRange(new ColumnHeader[] { mineralsGiant, minsunitsGiant, totaliskGiant });
            lstMineralsLevel5.FullRowSelect = true;
            lstMineralsLevel5.GridLines = true;
            lstMineralsLevel5.HideSelection = false;
            lstMineralsLevel5.Location = new Point(247, 30);
            lstMineralsLevel5.MultiSelect = false;
            lstMineralsLevel5.Name = "lstMineralsLevel5";
            lstMineralsLevel5.Size = new Size(243, 165);
            lstMineralsLevel5.TabIndex = 73;
            lstMineralsLevel5.UseCompatibleStateImageBehavior = false;
            lstMineralsLevel5.View = View.Details;
            // 
            // mineralsGiant
            // 
            mineralsGiant.Text = "Mineral";
            mineralsGiant.Width = 57;
            // 
            // minsunitsGiant
            // 
            minsunitsGiant.Text = "Units";
            minsunitsGiant.TextAlign = HorizontalAlignment.Right;
            minsunitsGiant.Width = 79;
            // 
            // totaliskGiant
            // 
            totaliskGiant.Text = "Total Isk";
            totaliskGiant.TextAlign = HorizontalAlignment.Right;
            totaliskGiant.Width = 103;
            // 
            // lblGiantBeltOreComp
            // 
            lblGiantBeltOreComp.AutoSize = true;
            lblGiantBeltOreComp.Location = new Point(71, 15);
            lblGiantBeltOreComp.Name = "lblGiantBeltOreComp";
            lblGiantBeltOreComp.Size = new Size(105, 13);
            lblGiantBeltOreComp.TabIndex = 74;
            lblGiantBeltOreComp.Text = "Belt Ore Composition";
            lblGiantBeltOreComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // ttMain
            // 
            ttMain.IsBalloon = true;
            // 
            // frmIndustryBeltFlip
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(519, 661);
            Controls.Add(tabIndustryBelts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmIndustryBeltFlip";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Industry Upgrade Belts";
            gbMineTaxBroker.ResumeLayout(false);
            gbMineTaxBroker.PerformLayout();
            tabIndustryBelts.ResumeLayout(false);
            tabSummary.ResumeLayout(false);
            gbGiant.ResumeLayout(false);
            gbGiant.PerformLayout();
            gbExtraLarge.ResumeLayout(false);
            gbExtraLarge.PerformLayout();
            gbLarge.ResumeLayout(false);
            gbLarge.PerformLayout();
            gbModerate.ResumeLayout(false);
            gbModerate.PerformLayout();
            gbSmall.ResumeLayout(false);
            gbSmall.PerformLayout();
            gbSummarySettings.ResumeLayout(false);
            gbSummarySettings.PerformLayout();
            gbTruesec.ResumeLayout(false);
            gbTruesec.PerformLayout();
            tabSmall.ResumeLayout(false);
            tabSmall.PerformLayout();
            gbSum1.ResumeLayout(false);
            gbSum1.PerformLayout();
            tabMedium.ResumeLayout(false);
            tabMedium.PerformLayout();
            gbSum2.ResumeLayout(false);
            gbSum2.PerformLayout();
            tabLarge.ResumeLayout(false);
            tabLarge.PerformLayout();
            gbSum3.ResumeLayout(false);
            gbSum3.PerformLayout();
            tabEnormous.ResumeLayout(false);
            tabEnormous.PerformLayout();
            gbSum4.ResumeLayout(false);
            gbSum4.PerformLayout();
            tabColossal.ResumeLayout(false);
            tabColossal.PerformLayout();
            gbSum5.ResumeLayout(false);
            gbSum5.PerformLayout();
            Shown += new EventHandler(frmIndustryBeltFlip_Shown);
            Disposed += new EventHandler(frmIndustryBeltFlip_Disposed);
            ResumeLayout(false);

        }
        internal ListView lstOresLevel1;
        internal ListView lstMineralsLevel1;
        internal ColumnHeader orenameSmall;
        internal ColumnHeader unitsSmall;
        internal ColumnHeader numberroidsSmall;
        internal ColumnHeader mineralsSmall;
        internal ColumnHeader minsunitsSmall;
        internal ColumnHeader totaliskSmall;
        internal Label lblSmallBeltOreComp;
        internal Label lblBeltTotalIskLevel1Sum;
        internal Label lblTotalIskLevel1Sum;
        internal ColumnHeader checkboxSmall;
        internal GroupBox gbMineTaxBroker;
        internal CheckBox chkIncludeTaxes;
        internal CheckBox chkBrokerFees;
        internal Label lblTotalBeltVolume1Sum;
        internal Label lblBeltVolume1Sum;
        internal Label lblTotalHourstoFlip1Sum;
        internal Label lblHourstoFlip1Sum;
        internal Label lblTotalIPH1Sum;
        internal Label lblIPH1Sum;
        internal Button btnClose;
        internal Button btnSaveSettings;
        internal Label lblCycleTime;
        internal TextBox txtCycleTime;
        internal Label lblm3perCycle;
        internal TextBox txtm3perCycle;
        internal Label lblNumMiners;
        internal ComboBox cmbNumMiners;
        internal Label lblm3perhrperminer1;
        internal Label lblm3perhrperminer;
        internal TabControl tabIndustryBelts;
        internal TabPage tabSummary;
        internal TabPage tabSmall;
        internal TabPage tabMedium;
        internal TabPage tabLarge;
        internal TabPage tabEnormous;
        internal TabPage tabColossal;
        internal GroupBox gbSummarySettings;
        internal GroupBox gbGiant;
        internal Label lblTotalBeltVolume5Sum;
        internal Label lblIPH5Sum;
        internal Label lblTotalHourstoFlip5Sum;
        internal Label lblTotalIPH5Sum;
        internal Label lblHourstoFlip5Sum;
        internal Label lblBeltVolume5Sum;
        internal Label lblTotalIskLevel5Sum;
        internal Label lblBeltTotalIskLevel5Sum;
        internal GroupBox gbExtraLarge;
        internal Label lblTotalBeltVolume4Sum;
        internal Label lblIPH4Sum;
        internal Label lblTotalHourstoFlip4Sum;
        internal Label lblTotalIPH4Sum;
        internal Label lblHourstoFlip4Sum;
        internal Label lblBeltVolume4Sum;
        internal Label lblTotalIskLevel4Sum;
        internal Label lblBeltTotalIskLevel4Sum;
        internal GroupBox gbLarge;
        internal Label lblTotalBeltVolume3Sum;
        internal Label lblIPH3Sum;
        internal Label lblTotalHourstoFlip3Sum;
        internal Label lblTotalIPH3Sum;
        internal Label lblHourstoFlip3Sum;
        internal Label lblBeltVolume3Sum;
        internal Label lblTotalIskLevel3Sum;
        internal Label lblBeltTotalIskLevel3Sum;
        internal GroupBox gbModerate;
        internal Label lblTotalBeltVolume2Sum;
        internal Label lblIPH2Sum;
        internal Label lblTotalHourstoFlip2Sum;
        internal Label lblTotalIPH2Sum;
        internal Label lblHourstoFlip2Sum;
        internal Label lblBeltVolume2Sum;
        internal Label lblTotalIskLevel2Sum;
        internal Label lblBeltTotalIskLevel2Sum;
        internal GroupBox gbSmall;
        internal Label lblSmallBeltMineralComp;
        internal ListView lstMineralsLevel2;
        internal ColumnHeader mineralsMedium;
        internal ColumnHeader minsunitsMedium;
        internal ColumnHeader totaliskMedium;
        internal ListView lstOresLevel2;
        internal ColumnHeader checkboxMedium;
        internal ColumnHeader orenameMedium;
        internal ColumnHeader numberroidsMedium;
        internal ColumnHeader unitsMedium;
        internal Label lblMediumBeltMineralComp;
        internal Label lblMediumBeltOreComp;
        internal Label lblLargeBeltMineralComp;
        internal ListView lstOresLevel3;
        internal ColumnHeader checkboxLarge;
        internal ColumnHeader orenameLarge;
        internal ColumnHeader numberroidsLarge;
        internal ColumnHeader unitsLarge;
        internal ListView lstMineralsLevel3;
        internal ColumnHeader mineralsLarge;
        internal ColumnHeader minsunitsLarge;
        internal ColumnHeader totaliskLarge;
        internal Label lblLargeBeltOreComp;
        internal Label lblXLBeltMineralComp;
        internal ListView lstOresLevel4;
        internal ColumnHeader checkboxXL;
        internal ColumnHeader orenameXL;
        internal ColumnHeader numberroidsXL;
        internal ColumnHeader unitsXL;
        internal ListView lstMineralsLevel4;
        internal ColumnHeader mineralsXL;
        internal ColumnHeader minsunitsXL;
        internal ColumnHeader totaliskXL;
        internal Label lblXLBeltOreComp;
        internal GroupBox gbSum5;
        internal Label lblBeltTotalIsk5;
        internal Label lblTotalHourstoFlip5;
        internal Label lblTotalIskLevel5;
        internal Label lblIPH5;
        internal Label lblTotalBeltVol5;
        internal Label lblHourstoFlip5;
        internal Label lblGiantBeltMineralComp;
        internal ListView lstOresLevel5;
        internal ColumnHeader checkboxGiant;
        internal ColumnHeader orenameGiant;
        internal ColumnHeader numberroidsGiant;
        internal ColumnHeader unitsGiant;
        internal ListView lstMineralsLevel5;
        internal ColumnHeader mineralsGiant;
        internal ColumnHeader minsunitsGiant;
        internal ColumnHeader totaliskGiant;
        internal Label lblGiantBeltOreComp;
        internal GroupBox gbSum1;
        internal Label lblTotalIPH1;
        internal Label lblTotalBeltVolume1;
        internal Label lblBeltTotalIsk1;
        internal Label lblTotalHourstoFlip1;
        internal Label lblTotalIskLevel1;
        internal Label lblIPH1;
        internal Label lblTotalBeltVol1;
        internal Label lblHourstoFlip1;
        internal GroupBox gbSum2;
        internal Label lblTotalIPH2;
        internal Label lblTotalBeltVolume2;
        internal Label lblBeltTotalIsk2;
        internal Label lblTotalHourstoFlip2;
        internal Label lblTotalIskLevel2;
        internal Label lblIPH2;
        internal Label lblTotalBeltVol2;
        internal Label lblHourstoFlip2;
        internal GroupBox gbSum3;
        internal Label lblTotalIPH3;
        internal Label lblTotalBeltVolume3;
        internal Label lblBeltTotalIsk3;
        internal Label lblTotalHourstoFlip3;
        internal Label lblTotalIskLevel3;
        internal Label lblIPH3;
        internal Label lblTotalBeltVol3;
        internal Label lblHourstoFlip3;
        internal GroupBox gbSum4;
        internal Label lblTotalIPH4;
        internal Label lblTotalBeltVolume4;
        internal Label lblBeltTotalIsk4;
        internal Label lblTotalHourstoFlip4;
        internal Label lblTotalIskLevel4;
        internal Label lblIPH4;
        internal Label lblTotalBeltVol4;
        internal Label lblHourstoFlip4;
        internal Label lblTotalIPH5;
        internal Label lblTotalBeltVolume5;
        internal Button btnCloseSmall;
        internal Button btnSaveSettingsSmall;
        internal Button btnCloseMedium;
        internal Button btnSaveSettingsMedium;
        internal Button btnCloseLarge;
        internal Button btnSaveSettingsLarge;
        internal Button btnCloseXL;
        internal Button btnSaveSettingsXLarge;
        internal Button btnCloseGiant;
        internal Button btnSaveSettingsGiant;
        internal CheckBox chkCompressOre;
        internal Button btnRefine;
        internal CheckBox chkIPHperMiner;
        internal ToolTip ttMain;
        internal TextBox txtBrokerFeeRate;
        internal ManufacturingFacility ReprocessingFacility;
        internal GroupBox gbTruesec;
        internal RadioButton rbtn10percent;
        internal RadioButton rbtn0percent;
        internal RadioButton rbtn5percent;
    }
}