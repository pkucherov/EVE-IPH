using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmIceBeltFlip : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIceBeltFlip));
            gbSummarySettings = new GroupBox();
            gbMineTaxBroker = new GroupBox();
            txtBrokerFeeRate = new TextBox();
            txtBrokerFeeRate.KeyDown += new KeyEventHandler(txtBrokerFeeRate_KeyDown);
            txtBrokerFeeRate.KeyPress += new KeyPressEventHandler(txtBrokerFeeRate_KeyPress);
            txtBrokerFeeRate.GotFocus += new EventHandler(txtBrokerFeeRate_GotFocus);
            txtBrokerFeeRate.LostFocus += new EventHandler(txtBrokerFeeRate_LostFocus);
            chkIPHperMiner = new CheckBox();
            chkIPHperMiner.CheckedChanged += new EventHandler(CheckChanged);
            chkCompressIce = new CheckBox();
            chkCompressIce.CheckedChanged += new EventHandler(CheckChanged);
            chkIncludeTaxes = new CheckBox();
            chkBrokerFees = new CheckBox();
            chkBrokerFees.Click += new EventHandler(chkBrokerFees_Click);
            ReprocessingFacility = new ManufacturingFacility();
            gbTrueSec = new GroupBox();
            rbtnNullWeak = new RadioButton();
            rbtnNullWeak.CheckedChanged += new EventHandler(rbtnCheckedChanged);
            rbtnLowsec = new RadioButton();
            rbtnLowsec.CheckedChanged += new EventHandler(rbtnCheckedChanged);
            rbtnHighsec = new RadioButton();
            rbtnHighsec.CheckedChanged += new EventHandler(rbtnCheckedChanged);
            rbtnNullStrong = new RadioButton();
            rbtnNullStrong.CheckedChanged += new EventHandler(rbtnCheckedChanged);
            gbSpace = new GroupBox();
            rbtnCaldari = new RadioButton();
            rbtnCaldari.CheckedChanged += new EventHandler(rbtnCheckedChanged);
            rbtnMinmatar = new RadioButton();
            rbtnMinmatar.CheckedChanged += new EventHandler(rbtnCheckedChanged);
            rbtnGallente = new RadioButton();
            rbtnGallente.CheckedChanged += new EventHandler(rbtnCheckedChanged);
            rbtnAmarr = new RadioButton();
            rbtnAmarr.CheckedChanged += new EventHandler(rbtnCheckedChanged);
            btnRefine = new Button();
            btnRefine.Click += new EventHandler(btnRefine_Click);
            lblCycleTime = new Label();
            txtCycleTime = new TextBox();
            txtCycleTime.KeyDown += new KeyEventHandler(TextBoxes_KeyDown);
            txtCycleTime.LostFocus += new EventHandler(Text_LostFocus);
            txtm3perCycle = new TextBox();
            txtm3perCycle.KeyDown += new KeyEventHandler(TextBoxes_KeyDown);
            txtm3perCycle.LostFocus += new EventHandler(Text_LostFocus);
            lblm3perCycle = new Label();
            cmbNumMiners = new ComboBox();
            cmbNumMiners.SelectedIndexChanged += new EventHandler(cmbNumMiners_SelectedIndexChanged);
            cmbNumMiners.KeyDown += new KeyEventHandler(TextBoxes_KeyDown);
            cmbNumMiners.LostFocus += new EventHandler(Text_LostFocus);
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            lblNumMiners = new Label();
            lblm3perhrperminer = new Label();
            lblm3perhrperminer1 = new Label();
            btnCloseSmall = new Button();
            btnCloseSmall.Click += new EventHandler(btnCloseSmall_Click);
            btnSaveChecks = new Button();
            btnSaveChecks.Click += new EventHandler(btnSaveChecks_Click);
            gbSum1 = new GroupBox();
            lblBeltIPH1 = new Label();
            lblBeltIPH = new Label();
            Label1 = new Label();
            lblTotalRefineVolume = new Label();
            lblTotalBeltValue = new Label();
            lblTotalIPH1 = new Label();
            lblTotalBeltVolume = new Label();
            lblTotalBeltValue1 = new Label();
            lblTotalRefineValue1 = new Label();
            lblTotalHourstoFlip = new Label();
            lblTotalRefineValue = new Label();
            lblRefineIPH = new Label();
            lblTotalBeltVol1 = new Label();
            lblHourstoFlip1 = new Label();
            lblIceProductComposition = new Label();
            lstIce = new ListView();
            lstIce.ColumnClick += new ColumnClickEventHandler(listIce_ColumnClick);
            lstIce.ItemChecked += new ItemCheckedEventHandler(listIce_ItemChecked);
            checkboxIce = new ColumnHeader();
            IceName = new ColumnHeader();
            IceUnits = new ColumnHeader();
            IcePPU = new ColumnHeader();
            lstIceProducts = new ListView();
            lstIceProducts.ColumnClick += new ColumnClickEventHandler(lstIceProducts_ColumnClick);
            iceProducts = new ColumnHeader();
            units = new ColumnHeader();
            totalISK = new ColumnHeader();
            lblBeltComp = new Label();
            gbSummarySettings.SuspendLayout();
            gbMineTaxBroker.SuspendLayout();
            gbTrueSec.SuspendLayout();
            gbSpace.SuspendLayout();
            gbSum1.SuspendLayout();
            SuspendLayout();
            // 
            // gbSummarySettings
            // 
            gbSummarySettings.Controls.Add(gbMineTaxBroker);
            gbSummarySettings.Controls.Add(ReprocessingFacility);
            gbSummarySettings.Controls.Add(gbTrueSec);
            gbSummarySettings.Controls.Add(gbSpace);
            gbSummarySettings.Controls.Add(btnRefine);
            gbSummarySettings.Controls.Add(lblCycleTime);
            gbSummarySettings.Controls.Add(txtCycleTime);
            gbSummarySettings.Controls.Add(txtm3perCycle);
            gbSummarySettings.Controls.Add(lblm3perCycle);
            gbSummarySettings.Controls.Add(cmbNumMiners);
            gbSummarySettings.Controls.Add(btnSaveSettings);
            gbSummarySettings.Controls.Add(lblNumMiners);
            gbSummarySettings.Controls.Add(lblm3perhrperminer);
            gbSummarySettings.Controls.Add(lblm3perhrperminer1);
            gbSummarySettings.Location = new Point(9, 3);
            gbSummarySettings.Name = "gbSummarySettings";
            gbSummarySettings.Size = new Size(601, 177);
            gbSummarySettings.TabIndex = 140;
            gbSummarySettings.TabStop = false;
            gbSummarySettings.Text = "Settings";
            // 
            // gbMineTaxBroker
            // 
            gbMineTaxBroker.Controls.Add(txtBrokerFeeRate);
            gbMineTaxBroker.Controls.Add(chkIPHperMiner);
            gbMineTaxBroker.Controls.Add(chkCompressIce);
            gbMineTaxBroker.Controls.Add(chkIncludeTaxes);
            gbMineTaxBroker.Controls.Add(chkBrokerFees);
            gbMineTaxBroker.Location = new Point(313, 26);
            gbMineTaxBroker.Name = "gbMineTaxBroker";
            gbMineTaxBroker.Size = new Size(114, 88);
            gbMineTaxBroker.TabIndex = 126;
            gbMineTaxBroker.TabStop = false;
            gbMineTaxBroker.Text = "Options:";
            // 
            // txtBrokerFeeRate
            // 
            txtBrokerFeeRate.Location = new Point(57, 63);
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
            chkIPHperMiner.Location = new Point(9, 33);
            chkIPHperMiner.Name = "chkIPHperMiner";
            chkIPHperMiner.Size = new Size(91, 17);
            chkIPHperMiner.TabIndex = 9;
            chkIPHperMiner.Text = "IPH per Miner";
            chkIPHperMiner.UseVisualStyleBackColor = true;
            // 
            // chkCompressIce
            // 
            chkCompressIce.AutoSize = true;
            chkCompressIce.Checked = true;
            chkCompressIce.CheckState = CheckState.Checked;
            chkCompressIce.Location = new Point(9, 17);
            chkCompressIce.Name = "chkCompressIce";
            chkCompressIce.Size = new Size(90, 17);
            chkCompressIce.TabIndex = 8;
            chkCompressIce.Text = "Compress Ice";
            chkCompressIce.UseVisualStyleBackColor = true;
            // 
            // chkIncludeTaxes
            // 
            chkIncludeTaxes.AutoSize = true;
            chkIncludeTaxes.Checked = true;
            chkIncludeTaxes.CheckState = CheckState.Checked;
            chkIncludeTaxes.Location = new Point(9, 49);
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
            chkBrokerFees.Location = new Point(9, 65);
            chkBrokerFees.Name = "chkBrokerFees";
            chkBrokerFees.Size = new Size(49, 17);
            chkBrokerFees.TabIndex = 10;
            chkBrokerFees.Text = "Fees";
            chkBrokerFees.ThreeState = true;
            chkBrokerFees.UseVisualStyleBackColor = true;
            // 
            // ReprocessingFacility
            // 
            ReprocessingFacility.BackColor = Color.Transparent;
            ReprocessingFacility.Location = new Point(6, 60);
            ReprocessingFacility.Name = "ReprocessingFacility";
            ReprocessingFacility.Size = new Size(303, 108);
            ReprocessingFacility.TabIndex = 125;
            // 
            // gbTrueSec
            // 
            gbTrueSec.Controls.Add(rbtnNullWeak);
            gbTrueSec.Controls.Add(rbtnLowsec);
            gbTrueSec.Controls.Add(rbtnHighsec);
            gbTrueSec.Controls.Add(rbtnNullStrong);
            gbTrueSec.Location = new Point(433, 26);
            gbTrueSec.Name = "gbTrueSec";
            gbTrueSec.Size = new Size(161, 88);
            gbTrueSec.TabIndex = 123;
            gbTrueSec.TabStop = false;
            gbTrueSec.Text = "System Security:";
            // 
            // rbtnNullWeak
            // 
            rbtnNullWeak.AutoSize = true;
            rbtnNullWeak.Location = new Point(6, 39);
            rbtnNullWeak.Name = "rbtnNullWeak";
            rbtnNullWeak.Size = new Size(149, 17);
            rbtnNullWeak.TabIndex = 5;
            rbtnNullWeak.Text = "Nullsec Weak (0.0 to -0.5)";
            rbtnNullWeak.UseVisualStyleBackColor = true;
            // 
            // rbtnLowsec
            // 
            rbtnLowsec.AutoSize = true;
            rbtnLowsec.Location = new Point(92, 19);
            rbtnLowsec.Name = "rbtnLowsec";
            rbtnLowsec.Size = new Size(62, 17);
            rbtnLowsec.TabIndex = 4;
            rbtnLowsec.Text = "Lowsec";
            rbtnLowsec.UseVisualStyleBackColor = true;
            // 
            // rbtnHighsec
            // 
            rbtnHighsec.AutoSize = true;
            rbtnHighsec.Checked = true;
            rbtnHighsec.Location = new Point(6, 19);
            rbtnHighsec.Name = "rbtnHighsec";
            rbtnHighsec.Size = new Size(64, 17);
            rbtnHighsec.TabIndex = 3;
            rbtnHighsec.TabStop = true;
            rbtnHighsec.Text = "Highsec";
            rbtnHighsec.UseVisualStyleBackColor = true;
            // 
            // rbtnNullStrong
            // 
            rbtnNullStrong.AutoSize = true;
            rbtnNullStrong.Location = new Point(6, 59);
            rbtnNullStrong.Name = "rbtnNullStrong";
            rbtnNullStrong.Size = new Size(154, 17);
            rbtnNullStrong.TabIndex = 6;
            rbtnNullStrong.Text = "Nullsec Strong (-0.5 to -1.0)";
            rbtnNullStrong.UseVisualStyleBackColor = true;
            // 
            // gbSpace
            // 
            gbSpace.Controls.Add(rbtnCaldari);
            gbSpace.Controls.Add(rbtnMinmatar);
            gbSpace.Controls.Add(rbtnGallente);
            gbSpace.Controls.Add(rbtnAmarr);
            gbSpace.Location = new Point(433, 114);
            gbSpace.Name = "gbSpace";
            gbSpace.Size = new Size(161, 55);
            gbSpace.TabIndex = 124;
            gbSpace.TabStop = false;
            gbSpace.Text = "Space:";
            // 
            // rbtnCaldari
            // 
            rbtnCaldari.AutoSize = true;
            rbtnCaldari.Location = new Point(83, 14);
            rbtnCaldari.Name = "rbtnCaldari";
            rbtnCaldari.Size = new Size(57, 17);
            rbtnCaldari.TabIndex = 4;
            rbtnCaldari.Text = "Caldari";
            rbtnCaldari.UseVisualStyleBackColor = true;
            // 
            // rbtnMinmatar
            // 
            rbtnMinmatar.AutoSize = true;
            rbtnMinmatar.Location = new Point(83, 32);
            rbtnMinmatar.Name = "rbtnMinmatar";
            rbtnMinmatar.Size = new Size(68, 17);
            rbtnMinmatar.TabIndex = 6;
            rbtnMinmatar.Text = "Minmatar";
            rbtnMinmatar.UseVisualStyleBackColor = true;
            // 
            // rbtnGallente
            // 
            rbtnGallente.AutoSize = true;
            rbtnGallente.Location = new Point(9, 32);
            rbtnGallente.Name = "rbtnGallente";
            rbtnGallente.Size = new Size(64, 17);
            rbtnGallente.TabIndex = 5;
            rbtnGallente.Text = "Gallente";
            rbtnGallente.UseVisualStyleBackColor = true;
            // 
            // rbtnAmarr
            // 
            rbtnAmarr.AutoSize = true;
            rbtnAmarr.Checked = true;
            rbtnAmarr.Location = new Point(9, 14);
            rbtnAmarr.Name = "rbtnAmarr";
            rbtnAmarr.Size = new Size(52, 17);
            rbtnAmarr.TabIndex = 3;
            rbtnAmarr.TabStop = true;
            rbtnAmarr.Text = "Amarr";
            rbtnAmarr.UseVisualStyleBackColor = true;
            // 
            // btnRefine
            // 
            btnRefine.Location = new Point(313, 117);
            btnRefine.Name = "btnRefine";
            btnRefine.Size = new Size(114, 26);
            btnRefine.TabIndex = 3;
            btnRefine.Text = "Refine";
            btnRefine.UseVisualStyleBackColor = true;
            // 
            // lblCycleTime
            // 
            lblCycleTime.AutoSize = true;
            lblCycleTime.Location = new Point(75, 17);
            lblCycleTime.Name = "lblCycleTime";
            lblCycleTime.Size = new Size(62, 13);
            lblCycleTime.TabIndex = 111;
            lblCycleTime.Text = "Cycle Time:";
            // 
            // txtCycleTime
            // 
            txtCycleTime.Location = new Point(75, 32);
            txtCycleTime.Name = "txtCycleTime";
            txtCycleTime.Size = new Size(66, 20);
            txtCycleTime.TabIndex = 1;
            txtCycleTime.Text = "104.67";
            txtCycleTime.TextAlign = HorizontalAlignment.Center;
            // 
            // txtm3perCycle
            // 
            txtm3perCycle.Location = new Point(144, 32);
            txtm3perCycle.Name = "txtm3perCycle";
            txtm3perCycle.Size = new Size(66, 20);
            txtm3perCycle.TabIndex = 2;
            txtm3perCycle.Text = "5833.11";
            txtm3perCycle.TextAlign = HorizontalAlignment.Center;
            // 
            // lblm3perCycle
            // 
            lblm3perCycle.AutoSize = true;
            lblm3perCycle.Location = new Point(141, 16);
            lblm3perCycle.Name = "lblm3perCycle";
            lblm3perCycle.Size = new Size(71, 13);
            lblm3perCycle.TabIndex = 113;
            lblm3perCycle.Text = "m3 per Cycle:";
            // 
            // cmbNumMiners
            // 
            cmbNumMiners.FormattingEnabled = true;
            cmbNumMiners.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbNumMiners.Location = new Point(6, 32);
            cmbNumMiners.Name = "cmbNumMiners";
            cmbNumMiners.Size = new Size(66, 21);
            cmbNumMiners.TabIndex = 0;
            cmbNumMiners.Text = "10";
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(313, 143);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(114, 26);
            btnSaveSettings.TabIndex = 4;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // lblNumMiners
            // 
            lblNumMiners.AutoSize = true;
            lblNumMiners.Location = new Point(6, 17);
            lblNumMiners.Name = "lblNumMiners";
            lblNumMiners.Size = new Size(66, 13);
            lblNumMiners.TabIndex = 115;
            lblNumMiners.Text = "Num Miners:";
            // 
            // lblm3perhrperminer
            // 
            lblm3perhrperminer.BorderStyle = BorderStyle.FixedSingle;
            lblm3perhrperminer.Location = new Point(213, 32);
            lblm3perhrperminer.Name = "lblm3perhrperminer";
            lblm3perhrperminer.Size = new Size(97, 20);
            lblm3perhrperminer.TabIndex = 122;
            lblm3perhrperminer.Text = "999,999.00";
            lblm3perhrperminer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblm3perhrperminer1
            // 
            lblm3perhrperminer1.AutoSize = true;
            lblm3perhrperminer1.Location = new Point(210, 16);
            lblm3perhrperminer1.Name = "lblm3perhrperminer1";
            lblm3perhrperminer1.Size = new Size(68, 13);
            lblm3perhrperminer1.TabIndex = 121;
            lblm3perhrperminer1.Text = "m3/hr/miner:";
            // 
            // btnCloseSmall
            // 
            btnCloseSmall.Location = new Point(523, 400);
            btnCloseSmall.Name = "btnCloseSmall";
            btnCloseSmall.Size = new Size(87, 40);
            btnCloseSmall.TabIndex = 145;
            btnCloseSmall.Text = "Close";
            btnCloseSmall.UseVisualStyleBackColor = true;
            // 
            // btnSaveChecks
            // 
            btnSaveChecks.Location = new Point(523, 354);
            btnSaveChecks.Name = "btnSaveChecks";
            btnSaveChecks.Size = new Size(87, 40);
            btnSaveChecks.TabIndex = 144;
            btnSaveChecks.Text = "Save Ice Selected ";
            btnSaveChecks.UseVisualStyleBackColor = true;
            // 
            // gbSum1
            // 
            gbSum1.Controls.Add(lblBeltIPH1);
            gbSum1.Controls.Add(lblBeltIPH);
            gbSum1.Controls.Add(Label1);
            gbSum1.Controls.Add(lblTotalRefineVolume);
            gbSum1.Controls.Add(lblTotalBeltValue);
            gbSum1.Controls.Add(lblTotalIPH1);
            gbSum1.Controls.Add(lblTotalBeltVolume);
            gbSum1.Controls.Add(lblTotalBeltValue1);
            gbSum1.Controls.Add(lblTotalRefineValue1);
            gbSum1.Controls.Add(lblTotalHourstoFlip);
            gbSum1.Controls.Add(lblTotalRefineValue);
            gbSum1.Controls.Add(lblRefineIPH);
            gbSum1.Controls.Add(lblTotalBeltVol1);
            gbSum1.Controls.Add(lblHourstoFlip1);
            gbSum1.Location = new Point(8, 344);
            gbSum1.Name = "gbSum1";
            gbSum1.Size = new Size(509, 99);
            gbSum1.TabIndex = 147;
            gbSum1.TabStop = false;
            // 
            // lblBeltIPH1
            // 
            lblBeltIPH1.AutoSize = true;
            lblBeltIPH1.Location = new Point(38, 78);
            lblBeltIPH1.Name = "lblBeltIPH1";
            lblBeltIPH1.Size = new Size(68, 13);
            lblBeltIPH1.TabIndex = 67;
            lblBeltIPH1.Text = "Isk per Hour:";
            lblBeltIPH1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBeltIPH
            // 
            lblBeltIPH.BorderStyle = BorderStyle.FixedSingle;
            lblBeltIPH.Location = new Point(112, 75);
            lblBeltIPH.Name = "lblBeltIPH";
            lblBeltIPH.Size = new Size(125, 18);
            lblBeltIPH.TabIndex = 66;
            lblBeltIPH.Text = "100,000.00";
            lblBeltIPH.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(271, 35);
            Label1.Name = "Label1";
            Label1.Size = new Size(106, 13);
            Label1.TabIndex = 65;
            Label1.Text = "Refine Total Volume:";
            Label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalRefineVolume
            // 
            lblTotalRefineVolume.BorderStyle = BorderStyle.FixedSingle;
            lblTotalRefineVolume.Location = new Point(378, 33);
            lblTotalRefineVolume.Name = "lblTotalRefineVolume";
            lblTotalRefineVolume.Size = new Size(125, 18);
            lblTotalRefineVolume.TabIndex = 64;
            lblTotalRefineVolume.Text = "100,000.00";
            lblTotalRefineVolume.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBeltValue
            // 
            lblTotalBeltValue.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltValue.Location = new Point(112, 12);
            lblTotalBeltValue.Name = "lblTotalBeltValue";
            lblTotalBeltValue.Size = new Size(125, 18);
            lblTotalBeltValue.TabIndex = 63;
            lblTotalBeltValue.Text = "100,000.00";
            lblTotalBeltValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalIPH1
            // 
            lblTotalIPH1.AutoSize = true;
            lblTotalIPH1.Location = new Point(275, 57);
            lblTotalIPH1.Name = "lblTotalIPH1";
            lblTotalIPH1.Size = new Size(102, 13);
            lblTotalIPH1.TabIndex = 61;
            lblTotalIPH1.Text = "Refine Isk per Hour:";
            lblTotalIPH1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalBeltVolume
            // 
            lblTotalBeltVolume.BorderStyle = BorderStyle.FixedSingle;
            lblTotalBeltVolume.Location = new Point(112, 33);
            lblTotalBeltVolume.Name = "lblTotalBeltVolume";
            lblTotalBeltVolume.Size = new Size(125, 18);
            lblTotalBeltVolume.TabIndex = 60;
            lblTotalBeltVolume.Text = "100,000.00";
            lblTotalBeltVolume.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBeltValue1
            // 
            lblTotalBeltValue1.AutoSize = true;
            lblTotalBeltValue1.Location = new Point(21, 13);
            lblTotalBeltValue1.Name = "lblTotalBeltValue1";
            lblTotalBeltValue1.Size = new Size(85, 13);
            lblTotalBeltValue1.TabIndex = 62;
            lblTotalBeltValue1.Text = "Belt Total Value:";
            lblTotalBeltValue1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalRefineValue1
            // 
            lblTotalRefineValue1.AutoSize = true;
            lblTotalRefineValue1.Location = new Point(279, 15);
            lblTotalRefineValue1.Name = "lblTotalRefineValue1";
            lblTotalRefineValue1.Size = new Size(98, 13);
            lblTotalRefineValue1.TabIndex = 52;
            lblTotalRefineValue1.Text = "Refine Total Value:";
            lblTotalRefineValue1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalHourstoFlip
            // 
            lblTotalHourstoFlip.BorderStyle = BorderStyle.FixedSingle;
            lblTotalHourstoFlip.Location = new Point(112, 54);
            lblTotalHourstoFlip.Name = "lblTotalHourstoFlip";
            lblTotalHourstoFlip.Size = new Size(125, 18);
            lblTotalHourstoFlip.TabIndex = 57;
            lblTotalHourstoFlip.Text = "100,000.00";
            lblTotalHourstoFlip.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalRefineValue
            // 
            lblTotalRefineValue.BorderStyle = BorderStyle.FixedSingle;
            lblTotalRefineValue.Location = new Point(378, 12);
            lblTotalRefineValue.Name = "lblTotalRefineValue";
            lblTotalRefineValue.Size = new Size(125, 18);
            lblTotalRefineValue.TabIndex = 53;
            lblTotalRefineValue.Text = "100,000.00";
            lblTotalRefineValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRefineIPH
            // 
            lblRefineIPH.BorderStyle = BorderStyle.FixedSingle;
            lblRefineIPH.Location = new Point(378, 54);
            lblRefineIPH.Name = "lblRefineIPH";
            lblRefineIPH.Size = new Size(125, 18);
            lblRefineIPH.TabIndex = 59;
            lblRefineIPH.Text = "100,000.00";
            lblRefineIPH.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBeltVol1
            // 
            lblTotalBeltVol1.AutoSize = true;
            lblTotalBeltVol1.Location = new Point(13, 33);
            lblTotalBeltVol1.Name = "lblTotalBeltVol1";
            lblTotalBeltVol1.Size = new Size(93, 13);
            lblTotalBeltVol1.TabIndex = 54;
            lblTotalBeltVol1.Text = "Belt Total Volume:";
            lblTotalBeltVol1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHourstoFlip1
            // 
            lblHourstoFlip1.AutoSize = true;
            lblHourstoFlip1.Location = new Point(37, 57);
            lblHourstoFlip1.Name = "lblHourstoFlip1";
            lblHourstoFlip1.Size = new Size(69, 13);
            lblHourstoFlip1.TabIndex = 56;
            lblHourstoFlip1.Text = "Hours to Flip:";
            lblHourstoFlip1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIceProductComposition
            // 
            lblIceProductComposition.AutoSize = true;
            lblIceProductComposition.Location = new Point(395, 183);
            lblIceProductComposition.Name = "lblIceProductComposition";
            lblIceProductComposition.Size = new Size(122, 13);
            lblIceProductComposition.TabIndex = 146;
            lblIceProductComposition.Text = "Ice Product Composition";
            lblIceProductComposition.TextAlign = ContentAlignment.TopCenter;
            // 
            // lstIce
            // 
            lstIce.CheckBoxes = true;
            lstIce.Columns.AddRange(new ColumnHeader[] { checkboxIce, IceName, IceUnits, IcePPU });
            lstIce.FullRowSelect = true;
            lstIce.GridLines = true;
            lstIce.HideSelection = false;
            lstIce.Location = new Point(9, 199);
            lstIce.MultiSelect = false;
            lstIce.Name = "lstIce";
            lstIce.Size = new Size(287, 148);
            lstIce.TabIndex = 141;
            lstIce.UseCompatibleStateImageBehavior = false;
            lstIce.View = View.Details;
            // 
            // checkboxIce
            // 
            checkboxIce.Text = "";
            checkboxIce.Width = 25;
            // 
            // IceName
            // 
            IceName.Text = "Ice";
            IceName.Width = 112;
            // 
            // IceUnits
            // 
            IceUnits.Text = "Units";
            IceUnits.TextAlign = HorizontalAlignment.Right;
            IceUnits.Width = 50;
            // 
            // IcePPU
            // 
            IcePPU.Text = "Price per Unit";
            IcePPU.TextAlign = HorizontalAlignment.Right;
            IcePPU.Width = 96;
            // 
            // lstIceProducts
            // 
            lstIceProducts.Columns.AddRange(new ColumnHeader[] { iceProducts, units, totalISK });
            lstIceProducts.FullRowSelect = true;
            lstIceProducts.GridLines = true;
            lstIceProducts.HideSelection = false;
            lstIceProducts.Location = new Point(302, 199);
            lstIceProducts.MultiSelect = false;
            lstIceProducts.Name = "lstIceProducts";
            lstIceProducts.Size = new Size(308, 148);
            lstIceProducts.TabIndex = 142;
            lstIceProducts.UseCompatibleStateImageBehavior = false;
            lstIceProducts.View = View.Details;
            // 
            // iceProducts
            // 
            iceProducts.Text = "Ice Product";
            iceProducts.Width = 120;
            // 
            // units
            // 
            units.Text = "Units";
            units.TextAlign = HorizontalAlignment.Right;
            units.Width = 78;
            // 
            // totalISK
            // 
            totalISK.Text = "Total Isk";
            totalISK.TextAlign = HorizontalAlignment.Right;
            totalISK.Width = 106;
            // 
            // lblBeltComp
            // 
            lblBeltComp.AutoSize = true;
            lblBeltComp.Location = new Point(101, 183);
            lblBeltComp.Name = "lblBeltComp";
            lblBeltComp.Size = new Size(103, 13);
            lblBeltComp.TabIndex = 143;
            lblBeltComp.Text = "Ice Belt Composition";
            lblBeltComp.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmIceBeltFlip
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 446);
            Controls.Add(lblIceProductComposition);
            Controls.Add(lstIce);
            Controls.Add(lstIceProducts);
            Controls.Add(lblBeltComp);
            Controls.Add(gbSummarySettings);
            Controls.Add(btnCloseSmall);
            Controls.Add(btnSaveChecks);
            Controls.Add(gbSum1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmIceBeltFlip";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ice Anomaly Belts";
            gbSummarySettings.ResumeLayout(false);
            gbSummarySettings.PerformLayout();
            gbMineTaxBroker.ResumeLayout(false);
            gbMineTaxBroker.PerformLayout();
            gbTrueSec.ResumeLayout(false);
            gbTrueSec.PerformLayout();
            gbSpace.ResumeLayout(false);
            gbSpace.PerformLayout();
            gbSum1.ResumeLayout(false);
            gbSum1.PerformLayout();
            Shown += new EventHandler(frmIceBeltFlip_Shown);
            Disposed += new EventHandler(frmIceBeltFlip_Disposed);
            ResumeLayout(false);
            PerformLayout();

        }

        internal GroupBox gbSummarySettings;
        internal GroupBox gbTrueSec;
        internal RadioButton rbtnNullWeak;
        internal RadioButton rbtnLowsec;
        internal RadioButton rbtnHighsec;
        internal Button btnRefine;
        internal Label lblCycleTime;
        internal TextBox txtCycleTime;
        internal TextBox txtm3perCycle;
        internal Button btnSaveSettings;
        internal Label lblm3perCycle;
        internal ComboBox cmbNumMiners;
        internal Label lblNumMiners;
        internal Label lblm3perhrperminer;
        internal Label lblm3perhrperminer1;
        internal Button btnCloseSmall;
        internal Button btnSaveChecks;
        internal GroupBox gbSum1;
        internal Label lblTotalIPH1;
        internal Label lblTotalBeltVolume;
        internal Label lblTotalRefineValue1;
        internal Label lblTotalHourstoFlip;
        internal Label lblTotalRefineValue;
        internal Label lblRefineIPH;
        internal Label lblTotalBeltVol1;
        internal Label lblHourstoFlip1;
        internal Label lblIceProductComposition;
        internal ListView lstIce;
        internal ColumnHeader checkboxIce;
        internal ColumnHeader IceName;
        internal ColumnHeader IceUnits;
        internal ListView lstIceProducts;
        internal ColumnHeader iceProducts;
        internal ColumnHeader units;
        internal ColumnHeader totalISK;
        internal Label lblBeltComp;
        internal RadioButton rbtnNullStrong;
        internal GroupBox gbSpace;
        internal RadioButton rbtnMinmatar;
        internal RadioButton rbtnGallente;
        internal RadioButton rbtnCaldari;
        internal RadioButton rbtnAmarr;
        internal ManufacturingFacility ReprocessingFacility;
        internal GroupBox gbMineTaxBroker;
        internal TextBox txtBrokerFeeRate;
        internal CheckBox chkIPHperMiner;
        internal CheckBox chkCompressIce;
        internal CheckBox chkIncludeTaxes;
        internal CheckBox chkBrokerFees;
        internal ColumnHeader IcePPU;
        internal Label lblTotalBeltValue;
        internal Label lblTotalBeltValue1;
        internal Label lblBeltIPH1;
        internal Label lblBeltIPH;
        internal Label Label1;
        internal Label lblTotalRefineVolume;
    }
}