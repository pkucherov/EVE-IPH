using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmSettings : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            chkCheckUpdatesStartup = new CheckBox();
            chkCheckUpdatesStartup.CheckedChanged += new EventHandler(chkCheckUpdatesStartup_CheckedChanged);
            btnSave = new Button();
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel = new Button();
            btnCancel.Click += new EventHandler(btnCancel_Click);
            gbGeneral = new GroupBox();
            chkShareFacilities = new CheckBox();
            chkDisableTracking = new CheckBox();
            chkLoadBPsbyChar = new CheckBox();
            chkLoadBPsbyChar.CheckedChanged += new EventHandler(chkLoadBPsbyChar_CheckedChanged);
            chkSaveFacilitiesbyChar = new CheckBox();
            chkSaveFacilitiesbyChar.CheckedChanged += new EventHandler(chkSaveFacilitiesbyChar_CheckedChanged);
            chkLinksInCopyText = new CheckBox();
            chkDisableSound = new CheckBox();
            chkDisableSound.CheckedChanged += new EventHandler(chkDisableSound_CheckedChanged);
            chkDisableSVR = new CheckBox();
            chkDisableSVR.CheckedChanged += new EventHandler(chkDisableSVR_CheckedChanged);
            chkShowToolTips = new CheckBox();
            chkShowToolTips.CheckedChanged += new EventHandler(chkShowToolTips_CheckedChanged);
            chkRefreshBPsonStartup = new CheckBox();
            chkRefreshAssetsonStartup = new CheckBox();
            chkBeanCounterManufacturing = new CheckBox();
            chkBeanCounterManufacturing.CheckedChanged += new EventHandler(chkBeanCounterManufacturing_CheckedChanged);
            cmbBeanCounterRefining = new ComboBox();
            cmbBeanCounterManufacturing = new ComboBox();
            chkBeanCounterRefining = new CheckBox();
            chkBeanCounterRefining.CheckedChanged += new EventHandler(chkBeanCounterRefining_CheckedChanged);
            gbStationStandings = new GroupBox();
            txtBrokerCorpStanding = new TextBox();
            txtBrokerCorpStanding.KeyPress += new KeyPressEventHandler(txtBrokerCorpStandings_keypress);
            chkBrokerCorpStanding = new CheckBox();
            chkBrokerCorpStanding.CheckedChanged += new EventHandler(chkBrokerCorpStanding_CheckedChanged);
            txtBrokerFactionStanding = new TextBox();
            txtBrokerFactionStanding.KeyPress += new KeyPressEventHandler(txtBrokerFactionStandings_keypress);
            chkBrokerFactionStanding = new CheckBox();
            chkBrokerFactionStanding.CheckedChanged += new EventHandler(chkBrokerFactionStanding_CheckedChanged);
            btnReset = new Button();
            btnReset.Click += new EventHandler(btnReset_Click);
            gbBuildBuySettings = new GroupBox();
            chkAlwaysBuyRAMs = new CheckBox();
            chkAlwaysBuyRAMs.CheckedChanged += new EventHandler(chkBuyRAMs_CheckedChanged);
            chkAlwaysBuyFuelBlocks = new CheckBox();
            chkAlwaysBuyFuelBlocks.CheckedChanged += new EventHandler(chkBuyFuelBlocks_CheckedChanged);
            chkSaveBPRelicsDecryptors = new CheckBox();
            chkSaveBPRelicsDecryptors.CheckedChanged += new EventHandler(chkSaveBPRelicsDecryptors_CheckedChanged);
            chkBuildBuyDefault = new CheckBox();
            chkBuildBuyDefault.CheckedChanged += new EventHandler(chkBuildBuyDefault_CheckedChanged);
            chkSuggestBuildwhenBPnotOwned = new CheckBox();
            chkBeanCounterCopy = new CheckBox();
            chkBeanCounterCopy.CheckedChanged += new EventHandler(chkBeanCounterCopy_CheckedChanged);
            cmbBeanCounterCopy = new ComboBox();
            gbDefaultMEPE = new GroupBox();
            txtDefaultTE = new TextBox();
            txtDefaultTE.KeyPress += new KeyPressEventHandler(txtDefaultTE_KeyPress);
            chkDefaultTE = new CheckBox();
            chkDefaultTE.CheckedChanged += new EventHandler(chkDefaultPE_CheckedChanged);
            txtDefaultME = new TextBox();
            txtDefaultME.KeyPress += new KeyPressEventHandler(txtDefaultME_KeyPress);
            chkDefaultME = new CheckBox();
            chkDefaultME.CheckedChanged += new EventHandler(chkDefaultME_CheckedChanged);
            ToolTip1 = new ToolTip(components);
            gbShoppingList = new GroupBox();
            chkIncludeShopListInventMats = new CheckBox();
            chkIncludeShopListCopyMats = new CheckBox();
            gb3rdpartyMarketRefresh = new GroupBox();
            txtFuzzworksMarketInterval = new TextBox();
            txtFuzzworksMarketInterval.KeyPress += new KeyPressEventHandler(txtEVEMarketerInterval_KeyPress);
            chkFuzzworksMarketInterval = new CheckBox();
            chkFuzzworksMarketInterval.CheckedChanged += new EventHandler(chkEVEMarketerInterval_CheckedChanged);
            gbImplants = new GroupBox();
            gbStartupOptions = new GroupBox();
            chkSupressESImsgs = new CheckBox();
            chkRefreshPublicStructureDataonStartup = new CheckBox();
            chkRefreshSystemCostIndiciesDataonStartup = new CheckBox();
            chkRefreshSystemCostIndiciesDataonStartup.CheckedChanged += new EventHandler(chkRefreshFacilityDataonStartup_CheckedChanged);
            chkRefreshMarketDataonStartup = new CheckBox();
            chkRefreshMarketDataonStartup.CheckedChanged += new EventHandler(chkRefreshMarketDataonStartup_CheckedChanged);
            gbExportOptions = new GroupBox();
            rbtnExportSSV = new RadioButton();
            rbtnExportSSV.CheckedChanged += new EventHandler(rbtnExportSSV_CheckedChanged);
            rbtnExportCSV = new RadioButton();
            rbtnExportCSV.CheckedChanged += new EventHandler(rbtnExportCSV_CheckedChanged);
            rbtnExportDefault = new RadioButton();
            rbtnExportDefault.CheckedChanged += new EventHandler(rbtnExportDefault_CheckedChanged);
            gbCalcAvgPrice = new GroupBox();
            cmbSVRAvgPriceDuration = new ComboBox();
            cmbSVRAvgPriceDuration.KeyPress += new KeyPressEventHandler(cmbSVRAvgPriceDuration_KeyPress);
            chkAutoUpdateSVRBPTab = new CheckBox();
            lblSVRRegion = new Label();
            lblSVRAvgPrice = new Label();
            cmbSVRRegion = new ComboBox();
            cmbSVRRegion.DropDown += new EventHandler(cmbSVRRegion_DropDown);
            cmbSVRRegion.KeyPress += new KeyPressEventHandler(cmbSVRRegion_KeyPress);
            txtSVRThreshold = new TextBox();
            txtSVRThreshold.KeyPress += new KeyPressEventHandler(txtSVRThreshold_KeyPress);
            lblSVRThreshold = new Label();
            gbProxySettings = new GroupBox();
            txtProxyAddress = new TextBox();
            txtProxyAddress.TextChanged += new EventHandler(txtProxyAddress_TextChanged);
            lblProxyAddress = new Label();
            txtProxyPort = new TextBox();
            txtProxyPort.KeyPress += new KeyPressEventHandler(txtProxyPort_KeyPress);
            lblProxyPort = new Label();
            gbCharacterOptions = new GroupBox();
            chkLoadMaxAlphaSkills = new CheckBox();
            chkUseActiveSkills = new CheckBox();
            chkUseActiveSkills.CheckedChanged += new EventHandler(chkUseActiveSkills_CheckedChanged);
            chkAlphaAccount = new CheckBox();
            chkAlphaAccount.CheckedChanged += new EventHandler(chkAlphaAccount_CheckedChanged);
            gbTaxRates = new GroupBox();
            lblAdjustDefaultFees = new Label();
            btnOpenRates = new Button();
            btnOpenRates.Click += new EventHandler(btnOpenRates_Click);
            gbGeneral.SuspendLayout();
            gbStationStandings.SuspendLayout();
            gbBuildBuySettings.SuspendLayout();
            gbDefaultMEPE.SuspendLayout();
            gbShoppingList.SuspendLayout();
            gb3rdpartyMarketRefresh.SuspendLayout();
            gbImplants.SuspendLayout();
            gbStartupOptions.SuspendLayout();
            gbExportOptions.SuspendLayout();
            gbCalcAvgPrice.SuspendLayout();
            gbProxySettings.SuspendLayout();
            gbCharacterOptions.SuspendLayout();
            gbTaxRates.SuspendLayout();
            SuspendLayout();
            // 
            // chkCheckUpdatesStartup
            // 
            chkCheckUpdatesStartup.AutoSize = true;
            chkCheckUpdatesStartup.Location = new Point(17, 19);
            chkCheckUpdatesStartup.Name = "chkCheckUpdatesStartup";
            chkCheckUpdatesStartup.Size = new Size(157, 17);
            chkCheckUpdatesStartup.TabIndex = 0;
            chkCheckUpdatesStartup.Text = "Check for Program Updates";
            chkCheckUpdatesStartup.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(348, 413);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 30);
            btnSave.TabIndex = 29;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(558, 413);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(101, 30);
            btnCancel.TabIndex = 31;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbGeneral
            // 
            gbGeneral.Controls.Add(chkShareFacilities);
            gbGeneral.Controls.Add(chkDisableTracking);
            gbGeneral.Controls.Add(chkLoadBPsbyChar);
            gbGeneral.Controls.Add(chkSaveFacilitiesbyChar);
            gbGeneral.Controls.Add(chkLinksInCopyText);
            gbGeneral.Controls.Add(chkDisableSound);
            gbGeneral.Controls.Add(chkDisableSVR);
            gbGeneral.Controls.Add(chkShowToolTips);
            gbGeneral.Location = new Point(5, 12);
            gbGeneral.Name = "gbGeneral";
            gbGeneral.Size = new Size(235, 186);
            gbGeneral.TabIndex = 4;
            gbGeneral.TabStop = false;
            gbGeneral.Text = "General:";
            // 
            // chkShareFacilities
            // 
            chkShareFacilities.AutoSize = true;
            chkShareFacilities.Location = new Point(17, 139);
            chkShareFacilities.Name = "chkShareFacilities";
            chkShareFacilities.Size = new Size(131, 17);
            chkShareFacilities.TabIndex = 42;
            chkShareFacilities.Text = "Share Saved Facilities";
            chkShareFacilities.UseVisualStyleBackColor = true;
            // 
            // chkDisableTracking
            // 
            chkDisableTracking.AutoSize = true;
            chkDisableTracking.Location = new Point(17, 159);
            chkDisableTracking.Name = "chkDisableTracking";
            chkDisableTracking.Size = new Size(199, 17);
            chkDisableTracking.TabIndex = 41;
            chkDisableTracking.Text = "Disable Anonomous Usage Tracking";
            chkDisableTracking.UseVisualStyleBackColor = true;
            // 
            // chkLoadBPsbyChar
            // 
            chkLoadBPsbyChar.AutoSize = true;
            chkLoadBPsbyChar.Location = new Point(17, 119);
            chkLoadBPsbyChar.Name = "chkLoadBPsbyChar";
            chkLoadBPsbyChar.Size = new Size(162, 17);
            chkLoadBPsbyChar.TabIndex = 40;
            chkLoadBPsbyChar.Text = "Load Blueprints by Character";
            chkLoadBPsbyChar.UseVisualStyleBackColor = true;
            // 
            // chkSaveFacilitiesbyChar
            // 
            chkSaveFacilitiesbyChar.AutoSize = true;
            chkSaveFacilitiesbyChar.Location = new Point(17, 99);
            chkSaveFacilitiesbyChar.Name = "chkSaveFacilitiesbyChar";
            chkSaveFacilitiesbyChar.Size = new Size(185, 17);
            chkSaveFacilitiesbyChar.TabIndex = 39;
            chkSaveFacilitiesbyChar.Text = "Save Facilities for each Character";
            chkSaveFacilitiesbyChar.UseVisualStyleBackColor = true;
            // 
            // chkLinksInCopyText
            // 
            chkLinksInCopyText.Location = new Point(17, 39);
            chkLinksInCopyText.Name = "chkLinksInCopyText";
            chkLinksInCopyText.Size = new Size(214, 17);
            chkLinksInCopyText.TabIndex = 38;
            chkLinksInCopyText.Text = "Include InGame Links in Copy Text";
            chkLinksInCopyText.UseVisualStyleBackColor = true;
            // 
            // chkDisableSound
            // 
            chkDisableSound.AutoSize = true;
            chkDisableSound.Location = new Point(17, 79);
            chkDisableSound.Name = "chkDisableSound";
            chkDisableSound.Size = new Size(95, 17);
            chkDisableSound.TabIndex = 24;
            chkDisableSound.Text = "Disable Sound";
            chkDisableSound.UseVisualStyleBackColor = true;
            // 
            // chkDisableSVR
            // 
            chkDisableSVR.AutoSize = true;
            chkDisableSVR.Location = new Point(17, 59);
            chkDisableSVR.Name = "chkDisableSVR";
            chkDisableSVR.Size = new Size(129, 17);
            chkDisableSVR.TabIndex = 0;
            chkDisableSVR.Text = "Disable SVR Updates";
            chkDisableSVR.UseVisualStyleBackColor = true;
            // 
            // chkShowToolTips
            // 
            chkShowToolTips.AutoSize = true;
            chkShowToolTips.Location = new Point(17, 19);
            chkShowToolTips.Name = "chkShowToolTips";
            chkShowToolTips.Size = new Size(100, 17);
            chkShowToolTips.TabIndex = 2;
            chkShowToolTips.Text = "Show Tool Tips";
            chkShowToolTips.UseVisualStyleBackColor = true;
            // 
            // chkRefreshBPsonStartup
            // 
            chkRefreshBPsonStartup.AutoSize = true;
            chkRefreshBPsonStartup.Location = new Point(17, 59);
            chkRefreshBPsonStartup.Name = "chkRefreshBPsonStartup";
            chkRefreshBPsonStartup.Size = new Size(85, 17);
            chkRefreshBPsonStartup.TabIndex = 26;
            chkRefreshBPsonStartup.Text = "Refresh BPs";
            chkRefreshBPsonStartup.UseVisualStyleBackColor = true;
            // 
            // chkRefreshAssetsonStartup
            // 
            chkRefreshAssetsonStartup.AutoSize = true;
            chkRefreshAssetsonStartup.Location = new Point(17, 39);
            chkRefreshAssetsonStartup.Name = "chkRefreshAssetsonStartup";
            chkRefreshAssetsonStartup.Size = new Size(97, 17);
            chkRefreshAssetsonStartup.TabIndex = 23;
            chkRefreshAssetsonStartup.Text = "Refresh Assets";
            chkRefreshAssetsonStartup.UseVisualStyleBackColor = true;
            // 
            // chkBeanCounterManufacturing
            // 
            chkBeanCounterManufacturing.AutoSize = true;
            chkBeanCounterManufacturing.Location = new Point(9, 19);
            chkBeanCounterManufacturing.Name = "chkBeanCounterManufacturing";
            chkBeanCounterManufacturing.Size = new Size(195, 17);
            chkBeanCounterManufacturing.TabIndex = 3;
            chkBeanCounterManufacturing.Text = "Manufacturing Beancounter Implant";
            chkBeanCounterManufacturing.UseVisualStyleBackColor = true;
            // 
            // cmbBeanCounterRefining
            // 
            cmbBeanCounterRefining.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBeanCounterRefining.FormattingEnabled = true;
            cmbBeanCounterRefining.Items.AddRange(new object[] { "Zainou 'Beancounter' Reprocessing RX-801", "Zainou 'Beancounter' Reprocessing RX-802", "Zainou 'Beancounter' Reprocessing RX-804" });
            cmbBeanCounterRefining.Location = new Point(9, 83);
            cmbBeanCounterRefining.Name = "cmbBeanCounterRefining";
            cmbBeanCounterRefining.Size = new Size(235, 21);
            cmbBeanCounterRefining.TabIndex = 5;
            // 
            // cmbBeanCounterManufacturing
            // 
            cmbBeanCounterManufacturing.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBeanCounterManufacturing.FormattingEnabled = true;
            cmbBeanCounterManufacturing.Items.AddRange(new object[] { "Zainou 'Beancounter' Industry BX-801", "Zainou 'Beancounter' Industry BX-802", "Zainou 'Beancounter' Industry BX-804" });
            cmbBeanCounterManufacturing.Location = new Point(9, 38);
            cmbBeanCounterManufacturing.Name = "cmbBeanCounterManufacturing";
            cmbBeanCounterManufacturing.Size = new Size(235, 21);
            cmbBeanCounterManufacturing.TabIndex = 4;
            // 
            // chkBeanCounterRefining
            // 
            chkBeanCounterRefining.AutoSize = true;
            chkBeanCounterRefining.Location = new Point(9, 64);
            chkBeanCounterRefining.Name = "chkBeanCounterRefining";
            chkBeanCounterRefining.Size = new Size(192, 17);
            chkBeanCounterRefining.TabIndex = 5;
            chkBeanCounterRefining.Text = "Reprocessing Beancounter Implant";
            chkBeanCounterRefining.UseVisualStyleBackColor = true;
            // 
            // gbStationStandings
            // 
            gbStationStandings.Controls.Add(txtBrokerCorpStanding);
            gbStationStandings.Controls.Add(chkBrokerCorpStanding);
            gbStationStandings.Controls.Add(txtBrokerFactionStanding);
            gbStationStandings.Controls.Add(chkBrokerFactionStanding);
            gbStationStandings.Location = new Point(246, 200);
            gbStationStandings.Name = "gbStationStandings";
            gbStationStandings.Size = new Size(160, 63);
            gbStationStandings.TabIndex = 7;
            gbStationStandings.TabStop = false;
            gbStationStandings.Text = "Station (base) Standings:";
            // 
            // txtBrokerCorpStanding
            // 
            txtBrokerCorpStanding.Location = new Point(110, 15);
            txtBrokerCorpStanding.MaxLength = 5;
            txtBrokerCorpStanding.Name = "txtBrokerCorpStanding";
            txtBrokerCorpStanding.Size = new Size(41, 20);
            txtBrokerCorpStanding.TabIndex = 26;
            txtBrokerCorpStanding.TextAlign = HorizontalAlignment.Center;
            // 
            // chkBrokerCorpStanding
            // 
            chkBrokerCorpStanding.Location = new Point(9, 17);
            chkBrokerCorpStanding.Name = "chkBrokerCorpStanding";
            chkBrokerCorpStanding.Size = new Size(85, 17);
            chkBrokerCorpStanding.TabIndex = 25;
            chkBrokerCorpStanding.Text = "Broker Corp:";
            chkBrokerCorpStanding.UseVisualStyleBackColor = true;
            // 
            // txtBrokerFactionStanding
            // 
            txtBrokerFactionStanding.Location = new Point(110, 37);
            txtBrokerFactionStanding.MaxLength = 5;
            txtBrokerFactionStanding.Name = "txtBrokerFactionStanding";
            txtBrokerFactionStanding.Size = new Size(41, 20);
            txtBrokerFactionStanding.TabIndex = 28;
            txtBrokerFactionStanding.TextAlign = HorizontalAlignment.Center;
            // 
            // chkBrokerFactionStanding
            // 
            chkBrokerFactionStanding.Location = new Point(9, 39);
            chkBrokerFactionStanding.Name = "chkBrokerFactionStanding";
            chkBrokerFactionStanding.Size = new Size(98, 17);
            chkBrokerFactionStanding.TabIndex = 27;
            chkBrokerFactionStanding.Text = "Broker Faction:";
            chkBrokerFactionStanding.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(453, 413);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(101, 30);
            btnReset.TabIndex = 30;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // gbBuildBuySettings
            // 
            gbBuildBuySettings.Controls.Add(chkAlwaysBuyRAMs);
            gbBuildBuySettings.Controls.Add(chkAlwaysBuyFuelBlocks);
            gbBuildBuySettings.Controls.Add(chkSaveBPRelicsDecryptors);
            gbBuildBuySettings.Controls.Add(chkBuildBuyDefault);
            gbBuildBuySettings.Controls.Add(chkSuggestBuildwhenBPnotOwned);
            gbBuildBuySettings.Location = new Point(410, 171);
            gbBuildBuySettings.Name = "gbBuildBuySettings";
            gbBuildBuySettings.Size = new Size(250, 125);
            gbBuildBuySettings.TabIndex = 9;
            gbBuildBuySettings.TabStop = false;
            gbBuildBuySettings.Text = "Build Settings:";
            // 
            // chkAlwaysBuyRAMs
            // 
            chkAlwaysBuyRAMs.AutoSize = true;
            chkAlwaysBuyRAMs.Location = new Point(9, 98);
            chkAlwaysBuyRAMs.Name = "chkAlwaysBuyRAMs";
            chkAlwaysBuyRAMs.Size = new Size(121, 17);
            chkAlwaysBuyRAMs.TabIndex = 40;
            chkAlwaysBuyRAMs.Text = "Always Buy R.A.M.s";
            chkAlwaysBuyRAMs.UseVisualStyleBackColor = true;
            // 
            // chkAlwaysBuyFuelBlocks
            // 
            chkAlwaysBuyFuelBlocks.AutoSize = true;
            chkAlwaysBuyFuelBlocks.Location = new Point(9, 78);
            chkAlwaysBuyFuelBlocks.Name = "chkAlwaysBuyFuelBlocks";
            chkAlwaysBuyFuelBlocks.Size = new Size(138, 17);
            chkAlwaysBuyFuelBlocks.TabIndex = 39;
            chkAlwaysBuyFuelBlocks.Text = "Always Buy Fuel Blocks";
            chkAlwaysBuyFuelBlocks.UseVisualStyleBackColor = true;
            // 
            // chkSaveBPRelicsDecryptors
            // 
            chkSaveBPRelicsDecryptors.AutoSize = true;
            chkSaveBPRelicsDecryptors.Location = new Point(9, 58);
            chkSaveBPRelicsDecryptors.Name = "chkSaveBPRelicsDecryptors";
            chkSaveBPRelicsDecryptors.Size = new Size(212, 17);
            chkSaveBPRelicsDecryptors.TabIndex = 38;
            chkSaveBPRelicsDecryptors.Text = "Save Relics and Decryptors on BP Tab";
            chkSaveBPRelicsDecryptors.UseVisualStyleBackColor = true;
            // 
            // chkBuildBuyDefault
            // 
            chkBuildBuyDefault.AutoSize = true;
            chkBuildBuyDefault.Location = new Point(9, 18);
            chkBuildBuyDefault.Name = "chkBuildBuyDefault";
            chkBuildBuyDefault.Size = new Size(109, 17);
            chkBuildBuyDefault.TabIndex = 32;
            chkBuildBuyDefault.Text = "Default Build/Buy";
            chkBuildBuyDefault.UseVisualStyleBackColor = true;
            // 
            // chkSuggestBuildwhenBPnotOwned
            // 
            chkSuggestBuildwhenBPnotOwned.AutoSize = true;
            chkSuggestBuildwhenBPnotOwned.Location = new Point(9, 38);
            chkSuggestBuildwhenBPnotOwned.Name = "chkSuggestBuildwhenBPnotOwned";
            chkSuggestBuildwhenBPnotOwned.Size = new Size(222, 17);
            chkSuggestBuildwhenBPnotOwned.TabIndex = 37;
            chkSuggestBuildwhenBPnotOwned.Text = "Suggest Build option when BP not owned";
            chkSuggestBuildwhenBPnotOwned.UseVisualStyleBackColor = true;
            // 
            // chkBeanCounterCopy
            // 
            chkBeanCounterCopy.AutoSize = true;
            chkBeanCounterCopy.Location = new Point(9, 109);
            chkBeanCounterCopy.Name = "chkBeanCounterCopy";
            chkBeanCounterCopy.Size = new Size(151, 17);
            chkBeanCounterCopy.TabIndex = 35;
            chkBeanCounterCopy.Text = "Copy Beancounter Implant";
            chkBeanCounterCopy.UseVisualStyleBackColor = true;
            // 
            // cmbBeanCounterCopy
            // 
            cmbBeanCounterCopy.DisplayMember = "Zainou 'Beancounter' Science SC-805";
            cmbBeanCounterCopy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBeanCounterCopy.FormattingEnabled = true;
            cmbBeanCounterCopy.Items.AddRange(new object[] { "Zainou 'Beancounter' Science SC-801", "Zainou 'Beancounter' Science SC-803", "Zainou 'Beancounter' Science SC-805" });
            cmbBeanCounterCopy.Location = new Point(9, 126);
            cmbBeanCounterCopy.Name = "cmbBeanCounterCopy";
            cmbBeanCounterCopy.Size = new Size(235, 21);
            cmbBeanCounterCopy.TabIndex = 36;
            // 
            // gbDefaultMEPE
            // 
            gbDefaultMEPE.Controls.Add(txtDefaultTE);
            gbDefaultMEPE.Controls.Add(chkDefaultTE);
            gbDefaultMEPE.Controls.Add(txtDefaultME);
            gbDefaultMEPE.Controls.Add(chkDefaultME);
            gbDefaultMEPE.Location = new Point(246, 12);
            gbDefaultMEPE.Name = "gbDefaultMEPE";
            gbDefaultMEPE.Size = new Size(160, 63);
            gbDefaultMEPE.TabIndex = 34;
            gbDefaultMEPE.TabStop = false;
            gbDefaultMEPE.Text = "Default ME/TE:";
            // 
            // txtDefaultTE
            // 
            txtDefaultTE.Location = new Point(110, 37);
            txtDefaultTE.Name = "txtDefaultTE";
            txtDefaultTE.Size = new Size(41, 20);
            txtDefaultTE.TabIndex = 26;
            txtDefaultTE.TextAlign = HorizontalAlignment.Center;
            // 
            // chkDefaultTE
            // 
            chkDefaultTE.Location = new Point(9, 39);
            chkDefaultTE.Name = "chkDefaultTE";
            chkDefaultTE.Size = new Size(85, 17);
            chkDefaultTE.TabIndex = 25;
            chkDefaultTE.Text = "Default TE:";
            chkDefaultTE.UseVisualStyleBackColor = true;
            // 
            // txtDefaultME
            // 
            txtDefaultME.Location = new Point(110, 15);
            txtDefaultME.Name = "txtDefaultME";
            txtDefaultME.Size = new Size(41, 20);
            txtDefaultME.TabIndex = 22;
            txtDefaultME.TextAlign = HorizontalAlignment.Center;
            // 
            // chkDefaultME
            // 
            chkDefaultME.Location = new Point(9, 16);
            chkDefaultME.Name = "chkDefaultME";
            chkDefaultME.Size = new Size(85, 17);
            chkDefaultME.TabIndex = 21;
            chkDefaultME.Text = "Default ME:";
            chkDefaultME.UseVisualStyleBackColor = true;
            // 
            // gbShoppingList
            // 
            gbShoppingList.Controls.Add(chkIncludeShopListInventMats);
            gbShoppingList.Controls.Add(chkIncludeShopListCopyMats);
            gbShoppingList.Location = new Point(246, 77);
            gbShoppingList.Name = "gbShoppingList";
            gbShoppingList.Size = new Size(160, 63);
            gbShoppingList.TabIndex = 37;
            gbShoppingList.TabStop = false;
            gbShoppingList.Text = "Shopping List:";
            // 
            // chkIncludeShopListInventMats
            // 
            chkIncludeShopListInventMats.AutoSize = true;
            chkIncludeShopListInventMats.Location = new Point(9, 19);
            chkIncludeShopListInventMats.Name = "chkIncludeShopListInventMats";
            chkIncludeShopListInventMats.Size = new Size(134, 17);
            chkIncludeShopListInventMats.TabIndex = 0;
            chkIncludeShopListInventMats.Text = "Include Invention Mats";
            chkIncludeShopListInventMats.UseVisualStyleBackColor = true;
            // 
            // chkIncludeShopListCopyMats
            // 
            chkIncludeShopListCopyMats.AutoSize = true;
            chkIncludeShopListCopyMats.Location = new Point(9, 40);
            chkIncludeShopListCopyMats.Name = "chkIncludeShopListCopyMats";
            chkIncludeShopListCopyMats.Size = new Size(114, 17);
            chkIncludeShopListCopyMats.TabIndex = 1;
            chkIncludeShopListCopyMats.Text = "Include Copy Mats";
            chkIncludeShopListCopyMats.UseVisualStyleBackColor = true;
            // 
            // gb3rdpartyMarketRefresh
            // 
            gb3rdpartyMarketRefresh.Controls.Add(txtFuzzworksMarketInterval);
            gb3rdpartyMarketRefresh.Controls.Add(chkFuzzworksMarketInterval);
            gb3rdpartyMarketRefresh.Location = new Point(246, 142);
            gb3rdpartyMarketRefresh.Name = "gb3rdpartyMarketRefresh";
            gb3rdpartyMarketRefresh.Size = new Size(160, 56);
            gb3rdpartyMarketRefresh.TabIndex = 38;
            gb3rdpartyMarketRefresh.TabStop = false;
            gb3rdpartyMarketRefresh.Text = "Fuzzworks Price Updates:";
            // 
            // txtFuzzworksMarketInterval
            // 
            txtFuzzworksMarketInterval.Location = new Point(110, 25);
            txtFuzzworksMarketInterval.Name = "txtFuzzworksMarketInterval";
            txtFuzzworksMarketInterval.Size = new Size(41, 20);
            txtFuzzworksMarketInterval.TabIndex = 24;
            txtFuzzworksMarketInterval.TextAlign = HorizontalAlignment.Center;
            // 
            // chkFuzzworksMarketInterval
            // 
            chkFuzzworksMarketInterval.Location = new Point(9, 18);
            chkFuzzworksMarketInterval.Name = "chkFuzzworksMarketInterval";
            chkFuzzworksMarketInterval.Size = new Size(105, 34);
            chkFuzzworksMarketInterval.TabIndex = 23;
            chkFuzzworksMarketInterval.Text = "Refresh Interval (Minutes):";
            chkFuzzworksMarketInterval.UseVisualStyleBackColor = true;
            // 
            // gbImplants
            // 
            gbImplants.Controls.Add(chkBeanCounterManufacturing);
            gbImplants.Controls.Add(chkBeanCounterCopy);
            gbImplants.Controls.Add(cmbBeanCounterManufacturing);
            gbImplants.Controls.Add(chkBeanCounterRefining);
            gbImplants.Controls.Add(cmbBeanCounterCopy);
            gbImplants.Controls.Add(cmbBeanCounterRefining);
            gbImplants.Location = new Point(410, 12);
            gbImplants.Name = "gbImplants";
            gbImplants.Size = new Size(250, 157);
            gbImplants.TabIndex = 36;
            gbImplants.TabStop = false;
            gbImplants.Text = "Implants:";
            // 
            // gbStartupOptions
            // 
            gbStartupOptions.Controls.Add(chkSupressESImsgs);
            gbStartupOptions.Controls.Add(chkRefreshPublicStructureDataonStartup);
            gbStartupOptions.Controls.Add(chkRefreshSystemCostIndiciesDataonStartup);
            gbStartupOptions.Controls.Add(chkRefreshMarketDataonStartup);
            gbStartupOptions.Controls.Add(chkRefreshBPsonStartup);
            gbStartupOptions.Controls.Add(chkCheckUpdatesStartup);
            gbStartupOptions.Controls.Add(chkRefreshAssetsonStartup);
            gbStartupOptions.Location = new Point(5, 200);
            gbStartupOptions.Name = "gbStartupOptions";
            gbStartupOptions.Size = new Size(235, 162);
            gbStartupOptions.TabIndex = 39;
            gbStartupOptions.TabStop = false;
            gbStartupOptions.Text = "Startup Options";
            // 
            // chkSupressESImsgs
            // 
            chkSupressESImsgs.AutoSize = true;
            chkSupressESImsgs.Location = new Point(17, 139);
            chkSupressESImsgs.Name = "chkSupressESImsgs";
            chkSupressESImsgs.Size = new Size(168, 17);
            chkSupressESImsgs.TabIndex = 31;
            chkSupressESImsgs.Text = "Supress ESI Status Messages";
            chkSupressESImsgs.UseVisualStyleBackColor = true;
            // 
            // chkRefreshPublicStructureDataonStartup
            // 
            chkRefreshPublicStructureDataonStartup.AutoSize = true;
            chkRefreshPublicStructureDataonStartup.Location = new Point(17, 119);
            chkRefreshPublicStructureDataonStartup.Name = "chkRefreshPublicStructureDataonStartup";
            chkRefreshPublicStructureDataonStartup.Size = new Size(167, 17);
            chkRefreshPublicStructureDataonStartup.TabIndex = 30;
            chkRefreshPublicStructureDataonStartup.Text = "Refresh Public Structure Data";
            chkRefreshPublicStructureDataonStartup.UseVisualStyleBackColor = true;
            // 
            // chkRefreshSystemCostIndiciesDataonStartup
            // 
            chkRefreshSystemCostIndiciesDataonStartup.AutoSize = true;
            chkRefreshSystemCostIndiciesDataonStartup.Location = new Point(17, 99);
            chkRefreshSystemCostIndiciesDataonStartup.Name = "chkRefreshSystemCostIndiciesDataonStartup";
            chkRefreshSystemCostIndiciesDataonStartup.Size = new Size(179, 17);
            chkRefreshSystemCostIndiciesDataonStartup.TabIndex = 29;
            chkRefreshSystemCostIndiciesDataonStartup.Text = "Refresh System Industry Indicies";
            chkRefreshSystemCostIndiciesDataonStartup.UseVisualStyleBackColor = true;
            // 
            // chkRefreshMarketDataonStartup
            // 
            chkRefreshMarketDataonStartup.AutoSize = true;
            chkRefreshMarketDataonStartup.Location = new Point(17, 79);
            chkRefreshMarketDataonStartup.Name = "chkRefreshMarketDataonStartup";
            chkRefreshMarketDataonStartup.Size = new Size(125, 17);
            chkRefreshMarketDataonStartup.TabIndex = 28;
            chkRefreshMarketDataonStartup.Text = "Refresh Market Data";
            chkRefreshMarketDataonStartup.UseVisualStyleBackColor = true;
            // 
            // gbExportOptions
            // 
            gbExportOptions.Controls.Add(rbtnExportSSV);
            gbExportOptions.Controls.Add(rbtnExportCSV);
            gbExportOptions.Controls.Add(rbtnExportDefault);
            gbExportOptions.Location = new Point(246, 347);
            gbExportOptions.Name = "gbExportOptions";
            gbExportOptions.Size = new Size(95, 102);
            gbExportOptions.TabIndex = 38;
            gbExportOptions.TabStop = false;
            gbExportOptions.Text = "Export Data in:";
            // 
            // rbtnExportSSV
            // 
            rbtnExportSSV.AutoSize = true;
            rbtnExportSSV.Location = new Point(9, 71);
            rbtnExportSSV.Name = "rbtnExportSSV";
            rbtnExportSSV.Size = new Size(46, 17);
            rbtnExportSSV.TabIndex = 2;
            rbtnExportSSV.TabStop = true;
            rbtnExportSSV.Text = "SSV";
            rbtnExportSSV.UseVisualStyleBackColor = true;
            // 
            // rbtnExportCSV
            // 
            rbtnExportCSV.AutoSize = true;
            rbtnExportCSV.Location = new Point(9, 48);
            rbtnExportCSV.Name = "rbtnExportCSV";
            rbtnExportCSV.Size = new Size(46, 17);
            rbtnExportCSV.TabIndex = 1;
            rbtnExportCSV.TabStop = true;
            rbtnExportCSV.Text = "CSV";
            rbtnExportCSV.UseVisualStyleBackColor = true;
            // 
            // rbtnExportDefault
            // 
            rbtnExportDefault.AutoSize = true;
            rbtnExportDefault.Location = new Point(9, 25);
            rbtnExportDefault.Name = "rbtnExportDefault";
            rbtnExportDefault.Size = new Size(59, 17);
            rbtnExportDefault.TabIndex = 0;
            rbtnExportDefault.TabStop = true;
            rbtnExportDefault.Text = "Default";
            rbtnExportDefault.UseVisualStyleBackColor = true;
            // 
            // gbCalcAvgPrice
            // 
            gbCalcAvgPrice.Controls.Add(cmbSVRAvgPriceDuration);
            gbCalcAvgPrice.Controls.Add(chkAutoUpdateSVRBPTab);
            gbCalcAvgPrice.Controls.Add(lblSVRRegion);
            gbCalcAvgPrice.Controls.Add(lblSVRAvgPrice);
            gbCalcAvgPrice.Controls.Add(cmbSVRRegion);
            gbCalcAvgPrice.Controls.Add(txtSVRThreshold);
            gbCalcAvgPrice.Controls.Add(lblSVRThreshold);
            gbCalcAvgPrice.Location = new Point(5, 362);
            gbCalcAvgPrice.Name = "gbCalcAvgPrice";
            gbCalcAvgPrice.Size = new Size(235, 87);
            gbCalcAvgPrice.TabIndex = 40;
            gbCalcAvgPrice.TabStop = false;
            gbCalcAvgPrice.Text = "SVR Settings:";
            // 
            // cmbSVRAvgPriceDuration
            // 
            cmbSVRAvgPriceDuration.FormattingEnabled = true;
            cmbSVRAvgPriceDuration.Items.AddRange(new object[] { "7", "15", "30", "60", "90", "180", "365" });
            cmbSVRAvgPriceDuration.Location = new Point(188, 14);
            cmbSVRAvgPriceDuration.MaxLength = 3;
            cmbSVRAvgPriceDuration.Name = "cmbSVRAvgPriceDuration";
            cmbSVRAvgPriceDuration.Size = new Size(41, 21);
            cmbSVRAvgPriceDuration.TabIndex = 3;
            // 
            // chkAutoUpdateSVRBPTab
            // 
            chkAutoUpdateSVRBPTab.AutoSize = true;
            chkAutoUpdateSVRBPTab.Location = new Point(17, 64);
            chkAutoUpdateSVRBPTab.Name = "chkAutoUpdateSVRBPTab";
            chkAutoUpdateSVRBPTab.Size = new Size(203, 17);
            chkAutoUpdateSVRBPTab.TabIndex = 39;
            chkAutoUpdateSVRBPTab.Text = "Automatically update SVR on BP Tab";
            chkAutoUpdateSVRBPTab.UseVisualStyleBackColor = true;
            // 
            // lblSVRRegion
            // 
            lblSVRRegion.AutoSize = true;
            lblSVRRegion.Location = new Point(17, 42);
            lblSVRRegion.Name = "lblSVRRegion";
            lblSVRRegion.Size = new Size(44, 13);
            lblSVRRegion.TabIndex = 4;
            lblSVRRegion.Text = "Region:";
            // 
            // lblSVRAvgPrice
            // 
            lblSVRAvgPrice.Location = new Point(111, 10);
            lblSVRAvgPrice.Name = "lblSVRAvgPrice";
            lblSVRAvgPrice.Size = new Size(78, 28);
            lblSVRAvgPrice.TabIndex = 2;
            lblSVRAvgPrice.Text = "Average Days:";
            lblSVRAvgPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbSVRRegion
            // 
            cmbSVRRegion.FormattingEnabled = true;
            cmbSVRRegion.Location = new Point(61, 39);
            cmbSVRRegion.Name = "cmbSVRRegion";
            cmbSVRRegion.Size = new Size(168, 21);
            cmbSVRRegion.TabIndex = 5;
            // 
            // txtSVRThreshold
            // 
            txtSVRThreshold.Location = new Point(61, 15);
            txtSVRThreshold.MaxLength = 10;
            txtSVRThreshold.Name = "txtSVRThreshold";
            txtSVRThreshold.Size = new Size(45, 20);
            txtSVRThreshold.TabIndex = 1;
            txtSVRThreshold.TextAlign = HorizontalAlignment.Right;
            // 
            // lblSVRThreshold
            // 
            lblSVRThreshold.AutoSize = true;
            lblSVRThreshold.Location = new Point(4, 18);
            lblSVRThreshold.Name = "lblSVRThreshold";
            lblSVRThreshold.Size = new Size(57, 13);
            lblSVRThreshold.TabIndex = 0;
            lblSVRThreshold.Text = "Threshold:";
            // 
            // gbProxySettings
            // 
            gbProxySettings.Controls.Add(txtProxyAddress);
            gbProxySettings.Controls.Add(lblProxyAddress);
            gbProxySettings.Controls.Add(txtProxyPort);
            gbProxySettings.Controls.Add(lblProxyPort);
            gbProxySettings.Location = new Point(347, 347);
            gbProxySettings.Name = "gbProxySettings";
            gbProxySettings.Size = new Size(311, 60);
            gbProxySettings.TabIndex = 41;
            gbProxySettings.TabStop = false;
            gbProxySettings.Text = "Proxy Settings:";
            // 
            // txtProxyAddress
            // 
            txtProxyAddress.Location = new Point(9, 29);
            txtProxyAddress.MaxLength = 0;
            txtProxyAddress.Name = "txtProxyAddress";
            txtProxyAddress.Size = new Size(245, 20);
            txtProxyAddress.TabIndex = 5;
            // 
            // lblProxyAddress
            // 
            lblProxyAddress.AutoSize = true;
            lblProxyAddress.Location = new Point(6, 15);
            lblProxyAddress.Name = "lblProxyAddress";
            lblProxyAddress.Size = new Size(48, 13);
            lblProxyAddress.TabIndex = 4;
            lblProxyAddress.Text = "Address:";
            // 
            // txtProxyPort
            // 
            txtProxyPort.Location = new Point(260, 29);
            txtProxyPort.MaxLength = 0;
            txtProxyPort.Name = "txtProxyPort";
            txtProxyPort.Size = new Size(45, 20);
            txtProxyPort.TabIndex = 3;
            // 
            // lblProxyPort
            // 
            lblProxyPort.AutoSize = true;
            lblProxyPort.Location = new Point(257, 15);
            lblProxyPort.Name = "lblProxyPort";
            lblProxyPort.Size = new Size(29, 13);
            lblProxyPort.TabIndex = 2;
            lblProxyPort.Text = "Port:";
            // 
            // gbCharacterOptions
            // 
            gbCharacterOptions.Controls.Add(chkLoadMaxAlphaSkills);
            gbCharacterOptions.Controls.Add(chkUseActiveSkills);
            gbCharacterOptions.Controls.Add(chkAlphaAccount);
            gbCharacterOptions.Location = new Point(246, 265);
            gbCharacterOptions.Name = "gbCharacterOptions";
            gbCharacterOptions.Size = new Size(160, 80);
            gbCharacterOptions.TabIndex = 39;
            gbCharacterOptions.TabStop = false;
            gbCharacterOptions.Text = "Character Options:";
            // 
            // chkLoadMaxAlphaSkills
            // 
            chkLoadMaxAlphaSkills.AutoSize = true;
            chkLoadMaxAlphaSkills.Location = new Point(9, 38);
            chkLoadMaxAlphaSkills.Name = "chkLoadMaxAlphaSkills";
            chkLoadMaxAlphaSkills.Size = new Size(147, 17);
            chkLoadMaxAlphaSkills.TabIndex = 33;
            chkLoadMaxAlphaSkills.Text = "Max Alpha Skills (Dummy)";
            chkLoadMaxAlphaSkills.UseVisualStyleBackColor = true;
            // 
            // chkUseActiveSkills
            // 
            chkUseActiveSkills.AutoSize = true;
            chkUseActiveSkills.Location = new Point(9, 57);
            chkUseActiveSkills.Name = "chkUseActiveSkills";
            chkUseActiveSkills.Size = new Size(105, 17);
            chkUseActiveSkills.TabIndex = 32;
            chkUseActiveSkills.Text = "Use Active Skills";
            chkUseActiveSkills.UseVisualStyleBackColor = true;
            // 
            // chkAlphaAccount
            // 
            chkAlphaAccount.AutoSize = true;
            chkAlphaAccount.Location = new Point(9, 16);
            chkAlphaAccount.Name = "chkAlphaAccount";
            chkAlphaAccount.Size = new Size(145, 17);
            chkAlphaAccount.TabIndex = 31;
            chkAlphaAccount.Text = "Alpha Account (.25% tax)";
            chkAlphaAccount.UseVisualStyleBackColor = true;
            // 
            // gbTaxRates
            // 
            gbTaxRates.Controls.Add(lblAdjustDefaultFees);
            gbTaxRates.Controls.Add(btnOpenRates);
            gbTaxRates.Location = new Point(410, 299);
            gbTaxRates.Name = "gbTaxRates";
            gbTaxRates.Size = new Size(250, 46);
            gbTaxRates.TabIndex = 39;
            gbTaxRates.TabStop = false;
            // 
            // lblAdjustDefaultFees
            // 
            lblAdjustDefaultFees.AutoSize = true;
            lblAdjustDefaultFees.Location = new Point(8, 20);
            lblAdjustDefaultFees.Name = "lblAdjustDefaultFees";
            lblAdjustDefaultFees.Size = new Size(128, 13);
            lblAdjustDefaultFees.TabIndex = 43;
            lblAdjustDefaultFees.Text = "Adjust Default Tax Rates:";
            // 
            // btnOpenRates
            // 
            btnOpenRates.Location = new Point(142, 11);
            btnOpenRates.Name = "btnOpenRates";
            btnOpenRates.Size = new Size(101, 30);
            btnOpenRates.TabIndex = 42;
            btnOpenRates.Text = "Edit Rates";
            btnOpenRates.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(665, 452);
            Controls.Add(gbTaxRates);
            Controls.Add(gbCharacterOptions);
            Controls.Add(gbBuildBuySettings);
            Controls.Add(gbProxySettings);
            Controls.Add(gbCalcAvgPrice);
            Controls.Add(gbExportOptions);
            Controls.Add(gbStartupOptions);
            Controls.Add(gbImplants);
            Controls.Add(gb3rdpartyMarketRefresh);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(gbStationStandings);
            Controls.Add(gbGeneral);
            Controls.Add(gbDefaultMEPE);
            Controls.Add(gbShoppingList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Application Settings";
            gbGeneral.ResumeLayout(false);
            gbGeneral.PerformLayout();
            gbStationStandings.ResumeLayout(false);
            gbStationStandings.PerformLayout();
            gbBuildBuySettings.ResumeLayout(false);
            gbBuildBuySettings.PerformLayout();
            gbDefaultMEPE.ResumeLayout(false);
            gbDefaultMEPE.PerformLayout();
            gbShoppingList.ResumeLayout(false);
            gbShoppingList.PerformLayout();
            gb3rdpartyMarketRefresh.ResumeLayout(false);
            gb3rdpartyMarketRefresh.PerformLayout();
            gbImplants.ResumeLayout(false);
            gbImplants.PerformLayout();
            gbStartupOptions.ResumeLayout(false);
            gbStartupOptions.PerformLayout();
            gbExportOptions.ResumeLayout(false);
            gbExportOptions.PerformLayout();
            gbCalcAvgPrice.ResumeLayout(false);
            gbCalcAvgPrice.PerformLayout();
            gbProxySettings.ResumeLayout(false);
            gbProxySettings.PerformLayout();
            gbCharacterOptions.ResumeLayout(false);
            gbCharacterOptions.PerformLayout();
            gbTaxRates.ResumeLayout(false);
            gbTaxRates.PerformLayout();
            Shown += new EventHandler(frmSettings_Shown);
            ResumeLayout(false);

        }
        internal CheckBox chkCheckUpdatesStartup;
        internal Button btnSave;
        internal Button btnCancel;
        internal GroupBox gbGeneral;
        internal CheckBox chkShowToolTips;
        internal CheckBox chkBeanCounterRefining;
        internal ComboBox cmbBeanCounterRefining;
        internal CheckBox chkBeanCounterManufacturing;
        internal ComboBox cmbBeanCounterManufacturing;
        internal GroupBox gbStationStandings;
        internal TextBox txtBrokerCorpStanding;
        internal CheckBox chkBrokerCorpStanding;
        internal TextBox txtBrokerFactionStanding;
        internal CheckBox chkBrokerFactionStanding;
        internal Button btnReset;
        internal GroupBox gbBuildBuySettings;
        internal CheckBox chkBuildBuyDefault;
        internal CheckBox chkBeanCounterCopy;
        internal ComboBox cmbBeanCounterCopy;
        internal GroupBox gbDefaultMEPE;
        internal TextBox txtDefaultTE;
        internal CheckBox chkDefaultTE;
        internal TextBox txtDefaultME;
        internal CheckBox chkDefaultME;
        internal CheckBox chkDisableSVR;
        internal ToolTip ToolTip1;
        internal GroupBox gbShoppingList;
        internal CheckBox chkIncludeShopListCopyMats;
        internal CheckBox chkIncludeShopListInventMats;
        internal CheckBox chkSuggestBuildwhenBPnotOwned;
        internal GroupBox gb3rdpartyMarketRefresh;
        internal TextBox txtFuzzworksMarketInterval;
        internal CheckBox chkFuzzworksMarketInterval;
        internal CheckBox chkRefreshAssetsonStartup;
        internal GroupBox gbImplants;
        internal CheckBox chkDisableSound;
        internal CheckBox chkRefreshBPsonStartup;
        internal GroupBox gbStartupOptions;
        internal CheckBox chkRefreshSystemCostIndiciesDataonStartup;
        internal CheckBox chkRefreshMarketDataonStartup;
        internal GroupBox gbExportOptions;
        internal RadioButton rbtnExportDefault;
        internal RadioButton rbtnExportSSV;
        internal RadioButton rbtnExportCSV;
        internal CheckBox chkSaveBPRelicsDecryptors;
        internal CheckBox chkLinksInCopyText;
        internal GroupBox gbCalcAvgPrice;
        internal Label lblSVRRegion;
        internal Label lblSVRAvgPrice;
        internal ComboBox cmbSVRRegion;
        internal TextBox txtSVRThreshold;
        internal Label lblSVRThreshold;
        internal ComboBox cmbSVRAvgPriceDuration;
        internal CheckBox chkAutoUpdateSVRBPTab;
        internal GroupBox gbProxySettings;
        internal TextBox txtProxyAddress;
        internal Label lblProxyAddress;
        internal TextBox txtProxyPort;
        internal Label lblProxyPort;
        internal CheckBox chkLoadBPsbyChar;
        internal CheckBox chkSaveFacilitiesbyChar;
        internal CheckBox chkRefreshPublicStructureDataonStartup;
        internal CheckBox chkDisableTracking;
        internal GroupBox gbCharacterOptions;
        internal CheckBox chkUseActiveSkills;
        internal CheckBox chkAlphaAccount;
        internal CheckBox chkSupressESImsgs;
        internal CheckBox chkLoadMaxAlphaSkills;
        internal CheckBox chkShareFacilities;
        internal CheckBox chkAlwaysBuyRAMs;
        internal CheckBox chkAlwaysBuyFuelBlocks;
        internal GroupBox gbTaxRates;
        internal Label lblAdjustDefaultFees;
        internal Button btnOpenRates;
    }
}