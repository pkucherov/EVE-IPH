using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmMain : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            mnuStripMain = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuSelectionAddChar = new ToolStripMenuItem();
            mnuSelectionAddChar.Click += new EventHandler(mnuSelectionAddChar_Click);
            mnuSelectionManageCharacters = new ToolStripMenuItem();
            mnuSelectionManageCharacters.Click += new EventHandler(mnuSelectionManageCharacters_Click);
            mnuViewErrorLog = new ToolStripMenuItem();
            mnuViewErrorLog.Click += new EventHandler(mnuViewErrorLog_Click);
            ToolStripSeparator1 = new ToolStripSeparator();
            mnuSelectionExit = new ToolStripMenuItem();
            mnuSelectionExit.Click += new EventHandler(mnuSelectionExit_Click);
            mnuEdit = new ToolStripMenuItem();
            mnuItemUpdatePrices = new ToolStripMenuItem();
            mnuItemUpdatePrices.Click += new EventHandler(mnuItemUpdatePrices_Click);
            SetPOSDataToolStripMenuItem = new ToolStripMenuItem();
            mnuManageBlueprintsToolStripMenuItem = new ToolStripMenuItem();
            mnuManageBlueprintsToolStripMenuItem.Click += new EventHandler(mnuManageBlueprintsToolStripMenuItem_Click);
            mnuClearBPHistory = new ToolStripMenuItem();
            mnuClearBPHistory.Click += new EventHandler(mnuClearBPHistory_Click);
            mnuUpdateData = new ToolStripMenuItem();
            mnuUpdateIndustryFacilities = new ToolStripMenuItem();
            mnuUpdateIndustryFacilities.Click += new EventHandler(UpdateIndustryFacilitiesToolStripMenuItem_Click);
            mnuUpdateESIMarketPrices = new ToolStripMenuItem();
            mnuUpdateESIMarketPrices.Click += new EventHandler(UpdateMarketPricesToolStripMenuItem_Click);
            mnuUpdateESIPublicStructures = new ToolStripMenuItem();
            mnuUpdateESIPublicStructures.Click += new EventHandler(mnuUpdateESIPublicStructures_Click);
            mnuChangeDummyCharacterName = new ToolStripMenuItem();
            mnuChangeDummyCharacterName.Click += new EventHandler(mnuChangeDummyCharacterName_Click);
            ToolStripSeparator6 = new ToolStripSeparator();
            mnuResetData = new ToolStripMenuItem();
            mnuResetBlueprintData = new ToolStripMenuItem();
            mnuResetBlueprintData.Click += new EventHandler(mnuResetBlueprintData_Click);
            mnuResetIgnoredBPs = new ToolStripMenuItem();
            mnuResetIgnoredBPs.Click += new EventHandler(mnuResetIgnoredBPs_Click);
            mnuResetPriceData = new ToolStripMenuItem();
            mnuResetPriceData.Click += new EventHandler(mnuResetPriceData_Click);
            mnuResetAgents = new ToolStripMenuItem();
            mnuResetAgents.Click += new EventHandler(mnuResetAgents_Click);
            mnuResetIndustryJobs = new ToolStripMenuItem();
            mnuResetIndustryJobs.Click += new EventHandler(mnuResetIndustryJobs_Click);
            mnuResetAssets = new ToolStripMenuItem();
            mnuResetAssets.Click += new EventHandler(mnuResetAssets_Click);
            mnuResetMarketHistory = new ToolStripMenuItem();
            mnuResetMarketHistory.Click += new EventHandler(mnuResetMarketHistory_Click);
            mnuResetMarketOrders = new ToolStripMenuItem();
            mnuResetMarketOrders.Click += new EventHandler(mnuResetMarketOrders_Click);
            mnuResetESIPublicStructures = new ToolStripMenuItem();
            mnuResetESIPublicStructures.Click += new EventHandler(mnuResetESIPublicStructures_Click);
            mnuResetSavedFacilities = new ToolStripMenuItem();
            mnuResetSavedFacilities.Click += new EventHandler(mnuResetSavedFacilities_Click);
            mnuResetESIIndustryFacilities = new ToolStripMenuItem();
            mnuResetESIIndustryFacilities.Click += new EventHandler(mnuResetESIIndustryFacilities_Click);
            mnuResetESIMarketPrices = new ToolStripMenuItem();
            mnuResetESIMarketPrices.Click += new EventHandler(mnuResetESIMarketPrices_Click);
            mnuResetESIDates = new ToolStripMenuItem();
            mnuResetESIDates.Click += new EventHandler(mnuResetESIDates_Click);
            ToolStripSeparator4 = new ToolStripSeparator();
            mnuResetAllData = new ToolStripMenuItem();
            mnuResetAllData.Click += new EventHandler(mnuResetAllData_Click);
            ViewToolStripMenuItem = new ToolStripMenuItem();
            mnuViewAssets = new ToolStripMenuItem();
            mnuViewAssets.Click += new EventHandler(mnuViewAssets_Click);
            mnuSelectionShoppingList = new ToolStripMenuItem();
            mnuSelectionShoppingList.Click += new EventHandler(mnuSelectionShoppingList_Click_1);
            mnuCharacterSkills = new ToolStripMenuItem();
            mnuCharacterSkills.Click += new EventHandler(mnuCharacterSkills_Click);
            mnuCharacterStandings = new ToolStripMenuItem();
            mnuCharacterStandings.Click += new EventHandler(mnuCharacterStandings_Click);
            ToolStripSeparator5 = new ToolStripSeparator();
            mnuCurrentResearchAgents = new ToolStripMenuItem();
            mnuCurrentResearchAgents.Click += new EventHandler(mnuCurrentResearchAgents_Click);
            mnuCurrentIndustryJobs = new ToolStripMenuItem();
            mnuCurrentIndustryJobs.Click += new EventHandler(mnuCurrentIndustryJobs_Click);
            ToolStripSeparator3 = new ToolStripSeparator();
            mnuViewESIStatus = new ToolStripMenuItem();
            mnuViewESIStatus.Click += new EventHandler(mnuViewESIStatus_Click);
            mnuTools = new ToolStripMenuItem();
            mnuMETECalculator = new ToolStripMenuItem();
            mnuMETECalculator.Click += new EventHandler(mnuMETECalculator_Click);
            mnuReprocessingPlant = new ToolStripMenuItem();
            mnuReprocessingPlant.Click += new EventHandler(mnuReprocessingPlant_Click);
            mnuOreFlips = new ToolStripMenuItem();
            mnuAnomalyOreBelts = new ToolStripMenuItem();
            mnuAnomalyOreBelts.Click += new EventHandler(mnuAnomalyOreBeltsUpgradeBelts_Click);
            mnuIceBelts = new ToolStripMenuItem();
            mnuIceBelts.Click += new EventHandler(mnuIceBelts_Click);
            mnuSettings = new ToolStripMenuItem();
            mnuUserSettings = new ToolStripMenuItem();
            mnuUserSettings.Click += new EventHandler(mnuUserSettings_Click);
            mnuSelectDefaultChar = new ToolStripMenuItem();
            mnuSelectDefaultChar.Click += new EventHandler(mnuSelectDefaultChar_Click);
            mnuRestoreDefaultTabSettings = new ToolStripMenuItem();
            mnuRestoreDefaultBP = new ToolStripMenuItem();
            mnuRestoreDefaultBP.Click += new EventHandler(mnuRestoreDefaultBP_Click);
            mnuRestoreDefaultUpdatePrices = new ToolStripMenuItem();
            mnuRestoreDefaultUpdatePrices.Click += new EventHandler(mnuRestoreDefaultUpdatePrices_Click);
            mnuRestoreDefaultManufacturing = new ToolStripMenuItem();
            mnuRestoreDefaultManufacturing.Click += new EventHandler(mnuRestoreDefaultManufacturing_Click);
            mnuRestoreDefaultDatacores = new ToolStripMenuItem();
            mnuRestoreDefaultDatacores.Click += new EventHandler(mnuRestoreDefaultDatacores_Click);
            mnuRestoreDefaultMining = new ToolStripMenuItem();
            mnuRestoreDefaultMining.Click += new EventHandler(mnuRestoreDefaultMining_Click);
            mnuResetBuildBuyManualSelections = new ToolStripMenuItem();
            mnuResetBuildBuyManualSelections.Click += new EventHandler(mnuResetBuildBuyManualSelections_Click);
            mnuAbout = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuYouTube = new ToolStripMenuItem();
            mnuYouTube.Click += new EventHandler(mnuYouTube_Click);
            mnuDiscord = new ToolStripMenuItem();
            mnuDiscord.Click += new EventHandler(mnuDiscord_Click);
            mnuPatchNotes = new ToolStripMenuItem();
            mnuPatchNotes.Click += new EventHandler(mnuPatchNotes_Click);
            mnuCheckforUpdates = new ToolStripMenuItem();
            mnuCheckforUpdates.Click += new EventHandler(mnuCheckforUpdates_Click);
            ToolStripSeparator2 = new ToolStripSeparator();
            mnuSelectionAbout = new ToolStripMenuItem();
            mnuSelectionAbout.Click += new EventHandler(mnuSelectionAbout_Click);
            pnlMain = new StatusStrip();
            mnuCharacter = new ToolStripDropDownButton();
            tsCharacter1 = new ToolStripMenuItem();
            tsCharacter1.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter2 = new ToolStripMenuItem();
            tsCharacter2.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter3 = new ToolStripMenuItem();
            tsCharacter3.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter4 = new ToolStripMenuItem();
            tsCharacter4.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter5 = new ToolStripMenuItem();
            tsCharacter5.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter6 = new ToolStripMenuItem();
            tsCharacter6.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter7 = new ToolStripMenuItem();
            tsCharacter7.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter8 = new ToolStripMenuItem();
            tsCharacter8.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter9 = new ToolStripMenuItem();
            tsCharacter9.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter10 = new ToolStripMenuItem();
            tsCharacter10.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter11 = new ToolStripMenuItem();
            tsCharacter11.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter12 = new ToolStripMenuItem();
            tsCharacter12.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter13 = new ToolStripMenuItem();
            tsCharacter13.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter14 = new ToolStripMenuItem();
            tsCharacter14.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter15 = new ToolStripMenuItem();
            tsCharacter15.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter16 = new ToolStripMenuItem();
            tsCharacter16.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter17 = new ToolStripMenuItem();
            tsCharacter17.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter18 = new ToolStripMenuItem();
            tsCharacter18.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter19 = new ToolStripMenuItem();
            tsCharacter19.Click += new EventHandler(CharacterNameToolStrip_Click);
            tsCharacter20 = new ToolStripMenuItem();
            tsCharacter20.Click += new EventHandler(CharacterNameToolStrip_Click);
            pnlSkills = new ToolStripStatusLabel();
            pnlSkills.Click += new EventHandler(pnlSkills_Click);
            pnlShoppingList = new ToolStripStatusLabel();
            pnlShoppingList.Click += new EventHandler(pnlShoppingList_Click);
            pnlStatus = new ToolStripStatusLabel();
            pnlProgressBar = new ToolStripProgressBar();
            txtListEdit = new TextBox();
            txtListEdit.GotFocus += new EventHandler(txtListEdit_GotFocus);
            txtListEdit.KeyDown += new KeyEventHandler(txtListEdit_KeyDown);
            txtListEdit.KeyPress += new KeyPressEventHandler(txtListEdit_KeyPress);
            txtListEdit.LostFocus += new EventHandler(txtListEdit_LostFocus);
            txtListEdit.TextChanged += new EventHandler(txtListEdit_TextChanged);
            _ttBP = new ToolTip(components);
            OpenFileDialog = new OpenFileDialog();
            SaveFileDialog = new SaveFileDialog();
            gbSystems = new GroupBox();
            ListOptionsMenu = new ContextMenuStrip(components);
            ListOptionsMenu.Opening += new System.ComponentModel.CancelEventHandler(ListOptionsMenu_Opening);
            ViewMarketHistoryToolStripMenuItem = new ToolStripMenuItem();
            ViewMarketHistoryToolStripMenuItem.Click += new EventHandler(ViewMarketHistoryToolStripMenuItem_Click);
            AddToShoppingListToolStripMenuItem = new ToolStripMenuItem();
            AddToShoppingListToolStripMenuItem.Click += new EventHandler(AddToShoppingListToolStripMenuItem_Click);
            IgnoreBlueprintToolStripMenuItem = new ToolStripMenuItem();
            IgnoreBlueprintToolStripMenuItem.Click += new EventHandler(IgnoreBlueprintToolStripMenuItem_Click);
            FavoriteBlueprintToolStripMenuItem = new ToolStripMenuItem();
            FavoriteBlueprintToolStripMenuItem.Click += new EventHandler(FavoriteBlueprintToolStripMenuItem_Click);
            ttUpdatePrices = new ToolTip(components);
            rbtnPriceSourceFW = new RadioButton();
            rbtnPriceSourceFW.CheckedChanged += new EventHandler(PriceSourceSelection_CheckedChanged);
            ttManufacturing = new ToolTip(components);
            ttDatacores = new ToolTip(components);
            ttReactions = new ToolTip(components);
            ttMining = new ToolTip(components);
            chkMineEDENCOM = new CheckBox();
            ttPI = new ToolTip(components);
            CalcImageList = new ImageList(components);
            cmbEdit = new ComboBox();
            cmbEdit.DropDownClosed += new EventHandler(cmbEdit_DropDownClosed);
            cmbEdit.SelectedIndexChanged += new EventHandler(cmbEdit_SelectedIndexChanged);
            cmbEdit.LostFocus += new EventHandler(cmbEdit_LostFocus);
            tabPI = new TabPage();
            btnPISaveSettings = new Button();
            gbPIPlanets = new GroupBox();
            chkPILava = new CheckBox();
            chkPIPlasma = new CheckBox();
            chkPIIce = new CheckBox();
            chkPIGas = new CheckBox();
            chkPIOcean = new CheckBox();
            chkPIBarren = new CheckBox();
            chkPIStorm = new CheckBox();
            chkPITemperate = new CheckBox();
            btnPIReset = new Button();
            tabMining = new TabPage();
            gbMineCrystalType = new GroupBox();
            chkMineTypeC = new CheckBox();
            chkMineTypeB = new CheckBox();
            chkMineTypeA = new CheckBox();
            tabMiningDrones = new TabControl();
            tabShipDrones = new TabPage();
            lblMineDroneIdealRange = new Label();
            cmbMineDroneName = new ComboBox();
            cmbMineDroneName.SelectedIndexChanged += new EventHandler(cmbMineDroneName_SelectedIndexChanged);
            lblMineMiningDroneYield = new Label();
            cmbMineDroneOpSkill = new ComboBox();
            cmbMineDroneOpSkill.SelectedIndexChanged += new EventHandler(cmbMineDroneOpSkill_SelectedIndexChanged);
            lblMineMiningDroneM3 = new Label();
            lblMineDroneOpSkill = new Label();
            lblMineNumMiningDrones = new Label();
            cmbMineDroneSpecSkill = new ComboBox();
            cmbMineDroneSpecSkill.SelectedIndexChanged += new EventHandler(cmbMineDroneSpecSkill_SelectedIndexChanged);
            cmbMineNumMiningDrones = new ComboBox();
            cmbMineNumMiningDrones.SelectedIndexChanged += new EventHandler(cmbMineNumMiningDrones_SelectedIndexChanged);
            lblMineDroneSpecSkill = new Label();
            lblMineDroneInterfacingSkill = new Label();
            lblMineDroneName = new Label();
            cmbMineDroneInterfacingSkill = new ComboBox();
            cmbMineDroneInterfacingSkill.SelectedIndexChanged += new EventHandler(cmbMineDroneInterfacingSkill_SelectedIndexChanged);
            tabBoosterDrones = new TabPage();
            lblMineBoosterDroneIdealRange = new Label();
            cmbMineBoosterDroneName = new ComboBox();
            cmbMineBoosterDroneName.SelectedIndexChanged += new EventHandler(cmbMineBoosterDroneName_SelectedIndexChanged);
            lblMineBoosterMiningDroneYield = new Label();
            cmbMineBoosterDroneOpSkill = new ComboBox();
            cmbMineBoosterDroneOpSkill.SelectedIndexChanged += new EventHandler(cmbMineBoosterDroneOpSkill_SelectedIndexChanged);
            lblMineBoosterMiningDroneM3 = new Label();
            lblMineBoosterDroneOpSkill = new Label();
            lblMineBoosterNumMiningDrones = new Label();
            cmbMineBoosterDroneSpecSkill = new ComboBox();
            cmbMineBoosterDroneSpecSkill.SelectedIndexChanged += new EventHandler(cmbMineBoosterDroneSpecSkill_SelectedIndexChanged);
            cmbMineBoosterNumMiningDrones = new ComboBox();
            cmbMineBoosterNumMiningDrones.SelectedIndexChanged += new EventHandler(cmbMineBoosterNumMiningDrones_SelectedIndexChanged);
            lblMineBoosterDroneSpecSkill = new Label();
            lblMineBoosterDroneInterfacingSkill = new Label();
            lblMineBoosterDroneName = new Label();
            cmbMineBoosterDroneInterfacingSkill = new ComboBox();
            cmbMineBoosterDroneInterfacingSkill.SelectedIndexChanged += new EventHandler(cmbMineBoosterDroneInterfacingSkill_SelectedIndexChanged);
            gbMineCrystals = new GroupBox();
            chkMineT2Crystals = new CheckBox();
            chkMineT1Crystals = new CheckBox();
            gbMineNumberMiners = new GroupBox();
            txtMineNumberMiners = new TextBox();
            txtMineNumberMiners.KeyPress += new KeyPressEventHandler(txtMineNumberMiners_KeyPress);
            lblMineNumberMiners = new Label();
            gbMineOreProcessingType = new GroupBox();
            chkMineUnrefinedOre = new CheckBox();
            chkMineRefinedOre = new CheckBox();
            chkMineRefinedOre.CheckedChanged += new EventHandler(chkMineRefinedOre_CheckedChanged);
            chkMineCompressedOre = new CheckBox();
            btnMineSaveAllSettings = new Button();
            btnMineSaveAllSettings.Click += new EventHandler(btnMineSaveSettings_Click);
            gbMineTaxBroker = new GroupBox();
            txtMineBrokerFeeRate = new TextBox();
            txtMineBrokerFeeRate.KeyDown += new KeyEventHandler(txtMineBrokerFeeRate_KeyDown);
            txtMineBrokerFeeRate.KeyPress += new KeyPressEventHandler(txtMineBrokerFeeRate_KeyPress);
            txtMineBrokerFeeRate.GotFocus += new EventHandler(txtMineBrokerFeeRate_GotFocus);
            txtMineBrokerFeeRate.LostFocus += new EventHandler(txtMineBrokerFeeRate_LostFocus);
            chkMineIncludeBrokerFees = new CheckBox();
            chkMineIncludeBrokerFees.Click += new EventHandler(chkMineIncludeBrokerFees_Click);
            chkMineIncludeTaxes = new CheckBox();
            gbMineStripStats = new GroupBox();
            lblMineRange = new Label();
            lblMineCycleTime1 = new Label();
            lblMineRange1 = new Label();
            lblMineCycleTime = new Label();
            chkMineUseFleetBooster = new CheckBox();
            chkMineUseFleetBooster.CheckedChanged += new EventHandler(chkMineUseFleetBooster_CheckedChanged);
            btnMineReset = new Button();
            btnMineReset.Click += new EventHandler(btnMineReset_Click);
            gbMineHauling = new GroupBox();
            txtMineHaulerM3 = new TextBox();
            txtMineHaulerM3.GotFocus += new EventHandler(txtMineHaulerM3_GotFocus);
            txtMineHaulerM3.KeyPress += new KeyPressEventHandler(txtMineHaulerM3_KeyPress);
            txtMineHaulerM3.LostFocus += new EventHandler(txtMineHaulerM3_LostFocus);
            lblMineHaulerM3 = new Label();
            lblMineRTSec = new Label();
            chkMineUseHauler = new CheckBox();
            chkMineUseHauler.CheckedChanged += new EventHandler(chkMineUseHauler_CheckedChanged);
            lblMineRTMin = new Label();
            txtMineRTMin = new TextBox();
            txtMineRTMin.GotFocus += new EventHandler(txtMineRTMin_GotFocus);
            txtMineRTMin.KeyPress += new KeyPressEventHandler(txtMineRTMin_KeyPress);
            txtMineRTSec = new TextBox();
            txtMineRTSec.GotFocus += new EventHandler(txtMineRTSec_GotFocus);
            txtMineRTSec.KeyPress += new KeyPressEventHandler(txtMineRTSec_KeyPress);
            txtMineRTSec.TextChanged += new EventHandler(txtMineRTSec_TextChanged);
            lblMineRoundTripTime = new Label();
            btnMineRefresh = new Button();
            btnMineRefresh.Click += new EventHandler(btnMineRefresh_Click);
            gbMineBooster = new GroupBox();
            chkMineBoosterDroneRig3 = new CheckBox();
            chkMineBoosterDroneRig3.Click += new EventHandler(BoosterMiningDroneRigs_Click);
            pictMineLaserOptmize = new PictureBox();
            pictMineRangeLink = new PictureBox();
            chkMineBoosterDroneRig2 = new CheckBox();
            chkMineBoosterDroneRig2.Click += new EventHandler(BoosterMiningDroneRigs_Click);
            chkMineBoosterDroneRig1 = new CheckBox();
            chkMineBoosterDroneRig1.Click += new EventHandler(BoosterMiningDroneRigs_Click);
            chkMineBoosterUseDrones = new CheckBox();
            chkMineBoosterUseDrones.CheckedChanged += new EventHandler(chkMineBoosterUseDrones_CheckedChanged);
            pictMineFleetBoostShip = new PictureBox();
            chkMineForemanLaserRangeBoost = new CheckBox();
            chkMineForemanLaserRangeBoost.Click += new EventHandler(chkMineForemanLaserRangeBoost_Click);
            chkMineIndyCoreDeployedMode = new CheckBox();
            chkMineIndyCoreDeployedMode.Click += new EventHandler(chkMineRorqDeployedMode_Click);
            cmbMineBoosterShipSkill = new ComboBox();
            chkMineForemanMindlink = new CheckBox();
            cmbMineBoosterShipName = new ComboBox();
            cmbMineBoosterShipName.SelectedIndexChanged += new EventHandler(cmbMineBoosterShip_SelectedIndexChanged);
            cmbMineMiningDirector = new ComboBox();
            cmbMineMiningDirector.SelectedIndexChanged += new EventHandler(cmbMineMiningDirector_SelectedIndexChanged);
            chkMineForemanLaserOpBoost = new CheckBox();
            chkMineForemanLaserOpBoost.Click += new EventHandler(chkMineForemanBooster_Click);
            lblMineMiningDirector = new Label();
            cmbMineMiningForeman = new ComboBox();
            cmbMineMiningForeman.SelectedIndexChanged += new EventHandler(cmbMineMiningForeman_SelectedIndexChanged);
            lblMineFleetBoosterShip = new Label();
            lblMineMiningForeman = new Label();
            lblMineBoosterShipSkill = new Label();
            cmbMineIndustReconfig = new ComboBox();
            lblMineIndustrialReconfig = new Label();
            gbMineRefining = new GroupBox();
            gbMineOreStuctureRates = new GroupBox();
            lblMineFacilityOreRate = new Label();
            lblMineFacilityMoonOreRate = new Label();
            lblMineFacilityOreRate1 = new Label();
            lblMineFacilityMoonOreRate1 = new Label();
            cmbMineRefining = new ComboBox();
            cmbMineRefining.SelectedIndexChanged += new EventHandler(cmbMineRefining_SelectedIndexChanged);
            lblMineRefining = new Label();
            cmbMineRefineryEff = new ComboBox();
            cmbMineRefineryEff.SelectedIndexChanged += new EventHandler(cmbMineRefineryEff_SelectedIndexChanged);
            lblMineRefineryEfficiency = new Label();
            MineRefineFacility = new ManufacturingFacility();
            tabMiningProcessingSkills = new TabControl();
            tabPageOres = new TabPage();
            chkOreProcessing1 = new CheckBox();
            chkOreProcessing1.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            cmbOreProcessing2 = new ComboBox();
            lblOreProcessing2 = new Label();
            chkOreProcessing3 = new CheckBox();
            chkOreProcessing3.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            chkOreProcessing2 = new CheckBox();
            chkOreProcessing2.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            chkOreProcessing6 = new CheckBox();
            chkOreProcessing6.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            cmbOreProcessing1 = new ComboBox();
            lblOreProcessing1 = new Label();
            lblOreProcessing6 = new Label();
            chkOreProcessing5 = new CheckBox();
            chkOreProcessing5.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            cmbOreProcessing6 = new ComboBox();
            lblOreProcessing3 = new Label();
            lblOreProcessing5 = new Label();
            cmbOreProcessing4 = new ComboBox();
            cmbOreProcessing3 = new ComboBox();
            chkOreProcessing4 = new CheckBox();
            chkOreProcessing4.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            lblOreProcessing4 = new Label();
            cmbOreProcessing5 = new ComboBox();
            tabPageMoonOres = new TabPage();
            lblOreProcessing7 = new Label();
            lblOreProcessing8 = new Label();
            lblOreProcessing10 = new Label();
            lblOreProcessing11 = new Label();
            cmbOreProcessing11 = new ComboBox();
            chkOreProcessing9 = new CheckBox();
            chkOreProcessing9.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            lblOreProcessing9 = new Label();
            chkOreProcessing8 = new CheckBox();
            chkOreProcessing8.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            cmbOreProcessing10 = new ComboBox();
            cmbOreProcessing7 = new ComboBox();
            chkOreProcessing10 = new CheckBox();
            chkOreProcessing10.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            chkOreProcessing7 = new CheckBox();
            chkOreProcessing7.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            cmbOreProcessing9 = new ComboBox();
            chkOreProcessing11 = new CheckBox();
            chkOreProcessing11.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            cmbOreProcessing8 = new ComboBox();
            tabPageIce = new TabPage();
            cmbOreProcessing12 = new ComboBox();
            lblOreProcessing12 = new Label();
            chkOreProcessing12 = new CheckBox();
            chkOreProcessing12.CheckedChanged += new EventHandler(OreCheckProcessing_CheckedChanged);
            gbMineShipSetup = new GroupBox();
            gbMineSelectShip = new GroupBox();
            pictMineSelectedShip = new PictureBox();
            lblMineSelectShip = new Label();
            cmbMineBaseShipSkill = new ComboBox();
            cmbMineBaseShipSkill.SelectedIndexChanged += new EventHandler(cmbMineBaseShipSkill_SelectedIndexChanged);
            cmbMineAdvShipSkill = new ComboBox();
            cmbMineAdvShipSkill.SelectedIndexChanged += new EventHandler(cmbMineAdvShipSkill_SelectedIndexChanged);
            cmbMineShipName = new ComboBox();
            cmbMineShipName.SelectedIndexChanged += new EventHandler(cmbMineShipName_SelectedIndexChanged);
            cmbMineShipName.DropDown += new EventHandler(cmbMineShipName_DropDown);
            lblMineBaseShipSkill = new Label();
            lblMineExhumers = new Label();
            gbMineShipEquipment = new GroupBox();
            gbMiningRigs = new GroupBox();
            cmbMineMiningRig3 = new ComboBox();
            cmbMineMiningRig3.SelectedIndexChanged += new EventHandler(ShipMiningDroneRigs_SelectedIndexChanged);
            cmbMineMiningRig1 = new ComboBox();
            cmbMineMiningRig1.SelectedIndexChanged += new EventHandler(ShipMiningDroneRigs_SelectedIndexChanged);
            cmbMineMiningRig2 = new ComboBox();
            cmbMineMiningRig2.SelectedIndexChanged += new EventHandler(ShipMiningDroneRigs_SelectedIndexChanged);
            cmbMineMiningLaser = new ComboBox();
            cmbMineMiningLaser.SelectedIndexChanged += new EventHandler(cmbMineMiningLaser_SelectedIndexChanged);
            cmbMineNumMiningUpgrades = new ComboBox();
            cmbMineNumLasers = new ComboBox();
            cmbMineMiningUpgrade = new ComboBox();
            cmbMineMiningUpgrade.SelectedIndexChanged += new EventHandler(cmbMineMiningUpgrade_SelectedIndexChanged);
            cmbMineHighwallImplant = new ComboBox();
            chkMineMichiImplant = new CheckBox();
            lblMineImplants = new Label();
            lblMineLaserNumber = new Label();
            lblMineNumMiningUpgrades = new Label();
            lblMineMinerTurret = new Label();
            lblMineMiningUpgrade = new Label();
            gbMineSkills = new GroupBox();
            cmbMineGasIceHarvesting = new ComboBox();
            cmbMineGasIceHarvesting.SelectedIndexChanged += new EventHandler(cmbMineIceHarvesting_SelectedIndexChanged);
            lblMineGasIceHarvesting = new Label();
            cmbMineDeepCore = new ComboBox();
            cmbMineDeepCore.SelectedIndexChanged += new EventHandler(cmbMineDeepCore_SelectedIndexChanged);
            lblMineAstrogeology = new Label();
            cmbMineSkill = new ComboBox();
            cmbMineSkill.SelectedIndexChanged += new EventHandler(cmbMineSkill_SelectedIndexChanged);
            lblMineSkill = new Label();
            cmbMineAstrogeology = new ComboBox();
            cmbMineAstrogeology.SelectedIndexChanged += new EventHandler(cmbMineAstrogeology_SelectedIndexChanged);
            lblMineDeepCore = new Label();
            gbMineMain = new GroupBox();
            gbMineIncludeOres = new GroupBox();
            chkMineIncludeA0StarOres = new CheckBox();
            chkMineIncludeHighSec = new CheckBox();
            chkMineIncludeNullSec = new CheckBox();
            chkMineIncludeNullSec.CheckedChanged += new EventHandler(chkMineIncludeNullSec_CheckedChanged);
            chkMineIncludeLowSec = new CheckBox();
            chkMineIncludeHighYieldOre = new CheckBox();
            cmbMineOreType = new ComboBox();
            cmbMineOreType.SelectedIndexChanged += new EventHandler(cmbMineType_SelectedIndexChanged);
            gbMineOreLocSov = new GroupBox();
            chkMineMoonMining = new CheckBox();
            chkMineMoonMining.CheckedChanged += new EventHandler(MiningSpace_CheckChange);
            chkMineTriglavian = new CheckBox();
            chkMineTriglavian.CheckedChanged += new EventHandler(MiningSpace_CheckChange);
            chkMineWH = new CheckBox();
            chkMineWH.CheckedChanged += new EventHandler(chkMineWH_CheckedChanged);
            gbMineWHSpace = new GroupBox();
            chkMineC6 = new CheckBox();
            chkMineC5 = new CheckBox();
            chkMineC4 = new CheckBox();
            chkMineC3 = new CheckBox();
            chkMineC2 = new CheckBox();
            chkMineC1 = new CheckBox();
            chkMineCaldari = new CheckBox();
            chkMineCaldari.CheckedChanged += new EventHandler(MiningSpace_CheckChange);
            chkMineMinmatar = new CheckBox();
            chkMineMinmatar.CheckedChanged += new EventHandler(MiningSpace_CheckChange);
            chkMineGallente = new CheckBox();
            chkMineGallente.CheckedChanged += new EventHandler(MiningSpace_CheckChange);
            chkMineAmarr = new CheckBox();
            chkMineAmarr.CheckedChanged += new EventHandler(MiningSpace_CheckChange);
            lblMineType = new Label();
            lstMineGrid = new ListView();
            lstMineGrid.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lstMineGrid_ColumnWidthChanging);
            lstMineGrid.MouseClick += new MouseEventHandler(lstMineGrid_MouseClick);
            lstMineGrid.ColumnClick += new ColumnClickEventHandler(lstMineGrid_ColumnClick);
            lstMineGrid.SelectedIndexChanged += new EventHandler(lstMineGrid_SelectedIndexChanged);
            tabDatacores = new TabPage();
            lstDC = new ListView();
            lstDC.ItemCheck += new ItemCheckEventHandler(lstDC_ItemCheck);
            lstDC.ItemChecked += new ItemCheckedEventHandler(lstDC_ItemChecked);
            lstDC.ColumnClick += new ColumnClickEventHandler(lstDC_ColumnClick);
            gbDCOptions = new GroupBox();
            btnDCSaveSettings = new Button();
            btnDCSaveSettings.Click += new EventHandler(btnDCSaveSettings_Click);
            gbDCAgentLocSov = new GroupBox();
            chkDCThukkerSov = new CheckBox();
            chkDCKhanidSov = new CheckBox();
            chkDCMinmatarSov = new CheckBox();
            chkDCSyndicateSov = new CheckBox();
            chkDCGallenteSov = new CheckBox();
            chkDCAmarrSov = new CheckBox();
            chkDCAmmatarSov = new CheckBox();
            chkDCCaldariSov = new CheckBox();
            gbDCTotalIPH = new GroupBox();
            lblDCTotalOptIPH = new Label();
            lblDCTotalSelectedIPH = new Label();
            txtDCTotalSelectedIPH = new TextBox();
            txtDCTotalOptIPH = new TextBox();
            gbDCPrices = new GroupBox();
            rbtnDCSystemPrices = new RadioButton();
            rbtnDCSystemPrices.MouseEnter += new EventHandler(rbtnDCSystemPrices_MouseEnter);
            rbtnDCRegionPrices = new RadioButton();
            rbtnDCRegionPrices.MouseEnter += new EventHandler(rbtnDCRegionPrices_MouseEnter);
            rbtnDCUpdatedPrices = new RadioButton();
            gbDCAgentTypes = new GroupBox();
            cmbDCRegions = new ComboBox();
            cmbDCRegions.DropDown += new EventHandler(cmbDCRegions_DropDown);
            lblDCRegion = new Label();
            chkDCLowSecAgents = new CheckBox();
            chkDCHighSecAgents = new CheckBox();
            chkDCIncludeAllAgents = new CheckBox();
            gbDCBaseSkills = new GroupBox();
            cmbDCResearchMgmt = new ComboBox();
            lblDCResearchManagement = new Label();
            lblDCNegotiation = new Label();
            cmbDCConnections = new ComboBox();
            cmbDCConnections.SelectedIndexChanged += new EventHandler(cmbDCConnections_SelectedIndexChanged);
            lblDCConnections = new Label();
            cmbDCNegotiation = new ComboBox();
            gbDCDatacores = new GroupBox();
            cmbDCSkillLevel17 = new ComboBox();
            cmbDCSkillLevel16 = new ComboBox();
            cmbDCSkillLevel15 = new ComboBox();
            cmbDCSkillLevel14 = new ComboBox();
            cmbDCSkillLevel13 = new ComboBox();
            cmbDCSkillLevel12 = new ComboBox();
            cmbDCSkillLevel11 = new ComboBox();
            cmbDCSkillLevel10 = new ComboBox();
            cmbDCSkillLevel9 = new ComboBox();
            cmbDCSkillLevel8 = new ComboBox();
            cmbDCSkillLevel7 = new ComboBox();
            cmbDCSkillLevel6 = new ComboBox();
            cmbDCSkillLevel5 = new ComboBox();
            cmbDCSkillLevel4 = new ComboBox();
            cmbDCSkillLevel3 = new ComboBox();
            cmbDCSkillLevel2 = new ComboBox();
            cmbDCSkillLevel1 = new ComboBox();
            chkDC17 = new CheckBox();
            chkDC17.CheckedChanged += new EventHandler(chkDC17_CheckedChanged);
            chkDC4 = new CheckBox();
            chkDC4.CheckedChanged += new EventHandler(chkDC4_CheckedChanged);
            chkDC16 = new CheckBox();
            chkDC16.CheckedChanged += new EventHandler(chkDC16_CheckedChanged);
            chkDC3 = new CheckBox();
            chkDC3.CheckedChanged += new EventHandler(chkDC3_CheckedChanged);
            lblDatacore17 = new Label();
            lblDatacore17.Click += new EventHandler(lblDatacore17_Click);
            chkDC15 = new CheckBox();
            chkDC15.CheckedChanged += new EventHandler(chkDC15_CheckedChanged);
            chkDC2 = new CheckBox();
            chkDC2.CheckedChanged += new EventHandler(chkDC2_CheckedChanged);
            chkDC14 = new CheckBox();
            chkDC14.CheckedChanged += new EventHandler(chkDC14_CheckedChanged);
            chkDC1 = new CheckBox();
            chkDC1.CheckedChanged += new EventHandler(chkDC1_CheckedChanged);
            chkDC13 = new CheckBox();
            chkDC13.CheckedChanged += new EventHandler(chkDC13_CheckedChanged);
            chkDC12 = new CheckBox();
            chkDC12.CheckedChanged += new EventHandler(chkDC12_CheckedChanged);
            chkDC11 = new CheckBox();
            chkDC11.CheckedChanged += new EventHandler(chkDC11_CheckedChanged);
            chkDC10 = new CheckBox();
            chkDC10.CheckedChanged += new EventHandler(chkDC10_CheckedChanged);
            lblDatacore16 = new Label();
            lblDatacore16.Click += new EventHandler(lblDatacore16_Click);
            lblDatacore4 = new Label();
            lblDatacore4.Click += new EventHandler(lblDatacore4_Click);
            lblDatacore15 = new Label();
            lblDatacore15.Click += new EventHandler(lblDatacore15_Click);
            chkDC9 = new CheckBox();
            chkDC9.CheckedChanged += new EventHandler(chkDC9_CheckedChanged);
            lblDatacore14 = new Label();
            lblDatacore14.Click += new EventHandler(lblDatacore14_Click);
            lblDatacore3 = new Label();
            lblDatacore3.Click += new EventHandler(lblDatacore3_Click);
            chkDC8 = new CheckBox();
            chkDC8.CheckedChanged += new EventHandler(chkDC8_CheckedChanged);
            lblDatacore13 = new Label();
            lblDatacore13.Click += new EventHandler(lblDatacore13_Click);
            lblDatacore2 = new Label();
            lblDatacore2.Click += new EventHandler(lblDatacore2_Click);
            chkDC7 = new CheckBox();
            chkDC7.CheckedChanged += new EventHandler(chkDC7_CheckedChanged);
            chkDC6 = new CheckBox();
            chkDC6.CheckedChanged += new EventHandler(chkDC6_CheckedChanged);
            lblDatacore1 = new Label();
            lblDatacore1.Click += new EventHandler(lblDatacore1_Click);
            chkDC5 = new CheckBox();
            chkDC5.CheckedChanged += new EventHandler(chkDC5_CheckedChanged);
            lblDatacore5 = new Label();
            lblDatacore5.Click += new EventHandler(lblDatacore5_Click);
            lblDatacore6 = new Label();
            lblDatacore6.Click += new EventHandler(lblDatacore6_Click);
            lblDatacore7 = new Label();
            lblDatacore7.Click += new EventHandler(lblDatacore7_Click);
            lblDatacore8 = new Label();
            lblDatacore8.Click += new EventHandler(lblDatacore8_Click);
            lblDatacore12 = new Label();
            lblDatacore12.Click += new EventHandler(lblDatacore12_Click);
            lblDatacore11 = new Label();
            lblDatacore11.Click += new EventHandler(lblDatacore11_Click);
            lblDatacore10 = new Label();
            lblDatacore10.Click += new EventHandler(lblDatacore10_Click);
            lblDatacore9 = new Label();
            lblDatacore9.Click += new EventHandler(lblDatacore9_Click);
            gbDCCodes = new GroupBox();
            lblDCColors = new Label();
            lblDCRedText = new Label();
            lblDCRedText.MouseEnter += new EventHandler(lblDCRedText_MouseEnter);
            lblDCOrangeText = new Label();
            lblDCOrangeText.MouseEnter += new EventHandler(lblDCOrangeText_MouseEnter);
            lblDCGrayText = new Label();
            lblDCGrayText.MouseEnter += new EventHandler(lblDCGrayText_MouseEnter);
            lblDCBlueText = new Label();
            lblDCBlueText.MouseEnter += new EventHandler(lblDCBlueText_MouseEnter);
            lblDCGreenBackColor = new Label();
            lblDCGreenBackColor.MouseEnter += new EventHandler(lblDCGreenBackColor_MouseEnter);
            gbDCCorpMinmatar = new GroupBox();
            lblDCCorp13 = new Label();
            lblDCCorp13.Click += new EventHandler(lblDCCorp13_Click);
            chkDCCorp13 = new CheckBox();
            chkDCCorp13.CheckedChanged += new EventHandler(chkDCCorp13_CheckedChanged);
            txtDCStanding13 = new TextBox();
            lblDCCorpLabel4 = new Label();
            lblDCCorp10 = new Label();
            lblDCCorp10.Click += new EventHandler(lblDCCorp10_Click);
            lblDCCorp11 = new Label();
            lblDCCorp11.Click += new EventHandler(lblDCCorp11_Click);
            lblDCCorp12 = new Label();
            lblDCCorp12.Click += new EventHandler(lblDCCorp12_Click);
            chkDCCorp10 = new CheckBox();
            chkDCCorp10.CheckedChanged += new EventHandler(chkDCCorp10_CheckedChanged);
            chkDCCorp11 = new CheckBox();
            chkDCCorp11.CheckedChanged += new EventHandler(chkDCCorp11_CheckedChanged);
            chkDCCorp12 = new CheckBox();
            chkDCCorp12.CheckedChanged += new EventHandler(chkDCCorp12_CheckedChanged);
            txtDCStanding10 = new TextBox();
            txtDCStanding11 = new TextBox();
            txtDCStanding12 = new TextBox();
            lblDCStanding4 = new Label();
            btnDCExporttoClip = new Button();
            btnDCExporttoClip.Click += new EventHandler(btnDCExporttoClip_Click);
            gbDCCorpAmarr = new GroupBox();
            lblDCCorpLabel1 = new Label();
            lblDCCorp1 = new Label();
            lblDCCorp1.Click += new EventHandler(lblDCCorp1_Click);
            lblDCCorp2 = new Label();
            lblDCCorp2.Click += new EventHandler(lblDCCorp2_Click);
            lblDCCorp3 = new Label();
            lblDCCorp3.Click += new EventHandler(lblDCCorp3_Click);
            chkDCCorp1 = new CheckBox();
            chkDCCorp1.CheckedChanged += new EventHandler(chkDCCorp1_CheckedChanged);
            chkDCCorp2 = new CheckBox();
            chkDCCorp2.CheckedChanged += new EventHandler(chkDCCorp2_CheckedChanged);
            chkDCCorp3 = new CheckBox();
            chkDCCorp3.CheckedChanged += new EventHandler(chkDCCorp3_CheckedChanged);
            txtDCStanding1 = new TextBox();
            txtDCStanding2 = new TextBox();
            txtDCStanding3 = new TextBox();
            lblDCStanding1 = new Label();
            btnDCReset = new Button();
            btnDCReset.Click += new EventHandler(btnDCReset_Click);
            gbDCCorpsCaldari = new GroupBox();
            lblDCCorpLabel2 = new Label();
            lblDCCorp4 = new Label();
            lblDCCorp4.Click += new EventHandler(lblDCCorp4_Click);
            lblDCCorp5 = new Label();
            lblDCCorp5.Click += new EventHandler(lblDCCorp5_Click);
            lblDCCorp6 = new Label();
            lblDCCorp6.Click += new EventHandler(lblDCCorp6_Click);
            chkDCCorp4 = new CheckBox();
            chkDCCorp4.CheckedChanged += new EventHandler(chkDCCorp4_CheckedChanged);
            chkDCCorp5 = new CheckBox();
            chkDCCorp5.CheckedChanged += new EventHandler(chkDCCorp5_CheckedChanged);
            chkDCCorp6 = new CheckBox();
            chkDCCorp6.CheckedChanged += new EventHandler(chkDCCorp6_CheckedChanged);
            txtDCStanding4 = new TextBox();
            txtDCStanding5 = new TextBox();
            txtDCStanding6 = new TextBox();
            lblDCStanding2 = new Label();
            gbDCCorpsGallente = new GroupBox();
            lblDCCorpLabel3 = new Label();
            lblDCCorp7 = new Label();
            lblDCCorp7.Click += new EventHandler(lblDCCorp7_Click);
            lblDCCorp8 = new Label();
            lblDCCorp8.Click += new EventHandler(lblDCCorp8_Click);
            lblDCCorp9 = new Label();
            lblDCCorp9.Click += new EventHandler(lblDCCorp9_Click);
            chkDCCorp7 = new CheckBox();
            chkDCCorp7.CheckedChanged += new EventHandler(chkDCCorp7_CheckedChanged);
            chkDCCorp8 = new CheckBox();
            chkDCCorp8.CheckedChanged += new EventHandler(chkDCCorp8_CheckedChanged);
            chkDCCorp9 = new CheckBox();
            chkDCCorp9.CheckedChanged += new EventHandler(chkDCCorp9_CheckedChanged);
            txtDCStanding7 = new TextBox();
            txtDCStanding8 = new TextBox();
            txtDCStanding9 = new TextBox();
            lblDCStanding3 = new Label();
            btnDCRefresh = new Button();
            btnDCRefresh.Click += new EventHandler(btnDCRefresh_Click);
            tabManufacturing = new TabPage();
            lstManufacturing = new ManufacturingListView();
            lstManufacturing.KeyDown += new KeyEventHandler(lstManufacturing_KeyDown);
            lstManufacturing.ColumnClick += new ColumnClickEventHandler(lstManufacturing_ColumnClick);
            lstManufacturing.ColumnReordered += new ColumnReorderedEventHandler(lstManufacturing_ColumnReordered);
            lstManufacturing.ColumnWidthChanged += new ColumnWidthChangedEventHandler(lstManufacturing_ColumnWidthChanged);
            lstManufacturing.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lstManufacturing_ColumnWidthChanging);
            lstManufacturing.DoubleClick += new EventHandler(lstManufacturing_DoubleClick);
            gbCalcBPSelectOptions = new GroupBox();
            gbCalcIgnoreinCalcs = new GroupBox();
            chkCalcIgnoreMinerals = new CheckBox();
            chkCalcIgnoreMinerals.CheckedChanged += new EventHandler(chkCalcIgnoreMinerals_CheckedChanged_1);
            chkCalcIgnoreT1Item = new CheckBox();
            chkCalcIgnoreT1Item.CheckedChanged += new EventHandler(chkCalcIgnoreT1Item_CheckedChanged);
            chkCalcIgnoreInvention = new CheckBox();
            chkCalcIgnoreInvention.CheckedChanged += new EventHandler(chkCalcIgnoreInvention_CheckedChanged_1);
            gbIncludeTaxesFees = new GroupBox();
            txtCalcBrokerFeeRate = new TextBox();
            txtCalcBrokerFeeRate.KeyDown += new KeyEventHandler(txtCalcBrokerFeeRate_KeyDown);
            txtCalcBrokerFeeRate.KeyPress += new KeyPressEventHandler(txtCalcBrokerFeeRate_KeyPress);
            txtCalcBrokerFeeRate.GotFocus += new EventHandler(txtCalcBrokerFeeRate_GotFocus);
            txtCalcBrokerFeeRate.LostFocus += new EventHandler(txtCalcBrokerFeeRate_LostFocus);
            chkCalcFees = new CheckBox();
            chkCalcFees.CheckedChanged += new EventHandler(chkCalcFees_CheckedChanged);
            chkCalcFees.Click += new EventHandler(chkCalcFees_Click);
            chkCalcTaxes = new CheckBox();
            chkCalcTaxes.CheckedChanged += new EventHandler(chkCalcTaxes_CheckedChanged);
            gbCalcSellExessItems = new GroupBox();
            rbtnCalcAdvT2MatType = new RadioButton();
            rbtnCalcAdvT2MatType.CheckedChanged += new EventHandler(rbtnCalcAdvT2MatType_CheckedChanged);
            rbtnCalcProcT2MatType = new RadioButton();
            rbtnCalcProcT2MatType.CheckedChanged += new EventHandler(rbtnCalcProcT2MatType_CheckedChanged);
            rbtnCalcRawT2MatType = new RadioButton();
            rbtnCalcRawT2MatType.CheckedChanged += new EventHandler(rbtnCalcRawT2MatType_CheckedChanged);
            chkCalcSellExessItems = new CheckBox();
            chkCalcSellExessItems.CheckedChanged += new EventHandler(chkCalcSellExessItems_CheckedChanged);
            chkCalcNPCBPOs = new CheckBox();
            chkCalcNPCBPOs.CheckedChanged += new EventHandler(chkCalcNPCBPOs_CheckedChanged);
            btnCalcShowAssets = new Button();
            btnCalcShowAssets.Click += new EventHandler(btnCalcShowAssets_Click);
            gbCalcIncludeItems = new GroupBox();
            chkCalcCanInvent = new CheckBox();
            chkCalcCanInvent.CheckedChanged += new EventHandler(chkCalcCanInvent_CheckedChanged);
            chkCalcCanBuild = new CheckBox();
            chkCalcCanBuild.CheckedChanged += new EventHandler(chkCalcCanBuild_CheckedChanged);
            gbCalcMarketFilters = new GroupBox();
            txtCalcProfitThreshold = new TextBox();
            txtCalcProfitThreshold.KeyPress += new KeyPressEventHandler(txtCalcProfitThreshold_KeyPress);
            txtCalcProfitThreshold.LostFocus += new EventHandler(txtCalcProfitThreshold_LostFocus);
            txtCalcProfitThreshold.TextChanged += new EventHandler(txtCalcProfitThreshold_TextChanged);
            tpMaxBuildTimeFilter = new TimePicker();
            tpMaxBuildTimeFilter.TimeChange += new TimePicker.TimeChangeEventHandler(tpMaxBuildTimeFilter_TimeChange);
            txtCalcSVRThreshold = new TextBox();
            txtCalcSVRThreshold.KeyPress += new KeyPressEventHandler(txtCalcSVRThreshold_KeyPress);
            txtCalcSVRThreshold.TextChanged += new EventHandler(txtCalcSVRThreshold_TextChanged);
            tpMinBuildTimeFilter = new TimePicker();
            tpMinBuildTimeFilter.TimeChange += new TimePicker.TimeChangeEventHandler(tpMinBuildTimeFilter_TimeChange);
            chkCalcMaxBuildTimeFilter = new CheckBox();
            chkCalcMaxBuildTimeFilter.CheckedChanged += new EventHandler(chkCalcMaxBuildTimeFilter_CheckedChanged);
            chkCalcMinBuildTimeFilter = new CheckBox();
            chkCalcMinBuildTimeFilter.CheckedChanged += new EventHandler(chkCalcMinBuildTimeFilter_CheckedChanged);
            cmbCalcPriceTrend = new ComboBox();
            cmbCalcPriceTrend.SelectedIndexChanged += new EventHandler(cmbCalcPriceTrend_SelectedIndexChanged);
            cmbCalcAvgPriceDuration = new ComboBox();
            cmbCalcAvgPriceDuration.KeyPress += new KeyPressEventHandler(cmbCalcAvgPriceDuration_KeyPress);
            cmbCalcAvgPriceDuration.SelectedIndexChanged += new EventHandler(cmbCalcAvgPriceDuration_SelectedIndexChanged);
            lblCalcPriceTrend = new Label();
            txtCalcVolumeThreshold = new TextBox();
            txtCalcVolumeThreshold.KeyPress += new KeyPressEventHandler(txtCalcVolumeThreshold_KeyPress);
            txtCalcVolumeThreshold.LostFocus += new EventHandler(txtCalcVolumeThreshold_LostFocus);
            txtCalcVolumeThreshold.TextChanged += new EventHandler(txtCalcVolumeThreshold_TextChanged);
            cmbCalcHistoryRegion = new ComboBox();
            cmbCalcHistoryRegion.DropDown += new EventHandler(cmbCalcHistoryRegion_DropDown);
            cmbCalcHistoryRegion.KeyPress += new KeyPressEventHandler(cmbCalcSVRRegion_KeyPress);
            cmbCalcHistoryRegion.SelectedIndexChanged += new EventHandler(cmbCalcSVRRegion_SelectedIndexChanged);
            lblCalcHistoryRegion = new Label();
            lblCalcSVRThreshold = new Label();
            lblCalcAvgPrice = new Label();
            txtCalcIPHThreshold = new TextBox();
            txtCalcIPHThreshold.KeyPress += new KeyPressEventHandler(txtCalcIPHThreshold_KeyPress);
            txtCalcIPHThreshold.LostFocus += new EventHandler(txtCalcIPHThreshold_LostFocus);
            txtCalcIPHThreshold.TextChanged += new EventHandler(txtCalcIPHThreshold_TextChanged);
            chkCalcProfitThreshold = new CheckBox();
            chkCalcProfitThreshold.Click += new EventHandler(chkCalcProfitThreshold_Click);
            chkCalcVolumeThreshold = new CheckBox();
            chkCalcVolumeThreshold.CheckedChanged += new EventHandler(chkCalcVolumeThreshold_CheckedChanged);
            chkCalcIPHThreshold = new CheckBox();
            chkCalcIPHThreshold.CheckedChanged += new EventHandler(chkCalcIPHThreshold_CheckedChanged);
            chkCalcSVRIncludeNull = new CheckBox();
            chkCalcSVRIncludeNull.CheckedChanged += new EventHandler(chkCalcSVRIncludeNull_CheckedChanged);
            btnCalcCalculate = new Button();
            btnCalcCalculate.Click += new EventHandler(btnCalculate_Click);
            btnCalcSelectColumns = new Button();
            btnCalcSelectColumns.Click += new EventHandler(btnCalcSelectColumns_Click);
            gbCalcSizeLimit = new GroupBox();
            chkCalcXL = new CheckBox();
            chkCalcXL.CheckedChanged += new EventHandler(chkCalcXL_CheckedChanged);
            chkCalcLarge = new CheckBox();
            chkCalcLarge.CheckedChanged += new EventHandler(chkCalcLarge_CheckedChanged);
            chkCalcMedium = new CheckBox();
            chkCalcMedium.CheckedChanged += new EventHandler(chkCalcMedium_CheckedChanged);
            chkCalcSmall = new CheckBox();
            chkCalcSmall.CheckedChanged += new EventHandler(chkCalcSmall_CheckedChanged);
            gbCalcProdLines = new GroupBox();
            chkCalcAutoCalcT2NumBPs = new CheckBox();
            chkCalcAutoCalcT2NumBPs.CheckedChanged += new EventHandler(chkCalcAutoCalcT2NumBPs_CheckedChanged);
            lblCalcBPs = new Label();
            txtCalcNumBPs = new TextBox();
            txtCalcNumBPs.KeyPress += new KeyPressEventHandler(txtCalcBPs_KeyPress);
            txtCalcNumBPs.TextChanged += new EventHandler(txtCalcBPs_TextChanged);
            txtCalcRuns = new TextBox();
            txtCalcRuns.TextChanged += new EventHandler(txtCalcRuns_TextChanged);
            txtCalcLabLines = new TextBox();
            txtCalcLabLines.DoubleClick += new EventHandler(txtCalcLabLines_DoubleClick);
            txtCalcLabLines.KeyPress += new KeyPressEventHandler(txtCalcLabLines_KeyPress);
            txtCalcLabLines.TextChanged += new EventHandler(txtCalcLabLines_TextChanged);
            lblCalcRuns = new Label();
            lblCalcLabLines1 = new Label();
            lblCalcProdLines1 = new Label();
            txtCalcProdLines = new TextBox();
            txtCalcProdLines.DoubleClick += new EventHandler(txtCalcProdLines_DoubleClick);
            txtCalcProdLines.KeyPress += new KeyPressEventHandler(txtCalcProdLines_KeyPress);
            txtCalcProdLines.TextChanged += new EventHandler(txtCalcProdLines_TextChanged);
            gbCalcCompareType = new GroupBox();
            chkCalcPPU = new CheckBox();
            chkCalcPPU.CheckedChanged += new EventHandler(chkCalcPPU_CheckedChanged);
            rbtnCalcCompareBuildBuy = new RadioButton();
            rbtnCalcCompareBuildBuy.CheckedChanged += new EventHandler(rbtnCalcCompareBuildBuy_CheckedChanged);
            rbtnCalcCompareRawMats = new RadioButton();
            rbtnCalcCompareRawMats.CheckedChanged += new EventHandler(rbtnCalcCompareRawMats_CheckedChanged);
            rbtnCalcCompareComponents = new RadioButton();
            rbtnCalcCompareComponents.CheckedChanged += new EventHandler(rbtnCalcCompareComponents_CheckedChanged);
            rbtnCalcCompareAll = new RadioButton();
            rbtnCalcCompareAll.CheckedChanged += new EventHandler(rbtnCalcCompareAll_CheckedChanged);
            gbCalcTextColors = new GroupBox();
            lblCalcColorCode6 = new Label();
            lblCalcColorCode6.MouseEnter += new EventHandler(lblCalcColorCode6_MouseEnter);
            lblCalcText = new Label();
            lblCalcColorCode3 = new Label();
            lblCalcColorCode3.MouseEnter += new EventHandler(lblCalcColorCode3_MouseEnter);
            lblCalcColorCode4 = new Label();
            lblCalcColorCode4.MouseEnter += new EventHandler(lblCalcColorCode4_MouseEnter);
            lblCalcColorCode5 = new Label();
            lblCalcColorCode5.MouseEnter += new EventHandler(lblCalcColorCode5_MouseEnter);
            lblCalcColorCode2 = new Label();
            lblCalcColorCode2.MouseEnter += new EventHandler(lblCalcColorCode2_MouseEnter);
            lblCalcColorCode1 = new Label();
            lblCalcColorCode1.MouseEnter += new EventHandler(lblCalcColorCode1_MouseEnter);
            gbCalcInvention = new GroupBox();
            chkCalcDecryptorforT3 = new CheckBox();
            chkCalcDecryptorforT3.CheckedChanged += new EventHandler(chkCalcDecryptorforT3_CheckedChanged);
            chkCalcDecryptorforT2 = new CheckBox();
            chkCalcDecryptorforT2.CheckedChanged += new EventHandler(chkCalcDecryptorforT2_CheckedChanged);
            chkCalcDecryptor0 = new CheckBox();
            chkCalcDecryptor0.Click += new EventHandler(chkCalcDecryptor0_Click);
            chkCalcDecryptor9 = new CheckBox();
            chkCalcDecryptor9.CheckedChanged += new EventHandler(chkCalcDecryptor9_CheckedChanged);
            chkCalcDecryptor8 = new CheckBox();
            chkCalcDecryptor8.CheckedChanged += new EventHandler(chkCalcDecryptor8_CheckedChanged);
            chkCalcDecryptor7 = new CheckBox();
            chkCalcDecryptor7.CheckedChanged += new EventHandler(chkCalcDecryptor7_CheckedChanged);
            chkCalcDecryptor6 = new CheckBox();
            chkCalcDecryptor6.CheckedChanged += new EventHandler(chkCalcDecryptor6_CheckedChanged);
            chkCalcDecryptor5 = new CheckBox();
            chkCalcDecryptor5.CheckedChanged += new EventHandler(chkCalcDecryptor5_CheckedChanged);
            chkCalcDecryptor4 = new CheckBox();
            chkCalcDecryptor4.CheckedChanged += new EventHandler(chkCalcDecryptor4_CheckedChanged);
            chkCalcDecryptor3 = new CheckBox();
            chkCalcDecryptor3.CheckedChanged += new EventHandler(chkCalcDecryptor3_CheckedChanged_1);
            chkCalcDecryptor2 = new CheckBox();
            chkCalcDecryptor2.CheckedChanged += new EventHandler(chkCalcDecryptor2_CheckedChanged);
            chkCalcDecryptor1 = new CheckBox();
            chkCalcDecryptor1.CheckedChanged += new EventHandler(chkCalcDecryptor1_CheckedChanged);
            lblCalcDecryptorUse = new Label();
            gbCalcBPRace = new GroupBox();
            chkCalcRaceOther = new CheckBox();
            chkCalcRaceOther.CheckedChanged += new EventHandler(chkCalcRaceOther_CheckedChanged);
            chkCalcRacePirate = new CheckBox();
            chkCalcRacePirate.CheckedChanged += new EventHandler(chkCalcRacePirate_CheckedChanged);
            chkCalcRaceMinmatar = new CheckBox();
            chkCalcRaceMinmatar.CheckedChanged += new EventHandler(chkCalcRaceMinmatar_CheckedChanged);
            chkCalcRaceGallente = new CheckBox();
            chkCalcRaceGallente.CheckedChanged += new EventHandler(chkCalcRaceGallente_CheckedChanged);
            chkCalcRaceCaldari = new CheckBox();
            chkCalcRaceCaldari.CheckedChanged += new EventHandler(chkCalcRaceCaldari_CheckedChanged);
            chkCalcRaceAmarr = new CheckBox();
            chkCalcRaceAmarr.CheckedChanged += new EventHandler(chkCalcRaceAmarr_CheckedChanged);
            gbTempMEPE = new GroupBox();
            txtCalcTempTE = new TextBox();
            txtCalcTempTE.KeyPress += new KeyPressEventHandler(txtTempPE_KeyPress);
            txtCalcTempTE.TextChanged += new EventHandler(txtCalcTempTE_TextChanged);
            lblTempPE = new Label();
            txtCalcTempME = new TextBox();
            txtCalcTempME.KeyPress += new KeyPressEventHandler(txtTempME_KeyPress);
            txtCalcTempME.TextChanged += new EventHandler(txtCalcTempME_TextChanged);
            lblTempME = new Label();
            tabCalcFacilities = new TabControl();
            tabCalcFacilityBase = new TabPage();
            CalcBaseFacility = new ManufacturingFacility();
            tabCalcFacilityComponents = new TabPage();
            CalcComponentsFacility = new ManufacturingFacility();
            tabCalcFacilityCopy = new TabPage();
            CalcCopyFacility = new ManufacturingFacility();
            tabCalcFacilityT2Invention = new TabPage();
            CalcInventionFacility = new ManufacturingFacility();
            tabCalcFacilityT3Invention = new TabPage();
            CalcT3InventionFacility = new ManufacturingFacility();
            tabCalcFacilitySupers = new TabPage();
            CalcSupersFacility = new ManufacturingFacility();
            tabCalcFacilityCapitals = new TabPage();
            CalcCapitalsFacility = new ManufacturingFacility();
            tabCalcFacilityT3Ships = new TabPage();
            CalcT3ShipsFacility = new ManufacturingFacility();
            tabCalcFacilitySubsystems = new TabPage();
            CalcSubsystemsFacility = new ManufacturingFacility();
            tabCalcFacilityBoosters = new TabPage();
            CalcBoostersFacility = new ManufacturingFacility();
            tabCalcFacilityReactions = new TabPage();
            CalcReactionsFacility = new ManufacturingFacility();
            gbCalcFilter = new GroupBox();
            cmbCalcBPTypeFilter = new ComboBox();
            cmbCalcBPTypeFilter.DropDown += new EventHandler(cmbCalcBPTypeFilter_DropDown);
            cmbCalcBPTypeFilter.GotFocus += new EventHandler(cmbCalcBPTypeFilter_GotFocus);
            cmbCalcBPTypeFilter.KeyPress += new KeyPressEventHandler(cmbCalcBPTypeFilter_KeyPress);
            cmbCalcBPTypeFilter.SelectedValueChanged += new EventHandler(cmbCalcBPTypeFilter_SelectedValueChanged);
            cmbCalcBPTypeFilter.Click += new EventHandler(cmbCalcBPTypeFilter_Click);
            gbCalcBPTech = new GroupBox();
            chkCalcPirateFaction = new CheckBox();
            chkCalcPirateFaction.CheckedChanged += new EventHandler(chkCalcPirateFaction_CheckedChanged);
            chkCalcStoryline = new CheckBox();
            chkCalcStoryline.CheckedChanged += new EventHandler(chkCalcStoryline_CheckedChanged);
            chkCalcNavyFaction = new CheckBox();
            chkCalcNavyFaction.CheckedChanged += new EventHandler(chkCalcNavyFaction_CheckedChanged);
            chkCalcT3 = new CheckBox();
            chkCalcT3.CheckedChanged += new EventHandler(chkCalcT3_CheckedChanged);
            chkCalcT3.Click += new EventHandler(chkCalcT3_Click);
            chkCalcT2 = new CheckBox();
            chkCalcT2.CheckedChanged += new EventHandler(chkCalcT2_CheckedChanged);
            chkCalcT2.Click += new EventHandler(chkCalcT2_Click);
            chkCalcT1 = new CheckBox();
            chkCalcT1.CheckedChanged += new EventHandler(chkCalcT1_CheckedChanged);
            gbCalcIncludeOwned = new GroupBox();
            chkCalcIncludeT3Owned = new CheckBox();
            chkCalcIncludeT3Owned.CheckedChanged += new EventHandler(chkCalcIncludeT3Owned_CheckedChanged);
            chkCalcIncludeT2Owned = new CheckBox();
            chkCalcIncludeT2Owned.CheckedChanged += new EventHandler(chkCalcIncludeT2Owned_CheckedChanged);
            btnCalcSaveSettings = new Button();
            btnCalcSaveSettings.Click += new EventHandler(btnCalcSaveSettings_Click);
            btnCalcExportList = new Button();
            btnCalcExportList.Click += new EventHandler(btnCalcExportList_Click);
            btnCalcPreview = new Button();
            btnCalcPreview.Click += new EventHandler(btnManufactureRefresh_Click);
            btnCalcReset = new Button();
            btnCalcReset.Click += new EventHandler(btnCalcReset_Click);
            gbCalcTextFilter = new GroupBox();
            btnCalcResetTextSearch = new Button();
            btnCalcResetTextSearch.Click += new EventHandler(btnCalcResetTextSearch_Click);
            txtCalcItemFilter = new TextBox();
            txtCalcItemFilter.TextChanged += new EventHandler(txtCalcItemFilter_TextChanged);
            txtCalcItemFilter.KeyDown += new KeyEventHandler(txtCalcItemFilter_KeyDown);
            gbCalcBPType = new GroupBox();
            chkCalcReactions = new CheckBox();
            chkCalcReactions.CheckedChanged += new EventHandler(chkCalcReactions_CheckedChanged);
            chkCalcCelestials = new CheckBox();
            chkCalcCelestials.CheckedChanged += new EventHandler(chkCalcCelestials_CheckedChanged);
            chkCalcMisc = new CheckBox();
            chkCalcMisc.CheckedChanged += new EventHandler(chkCalcMisc_CheckedChanged);
            chkCalcSubsystems = new CheckBox();
            chkCalcSubsystems.CheckedChanged += new EventHandler(chkCalcSubsystems_CheckedChanged);
            chkCalcDeployables = new CheckBox();
            chkCalcDeployables.CheckedChanged += new EventHandler(chkCalcDeployables_CheckedChanged);
            chkCalcStructures = new CheckBox();
            chkCalcStructures.CheckedChanged += new EventHandler(chkCalcStructures_CheckedChanged);
            chkCalcStructureRigs = new CheckBox();
            chkCalcStructureRigs.CheckedChanged += new EventHandler(chkCalcStationParts_CheckedChanged);
            chkCalcBoosters = new CheckBox();
            chkCalcBoosters.CheckedChanged += new EventHandler(chkCalcBoosters_CheckedChanged);
            chkCalcRigs = new CheckBox();
            chkCalcRigs.CheckedChanged += new EventHandler(chkCalcRigs_CheckedChanged);
            chkCalcComponents = new CheckBox();
            chkCalcComponents.CheckedChanged += new EventHandler(chkCalcComponents_CheckedChanged);
            chkCalcAmmo = new CheckBox();
            chkCalcAmmo.CheckedChanged += new EventHandler(chkCalcAmmo_CheckedChanged);
            chkCalcDrones = new CheckBox();
            chkCalcDrones.CheckedChanged += new EventHandler(chkCalcDrones_CheckedChanged);
            chkCalcModules = new CheckBox();
            chkCalcModules.CheckedChanged += new EventHandler(chkCalcModules_CheckedChanged);
            chkCalcShips = new CheckBox();
            chkCalcShips.CheckedChanged += new EventHandler(chkCalcShips_CheckedChanged);
            chkCalcStructureModules = new CheckBox();
            chkCalcStructureModules.CheckedChanged += new EventHandler(chkCalcStructureModules_CheckedChanged);
            gbCalcBPSelect = new GroupBox();
            rbtnCalcBPFavorites = new RadioButton();
            rbtnCalcBPFavorites.CheckedChanged += new EventHandler(rbtnCalcBPFavorites_CheckedChanged);
            rbtnCalcAllBPs = new RadioButton();
            rbtnCalcAllBPs.CheckedChanged += new EventHandler(rbtnCalcAllBPs_CheckedChanged);
            rbtnCalcBPOwned = new RadioButton();
            rbtnCalcBPOwned.CheckedChanged += new EventHandler(rbtnCalcBPOwned_CheckedChanged);
            gbCalcRelics = new GroupBox();
            chkCalcRERelic2 = new CheckBox();
            chkCalcRERelic2.CheckedChanged += new EventHandler(chkCalcRERelic2_CheckedChanged);
            chkCalcRERelic3 = new CheckBox();
            chkCalcRERelic3.CheckedChanged += new EventHandler(chkCalcRERelic3_CheckedChanged);
            chkCalcRERelic1 = new CheckBox();
            chkCalcRERelic1.CheckedChanged += new EventHandler(chkCalcRERelic1_CheckedChanged);
            tabUpdatePrices = new TabPage();
            gbRawMaterials = new GroupBox();
            gbReactionMaterials = new GroupBox();
            chkAdvancedMats = new CheckBox();
            chkAdvancedMats.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkBoosterMats = new CheckBox();
            chkBoosterMats.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkMolecularForgedMaterials = new CheckBox();
            chkMolecularForgedMaterials.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkPolymers = new CheckBox();
            chkPolymers.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkProcessedMats = new CheckBox();
            chkProcessedMats.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkRawMoonMats = new CheckBox();
            chkRawMoonMats.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            gbResearchEquipment = new GroupBox();
            chkRDb = new CheckBox();
            chkRDb.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkAncientRelics = new CheckBox();
            chkAncientRelics.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkDecryptors = new CheckBox();
            chkDecryptors.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkDatacores = new CheckBox();
            chkDatacores.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkMinerals = new CheckBox();
            chkMinerals.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkFactionMaterials = new CheckBox();
            chkFactionMaterials.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkNamedComponents = new CheckBox();
            chkNamedComponents.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkMisc = new CheckBox();
            chkMisc.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkMolecularForgingTools = new CheckBox();
            chkMolecularForgingTools.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkAdvancedProtectiveTechnology = new CheckBox();
            chkAdvancedProtectiveTechnology.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkBPCs = new CheckBox();
            chkBPCs.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkRawMaterials = new CheckBox();
            chkRawMaterials.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkPriceMaterialResearchEqPrices = new CheckBox();
            chkPriceMaterialResearchEqPrices.CheckedChanged += new EventHandler(chkPriceRawMaterialPrices_CheckedChanged);
            chkPlanetary = new CheckBox();
            chkPlanetary.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkGas = new CheckBox();
            chkGas.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkSalvage = new CheckBox();
            chkSalvage.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkIceProducts = new CheckBox();
            chkIceProducts.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            gbSingleSource = new GroupBox();
            gbMarketStructures = new GroupBox();
            btnAddStructureIDs = new Button();
            btnAddStructureIDs.Click += new EventHandler(btnAddStructureIDs_Click);
            btnViewSavedStructures = new Button();
            btnViewSavedStructures.Click += new EventHandler(btnViewSavedStructures_Click);
            gbRegionSystemPrice = new GroupBox();
            cmbPriceRegions = new ComboBox();
            cmbPriceRegions.DropDown += new EventHandler(cmbPriceRegion_DropDown);
            cmbPriceRegions.SelectedIndexChanged += new EventHandler(cmbPriceRegion_SelectedIndexChanged);
            cmbPriceSystems = new ComboBox();
            cmbPriceSystems.DropDownClosed += new EventHandler(cmbPriceSystems_DropDownClosed);
            cmbPriceSystems.GotFocus += new EventHandler(cmbPriceSystems_GotFocus);
            cmbPriceSystems.DropDown += new EventHandler(cmbPriceSystems_DropDown);
            cmbPriceSystems.SelectedIndexChanged += new EventHandler(cmbPriceSystems_SelectedIndexChanged);
            gbTradeHubSystems = new GroupBox();
            chkSystems6 = new CheckBox();
            chkSystems6.CheckedChanged += new EventHandler(chkSystems1_CheckedChanged);
            chkSystems5 = new CheckBox();
            chkSystems5.CheckedChanged += new EventHandler(chkSystems1_CheckedChanged);
            chkSystems4 = new CheckBox();
            chkSystems4.CheckedChanged += new EventHandler(chkSystems1_CheckedChanged);
            chkSystems3 = new CheckBox();
            chkSystems3.CheckedChanged += new EventHandler(chkSystems1_CheckedChanged);
            chkSystems2 = new CheckBox();
            chkSystems2.CheckedChanged += new EventHandler(chkSystems1_CheckedChanged);
            _chkSystems1 = new CheckBox();
            _chkSystems1.CheckedChanged += new EventHandler(chkSystems1_CheckedChanged);
            gbPriceProfile = new GroupBox();
            tabPriceProfile = new TabControl();
            tabPriceProfile.SelectedIndexChanged += new EventHandler(tabPriceProfile_SelectedIndexChanged);
            tabPriceProfileRaw = new TabPage();
            lstRawPriceProfile = new MyListView();
            lstRawPriceProfile.MouseClick += new MouseEventHandler(lstRawPriceProfile_MouseClick);
            tabPriceProfileManufactured = new TabPage();
            lstManufacturedPriceProfile = new MyListView();
            lstManufacturedPriceProfile.MouseClick += new MouseEventHandler(lstManufacturedPriceProfile_MouseClick);
            gbPPDefaultSettings = new GroupBox();
            btnPPUpdateDefaults = new Button();
            btnPPUpdateDefaults.Click += new EventHandler(btnPPUpdateDefaults_Click);
            cmbPPDefaultsPriceType = new ComboBox();
            lblPPDefaultsSystem = new Label();
            lblPPDefaultsPriceType = new Label();
            cmbPPDefaultsSystem = new ComboBox();
            cmbPPDefaultsSystem.DropDown += new EventHandler(cmbPPDefaultsSystem_DropDown);
            cmbPPDefaultsRegion = new ComboBox();
            cmbPPDefaultsRegion.SelectedIndexChanged += new EventHandler(cmbPPDefaultsRegion_SelectedIndexChanged);
            cmbPPDefaultsRegion.DropDown += new EventHandler(cmbPPDefaultsRegion_DropDown);
            lblPPDefaultsRegion = new Label();
            txtPPDefaultsPriceMod = new TextBox();
            txtPPDefaultsPriceMod.LostFocus += new EventHandler(txtPPDefaultsPriceMod_LostFocus);
            txtPPDefaultsPriceMod.KeyPress += new KeyPressEventHandler(txtPPDefaultsPriceMod_KeyPress);
            lblPPDefaultsPriceMod = new Label();
            btnLoadPricesfromFile = new Button();
            btnLoadPricesfromFile.Click += new EventHandler(btnLoadPricesfromFile_Click);
            btnSavePricestoFile = new Button();
            btnSavePricestoFile.Click += new EventHandler(btnSavePricestoFile_Click);
            lstPricesView = new MyListView();
            lstPricesView.ProcMsg += new MyListView.ProcMsgEventHandler(lstPricesView_ProcMsg);
            lstPricesView.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lstPricesView_ColumnWidthChanging);
            lstPricesView.ColumnClick += new ColumnClickEventHandler(lstPricesView_ColumnClick);
            lstPricesView.MouseClick += new MouseEventHandler(lstPricesView_MouseClick);
            txtPriceItemFilter = new TextBox();
            txtPriceItemFilter.KeyDown += new KeyEventHandler(txtPriceItemFilter_KeyDown);
            gbPriceOptions = new GroupBox();
            txtItemsPriceModifier = new TextBox();
            txtItemsPriceModifier.KeyPress += new KeyPressEventHandler(txtItemsPriceModifier_KeyPress);
            txtItemsPriceModifier.LostFocus += new EventHandler(txtItemsPriceModifier_LostFocus);
            txtRawPriceModifier = new TextBox();
            txtRawPriceModifier.KeyPress += new KeyPressEventHandler(txtRawPriceModifier_KeyPress);
            txtRawPriceModifier.LostFocus += new EventHandler(txtRawPriceModifier_LostFocus);
            gbPriceTypes = new GroupBox();
            rbtnPriceSettingPriceProfile = new RadioButton();
            rbtnPriceSettingPriceProfile.CheckedChanged += new EventHandler(rbtnPriceSettingPriceProfile_CheckedChanged);
            rbtnPriceSettingSingleSelect = new RadioButton();
            lblItemsPriceModifier = new Label();
            lblRawPriceModifier = new Label();
            gbDataSource = new GroupBox();
            rbtnPriceSourceCCPData = new RadioButton();
            rbtnPriceSourceCCPData.CheckedChanged += new EventHandler(PriceSourceSelection_CheckedChanged);
            rbtnPriceSourceEM = new RadioButton();
            rbtnPriceSourceEM.CheckedChanged += new EventHandler(PriceSourceSelection_CheckedChanged);
            cmbItemsSplitPrices = new ComboBox();
            cmbRawMatsSplitPrices = new ComboBox();
            lblItemsSplitPrices = new Label();
            lblRawMatsSplitPrices = new Label();
            btnSaveUpdatePrices = new Button();
            btnSaveUpdatePrices.Click += new EventHandler(btnSaveUpdatePrices_Click);
            btnCancelUpdate = new Button();
            btnCancelUpdate.Click += new EventHandler(btnCancelUpdate_Click);
            btnClearItemFilter = new Button();
            btnClearItemFilter.Click += new EventHandler(btnReset_Click);
            btnToggleAllPriceItems = new Button();
            btnToggleAllPriceItems.Click += new EventHandler(btnToggleAllPriceItems_Click);
            btnDownloadPrices = new Button();
            btnDownloadPrices.Click += new EventHandler(btnImportPrices_Click);
            lblItemFilter = new Label();
            gbManufacturedItems = new GroupBox();
            chkPriceManufacturedPrices = new CheckBox();
            chkPriceManufacturedPrices.CheckedChanged += new EventHandler(chkPriceSelectManufacturedItems_CheckedChanged);
            gbComponents = new GroupBox();
            gbReprocessables = new GroupBox();
            chkNoBuildItems = new CheckBox();
            chkNoBuildItems.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkFuelBlocks = new CheckBox();
            chkFuelBlocks.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkRAM = new CheckBox();
            chkRAM.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkProtectiveComponents = new CheckBox();
            chkProtectiveComponents.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkSubsystemComponents = new CheckBox();
            chkSubsystemComponents.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkStructureComponents = new CheckBox();
            chkStructureComponents.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkComponents = new CheckBox();
            chkComponents.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkCapitalShipComponents = new CheckBox();
            chkCapitalShipComponents.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkCapT2Components = new CheckBox();
            chkCapT2Components.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            gbItems = new GroupBox();
            chkCelestials = new CheckBox();
            chkCelestials.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkDeployables = new CheckBox();
            chkDeployables.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            cmbPriceChargeTypes = new ComboBox();
            cmbPriceChargeTypes.DropDown += new EventHandler(cmbPriceChargeTypes_DropDown);
            cmbPriceChargeTypes.SelectedIndexChanged += new EventHandler(cmbPriceChargeTypes_SelectedIndexChanged);
            chkStructures = new CheckBox();
            chkStructures.CheckedChanged += new EventHandler(chkTechManufacturedItems_CheckedChanged);
            chkStructureRigs = new CheckBox();
            chkStructureRigs.CheckedChanged += new EventHandler(chkTechManufacturedItems_CheckedChanged);
            chkCharges = new CheckBox();
            chkCharges.CheckedChanged += new EventHandler(chkCharges_CheckedChanged);
            chkBoosters = new CheckBox();
            chkBoosters.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            cmbPriceShipTypes = new ComboBox();
            cmbPriceShipTypes.DropDown += new EventHandler(cmbPriceShipTypes_DropDown);
            cmbPriceShipTypes.SelectedIndexChanged += new EventHandler(cmbPriceShipTypes_SelectedIndexChanged);
            gbPricesTech = new GroupBox();
            chkPricesT4 = new CheckBox();
            chkPricesT4.Click += new EventHandler(chkPricesTech_Click);
            chkPricesT6 = new CheckBox();
            chkPricesT6.Click += new EventHandler(chkPricesTech_Click);
            chkPricesT5 = new CheckBox();
            chkPricesT5.Click += new EventHandler(chkPricesTech_Click);
            chkPricesT3 = new CheckBox();
            chkPricesT3.Click += new EventHandler(chkPricesTech_Click);
            chkPricesT2 = new CheckBox();
            chkPricesT2.Click += new EventHandler(chkPricesTech_Click);
            chkPricesT1 = new CheckBox();
            chkPricesT1.Click += new EventHandler(chkPricesTech_Click);
            chkSubsystems = new CheckBox();
            chkSubsystems.CheckedChanged += new EventHandler(chkTechManufacturedItems_CheckedChanged);
            chkShips = new CheckBox();
            chkShips.CheckedChanged += new EventHandler(chkShips_CheckedChanged);
            chkModules = new CheckBox();
            chkModules.CheckedChanged += new EventHandler(chkTechManufacturedItems_CheckedChanged);
            chkRigs = new CheckBox();
            chkRigs.CheckedChanged += new EventHandler(chkTechManufacturedItems_CheckedChanged);
            chkDrones = new CheckBox();
            chkDrones.CheckedChanged += new EventHandler(chkTechManufacturedItems_CheckedChanged);
            chkUpdatePricesNoPrice = new CheckBox();
            chkUpdatePricesNoPrice.CheckedChanged += new EventHandler(chkTechManufacturedItems_CheckedChanged);
            chkImplants = new CheckBox();
            chkImplants.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            chkStructureModules = new CheckBox();
            chkStructureModules.CheckedChanged += new EventHandler(ProcessnonTechItemChecks_CheckedChanged);
            btnOpenMarketBrowser = new Button();
            btnOpenMarketBrowser.Click += new EventHandler(btnOpenMarketBrowser_Click);
            tabBlueprints = new TabPage();
            gbBPMEPEImage = new GroupBox();
            gbBPSellExcess = new GroupBox();
            btnBPListMats = new Button();
            btnBPListMats.Click += new EventHandler(btnBPListMats_Click);
            chkBPSellExcessItems = new CheckBox();
            chkBPSellExcessItems.CheckedChanged += new EventHandler(chkBPSellExcessItems_CheckedChanged);
            btnBPSaveBP = new Button();
            btnBPSaveBP.Click += new EventHandler(btnBPSaveBP_Click);
            tabBPInventionEquip = new TabControl();
            tabBPInventionEquip.Click += new EventHandler(tabBPInventionEquip_Click);
            tabFacility = new TabPage();
            BPTabFacility = new ManufacturingFacility();
            tabT3Calcs = new TabPage();
            lblBPT3Decryptor = new Label();
            cmbBPT3Decryptor = new ComboBox();
            cmbBPT3Decryptor.DropDown += new EventHandler(cmbBPT3Decryptor_DropDown);
            cmbBPT3Decryptor.SelectedIndexChanged += new EventHandler(cmbBPT3Decryptor_SelectedIndexChanged);
            cmbBPT3Decryptor.KeyPress += new KeyPressEventHandler(cmbBPREDecryptor_KeyPress);
            lblBPT3Stats = new Label();
            lblBPRelic = new Label();
            txtBPRelicLines = new TextBox();
            lblBPRelicLines = new Label();
            lblBPRETime = new Label();
            cmbBPRelic = new ComboBox();
            cmbBPRelic.DropDown += new EventHandler(cmbBPRelic_DropDown);
            cmbBPRelic.SelectedIndexChanged += new EventHandler(cmbBPRelic_SelectedIndexChanged);
            lblBPRECost = new Label();
            lblBPRECost.DoubleClick += new EventHandler(lblBPRECost_DoubleClick);
            lblBPT3InventionChance = new Label();
            lblBPT3InventionChance1 = new Label();
            lblT3InventStatus = new Label();
            lblT3InventStatus.DoubleClick += new EventHandler(lblReverseEngineerStatus_Click);
            chkBPIncludeT3Time = new CheckBox();
            chkBPIncludeT3Time.CheckedChanged += new EventHandler(chkBPIncludeT3Time_CheckedChanged);
            chkBPIncludeT3Costs = new CheckBox();
            chkBPIncludeT3Costs.CheckedChanged += new EventHandler(chkBPIncludeT3Costs_CheckedChanged);
            tabInventionCalcs = new TabPage();
            lblBPCopyTime = new Label();
            lblBPT2InventStatus = new Label();
            lblBPT2InventStatus.DoubleClick += new EventHandler(lblBPInventStatus_Click);
            lblBPCopyCosts = new Label();
            lblBPCopyCosts.DoubleClick += new EventHandler(lblBPCopyCosts_DoubleClick);
            txtBPInventionLines = new TextBox();
            txtBPInventionLines.DoubleClick += new EventHandler(txtBPInventionLines_DoubleClick);
            txtBPInventionLines.KeyDown += new KeyEventHandler(txtBPInventionLines_KeyDown);
            txtBPInventionLines.KeyPress += new KeyPressEventHandler(txtBPInventionLines_KeyPress);
            lblBPInventionLines = new Label();
            lblInventionChance1 = new Label();
            lblBPDecryptor = new Label();
            lblBPInventionTime = new Label();
            lblBPDecryptorStats = new Label();
            lblBPInventionCost = new Label();
            lblBPInventionCost.DoubleClick += new EventHandler(lblBPInventionCost_DoubleClick);
            cmbBPInventionDecryptor = new ComboBox();
            cmbBPInventionDecryptor.DropDown += new EventHandler(cmbBPInventionDecryptor_DropDown);
            cmbBPInventionDecryptor.SelectedIndexChanged += new EventHandler(cmbBPInventionDecryptor_SelectedIndexChanged);
            cmbBPInventionDecryptor.KeyPress += new KeyPressEventHandler(cmbBPInventionDecryptor_KeyPress);
            lblBPInventionChance = new Label();
            chkBPIncludeInventionTime = new CheckBox();
            chkBPIncludeInventionTime.CheckedChanged += new EventHandler(chkBPIncludeInventionTime_CheckedChanged);
            chkBPIncludeCopyTime = new CheckBox();
            chkBPIncludeCopyTime.CheckedChanged += new EventHandler(chkBPIncludeCopyTime_CheckedChanged);
            chkBPIncludeCopyCosts = new CheckBox();
            chkBPIncludeCopyCosts.CheckedChanged += new EventHandler(chkBPIncludeCopyCosts_CheckedChanged);
            chkBPIncludeInventionCosts = new CheckBox();
            chkBPIncludeInventionCosts.CheckedChanged += new EventHandler(chkBPIncludeInventionCosts_CheckedChanged);
            btnBPSaveSettings = new Button();
            btnBPSaveSettings.Click += new EventHandler(btnBPSaveSettings_Click);
            txtBPLines = new TextBox();
            txtBPLines.DoubleClick += new EventHandler(txtBPLines_DoubleClick);
            txtBPLines.LostFocus += new EventHandler(txtBPLines_LostFocus);
            txtBPLines.KeyDown += new KeyEventHandler(txtBPLines_KeyDown);
            txtBPLines.KeyPress += new KeyPressEventHandler(txtBPLines_KeyPress);
            txtBPLines.TextChanged += new EventHandler(txtBPLines_TextChanged);
            pictBP = new PictureBox();
            pictBP.DoubleClick += new EventHandler(pictBP_DoubleClick);
            gbBPManualSystemCostIndex = new GroupBox();
            btnBPUpdateCostIndex = new Button();
            btnBPUpdateCostIndex.Click += new EventHandler(btnBPUpdateCostIndex_Click);
            lblBPSystemCostIndexManual = new Label();
            txtBPUpdateCostIndex = new TextBox();
            txtBPUpdateCostIndex.GotFocus += new EventHandler(txtBPUpdateCostIndex_GotFocus);
            txtBPUpdateCostIndex.KeyDown += new KeyEventHandler(txtBPUpdateCostIndex_KeyDown);
            txtBPUpdateCostIndex.KeyPress += new KeyPressEventHandler(txtBPUpdateCostIndex_KeyPress);
            txtBPUpdateCostIndex.LostFocus += new EventHandler(txtBPUpdateCostIndex_LostFocus);
            txtBPNumBPs = new TextBox();
            txtBPNumBPs.DoubleClick += new EventHandler(txtBPNumBPs_DoubleClick);
            txtBPNumBPs.KeyDown += new KeyEventHandler(txtBPNumBPs_KeyDown);
            txtBPNumBPs.KeyPress += new KeyPressEventHandler(txtBPNumBPs_KeyPress);
            txtBPNumBPs.TextChanged += new EventHandler(txtBPNumBPs_TextChanged);
            txtBPNumBPs.LostFocus += new EventHandler(txtBPNumBPs_LostFocus);
            btnBPRefreshBP = new Button();
            btnBPRefreshBP.Click += new EventHandler(btnRefreshBP_Click);
            lblBPLines = new Label();
            txtBPME = new TextBox();
            txtBPME.KeyDown += new KeyEventHandler(txtBPME_KeyDown);
            txtBPME.KeyPress += new KeyPressEventHandler(txtBPME_KeyPress);
            txtBPME.TextChanged += new EventHandler(txtBPME_TextChanged);
            txtBPME.LostFocus += new EventHandler(txtBPME_LostFocus);
            lblBPRuns = new Label();
            chkBPBuildBuy = new CheckBox();
            chkBPBuildBuy.CheckedChanged += new EventHandler(chkBPBuildBuy_CheckedChanged);
            txtBPRuns = new TextBox();
            txtBPRuns.MouseWheel += new MouseEventHandler(txtBPRuns_MouseWheel);
            txtBPRuns.GotFocus += new EventHandler(txtBPRuns_GotFocus);
            txtBPRuns.KeyDown += new KeyEventHandler(txtBPRuns_KeyDown);
            txtBPRuns.KeyPress += new KeyPressEventHandler(txtBPRuns_KeyPress);
            txtBPRuns.TextChanged += new EventHandler(txtBPRuns_TextChanged);
            txtBPRuns.KeyUp += new KeyEventHandler(txtBPRuns_KeyUp);
            txtBPRuns.LostFocus += new EventHandler(txtBPRuns_LostFocus);
            txtBPAddlCosts = new TextBox();
            txtBPAddlCosts.KeyDown += new KeyEventHandler(txtBPAddlCosts_KeyDown);
            txtBPAddlCosts.KeyPress += new KeyPressEventHandler(txtBPAddlCosts_KeyPress);
            txtBPAddlCosts.LostFocus += new EventHandler(txtBPAddlCosts_LostFocus);
            txtBPAddlCosts.TextChanged += new EventHandler(txtBPAddlCosts_TextChanged);
            lblBPAddlCosts = new Label();
            lblBPME = new Label();
            txtBPTE = new TextBox();
            txtBPTE.KeyDown += new KeyEventHandler(txtBPTE_KeyDown);
            txtBPTE.KeyPress += new KeyPressEventHandler(txtBPTE_KeyPress);
            txtBPTE.TextChanged += new EventHandler(txtBPTE_TextChanged);
            txtBPTE.LostFocus += new EventHandler(txtBPTE_LostFocus);
            lblBPPE = new Label();
            lblBPNumBPs = new Label();
            gbBPIgnoreinCalcs = new GroupBox();
            chkBPIgnoreMinerals = new CheckBox();
            chkBPIgnoreMinerals.CheckedChanged += new EventHandler(chkBPIgnoreMinerals_CheckedChanged);
            chkBPIgnoreT1Item = new CheckBox();
            chkBPIgnoreT1Item.CheckedChanged += new EventHandler(chkBPIgnoreT1Item_CheckedChanged);
            chkBPIgnoreInvention = new CheckBox();
            chkBPIgnoreInvention.CheckedChanged += new EventHandler(chkBPIgnoreInvention_CheckedChanged);
            btnBPBuiltComponents = new Button();
            btnBPBuiltComponents.Click += new EventHandler(btnBPBuiltComponents_Click);
            btnBPComponents = new Button();
            btnBPComponents.Click += new EventHandler(btnBPComponents_Click);
            rbtnBPRawT2MatType = new RadioButton();
            rbtnBPRawT2MatType.CheckedChanged += new EventHandler(rbtnBPRawT2MatType_CheckedChanged);
            rbtnBPProcT2MatType = new RadioButton();
            rbtnBPProcT2MatType.CheckedChanged += new EventHandler(rbtnBPProcT2MatType_CheckedChanged);
            rbtnBPAdvT2MatType = new RadioButton();
            rbtnBPAdvT2MatType.CheckedChanged += new EventHandler(rbtnBPAdvT2MatType_CheckedChanged);
            lblBPT2MatTypeSelector = new Label();
            lstBPList = new ListBox();
            lstBPList.SelectedValueChanged += new EventHandler(lstBPList_SelectedValueChanged);
            lstBPList.MouseDown += new MouseEventHandler(lstBPList_MouseDown);
            lstBPList.MouseMove += new MouseEventHandler(lstBPList_MouseMove);
            lstBPList.LostFocus += new EventHandler(lstBPList_LostFocus);
            gbBPBlueprintType = new GroupBox();
            chkBPNPCBPOs = new CheckBox();
            chkBPNPCBPOs.CheckedChanged += new EventHandler(chkBPNPCBPOs_CheckedChanged);
            rbtnBPReactionsBlueprints = new RadioButton();
            rbtnBPReactionsBlueprints.CheckedChanged += new EventHandler(rbtnBPReactionsBlueprints_CheckedChanged);
            rbtnBPStructureModulesBlueprints = new RadioButton();
            rbtnBPStructureModulesBlueprints.CheckedChanged += new EventHandler(rbtnBPStationModulesBlueprints_CheckedChanged);
            rbtnBPCelestialsBlueprints = new RadioButton();
            rbtnBPCelestialsBlueprints.CheckedChanged += new EventHandler(rbtnBPCelestialBlueprints_CheckedChanged);
            rbtnBPMiscBlueprints = new RadioButton();
            rbtnBPMiscBlueprints.CheckedChanged += new EventHandler(rbtnToolBlueprints_CheckedChanged);
            rbtnBPStructureBlueprints = new RadioButton();
            rbtnBPStructureBlueprints.CheckedChanged += new EventHandler(rbtnStructureBlueprints_CheckedChanged);
            rbtnBPFavoriteBlueprints = new RadioButton();
            rbtnBPFavoriteBlueprints.CheckedChanged += new EventHandler(rbtnBPFavoriteBlueprints_CheckedChanged);
            rbtnBPStructureRigsBlueprints = new RadioButton();
            rbtnBPStructureRigsBlueprints.CheckedChanged += new EventHandler(rbtnBPStationPartsBlueprints_CheckedChanged);
            rbtnBPOwnedBlueprints = new RadioButton();
            rbtnBPOwnedBlueprints.CheckedChanged += new EventHandler(rbtnBPOwnedBlueprints_CheckedChanged);
            rbtnBPRigBlueprints = new RadioButton();
            rbtnBPRigBlueprints.CheckedChanged += new EventHandler(rbtnRigBlueprints_CheckedChanged);
            rbtnBPBoosterBlueprints = new RadioButton();
            rbtnBPBoosterBlueprints.CheckedChanged += new EventHandler(rbtnBoosterBlueprints_CheckedChanged);
            rbtnBPSubsystemBlueprints = new RadioButton();
            rbtnBPSubsystemBlueprints.CheckedChanged += new EventHandler(rbtnSubsystemBlueprints_CheckedChanged);
            rbtnBPModuleBlueprints = new RadioButton();
            rbtnBPModuleBlueprints.CheckedChanged += new EventHandler(rbtnModuleBlueprints_CheckedChanged);
            rbtnBPAmmoChargeBlueprints = new RadioButton();
            rbtnBPAmmoChargeBlueprints.CheckedChanged += new EventHandler(rbtnAmmoChargeBlueprints_CheckedChanged);
            rbtnBPDroneBlueprints = new RadioButton();
            rbtnBPDroneBlueprints.CheckedChanged += new EventHandler(rbtnDroneBlueprints_CheckedChanged);
            rbtnBPComponentBlueprints = new RadioButton();
            rbtnBPComponentBlueprints.CheckedChanged += new EventHandler(rbtnComponentBlueprints_CheckedChanged);
            rbtnBPAllBlueprints = new RadioButton();
            rbtnBPAllBlueprints.CheckedChanged += new EventHandler(rbtnAllBlueprints_CheckedChanged);
            rbtnBPShipBlueprints = new RadioButton();
            rbtnBPShipBlueprints.CheckedChanged += new EventHandler(rbtnShipBlueprints_CheckedChanged);
            rbtnBPDeployableBlueprints = new RadioButton();
            rbtnBPDeployableBlueprints.CheckedChanged += new EventHandler(rbtnBPDeployableBlueprints_CheckedChanged);
            gbBPBlueprintTech = new GroupBox();
            chkBPPirateFaction = new CheckBox();
            chkBPPirateFaction.CheckedChanged += new EventHandler(chkBPPirateFaction_CheckedChanged);
            chkBPStoryline = new CheckBox();
            chkBPStoryline.CheckedChanged += new EventHandler(chkBPStoryline_CheckedChanged);
            chkBPNavyFaction = new CheckBox();
            chkBPNavyFaction.CheckedChanged += new EventHandler(chkBPNavyFaction_CheckedChanged);
            chkBPT3 = new CheckBox();
            chkBPT3.CheckedChanged += new EventHandler(chkbpT3_CheckedChanged);
            chkBPT2 = new CheckBox();
            chkBPT2.CheckedChanged += new EventHandler(chkbpT2_CheckedChanged);
            chkBPT1 = new CheckBox();
            chkBPT1.CheckedChanged += new EventHandler(chkbpT1_CheckedChanged);
            gbFilters = new GroupBox();
            chkBPXL = new CheckBox();
            chkBPXL.CheckedChanged += new EventHandler(chkBPXL_CheckedChanged);
            chkBPLarge = new CheckBox();
            chkBPLarge.CheckedChanged += new EventHandler(chkBPLarge_CheckedChanged);
            chkBPMedium = new CheckBox();
            chkBPMedium.CheckedChanged += new EventHandler(chkBPMedium_CheckedChanged);
            chkBPSmall = new CheckBox();
            chkBPSmall.CheckedChanged += new EventHandler(chkBPSmall_CheckedChanged);
            cmbBPBlueprintSelection = new ComboBox();
            cmbBPBlueprintSelection.DropDown += new EventHandler(cmbBPBlueprintSelection_DropDown);
            cmbBPBlueprintSelection.DropDownClosed += new EventHandler(cmbBPBlueprintSelection_DropDownClosed);
            cmbBPBlueprintSelection.MouseWheel += new MouseEventHandler(cmbBPBlueprintSelection_MouseWheel);
            cmbBPBlueprintSelection.DoubleClick += new EventHandler(cmbBPBlueprintSelection_DoubleClick);
            cmbBPBlueprintSelection.LostFocus += new EventHandler(cmbBPBlueprintSelection_LostFocus);
            cmbBPBlueprintSelection.SelectionChangeCommitted += new EventHandler(cmbBPBlueprintSelection_SelectionChangeCommitted);
            cmbBPBlueprintSelection.TextChanged += new EventHandler(cmbBPBlueprintSelection_TextChanged);
            cmbBPBlueprintSelection.KeyDown += new KeyEventHandler(cmbBPBlueprintSelection_KeyDown);
            btnBPListView = new Button();
            btnBPListView.Click += new EventHandler(btnBPListView_Click);
            btnBPForward = new Button();
            btnBPForward.Click += new EventHandler(btnBPForward_Click);
            btnBPBack = new Button();
            btnBPBack.Click += new EventHandler(btnBPBack_Click);
            lblBPSelectBlueprint = new Label();
            gbBPInventionStats = new GroupBox();
            txtBPBrokerFeeRate = new TextBox();
            txtBPBrokerFeeRate.KeyDown += new KeyEventHandler(txtBPBrokerFeeRate_KeyDown);
            txtBPBrokerFeeRate.KeyPress += new KeyPressEventHandler(txtBPBrokerFeeRate_KeyPress);
            txtBPBrokerFeeRate.GotFocus += new EventHandler(txtBPBrokerFeeRate_GotFocus);
            txtBPBrokerFeeRate.LostFocus += new EventHandler(txtBPBrokerFeeRate_LostFocus);
            txtBPMarketPriceEdit = new TextBox();
            txtBPMarketPriceEdit.GotFocus += new EventHandler(txtBPMarketPriceEdit_GotFocus);
            txtBPMarketPriceEdit.KeyDown += new KeyEventHandler(txtBPMarketPriceEdit_KeyDown);
            txtBPMarketPriceEdit.KeyPress += new KeyPressEventHandler(txtBPMarketPriceEdit_KeyPress);
            txtBPMarketPriceEdit.LostFocus += new EventHandler(txtBPMarketPriceEdit_LostFocus);
            lblBPProductionTime = new Label();
            lblBPTotalUnits = new Label();
            lblBPTaxes = new Label();
            lblBPTotalUnits1 = new Label();
            lblBPBrokerFees = new Label();
            lblBPPT = new Label();
            chkBPTaxes = new CheckBox();
            chkBPTaxes.CheckedChanged += new EventHandler(chkBPTaxesFees_CheckedChanged);
            lblBPMarketCost = new Label();
            lblBPMarketCost.Click += new EventHandler(lblBPMarketCost_Click);
            lblBPMarketCost1 = new Label();
            lblBPRawTotalCost = new Label();
            lblBPRawTotalCost.DoubleClick += new EventHandler(lblBPRawTotalCost_DoubleClick);
            lblBPCompProfit = new Label();
            lblBPCompProfit.DoubleClick += new EventHandler(lblBPCompProfit_DoubleClick);
            lblBPRawTotalCost1 = new Label();
            chkBPBrokerFees = new CheckBox();
            chkBPBrokerFees.CheckedChanged += new EventHandler(chkBPBrokerFees_CheckedChanged);
            chkBPBrokerFees.Click += new EventHandler(chkBPBrokerFees_Click);
            lblBPCompIPH = new Label();
            lblBPRawIPH = new Label();
            lblBPTotalCompCost1 = new Label();
            lblBPCompIPH1 = new Label();
            lblBPTotalItemPT = new Label();
            lblBPTotalCompCost = new Label();
            lblBPTotalCompCost.DoubleClick += new EventHandler(lblBPTotalCompCost_DoubleClick);
            lblBPCPTPT = new Label();
            lblBPRawSVR = new Label();
            lblBPRawSVR.DoubleClick += new EventHandler(lblBPRawSVR_DoubleClick);
            lblBPRawIPH1 = new Label();
            lblBPRawProfit = new Label();
            lblBPRawProfit.DoubleClick += new EventHandler(lblBPRawProfit_DoubleClick);
            lblBPBPSVR = new Label();
            lblBPBPSVR.DoubleClick += new EventHandler(lblBPBPSVR_DoubleClick);
            lblBPCompProfit1 = new Label();
            lblBPRawProfit1 = new Label();
            lblBPBPSVR1 = new Label();
            lblBPRawSVR1 = new Label();
            chkBPPricePerUnit = new CheckBox();
            chkBPPricePerUnit.CheckedChanged += new EventHandler(chkPerUnit_CheckedChanged);
            lblBPBuyColor = new Label();
            lblBPBuildColor = new Label();
            gbBPShopandCopy = new GroupBox();
            chkBPSimpleCopy = new CheckBox();
            rbtnBPCopyInvREMats = new RadioButton();
            rbtnBPComponentCopy = new RadioButton();
            rbtnBPRawmatCopy = new RadioButton();
            btnBPCopyMatstoClip = new Button();
            btnBPCopyMatstoClip.Click += new EventHandler(btnCopyMatstoClip_Click);
            btnBPAddBPMatstoShoppingList = new Button();
            btnBPAddBPMatstoShoppingList.Click += new EventHandler(btnAddBPMatstoShoppingList_Click);
            lblBPSimpleCopy = new Label();
            lblBPCanMakeBPAll = new Label();
            lblBPCanMakeBPAll.DoubleClick += new EventHandler(lblBPCanMakeBPAll_DoubleClick);
            lblBPRawMatCost = new Label();
            lblBPRawMatCost1 = new Label();
            lblBPCanMakeBP = new Label();
            lblBPCanMakeBP.DoubleClick += new EventHandler(lblBPCanMakeBP_DoubleClick);
            lblBPRawMats = new Label();
            lblBPComponentMatCost = new Label();
            lblBPComponentMats = new Label();
            lblBPComponentMatCost1 = new Label();
            lstBPComponentMats = new MyListView();
            lstBPComponentMats.ProcMsg += new MyListView.ProcMsgEventHandler(lstBPComponentMats_ProcMsg);
            lstBPComponentMats.ColumnClick += new ColumnClickEventHandler(lstBPComponentMats_ColumnClick);
            lstBPComponentMats.MouseClick += new MouseEventHandler(lstBPComponentMats_MouseClick);
            lstBPComponentMats.MouseDown += new MouseEventHandler(lstBPComponentMats_MouseDown);
            lstBPComponentMats.MouseUp += new MouseEventHandler(lstBPComponentMats_MouseUp);
            lstBPComponentMats.ItemCheck += new ItemCheckEventHandler(lstBPComponentMats_ItemCheck);
            lstBPComponentMats.ItemChecked += new ItemCheckedEventHandler(lstBPComponentMats_ItemChecked);
            lstBPComponentMats.DoubleClick += new EventHandler(lstBPComponentMats_DoubleClick);
            lstBPRawMats = new MyListView();
            lstBPRawMats.ProcMsg += new MyListView.ProcMsgEventHandler(lstBPRawMats_ProcMsg);
            lstBPRawMats.ColumnClick += new ColumnClickEventHandler(lstBPRawMats_ColumnClick);
            lstBPRawMats.MouseClick += new MouseEventHandler(lstBPRawMats_MouseClick);
            lstBPBuiltComponents = new MyListView();
            tabMain = new TabControl();
            tabMain.Click += new EventHandler(tabMain_Click);
            mnuStripMain.SuspendLayout();
            pnlMain.SuspendLayout();
            ListOptionsMenu.SuspendLayout();
            tabPI.SuspendLayout();
            gbPIPlanets.SuspendLayout();
            tabMining.SuspendLayout();
            gbMineCrystalType.SuspendLayout();
            tabMiningDrones.SuspendLayout();
            tabShipDrones.SuspendLayout();
            tabBoosterDrones.SuspendLayout();
            gbMineCrystals.SuspendLayout();
            gbMineNumberMiners.SuspendLayout();
            gbMineOreProcessingType.SuspendLayout();
            gbMineTaxBroker.SuspendLayout();
            gbMineStripStats.SuspendLayout();
            gbMineHauling.SuspendLayout();
            gbMineBooster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictMineLaserOptmize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineRangeLink).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictMineFleetBoostShip).BeginInit();
            gbMineRefining.SuspendLayout();
            gbMineOreStuctureRates.SuspendLayout();
            tabMiningProcessingSkills.SuspendLayout();
            tabPageOres.SuspendLayout();
            tabPageMoonOres.SuspendLayout();
            tabPageIce.SuspendLayout();
            gbMineShipSetup.SuspendLayout();
            gbMineSelectShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictMineSelectedShip).BeginInit();
            gbMineShipEquipment.SuspendLayout();
            gbMiningRigs.SuspendLayout();
            gbMineSkills.SuspendLayout();
            gbMineMain.SuspendLayout();
            gbMineIncludeOres.SuspendLayout();
            gbMineOreLocSov.SuspendLayout();
            gbMineWHSpace.SuspendLayout();
            tabDatacores.SuspendLayout();
            gbDCOptions.SuspendLayout();
            gbDCAgentLocSov.SuspendLayout();
            gbDCTotalIPH.SuspendLayout();
            gbDCPrices.SuspendLayout();
            gbDCAgentTypes.SuspendLayout();
            gbDCBaseSkills.SuspendLayout();
            gbDCDatacores.SuspendLayout();
            gbDCCodes.SuspendLayout();
            gbDCCorpMinmatar.SuspendLayout();
            gbDCCorpAmarr.SuspendLayout();
            gbDCCorpsCaldari.SuspendLayout();
            gbDCCorpsGallente.SuspendLayout();
            tabManufacturing.SuspendLayout();
            gbCalcBPSelectOptions.SuspendLayout();
            gbCalcIgnoreinCalcs.SuspendLayout();
            gbIncludeTaxesFees.SuspendLayout();
            gbCalcSellExessItems.SuspendLayout();
            gbCalcIncludeItems.SuspendLayout();
            gbCalcMarketFilters.SuspendLayout();
            gbCalcSizeLimit.SuspendLayout();
            gbCalcProdLines.SuspendLayout();
            gbCalcCompareType.SuspendLayout();
            gbCalcTextColors.SuspendLayout();
            gbCalcInvention.SuspendLayout();
            gbCalcBPRace.SuspendLayout();
            gbTempMEPE.SuspendLayout();
            tabCalcFacilities.SuspendLayout();
            tabCalcFacilityBase.SuspendLayout();
            tabCalcFacilityComponents.SuspendLayout();
            tabCalcFacilityCopy.SuspendLayout();
            tabCalcFacilityT2Invention.SuspendLayout();
            tabCalcFacilityT3Invention.SuspendLayout();
            tabCalcFacilitySupers.SuspendLayout();
            tabCalcFacilityCapitals.SuspendLayout();
            tabCalcFacilityT3Ships.SuspendLayout();
            tabCalcFacilitySubsystems.SuspendLayout();
            tabCalcFacilityBoosters.SuspendLayout();
            tabCalcFacilityReactions.SuspendLayout();
            gbCalcFilter.SuspendLayout();
            gbCalcBPTech.SuspendLayout();
            gbCalcIncludeOwned.SuspendLayout();
            gbCalcTextFilter.SuspendLayout();
            gbCalcBPType.SuspendLayout();
            gbCalcBPSelect.SuspendLayout();
            gbCalcRelics.SuspendLayout();
            tabUpdatePrices.SuspendLayout();
            gbRawMaterials.SuspendLayout();
            gbReactionMaterials.SuspendLayout();
            gbResearchEquipment.SuspendLayout();
            gbSingleSource.SuspendLayout();
            gbMarketStructures.SuspendLayout();
            gbRegionSystemPrice.SuspendLayout();
            gbTradeHubSystems.SuspendLayout();
            gbPriceProfile.SuspendLayout();
            tabPriceProfile.SuspendLayout();
            tabPriceProfileRaw.SuspendLayout();
            tabPriceProfileManufactured.SuspendLayout();
            gbPPDefaultSettings.SuspendLayout();
            gbPriceOptions.SuspendLayout();
            gbPriceTypes.SuspendLayout();
            gbDataSource.SuspendLayout();
            gbManufacturedItems.SuspendLayout();
            gbComponents.SuspendLayout();
            gbReprocessables.SuspendLayout();
            gbItems.SuspendLayout();
            gbPricesTech.SuspendLayout();
            tabBlueprints.SuspendLayout();
            gbBPMEPEImage.SuspendLayout();
            gbBPSellExcess.SuspendLayout();
            tabBPInventionEquip.SuspendLayout();
            tabFacility.SuspendLayout();
            tabT3Calcs.SuspendLayout();
            tabInventionCalcs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictBP).BeginInit();
            gbBPManualSystemCostIndex.SuspendLayout();
            gbBPIgnoreinCalcs.SuspendLayout();
            gbBPBlueprintType.SuspendLayout();
            gbBPBlueprintTech.SuspendLayout();
            gbFilters.SuspendLayout();
            gbBPInventionStats.SuspendLayout();
            gbBPShopandCopy.SuspendLayout();
            tabMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuStripMain
            // 
            mnuStripMain.Items.AddRange(new ToolStripItem[] { mnuFile, mnuEdit, mnuUpdateData, ViewToolStripMenuItem, mnuTools, mnuSettings, mnuAbout });
            mnuStripMain.Location = new Point(0, 0);
            mnuStripMain.Name = "mnuStripMain";
            mnuStripMain.Size = new Size(1149, 28);
            mnuStripMain.TabIndex = 0;
            mnuStripMain.Text = "MainMenu";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuSelectionAddChar, mnuSelectionManageCharacters, mnuViewErrorLog, ToolStripSeparator1, mnuSelectionExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(44, 24);
            mnuFile.Text = "File";
            // 
            // mnuSelectionAddChar
            // 
            mnuSelectionAddChar.Name = "mnuSelectionAddChar";
            mnuSelectionAddChar.Size = new Size(196, 24);
            mnuSelectionAddChar.Text = "Add Character";
            // 
            // mnuSelectionManageCharacters
            // 
            mnuSelectionManageCharacters.Name = "mnuSelectionManageCharacters";
            mnuSelectionManageCharacters.Size = new Size(196, 24);
            mnuSelectionManageCharacters.Text = "Manage Accounts";
            // 
            // mnuViewErrorLog
            // 
            mnuViewErrorLog.Name = "mnuViewErrorLog";
            mnuViewErrorLog.Size = new Size(196, 24);
            mnuViewErrorLog.Text = "View Error Log";
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(193, 6);
            // 
            // mnuSelectionExit
            // 
            mnuSelectionExit.Name = "mnuSelectionExit";
            mnuSelectionExit.Size = new Size(196, 24);
            mnuSelectionExit.Text = "Exit";
            // 
            // mnuEdit
            // 
            mnuEdit.DropDownItems.AddRange(new ToolStripItem[] { mnuItemUpdatePrices, SetPOSDataToolStripMenuItem, mnuManageBlueprintsToolStripMenuItem, mnuClearBPHistory });
            mnuEdit.Name = "mnuEdit";
            mnuEdit.Size = new Size(47, 24);
            mnuEdit.Text = "Edit";
            // 
            // mnuItemUpdatePrices
            // 
            mnuItemUpdatePrices.Name = "mnuItemUpdatePrices";
            mnuItemUpdatePrices.Size = new Size(202, 24);
            mnuItemUpdatePrices.Text = "Prices";
            // 
            // SetPOSDataToolStripMenuItem
            // 
            SetPOSDataToolStripMenuItem.Name = "SetPOSDataToolStripMenuItem";
            SetPOSDataToolStripMenuItem.Size = new Size(202, 24);
            SetPOSDataToolStripMenuItem.Text = "POS Data";
            SetPOSDataToolStripMenuItem.Visible = false;
            // 
            // mnuManageBlueprintsToolStripMenuItem
            // 
            mnuManageBlueprintsToolStripMenuItem.Name = "mnuManageBlueprintsToolStripMenuItem";
            mnuManageBlueprintsToolStripMenuItem.Size = new Size(202, 24);
            mnuManageBlueprintsToolStripMenuItem.Text = "Manage Blueprints";
            // 
            // mnuClearBPHistory
            // 
            mnuClearBPHistory.Name = "mnuClearBPHistory";
            mnuClearBPHistory.Size = new Size(202, 24);
            mnuClearBPHistory.Text = "Clear BP History";
            // 
            // mnuUpdateData
            // 
            mnuUpdateData.DropDownItems.AddRange(new ToolStripItem[] { mnuUpdateIndustryFacilities, mnuUpdateESIMarketPrices, mnuUpdateESIPublicStructures, mnuChangeDummyCharacterName, ToolStripSeparator6, mnuResetData });
            mnuUpdateData.Name = "mnuUpdateData";
            mnuUpdateData.Size = new Size(53, 24);
            mnuUpdateData.Text = "Data";
            // 
            // mnuUpdateIndustryFacilities
            // 
            mnuUpdateIndustryFacilities.Name = "mnuUpdateIndustryFacilities";
            mnuUpdateIndustryFacilities.Size = new Size(295, 24);
            mnuUpdateIndustryFacilities.Text = "Update Industry Facilities";
            // 
            // mnuUpdateESIMarketPrices
            // 
            mnuUpdateESIMarketPrices.Name = "mnuUpdateESIMarketPrices";
            mnuUpdateESIMarketPrices.Size = new Size(295, 24);
            mnuUpdateESIMarketPrices.Text = "Update Adjusted Market Prices";
            // 
            // mnuUpdateESIPublicStructures
            // 
            mnuUpdateESIPublicStructures.Name = "mnuUpdateESIPublicStructures";
            mnuUpdateESIPublicStructures.Size = new Size(295, 24);
            mnuUpdateESIPublicStructures.Text = "Update Public Structures";
            // 
            // mnuChangeDummyCharacterName
            // 
            mnuChangeDummyCharacterName.Name = "mnuChangeDummyCharacterName";
            mnuChangeDummyCharacterName.Size = new Size(295, 24);
            mnuChangeDummyCharacterName.Text = "Change Dummy Character Name";
            // 
            // ToolStripSeparator6
            // 
            ToolStripSeparator6.Name = "ToolStripSeparator6";
            ToolStripSeparator6.Size = new Size(292, 6);
            // 
            // mnuResetData
            // 
            mnuResetData.DropDownItems.AddRange(new ToolStripItem[] { mnuResetBlueprintData, mnuResetIgnoredBPs, mnuResetPriceData, mnuResetAgents, mnuResetIndustryJobs, mnuResetAssets, mnuResetMarketHistory, mnuResetMarketOrders, mnuResetESIPublicStructures, mnuResetSavedFacilities, mnuResetESIIndustryFacilities, mnuResetESIMarketPrices, mnuResetESIDates, ToolStripSeparator4, mnuResetAllData });
            mnuResetData.Name = "mnuResetData";
            mnuResetData.Size = new Size(295, 24);
            mnuResetData.Text = "Reset Data";
            // 
            // mnuResetBlueprintData
            // 
            mnuResetBlueprintData.Name = "mnuResetBlueprintData";
            mnuResetBlueprintData.Size = new Size(309, 24);
            mnuResetBlueprintData.Text = "Reset Blueprint Data";
            // 
            // mnuResetIgnoredBPs
            // 
            mnuResetIgnoredBPs.Name = "mnuResetIgnoredBPs";
            mnuResetIgnoredBPs.Size = new Size(309, 24);
            mnuResetIgnoredBPs.Text = "Reset All Ignored BPs";
            // 
            // mnuResetPriceData
            // 
            mnuResetPriceData.Name = "mnuResetPriceData";
            mnuResetPriceData.Size = new Size(309, 24);
            mnuResetPriceData.Text = "Reset Price Data";
            // 
            // mnuResetAgents
            // 
            mnuResetAgents.Name = "mnuResetAgents";
            mnuResetAgents.Size = new Size(309, 24);
            mnuResetAgents.Text = "Reset Research Agents";
            // 
            // mnuResetIndustryJobs
            // 
            mnuResetIndustryJobs.Name = "mnuResetIndustryJobs";
            mnuResetIndustryJobs.Size = new Size(309, 24);
            mnuResetIndustryJobs.Text = "Reset Industry Jobs";
            // 
            // mnuResetAssets
            // 
            mnuResetAssets.Name = "mnuResetAssets";
            mnuResetAssets.Size = new Size(309, 24);
            mnuResetAssets.Text = "Reset Assets";
            // 
            // mnuResetMarketHistory
            // 
            mnuResetMarketHistory.Name = "mnuResetMarketHistory";
            mnuResetMarketHistory.Size = new Size(309, 24);
            mnuResetMarketHistory.Text = "Reset Market History";
            // 
            // mnuResetMarketOrders
            // 
            mnuResetMarketOrders.Name = "mnuResetMarketOrders";
            mnuResetMarketOrders.Size = new Size(309, 24);
            mnuResetMarketOrders.Text = "Reset Market Orders";
            // 
            // mnuResetESIPublicStructures
            // 
            mnuResetESIPublicStructures.Name = "mnuResetESIPublicStructures";
            mnuResetESIPublicStructures.Size = new Size(309, 24);
            mnuResetESIPublicStructures.Text = "Reset Public Structures";
            // 
            // mnuResetSavedFacilities
            // 
            mnuResetSavedFacilities.Name = "mnuResetSavedFacilities";
            mnuResetSavedFacilities.Size = new Size(309, 24);
            mnuResetSavedFacilities.Text = "Reset Saved Facilities";
            // 
            // mnuResetESIIndustryFacilities
            // 
            mnuResetESIIndustryFacilities.Name = "mnuResetESIIndustryFacilities";
            mnuResetESIIndustryFacilities.Size = new Size(309, 24);
            mnuResetESIIndustryFacilities.Text = "Reset Industry System Indicies (ESI)";
            // 
            // mnuResetESIMarketPrices
            // 
            mnuResetESIMarketPrices.Name = "mnuResetESIMarketPrices";
            mnuResetESIMarketPrices.Size = new Size(309, 24);
            mnuResetESIMarketPrices.Text = "Reset Adjusted Market Prices (ESI)";
            // 
            // mnuResetESIDates
            // 
            mnuResetESIDates.Name = "mnuResetESIDates";
            mnuResetESIDates.Size = new Size(309, 24);
            mnuResetESIDates.Text = "Reset All ESI Cache Dates";
            // 
            // ToolStripSeparator4
            // 
            ToolStripSeparator4.Name = "ToolStripSeparator4";
            ToolStripSeparator4.Size = new Size(306, 6);
            // 
            // mnuResetAllData
            // 
            mnuResetAllData.Name = "mnuResetAllData";
            mnuResetAllData.Size = new Size(309, 24);
            mnuResetAllData.Text = "Reset All Data";
            // 
            // ViewToolStripMenuItem
            // 
            ViewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuViewAssets, mnuSelectionShoppingList, mnuCharacterSkills, mnuCharacterStandings, ToolStripSeparator5, mnuCurrentResearchAgents, mnuCurrentIndustryJobs, ToolStripSeparator3, mnuViewESIStatus });
            ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            ViewToolStripMenuItem.Size = new Size(53, 24);
            ViewToolStripMenuItem.Text = "View";
            // 
            // mnuViewAssets
            // 
            mnuViewAssets.Name = "mnuViewAssets";
            mnuViewAssets.Size = new Size(239, 24);
            mnuViewAssets.Text = "Assets";
            // 
            // mnuSelectionShoppingList
            // 
            mnuSelectionShoppingList.Name = "mnuSelectionShoppingList";
            mnuSelectionShoppingList.Size = new Size(239, 24);
            mnuSelectionShoppingList.Text = "Shopping List";
            // 
            // mnuCharacterSkills
            // 
            mnuCharacterSkills.Name = "mnuCharacterSkills";
            mnuCharacterSkills.Size = new Size(239, 24);
            mnuCharacterSkills.Text = "Character Skills";
            // 
            // mnuCharacterStandings
            // 
            mnuCharacterStandings.Name = "mnuCharacterStandings";
            mnuCharacterStandings.Size = new Size(239, 24);
            mnuCharacterStandings.Text = "Character Standings";
            // 
            // ToolStripSeparator5
            // 
            ToolStripSeparator5.Name = "ToolStripSeparator5";
            ToolStripSeparator5.Size = new Size(236, 6);
            // 
            // mnuCurrentResearchAgents
            // 
            mnuCurrentResearchAgents.Name = "mnuCurrentResearchAgents";
            mnuCurrentResearchAgents.Size = new Size(239, 24);
            mnuCurrentResearchAgents.Text = "Current Research Agents";
            // 
            // mnuCurrentIndustryJobs
            // 
            mnuCurrentIndustryJobs.Name = "mnuCurrentIndustryJobs";
            mnuCurrentIndustryJobs.Size = new Size(239, 24);
            mnuCurrentIndustryJobs.Text = "Current Industry Jobs";
            // 
            // ToolStripSeparator3
            // 
            ToolStripSeparator3.Name = "ToolStripSeparator3";
            ToolStripSeparator3.Size = new Size(236, 6);
            // 
            // mnuViewESIStatus
            // 
            mnuViewESIStatus.Name = "mnuViewESIStatus";
            mnuViewESIStatus.Size = new Size(239, 24);
            mnuViewESIStatus.Text = "View ESI Status";
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuMETECalculator, mnuReprocessingPlant, mnuOreFlips });
            mnuTools.Name = "mnuTools";
            mnuTools.Size = new Size(56, 24);
            mnuTools.Text = "Tools";
            // 
            // mnuMETECalculator
            // 
            mnuMETECalculator.Name = "mnuMETECalculator";
            mnuMETECalculator.Size = new Size(259, 24);
            mnuMETECalculator.Text = "ME/TE Calculator";
            mnuMETECalculator.Visible = false;
            // 
            // mnuReprocessingPlant
            // 
            mnuReprocessingPlant.Name = "mnuReprocessingPlant";
            mnuReprocessingPlant.Size = new Size(259, 24);
            mnuReprocessingPlant.Text = "Reprocessing Plant";
            // 
            // mnuOreFlips
            // 
            mnuOreFlips.DropDownItems.AddRange(new ToolStripItem[] { mnuAnomalyOreBelts, mnuIceBelts });
            mnuOreFlips.Name = "mnuOreFlips";
            mnuOreFlips.Size = new Size(259, 24);
            mnuOreFlips.Text = "Mining Belt Flip Calculators";
            mnuOreFlips.Visible = false;
            // 
            // mnuAnomalyOreBelts
            // 
            mnuAnomalyOreBelts.Name = "mnuAnomalyOreBelts";
            mnuAnomalyOreBelts.Size = new Size(212, 24);
            mnuAnomalyOreBelts.Text = "Ore Soverignty Belts";
            // 
            // mnuIceBelts
            // 
            mnuIceBelts.Name = "mnuIceBelts";
            mnuIceBelts.Size = new Size(212, 24);
            mnuIceBelts.Text = "Ice Belts";
            // 
            // mnuSettings
            // 
            mnuSettings.DropDownItems.AddRange(new ToolStripItem[] { mnuUserSettings, mnuSelectDefaultChar, mnuRestoreDefaultTabSettings, mnuResetBuildBuyManualSelections });
            mnuSettings.Name = "mnuSettings";
            mnuSettings.Size = new Size(74, 24);
            mnuSettings.Text = "Settings";
            // 
            // mnuUserSettings
            // 
            mnuUserSettings.Name = "mnuUserSettings";
            mnuUserSettings.Size = new Size(306, 24);
            mnuUserSettings.Text = "Select Application Settings";
            // 
            // mnuSelectDefaultChar
            // 
            mnuSelectDefaultChar.Name = "mnuSelectDefaultChar";
            mnuSelectDefaultChar.Size = new Size(306, 24);
            mnuSelectDefaultChar.Text = "Select Default Character";
            // 
            // mnuRestoreDefaultTabSettings
            // 
            mnuRestoreDefaultTabSettings.DropDownItems.AddRange(new ToolStripItem[] { mnuRestoreDefaultBP, mnuRestoreDefaultUpdatePrices, mnuRestoreDefaultManufacturing, mnuRestoreDefaultDatacores, mnuRestoreDefaultMining });
            mnuRestoreDefaultTabSettings.Name = "mnuRestoreDefaultTabSettings";
            mnuRestoreDefaultTabSettings.Size = new Size(306, 24);
            mnuRestoreDefaultTabSettings.Text = "Restore Default Tab Settings";
            // 
            // mnuRestoreDefaultBP
            // 
            mnuRestoreDefaultBP.Name = "mnuRestoreDefaultBP";
            mnuRestoreDefaultBP.Size = new Size(174, 24);
            mnuRestoreDefaultBP.Text = "Blueprints";
            // 
            // mnuRestoreDefaultUpdatePrices
            // 
            mnuRestoreDefaultUpdatePrices.Name = "mnuRestoreDefaultUpdatePrices";
            mnuRestoreDefaultUpdatePrices.Size = new Size(174, 24);
            mnuRestoreDefaultUpdatePrices.Text = "Update Prices";
            // 
            // mnuRestoreDefaultManufacturing
            // 
            mnuRestoreDefaultManufacturing.Name = "mnuRestoreDefaultManufacturing";
            mnuRestoreDefaultManufacturing.Size = new Size(174, 24);
            mnuRestoreDefaultManufacturing.Text = "Manufacturing";
            // 
            // mnuRestoreDefaultDatacores
            // 
            mnuRestoreDefaultDatacores.Name = "mnuRestoreDefaultDatacores";
            mnuRestoreDefaultDatacores.Size = new Size(174, 24);
            mnuRestoreDefaultDatacores.Text = "Datacores";
            // 
            // mnuRestoreDefaultMining
            // 
            mnuRestoreDefaultMining.Name = "mnuRestoreDefaultMining";
            mnuRestoreDefaultMining.Size = new Size(174, 24);
            mnuRestoreDefaultMining.Text = "Mining";
            // 
            // mnuResetBuildBuyManualSelections
            // 
            mnuResetBuildBuyManualSelections.Name = "mnuResetBuildBuyManualSelections";
            mnuResetBuildBuyManualSelections.Size = new Size(306, 24);
            mnuResetBuildBuyManualSelections.Text = "Reset Build/Buy Manual Selections";
            // 
            // mnuAbout
            // 
            mnuAbout.DropDownItems.AddRange(new ToolStripItem[] { mnuHelp, mnuPatchNotes, mnuCheckforUpdates, ToolStripSeparator2, mnuSelectionAbout });
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(62, 24);
            mnuAbout.Text = "About";
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuYouTube, mnuDiscord });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(199, 24);
            mnuHelp.Text = "Help";
            // 
            // mnuYouTube
            // 
            mnuYouTube.Name = "mnuYouTube";
            mnuYouTube.Size = new Size(284, 24);
            mnuYouTube.Text = "Open the IPH YouTube Channel";
            // 
            // mnuDiscord
            // 
            mnuDiscord.Name = "mnuDiscord";
            mnuDiscord.Size = new Size(284, 24);
            mnuDiscord.Text = "Join the IPH Discord Server";
            // 
            // mnuPatchNotes
            // 
            mnuPatchNotes.Name = "mnuPatchNotes";
            mnuPatchNotes.Size = new Size(199, 24);
            mnuPatchNotes.Text = "View Patch Notes";
            // 
            // mnuCheckforUpdates
            // 
            mnuCheckforUpdates.Name = "mnuCheckforUpdates";
            mnuCheckforUpdates.Size = new Size(199, 24);
            mnuCheckforUpdates.Text = "Check for Updates";
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Size = new Size(196, 6);
            // 
            // mnuSelectionAbout
            // 
            mnuSelectionAbout.Name = "mnuSelectionAbout";
            mnuSelectionAbout.Size = new Size(199, 24);
            mnuSelectionAbout.Text = "About IPH";
            // 
            // pnlMain
            // 
            pnlMain.Items.AddRange(new ToolStripItem[] { mnuCharacter, pnlSkills, pnlShoppingList, pnlStatus, pnlProgressBar });
            pnlMain.Location = new Point(0, 669);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1149, 22);
            pnlMain.SizingGrip = false;
            pnlMain.TabIndex = 1;
            pnlMain.Text = "pnlMain";
            // 
            // mnuCharacter
            // 
            mnuCharacter.Alignment = ToolStripItemAlignment.Right;
            mnuCharacter.AutoSize = false;
            mnuCharacter.AutoToolTip = false;
            mnuCharacter.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mnuCharacter.DropDownItems.AddRange(new ToolStripItem[] { tsCharacter1, tsCharacter2, tsCharacter3, tsCharacter4, tsCharacter5, tsCharacter6, tsCharacter7, tsCharacter8, tsCharacter9, tsCharacter10, tsCharacter11, tsCharacter12, tsCharacter13, tsCharacter14, tsCharacter15, tsCharacter16, tsCharacter17, tsCharacter18, tsCharacter19, tsCharacter20 });
            mnuCharacter.ImageAlign = ContentAlignment.MiddleLeft;
            mnuCharacter.ImageScaling = ToolStripItemImageScaling.None;
            mnuCharacter.ImageTransparentColor = Color.Magenta;
            mnuCharacter.Name = "mnuCharacter";
            mnuCharacter.Size = new Size(250, 20);
            mnuCharacter.Text = "Character Loaded:";
            mnuCharacter.TextAlign = ContentAlignment.MiddleLeft;
            mnuCharacter.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // tsCharacter1
            // 
            tsCharacter1.Name = "tsCharacter1";
            tsCharacter1.Size = new Size(168, 24);
            tsCharacter1.Text = "tsCharacter1";
            // 
            // tsCharacter2
            // 
            tsCharacter2.Name = "tsCharacter2";
            tsCharacter2.Size = new Size(168, 24);
            tsCharacter2.Text = "tsCharacter2";
            // 
            // tsCharacter3
            // 
            tsCharacter3.Name = "tsCharacter3";
            tsCharacter3.Size = new Size(168, 24);
            tsCharacter3.Text = "tsCharacter3";
            // 
            // tsCharacter4
            // 
            tsCharacter4.Name = "tsCharacter4";
            tsCharacter4.Size = new Size(168, 24);
            tsCharacter4.Text = "tsCharacter4";
            // 
            // tsCharacter5
            // 
            tsCharacter5.ImageTransparentColor = Color.White;
            tsCharacter5.Name = "tsCharacter5";
            tsCharacter5.Size = new Size(168, 24);
            tsCharacter5.Text = "tsCharacter5";
            // 
            // tsCharacter6
            // 
            tsCharacter6.Name = "tsCharacter6";
            tsCharacter6.Size = new Size(168, 24);
            tsCharacter6.Text = "tsCharacter6";
            // 
            // tsCharacter7
            // 
            tsCharacter7.Name = "tsCharacter7";
            tsCharacter7.Size = new Size(168, 24);
            tsCharacter7.Text = "tsCharacter7";
            // 
            // tsCharacter8
            // 
            tsCharacter8.Name = "tsCharacter8";
            tsCharacter8.Size = new Size(168, 24);
            tsCharacter8.Text = "tsCharacter8";
            // 
            // tsCharacter9
            // 
            tsCharacter9.Name = "tsCharacter9";
            tsCharacter9.Size = new Size(168, 24);
            tsCharacter9.Text = "tsCharacter9";
            // 
            // tsCharacter10
            // 
            tsCharacter10.Name = "tsCharacter10";
            tsCharacter10.Size = new Size(168, 24);
            tsCharacter10.Text = "tsCharacter10";
            // 
            // tsCharacter11
            // 
            tsCharacter11.Name = "tsCharacter11";
            tsCharacter11.Size = new Size(168, 24);
            tsCharacter11.Text = "tsCharacter11";
            // 
            // tsCharacter12
            // 
            tsCharacter12.Name = "tsCharacter12";
            tsCharacter12.Size = new Size(168, 24);
            tsCharacter12.Text = "tsCharacter12";
            // 
            // tsCharacter13
            // 
            tsCharacter13.Name = "tsCharacter13";
            tsCharacter13.Size = new Size(168, 24);
            tsCharacter13.Text = "tsCharacter13";
            // 
            // tsCharacter14
            // 
            tsCharacter14.Name = "tsCharacter14";
            tsCharacter14.Size = new Size(168, 24);
            tsCharacter14.Text = "tsCharacter14";
            // 
            // tsCharacter15
            // 
            tsCharacter15.Name = "tsCharacter15";
            tsCharacter15.Size = new Size(168, 24);
            tsCharacter15.Text = "tsCharacter15";
            // 
            // tsCharacter16
            // 
            tsCharacter16.Name = "tsCharacter16";
            tsCharacter16.Size = new Size(168, 24);
            tsCharacter16.Text = "tsCharacter16";
            // 
            // tsCharacter17
            // 
            tsCharacter17.Name = "tsCharacter17";
            tsCharacter17.Size = new Size(168, 24);
            tsCharacter17.Text = "tsCharacter17";
            // 
            // tsCharacter18
            // 
            tsCharacter18.Name = "tsCharacter18";
            tsCharacter18.Size = new Size(168, 24);
            tsCharacter18.Text = "tsCharacter18";
            // 
            // tsCharacter19
            // 
            tsCharacter19.Name = "tsCharacter19";
            tsCharacter19.Size = new Size(168, 24);
            tsCharacter19.Text = "tsCharacter19";
            // 
            // tsCharacter20
            // 
            tsCharacter20.Name = "tsCharacter20";
            tsCharacter20.Size = new Size(168, 24);
            tsCharacter20.Text = "tsCharacter20";
            // 
            // pnlSkills
            // 
            pnlSkills.AutoSize = false;
            pnlSkills.Name = "pnlSkills";
            pnlSkills.Size = new Size(153, 17);
            pnlSkills.Text = "Skills Overidden";
            // 
            // pnlShoppingList
            // 
            pnlShoppingList.AutoSize = false;
            pnlShoppingList.Name = "pnlShoppingList";
            pnlShoppingList.Size = new Size(200, 17);
            pnlShoppingList.ToolTipText = "Click to Open Shopping List";
            // 
            // pnlStatus
            // 
            pnlStatus.AutoSize = false;
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(215, 17);
            pnlStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlProgressBar
            // 
            pnlProgressBar.AutoSize = false;
            pnlProgressBar.Name = "pnlProgressBar";
            pnlProgressBar.Size = new Size(300, 16);
            pnlProgressBar.Step = 1;
            pnlProgressBar.Visible = false;
            // 
            // txtListEdit
            // 
            txtListEdit.Location = new Point(1032, 4);
            txtListEdit.Name = "txtListEdit";
            txtListEdit.Size = new Size(48, 20);
            txtListEdit.TabIndex = 59;
            txtListEdit.TabStop = false;
            txtListEdit.Visible = false;
            // 
            // ttBP
            // 
            _ttBP.IsBalloon = true;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "OpenFileDialog1";
            // 
            // gbSystems
            // 
            gbSystems.Location = new Point(0, 0);
            gbSystems.Name = "gbSystems";
            gbSystems.Size = new Size(200, 100);
            gbSystems.TabIndex = 0;
            gbSystems.TabStop = false;
            // 
            // ListOptionsMenu
            // 
            ListOptionsMenu.Items.AddRange(new ToolStripItem[] { ViewMarketHistoryToolStripMenuItem, AddToShoppingListToolStripMenuItem, IgnoreBlueprintToolStripMenuItem, FavoriteBlueprintToolStripMenuItem });
            ListOptionsMenu.Name = "ListOptionsMenu";
            ListOptionsMenu.Size = new Size(219, 100);
            // 
            // ViewMarketHistoryToolStripMenuItem
            // 
            ViewMarketHistoryToolStripMenuItem.Name = "ViewMarketHistoryToolStripMenuItem";
            ViewMarketHistoryToolStripMenuItem.Size = new Size(218, 24);
            ViewMarketHistoryToolStripMenuItem.Text = "View Market History";
            // 
            // AddToShoppingListToolStripMenuItem
            // 
            AddToShoppingListToolStripMenuItem.Name = "AddToShoppingListToolStripMenuItem";
            AddToShoppingListToolStripMenuItem.Size = new Size(218, 24);
            AddToShoppingListToolStripMenuItem.Text = "Add to Shopping List";
            // 
            // IgnoreBlueprintToolStripMenuItem
            // 
            IgnoreBlueprintToolStripMenuItem.Name = "IgnoreBlueprintToolStripMenuItem";
            IgnoreBlueprintToolStripMenuItem.Size = new Size(218, 24);
            IgnoreBlueprintToolStripMenuItem.Text = "Ignore Blueprint";
            // 
            // FavoriteBlueprintToolStripMenuItem
            // 
            FavoriteBlueprintToolStripMenuItem.Name = "FavoriteBlueprintToolStripMenuItem";
            FavoriteBlueprintToolStripMenuItem.Size = new Size(218, 24);
            FavoriteBlueprintToolStripMenuItem.Text = "Favorite Blueprint";
            // 
            // rbtnPriceSourceFW
            // 
            rbtnPriceSourceFW.AutoSize = true;
            rbtnPriceSourceFW.Location = new Point(99, 19);
            rbtnPriceSourceFW.Name = "rbtnPriceSourceFW";
            rbtnPriceSourceFW.Size = new Size(75, 17);
            rbtnPriceSourceFW.TabIndex = 49;
            rbtnPriceSourceFW.Text = "Fuzzworks";
            ttUpdatePrices.SetToolTip(rbtnPriceSourceFW, "Fuzzworks");
            rbtnPriceSourceFW.UseVisualStyleBackColor = true;
            // 
            // chkMineEDENCOM
            // 
            chkMineEDENCOM.AutoSize = true;
            chkMineEDENCOM.Location = new Point(119, 75);
            chkMineEDENCOM.Name = "chkMineEDENCOM";
            chkMineEDENCOM.Size = new Size(117, 17);
            chkMineEDENCOM.TabIndex = 7;
            chkMineEDENCOM.Text = "EDENCOM System";
            ttMining.SetToolTip(chkMineEDENCOM, "Mining in an EDENCOM system provides 10% mining bonus.");
            chkMineEDENCOM.UseVisualStyleBackColor = true;
            // 
            // CalcImageList
            // 
            CalcImageList.ImageStream = (ImageListStreamer)resources.GetObject("CalcImageList.ImageStream");
            CalcImageList.TransparentColor = Color.White;
            CalcImageList.Images.SetKeyName(0, "GreenUP.bmp");
            CalcImageList.Images.SetKeyName(1, "RedDown.bmp");
            CalcImageList.Images.SetKeyName(2, "T2.bmp");
            CalcImageList.Images.SetKeyName(3, "T3.bmp");
            CalcImageList.Images.SetKeyName(4, "Storyline.bmp");
            CalcImageList.Images.SetKeyName(5, "Faction.bmp");
            CalcImageList.Images.SetKeyName(6, "Blank.bmp");
            CalcImageList.Images.SetKeyName(7, "Green Up Arrow.bmp");
            CalcImageList.Images.SetKeyName(8, "Red Down Arrow.bmp");
            // 
            // cmbEdit
            // 
            cmbEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdit.FormattingEnabled = true;
            cmbEdit.ItemHeight = 13;
            cmbEdit.Items.AddRange(new object[] { "Yes", "No" });
            cmbEdit.Location = new Point(950, 4);
            cmbEdit.Name = "cmbEdit";
            cmbEdit.Size = new Size(48, 21);
            cmbEdit.TabIndex = 62;
            cmbEdit.TabStop = false;
            cmbEdit.Visible = false;
            // 
            // tabPI
            // 
            tabPI.Controls.Add(btnPISaveSettings);
            tabPI.Controls.Add(gbPIPlanets);
            tabPI.Controls.Add(btnPIReset);
            tabPI.Location = new Point(4, 22);
            tabPI.Name = "tabPI";
            tabPI.Padding = new Padding(3);
            tabPI.Size = new Size(1137, 615);
            tabPI.TabIndex = 6;
            tabPI.Text = "Planetary Interaction";
            tabPI.UseVisualStyleBackColor = true;
            // 
            // btnPISaveSettings
            // 
            btnPISaveSettings.Location = new Point(315, 47);
            btnPISaveSettings.Name = "btnPISaveSettings";
            btnPISaveSettings.Size = new Size(92, 23);
            btnPISaveSettings.TabIndex = 74;
            btnPISaveSettings.Text = "Save Settings";
            btnPISaveSettings.UseVisualStyleBackColor = true;
            // 
            // gbPIPlanets
            // 
            gbPIPlanets.Controls.Add(chkPILava);
            gbPIPlanets.Controls.Add(chkPIPlasma);
            gbPIPlanets.Controls.Add(chkPIIce);
            gbPIPlanets.Controls.Add(chkPIGas);
            gbPIPlanets.Controls.Add(chkPIOcean);
            gbPIPlanets.Controls.Add(chkPIBarren);
            gbPIPlanets.Controls.Add(chkPIStorm);
            gbPIPlanets.Controls.Add(chkPITemperate);
            gbPIPlanets.Location = new Point(9, 9);
            gbPIPlanets.Name = "gbPIPlanets";
            gbPIPlanets.Size = new Size(299, 67);
            gbPIPlanets.TabIndex = 41;
            gbPIPlanets.TabStop = false;
            gbPIPlanets.Text = "Planets";
            // 
            // chkPILava
            // 
            chkPILava.AutoSize = true;
            chkPILava.Location = new Point(216, 19);
            chkPILava.Name = "chkPILava";
            chkPILava.Size = new Size(50, 17);
            chkPILava.TabIndex = 25;
            chkPILava.Text = "Lava";
            chkPILava.UseVisualStyleBackColor = true;
            // 
            // chkPIPlasma
            // 
            chkPIPlasma.AutoSize = true;
            chkPIPlasma.Location = new Point(83, 42);
            chkPIPlasma.Name = "chkPIPlasma";
            chkPIPlasma.Size = new Size(60, 17);
            chkPIPlasma.TabIndex = 27;
            chkPIPlasma.Text = "Plasma";
            chkPIPlasma.UseVisualStyleBackColor = true;
            // 
            // chkPIIce
            // 
            chkPIIce.AutoSize = true;
            chkPIIce.Location = new Point(153, 19);
            chkPIIce.Name = "chkPIIce";
            chkPIIce.Size = new Size(41, 17);
            chkPIIce.TabIndex = 23;
            chkPIIce.Text = "Ice";
            chkPIIce.UseVisualStyleBackColor = true;
            // 
            // chkPIGas
            // 
            chkPIGas.AutoSize = true;
            chkPIGas.Location = new Point(83, 19);
            chkPIGas.Name = "chkPIGas";
            chkPIGas.Size = new Size(45, 17);
            chkPIGas.TabIndex = 24;
            chkPIGas.Text = "Gas";
            chkPIGas.UseVisualStyleBackColor = true;
            // 
            // chkPIOcean
            // 
            chkPIOcean.AutoSize = true;
            chkPIOcean.Location = new Point(15, 42);
            chkPIOcean.Name = "chkPIOcean";
            chkPIOcean.Size = new Size(58, 17);
            chkPIOcean.TabIndex = 26;
            chkPIOcean.Text = "Ocean";
            chkPIOcean.UseVisualStyleBackColor = true;
            // 
            // chkPIBarren
            // 
            chkPIBarren.AutoSize = true;
            chkPIBarren.Location = new Point(15, 19);
            chkPIBarren.Name = "chkPIBarren";
            chkPIBarren.Size = new Size(57, 17);
            chkPIBarren.TabIndex = 22;
            chkPIBarren.Text = "Barren";
            chkPIBarren.UseVisualStyleBackColor = true;
            // 
            // chkPIStorm
            // 
            chkPIStorm.AutoSize = true;
            chkPIStorm.Location = new Point(153, 42);
            chkPIStorm.Name = "chkPIStorm";
            chkPIStorm.Size = new Size(53, 17);
            chkPIStorm.TabIndex = 28;
            chkPIStorm.Text = "Storm";
            chkPIStorm.UseVisualStyleBackColor = true;
            // 
            // chkPITemperate
            // 
            chkPITemperate.AutoSize = true;
            chkPITemperate.Location = new Point(216, 42);
            chkPITemperate.Name = "chkPITemperate";
            chkPITemperate.Size = new Size(77, 17);
            chkPITemperate.TabIndex = 29;
            chkPITemperate.Text = "Temperate";
            chkPITemperate.UseVisualStyleBackColor = true;
            // 
            // btnPIReset
            // 
            btnPIReset.Location = new Point(315, 14);
            btnPIReset.Name = "btnPIReset";
            btnPIReset.Size = new Size(92, 25);
            btnPIReset.TabIndex = 73;
            btnPIReset.Text = "Reset";
            btnPIReset.UseVisualStyleBackColor = true;
            // 
            // tabMining
            // 
            tabMining.Controls.Add(gbMineCrystalType);
            tabMining.Controls.Add(tabMiningDrones);
            tabMining.Controls.Add(gbMineCrystals);
            tabMining.Controls.Add(gbMineNumberMiners);
            tabMining.Controls.Add(gbMineOreProcessingType);
            tabMining.Controls.Add(btnMineSaveAllSettings);
            tabMining.Controls.Add(gbMineTaxBroker);
            tabMining.Controls.Add(gbMineStripStats);
            tabMining.Controls.Add(chkMineUseFleetBooster);
            tabMining.Controls.Add(btnMineReset);
            tabMining.Controls.Add(gbMineHauling);
            tabMining.Controls.Add(btnMineRefresh);
            tabMining.Controls.Add(gbMineBooster);
            tabMining.Controls.Add(gbMineRefining);
            tabMining.Controls.Add(gbMineShipSetup);
            tabMining.Controls.Add(gbMineMain);
            tabMining.Controls.Add(lstMineGrid);
            tabMining.Location = new Point(4, 22);
            tabMining.Name = "tabMining";
            tabMining.Size = new Size(1137, 615);
            tabMining.TabIndex = 5;
            tabMining.Text = "Mining";
            tabMining.UseVisualStyleBackColor = true;
            // 
            // gbMineCrystalType
            // 
            gbMineCrystalType.Controls.Add(chkMineTypeC);
            gbMineCrystalType.Controls.Add(chkMineTypeB);
            gbMineCrystalType.Controls.Add(chkMineTypeA);
            gbMineCrystalType.Location = new Point(1040, 514);
            gbMineCrystalType.Name = "gbMineCrystalType";
            gbMineCrystalType.Size = new Size(83, 85);
            gbMineCrystalType.TabIndex = 8;
            gbMineCrystalType.TabStop = false;
            gbMineCrystalType.Text = "Crystal Type:";
            // 
            // chkMineTypeC
            // 
            chkMineTypeC.AutoSize = true;
            chkMineTypeC.Checked = true;
            chkMineTypeC.CheckState = CheckState.Checked;
            chkMineTypeC.Location = new Point(7, 59);
            chkMineTypeC.Name = "chkMineTypeC";
            chkMineTypeC.Size = new Size(60, 17);
            chkMineTypeC.TabIndex = 2;
            chkMineTypeC.Text = "Type C";
            chkMineTypeC.UseVisualStyleBackColor = true;
            // 
            // chkMineTypeB
            // 
            chkMineTypeB.AutoSize = true;
            chkMineTypeB.Checked = true;
            chkMineTypeB.CheckState = CheckState.Checked;
            chkMineTypeB.Location = new Point(7, 39);
            chkMineTypeB.Name = "chkMineTypeB";
            chkMineTypeB.Size = new Size(60, 17);
            chkMineTypeB.TabIndex = 0;
            chkMineTypeB.Text = "Type B";
            chkMineTypeB.UseVisualStyleBackColor = true;
            // 
            // chkMineTypeA
            // 
            chkMineTypeA.AutoSize = true;
            chkMineTypeA.Checked = true;
            chkMineTypeA.CheckState = CheckState.Checked;
            chkMineTypeA.Location = new Point(7, 19);
            chkMineTypeA.Name = "chkMineTypeA";
            chkMineTypeA.Size = new Size(60, 17);
            chkMineTypeA.TabIndex = 1;
            chkMineTypeA.Text = "Type A";
            chkMineTypeA.UseVisualStyleBackColor = true;
            // 
            // tabMiningDrones
            // 
            tabMiningDrones.Controls.Add(tabShipDrones);
            tabMiningDrones.Controls.Add(tabBoosterDrones);
            tabMiningDrones.Location = new Point(374, 14);
            tabMiningDrones.Name = "tabMiningDrones";
            tabMiningDrones.SelectedIndex = 0;
            tabMiningDrones.Size = new Size(261, 138);
            tabMiningDrones.TabIndex = 120;
            // 
            // tabShipDrones
            // 
            tabShipDrones.Controls.Add(lblMineDroneIdealRange);
            tabShipDrones.Controls.Add(cmbMineDroneName);
            tabShipDrones.Controls.Add(lblMineMiningDroneYield);
            tabShipDrones.Controls.Add(cmbMineDroneOpSkill);
            tabShipDrones.Controls.Add(lblMineMiningDroneM3);
            tabShipDrones.Controls.Add(lblMineDroneOpSkill);
            tabShipDrones.Controls.Add(lblMineNumMiningDrones);
            tabShipDrones.Controls.Add(cmbMineDroneSpecSkill);
            tabShipDrones.Controls.Add(cmbMineNumMiningDrones);
            tabShipDrones.Controls.Add(lblMineDroneSpecSkill);
            tabShipDrones.Controls.Add(lblMineDroneInterfacingSkill);
            tabShipDrones.Controls.Add(lblMineDroneName);
            tabShipDrones.Controls.Add(cmbMineDroneInterfacingSkill);
            tabShipDrones.Location = new Point(4, 22);
            tabShipDrones.Name = "tabShipDrones";
            tabShipDrones.Padding = new Padding(3);
            tabShipDrones.Size = new Size(253, 112);
            tabShipDrones.TabIndex = 0;
            tabShipDrones.Text = "Ship Mining Drones";
            tabShipDrones.UseVisualStyleBackColor = true;
            // 
            // lblMineDroneIdealRange
            // 
            lblMineDroneIdealRange.Location = new Point(112, 87);
            lblMineDroneIdealRange.Name = "lblMineDroneIdealRange";
            lblMineDroneIdealRange.Size = new Size(134, 16);
            lblMineDroneIdealRange.TabIndex = 137;
            lblMineDroneIdealRange.Text = "Ideal Range:";
            lblMineDroneIdealRange.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbMineDroneName
            // 
            cmbMineDroneName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineDroneName.FormattingEnabled = true;
            cmbMineDroneName.Location = new Point(74, 6);
            cmbMineDroneName.Name = "cmbMineDroneName";
            cmbMineDroneName.Size = new Size(172, 21);
            cmbMineDroneName.TabIndex = 132;
            // 
            // lblMineMiningDroneYield
            // 
            lblMineMiningDroneYield.BorderStyle = BorderStyle.FixedSingle;
            lblMineMiningDroneYield.Location = new Point(167, 56);
            lblMineMiningDroneYield.Name = "lblMineMiningDroneYield";
            lblMineMiningDroneYield.Size = new Size(79, 23);
            lblMineMiningDroneYield.TabIndex = 136;
            lblMineMiningDroneYield.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbMineDroneOpSkill
            // 
            cmbMineDroneOpSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineDroneOpSkill.FormattingEnabled = true;
            cmbMineDroneOpSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineDroneOpSkill.Location = new Point(74, 32);
            cmbMineDroneOpSkill.Name = "cmbMineDroneOpSkill";
            cmbMineDroneOpSkill.Size = new Size(36, 21);
            cmbMineDroneOpSkill.TabIndex = 110;
            // 
            // lblMineMiningDroneM3
            // 
            lblMineMiningDroneM3.Location = new Point(112, 53);
            lblMineMiningDroneM3.Name = "lblMineMiningDroneM3";
            lblMineMiningDroneM3.Size = new Size(53, 30);
            lblMineMiningDroneM3.TabIndex = 9;
            lblMineMiningDroneM3.Text = "Yield (m3/Hr):";
            lblMineMiningDroneM3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineDroneOpSkill
            // 
            lblMineDroneOpSkill.AutoSize = true;
            lblMineDroneOpSkill.Location = new Point(27, 36);
            lblMineDroneOpSkill.Name = "lblMineDroneOpSkill";
            lblMineDroneOpSkill.Size = new Size(46, 13);
            lblMineDroneOpSkill.TabIndex = 111;
            lblMineDroneOpSkill.Text = "Op Skill:";
            lblMineDroneOpSkill.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineNumMiningDrones
            // 
            lblMineNumMiningDrones.AutoSize = true;
            lblMineNumMiningDrones.Location = new Point(113, 36);
            lblMineNumMiningDrones.Name = "lblMineNumMiningDrones";
            lblMineNumMiningDrones.Size = new Size(96, 13);
            lblMineNumMiningDrones.TabIndex = 135;
            lblMineNumMiningDrones.Text = "Number of Drones:";
            // 
            // cmbMineDroneSpecSkill
            // 
            cmbMineDroneSpecSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineDroneSpecSkill.FormattingEnabled = true;
            cmbMineDroneSpecSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineDroneSpecSkill.Location = new Point(74, 58);
            cmbMineDroneSpecSkill.Name = "cmbMineDroneSpecSkill";
            cmbMineDroneSpecSkill.Size = new Size(36, 21);
            cmbMineDroneSpecSkill.TabIndex = 112;
            // 
            // cmbMineNumMiningDrones
            // 
            cmbMineNumMiningDrones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineNumMiningDrones.FormattingEnabled = true;
            cmbMineNumMiningDrones.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineNumMiningDrones.Location = new Point(210, 32);
            cmbMineNumMiningDrones.Name = "cmbMineNumMiningDrones";
            cmbMineNumMiningDrones.Size = new Size(36, 21);
            cmbMineNumMiningDrones.TabIndex = 134;
            // 
            // lblMineDroneSpecSkill
            // 
            lblMineDroneSpecSkill.AutoSize = true;
            lblMineDroneSpecSkill.Location = new Point(16, 60);
            lblMineDroneSpecSkill.Name = "lblMineDroneSpecSkill";
            lblMineDroneSpecSkill.Size = new Size(57, 13);
            lblMineDroneSpecSkill.TabIndex = 113;
            lblMineDroneSpecSkill.Text = "Spec Skill:";
            lblMineDroneSpecSkill.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineDroneInterfacingSkill
            // 
            lblMineDroneInterfacingSkill.Location = new Point(12, 78);
            lblMineDroneInterfacingSkill.Name = "lblMineDroneInterfacingSkill";
            lblMineDroneInterfacingSkill.Size = new Size(61, 29);
            lblMineDroneInterfacingSkill.TabIndex = 115;
            lblMineDroneInterfacingSkill.Text = "Drone Interfacing:";
            lblMineDroneInterfacingSkill.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineDroneName
            // 
            lblMineDroneName.AutoSize = true;
            lblMineDroneName.Location = new Point(3, 9);
            lblMineDroneName.Name = "lblMineDroneName";
            lblMineDroneName.Size = new Size(70, 13);
            lblMineDroneName.TabIndex = 133;
            lblMineDroneName.Text = "Drone Name:";
            lblMineDroneName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbMineDroneInterfacingSkill
            // 
            cmbMineDroneInterfacingSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineDroneInterfacingSkill.FormattingEnabled = true;
            cmbMineDroneInterfacingSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineDroneInterfacingSkill.Location = new Point(74, 84);
            cmbMineDroneInterfacingSkill.Name = "cmbMineDroneInterfacingSkill";
            cmbMineDroneInterfacingSkill.Size = new Size(36, 21);
            cmbMineDroneInterfacingSkill.TabIndex = 114;
            // 
            // tabBoosterDrones
            // 
            tabBoosterDrones.Controls.Add(lblMineBoosterDroneIdealRange);
            tabBoosterDrones.Controls.Add(cmbMineBoosterDroneName);
            tabBoosterDrones.Controls.Add(lblMineBoosterMiningDroneYield);
            tabBoosterDrones.Controls.Add(cmbMineBoosterDroneOpSkill);
            tabBoosterDrones.Controls.Add(lblMineBoosterMiningDroneM3);
            tabBoosterDrones.Controls.Add(lblMineBoosterDroneOpSkill);
            tabBoosterDrones.Controls.Add(lblMineBoosterNumMiningDrones);
            tabBoosterDrones.Controls.Add(cmbMineBoosterDroneSpecSkill);
            tabBoosterDrones.Controls.Add(cmbMineBoosterNumMiningDrones);
            tabBoosterDrones.Controls.Add(lblMineBoosterDroneSpecSkill);
            tabBoosterDrones.Controls.Add(lblMineBoosterDroneInterfacingSkill);
            tabBoosterDrones.Controls.Add(lblMineBoosterDroneName);
            tabBoosterDrones.Controls.Add(cmbMineBoosterDroneInterfacingSkill);
            tabBoosterDrones.Location = new Point(4, 22);
            tabBoosterDrones.Name = "tabBoosterDrones";
            tabBoosterDrones.Padding = new Padding(3);
            tabBoosterDrones.Size = new Size(253, 112);
            tabBoosterDrones.TabIndex = 1;
            tabBoosterDrones.Text = "Booster Mining Drones";
            tabBoosterDrones.UseVisualStyleBackColor = true;
            // 
            // lblMineBoosterDroneIdealRange
            // 
            lblMineBoosterDroneIdealRange.Location = new Point(112, 87);
            lblMineBoosterDroneIdealRange.Name = "lblMineBoosterDroneIdealRange";
            lblMineBoosterDroneIdealRange.Size = new Size(134, 16);
            lblMineBoosterDroneIdealRange.TabIndex = 150;
            lblMineBoosterDroneIdealRange.Text = "Ideal Range:";
            lblMineBoosterDroneIdealRange.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbMineBoosterDroneName
            // 
            cmbMineBoosterDroneName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineBoosterDroneName.FormattingEnabled = true;
            cmbMineBoosterDroneName.Location = new Point(74, 6);
            cmbMineBoosterDroneName.Name = "cmbMineBoosterDroneName";
            cmbMineBoosterDroneName.Size = new Size(172, 21);
            cmbMineBoosterDroneName.TabIndex = 145;
            // 
            // lblMineBoosterMiningDroneYield
            // 
            lblMineBoosterMiningDroneYield.BorderStyle = BorderStyle.FixedSingle;
            lblMineBoosterMiningDroneYield.Location = new Point(167, 56);
            lblMineBoosterMiningDroneYield.Name = "lblMineBoosterMiningDroneYield";
            lblMineBoosterMiningDroneYield.Size = new Size(79, 23);
            lblMineBoosterMiningDroneYield.TabIndex = 149;
            lblMineBoosterMiningDroneYield.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbMineBoosterDroneOpSkill
            // 
            cmbMineBoosterDroneOpSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineBoosterDroneOpSkill.FormattingEnabled = true;
            cmbMineBoosterDroneOpSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineBoosterDroneOpSkill.Location = new Point(74, 32);
            cmbMineBoosterDroneOpSkill.Name = "cmbMineBoosterDroneOpSkill";
            cmbMineBoosterDroneOpSkill.Size = new Size(36, 21);
            cmbMineBoosterDroneOpSkill.TabIndex = 139;
            // 
            // lblMineBoosterMiningDroneM3
            // 
            lblMineBoosterMiningDroneM3.Location = new Point(112, 53);
            lblMineBoosterMiningDroneM3.Name = "lblMineBoosterMiningDroneM3";
            lblMineBoosterMiningDroneM3.Size = new Size(53, 30);
            lblMineBoosterMiningDroneM3.TabIndex = 138;
            lblMineBoosterMiningDroneM3.Text = "Yield (m3/Hr):";
            lblMineBoosterMiningDroneM3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineBoosterDroneOpSkill
            // 
            lblMineBoosterDroneOpSkill.AutoSize = true;
            lblMineBoosterDroneOpSkill.Location = new Point(27, 36);
            lblMineBoosterDroneOpSkill.Name = "lblMineBoosterDroneOpSkill";
            lblMineBoosterDroneOpSkill.Size = new Size(46, 13);
            lblMineBoosterDroneOpSkill.TabIndex = 140;
            lblMineBoosterDroneOpSkill.Text = "Op Skill:";
            lblMineBoosterDroneOpSkill.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineBoosterNumMiningDrones
            // 
            lblMineBoosterNumMiningDrones.AutoSize = true;
            lblMineBoosterNumMiningDrones.Location = new Point(113, 36);
            lblMineBoosterNumMiningDrones.Name = "lblMineBoosterNumMiningDrones";
            lblMineBoosterNumMiningDrones.Size = new Size(96, 13);
            lblMineBoosterNumMiningDrones.TabIndex = 148;
            lblMineBoosterNumMiningDrones.Text = "Number of Drones:";
            // 
            // cmbMineBoosterDroneSpecSkill
            // 
            cmbMineBoosterDroneSpecSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineBoosterDroneSpecSkill.FormattingEnabled = true;
            cmbMineBoosterDroneSpecSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineBoosterDroneSpecSkill.Location = new Point(74, 58);
            cmbMineBoosterDroneSpecSkill.Name = "cmbMineBoosterDroneSpecSkill";
            cmbMineBoosterDroneSpecSkill.Size = new Size(36, 21);
            cmbMineBoosterDroneSpecSkill.TabIndex = 141;
            // 
            // cmbMineBoosterNumMiningDrones
            // 
            cmbMineBoosterNumMiningDrones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineBoosterNumMiningDrones.FormattingEnabled = true;
            cmbMineBoosterNumMiningDrones.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineBoosterNumMiningDrones.Location = new Point(210, 32);
            cmbMineBoosterNumMiningDrones.Name = "cmbMineBoosterNumMiningDrones";
            cmbMineBoosterNumMiningDrones.Size = new Size(36, 21);
            cmbMineBoosterNumMiningDrones.TabIndex = 147;
            // 
            // lblMineBoosterDroneSpecSkill
            // 
            lblMineBoosterDroneSpecSkill.AutoSize = true;
            lblMineBoosterDroneSpecSkill.Location = new Point(16, 60);
            lblMineBoosterDroneSpecSkill.Name = "lblMineBoosterDroneSpecSkill";
            lblMineBoosterDroneSpecSkill.Size = new Size(57, 13);
            lblMineBoosterDroneSpecSkill.TabIndex = 142;
            lblMineBoosterDroneSpecSkill.Text = "Spec Skill:";
            lblMineBoosterDroneSpecSkill.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineBoosterDroneInterfacingSkill
            // 
            lblMineBoosterDroneInterfacingSkill.Location = new Point(12, 78);
            lblMineBoosterDroneInterfacingSkill.Name = "lblMineBoosterDroneInterfacingSkill";
            lblMineBoosterDroneInterfacingSkill.Size = new Size(61, 29);
            lblMineBoosterDroneInterfacingSkill.TabIndex = 144;
            lblMineBoosterDroneInterfacingSkill.Text = "Drone Interfacing:";
            lblMineBoosterDroneInterfacingSkill.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineBoosterDroneName
            // 
            lblMineBoosterDroneName.AutoSize = true;
            lblMineBoosterDroneName.Location = new Point(3, 9);
            lblMineBoosterDroneName.Name = "lblMineBoosterDroneName";
            lblMineBoosterDroneName.Size = new Size(70, 13);
            lblMineBoosterDroneName.TabIndex = 146;
            lblMineBoosterDroneName.Text = "Drone Name:";
            lblMineBoosterDroneName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbMineBoosterDroneInterfacingSkill
            // 
            cmbMineBoosterDroneInterfacingSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineBoosterDroneInterfacingSkill.FormattingEnabled = true;
            cmbMineBoosterDroneInterfacingSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineBoosterDroneInterfacingSkill.Location = new Point(74, 84);
            cmbMineBoosterDroneInterfacingSkill.Name = "cmbMineBoosterDroneInterfacingSkill";
            cmbMineBoosterDroneInterfacingSkill.Size = new Size(36, 21);
            cmbMineBoosterDroneInterfacingSkill.TabIndex = 143;
            // 
            // gbMineCrystals
            // 
            gbMineCrystals.Controls.Add(chkMineT2Crystals);
            gbMineCrystals.Controls.Add(chkMineT1Crystals);
            gbMineCrystals.Location = new Point(1040, 448);
            gbMineCrystals.Name = "gbMineCrystals";
            gbMineCrystals.Size = new Size(83, 60);
            gbMineCrystals.TabIndex = 4;
            gbMineCrystals.TabStop = false;
            gbMineCrystals.Text = "Crystal Tech:";
            // 
            // chkMineT2Crystals
            // 
            chkMineT2Crystals.AutoSize = true;
            chkMineT2Crystals.Checked = true;
            chkMineT2Crystals.CheckState = CheckState.Checked;
            chkMineT2Crystals.Location = new Point(7, 35);
            chkMineT2Crystals.Name = "chkMineT2Crystals";
            chkMineT2Crystals.Size = new Size(78, 17);
            chkMineT2Crystals.TabIndex = 9;
            chkMineT2Crystals.Text = "T2 Crystals";
            chkMineT2Crystals.UseVisualStyleBackColor = true;
            // 
            // chkMineT1Crystals
            // 
            chkMineT1Crystals.AutoSize = true;
            chkMineT1Crystals.Checked = true;
            chkMineT1Crystals.CheckState = CheckState.Checked;
            chkMineT1Crystals.Location = new Point(7, 18);
            chkMineT1Crystals.Name = "chkMineT1Crystals";
            chkMineT1Crystals.Size = new Size(78, 17);
            chkMineT1Crystals.TabIndex = 10;
            chkMineT1Crystals.Text = "T1 Crystals";
            chkMineT1Crystals.UseVisualStyleBackColor = true;
            // 
            // gbMineNumberMiners
            // 
            gbMineNumberMiners.Controls.Add(txtMineNumberMiners);
            gbMineNumberMiners.Controls.Add(lblMineNumberMiners);
            gbMineNumberMiners.Location = new Point(580, 156);
            gbMineNumberMiners.Name = "gbMineNumberMiners";
            gbMineNumberMiners.Size = new Size(125, 44);
            gbMineNumberMiners.TabIndex = 110;
            gbMineNumberMiners.TabStop = false;
            gbMineNumberMiners.Text = "Multi-box mining:";
            // 
            // txtMineNumberMiners
            // 
            txtMineNumberMiners.Location = new Point(92, 17);
            txtMineNumberMiners.MaxLength = 5;
            txtMineNumberMiners.Name = "txtMineNumberMiners";
            txtMineNumberMiners.Size = new Size(27, 20);
            txtMineNumberMiners.TabIndex = 4;
            txtMineNumberMiners.TextAlign = HorizontalAlignment.Center;
            // 
            // lblMineNumberMiners
            // 
            lblMineNumberMiners.AutoSize = true;
            lblMineNumberMiners.Location = new Point(0, 20);
            lblMineNumberMiners.Name = "lblMineNumberMiners";
            lblMineNumberMiners.Size = new Size(93, 13);
            lblMineNumberMiners.TabIndex = 133;
            lblMineNumberMiners.Text = "Number of Miners:";
            // 
            // gbMineOreProcessingType
            // 
            gbMineOreProcessingType.Controls.Add(chkMineUnrefinedOre);
            gbMineOreProcessingType.Controls.Add(chkMineRefinedOre);
            gbMineOreProcessingType.Controls.Add(chkMineCompressedOre);
            gbMineOreProcessingType.Location = new Point(580, 200);
            gbMineOreProcessingType.Name = "gbMineOreProcessingType";
            gbMineOreProcessingType.Size = new Size(125, 73);
            gbMineOreProcessingType.TabIndex = 118;
            gbMineOreProcessingType.TabStop = false;
            gbMineOreProcessingType.Text = "Processing Types";
            // 
            // chkMineUnrefinedOre
            // 
            chkMineUnrefinedOre.AutoSize = true;
            chkMineUnrefinedOre.BackColor = Color.Transparent;
            chkMineUnrefinedOre.Location = new Point(13, 35);
            chkMineUnrefinedOre.Name = "chkMineUnrefinedOre";
            chkMineUnrefinedOre.Size = new Size(92, 17);
            chkMineUnrefinedOre.TabIndex = 118;
            chkMineUnrefinedOre.Text = "Unrefined Ore";
            chkMineUnrefinedOre.UseVisualStyleBackColor = false;
            // 
            // chkMineRefinedOre
            // 
            chkMineRefinedOre.AutoSize = true;
            chkMineRefinedOre.BackColor = Color.Transparent;
            chkMineRefinedOre.Location = new Point(13, 18);
            chkMineRefinedOre.Name = "chkMineRefinedOre";
            chkMineRefinedOre.Size = new Size(83, 17);
            chkMineRefinedOre.TabIndex = 19;
            chkMineRefinedOre.Text = "Refined Ore";
            chkMineRefinedOre.UseVisualStyleBackColor = false;
            // 
            // chkMineCompressedOre
            // 
            chkMineCompressedOre.AutoSize = true;
            chkMineCompressedOre.BackColor = Color.Transparent;
            chkMineCompressedOre.Location = new Point(13, 52);
            chkMineCompressedOre.Name = "chkMineCompressedOre";
            chkMineCompressedOre.Size = new Size(104, 17);
            chkMineCompressedOre.TabIndex = 117;
            chkMineCompressedOre.Text = "Compressed Ore";
            chkMineCompressedOre.UseVisualStyleBackColor = false;
            // 
            // btnMineSaveAllSettings
            // 
            btnMineSaveAllSettings.Location = new Point(637, 114);
            btnMineSaveAllSettings.Name = "btnMineSaveAllSettings";
            btnMineSaveAllSettings.Size = new Size(68, 34);
            btnMineSaveAllSettings.TabIndex = 3;
            btnMineSaveAllSettings.Text = "Save Settings";
            btnMineSaveAllSettings.UseVisualStyleBackColor = true;
            // 
            // gbMineTaxBroker
            // 
            gbMineTaxBroker.Controls.Add(txtMineBrokerFeeRate);
            gbMineTaxBroker.Controls.Add(chkMineIncludeBrokerFees);
            gbMineTaxBroker.Controls.Add(chkMineIncludeTaxes);
            gbMineTaxBroker.Location = new Point(1057, 241);
            gbMineTaxBroker.Name = "gbMineTaxBroker";
            gbMineTaxBroker.Size = new Size(72, 69);
            gbMineTaxBroker.TabIndex = 7;
            gbMineTaxBroker.TabStop = false;
            gbMineTaxBroker.Text = "Include:";
            // 
            // txtMineBrokerFeeRate
            // 
            txtMineBrokerFeeRate.Location = new Point(6, 45);
            txtMineBrokerFeeRate.Name = "txtMineBrokerFeeRate";
            txtMineBrokerFeeRate.Size = new Size(60, 20);
            txtMineBrokerFeeRate.TabIndex = 8;
            txtMineBrokerFeeRate.TextAlign = HorizontalAlignment.Center;
            txtMineBrokerFeeRate.Visible = false;
            // 
            // chkMineIncludeBrokerFees
            // 
            chkMineIncludeBrokerFees.AutoSize = true;
            chkMineIncludeBrokerFees.Checked = true;
            chkMineIncludeBrokerFees.CheckState = CheckState.Checked;
            chkMineIncludeBrokerFees.Location = new Point(6, 29);
            chkMineIncludeBrokerFees.Name = "chkMineIncludeBrokerFees";
            chkMineIncludeBrokerFees.Size = new Size(49, 17);
            chkMineIncludeBrokerFees.TabIndex = 0;
            chkMineIncludeBrokerFees.Text = "Fees";
            chkMineIncludeBrokerFees.ThreeState = true;
            chkMineIncludeBrokerFees.UseVisualStyleBackColor = true;
            // 
            // chkMineIncludeTaxes
            // 
            chkMineIncludeTaxes.AutoSize = true;
            chkMineIncludeTaxes.Checked = true;
            chkMineIncludeTaxes.CheckState = CheckState.Checked;
            chkMineIncludeTaxes.Location = new Point(6, 14);
            chkMineIncludeTaxes.Name = "chkMineIncludeTaxes";
            chkMineIncludeTaxes.Size = new Size(55, 17);
            chkMineIncludeTaxes.TabIndex = 1;
            chkMineIncludeTaxes.Text = "Taxes";
            chkMineIncludeTaxes.UseVisualStyleBackColor = true;
            // 
            // gbMineStripStats
            // 
            gbMineStripStats.Controls.Add(lblMineRange);
            gbMineStripStats.Controls.Add(lblMineCycleTime1);
            gbMineStripStats.Controls.Add(lblMineRange1);
            gbMineStripStats.Controls.Add(lblMineCycleTime);
            gbMineStripStats.Location = new Point(711, 241);
            gbMineStripStats.Name = "gbMineStripStats";
            gbMineStripStats.Size = new Size(140, 69);
            gbMineStripStats.TabIndex = 5;
            gbMineStripStats.TabStop = false;
            gbMineStripStats.Text = "Miner Stats:";
            // 
            // lblMineRange
            // 
            lblMineRange.BorderStyle = BorderStyle.FixedSingle;
            lblMineRange.Location = new Point(79, 42);
            lblMineRange.Name = "lblMineRange";
            lblMineRange.Size = new Size(53, 18);
            lblMineRange.TabIndex = 135;
            lblMineRange.Text = "99.99 km";
            lblMineRange.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMineCycleTime1
            // 
            lblMineCycleTime1.AutoSize = true;
            lblMineCycleTime1.Location = new Point(9, 21);
            lblMineCycleTime1.Name = "lblMineCycleTime1";
            lblMineCycleTime1.Size = new Size(62, 13);
            lblMineCycleTime1.TabIndex = 132;
            lblMineCycleTime1.Text = "Cycle Time:";
            // 
            // lblMineRange1
            // 
            lblMineRange1.AutoSize = true;
            lblMineRange1.Location = new Point(9, 45);
            lblMineRange1.Name = "lblMineRange1";
            lblMineRange1.Size = new Size(71, 13);
            lblMineRange1.TabIndex = 134;
            lblMineRange1.Text = "Laser Range:";
            // 
            // lblMineCycleTime
            // 
            lblMineCycleTime.BorderStyle = BorderStyle.FixedSingle;
            lblMineCycleTime.Location = new Point(79, 18);
            lblMineCycleTime.Name = "lblMineCycleTime";
            lblMineCycleTime.Size = new Size(53, 18);
            lblMineCycleTime.TabIndex = 133;
            lblMineCycleTime.Text = "999.99 s";
            lblMineCycleTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkMineUseFleetBooster
            // 
            chkMineUseFleetBooster.AutoSize = true;
            chkMineUseFleetBooster.BackColor = Color.Transparent;
            chkMineUseFleetBooster.Location = new Point(14, 155);
            chkMineUseFleetBooster.Name = "chkMineUseFleetBooster";
            chkMineUseFleetBooster.Size = new Size(113, 17);
            chkMineUseFleetBooster.TabIndex = 0;
            chkMineUseFleetBooster.Text = "Use Fleet Booster:";
            chkMineUseFleetBooster.UseVisualStyleBackColor = false;
            // 
            // btnMineReset
            // 
            btnMineReset.Location = new Point(637, 76);
            btnMineReset.Name = "btnMineReset";
            btnMineReset.Size = new Size(68, 34);
            btnMineReset.TabIndex = 2;
            btnMineReset.Text = "Reset";
            btnMineReset.UseVisualStyleBackColor = true;
            // 
            // gbMineHauling
            // 
            gbMineHauling.Controls.Add(txtMineHaulerM3);
            gbMineHauling.Controls.Add(lblMineHaulerM3);
            gbMineHauling.Controls.Add(lblMineRTSec);
            gbMineHauling.Controls.Add(chkMineUseHauler);
            gbMineHauling.Controls.Add(lblMineRTMin);
            gbMineHauling.Controls.Add(txtMineRTMin);
            gbMineHauling.Controls.Add(txtMineRTSec);
            gbMineHauling.Controls.Add(lblMineRoundTripTime);
            gbMineHauling.Location = new Point(856, 241);
            gbMineHauling.Name = "gbMineHauling";
            gbMineHauling.Size = new Size(195, 69);
            gbMineHauling.TabIndex = 6;
            gbMineHauling.TabStop = false;
            gbMineHauling.Text = "Hauling:";
            // 
            // txtMineHaulerM3
            // 
            txtMineHaulerM3.Location = new Point(25, 40);
            txtMineHaulerM3.Name = "txtMineHaulerM3";
            txtMineHaulerM3.Size = new Size(65, 20);
            txtMineHaulerM3.TabIndex = 1;
            txtMineHaulerM3.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMineHaulerM3
            // 
            lblMineHaulerM3.AutoSize = true;
            lblMineHaulerM3.Location = new Point(3, 43);
            lblMineHaulerM3.Name = "lblMineHaulerM3";
            lblMineHaulerM3.Size = new Size(24, 13);
            lblMineHaulerM3.TabIndex = 7;
            lblMineHaulerM3.Text = "m3:";
            // 
            // lblMineRTSec
            // 
            lblMineRTSec.AutoSize = true;
            lblMineRTSec.Location = new Point(151, 27);
            lblMineRTSec.Name = "lblMineRTSec";
            lblMineRTSec.Size = new Size(29, 13);
            lblMineRTSec.TabIndex = 5;
            lblMineRTSec.Text = "Sec:";
            // 
            // chkMineUseHauler
            // 
            chkMineUseHauler.AutoSize = true;
            chkMineUseHauler.Location = new Point(6, 21);
            chkMineUseHauler.Name = "chkMineUseHauler";
            chkMineUseHauler.Size = new Size(79, 17);
            chkMineUseHauler.TabIndex = 0;
            chkMineUseHauler.Text = "Use Hauler";
            chkMineUseHauler.UseVisualStyleBackColor = true;
            // 
            // lblMineRTMin
            // 
            lblMineRTMin.AutoSize = true;
            lblMineRTMin.Location = new Point(103, 27);
            lblMineRTMin.Name = "lblMineRTMin";
            lblMineRTMin.Size = new Size(27, 13);
            lblMineRTMin.TabIndex = 4;
            lblMineRTMin.Text = "Min:";
            // 
            // txtMineRTMin
            // 
            txtMineRTMin.Location = new Point(95, 40);
            txtMineRTMin.Name = "txtMineRTMin";
            txtMineRTMin.Size = new Size(43, 20);
            txtMineRTMin.TabIndex = 2;
            txtMineRTMin.TextAlign = HorizontalAlignment.Center;
            // 
            // txtMineRTSec
            // 
            txtMineRTSec.Location = new Point(143, 40);
            txtMineRTSec.Name = "txtMineRTSec";
            txtMineRTSec.Size = new Size(43, 20);
            txtMineRTSec.TabIndex = 3;
            txtMineRTSec.TextAlign = HorizontalAlignment.Center;
            // 
            // lblMineRoundTripTime
            // 
            lblMineRoundTripTime.AutoSize = true;
            lblMineRoundTripTime.Location = new Point(80, 11);
            lblMineRoundTripTime.Name = "lblMineRoundTripTime";
            lblMineRoundTripTime.Size = new Size(111, 13);
            lblMineRoundTripTime.TabIndex = 1;
            lblMineRoundTripTime.Text = "Round Trip to Station:";
            lblMineRoundTripTime.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnMineRefresh
            // 
            btnMineRefresh.Location = new Point(637, 38);
            btnMineRefresh.Name = "btnMineRefresh";
            btnMineRefresh.Size = new Size(68, 34);
            btnMineRefresh.TabIndex = 1;
            btnMineRefresh.Text = "Calculate";
            btnMineRefresh.UseVisualStyleBackColor = true;
            // 
            // gbMineBooster
            // 
            gbMineBooster.Controls.Add(chkMineBoosterDroneRig3);
            gbMineBooster.Controls.Add(pictMineLaserOptmize);
            gbMineBooster.Controls.Add(pictMineRangeLink);
            gbMineBooster.Controls.Add(chkMineBoosterDroneRig2);
            gbMineBooster.Controls.Add(chkMineBoosterDroneRig1);
            gbMineBooster.Controls.Add(chkMineBoosterUseDrones);
            gbMineBooster.Controls.Add(pictMineFleetBoostShip);
            gbMineBooster.Controls.Add(chkMineForemanLaserRangeBoost);
            gbMineBooster.Controls.Add(chkMineIndyCoreDeployedMode);
            gbMineBooster.Controls.Add(cmbMineBoosterShipSkill);
            gbMineBooster.Controls.Add(chkMineForemanMindlink);
            gbMineBooster.Controls.Add(cmbMineBoosterShipName);
            gbMineBooster.Controls.Add(cmbMineMiningDirector);
            gbMineBooster.Controls.Add(chkMineForemanLaserOpBoost);
            gbMineBooster.Controls.Add(lblMineMiningDirector);
            gbMineBooster.Controls.Add(cmbMineMiningForeman);
            gbMineBooster.Controls.Add(lblMineFleetBoosterShip);
            gbMineBooster.Controls.Add(lblMineMiningForeman);
            gbMineBooster.Controls.Add(lblMineBoosterShipSkill);
            gbMineBooster.Controls.Add(cmbMineIndustReconfig);
            gbMineBooster.Controls.Add(lblMineIndustrialReconfig);
            gbMineBooster.Location = new Point(6, 156);
            gbMineBooster.Name = "gbMineBooster";
            gbMineBooster.Size = new Size(568, 117);
            gbMineBooster.TabIndex = 3;
            gbMineBooster.TabStop = false;
            // 
            // chkMineBoosterDroneRig3
            // 
            chkMineBoosterDroneRig3.AutoSize = true;
            chkMineBoosterDroneRig3.Location = new Point(326, 95);
            chkMineBoosterDroneRig3.Name = "chkMineBoosterDroneRig3";
            chkMineBoosterDroneRig3.Size = new Size(90, 17);
            chkMineBoosterDroneRig3.TabIndex = 146;
            chkMineBoosterDroneRig3.Text = "T1 Drone Rig";
            chkMineBoosterDroneRig3.ThreeState = true;
            chkMineBoosterDroneRig3.UseVisualStyleBackColor = true;
            // 
            // pictMineLaserOptmize
            // 
            pictMineLaserOptmize.Location = new Point(528, 64);
            pictMineLaserOptmize.Name = "pictMineLaserOptmize";
            pictMineLaserOptmize.Size = new Size(32, 32);
            pictMineLaserOptmize.TabIndex = 139;
            pictMineLaserOptmize.TabStop = false;
            // 
            // pictMineRangeLink
            // 
            pictMineRangeLink.Location = new Point(528, 24);
            pictMineRangeLink.Name = "pictMineRangeLink";
            pictMineRangeLink.Size = new Size(32, 32);
            pictMineRangeLink.TabIndex = 138;
            pictMineRangeLink.TabStop = false;
            // 
            // chkMineBoosterDroneRig2
            // 
            chkMineBoosterDroneRig2.AutoSize = true;
            chkMineBoosterDroneRig2.Location = new Point(236, 95);
            chkMineBoosterDroneRig2.Name = "chkMineBoosterDroneRig2";
            chkMineBoosterDroneRig2.Size = new Size(90, 17);
            chkMineBoosterDroneRig2.TabIndex = 145;
            chkMineBoosterDroneRig2.Text = "T1 Drone Rig";
            chkMineBoosterDroneRig2.ThreeState = true;
            chkMineBoosterDroneRig2.UseVisualStyleBackColor = true;
            // 
            // chkMineBoosterDroneRig1
            // 
            chkMineBoosterDroneRig1.AutoSize = true;
            chkMineBoosterDroneRig1.Location = new Point(146, 95);
            chkMineBoosterDroneRig1.Name = "chkMineBoosterDroneRig1";
            chkMineBoosterDroneRig1.Size = new Size(90, 17);
            chkMineBoosterDroneRig1.TabIndex = 144;
            chkMineBoosterDroneRig1.Text = "T1 Drone Rig";
            chkMineBoosterDroneRig1.ThreeState = true;
            chkMineBoosterDroneRig1.UseVisualStyleBackColor = true;
            // 
            // chkMineBoosterUseDrones
            // 
            chkMineBoosterUseDrones.AutoSize = true;
            chkMineBoosterUseDrones.Location = new Point(18, 96);
            chkMineBoosterUseDrones.Name = "chkMineBoosterUseDrones";
            chkMineBoosterUseDrones.Size = new Size(116, 17);
            chkMineBoosterUseDrones.TabIndex = 141;
            chkMineBoosterUseDrones.Text = "Use Mining Drones";
            chkMineBoosterUseDrones.UseVisualStyleBackColor = true;
            // 
            // pictMineFleetBoostShip
            // 
            pictMineFleetBoostShip.BackColor = Color.White;
            pictMineFleetBoostShip.BorderStyle = BorderStyle.Fixed3D;
            pictMineFleetBoostShip.Location = new Point(170, 17);
            pictMineFleetBoostShip.Name = "pictMineFleetBoostShip";
            pictMineFleetBoostShip.Size = new Size(68, 69);
            pictMineFleetBoostShip.TabIndex = 137;
            pictMineFleetBoostShip.TabStop = false;
            // 
            // chkMineForemanLaserRangeBoost
            // 
            chkMineForemanLaserRangeBoost.Location = new Point(370, 18);
            chkMineForemanLaserRangeBoost.Name = "chkMineForemanLaserRangeBoost";
            chkMineForemanLaserRangeBoost.Size = new Size(152, 45);
            chkMineForemanLaserRangeBoost.TabIndex = 9;
            chkMineForemanLaserRangeBoost.Text = "Mining Foreman Link - Mining Laser Field Enhancement Charge";
            chkMineForemanLaserRangeBoost.ThreeState = true;
            chkMineForemanLaserRangeBoost.UseVisualStyleBackColor = true;
            // 
            // chkMineIndyCoreDeployedMode
            // 
            chkMineIndyCoreDeployedMode.AutoSize = true;
            chkMineIndyCoreDeployedMode.Location = new Point(18, 80);
            chkMineIndyCoreDeployedMode.Name = "chkMineIndyCoreDeployedMode";
            chkMineIndyCoreDeployedMode.Size = new Size(134, 17);
            chkMineIndyCoreDeployedMode.TabIndex = 4;
            chkMineIndyCoreDeployedMode.Text = "Industrial Core Inactive";
            chkMineIndyCoreDeployedMode.ThreeState = true;
            chkMineIndyCoreDeployedMode.UseVisualStyleBackColor = true;
            // 
            // cmbMineBoosterShipSkill
            // 
            cmbMineBoosterShipSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineBoosterShipSkill.FormattingEnabled = true;
            cmbMineBoosterShipSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineBoosterShipSkill.Location = new Point(77, 41);
            cmbMineBoosterShipSkill.Name = "cmbMineBoosterShipSkill";
            cmbMineBoosterShipSkill.Size = new Size(46, 21);
            cmbMineBoosterShipSkill.TabIndex = 2;
            // 
            // chkMineForemanMindlink
            // 
            chkMineForemanMindlink.AutoSize = true;
            chkMineForemanMindlink.Location = new Point(18, 64);
            chkMineForemanMindlink.Name = "chkMineForemanMindlink";
            chkMineForemanMindlink.Size = new Size(143, 17);
            chkMineForemanMindlink.TabIndex = 3;
            chkMineForemanMindlink.Text = "Mining Foreman Mindlink";
            chkMineForemanMindlink.UseVisualStyleBackColor = true;
            // 
            // cmbMineBoosterShipName
            // 
            cmbMineBoosterShipName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineBoosterShipName.FormattingEnabled = true;
            cmbMineBoosterShipName.Items.AddRange(new object[] { "Orca", "Rorqual", "Battlecruiser", "Other" });
            cmbMineBoosterShipName.Location = new Point(77, 17);
            cmbMineBoosterShipName.Name = "cmbMineBoosterShipName";
            cmbMineBoosterShipName.Size = new Size(85, 21);
            cmbMineBoosterShipName.TabIndex = 1;
            // 
            // cmbMineMiningDirector
            // 
            cmbMineMiningDirector.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineMiningDirector.FormattingEnabled = true;
            cmbMineMiningDirector.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineMiningDirector.Location = new Point(326, 41);
            cmbMineMiningDirector.Name = "cmbMineMiningDirector";
            cmbMineMiningDirector.Size = new Size(36, 21);
            cmbMineMiningDirector.TabIndex = 6;
            // 
            // chkMineForemanLaserOpBoost
            // 
            chkMineForemanLaserOpBoost.Location = new Point(370, 60);
            chkMineForemanLaserOpBoost.Name = "chkMineForemanLaserOpBoost";
            chkMineForemanLaserOpBoost.Size = new Size(152, 40);
            chkMineForemanLaserOpBoost.TabIndex = 10;
            chkMineForemanLaserOpBoost.Text = "Mining Foreman Link - Laser Optimization Charge";
            chkMineForemanLaserOpBoost.ThreeState = true;
            chkMineForemanLaserOpBoost.UseVisualStyleBackColor = true;
            // 
            // lblMineMiningDirector
            // 
            lblMineMiningDirector.Location = new Point(239, 44);
            lblMineMiningDirector.Name = "lblMineMiningDirector";
            lblMineMiningDirector.Size = new Size(86, 13);
            lblMineMiningDirector.TabIndex = 115;
            lblMineMiningDirector.Text = "Mining Director:";
            lblMineMiningDirector.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbMineMiningForeman
            // 
            cmbMineMiningForeman.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineMiningForeman.FormattingEnabled = true;
            cmbMineMiningForeman.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineMiningForeman.Location = new Point(326, 18);
            cmbMineMiningForeman.Name = "cmbMineMiningForeman";
            cmbMineMiningForeman.Size = new Size(36, 21);
            cmbMineMiningForeman.TabIndex = 5;
            // 
            // lblMineFleetBoosterShip
            // 
            lblMineFleetBoosterShip.AutoSize = true;
            lblMineFleetBoosterShip.Location = new Point(15, 21);
            lblMineFleetBoosterShip.Name = "lblMineFleetBoosterShip";
            lblMineFleetBoosterShip.Size = new Size(64, 13);
            lblMineFleetBoosterShip.TabIndex = 119;
            lblMineFleetBoosterShip.Text = "Select Ship:";
            // 
            // lblMineMiningForeman
            // 
            lblMineMiningForeman.Location = new Point(239, 21);
            lblMineMiningForeman.Name = "lblMineMiningForeman";
            lblMineMiningForeman.Size = new Size(86, 13);
            lblMineMiningForeman.TabIndex = 113;
            lblMineMiningForeman.Text = "Mining Foreman:";
            lblMineMiningForeman.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMineBoosterShipSkill
            // 
            lblMineBoosterShipSkill.AutoSize = true;
            lblMineBoosterShipSkill.Location = new Point(16, 45);
            lblMineBoosterShipSkill.Name = "lblMineBoosterShipSkill";
            lblMineBoosterShipSkill.Size = new Size(53, 13);
            lblMineBoosterShipSkill.TabIndex = 131;
            lblMineBoosterShipSkill.Text = "Ship Skill:";
            // 
            // cmbMineIndustReconfig
            // 
            cmbMineIndustReconfig.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineIndustReconfig.FormattingEnabled = true;
            cmbMineIndustReconfig.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineIndustReconfig.Location = new Point(326, 64);
            cmbMineIndustReconfig.Name = "cmbMineIndustReconfig";
            cmbMineIndustReconfig.Size = new Size(36, 21);
            cmbMineIndustReconfig.TabIndex = 8;
            // 
            // lblMineIndustrialReconfig
            // 
            lblMineIndustrialReconfig.Location = new Point(232, 55);
            lblMineIndustrialReconfig.Name = "lblMineIndustrialReconfig";
            lblMineIndustrialReconfig.Size = new Size(93, 39);
            lblMineIndustrialReconfig.TabIndex = 135;
            lblMineIndustrialReconfig.Text = "Industrial Reconfiguration:";
            lblMineIndustrialReconfig.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbMineRefining
            // 
            gbMineRefining.Controls.Add(gbMineOreStuctureRates);
            gbMineRefining.Controls.Add(cmbMineRefining);
            gbMineRefining.Controls.Add(lblMineRefining);
            gbMineRefining.Controls.Add(cmbMineRefineryEff);
            gbMineRefining.Controls.Add(lblMineRefineryEfficiency);
            gbMineRefining.Controls.Add(MineRefineFacility);
            gbMineRefining.Controls.Add(tabMiningProcessingSkills);
            gbMineRefining.Location = new Point(711, 310);
            gbMineRefining.Name = "gbMineRefining";
            gbMineRefining.Size = new Size(417, 299);
            gbMineRefining.TabIndex = 8;
            gbMineRefining.TabStop = false;
            gbMineRefining.Text = "Refining Settings:";
            // 
            // gbMineOreStuctureRates
            // 
            gbMineOreStuctureRates.Controls.Add(lblMineFacilityOreRate);
            gbMineOreStuctureRates.Controls.Add(lblMineFacilityMoonOreRate);
            gbMineOreStuctureRates.Controls.Add(lblMineFacilityOreRate1);
            gbMineOreStuctureRates.Controls.Add(lblMineFacilityMoonOreRate1);
            gbMineOreStuctureRates.Location = new Point(312, 62);
            gbMineOreStuctureRates.Name = "gbMineOreStuctureRates";
            gbMineOreStuctureRates.Size = new Size(101, 60);
            gbMineOreStuctureRates.TabIndex = 121;
            gbMineOreStuctureRates.TabStop = false;
            gbMineOreStuctureRates.Text = "Refine Yields:";
            // 
            // lblMineFacilityOreRate
            // 
            lblMineFacilityOreRate.BorderStyle = BorderStyle.FixedSingle;
            lblMineFacilityOreRate.Location = new Point(47, 16);
            lblMineFacilityOreRate.Name = "lblMineFacilityOreRate";
            lblMineFacilityOreRate.Size = new Size(50, 18);
            lblMineFacilityOreRate.TabIndex = 136;
            lblMineFacilityOreRate.Text = "100.00%";
            lblMineFacilityOreRate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMineFacilityMoonOreRate
            // 
            lblMineFacilityMoonOreRate.BorderStyle = BorderStyle.FixedSingle;
            lblMineFacilityMoonOreRate.Location = new Point(47, 37);
            lblMineFacilityMoonOreRate.Name = "lblMineFacilityMoonOreRate";
            lblMineFacilityMoonOreRate.Size = new Size(50, 18);
            lblMineFacilityMoonOreRate.TabIndex = 137;
            lblMineFacilityMoonOreRate.Text = "100.00%";
            lblMineFacilityMoonOreRate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMineFacilityOreRate1
            // 
            lblMineFacilityOreRate1.AutoSize = true;
            lblMineFacilityOreRate1.Location = new Point(19, 19);
            lblMineFacilityOreRate1.Name = "lblMineFacilityOreRate1";
            lblMineFacilityOreRate1.Size = new Size(27, 13);
            lblMineFacilityOreRate1.TabIndex = 123;
            lblMineFacilityOreRate1.Text = "Ore:";
            // 
            // lblMineFacilityMoonOreRate1
            // 
            lblMineFacilityMoonOreRate1.AutoSize = true;
            lblMineFacilityMoonOreRate1.Location = new Point(9, 40);
            lblMineFacilityMoonOreRate1.Name = "lblMineFacilityMoonOreRate1";
            lblMineFacilityMoonOreRate1.Size = new Size(37, 13);
            lblMineFacilityMoonOreRate1.TabIndex = 125;
            lblMineFacilityMoonOreRate1.Text = "Moon:";
            // 
            // cmbMineRefining
            // 
            cmbMineRefining.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineRefining.FormattingEnabled = true;
            cmbMineRefining.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineRefining.Location = new Point(382, 13);
            cmbMineRefining.Name = "cmbMineRefining";
            cmbMineRefining.Size = new Size(30, 21);
            cmbMineRefining.TabIndex = 0;
            // 
            // lblMineRefining
            // 
            lblMineRefining.AutoSize = true;
            lblMineRefining.Location = new Point(309, 16);
            lblMineRefining.Name = "lblMineRefining";
            lblMineRefining.Size = new Size(75, 13);
            lblMineRefining.TabIndex = 108;
            lblMineRefining.Text = "Reprocessing:";
            // 
            // cmbMineRefineryEff
            // 
            cmbMineRefineryEff.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineRefineryEff.FormattingEnabled = true;
            cmbMineRefineryEff.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineRefineryEff.Location = new Point(382, 36);
            cmbMineRefineryEff.Name = "cmbMineRefineryEff";
            cmbMineRefineryEff.Size = new Size(30, 21);
            cmbMineRefineryEff.TabIndex = 1;
            // 
            // lblMineRefineryEfficiency
            // 
            lblMineRefineryEfficiency.Location = new Point(309, 33);
            lblMineRefineryEfficiency.Name = "lblMineRefineryEfficiency";
            lblMineRefineryEfficiency.Size = new Size(77, 27);
            lblMineRefineryEfficiency.TabIndex = 109;
            lblMineRefineryEfficiency.Text = "Reprocessing Efficiency:";
            // 
            // MineRefineFacility
            // 
            MineRefineFacility.BackColor = Color.Transparent;
            MineRefineFacility.Location = new Point(7, 14);
            MineRefineFacility.Name = "MineRefineFacility";
            MineRefineFacility.Size = new Size(303, 108);
            MineRefineFacility.TabIndex = 122;
            // 
            // tabMiningProcessingSkills
            // 
            tabMiningProcessingSkills.Controls.Add(tabPageOres);
            tabMiningProcessingSkills.Controls.Add(tabPageMoonOres);
            tabMiningProcessingSkills.Controls.Add(tabPageIce);
            tabMiningProcessingSkills.Location = new Point(7, 123);
            tabMiningProcessingSkills.Name = "tabMiningProcessingSkills";
            tabMiningProcessingSkills.SelectedIndex = 0;
            tabMiningProcessingSkills.Size = new Size(318, 170);
            tabMiningProcessingSkills.TabIndex = 121;
            // 
            // tabPageOres
            // 
            tabPageOres.Controls.Add(chkOreProcessing1);
            tabPageOres.Controls.Add(cmbOreProcessing2);
            tabPageOres.Controls.Add(lblOreProcessing2);
            tabPageOres.Controls.Add(chkOreProcessing3);
            tabPageOres.Controls.Add(chkOreProcessing2);
            tabPageOres.Controls.Add(chkOreProcessing6);
            tabPageOres.Controls.Add(cmbOreProcessing1);
            tabPageOres.Controls.Add(lblOreProcessing1);
            tabPageOres.Controls.Add(lblOreProcessing6);
            tabPageOres.Controls.Add(chkOreProcessing5);
            tabPageOres.Controls.Add(cmbOreProcessing6);
            tabPageOres.Controls.Add(lblOreProcessing3);
            tabPageOres.Controls.Add(lblOreProcessing5);
            tabPageOres.Controls.Add(cmbOreProcessing4);
            tabPageOres.Controls.Add(cmbOreProcessing3);
            tabPageOres.Controls.Add(chkOreProcessing4);
            tabPageOres.Controls.Add(lblOreProcessing4);
            tabPageOres.Controls.Add(cmbOreProcessing5);
            tabPageOres.Location = new Point(4, 22);
            tabPageOres.Name = "tabPageOres";
            tabPageOres.Padding = new Padding(3);
            tabPageOres.Size = new Size(310, 144);
            tabPageOres.TabIndex = 0;
            tabPageOres.Text = "Ore Processing";
            tabPageOres.UseVisualStyleBackColor = true;
            // 
            // chkOreProcessing1
            // 
            chkOreProcessing1.AutoSize = true;
            chkOreProcessing1.Location = new Point(10, 10);
            chkOreProcessing1.Name = "chkOreProcessing1";
            chkOreProcessing1.Size = new Size(15, 14);
            chkOreProcessing1.TabIndex = 95;
            chkOreProcessing1.UseVisualStyleBackColor = true;
            // 
            // cmbOreProcessing2
            // 
            cmbOreProcessing2.FormattingEnabled = true;
            cmbOreProcessing2.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing2.Location = new Point(168, 29);
            cmbOreProcessing2.Name = "cmbOreProcessing2";
            cmbOreProcessing2.Size = new Size(36, 21);
            cmbOreProcessing2.TabIndex = 102;
            // 
            // lblOreProcessing2
            // 
            lblOreProcessing2.Location = new Point(32, 32);
            lblOreProcessing2.Name = "lblOreProcessing2";
            lblOreProcessing2.Size = new Size(133, 13);
            lblOreProcessing2.TabIndex = 133;
            lblOreProcessing2.Text = "Coherent Ore Processing";
            // 
            // chkOreProcessing3
            // 
            chkOreProcessing3.AutoSize = true;
            chkOreProcessing3.Location = new Point(10, 54);
            chkOreProcessing3.Name = "chkOreProcessing3";
            chkOreProcessing3.Size = new Size(15, 14);
            chkOreProcessing3.TabIndex = 107;
            chkOreProcessing3.UseVisualStyleBackColor = true;
            // 
            // chkOreProcessing2
            // 
            chkOreProcessing2.AutoSize = true;
            chkOreProcessing2.Location = new Point(10, 32);
            chkOreProcessing2.Name = "chkOreProcessing2";
            chkOreProcessing2.Size = new Size(15, 14);
            chkOreProcessing2.TabIndex = 101;
            chkOreProcessing2.UseVisualStyleBackColor = true;
            // 
            // chkOreProcessing6
            // 
            chkOreProcessing6.AutoSize = true;
            chkOreProcessing6.Location = new Point(10, 120);
            chkOreProcessing6.Name = "chkOreProcessing6";
            chkOreProcessing6.Size = new Size(15, 14);
            chkOreProcessing6.TabIndex = 125;
            chkOreProcessing6.UseVisualStyleBackColor = true;
            // 
            // cmbOreProcessing1
            // 
            cmbOreProcessing1.FormattingEnabled = true;
            cmbOreProcessing1.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing1.Location = new Point(168, 7);
            cmbOreProcessing1.Name = "cmbOreProcessing1";
            cmbOreProcessing1.Size = new Size(36, 21);
            cmbOreProcessing1.TabIndex = 96;
            // 
            // lblOreProcessing1
            // 
            lblOreProcessing1.Location = new Point(32, 10);
            lblOreProcessing1.Name = "lblOreProcessing1";
            lblOreProcessing1.Size = new Size(133, 13);
            lblOreProcessing1.TabIndex = 127;
            lblOreProcessing1.Text = "Simple Ore Processing";
            // 
            // lblOreProcessing6
            // 
            lblOreProcessing6.Location = new Point(32, 120);
            lblOreProcessing6.Name = "lblOreProcessing6";
            lblOreProcessing6.Size = new Size(133, 13);
            lblOreProcessing6.TabIndex = 142;
            lblOreProcessing6.Text = "Mercoxit Ore Processing";
            // 
            // chkOreProcessing5
            // 
            chkOreProcessing5.AutoSize = true;
            chkOreProcessing5.Location = new Point(10, 98);
            chkOreProcessing5.Name = "chkOreProcessing5";
            chkOreProcessing5.Size = new Size(15, 14);
            chkOreProcessing5.TabIndex = 121;
            chkOreProcessing5.UseVisualStyleBackColor = true;
            // 
            // cmbOreProcessing6
            // 
            cmbOreProcessing6.FormattingEnabled = true;
            cmbOreProcessing6.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing6.Location = new Point(168, 117);
            cmbOreProcessing6.Name = "cmbOreProcessing6";
            cmbOreProcessing6.Size = new Size(36, 21);
            cmbOreProcessing6.TabIndex = 126;
            // 
            // lblOreProcessing3
            // 
            lblOreProcessing3.Location = new Point(32, 54);
            lblOreProcessing3.Name = "lblOreProcessing3";
            lblOreProcessing3.Size = new Size(133, 13);
            lblOreProcessing3.TabIndex = 130;
            lblOreProcessing3.Text = "Variegated Ore Processing";
            // 
            // lblOreProcessing5
            // 
            lblOreProcessing5.Location = new Point(32, 98);
            lblOreProcessing5.Name = "lblOreProcessing5";
            lblOreProcessing5.Size = new Size(133, 13);
            lblOreProcessing5.TabIndex = 141;
            lblOreProcessing5.Text = "Abyssal Ore Processing";
            // 
            // cmbOreProcessing4
            // 
            cmbOreProcessing4.FormattingEnabled = true;
            cmbOreProcessing4.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing4.Location = new Point(168, 73);
            cmbOreProcessing4.Name = "cmbOreProcessing4";
            cmbOreProcessing4.Size = new Size(36, 21);
            cmbOreProcessing4.TabIndex = 114;
            // 
            // cmbOreProcessing3
            // 
            cmbOreProcessing3.FormattingEnabled = true;
            cmbOreProcessing3.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing3.Location = new Point(168, 51);
            cmbOreProcessing3.Name = "cmbOreProcessing3";
            cmbOreProcessing3.Size = new Size(36, 21);
            cmbOreProcessing3.TabIndex = 108;
            // 
            // chkOreProcessing4
            // 
            chkOreProcessing4.AutoSize = true;
            chkOreProcessing4.Location = new Point(10, 76);
            chkOreProcessing4.Name = "chkOreProcessing4";
            chkOreProcessing4.Size = new Size(15, 14);
            chkOreProcessing4.TabIndex = 113;
            chkOreProcessing4.UseVisualStyleBackColor = true;
            // 
            // lblOreProcessing4
            // 
            lblOreProcessing4.Location = new Point(32, 76);
            lblOreProcessing4.Name = "lblOreProcessing4";
            lblOreProcessing4.Size = new Size(133, 13);
            lblOreProcessing4.TabIndex = 139;
            lblOreProcessing4.Text = "Complex Ore Processing";
            // 
            // cmbOreProcessing5
            // 
            cmbOreProcessing5.FormattingEnabled = true;
            cmbOreProcessing5.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing5.Location = new Point(168, 95);
            cmbOreProcessing5.Name = "cmbOreProcessing5";
            cmbOreProcessing5.Size = new Size(36, 21);
            cmbOreProcessing5.TabIndex = 122;
            // 
            // tabPageMoonOres
            // 
            tabPageMoonOres.Controls.Add(lblOreProcessing7);
            tabPageMoonOres.Controls.Add(lblOreProcessing8);
            tabPageMoonOres.Controls.Add(lblOreProcessing10);
            tabPageMoonOres.Controls.Add(lblOreProcessing11);
            tabPageMoonOres.Controls.Add(cmbOreProcessing11);
            tabPageMoonOres.Controls.Add(chkOreProcessing9);
            tabPageMoonOres.Controls.Add(lblOreProcessing9);
            tabPageMoonOres.Controls.Add(chkOreProcessing8);
            tabPageMoonOres.Controls.Add(cmbOreProcessing10);
            tabPageMoonOres.Controls.Add(cmbOreProcessing7);
            tabPageMoonOres.Controls.Add(chkOreProcessing10);
            tabPageMoonOres.Controls.Add(chkOreProcessing7);
            tabPageMoonOres.Controls.Add(cmbOreProcessing9);
            tabPageMoonOres.Controls.Add(chkOreProcessing11);
            tabPageMoonOres.Controls.Add(cmbOreProcessing8);
            tabPageMoonOres.Location = new Point(4, 22);
            tabPageMoonOres.Name = "tabPageMoonOres";
            tabPageMoonOres.Size = new Size(310, 144);
            tabPageMoonOres.TabIndex = 2;
            tabPageMoonOres.Text = "Moon Ore Processing";
            tabPageMoonOres.UseVisualStyleBackColor = true;
            // 
            // lblOreProcessing7
            // 
            lblOreProcessing7.Location = new Point(31, 10);
            lblOreProcessing7.Name = "lblOreProcessing7";
            lblOreProcessing7.Size = new Size(167, 13);
            lblOreProcessing7.TabIndex = 148;
            lblOreProcessing7.Text = "Ubiquitous Moon Ore Processing";
            // 
            // lblOreProcessing8
            // 
            lblOreProcessing8.Location = new Point(31, 32);
            lblOreProcessing8.Name = "lblOreProcessing8";
            lblOreProcessing8.Size = new Size(167, 13);
            lblOreProcessing8.TabIndex = 149;
            lblOreProcessing8.Text = "Uncommon Moon Ore Processing";
            // 
            // lblOreProcessing10
            // 
            lblOreProcessing10.Location = new Point(31, 76);
            lblOreProcessing10.Name = "lblOreProcessing10";
            lblOreProcessing10.Size = new Size(167, 13);
            lblOreProcessing10.TabIndex = 145;
            lblOreProcessing10.Text = "Common Moon Ore Processing";
            // 
            // lblOreProcessing11
            // 
            lblOreProcessing11.Location = new Point(31, 98);
            lblOreProcessing11.Name = "lblOreProcessing11";
            lblOreProcessing11.Size = new Size(167, 13);
            lblOreProcessing11.TabIndex = 147;
            lblOreProcessing11.Text = "Rare Moon Ore Processing";
            // 
            // cmbOreProcessing11
            // 
            cmbOreProcessing11.FormattingEnabled = true;
            cmbOreProcessing11.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing11.Location = new Point(202, 95);
            cmbOreProcessing11.Name = "cmbOreProcessing11";
            cmbOreProcessing11.Size = new Size(36, 21);
            cmbOreProcessing11.TabIndex = 140;
            // 
            // chkOreProcessing9
            // 
            chkOreProcessing9.AutoSize = true;
            chkOreProcessing9.Location = new Point(10, 54);
            chkOreProcessing9.Name = "chkOreProcessing9";
            chkOreProcessing9.Size = new Size(15, 14);
            chkOreProcessing9.TabIndex = 137;
            chkOreProcessing9.UseVisualStyleBackColor = true;
            // 
            // lblOreProcessing9
            // 
            lblOreProcessing9.Location = new Point(31, 54);
            lblOreProcessing9.Name = "lblOreProcessing9";
            lblOreProcessing9.Size = new Size(167, 13);
            lblOreProcessing9.TabIndex = 146;
            lblOreProcessing9.Text = "Exceptional Moon Ore Processing";
            // 
            // chkOreProcessing8
            // 
            chkOreProcessing8.AutoSize = true;
            chkOreProcessing8.Location = new Point(10, 32);
            chkOreProcessing8.Name = "chkOreProcessing8";
            chkOreProcessing8.Size = new Size(15, 14);
            chkOreProcessing8.TabIndex = 143;
            chkOreProcessing8.UseVisualStyleBackColor = true;
            // 
            // cmbOreProcessing10
            // 
            cmbOreProcessing10.FormattingEnabled = true;
            cmbOreProcessing10.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing10.Location = new Point(202, 73);
            cmbOreProcessing10.Name = "cmbOreProcessing10";
            cmbOreProcessing10.Size = new Size(36, 21);
            cmbOreProcessing10.TabIndex = 136;
            // 
            // cmbOreProcessing7
            // 
            cmbOreProcessing7.FormattingEnabled = true;
            cmbOreProcessing7.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing7.Location = new Point(202, 7);
            cmbOreProcessing7.Name = "cmbOreProcessing7";
            cmbOreProcessing7.Size = new Size(36, 21);
            cmbOreProcessing7.TabIndex = 142;
            // 
            // chkOreProcessing10
            // 
            chkOreProcessing10.AutoSize = true;
            chkOreProcessing10.Location = new Point(10, 76);
            chkOreProcessing10.Name = "chkOreProcessing10";
            chkOreProcessing10.Size = new Size(15, 14);
            chkOreProcessing10.TabIndex = 135;
            chkOreProcessing10.UseVisualStyleBackColor = true;
            // 
            // chkOreProcessing7
            // 
            chkOreProcessing7.AutoSize = true;
            chkOreProcessing7.Location = new Point(10, 10);
            chkOreProcessing7.Name = "chkOreProcessing7";
            chkOreProcessing7.Size = new Size(15, 14);
            chkOreProcessing7.TabIndex = 141;
            chkOreProcessing7.UseVisualStyleBackColor = true;
            // 
            // cmbOreProcessing9
            // 
            cmbOreProcessing9.FormattingEnabled = true;
            cmbOreProcessing9.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing9.Location = new Point(202, 51);
            cmbOreProcessing9.Name = "cmbOreProcessing9";
            cmbOreProcessing9.Size = new Size(36, 21);
            cmbOreProcessing9.TabIndex = 138;
            // 
            // chkOreProcessing11
            // 
            chkOreProcessing11.AutoSize = true;
            chkOreProcessing11.Location = new Point(10, 98);
            chkOreProcessing11.Name = "chkOreProcessing11";
            chkOreProcessing11.Size = new Size(15, 14);
            chkOreProcessing11.TabIndex = 139;
            chkOreProcessing11.UseVisualStyleBackColor = true;
            // 
            // cmbOreProcessing8
            // 
            cmbOreProcessing8.FormattingEnabled = true;
            cmbOreProcessing8.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing8.Location = new Point(202, 29);
            cmbOreProcessing8.Name = "cmbOreProcessing8";
            cmbOreProcessing8.Size = new Size(36, 21);
            cmbOreProcessing8.TabIndex = 144;
            // 
            // tabPageIce
            // 
            tabPageIce.Controls.Add(cmbOreProcessing12);
            tabPageIce.Controls.Add(lblOreProcessing12);
            tabPageIce.Controls.Add(chkOreProcessing12);
            tabPageIce.Location = new Point(4, 22);
            tabPageIce.Name = "tabPageIce";
            tabPageIce.Padding = new Padding(3);
            tabPageIce.Size = new Size(310, 144);
            tabPageIce.TabIndex = 3;
            tabPageIce.Text = "Ice Processing";
            tabPageIce.UseVisualStyleBackColor = true;
            // 
            // cmbOreProcessing12
            // 
            cmbOreProcessing12.FormattingEnabled = true;
            cmbOreProcessing12.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbOreProcessing12.Location = new Point(168, 7);
            cmbOreProcessing12.Name = "cmbOreProcessing12";
            cmbOreProcessing12.Size = new Size(36, 21);
            cmbOreProcessing12.TabIndex = 147;
            // 
            // lblOreProcessing12
            // 
            lblOreProcessing12.Location = new Point(29, 11);
            lblOreProcessing12.Name = "lblOreProcessing12";
            lblOreProcessing12.Size = new Size(133, 13);
            lblOreProcessing12.TabIndex = 148;
            lblOreProcessing12.Text = "Ice Processing";
            // 
            // chkOreProcessing12
            // 
            chkOreProcessing12.AutoSize = true;
            chkOreProcessing12.Location = new Point(10, 10);
            chkOreProcessing12.Name = "chkOreProcessing12";
            chkOreProcessing12.Size = new Size(15, 14);
            chkOreProcessing12.TabIndex = 146;
            chkOreProcessing12.UseVisualStyleBackColor = true;
            // 
            // gbMineShipSetup
            // 
            gbMineShipSetup.Controls.Add(gbMineSelectShip);
            gbMineShipSetup.Controls.Add(gbMineShipEquipment);
            gbMineShipSetup.Controls.Add(gbMineSkills);
            gbMineShipSetup.Location = new Point(711, 8);
            gbMineShipSetup.Name = "gbMineShipSetup";
            gbMineShipSetup.Size = new Size(418, 233);
            gbMineShipSetup.TabIndex = 4;
            gbMineShipSetup.TabStop = false;
            gbMineShipSetup.Text = "Mining Skills/Ship Setup:";
            // 
            // gbMineSelectShip
            // 
            gbMineSelectShip.Controls.Add(pictMineSelectedShip);
            gbMineSelectShip.Controls.Add(lblMineSelectShip);
            gbMineSelectShip.Controls.Add(cmbMineBaseShipSkill);
            gbMineSelectShip.Controls.Add(cmbMineAdvShipSkill);
            gbMineSelectShip.Controls.Add(cmbMineShipName);
            gbMineSelectShip.Controls.Add(lblMineBaseShipSkill);
            gbMineSelectShip.Controls.Add(lblMineExhumers);
            gbMineSelectShip.Location = new Point(6, 13);
            gbMineSelectShip.Name = "gbMineSelectShip";
            gbMineSelectShip.Size = new Size(111, 174);
            gbMineSelectShip.TabIndex = 0;
            gbMineSelectShip.TabStop = false;
            gbMineSelectShip.Text = "Select Ship:";
            // 
            // pictMineSelectedShip
            // 
            pictMineSelectedShip.BackColor = Color.White;
            pictMineSelectedShip.BorderStyle = BorderStyle.Fixed3D;
            pictMineSelectedShip.Location = new Point(21, 95);
            pictMineSelectedShip.Name = "pictMineSelectedShip";
            pictMineSelectedShip.Size = new Size(68, 69);
            pictMineSelectedShip.TabIndex = 138;
            pictMineSelectedShip.TabStop = false;
            // 
            // lblMineSelectShip
            // 
            lblMineSelectShip.AutoSize = true;
            lblMineSelectShip.Location = new Point(3, 15);
            lblMineSelectShip.Name = "lblMineSelectShip";
            lblMineSelectShip.Size = new Size(62, 13);
            lblMineSelectShip.TabIndex = 0;
            lblMineSelectShip.Text = "Ship Name:";
            // 
            // cmbMineBaseShipSkill
            // 
            cmbMineBaseShipSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineBaseShipSkill.FormattingEnabled = true;
            cmbMineBaseShipSkill.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cmbMineBaseShipSkill.Location = new Point(6, 70);
            cmbMineBaseShipSkill.Name = "cmbMineBaseShipSkill";
            cmbMineBaseShipSkill.Size = new Size(48, 21);
            cmbMineBaseShipSkill.TabIndex = 1;
            // 
            // cmbMineAdvShipSkill
            // 
            cmbMineAdvShipSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineAdvShipSkill.FormattingEnabled = true;
            cmbMineAdvShipSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineAdvShipSkill.Location = new Point(57, 70);
            cmbMineAdvShipSkill.Name = "cmbMineAdvShipSkill";
            cmbMineAdvShipSkill.Size = new Size(48, 21);
            cmbMineAdvShipSkill.TabIndex = 2;
            // 
            // cmbMineShipName
            // 
            cmbMineShipName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineShipName.FormattingEnabled = true;
            cmbMineShipName.Location = new Point(6, 30);
            cmbMineShipName.Name = "cmbMineShipName";
            cmbMineShipName.Size = new Size(99, 21);
            cmbMineShipName.TabIndex = 0;
            // 
            // lblMineBaseShipSkill
            // 
            lblMineBaseShipSkill.AutoSize = true;
            lblMineBaseShipSkill.Location = new Point(3, 54);
            lblMineBaseShipSkill.Name = "lblMineBaseShipSkill";
            lblMineBaseShipSkill.Size = new Size(53, 13);
            lblMineBaseShipSkill.TabIndex = 130;
            lblMineBaseShipSkill.Text = "Ship Skill:";
            // 
            // lblMineExhumers
            // 
            lblMineExhumers.AutoSize = true;
            lblMineExhumers.Location = new Point(54, 54);
            lblMineExhumers.Name = "lblMineExhumers";
            lblMineExhumers.Size = new Size(57, 13);
            lblMineExhumers.TabIndex = 128;
            lblMineExhumers.Text = "Spec Skill:";
            // 
            // gbMineShipEquipment
            // 
            gbMineShipEquipment.Controls.Add(gbMiningRigs);
            gbMineShipEquipment.Controls.Add(cmbMineMiningLaser);
            gbMineShipEquipment.Controls.Add(cmbMineNumMiningUpgrades);
            gbMineShipEquipment.Controls.Add(cmbMineNumLasers);
            gbMineShipEquipment.Controls.Add(cmbMineMiningUpgrade);
            gbMineShipEquipment.Controls.Add(cmbMineHighwallImplant);
            gbMineShipEquipment.Controls.Add(chkMineMichiImplant);
            gbMineShipEquipment.Controls.Add(lblMineImplants);
            gbMineShipEquipment.Controls.Add(lblMineLaserNumber);
            gbMineShipEquipment.Controls.Add(lblMineNumMiningUpgrades);
            gbMineShipEquipment.Controls.Add(lblMineMinerTurret);
            gbMineShipEquipment.Controls.Add(lblMineMiningUpgrade);
            gbMineShipEquipment.Location = new Point(122, 13);
            gbMineShipEquipment.Name = "gbMineShipEquipment";
            gbMineShipEquipment.Size = new Size(290, 174);
            gbMineShipEquipment.TabIndex = 1;
            gbMineShipEquipment.TabStop = false;
            gbMineShipEquipment.Text = "Select Ship Equipment:";
            // 
            // gbMiningRigs
            // 
            gbMiningRigs.Controls.Add(cmbMineMiningRig3);
            gbMiningRigs.Controls.Add(cmbMineMiningRig1);
            gbMiningRigs.Controls.Add(cmbMineMiningRig2);
            gbMiningRigs.Location = new Point(6, 127);
            gbMiningRigs.Name = "gbMiningRigs";
            gbMiningRigs.Size = new Size(279, 41);
            gbMiningRigs.TabIndex = 136;
            gbMiningRigs.TabStop = false;
            gbMiningRigs.Text = "Mining Rigs:";
            // 
            // cmbMineMiningRig3
            // 
            cmbMineMiningRig3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineMiningRig3.FormattingEnabled = true;
            cmbMineMiningRig3.Items.AddRange(new object[] { "None", "T1 Drone Rig", "T2 Drone Rig" });
            cmbMineMiningRig3.Location = new Point(186, 15);
            cmbMineMiningRig3.Name = "cmbMineMiningRig3";
            cmbMineMiningRig3.Size = new Size(89, 21);
            cmbMineMiningRig3.TabIndex = 146;
            // 
            // cmbMineMiningRig1
            // 
            cmbMineMiningRig1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineMiningRig1.FormattingEnabled = true;
            cmbMineMiningRig1.Items.AddRange(new object[] { "None", "T1 Drone Rig", "T2 Drone Rig" });
            cmbMineMiningRig1.Location = new Point(4, 15);
            cmbMineMiningRig1.Name = "cmbMineMiningRig1";
            cmbMineMiningRig1.Size = new Size(89, 21);
            cmbMineMiningRig1.TabIndex = 137;
            // 
            // cmbMineMiningRig2
            // 
            cmbMineMiningRig2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineMiningRig2.FormattingEnabled = true;
            cmbMineMiningRig2.Items.AddRange(new object[] { "None", "T1 Drone Rig", "T2 Drone Rig" });
            cmbMineMiningRig2.Location = new Point(95, 15);
            cmbMineMiningRig2.Name = "cmbMineMiningRig2";
            cmbMineMiningRig2.Size = new Size(89, 21);
            cmbMineMiningRig2.TabIndex = 145;
            // 
            // cmbMineMiningLaser
            // 
            cmbMineMiningLaser.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineMiningLaser.FormattingEnabled = true;
            cmbMineMiningLaser.Location = new Point(67, 17);
            cmbMineMiningLaser.Name = "cmbMineMiningLaser";
            cmbMineMiningLaser.Size = new Size(218, 21);
            cmbMineMiningLaser.TabIndex = 0;
            // 
            // cmbMineNumMiningUpgrades
            // 
            cmbMineNumMiningUpgrades.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineNumMiningUpgrades.FormattingEnabled = true;
            cmbMineNumMiningUpgrades.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineNumMiningUpgrades.Location = new Point(249, 69);
            cmbMineNumMiningUpgrades.Name = "cmbMineNumMiningUpgrades";
            cmbMineNumMiningUpgrades.Size = new Size(36, 21);
            cmbMineNumMiningUpgrades.TabIndex = 3;
            // 
            // cmbMineNumLasers
            // 
            cmbMineNumLasers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineNumLasers.FormattingEnabled = true;
            cmbMineNumLasers.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineNumLasers.Location = new Point(101, 69);
            cmbMineNumLasers.Name = "cmbMineNumLasers";
            cmbMineNumLasers.Size = new Size(36, 21);
            cmbMineNumLasers.TabIndex = 2;
            // 
            // cmbMineMiningUpgrade
            // 
            cmbMineMiningUpgrade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineMiningUpgrade.FormattingEnabled = true;
            cmbMineMiningUpgrade.Items.AddRange(new object[] { "None", "5% (T1)", "8% (M1)", "9% (T2)", "9% (M6)", "10% (M6)" });
            cmbMineMiningUpgrade.Location = new Point(55, 42);
            cmbMineMiningUpgrade.Name = "cmbMineMiningUpgrade";
            cmbMineMiningUpgrade.Size = new Size(230, 21);
            cmbMineMiningUpgrade.TabIndex = 1;
            // 
            // cmbMineHighwallImplant
            // 
            cmbMineHighwallImplant.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineHighwallImplant.FormattingEnabled = true;
            cmbMineHighwallImplant.Location = new Point(45, 101);
            cmbMineHighwallImplant.Name = "cmbMineHighwallImplant";
            cmbMineHighwallImplant.Size = new Size(120, 21);
            cmbMineHighwallImplant.TabIndex = 5;
            // 
            // chkMineMichiImplant
            // 
            chkMineMichiImplant.Location = new Point(172, 94);
            chkMineMichiImplant.Name = "chkMineMichiImplant";
            chkMineMichiImplant.Size = new Size(124, 34);
            chkMineMichiImplant.TabIndex = 6;
            chkMineMichiImplant.Text = "Michi's Excavation Augmentor";
            chkMineMichiImplant.UseVisualStyleBackColor = true;
            // 
            // lblMineImplants
            // 
            lblMineImplants.Location = new Point(1, 97);
            lblMineImplants.Name = "lblMineImplants";
            lblMineImplants.Size = new Size(60, 29);
            lblMineImplants.TabIndex = 23;
            lblMineImplants.Text = "Mining Implant:";
            // 
            // lblMineLaserNumber
            // 
            lblMineLaserNumber.AutoSize = true;
            lblMineLaserNumber.Location = new Point(1, 73);
            lblMineLaserNumber.Name = "lblMineLaserNumber";
            lblMineLaserNumber.Size = new Size(94, 13);
            lblMineLaserNumber.TabIndex = 125;
            lblMineLaserNumber.Text = "# Mining Modules:";
            // 
            // lblMineNumMiningUpgrades
            // 
            lblMineNumMiningUpgrades.AutoSize = true;
            lblMineNumMiningUpgrades.Location = new Point(143, 73);
            lblMineNumMiningUpgrades.Name = "lblMineNumMiningUpgrades";
            lblMineNumMiningUpgrades.Size = new Size(100, 13);
            lblMineNumMiningUpgrades.TabIndex = 129;
            lblMineNumMiningUpgrades.Text = "# Mining Upgrades:";
            // 
            // lblMineMinerTurret
            // 
            lblMineMinerTurret.AutoSize = true;
            lblMineMinerTurret.Location = new Point(1, 20);
            lblMineMinerTurret.Name = "lblMineMinerTurret";
            lblMineMinerTurret.Size = new Size(67, 13);
            lblMineMinerTurret.TabIndex = 131;
            lblMineMinerTurret.Text = "Miner Name:";
            // 
            // lblMineMiningUpgrade
            // 
            lblMineMiningUpgrade.AutoSize = true;
            lblMineMiningUpgrade.Location = new Point(1, 47);
            lblMineMiningUpgrade.Name = "lblMineMiningUpgrade";
            lblMineMiningUpgrade.Size = new Size(51, 13);
            lblMineMiningUpgrade.TabIndex = 132;
            lblMineMiningUpgrade.Text = "Upgrade:";
            // 
            // gbMineSkills
            // 
            gbMineSkills.Controls.Add(cmbMineGasIceHarvesting);
            gbMineSkills.Controls.Add(lblMineGasIceHarvesting);
            gbMineSkills.Controls.Add(cmbMineDeepCore);
            gbMineSkills.Controls.Add(lblMineAstrogeology);
            gbMineSkills.Controls.Add(cmbMineSkill);
            gbMineSkills.Controls.Add(lblMineSkill);
            gbMineSkills.Controls.Add(cmbMineAstrogeology);
            gbMineSkills.Controls.Add(lblMineDeepCore);
            gbMineSkills.Location = new Point(6, 187);
            gbMineSkills.Name = "gbMineSkills";
            gbMineSkills.Size = new Size(406, 41);
            gbMineSkills.TabIndex = 2;
            gbMineSkills.TabStop = false;
            gbMineSkills.Text = "Skills:";
            // 
            // cmbMineGasIceHarvesting
            // 
            cmbMineGasIceHarvesting.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineGasIceHarvesting.FormattingEnabled = true;
            cmbMineGasIceHarvesting.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineGasIceHarvesting.Location = new Point(141, 13);
            cmbMineGasIceHarvesting.Name = "cmbMineGasIceHarvesting";
            cmbMineGasIceHarvesting.Size = new Size(36, 21);
            cmbMineGasIceHarvesting.TabIndex = 1;
            // 
            // lblMineGasIceHarvesting
            // 
            lblMineGasIceHarvesting.AutoSize = true;
            lblMineGasIceHarvesting.Location = new Point(89, 17);
            lblMineGasIceHarvesting.Name = "lblMineGasIceHarvesting";
            lblMineGasIceHarvesting.Size = new Size(51, 13);
            lblMineGasIceHarvesting.TabIndex = 117;
            lblMineGasIceHarvesting.Text = "Ice Harv:";
            // 
            // cmbMineDeepCore
            // 
            cmbMineDeepCore.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineDeepCore.FormattingEnabled = true;
            cmbMineDeepCore.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineDeepCore.Location = new Point(356, 13);
            cmbMineDeepCore.Name = "cmbMineDeepCore";
            cmbMineDeepCore.Size = new Size(36, 21);
            cmbMineDeepCore.TabIndex = 3;
            // 
            // lblMineAstrogeology
            // 
            lblMineAstrogeology.AutoSize = true;
            lblMineAstrogeology.Location = new Point(183, 17);
            lblMineAstrogeology.Name = "lblMineAstrogeology";
            lblMineAstrogeology.Size = new Size(71, 13);
            lblMineAstrogeology.TabIndex = 109;
            lblMineAstrogeology.Text = "Astrogeology:";
            // 
            // cmbMineSkill
            // 
            cmbMineSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineSkill.FormattingEnabled = true;
            cmbMineSkill.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineSkill.Location = new Point(48, 13);
            cmbMineSkill.Name = "cmbMineSkill";
            cmbMineSkill.Size = new Size(36, 21);
            cmbMineSkill.TabIndex = 0;
            // 
            // lblMineSkill
            // 
            lblMineSkill.AutoSize = true;
            lblMineSkill.Location = new Point(6, 17);
            lblMineSkill.Name = "lblMineSkill";
            lblMineSkill.Size = new Size(41, 13);
            lblMineSkill.TabIndex = 108;
            lblMineSkill.Text = "Mining:";
            // 
            // cmbMineAstrogeology
            // 
            cmbMineAstrogeology.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMineAstrogeology.FormattingEnabled = true;
            cmbMineAstrogeology.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbMineAstrogeology.Location = new Point(255, 13);
            cmbMineAstrogeology.Name = "cmbMineAstrogeology";
            cmbMineAstrogeology.Size = new Size(36, 21);
            cmbMineAstrogeology.TabIndex = 2;
            // 
            // lblMineDeepCore
            // 
            lblMineDeepCore.Location = new Point(297, 10);
            lblMineDeepCore.Name = "lblMineDeepCore";
            lblMineDeepCore.Size = new Size(60, 27);
            lblMineDeepCore.TabIndex = 114;
            lblMineDeepCore.Text = "Deep Core Mining:";
            // 
            // gbMineMain
            // 
            gbMineMain.Controls.Add(gbMineIncludeOres);
            gbMineMain.Controls.Add(cmbMineOreType);
            gbMineMain.Controls.Add(gbMineOreLocSov);
            gbMineMain.Controls.Add(lblMineType);
            gbMineMain.Location = new Point(6, 8);
            gbMineMain.Name = "gbMineMain";
            gbMineMain.Size = new Size(362, 144);
            gbMineMain.TabIndex = 0;
            gbMineMain.TabStop = false;
            gbMineMain.Text = "Options:";
            // 
            // gbMineIncludeOres
            // 
            gbMineIncludeOres.Controls.Add(chkMineIncludeA0StarOres);
            gbMineIncludeOres.Controls.Add(chkMineIncludeHighSec);
            gbMineIncludeOres.Controls.Add(chkMineIncludeNullSec);
            gbMineIncludeOres.Controls.Add(chkMineIncludeLowSec);
            gbMineIncludeOres.Controls.Add(chkMineIncludeHighYieldOre);
            gbMineIncludeOres.Location = new Point(6, 38);
            gbMineIncludeOres.Name = "gbMineIncludeOres";
            gbMineIncludeOres.Size = new Size(105, 100);
            gbMineIncludeOres.TabIndex = 4;
            gbMineIncludeOres.TabStop = false;
            gbMineIncludeOres.Text = "Include:";
            // 
            // chkMineIncludeA0StarOres
            // 
            chkMineIncludeA0StarOres.AutoSize = true;
            chkMineIncludeA0StarOres.Location = new Point(9, 64);
            chkMineIncludeA0StarOres.Name = "chkMineIncludeA0StarOres";
            chkMineIncludeA0StarOres.Size = new Size(86, 17);
            chkMineIncludeA0StarOres.TabIndex = 4;
            chkMineIncludeA0StarOres.Text = "A0 Star Ores";
            chkMineIncludeA0StarOres.UseVisualStyleBackColor = true;
            // 
            // chkMineIncludeHighSec
            // 
            chkMineIncludeHighSec.AutoSize = true;
            chkMineIncludeHighSec.Location = new Point(9, 13);
            chkMineIncludeHighSec.Name = "chkMineIncludeHighSec";
            chkMineIncludeHighSec.Size = new Size(95, 17);
            chkMineIncludeHighSec.TabIndex = 0;
            chkMineIncludeHighSec.Text = "High Sec Ores";
            chkMineIncludeHighSec.UseVisualStyleBackColor = true;
            // 
            // chkMineIncludeNullSec
            // 
            chkMineIncludeNullSec.AutoSize = true;
            chkMineIncludeNullSec.Location = new Point(9, 47);
            chkMineIncludeNullSec.Name = "chkMineIncludeNullSec";
            chkMineIncludeNullSec.Size = new Size(91, 17);
            chkMineIncludeNullSec.TabIndex = 2;
            chkMineIncludeNullSec.Text = "Null Sec Ores";
            chkMineIncludeNullSec.UseVisualStyleBackColor = true;
            // 
            // chkMineIncludeLowSec
            // 
            chkMineIncludeLowSec.AutoSize = true;
            chkMineIncludeLowSec.Location = new Point(9, 30);
            chkMineIncludeLowSec.Name = "chkMineIncludeLowSec";
            chkMineIncludeLowSec.Size = new Size(93, 17);
            chkMineIncludeLowSec.TabIndex = 1;
            chkMineIncludeLowSec.Text = "Low Sec Ores";
            chkMineIncludeLowSec.UseVisualStyleBackColor = true;
            // 
            // chkMineIncludeHighYieldOre
            // 
            chkMineIncludeHighYieldOre.AutoSize = true;
            chkMineIncludeHighYieldOre.Location = new Point(9, 81);
            chkMineIncludeHighYieldOre.Name = "chkMineIncludeHighYieldOre";
            chkMineIncludeHighYieldOre.Size = new Size(99, 17);
            chkMineIncludeHighYieldOre.TabIndex = 3;
            chkMineIncludeHighYieldOre.Text = "High Yield Ores";
            chkMineIncludeHighYieldOre.UseVisualStyleBackColor = true;
            // 
            // cmbMineOreType
            // 
            cmbMineOreType.FormattingEnabled = true;
            cmbMineOreType.Items.AddRange(new object[] { "Ore", "Ice", "Gas" });
            cmbMineOreType.Location = new Point(67, 15);
            cmbMineOreType.Name = "cmbMineOreType";
            cmbMineOreType.Size = new Size(44, 21);
            cmbMineOreType.TabIndex = 0;
            // 
            // gbMineOreLocSov
            // 
            gbMineOreLocSov.Controls.Add(chkMineEDENCOM);
            gbMineOreLocSov.Controls.Add(chkMineMoonMining);
            gbMineOreLocSov.Controls.Add(chkMineTriglavian);
            gbMineOreLocSov.Controls.Add(chkMineWH);
            gbMineOreLocSov.Controls.Add(gbMineWHSpace);
            gbMineOreLocSov.Controls.Add(chkMineCaldari);
            gbMineOreLocSov.Controls.Add(chkMineMinmatar);
            gbMineOreLocSov.Controls.Add(chkMineGallente);
            gbMineOreLocSov.Controls.Add(chkMineAmarr);
            gbMineOreLocSov.Location = new Point(114, 9);
            gbMineOreLocSov.Name = "gbMineOreLocSov";
            gbMineOreLocSov.Size = new Size(243, 129);
            gbMineOreLocSov.TabIndex = 5;
            gbMineOreLocSov.TabStop = false;
            gbMineOreLocSov.Text = "Ore Location:";
            // 
            // chkMineMoonMining
            // 
            chkMineMoonMining.AutoSize = true;
            chkMineMoonMining.Location = new Point(11, 75);
            chkMineMoonMining.Name = "chkMineMoonMining";
            chkMineMoonMining.Size = new Size(87, 17);
            chkMineMoonMining.TabIndex = 6;
            chkMineMoonMining.Text = "Moon Mining";
            chkMineMoonMining.UseVisualStyleBackColor = true;
            // 
            // chkMineTriglavian
            // 
            chkMineTriglavian.AutoSize = true;
            chkMineTriglavian.Location = new Point(119, 56);
            chkMineTriglavian.Name = "chkMineTriglavian";
            chkMineTriglavian.Size = new Size(106, 17);
            chkMineTriglavian.TabIndex = 6;
            chkMineTriglavian.Text = "Triglavian Space";
            chkMineTriglavian.UseVisualStyleBackColor = true;
            // 
            // chkMineWH
            // 
            chkMineWH.AutoSize = true;
            chkMineWH.Location = new Point(11, 56);
            chkMineWH.Name = "chkMineWH";
            chkMineWH.Size = new Size(108, 17);
            chkMineWH.TabIndex = 4;
            chkMineWH.Text = "Wormhole Space";
            chkMineWH.UseVisualStyleBackColor = true;
            // 
            // gbMineWHSpace
            // 
            gbMineWHSpace.Controls.Add(chkMineC6);
            gbMineWHSpace.Controls.Add(chkMineC5);
            gbMineWHSpace.Controls.Add(chkMineC4);
            gbMineWHSpace.Controls.Add(chkMineC3);
            gbMineWHSpace.Controls.Add(chkMineC2);
            gbMineWHSpace.Controls.Add(chkMineC1);
            gbMineWHSpace.Location = new Point(6, 87);
            gbMineWHSpace.Name = "gbMineWHSpace";
            gbMineWHSpace.Size = new Size(230, 37);
            gbMineWHSpace.TabIndex = 5;
            gbMineWHSpace.TabStop = false;
            // 
            // chkMineC6
            // 
            chkMineC6.AutoSize = true;
            chkMineC6.Location = new Point(190, 13);
            chkMineC6.Name = "chkMineC6";
            chkMineC6.Size = new Size(39, 17);
            chkMineC6.TabIndex = 10;
            chkMineC6.Text = "C6";
            chkMineC6.UseVisualStyleBackColor = true;
            // 
            // chkMineC5
            // 
            chkMineC5.AutoSize = true;
            chkMineC5.Location = new Point(153, 13);
            chkMineC5.Name = "chkMineC5";
            chkMineC5.Size = new Size(39, 17);
            chkMineC5.TabIndex = 9;
            chkMineC5.Text = "C5";
            chkMineC5.UseVisualStyleBackColor = true;
            // 
            // chkMineC4
            // 
            chkMineC4.AutoSize = true;
            chkMineC4.Location = new Point(116, 13);
            chkMineC4.Name = "chkMineC4";
            chkMineC4.Size = new Size(39, 17);
            chkMineC4.TabIndex = 8;
            chkMineC4.Text = "C4";
            chkMineC4.UseVisualStyleBackColor = true;
            // 
            // chkMineC3
            // 
            chkMineC3.AutoSize = true;
            chkMineC3.Location = new Point(79, 13);
            chkMineC3.Name = "chkMineC3";
            chkMineC3.Size = new Size(39, 17);
            chkMineC3.TabIndex = 7;
            chkMineC3.Text = "C3";
            chkMineC3.UseVisualStyleBackColor = true;
            // 
            // chkMineC2
            // 
            chkMineC2.AutoSize = true;
            chkMineC2.Location = new Point(42, 13);
            chkMineC2.Name = "chkMineC2";
            chkMineC2.Size = new Size(39, 17);
            chkMineC2.TabIndex = 6;
            chkMineC2.Text = "C2";
            chkMineC2.UseVisualStyleBackColor = true;
            // 
            // chkMineC1
            // 
            chkMineC1.AutoSize = true;
            chkMineC1.Location = new Point(5, 13);
            chkMineC1.Name = "chkMineC1";
            chkMineC1.Size = new Size(39, 17);
            chkMineC1.TabIndex = 5;
            chkMineC1.Text = "C1";
            chkMineC1.UseVisualStyleBackColor = true;
            // 
            // chkMineCaldari
            // 
            chkMineCaldari.AutoSize = true;
            chkMineCaldari.Location = new Point(119, 18);
            chkMineCaldari.Name = "chkMineCaldari";
            chkMineCaldari.Size = new Size(92, 17);
            chkMineCaldari.TabIndex = 1;
            chkMineCaldari.Text = "Caldari Space";
            chkMineCaldari.UseVisualStyleBackColor = true;
            // 
            // chkMineMinmatar
            // 
            chkMineMinmatar.AutoSize = true;
            chkMineMinmatar.Location = new Point(119, 37);
            chkMineMinmatar.Name = "chkMineMinmatar";
            chkMineMinmatar.Size = new Size(103, 17);
            chkMineMinmatar.TabIndex = 3;
            chkMineMinmatar.Text = "Minmatar Space";
            chkMineMinmatar.UseVisualStyleBackColor = true;
            // 
            // chkMineGallente
            // 
            chkMineGallente.AutoSize = true;
            chkMineGallente.Location = new Point(11, 37);
            chkMineGallente.Name = "chkMineGallente";
            chkMineGallente.Size = new Size(99, 17);
            chkMineGallente.TabIndex = 2;
            chkMineGallente.Text = "Gallente Space";
            chkMineGallente.UseVisualStyleBackColor = true;
            // 
            // chkMineAmarr
            // 
            chkMineAmarr.AutoSize = true;
            chkMineAmarr.Location = new Point(11, 18);
            chkMineAmarr.Name = "chkMineAmarr";
            chkMineAmarr.Size = new Size(87, 17);
            chkMineAmarr.TabIndex = 0;
            chkMineAmarr.Text = "Amarr Space";
            chkMineAmarr.UseVisualStyleBackColor = true;
            // 
            // lblMineType
            // 
            lblMineType.AutoSize = true;
            lblMineType.Location = new Point(2, 18);
            lblMineType.Name = "lblMineType";
            lblMineType.Size = new Size(67, 13);
            lblMineType.TabIndex = 60;
            lblMineType.Text = "Select Type:";
            // 
            // lstMineGrid
            // 
            lstMineGrid.FullRowSelect = true;
            lstMineGrid.GridLines = true;
            lstMineGrid.HideSelection = false;
            lstMineGrid.Location = new Point(5, 276);
            lstMineGrid.MultiSelect = false;
            lstMineGrid.Name = "lstMineGrid";
            lstMineGrid.Size = new Size(700, 332);
            lstMineGrid.TabIndex = 8;
            lstMineGrid.UseCompatibleStateImageBehavior = false;
            lstMineGrid.View = View.Details;
            // 
            // tabDatacores
            // 
            tabDatacores.Controls.Add(lstDC);
            tabDatacores.Controls.Add(gbDCOptions);
            tabDatacores.Location = new Point(4, 22);
            tabDatacores.Name = "tabDatacores";
            tabDatacores.Size = new Size(1137, 615);
            tabDatacores.TabIndex = 3;
            tabDatacores.Text = "Datacores";
            tabDatacores.UseVisualStyleBackColor = true;
            // 
            // lstDC
            // 
            lstDC.CheckBoxes = true;
            lstDC.FullRowSelect = true;
            lstDC.GridLines = true;
            lstDC.HideSelection = false;
            lstDC.Location = new Point(5, 8);
            lstDC.Name = "lstDC";
            lstDC.Size = new Size(1124, 282);
            lstDC.TabIndex = 10;
            lstDC.UseCompatibleStateImageBehavior = false;
            lstDC.View = View.Details;
            // 
            // gbDCOptions
            // 
            gbDCOptions.Controls.Add(btnDCSaveSettings);
            gbDCOptions.Controls.Add(gbDCAgentLocSov);
            gbDCOptions.Controls.Add(gbDCTotalIPH);
            gbDCOptions.Controls.Add(gbDCPrices);
            gbDCOptions.Controls.Add(gbDCAgentTypes);
            gbDCOptions.Controls.Add(gbDCBaseSkills);
            gbDCOptions.Controls.Add(gbDCDatacores);
            gbDCOptions.Controls.Add(gbDCCorpMinmatar);
            gbDCOptions.Controls.Add(btnDCExporttoClip);
            gbDCOptions.Controls.Add(gbDCCorpAmarr);
            gbDCOptions.Controls.Add(btnDCReset);
            gbDCOptions.Controls.Add(gbDCCorpsCaldari);
            gbDCOptions.Controls.Add(gbDCCorpsGallente);
            gbDCOptions.Controls.Add(btnDCRefresh);
            gbDCOptions.Location = new Point(5, 286);
            gbDCOptions.Name = "gbDCOptions";
            gbDCOptions.Size = new Size(1124, 323);
            gbDCOptions.TabIndex = 9;
            gbDCOptions.TabStop = false;
            // 
            // btnDCSaveSettings
            // 
            btnDCSaveSettings.Location = new Point(980, 176);
            btnDCSaveSettings.Name = "btnDCSaveSettings";
            btnDCSaveSettings.Size = new Size(138, 30);
            btnDCSaveSettings.TabIndex = 71;
            btnDCSaveSettings.Text = "Save Settings";
            btnDCSaveSettings.UseVisualStyleBackColor = true;
            // 
            // gbDCAgentLocSov
            // 
            gbDCAgentLocSov.Controls.Add(chkDCThukkerSov);
            gbDCAgentLocSov.Controls.Add(chkDCKhanidSov);
            gbDCAgentLocSov.Controls.Add(chkDCMinmatarSov);
            gbDCAgentLocSov.Controls.Add(chkDCSyndicateSov);
            gbDCAgentLocSov.Controls.Add(chkDCGallenteSov);
            gbDCAgentLocSov.Controls.Add(chkDCAmarrSov);
            gbDCAgentLocSov.Controls.Add(chkDCAmmatarSov);
            gbDCAgentLocSov.Controls.Add(chkDCCaldariSov);
            gbDCAgentLocSov.Location = new Point(746, 241);
            gbDCAgentLocSov.Name = "gbDCAgentLocSov";
            gbDCAgentLocSov.Size = new Size(372, 76);
            gbDCAgentLocSov.TabIndex = 63;
            gbDCAgentLocSov.TabStop = false;
            gbDCAgentLocSov.Text = "Agent Location Sovergnity:";
            // 
            // chkDCThukkerSov
            // 
            chkDCThukkerSov.AutoSize = true;
            chkDCThukkerSov.Location = new Point(272, 36);
            chkDCThukkerSov.Name = "chkDCThukkerSov";
            chkDCThukkerSov.Size = new Size(93, 17);
            chkDCThukkerSov.TabIndex = 34;
            chkDCThukkerSov.Text = "Thukker Tribe";
            chkDCThukkerSov.UseVisualStyleBackColor = true;
            // 
            // chkDCKhanidSov
            // 
            chkDCKhanidSov.AutoSize = true;
            chkDCKhanidSov.Location = new Point(127, 36);
            chkDCKhanidSov.Name = "chkDCKhanidSov";
            chkDCKhanidSov.Size = new Size(103, 17);
            chkDCKhanidSov.TabIndex = 31;
            chkDCKhanidSov.Text = "Khanid Kingdom";
            chkDCKhanidSov.UseVisualStyleBackColor = true;
            // 
            // chkDCMinmatarSov
            // 
            chkDCMinmatarSov.AutoSize = true;
            chkDCMinmatarSov.Location = new Point(127, 53);
            chkDCMinmatarSov.Name = "chkDCMinmatarSov";
            chkDCMinmatarSov.Size = new Size(114, 17);
            chkDCMinmatarSov.TabIndex = 32;
            chkDCMinmatarSov.Text = "Minmatar Republic";
            chkDCMinmatarSov.UseVisualStyleBackColor = true;
            // 
            // chkDCSyndicateSov
            // 
            chkDCSyndicateSov.AutoSize = true;
            chkDCSyndicateSov.Location = new Point(272, 19);
            chkDCSyndicateSov.Name = "chkDCSyndicateSov";
            chkDCSyndicateSov.Size = new Size(95, 17);
            chkDCSyndicateSov.TabIndex = 33;
            chkDCSyndicateSov.Text = "The Syndicate";
            chkDCSyndicateSov.UseVisualStyleBackColor = true;
            // 
            // chkDCGallenteSov
            // 
            chkDCGallenteSov.AutoSize = true;
            chkDCGallenteSov.Location = new Point(127, 19);
            chkDCGallenteSov.Name = "chkDCGallenteSov";
            chkDCGallenteSov.Size = new Size(118, 17);
            chkDCGallenteSov.TabIndex = 30;
            chkDCGallenteSov.Text = "Gallente Federation";
            chkDCGallenteSov.UseVisualStyleBackColor = true;
            // 
            // chkDCAmarrSov
            // 
            chkDCAmarrSov.AutoSize = true;
            chkDCAmarrSov.Location = new Point(12, 19);
            chkDCAmarrSov.Name = "chkDCAmarrSov";
            chkDCAmarrSov.Size = new Size(88, 17);
            chkDCAmarrSov.TabIndex = 27;
            chkDCAmarrSov.Text = "Amarr Empire";
            chkDCAmarrSov.UseVisualStyleBackColor = true;
            // 
            // chkDCAmmatarSov
            // 
            chkDCAmmatarSov.AutoSize = true;
            chkDCAmmatarSov.Location = new Point(12, 36);
            chkDCAmmatarSov.Name = "chkDCAmmatarSov";
            chkDCAmmatarSov.Size = new Size(112, 17);
            chkDCAmmatarSov.TabIndex = 28;
            chkDCAmmatarSov.Text = "Ammatar Mandate";
            chkDCAmmatarSov.UseVisualStyleBackColor = true;
            // 
            // chkDCCaldariSov
            // 
            chkDCCaldariSov.AutoSize = true;
            chkDCCaldariSov.Location = new Point(12, 53);
            chkDCCaldariSov.Name = "chkDCCaldariSov";
            chkDCCaldariSov.Size = new Size(86, 17);
            chkDCCaldariSov.TabIndex = 29;
            chkDCCaldariSov.Text = "Caldari State";
            chkDCCaldariSov.UseVisualStyleBackColor = true;
            // 
            // gbDCTotalIPH
            // 
            gbDCTotalIPH.Controls.Add(lblDCTotalOptIPH);
            gbDCTotalIPH.Controls.Add(lblDCTotalSelectedIPH);
            gbDCTotalIPH.Controls.Add(txtDCTotalSelectedIPH);
            gbDCTotalIPH.Controls.Add(txtDCTotalOptIPH);
            gbDCTotalIPH.Location = new Point(978, 11);
            gbDCTotalIPH.Name = "gbDCTotalIPH";
            gbDCTotalIPH.Size = new Size(140, 101);
            gbDCTotalIPH.TabIndex = 70;
            gbDCTotalIPH.TabStop = false;
            gbDCTotalIPH.Text = "Total Isk per Hour:";
            // 
            // lblDCTotalOptIPH
            // 
            lblDCTotalOptIPH.Location = new Point(5, 56);
            lblDCTotalOptIPH.Name = "lblDCTotalOptIPH";
            lblDCTotalOptIPH.Size = new Size(81, 13);
            lblDCTotalOptIPH.TabIndex = 47;
            lblDCTotalOptIPH.Text = "Total Optimal:";
            // 
            // lblDCTotalSelectedIPH
            // 
            lblDCTotalSelectedIPH.Location = new Point(5, 19);
            lblDCTotalSelectedIPH.Name = "lblDCTotalSelectedIPH";
            lblDCTotalSelectedIPH.Size = new Size(81, 13);
            lblDCTotalSelectedIPH.TabIndex = 46;
            lblDCTotalSelectedIPH.Text = "Total Selected:";
            // 
            // txtDCTotalSelectedIPH
            // 
            txtDCTotalSelectedIPH.Location = new Point(5, 33);
            txtDCTotalSelectedIPH.Name = "txtDCTotalSelectedIPH";
            txtDCTotalSelectedIPH.Size = new Size(129, 20);
            txtDCTotalSelectedIPH.TabIndex = 41;
            txtDCTotalSelectedIPH.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDCTotalOptIPH
            // 
            txtDCTotalOptIPH.Location = new Point(5, 71);
            txtDCTotalOptIPH.Name = "txtDCTotalOptIPH";
            txtDCTotalOptIPH.Size = new Size(129, 20);
            txtDCTotalOptIPH.TabIndex = 40;
            txtDCTotalOptIPH.TextAlign = HorizontalAlignment.Center;
            // 
            // gbDCPrices
            // 
            gbDCPrices.Controls.Add(rbtnDCSystemPrices);
            gbDCPrices.Controls.Add(rbtnDCRegionPrices);
            gbDCPrices.Controls.Add(rbtnDCUpdatedPrices);
            gbDCPrices.Location = new Point(6, 277);
            gbDCPrices.Name = "gbDCPrices";
            gbDCPrices.Size = new Size(506, 40);
            gbDCPrices.TabIndex = 7;
            gbDCPrices.TabStop = false;
            gbDCPrices.Text = "Use Prices From:";
            // 
            // rbtnDCSystemPrices
            // 
            rbtnDCSystemPrices.AutoSize = true;
            rbtnDCSystemPrices.Location = new Point(313, 16);
            rbtnDCSystemPrices.Name = "rbtnDCSystemPrices";
            rbtnDCSystemPrices.Size = new Size(90, 17);
            rbtnDCSystemPrices.TabIndex = 2;
            rbtnDCSystemPrices.TabStop = true;
            rbtnDCSystemPrices.Text = "Agent System";
            rbtnDCSystemPrices.UseVisualStyleBackColor = true;
            // 
            // rbtnDCRegionPrices
            // 
            rbtnDCRegionPrices.AutoSize = true;
            rbtnDCRegionPrices.Location = new Point(164, 16);
            rbtnDCRegionPrices.Name = "rbtnDCRegionPrices";
            rbtnDCRegionPrices.Size = new Size(90, 17);
            rbtnDCRegionPrices.TabIndex = 1;
            rbtnDCRegionPrices.TabStop = true;
            rbtnDCRegionPrices.Text = "Agent Region";
            rbtnDCRegionPrices.UseVisualStyleBackColor = true;
            // 
            // rbtnDCUpdatedPrices
            // 
            rbtnDCUpdatedPrices.AutoSize = true;
            rbtnDCUpdatedPrices.Location = new Point(7, 16);
            rbtnDCUpdatedPrices.Name = "rbtnDCUpdatedPrices";
            rbtnDCUpdatedPrices.Size = new Size(98, 17);
            rbtnDCUpdatedPrices.TabIndex = 0;
            rbtnDCUpdatedPrices.TabStop = true;
            rbtnDCUpdatedPrices.Text = "Updated Prices";
            rbtnDCUpdatedPrices.UseVisualStyleBackColor = true;
            // 
            // gbDCAgentTypes
            // 
            gbDCAgentTypes.Controls.Add(cmbDCRegions);
            gbDCAgentTypes.Controls.Add(lblDCRegion);
            gbDCAgentTypes.Controls.Add(chkDCLowSecAgents);
            gbDCAgentTypes.Controls.Add(chkDCHighSecAgents);
            gbDCAgentTypes.Controls.Add(chkDCIncludeAllAgents);
            gbDCAgentTypes.Location = new Point(518, 214);
            gbDCAgentTypes.Name = "gbDCAgentTypes";
            gbDCAgentTypes.Size = new Size(222, 104);
            gbDCAgentTypes.TabIndex = 69;
            gbDCAgentTypes.TabStop = false;
            gbDCAgentTypes.Text = "Agents:";
            // 
            // cmbDCRegions
            // 
            cmbDCRegions.FormattingEnabled = true;
            cmbDCRegions.Location = new Point(65, 70);
            cmbDCRegions.Name = "cmbDCRegions";
            cmbDCRegions.Size = new Size(144, 21);
            cmbDCRegions.TabIndex = 6;
            cmbDCRegions.Text = "All Regions";
            // 
            // lblDCRegion
            // 
            lblDCRegion.Location = new Point(9, 73);
            lblDCRegion.Name = "lblDCRegion";
            lblDCRegion.Size = new Size(59, 13);
            lblDCRegion.TabIndex = 7;
            lblDCRegion.Text = "In Region:";
            // 
            // chkDCLowSecAgents
            // 
            chkDCLowSecAgents.AutoSize = true;
            chkDCLowSecAgents.Location = new Point(97, 21);
            chkDCLowSecAgents.Name = "chkDCLowSecAgents";
            chkDCLowSecAgents.Size = new Size(91, 17);
            chkDCLowSecAgents.TabIndex = 1;
            chkDCLowSecAgents.Text = "Low/Null Sec";
            chkDCLowSecAgents.UseVisualStyleBackColor = true;
            // 
            // chkDCHighSecAgents
            // 
            chkDCHighSecAgents.AutoSize = true;
            chkDCHighSecAgents.Location = new Point(12, 21);
            chkDCHighSecAgents.Name = "chkDCHighSecAgents";
            chkDCHighSecAgents.Size = new Size(70, 17);
            chkDCHighSecAgents.TabIndex = 0;
            chkDCHighSecAgents.Text = "High Sec";
            chkDCHighSecAgents.UseVisualStyleBackColor = true;
            // 
            // chkDCIncludeAllAgents
            // 
            chkDCIncludeAllAgents.AutoSize = true;
            chkDCIncludeAllAgents.Location = new Point(12, 44);
            chkDCIncludeAllAgents.Name = "chkDCIncludeAllAgents";
            chkDCIncludeAllAgents.Size = new Size(178, 17);
            chkDCIncludeAllAgents.TabIndex = 0;
            chkDCIncludeAllAgents.Text = "Include Agents I Cannot Access";
            chkDCIncludeAllAgents.UseVisualStyleBackColor = true;
            // 
            // gbDCBaseSkills
            // 
            gbDCBaseSkills.Controls.Add(cmbDCResearchMgmt);
            gbDCBaseSkills.Controls.Add(lblDCResearchManagement);
            gbDCBaseSkills.Controls.Add(lblDCNegotiation);
            gbDCBaseSkills.Controls.Add(cmbDCConnections);
            gbDCBaseSkills.Controls.Add(lblDCConnections);
            gbDCBaseSkills.Controls.Add(cmbDCNegotiation);
            gbDCBaseSkills.Location = new Point(6, 236);
            gbDCBaseSkills.Name = "gbDCBaseSkills";
            gbDCBaseSkills.Size = new Size(506, 40);
            gbDCBaseSkills.TabIndex = 9;
            gbDCBaseSkills.TabStop = false;
            gbDCBaseSkills.Text = "Base Skills:";
            // 
            // cmbDCResearchMgmt
            // 
            cmbDCResearchMgmt.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCResearchMgmt.FormattingEnabled = true;
            cmbDCResearchMgmt.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCResearchMgmt.Location = new Point(396, 13);
            cmbDCResearchMgmt.Name = "cmbDCResearchMgmt";
            cmbDCResearchMgmt.Size = new Size(36, 21);
            cmbDCResearchMgmt.TabIndex = 60;
            // 
            // lblDCResearchManagement
            // 
            lblDCResearchManagement.AutoSize = true;
            lblDCResearchManagement.Location = new Point(269, 17);
            lblDCResearchManagement.Name = "lblDCResearchManagement";
            lblDCResearchManagement.Size = new Size(121, 13);
            lblDCResearchManagement.TabIndex = 59;
            lblDCResearchManagement.Text = "Research Project Mgmt:";
            // 
            // lblDCNegotiation
            // 
            lblDCNegotiation.AutoSize = true;
            lblDCNegotiation.Location = new Point(6, 17);
            lblDCNegotiation.Name = "lblDCNegotiation";
            lblDCNegotiation.Size = new Size(64, 13);
            lblDCNegotiation.TabIndex = 58;
            lblDCNegotiation.Text = "Negotiation:";
            // 
            // cmbDCConnections
            // 
            cmbDCConnections.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCConnections.FormattingEnabled = true;
            cmbDCConnections.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCConnections.Location = new Point(218, 13);
            cmbDCConnections.Name = "cmbDCConnections";
            cmbDCConnections.Size = new Size(36, 21);
            cmbDCConnections.TabIndex = 55;
            // 
            // lblDCConnections
            // 
            lblDCConnections.AutoSize = true;
            lblDCConnections.Location = new Point(143, 17);
            lblDCConnections.Name = "lblDCConnections";
            lblDCConnections.Size = new Size(69, 13);
            lblDCConnections.TabIndex = 57;
            lblDCConnections.Text = "Connections:";
            // 
            // cmbDCNegotiation
            // 
            cmbDCNegotiation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCNegotiation.FormattingEnabled = true;
            cmbDCNegotiation.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCNegotiation.Location = new Point(76, 13);
            cmbDCNegotiation.Name = "cmbDCNegotiation";
            cmbDCNegotiation.Size = new Size(36, 21);
            cmbDCNegotiation.TabIndex = 56;
            // 
            // gbDCDatacores
            // 
            gbDCDatacores.Controls.Add(cmbDCSkillLevel17);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel16);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel15);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel14);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel13);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel12);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel11);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel10);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel9);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel8);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel7);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel6);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel5);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel4);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel3);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel2);
            gbDCDatacores.Controls.Add(cmbDCSkillLevel1);
            gbDCDatacores.Controls.Add(chkDC17);
            gbDCDatacores.Controls.Add(chkDC4);
            gbDCDatacores.Controls.Add(chkDC16);
            gbDCDatacores.Controls.Add(chkDC3);
            gbDCDatacores.Controls.Add(lblDatacore17);
            gbDCDatacores.Controls.Add(chkDC15);
            gbDCDatacores.Controls.Add(chkDC2);
            gbDCDatacores.Controls.Add(chkDC14);
            gbDCDatacores.Controls.Add(chkDC1);
            gbDCDatacores.Controls.Add(chkDC13);
            gbDCDatacores.Controls.Add(chkDC12);
            gbDCDatacores.Controls.Add(chkDC11);
            gbDCDatacores.Controls.Add(chkDC10);
            gbDCDatacores.Controls.Add(lblDatacore16);
            gbDCDatacores.Controls.Add(lblDatacore4);
            gbDCDatacores.Controls.Add(lblDatacore15);
            gbDCDatacores.Controls.Add(chkDC9);
            gbDCDatacores.Controls.Add(lblDatacore14);
            gbDCDatacores.Controls.Add(lblDatacore3);
            gbDCDatacores.Controls.Add(chkDC8);
            gbDCDatacores.Controls.Add(lblDatacore13);
            gbDCDatacores.Controls.Add(lblDatacore2);
            gbDCDatacores.Controls.Add(chkDC7);
            gbDCDatacores.Controls.Add(chkDC6);
            gbDCDatacores.Controls.Add(lblDatacore1);
            gbDCDatacores.Controls.Add(chkDC5);
            gbDCDatacores.Controls.Add(lblDatacore5);
            gbDCDatacores.Controls.Add(lblDatacore6);
            gbDCDatacores.Controls.Add(lblDatacore7);
            gbDCDatacores.Controls.Add(lblDatacore8);
            gbDCDatacores.Controls.Add(lblDatacore12);
            gbDCDatacores.Controls.Add(lblDatacore11);
            gbDCDatacores.Controls.Add(lblDatacore10);
            gbDCDatacores.Controls.Add(lblDatacore9);
            gbDCDatacores.Controls.Add(gbDCCodes);
            gbDCDatacores.Location = new Point(6, 11);
            gbDCDatacores.Name = "gbDCDatacores";
            gbDCDatacores.Size = new Size(506, 224);
            gbDCDatacores.TabIndex = 3;
            gbDCDatacores.TabStop = false;
            gbDCDatacores.Text = "Datacore Skills:";
            // 
            // cmbDCSkillLevel17
            // 
            cmbDCSkillLevel17.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel17.FormattingEnabled = true;
            cmbDCSkillLevel17.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel17.Location = new Point(465, 167);
            cmbDCSkillLevel17.Name = "cmbDCSkillLevel17";
            cmbDCSkillLevel17.Size = new Size(36, 21);
            cmbDCSkillLevel17.TabIndex = 55;
            // 
            // cmbDCSkillLevel16
            // 
            cmbDCSkillLevel16.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel16.FormattingEnabled = true;
            cmbDCSkillLevel16.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel16.Location = new Point(465, 145);
            cmbDCSkillLevel16.Name = "cmbDCSkillLevel16";
            cmbDCSkillLevel16.Size = new Size(36, 21);
            cmbDCSkillLevel16.TabIndex = 54;
            // 
            // cmbDCSkillLevel15
            // 
            cmbDCSkillLevel15.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel15.FormattingEnabled = true;
            cmbDCSkillLevel15.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel15.Location = new Point(465, 122);
            cmbDCSkillLevel15.Name = "cmbDCSkillLevel15";
            cmbDCSkillLevel15.Size = new Size(36, 21);
            cmbDCSkillLevel15.TabIndex = 53;
            // 
            // cmbDCSkillLevel14
            // 
            cmbDCSkillLevel14.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel14.FormattingEnabled = true;
            cmbDCSkillLevel14.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel14.Location = new Point(465, 100);
            cmbDCSkillLevel14.Name = "cmbDCSkillLevel14";
            cmbDCSkillLevel14.Size = new Size(36, 21);
            cmbDCSkillLevel14.TabIndex = 52;
            // 
            // cmbDCSkillLevel13
            // 
            cmbDCSkillLevel13.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel13.FormattingEnabled = true;
            cmbDCSkillLevel13.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel13.Location = new Point(465, 78);
            cmbDCSkillLevel13.Name = "cmbDCSkillLevel13";
            cmbDCSkillLevel13.Size = new Size(36, 21);
            cmbDCSkillLevel13.TabIndex = 51;
            // 
            // cmbDCSkillLevel12
            // 
            cmbDCSkillLevel12.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel12.FormattingEnabled = true;
            cmbDCSkillLevel12.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel12.Location = new Point(465, 55);
            cmbDCSkillLevel12.Name = "cmbDCSkillLevel12";
            cmbDCSkillLevel12.Size = new Size(36, 21);
            cmbDCSkillLevel12.TabIndex = 50;
            // 
            // cmbDCSkillLevel11
            // 
            cmbDCSkillLevel11.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel11.FormattingEnabled = true;
            cmbDCSkillLevel11.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel11.Location = new Point(465, 33);
            cmbDCSkillLevel11.Name = "cmbDCSkillLevel11";
            cmbDCSkillLevel11.Size = new Size(36, 21);
            cmbDCSkillLevel11.TabIndex = 49;
            // 
            // cmbDCSkillLevel10
            // 
            cmbDCSkillLevel10.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel10.FormattingEnabled = true;
            cmbDCSkillLevel10.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel10.Location = new Point(218, 191);
            cmbDCSkillLevel10.Name = "cmbDCSkillLevel10";
            cmbDCSkillLevel10.Size = new Size(36, 21);
            cmbDCSkillLevel10.TabIndex = 48;
            // 
            // cmbDCSkillLevel9
            // 
            cmbDCSkillLevel9.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel9.FormattingEnabled = true;
            cmbDCSkillLevel9.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel9.Location = new Point(465, 11);
            cmbDCSkillLevel9.Name = "cmbDCSkillLevel9";
            cmbDCSkillLevel9.Size = new Size(36, 21);
            cmbDCSkillLevel9.TabIndex = 47;
            // 
            // cmbDCSkillLevel8
            // 
            cmbDCSkillLevel8.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel8.FormattingEnabled = true;
            cmbDCSkillLevel8.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel8.Location = new Point(218, 169);
            cmbDCSkillLevel8.Name = "cmbDCSkillLevel8";
            cmbDCSkillLevel8.Size = new Size(36, 21);
            cmbDCSkillLevel8.TabIndex = 46;
            // 
            // cmbDCSkillLevel7
            // 
            cmbDCSkillLevel7.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel7.FormattingEnabled = true;
            cmbDCSkillLevel7.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel7.Location = new Point(218, 147);
            cmbDCSkillLevel7.Name = "cmbDCSkillLevel7";
            cmbDCSkillLevel7.Size = new Size(36, 21);
            cmbDCSkillLevel7.TabIndex = 45;
            // 
            // cmbDCSkillLevel6
            // 
            cmbDCSkillLevel6.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel6.FormattingEnabled = true;
            cmbDCSkillLevel6.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel6.Location = new Point(218, 124);
            cmbDCSkillLevel6.Name = "cmbDCSkillLevel6";
            cmbDCSkillLevel6.Size = new Size(36, 21);
            cmbDCSkillLevel6.TabIndex = 44;
            // 
            // cmbDCSkillLevel5
            // 
            cmbDCSkillLevel5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel5.FormattingEnabled = true;
            cmbDCSkillLevel5.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel5.Location = new Point(218, 102);
            cmbDCSkillLevel5.Name = "cmbDCSkillLevel5";
            cmbDCSkillLevel5.Size = new Size(36, 21);
            cmbDCSkillLevel5.TabIndex = 43;
            // 
            // cmbDCSkillLevel4
            // 
            cmbDCSkillLevel4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel4.FormattingEnabled = true;
            cmbDCSkillLevel4.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel4.Location = new Point(218, 80);
            cmbDCSkillLevel4.Name = "cmbDCSkillLevel4";
            cmbDCSkillLevel4.Size = new Size(36, 21);
            cmbDCSkillLevel4.TabIndex = 42;
            // 
            // cmbDCSkillLevel3
            // 
            cmbDCSkillLevel3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel3.FormattingEnabled = true;
            cmbDCSkillLevel3.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel3.Location = new Point(218, 57);
            cmbDCSkillLevel3.Name = "cmbDCSkillLevel3";
            cmbDCSkillLevel3.Size = new Size(36, 21);
            cmbDCSkillLevel3.TabIndex = 41;
            // 
            // cmbDCSkillLevel2
            // 
            cmbDCSkillLevel2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel2.FormattingEnabled = true;
            cmbDCSkillLevel2.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel2.Location = new Point(218, 35);
            cmbDCSkillLevel2.Name = "cmbDCSkillLevel2";
            cmbDCSkillLevel2.Size = new Size(36, 21);
            cmbDCSkillLevel2.TabIndex = 40;
            // 
            // cmbDCSkillLevel1
            // 
            cmbDCSkillLevel1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDCSkillLevel1.FormattingEnabled = true;
            cmbDCSkillLevel1.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbDCSkillLevel1.Location = new Point(218, 13);
            cmbDCSkillLevel1.Name = "cmbDCSkillLevel1";
            cmbDCSkillLevel1.Size = new Size(36, 21);
            cmbDCSkillLevel1.TabIndex = 39;
            // 
            // chkDC17
            // 
            chkDC17.AutoSize = true;
            chkDC17.Location = new Point(277, 172);
            chkDC17.Name = "chkDC17";
            chkDC17.Size = new Size(15, 14);
            chkDC17.TabIndex = 38;
            chkDC17.UseVisualStyleBackColor = true;
            // 
            // chkDC4
            // 
            chkDC4.AutoSize = true;
            chkDC4.Location = new Point(7, 83);
            chkDC4.Name = "chkDC4";
            chkDC4.Size = new Size(15, 14);
            chkDC4.TabIndex = 30;
            chkDC4.UseVisualStyleBackColor = true;
            // 
            // chkDC16
            // 
            chkDC16.AutoSize = true;
            chkDC16.Location = new Point(277, 150);
            chkDC16.Name = "chkDC16";
            chkDC16.Size = new Size(15, 14);
            chkDC16.TabIndex = 37;
            chkDC16.UseVisualStyleBackColor = true;
            // 
            // chkDC3
            // 
            chkDC3.AutoSize = true;
            chkDC3.Location = new Point(7, 60);
            chkDC3.Name = "chkDC3";
            chkDC3.Size = new Size(15, 14);
            chkDC3.TabIndex = 29;
            chkDC3.UseVisualStyleBackColor = true;
            // 
            // lblDatacore17
            // 
            lblDatacore17.Location = new Point(298, 173);
            lblDatacore17.Name = "lblDatacore17";
            lblDatacore17.Size = new Size(122, 13);
            lblDatacore17.TabIndex = 24;
            lblDatacore17.Text = "Rocket Science";
            // 
            // chkDC15
            // 
            chkDC15.AutoSize = true;
            chkDC15.Location = new Point(277, 127);
            chkDC15.Name = "chkDC15";
            chkDC15.Size = new Size(15, 14);
            chkDC15.TabIndex = 36;
            chkDC15.UseVisualStyleBackColor = true;
            // 
            // chkDC2
            // 
            chkDC2.AutoSize = true;
            chkDC2.Location = new Point(7, 38);
            chkDC2.Name = "chkDC2";
            chkDC2.Size = new Size(15, 14);
            chkDC2.TabIndex = 28;
            chkDC2.UseVisualStyleBackColor = true;
            // 
            // chkDC14
            // 
            chkDC14.AutoSize = true;
            chkDC14.Location = new Point(277, 105);
            chkDC14.Name = "chkDC14";
            chkDC14.Size = new Size(15, 14);
            chkDC14.TabIndex = 35;
            chkDC14.UseVisualStyleBackColor = true;
            // 
            // chkDC1
            // 
            chkDC1.AutoSize = true;
            chkDC1.Location = new Point(7, 16);
            chkDC1.Name = "chkDC1";
            chkDC1.Size = new Size(15, 14);
            chkDC1.TabIndex = 27;
            chkDC1.UseVisualStyleBackColor = true;
            // 
            // chkDC13
            // 
            chkDC13.AutoSize = true;
            chkDC13.Location = new Point(277, 83);
            chkDC13.Name = "chkDC13";
            chkDC13.Size = new Size(15, 14);
            chkDC13.TabIndex = 34;
            chkDC13.UseVisualStyleBackColor = true;
            // 
            // chkDC12
            // 
            chkDC12.AutoSize = true;
            chkDC12.Location = new Point(277, 60);
            chkDC12.Name = "chkDC12";
            chkDC12.Size = new Size(15, 14);
            chkDC12.TabIndex = 33;
            chkDC12.UseVisualStyleBackColor = true;
            // 
            // chkDC11
            // 
            chkDC11.AutoSize = true;
            chkDC11.Location = new Point(277, 38);
            chkDC11.Name = "chkDC11";
            chkDC11.Size = new Size(15, 14);
            chkDC11.TabIndex = 32;
            chkDC11.UseVisualStyleBackColor = true;
            // 
            // chkDC10
            // 
            chkDC10.AutoSize = true;
            chkDC10.Location = new Point(7, 194);
            chkDC10.Name = "chkDC10";
            chkDC10.Size = new Size(15, 14);
            chkDC10.TabIndex = 31;
            chkDC10.UseVisualStyleBackColor = true;
            // 
            // lblDatacore16
            // 
            lblDatacore16.Location = new Point(298, 151);
            lblDatacore16.Name = "lblDatacore16";
            lblDatacore16.Size = new Size(122, 13);
            lblDatacore16.TabIndex = 20;
            lblDatacore16.Text = "Quantum Physics";
            // 
            // lblDatacore4
            // 
            lblDatacore4.Location = new Point(28, 84);
            lblDatacore4.Name = "lblDatacore4";
            lblDatacore4.Size = new Size(158, 13);
            lblDatacore4.TabIndex = 4;
            lblDatacore4.Text = "Minmatar Starship Engineering";
            // 
            // lblDatacore15
            // 
            lblDatacore15.Location = new Point(298, 128);
            lblDatacore15.Name = "lblDatacore15";
            lblDatacore15.Size = new Size(122, 13);
            lblDatacore15.TabIndex = 19;
            lblDatacore15.Text = "Plasma Physics";
            // 
            // chkDC9
            // 
            chkDC9.AutoSize = true;
            chkDC9.Location = new Point(277, 16);
            chkDC9.Name = "chkDC9";
            chkDC9.Size = new Size(15, 14);
            chkDC9.TabIndex = 30;
            chkDC9.UseVisualStyleBackColor = true;
            // 
            // lblDatacore14
            // 
            lblDatacore14.Location = new Point(298, 106);
            lblDatacore14.Name = "lblDatacore14";
            lblDatacore14.Size = new Size(122, 13);
            lblDatacore14.TabIndex = 18;
            lblDatacore14.Text = "Nuclear Physics";
            // 
            // lblDatacore3
            // 
            lblDatacore3.Location = new Point(28, 61);
            lblDatacore3.Name = "lblDatacore3";
            lblDatacore3.Size = new Size(158, 13);
            lblDatacore3.TabIndex = 3;
            lblDatacore3.Text = "Gallente Starship Engineering";
            // 
            // chkDC8
            // 
            chkDC8.AutoSize = true;
            chkDC8.Location = new Point(7, 172);
            chkDC8.Name = "chkDC8";
            chkDC8.Size = new Size(15, 14);
            chkDC8.TabIndex = 29;
            chkDC8.UseVisualStyleBackColor = true;
            // 
            // lblDatacore13
            // 
            lblDatacore13.Location = new Point(298, 84);
            lblDatacore13.Name = "lblDatacore13";
            lblDatacore13.Size = new Size(122, 13);
            lblDatacore13.TabIndex = 17;
            lblDatacore13.Text = "Nanite Engineering";
            // 
            // lblDatacore2
            // 
            lblDatacore2.Location = new Point(28, 39);
            lblDatacore2.Name = "lblDatacore2";
            lblDatacore2.Size = new Size(158, 13);
            lblDatacore2.TabIndex = 2;
            lblDatacore2.Text = "Caldari Starship Engineering";
            // 
            // chkDC7
            // 
            chkDC7.AutoSize = true;
            chkDC7.Location = new Point(7, 150);
            chkDC7.Name = "chkDC7";
            chkDC7.Size = new Size(15, 14);
            chkDC7.TabIndex = 28;
            chkDC7.UseVisualStyleBackColor = true;
            // 
            // chkDC6
            // 
            chkDC6.AutoSize = true;
            chkDC6.Location = new Point(7, 127);
            chkDC6.Name = "chkDC6";
            chkDC6.Size = new Size(15, 14);
            chkDC6.TabIndex = 27;
            chkDC6.UseVisualStyleBackColor = true;
            // 
            // lblDatacore1
            // 
            lblDatacore1.Location = new Point(28, 17);
            lblDatacore1.Name = "lblDatacore1";
            lblDatacore1.Size = new Size(158, 13);
            lblDatacore1.TabIndex = 1;
            lblDatacore1.Text = "Amarr Starship Engineering";
            // 
            // chkDC5
            // 
            chkDC5.AutoSize = true;
            chkDC5.Location = new Point(7, 105);
            chkDC5.Name = "chkDC5";
            chkDC5.Size = new Size(15, 14);
            chkDC5.TabIndex = 26;
            chkDC5.UseVisualStyleBackColor = true;
            // 
            // lblDatacore5
            // 
            lblDatacore5.Location = new Point(28, 106);
            lblDatacore5.Name = "lblDatacore5";
            lblDatacore5.Size = new Size(158, 13);
            lblDatacore5.TabIndex = 1;
            lblDatacore5.Text = "Electromagnetic Physics";
            // 
            // lblDatacore6
            // 
            lblDatacore6.Location = new Point(28, 128);
            lblDatacore6.Name = "lblDatacore6";
            lblDatacore6.Size = new Size(158, 13);
            lblDatacore6.TabIndex = 2;
            lblDatacore6.Text = "Electronic Engineering";
            // 
            // lblDatacore7
            // 
            lblDatacore7.Location = new Point(28, 151);
            lblDatacore7.Name = "lblDatacore7";
            lblDatacore7.Size = new Size(158, 13);
            lblDatacore7.TabIndex = 3;
            lblDatacore7.Text = "Graviton Physics";
            // 
            // lblDatacore8
            // 
            lblDatacore8.Location = new Point(28, 173);
            lblDatacore8.Name = "lblDatacore8";
            lblDatacore8.Size = new Size(158, 13);
            lblDatacore8.TabIndex = 4;
            lblDatacore8.Text = "High Energy Physics";
            // 
            // lblDatacore12
            // 
            lblDatacore12.Location = new Point(298, 61);
            lblDatacore12.Name = "lblDatacore12";
            lblDatacore12.Size = new Size(122, 13);
            lblDatacore12.TabIndex = 12;
            lblDatacore12.Text = "Molecular Engineering";
            // 
            // lblDatacore11
            // 
            lblDatacore11.Location = new Point(298, 39);
            lblDatacore11.Name = "lblDatacore11";
            lblDatacore11.Size = new Size(122, 13);
            lblDatacore11.TabIndex = 11;
            lblDatacore11.Text = "Mechanical Engineering";
            // 
            // lblDatacore10
            // 
            lblDatacore10.Location = new Point(28, 195);
            lblDatacore10.Name = "lblDatacore10";
            lblDatacore10.Size = new Size(158, 13);
            lblDatacore10.TabIndex = 10;
            lblDatacore10.Text = "Laser Physics";
            // 
            // lblDatacore9
            // 
            lblDatacore9.Location = new Point(298, 17);
            lblDatacore9.Name = "lblDatacore9";
            lblDatacore9.Size = new Size(122, 13);
            lblDatacore9.TabIndex = 9;
            lblDatacore9.Text = "Hydromagnetic Physics";
            // 
            // gbDCCodes
            // 
            gbDCCodes.Controls.Add(lblDCColors);
            gbDCCodes.Controls.Add(lblDCRedText);
            gbDCCodes.Controls.Add(lblDCOrangeText);
            gbDCCodes.Controls.Add(lblDCGrayText);
            gbDCCodes.Controls.Add(lblDCBlueText);
            gbDCCodes.Controls.Add(lblDCGreenBackColor);
            gbDCCodes.Location = new Point(277, 187);
            gbDCCodes.Name = "gbDCCodes";
            gbDCCodes.Size = new Size(224, 30);
            gbDCCodes.TabIndex = 56;
            gbDCCodes.TabStop = false;
            // 
            // lblDCColors
            // 
            lblDCColors.AutoSize = true;
            lblDCColors.Location = new Point(8, 11);
            lblDCColors.Name = "lblDCColors";
            lblDCColors.Size = new Size(63, 13);
            lblDCColors.TabIndex = 5;
            lblDCColors.Text = "Text Colors:";
            lblDCColors.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDCRedText
            // 
            lblDCRedText.BorderStyle = BorderStyle.FixedSingle;
            lblDCRedText.ForeColor = Color.Red;
            lblDCRedText.Location = new Point(200, 10);
            lblDCRedText.Name = "lblDCRedText";
            lblDCRedText.Size = new Size(15, 15);
            lblDCRedText.TabIndex = 4;
            lblDCRedText.Text = "T";
            lblDCRedText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDCOrangeText
            // 
            lblDCOrangeText.BorderStyle = BorderStyle.FixedSingle;
            lblDCOrangeText.ForeColor = Color.Orange;
            lblDCOrangeText.Location = new Point(170, 10);
            lblDCOrangeText.Name = "lblDCOrangeText";
            lblDCOrangeText.Size = new Size(15, 15);
            lblDCOrangeText.TabIndex = 3;
            lblDCOrangeText.Text = "T";
            lblDCOrangeText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDCGrayText
            // 
            lblDCGrayText.BorderStyle = BorderStyle.FixedSingle;
            lblDCGrayText.ForeColor = Color.Gray;
            lblDCGrayText.Location = new Point(140, 10);
            lblDCGrayText.Name = "lblDCGrayText";
            lblDCGrayText.Size = new Size(15, 15);
            lblDCGrayText.TabIndex = 2;
            lblDCGrayText.Text = "T";
            lblDCGrayText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDCBlueText
            // 
            lblDCBlueText.BorderStyle = BorderStyle.FixedSingle;
            lblDCBlueText.ForeColor = Color.Blue;
            lblDCBlueText.Location = new Point(110, 10);
            lblDCBlueText.Name = "lblDCBlueText";
            lblDCBlueText.Size = new Size(15, 15);
            lblDCBlueText.TabIndex = 1;
            lblDCBlueText.Text = "T";
            lblDCBlueText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDCGreenBackColor
            // 
            lblDCGreenBackColor.BackColor = Color.LightGreen;
            lblDCGreenBackColor.BorderStyle = BorderStyle.FixedSingle;
            lblDCGreenBackColor.Location = new Point(80, 10);
            lblDCGreenBackColor.Name = "lblDCGreenBackColor";
            lblDCGreenBackColor.Size = new Size(15, 15);
            lblDCGreenBackColor.TabIndex = 0;
            lblDCGreenBackColor.Text = "T";
            lblDCGreenBackColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbDCCorpMinmatar
            // 
            gbDCCorpMinmatar.Controls.Add(lblDCCorp13);
            gbDCCorpMinmatar.Controls.Add(chkDCCorp13);
            gbDCCorpMinmatar.Controls.Add(txtDCStanding13);
            gbDCCorpMinmatar.Controls.Add(lblDCCorpLabel4);
            gbDCCorpMinmatar.Controls.Add(lblDCCorp10);
            gbDCCorpMinmatar.Controls.Add(lblDCCorp11);
            gbDCCorpMinmatar.Controls.Add(lblDCCorp12);
            gbDCCorpMinmatar.Controls.Add(chkDCCorp10);
            gbDCCorpMinmatar.Controls.Add(chkDCCorp11);
            gbDCCorpMinmatar.Controls.Add(chkDCCorp12);
            gbDCCorpMinmatar.Controls.Add(txtDCStanding10);
            gbDCCorpMinmatar.Controls.Add(txtDCStanding11);
            gbDCCorpMinmatar.Controls.Add(txtDCStanding12);
            gbDCCorpMinmatar.Controls.Add(lblDCStanding4);
            gbDCCorpMinmatar.Location = new Point(746, 119);
            gbDCCorpMinmatar.Name = "gbDCCorpMinmatar";
            gbDCCorpMinmatar.Size = new Size(228, 122);
            gbDCCorpMinmatar.TabIndex = 64;
            gbDCCorpMinmatar.TabStop = false;
            gbDCCorpMinmatar.Text = "Minmatar Republic/Thukker Tribe/Khanid";
            // 
            // lblDCCorp13
            // 
            lblDCCorp13.Location = new Point(33, 101);
            lblDCCorp13.Name = "lblDCCorp13";
            lblDCCorp13.Size = new Size(139, 13);
            lblDCCorp13.TabIndex = 46;
            lblDCCorp13.Text = "Thukker Mix";
            // 
            // chkDCCorp13
            // 
            chkDCCorp13.AutoSize = true;
            chkDCCorp13.Location = new Point(12, 100);
            chkDCCorp13.Name = "chkDCCorp13";
            chkDCCorp13.Size = new Size(15, 14);
            chkDCCorp13.TabIndex = 47;
            chkDCCorp13.UseVisualStyleBackColor = true;
            // 
            // txtDCStanding13
            // 
            txtDCStanding13.Location = new Point(176, 97);
            txtDCStanding13.Name = "txtDCStanding13";
            txtDCStanding13.Size = new Size(35, 20);
            txtDCStanding13.TabIndex = 48;
            txtDCStanding13.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDCCorpLabel4
            // 
            lblDCCorpLabel4.AutoSize = true;
            lblDCCorpLabel4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDCCorpLabel4.Location = new Point(33, 16);
            lblDCCorpLabel4.Name = "lblDCCorpLabel4";
            lblDCCorpLabel4.Size = new Size(72, 13);
            lblDCCorpLabel4.TabIndex = 45;
            lblDCCorpLabel4.Text = "Corporation";
            lblDCCorpLabel4.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDCCorp10
            // 
            lblDCCorp10.Location = new Point(33, 35);
            lblDCCorp10.Name = "lblDCCorp10";
            lblDCCorp10.Size = new Size(139, 13);
            lblDCCorp10.TabIndex = 1;
            lblDCCorp10.Text = "Boundless Creation";
            // 
            // lblDCCorp11
            // 
            lblDCCorp11.Location = new Point(33, 57);
            lblDCCorp11.Name = "lblDCCorp11";
            lblDCCorp11.Size = new Size(139, 13);
            lblDCCorp11.TabIndex = 2;
            lblDCCorp11.Text = "Core Complexion Inc.";
            // 
            // lblDCCorp12
            // 
            lblDCCorp12.Location = new Point(33, 79);
            lblDCCorp12.Name = "lblDCCorp12";
            lblDCCorp12.Size = new Size(139, 13);
            lblDCCorp12.TabIndex = 3;
            lblDCCorp12.Text = "Khanid Innovation";
            // 
            // chkDCCorp10
            // 
            chkDCCorp10.AutoSize = true;
            chkDCCorp10.Location = new Point(12, 34);
            chkDCCorp10.Name = "chkDCCorp10";
            chkDCCorp10.Size = new Size(15, 14);
            chkDCCorp10.TabIndex = 27;
            chkDCCorp10.UseVisualStyleBackColor = true;
            // 
            // chkDCCorp11
            // 
            chkDCCorp11.AutoSize = true;
            chkDCCorp11.Location = new Point(12, 56);
            chkDCCorp11.Name = "chkDCCorp11";
            chkDCCorp11.Size = new Size(15, 14);
            chkDCCorp11.TabIndex = 28;
            chkDCCorp11.UseVisualStyleBackColor = true;
            // 
            // chkDCCorp12
            // 
            chkDCCorp12.AutoSize = true;
            chkDCCorp12.Location = new Point(12, 78);
            chkDCCorp12.Name = "chkDCCorp12";
            chkDCCorp12.Size = new Size(15, 14);
            chkDCCorp12.TabIndex = 29;
            chkDCCorp12.UseVisualStyleBackColor = true;
            // 
            // txtDCStanding10
            // 
            txtDCStanding10.Location = new Point(176, 31);
            txtDCStanding10.Name = "txtDCStanding10";
            txtDCStanding10.Size = new Size(35, 20);
            txtDCStanding10.TabIndex = 39;
            txtDCStanding10.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDCStanding11
            // 
            txtDCStanding11.Location = new Point(176, 53);
            txtDCStanding11.Name = "txtDCStanding11";
            txtDCStanding11.Size = new Size(35, 20);
            txtDCStanding11.TabIndex = 40;
            txtDCStanding11.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDCStanding12
            // 
            txtDCStanding12.Location = new Point(176, 75);
            txtDCStanding12.Name = "txtDCStanding12";
            txtDCStanding12.Size = new Size(35, 20);
            txtDCStanding12.TabIndex = 41;
            txtDCStanding12.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDCStanding4
            // 
            lblDCStanding4.AutoSize = true;
            lblDCStanding4.Location = new Point(169, 16);
            lblDCStanding4.Name = "lblDCStanding4";
            lblDCStanding4.Size = new Size(49, 13);
            lblDCStanding4.TabIndex = 44;
            lblDCStanding4.Text = "Standing";
            lblDCStanding4.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnDCExporttoClip
            // 
            btnDCExporttoClip.Location = new Point(980, 206);
            btnDCExporttoClip.Name = "btnDCExporttoClip";
            btnDCExporttoClip.Size = new Size(138, 35);
            btnDCExporttoClip.TabIndex = 68;
            btnDCExporttoClip.Text = "Copy Selected to Clipboard";
            btnDCExporttoClip.UseVisualStyleBackColor = true;
            // 
            // gbDCCorpAmarr
            // 
            gbDCCorpAmarr.Controls.Add(lblDCCorpLabel1);
            gbDCCorpAmarr.Controls.Add(lblDCCorp1);
            gbDCCorpAmarr.Controls.Add(lblDCCorp2);
            gbDCCorpAmarr.Controls.Add(lblDCCorp3);
            gbDCCorpAmarr.Controls.Add(chkDCCorp1);
            gbDCCorpAmarr.Controls.Add(chkDCCorp2);
            gbDCCorpAmarr.Controls.Add(chkDCCorp3);
            gbDCCorpAmarr.Controls.Add(txtDCStanding1);
            gbDCCorpAmarr.Controls.Add(txtDCStanding2);
            gbDCCorpAmarr.Controls.Add(txtDCStanding3);
            gbDCCorpAmarr.Controls.Add(lblDCStanding1);
            gbDCCorpAmarr.Location = new Point(518, 12);
            gbDCCorpAmarr.Name = "gbDCCorpAmarr";
            gbDCCorpAmarr.Size = new Size(222, 100);
            gbDCCorpAmarr.TabIndex = 63;
            gbDCCorpAmarr.TabStop = false;
            gbDCCorpAmarr.Text = "Amarr Empire/Ammatar Mandate";
            // 
            // lblDCCorpLabel1
            // 
            lblDCCorpLabel1.AutoSize = true;
            lblDCCorpLabel1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDCCorpLabel1.Location = new Point(33, 15);
            lblDCCorpLabel1.Name = "lblDCCorpLabel1";
            lblDCCorpLabel1.Size = new Size(72, 13);
            lblDCCorpLabel1.TabIndex = 45;
            lblDCCorpLabel1.Text = "Corporation";
            lblDCCorpLabel1.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDCCorp1
            // 
            lblDCCorp1.Location = new Point(33, 34);
            lblDCCorp1.Name = "lblDCCorp1";
            lblDCCorp1.Size = new Size(139, 13);
            lblDCCorp1.TabIndex = 1;
            lblDCCorp1.Text = "Carthum Conglomerate";
            // 
            // lblDCCorp2
            // 
            lblDCCorp2.Location = new Point(33, 56);
            lblDCCorp2.Name = "lblDCCorp2";
            lblDCCorp2.Size = new Size(139, 13);
            lblDCCorp2.TabIndex = 2;
            lblDCCorp2.Text = "Viziam";
            // 
            // lblDCCorp3
            // 
            lblDCCorp3.Location = new Point(33, 78);
            lblDCCorp3.Name = "lblDCCorp3";
            lblDCCorp3.Size = new Size(139, 13);
            lblDCCorp3.TabIndex = 3;
            lblDCCorp3.Text = "Nefantar Miner Association";
            // 
            // chkDCCorp1
            // 
            chkDCCorp1.AutoSize = true;
            chkDCCorp1.Location = new Point(12, 33);
            chkDCCorp1.Name = "chkDCCorp1";
            chkDCCorp1.Size = new Size(15, 14);
            chkDCCorp1.TabIndex = 27;
            chkDCCorp1.UseVisualStyleBackColor = true;
            // 
            // chkDCCorp2
            // 
            chkDCCorp2.AutoSize = true;
            chkDCCorp2.Location = new Point(12, 55);
            chkDCCorp2.Name = "chkDCCorp2";
            chkDCCorp2.Size = new Size(15, 14);
            chkDCCorp2.TabIndex = 28;
            chkDCCorp2.UseVisualStyleBackColor = true;
            // 
            // chkDCCorp3
            // 
            chkDCCorp3.AutoSize = true;
            chkDCCorp3.Location = new Point(12, 77);
            chkDCCorp3.Name = "chkDCCorp3";
            chkDCCorp3.Size = new Size(15, 14);
            chkDCCorp3.TabIndex = 29;
            chkDCCorp3.UseVisualStyleBackColor = true;
            // 
            // txtDCStanding1
            // 
            txtDCStanding1.Location = new Point(174, 30);
            txtDCStanding1.Name = "txtDCStanding1";
            txtDCStanding1.Size = new Size(35, 20);
            txtDCStanding1.TabIndex = 39;
            txtDCStanding1.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDCStanding2
            // 
            txtDCStanding2.Location = new Point(174, 52);
            txtDCStanding2.Name = "txtDCStanding2";
            txtDCStanding2.Size = new Size(35, 20);
            txtDCStanding2.TabIndex = 40;
            txtDCStanding2.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDCStanding3
            // 
            txtDCStanding3.Location = new Point(174, 74);
            txtDCStanding3.Name = "txtDCStanding3";
            txtDCStanding3.Size = new Size(35, 20);
            txtDCStanding3.TabIndex = 41;
            txtDCStanding3.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDCStanding1
            // 
            lblDCStanding1.AutoSize = true;
            lblDCStanding1.Location = new Point(165, 14);
            lblDCStanding1.Name = "lblDCStanding1";
            lblDCStanding1.Size = new Size(49, 13);
            lblDCStanding1.TabIndex = 44;
            lblDCStanding1.Text = "Standing";
            lblDCStanding1.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnDCReset
            // 
            btnDCReset.Location = new Point(980, 146);
            btnDCReset.Name = "btnDCReset";
            btnDCReset.Size = new Size(138, 30);
            btnDCReset.TabIndex = 67;
            btnDCReset.Text = "Reset";
            btnDCReset.UseVisualStyleBackColor = true;
            // 
            // gbDCCorpsCaldari
            // 
            gbDCCorpsCaldari.Controls.Add(lblDCCorpLabel2);
            gbDCCorpsCaldari.Controls.Add(lblDCCorp4);
            gbDCCorpsCaldari.Controls.Add(lblDCCorp5);
            gbDCCorpsCaldari.Controls.Add(lblDCCorp6);
            gbDCCorpsCaldari.Controls.Add(chkDCCorp4);
            gbDCCorpsCaldari.Controls.Add(chkDCCorp5);
            gbDCCorpsCaldari.Controls.Add(chkDCCorp6);
            gbDCCorpsCaldari.Controls.Add(txtDCStanding4);
            gbDCCorpsCaldari.Controls.Add(txtDCStanding5);
            gbDCCorpsCaldari.Controls.Add(txtDCStanding6);
            gbDCCorpsCaldari.Controls.Add(lblDCStanding2);
            gbDCCorpsCaldari.Location = new Point(518, 114);
            gbDCCorpsCaldari.Name = "gbDCCorpsCaldari";
            gbDCCorpsCaldari.Size = new Size(222, 100);
            gbDCCorpsCaldari.TabIndex = 62;
            gbDCCorpsCaldari.TabStop = false;
            gbDCCorpsCaldari.Text = "Caldari State";
            // 
            // lblDCCorpLabel2
            // 
            lblDCCorpLabel2.AutoSize = true;
            lblDCCorpLabel2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDCCorpLabel2.Location = new Point(33, 16);
            lblDCCorpLabel2.Name = "lblDCCorpLabel2";
            lblDCCorpLabel2.Size = new Size(72, 13);
            lblDCCorpLabel2.TabIndex = 45;
            lblDCCorpLabel2.Text = "Corporation";
            lblDCCorpLabel2.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDCCorp4
            // 
            lblDCCorp4.Location = new Point(33, 34);
            lblDCCorp4.Name = "lblDCCorp4";
            lblDCCorp4.Size = new Size(131, 13);
            lblDCCorp4.TabIndex = 1;
            lblDCCorp4.Text = "Ishukone Corporation";
            // 
            // lblDCCorp5
            // 
            lblDCCorp5.Location = new Point(33, 56);
            lblDCCorp5.Name = "lblDCCorp5";
            lblDCCorp5.Size = new Size(131, 13);
            lblDCCorp5.TabIndex = 2;
            lblDCCorp5.Text = "Kaalakiota Corporation";
            // 
            // lblDCCorp6
            // 
            lblDCCorp6.Location = new Point(33, 78);
            lblDCCorp6.Name = "lblDCCorp6";
            lblDCCorp6.Size = new Size(131, 13);
            lblDCCorp6.TabIndex = 3;
            lblDCCorp6.Text = "Lai Dai Corporation";
            // 
            // chkDCCorp4
            // 
            chkDCCorp4.AutoSize = true;
            chkDCCorp4.Location = new Point(10, 33);
            chkDCCorp4.Name = "chkDCCorp4";
            chkDCCorp4.Size = new Size(15, 14);
            chkDCCorp4.TabIndex = 27;
            chkDCCorp4.UseVisualStyleBackColor = true;
            // 
            // chkDCCorp5
            // 
            chkDCCorp5.AutoSize = true;
            chkDCCorp5.Location = new Point(10, 55);
            chkDCCorp5.Name = "chkDCCorp5";
            chkDCCorp5.Size = new Size(15, 14);
            chkDCCorp5.TabIndex = 28;
            chkDCCorp5.UseVisualStyleBackColor = true;
            // 
            // chkDCCorp6
            // 
            chkDCCorp6.AutoSize = true;
            chkDCCorp6.Location = new Point(10, 77);
            chkDCCorp6.Name = "chkDCCorp6";
            chkDCCorp6.Size = new Size(15, 14);
            chkDCCorp6.TabIndex = 29;
            chkDCCorp6.UseVisualStyleBackColor = true;
            // 
            // txtDCStanding4
            // 
            txtDCStanding4.Location = new Point(174, 32);
            txtDCStanding4.Name = "txtDCStanding4";
            txtDCStanding4.Size = new Size(35, 20);
            txtDCStanding4.TabIndex = 39;
            txtDCStanding4.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDCStanding5
            // 
            txtDCStanding5.Location = new Point(174, 54);
            txtDCStanding5.Name = "txtDCStanding5";
            txtDCStanding5.Size = new Size(35, 20);
            txtDCStanding5.TabIndex = 40;
            txtDCStanding5.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDCStanding6
            // 
            txtDCStanding6.Location = new Point(174, 76);
            txtDCStanding6.Name = "txtDCStanding6";
            txtDCStanding6.Size = new Size(35, 20);
            txtDCStanding6.TabIndex = 41;
            txtDCStanding6.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDCStanding2
            // 
            lblDCStanding2.AutoSize = true;
            lblDCStanding2.Location = new Point(163, 16);
            lblDCStanding2.Name = "lblDCStanding2";
            lblDCStanding2.Size = new Size(49, 13);
            lblDCStanding2.TabIndex = 44;
            lblDCStanding2.Text = "Standing";
            lblDCStanding2.TextAlign = ContentAlignment.TopCenter;
            // 
            // gbDCCorpsGallente
            // 
            gbDCCorpsGallente.Controls.Add(lblDCCorpLabel3);
            gbDCCorpsGallente.Controls.Add(lblDCCorp7);
            gbDCCorpsGallente.Controls.Add(lblDCCorp8);
            gbDCCorpsGallente.Controls.Add(lblDCCorp9);
            gbDCCorpsGallente.Controls.Add(chkDCCorp7);
            gbDCCorpsGallente.Controls.Add(chkDCCorp8);
            gbDCCorpsGallente.Controls.Add(chkDCCorp9);
            gbDCCorpsGallente.Controls.Add(txtDCStanding7);
            gbDCCorpsGallente.Controls.Add(txtDCStanding8);
            gbDCCorpsGallente.Controls.Add(txtDCStanding9);
            gbDCCorpsGallente.Controls.Add(lblDCStanding3);
            gbDCCorpsGallente.Location = new Point(746, 12);
            gbDCCorpsGallente.Name = "gbDCCorpsGallente";
            gbDCCorpsGallente.Size = new Size(226, 100);
            gbDCCorpsGallente.TabIndex = 61;
            gbDCCorpsGallente.TabStop = false;
            gbDCCorpsGallente.Text = "Gallente Federation";
            // 
            // lblDCCorpLabel3
            // 
            lblDCCorpLabel3.AutoSize = true;
            lblDCCorpLabel3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDCCorpLabel3.Location = new Point(33, 16);
            lblDCCorpLabel3.Name = "lblDCCorpLabel3";
            lblDCCorpLabel3.Size = new Size(72, 13);
            lblDCCorpLabel3.TabIndex = 45;
            lblDCCorpLabel3.Text = "Corporation";
            lblDCCorpLabel3.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDCCorp7
            // 
            lblDCCorp7.Location = new Point(33, 35);
            lblDCCorp7.Name = "lblDCCorp7";
            lblDCCorp7.Size = new Size(139, 13);
            lblDCCorp7.TabIndex = 1;
            lblDCCorp7.Text = "CreoDron";
            // 
            // lblDCCorp8
            // 
            lblDCCorp8.Location = new Point(33, 57);
            lblDCCorp8.Name = "lblDCCorp8";
            lblDCCorp8.Size = new Size(139, 13);
            lblDCCorp8.TabIndex = 2;
            lblDCCorp8.Text = "Duvolle Laboratories";
            // 
            // lblDCCorp9
            // 
            lblDCCorp9.Location = new Point(33, 79);
            lblDCCorp9.Name = "lblDCCorp9";
            lblDCCorp9.Size = new Size(139, 13);
            lblDCCorp9.TabIndex = 3;
            lblDCCorp9.Text = "Roden Shipyards";
            // 
            // chkDCCorp7
            // 
            chkDCCorp7.AutoSize = true;
            chkDCCorp7.Location = new Point(12, 34);
            chkDCCorp7.Name = "chkDCCorp7";
            chkDCCorp7.Size = new Size(15, 14);
            chkDCCorp7.TabIndex = 27;
            chkDCCorp7.UseVisualStyleBackColor = true;
            // 
            // chkDCCorp8
            // 
            chkDCCorp8.AutoSize = true;
            chkDCCorp8.Location = new Point(12, 56);
            chkDCCorp8.Name = "chkDCCorp8";
            chkDCCorp8.Size = new Size(15, 14);
            chkDCCorp8.TabIndex = 28;
            chkDCCorp8.UseVisualStyleBackColor = true;
            // 
            // chkDCCorp9
            // 
            chkDCCorp9.AutoSize = true;
            chkDCCorp9.Location = new Point(12, 78);
            chkDCCorp9.Name = "chkDCCorp9";
            chkDCCorp9.Size = new Size(15, 14);
            chkDCCorp9.TabIndex = 29;
            chkDCCorp9.UseVisualStyleBackColor = true;
            // 
            // txtDCStanding7
            // 
            txtDCStanding7.Location = new Point(178, 31);
            txtDCStanding7.Name = "txtDCStanding7";
            txtDCStanding7.Size = new Size(35, 20);
            txtDCStanding7.TabIndex = 39;
            txtDCStanding7.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDCStanding8
            // 
            txtDCStanding8.Location = new Point(178, 53);
            txtDCStanding8.Name = "txtDCStanding8";
            txtDCStanding8.Size = new Size(35, 20);
            txtDCStanding8.TabIndex = 40;
            txtDCStanding8.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDCStanding9
            // 
            txtDCStanding9.Location = new Point(178, 75);
            txtDCStanding9.Name = "txtDCStanding9";
            txtDCStanding9.Size = new Size(35, 20);
            txtDCStanding9.TabIndex = 41;
            txtDCStanding9.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDCStanding3
            // 
            lblDCStanding3.AutoSize = true;
            lblDCStanding3.Location = new Point(169, 15);
            lblDCStanding3.Name = "lblDCStanding3";
            lblDCStanding3.Size = new Size(49, 13);
            lblDCStanding3.TabIndex = 44;
            lblDCStanding3.Text = "Standing";
            lblDCStanding3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnDCRefresh
            // 
            btnDCRefresh.Location = new Point(980, 116);
            btnDCRefresh.Name = "btnDCRefresh";
            btnDCRefresh.Size = new Size(138, 30);
            btnDCRefresh.TabIndex = 66;
            btnDCRefresh.Text = "Refresh";
            btnDCRefresh.UseVisualStyleBackColor = true;
            // 
            // tabManufacturing
            // 
            tabManufacturing.Controls.Add(lstManufacturing);
            tabManufacturing.Controls.Add(gbCalcBPSelectOptions);
            tabManufacturing.Location = new Point(4, 22);
            tabManufacturing.Name = "tabManufacturing";
            tabManufacturing.Size = new Size(1137, 615);
            tabManufacturing.TabIndex = 2;
            tabManufacturing.Text = "Manufacturing List";
            tabManufacturing.UseVisualStyleBackColor = true;
            // 
            // lstManufacturing
            // 
            lstManufacturing.AllowColumnReorder = true;
            lstManufacturing.ContextMenuStrip = ListOptionsMenu;
            lstManufacturing.FullRowSelect = true;
            lstManufacturing.GridLines = true;
            lstManufacturing.HideSelection = false;
            lstManufacturing.Location = new Point(8, 7);
            lstManufacturing.Name = "lstManufacturing";
            lstManufacturing.OwnerDraw = true;
            lstManufacturing.Size = new Size(1121, 300);
            lstManufacturing.TabIndex = 1;
            lstManufacturing.UseCompatibleStateImageBehavior = false;
            lstManufacturing.View = View.Details;
            // 
            // gbCalcBPSelectOptions
            // 
            gbCalcBPSelectOptions.Controls.Add(gbCalcIgnoreinCalcs);
            gbCalcBPSelectOptions.Controls.Add(gbIncludeTaxesFees);
            gbCalcBPSelectOptions.Controls.Add(gbCalcSellExessItems);
            gbCalcBPSelectOptions.Controls.Add(chkCalcNPCBPOs);
            gbCalcBPSelectOptions.Controls.Add(btnCalcShowAssets);
            gbCalcBPSelectOptions.Controls.Add(gbCalcIncludeItems);
            gbCalcBPSelectOptions.Controls.Add(gbCalcMarketFilters);
            gbCalcBPSelectOptions.Controls.Add(btnCalcCalculate);
            gbCalcBPSelectOptions.Controls.Add(btnCalcSelectColumns);
            gbCalcBPSelectOptions.Controls.Add(gbCalcSizeLimit);
            gbCalcBPSelectOptions.Controls.Add(gbCalcProdLines);
            gbCalcBPSelectOptions.Controls.Add(gbCalcCompareType);
            gbCalcBPSelectOptions.Controls.Add(gbCalcTextColors);
            gbCalcBPSelectOptions.Controls.Add(gbCalcInvention);
            gbCalcBPSelectOptions.Controls.Add(gbCalcBPRace);
            gbCalcBPSelectOptions.Controls.Add(gbTempMEPE);
            gbCalcBPSelectOptions.Controls.Add(tabCalcFacilities);
            gbCalcBPSelectOptions.Controls.Add(gbCalcFilter);
            gbCalcBPSelectOptions.Controls.Add(gbCalcBPTech);
            gbCalcBPSelectOptions.Controls.Add(gbCalcIncludeOwned);
            gbCalcBPSelectOptions.Controls.Add(btnCalcSaveSettings);
            gbCalcBPSelectOptions.Controls.Add(btnCalcExportList);
            gbCalcBPSelectOptions.Controls.Add(btnCalcPreview);
            gbCalcBPSelectOptions.Controls.Add(btnCalcReset);
            gbCalcBPSelectOptions.Controls.Add(gbCalcTextFilter);
            gbCalcBPSelectOptions.Controls.Add(gbCalcBPType);
            gbCalcBPSelectOptions.Controls.Add(gbCalcBPSelect);
            gbCalcBPSelectOptions.Controls.Add(gbCalcRelics);
            gbCalcBPSelectOptions.Location = new Point(8, 308);
            gbCalcBPSelectOptions.Name = "gbCalcBPSelectOptions";
            gbCalcBPSelectOptions.Size = new Size(1121, 300);
            gbCalcBPSelectOptions.TabIndex = 0;
            gbCalcBPSelectOptions.TabStop = false;
            gbCalcBPSelectOptions.Text = "Blueprint Filters:";
            // 
            // gbCalcIgnoreinCalcs
            // 
            gbCalcIgnoreinCalcs.Controls.Add(chkCalcIgnoreMinerals);
            gbCalcIgnoreinCalcs.Controls.Add(chkCalcIgnoreT1Item);
            gbCalcIgnoreinCalcs.Controls.Add(chkCalcIgnoreInvention);
            gbCalcIgnoreinCalcs.Location = new Point(859, 199);
            gbCalcIgnoreinCalcs.Name = "gbCalcIgnoreinCalcs";
            gbCalcIgnoreinCalcs.Size = new Size(156, 56);
            gbCalcIgnoreinCalcs.TabIndex = 19;
            gbCalcIgnoreinCalcs.TabStop = false;
            gbCalcIgnoreinCalcs.Text = "Ignore in Calculations:";
            // 
            // chkCalcIgnoreMinerals
            // 
            chkCalcIgnoreMinerals.AutoSize = true;
            chkCalcIgnoreMinerals.CheckAlign = ContentAlignment.BottomLeft;
            chkCalcIgnoreMinerals.Location = new Point(86, 16);
            chkCalcIgnoreMinerals.Name = "chkCalcIgnoreMinerals";
            chkCalcIgnoreMinerals.Size = new Size(65, 17);
            chkCalcIgnoreMinerals.TabIndex = 1;
            chkCalcIgnoreMinerals.Text = "Minerals";
            chkCalcIgnoreMinerals.UseVisualStyleBackColor = true;
            // 
            // chkCalcIgnoreT1Item
            // 
            chkCalcIgnoreT1Item.AutoSize = true;
            chkCalcIgnoreT1Item.Location = new Point(9, 34);
            chkCalcIgnoreT1Item.Name = "chkCalcIgnoreT1Item";
            chkCalcIgnoreT1Item.Size = new Size(89, 17);
            chkCalcIgnoreT1Item.TabIndex = 2;
            chkCalcIgnoreT1Item.Text = "T1 Base Item";
            chkCalcIgnoreT1Item.UseVisualStyleBackColor = true;
            // 
            // chkCalcIgnoreInvention
            // 
            chkCalcIgnoreInvention.AutoSize = true;
            chkCalcIgnoreInvention.Location = new Point(9, 16);
            chkCalcIgnoreInvention.Name = "chkCalcIgnoreInvention";
            chkCalcIgnoreInvention.Size = new Size(70, 17);
            chkCalcIgnoreInvention.TabIndex = 0;
            chkCalcIgnoreInvention.Text = "Invention";
            chkCalcIgnoreInvention.UseVisualStyleBackColor = true;
            // 
            // gbIncludeTaxesFees
            // 
            gbIncludeTaxesFees.Controls.Add(txtCalcBrokerFeeRate);
            gbIncludeTaxesFees.Controls.Add(chkCalcFees);
            gbIncludeTaxesFees.Controls.Add(chkCalcTaxes);
            gbIncludeTaxesFees.Location = new Point(859, 255);
            gbIncludeTaxesFees.Name = "gbIncludeTaxesFees";
            gbIncludeTaxesFees.Size = new Size(156, 39);
            gbIncludeTaxesFees.TabIndex = 17;
            gbIncludeTaxesFees.TabStop = false;
            gbIncludeTaxesFees.Text = "Include:";
            // 
            // txtCalcBrokerFeeRate
            // 
            txtCalcBrokerFeeRate.Location = new Point(114, 14);
            txtCalcBrokerFeeRate.Name = "txtCalcBrokerFeeRate";
            txtCalcBrokerFeeRate.Size = new Size(37, 20);
            txtCalcBrokerFeeRate.TabIndex = 62;
            txtCalcBrokerFeeRate.TabStop = false;
            txtCalcBrokerFeeRate.TextAlign = HorizontalAlignment.Right;
            txtCalcBrokerFeeRate.Visible = false;
            // 
            // chkCalcFees
            // 
            chkCalcFees.AutoSize = true;
            chkCalcFees.Location = new Point(65, 17);
            chkCalcFees.Name = "chkCalcFees";
            chkCalcFees.Size = new Size(49, 17);
            chkCalcFees.TabIndex = 1;
            chkCalcFees.Text = "Fees";
            chkCalcFees.ThreeState = true;
            chkCalcFees.UseVisualStyleBackColor = true;
            // 
            // chkCalcTaxes
            // 
            chkCalcTaxes.AutoSize = true;
            chkCalcTaxes.Location = new Point(9, 17);
            chkCalcTaxes.Name = "chkCalcTaxes";
            chkCalcTaxes.Size = new Size(55, 17);
            chkCalcTaxes.TabIndex = 0;
            chkCalcTaxes.Text = "Taxes";
            chkCalcTaxes.UseVisualStyleBackColor = true;
            // 
            // gbCalcSellExessItems
            // 
            gbCalcSellExessItems.Controls.Add(rbtnCalcAdvT2MatType);
            gbCalcSellExessItems.Controls.Add(rbtnCalcProcT2MatType);
            gbCalcSellExessItems.Controls.Add(rbtnCalcRawT2MatType);
            gbCalcSellExessItems.Controls.Add(chkCalcSellExessItems);
            gbCalcSellExessItems.Location = new Point(1019, 197);
            gbCalcSellExessItems.Name = "gbCalcSellExessItems";
            gbCalcSellExessItems.Size = new Size(96, 97);
            gbCalcSellExessItems.TabIndex = 29;
            gbCalcSellExessItems.TabStop = false;
            gbCalcSellExessItems.Text = "T2/3 Mat Type";
            // 
            // rbtnCalcAdvT2MatType
            // 
            rbtnCalcAdvT2MatType.AutoSize = true;
            rbtnCalcAdvT2MatType.BackColor = Color.Transparent;
            rbtnCalcAdvT2MatType.Location = new Point(7, 17);
            rbtnCalcAdvT2MatType.Name = "rbtnCalcAdvT2MatType";
            rbtnCalcAdvT2MatType.Size = new Size(74, 17);
            rbtnCalcAdvT2MatType.TabIndex = 76;
            rbtnCalcAdvT2MatType.TabStop = true;
            rbtnCalcAdvT2MatType.Text = "Advanced";
            rbtnCalcAdvT2MatType.UseVisualStyleBackColor = false;
            // 
            // rbtnCalcProcT2MatType
            // 
            rbtnCalcProcT2MatType.AutoSize = true;
            rbtnCalcProcT2MatType.BackColor = Color.Transparent;
            rbtnCalcProcT2MatType.Location = new Point(7, 33);
            rbtnCalcProcT2MatType.Name = "rbtnCalcProcT2MatType";
            rbtnCalcProcT2MatType.Size = new Size(75, 17);
            rbtnCalcProcT2MatType.TabIndex = 77;
            rbtnCalcProcT2MatType.TabStop = true;
            rbtnCalcProcT2MatType.Text = "Processed";
            rbtnCalcProcT2MatType.UseVisualStyleBackColor = false;
            // 
            // rbtnCalcRawT2MatType
            // 
            rbtnCalcRawT2MatType.AutoSize = true;
            rbtnCalcRawT2MatType.BackColor = Color.Transparent;
            rbtnCalcRawT2MatType.Location = new Point(7, 49);
            rbtnCalcRawT2MatType.Name = "rbtnCalcRawT2MatType";
            rbtnCalcRawT2MatType.Size = new Size(47, 17);
            rbtnCalcRawT2MatType.TabIndex = 78;
            rbtnCalcRawT2MatType.TabStop = true;
            rbtnCalcRawT2MatType.Text = "Raw";
            rbtnCalcRawT2MatType.UseVisualStyleBackColor = false;
            // 
            // chkCalcSellExessItems
            // 
            chkCalcSellExessItems.Location = new Point(7, 65);
            chkCalcSellExessItems.Name = "chkCalcSellExessItems";
            chkCalcSellExessItems.Size = new Size(83, 32);
            chkCalcSellExessItems.TabIndex = 1;
            chkCalcSellExessItems.Text = "Sell excess build items";
            chkCalcSellExessItems.UseVisualStyleBackColor = true;
            // 
            // chkCalcNPCBPOs
            // 
            chkCalcNPCBPOs.AutoSize = true;
            chkCalcNPCBPOs.Location = new Point(439, 13);
            chkCalcNPCBPOs.Name = "chkCalcNPCBPOs";
            chkCalcNPCBPOs.Size = new Size(100, 17);
            chkCalcNPCBPOs.TabIndex = 15;
            chkCalcNPCBPOs.Text = "NPC BPOs only";
            chkCalcNPCBPOs.UseVisualStyleBackColor = true;
            // 
            // btnCalcShowAssets
            // 
            btnCalcShowAssets.Image = (Image)resources.GetObject("btnCalcShowAssets.Image");
            btnCalcShowAssets.Location = new Point(219, 205);
            btnCalcShowAssets.Name = "btnCalcShowAssets";
            btnCalcShowAssets.Size = new Size(48, 48);
            btnCalcShowAssets.TabIndex = 28;
            btnCalcShowAssets.UseVisualStyleBackColor = true;
            // 
            // gbCalcIncludeItems
            // 
            gbCalcIncludeItems.Controls.Add(chkCalcCanInvent);
            gbCalcIncludeItems.Controls.Add(chkCalcCanBuild);
            gbCalcIncludeItems.ImeMode = ImeMode.Off;
            gbCalcIncludeItems.Location = new Point(409, 147);
            gbCalcIncludeItems.Name = "gbCalcIncludeItems";
            gbCalcIncludeItems.Size = new Size(134, 42);
            gbCalcIncludeItems.TabIndex = 12;
            gbCalcIncludeItems.TabStop = false;
            gbCalcIncludeItems.Text = "Only Items I Can:";
            // 
            // chkCalcCanInvent
            // 
            chkCalcCanInvent.AutoSize = true;
            chkCalcCanInvent.Location = new Point(66, 19);
            chkCalcCanInvent.Name = "chkCalcCanInvent";
            chkCalcCanInvent.Size = new Size(56, 17);
            chkCalcCanInvent.TabIndex = 1;
            chkCalcCanInvent.Text = "Invent";
            chkCalcCanInvent.UseVisualStyleBackColor = true;
            // 
            // chkCalcCanBuild
            // 
            chkCalcCanBuild.AutoSize = true;
            chkCalcCanBuild.Location = new Point(9, 19);
            chkCalcCanBuild.Name = "chkCalcCanBuild";
            chkCalcCanBuild.Size = new Size(49, 17);
            chkCalcCanBuild.TabIndex = 0;
            chkCalcCanBuild.Text = "Build";
            chkCalcCanBuild.UseVisualStyleBackColor = true;
            // 
            // gbCalcMarketFilters
            // 
            gbCalcMarketFilters.Controls.Add(txtCalcProfitThreshold);
            gbCalcMarketFilters.Controls.Add(tpMaxBuildTimeFilter);
            gbCalcMarketFilters.Controls.Add(txtCalcSVRThreshold);
            gbCalcMarketFilters.Controls.Add(tpMinBuildTimeFilter);
            gbCalcMarketFilters.Controls.Add(chkCalcMaxBuildTimeFilter);
            gbCalcMarketFilters.Controls.Add(chkCalcMinBuildTimeFilter);
            gbCalcMarketFilters.Controls.Add(cmbCalcPriceTrend);
            gbCalcMarketFilters.Controls.Add(cmbCalcAvgPriceDuration);
            gbCalcMarketFilters.Controls.Add(lblCalcPriceTrend);
            gbCalcMarketFilters.Controls.Add(txtCalcVolumeThreshold);
            gbCalcMarketFilters.Controls.Add(cmbCalcHistoryRegion);
            gbCalcMarketFilters.Controls.Add(lblCalcHistoryRegion);
            gbCalcMarketFilters.Controls.Add(lblCalcSVRThreshold);
            gbCalcMarketFilters.Controls.Add(lblCalcAvgPrice);
            gbCalcMarketFilters.Controls.Add(txtCalcIPHThreshold);
            gbCalcMarketFilters.Controls.Add(chkCalcProfitThreshold);
            gbCalcMarketFilters.Controls.Add(chkCalcVolumeThreshold);
            gbCalcMarketFilters.Controls.Add(chkCalcIPHThreshold);
            gbCalcMarketFilters.Controls.Add(chkCalcSVRIncludeNull);
            gbCalcMarketFilters.Location = new Point(409, 188);
            gbCalcMarketFilters.Name = "gbCalcMarketFilters";
            gbCalcMarketFilters.Size = new Size(447, 106);
            gbCalcMarketFilters.TabIndex = 27;
            gbCalcMarketFilters.TabStop = false;
            gbCalcMarketFilters.Text = "Market Filters:";
            // 
            // txtCalcProfitThreshold
            // 
            txtCalcProfitThreshold.Enabled = false;
            txtCalcProfitThreshold.Location = new Point(333, 79);
            txtCalcProfitThreshold.Name = "txtCalcProfitThreshold";
            txtCalcProfitThreshold.Size = new Size(108, 20);
            txtCalcProfitThreshold.TabIndex = 62;
            txtCalcProfitThreshold.TabStop = false;
            txtCalcProfitThreshold.Text = "0.00";
            txtCalcProfitThreshold.TextAlign = HorizontalAlignment.Right;
            // 
            // tpMaxBuildTimeFilter
            // 
            tpMaxBuildTimeFilter.BorderStyle = BorderStyle.FixedSingle;
            tpMaxBuildTimeFilter.Enabled = false;
            tpMaxBuildTimeFilter.Location = new Point(328, 39);
            tpMaxBuildTimeFilter.Name = "tpMaxBuildTimeFilter";
            tpMaxBuildTimeFilter.Size = new Size(113, 22);
            tpMaxBuildTimeFilter.TabIndex = 70;
            // 
            // txtCalcSVRThreshold
            // 
            txtCalcSVRThreshold.Location = new Point(65, 40);
            txtCalcSVRThreshold.MaxLength = 10;
            txtCalcSVRThreshold.Name = "txtCalcSVRThreshold";
            txtCalcSVRThreshold.Size = new Size(60, 20);
            txtCalcSVRThreshold.TabIndex = 1;
            txtCalcSVRThreshold.TextAlign = HorizontalAlignment.Right;
            // 
            // tpMinBuildTimeFilter
            // 
            tpMinBuildTimeFilter.BorderStyle = BorderStyle.FixedSingle;
            tpMinBuildTimeFilter.Enabled = false;
            tpMinBuildTimeFilter.Location = new Point(328, 14);
            tpMinBuildTimeFilter.Name = "tpMinBuildTimeFilter";
            tpMinBuildTimeFilter.Size = new Size(113, 22);
            tpMinBuildTimeFilter.TabIndex = 69;
            // 
            // chkCalcMaxBuildTimeFilter
            // 
            chkCalcMaxBuildTimeFilter.AutoSize = true;
            chkCalcMaxBuildTimeFilter.Location = new Point(227, 42);
            chkCalcMaxBuildTimeFilter.Name = "chkCalcMaxBuildTimeFilter";
            chkCalcMaxBuildTimeFilter.Size = new Size(101, 17);
            chkCalcMaxBuildTimeFilter.TabIndex = 71;
            chkCalcMaxBuildTimeFilter.Text = "Max Build Time:";
            chkCalcMaxBuildTimeFilter.UseVisualStyleBackColor = true;
            // 
            // chkCalcMinBuildTimeFilter
            // 
            chkCalcMinBuildTimeFilter.AutoSize = true;
            chkCalcMinBuildTimeFilter.Location = new Point(227, 17);
            chkCalcMinBuildTimeFilter.Name = "chkCalcMinBuildTimeFilter";
            chkCalcMinBuildTimeFilter.Size = new Size(98, 17);
            chkCalcMinBuildTimeFilter.TabIndex = 70;
            chkCalcMinBuildTimeFilter.Text = "Min Build Time:";
            chkCalcMinBuildTimeFilter.UseVisualStyleBackColor = true;
            // 
            // cmbCalcPriceTrend
            // 
            cmbCalcPriceTrend.FormattingEnabled = true;
            cmbCalcPriceTrend.Items.AddRange(new object[] { "All", "Up", "Down" });
            cmbCalcPriceTrend.Location = new Point(75, 78);
            cmbCalcPriceTrend.MaxLength = 3;
            cmbCalcPriceTrend.Name = "cmbCalcPriceTrend";
            cmbCalcPriceTrend.Size = new Size(48, 21);
            cmbCalcPriceTrend.TabIndex = 7;
            // 
            // cmbCalcAvgPriceDuration
            // 
            cmbCalcAvgPriceDuration.FormattingEnabled = true;
            cmbCalcAvgPriceDuration.Items.AddRange(new object[] { "7", "15", "30", "60", "90" });
            cmbCalcAvgPriceDuration.Location = new Point(164, 39);
            cmbCalcAvgPriceDuration.MaxLength = 3;
            cmbCalcAvgPriceDuration.Name = "cmbCalcAvgPriceDuration";
            cmbCalcAvgPriceDuration.Size = new Size(41, 21);
            cmbCalcAvgPriceDuration.TabIndex = 3;
            // 
            // lblCalcPriceTrend
            // 
            lblCalcPriceTrend.AutoSize = true;
            lblCalcPriceTrend.Location = new Point(6, 82);
            lblCalcPriceTrend.Name = "lblCalcPriceTrend";
            lblCalcPriceTrend.Size = new Size(65, 13);
            lblCalcPriceTrend.TabIndex = 6;
            lblCalcPriceTrend.Text = "Price Trend:";
            lblCalcPriceTrend.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCalcVolumeThreshold
            // 
            txtCalcVolumeThreshold.Enabled = false;
            txtCalcVolumeThreshold.Location = new Point(239, 79);
            txtCalcVolumeThreshold.Name = "txtCalcVolumeThreshold";
            txtCalcVolumeThreshold.Size = new Size(90, 20);
            txtCalcVolumeThreshold.TabIndex = 63;
            txtCalcVolumeThreshold.TabStop = false;
            txtCalcVolumeThreshold.Text = "0.00";
            txtCalcVolumeThreshold.TextAlign = HorizontalAlignment.Right;
            // 
            // cmbCalcHistoryRegion
            // 
            cmbCalcHistoryRegion.FormattingEnabled = true;
            cmbCalcHistoryRegion.Location = new Point(56, 15);
            cmbCalcHistoryRegion.Name = "cmbCalcHistoryRegion";
            cmbCalcHistoryRegion.Size = new Size(149, 21);
            cmbCalcHistoryRegion.TabIndex = 5;
            // 
            // lblCalcHistoryRegion
            // 
            lblCalcHistoryRegion.AutoSize = true;
            lblCalcHistoryRegion.Location = new Point(6, 18);
            lblCalcHistoryRegion.Name = "lblCalcHistoryRegion";
            lblCalcHistoryRegion.Size = new Size(44, 13);
            lblCalcHistoryRegion.TabIndex = 4;
            lblCalcHistoryRegion.Text = "Region:";
            // 
            // lblCalcSVRThreshold
            // 
            lblCalcSVRThreshold.Location = new Point(6, 35);
            lblCalcSVRThreshold.Name = "lblCalcSVRThreshold";
            lblCalcSVRThreshold.Size = new Size(65, 27);
            lblCalcSVRThreshold.TabIndex = 0;
            lblCalcSVRThreshold.Text = "SVR Threshold:";
            // 
            // lblCalcAvgPrice
            // 
            lblCalcAvgPrice.Location = new Point(131, 35);
            lblCalcAvgPrice.Name = "lblCalcAvgPrice";
            lblCalcAvgPrice.Size = new Size(41, 27);
            lblCalcAvgPrice.TabIndex = 2;
            lblCalcAvgPrice.Text = "Avg Days:";
            lblCalcAvgPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCalcIPHThreshold
            // 
            txtCalcIPHThreshold.Enabled = false;
            txtCalcIPHThreshold.Location = new Point(145, 79);
            txtCalcIPHThreshold.Name = "txtCalcIPHThreshold";
            txtCalcIPHThreshold.Size = new Size(90, 20);
            txtCalcIPHThreshold.TabIndex = 72;
            txtCalcIPHThreshold.TabStop = false;
            txtCalcIPHThreshold.Text = "0.00";
            txtCalcIPHThreshold.TextAlign = HorizontalAlignment.Right;
            // 
            // chkCalcProfitThreshold
            // 
            chkCalcProfitThreshold.AutoSize = true;
            chkCalcProfitThreshold.Location = new Point(333, 63);
            chkCalcProfitThreshold.Name = "chkCalcProfitThreshold";
            chkCalcProfitThreshold.Size = new Size(103, 17);
            chkCalcProfitThreshold.TabIndex = 76;
            chkCalcProfitThreshold.Text = "Profit Threshold:";
            chkCalcProfitThreshold.ThreeState = true;
            chkCalcProfitThreshold.UseVisualStyleBackColor = true;
            // 
            // chkCalcVolumeThreshold
            // 
            chkCalcVolumeThreshold.AutoSize = true;
            chkCalcVolumeThreshold.Location = new Point(239, 63);
            chkCalcVolumeThreshold.Name = "chkCalcVolumeThreshold";
            chkCalcVolumeThreshold.Size = new Size(97, 17);
            chkCalcVolumeThreshold.TabIndex = 77;
            chkCalcVolumeThreshold.Text = "Vol. Threshold:";
            chkCalcVolumeThreshold.UseVisualStyleBackColor = true;
            // 
            // chkCalcIPHThreshold
            // 
            chkCalcIPHThreshold.AutoSize = true;
            chkCalcIPHThreshold.Location = new Point(145, 63);
            chkCalcIPHThreshold.Name = "chkCalcIPHThreshold";
            chkCalcIPHThreshold.Size = new Size(97, 17);
            chkCalcIPHThreshold.TabIndex = 75;
            chkCalcIPHThreshold.Text = "IPH Threshold:";
            chkCalcIPHThreshold.UseVisualStyleBackColor = true;
            // 
            // chkCalcSVRIncludeNull
            // 
            chkCalcSVRIncludeNull.AutoSize = true;
            chkCalcSVRIncludeNull.Location = new Point(9, 63);
            chkCalcSVRIncludeNull.Name = "chkCalcSVRIncludeNull";
            chkCalcSVRIncludeNull.Size = new Size(136, 17);
            chkCalcSVRIncludeNull.TabIndex = 6;
            chkCalcSVRIncludeNull.Text = "Include Items w/o SVR";
            chkCalcSVRIncludeNull.UseVisualStyleBackColor = true;
            // 
            // btnCalcCalculate
            // 
            btnCalcCalculate.Location = new Point(1018, 49);
            btnCalcCalculate.Name = "btnCalcCalculate";
            btnCalcCalculate.Size = new Size(98, 29);
            btnCalcCalculate.TabIndex = 21;
            btnCalcCalculate.Text = "Calculate";
            btnCalcCalculate.UseVisualStyleBackColor = true;
            // 
            // btnCalcSelectColumns
            // 
            btnCalcSelectColumns.Location = new Point(1018, 107);
            btnCalcSelectColumns.Name = "btnCalcSelectColumns";
            btnCalcSelectColumns.Size = new Size(98, 29);
            btnCalcSelectColumns.TabIndex = 23;
            btnCalcSelectColumns.Text = "Select Columns";
            btnCalcSelectColumns.UseVisualStyleBackColor = true;
            // 
            // gbCalcSizeLimit
            // 
            gbCalcSizeLimit.Controls.Add(chkCalcXL);
            gbCalcSizeLimit.Controls.Add(chkCalcLarge);
            gbCalcSizeLimit.Controls.Add(chkCalcMedium);
            gbCalcSizeLimit.Controls.Add(chkCalcSmall);
            gbCalcSizeLimit.Location = new Point(6, 81);
            gbCalcSizeLimit.Name = "gbCalcSizeLimit";
            gbCalcSizeLimit.Size = new Size(148, 38);
            gbCalcSizeLimit.TabIndex = 3;
            gbCalcSizeLimit.TabStop = false;
            gbCalcSizeLimit.Text = "Size Limit";
            // 
            // chkCalcXL
            // 
            chkCalcXL.AutoSize = true;
            chkCalcXL.Location = new Point(109, 17);
            chkCalcXL.Name = "chkCalcXL";
            chkCalcXL.Size = new Size(39, 17);
            chkCalcXL.TabIndex = 3;
            chkCalcXL.Text = "XL";
            chkCalcXL.UseVisualStyleBackColor = true;
            // 
            // chkCalcLarge
            // 
            chkCalcLarge.AutoSize = true;
            chkCalcLarge.Location = new Point(77, 17);
            chkCalcLarge.Name = "chkCalcLarge";
            chkCalcLarge.Size = new Size(32, 17);
            chkCalcLarge.TabIndex = 2;
            chkCalcLarge.Text = "L";
            chkCalcLarge.UseVisualStyleBackColor = true;
            // 
            // chkCalcMedium
            // 
            chkCalcMedium.AutoSize = true;
            chkCalcMedium.Location = new Point(42, 17);
            chkCalcMedium.Name = "chkCalcMedium";
            chkCalcMedium.Size = new Size(35, 17);
            chkCalcMedium.TabIndex = 1;
            chkCalcMedium.Text = "M";
            chkCalcMedium.UseVisualStyleBackColor = true;
            // 
            // chkCalcSmall
            // 
            chkCalcSmall.AutoSize = true;
            chkCalcSmall.Location = new Point(9, 17);
            chkCalcSmall.Name = "chkCalcSmall";
            chkCalcSmall.Size = new Size(33, 17);
            chkCalcSmall.TabIndex = 0;
            chkCalcSmall.Text = "S";
            chkCalcSmall.TextAlign = ContentAlignment.MiddleCenter;
            chkCalcSmall.UseVisualStyleBackColor = true;
            // 
            // gbCalcProdLines
            // 
            gbCalcProdLines.Controls.Add(chkCalcAutoCalcT2NumBPs);
            gbCalcProdLines.Controls.Add(lblCalcBPs);
            gbCalcProdLines.Controls.Add(txtCalcNumBPs);
            gbCalcProdLines.Controls.Add(txtCalcRuns);
            gbCalcProdLines.Controls.Add(txtCalcLabLines);
            gbCalcProdLines.Controls.Add(lblCalcRuns);
            gbCalcProdLines.Controls.Add(lblCalcLabLines1);
            gbCalcProdLines.Controls.Add(lblCalcProdLines1);
            gbCalcProdLines.Controls.Add(txtCalcProdLines);
            gbCalcProdLines.Location = new Point(859, 15);
            gbCalcProdLines.Name = "gbCalcProdLines";
            gbCalcProdLines.Size = new Size(156, 72);
            gbCalcProdLines.TabIndex = 15;
            gbCalcProdLines.TabStop = false;
            gbCalcProdLines.Text = "Runs / Lines:";
            // 
            // chkCalcAutoCalcT2NumBPs
            // 
            chkCalcAutoCalcT2NumBPs.AutoSize = true;
            chkCalcAutoCalcT2NumBPs.Location = new Point(12, 52);
            chkCalcAutoCalcT2NumBPs.Name = "chkCalcAutoCalcT2NumBPs";
            chkCalcAutoCalcT2NumBPs.Size = new Size(135, 17);
            chkCalcAutoCalcT2NumBPs.TabIndex = 8;
            chkCalcAutoCalcT2NumBPs.Text = "Auto Calc T2 Num BPs";
            chkCalcAutoCalcT2NumBPs.UseVisualStyleBackColor = true;
            // 
            // lblCalcBPs
            // 
            lblCalcBPs.AutoSize = true;
            lblCalcBPs.Location = new Point(44, 13);
            lblCalcBPs.Name = "lblCalcBPs";
            lblCalcBPs.Size = new Size(29, 13);
            lblCalcBPs.TabIndex = 2;
            lblCalcBPs.Text = "BPs:";
            // 
            // txtCalcNumBPs
            // 
            txtCalcNumBPs.Location = new Point(45, 28);
            txtCalcNumBPs.MaxLength = 3;
            txtCalcNumBPs.Name = "txtCalcNumBPs";
            txtCalcNumBPs.Size = new Size(32, 20);
            txtCalcNumBPs.TabIndex = 3;
            txtCalcNumBPs.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCalcRuns
            // 
            txtCalcRuns.Location = new Point(9, 28);
            txtCalcRuns.MaxLength = 4;
            txtCalcRuns.Name = "txtCalcRuns";
            txtCalcRuns.Size = new Size(32, 20);
            txtCalcRuns.TabIndex = 1;
            txtCalcRuns.TextAlign = HorizontalAlignment.Right;
            // 
            // txtCalcLabLines
            // 
            txtCalcLabLines.Location = new Point(115, 28);
            txtCalcLabLines.MaxLength = 3;
            txtCalcLabLines.Name = "txtCalcLabLines";
            txtCalcLabLines.Size = new Size(32, 20);
            txtCalcLabLines.TabIndex = 7;
            txtCalcLabLines.TextAlign = HorizontalAlignment.Center;
            // 
            // lblCalcRuns
            // 
            lblCalcRuns.AutoSize = true;
            lblCalcRuns.Location = new Point(8, 13);
            lblCalcRuns.Name = "lblCalcRuns";
            lblCalcRuns.Size = new Size(35, 13);
            lblCalcRuns.TabIndex = 0;
            lblCalcRuns.Text = "Runs:";
            // 
            // lblCalcLabLines1
            // 
            lblCalcLabLines1.AutoSize = true;
            lblCalcLabLines1.Location = new Point(113, 13);
            lblCalcLabLines1.Name = "lblCalcLabLines1";
            lblCalcLabLines1.Size = new Size(33, 13);
            lblCalcLabLines1.TabIndex = 6;
            lblCalcLabLines1.Text = "Labs:";
            // 
            // lblCalcProdLines1
            // 
            lblCalcProdLines1.AutoSize = true;
            lblCalcProdLines1.Location = new Point(79, 13);
            lblCalcProdLines1.Name = "lblCalcProdLines1";
            lblCalcProdLines1.Size = new Size(32, 13);
            lblCalcProdLines1.TabIndex = 4;
            lblCalcProdLines1.Text = "Prod:";
            // 
            // txtCalcProdLines
            // 
            txtCalcProdLines.Location = new Point(80, 28);
            txtCalcProdLines.MaxLength = 3;
            txtCalcProdLines.Name = "txtCalcProdLines";
            txtCalcProdLines.Size = new Size(32, 20);
            txtCalcProdLines.TabIndex = 5;
            txtCalcProdLines.TextAlign = HorizontalAlignment.Center;
            // 
            // gbCalcCompareType
            // 
            gbCalcCompareType.Controls.Add(chkCalcPPU);
            gbCalcCompareType.Controls.Add(rbtnCalcCompareBuildBuy);
            gbCalcCompareType.Controls.Add(rbtnCalcCompareRawMats);
            gbCalcCompareType.Controls.Add(rbtnCalcCompareComponents);
            gbCalcCompareType.Controls.Add(rbtnCalcCompareAll);
            gbCalcCompareType.Location = new Point(859, 89);
            gbCalcCompareType.Name = "gbCalcCompareType";
            gbCalcCompareType.Size = new Size(156, 110);
            gbCalcCompareType.TabIndex = 16;
            gbCalcCompareType.TabStop = false;
            gbCalcCompareType.Text = "Price Comparison:";
            // 
            // chkCalcPPU
            // 
            chkCalcPPU.AutoSize = true;
            chkCalcPPU.Location = new Point(9, 88);
            chkCalcPPU.Name = "chkCalcPPU";
            chkCalcPPU.Size = new Size(137, 17);
            chkCalcPPU.TabIndex = 9;
            chkCalcPPU.Text = "Calculate Price per Unit";
            chkCalcPPU.UseVisualStyleBackColor = true;
            // 
            // rbtnCalcCompareBuildBuy
            // 
            rbtnCalcCompareBuildBuy.AutoSize = true;
            rbtnCalcCompareBuildBuy.Location = new Point(9, 32);
            rbtnCalcCompareBuildBuy.Name = "rbtnCalcCompareBuildBuy";
            rbtnCalcCompareBuildBuy.Size = new Size(116, 17);
            rbtnCalcCompareBuildBuy.TabIndex = 1;
            rbtnCalcCompareBuildBuy.Text = "Compare Build/Buy";
            rbtnCalcCompareBuildBuy.UseVisualStyleBackColor = true;
            // 
            // rbtnCalcCompareRawMats
            // 
            rbtnCalcCompareRawMats.AutoSize = true;
            rbtnCalcCompareRawMats.Location = new Point(9, 49);
            rbtnCalcCompareRawMats.Name = "rbtnCalcCompareRawMats";
            rbtnCalcCompareRawMats.Size = new Size(137, 17);
            rbtnCalcCompareRawMats.TabIndex = 2;
            rbtnCalcCompareRawMats.Text = "Compare Raw Materials";
            rbtnCalcCompareRawMats.UseVisualStyleBackColor = true;
            // 
            // rbtnCalcCompareComponents
            // 
            rbtnCalcCompareComponents.AutoSize = true;
            rbtnCalcCompareComponents.Location = new Point(9, 66);
            rbtnCalcCompareComponents.Name = "rbtnCalcCompareComponents";
            rbtnCalcCompareComponents.Size = new Size(129, 17);
            rbtnCalcCompareComponents.TabIndex = 3;
            rbtnCalcCompareComponents.Text = "Compare Components";
            rbtnCalcCompareComponents.UseVisualStyleBackColor = true;
            // 
            // rbtnCalcCompareAll
            // 
            rbtnCalcCompareAll.AutoSize = true;
            rbtnCalcCompareAll.Location = new Point(9, 15);
            rbtnCalcCompareAll.Name = "rbtnCalcCompareAll";
            rbtnCalcCompareAll.Size = new Size(81, 17);
            rbtnCalcCompareAll.TabIndex = 0;
            rbtnCalcCompareAll.Text = "Compare All";
            rbtnCalcCompareAll.UseVisualStyleBackColor = true;
            // 
            // gbCalcTextColors
            // 
            gbCalcTextColors.Controls.Add(lblCalcColorCode6);
            gbCalcTextColors.Controls.Add(lblCalcText);
            gbCalcTextColors.Controls.Add(lblCalcColorCode3);
            gbCalcTextColors.Controls.Add(lblCalcColorCode4);
            gbCalcTextColors.Controls.Add(lblCalcColorCode5);
            gbCalcTextColors.Controls.Add(lblCalcColorCode2);
            gbCalcTextColors.Controls.Add(lblCalcColorCode1);
            gbCalcTextColors.Location = new Point(6, 116);
            gbCalcTextColors.Name = "gbCalcTextColors";
            gbCalcTextColors.Size = new Size(148, 30);
            gbCalcTextColors.TabIndex = 5;
            gbCalcTextColors.TabStop = false;
            // 
            // lblCalcColorCode6
            // 
            lblCalcColorCode6.BackColor = Color.LightGreen;
            lblCalcColorCode6.BorderStyle = BorderStyle.FixedSingle;
            lblCalcColorCode6.ForeColor = SystemColors.ControlText;
            lblCalcColorCode6.Location = new Point(55, 10);
            lblCalcColorCode6.Name = "lblCalcColorCode6";
            lblCalcColorCode6.Size = new Size(15, 15);
            lblCalcColorCode6.TabIndex = 5;
            lblCalcColorCode6.Text = "T";
            lblCalcColorCode6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCalcText
            // 
            lblCalcText.AutoSize = true;
            lblCalcText.Location = new Point(6, 11);
            lblCalcText.Name = "lblCalcText";
            lblCalcText.Size = new Size(31, 13);
            lblCalcText.TabIndex = 0;
            lblCalcText.Text = "Text:";
            // 
            // lblCalcColorCode3
            // 
            lblCalcColorCode3.BorderStyle = BorderStyle.FixedSingle;
            lblCalcColorCode3.ForeColor = Color.DarkGreen;
            lblCalcColorCode3.Location = new Point(127, 10);
            lblCalcColorCode3.Name = "lblCalcColorCode3";
            lblCalcColorCode3.Size = new Size(15, 15);
            lblCalcColorCode3.TabIndex = 2;
            lblCalcColorCode3.Text = "T";
            lblCalcColorCode3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCalcColorCode4
            // 
            lblCalcColorCode4.BorderStyle = BorderStyle.FixedSingle;
            lblCalcColorCode4.ForeColor = Color.DarkOrange;
            lblCalcColorCode4.Location = new Point(109, 10);
            lblCalcColorCode4.Name = "lblCalcColorCode4";
            lblCalcColorCode4.Size = new Size(15, 15);
            lblCalcColorCode4.TabIndex = 3;
            lblCalcColorCode4.Text = "T";
            lblCalcColorCode4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCalcColorCode5
            // 
            lblCalcColorCode5.BorderStyle = BorderStyle.FixedSingle;
            lblCalcColorCode5.ForeColor = Color.DarkRed;
            lblCalcColorCode5.Location = new Point(91, 10);
            lblCalcColorCode5.Name = "lblCalcColorCode5";
            lblCalcColorCode5.Size = new Size(15, 15);
            lblCalcColorCode5.TabIndex = 4;
            lblCalcColorCode5.Text = "T";
            lblCalcColorCode5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCalcColorCode2
            // 
            lblCalcColorCode2.BackColor = Color.LightSteelBlue;
            lblCalcColorCode2.BorderStyle = BorderStyle.FixedSingle;
            lblCalcColorCode2.ForeColor = Color.Black;
            lblCalcColorCode2.Location = new Point(73, 10);
            lblCalcColorCode2.Name = "lblCalcColorCode2";
            lblCalcColorCode2.Size = new Size(15, 15);
            lblCalcColorCode2.TabIndex = 1;
            lblCalcColorCode2.Text = "T";
            lblCalcColorCode2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCalcColorCode1
            // 
            lblCalcColorCode1.BackColor = Color.BlanchedAlmond;
            lblCalcColorCode1.BorderStyle = BorderStyle.FixedSingle;
            lblCalcColorCode1.Location = new Point(37, 10);
            lblCalcColorCode1.Name = "lblCalcColorCode1";
            lblCalcColorCode1.Size = new Size(15, 15);
            lblCalcColorCode1.TabIndex = 0;
            lblCalcColorCode1.Text = "T";
            lblCalcColorCode1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbCalcInvention
            // 
            gbCalcInvention.Controls.Add(chkCalcDecryptorforT3);
            gbCalcInvention.Controls.Add(chkCalcDecryptorforT2);
            gbCalcInvention.Controls.Add(chkCalcDecryptor0);
            gbCalcInvention.Controls.Add(chkCalcDecryptor9);
            gbCalcInvention.Controls.Add(chkCalcDecryptor8);
            gbCalcInvention.Controls.Add(chkCalcDecryptor7);
            gbCalcInvention.Controls.Add(chkCalcDecryptor6);
            gbCalcInvention.Controls.Add(chkCalcDecryptor5);
            gbCalcInvention.Controls.Add(chkCalcDecryptor4);
            gbCalcInvention.Controls.Add(chkCalcDecryptor3);
            gbCalcInvention.Controls.Add(chkCalcDecryptor2);
            gbCalcInvention.Controls.Add(chkCalcDecryptor1);
            gbCalcInvention.Controls.Add(lblCalcDecryptorUse);
            gbCalcInvention.Location = new Point(6, 147);
            gbCalcInvention.Name = "gbCalcInvention";
            gbCalcInvention.Size = new Size(400, 52);
            gbCalcInvention.TabIndex = 6;
            gbCalcInvention.TabStop = false;
            gbCalcInvention.Text = "Invention Decryptors (Probability Multiplier):";
            // 
            // chkCalcDecryptorforT3
            // 
            chkCalcDecryptorforT3.AutoSize = true;
            chkCalcDecryptorforT3.Location = new Point(354, 30);
            chkCalcDecryptorforT3.Name = "chkCalcDecryptorforT3";
            chkCalcDecryptorforT3.Size = new Size(39, 17);
            chkCalcDecryptorforT3.TabIndex = 12;
            chkCalcDecryptorforT3.Text = "T3";
            chkCalcDecryptorforT3.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptorforT2
            // 
            chkCalcDecryptorforT2.AutoSize = true;
            chkCalcDecryptorforT2.Location = new Point(354, 14);
            chkCalcDecryptorforT2.Name = "chkCalcDecryptorforT2";
            chkCalcDecryptorforT2.Size = new Size(39, 17);
            chkCalcDecryptorforT2.TabIndex = 11;
            chkCalcDecryptorforT2.Text = "T2";
            chkCalcDecryptorforT2.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor0
            // 
            chkCalcDecryptor0.AutoSize = true;
            chkCalcDecryptor0.Location = new Point(9, 30);
            chkCalcDecryptor0.Name = "chkCalcDecryptor0";
            chkCalcDecryptor0.Size = new Size(61, 17);
            chkCalcDecryptor0.TabIndex = 1;
            chkCalcDecryptor0.Text = "Optimal";
            chkCalcDecryptor0.ThreeState = true;
            chkCalcDecryptor0.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor9
            // 
            chkCalcDecryptor9.AutoSize = true;
            chkCalcDecryptor9.Location = new Point(267, 30);
            chkCalcDecryptor9.Name = "chkCalcDecryptor9";
            chkCalcDecryptor9.Size = new Size(46, 17);
            chkCalcDecryptor9.TabIndex = 9;
            chkCalcDecryptor9.Text = "1.9x";
            chkCalcDecryptor9.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor8
            // 
            chkCalcDecryptor8.AutoSize = true;
            chkCalcDecryptor8.Location = new Point(211, 29);
            chkCalcDecryptor8.Name = "chkCalcDecryptor8";
            chkCalcDecryptor8.Size = new Size(46, 17);
            chkCalcDecryptor8.TabIndex = 7;
            chkCalcDecryptor8.Text = "1.8x";
            chkCalcDecryptor8.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor7
            // 
            chkCalcDecryptor7.AutoSize = true;
            chkCalcDecryptor7.Location = new Point(155, 30);
            chkCalcDecryptor7.Name = "chkCalcDecryptor7";
            chkCalcDecryptor7.Size = new Size(46, 17);
            chkCalcDecryptor7.TabIndex = 5;
            chkCalcDecryptor7.Text = "1.5x";
            chkCalcDecryptor7.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor6
            // 
            chkCalcDecryptor6.AutoSize = true;
            chkCalcDecryptor6.Location = new Point(99, 30);
            chkCalcDecryptor6.Name = "chkCalcDecryptor6";
            chkCalcDecryptor6.Size = new Size(46, 17);
            chkCalcDecryptor6.TabIndex = 3;
            chkCalcDecryptor6.Text = "1.2x";
            chkCalcDecryptor6.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor5
            // 
            chkCalcDecryptor5.AutoSize = true;
            chkCalcDecryptor5.Location = new Point(267, 14);
            chkCalcDecryptor5.Name = "chkCalcDecryptor5";
            chkCalcDecryptor5.Size = new Size(46, 17);
            chkCalcDecryptor5.TabIndex = 8;
            chkCalcDecryptor5.Text = "1.1x";
            chkCalcDecryptor5.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor4
            // 
            chkCalcDecryptor4.AutoSize = true;
            chkCalcDecryptor4.Location = new Point(211, 13);
            chkCalcDecryptor4.Name = "chkCalcDecryptor4";
            chkCalcDecryptor4.Size = new Size(46, 17);
            chkCalcDecryptor4.TabIndex = 6;
            chkCalcDecryptor4.Text = "1.0x";
            chkCalcDecryptor4.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor3
            // 
            chkCalcDecryptor3.AutoSize = true;
            chkCalcDecryptor3.Location = new Point(155, 14);
            chkCalcDecryptor3.Name = "chkCalcDecryptor3";
            chkCalcDecryptor3.Size = new Size(46, 17);
            chkCalcDecryptor3.TabIndex = 4;
            chkCalcDecryptor3.Text = "0.9x";
            chkCalcDecryptor3.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor2
            // 
            chkCalcDecryptor2.AutoSize = true;
            chkCalcDecryptor2.Location = new Point(99, 14);
            chkCalcDecryptor2.Name = "chkCalcDecryptor2";
            chkCalcDecryptor2.Size = new Size(46, 17);
            chkCalcDecryptor2.TabIndex = 2;
            chkCalcDecryptor2.Text = "0.6x";
            chkCalcDecryptor2.UseVisualStyleBackColor = true;
            // 
            // chkCalcDecryptor1
            // 
            chkCalcDecryptor1.AutoSize = true;
            chkCalcDecryptor1.Location = new Point(9, 14);
            chkCalcDecryptor1.Name = "chkCalcDecryptor1";
            chkCalcDecryptor1.Size = new Size(52, 17);
            chkCalcDecryptor1.TabIndex = 0;
            chkCalcDecryptor1.Text = "None";
            chkCalcDecryptor1.UseVisualStyleBackColor = true;
            // 
            // lblCalcDecryptorUse
            // 
            lblCalcDecryptorUse.Location = new Point(319, 13);
            lblCalcDecryptorUse.Name = "lblCalcDecryptorUse";
            lblCalcDecryptorUse.Size = new Size(36, 33);
            lblCalcDecryptorUse.TabIndex = 10;
            lblCalcDecryptorUse.Text = "Use For:";
            lblCalcDecryptorUse.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbCalcBPRace
            // 
            gbCalcBPRace.Controls.Add(chkCalcRaceOther);
            gbCalcBPRace.Controls.Add(chkCalcRacePirate);
            gbCalcBPRace.Controls.Add(chkCalcRaceMinmatar);
            gbCalcBPRace.Controls.Add(chkCalcRaceGallente);
            gbCalcBPRace.Controls.Add(chkCalcRaceCaldari);
            gbCalcBPRace.Controls.Add(chkCalcRaceAmarr);
            gbCalcBPRace.Location = new Point(159, 81);
            gbCalcBPRace.Name = "gbCalcBPRace";
            gbCalcBPRace.Size = new Size(192, 65);
            gbCalcBPRace.TabIndex = 4;
            gbCalcBPRace.TabStop = false;
            gbCalcBPRace.Text = "BP Race";
            // 
            // chkCalcRaceOther
            // 
            chkCalcRaceOther.AutoSize = true;
            chkCalcRaceOther.Location = new Point(136, 40);
            chkCalcRaceOther.Name = "chkCalcRaceOther";
            chkCalcRaceOther.Size = new Size(52, 17);
            chkCalcRaceOther.TabIndex = 5;
            chkCalcRaceOther.Text = "Other";
            chkCalcRaceOther.UseVisualStyleBackColor = true;
            // 
            // chkCalcRacePirate
            // 
            chkCalcRacePirate.AutoSize = true;
            chkCalcRacePirate.Location = new Point(136, 17);
            chkCalcRacePirate.Name = "chkCalcRacePirate";
            chkCalcRacePirate.Size = new Size(53, 17);
            chkCalcRacePirate.TabIndex = 2;
            chkCalcRacePirate.Text = "Pirate";
            chkCalcRacePirate.UseVisualStyleBackColor = true;
            // 
            // chkCalcRaceMinmatar
            // 
            chkCalcRaceMinmatar.AutoSize = true;
            chkCalcRaceMinmatar.Location = new Point(69, 40);
            chkCalcRaceMinmatar.Name = "chkCalcRaceMinmatar";
            chkCalcRaceMinmatar.Size = new Size(69, 17);
            chkCalcRaceMinmatar.TabIndex = 4;
            chkCalcRaceMinmatar.Text = "Minmatar";
            chkCalcRaceMinmatar.UseVisualStyleBackColor = true;
            // 
            // chkCalcRaceGallente
            // 
            chkCalcRaceGallente.AutoSize = true;
            chkCalcRaceGallente.Location = new Point(6, 40);
            chkCalcRaceGallente.Name = "chkCalcRaceGallente";
            chkCalcRaceGallente.Size = new Size(65, 17);
            chkCalcRaceGallente.TabIndex = 3;
            chkCalcRaceGallente.Text = "Gallente";
            chkCalcRaceGallente.UseVisualStyleBackColor = true;
            // 
            // chkCalcRaceCaldari
            // 
            chkCalcRaceCaldari.AutoSize = true;
            chkCalcRaceCaldari.Location = new Point(69, 17);
            chkCalcRaceCaldari.Name = "chkCalcRaceCaldari";
            chkCalcRaceCaldari.Size = new Size(58, 17);
            chkCalcRaceCaldari.TabIndex = 1;
            chkCalcRaceCaldari.Text = "Caldari";
            chkCalcRaceCaldari.UseVisualStyleBackColor = true;
            // 
            // chkCalcRaceAmarr
            // 
            chkCalcRaceAmarr.AutoSize = true;
            chkCalcRaceAmarr.Location = new Point(6, 17);
            chkCalcRaceAmarr.Name = "chkCalcRaceAmarr";
            chkCalcRaceAmarr.Size = new Size(53, 17);
            chkCalcRaceAmarr.TabIndex = 0;
            chkCalcRaceAmarr.Text = "Amarr";
            chkCalcRaceAmarr.UseVisualStyleBackColor = true;
            // 
            // gbTempMEPE
            // 
            gbTempMEPE.Controls.Add(txtCalcTempTE);
            gbTempMEPE.Controls.Add(lblTempPE);
            gbTempMEPE.Controls.Add(txtCalcTempME);
            gbTempMEPE.Controls.Add(lblTempME);
            gbTempMEPE.Location = new Point(273, 254);
            gbTempMEPE.Name = "gbTempMEPE";
            gbTempMEPE.Size = new Size(133, 40);
            gbTempMEPE.TabIndex = 11;
            gbTempMEPE.TabStop = false;
            gbTempMEPE.Text = "Unowned BPs:";
            // 
            // txtCalcTempTE
            // 
            txtCalcTempTE.Location = new Point(97, 13);
            txtCalcTempTE.Name = "txtCalcTempTE";
            txtCalcTempTE.Size = new Size(29, 20);
            txtCalcTempTE.TabIndex = 3;
            // 
            // lblTempPE
            // 
            lblTempPE.AutoSize = true;
            lblTempPE.Location = new Point(70, 17);
            lblTempPE.Name = "lblTempPE";
            lblTempPE.Size = new Size(24, 13);
            lblTempPE.TabIndex = 2;
            lblTempPE.Text = "TE:";
            // 
            // txtCalcTempME
            // 
            txtCalcTempME.Location = new Point(37, 13);
            txtCalcTempME.Name = "txtCalcTempME";
            txtCalcTempME.Size = new Size(29, 20);
            txtCalcTempME.TabIndex = 1;
            // 
            // lblTempME
            // 
            lblTempME.AutoSize = true;
            lblTempME.Location = new Point(13, 17);
            lblTempME.Name = "lblTempME";
            lblTempME.Size = new Size(26, 13);
            lblTempME.TabIndex = 0;
            lblTempME.Text = "ME:";
            // 
            // tabCalcFacilities
            // 
            tabCalcFacilities.Controls.Add(tabCalcFacilityBase);
            tabCalcFacilities.Controls.Add(tabCalcFacilityComponents);
            tabCalcFacilities.Controls.Add(tabCalcFacilityCopy);
            tabCalcFacilities.Controls.Add(tabCalcFacilityT2Invention);
            tabCalcFacilities.Controls.Add(tabCalcFacilityT3Invention);
            tabCalcFacilities.Controls.Add(tabCalcFacilitySupers);
            tabCalcFacilities.Controls.Add(tabCalcFacilityCapitals);
            tabCalcFacilities.Controls.Add(tabCalcFacilityT3Ships);
            tabCalcFacilities.Controls.Add(tabCalcFacilitySubsystems);
            tabCalcFacilities.Controls.Add(tabCalcFacilityBoosters);
            tabCalcFacilities.Controls.Add(tabCalcFacilityReactions);
            tabCalcFacilities.DataBindings.Add(new Binding("Font", My.MySettings.Default, "MyDefault", true, DataSourceUpdateMode.OnPropertyChanged));
            tabCalcFacilities.Font = My.MySettings.Default.MyDefault;
            tabCalcFacilities.HotTrack = true;
            tabCalcFacilities.ItemSize = new Size(49, 20);
            tabCalcFacilities.Location = new Point(546, 13);
            tabCalcFacilities.Multiline = true;
            tabCalcFacilities.Name = "tabCalcFacilities";
            tabCalcFacilities.Padding = new Point(0, 0);
            tabCalcFacilities.RightToLeft = RightToLeft.No;
            tabCalcFacilities.SelectedIndex = 0;
            tabCalcFacilities.Size = new Size(310, 176);
            tabCalcFacilities.SizeMode = TabSizeMode.FillToRight;
            tabCalcFacilities.TabIndex = 13;
            // 
            // tabCalcFacilityBase
            // 
            tabCalcFacilityBase.Controls.Add(CalcBaseFacility);
            tabCalcFacilityBase.Location = new Point(4, 44);
            tabCalcFacilityBase.Margin = new Padding(0);
            tabCalcFacilityBase.Name = "tabCalcFacilityBase";
            tabCalcFacilityBase.Padding = new Padding(3);
            tabCalcFacilityBase.Size = new Size(302, 128);
            tabCalcFacilityBase.TabIndex = 1;
            tabCalcFacilityBase.Text = "Base";
            tabCalcFacilityBase.UseVisualStyleBackColor = true;
            // 
            // CalcBaseFacility
            // 
            CalcBaseFacility.Location = new Point(0, 0);
            CalcBaseFacility.Name = "CalcBaseFacility";
            CalcBaseFacility.Size = new Size(303, 128);
            CalcBaseFacility.TabIndex = 0;
            // 
            // tabCalcFacilityComponents
            // 
            tabCalcFacilityComponents.Controls.Add(CalcComponentsFacility);
            tabCalcFacilityComponents.Location = new Point(4, 44);
            tabCalcFacilityComponents.Name = "tabCalcFacilityComponents";
            tabCalcFacilityComponents.Size = new Size(302, 128);
            tabCalcFacilityComponents.TabIndex = 10;
            tabCalcFacilityComponents.Text = "Components";
            tabCalcFacilityComponents.UseVisualStyleBackColor = true;
            // 
            // CalcComponentsFacility
            // 
            CalcComponentsFacility.Location = new Point(0, 0);
            CalcComponentsFacility.Name = "CalcComponentsFacility";
            CalcComponentsFacility.Size = new Size(303, 128);
            CalcComponentsFacility.TabIndex = 1;
            // 
            // tabCalcFacilityCopy
            // 
            tabCalcFacilityCopy.Controls.Add(CalcCopyFacility);
            tabCalcFacilityCopy.Location = new Point(4, 44);
            tabCalcFacilityCopy.Name = "tabCalcFacilityCopy";
            tabCalcFacilityCopy.Size = new Size(302, 128);
            tabCalcFacilityCopy.TabIndex = 3;
            tabCalcFacilityCopy.Text = "Copy";
            tabCalcFacilityCopy.UseVisualStyleBackColor = true;
            // 
            // CalcCopyFacility
            // 
            CalcCopyFacility.Location = new Point(0, 0);
            CalcCopyFacility.Name = "CalcCopyFacility";
            CalcCopyFacility.Size = new Size(303, 128);
            CalcCopyFacility.TabIndex = 1;
            // 
            // tabCalcFacilityT2Invention
            // 
            tabCalcFacilityT2Invention.Controls.Add(CalcInventionFacility);
            tabCalcFacilityT2Invention.Location = new Point(4, 44);
            tabCalcFacilityT2Invention.Name = "tabCalcFacilityT2Invention";
            tabCalcFacilityT2Invention.Size = new Size(302, 128);
            tabCalcFacilityT2Invention.TabIndex = 2;
            tabCalcFacilityT2Invention.Text = "T2 Inv";
            tabCalcFacilityT2Invention.UseVisualStyleBackColor = true;
            // 
            // CalcInventionFacility
            // 
            CalcInventionFacility.Location = new Point(0, 0);
            CalcInventionFacility.Name = "CalcInventionFacility";
            CalcInventionFacility.Size = new Size(303, 128);
            CalcInventionFacility.TabIndex = 1;
            // 
            // tabCalcFacilityT3Invention
            // 
            tabCalcFacilityT3Invention.Controls.Add(CalcT3InventionFacility);
            tabCalcFacilityT3Invention.Location = new Point(4, 44);
            tabCalcFacilityT3Invention.Name = "tabCalcFacilityT3Invention";
            tabCalcFacilityT3Invention.Size = new Size(302, 128);
            tabCalcFacilityT3Invention.TabIndex = 11;
            tabCalcFacilityT3Invention.Text = "T3 Inv";
            tabCalcFacilityT3Invention.UseVisualStyleBackColor = true;
            // 
            // CalcT3InventionFacility
            // 
            CalcT3InventionFacility.Location = new Point(0, 0);
            CalcT3InventionFacility.Name = "CalcT3InventionFacility";
            CalcT3InventionFacility.Size = new Size(303, 128);
            CalcT3InventionFacility.TabIndex = 1;
            // 
            // tabCalcFacilitySupers
            // 
            tabCalcFacilitySupers.Controls.Add(CalcSupersFacility);
            tabCalcFacilitySupers.Location = new Point(4, 44);
            tabCalcFacilitySupers.Name = "tabCalcFacilitySupers";
            tabCalcFacilitySupers.Size = new Size(302, 128);
            tabCalcFacilitySupers.TabIndex = 6;
            tabCalcFacilitySupers.Text = "Supers";
            tabCalcFacilitySupers.UseVisualStyleBackColor = true;
            // 
            // CalcSupersFacility
            // 
            CalcSupersFacility.Location = new Point(0, 0);
            CalcSupersFacility.Name = "CalcSupersFacility";
            CalcSupersFacility.Size = new Size(303, 128);
            CalcSupersFacility.TabIndex = 1;
            // 
            // tabCalcFacilityCapitals
            // 
            tabCalcFacilityCapitals.Controls.Add(CalcCapitalsFacility);
            tabCalcFacilityCapitals.Location = new Point(4, 44);
            tabCalcFacilityCapitals.Name = "tabCalcFacilityCapitals";
            tabCalcFacilityCapitals.Size = new Size(302, 128);
            tabCalcFacilityCapitals.TabIndex = 5;
            tabCalcFacilityCapitals.Text = "Capitals";
            tabCalcFacilityCapitals.UseVisualStyleBackColor = true;
            // 
            // CalcCapitalsFacility
            // 
            CalcCapitalsFacility.Location = new Point(0, 0);
            CalcCapitalsFacility.Name = "CalcCapitalsFacility";
            CalcCapitalsFacility.Size = new Size(303, 128);
            CalcCapitalsFacility.TabIndex = 1;
            // 
            // tabCalcFacilityT3Ships
            // 
            tabCalcFacilityT3Ships.Controls.Add(CalcT3ShipsFacility);
            tabCalcFacilityT3Ships.Location = new Point(4, 44);
            tabCalcFacilityT3Ships.Name = "tabCalcFacilityT3Ships";
            tabCalcFacilityT3Ships.Size = new Size(302, 128);
            tabCalcFacilityT3Ships.TabIndex = 9;
            tabCalcFacilityT3Ships.Text = "T3 Ships";
            tabCalcFacilityT3Ships.UseVisualStyleBackColor = true;
            // 
            // CalcT3ShipsFacility
            // 
            CalcT3ShipsFacility.Location = new Point(0, 0);
            CalcT3ShipsFacility.Name = "CalcT3ShipsFacility";
            CalcT3ShipsFacility.Size = new Size(303, 128);
            CalcT3ShipsFacility.TabIndex = 1;
            // 
            // tabCalcFacilitySubsystems
            // 
            tabCalcFacilitySubsystems.Controls.Add(CalcSubsystemsFacility);
            tabCalcFacilitySubsystems.Location = new Point(4, 44);
            tabCalcFacilitySubsystems.Name = "tabCalcFacilitySubsystems";
            tabCalcFacilitySubsystems.Size = new Size(302, 128);
            tabCalcFacilitySubsystems.TabIndex = 8;
            tabCalcFacilitySubsystems.Text = "Subsystems";
            tabCalcFacilitySubsystems.UseVisualStyleBackColor = true;
            // 
            // CalcSubsystemsFacility
            // 
            CalcSubsystemsFacility.Location = new Point(0, 0);
            CalcSubsystemsFacility.Name = "CalcSubsystemsFacility";
            CalcSubsystemsFacility.Size = new Size(303, 128);
            CalcSubsystemsFacility.TabIndex = 1;
            // 
            // tabCalcFacilityBoosters
            // 
            tabCalcFacilityBoosters.Controls.Add(CalcBoostersFacility);
            tabCalcFacilityBoosters.Location = new Point(4, 44);
            tabCalcFacilityBoosters.Name = "tabCalcFacilityBoosters";
            tabCalcFacilityBoosters.Size = new Size(302, 128);
            tabCalcFacilityBoosters.TabIndex = 7;
            tabCalcFacilityBoosters.Text = "Boosters";
            tabCalcFacilityBoosters.UseVisualStyleBackColor = true;
            // 
            // CalcBoostersFacility
            // 
            CalcBoostersFacility.Location = new Point(0, 0);
            CalcBoostersFacility.Name = "CalcBoostersFacility";
            CalcBoostersFacility.Size = new Size(303, 128);
            CalcBoostersFacility.TabIndex = 1;
            // 
            // tabCalcFacilityReactions
            // 
            tabCalcFacilityReactions.Controls.Add(CalcReactionsFacility);
            tabCalcFacilityReactions.Location = new Point(4, 44);
            tabCalcFacilityReactions.Name = "tabCalcFacilityReactions";
            tabCalcFacilityReactions.Size = new Size(302, 128);
            tabCalcFacilityReactions.TabIndex = 4;
            tabCalcFacilityReactions.Text = "Reactions";
            tabCalcFacilityReactions.UseVisualStyleBackColor = true;
            // 
            // CalcReactionsFacility
            // 
            CalcReactionsFacility.Location = new Point(0, 0);
            CalcReactionsFacility.Name = "CalcReactionsFacility";
            CalcReactionsFacility.Size = new Size(303, 128);
            CalcReactionsFacility.TabIndex = 1;
            // 
            // gbCalcFilter
            // 
            gbCalcFilter.Controls.Add(cmbCalcBPTypeFilter);
            gbCalcFilter.Location = new Point(6, 201);
            gbCalcFilter.Name = "gbCalcFilter";
            gbCalcFilter.Size = new Size(210, 49);
            gbCalcFilter.TabIndex = 8;
            gbCalcFilter.TabStop = false;
            gbCalcFilter.Text = "Item Type Filter:";
            // 
            // cmbCalcBPTypeFilter
            // 
            cmbCalcBPTypeFilter.FormattingEnabled = true;
            cmbCalcBPTypeFilter.Location = new Point(9, 18);
            cmbCalcBPTypeFilter.Name = "cmbCalcBPTypeFilter";
            cmbCalcBPTypeFilter.Size = new Size(195, 21);
            cmbCalcBPTypeFilter.TabIndex = 0;
            cmbCalcBPTypeFilter.Text = "All Types";
            // 
            // gbCalcBPTech
            // 
            gbCalcBPTech.Controls.Add(chkCalcPirateFaction);
            gbCalcBPTech.Controls.Add(chkCalcStoryline);
            gbCalcBPTech.Controls.Add(chkCalcNavyFaction);
            gbCalcBPTech.Controls.Add(chkCalcT3);
            gbCalcBPTech.Controls.Add(chkCalcT2);
            gbCalcBPTech.Controls.Add(chkCalcT1);
            gbCalcBPTech.Location = new Point(209, 15);
            gbCalcBPTech.Name = "gbCalcBPTech";
            gbCalcBPTech.Size = new Size(142, 65);
            gbCalcBPTech.TabIndex = 2;
            gbCalcBPTech.TabStop = false;
            gbCalcBPTech.Text = "Tech";
            // 
            // chkCalcPirateFaction
            // 
            chkCalcPirateFaction.AutoSize = true;
            chkCalcPirateFaction.Location = new Point(76, 45);
            chkCalcPirateFaction.Name = "chkCalcPirateFaction";
            chkCalcPirateFaction.Size = new Size(53, 17);
            chkCalcPirateFaction.TabIndex = 5;
            chkCalcPirateFaction.Text = "Pirate";
            chkCalcPirateFaction.TextAlign = ContentAlignment.TopLeft;
            chkCalcPirateFaction.UseVisualStyleBackColor = true;
            // 
            // chkCalcStoryline
            // 
            chkCalcStoryline.AutoSize = true;
            chkCalcStoryline.Location = new Point(76, 13);
            chkCalcStoryline.Name = "chkCalcStoryline";
            chkCalcStoryline.Size = new Size(66, 17);
            chkCalcStoryline.TabIndex = 3;
            chkCalcStoryline.Text = "Storyline";
            chkCalcStoryline.UseVisualStyleBackColor = true;
            // 
            // chkCalcNavyFaction
            // 
            chkCalcNavyFaction.AutoSize = true;
            chkCalcNavyFaction.Location = new Point(76, 29);
            chkCalcNavyFaction.Name = "chkCalcNavyFaction";
            chkCalcNavyFaction.Size = new Size(51, 17);
            chkCalcNavyFaction.TabIndex = 4;
            chkCalcNavyFaction.Text = "Navy";
            chkCalcNavyFaction.TextAlign = ContentAlignment.TopLeft;
            chkCalcNavyFaction.UseVisualStyleBackColor = true;
            // 
            // chkCalcT3
            // 
            chkCalcT3.AutoSize = true;
            chkCalcT3.Location = new Point(14, 46);
            chkCalcT3.Name = "chkCalcT3";
            chkCalcT3.Size = new Size(60, 17);
            chkCalcT3.TabIndex = 2;
            chkCalcT3.Text = "Tech 3";
            chkCalcT3.UseVisualStyleBackColor = true;
            // 
            // chkCalcT2
            // 
            chkCalcT2.AutoSize = true;
            chkCalcT2.Location = new Point(14, 29);
            chkCalcT2.Name = "chkCalcT2";
            chkCalcT2.Size = new Size(60, 17);
            chkCalcT2.TabIndex = 1;
            chkCalcT2.Text = "Tech 2";
            chkCalcT2.UseVisualStyleBackColor = true;
            // 
            // chkCalcT1
            // 
            chkCalcT1.AutoSize = true;
            chkCalcT1.Location = new Point(14, 14);
            chkCalcT1.Name = "chkCalcT1";
            chkCalcT1.Size = new Size(60, 17);
            chkCalcT1.TabIndex = 0;
            chkCalcT1.Text = "Tech 1";
            chkCalcT1.UseVisualStyleBackColor = true;
            // 
            // gbCalcIncludeOwned
            // 
            gbCalcIncludeOwned.Controls.Add(chkCalcIncludeT3Owned);
            gbCalcIncludeOwned.Controls.Add(chkCalcIncludeT2Owned);
            gbCalcIncludeOwned.Location = new Point(104, 15);
            gbCalcIncludeOwned.Name = "gbCalcIncludeOwned";
            gbCalcIncludeOwned.Size = new Size(102, 65);
            gbCalcIncludeOwned.TabIndex = 1;
            gbCalcIncludeOwned.TabStop = false;
            gbCalcIncludeOwned.Text = "Include Owned";
            // 
            // chkCalcIncludeT3Owned
            // 
            chkCalcIncludeT3Owned.AutoSize = true;
            chkCalcIncludeT3Owned.Location = new Point(8, 44);
            chkCalcIncludeT3Owned.Name = "chkCalcIncludeT3Owned";
            chkCalcIncludeT3Owned.Size = new Size(84, 17);
            chkCalcIncludeT3Owned.TabIndex = 1;
            chkCalcIncludeT3Owned.Text = "T3 Invented";
            chkCalcIncludeT3Owned.UseVisualStyleBackColor = true;
            // 
            // chkCalcIncludeT2Owned
            // 
            chkCalcIncludeT2Owned.AutoSize = true;
            chkCalcIncludeT2Owned.Location = new Point(8, 21);
            chkCalcIncludeT2Owned.Name = "chkCalcIncludeT2Owned";
            chkCalcIncludeT2Owned.Size = new Size(84, 17);
            chkCalcIncludeT2Owned.TabIndex = 0;
            chkCalcIncludeT2Owned.Text = "T2 Invented";
            chkCalcIncludeT2Owned.UseVisualStyleBackColor = true;
            // 
            // btnCalcSaveSettings
            // 
            btnCalcSaveSettings.Location = new Point(1018, 136);
            btnCalcSaveSettings.Name = "btnCalcSaveSettings";
            btnCalcSaveSettings.Size = new Size(98, 29);
            btnCalcSaveSettings.TabIndex = 24;
            btnCalcSaveSettings.Text = "Save Settings";
            btnCalcSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnCalcExportList
            // 
            btnCalcExportList.Location = new Point(1018, 165);
            btnCalcExportList.Name = "btnCalcExportList";
            btnCalcExportList.Size = new Size(98, 29);
            btnCalcExportList.TabIndex = 25;
            btnCalcExportList.Text = "Export Table";
            btnCalcExportList.UseVisualStyleBackColor = true;
            // 
            // btnCalcPreview
            // 
            btnCalcPreview.Location = new Point(1018, 20);
            btnCalcPreview.Name = "btnCalcPreview";
            btnCalcPreview.Size = new Size(98, 29);
            btnCalcPreview.TabIndex = 20;
            btnCalcPreview.Text = "Preview Item List";
            btnCalcPreview.UseVisualStyleBackColor = true;
            // 
            // btnCalcReset
            // 
            btnCalcReset.Location = new Point(1018, 78);
            btnCalcReset.Name = "btnCalcReset";
            btnCalcReset.Size = new Size(98, 29);
            btnCalcReset.TabIndex = 22;
            btnCalcReset.Text = "Reset";
            btnCalcReset.UseVisualStyleBackColor = true;
            // 
            // gbCalcTextFilter
            // 
            gbCalcTextFilter.Controls.Add(btnCalcResetTextSearch);
            gbCalcTextFilter.Controls.Add(txtCalcItemFilter);
            gbCalcTextFilter.Location = new Point(6, 251);
            gbCalcTextFilter.Name = "gbCalcTextFilter";
            gbCalcTextFilter.Size = new Size(261, 43);
            gbCalcTextFilter.TabIndex = 9;
            gbCalcTextFilter.TabStop = false;
            gbCalcTextFilter.Text = "Text Item Filter:";
            // 
            // btnCalcResetTextSearch
            // 
            btnCalcResetTextSearch.Location = new Point(216, 15);
            btnCalcResetTextSearch.Name = "btnCalcResetTextSearch";
            btnCalcResetTextSearch.Size = new Size(39, 21);
            btnCalcResetTextSearch.TabIndex = 1;
            btnCalcResetTextSearch.Text = "Clear";
            btnCalcResetTextSearch.UseVisualStyleBackColor = true;
            // 
            // txtCalcItemFilter
            // 
            txtCalcItemFilter.Location = new Point(9, 16);
            txtCalcItemFilter.Name = "txtCalcItemFilter";
            txtCalcItemFilter.Size = new Size(201, 20);
            txtCalcItemFilter.TabIndex = 0;
            // 
            // gbCalcBPType
            // 
            gbCalcBPType.Controls.Add(chkCalcReactions);
            gbCalcBPType.Controls.Add(chkCalcCelestials);
            gbCalcBPType.Controls.Add(chkCalcMisc);
            gbCalcBPType.Controls.Add(chkCalcSubsystems);
            gbCalcBPType.Controls.Add(chkCalcDeployables);
            gbCalcBPType.Controls.Add(chkCalcStructures);
            gbCalcBPType.Controls.Add(chkCalcStructureRigs);
            gbCalcBPType.Controls.Add(chkCalcBoosters);
            gbCalcBPType.Controls.Add(chkCalcRigs);
            gbCalcBPType.Controls.Add(chkCalcComponents);
            gbCalcBPType.Controls.Add(chkCalcAmmo);
            gbCalcBPType.Controls.Add(chkCalcDrones);
            gbCalcBPType.Controls.Add(chkCalcModules);
            gbCalcBPType.Controls.Add(chkCalcShips);
            gbCalcBPType.Controls.Add(chkCalcStructureModules);
            gbCalcBPType.Location = new Point(355, 15);
            gbCalcBPType.Name = "gbCalcBPType";
            gbCalcBPType.Size = new Size(188, 132);
            gbCalcBPType.TabIndex = 5;
            gbCalcBPType.TabStop = false;
            gbCalcBPType.Text = "Blueprint Type:";
            // 
            // chkCalcReactions
            // 
            chkCalcReactions.AutoSize = true;
            chkCalcReactions.Location = new Point(111, 111);
            chkCalcReactions.Name = "chkCalcReactions";
            chkCalcReactions.Size = new Size(74, 17);
            chkCalcReactions.TabIndex = 14;
            chkCalcReactions.Text = "Reactions";
            chkCalcReactions.UseVisualStyleBackColor = true;
            // 
            // chkCalcCelestials
            // 
            chkCalcCelestials.AutoSize = true;
            chkCalcCelestials.Location = new Point(111, 95);
            chkCalcCelestials.Name = "chkCalcCelestials";
            chkCalcCelestials.Size = new Size(70, 17);
            chkCalcCelestials.TabIndex = 10;
            chkCalcCelestials.Text = "Celestials";
            chkCalcCelestials.UseVisualStyleBackColor = true;
            // 
            // chkCalcMisc
            // 
            chkCalcMisc.AutoSize = true;
            chkCalcMisc.Location = new Point(130, 47);
            chkCalcMisc.Name = "chkCalcMisc";
            chkCalcMisc.Size = new Size(51, 17);
            chkCalcMisc.TabIndex = 12;
            chkCalcMisc.Text = "Misc.";
            chkCalcMisc.UseVisualStyleBackColor = true;
            // 
            // chkCalcSubsystems
            // 
            chkCalcSubsystems.AutoSize = true;
            chkCalcSubsystems.Location = new Point(84, 63);
            chkCalcSubsystems.Name = "chkCalcSubsystems";
            chkCalcSubsystems.Size = new Size(82, 17);
            chkCalcSubsystems.TabIndex = 7;
            chkCalcSubsystems.Text = "Subsystems";
            chkCalcSubsystems.UseVisualStyleBackColor = true;
            // 
            // chkCalcDeployables
            // 
            chkCalcDeployables.AutoSize = true;
            chkCalcDeployables.Location = new Point(5, 63);
            chkCalcDeployables.Name = "chkCalcDeployables";
            chkCalcDeployables.Size = new Size(84, 17);
            chkCalcDeployables.TabIndex = 6;
            chkCalcDeployables.Text = "Deployables";
            chkCalcDeployables.UseVisualStyleBackColor = true;
            // 
            // chkCalcStructures
            // 
            chkCalcStructures.AutoSize = true;
            chkCalcStructures.Location = new Point(5, 79);
            chkCalcStructures.Name = "chkCalcStructures";
            chkCalcStructures.Size = new Size(74, 17);
            chkCalcStructures.TabIndex = 8;
            chkCalcStructures.Text = "Structures";
            chkCalcStructures.UseVisualStyleBackColor = true;
            // 
            // chkCalcStructureRigs
            // 
            chkCalcStructureRigs.AutoSize = true;
            chkCalcStructureRigs.Location = new Point(5, 95);
            chkCalcStructureRigs.Name = "chkCalcStructureRigs";
            chkCalcStructureRigs.Size = new Size(93, 17);
            chkCalcStructureRigs.TabIndex = 11;
            chkCalcStructureRigs.Text = "Structure Rigs";
            chkCalcStructureRigs.UseVisualStyleBackColor = true;
            // 
            // chkCalcBoosters
            // 
            chkCalcBoosters.AutoSize = true;
            chkCalcBoosters.Location = new Point(84, 79);
            chkCalcBoosters.Name = "chkCalcBoosters";
            chkCalcBoosters.Size = new Size(67, 17);
            chkCalcBoosters.TabIndex = 9;
            chkCalcBoosters.Text = "Boosters";
            chkCalcBoosters.UseVisualStyleBackColor = true;
            // 
            // chkCalcRigs
            // 
            chkCalcRigs.AutoSize = true;
            chkCalcRigs.Location = new Point(84, 47);
            chkCalcRigs.Name = "chkCalcRigs";
            chkCalcRigs.Size = new Size(47, 17);
            chkCalcRigs.TabIndex = 5;
            chkCalcRigs.Text = "Rigs";
            chkCalcRigs.UseVisualStyleBackColor = true;
            // 
            // chkCalcComponents
            // 
            chkCalcComponents.AutoSize = true;
            chkCalcComponents.Location = new Point(5, 47);
            chkCalcComponents.Name = "chkCalcComponents";
            chkCalcComponents.Size = new Size(85, 17);
            chkCalcComponents.TabIndex = 4;
            chkCalcComponents.Text = "Components";
            chkCalcComponents.UseVisualStyleBackColor = true;
            // 
            // chkCalcAmmo
            // 
            chkCalcAmmo.AutoSize = true;
            chkCalcAmmo.Location = new Point(84, 31);
            chkCalcAmmo.Name = "chkCalcAmmo";
            chkCalcAmmo.Size = new Size(99, 17);
            chkCalcAmmo.TabIndex = 3;
            chkCalcAmmo.Text = "Ammo/Charges";
            chkCalcAmmo.UseVisualStyleBackColor = true;
            // 
            // chkCalcDrones
            // 
            chkCalcDrones.AutoSize = true;
            chkCalcDrones.Location = new Point(5, 31);
            chkCalcDrones.Name = "chkCalcDrones";
            chkCalcDrones.Size = new Size(60, 17);
            chkCalcDrones.TabIndex = 2;
            chkCalcDrones.Text = "Drones";
            chkCalcDrones.UseVisualStyleBackColor = true;
            // 
            // chkCalcModules
            // 
            chkCalcModules.AutoSize = true;
            chkCalcModules.Location = new Point(84, 15);
            chkCalcModules.Name = "chkCalcModules";
            chkCalcModules.Size = new Size(66, 17);
            chkCalcModules.TabIndex = 1;
            chkCalcModules.Text = "Modules";
            chkCalcModules.UseVisualStyleBackColor = true;
            // 
            // chkCalcShips
            // 
            chkCalcShips.AutoSize = true;
            chkCalcShips.Location = new Point(5, 15);
            chkCalcShips.Name = "chkCalcShips";
            chkCalcShips.Size = new Size(52, 17);
            chkCalcShips.TabIndex = 0;
            chkCalcShips.Text = "Ships";
            chkCalcShips.UseVisualStyleBackColor = true;
            // 
            // chkCalcStructureModules
            // 
            chkCalcStructureModules.AutoSize = true;
            chkCalcStructureModules.Location = new Point(5, 111);
            chkCalcStructureModules.Name = "chkCalcStructureModules";
            chkCalcStructureModules.Size = new Size(112, 17);
            chkCalcStructureModules.TabIndex = 13;
            chkCalcStructureModules.Text = "Structure Modules";
            chkCalcStructureModules.UseVisualStyleBackColor = true;
            // 
            // gbCalcBPSelect
            // 
            gbCalcBPSelect.Controls.Add(rbtnCalcBPFavorites);
            gbCalcBPSelect.Controls.Add(rbtnCalcAllBPs);
            gbCalcBPSelect.Controls.Add(rbtnCalcBPOwned);
            gbCalcBPSelect.Location = new Point(6, 15);
            gbCalcBPSelect.Name = "gbCalcBPSelect";
            gbCalcBPSelect.Size = new Size(95, 65);
            gbCalcBPSelect.TabIndex = 0;
            gbCalcBPSelect.TabStop = false;
            gbCalcBPSelect.Text = "Load:";
            // 
            // rbtnCalcBPFavorites
            // 
            rbtnCalcBPFavorites.AutoSize = true;
            rbtnCalcBPFavorites.Location = new Point(8, 44);
            rbtnCalcBPFavorites.Name = "rbtnCalcBPFavorites";
            rbtnCalcBPFavorites.Size = new Size(68, 17);
            rbtnCalcBPFavorites.TabIndex = 2;
            rbtnCalcBPFavorites.Text = "Favorites";
            rbtnCalcBPFavorites.UseVisualStyleBackColor = true;
            // 
            // rbtnCalcAllBPs
            // 
            rbtnCalcAllBPs.AutoSize = true;
            rbtnCalcAllBPs.Location = new Point(8, 14);
            rbtnCalcAllBPs.Name = "rbtnCalcAllBPs";
            rbtnCalcAllBPs.Size = new Size(85, 17);
            rbtnCalcAllBPs.TabIndex = 0;
            rbtnCalcAllBPs.Text = "All Blueprints";
            rbtnCalcAllBPs.UseVisualStyleBackColor = true;
            // 
            // rbtnCalcBPOwned
            // 
            rbtnCalcBPOwned.AutoSize = true;
            rbtnCalcBPOwned.Location = new Point(8, 29);
            rbtnCalcBPOwned.Name = "rbtnCalcBPOwned";
            rbtnCalcBPOwned.Size = new Size(81, 17);
            rbtnCalcBPOwned.TabIndex = 1;
            rbtnCalcBPOwned.Text = "Owned BPs";
            rbtnCalcBPOwned.UseVisualStyleBackColor = true;
            // 
            // gbCalcRelics
            // 
            gbCalcRelics.Controls.Add(chkCalcRERelic2);
            gbCalcRelics.Controls.Add(chkCalcRERelic3);
            gbCalcRelics.Controls.Add(chkCalcRERelic1);
            gbCalcRelics.Location = new Point(273, 201);
            gbCalcRelics.Name = "gbCalcRelics";
            gbCalcRelics.Size = new Size(133, 52);
            gbCalcRelics.TabIndex = 7;
            gbCalcRelics.TabStop = false;
            gbCalcRelics.Text = "Invention Relics:";
            // 
            // chkCalcRERelic2
            // 
            chkCalcRERelic2.Location = new Point(9, 30);
            chkCalcRERelic2.Name = "chkCalcRERelic2";
            chkCalcRERelic2.Size = new Size(95, 17);
            chkCalcRERelic2.TabIndex = 1;
            chkCalcRERelic2.Text = "Malfunctioning";
            chkCalcRERelic2.UseVisualStyleBackColor = true;
            // 
            // chkCalcRERelic3
            // 
            chkCalcRERelic3.AutoSize = true;
            chkCalcRERelic3.Location = new Point(78, 14);
            chkCalcRERelic3.Name = "chkCalcRERelic3";
            chkCalcRERelic3.Size = new Size(53, 17);
            chkCalcRERelic3.TabIndex = 2;
            chkCalcRERelic3.Text = "Intact";
            chkCalcRERelic3.UseVisualStyleBackColor = true;
            // 
            // chkCalcRERelic1
            // 
            chkCalcRERelic1.AutoSize = true;
            chkCalcRERelic1.Location = new Point(9, 14);
            chkCalcRERelic1.Name = "chkCalcRERelic1";
            chkCalcRERelic1.Size = new Size(70, 17);
            chkCalcRERelic1.TabIndex = 0;
            chkCalcRERelic1.Text = "Wrecked";
            chkCalcRERelic1.UseVisualStyleBackColor = true;
            // 
            // tabUpdatePrices
            // 
            tabUpdatePrices.Controls.Add(gbRawMaterials);
            tabUpdatePrices.Controls.Add(gbSingleSource);
            tabUpdatePrices.Controls.Add(gbPriceProfile);
            tabUpdatePrices.Controls.Add(btnLoadPricesfromFile);
            tabUpdatePrices.Controls.Add(btnSavePricestoFile);
            tabUpdatePrices.Controls.Add(lstPricesView);
            tabUpdatePrices.Controls.Add(txtPriceItemFilter);
            tabUpdatePrices.Controls.Add(gbPriceOptions);
            tabUpdatePrices.Controls.Add(btnSaveUpdatePrices);
            tabUpdatePrices.Controls.Add(btnCancelUpdate);
            tabUpdatePrices.Controls.Add(btnClearItemFilter);
            tabUpdatePrices.Controls.Add(btnToggleAllPriceItems);
            tabUpdatePrices.Controls.Add(btnDownloadPrices);
            tabUpdatePrices.Controls.Add(lblItemFilter);
            tabUpdatePrices.Controls.Add(gbManufacturedItems);
            tabUpdatePrices.Controls.Add(btnOpenMarketBrowser);
            tabUpdatePrices.Location = new Point(4, 22);
            tabUpdatePrices.Name = "tabUpdatePrices";
            tabUpdatePrices.Padding = new Padding(3);
            tabUpdatePrices.Size = new Size(1137, 615);
            tabUpdatePrices.TabIndex = 1;
            tabUpdatePrices.Text = "Update Prices";
            tabUpdatePrices.UseVisualStyleBackColor = true;
            // 
            // gbRawMaterials
            // 
            gbRawMaterials.Controls.Add(gbReactionMaterials);
            gbRawMaterials.Controls.Add(gbResearchEquipment);
            gbRawMaterials.Controls.Add(chkMinerals);
            gbRawMaterials.Controls.Add(chkFactionMaterials);
            gbRawMaterials.Controls.Add(chkNamedComponents);
            gbRawMaterials.Controls.Add(chkMisc);
            gbRawMaterials.Controls.Add(chkMolecularForgingTools);
            gbRawMaterials.Controls.Add(chkAdvancedProtectiveTechnology);
            gbRawMaterials.Controls.Add(chkBPCs);
            gbRawMaterials.Controls.Add(chkRawMaterials);
            gbRawMaterials.Controls.Add(chkPriceMaterialResearchEqPrices);
            gbRawMaterials.Controls.Add(chkPlanetary);
            gbRawMaterials.Controls.Add(chkGas);
            gbRawMaterials.Controls.Add(chkSalvage);
            gbRawMaterials.Controls.Add(chkIceProducts);
            gbRawMaterials.Location = new Point(8, 337);
            gbRawMaterials.Name = "gbRawMaterials";
            gbRawMaterials.Size = new Size(257, 238);
            gbRawMaterials.TabIndex = 1;
            gbRawMaterials.TabStop = false;
            // 
            // gbReactionMaterials
            // 
            gbReactionMaterials.Controls.Add(chkAdvancedMats);
            gbReactionMaterials.Controls.Add(chkBoosterMats);
            gbReactionMaterials.Controls.Add(chkMolecularForgedMaterials);
            gbReactionMaterials.Controls.Add(chkPolymers);
            gbReactionMaterials.Controls.Add(chkProcessedMats);
            gbReactionMaterials.Controls.Add(chkRawMoonMats);
            gbReactionMaterials.Location = new Point(4, 123);
            gbReactionMaterials.Name = "gbReactionMaterials";
            gbReactionMaterials.Size = new Size(249, 70);
            gbReactionMaterials.TabIndex = 27;
            gbReactionMaterials.TabStop = false;
            gbReactionMaterials.Text = "Reaction Materials";
            // 
            // chkAdvancedMats
            // 
            chkAdvancedMats.AutoSize = true;
            chkAdvancedMats.Location = new Point(5, 16);
            chkAdvancedMats.Name = "chkAdvancedMats";
            chkAdvancedMats.Size = new Size(105, 17);
            chkAdvancedMats.TabIndex = 15;
            chkAdvancedMats.Text = "Advanced Moon";
            chkAdvancedMats.UseVisualStyleBackColor = true;
            // 
            // chkBoosterMats
            // 
            chkBoosterMats.AutoSize = true;
            chkBoosterMats.Location = new Point(125, 16);
            chkBoosterMats.Name = "chkBoosterMats";
            chkBoosterMats.Size = new Size(107, 17);
            chkBoosterMats.TabIndex = 18;
            chkBoosterMats.Text = "Booster Materials";
            chkBoosterMats.UseVisualStyleBackColor = true;
            // 
            // chkMolecularForgedMaterials
            // 
            chkMolecularForgedMaterials.AutoSize = true;
            chkMolecularForgedMaterials.Location = new Point(5, 33);
            chkMolecularForgedMaterials.Name = "chkMolecularForgedMaterials";
            chkMolecularForgedMaterials.Size = new Size(108, 17);
            chkMolecularForgedMaterials.TabIndex = 21;
            chkMolecularForgedMaterials.Text = "Molecular-Forged";
            chkMolecularForgedMaterials.UseVisualStyleBackColor = true;
            // 
            // chkPolymers
            // 
            chkPolymers.AutoSize = true;
            chkPolymers.Location = new Point(125, 33);
            chkPolymers.Name = "chkPolymers";
            chkPolymers.Size = new Size(108, 17);
            chkPolymers.TabIndex = 10;
            chkPolymers.Text = "Polymer Materials";
            chkPolymers.UseVisualStyleBackColor = true;
            // 
            // chkProcessedMats
            // 
            chkProcessedMats.AutoSize = true;
            chkProcessedMats.Location = new Point(5, 50);
            chkProcessedMats.Name = "chkProcessedMats";
            chkProcessedMats.Size = new Size(106, 17);
            chkProcessedMats.TabIndex = 14;
            chkProcessedMats.Text = "Processed Moon";
            chkProcessedMats.UseVisualStyleBackColor = true;
            // 
            // chkRawMoonMats
            // 
            chkRawMoonMats.AutoSize = true;
            chkRawMoonMats.Location = new Point(125, 50);
            chkRawMoonMats.Name = "chkRawMoonMats";
            chkRawMoonMats.Size = new Size(123, 17);
            chkRawMoonMats.TabIndex = 13;
            chkRawMoonMats.Text = "Raw Moon Materials";
            chkRawMoonMats.UseVisualStyleBackColor = true;
            // 
            // gbResearchEquipment
            // 
            gbResearchEquipment.Controls.Add(chkRDb);
            gbResearchEquipment.Controls.Add(chkAncientRelics);
            gbResearchEquipment.Controls.Add(chkDecryptors);
            gbResearchEquipment.Controls.Add(chkDatacores);
            gbResearchEquipment.Location = new Point(4, 195);
            gbResearchEquipment.Name = "gbResearchEquipment";
            gbResearchEquipment.Size = new Size(249, 37);
            gbResearchEquipment.TabIndex = 26;
            gbResearchEquipment.TabStop = false;
            gbResearchEquipment.Text = "Research Equipment";
            // 
            // chkRDb
            // 
            chkRDb.AutoSize = true;
            chkRDb.Location = new Point(199, 16);
            chkRDb.Name = "chkRDb";
            chkRDb.Size = new Size(51, 17);
            chkRDb.TabIndex = 25;
            chkRDb.Text = "R.Db";
            chkRDb.UseVisualStyleBackColor = true;
            // 
            // chkAncientRelics
            // 
            chkAncientRelics.AutoSize = true;
            chkAncientRelics.Location = new Point(148, 16);
            chkAncientRelics.Name = "chkAncientRelics";
            chkAncientRelics.Size = new Size(55, 17);
            chkAncientRelics.TabIndex = 9;
            chkAncientRelics.Text = "Relics";
            chkAncientRelics.UseVisualStyleBackColor = true;
            // 
            // chkDecryptors
            // 
            chkDecryptors.AutoSize = true;
            chkDecryptors.Location = new Point(76, 16);
            chkDecryptors.Name = "chkDecryptors";
            chkDecryptors.Size = new Size(77, 17);
            chkDecryptors.TabIndex = 4;
            chkDecryptors.Text = "Decryptors";
            chkDecryptors.UseVisualStyleBackColor = true;
            // 
            // chkDatacores
            // 
            chkDatacores.AutoSize = true;
            chkDatacores.Location = new Point(5, 16);
            chkDatacores.Name = "chkDatacores";
            chkDatacores.Size = new Size(75, 17);
            chkDatacores.TabIndex = 2;
            chkDatacores.Text = "Datacores";
            chkDatacores.UseVisualStyleBackColor = true;
            // 
            // chkMinerals
            // 
            chkMinerals.AutoSize = true;
            chkMinerals.Location = new Point(147, 70);
            chkMinerals.Name = "chkMinerals";
            chkMinerals.Size = new Size(65, 17);
            chkMinerals.TabIndex = 0;
            chkMinerals.Text = "Minerals";
            chkMinerals.UseVisualStyleBackColor = true;
            // 
            // chkFactionMaterials
            // 
            chkFactionMaterials.AutoSize = true;
            chkFactionMaterials.Location = new Point(147, 53);
            chkFactionMaterials.Name = "chkFactionMaterials";
            chkFactionMaterials.Size = new Size(106, 17);
            chkFactionMaterials.TabIndex = 16;
            chkFactionMaterials.Text = "Faction Materials";
            chkFactionMaterials.UseVisualStyleBackColor = true;
            // 
            // chkNamedComponents
            // 
            chkNamedComponents.AutoSize = true;
            chkNamedComponents.Location = new Point(9, 70);
            chkNamedComponents.Name = "chkNamedComponents";
            chkNamedComponents.Size = new Size(122, 17);
            chkNamedComponents.TabIndex = 24;
            chkNamedComponents.Text = "Named Components";
            chkNamedComponents.UseVisualStyleBackColor = true;
            // 
            // chkMisc
            // 
            chkMisc.AutoSize = true;
            chkMisc.Location = new Point(80, 104);
            chkMisc.Name = "chkMisc";
            chkMisc.Size = new Size(51, 17);
            chkMisc.TabIndex = 12;
            chkMisc.Text = "Misc.";
            chkMisc.UseVisualStyleBackColor = true;
            // 
            // chkMolecularForgingTools
            // 
            chkMolecularForgingTools.AutoSize = true;
            chkMolecularForgingTools.Location = new Point(9, 53);
            chkMolecularForgingTools.Name = "chkMolecularForgingTools";
            chkMolecularForgingTools.Size = new Size(139, 17);
            chkMolecularForgingTools.TabIndex = 23;
            chkMolecularForgingTools.Text = "Molecular-Forging Tools";
            chkMolecularForgingTools.UseVisualStyleBackColor = true;
            // 
            // chkAdvancedProtectiveTechnology
            // 
            chkAdvancedProtectiveTechnology.AutoSize = true;
            chkAdvancedProtectiveTechnology.Location = new Point(9, 19);
            chkAdvancedProtectiveTechnology.Name = "chkAdvancedProtectiveTechnology";
            chkAdvancedProtectiveTechnology.Size = new Size(185, 17);
            chkAdvancedProtectiveTechnology.TabIndex = 22;
            chkAdvancedProtectiveTechnology.Text = "Advanced Protective Technology";
            chkAdvancedProtectiveTechnology.UseVisualStyleBackColor = true;
            // 
            // chkBPCs
            // 
            chkBPCs.AutoSize = true;
            chkBPCs.Location = new Point(147, 104);
            chkBPCs.Name = "chkBPCs";
            chkBPCs.Size = new Size(102, 17);
            chkBPCs.TabIndex = 19;
            chkBPCs.Text = "Blueprint Copies";
            chkBPCs.UseVisualStyleBackColor = true;
            // 
            // chkRawMaterials
            // 
            chkRawMaterials.AutoSize = true;
            chkRawMaterials.Location = new Point(147, 87);
            chkRawMaterials.Name = "chkRawMaterials";
            chkRawMaterials.Size = new Size(93, 17);
            chkRawMaterials.TabIndex = 6;
            chkRawMaterials.Text = "Raw Materials";
            chkRawMaterials.UseVisualStyleBackColor = true;
            // 
            // chkPriceMaterialResearchEqPrices
            // 
            chkPriceMaterialResearchEqPrices.AutoSize = true;
            chkPriceMaterialResearchEqPrices.BackColor = Color.White;
            chkPriceMaterialResearchEqPrices.Location = new Point(6, 1);
            chkPriceMaterialResearchEqPrices.Name = "chkPriceMaterialResearchEqPrices";
            chkPriceMaterialResearchEqPrices.Size = new Size(179, 17);
            chkPriceMaterialResearchEqPrices.TabIndex = 0;
            chkPriceMaterialResearchEqPrices.Text = "Materials && Research Equipment";
            chkPriceMaterialResearchEqPrices.UseVisualStyleBackColor = false;
            // 
            // chkPlanetary
            // 
            chkPlanetary.AutoSize = true;
            chkPlanetary.Location = new Point(9, 87);
            chkPlanetary.Name = "chkPlanetary";
            chkPlanetary.Size = new Size(115, 17);
            chkPlanetary.TabIndex = 5;
            chkPlanetary.Text = "Planetary Materials";
            chkPlanetary.UseVisualStyleBackColor = true;
            // 
            // chkGas
            // 
            chkGas.AutoSize = true;
            chkGas.Location = new Point(9, 36);
            chkGas.Name = "chkGas";
            chkGas.Size = new Size(120, 17);
            chkGas.TabIndex = 11;
            chkGas.Text = "Gas Cloud Materials";
            chkGas.UseVisualStyleBackColor = true;
            // 
            // chkSalvage
            // 
            chkSalvage.AutoSize = true;
            chkSalvage.Location = new Point(9, 104);
            chkSalvage.Name = "chkSalvage";
            chkSalvage.Size = new Size(65, 17);
            chkSalvage.TabIndex = 7;
            chkSalvage.Text = "Salvage";
            chkSalvage.UseVisualStyleBackColor = true;
            // 
            // chkIceProducts
            // 
            chkIceProducts.AutoSize = true;
            chkIceProducts.Location = new Point(147, 36);
            chkIceProducts.Name = "chkIceProducts";
            chkIceProducts.Size = new Size(86, 17);
            chkIceProducts.TabIndex = 1;
            chkIceProducts.Text = "Ice Products";
            chkIceProducts.UseVisualStyleBackColor = true;
            // 
            // gbSingleSource
            // 
            gbSingleSource.Controls.Add(gbMarketStructures);
            gbSingleSource.Controls.Add(gbRegionSystemPrice);
            gbSingleSource.Controls.Add(gbTradeHubSystems);
            gbSingleSource.Location = new Point(675, 381);
            gbSingleSource.Name = "gbSingleSource";
            gbSingleSource.Size = new Size(457, 102);
            gbSingleSource.TabIndex = 126;
            gbSingleSource.TabStop = false;
            gbSingleSource.Text = "Single Source ";
            // 
            // gbMarketStructures
            // 
            gbMarketStructures.Controls.Add(btnAddStructureIDs);
            gbMarketStructures.Controls.Add(btnViewSavedStructures);
            gbMarketStructures.Location = new Point(323, 18);
            gbMarketStructures.Name = "gbMarketStructures";
            gbMarketStructures.Size = new Size(127, 77);
            gbMarketStructures.TabIndex = 126;
            gbMarketStructures.TabStop = false;
            gbMarketStructures.Text = "Market Structures:";
            // 
            // btnAddStructureIDs
            // 
            btnAddStructureIDs.Location = new Point(13, 16);
            btnAddStructureIDs.Name = "btnAddStructureIDs";
            btnAddStructureIDs.Size = new Size(100, 25);
            btnAddStructureIDs.TabIndex = 71;
            btnAddStructureIDs.Text = "Add Structure IDs";
            btnAddStructureIDs.UseVisualStyleBackColor = true;
            // 
            // btnViewSavedStructures
            // 
            btnViewSavedStructures.Location = new Point(13, 46);
            btnViewSavedStructures.Name = "btnViewSavedStructures";
            btnViewSavedStructures.Size = new Size(100, 25);
            btnViewSavedStructures.TabIndex = 122;
            btnViewSavedStructures.Text = "View Saved SIDs";
            btnViewSavedStructures.UseVisualStyleBackColor = true;
            // 
            // gbRegionSystemPrice
            // 
            gbRegionSystemPrice.Controls.Add(cmbPriceRegions);
            gbRegionSystemPrice.Controls.Add(cmbPriceSystems);
            gbRegionSystemPrice.Location = new Point(184, 18);
            gbRegionSystemPrice.Name = "gbRegionSystemPrice";
            gbRegionSystemPrice.Size = new Size(133, 77);
            gbRegionSystemPrice.TabIndex = 125;
            gbRegionSystemPrice.TabStop = false;
            gbRegionSystemPrice.Text = "Region or System:";
            // 
            // cmbPriceRegions
            // 
            cmbPriceRegions.FormattingEnabled = true;
            cmbPriceRegions.Location = new Point(9, 18);
            cmbPriceRegions.Name = "cmbPriceRegions";
            cmbPriceRegions.Size = new Size(115, 21);
            cmbPriceRegions.TabIndex = 124;
            cmbPriceRegions.Text = "Select Region";
            // 
            // cmbPriceSystems
            // 
            cmbPriceSystems.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPriceSystems.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPriceSystems.FormattingEnabled = true;
            cmbPriceSystems.Location = new Point(9, 48);
            cmbPriceSystems.Name = "cmbPriceSystems";
            cmbPriceSystems.Size = new Size(115, 21);
            cmbPriceSystems.TabIndex = 5;
            cmbPriceSystems.Text = "Select System";
            // 
            // gbTradeHubSystems
            // 
            gbTradeHubSystems.Controls.Add(chkSystems6);
            gbTradeHubSystems.Controls.Add(chkSystems5);
            gbTradeHubSystems.Controls.Add(chkSystems4);
            gbTradeHubSystems.Controls.Add(chkSystems3);
            gbTradeHubSystems.Controls.Add(chkSystems2);
            gbTradeHubSystems.Controls.Add(_chkSystems1);
            gbTradeHubSystems.Location = new Point(8, 18);
            gbTradeHubSystems.Name = "gbTradeHubSystems";
            gbTradeHubSystems.Size = new Size(170, 77);
            gbTradeHubSystems.TabIndex = 8;
            gbTradeHubSystems.TabStop = false;
            gbTradeHubSystems.Text = "Trade Hub System:";
            // 
            // chkSystems6
            // 
            chkSystems6.AutoSize = true;
            chkSystems6.Location = new Point(89, 19);
            chkSystems6.Name = "chkSystems6";
            chkSystems6.Size = new Size(70, 17);
            chkSystems6.TabIndex = 7;
            chkSystems6.Text = "Perimeter";
            chkSystems6.UseVisualStyleBackColor = true;
            // 
            // chkSystems5
            // 
            chkSystems5.AutoSize = true;
            chkSystems5.Location = new Point(89, 53);
            chkSystems5.Name = "chkSystems5";
            chkSystems5.Size = new Size(46, 17);
            chkSystems5.TabIndex = 4;
            chkSystems5.Text = "Hek";
            chkSystems5.UseVisualStyleBackColor = true;
            // 
            // chkSystems4
            // 
            chkSystems4.AutoSize = true;
            chkSystems4.Location = new Point(14, 53);
            chkSystems4.Name = "chkSystems4";
            chkSystems4.Size = new Size(51, 17);
            chkSystems4.TabIndex = 3;
            chkSystems4.Text = "Rens";
            chkSystems4.UseVisualStyleBackColor = true;
            // 
            // chkSystems3
            // 
            chkSystems3.AutoSize = true;
            chkSystems3.Location = new Point(89, 36);
            chkSystems3.Name = "chkSystems3";
            chkSystems3.Size = new Size(61, 17);
            chkSystems3.TabIndex = 2;
            chkSystems3.Text = "Dodixie";
            chkSystems3.UseVisualStyleBackColor = true;
            // 
            // chkSystems2
            // 
            chkSystems2.AutoSize = true;
            chkSystems2.Location = new Point(14, 36);
            chkSystems2.Name = "chkSystems2";
            chkSystems2.Size = new Size(53, 17);
            chkSystems2.TabIndex = 1;
            chkSystems2.Text = "Amarr";
            chkSystems2.UseVisualStyleBackColor = true;
            // 
            // chkSystems1
            // 
            _chkSystems1.AutoSize = true;
            _chkSystems1.Location = new Point(14, 19);
            _chkSystems1.Name = "_chkSystems1";
            _chkSystems1.Size = new Size(42, 17);
            _chkSystems1.TabIndex = 0;
            _chkSystems1.Text = "Jita";
            _chkSystems1.UseVisualStyleBackColor = true;
            // 
            // gbPriceProfile
            // 
            gbPriceProfile.Controls.Add(tabPriceProfile);
            gbPriceProfile.Controls.Add(gbPPDefaultSettings);
            gbPriceProfile.Location = new Point(674, 4);
            gbPriceProfile.Name = "gbPriceProfile";
            gbPriceProfile.Size = new Size(457, 371);
            gbPriceProfile.TabIndex = 125;
            gbPriceProfile.TabStop = false;
            gbPriceProfile.Text = "Set Price Profile";
            // 
            // tabPriceProfile
            // 
            tabPriceProfile.Controls.Add(tabPriceProfileRaw);
            tabPriceProfile.Controls.Add(tabPriceProfileManufactured);
            tabPriceProfile.Location = new Point(4, 15);
            tabPriceProfile.Name = "tabPriceProfile";
            tabPriceProfile.SelectedIndex = 0;
            tabPriceProfile.Size = new Size(449, 280);
            tabPriceProfile.TabIndex = 9;
            // 
            // tabPriceProfileRaw
            // 
            tabPriceProfileRaw.Controls.Add(lstRawPriceProfile);
            tabPriceProfileRaw.Location = new Point(4, 22);
            tabPriceProfileRaw.Name = "tabPriceProfileRaw";
            tabPriceProfileRaw.Padding = new Padding(3);
            tabPriceProfileRaw.Size = new Size(441, 254);
            tabPriceProfileRaw.TabIndex = 0;
            tabPriceProfileRaw.Text = "Materials && Research Equipment";
            tabPriceProfileRaw.UseVisualStyleBackColor = true;
            // 
            // lstRawPriceProfile
            // 
            lstRawPriceProfile.FullRowSelect = true;
            lstRawPriceProfile.GridLines = true;
            lstRawPriceProfile.HideSelection = false;
            lstRawPriceProfile.Location = new Point(2, 3);
            lstRawPriceProfile.MultiSelect = false;
            lstRawPriceProfile.Name = "lstRawPriceProfile";
            lstRawPriceProfile.Size = new Size(437, 248);
            lstRawPriceProfile.TabIndex = 1;
            lstRawPriceProfile.UseCompatibleStateImageBehavior = false;
            lstRawPriceProfile.View = View.Details;
            // 
            // tabPriceProfileManufactured
            // 
            tabPriceProfileManufactured.Controls.Add(lstManufacturedPriceProfile);
            tabPriceProfileManufactured.Location = new Point(4, 22);
            tabPriceProfileManufactured.Name = "tabPriceProfileManufactured";
            tabPriceProfileManufactured.Padding = new Padding(3);
            tabPriceProfileManufactured.Size = new Size(441, 254);
            tabPriceProfileManufactured.TabIndex = 1;
            tabPriceProfileManufactured.Text = "Manufactured Items";
            tabPriceProfileManufactured.UseVisualStyleBackColor = true;
            // 
            // lstManufacturedPriceProfile
            // 
            lstManufacturedPriceProfile.FullRowSelect = true;
            lstManufacturedPriceProfile.GridLines = true;
            lstManufacturedPriceProfile.HideSelection = false;
            lstManufacturedPriceProfile.Location = new Point(2, 3);
            lstManufacturedPriceProfile.MultiSelect = false;
            lstManufacturedPriceProfile.Name = "lstManufacturedPriceProfile";
            lstManufacturedPriceProfile.Size = new Size(437, 248);
            lstManufacturedPriceProfile.TabIndex = 2;
            lstManufacturedPriceProfile.UseCompatibleStateImageBehavior = false;
            lstManufacturedPriceProfile.View = View.Details;
            // 
            // gbPPDefaultSettings
            // 
            gbPPDefaultSettings.Controls.Add(btnPPUpdateDefaults);
            gbPPDefaultSettings.Controls.Add(cmbPPDefaultsPriceType);
            gbPPDefaultSettings.Controls.Add(lblPPDefaultsSystem);
            gbPPDefaultSettings.Controls.Add(lblPPDefaultsPriceType);
            gbPPDefaultSettings.Controls.Add(cmbPPDefaultsSystem);
            gbPPDefaultSettings.Controls.Add(cmbPPDefaultsRegion);
            gbPPDefaultSettings.Controls.Add(lblPPDefaultsRegion);
            gbPPDefaultSettings.Controls.Add(txtPPDefaultsPriceMod);
            gbPPDefaultSettings.Controls.Add(lblPPDefaultsPriceMod);
            gbPPDefaultSettings.Location = new Point(8, 299);
            gbPPDefaultSettings.Name = "gbPPDefaultSettings";
            gbPPDefaultSettings.Size = new Size(443, 64);
            gbPPDefaultSettings.TabIndex = 53;
            gbPPDefaultSettings.TabStop = false;
            gbPPDefaultSettings.Text = "Set Defaults:";
            // 
            // btnPPUpdateDefaults
            // 
            btnPPUpdateDefaults.Location = new Point(385, 30);
            btnPPUpdateDefaults.Name = "btnPPUpdateDefaults";
            btnPPUpdateDefaults.Size = new Size(51, 23);
            btnPPUpdateDefaults.TabIndex = 4;
            btnPPUpdateDefaults.Text = "Update";
            btnPPUpdateDefaults.UseVisualStyleBackColor = true;
            // 
            // cmbPPDefaultsPriceType
            // 
            cmbPPDefaultsPriceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPPDefaultsPriceType.FormattingEnabled = true;
            cmbPPDefaultsPriceType.Items.AddRange(new object[] { "Min Sell", "Max Sell", "Avg Sell", "Median Sell", "Percentile Sell", "Min Buy", "Max Buy", "Avg Buy", "Median Buy", "Percentile Buy", "Split Price" });
            cmbPPDefaultsPriceType.Location = new Point(6, 31);
            cmbPPDefaultsPriceType.Name = "cmbPPDefaultsPriceType";
            cmbPPDefaultsPriceType.Size = new Size(91, 21);
            cmbPPDefaultsPriceType.TabIndex = 0;
            // 
            // lblPPDefaultsSystem
            // 
            lblPPDefaultsSystem.AutoSize = true;
            lblPPDefaultsSystem.Location = new Point(215, 17);
            lblPPDefaultsSystem.Name = "lblPPDefaultsSystem";
            lblPPDefaultsSystem.Size = new Size(44, 13);
            lblPPDefaultsSystem.TabIndex = 51;
            lblPPDefaultsSystem.Text = "System:";
            // 
            // lblPPDefaultsPriceType
            // 
            lblPPDefaultsPriceType.AutoSize = true;
            lblPPDefaultsPriceType.Location = new Point(3, 17);
            lblPPDefaultsPriceType.Name = "lblPPDefaultsPriceType";
            lblPPDefaultsPriceType.Size = new Size(61, 13);
            lblPPDefaultsPriceType.TabIndex = 47;
            lblPPDefaultsPriceType.Text = "Price Type:";
            // 
            // cmbPPDefaultsSystem
            // 
            cmbPPDefaultsSystem.FormattingEnabled = true;
            cmbPPDefaultsSystem.Location = new Point(218, 31);
            cmbPPDefaultsSystem.Name = "cmbPPDefaultsSystem";
            cmbPPDefaultsSystem.Size = new Size(115, 21);
            cmbPPDefaultsSystem.TabIndex = 2;
            cmbPPDefaultsSystem.Text = "Select System";
            // 
            // cmbPPDefaultsRegion
            // 
            cmbPPDefaultsRegion.FormattingEnabled = true;
            cmbPPDefaultsRegion.Location = new Point(100, 31);
            cmbPPDefaultsRegion.Name = "cmbPPDefaultsRegion";
            cmbPPDefaultsRegion.Size = new Size(115, 21);
            cmbPPDefaultsRegion.TabIndex = 1;
            cmbPPDefaultsRegion.Text = "Select Region";
            // 
            // lblPPDefaultsRegion
            // 
            lblPPDefaultsRegion.AutoSize = true;
            lblPPDefaultsRegion.Location = new Point(97, 17);
            lblPPDefaultsRegion.Name = "lblPPDefaultsRegion";
            lblPPDefaultsRegion.Size = new Size(44, 13);
            lblPPDefaultsRegion.TabIndex = 50;
            lblPPDefaultsRegion.Text = "Region:";
            // 
            // txtPPDefaultsPriceMod
            // 
            txtPPDefaultsPriceMod.Location = new Point(336, 32);
            txtPPDefaultsPriceMod.Name = "txtPPDefaultsPriceMod";
            txtPPDefaultsPriceMod.Size = new Size(46, 20);
            txtPPDefaultsPriceMod.TabIndex = 3;
            txtPPDefaultsPriceMod.Text = "0.0%";
            txtPPDefaultsPriceMod.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPPDefaultsPriceMod
            // 
            lblPPDefaultsPriceMod.AutoSize = true;
            lblPPDefaultsPriceMod.Location = new Point(333, 17);
            lblPPDefaultsPriceMod.Name = "lblPPDefaultsPriceMod";
            lblPPDefaultsPriceMod.Size = new Size(47, 13);
            lblPPDefaultsPriceMod.TabIndex = 44;
            lblPPDefaultsPriceMod.Text = "Modifier:";
            // 
            // btnLoadPricesfromFile
            // 
            btnLoadPricesfromFile.Location = new Point(588, 578);
            btnLoadPricesfromFile.Name = "btnLoadPricesfromFile";
            btnLoadPricesfromFile.Size = new Size(80, 32);
            btnLoadPricesfromFile.TabIndex = 42;
            btnLoadPricesfromFile.Text = "Load Prices";
            btnLoadPricesfromFile.UseVisualStyleBackColor = true;
            // 
            // btnSavePricestoFile
            // 
            btnSavePricestoFile.Location = new Point(502, 578);
            btnSavePricestoFile.Name = "btnSavePricestoFile";
            btnSavePricestoFile.Size = new Size(80, 32);
            btnSavePricestoFile.TabIndex = 41;
            btnSavePricestoFile.Text = "Save Prices";
            btnSavePricestoFile.UseVisualStyleBackColor = true;
            // 
            // lstPricesView
            // 
            lstPricesView.FullRowSelect = true;
            lstPricesView.GridLines = true;
            lstPricesView.HideSelection = false;
            lstPricesView.Location = new Point(8, 10);
            lstPricesView.MultiSelect = false;
            lstPricesView.Name = "lstPricesView";
            lstPricesView.Size = new Size(660, 321);
            lstPricesView.TabIndex = 0;
            lstPricesView.UseCompatibleStateImageBehavior = false;
            lstPricesView.View = View.Details;
            // 
            // txtPriceItemFilter
            // 
            txtPriceItemFilter.Location = new Point(80, 584);
            txtPriceItemFilter.Name = "txtPriceItemFilter";
            txtPriceItemFilter.Size = new Size(226, 20);
            txtPriceItemFilter.TabIndex = 3;
            // 
            // gbPriceOptions
            // 
            gbPriceOptions.Controls.Add(txtItemsPriceModifier);
            gbPriceOptions.Controls.Add(txtRawPriceModifier);
            gbPriceOptions.Controls.Add(gbPriceTypes);
            gbPriceOptions.Controls.Add(lblItemsPriceModifier);
            gbPriceOptions.Controls.Add(lblRawPriceModifier);
            gbPriceOptions.Controls.Add(gbDataSource);
            gbPriceOptions.Controls.Add(cmbItemsSplitPrices);
            gbPriceOptions.Controls.Add(cmbRawMatsSplitPrices);
            gbPriceOptions.Controls.Add(lblItemsSplitPrices);
            gbPriceOptions.Controls.Add(lblRawMatsSplitPrices);
            gbPriceOptions.Location = new Point(674, 482);
            gbPriceOptions.Name = "gbPriceOptions";
            gbPriceOptions.Size = new Size(457, 93);
            gbPriceOptions.TabIndex = 10;
            gbPriceOptions.TabStop = false;
            // 
            // txtItemsPriceModifier
            // 
            txtItemsPriceModifier.Location = new Point(219, 64);
            txtItemsPriceModifier.Name = "txtItemsPriceModifier";
            txtItemsPriceModifier.Size = new Size(46, 20);
            txtItemsPriceModifier.TabIndex = 4;
            txtItemsPriceModifier.TextAlign = HorizontalAlignment.Right;
            // 
            // txtRawPriceModifier
            // 
            txtRawPriceModifier.Location = new Point(219, 25);
            txtRawPriceModifier.Name = "txtRawPriceModifier";
            txtRawPriceModifier.Size = new Size(46, 20);
            txtRawPriceModifier.TabIndex = 3;
            txtRawPriceModifier.TextAlign = HorizontalAlignment.Right;
            // 
            // gbPriceTypes
            // 
            gbPriceTypes.Controls.Add(rbtnPriceSettingPriceProfile);
            gbPriceTypes.Controls.Add(rbtnPriceSettingSingleSelect);
            gbPriceTypes.Location = new Point(271, 49);
            gbPriceTypes.Name = "gbPriceTypes";
            gbPriceTypes.Size = new Size(180, 38);
            gbPriceTypes.TabIndex = 19;
            gbPriceTypes.TabStop = false;
            gbPriceTypes.Text = "Price Settings:";
            // 
            // rbtnPriceSettingPriceProfile
            // 
            rbtnPriceSettingPriceProfile.AutoSize = true;
            rbtnPriceSettingPriceProfile.Location = new Point(99, 15);
            rbtnPriceSettingPriceProfile.Name = "rbtnPriceSettingPriceProfile";
            rbtnPriceSettingPriceProfile.Size = new Size(81, 17);
            rbtnPriceSettingPriceProfile.TabIndex = 8;
            rbtnPriceSettingPriceProfile.Text = "Price Profile";
            rbtnPriceSettingPriceProfile.UseVisualStyleBackColor = true;
            // 
            // rbtnPriceSettingSingleSelect
            // 
            rbtnPriceSettingSingleSelect.AutoSize = true;
            rbtnPriceSettingSingleSelect.Location = new Point(5, 15);
            rbtnPriceSettingSingleSelect.Name = "rbtnPriceSettingSingleSelect";
            rbtnPriceSettingSingleSelect.Size = new Size(91, 17);
            rbtnPriceSettingSingleSelect.TabIndex = 7;
            rbtnPriceSettingSingleSelect.Text = "Single Source";
            rbtnPriceSettingSingleSelect.UseVisualStyleBackColor = true;
            // 
            // lblItemsPriceModifier
            // 
            lblItemsPriceModifier.Location = new Point(145, 60);
            lblItemsPriceModifier.Name = "lblItemsPriceModifier";
            lblItemsPriceModifier.Size = new Size(81, 29);
            lblItemsPriceModifier.TabIndex = 48;
            lblItemsPriceModifier.Text = "Manufactured Price Modifier:";
            // 
            // lblRawPriceModifier
            // 
            lblRawPriceModifier.Location = new Point(145, 21);
            lblRawPriceModifier.Name = "lblRawPriceModifier";
            lblRawPriceModifier.Size = new Size(81, 29);
            lblRawPriceModifier.TabIndex = 20;
            lblRawPriceModifier.Text = "Raw Price Modifier:";
            // 
            // gbDataSource
            // 
            gbDataSource.Controls.Add(rbtnPriceSourceCCPData);
            gbDataSource.Controls.Add(rbtnPriceSourceFW);
            gbDataSource.Controls.Add(rbtnPriceSourceEM);
            gbDataSource.Location = new Point(271, 7);
            gbDataSource.Name = "gbDataSource";
            gbDataSource.Size = new Size(180, 41);
            gbDataSource.TabIndex = 18;
            gbDataSource.TabStop = false;
            gbDataSource.Text = "Data Source:";
            // 
            // rbtnPriceSourceCCPData
            // 
            rbtnPriceSourceCCPData.AutoSize = true;
            rbtnPriceSourceCCPData.Location = new Point(5, 19);
            rbtnPriceSourceCCPData.Name = "rbtnPriceSourceCCPData";
            rbtnPriceSourceCCPData.Size = new Size(73, 17);
            rbtnPriceSourceCCPData.TabIndex = 6;
            rbtnPriceSourceCCPData.Text = "Tranquility";
            rbtnPriceSourceCCPData.UseVisualStyleBackColor = true;
            // 
            // rbtnPriceSourceEM
            // 
            rbtnPriceSourceEM.AutoSize = true;
            rbtnPriceSourceEM.Location = new Point(57, 19);
            rbtnPriceSourceEM.Name = "rbtnPriceSourceEM";
            rbtnPriceSourceEM.Size = new Size(67, 17);
            rbtnPriceSourceEM.TabIndex = 5;
            rbtnPriceSourceEM.Text = "Marketer";
            rbtnPriceSourceEM.UseVisualStyleBackColor = true;
            rbtnPriceSourceEM.Visible = false;
            // 
            // cmbItemsSplitPrices
            // 
            cmbItemsSplitPrices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItemsSplitPrices.FormattingEnabled = true;
            cmbItemsSplitPrices.Items.AddRange(new object[] { "Min Sell", "Max Sell", "Avg Sell", "Median Sell", "Percentile Sell", "Min Buy", "Max Buy", "Avg Buy", "Median Buy", "Percentile Buy", "Split Price" });
            cmbItemsSplitPrices.Location = new Point(8, 64);
            cmbItemsSplitPrices.Name = "cmbItemsSplitPrices";
            cmbItemsSplitPrices.Size = new Size(131, 21);
            cmbItemsSplitPrices.TabIndex = 2;
            // 
            // cmbRawMatsSplitPrices
            // 
            cmbRawMatsSplitPrices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRawMatsSplitPrices.FormattingEnabled = true;
            cmbRawMatsSplitPrices.Items.AddRange(new object[] { "Min Sell", "Max Sell", "Avg Sell", "Median Sell", "Percentile Sell", "Min Buy", "Max Buy", "Avg Buy", "Median Buy", "Percentile Buy", "Split Price" });
            cmbRawMatsSplitPrices.Location = new Point(8, 25);
            cmbRawMatsSplitPrices.Name = "cmbRawMatsSplitPrices";
            cmbRawMatsSplitPrices.Size = new Size(131, 21);
            cmbRawMatsSplitPrices.TabIndex = 1;
            // 
            // lblItemsSplitPrices
            // 
            lblItemsSplitPrices.AutoSize = true;
            lblItemsSplitPrices.Location = new Point(5, 50);
            lblItemsSplitPrices.Name = "lblItemsSplitPrices";
            lblItemsSplitPrices.Size = new Size(104, 13);
            lblItemsSplitPrices.TabIndex = 6;
            lblItemsSplitPrices.Text = "Manufactured Items:";
            // 
            // lblRawMatsSplitPrices
            // 
            lblRawMatsSplitPrices.AutoSize = true;
            lblRawMatsSplitPrices.Location = new Point(5, 11);
            lblRawMatsSplitPrices.Name = "lblRawMatsSplitPrices";
            lblRawMatsSplitPrices.Size = new Size(77, 13);
            lblRawMatsSplitPrices.TabIndex = 7;
            lblRawMatsSplitPrices.Text = "Raw Materials:";
            // 
            // btnSaveUpdatePrices
            // 
            btnSaveUpdatePrices.Location = new Point(903, 578);
            btnSaveUpdatePrices.Name = "btnSaveUpdatePrices";
            btnSaveUpdatePrices.Size = new Size(113, 32);
            btnSaveUpdatePrices.TabIndex = 14;
            btnSaveUpdatePrices.Text = "Save Settings";
            btnSaveUpdatePrices.UseVisualStyleBackColor = true;
            // 
            // btnCancelUpdate
            // 
            btnCancelUpdate.Location = new Point(1017, 578);
            btnCancelUpdate.Name = "btnCancelUpdate";
            btnCancelUpdate.Size = new Size(113, 32);
            btnCancelUpdate.TabIndex = 13;
            btnCancelUpdate.Text = "Cancel Update";
            btnCancelUpdate.UseVisualStyleBackColor = true;
            // 
            // btnClearItemFilter
            // 
            btnClearItemFilter.Location = new Point(312, 583);
            btnClearItemFilter.Name = "btnClearItemFilter";
            btnClearItemFilter.Size = new Size(59, 21);
            btnClearItemFilter.TabIndex = 4;
            btnClearItemFilter.Text = "Clear";
            btnClearItemFilter.UseVisualStyleBackColor = true;
            // 
            // btnToggleAllPriceItems
            // 
            btnToggleAllPriceItems.Location = new Point(675, 578);
            btnToggleAllPriceItems.Name = "btnToggleAllPriceItems";
            btnToggleAllPriceItems.Size = new Size(113, 32);
            btnToggleAllPriceItems.TabIndex = 11;
            btnToggleAllPriceItems.Text = "Select All Items";
            btnToggleAllPriceItems.UseVisualStyleBackColor = true;
            // 
            // btnDownloadPrices
            // 
            btnDownloadPrices.Location = new Point(789, 578);
            btnDownloadPrices.Name = "btnDownloadPrices";
            btnDownloadPrices.Size = new Size(113, 32);
            btnDownloadPrices.TabIndex = 12;
            btnDownloadPrices.Text = "Download Prices";
            btnDownloadPrices.UseVisualStyleBackColor = true;
            // 
            // lblItemFilter
            // 
            lblItemFilter.AutoSize = true;
            lblItemFilter.Location = new Point(15, 588);
            lblItemFilter.Name = "lblItemFilter";
            lblItemFilter.Size = new Size(55, 13);
            lblItemFilter.TabIndex = 5;
            lblItemFilter.Text = "Item Filter:";
            // 
            // gbManufacturedItems
            // 
            gbManufacturedItems.Controls.Add(chkPriceManufacturedPrices);
            gbManufacturedItems.Controls.Add(gbComponents);
            gbManufacturedItems.Controls.Add(gbItems);
            gbManufacturedItems.Location = new Point(269, 337);
            gbManufacturedItems.Name = "gbManufacturedItems";
            gbManufacturedItems.Size = new Size(399, 238);
            gbManufacturedItems.TabIndex = 2;
            gbManufacturedItems.TabStop = false;
            // 
            // chkPriceManufacturedPrices
            // 
            chkPriceManufacturedPrices.AutoSize = true;
            chkPriceManufacturedPrices.BackColor = Color.White;
            chkPriceManufacturedPrices.Location = new Point(6, 1);
            chkPriceManufacturedPrices.Name = "chkPriceManufacturedPrices";
            chkPriceManufacturedPrices.Size = new Size(120, 17);
            chkPriceManufacturedPrices.TabIndex = 0;
            chkPriceManufacturedPrices.Text = "Manufactured Items";
            chkPriceManufacturedPrices.UseVisualStyleBackColor = false;
            // 
            // gbComponents
            // 
            gbComponents.Controls.Add(gbReprocessables);
            gbComponents.Controls.Add(chkFuelBlocks);
            gbComponents.Controls.Add(chkRAM);
            gbComponents.Controls.Add(chkProtectiveComponents);
            gbComponents.Controls.Add(chkSubsystemComponents);
            gbComponents.Controls.Add(chkStructureComponents);
            gbComponents.Controls.Add(chkComponents);
            gbComponents.Controls.Add(chkCapitalShipComponents);
            gbComponents.Controls.Add(chkCapT2Components);
            gbComponents.Location = new Point(5, 145);
            gbComponents.Name = "gbComponents";
            gbComponents.Size = new Size(388, 88);
            gbComponents.TabIndex = 2;
            gbComponents.TabStop = false;
            gbComponents.Text = "Components";
            // 
            // gbReprocessables
            // 
            gbReprocessables.Controls.Add(chkNoBuildItems);
            gbReprocessables.Location = new Point(283, 52);
            gbReprocessables.Name = "gbReprocessables";
            gbReprocessables.Size = new Size(101, 32);
            gbReprocessables.TabIndex = 19;
            gbReprocessables.TabStop = false;
            // 
            // chkNoBuildItems
            // 
            chkNoBuildItems.AutoSize = true;
            chkNoBuildItems.Location = new Point(6, 11);
            chkNoBuildItems.Name = "chkNoBuildItems";
            chkNoBuildItems.Size = new Size(94, 17);
            chkNoBuildItems.TabIndex = 20;
            chkNoBuildItems.Text = "No Build Items";
            chkNoBuildItems.UseVisualStyleBackColor = true;
            // 
            // chkFuelBlocks
            // 
            chkFuelBlocks.AutoSize = true;
            chkFuelBlocks.Location = new Point(196, 49);
            chkFuelBlocks.Name = "chkFuelBlocks";
            chkFuelBlocks.Size = new Size(81, 17);
            chkFuelBlocks.TabIndex = 3;
            chkFuelBlocks.Text = "Fuel Blocks";
            chkFuelBlocks.UseVisualStyleBackColor = true;
            // 
            // chkRAM
            // 
            chkRAM.AutoSize = true;
            chkRAM.Location = new Point(196, 66);
            chkRAM.Name = "chkRAM";
            chkRAM.Size = new Size(59, 17);
            chkRAM.TabIndex = 1;
            chkRAM.Text = "R.A.M.";
            chkRAM.UseVisualStyleBackColor = true;
            // 
            // chkProtectiveComponents
            // 
            chkProtectiveComponents.AutoSize = true;
            chkProtectiveComponents.Location = new Point(196, 32);
            chkProtectiveComponents.Name = "chkProtectiveComponents";
            chkProtectiveComponents.Size = new Size(136, 17);
            chkProtectiveComponents.TabIndex = 18;
            chkProtectiveComponents.Text = "Protective Components";
            chkProtectiveComponents.UseVisualStyleBackColor = true;
            // 
            // chkSubsystemComponents
            // 
            chkSubsystemComponents.AutoSize = true;
            chkSubsystemComponents.Location = new Point(9, 49);
            chkSubsystemComponents.Name = "chkSubsystemComponents";
            chkSubsystemComponents.Size = new Size(139, 17);
            chkSubsystemComponents.TabIndex = 5;
            chkSubsystemComponents.Text = "Subsystem Components";
            chkSubsystemComponents.UseVisualStyleBackColor = true;
            // 
            // chkStructureComponents
            // 
            chkStructureComponents.AutoSize = true;
            chkStructureComponents.Location = new Point(9, 66);
            chkStructureComponents.Name = "chkStructureComponents";
            chkStructureComponents.Size = new Size(131, 17);
            chkStructureComponents.TabIndex = 17;
            chkStructureComponents.Text = "Structure Components";
            chkStructureComponents.UseVisualStyleBackColor = true;
            // 
            // chkComponents
            // 
            chkComponents.AutoSize = true;
            chkComponents.Location = new Point(9, 32);
            chkComponents.Name = "chkComponents";
            chkComponents.Size = new Size(137, 17);
            chkComponents.TabIndex = 4;
            chkComponents.Text = "Advanced Components";
            chkComponents.UseVisualStyleBackColor = true;
            // 
            // chkCapitalShipComponents
            // 
            chkCapitalShipComponents.AutoSize = true;
            chkCapitalShipComponents.Location = new Point(196, 15);
            chkCapitalShipComponents.Name = "chkCapitalShipComponents";
            chkCapitalShipComponents.Size = new Size(190, 17);
            chkCapitalShipComponents.TabIndex = 3;
            chkCapitalShipComponents.Text = "Standard Capital Ship Components";
            chkCapitalShipComponents.UseVisualStyleBackColor = true;
            // 
            // chkCapT2Components
            // 
            chkCapT2Components.AutoSize = true;
            chkCapT2Components.Location = new Point(9, 15);
            chkCapT2Components.Name = "chkCapT2Components";
            chkCapT2Components.Size = new Size(172, 17);
            chkCapT2Components.TabIndex = 2;
            chkCapT2Components.Text = "Advanced Capital Components";
            chkCapT2Components.UseVisualStyleBackColor = true;
            // 
            // gbItems
            // 
            gbItems.Controls.Add(chkCelestials);
            gbItems.Controls.Add(chkDeployables);
            gbItems.Controls.Add(cmbPriceChargeTypes);
            gbItems.Controls.Add(chkStructures);
            gbItems.Controls.Add(chkStructureRigs);
            gbItems.Controls.Add(chkCharges);
            gbItems.Controls.Add(chkBoosters);
            gbItems.Controls.Add(cmbPriceShipTypes);
            gbItems.Controls.Add(gbPricesTech);
            gbItems.Controls.Add(chkSubsystems);
            gbItems.Controls.Add(chkShips);
            gbItems.Controls.Add(chkModules);
            gbItems.Controls.Add(chkRigs);
            gbItems.Controls.Add(chkDrones);
            gbItems.Controls.Add(chkUpdatePricesNoPrice);
            gbItems.Controls.Add(chkImplants);
            gbItems.Controls.Add(chkStructureModules);
            gbItems.Location = new Point(5, 16);
            gbItems.Name = "gbItems";
            gbItems.Size = new Size(388, 128);
            gbItems.TabIndex = 1;
            gbItems.TabStop = false;
            gbItems.Text = "Items";
            // 
            // chkCelestials
            // 
            chkCelestials.AutoSize = true;
            chkCelestials.Location = new Point(196, 92);
            chkCelestials.Name = "chkCelestials";
            chkCelestials.Size = new Size(70, 17);
            chkCelestials.TabIndex = 13;
            chkCelestials.Text = "Celestials";
            chkCelestials.UseVisualStyleBackColor = true;
            // 
            // chkDeployables
            // 
            chkDeployables.AutoSize = true;
            chkDeployables.Location = new Point(94, 75);
            chkDeployables.Name = "chkDeployables";
            chkDeployables.Size = new Size(84, 17);
            chkDeployables.TabIndex = 9;
            chkDeployables.Text = "Deployables";
            chkDeployables.UseVisualStyleBackColor = true;
            // 
            // cmbPriceChargeTypes
            // 
            cmbPriceChargeTypes.FormattingEnabled = true;
            cmbPriceChargeTypes.Location = new Point(71, 34);
            cmbPriceChargeTypes.Name = "cmbPriceChargeTypes";
            cmbPriceChargeTypes.Size = new Size(211, 21);
            cmbPriceChargeTypes.TabIndex = 5;
            cmbPriceChargeTypes.Text = "All Charge Types";
            // 
            // chkStructures
            // 
            chkStructures.AutoSize = true;
            chkStructures.Location = new Point(9, 92);
            chkStructures.Name = "chkStructures";
            chkStructures.Size = new Size(74, 17);
            chkStructures.TabIndex = 12;
            chkStructures.Text = "Structures";
            chkStructures.UseVisualStyleBackColor = true;
            // 
            // chkStructureRigs
            // 
            chkStructureRigs.AutoSize = true;
            chkStructureRigs.Location = new Point(94, 92);
            chkStructureRigs.Name = "chkStructureRigs";
            chkStructureRigs.Size = new Size(93, 17);
            chkStructureRigs.TabIndex = 14;
            chkStructureRigs.Text = "Structure Rigs";
            chkStructureRigs.UseVisualStyleBackColor = true;
            // 
            // chkCharges
            // 
            chkCharges.AutoSize = true;
            chkCharges.Location = new Point(9, 36);
            chkCharges.Name = "chkCharges";
            chkCharges.Size = new Size(65, 17);
            chkCharges.TabIndex = 4;
            chkCharges.Text = "Charges";
            chkCharges.UseVisualStyleBackColor = true;
            // 
            // chkBoosters
            // 
            chkBoosters.AutoSize = true;
            chkBoosters.Location = new Point(196, 75);
            chkBoosters.Name = "chkBoosters";
            chkBoosters.Size = new Size(67, 17);
            chkBoosters.TabIndex = 11;
            chkBoosters.Text = "Boosters";
            chkBoosters.UseVisualStyleBackColor = true;
            // 
            // cmbPriceShipTypes
            // 
            cmbPriceShipTypes.FormattingEnabled = true;
            cmbPriceShipTypes.Location = new Point(71, 12);
            cmbPriceShipTypes.Name = "cmbPriceShipTypes";
            cmbPriceShipTypes.Size = new Size(211, 21);
            cmbPriceShipTypes.TabIndex = 3;
            cmbPriceShipTypes.Text = "All Ship Types";
            // 
            // gbPricesTech
            // 
            gbPricesTech.Controls.Add(chkPricesT4);
            gbPricesTech.Controls.Add(chkPricesT6);
            gbPricesTech.Controls.Add(chkPricesT5);
            gbPricesTech.Controls.Add(chkPricesT3);
            gbPricesTech.Controls.Add(chkPricesT2);
            gbPricesTech.Controls.Add(chkPricesT1);
            gbPricesTech.Location = new Point(288, 7);
            gbPricesTech.Name = "gbPricesTech";
            gbPricesTech.Size = new Size(94, 114);
            gbPricesTech.TabIndex = 15;
            gbPricesTech.TabStop = false;
            // 
            // chkPricesT4
            // 
            chkPricesT4.AutoSize = true;
            chkPricesT4.Enabled = false;
            chkPricesT4.Location = new Point(6, 60);
            chkPricesT4.Name = "chkPricesT4";
            chkPricesT4.Size = new Size(66, 17);
            chkPricesT4.TabIndex = 3;
            chkPricesT4.Text = "Storyline";
            chkPricesT4.TextAlign = ContentAlignment.TopLeft;
            chkPricesT4.UseVisualStyleBackColor = true;
            // 
            // chkPricesT6
            // 
            chkPricesT6.AutoSize = true;
            chkPricesT6.Enabled = false;
            chkPricesT6.Location = new Point(6, 94);
            chkPricesT6.Name = "chkPricesT6";
            chkPricesT6.Size = new Size(91, 17);
            chkPricesT6.TabIndex = 9;
            chkPricesT6.Text = "Pirate Faction";
            chkPricesT6.TextAlign = ContentAlignment.TopLeft;
            chkPricesT6.UseVisualStyleBackColor = true;
            // 
            // chkPricesT5
            // 
            chkPricesT5.AutoSize = true;
            chkPricesT5.Enabled = false;
            chkPricesT5.Location = new Point(6, 77);
            chkPricesT5.Name = "chkPricesT5";
            chkPricesT5.Size = new Size(89, 17);
            chkPricesT5.TabIndex = 8;
            chkPricesT5.Text = "Navy Faction";
            chkPricesT5.TextAlign = ContentAlignment.TopLeft;
            chkPricesT5.UseVisualStyleBackColor = true;
            // 
            // chkPricesT3
            // 
            chkPricesT3.AutoSize = true;
            chkPricesT3.Enabled = false;
            chkPricesT3.Location = new Point(6, 43);
            chkPricesT3.Name = "chkPricesT3";
            chkPricesT3.Size = new Size(60, 17);
            chkPricesT3.TabIndex = 2;
            chkPricesT3.Text = "Tech 3";
            chkPricesT3.UseVisualStyleBackColor = true;
            // 
            // chkPricesT2
            // 
            chkPricesT2.AutoSize = true;
            chkPricesT2.Enabled = false;
            chkPricesT2.Location = new Point(6, 26);
            chkPricesT2.Name = "chkPricesT2";
            chkPricesT2.Size = new Size(60, 17);
            chkPricesT2.TabIndex = 1;
            chkPricesT2.Text = "Tech 2";
            chkPricesT2.UseVisualStyleBackColor = true;
            // 
            // chkPricesT1
            // 
            chkPricesT1.AutoSize = true;
            chkPricesT1.Enabled = false;
            chkPricesT1.Location = new Point(6, 9);
            chkPricesT1.Name = "chkPricesT1";
            chkPricesT1.Size = new Size(60, 17);
            chkPricesT1.TabIndex = 0;
            chkPricesT1.Text = "Tech 1";
            chkPricesT1.UseVisualStyleBackColor = true;
            // 
            // chkSubsystems
            // 
            chkSubsystems.AutoSize = true;
            chkSubsystems.Location = new Point(9, 75);
            chkSubsystems.Name = "chkSubsystems";
            chkSubsystems.Size = new Size(82, 17);
            chkSubsystems.TabIndex = 10;
            chkSubsystems.Text = "Subsystems";
            chkSubsystems.UseVisualStyleBackColor = true;
            // 
            // chkShips
            // 
            chkShips.AutoSize = true;
            chkShips.Location = new Point(9, 14);
            chkShips.Name = "chkShips";
            chkShips.Size = new Size(52, 17);
            chkShips.TabIndex = 2;
            chkShips.Text = "Ships";
            chkShips.UseVisualStyleBackColor = true;
            // 
            // chkModules
            // 
            chkModules.AutoSize = true;
            chkModules.Location = new Point(9, 58);
            chkModules.Name = "chkModules";
            chkModules.Size = new Size(66, 17);
            chkModules.TabIndex = 6;
            chkModules.Text = "Modules";
            chkModules.UseVisualStyleBackColor = true;
            // 
            // chkRigs
            // 
            chkRigs.AutoSize = true;
            chkRigs.Location = new Point(196, 58);
            chkRigs.Name = "chkRigs";
            chkRigs.Size = new Size(47, 17);
            chkRigs.TabIndex = 8;
            chkRigs.Text = "Rigs";
            chkRigs.UseVisualStyleBackColor = true;
            // 
            // chkDrones
            // 
            chkDrones.AutoSize = true;
            chkDrones.Location = new Point(94, 58);
            chkDrones.Name = "chkDrones";
            chkDrones.Size = new Size(60, 17);
            chkDrones.TabIndex = 7;
            chkDrones.Text = "Drones";
            chkDrones.UseVisualStyleBackColor = true;
            // 
            // chkUpdatePricesNoPrice
            // 
            chkUpdatePricesNoPrice.AutoSize = true;
            chkUpdatePricesNoPrice.Location = new Point(182, 109);
            chkUpdatePricesNoPrice.Name = "chkUpdatePricesNoPrice";
            chkUpdatePricesNoPrice.Size = new Size(108, 17);
            chkUpdatePricesNoPrice.TabIndex = 6;
            chkUpdatePricesNoPrice.Text = "Items w/No Price";
            chkUpdatePricesNoPrice.UseVisualStyleBackColor = true;
            // 
            // chkImplants
            // 
            chkImplants.AutoSize = true;
            chkImplants.Location = new Point(119, 109);
            chkImplants.Name = "chkImplants";
            chkImplants.Size = new Size(65, 17);
            chkImplants.TabIndex = 4;
            chkImplants.Text = "Implants";
            chkImplants.UseVisualStyleBackColor = true;
            // 
            // chkStructureModules
            // 
            chkStructureModules.AutoSize = true;
            chkStructureModules.Location = new Point(9, 109);
            chkStructureModules.Name = "chkStructureModules";
            chkStructureModules.Size = new Size(112, 17);
            chkStructureModules.TabIndex = 16;
            chkStructureModules.Text = "Structure Modules";
            chkStructureModules.UseVisualStyleBackColor = true;
            // 
            // btnOpenMarketBrowser
            // 
            btnOpenMarketBrowser.Location = new Point(377, 578);
            btnOpenMarketBrowser.Name = "btnOpenMarketBrowser";
            btnOpenMarketBrowser.Size = new Size(119, 32);
            btnOpenMarketBrowser.TabIndex = 127;
            btnOpenMarketBrowser.Text = "Load Price History";
            btnOpenMarketBrowser.UseVisualStyleBackColor = true;
            // 
            // tabBlueprints
            // 
            tabBlueprints.BackColor = Color.Transparent;
            tabBlueprints.Controls.Add(gbBPMEPEImage);
            tabBlueprints.Controls.Add(btnBPBuiltComponents);
            tabBlueprints.Controls.Add(btnBPComponents);
            tabBlueprints.Controls.Add(rbtnBPRawT2MatType);
            tabBlueprints.Controls.Add(rbtnBPProcT2MatType);
            tabBlueprints.Controls.Add(rbtnBPAdvT2MatType);
            tabBlueprints.Controls.Add(lblBPT2MatTypeSelector);
            tabBlueprints.Controls.Add(lstBPList);
            tabBlueprints.Controls.Add(gbBPBlueprintType);
            tabBlueprints.Controls.Add(gbBPBlueprintTech);
            tabBlueprints.Controls.Add(gbFilters);
            tabBlueprints.Controls.Add(cmbBPBlueprintSelection);
            tabBlueprints.Controls.Add(btnBPListView);
            tabBlueprints.Controls.Add(btnBPForward);
            tabBlueprints.Controls.Add(btnBPBack);
            tabBlueprints.Controls.Add(lblBPSelectBlueprint);
            tabBlueprints.Controls.Add(gbBPInventionStats);
            tabBlueprints.Controls.Add(lblBPBuyColor);
            tabBlueprints.Controls.Add(lblBPBuildColor);
            tabBlueprints.Controls.Add(gbBPShopandCopy);
            tabBlueprints.Controls.Add(lblBPCanMakeBPAll);
            tabBlueprints.Controls.Add(lblBPRawMatCost);
            tabBlueprints.Controls.Add(lblBPRawMatCost1);
            tabBlueprints.Controls.Add(lblBPCanMakeBP);
            tabBlueprints.Controls.Add(lblBPRawMats);
            tabBlueprints.Controls.Add(lblBPComponentMatCost);
            tabBlueprints.Controls.Add(lblBPComponentMats);
            tabBlueprints.Controls.Add(lblBPComponentMatCost1);
            tabBlueprints.Controls.Add(lstBPComponentMats);
            tabBlueprints.Controls.Add(lstBPRawMats);
            tabBlueprints.Controls.Add(lstBPBuiltComponents);
            tabBlueprints.ForeColor = SystemColors.ControlText;
            tabBlueprints.Location = new Point(4, 22);
            tabBlueprints.Name = "tabBlueprints";
            tabBlueprints.Padding = new Padding(3);
            tabBlueprints.Size = new Size(1137, 615);
            tabBlueprints.TabIndex = 0;
            tabBlueprints.Text = "Blueprints";
            tabBlueprints.UseVisualStyleBackColor = true;
            // 
            // gbBPMEPEImage
            // 
            gbBPMEPEImage.BackColor = Color.Transparent;
            gbBPMEPEImage.Controls.Add(gbBPSellExcess);
            gbBPMEPEImage.Controls.Add(btnBPSaveBP);
            gbBPMEPEImage.Controls.Add(tabBPInventionEquip);
            gbBPMEPEImage.Controls.Add(btnBPSaveSettings);
            gbBPMEPEImage.Controls.Add(txtBPLines);
            gbBPMEPEImage.Controls.Add(pictBP);
            gbBPMEPEImage.Controls.Add(gbBPManualSystemCostIndex);
            gbBPMEPEImage.Controls.Add(txtBPNumBPs);
            gbBPMEPEImage.Controls.Add(btnBPRefreshBP);
            gbBPMEPEImage.Controls.Add(lblBPLines);
            gbBPMEPEImage.Controls.Add(txtBPME);
            gbBPMEPEImage.Controls.Add(lblBPRuns);
            gbBPMEPEImage.Controls.Add(chkBPBuildBuy);
            gbBPMEPEImage.Controls.Add(txtBPRuns);
            gbBPMEPEImage.Controls.Add(txtBPAddlCosts);
            gbBPMEPEImage.Controls.Add(lblBPAddlCosts);
            gbBPMEPEImage.Controls.Add(lblBPME);
            gbBPMEPEImage.Controls.Add(txtBPTE);
            gbBPMEPEImage.Controls.Add(lblBPPE);
            gbBPMEPEImage.Controls.Add(lblBPNumBPs);
            gbBPMEPEImage.Controls.Add(gbBPIgnoreinCalcs);
            gbBPMEPEImage.Location = new Point(392, 8);
            gbBPMEPEImage.Name = "gbBPMEPEImage";
            gbBPMEPEImage.Size = new Size(455, 224);
            gbBPMEPEImage.TabIndex = 6;
            gbBPMEPEImage.TabStop = false;
            // 
            // gbBPSellExcess
            // 
            gbBPSellExcess.Controls.Add(btnBPListMats);
            gbBPSellExcess.Controls.Add(chkBPSellExcessItems);
            gbBPSellExcess.Location = new Point(238, 7);
            gbBPSellExcess.Name = "gbBPSellExcess";
            gbBPSellExcess.Size = new Size(82, 60);
            gbBPSellExcess.TabIndex = 21;
            gbBPSellExcess.TabStop = false;
            // 
            // btnBPListMats
            // 
            btnBPListMats.Location = new Point(6, 35);
            btnBPListMats.Name = "btnBPListMats";
            btnBPListMats.Size = new Size(72, 22);
            btnBPListMats.TabIndex = 24;
            btnBPListMats.Text = "List Mats";
            btnBPListMats.UseVisualStyleBackColor = true;
            // 
            // chkBPSellExcessItems
            // 
            chkBPSellExcessItems.Location = new Point(3, 7);
            chkBPSellExcessItems.Name = "chkBPSellExcessItems";
            chkBPSellExcessItems.Size = new Size(79, 32);
            chkBPSellExcessItems.TabIndex = 1;
            chkBPSellExcessItems.Text = "Sell excess build items";
            chkBPSellExcessItems.UseVisualStyleBackColor = true;
            // 
            // btnBPSaveBP
            // 
            btnBPSaveBP.Location = new Point(6, 154);
            btnBPSaveBP.Name = "btnBPSaveBP";
            btnBPSaveBP.Size = new Size(45, 34);
            btnBPSaveBP.TabIndex = 17;
            btnBPSaveBP.Text = "Save BP";
            btnBPSaveBP.UseVisualStyleBackColor = true;
            // 
            // tabBPInventionEquip
            // 
            tabBPInventionEquip.Alignment = TabAlignment.Right;
            tabBPInventionEquip.Controls.Add(tabFacility);
            tabBPInventionEquip.Controls.Add(tabT3Calcs);
            tabBPInventionEquip.Controls.Add(tabInventionCalcs);
            tabBPInventionEquip.DataBindings.Add(new Binding("Font", My.MySettings.Default, "MyDefault", true, DataSourceUpdateMode.OnPropertyChanged));
            tabBPInventionEquip.Font = My.MySettings.Default.MyDefault;
            tabBPInventionEquip.ItemSize = new Size(49, 20);
            tabBPInventionEquip.Location = new Point(141, 68);
            tabBPInventionEquip.Multiline = true;
            tabBPInventionEquip.Name = "tabBPInventionEquip";
            tabBPInventionEquip.Padding = new Point(0, 0);
            tabBPInventionEquip.RightToLeft = RightToLeft.No;
            tabBPInventionEquip.SelectedIndex = 0;
            tabBPInventionEquip.Size = new Size(309, 150);
            tabBPInventionEquip.SizeMode = TabSizeMode.FillToRight;
            tabBPInventionEquip.TabIndex = 16;
            // 
            // tabFacility
            // 
            tabFacility.Controls.Add(BPTabFacility);
            tabFacility.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabFacility.Location = new Point(4, 4);
            tabFacility.Margin = new Padding(0);
            tabFacility.Name = "tabFacility";
            tabFacility.Padding = new Padding(3);
            tabFacility.Size = new Size(261, 142);
            tabFacility.TabIndex = 1;
            tabFacility.Text = "Facility";
            tabFacility.UseVisualStyleBackColor = true;
            // 
            // BPTabFacility
            // 
            BPTabFacility.Location = new Point(0, 0);
            BPTabFacility.Name = "BPTabFacility";
            BPTabFacility.Size = new Size(280, 142);
            BPTabFacility.TabIndex = 0;
            // 
            // tabT3Calcs
            // 
            tabT3Calcs.Controls.Add(lblBPT3Decryptor);
            tabT3Calcs.Controls.Add(cmbBPT3Decryptor);
            tabT3Calcs.Controls.Add(lblBPT3Stats);
            tabT3Calcs.Controls.Add(lblBPRelic);
            tabT3Calcs.Controls.Add(txtBPRelicLines);
            tabT3Calcs.Controls.Add(lblBPRelicLines);
            tabT3Calcs.Controls.Add(lblBPRETime);
            tabT3Calcs.Controls.Add(cmbBPRelic);
            tabT3Calcs.Controls.Add(lblBPRECost);
            tabT3Calcs.Controls.Add(lblBPT3InventionChance);
            tabT3Calcs.Controls.Add(lblBPT3InventionChance1);
            tabT3Calcs.Controls.Add(lblT3InventStatus);
            tabT3Calcs.Controls.Add(chkBPIncludeT3Time);
            tabT3Calcs.Controls.Add(chkBPIncludeT3Costs);
            tabT3Calcs.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabT3Calcs.Location = new Point(4, 4);
            tabT3Calcs.Name = "tabT3Calcs";
            tabT3Calcs.Size = new Size(261, 142);
            tabT3Calcs.TabIndex = 2;
            tabT3Calcs.Text = "Invention";
            tabT3Calcs.UseVisualStyleBackColor = true;
            // 
            // lblBPT3Decryptor
            // 
            lblBPT3Decryptor.AutoSize = true;
            lblBPT3Decryptor.Location = new Point(69, 94);
            lblBPT3Decryptor.Name = "lblBPT3Decryptor";
            lblBPT3Decryptor.Size = new Size(89, 13);
            lblBPT3Decryptor.TabIndex = 53;
            lblBPT3Decryptor.Text = "Select Decryptor:";
            // 
            // cmbBPT3Decryptor
            // 
            cmbBPT3Decryptor.FormattingEnabled = true;
            cmbBPT3Decryptor.ItemHeight = 13;
            cmbBPT3Decryptor.Location = new Point(71, 108);
            cmbBPT3Decryptor.Name = "cmbBPT3Decryptor";
            cmbBPT3Decryptor.Size = new Size(206, 21);
            cmbBPT3Decryptor.TabIndex = 54;
            // 
            // lblBPT3Stats
            // 
            lblBPT3Stats.BorderStyle = BorderStyle.FixedSingle;
            lblBPT3Stats.Location = new Point(199, 2);
            lblBPT3Stats.Name = "lblBPT3Stats";
            lblBPT3Stats.Size = new Size(78, 30);
            lblBPT3Stats.TabIndex = 52;
            lblBPT3Stats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPRelic
            // 
            lblBPRelic.AutoSize = true;
            lblBPRelic.Location = new Point(38, 22);
            lblBPRelic.Name = "lblBPRelic";
            lblBPRelic.Size = new Size(67, 13);
            lblBPRelic.TabIndex = 41;
            lblBPRelic.Text = "Select Relic:";
            // 
            // txtBPRelicLines
            // 
            txtBPRelicLines.Location = new Point(4, 36);
            txtBPRelicLines.MaxLength = 4;
            txtBPRelicLines.Name = "txtBPRelicLines";
            txtBPRelicLines.Size = new Size(31, 20);
            txtBPRelicLines.TabIndex = 42;
            // 
            // lblBPRelicLines
            // 
            lblBPRelicLines.AutoSize = true;
            lblBPRelicLines.Location = new Point(2, 22);
            lblBPRelicLines.Name = "lblBPRelicLines";
            lblBPRelicLines.Size = new Size(35, 13);
            lblBPRelicLines.TabIndex = 40;
            lblBPRelicLines.Text = "Lines:";
            // 
            // lblBPRETime
            // 
            lblBPRETime.BorderStyle = BorderStyle.FixedSingle;
            lblBPRETime.Location = new Point(179, 75);
            lblBPRETime.Name = "lblBPRETime";
            lblBPRETime.Size = new Size(98, 17);
            lblBPRETime.TabIndex = 50;
            lblBPRETime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbBPRelic
            // 
            cmbBPRelic.FormattingEnabled = true;
            cmbBPRelic.ItemHeight = 13;
            cmbBPRelic.Items.AddRange(new object[] { "Wrecked", "Malfunctioning", "Intact" });
            cmbBPRelic.Location = new Point(41, 36);
            cmbBPRelic.Name = "cmbBPRelic";
            cmbBPRelic.Size = new Size(236, 21);
            cmbBPRelic.TabIndex = 43;
            // 
            // lblBPRECost
            // 
            lblBPRECost.BorderStyle = BorderStyle.FixedSingle;
            lblBPRECost.Location = new Point(71, 75);
            lblBPRECost.Name = "lblBPRECost";
            lblBPRECost.Size = new Size(105, 17);
            lblBPRECost.TabIndex = 48;
            lblBPRECost.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPT3InventionChance
            // 
            lblBPT3InventionChance.BorderStyle = BorderStyle.FixedSingle;
            lblBPT3InventionChance.Location = new Point(4, 75);
            lblBPT3InventionChance.Name = "lblBPT3InventionChance";
            lblBPT3InventionChance.Size = new Size(63, 17);
            lblBPT3InventionChance.TabIndex = 46;
            lblBPT3InventionChance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPT3InventionChance1
            // 
            lblBPT3InventionChance1.AutoSize = true;
            lblBPT3InventionChance1.Location = new Point(2, 60);
            lblBPT3InventionChance1.Name = "lblBPT3InventionChance1";
            lblBPT3InventionChance1.Size = new Size(47, 13);
            lblBPT3InventionChance1.TabIndex = 45;
            lblBPT3InventionChance1.Text = "Chance:";
            // 
            // lblT3InventStatus
            // 
            lblT3InventStatus.ForeColor = Color.Black;
            lblT3InventStatus.Location = new Point(1, 4);
            lblT3InventStatus.Name = "lblT3InventStatus";
            lblT3InventStatus.Size = new Size(185, 13);
            lblT3InventStatus.TabIndex = 37;
            lblT3InventStatus.Text = "T3 Invention Calculations:";
            // 
            // chkBPIncludeT3Time
            // 
            chkBPIncludeT3Time.AutoSize = true;
            chkBPIncludeT3Time.Location = new Point(179, 59);
            chkBPIncludeT3Time.Name = "chkBPIncludeT3Time";
            chkBPIncludeT3Time.Size = new Size(99, 17);
            chkBPIncludeT3Time.TabIndex = 49;
            chkBPIncludeT3Time.Text = "Invention Time:";
            chkBPIncludeT3Time.UseVisualStyleBackColor = true;
            // 
            // chkBPIncludeT3Costs
            // 
            chkBPIncludeT3Costs.AutoSize = true;
            chkBPIncludeT3Costs.Location = new Point(71, 59);
            chkBPIncludeT3Costs.Name = "chkBPIncludeT3Costs";
            chkBPIncludeT3Costs.Size = new Size(102, 17);
            chkBPIncludeT3Costs.TabIndex = 47;
            chkBPIncludeT3Costs.Text = "Invention Costs:";
            chkBPIncludeT3Costs.UseVisualStyleBackColor = true;
            // 
            // tabInventionCalcs
            // 
            tabInventionCalcs.Controls.Add(lblBPCopyTime);
            tabInventionCalcs.Controls.Add(lblBPT2InventStatus);
            tabInventionCalcs.Controls.Add(lblBPCopyCosts);
            tabInventionCalcs.Controls.Add(txtBPInventionLines);
            tabInventionCalcs.Controls.Add(lblBPInventionLines);
            tabInventionCalcs.Controls.Add(lblInventionChance1);
            tabInventionCalcs.Controls.Add(lblBPDecryptor);
            tabInventionCalcs.Controls.Add(lblBPInventionTime);
            tabInventionCalcs.Controls.Add(lblBPDecryptorStats);
            tabInventionCalcs.Controls.Add(lblBPInventionCost);
            tabInventionCalcs.Controls.Add(cmbBPInventionDecryptor);
            tabInventionCalcs.Controls.Add(lblBPInventionChance);
            tabInventionCalcs.Controls.Add(chkBPIncludeInventionTime);
            tabInventionCalcs.Controls.Add(chkBPIncludeCopyTime);
            tabInventionCalcs.Controls.Add(chkBPIncludeCopyCosts);
            tabInventionCalcs.Controls.Add(chkBPIncludeInventionCosts);
            tabInventionCalcs.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabInventionCalcs.Location = new Point(4, 4);
            tabInventionCalcs.Margin = new Padding(0);
            tabInventionCalcs.Name = "tabInventionCalcs";
            tabInventionCalcs.Padding = new Padding(3);
            tabInventionCalcs.Size = new Size(261, 142);
            tabInventionCalcs.TabIndex = 0;
            tabInventionCalcs.Text = "Invention";
            tabInventionCalcs.UseVisualStyleBackColor = true;
            // 
            // lblBPCopyTime
            // 
            lblBPCopyTime.BorderStyle = BorderStyle.FixedSingle;
            lblBPCopyTime.Location = new Point(179, 111);
            lblBPCopyTime.Name = "lblBPCopyTime";
            lblBPCopyTime.Size = new Size(99, 17);
            lblBPCopyTime.TabIndex = 36;
            lblBPCopyTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPT2InventStatus
            // 
            lblBPT2InventStatus.AutoSize = true;
            lblBPT2InventStatus.ForeColor = Color.Black;
            lblBPT2InventStatus.Location = new Point(1, 4);
            lblBPT2InventStatus.Name = "lblBPT2InventStatus";
            lblBPT2InventStatus.Size = new Size(114, 13);
            lblBPT2InventStatus.TabIndex = 19;
            lblBPT2InventStatus.Text = "Invention Calculations:";
            // 
            // lblBPCopyCosts
            // 
            lblBPCopyCosts.BorderStyle = BorderStyle.FixedSingle;
            lblBPCopyCosts.Location = new Point(71, 111);
            lblBPCopyCosts.Name = "lblBPCopyCosts";
            lblBPCopyCosts.Size = new Size(105, 17);
            lblBPCopyCosts.TabIndex = 34;
            lblBPCopyCosts.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBPInventionLines
            // 
            txtBPInventionLines.Location = new Point(4, 36);
            txtBPInventionLines.MaxLength = 4;
            txtBPInventionLines.Name = "txtBPInventionLines";
            txtBPInventionLines.Size = new Size(31, 20);
            txtBPInventionLines.TabIndex = 24;
            // 
            // lblBPInventionLines
            // 
            lblBPInventionLines.AutoSize = true;
            lblBPInventionLines.Location = new Point(3, 22);
            lblBPInventionLines.Name = "lblBPInventionLines";
            lblBPInventionLines.Size = new Size(35, 13);
            lblBPInventionLines.TabIndex = 23;
            lblBPInventionLines.Text = "Lines:";
            // 
            // lblInventionChance1
            // 
            lblInventionChance1.AutoSize = true;
            lblInventionChance1.Location = new Point(2, 60);
            lblInventionChance1.Name = "lblInventionChance1";
            lblInventionChance1.Size = new Size(47, 13);
            lblInventionChance1.TabIndex = 27;
            lblInventionChance1.Text = "Chance:";
            // 
            // lblBPDecryptor
            // 
            lblBPDecryptor.AutoSize = true;
            lblBPDecryptor.Location = new Point(38, 22);
            lblBPDecryptor.Name = "lblBPDecryptor";
            lblBPDecryptor.Size = new Size(89, 13);
            lblBPDecryptor.TabIndex = 25;
            lblBPDecryptor.Text = "Select Decryptor:";
            // 
            // lblBPInventionTime
            // 
            lblBPInventionTime.BorderStyle = BorderStyle.FixedSingle;
            lblBPInventionTime.Location = new Point(179, 75);
            lblBPInventionTime.Name = "lblBPInventionTime";
            lblBPInventionTime.Size = new Size(98, 17);
            lblBPInventionTime.TabIndex = 32;
            lblBPInventionTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPDecryptorStats
            // 
            lblBPDecryptorStats.BorderStyle = BorderStyle.FixedSingle;
            lblBPDecryptorStats.Location = new Point(179, 2);
            lblBPDecryptorStats.Name = "lblBPDecryptorStats";
            lblBPDecryptorStats.Size = new Size(98, 30);
            lblBPDecryptorStats.TabIndex = 20;
            lblBPDecryptorStats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPInventionCost
            // 
            lblBPInventionCost.BorderStyle = BorderStyle.FixedSingle;
            lblBPInventionCost.Location = new Point(71, 75);
            lblBPInventionCost.Name = "lblBPInventionCost";
            lblBPInventionCost.Size = new Size(105, 17);
            lblBPInventionCost.TabIndex = 30;
            lblBPInventionCost.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbBPInventionDecryptor
            // 
            cmbBPInventionDecryptor.FormattingEnabled = true;
            cmbBPInventionDecryptor.ItemHeight = 13;
            cmbBPInventionDecryptor.Location = new Point(41, 36);
            cmbBPInventionDecryptor.Name = "cmbBPInventionDecryptor";
            cmbBPInventionDecryptor.Size = new Size(236, 21);
            cmbBPInventionDecryptor.TabIndex = 26;
            // 
            // lblBPInventionChance
            // 
            lblBPInventionChance.BorderStyle = BorderStyle.FixedSingle;
            lblBPInventionChance.Location = new Point(4, 75);
            lblBPInventionChance.Name = "lblBPInventionChance";
            lblBPInventionChance.Size = new Size(63, 17);
            lblBPInventionChance.TabIndex = 28;
            lblBPInventionChance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkBPIncludeInventionTime
            // 
            chkBPIncludeInventionTime.AutoSize = true;
            chkBPIncludeInventionTime.Location = new Point(179, 59);
            chkBPIncludeInventionTime.Name = "chkBPIncludeInventionTime";
            chkBPIncludeInventionTime.Size = new Size(99, 17);
            chkBPIncludeInventionTime.TabIndex = 31;
            chkBPIncludeInventionTime.Text = "Invention Time:";
            chkBPIncludeInventionTime.UseVisualStyleBackColor = true;
            // 
            // chkBPIncludeCopyTime
            // 
            chkBPIncludeCopyTime.AutoSize = true;
            chkBPIncludeCopyTime.Location = new Point(179, 95);
            chkBPIncludeCopyTime.Name = "chkBPIncludeCopyTime";
            chkBPIncludeCopyTime.Size = new Size(79, 17);
            chkBPIncludeCopyTime.TabIndex = 35;
            chkBPIncludeCopyTime.Text = "Copy Time:";
            chkBPIncludeCopyTime.UseVisualStyleBackColor = true;
            // 
            // chkBPIncludeCopyCosts
            // 
            chkBPIncludeCopyCosts.AutoSize = true;
            chkBPIncludeCopyCosts.Location = new Point(71, 95);
            chkBPIncludeCopyCosts.Name = "chkBPIncludeCopyCosts";
            chkBPIncludeCopyCosts.Size = new Size(82, 17);
            chkBPIncludeCopyCosts.TabIndex = 33;
            chkBPIncludeCopyCosts.Text = "Copy Costs:";
            chkBPIncludeCopyCosts.UseVisualStyleBackColor = true;
            // 
            // chkBPIncludeInventionCosts
            // 
            chkBPIncludeInventionCosts.AutoSize = true;
            chkBPIncludeInventionCosts.Location = new Point(71, 59);
            chkBPIncludeInventionCosts.Name = "chkBPIncludeInventionCosts";
            chkBPIncludeInventionCosts.Size = new Size(102, 17);
            chkBPIncludeInventionCosts.TabIndex = 29;
            chkBPIncludeInventionCosts.Text = "Invention Costs:";
            chkBPIncludeInventionCosts.UseVisualStyleBackColor = true;
            // 
            // btnBPSaveSettings
            // 
            btnBPSaveSettings.Location = new Point(54, 154);
            btnBPSaveSettings.Name = "btnBPSaveSettings";
            btnBPSaveSettings.Size = new Size(82, 34);
            btnBPSaveSettings.TabIndex = 14;
            btnBPSaveSettings.Text = "Save Settings";
            btnBPSaveSettings.UseVisualStyleBackColor = true;
            // 
            // txtBPLines
            // 
            txtBPLines.Location = new Point(38, 105);
            txtBPLines.MaxLength = 3;
            txtBPLines.Name = "txtBPLines";
            txtBPLines.Size = new Size(32, 20);
            txtBPLines.TabIndex = 8;
            // 
            // pictBP
            // 
            pictBP.BackColor = Color.White;
            pictBP.BorderStyle = BorderStyle.Fixed3D;
            pictBP.Location = new Point(6, 12);
            pictBP.Name = "pictBP";
            pictBP.Size = new Size(68, 69);
            pictBP.TabIndex = 0;
            pictBP.TabStop = false;
            // 
            // gbBPManualSystemCostIndex
            // 
            gbBPManualSystemCostIndex.Controls.Add(btnBPUpdateCostIndex);
            gbBPManualSystemCostIndex.Controls.Add(lblBPSystemCostIndexManual);
            gbBPManualSystemCostIndex.Controls.Add(txtBPUpdateCostIndex);
            gbBPManualSystemCostIndex.Location = new Point(323, 7);
            gbBPManualSystemCostIndex.Name = "gbBPManualSystemCostIndex";
            gbBPManualSystemCostIndex.Size = new Size(127, 60);
            gbBPManualSystemCostIndex.TabIndex = 23;
            gbBPManualSystemCostIndex.TabStop = false;
            gbBPManualSystemCostIndex.Text = "Update System Data:";
            // 
            // btnBPUpdateCostIndex
            // 
            btnBPUpdateCostIndex.Enabled = false;
            btnBPUpdateCostIndex.Location = new Point(76, 13);
            btnBPUpdateCostIndex.Name = "btnBPUpdateCostIndex";
            btnBPUpdateCostIndex.Size = new Size(50, 45);
            btnBPUpdateCostIndex.TabIndex = 21;
            btnBPUpdateCostIndex.Text = "Update System";
            btnBPUpdateCostIndex.UseVisualStyleBackColor = true;
            // 
            // lblBPSystemCostIndexManual
            // 
            lblBPSystemCostIndexManual.AutoSize = true;
            lblBPSystemCostIndexManual.Location = new Point(3, 20);
            lblBPSystemCostIndexManual.Name = "lblBPSystemCostIndexManual";
            lblBPSystemCostIndexManual.Size = new Size(60, 13);
            lblBPSystemCostIndexManual.TabIndex = 26;
            lblBPSystemCostIndexManual.Text = "Cost Index:";
            // 
            // txtBPUpdateCostIndex
            // 
            txtBPUpdateCostIndex.Location = new Point(5, 37);
            txtBPUpdateCostIndex.MaxLength = 7;
            txtBPUpdateCostIndex.Name = "txtBPUpdateCostIndex";
            txtBPUpdateCostIndex.Size = new Size(66, 20);
            txtBPUpdateCostIndex.TabIndex = 22;
            txtBPUpdateCostIndex.Text = "0.00 %";
            txtBPUpdateCostIndex.TextAlign = HorizontalAlignment.Right;
            // 
            // txtBPNumBPs
            // 
            txtBPNumBPs.Location = new Point(104, 105);
            txtBPNumBPs.Name = "txtBPNumBPs";
            txtBPNumBPs.Size = new Size(32, 20);
            txtBPNumBPs.TabIndex = 10;
            // 
            // btnBPRefreshBP
            // 
            btnBPRefreshBP.Location = new Point(6, 189);
            btnBPRefreshBP.Name = "btnBPRefreshBP";
            btnBPRefreshBP.Size = new Size(130, 30);
            btnBPRefreshBP.TabIndex = 13;
            btnBPRefreshBP.Text = "Refresh";
            btnBPRefreshBP.UseVisualStyleBackColor = true;
            // 
            // lblBPLines
            // 
            lblBPLines.AutoSize = true;
            lblBPLines.Location = new Point(4, 109);
            lblBPLines.Name = "lblBPLines";
            lblBPLines.Size = new Size(35, 13);
            lblBPLines.TabIndex = 7;
            lblBPLines.Text = "Lines:";
            // 
            // txtBPME
            // 
            txtBPME.Location = new Point(76, 60);
            txtBPME.MaxLength = 2;
            txtBPME.Name = "txtBPME";
            txtBPME.Size = new Size(29, 20);
            txtBPME.TabIndex = 4;
            txtBPME.Text = "0";
            txtBPME.TextAlign = HorizontalAlignment.Right;
            // 
            // lblBPRuns
            // 
            lblBPRuns.AutoSize = true;
            lblBPRuns.Location = new Point(74, 11);
            lblBPRuns.Name = "lblBPRuns";
            lblBPRuns.Size = new Size(62, 13);
            lblBPRuns.TabIndex = 0;
            lblBPRuns.Text = "Total Runs:";
            // 
            // chkBPBuildBuy
            // 
            chkBPBuildBuy.AutoSize = true;
            chkBPBuildBuy.Location = new Point(12, 86);
            chkBPBuildBuy.Name = "chkBPBuildBuy";
            chkBPBuildBuy.Size = new Size(119, 17);
            chkBPBuildBuy.TabIndex = 6;
            chkBPBuildBuy.Text = "Calculate Build/Buy";
            chkBPBuildBuy.UseVisualStyleBackColor = true;
            // 
            // txtBPRuns
            // 
            txtBPRuns.Location = new Point(76, 25);
            txtBPRuns.MaxLength = 6;
            txtBPRuns.Name = "txtBPRuns";
            txtBPRuns.Size = new Size(60, 20);
            txtBPRuns.TabIndex = 1;
            txtBPRuns.TextAlign = HorizontalAlignment.Right;
            // 
            // txtBPAddlCosts
            // 
            txtBPAddlCosts.Location = new Point(38, 130);
            txtBPAddlCosts.MaxLength = 15;
            txtBPAddlCosts.Name = "txtBPAddlCosts";
            txtBPAddlCosts.Size = new Size(98, 20);
            txtBPAddlCosts.TabIndex = 12;
            txtBPAddlCosts.TextAlign = HorizontalAlignment.Right;
            // 
            // lblBPAddlCosts
            // 
            lblBPAddlCosts.Location = new Point(4, 126);
            lblBPAddlCosts.Name = "lblBPAddlCosts";
            lblBPAddlCosts.Size = new Size(39, 28);
            lblBPAddlCosts.TabIndex = 11;
            lblBPAddlCosts.Text = "Add'l Costs:";
            // 
            // lblBPME
            // 
            lblBPME.AutoSize = true;
            lblBPME.Location = new Point(77, 46);
            lblBPME.Name = "lblBPME";
            lblBPME.Size = new Size(26, 13);
            lblBPME.TabIndex = 2;
            lblBPME.Text = "ME:";
            // 
            // txtBPTE
            // 
            txtBPTE.Location = new Point(107, 60);
            txtBPTE.MaxLength = 2;
            txtBPTE.Name = "txtBPTE";
            txtBPTE.Size = new Size(29, 20);
            txtBPTE.TabIndex = 5;
            txtBPTE.Text = "0";
            txtBPTE.TextAlign = HorizontalAlignment.Right;
            // 
            // lblBPPE
            // 
            lblBPPE.AutoSize = true;
            lblBPPE.Location = new Point(109, 46);
            lblBPPE.Name = "lblBPPE";
            lblBPPE.Size = new Size(24, 13);
            lblBPPE.TabIndex = 3;
            lblBPPE.Text = "TE:";
            // 
            // lblBPNumBPs
            // 
            lblBPNumBPs.AutoSize = true;
            lblBPNumBPs.Location = new Point(75, 109);
            lblBPNumBPs.Name = "lblBPNumBPs";
            lblBPNumBPs.Size = new Size(29, 13);
            lblBPNumBPs.TabIndex = 9;
            lblBPNumBPs.Text = "BPs:";
            // 
            // gbBPIgnoreinCalcs
            // 
            gbBPIgnoreinCalcs.Controls.Add(chkBPIgnoreMinerals);
            gbBPIgnoreinCalcs.Controls.Add(chkBPIgnoreT1Item);
            gbBPIgnoreinCalcs.Controls.Add(chkBPIgnoreInvention);
            gbBPIgnoreinCalcs.Location = new Point(141, 7);
            gbBPIgnoreinCalcs.Name = "gbBPIgnoreinCalcs";
            gbBPIgnoreinCalcs.Size = new Size(94, 60);
            gbBPIgnoreinCalcs.TabIndex = 20;
            gbBPIgnoreinCalcs.TabStop = false;
            gbBPIgnoreinCalcs.Text = "Ignore in Calcs:";
            // 
            // chkBPIgnoreMinerals
            // 
            chkBPIgnoreMinerals.AutoSize = true;
            chkBPIgnoreMinerals.Location = new Point(5, 41);
            chkBPIgnoreMinerals.Name = "chkBPIgnoreMinerals";
            chkBPIgnoreMinerals.Size = new Size(65, 17);
            chkBPIgnoreMinerals.TabIndex = 1;
            chkBPIgnoreMinerals.Text = "Minerals";
            chkBPIgnoreMinerals.UseVisualStyleBackColor = true;
            // 
            // chkBPIgnoreT1Item
            // 
            chkBPIgnoreT1Item.AutoSize = true;
            chkBPIgnoreT1Item.Location = new Point(5, 27);
            chkBPIgnoreT1Item.Name = "chkBPIgnoreT1Item";
            chkBPIgnoreT1Item.Size = new Size(62, 17);
            chkBPIgnoreT1Item.TabIndex = 2;
            chkBPIgnoreT1Item.Text = "T1 Item";
            chkBPIgnoreT1Item.UseVisualStyleBackColor = true;
            // 
            // chkBPIgnoreInvention
            // 
            chkBPIgnoreInvention.AutoSize = true;
            chkBPIgnoreInvention.Location = new Point(5, 13);
            chkBPIgnoreInvention.Name = "chkBPIgnoreInvention";
            chkBPIgnoreInvention.Size = new Size(70, 17);
            chkBPIgnoreInvention.TabIndex = 0;
            chkBPIgnoreInvention.Text = "Invention";
            chkBPIgnoreInvention.UseVisualStyleBackColor = true;
            // 
            // btnBPBuiltComponents
            // 
            btnBPBuiltComponents.AutoSize = true;
            btnBPBuiltComponents.Location = new Point(84, 588);
            btnBPBuiltComponents.Name = "btnBPBuiltComponents";
            btnBPBuiltComponents.Size = new Size(99, 23);
            btnBPBuiltComponents.TabIndex = 79;
            btnBPBuiltComponents.Text = "Built Components";
            btnBPBuiltComponents.UseVisualStyleBackColor = true;
            // 
            // btnBPComponents
            // 
            btnBPComponents.AutoSize = true;
            btnBPComponents.Location = new Point(6, 588);
            btnBPComponents.Name = "btnBPComponents";
            btnBPComponents.Size = new Size(76, 23);
            btnBPComponents.TabIndex = 78;
            btnBPComponents.Text = "Components";
            btnBPComponents.UseVisualStyleBackColor = true;
            // 
            // rbtnBPRawT2MatType
            // 
            rbtnBPRawT2MatType.AutoSize = true;
            rbtnBPRawT2MatType.BackColor = Color.Transparent;
            rbtnBPRawT2MatType.Location = new Point(668, 236);
            rbtnBPRawT2MatType.Name = "rbtnBPRawT2MatType";
            rbtnBPRawT2MatType.Size = new Size(47, 17);
            rbtnBPRawT2MatType.TabIndex = 75;
            rbtnBPRawT2MatType.TabStop = true;
            rbtnBPRawT2MatType.Text = "Raw";
            rbtnBPRawT2MatType.UseVisualStyleBackColor = false;
            // 
            // rbtnBPProcT2MatType
            // 
            rbtnBPProcT2MatType.AutoSize = true;
            rbtnBPProcT2MatType.BackColor = Color.Transparent;
            rbtnBPProcT2MatType.Location = new Point(594, 236);
            rbtnBPProcT2MatType.Name = "rbtnBPProcT2MatType";
            rbtnBPProcT2MatType.Size = new Size(75, 17);
            rbtnBPProcT2MatType.TabIndex = 74;
            rbtnBPProcT2MatType.TabStop = true;
            rbtnBPProcT2MatType.Text = "Processed";
            rbtnBPProcT2MatType.UseVisualStyleBackColor = false;
            // 
            // rbtnBPAdvT2MatType
            // 
            rbtnBPAdvT2MatType.AutoSize = true;
            rbtnBPAdvT2MatType.BackColor = Color.Transparent;
            rbtnBPAdvT2MatType.Location = new Point(522, 236);
            rbtnBPAdvT2MatType.Name = "rbtnBPAdvT2MatType";
            rbtnBPAdvT2MatType.Size = new Size(74, 17);
            rbtnBPAdvT2MatType.TabIndex = 19;
            rbtnBPAdvT2MatType.TabStop = true;
            rbtnBPAdvT2MatType.Text = "Advanced";
            rbtnBPAdvT2MatType.UseVisualStyleBackColor = false;
            // 
            // lblBPT2MatTypeSelector
            // 
            lblBPT2MatTypeSelector.BackColor = Color.Transparent;
            lblBPT2MatTypeSelector.Location = new Point(414, 234);
            lblBPT2MatTypeSelector.Name = "lblBPT2MatTypeSelector";
            lblBPT2MatTypeSelector.Size = new Size(308, 20);
            lblBPT2MatTypeSelector.TabIndex = 76;
            lblBPT2MatTypeSelector.Text = "T2/T3 Material Type:";
            lblBPT2MatTypeSelector.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lstBPList
            // 
            lstBPList.BackColor = SystemColors.Window;
            lstBPList.FormattingEnabled = true;
            lstBPList.Location = new Point(4, 47);
            lstBPList.Name = "lstBPList";
            lstBPList.Size = new Size(322, 134);
            lstBPList.TabIndex = 64;
            lstBPList.Visible = false;
            // 
            // gbBPBlueprintType
            // 
            gbBPBlueprintType.Controls.Add(chkBPNPCBPOs);
            gbBPBlueprintType.Controls.Add(rbtnBPReactionsBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPStructureModulesBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPCelestialsBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPMiscBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPStructureBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPFavoriteBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPStructureRigsBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPOwnedBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPRigBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPBoosterBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPSubsystemBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPModuleBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPAmmoChargeBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPDroneBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPComponentBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPAllBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPShipBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPDeployableBlueprints);
            gbBPBlueprintType.Location = new Point(4, 51);
            gbBPBlueprintType.Name = "gbBPBlueprintType";
            gbBPBlueprintType.Size = new Size(294, 125);
            gbBPBlueprintType.TabIndex = 71;
            gbBPBlueprintType.TabStop = false;
            gbBPBlueprintType.Text = "Blueprint Type";
            // 
            // chkBPNPCBPOs
            // 
            chkBPNPCBPOs.AutoSize = true;
            chkBPNPCBPOs.Location = new Point(208, 103);
            chkBPNPCBPOs.Name = "chkBPNPCBPOs";
            chkBPNPCBPOs.Size = new Size(78, 17);
            chkBPNPCBPOs.TabIndex = 6;
            chkBPNPCBPOs.Text = "NPC BPOs";
            chkBPNPCBPOs.TextAlign = ContentAlignment.TopLeft;
            chkBPNPCBPOs.UseVisualStyleBackColor = true;
            // 
            // rbtnBPReactionsBlueprints
            // 
            rbtnBPReactionsBlueprints.AutoSize = true;
            rbtnBPReactionsBlueprints.Location = new Point(9, 102);
            rbtnBPReactionsBlueprints.Name = "rbtnBPReactionsBlueprints";
            rbtnBPReactionsBlueprints.Size = new Size(73, 17);
            rbtnBPReactionsBlueprints.TabIndex = 66;
            rbtnBPReactionsBlueprints.TabStop = true;
            rbtnBPReactionsBlueprints.Text = "Reactions";
            rbtnBPReactionsBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPStructureModulesBlueprints
            // 
            rbtnBPStructureModulesBlueprints.AutoSize = true;
            rbtnBPStructureModulesBlueprints.Location = new Point(97, 102);
            rbtnBPStructureModulesBlueprints.Name = "rbtnBPStructureModulesBlueprints";
            rbtnBPStructureModulesBlueprints.Size = new Size(111, 17);
            rbtnBPStructureModulesBlueprints.TabIndex = 65;
            rbtnBPStructureModulesBlueprints.TabStop = true;
            rbtnBPStructureModulesBlueprints.Text = "Structure Modules";
            rbtnBPStructureModulesBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPCelestialsBlueprints
            // 
            rbtnBPCelestialsBlueprints.AutoSize = true;
            rbtnBPCelestialsBlueprints.Location = new Point(208, 85);
            rbtnBPCelestialsBlueprints.Name = "rbtnBPCelestialsBlueprints";
            rbtnBPCelestialsBlueprints.Size = new Size(69, 17);
            rbtnBPCelestialsBlueprints.TabIndex = 14;
            rbtnBPCelestialsBlueprints.TabStop = true;
            rbtnBPCelestialsBlueprints.Text = "Celestials";
            rbtnBPCelestialsBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPMiscBlueprints
            // 
            rbtnBPMiscBlueprints.AutoSize = true;
            rbtnBPMiscBlueprints.Location = new Point(149, 51);
            rbtnBPMiscBlueprints.Name = "rbtnBPMiscBlueprints";
            rbtnBPMiscBlueprints.Size = new Size(50, 17);
            rbtnBPMiscBlueprints.TabIndex = 15;
            rbtnBPMiscBlueprints.TabStop = true;
            rbtnBPMiscBlueprints.Text = "Misc.";
            rbtnBPMiscBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPStructureBlueprints
            // 
            rbtnBPStructureBlueprints.AutoSize = true;
            rbtnBPStructureBlueprints.Location = new Point(9, 85);
            rbtnBPStructureBlueprints.Name = "rbtnBPStructureBlueprints";
            rbtnBPStructureBlueprints.Size = new Size(73, 17);
            rbtnBPStructureBlueprints.TabIndex = 12;
            rbtnBPStructureBlueprints.TabStop = true;
            rbtnBPStructureBlueprints.Text = "Structures";
            rbtnBPStructureBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPFavoriteBlueprints
            // 
            rbtnBPFavoriteBlueprints.AutoSize = true;
            rbtnBPFavoriteBlueprints.Location = new Point(208, 17);
            rbtnBPFavoriteBlueprints.Name = "rbtnBPFavoriteBlueprints";
            rbtnBPFavoriteBlueprints.Size = new Size(68, 17);
            rbtnBPFavoriteBlueprints.TabIndex = 2;
            rbtnBPFavoriteBlueprints.TabStop = true;
            rbtnBPFavoriteBlueprints.Text = "Favorites";
            rbtnBPFavoriteBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPStructureRigsBlueprints
            // 
            rbtnBPStructureRigsBlueprints.AutoSize = true;
            rbtnBPStructureRigsBlueprints.Location = new Point(97, 85);
            rbtnBPStructureRigsBlueprints.Name = "rbtnBPStructureRigsBlueprints";
            rbtnBPStructureRigsBlueprints.Size = new Size(92, 17);
            rbtnBPStructureRigsBlueprints.TabIndex = 13;
            rbtnBPStructureRigsBlueprints.TabStop = true;
            rbtnBPStructureRigsBlueprints.Text = "Structure Rigs";
            rbtnBPStructureRigsBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPOwnedBlueprints
            // 
            rbtnBPOwnedBlueprints.AutoSize = true;
            rbtnBPOwnedBlueprints.Location = new Point(97, 17);
            rbtnBPOwnedBlueprints.Name = "rbtnBPOwnedBlueprints";
            rbtnBPOwnedBlueprints.Size = new Size(59, 17);
            rbtnBPOwnedBlueprints.TabIndex = 1;
            rbtnBPOwnedBlueprints.TabStop = true;
            rbtnBPOwnedBlueprints.Text = "Owned";
            rbtnBPOwnedBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPRigBlueprints
            // 
            rbtnBPRigBlueprints.AutoSize = true;
            rbtnBPRigBlueprints.Location = new Point(97, 51);
            rbtnBPRigBlueprints.Name = "rbtnBPRigBlueprints";
            rbtnBPRigBlueprints.Size = new Size(46, 17);
            rbtnBPRigBlueprints.TabIndex = 7;
            rbtnBPRigBlueprints.TabStop = true;
            rbtnBPRigBlueprints.Text = "Rigs";
            rbtnBPRigBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPBoosterBlueprints
            // 
            rbtnBPBoosterBlueprints.AutoSize = true;
            rbtnBPBoosterBlueprints.Location = new Point(208, 68);
            rbtnBPBoosterBlueprints.Name = "rbtnBPBoosterBlueprints";
            rbtnBPBoosterBlueprints.Size = new Size(66, 17);
            rbtnBPBoosterBlueprints.TabIndex = 11;
            rbtnBPBoosterBlueprints.TabStop = true;
            rbtnBPBoosterBlueprints.Text = "Boosters";
            rbtnBPBoosterBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPSubsystemBlueprints
            // 
            rbtnBPSubsystemBlueprints.AutoSize = true;
            rbtnBPSubsystemBlueprints.Location = new Point(208, 51);
            rbtnBPSubsystemBlueprints.Name = "rbtnBPSubsystemBlueprints";
            rbtnBPSubsystemBlueprints.Size = new Size(81, 17);
            rbtnBPSubsystemBlueprints.TabIndex = 8;
            rbtnBPSubsystemBlueprints.TabStop = true;
            rbtnBPSubsystemBlueprints.Text = "Subsystems";
            rbtnBPSubsystemBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPModuleBlueprints
            // 
            rbtnBPModuleBlueprints.AutoSize = true;
            rbtnBPModuleBlueprints.Location = new Point(208, 34);
            rbtnBPModuleBlueprints.Name = "rbtnBPModuleBlueprints";
            rbtnBPModuleBlueprints.Size = new Size(65, 17);
            rbtnBPModuleBlueprints.TabIndex = 4;
            rbtnBPModuleBlueprints.TabStop = true;
            rbtnBPModuleBlueprints.Text = "Modules";
            rbtnBPModuleBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPAmmoChargeBlueprints
            // 
            rbtnBPAmmoChargeBlueprints.AutoSize = true;
            rbtnBPAmmoChargeBlueprints.Location = new Point(97, 34);
            rbtnBPAmmoChargeBlueprints.Name = "rbtnBPAmmoChargeBlueprints";
            rbtnBPAmmoChargeBlueprints.Size = new Size(98, 17);
            rbtnBPAmmoChargeBlueprints.TabIndex = 5;
            rbtnBPAmmoChargeBlueprints.TabStop = true;
            rbtnBPAmmoChargeBlueprints.Text = "Ammo/Charges";
            rbtnBPAmmoChargeBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPDroneBlueprints
            // 
            rbtnBPDroneBlueprints.AutoSize = true;
            rbtnBPDroneBlueprints.Location = new Point(9, 51);
            rbtnBPDroneBlueprints.Name = "rbtnBPDroneBlueprints";
            rbtnBPDroneBlueprints.Size = new Size(59, 17);
            rbtnBPDroneBlueprints.TabIndex = 6;
            rbtnBPDroneBlueprints.TabStop = true;
            rbtnBPDroneBlueprints.Text = "Drones";
            rbtnBPDroneBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPComponentBlueprints
            // 
            rbtnBPComponentBlueprints.AutoSize = true;
            rbtnBPComponentBlueprints.Location = new Point(97, 68);
            rbtnBPComponentBlueprints.Name = "rbtnBPComponentBlueprints";
            rbtnBPComponentBlueprints.Size = new Size(84, 17);
            rbtnBPComponentBlueprints.TabIndex = 10;
            rbtnBPComponentBlueprints.TabStop = true;
            rbtnBPComponentBlueprints.Text = "Components";
            rbtnBPComponentBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPAllBlueprints
            // 
            rbtnBPAllBlueprints.AutoSize = true;
            rbtnBPAllBlueprints.Location = new Point(9, 17);
            rbtnBPAllBlueprints.Name = "rbtnBPAllBlueprints";
            rbtnBPAllBlueprints.Size = new Size(36, 17);
            rbtnBPAllBlueprints.TabIndex = 0;
            rbtnBPAllBlueprints.TabStop = true;
            rbtnBPAllBlueprints.Text = "All";
            rbtnBPAllBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPShipBlueprints
            // 
            rbtnBPShipBlueprints.AutoSize = true;
            rbtnBPShipBlueprints.Location = new Point(9, 34);
            rbtnBPShipBlueprints.Name = "rbtnBPShipBlueprints";
            rbtnBPShipBlueprints.Size = new Size(51, 17);
            rbtnBPShipBlueprints.TabIndex = 3;
            rbtnBPShipBlueprints.TabStop = true;
            rbtnBPShipBlueprints.Text = "Ships";
            rbtnBPShipBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPDeployableBlueprints
            // 
            rbtnBPDeployableBlueprints.AutoSize = true;
            rbtnBPDeployableBlueprints.Location = new Point(9, 68);
            rbtnBPDeployableBlueprints.Name = "rbtnBPDeployableBlueprints";
            rbtnBPDeployableBlueprints.Size = new Size(78, 17);
            rbtnBPDeployableBlueprints.TabIndex = 9;
            rbtnBPDeployableBlueprints.TabStop = true;
            rbtnBPDeployableBlueprints.Text = "Deployable";
            rbtnBPDeployableBlueprints.UseVisualStyleBackColor = true;
            // 
            // gbBPBlueprintTech
            // 
            gbBPBlueprintTech.Controls.Add(chkBPPirateFaction);
            gbBPBlueprintTech.Controls.Add(chkBPStoryline);
            gbBPBlueprintTech.Controls.Add(chkBPNavyFaction);
            gbBPBlueprintTech.Controls.Add(chkBPT3);
            gbBPBlueprintTech.Controls.Add(chkBPT2);
            gbBPBlueprintTech.Controls.Add(chkBPT1);
            gbBPBlueprintTech.Location = new Point(301, 106);
            gbBPBlueprintTech.Name = "gbBPBlueprintTech";
            gbBPBlueprintTech.Size = new Size(87, 126);
            gbBPBlueprintTech.TabIndex = 73;
            gbBPBlueprintTech.TabStop = false;
            gbBPBlueprintTech.Text = "Tech";
            // 
            // chkBPPirateFaction
            // 
            chkBPPirateFaction.AutoSize = true;
            chkBPPirateFaction.Location = new Point(8, 105);
            chkBPPirateFaction.Name = "chkBPPirateFaction";
            chkBPPirateFaction.Size = new Size(53, 17);
            chkBPPirateFaction.TabIndex = 5;
            chkBPPirateFaction.Text = "Pirate";
            chkBPPirateFaction.TextAlign = ContentAlignment.TopLeft;
            chkBPPirateFaction.UseVisualStyleBackColor = true;
            // 
            // chkBPStoryline
            // 
            chkBPStoryline.AutoSize = true;
            chkBPStoryline.Location = new Point(8, 69);
            chkBPStoryline.Name = "chkBPStoryline";
            chkBPStoryline.Size = new Size(66, 17);
            chkBPStoryline.TabIndex = 3;
            chkBPStoryline.Text = "Storyline";
            chkBPStoryline.UseVisualStyleBackColor = true;
            // 
            // chkBPNavyFaction
            // 
            chkBPNavyFaction.AutoSize = true;
            chkBPNavyFaction.Location = new Point(8, 87);
            chkBPNavyFaction.Name = "chkBPNavyFaction";
            chkBPNavyFaction.Size = new Size(51, 17);
            chkBPNavyFaction.TabIndex = 4;
            chkBPNavyFaction.Text = "Navy";
            chkBPNavyFaction.TextAlign = ContentAlignment.TopLeft;
            chkBPNavyFaction.UseVisualStyleBackColor = true;
            // 
            // chkBPT3
            // 
            chkBPT3.AutoSize = true;
            chkBPT3.Location = new Point(8, 51);
            chkBPT3.Name = "chkBPT3";
            chkBPT3.Size = new Size(60, 17);
            chkBPT3.TabIndex = 2;
            chkBPT3.Text = "Tech 3";
            chkBPT3.UseVisualStyleBackColor = true;
            // 
            // chkBPT2
            // 
            chkBPT2.AutoSize = true;
            chkBPT2.Location = new Point(8, 33);
            chkBPT2.Name = "chkBPT2";
            chkBPT2.Size = new Size(60, 17);
            chkBPT2.TabIndex = 1;
            chkBPT2.Text = "Tech 2";
            chkBPT2.UseVisualStyleBackColor = true;
            // 
            // chkBPT1
            // 
            chkBPT1.AutoSize = true;
            chkBPT1.Location = new Point(8, 15);
            chkBPT1.Name = "chkBPT1";
            chkBPT1.Size = new Size(60, 17);
            chkBPT1.TabIndex = 0;
            chkBPT1.Text = "Tech 1";
            chkBPT1.UseVisualStyleBackColor = true;
            // 
            // gbFilters
            // 
            gbFilters.Controls.Add(chkBPXL);
            gbFilters.Controls.Add(chkBPLarge);
            gbFilters.Controls.Add(chkBPMedium);
            gbFilters.Controls.Add(chkBPSmall);
            gbFilters.Location = new Point(301, 51);
            gbFilters.Name = "gbFilters";
            gbFilters.Size = new Size(87, 55);
            gbFilters.TabIndex = 72;
            gbFilters.TabStop = false;
            gbFilters.Text = "Size Limit";
            // 
            // chkBPXL
            // 
            chkBPXL.AutoSize = true;
            chkBPXL.Location = new Point(43, 33);
            chkBPXL.Name = "chkBPXL";
            chkBPXL.Size = new Size(39, 17);
            chkBPXL.TabIndex = 4;
            chkBPXL.Text = "XL";
            chkBPXL.UseVisualStyleBackColor = true;
            // 
            // chkBPLarge
            // 
            chkBPLarge.AutoSize = true;
            chkBPLarge.Location = new Point(8, 33);
            chkBPLarge.Name = "chkBPLarge";
            chkBPLarge.Size = new Size(32, 17);
            chkBPLarge.TabIndex = 3;
            chkBPLarge.Text = "L";
            chkBPLarge.UseVisualStyleBackColor = true;
            // 
            // chkBPMedium
            // 
            chkBPMedium.AutoSize = true;
            chkBPMedium.Location = new Point(43, 15);
            chkBPMedium.Name = "chkBPMedium";
            chkBPMedium.Size = new Size(35, 17);
            chkBPMedium.TabIndex = 2;
            chkBPMedium.Text = "M";
            chkBPMedium.UseVisualStyleBackColor = true;
            // 
            // chkBPSmall
            // 
            chkBPSmall.AutoSize = true;
            chkBPSmall.Location = new Point(8, 15);
            chkBPSmall.Name = "chkBPSmall";
            chkBPSmall.Size = new Size(33, 17);
            chkBPSmall.TabIndex = 1;
            chkBPSmall.Text = "S";
            chkBPSmall.TextAlign = ContentAlignment.MiddleCenter;
            chkBPSmall.UseVisualStyleBackColor = true;
            // 
            // cmbBPBlueprintSelection
            // 
            cmbBPBlueprintSelection.Location = new Point(4, 27);
            cmbBPBlueprintSelection.Name = "cmbBPBlueprintSelection";
            cmbBPBlueprintSelection.Size = new Size(322, 21);
            cmbBPBlueprintSelection.TabIndex = 70;
            cmbBPBlueprintSelection.Text = "Select Blueprint or Reaction";
            // 
            // btnBPListView
            // 
            btnBPListView.Location = new Point(332, 14);
            btnBPListView.Name = "btnBPListView";
            btnBPListView.Size = new Size(56, 36);
            btnBPListView.TabIndex = 5;
            btnBPListView.Text = "Blueprint Viewer";
            btnBPListView.UseVisualStyleBackColor = true;
            // 
            // btnBPForward
            // 
            btnBPForward.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnBPForward.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnBPForward.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnBPForward.FlatStyle = FlatStyle.Flat;
            btnBPForward.Image = (Image)resources.GetObject("btnBPForward.Image");
            btnBPForward.Location = new Point(1114, 236);
            btnBPForward.Name = "btnBPForward";
            btnBPForward.Size = new Size(17, 19);
            btnBPForward.TabIndex = 37;
            btnBPForward.UseVisualStyleBackColor = true;
            // 
            // btnBPBack
            // 
            btnBPBack.BackColor = Color.Transparent;
            btnBPBack.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            btnBPBack.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnBPBack.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnBPBack.FlatStyle = FlatStyle.Flat;
            btnBPBack.Image = (Image)resources.GetObject("btnBPBack.Image");
            btnBPBack.Location = new Point(1091, 236);
            btnBPBack.Name = "btnBPBack";
            btnBPBack.Size = new Size(17, 19);
            btnBPBack.TabIndex = 36;
            btnBPBack.UseVisualStyleBackColor = false;
            // 
            // lblBPSelectBlueprint
            // 
            lblBPSelectBlueprint.AutoSize = true;
            lblBPSelectBlueprint.Location = new Point(3, 12);
            lblBPSelectBlueprint.Name = "lblBPSelectBlueprint";
            lblBPSelectBlueprint.Size = new Size(151, 13);
            lblBPSelectBlueprint.TabIndex = 0;
            lblBPSelectBlueprint.Text = "Selected Blueprint or Reaction";
            // 
            // gbBPInventionStats
            // 
            gbBPInventionStats.BackColor = Color.Transparent;
            gbBPInventionStats.Controls.Add(txtBPBrokerFeeRate);
            gbBPInventionStats.Controls.Add(txtBPMarketPriceEdit);
            gbBPInventionStats.Controls.Add(lblBPProductionTime);
            gbBPInventionStats.Controls.Add(lblBPTotalUnits);
            gbBPInventionStats.Controls.Add(lblBPTaxes);
            gbBPInventionStats.Controls.Add(lblBPTotalUnits1);
            gbBPInventionStats.Controls.Add(lblBPBrokerFees);
            gbBPInventionStats.Controls.Add(lblBPPT);
            gbBPInventionStats.Controls.Add(chkBPTaxes);
            gbBPInventionStats.Controls.Add(lblBPMarketCost);
            gbBPInventionStats.Controls.Add(lblBPMarketCost1);
            gbBPInventionStats.Controls.Add(lblBPRawTotalCost);
            gbBPInventionStats.Controls.Add(lblBPCompProfit);
            gbBPInventionStats.Controls.Add(lblBPRawTotalCost1);
            gbBPInventionStats.Controls.Add(chkBPBrokerFees);
            gbBPInventionStats.Controls.Add(lblBPCompIPH);
            gbBPInventionStats.Controls.Add(lblBPRawIPH);
            gbBPInventionStats.Controls.Add(lblBPTotalCompCost1);
            gbBPInventionStats.Controls.Add(lblBPCompIPH1);
            gbBPInventionStats.Controls.Add(lblBPTotalItemPT);
            gbBPInventionStats.Controls.Add(lblBPTotalCompCost);
            gbBPInventionStats.Controls.Add(lblBPCPTPT);
            gbBPInventionStats.Controls.Add(lblBPRawSVR);
            gbBPInventionStats.Controls.Add(lblBPRawIPH1);
            gbBPInventionStats.Controls.Add(lblBPRawProfit);
            gbBPInventionStats.Controls.Add(lblBPBPSVR);
            gbBPInventionStats.Controls.Add(lblBPCompProfit1);
            gbBPInventionStats.Controls.Add(lblBPRawProfit1);
            gbBPInventionStats.Controls.Add(lblBPBPSVR1);
            gbBPInventionStats.Controls.Add(lblBPRawSVR1);
            gbBPInventionStats.Controls.Add(chkBPPricePerUnit);
            gbBPInventionStats.Location = new Point(853, 8);
            gbBPInventionStats.Name = "gbBPInventionStats";
            gbBPInventionStats.Size = new Size(278, 224);
            gbBPInventionStats.TabIndex = 17;
            gbBPInventionStats.TabStop = false;
            // 
            // txtBPBrokerFeeRate
            // 
            txtBPBrokerFeeRate.Location = new Point(225, 77);
            txtBPBrokerFeeRate.Name = "txtBPBrokerFeeRate";
            txtBPBrokerFeeRate.Size = new Size(48, 20);
            txtBPBrokerFeeRate.TabIndex = 61;
            txtBPBrokerFeeRate.TabStop = false;
            txtBPBrokerFeeRate.TextAlign = HorizontalAlignment.Right;
            txtBPBrokerFeeRate.Visible = false;
            // 
            // txtBPMarketPriceEdit
            // 
            txtBPMarketPriceEdit.Location = new Point(53, 97);
            txtBPMarketPriceEdit.Name = "txtBPMarketPriceEdit";
            txtBPMarketPriceEdit.Size = new Size(131, 20);
            txtBPMarketPriceEdit.TabIndex = 60;
            txtBPMarketPriceEdit.TabStop = false;
            txtBPMarketPriceEdit.TextAlign = HorizontalAlignment.Right;
            txtBPMarketPriceEdit.Visible = false;
            // 
            // lblBPProductionTime
            // 
            lblBPProductionTime.BackColor = Color.Transparent;
            lblBPProductionTime.BorderStyle = BorderStyle.FixedSingle;
            lblBPProductionTime.Location = new Point(5, 25);
            lblBPProductionTime.Name = "lblBPProductionTime";
            lblBPProductionTime.Size = new Size(132, 17);
            lblBPProductionTime.TabIndex = 1;
            lblBPProductionTime.Text = "00:00:00";
            lblBPProductionTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPTotalUnits
            // 
            lblBPTotalUnits.BorderStyle = BorderStyle.FixedSingle;
            lblBPTotalUnits.Location = new Point(141, 60);
            lblBPTotalUnits.Name = "lblBPTotalUnits";
            lblBPTotalUnits.Size = new Size(132, 16);
            lblBPTotalUnits.TabIndex = 7;
            lblBPTotalUnits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPTaxes
            // 
            lblBPTaxes.BorderStyle = BorderStyle.FixedSingle;
            lblBPTaxes.Location = new Point(6, 98);
            lblBPTaxes.Name = "lblBPTaxes";
            lblBPTaxes.Size = new Size(131, 17);
            lblBPTaxes.TabIndex = 10;
            lblBPTaxes.Text = "0.00";
            lblBPTaxes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPTotalUnits1
            // 
            lblBPTotalUnits1.AutoSize = true;
            lblBPTotalUnits1.Location = new Point(138, 45);
            lblBPTotalUnits1.Name = "lblBPTotalUnits1";
            lblBPTotalUnits1.Size = new Size(34, 13);
            lblBPTotalUnits1.TabIndex = 6;
            lblBPTotalUnits1.Text = "Units:";
            // 
            // lblBPBrokerFees
            // 
            lblBPBrokerFees.BorderStyle = BorderStyle.FixedSingle;
            lblBPBrokerFees.Location = new Point(141, 98);
            lblBPBrokerFees.Name = "lblBPBrokerFees";
            lblBPBrokerFees.Size = new Size(132, 17);
            lblBPBrokerFees.TabIndex = 12;
            lblBPBrokerFees.Text = "0.00";
            lblBPBrokerFees.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPPT
            // 
            lblBPPT.AutoSize = true;
            lblBPPT.Location = new Point(3, 10);
            lblBPPT.Name = "lblBPPT";
            lblBPPT.Size = new Size(104, 13);
            lblBPPT.TabIndex = 0;
            lblBPPT.Text = "BP Production Time:";
            // 
            // chkBPTaxes
            // 
            chkBPTaxes.AutoSize = true;
            chkBPTaxes.Checked = true;
            chkBPTaxes.CheckState = CheckState.Checked;
            chkBPTaxes.Location = new Point(6, 79);
            chkBPTaxes.Name = "chkBPTaxes";
            chkBPTaxes.Size = new Size(58, 17);
            chkBPTaxes.TabIndex = 9;
            chkBPTaxes.Text = "Taxes:";
            chkBPTaxes.UseVisualStyleBackColor = true;
            // 
            // lblBPMarketCost
            // 
            lblBPMarketCost.BorderStyle = BorderStyle.FixedSingle;
            lblBPMarketCost.Location = new Point(5, 59);
            lblBPMarketCost.Name = "lblBPMarketCost";
            lblBPMarketCost.Size = new Size(132, 17);
            lblBPMarketCost.TabIndex = 5;
            lblBPMarketCost.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPMarketCost1
            // 
            lblBPMarketCost1.AutoSize = true;
            lblBPMarketCost1.Location = new Point(3, 45);
            lblBPMarketCost1.Name = "lblBPMarketCost1";
            lblBPMarketCost1.Size = new Size(70, 13);
            lblBPMarketCost1.TabIndex = 4;
            lblBPMarketCost1.Text = "Market Price:";
            // 
            // lblBPRawTotalCost
            // 
            lblBPRawTotalCost.BorderStyle = BorderStyle.FixedSingle;
            lblBPRawTotalCost.Location = new Point(141, 132);
            lblBPRawTotalCost.Name = "lblBPRawTotalCost";
            lblBPRawTotalCost.Size = new Size(132, 17);
            lblBPRawTotalCost.TabIndex = 16;
            lblBPRawTotalCost.Text = "0.00";
            lblBPRawTotalCost.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPCompProfit
            // 
            lblBPCompProfit.BorderStyle = BorderStyle.FixedSingle;
            lblBPCompProfit.Location = new Point(5, 166);
            lblBPCompProfit.Name = "lblBPCompProfit";
            lblBPCompProfit.Size = new Size(132, 17);
            lblBPCompProfit.TabIndex = 18;
            lblBPCompProfit.Text = "0.00";
            lblBPCompProfit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPRawTotalCost1
            // 
            lblBPRawTotalCost1.AutoSize = true;
            lblBPRawTotalCost1.Location = new Point(138, 118);
            lblBPRawTotalCost1.Name = "lblBPRawTotalCost1";
            lblBPRawTotalCost1.Size = new Size(104, 13);
            lblBPRawTotalCost1.TabIndex = 15;
            lblBPRawTotalCost1.Text = "Total Raw Mat Cost:";
            // 
            // chkBPBrokerFees
            // 
            chkBPBrokerFees.AutoSize = true;
            chkBPBrokerFees.Checked = true;
            chkBPBrokerFees.CheckState = CheckState.Checked;
            chkBPBrokerFees.Location = new Point(141, 79);
            chkBPBrokerFees.Name = "chkBPBrokerFees";
            chkBPBrokerFees.Size = new Size(52, 17);
            chkBPBrokerFees.TabIndex = 11;
            chkBPBrokerFees.Text = "Fees:";
            chkBPBrokerFees.ThreeState = true;
            chkBPBrokerFees.UseVisualStyleBackColor = true;
            // 
            // lblBPCompIPH
            // 
            lblBPCompIPH.BorderStyle = BorderStyle.FixedSingle;
            lblBPCompIPH.Location = new Point(5, 200);
            lblBPCompIPH.Name = "lblBPCompIPH";
            lblBPCompIPH.Size = new Size(89, 17);
            lblBPCompIPH.TabIndex = 22;
            lblBPCompIPH.Text = "0.00";
            lblBPCompIPH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPRawIPH
            // 
            lblBPRawIPH.BorderStyle = BorderStyle.FixedSingle;
            lblBPRawIPH.Location = new Point(141, 200);
            lblBPRawIPH.Name = "lblBPRawIPH";
            lblBPRawIPH.Size = new Size(89, 17);
            lblBPRawIPH.TabIndex = 26;
            lblBPRawIPH.Text = "0.00";
            lblBPRawIPH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPTotalCompCost1
            // 
            lblBPTotalCompCost1.AutoSize = true;
            lblBPTotalCompCost1.Location = new Point(3, 118);
            lblBPTotalCompCost1.Name = "lblBPTotalCompCost1";
            lblBPTotalCompCost1.Size = new Size(115, 13);
            lblBPTotalCompCost1.TabIndex = 13;
            lblBPTotalCompCost1.Text = "Total Component Cost:";
            // 
            // lblBPCompIPH1
            // 
            lblBPCompIPH1.AutoSize = true;
            lblBPCompIPH1.Font = new Font("Microsoft Sans Serif", 8.25f);
            lblBPCompIPH1.Location = new Point(3, 186);
            lblBPCompIPH1.Name = "lblBPCompIPH1";
            lblBPCompIPH1.Size = new Size(88, 13);
            lblBPCompIPH1.TabIndex = 21;
            lblBPCompIPH1.Text = "BP ISK per Hour:";
            // 
            // lblBPTotalItemPT
            // 
            lblBPTotalItemPT.BorderStyle = BorderStyle.FixedSingle;
            lblBPTotalItemPT.Location = new Point(141, 25);
            lblBPTotalItemPT.Name = "lblBPTotalItemPT";
            lblBPTotalItemPT.Size = new Size(132, 17);
            lblBPTotalItemPT.TabIndex = 3;
            lblBPTotalItemPT.Text = "00:00:00";
            lblBPTotalItemPT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPTotalCompCost
            // 
            lblBPTotalCompCost.BorderStyle = BorderStyle.FixedSingle;
            lblBPTotalCompCost.Location = new Point(5, 132);
            lblBPTotalCompCost.Name = "lblBPTotalCompCost";
            lblBPTotalCompCost.Size = new Size(132, 17);
            lblBPTotalCompCost.TabIndex = 14;
            lblBPTotalCompCost.Text = "0.00";
            lblBPTotalCompCost.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPCPTPT
            // 
            lblBPCPTPT.AutoSize = true;
            lblBPCPTPT.Location = new Point(138, 10);
            lblBPCPTPT.Name = "lblBPCPTPT";
            lblBPCPTPT.Size = new Size(114, 13);
            lblBPCPTPT.TabIndex = 2;
            lblBPCPTPT.Text = "Total Production Time:";
            // 
            // lblBPRawSVR
            // 
            lblBPRawSVR.BorderStyle = BorderStyle.FixedSingle;
            lblBPRawSVR.Location = new Point(232, 200);
            lblBPRawSVR.Name = "lblBPRawSVR";
            lblBPRawSVR.Size = new Size(41, 17);
            lblBPRawSVR.TabIndex = 28;
            lblBPRawSVR.Text = "0.00";
            lblBPRawSVR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPRawIPH1
            // 
            lblBPRawIPH1.AutoSize = true;
            lblBPRawIPH1.Location = new Point(138, 186);
            lblBPRawIPH1.Name = "lblBPRawIPH1";
            lblBPRawIPH1.Size = new Size(96, 13);
            lblBPRawIPH1.TabIndex = 25;
            lblBPRawIPH1.Text = "Raw ISK per Hour:";
            // 
            // lblBPRawProfit
            // 
            lblBPRawProfit.BorderStyle = BorderStyle.FixedSingle;
            lblBPRawProfit.Location = new Point(141, 166);
            lblBPRawProfit.Name = "lblBPRawProfit";
            lblBPRawProfit.Size = new Size(132, 17);
            lblBPRawProfit.TabIndex = 20;
            lblBPRawProfit.Text = "0.00";
            lblBPRawProfit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPBPSVR
            // 
            lblBPBPSVR.BorderStyle = BorderStyle.FixedSingle;
            lblBPBPSVR.Location = new Point(97, 200);
            lblBPBPSVR.Name = "lblBPBPSVR";
            lblBPBPSVR.Size = new Size(40, 17);
            lblBPBPSVR.TabIndex = 24;
            lblBPBPSVR.Text = "0.00";
            lblBPBPSVR.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPCompProfit1
            // 
            lblBPCompProfit1.AutoSize = true;
            lblBPCompProfit1.Location = new Point(3, 152);
            lblBPCompProfit1.Name = "lblBPCompProfit1";
            lblBPCompProfit1.Size = new Size(91, 13);
            lblBPCompProfit1.TabIndex = 17;
            lblBPCompProfit1.Text = "Component Profit:";
            // 
            // lblBPRawProfit1
            // 
            lblBPRawProfit1.AutoSize = true;
            lblBPRawProfit1.Location = new Point(138, 152);
            lblBPRawProfit1.Name = "lblBPRawProfit1";
            lblBPRawProfit1.Size = new Size(59, 13);
            lblBPRawProfit1.TabIndex = 19;
            lblBPRawProfit1.Text = "Raw Profit:";
            // 
            // lblBPBPSVR1
            // 
            lblBPBPSVR1.Font = new Font("Microsoft Sans Serif", 8.25f);
            lblBPBPSVR1.Location = new Point(101, 186);
            lblBPBPSVR1.Name = "lblBPBPSVR1";
            lblBPBPSVR1.Size = new Size(32, 13);
            lblBPBPSVR1.TabIndex = 23;
            lblBPBPSVR1.Text = "SVR";
            lblBPBPSVR1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPRawSVR1
            // 
            lblBPRawSVR1.Location = new Point(236, 186);
            lblBPRawSVR1.Name = "lblBPRawSVR1";
            lblBPRawSVR1.Size = new Size(32, 13);
            lblBPRawSVR1.TabIndex = 27;
            lblBPRawSVR1.Text = "SVR";
            lblBPRawSVR1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkBPPricePerUnit
            // 
            chkBPPricePerUnit.AutoSize = true;
            chkBPPricePerUnit.Location = new Point(225, 44);
            chkBPPricePerUnit.Name = "chkBPPricePerUnit";
            chkBPPricePerUnit.Size = new Size(48, 17);
            chkBPPricePerUnit.TabIndex = 8;
            chkBPPricePerUnit.Text = "PPU";
            chkBPPricePerUnit.UseVisualStyleBackColor = true;
            // 
            // lblBPBuyColor
            // 
            lblBPBuyColor.BackColor = Color.DarkSeaGreen;
            lblBPBuyColor.BorderStyle = BorderStyle.FixedSingle;
            lblBPBuyColor.Location = new Point(69, 238);
            lblBPBuyColor.Name = "lblBPBuyColor";
            lblBPBuyColor.Size = new Size(59, 16);
            lblBPBuyColor.TabIndex = 31;
            lblBPBuyColor.Text = "Buy Item";
            lblBPBuyColor.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBPBuildColor
            // 
            lblBPBuildColor.BackColor = Color.Gold;
            lblBPBuildColor.BorderStyle = BorderStyle.FixedSingle;
            lblBPBuildColor.Location = new Point(9, 238);
            lblBPBuildColor.Name = "lblBPBuildColor";
            lblBPBuildColor.Size = new Size(59, 16);
            lblBPBuildColor.TabIndex = 30;
            lblBPBuildColor.Text = "Build Item";
            lblBPBuildColor.TextAlign = ContentAlignment.TopCenter;
            // 
            // gbBPShopandCopy
            // 
            gbBPShopandCopy.Controls.Add(chkBPSimpleCopy);
            gbBPShopandCopy.Controls.Add(rbtnBPCopyInvREMats);
            gbBPShopandCopy.Controls.Add(rbtnBPComponentCopy);
            gbBPShopandCopy.Controls.Add(rbtnBPRawmatCopy);
            gbBPShopandCopy.Controls.Add(btnBPCopyMatstoClip);
            gbBPShopandCopy.Controls.Add(btnBPAddBPMatstoShoppingList);
            gbBPShopandCopy.Controls.Add(lblBPSimpleCopy);
            gbBPShopandCopy.Location = new Point(4, 174);
            gbBPShopandCopy.Name = "gbBPShopandCopy";
            gbBPShopandCopy.Size = new Size(294, 58);
            gbBPShopandCopy.TabIndex = 3;
            gbBPShopandCopy.TabStop = false;
            // 
            // chkBPSimpleCopy
            // 
            chkBPSimpleCopy.AutoSize = true;
            chkBPSimpleCopy.Location = new Point(176, 37);
            chkBPSimpleCopy.Name = "chkBPSimpleCopy";
            chkBPSimpleCopy.Size = new Size(15, 14);
            chkBPSimpleCopy.TabIndex = 6;
            chkBPSimpleCopy.TextAlign = ContentAlignment.TopLeft;
            chkBPSimpleCopy.UseVisualStyleBackColor = true;
            // 
            // rbtnBPCopyInvREMats
            // 
            rbtnBPCopyInvREMats.AutoSize = true;
            rbtnBPCopyInvREMats.Location = new Point(201, 38);
            rbtnBPCopyInvREMats.Name = "rbtnBPCopyInvREMats";
            rbtnBPCopyInvREMats.Size = new Size(89, 17);
            rbtnBPCopyInvREMats.TabIndex = 4;
            rbtnBPCopyInvREMats.TabStop = true;
            rbtnBPCopyInvREMats.Text = "Invention/RE";
            rbtnBPCopyInvREMats.UseVisualStyleBackColor = true;
            // 
            // rbtnBPComponentCopy
            // 
            rbtnBPComponentCopy.AutoSize = true;
            rbtnBPComponentCopy.Checked = true;
            rbtnBPComponentCopy.Location = new Point(201, 8);
            rbtnBPComponentCopy.Name = "rbtnBPComponentCopy";
            rbtnBPComponentCopy.Size = new Size(84, 17);
            rbtnBPComponentCopy.TabIndex = 2;
            rbtnBPComponentCopy.TabStop = true;
            rbtnBPComponentCopy.Text = "Components";
            rbtnBPComponentCopy.UseVisualStyleBackColor = true;
            // 
            // rbtnBPRawmatCopy
            // 
            rbtnBPRawmatCopy.AutoSize = true;
            rbtnBPRawmatCopy.Location = new Point(201, 23);
            rbtnBPRawmatCopy.Name = "rbtnBPRawmatCopy";
            rbtnBPRawmatCopy.Size = new Size(92, 17);
            rbtnBPRawmatCopy.TabIndex = 3;
            rbtnBPRawmatCopy.TabStop = true;
            rbtnBPRawmatCopy.Text = "Raw Materials";
            rbtnBPRawmatCopy.UseVisualStyleBackColor = true;
            // 
            // btnBPCopyMatstoClip
            // 
            btnBPCopyMatstoClip.Location = new Point(85, 12);
            btnBPCopyMatstoClip.Name = "btnBPCopyMatstoClip";
            btnBPCopyMatstoClip.Size = new Size(79, 39);
            btnBPCopyMatstoClip.TabIndex = 1;
            btnBPCopyMatstoClip.Text = "Copy to Clipboard";
            btnBPCopyMatstoClip.UseVisualStyleBackColor = true;
            // 
            // btnBPAddBPMatstoShoppingList
            // 
            btnBPAddBPMatstoShoppingList.Location = new Point(5, 12);
            btnBPAddBPMatstoShoppingList.Name = "btnBPAddBPMatstoShoppingList";
            btnBPAddBPMatstoShoppingList.Size = new Size(79, 39);
            btnBPAddBPMatstoShoppingList.TabIndex = 0;
            btnBPAddBPMatstoShoppingList.Text = "Add to Shopping List";
            btnBPAddBPMatstoShoppingList.UseVisualStyleBackColor = true;
            // 
            // lblBPSimpleCopy
            // 
            lblBPSimpleCopy.Location = new Point(164, 9);
            lblBPSimpleCopy.Name = "lblBPSimpleCopy";
            lblBPSimpleCopy.Size = new Size(39, 28);
            lblBPSimpleCopy.TabIndex = 18;
            lblBPSimpleCopy.Text = "Simple Copy";
            lblBPSimpleCopy.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBPCanMakeBPAll
            // 
            lblBPCanMakeBPAll.ForeColor = Color.Red;
            lblBPCanMakeBPAll.Location = new Point(723, 591);
            lblBPCanMakeBPAll.Name = "lblBPCanMakeBPAll";
            lblBPCanMakeBPAll.Size = new Size(205, 16);
            lblBPCanMakeBPAll.TabIndex = 27;
            lblBPCanMakeBPAll.Text = "Cannot Make All Components for this Item";
            lblBPCanMakeBPAll.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPRawMatCost
            // 
            lblBPRawMatCost.BorderStyle = BorderStyle.FixedSingle;
            lblBPRawMatCost.Location = new Point(1013, 591);
            lblBPRawMatCost.Name = "lblBPRawMatCost";
            lblBPRawMatCost.Size = new Size(118, 16);
            lblBPRawMatCost.TabIndex = 24;
            lblBPRawMatCost.Text = "0.00";
            lblBPRawMatCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBPRawMatCost1
            // 
            lblBPRawMatCost1.AutoSize = true;
            lblBPRawMatCost1.Location = new Point(934, 593);
            lblBPRawMatCost1.Name = "lblBPRawMatCost1";
            lblBPRawMatCost1.Size = new Size(77, 13);
            lblBPRawMatCost1.TabIndex = 23;
            lblBPRawMatCost1.Text = "Raw Mat Cost:";
            lblBPRawMatCost1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBPCanMakeBP
            // 
            lblBPCanMakeBP.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBPCanMakeBP.ForeColor = Color.Red;
            lblBPCanMakeBP.Location = new Point(217, 589);
            lblBPCanMakeBP.Name = "lblBPCanMakeBP";
            lblBPCanMakeBP.Size = new Size(115, 21);
            lblBPCanMakeBP.TabIndex = 13;
            lblBPCanMakeBP.Text = "Cannot Make this Item";
            lblBPCanMakeBP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPRawMats
            // 
            lblBPRawMats.Location = new Point(569, 235);
            lblBPRawMats.Name = "lblBPRawMats";
            lblBPRawMats.Size = new Size(562, 20);
            lblBPRawMats.TabIndex = 14;
            lblBPRawMats.Text = "Raw Material List";
            lblBPRawMats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPComponentMatCost
            // 
            lblBPComponentMatCost.BorderStyle = BorderStyle.FixedSingle;
            lblBPComponentMatCost.Location = new Point(448, 591);
            lblBPComponentMatCost.Name = "lblBPComponentMatCost";
            lblBPComponentMatCost.Size = new Size(118, 16);
            lblBPComponentMatCost.TabIndex = 26;
            lblBPComponentMatCost.Text = "0.00";
            lblBPComponentMatCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBPComponentMats
            // 
            lblBPComponentMats.Location = new Point(4, 235);
            lblBPComponentMats.Name = "lblBPComponentMats";
            lblBPComponentMats.Size = new Size(562, 20);
            lblBPComponentMats.TabIndex = 13;
            lblBPComponentMats.Text = "Component Material List";
            lblBPComponentMats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPComponentMatCost1
            // 
            lblBPComponentMatCost1.AutoSize = true;
            lblBPComponentMatCost1.Location = new Point(338, 593);
            lblBPComponentMatCost1.Name = "lblBPComponentMatCost1";
            lblBPComponentMatCost1.Size = new Size(109, 13);
            lblBPComponentMatCost1.TabIndex = 25;
            lblBPComponentMatCost1.Text = "Component Mat Cost:";
            lblBPComponentMatCost1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lstBPComponentMats
            // 
            lstBPComponentMats.BackColor = SystemColors.Window;
            lstBPComponentMats.CheckBoxes = true;
            lstBPComponentMats.FullRowSelect = true;
            lstBPComponentMats.GridLines = true;
            lstBPComponentMats.HideSelection = false;
            lstBPComponentMats.Location = new Point(4, 258);
            lstBPComponentMats.MultiSelect = false;
            lstBPComponentMats.Name = "lstBPComponentMats";
            lstBPComponentMats.Size = new Size(561, 329);
            lstBPComponentMats.TabIndex = 35;
            lstBPComponentMats.TabStop = false;
            lstBPComponentMats.UseCompatibleStateImageBehavior = false;
            lstBPComponentMats.View = View.Details;
            // 
            // lstBPRawMats
            // 
            lstBPRawMats.BackColor = SystemColors.Window;
            lstBPRawMats.FullRowSelect = true;
            lstBPRawMats.GridLines = true;
            lstBPRawMats.HideSelection = false;
            lstBPRawMats.Location = new Point(570, 258);
            lstBPRawMats.MultiSelect = false;
            lstBPRawMats.Name = "lstBPRawMats";
            lstBPRawMats.Size = new Size(561, 329);
            lstBPRawMats.TabIndex = 34;
            lstBPRawMats.TabStop = false;
            lstBPRawMats.UseCompatibleStateImageBehavior = false;
            lstBPRawMats.View = View.Details;
            // 
            // lstBPBuiltComponents
            // 
            lstBPBuiltComponents.FullRowSelect = true;
            lstBPBuiltComponents.GridLines = true;
            lstBPBuiltComponents.HideSelection = false;
            lstBPBuiltComponents.Location = new Point(4, 258);
            lstBPBuiltComponents.MultiSelect = false;
            lstBPBuiltComponents.Name = "lstBPBuiltComponents";
            lstBPBuiltComponents.Size = new Size(561, 329);
            lstBPBuiltComponents.TabIndex = 77;
            lstBPBuiltComponents.TabStop = false;
            lstBPBuiltComponents.UseCompatibleStateImageBehavior = false;
            lstBPBuiltComponents.View = View.Details;
            lstBPBuiltComponents.Visible = false;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabBlueprints);
            tabMain.Controls.Add(tabUpdatePrices);
            tabMain.Controls.Add(tabManufacturing);
            tabMain.Controls.Add(tabDatacores);
            tabMain.Controls.Add(tabMining);
            tabMain.Controls.Add(tabPI);
            tabMain.DataBindings.Add(new Binding("Font", My.MySettings.Default, "MyDefault", true, DataSourceUpdateMode.OnPropertyChanged));
            tabMain.Font = My.MySettings.Default.MyDefault;
            tabMain.Location = new Point(2, 26);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1145, 641);
            tabMain.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1149, 691);
            Controls.Add(cmbEdit);
            Controls.Add(txtListEdit);
            Controls.Add(tabMain);
            Controls.Add(pnlMain);
            Controls.Add(mnuStripMain);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnuStripMain;
            MaximizeBox = false;
            Name = "frmMain";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EVE ISK per Hour";
            mnuStripMain.ResumeLayout(false);
            mnuStripMain.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ListOptionsMenu.ResumeLayout(false);
            tabPI.ResumeLayout(false);
            gbPIPlanets.ResumeLayout(false);
            gbPIPlanets.PerformLayout();
            tabMining.ResumeLayout(false);
            tabMining.PerformLayout();
            gbMineCrystalType.ResumeLayout(false);
            gbMineCrystalType.PerformLayout();
            tabMiningDrones.ResumeLayout(false);
            tabShipDrones.ResumeLayout(false);
            tabShipDrones.PerformLayout();
            tabBoosterDrones.ResumeLayout(false);
            tabBoosterDrones.PerformLayout();
            gbMineCrystals.ResumeLayout(false);
            gbMineCrystals.PerformLayout();
            gbMineNumberMiners.ResumeLayout(false);
            gbMineNumberMiners.PerformLayout();
            gbMineOreProcessingType.ResumeLayout(false);
            gbMineOreProcessingType.PerformLayout();
            gbMineTaxBroker.ResumeLayout(false);
            gbMineTaxBroker.PerformLayout();
            gbMineStripStats.ResumeLayout(false);
            gbMineStripStats.PerformLayout();
            gbMineHauling.ResumeLayout(false);
            gbMineHauling.PerformLayout();
            gbMineBooster.ResumeLayout(false);
            gbMineBooster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictMineLaserOptmize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineRangeLink).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictMineFleetBoostShip).EndInit();
            gbMineRefining.ResumeLayout(false);
            gbMineRefining.PerformLayout();
            gbMineOreStuctureRates.ResumeLayout(false);
            gbMineOreStuctureRates.PerformLayout();
            tabMiningProcessingSkills.ResumeLayout(false);
            tabPageOres.ResumeLayout(false);
            tabPageOres.PerformLayout();
            tabPageMoonOres.ResumeLayout(false);
            tabPageMoonOres.PerformLayout();
            tabPageIce.ResumeLayout(false);
            tabPageIce.PerformLayout();
            gbMineShipSetup.ResumeLayout(false);
            gbMineSelectShip.ResumeLayout(false);
            gbMineSelectShip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictMineSelectedShip).EndInit();
            gbMineShipEquipment.ResumeLayout(false);
            gbMineShipEquipment.PerformLayout();
            gbMiningRigs.ResumeLayout(false);
            gbMineSkills.ResumeLayout(false);
            gbMineSkills.PerformLayout();
            gbMineMain.ResumeLayout(false);
            gbMineMain.PerformLayout();
            gbMineIncludeOres.ResumeLayout(false);
            gbMineIncludeOres.PerformLayout();
            gbMineOreLocSov.ResumeLayout(false);
            gbMineOreLocSov.PerformLayout();
            gbMineWHSpace.ResumeLayout(false);
            gbMineWHSpace.PerformLayout();
            tabDatacores.ResumeLayout(false);
            gbDCOptions.ResumeLayout(false);
            gbDCAgentLocSov.ResumeLayout(false);
            gbDCAgentLocSov.PerformLayout();
            gbDCTotalIPH.ResumeLayout(false);
            gbDCTotalIPH.PerformLayout();
            gbDCPrices.ResumeLayout(false);
            gbDCPrices.PerformLayout();
            gbDCAgentTypes.ResumeLayout(false);
            gbDCAgentTypes.PerformLayout();
            gbDCBaseSkills.ResumeLayout(false);
            gbDCBaseSkills.PerformLayout();
            gbDCDatacores.ResumeLayout(false);
            gbDCDatacores.PerformLayout();
            gbDCCodes.ResumeLayout(false);
            gbDCCodes.PerformLayout();
            gbDCCorpMinmatar.ResumeLayout(false);
            gbDCCorpMinmatar.PerformLayout();
            gbDCCorpAmarr.ResumeLayout(false);
            gbDCCorpAmarr.PerformLayout();
            gbDCCorpsCaldari.ResumeLayout(false);
            gbDCCorpsCaldari.PerformLayout();
            gbDCCorpsGallente.ResumeLayout(false);
            gbDCCorpsGallente.PerformLayout();
            tabManufacturing.ResumeLayout(false);
            gbCalcBPSelectOptions.ResumeLayout(false);
            gbCalcBPSelectOptions.PerformLayout();
            gbCalcIgnoreinCalcs.ResumeLayout(false);
            gbCalcIgnoreinCalcs.PerformLayout();
            gbIncludeTaxesFees.ResumeLayout(false);
            gbIncludeTaxesFees.PerformLayout();
            gbCalcSellExessItems.ResumeLayout(false);
            gbCalcSellExessItems.PerformLayout();
            gbCalcIncludeItems.ResumeLayout(false);
            gbCalcIncludeItems.PerformLayout();
            gbCalcMarketFilters.ResumeLayout(false);
            gbCalcMarketFilters.PerformLayout();
            gbCalcSizeLimit.ResumeLayout(false);
            gbCalcSizeLimit.PerformLayout();
            gbCalcProdLines.ResumeLayout(false);
            gbCalcProdLines.PerformLayout();
            gbCalcCompareType.ResumeLayout(false);
            gbCalcCompareType.PerformLayout();
            gbCalcTextColors.ResumeLayout(false);
            gbCalcTextColors.PerformLayout();
            gbCalcInvention.ResumeLayout(false);
            gbCalcInvention.PerformLayout();
            gbCalcBPRace.ResumeLayout(false);
            gbCalcBPRace.PerformLayout();
            gbTempMEPE.ResumeLayout(false);
            gbTempMEPE.PerformLayout();
            tabCalcFacilities.ResumeLayout(false);
            tabCalcFacilityBase.ResumeLayout(false);
            tabCalcFacilityComponents.ResumeLayout(false);
            tabCalcFacilityCopy.ResumeLayout(false);
            tabCalcFacilityT2Invention.ResumeLayout(false);
            tabCalcFacilityT3Invention.ResumeLayout(false);
            tabCalcFacilitySupers.ResumeLayout(false);
            tabCalcFacilityCapitals.ResumeLayout(false);
            tabCalcFacilityT3Ships.ResumeLayout(false);
            tabCalcFacilitySubsystems.ResumeLayout(false);
            tabCalcFacilityBoosters.ResumeLayout(false);
            tabCalcFacilityReactions.ResumeLayout(false);
            gbCalcFilter.ResumeLayout(false);
            gbCalcBPTech.ResumeLayout(false);
            gbCalcBPTech.PerformLayout();
            gbCalcIncludeOwned.ResumeLayout(false);
            gbCalcIncludeOwned.PerformLayout();
            gbCalcTextFilter.ResumeLayout(false);
            gbCalcTextFilter.PerformLayout();
            gbCalcBPType.ResumeLayout(false);
            gbCalcBPType.PerformLayout();
            gbCalcBPSelect.ResumeLayout(false);
            gbCalcBPSelect.PerformLayout();
            gbCalcRelics.ResumeLayout(false);
            gbCalcRelics.PerformLayout();
            tabUpdatePrices.ResumeLayout(false);
            tabUpdatePrices.PerformLayout();
            gbRawMaterials.ResumeLayout(false);
            gbRawMaterials.PerformLayout();
            gbReactionMaterials.ResumeLayout(false);
            gbReactionMaterials.PerformLayout();
            gbResearchEquipment.ResumeLayout(false);
            gbResearchEquipment.PerformLayout();
            gbSingleSource.ResumeLayout(false);
            gbMarketStructures.ResumeLayout(false);
            gbRegionSystemPrice.ResumeLayout(false);
            gbTradeHubSystems.ResumeLayout(false);
            gbTradeHubSystems.PerformLayout();
            gbPriceProfile.ResumeLayout(false);
            tabPriceProfile.ResumeLayout(false);
            tabPriceProfileRaw.ResumeLayout(false);
            tabPriceProfileManufactured.ResumeLayout(false);
            gbPPDefaultSettings.ResumeLayout(false);
            gbPPDefaultSettings.PerformLayout();
            gbPriceOptions.ResumeLayout(false);
            gbPriceOptions.PerformLayout();
            gbPriceTypes.ResumeLayout(false);
            gbPriceTypes.PerformLayout();
            gbDataSource.ResumeLayout(false);
            gbDataSource.PerformLayout();
            gbManufacturedItems.ResumeLayout(false);
            gbManufacturedItems.PerformLayout();
            gbComponents.ResumeLayout(false);
            gbComponents.PerformLayout();
            gbReprocessables.ResumeLayout(false);
            gbReprocessables.PerformLayout();
            gbItems.ResumeLayout(false);
            gbItems.PerformLayout();
            gbPricesTech.ResumeLayout(false);
            gbPricesTech.PerformLayout();
            tabBlueprints.ResumeLayout(false);
            tabBlueprints.PerformLayout();
            gbBPMEPEImage.ResumeLayout(false);
            gbBPMEPEImage.PerformLayout();
            gbBPSellExcess.ResumeLayout(false);
            tabBPInventionEquip.ResumeLayout(false);
            tabFacility.ResumeLayout(false);
            tabT3Calcs.ResumeLayout(false);
            tabT3Calcs.PerformLayout();
            tabInventionCalcs.ResumeLayout(false);
            tabInventionCalcs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictBP).EndInit();
            gbBPManualSystemCostIndex.ResumeLayout(false);
            gbBPManualSystemCostIndex.PerformLayout();
            gbBPIgnoreinCalcs.ResumeLayout(false);
            gbBPIgnoreinCalcs.PerformLayout();
            gbBPBlueprintType.ResumeLayout(false);
            gbBPBlueprintType.PerformLayout();
            gbBPBlueprintTech.ResumeLayout(false);
            gbBPBlueprintTech.PerformLayout();
            gbFilters.ResumeLayout(false);
            gbFilters.PerformLayout();
            gbBPInventionStats.ResumeLayout(false);
            gbBPInventionStats.PerformLayout();
            gbBPShopandCopy.ResumeLayout(false);
            gbBPShopandCopy.PerformLayout();
            tabMain.ResumeLayout(false);
            FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
            Load += new EventHandler(frmMain_Load);
            Activated += new EventHandler(frmMain_Activated);
            ResumeLayout(false);
            PerformLayout();

        }
        internal MenuStrip mnuStripMain;
        internal ToolStripMenuItem mnuFile;
        internal ToolStripMenuItem mnuSelectionExit;
        internal ToolStripMenuItem mnuEdit;
        internal ToolStripMenuItem mnuSettings;
        internal ToolStripMenuItem mnuAbout;
        internal ToolStripMenuItem mnuSelectionAbout;
        internal StatusStrip pnlMain;
        internal ToolStripStatusLabel pnlStatus;
        internal ToolStripStatusLabel pnlShoppingList;
        internal ToolStripMenuItem mnuSelectDefaultChar;
        internal ToolStripMenuItem mnuItemUpdatePrices;
        internal ToolStripMenuItem mnuSelectionAddChar;
        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripMenuItem mnuManageBlueprintsToolStripMenuItem;
        internal ToolStripMenuItem mnuUserSettings;
        internal GroupBox gbSystems;
        private ToolTip _ttBP;

        internal virtual ToolTip ttBP
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ttBP;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ttBP = value;
            }
        }
        internal ToolStripProgressBar pnlProgressBar;
        internal ToolStripMenuItem mnuCheckforUpdates;
        internal ToolStripMenuItem ViewToolStripMenuItem;
        internal ToolStripMenuItem mnuSelectionShoppingList;
        internal ToolStripMenuItem mnuCharacterSkills;
        internal ToolStripMenuItem mnuCharacterStandings;
        internal ToolStripStatusLabel pnlSkills;
        internal ToolStripSeparator ToolStripSeparator2;
        internal ToolStripMenuItem mnuSelectionManageCharacters;
        internal ToolStripMenuItem SetPOSDataToolStripMenuItem;
        internal ToolStripMenuItem mnuRestoreDefaultTabSettings;
        internal ToolStripMenuItem mnuRestoreDefaultBP;
        internal ToolStripMenuItem mnuRestoreDefaultUpdatePrices;
        internal ToolStripMenuItem mnuRestoreDefaultManufacturing;
        internal ToolStripMenuItem mnuRestoreDefaultDatacores;
        internal ToolStripMenuItem mnuRestoreDefaultMining;
        internal ToolStripMenuItem mnuCurrentResearchAgents;
        internal OpenFileDialog OpenFileDialog;
        internal SaveFileDialog SaveFileDialog;
        internal TextBox txtListEdit;
        internal ToolStripMenuItem mnuPatchNotes;
        internal ToolStripMenuItem mnuTools;
        internal ToolStripMenuItem mnuCurrentIndustryJobs;
        internal ToolStripSeparator ToolStripSeparator5;
        internal ToolStripMenuItem mnuReprocessingPlant;
        internal ToolStripMenuItem mnuUpdateData;
        internal ToolStripMenuItem mnuUpdateIndustryFacilities;
        internal ToolStripMenuItem mnuUpdateESIMarketPrices;
        internal ToolStripSeparator ToolStripSeparator6;
        internal ToolStripMenuItem mnuResetData;
        internal ToolStripMenuItem mnuResetBlueprintData;
        internal ToolStripMenuItem mnuResetPriceData;
        internal ToolStripMenuItem mnuResetAgents;
        internal ToolStripMenuItem mnuResetIndustryJobs;
        internal ToolStripMenuItem mnuResetAssets;
        internal ToolStripSeparator ToolStripSeparator4;
        internal ToolStripMenuItem mnuResetAllData;
        internal ToolStripMenuItem mnuResetESIDates;
        internal ContextMenuStrip ListOptionsMenu;
        internal ToolStripMenuItem mnuResetESIMarketPrices;
        internal ToolStripMenuItem mnuResetESIIndustryFacilities;
        internal ToolStripMenuItem IgnoreBlueprintToolStripMenuItem;
        internal ToolStripMenuItem mnuResetIgnoredBPs;
        internal ToolStripDropDownButton mnuCharacter;
        internal ToolStripMenuItem tsCharacter1;
        internal ToolStripMenuItem tsCharacter2;
        internal ToolStripMenuItem tsCharacter3;
        internal ToolStripMenuItem tsCharacter4;
        internal ToolStripMenuItem tsCharacter5;
        internal ToolStripMenuItem tsCharacter6;
        internal ToolStripMenuItem tsCharacter7;
        internal ToolStripMenuItem tsCharacter8;
        internal ToolStripMenuItem tsCharacter9;
        internal ToolStripMenuItem tsCharacter10;
        internal ToolStripMenuItem tsCharacter11;
        internal ToolStripMenuItem tsCharacter12;
        internal ToolStripMenuItem tsCharacter13;
        internal ToolStripMenuItem tsCharacter14;
        internal ToolStripMenuItem tsCharacter15;
        internal ToolStripMenuItem tsCharacter16;
        internal ToolStripMenuItem tsCharacter17;
        internal ToolStripMenuItem tsCharacter18;
        internal ToolStripMenuItem tsCharacter19;
        internal ToolStripMenuItem tsCharacter20;
        internal ToolTip ttUpdatePrices;
        internal ToolTip ttManufacturing;
        internal ToolTip ttDatacores;
        internal ToolTip ttReactions;
        internal ToolTip ttMining;
        internal ToolTip ttPI;
        internal ToolStripMenuItem ViewMarketHistoryToolStripMenuItem;
        internal ImageList CalcImageList;
        internal ToolStripMenuItem AddToShoppingListToolStripMenuItem;
        internal ToolStripMenuItem mnuClearBPHistory;
        internal ComboBox cmbEdit;
        internal ToolStripMenuItem mnuResetMarketHistory;
        internal ToolStripMenuItem mnuResetMarketOrders;
        internal ToolStripMenuItem mnuViewAssets;
        internal ToolStripMenuItem mnuUpdateESIPublicStructures;
        internal ToolStripMenuItem mnuResetESIPublicStructures;
        internal ToolStripMenuItem mnuChangeDummyCharacterName;
        internal ToolStripSeparator ToolStripSeparator3;
        internal ToolStripMenuItem mnuViewESIStatus;
        internal TabPage tabPI;
        internal Button btnPISaveSettings;
        internal GroupBox gbPIPlanets;
        internal CheckBox chkPILava;
        internal CheckBox chkPIPlasma;
        internal CheckBox chkPIIce;
        internal CheckBox chkPIGas;
        internal CheckBox chkPIOcean;
        internal CheckBox chkPIBarren;
        internal CheckBox chkPIStorm;
        internal CheckBox chkPITemperate;
        internal Button btnPIReset;
        internal TabPage tabMining;
        internal GroupBox gbMineNumberMiners;
        internal TextBox txtMineNumberMiners;
        internal Label lblMineNumberMiners;
        internal GroupBox gbMineOreProcessingType;
        internal CheckBox chkMineUnrefinedOre;
        internal CheckBox chkMineRefinedOre;
        internal CheckBox chkMineCompressedOre;
        internal Button btnMineSaveAllSettings;
        internal GroupBox gbMineTaxBroker;
        internal CheckBox chkMineIncludeTaxes;
        internal CheckBox chkMineIncludeBrokerFees;
        internal GroupBox gbMineStripStats;
        internal Label lblMineRange;
        internal Label lblMineCycleTime1;
        internal Label lblMineRange1;
        internal Label lblMineCycleTime;
        internal CheckBox chkMineUseFleetBooster;
        internal Button btnMineReset;
        internal GroupBox gbMineHauling;
        internal TextBox txtMineHaulerM3;
        internal Label lblMineHaulerM3;
        internal Label lblMineRTSec;
        internal CheckBox chkMineUseHauler;
        internal Label lblMineRTMin;
        internal TextBox txtMineRTMin;
        internal TextBox txtMineRTSec;
        internal Label lblMineRoundTripTime;
        internal Button btnMineRefresh;
        internal GroupBox gbMineBooster;
        internal PictureBox pictMineLaserOptmize;
        internal PictureBox pictMineRangeLink;
        internal PictureBox pictMineFleetBoostShip;
        internal CheckBox chkMineForemanLaserRangeBoost;
        internal ComboBox cmbMineIndustReconfig;
        internal Label lblMineIndustrialReconfig;
        internal CheckBox chkMineIndyCoreDeployedMode;
        internal ComboBox cmbMineBoosterShipSkill;
        internal CheckBox chkMineForemanMindlink;
        internal ComboBox cmbMineBoosterShipName;
        internal ComboBox cmbMineMiningDirector;
        internal CheckBox chkMineForemanLaserOpBoost;
        internal Label lblMineMiningDirector;
        internal ComboBox cmbMineMiningForeman;
        internal Label lblMineFleetBoosterShip;
        internal Label lblMineMiningForeman;
        internal Label lblMineBoosterShipSkill;
        internal GroupBox gbMineRefining;
        internal ComboBox cmbMineRefining;
        internal Label lblMineRefining;
        internal ComboBox cmbMineRefineryEff;
        internal Label lblMineRefineryEfficiency;
        internal GroupBox gbMineShipSetup;
        internal GroupBox gbMineSelectShip;
        internal PictureBox pictMineSelectedShip;
        internal Label lblMineSelectShip;
        internal ComboBox cmbMineBaseShipSkill;
        internal ComboBox cmbMineAdvShipSkill;
        internal ComboBox cmbMineShipName;
        internal Label lblMineBaseShipSkill;
        internal Label lblMineExhumers;
        internal GroupBox gbMineShipEquipment;
        internal GroupBox gbMiningRigs;
        internal ComboBox cmbMineMiningLaser;
        internal Label lblMineMiningUpgrade;
        internal GroupBox gbMineCrystals;
        internal ComboBox cmbMineNumMiningUpgrades;
        internal ComboBox cmbMineNumLasers;
        internal ComboBox cmbMineMiningUpgrade;
        internal ComboBox cmbMineHighwallImplant;
        internal CheckBox chkMineMichiImplant;
        internal Label lblMineImplants;
        internal Label lblMineLaserNumber;
        internal Label lblMineNumMiningUpgrades;
        internal Label lblMineMinerTurret;
        internal GroupBox gbMineSkills;
        internal ComboBox cmbMineGasIceHarvesting;
        internal Label lblMineGasIceHarvesting;
        internal ComboBox cmbMineDeepCore;
        internal Label lblMineAstrogeology;
        internal ComboBox cmbMineSkill;
        internal Label lblMineSkill;
        internal ComboBox cmbMineAstrogeology;
        internal Label lblMineDeepCore;
        internal GroupBox gbMineMain;
        internal GroupBox gbMineIncludeOres;
        internal CheckBox chkMineIncludeHighSec;
        internal CheckBox chkMineIncludeNullSec;
        internal CheckBox chkMineIncludeLowSec;
        internal CheckBox chkMineIncludeHighYieldOre;
        internal Label lblMineType;
        internal ComboBox cmbMineOreType;
        internal GroupBox gbMineOreLocSov;
        internal CheckBox chkMineMoonMining;
        internal CheckBox chkMineWH;
        internal GroupBox gbMineWHSpace;
        internal CheckBox chkMineC6;
        internal CheckBox chkMineC2;
        internal CheckBox chkMineC4;
        internal CheckBox chkMineC1;
        internal CheckBox chkMineC5;
        internal CheckBox chkMineC3;
        internal CheckBox chkMineCaldari;
        internal CheckBox chkMineMinmatar;
        internal CheckBox chkMineGallente;
        internal CheckBox chkMineAmarr;
        internal ListView lstMineGrid;
        internal TabPage tabDatacores;
        internal ListView lstDC;
        internal GroupBox gbDCOptions;
        internal Button btnDCSaveSettings;
        internal GroupBox gbDCAgentLocSov;
        internal CheckBox chkDCThukkerSov;
        internal CheckBox chkDCKhanidSov;
        internal CheckBox chkDCMinmatarSov;
        internal CheckBox chkDCSyndicateSov;
        internal CheckBox chkDCGallenteSov;
        internal CheckBox chkDCAmarrSov;
        internal CheckBox chkDCAmmatarSov;
        internal CheckBox chkDCCaldariSov;
        internal GroupBox gbDCTotalIPH;
        internal Label lblDCTotalOptIPH;
        internal Label lblDCTotalSelectedIPH;
        internal TextBox txtDCTotalSelectedIPH;
        internal TextBox txtDCTotalOptIPH;
        internal GroupBox gbDCPrices;
        internal RadioButton rbtnDCSystemPrices;
        internal RadioButton rbtnDCRegionPrices;
        internal RadioButton rbtnDCUpdatedPrices;
        internal GroupBox gbDCAgentTypes;
        internal ComboBox cmbDCRegions;
        internal Label lblDCRegion;
        internal CheckBox chkDCLowSecAgents;
        internal CheckBox chkDCHighSecAgents;
        internal CheckBox chkDCIncludeAllAgents;
        internal GroupBox gbDCBaseSkills;
        internal ComboBox cmbDCResearchMgmt;
        internal Label lblDCResearchManagement;
        internal Label lblDCNegotiation;
        internal ComboBox cmbDCConnections;
        internal Label lblDCConnections;
        internal ComboBox cmbDCNegotiation;
        internal GroupBox gbDCDatacores;
        internal ComboBox cmbDCSkillLevel17;
        internal ComboBox cmbDCSkillLevel16;
        internal ComboBox cmbDCSkillLevel15;
        internal ComboBox cmbDCSkillLevel14;
        internal ComboBox cmbDCSkillLevel13;
        internal ComboBox cmbDCSkillLevel12;
        internal ComboBox cmbDCSkillLevel11;
        internal ComboBox cmbDCSkillLevel10;
        internal ComboBox cmbDCSkillLevel9;
        internal ComboBox cmbDCSkillLevel8;
        internal ComboBox cmbDCSkillLevel7;
        internal ComboBox cmbDCSkillLevel6;
        internal ComboBox cmbDCSkillLevel5;
        internal ComboBox cmbDCSkillLevel4;
        internal ComboBox cmbDCSkillLevel3;
        internal ComboBox cmbDCSkillLevel2;
        internal ComboBox cmbDCSkillLevel1;
        internal CheckBox chkDC17;
        internal CheckBox chkDC4;
        internal CheckBox chkDC16;
        internal CheckBox chkDC3;
        internal Label lblDatacore17;
        internal CheckBox chkDC15;
        internal CheckBox chkDC2;
        internal CheckBox chkDC14;
        internal CheckBox chkDC1;
        internal CheckBox chkDC13;
        internal CheckBox chkDC12;
        internal CheckBox chkDC11;
        internal CheckBox chkDC10;
        internal Label lblDatacore16;
        internal Label lblDatacore4;
        internal Label lblDatacore15;
        internal CheckBox chkDC9;
        internal Label lblDatacore14;
        internal Label lblDatacore3;
        internal CheckBox chkDC8;
        internal Label lblDatacore13;
        internal Label lblDatacore2;
        internal CheckBox chkDC7;
        internal CheckBox chkDC6;
        internal Label lblDatacore1;
        internal CheckBox chkDC5;
        internal Label lblDatacore5;
        internal Label lblDatacore6;
        internal Label lblDatacore7;
        internal Label lblDatacore8;
        internal Label lblDatacore12;
        internal Label lblDatacore11;
        internal Label lblDatacore10;
        internal Label lblDatacore9;
        internal GroupBox gbDCCodes;
        internal Label lblDCColors;
        internal Label lblDCRedText;
        internal Label lblDCOrangeText;
        internal Label lblDCGrayText;
        internal Label lblDCBlueText;
        internal Label lblDCGreenBackColor;
        internal GroupBox gbDCCorpMinmatar;
        internal Label lblDCCorp13;
        internal CheckBox chkDCCorp13;
        internal TextBox txtDCStanding13;
        internal Label lblDCCorpLabel4;
        internal Label lblDCCorp10;
        internal Label lblDCCorp11;
        internal Label lblDCCorp12;
        internal CheckBox chkDCCorp10;
        internal CheckBox chkDCCorp11;
        internal CheckBox chkDCCorp12;
        internal TextBox txtDCStanding10;
        internal TextBox txtDCStanding11;
        internal TextBox txtDCStanding12;
        internal Label lblDCStanding4;
        internal Button btnDCExporttoClip;
        internal GroupBox gbDCCorpAmarr;
        internal Label lblDCCorpLabel1;
        internal Label lblDCCorp1;
        internal Label lblDCCorp2;
        internal Label lblDCCorp3;
        internal CheckBox chkDCCorp1;
        internal CheckBox chkDCCorp2;
        internal CheckBox chkDCCorp3;
        internal TextBox txtDCStanding1;
        internal TextBox txtDCStanding2;
        internal TextBox txtDCStanding3;
        internal Label lblDCStanding1;
        internal Button btnDCReset;
        internal GroupBox gbDCCorpsCaldari;
        internal Label lblDCCorpLabel2;
        internal Label lblDCCorp4;
        internal Label lblDCCorp5;
        internal Label lblDCCorp6;
        internal CheckBox chkDCCorp4;
        internal CheckBox chkDCCorp5;
        internal CheckBox chkDCCorp6;
        internal TextBox txtDCStanding4;
        internal TextBox txtDCStanding5;
        internal TextBox txtDCStanding6;
        internal Label lblDCStanding2;
        internal GroupBox gbDCCorpsGallente;
        internal Label lblDCCorpLabel3;
        internal Label lblDCCorp7;
        internal Label lblDCCorp8;
        internal Label lblDCCorp9;
        internal CheckBox chkDCCorp7;
        internal CheckBox chkDCCorp8;
        internal CheckBox chkDCCorp9;
        internal TextBox txtDCStanding7;
        internal TextBox txtDCStanding8;
        internal TextBox txtDCStanding9;
        internal Label lblDCStanding3;
        internal Button btnDCRefresh;
        internal TabPage tabManufacturing;
        internal ManufacturingListView lstManufacturing;
        internal GroupBox gbCalcBPSelectOptions;
        internal GroupBox gbCalcSellExessItems;
        internal CheckBox chkCalcSellExessItems;
        internal CheckBox chkCalcNPCBPOs;
        internal Button btnCalcShowAssets;
        internal GroupBox gbCalcIncludeItems;
        internal CheckBox chkCalcCanInvent;
        internal CheckBox chkCalcCanBuild;
        internal GroupBox gbCalcMarketFilters;
        internal TextBox txtCalcProfitThreshold;
        internal TimePicker tpMaxBuildTimeFilter;
        internal TextBox txtCalcSVRThreshold;
        internal TimePicker tpMinBuildTimeFilter;
        internal CheckBox chkCalcMaxBuildTimeFilter;
        internal CheckBox chkCalcMinBuildTimeFilter;
        internal ComboBox cmbCalcPriceTrend;
        internal ComboBox cmbCalcAvgPriceDuration;
        internal Label lblCalcPriceTrend;
        internal TextBox txtCalcVolumeThreshold;
        internal ComboBox cmbCalcHistoryRegion;
        internal Label lblCalcHistoryRegion;
        internal Label lblCalcSVRThreshold;
        internal Label lblCalcAvgPrice;
        internal TextBox txtCalcIPHThreshold;
        internal CheckBox chkCalcProfitThreshold;
        internal CheckBox chkCalcVolumeThreshold;
        internal CheckBox chkCalcSVRIncludeNull;
        internal CheckBox chkCalcIPHThreshold;
        internal Button btnCalcCalculate;
        internal GroupBox gbCalcIgnoreinCalcs;
        internal CheckBox chkCalcIgnoreMinerals;
        internal CheckBox chkCalcIgnoreT1Item;
        internal CheckBox chkCalcIgnoreInvention;
        internal GroupBox gbIncludeTaxesFees;
        internal CheckBox chkCalcFees;
        internal CheckBox chkCalcTaxes;
        internal Button btnCalcSelectColumns;
        internal GroupBox gbCalcSizeLimit;
        internal CheckBox chkCalcXL;
        internal CheckBox chkCalcLarge;
        internal CheckBox chkCalcMedium;
        internal CheckBox chkCalcSmall;
        internal GroupBox gbCalcProdLines;
        internal CheckBox chkCalcAutoCalcT2NumBPs;
        internal Label lblCalcBPs;
        internal TextBox txtCalcNumBPs;
        internal TextBox txtCalcRuns;
        internal TextBox txtCalcLabLines;
        internal Label lblCalcRuns;
        internal Label lblCalcLabLines1;
        internal Label lblCalcProdLines1;
        internal TextBox txtCalcProdLines;
        internal GroupBox gbCalcCompareType;
        internal CheckBox chkCalcPPU;
        internal RadioButton rbtnCalcCompareBuildBuy;
        internal RadioButton rbtnCalcCompareRawMats;
        internal RadioButton rbtnCalcCompareComponents;
        internal RadioButton rbtnCalcCompareAll;
        internal GroupBox gbCalcTextColors;
        internal Label lblCalcColorCode6;
        internal Label lblCalcText;
        internal Label lblCalcColorCode3;
        internal Label lblCalcColorCode4;
        internal Label lblCalcColorCode5;
        internal Label lblCalcColorCode2;
        internal Label lblCalcColorCode1;
        internal GroupBox gbCalcInvention;
        internal CheckBox chkCalcDecryptorforT3;
        internal CheckBox chkCalcDecryptorforT2;
        internal CheckBox chkCalcDecryptor0;
        internal CheckBox chkCalcDecryptor9;
        internal CheckBox chkCalcDecryptor8;
        internal CheckBox chkCalcDecryptor7;
        internal CheckBox chkCalcDecryptor6;
        internal CheckBox chkCalcDecryptor5;
        internal CheckBox chkCalcDecryptor4;
        internal CheckBox chkCalcDecryptor3;
        internal CheckBox chkCalcDecryptor2;
        internal CheckBox chkCalcDecryptor1;
        internal Label lblCalcDecryptorUse;
        internal GroupBox gbCalcBPRace;
        internal CheckBox chkCalcRaceOther;
        internal CheckBox chkCalcRacePirate;
        internal CheckBox chkCalcRaceMinmatar;
        internal CheckBox chkCalcRaceGallente;
        internal CheckBox chkCalcRaceCaldari;
        internal CheckBox chkCalcRaceAmarr;
        internal GroupBox gbTempMEPE;
        internal TextBox txtCalcTempTE;
        internal Label lblTempPE;
        internal TextBox txtCalcTempME;
        internal Label lblTempME;
        internal TabControl tabCalcFacilities;
        internal TabPage tabCalcFacilityBase;
        internal ManufacturingFacility CalcBaseFacility;
        internal TabPage tabCalcFacilityComponents;
        internal ManufacturingFacility CalcComponentsFacility;
        internal TabPage tabCalcFacilityCopy;
        internal ManufacturingFacility CalcCopyFacility;
        internal TabPage tabCalcFacilityT2Invention;
        internal ManufacturingFacility CalcInventionFacility;
        internal TabPage tabCalcFacilityT3Invention;
        internal ManufacturingFacility CalcT3InventionFacility;
        internal TabPage tabCalcFacilitySupers;
        internal ManufacturingFacility CalcSupersFacility;
        internal TabPage tabCalcFacilityCapitals;
        internal ManufacturingFacility CalcCapitalsFacility;
        internal TabPage tabCalcFacilityT3Ships;
        internal ManufacturingFacility CalcT3ShipsFacility;
        internal TabPage tabCalcFacilitySubsystems;
        internal ManufacturingFacility CalcSubsystemsFacility;
        internal TabPage tabCalcFacilityBoosters;
        internal ManufacturingFacility CalcBoostersFacility;
        internal TabPage tabCalcFacilityReactions;
        internal ManufacturingFacility CalcReactionsFacility;
        internal GroupBox gbCalcFilter;
        internal ComboBox cmbCalcBPTypeFilter;
        internal GroupBox gbCalcBPTech;
        internal CheckBox chkCalcPirateFaction;
        internal CheckBox chkCalcStoryline;
        internal CheckBox chkCalcNavyFaction;
        internal CheckBox chkCalcT3;
        internal CheckBox chkCalcT2;
        internal CheckBox chkCalcT1;
        internal GroupBox gbCalcIncludeOwned;
        internal CheckBox chkCalcIncludeT3Owned;
        internal CheckBox chkCalcIncludeT2Owned;
        internal Button btnCalcSaveSettings;
        internal Button btnCalcExportList;
        internal Button btnCalcPreview;
        internal Button btnCalcReset;
        internal GroupBox gbCalcTextFilter;
        internal Button btnCalcResetTextSearch;
        internal TextBox txtCalcItemFilter;
        internal GroupBox gbCalcBPType;
        internal CheckBox chkCalcReactions;
        internal CheckBox chkCalcCelestials;
        internal CheckBox chkCalcMisc;
        internal CheckBox chkCalcSubsystems;
        internal CheckBox chkCalcDeployables;
        internal CheckBox chkCalcStructures;
        internal CheckBox chkCalcStructureRigs;
        internal CheckBox chkCalcBoosters;
        internal CheckBox chkCalcRigs;
        internal CheckBox chkCalcComponents;
        internal CheckBox chkCalcAmmo;
        internal CheckBox chkCalcDrones;
        internal CheckBox chkCalcModules;
        internal CheckBox chkCalcShips;
        internal CheckBox chkCalcStructureModules;
        internal GroupBox gbCalcBPSelect;
        internal RadioButton rbtnCalcBPFavorites;
        internal RadioButton rbtnCalcAllBPs;
        internal RadioButton rbtnCalcBPOwned;
        internal GroupBox gbCalcRelics;
        internal CheckBox chkCalcRERelic2;
        internal CheckBox chkCalcRERelic3;
        internal CheckBox chkCalcRERelic1;
        internal TabPage tabUpdatePrices;
        internal Button btnLoadPricesfromFile;
        internal Button btnSavePricestoFile;
        internal MyListView lstPricesView;
        internal TextBox txtPriceItemFilter;
        internal GroupBox gbPriceOptions;
        internal TextBox txtItemsPriceModifier;
        internal TextBox txtRawPriceModifier;
        internal GroupBox gbPriceTypes;
        internal RadioButton rbtnPriceSettingPriceProfile;
        internal RadioButton rbtnPriceSettingSingleSelect;
        internal Label lblItemsPriceModifier;
        internal Label lblRawPriceModifier;
        internal GroupBox gbDataSource;
        internal RadioButton rbtnPriceSourceCCPData;
        internal RadioButton rbtnPriceSourceEM;
        internal ComboBox cmbItemsSplitPrices;
        internal ComboBox cmbRawMatsSplitPrices;
        internal Label lblItemsSplitPrices;
        internal Label lblRawMatsSplitPrices;
        internal Button btnSaveUpdatePrices;
        internal Button btnCancelUpdate;
        internal Button btnClearItemFilter;
        internal Button btnToggleAllPriceItems;
        internal Button btnDownloadPrices;
        internal Label lblItemFilter;
        internal GroupBox gbManufacturedItems;
        internal CheckBox chkPriceManufacturedPrices;
        internal CheckBox chkImplants;
        internal CheckBox chkUpdatePricesNoPrice;
        internal CheckBox chkFuelBlocks;
        internal CheckBox chkRAM;
        internal GroupBox gbComponents;
        internal CheckBox chkStructureComponents;
        internal CheckBox chkSubsystemComponents;
        internal CheckBox chkComponents;
        internal CheckBox chkCapitalShipComponents;
        internal CheckBox chkCapT2Components;
        internal GroupBox gbItems;
        internal CheckBox chkStructureModules;
        internal CheckBox chkCelestials;
        internal CheckBox chkDeployables;
        internal ComboBox cmbPriceChargeTypes;
        internal CheckBox chkStructures;
        internal CheckBox chkStructureRigs;
        internal CheckBox chkCharges;
        internal CheckBox chkBoosters;
        internal ComboBox cmbPriceShipTypes;
        internal GroupBox gbPricesTech;
        internal CheckBox chkPricesT4;
        internal CheckBox chkPricesT6;
        internal CheckBox chkPricesT5;
        internal CheckBox chkPricesT3;
        internal CheckBox chkPricesT2;
        internal CheckBox chkPricesT1;
        internal CheckBox chkSubsystems;
        internal CheckBox chkShips;
        internal CheckBox chkModules;
        internal CheckBox chkRigs;
        internal CheckBox chkDrones;
        internal GroupBox gbRawMaterials;
        internal CheckBox chkBPCs;
        internal CheckBox chkMisc;
        internal CheckBox chkRawMaterials;
        internal CheckBox chkPriceMaterialResearchEqPrices;
        internal CheckBox chkPlanetary;
        internal CheckBox chkBoosterMats;
        internal CheckBox chkFactionMaterials;
        internal CheckBox chkAdvancedMats;
        internal CheckBox chkProcessedMats;
        internal CheckBox chkRawMoonMats;
        internal CheckBox chkGas;
        internal CheckBox chkPolymers;
        internal CheckBox chkAncientRelics;
        internal CheckBox chkSalvage;
        internal CheckBox chkDecryptors;
        internal CheckBox chkDatacores;
        internal CheckBox chkIceProducts;
        internal CheckBox chkMinerals;
        internal GroupBox gbTradeHubSystems;
        internal ComboBox cmbPriceSystems;
        internal CheckBox chkSystems2;
        internal CheckBox chkSystems4;
        internal CheckBox chkSystems5;
        internal CheckBox chkSystems3;
        private CheckBox _chkSystems1;

        public virtual CheckBox chkSystems1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSystems1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSystems1 != null)
                {
                    _chkSystems1.CheckedChanged -= chkSystems1_CheckedChanged;
                }

                _chkSystems1 = value;
                if (_chkSystems1 != null)
                {
                    _chkSystems1.CheckedChanged += chkSystems1_CheckedChanged;
                }
            }
        }
        internal Button btnViewSavedStructures;
        internal Button btnAddStructureIDs;
        internal TabPage tabBlueprints;
        internal RadioButton rbtnBPRawT2MatType;
        private RadioButton rbtnBPProcT2MatType;
        internal RadioButton rbtnBPAdvT2MatType;
        internal Label lblBPT2MatTypeSelector;
        internal ListBox lstBPList;
        internal GroupBox gbBPBlueprintType;
        internal CheckBox chkBPNPCBPOs;
        internal RadioButton rbtnBPReactionsBlueprints;
        internal RadioButton rbtnBPStructureModulesBlueprints;
        internal RadioButton rbtnBPCelestialsBlueprints;
        internal RadioButton rbtnBPMiscBlueprints;
        internal RadioButton rbtnBPStructureBlueprints;
        internal RadioButton rbtnBPFavoriteBlueprints;
        internal RadioButton rbtnBPStructureRigsBlueprints;
        internal RadioButton rbtnBPOwnedBlueprints;
        internal RadioButton rbtnBPRigBlueprints;
        internal RadioButton rbtnBPBoosterBlueprints;
        internal RadioButton rbtnBPSubsystemBlueprints;
        internal RadioButton rbtnBPModuleBlueprints;
        internal RadioButton rbtnBPAmmoChargeBlueprints;
        internal RadioButton rbtnBPDroneBlueprints;
        internal RadioButton rbtnBPComponentBlueprints;
        internal RadioButton rbtnBPAllBlueprints;
        internal RadioButton rbtnBPShipBlueprints;
        internal RadioButton rbtnBPDeployableBlueprints;
        internal GroupBox gbBPBlueprintTech;
        internal CheckBox chkBPPirateFaction;
        internal CheckBox chkBPStoryline;
        internal CheckBox chkBPNavyFaction;
        internal CheckBox chkBPT3;
        internal CheckBox chkBPT2;
        internal CheckBox chkBPT1;
        internal GroupBox gbFilters;
        internal CheckBox chkBPXL;
        internal CheckBox chkBPLarge;
        internal CheckBox chkBPMedium;
        internal CheckBox chkBPSmall;
        internal ComboBox cmbBPBlueprintSelection;
        internal Button btnBPListView;
        internal Button btnBPForward;
        internal Button btnBPBack;
        internal Label lblBPSelectBlueprint;
        internal GroupBox gbBPInventionStats;
        internal TextBox txtBPMarketPriceEdit;
        internal Label lblBPProductionTime;
        internal Label lblBPTotalUnits;
        internal Label lblBPTaxes;
        internal Label lblBPTotalUnits1;
        internal Label lblBPBrokerFees;
        internal Label lblBPPT;
        internal CheckBox chkBPTaxes;
        internal Label lblBPMarketCost;
        internal Label lblBPMarketCost1;
        internal Label lblBPRawTotalCost;
        internal Label lblBPCompProfit;
        internal Label lblBPRawTotalCost1;
        internal CheckBox chkBPBrokerFees;
        internal Label lblBPCompIPH;
        internal Label lblBPRawIPH;
        internal Label lblBPTotalCompCost1;
        internal Label lblBPCompIPH1;
        internal Label lblBPTotalItemPT;
        internal Label lblBPTotalCompCost;
        internal Label lblBPCPTPT;
        internal Label lblBPRawSVR;
        internal Label lblBPRawIPH1;
        internal Label lblBPRawProfit;
        internal Label lblBPBPSVR;
        internal Label lblBPCompProfit1;
        internal Label lblBPRawProfit1;
        internal Label lblBPBPSVR1;
        internal Label lblBPRawSVR1;
        internal CheckBox chkBPPricePerUnit;
        internal Label lblBPBuyColor;
        internal Label lblBPBuildColor;
        internal GroupBox gbBPMEPEImage;
        internal GroupBox gbBPSellExcess;
        internal Button btnBPListMats;
        internal CheckBox chkBPSellExcessItems;
        internal Button btnBPSaveBP;
        internal TabControl tabBPInventionEquip;
        internal TabPage tabFacility;
        internal ManufacturingFacility BPTabFacility;
        internal TabPage tabT3Calcs;
        internal Label lblBPT3Decryptor;
        internal ComboBox cmbBPT3Decryptor;
        internal Label lblBPT3Stats;
        internal Label lblBPRelic;
        internal TextBox txtBPRelicLines;
        internal Label lblBPRelicLines;
        internal Label lblBPRETime;
        internal ComboBox cmbBPRelic;
        internal Label lblBPRECost;
        internal Label lblBPT3InventionChance;
        internal Label lblBPT3InventionChance1;
        internal Label lblT3InventStatus;
        internal CheckBox chkBPIncludeT3Time;
        internal CheckBox chkBPIncludeT3Costs;
        internal TabPage tabInventionCalcs;
        internal Label lblBPCopyTime;
        internal Label lblBPT2InventStatus;
        internal Label lblBPCopyCosts;
        internal TextBox txtBPInventionLines;
        internal Label lblBPInventionLines;
        internal Label lblInventionChance1;
        internal Label lblBPDecryptor;
        internal Label lblBPInventionTime;
        internal Label lblBPDecryptorStats;
        internal Label lblBPInventionCost;
        internal ComboBox cmbBPInventionDecryptor;
        internal Label lblBPInventionChance;
        internal CheckBox chkBPIncludeInventionTime;
        internal CheckBox chkBPIncludeCopyTime;
        internal CheckBox chkBPIncludeCopyCosts;
        internal CheckBox chkBPIncludeInventionCosts;
        internal Button btnBPSaveSettings;
        internal TextBox txtBPLines;
        internal PictureBox pictBP;
        internal GroupBox gbBPManualSystemCostIndex;
        internal Button btnBPUpdateCostIndex;
        internal Label lblBPSystemCostIndexManual;
        internal TextBox txtBPUpdateCostIndex;
        internal TextBox txtBPNumBPs;
        internal Button btnBPRefreshBP;
        internal Label lblBPLines;
        internal TextBox txtBPME;
        internal Label lblBPRuns;
        internal CheckBox chkBPBuildBuy;
        internal TextBox txtBPRuns;
        internal TextBox txtBPAddlCosts;
        internal Label lblBPAddlCosts;
        internal Label lblBPME;
        internal TextBox txtBPTE;
        internal Label lblBPPE;
        internal Label lblBPNumBPs;
        internal GroupBox gbBPIgnoreinCalcs;
        internal CheckBox chkBPIgnoreMinerals;
        internal CheckBox chkBPIgnoreT1Item;
        internal CheckBox chkBPIgnoreInvention;
        internal GroupBox gbBPShopandCopy;
        internal CheckBox chkBPSimpleCopy;
        internal RadioButton rbtnBPCopyInvREMats;
        internal RadioButton rbtnBPComponentCopy;
        internal RadioButton rbtnBPRawmatCopy;
        internal Button btnBPCopyMatstoClip;
        internal Button btnBPAddBPMatstoShoppingList;
        internal Label lblBPSimpleCopy;
        internal Label lblBPCanMakeBPAll;
        internal Label lblBPRawMatCost;
        internal Label lblBPRawMatCost1;
        internal Label lblBPCanMakeBP;
        internal Label lblBPRawMats;
        internal Label lblBPComponentMatCost;
        internal Label lblBPComponentMats;
        internal Label lblBPComponentMatCost1;
        internal MyListView lstBPRawMats;
        internal TabControl tabMain;
        internal MyListView lstBPComponentMats;
        internal MyListView lstBPBuiltComponents;
        internal Button btnBPBuiltComponents;
        internal Button btnBPComponents;
        internal ToolStripMenuItem FavoriteBlueprintToolStripMenuItem;
        internal TextBox txtBPBrokerFeeRate;
        internal TextBox txtCalcBrokerFeeRate;
        internal TextBox txtMineBrokerFeeRate;
        internal CheckBox chkMineTriglavian;
        internal ToolStripMenuItem mnuResetBuildBuyManualSelections;
        internal RadioButton rbtnCalcAdvT2MatType;
        private RadioButton rbtnCalcProcT2MatType;
        internal RadioButton rbtnCalcRawT2MatType;
        internal Label lblMineMiningDroneM3;
        internal Label lblMineDroneSpecSkill;
        internal ComboBox cmbMineDroneSpecSkill;
        internal Label lblMineDroneOpSkill;
        internal ComboBox cmbMineDroneOpSkill;
        internal ComboBox cmbMineDroneName;
        internal Label lblMineDroneName;
        internal ComboBox cmbMineDroneInterfacingSkill;
        internal Label lblMineDroneInterfacingSkill;
        internal CheckBox chkMineBoosterUseDrones;
        internal Label lblMineNumMiningDrones;
        internal ComboBox cmbMineNumMiningDrones;
        internal Label lblMineMiningDroneYield;
        internal Label lblMineDroneIdealRange;
        internal CheckBox chkMineBoosterDroneRig2;
        internal CheckBox chkMineBoosterDroneRig1;
        internal TabControl tabMiningDrones;
        internal TabPage tabShipDrones;
        internal TabPage tabBoosterDrones;
        internal Label lblMineBoosterDroneIdealRange;
        internal ComboBox cmbMineBoosterDroneName;
        internal Label lblMineBoosterMiningDroneYield;
        internal ComboBox cmbMineBoosterDroneOpSkill;
        internal Label lblMineBoosterMiningDroneM3;
        internal Label lblMineBoosterDroneOpSkill;
        internal Label lblMineBoosterNumMiningDrones;
        internal ComboBox cmbMineBoosterDroneSpecSkill;
        internal ComboBox cmbMineBoosterNumMiningDrones;
        internal Label lblMineBoosterDroneSpecSkill;
        internal Label lblMineBoosterDroneInterfacingSkill;
        internal Label lblMineBoosterDroneName;
        internal ComboBox cmbMineBoosterDroneInterfacingSkill;
        internal ManufacturingFacility MineRefineFacility;
        internal CheckBox chkMineBoosterDroneRig3;
        internal ComboBox cmbMineMiningRig3;
        internal ComboBox cmbMineMiningRig2;
        internal ComboBox cmbMineMiningRig1;
        internal TabControl tabPriceProfile;
        internal TabPage tabPriceProfileRaw;
        internal GroupBox gbPPDefaultSettings;
        internal Button btnPPUpdateDefaults;
        internal ComboBox cmbPPDefaultsPriceType;
        internal Label lblPPDefaultsSystem;
        internal Label lblPPDefaultsPriceType;
        internal ComboBox cmbPPDefaultsSystem;
        internal ComboBox cmbPPDefaultsRegion;
        internal Label lblPPDefaultsRegion;
        internal TextBox txtPPDefaultsPriceMod;
        internal Label lblPPDefaultsPriceMod;
        internal MyListView lstRawPriceProfile;
        internal TabPage tabPriceProfileManufactured;
        internal MyListView lstManufacturedPriceProfile;
        internal ComboBox cmbPriceRegions;
        internal GroupBox gbSingleSource;
        internal GroupBox gbPriceProfile;
        internal GroupBox gbMarketStructures;
        internal GroupBox gbRegionSystemPrice;
        internal Button btnOpenMarketBrowser;
        internal CheckBox chkSystems6;
        internal CheckBox chkMolecularForgedMaterials;
        internal CheckBox chkAdvancedProtectiveTechnology;
        internal CheckBox chkMolecularForgingTools;
        internal CheckBox chkNamedComponents;
        internal CheckBox chkRDb;
        internal GroupBox gbReactionMaterials;
        internal GroupBox gbResearchEquipment;
        internal CheckBox chkProtectiveComponents;
        internal Label lblMineFacilityMoonOreRate;
        internal Label lblMineFacilityOreRate;
        internal Label lblMineFacilityMoonOreRate1;
        internal Label lblMineFacilityOreRate1;
        internal GroupBox gbMineOreStuctureRates;
        internal ToolStripMenuItem mnuOreFlips;
        internal ToolStripMenuItem mnuAnomalyOreBelts;
        internal ToolStripMenuItem mnuIceBelts;
        internal ToolStripMenuItem mnuResetSavedFacilities;
        internal GroupBox gbReprocessables;
        internal CheckBox chkNoBuildItems;
        internal ToolStripMenuItem mnuViewErrorLog;
        internal GroupBox gbMineCrystalType;
        internal CheckBox chkMineTypeC;
        internal CheckBox chkMineTypeB;
        internal CheckBox chkMineTypeA;
        internal CheckBox chkMineT2Crystals;
        internal CheckBox chkMineT1Crystals;
        internal TabControl tabMiningProcessingSkills;
        internal TabPage tabPageOres;
        internal CheckBox chkOreProcessing1;
        internal ComboBox cmbOreProcessing2;
        internal Label lblOreProcessing2;
        internal CheckBox chkOreProcessing3;
        internal CheckBox chkOreProcessing2;
        internal CheckBox chkOreProcessing6;
        internal ComboBox cmbOreProcessing1;
        internal Label lblOreProcessing1;
        internal Label lblOreProcessing6;
        internal CheckBox chkOreProcessing5;
        internal ComboBox cmbOreProcessing6;
        internal Label lblOreProcessing3;
        internal Label lblOreProcessing5;
        internal ComboBox cmbOreProcessing4;
        internal ComboBox cmbOreProcessing3;
        internal CheckBox chkOreProcessing4;
        internal Label lblOreProcessing4;
        internal ComboBox cmbOreProcessing5;
        internal TabPage tabPageMoonOres;
        internal Label lblOreProcessing7;
        internal Label lblOreProcessing8;
        internal Label lblOreProcessing10;
        internal Label lblOreProcessing11;
        internal ComboBox cmbOreProcessing11;
        internal CheckBox chkOreProcessing9;
        internal Label lblOreProcessing9;
        internal CheckBox chkOreProcessing8;
        internal ComboBox cmbOreProcessing10;
        internal ComboBox cmbOreProcessing7;
        internal CheckBox chkOreProcessing10;
        internal CheckBox chkOreProcessing7;
        internal ComboBox cmbOreProcessing9;
        internal CheckBox chkOreProcessing11;
        internal ComboBox cmbOreProcessing8;
        internal TabPage tabPageIce;
        internal ComboBox cmbOreProcessing12;
        internal Label lblOreProcessing12;
        internal CheckBox chkOreProcessing12;
        internal ToolStripMenuItem mnuMETECalculator;
        internal RadioButton rbtnPriceSourceFW;
        internal CheckBox chkMineEDENCOM;
        internal ToolStripMenuItem mnuHelp;
        internal ToolStripMenuItem mnuYouTube;
        internal ToolStripMenuItem mnuDiscord;
        internal CheckBox chkMineIncludeA0StarOres;
    }
}