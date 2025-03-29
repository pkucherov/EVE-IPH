using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmUpwellStructureFitting : Form
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
            var ListViewGroup1 = new ListViewGroup("Services", HorizontalAlignment.Left);
            var ListViewGroup2 = new ListViewGroup("High Slots", HorizontalAlignment.Left);
            var ListViewGroup3 = new ListViewGroup("Mid Slots", HorizontalAlignment.Left);
            var ListViewGroup4 = new ListViewGroup("Low Slots", HorizontalAlignment.Left);
            var ListViewGroup5 = new ListViewGroup("Combat Rigs", HorizontalAlignment.Left);
            var ListViewGroup6 = new ListViewGroup("Reprocessing Rigs", HorizontalAlignment.Left);
            var ListViewGroup7 = new ListViewGroup("Engineering Rigs", HorizontalAlignment.Left);
            var ListViewGroup8 = new ListViewGroup("Reaction Rigs", HorizontalAlignment.Left);
            var ListViewGroup9 = new ListViewGroup("Drilling Rigs", HorizontalAlignment.Left);
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpwellStructureFitting));
            FittingImages = new ImageList(components);
            FittingListViewIcons = new ListView();
            FittingListViewIcons.MouseDown += new MouseEventHandler(ServiceModuleListView_MouseDown);
            FittingListViewIcons.ItemActivate += new EventHandler(ServiceModuleListView_ItemActivate);
            lblSelectedUpwellStructure = new Label();
            cmbUpwellStructureName = new ComboBox();
            cmbUpwellStructureName.SelectedIndexChanged += new EventHandler(cmbUpwellStructureName_SelectedIndexChanged);
            cmbUpwellStructureName.KeyPress += new KeyPressEventHandler(cmbUpwellStructureName_KeyPress);
            chkIncludeFuelCosts = new CheckBox();
            chkIncludeFuelCosts.CheckedChanged += new EventHandler(chkIncludeFuelCosts_CheckedChanged);
            btnStripFitting = new Button();
            btnStripFitting.Click += new EventHandler(btnToggleAllPriceItems_Click);
            tabUpwellStructure = new TabControl();
            tabFitting = new TabPage();
            LowSlot3 = new PictureBox();
            LowSlot3.DoubleClick += new EventHandler(LowSlot3_DoubleClick);
            LowSlot3.MouseEnter += new EventHandler(LowSlot3_MouseEnter);
            RigSlot2 = new PictureBox();
            RigSlot2.DoubleClick += new EventHandler(RigSlot2_DoubleClick);
            RigSlot2.MouseEnter += new EventHandler(RigSlot2_MouseEnter);
            LowSlot6 = new PictureBox();
            LowSlot6.DoubleClick += new EventHandler(LowSlot6_DoubleClick);
            LowSlot6.MouseEnter += new EventHandler(LowSlot6_MouseEnter);
            RigSlot3 = new PictureBox();
            RigSlot3.DoubleClick += new EventHandler(RigSlot3_DoubleClick);
            RigSlot3.MouseEnter += new EventHandler(RigSlot3_MouseEnter);
            LowSlot2 = new PictureBox();
            LowSlot2.DoubleClick += new EventHandler(LowSlot2_DoubleClick);
            LowSlot2.MouseEnter += new EventHandler(LowSlot2_MouseEnter);
            RigSlot1 = new PictureBox();
            RigSlot1.DoubleClick += new EventHandler(RigSlot1_DoubleClick);
            RigSlot1.MouseEnter += new EventHandler(RigSlot1_MouseEnter);
            LowSlot7 = new PictureBox();
            LowSlot7.DoubleClick += new EventHandler(LowSlot7_DoubleClick);
            LowSlot7.MouseEnter += new EventHandler(LowSlot7_MouseEnter);
            ServiceSlot1 = new PictureBox();
            ServiceSlot1.DoubleClick += new EventHandler(ServiceSlot1_DoubleClick);
            ServiceSlot1.MouseEnter += new EventHandler(ServiceSlot1_MouseEnter);
            LowSlot8 = new PictureBox();
            LowSlot8.DoubleClick += new EventHandler(LowSlot8_DoubleClick);
            LowSlot8.MouseEnter += new EventHandler(LowSlot8_MouseEnter);
            ServiceSlot2 = new PictureBox();
            ServiceSlot2.DoubleClick += new EventHandler(ServiceSlot2_DoubleClick);
            ServiceSlot2.MouseEnter += new EventHandler(ServiceSlot2_MouseEnter);
            LowSlot4 = new PictureBox();
            LowSlot4.DoubleClick += new EventHandler(LowSlot4_DoubleClick);
            LowSlot4.MouseEnter += new EventHandler(LowSlot4_MouseEnter);
            ServiceSlot3 = new PictureBox();
            ServiceSlot3.DoubleClick += new EventHandler(ServiceSlot3_DoubleClick);
            ServiceSlot3.MouseEnter += new EventHandler(ServiceSlot3_MouseEnter);
            LowSlot5 = new PictureBox();
            LowSlot5.DoubleClick += new EventHandler(LowSlot5_DoubleClick);
            LowSlot5.MouseEnter += new EventHandler(LowSlot5_MouseEnter);
            ServiceSlot4 = new PictureBox();
            ServiceSlot4.DoubleClick += new EventHandler(ServiceSlot4_DoubleClick);
            ServiceSlot4.MouseEnter += new EventHandler(ServiceSlot4_MouseEnter);
            LowSlot1 = new PictureBox();
            LowSlot1.DoubleClick += new EventHandler(LowSlot1_DoubleClick);
            LowSlot1.MouseEnter += new EventHandler(LowSlot1_MouseEnter);
            HighSlot8 = new PictureBox();
            HighSlot8.DoubleClick += new EventHandler(HighSlot8_DoubleClick);
            HighSlot8.MouseEnter += new EventHandler(HighSlot8_MouseEnter);
            ServiceSlot5 = new PictureBox();
            ServiceSlot5.DoubleClick += new EventHandler(ServiceSlot5_DoubleClick);
            ServiceSlot5.MouseEnter += new EventHandler(ServiceSlot5_MouseEnter);
            HighSlot5 = new PictureBox();
            HighSlot5.DoubleClick += new EventHandler(HighSlot5_DoubleClick);
            HighSlot5.MouseEnter += new EventHandler(HighSlot5_MouseEnter);
            ServiceSlot6 = new PictureBox();
            ServiceSlot6.DoubleClick += new EventHandler(ServiceSlot6_DoubleClick);
            ServiceSlot6.MouseEnter += new EventHandler(ServiceSlot6_MouseEnter);
            HighSlot6 = new PictureBox();
            HighSlot6.DoubleClick += new EventHandler(HighSlot6_DoubleClick);
            HighSlot6.MouseEnter += new EventHandler(HighSlot6_MouseEnter);
            MidSlot3 = new PictureBox();
            MidSlot3.DoubleClick += new EventHandler(MidSlot3_DoubleClick);
            MidSlot3.MouseEnter += new EventHandler(MidSlot3_MouseEnter);
            HighSlot4 = new PictureBox();
            HighSlot4.DoubleClick += new EventHandler(HighSlot4_DoubleClick);
            HighSlot4.MouseEnter += new EventHandler(HighSlot4_MouseEnter);
            MidSlot4 = new PictureBox();
            MidSlot4.DoubleClick += new EventHandler(MidSlot4_DoubleClick);
            MidSlot4.MouseEnter += new EventHandler(MidSlot4_MouseEnter);
            HighSlot2 = new PictureBox();
            HighSlot2.DoubleClick += new EventHandler(HighSlot2_DoubleClick);
            HighSlot2.MouseEnter += new EventHandler(HighSlot2_MouseEnter);
            MidSlot2 = new PictureBox();
            MidSlot2.DoubleClick += new EventHandler(MidSlot2_DoubleClick);
            MidSlot2.MouseEnter += new EventHandler(MidSlot2_MouseEnter);
            HighSlot3 = new PictureBox();
            HighSlot3.DoubleClick += new EventHandler(HighSlot3_DoubleClick);
            HighSlot3.MouseEnter += new EventHandler(HighSlot3_MouseEnter);
            MidSlot1 = new PictureBox();
            MidSlot1.DoubleClick += new EventHandler(MidSlot1_DoubleClick);
            MidSlot1.MouseEnter += new EventHandler(MidSlot1_MouseEnter);
            HighSlot7 = new PictureBox();
            HighSlot7.DoubleClick += new EventHandler(HighSlot7_DoubleClick);
            HighSlot7.MouseEnter += new EventHandler(HighSlot7_MouseEnter);
            MidSlot5 = new PictureBox();
            MidSlot5.DoubleClick += new EventHandler(MidSlot5_DoubleClick);
            MidSlot5.MouseEnter += new EventHandler(MidSlot5_MouseEnter);
            MidSlot8 = new PictureBox();
            MidSlot8.DoubleClick += new EventHandler(MidSlot8_DoubleClick);
            MidSlot8.MouseEnter += new EventHandler(MidSlot8_MouseEnter);
            HighSlot1 = new PictureBox();
            HighSlot1.DoubleClick += new EventHandler(HighSlot1_DoubleClick);
            HighSlot1.MouseEnter += new EventHandler(HighSlot1_MouseEnter);
            MidSlot6 = new PictureBox();
            MidSlot6.DoubleClick += new EventHandler(MidSlot6_DoubleClick);
            MidSlot6.MouseEnter += new EventHandler(MidSlot6_MouseEnter);
            MidSlot7 = new PictureBox();
            MidSlot7.DoubleClick += new EventHandler(MidSlot7_DoubleClick);
            MidSlot7.MouseEnter += new EventHandler(MidSlot7_MouseEnter);
            StructurePicture = new PictureBox();
            tabFuelandBonuses = new TabPage();
            gbFacilityBonuses = new GroupBox();
            btnBonusPopout = new Button();
            btnBonusPopout.Click += new EventHandler(btnBonusPopout_Click);
            lstUpwellStructureBonuses = new ListView();
            lstUpwellStructureBonuses.ColumnClick += new ColumnClickEventHandler(lstUpwellStructureBonuses_ColumnClick);
            BonusAppliesTo = new ColumnHeader();
            Activity = new ColumnHeader();
            Bonuses = new ColumnHeader();
            Source = new ColumnHeader();
            gbFuelBlocks = new GroupBox();
            btnRefreshPrices = new Button();
            btnRefreshPrices.Click += new EventHandler(btnRefreshPrices_Click);
            gbFuelPrices = new GroupBox();
            lblHydrogenIsotopes = new Label();
            lblHeavyWater = new Label();
            lblStrontiumClathrates = new Label();
            lblEnrichedUranium = new Label();
            lblOxygen = new Label();
            lblCoolant = new Label();
            lblLiquidOzone = new Label();
            lblMechanicalParts = new Label();
            lblRobotics = new Label();
            lblNitrogenIsotopes = new Label();
            lblHeliumIsotopes = new Label();
            lblOxygenIsotopes = new Label();
            picHeliumIsotopes = new PictureBox();
            txtMechanicalParts = new TextBox();
            txtMechanicalParts.KeyDown += new KeyEventHandler(txtMechanicalParts_KeyDown);
            txtMechanicalParts.KeyPress += new KeyPressEventHandler(txtMechanicalParts_KeyPress);
            txtMechanicalParts.GotFocus += new EventHandler(txtMechanicalParts_GotFocus);
            txtNitrogenIsotopes = new TextBox();
            txtNitrogenIsotopes.KeyDown += new KeyEventHandler(txtNitrogenIsotopes_KeyDown);
            txtNitrogenIsotopes.KeyPress += new KeyPressEventHandler(txtNitrogenIsotopes_KeyPress);
            txtNitrogenIsotopes.GotFocus += new EventHandler(txtNitrogenIsotopes_GotFocus);
            txtLiquidOzone = new TextBox();
            txtLiquidOzone.KeyDown += new KeyEventHandler(txtLiquidOzone_KeyDown);
            txtLiquidOzone.KeyPress += new KeyPressEventHandler(txtLiquidOzone_KeyPress);
            txtLiquidOzone.GotFocus += new EventHandler(txtLiquidOzone_GotFocus);
            txtCoolant = new TextBox();
            txtCoolant.KeyDown += new KeyEventHandler(txtCoolant_KeyDown);
            txtCoolant.KeyPress += new KeyPressEventHandler(txtCoolant_KeyPress);
            txtCoolant.GotFocus += new EventHandler(txtCoolant_GotFocus);
            txtOxygen = new TextBox();
            txtOxygen.KeyDown += new KeyEventHandler(txtOxygen_KeyDown);
            txtOxygen.KeyPress += new KeyPressEventHandler(txtOxygen_KeyPress);
            txtOxygen.GotFocus += new EventHandler(txtOxygen_GotFocus);
            txtEnrichedUranium = new TextBox();
            txtEnrichedUranium.KeyDown += new KeyEventHandler(txtEnrichedUranium_KeyDown);
            txtEnrichedUranium.KeyPress += new KeyPressEventHandler(txtEnrichedUranium_KeyPress);
            txtEnrichedUranium.GotFocus += new EventHandler(txtEnrichedUranium_GotFocus);
            txtStrontiumClathrates = new TextBox();
            txtStrontiumClathrates.KeyDown += new KeyEventHandler(txtStrontiumClathrates_KeyDown);
            txtStrontiumClathrates.KeyPress += new KeyPressEventHandler(txtStrontiumClathrates_KeyPress);
            txtStrontiumClathrates.GotFocus += new EventHandler(txtStrontiumClathrates_GotFocus);
            picCoolant = new PictureBox();
            picOxygen = new PictureBox();
            txtHeavyWater = new TextBox();
            txtHeavyWater.KeyDown += new KeyEventHandler(txtHeavyWater_KeyDown);
            txtHeavyWater.KeyPress += new KeyPressEventHandler(txtHeavyWater_KeyPress);
            txtHeavyWater.GotFocus += new EventHandler(txtHeavyWater_GotFocus);
            picNitrogenIsotopes = new PictureBox();
            txtRobotics = new TextBox();
            txtRobotics.KeyDown += new KeyEventHandler(txtRobotics_KeyDown);
            txtRobotics.KeyPress += new KeyPressEventHandler(txtRobotics_KeyPress);
            txtRobotics.GotFocus += new EventHandler(txtRobotics_GotFocus);
            picHydrogenIsotopes = new PictureBox();
            picEnrichedUranium = new PictureBox();
            picOxygenIsotopes = new PictureBox();
            picMechanicalParts = new PictureBox();
            picRobotics = new PictureBox();
            picStrontiumClathrates = new PictureBox();
            txtOxygenIsotopes = new TextBox();
            txtOxygenIsotopes.KeyDown += new KeyEventHandler(txtOxygenIsotopes_KeyDown);
            txtOxygenIsotopes.KeyPress += new KeyPressEventHandler(txtOxygenIsotopes_KeyPress);
            txtOxygenIsotopes.GotFocus += new EventHandler(txtOxygenIsotopes_GotFocus);
            picLiquidOzone = new PictureBox();
            picHeavyWater = new PictureBox();
            txtHydrogenIsotopes = new TextBox();
            txtHydrogenIsotopes.KeyDown += new KeyEventHandler(txtHydrogenIsotopes_KeyDown);
            txtHydrogenIsotopes.KeyPress += new KeyPressEventHandler(txtHydrogenIsotopes_KeyPress);
            txtHydrogenIsotopes.GotFocus += new EventHandler(txtHydrogenIsotopes_GotFocus);
            txtHeliumIsotopes = new TextBox();
            txtHeliumIsotopes.KeyDown += new KeyEventHandler(txtHeliumIsotopes_KeyDown);
            txtHeliumIsotopes.KeyPress += new KeyPressEventHandler(txtHeliumIsotopes_KeyPress);
            txtHeliumIsotopes.GotFocus += new EventHandler(txtHeliumIsotopes_GotFocus);
            btnSaveFuelBlockInfo = new Button();
            btnSaveFuelBlockInfo.Click += new EventHandler(btnSaveFuelBlockInfo_Click);
            gbFuelBlocks2 = new GroupBox();
            picHeliumFuelBlock = new PictureBox();
            lblHeliumFuelBlock = new Label();
            lblHeliumFuelBlockBPME = new Label();
            txtHeliumFuelBlockBPME = new TextBox();
            txtHeliumFuelBlockBPME.KeyDown += new KeyEventHandler(txtHeliumFuelBlockBPME_KeyDown);
            txtHeliumFuelBlockBPME.KeyPress += new KeyPressEventHandler(txtHeliumFuelBlockBPME_KeyPress);
            txtHeliumFuelBlockBPME.GotFocus += new EventHandler(txtHeliumFuelBlockBPME_GotFocus);
            lblHeliumFuelBlockBuy = new Label();
            lblHeliumFuelBlockBuild = new Label();
            txtHeliumFuelBlockBuyPrice = new TextBox();
            txtHeliumFuelBlockBuyPrice.KeyDown += new KeyEventHandler(txtHeliumFuelBlockBuyPrice_KeyDown);
            txtHeliumFuelBlockBuyPrice.KeyPress += new KeyPressEventHandler(txtHeliumFuelBlockBuyPrice_KeyPress);
            txtHeliumFuelBlockBuyPrice.GotFocus += new EventHandler(txtHeliumFuelBlockBuyPrice_GotFocus);
            lblHeliumFuelBlockBuildPrice = new Label();
            lblHydrogenFuelBlock = new Label();
            lblHydrogenFuelBlockBPME = new Label();
            picHydrogenFuelBlock = new PictureBox();
            txtHydrogenFuelBlockBPME = new TextBox();
            txtHydrogenFuelBlockBPME.KeyDown += new KeyEventHandler(txtHydrogenFuelBlockBPME_KeyDown);
            txtHydrogenFuelBlockBPME.KeyPress += new KeyPressEventHandler(txtHydrogenFuelBlockBPME_KeyPress);
            txtHydrogenFuelBlockBPME.GotFocus += new EventHandler(txtHydrogenFuelBlockBPME_GotFocus);
            lblHydrogenBlockBuy = new Label();
            lblHydrogenFuelBlockBuild = new Label();
            txtHydrogenFuelBlockBuyPrice = new TextBox();
            txtHydrogenFuelBlockBuyPrice.KeyDown += new KeyEventHandler(txtHydrogenFuelBlockBuyPrice_KeyDown);
            txtHydrogenFuelBlockBuyPrice.KeyPress += new KeyPressEventHandler(txtHydrogenFuelBlockBuyPrice_KeyPress);
            txtHydrogenFuelBlockBuyPrice.GotFocus += new EventHandler(txtHydrogenFuelBlockBuyPrice_GotFocus);
            lblHydrogenFuelBlockBuildPrice = new Label();
            lblNitrogenFuelBlock = new Label();
            lblNitrogenFuelBlockBPME = new Label();
            picNitrogenFuelBlock = new PictureBox();
            txtNitrogenFuelBlockBPME = new TextBox();
            txtNitrogenFuelBlockBPME.KeyDown += new KeyEventHandler(txtNitrogenFuelBlockBPME_KeyDown);
            txtNitrogenFuelBlockBPME.KeyPress += new KeyPressEventHandler(txtNitrogenFuelBlockBPME_KeyPress);
            txtNitrogenFuelBlockBPME.GotFocus += new EventHandler(txtNitrogenFuelBlockBPME_GotFocus);
            lblNitrogenFuelBlockBuy = new Label();
            lblNitrogenFuelBlockBuild = new Label();
            txtNitrogenFuelBlockBuyPrice = new TextBox();
            txtNitrogenFuelBlockBuyPrice.KeyDown += new KeyEventHandler(txtNitrogenFuelBlockBuyPrice_KeyDown);
            txtNitrogenFuelBlockBuyPrice.KeyPress += new KeyPressEventHandler(txtNitrogenFuelBlockBuyPrice_KeyPress);
            txtNitrogenFuelBlockBuyPrice.GotFocus += new EventHandler(txtNitrogenFuelBlockBuyPrice_GotFocus);
            lblNitrogenFuelBlockBuildPrice = new Label();
            lblOxygenFuelBlock = new Label();
            lblOxygenFuelBlockBPME = new Label();
            picOxygenFuelBlock = new PictureBox();
            txtOxygenFuelBlockBPME = new TextBox();
            txtOxygenFuelBlockBPME.KeyDown += new KeyEventHandler(txtOxygenFuelBlockBPME_KeyDown);
            txtOxygenFuelBlockBPME.KeyPress += new KeyPressEventHandler(txtOxygenFuelBlockBPME_KeyPress);
            txtOxygenFuelBlockBPME.GotFocus += new EventHandler(txtOxygenFuelBlockBPME_GotFocus);
            lblOxygenFuelBlockBuy = new Label();
            lblOxygenFuelBlockBuild = new Label();
            txtOxygenFuelBlockBuyPrice = new TextBox();
            txtOxygenFuelBlockBuyPrice.KeyDown += new KeyEventHandler(txtOxygenFuelBlockBuyPrice_KeyDown);
            txtOxygenFuelBlockBuyPrice.KeyPress += new KeyPressEventHandler(txtOxygenFuelBlockBuyPrice_KeyPress);
            txtOxygenFuelBlockBuyPrice.GotFocus += new EventHandler(txtOxygenFuelBlockBuyPrice_GotFocus);
            lblOxygenFuelBlockBuildPrice = new Label();
            gbFuelBlockOptions = new GroupBox();
            rbtnBuyBlocks = new RadioButton();
            rbtnBuyBlocks.CheckedChanged += new EventHandler(rbtnBuyBlocks_CheckedChanged);
            rbtnBuildBlocks = new RadioButton();
            rbtnBuildBlocks.CheckedChanged += new EventHandler(rbtnBuildBlocks_CheckedChanged);
            chkAutoUpdateFuelPrice = new CheckBox();
            btnSavePrices = new Button();
            btnSavePrices.Click += new EventHandler(btnSavePrices_Click);
            btnUpdateBuildCost = new Button();
            btnUpdateBuildCost.Click += new EventHandler(btnUpdateBuildCost_Click);
            lblLauncherSlots = new Label();
            gbFilterOptions = new GroupBox();
            chkRigTypeViewDrilling = new CheckBox();
            chkRigTypeViewDrilling.CheckedChanged += new EventHandler(chkRigTypeViewDrilling_CheckedChanged);
            chkRigTypeViewReaction = new CheckBox();
            chkRigTypeViewReaction.CheckedChanged += new EventHandler(chkRigTypeViewReaction_CheckedChanged);
            chkRigTypeViewCombat = new CheckBox();
            chkRigTypeViewCombat.CheckedChanged += new EventHandler(chkRigTypeViewCombat_CheckedChanged);
            chkRigTypeViewReprocessing = new CheckBox();
            chkRigTypeViewReprocessing.CheckedChanged += new EventHandler(chkRigTypeViewReprocessing_CheckedChanged);
            chkRigTypeViewEngineering = new CheckBox();
            chkRigTypeViewEngineering.CheckedChanged += new EventHandler(chkRigTypeViewEngineering_CheckedChanged);
            chkItemViewTypeLow = new CheckBox();
            chkItemViewTypeLow.CheckedChanged += new EventHandler(chkItemViewTypeLow_CheckedChanged);
            chkItemViewTypeMedium = new CheckBox();
            chkItemViewTypeMedium.CheckedChanged += new EventHandler(chkItemViewTypeMedium_CheckedChanged);
            chkItemViewTypeHigh = new CheckBox();
            chkItemViewTypeHigh.CheckedChanged += new EventHandler(chkItemViewTypeHigh_CheckedChanged);
            chkItemViewTypeServices = new CheckBox();
            chkItemViewTypeServices.CheckedChanged += new EventHandler(chkItemViewTypeServices_CheckedChanged);
            gbStatsandOptions = new GroupBox();
            gbOptions = new GroupBox();
            lblSystemSecurity = new Label();
            chkNullSec = new CheckBox();
            chkNullSec.CheckedChanged += new EventHandler(chkNullSec_CheckedChanged);
            chkLowSec = new CheckBox();
            chkLowSec.CheckedChanged += new EventHandler(chkLowSec_CheckedChanged);
            chkHighSec = new CheckBox();
            chkHighSec.CheckedChanged += new EventHandler(chkHighSec_CheckedChanged);
            gbIncludeFuelBlocks = new GroupBox();
            lblServiceModuleBPD = new Label();
            lblFuelBlocksperDay = new Label();
            gbSelectedFuelBlock = new GroupBox();
            rbtnHeliumFuelBlock = new RadioButton();
            rbtnHeliumFuelBlock.CheckedChanged += new EventHandler(rbtnHeliumFuelBlock_CheckedChanged);
            rbtnHydrogenFuelBlock = new RadioButton();
            rbtnHydrogenFuelBlock.CheckedChanged += new EventHandler(rbtnHydrogenFuelBlock_CheckedChanged);
            rbtnOxygenFuelBlock = new RadioButton();
            rbtnOxygenFuelBlock.CheckedChanged += new EventHandler(rbtnOxygenFuelBlock_CheckedChanged);
            rbtnNitrogenFuelBlock = new RadioButton();
            rbtnNitrogenFuelBlock.CheckedChanged += new EventHandler(rbtnNitrogenFuelBlock_CheckedChanged);
            lblFuelReductionBonus = new Label();
            lblServiceModuleOnlineAmt = new Label();
            lblOnlineAmt = new Label();
            lblFuelBPH = new Label();
            lblServiceModuleBPH = new Label();
            lblServiceModuleFCPH = new Label();
            lblFuelCost = new Label();
            lblCapacitor = new Label();
            lblCapacitor1 = new Label();
            lblCalibration = new Label();
            lblCalibration1 = new Label();
            lblCPU = new Label();
            lblPowerGrid = new Label();
            lblCPU1 = new Label();
            lblPowerGrid1 = new Label();
            btnSaveFitting = new Button();
            btnSaveFitting.Click += new EventHandler(btnSaveFitting_Click);
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            btnCloseForm = new Button();
            btnCloseForm.Click += new EventHandler(btnCloseForm_Click);
            gbTextFilter = new GroupBox();
            btnItemFilter = new Button();
            btnItemFilter.Click += new EventHandler(btnItemFilter_Click);
            btnResetItemFilter = new Button();
            btnResetItemFilter.Click += new EventHandler(btnResetItemFilter_Click);
            txtItemFilter = new TextBox();
            txtItemFilter.KeyDown += new KeyEventHandler(txtItemFilter_KeyDown);
            EventLog1 = new EventLog();
            pbFloat = new PictureBox();
            MainToolTip = new ToolTip(components);
            gbViewType = new GroupBox();
            rbtnListView = new RadioButton();
            rbtnListView.CheckedChanged += new EventHandler(rbtnListView_CheckedChanged);
            rbtnViewIcons = new RadioButton();
            rbtnViewIcons.CheckedChanged += new EventHandler(rbtnViewIcons_CheckedChanged);
            FittingListViewDetails = new ManufacturingListView();
            FittingListViewDetails.DoubleClick += new EventHandler(FittingListViewDetails_DoubleClick);
            FittingListViewDetails.ColumnClick += new ColumnClickEventHandler(FittingListViewDetails_ColumnClick);
            ModuleName = new ColumnHeader();
            ModuleType = new ColumnHeader();
            GroupTag = new ColumnHeader();
            ModuleTypeID = new ColumnHeader();
            tabUpwellStructure.SuspendLayout();
            tabFitting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LowSlot3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RigSlot2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RigSlot3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RigSlot1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StructurePicture).BeginInit();
            tabFuelandBonuses.SuspendLayout();
            gbFacilityBonuses.SuspendLayout();
            gbFuelBlocks.SuspendLayout();
            gbFuelPrices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeliumIsotopes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCoolant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOxygen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picNitrogenIsotopes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHydrogenIsotopes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEnrichedUranium).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOxygenIsotopes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picMechanicalParts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picRobotics).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picStrontiumClathrates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLiquidOzone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHeavyWater).BeginInit();
            gbFuelBlocks2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeliumFuelBlock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHydrogenFuelBlock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picNitrogenFuelBlock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOxygenFuelBlock).BeginInit();
            gbFuelBlockOptions.SuspendLayout();
            gbFilterOptions.SuspendLayout();
            gbStatsandOptions.SuspendLayout();
            gbOptions.SuspendLayout();
            gbIncludeFuelBlocks.SuspendLayout();
            gbSelectedFuelBlock.SuspendLayout();
            gbTextFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EventLog1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFloat).BeginInit();
            gbViewType.SuspendLayout();
            SuspendLayout();
            // 
            // FittingImages
            // 
            FittingImages.ColorDepth = ColorDepth.Depth32Bit;
            FittingImages.ImageSize = new Size(64, 64);
            FittingImages.TransparentColor = Color.Transparent;
            // 
            // FittingListViewIcons
            // 
            FittingListViewIcons.Activation = ItemActivation.TwoClick;
            FittingListViewIcons.AllowDrop = true;
            FittingListViewIcons.AutoArrange = false;
            FittingListViewIcons.GridLines = true;
            ListViewGroup1.Header = "Services";
            ListViewGroup1.Name = "ServiceSlots";
            ListViewGroup1.Tag = "ServiceSlot";
            ListViewGroup2.Header = "High Slots";
            ListViewGroup2.Name = "HighSlots";
            ListViewGroup2.Tag = "HighSlot";
            ListViewGroup3.Header = "Mid Slots";
            ListViewGroup3.Name = "MidSlots";
            ListViewGroup3.Tag = "MidSlot";
            ListViewGroup4.Header = "Low Slots";
            ListViewGroup4.Name = "LowSlots";
            ListViewGroup4.Tag = "LowSlot";
            ListViewGroup5.Header = "Combat Rigs";
            ListViewGroup5.Name = "CombatRigs";
            ListViewGroup5.Tag = "RigSlot";
            ListViewGroup6.Header = "Reprocessing Rigs";
            ListViewGroup6.Name = "ReprocessingRigs";
            ListViewGroup6.Tag = "RigSlot";
            ListViewGroup7.Header = "Engineering Rigs";
            ListViewGroup7.Name = "EngineeringRigs";
            ListViewGroup7.Tag = "RigSlot";
            ListViewGroup8.Header = "Reaction Rigs";
            ListViewGroup8.Name = "ReactionRigs";
            ListViewGroup8.Tag = "RigSlot";
            ListViewGroup9.Header = "Drilling Rigs";
            ListViewGroup9.Name = "DrillingRigs";
            ListViewGroup9.Tag = "RigSlot";
            FittingListViewIcons.Groups.AddRange(new ListViewGroup[] { ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5, ListViewGroup6, ListViewGroup7, ListViewGroup8, ListViewGroup9 });
            FittingListViewIcons.HoverSelection = true;
            FittingListViewIcons.LargeImageList = FittingImages;
            FittingListViewIcons.Location = new Point(6, 210);
            FittingListViewIcons.MultiSelect = false;
            FittingListViewIcons.Name = "FittingListViewIcons";
            FittingListViewIcons.Size = new Size(342, 363);
            FittingListViewIcons.TabIndex = 8;
            FittingListViewIcons.UseCompatibleStateImageBehavior = false;
            // 
            // lblSelectedUpwellStructure
            // 
            lblSelectedUpwellStructure.AutoSize = true;
            lblSelectedUpwellStructure.Location = new Point(6, 12);
            lblSelectedUpwellStructure.Name = "lblSelectedUpwellStructure";
            lblSelectedUpwellStructure.Size = new Size(133, 13);
            lblSelectedUpwellStructure.TabIndex = 0;
            lblSelectedUpwellStructure.Text = "Selected Upwell Structure:";
            // 
            // cmbUpwellStructureName
            // 
            cmbUpwellStructureName.FormattingEnabled = true;
            cmbUpwellStructureName.Location = new Point(138, 8);
            cmbUpwellStructureName.Name = "cmbUpwellStructureName";
            cmbUpwellStructureName.Size = new Size(210, 21);
            cmbUpwellStructureName.TabIndex = 1;
            // 
            // chkIncludeFuelCosts
            // 
            chkIncludeFuelCosts.AutoSize = true;
            chkIncludeFuelCosts.Location = new Point(6, 193);
            chkIncludeFuelCosts.Name = "chkIncludeFuelCosts";
            chkIncludeFuelCosts.Size = new Size(113, 17);
            chkIncludeFuelCosts.TabIndex = 9;
            chkIncludeFuelCosts.Text = "Include Fuel Costs";
            chkIncludeFuelCosts.UseVisualStyleBackColor = true;
            // 
            // btnStripFitting
            // 
            btnStripFitting.Location = new Point(93, 35);
            btnStripFitting.Name = "btnStripFitting";
            btnStripFitting.Size = new Size(81, 30);
            btnStripFitting.TabIndex = 2;
            btnStripFitting.Text = "Strip Fitting";
            btnStripFitting.UseVisualStyleBackColor = true;
            // 
            // tabUpwellStructure
            // 
            tabUpwellStructure.Controls.Add(tabFitting);
            tabUpwellStructure.Controls.Add(tabFuelandBonuses);
            tabUpwellStructure.Location = new Point(354, 4);
            tabUpwellStructure.Name = "tabUpwellStructure";
            tabUpwellStructure.SelectedIndex = 0;
            tabUpwellStructure.Size = new Size(603, 603);
            tabUpwellStructure.TabIndex = 9;
            // 
            // tabFitting
            // 
            tabFitting.Controls.Add(LowSlot3);
            tabFitting.Controls.Add(RigSlot2);
            tabFitting.Controls.Add(LowSlot6);
            tabFitting.Controls.Add(RigSlot3);
            tabFitting.Controls.Add(LowSlot2);
            tabFitting.Controls.Add(RigSlot1);
            tabFitting.Controls.Add(LowSlot7);
            tabFitting.Controls.Add(ServiceSlot1);
            tabFitting.Controls.Add(LowSlot8);
            tabFitting.Controls.Add(ServiceSlot2);
            tabFitting.Controls.Add(LowSlot4);
            tabFitting.Controls.Add(ServiceSlot3);
            tabFitting.Controls.Add(LowSlot5);
            tabFitting.Controls.Add(ServiceSlot4);
            tabFitting.Controls.Add(LowSlot1);
            tabFitting.Controls.Add(HighSlot8);
            tabFitting.Controls.Add(ServiceSlot5);
            tabFitting.Controls.Add(HighSlot5);
            tabFitting.Controls.Add(ServiceSlot6);
            tabFitting.Controls.Add(HighSlot6);
            tabFitting.Controls.Add(MidSlot3);
            tabFitting.Controls.Add(HighSlot4);
            tabFitting.Controls.Add(MidSlot4);
            tabFitting.Controls.Add(HighSlot2);
            tabFitting.Controls.Add(MidSlot2);
            tabFitting.Controls.Add(HighSlot3);
            tabFitting.Controls.Add(MidSlot1);
            tabFitting.Controls.Add(HighSlot7);
            tabFitting.Controls.Add(MidSlot5);
            tabFitting.Controls.Add(MidSlot8);
            tabFitting.Controls.Add(HighSlot1);
            tabFitting.Controls.Add(MidSlot6);
            tabFitting.Controls.Add(MidSlot7);
            tabFitting.Controls.Add(StructurePicture);
            tabFitting.Location = new Point(4, 22);
            tabFitting.Name = "tabFitting";
            tabFitting.Padding = new Padding(3);
            tabFitting.Size = new Size(595, 577);
            tabFitting.TabIndex = 0;
            tabFitting.Text = "Fitting";
            tabFitting.UseVisualStyleBackColor = true;
            // 
            // LowSlot3
            // 
            LowSlot3.BackColor = Color.WhiteSmoke;
            LowSlot3.BackgroundImage = (Image)resources.GetObject("LowSlot3.BackgroundImage");
            LowSlot3.BackgroundImageLayout = ImageLayout.Zoom;
            LowSlot3.BorderStyle = BorderStyle.Fixed3D;
            LowSlot3.Location = new Point(518, 151);
            LowSlot3.Name = "LowSlot3";
            LowSlot3.Size = new Size(64, 64);
            LowSlot3.SizeMode = PictureBoxSizeMode.CenterImage;
            LowSlot3.TabIndex = 34;
            LowSlot3.TabStop = false;
            // 
            // RigSlot2
            // 
            RigSlot2.BackColor = Color.WhiteSmoke;
            RigSlot2.BackgroundImage = (Image)resources.GetObject("RigSlot2.BackgroundImage");
            RigSlot2.BackgroundImageLayout = ImageLayout.Zoom;
            RigSlot2.BorderStyle = BorderStyle.Fixed3D;
            RigSlot2.Location = new Point(267, 431);
            RigSlot2.Name = "RigSlot2";
            RigSlot2.Size = new Size(64, 64);
            RigSlot2.SizeMode = PictureBoxSizeMode.CenterImage;
            RigSlot2.TabIndex = 26;
            RigSlot2.TabStop = false;
            // 
            // LowSlot6
            // 
            LowSlot6.BackColor = Color.WhiteSmoke;
            LowSlot6.BackgroundImage = (Image)resources.GetObject("LowSlot6.BackgroundImage");
            LowSlot6.BackgroundImageLayout = ImageLayout.Zoom;
            LowSlot6.BorderStyle = BorderStyle.Fixed3D;
            LowSlot6.Location = new Point(518, 361);
            LowSlot6.Name = "LowSlot6";
            LowSlot6.Size = new Size(64, 64);
            LowSlot6.SizeMode = PictureBoxSizeMode.CenterImage;
            LowSlot6.TabIndex = 33;
            LowSlot6.TabStop = false;
            // 
            // RigSlot3
            // 
            RigSlot3.BackColor = Color.WhiteSmoke;
            RigSlot3.BackgroundImage = (Image)resources.GetObject("RigSlot3.BackgroundImage");
            RigSlot3.BackgroundImageLayout = ImageLayout.Zoom;
            RigSlot3.BorderStyle = BorderStyle.Fixed3D;
            RigSlot3.Location = new Point(337, 431);
            RigSlot3.Name = "RigSlot3";
            RigSlot3.Size = new Size(64, 64);
            RigSlot3.SizeMode = PictureBoxSizeMode.CenterImage;
            RigSlot3.TabIndex = 25;
            RigSlot3.TabStop = false;
            // 
            // LowSlot2
            // 
            LowSlot2.BackColor = Color.WhiteSmoke;
            LowSlot2.BackgroundImage = (Image)resources.GetObject("LowSlot2.BackgroundImage");
            LowSlot2.BackgroundImageLayout = ImageLayout.Zoom;
            LowSlot2.BorderStyle = BorderStyle.Fixed3D;
            LowSlot2.Location = new Point(518, 81);
            LowSlot2.Name = "LowSlot2";
            LowSlot2.Size = new Size(64, 64);
            LowSlot2.SizeMode = PictureBoxSizeMode.CenterImage;
            LowSlot2.TabIndex = 32;
            LowSlot2.TabStop = false;
            // 
            // RigSlot1
            // 
            RigSlot1.BackColor = Color.WhiteSmoke;
            RigSlot1.BackgroundImage = (Image)resources.GetObject("RigSlot1.BackgroundImage");
            RigSlot1.BackgroundImageLayout = ImageLayout.Zoom;
            RigSlot1.BorderStyle = BorderStyle.Fixed3D;
            RigSlot1.Location = new Point(197, 431);
            RigSlot1.Name = "RigSlot1";
            RigSlot1.Size = new Size(64, 64);
            RigSlot1.SizeMode = PictureBoxSizeMode.CenterImage;
            RigSlot1.TabIndex = 6;
            RigSlot1.TabStop = false;
            // 
            // LowSlot7
            // 
            LowSlot7.BackColor = Color.WhiteSmoke;
            LowSlot7.BackgroundImage = (Image)resources.GetObject("LowSlot7.BackgroundImage");
            LowSlot7.BackgroundImageLayout = ImageLayout.Zoom;
            LowSlot7.BorderStyle = BorderStyle.Fixed3D;
            LowSlot7.Location = new Point(518, 431);
            LowSlot7.Name = "LowSlot7";
            LowSlot7.Size = new Size(64, 64);
            LowSlot7.SizeMode = PictureBoxSizeMode.CenterImage;
            LowSlot7.TabIndex = 31;
            LowSlot7.TabStop = false;
            // 
            // ServiceSlot1
            // 
            ServiceSlot1.BackColor = Color.WhiteSmoke;
            ServiceSlot1.BackgroundImage = (Image)resources.GetObject("ServiceSlot1.BackgroundImage");
            ServiceSlot1.BackgroundImageLayout = ImageLayout.Zoom;
            ServiceSlot1.BorderStyle = BorderStyle.Fixed3D;
            ServiceSlot1.Location = new Point(232, 501);
            ServiceSlot1.Name = "ServiceSlot1";
            ServiceSlot1.Size = new Size(64, 64);
            ServiceSlot1.SizeMode = PictureBoxSizeMode.CenterImage;
            ServiceSlot1.TabIndex = 12;
            ServiceSlot1.TabStop = false;
            // 
            // LowSlot8
            // 
            LowSlot8.BackColor = Color.WhiteSmoke;
            LowSlot8.BackgroundImage = (Image)resources.GetObject("LowSlot8.BackgroundImage");
            LowSlot8.BackgroundImageLayout = ImageLayout.Zoom;
            LowSlot8.BorderStyle = BorderStyle.Fixed3D;
            LowSlot8.Location = new Point(518, 501);
            LowSlot8.Name = "LowSlot8";
            LowSlot8.Size = new Size(64, 64);
            LowSlot8.SizeMode = PictureBoxSizeMode.CenterImage;
            LowSlot8.TabIndex = 30;
            LowSlot8.TabStop = false;
            // 
            // ServiceSlot2
            // 
            ServiceSlot2.BackColor = Color.WhiteSmoke;
            ServiceSlot2.BackgroundImage = (Image)resources.GetObject("ServiceSlot2.BackgroundImage");
            ServiceSlot2.BackgroundImageLayout = ImageLayout.Zoom;
            ServiceSlot2.BorderStyle = BorderStyle.Fixed3D;
            ServiceSlot2.Location = new Point(302, 501);
            ServiceSlot2.Name = "ServiceSlot2";
            ServiceSlot2.Size = new Size(64, 64);
            ServiceSlot2.SizeMode = PictureBoxSizeMode.CenterImage;
            ServiceSlot2.TabIndex = 13;
            ServiceSlot2.TabStop = false;
            // 
            // LowSlot4
            // 
            LowSlot4.BackColor = Color.WhiteSmoke;
            LowSlot4.BackgroundImage = (Image)resources.GetObject("LowSlot4.BackgroundImage");
            LowSlot4.BackgroundImageLayout = ImageLayout.Zoom;
            LowSlot4.BorderStyle = BorderStyle.Fixed3D;
            LowSlot4.Location = new Point(518, 221);
            LowSlot4.Name = "LowSlot4";
            LowSlot4.Size = new Size(64, 64);
            LowSlot4.SizeMode = PictureBoxSizeMode.CenterImage;
            LowSlot4.TabIndex = 29;
            LowSlot4.TabStop = false;
            // 
            // ServiceSlot3
            // 
            ServiceSlot3.BackColor = Color.WhiteSmoke;
            ServiceSlot3.BackgroundImage = (Image)resources.GetObject("ServiceSlot3.BackgroundImage");
            ServiceSlot3.BackgroundImageLayout = ImageLayout.Zoom;
            ServiceSlot3.BorderStyle = BorderStyle.Fixed3D;
            ServiceSlot3.Location = new Point(162, 501);
            ServiceSlot3.Name = "ServiceSlot3";
            ServiceSlot3.Size = new Size(64, 64);
            ServiceSlot3.SizeMode = PictureBoxSizeMode.CenterImage;
            ServiceSlot3.TabIndex = 14;
            ServiceSlot3.TabStop = false;
            // 
            // LowSlot5
            // 
            LowSlot5.BackColor = Color.WhiteSmoke;
            LowSlot5.BackgroundImage = (Image)resources.GetObject("LowSlot5.BackgroundImage");
            LowSlot5.BackgroundImageLayout = ImageLayout.Zoom;
            LowSlot5.BorderStyle = BorderStyle.Fixed3D;
            LowSlot5.Location = new Point(518, 291);
            LowSlot5.Name = "LowSlot5";
            LowSlot5.Size = new Size(64, 64);
            LowSlot5.SizeMode = PictureBoxSizeMode.CenterImage;
            LowSlot5.TabIndex = 27;
            LowSlot5.TabStop = false;
            // 
            // ServiceSlot4
            // 
            ServiceSlot4.BackColor = Color.WhiteSmoke;
            ServiceSlot4.BackgroundImage = (Image)resources.GetObject("ServiceSlot4.BackgroundImage");
            ServiceSlot4.BackgroundImageLayout = ImageLayout.Zoom;
            ServiceSlot4.BorderStyle = BorderStyle.Fixed3D;
            ServiceSlot4.Location = new Point(372, 501);
            ServiceSlot4.Name = "ServiceSlot4";
            ServiceSlot4.Size = new Size(64, 64);
            ServiceSlot4.SizeMode = PictureBoxSizeMode.CenterImage;
            ServiceSlot4.TabIndex = 15;
            ServiceSlot4.TabStop = false;
            // 
            // LowSlot1
            // 
            LowSlot1.BackColor = Color.WhiteSmoke;
            LowSlot1.BackgroundImage = (Image)resources.GetObject("LowSlot1.BackgroundImage");
            LowSlot1.BackgroundImageLayout = ImageLayout.Zoom;
            LowSlot1.BorderStyle = BorderStyle.Fixed3D;
            LowSlot1.Location = new Point(518, 11);
            LowSlot1.Name = "LowSlot1";
            LowSlot1.Size = new Size(64, 64);
            LowSlot1.SizeMode = PictureBoxSizeMode.CenterImage;
            LowSlot1.TabIndex = 11;
            LowSlot1.TabStop = false;
            // 
            // HighSlot8
            // 
            HighSlot8.BackColor = Color.WhiteSmoke;
            HighSlot8.BackgroundImage = (Image)resources.GetObject("HighSlot8.BackgroundImage");
            HighSlot8.BackgroundImageLayout = ImageLayout.Zoom;
            HighSlot8.BorderStyle = BorderStyle.Fixed3D;
            HighSlot8.InitialImage = (Image)resources.GetObject("HighSlot8.InitialImage");
            HighSlot8.Location = new Point(442, 81);
            HighSlot8.Name = "HighSlot8";
            HighSlot8.Size = new Size(64, 64);
            HighSlot8.SizeMode = PictureBoxSizeMode.CenterImage;
            HighSlot8.TabIndex = 24;
            HighSlot8.TabStop = false;
            // 
            // ServiceSlot5
            // 
            ServiceSlot5.BackColor = Color.WhiteSmoke;
            ServiceSlot5.BackgroundImage = (Image)resources.GetObject("ServiceSlot5.BackgroundImage");
            ServiceSlot5.BackgroundImageLayout = ImageLayout.Zoom;
            ServiceSlot5.BorderStyle = BorderStyle.Fixed3D;
            ServiceSlot5.Location = new Point(92, 501);
            ServiceSlot5.Name = "ServiceSlot5";
            ServiceSlot5.Size = new Size(64, 64);
            ServiceSlot5.SizeMode = PictureBoxSizeMode.CenterImage;
            ServiceSlot5.TabIndex = 16;
            ServiceSlot5.TabStop = false;
            // 
            // HighSlot5
            // 
            HighSlot5.BackColor = Color.WhiteSmoke;
            HighSlot5.BackgroundImage = (Image)resources.GetObject("HighSlot5.BackgroundImage");
            HighSlot5.BackgroundImageLayout = ImageLayout.Zoom;
            HighSlot5.BorderStyle = BorderStyle.Fixed3D;
            HighSlot5.InitialImage = (Image)resources.GetObject("HighSlot5.InitialImage");
            HighSlot5.Location = new Point(92, 11);
            HighSlot5.Name = "HighSlot5";
            HighSlot5.Size = new Size(64, 64);
            HighSlot5.SizeMode = PictureBoxSizeMode.CenterImage;
            HighSlot5.TabIndex = 23;
            HighSlot5.TabStop = false;
            // 
            // ServiceSlot6
            // 
            ServiceSlot6.BackColor = Color.WhiteSmoke;
            ServiceSlot6.BackgroundImage = (Image)resources.GetObject("ServiceSlot6.BackgroundImage");
            ServiceSlot6.BackgroundImageLayout = ImageLayout.Zoom;
            ServiceSlot6.BorderStyle = BorderStyle.Fixed3D;
            ServiceSlot6.Location = new Point(442, 501);
            ServiceSlot6.Name = "ServiceSlot6";
            ServiceSlot6.Size = new Size(64, 64);
            ServiceSlot6.SizeMode = PictureBoxSizeMode.CenterImage;
            ServiceSlot6.TabIndex = 17;
            ServiceSlot6.TabStop = false;
            // 
            // HighSlot6
            // 
            HighSlot6.BackColor = Color.WhiteSmoke;
            HighSlot6.BackgroundImage = (Image)resources.GetObject("HighSlot6.BackgroundImage");
            HighSlot6.BackgroundImageLayout = ImageLayout.Zoom;
            HighSlot6.BorderStyle = BorderStyle.Fixed3D;
            HighSlot6.InitialImage = (Image)resources.GetObject("HighSlot6.InitialImage");
            HighSlot6.Location = new Point(442, 11);
            HighSlot6.Name = "HighSlot6";
            HighSlot6.Size = new Size(64, 64);
            HighSlot6.SizeMode = PictureBoxSizeMode.CenterImage;
            HighSlot6.TabIndex = 22;
            HighSlot6.TabStop = false;
            // 
            // MidSlot3
            // 
            MidSlot3.BackColor = Color.WhiteSmoke;
            MidSlot3.BackgroundImage = (Image)resources.GetObject("MidSlot3.BackgroundImage");
            MidSlot3.BackgroundImageLayout = ImageLayout.Zoom;
            MidSlot3.BorderStyle = BorderStyle.Fixed3D;
            MidSlot3.Location = new Point(15, 151);
            MidSlot3.Name = "MidSlot3";
            MidSlot3.Size = new Size(64, 64);
            MidSlot3.SizeMode = PictureBoxSizeMode.CenterImage;
            MidSlot3.TabIndex = 41;
            MidSlot3.TabStop = false;
            // 
            // HighSlot4
            // 
            HighSlot4.BackColor = Color.WhiteSmoke;
            HighSlot4.BackgroundImage = (Image)resources.GetObject("HighSlot4.BackgroundImage");
            HighSlot4.BackgroundImageLayout = ImageLayout.Zoom;
            HighSlot4.BorderStyle = BorderStyle.Fixed3D;
            HighSlot4.InitialImage = (Image)resources.GetObject("HighSlot4.InitialImage");
            HighSlot4.Location = new Point(372, 11);
            HighSlot4.Name = "HighSlot4";
            HighSlot4.Size = new Size(64, 64);
            HighSlot4.SizeMode = PictureBoxSizeMode.CenterImage;
            HighSlot4.TabIndex = 21;
            HighSlot4.TabStop = false;
            // 
            // MidSlot4
            // 
            MidSlot4.BackColor = Color.WhiteSmoke;
            MidSlot4.BackgroundImage = (Image)resources.GetObject("MidSlot4.BackgroundImage");
            MidSlot4.BackgroundImageLayout = ImageLayout.Zoom;
            MidSlot4.BorderStyle = BorderStyle.Fixed3D;
            MidSlot4.Location = new Point(15, 221);
            MidSlot4.Name = "MidSlot4";
            MidSlot4.Size = new Size(64, 64);
            MidSlot4.SizeMode = PictureBoxSizeMode.CenterImage;
            MidSlot4.TabIndex = 40;
            MidSlot4.TabStop = false;
            // 
            // HighSlot2
            // 
            HighSlot2.BackColor = Color.WhiteSmoke;
            HighSlot2.BackgroundImage = (Image)resources.GetObject("HighSlot2.BackgroundImage");
            HighSlot2.BackgroundImageLayout = ImageLayout.Zoom;
            HighSlot2.BorderStyle = BorderStyle.Fixed3D;
            HighSlot2.InitialImage = (Image)resources.GetObject("HighSlot2.InitialImage");
            HighSlot2.Location = new Point(302, 11);
            HighSlot2.Name = "HighSlot2";
            HighSlot2.Size = new Size(64, 64);
            HighSlot2.SizeMode = PictureBoxSizeMode.CenterImage;
            HighSlot2.TabIndex = 20;
            HighSlot2.TabStop = false;
            // 
            // MidSlot2
            // 
            MidSlot2.BackColor = Color.WhiteSmoke;
            MidSlot2.BackgroundImage = (Image)resources.GetObject("MidSlot2.BackgroundImage");
            MidSlot2.BackgroundImageLayout = ImageLayout.Zoom;
            MidSlot2.BorderStyle = BorderStyle.Fixed3D;
            MidSlot2.Location = new Point(15, 81);
            MidSlot2.Name = "MidSlot2";
            MidSlot2.Size = new Size(64, 64);
            MidSlot2.SizeMode = PictureBoxSizeMode.CenterImage;
            MidSlot2.TabIndex = 39;
            MidSlot2.TabStop = false;
            // 
            // HighSlot3
            // 
            HighSlot3.BackColor = Color.WhiteSmoke;
            HighSlot3.BackgroundImage = (Image)resources.GetObject("HighSlot3.BackgroundImage");
            HighSlot3.BackgroundImageLayout = ImageLayout.Zoom;
            HighSlot3.BorderStyle = BorderStyle.Fixed3D;
            HighSlot3.InitialImage = (Image)resources.GetObject("HighSlot3.InitialImage");
            HighSlot3.Location = new Point(162, 11);
            HighSlot3.Name = "HighSlot3";
            HighSlot3.Size = new Size(64, 64);
            HighSlot3.SizeMode = PictureBoxSizeMode.CenterImage;
            HighSlot3.TabIndex = 19;
            HighSlot3.TabStop = false;
            // 
            // MidSlot1
            // 
            MidSlot1.BackColor = Color.WhiteSmoke;
            MidSlot1.BackgroundImage = (Image)resources.GetObject("MidSlot1.BackgroundImage");
            MidSlot1.BackgroundImageLayout = ImageLayout.Zoom;
            MidSlot1.BorderStyle = BorderStyle.Fixed3D;
            MidSlot1.Location = new Point(15, 11);
            MidSlot1.Name = "MidSlot1";
            MidSlot1.Size = new Size(64, 64);
            MidSlot1.SizeMode = PictureBoxSizeMode.CenterImage;
            MidSlot1.TabIndex = 10;
            MidSlot1.TabStop = false;
            // 
            // HighSlot7
            // 
            HighSlot7.BackColor = Color.WhiteSmoke;
            HighSlot7.BackgroundImage = (Image)resources.GetObject("HighSlot7.BackgroundImage");
            HighSlot7.BackgroundImageLayout = ImageLayout.Zoom;
            HighSlot7.BorderStyle = BorderStyle.Fixed3D;
            HighSlot7.InitialImage = (Image)resources.GetObject("HighSlot7.InitialImage");
            HighSlot7.Location = new Point(92, 81);
            HighSlot7.Name = "HighSlot7";
            HighSlot7.Size = new Size(64, 64);
            HighSlot7.SizeMode = PictureBoxSizeMode.CenterImage;
            HighSlot7.TabIndex = 18;
            HighSlot7.TabStop = false;
            // 
            // MidSlot5
            // 
            MidSlot5.BackColor = Color.WhiteSmoke;
            MidSlot5.BackgroundImage = (Image)resources.GetObject("MidSlot5.BackgroundImage");
            MidSlot5.BackgroundImageLayout = ImageLayout.Zoom;
            MidSlot5.BorderStyle = BorderStyle.Fixed3D;
            MidSlot5.Location = new Point(15, 291);
            MidSlot5.Name = "MidSlot5";
            MidSlot5.Size = new Size(64, 64);
            MidSlot5.SizeMode = PictureBoxSizeMode.CenterImage;
            MidSlot5.TabIndex = 38;
            MidSlot5.TabStop = false;
            // 
            // MidSlot8
            // 
            MidSlot8.BackColor = Color.WhiteSmoke;
            MidSlot8.BackgroundImage = (Image)resources.GetObject("MidSlot8.BackgroundImage");
            MidSlot8.BackgroundImageLayout = ImageLayout.Zoom;
            MidSlot8.BorderStyle = BorderStyle.Fixed3D;
            MidSlot8.Location = new Point(15, 501);
            MidSlot8.Name = "MidSlot8";
            MidSlot8.Size = new Size(64, 64);
            MidSlot8.SizeMode = PictureBoxSizeMode.CenterImage;
            MidSlot8.TabIndex = 35;
            MidSlot8.TabStop = false;
            // 
            // HighSlot1
            // 
            HighSlot1.BackColor = Color.WhiteSmoke;
            HighSlot1.BackgroundImage = (Image)resources.GetObject("HighSlot1.BackgroundImage");
            HighSlot1.BackgroundImageLayout = ImageLayout.Zoom;
            HighSlot1.BorderStyle = BorderStyle.Fixed3D;
            HighSlot1.InitialImage = (Image)resources.GetObject("HighSlot1.InitialImage");
            HighSlot1.Location = new Point(232, 11);
            HighSlot1.Name = "HighSlot1";
            HighSlot1.Size = new Size(64, 64);
            HighSlot1.SizeMode = PictureBoxSizeMode.CenterImage;
            HighSlot1.TabIndex = 5;
            HighSlot1.TabStop = false;
            // 
            // MidSlot6
            // 
            MidSlot6.BackColor = Color.WhiteSmoke;
            MidSlot6.BackgroundImage = (Image)resources.GetObject("MidSlot6.BackgroundImage");
            MidSlot6.BackgroundImageLayout = ImageLayout.Zoom;
            MidSlot6.BorderStyle = BorderStyle.Fixed3D;
            MidSlot6.Location = new Point(15, 361);
            MidSlot6.Name = "MidSlot6";
            MidSlot6.Size = new Size(64, 64);
            MidSlot6.SizeMode = PictureBoxSizeMode.CenterImage;
            MidSlot6.TabIndex = 37;
            MidSlot6.TabStop = false;
            // 
            // MidSlot7
            // 
            MidSlot7.BackColor = Color.WhiteSmoke;
            MidSlot7.BackgroundImage = (Image)resources.GetObject("MidSlot7.BackgroundImage");
            MidSlot7.BackgroundImageLayout = ImageLayout.Zoom;
            MidSlot7.BorderStyle = BorderStyle.Fixed3D;
            MidSlot7.Location = new Point(15, 431);
            MidSlot7.Name = "MidSlot7";
            MidSlot7.Size = new Size(64, 64);
            MidSlot7.SizeMode = PictureBoxSizeMode.CenterImage;
            MidSlot7.TabIndex = 36;
            MidSlot7.TabStop = false;
            // 
            // StructurePicture
            // 
            StructurePicture.BackColor = Color.Black;
            StructurePicture.BackgroundImageLayout = ImageLayout.Center;
            StructurePicture.BorderStyle = BorderStyle.Fixed3D;
            StructurePicture.Location = new Point(5, 6);
            StructurePicture.Name = "StructurePicture";
            StructurePicture.Size = new Size(586, 566);
            StructurePicture.SizeMode = PictureBoxSizeMode.CenterImage;
            StructurePicture.TabIndex = 9;
            StructurePicture.TabStop = false;
            // 
            // tabFuelandBonuses
            // 
            tabFuelandBonuses.Controls.Add(gbFacilityBonuses);
            tabFuelandBonuses.Controls.Add(gbFuelBlocks);
            tabFuelandBonuses.Location = new Point(4, 22);
            tabFuelandBonuses.Name = "tabFuelandBonuses";
            tabFuelandBonuses.Padding = new Padding(3);
            tabFuelandBonuses.Size = new Size(595, 577);
            tabFuelandBonuses.TabIndex = 1;
            tabFuelandBonuses.Text = "Fuel Settings and Bonuses";
            tabFuelandBonuses.UseVisualStyleBackColor = true;
            // 
            // gbFacilityBonuses
            // 
            gbFacilityBonuses.Controls.Add(btnBonusPopout);
            gbFacilityBonuses.Controls.Add(lstUpwellStructureBonuses);
            gbFacilityBonuses.Location = new Point(6, 10);
            gbFacilityBonuses.Name = "gbFacilityBonuses";
            gbFacilityBonuses.Size = new Size(583, 145);
            gbFacilityBonuses.TabIndex = 0;
            gbFacilityBonuses.TabStop = false;
            gbFacilityBonuses.Text = "Facility Bonuses";
            // 
            // btnBonusPopout
            // 
            btnBonusPopout.FlatAppearance.BorderSize = 0;
            btnBonusPopout.FlatStyle = FlatStyle.Flat;
            btnBonusPopout.ForeColor = SystemColors.ControlText;
            btnBonusPopout.Image = (Image)resources.GetObject("btnBonusPopout.Image");
            btnBonusPopout.Location = new Point(551, 20);
            btnBonusPopout.Name = "btnBonusPopout";
            btnBonusPopout.Size = new Size(18, 18);
            btnBonusPopout.TabIndex = 0;
            btnBonusPopout.UseVisualStyleBackColor = true;
            // 
            // lstUpwellStructureBonuses
            // 
            lstUpwellStructureBonuses.Columns.AddRange(new ColumnHeader[] { BonusAppliesTo, Activity, Bonuses, Source });
            lstUpwellStructureBonuses.FullRowSelect = true;
            lstUpwellStructureBonuses.GridLines = true;
            lstUpwellStructureBonuses.HideSelection = false;
            lstUpwellStructureBonuses.Location = new Point(12, 19);
            lstUpwellStructureBonuses.MultiSelect = false;
            lstUpwellStructureBonuses.Name = "lstUpwellStructureBonuses";
            lstUpwellStructureBonuses.Size = new Size(560, 116);
            lstUpwellStructureBonuses.TabIndex = 0;
            lstUpwellStructureBonuses.TabStop = false;
            lstUpwellStructureBonuses.UseCompatibleStateImageBehavior = false;
            lstUpwellStructureBonuses.View = View.Details;
            // 
            // BonusAppliesTo
            // 
            BonusAppliesTo.Text = "Bonus Applies to";
            BonusAppliesTo.Width = 125;
            // 
            // Activity
            // 
            Activity.Text = "Activity";
            Activity.Width = 100;
            // 
            // Bonuses
            // 
            Bonuses.Text = "Bonuses";
            Bonuses.Width = 200;
            // 
            // Source
            // 
            Source.Text = "Bonus Source";
            Source.Width = 131;
            // 
            // gbFuelBlocks
            // 
            gbFuelBlocks.Controls.Add(btnRefreshPrices);
            gbFuelBlocks.Controls.Add(gbFuelPrices);
            gbFuelBlocks.Controls.Add(btnSaveFuelBlockInfo);
            gbFuelBlocks.Controls.Add(gbFuelBlocks2);
            gbFuelBlocks.Controls.Add(gbFuelBlockOptions);
            gbFuelBlocks.Controls.Add(btnSavePrices);
            gbFuelBlocks.Controls.Add(btnUpdateBuildCost);
            gbFuelBlocks.Location = new Point(6, 161);
            gbFuelBlocks.Name = "gbFuelBlocks";
            gbFuelBlocks.Size = new Size(583, 410);
            gbFuelBlocks.TabIndex = 0;
            gbFuelBlocks.TabStop = false;
            gbFuelBlocks.Text = "Fuel Blocks";
            // 
            // btnRefreshPrices
            // 
            btnRefreshPrices.Location = new Point(444, 19);
            btnRefreshPrices.Name = "btnRefreshPrices";
            btnRefreshPrices.Size = new Size(125, 34);
            btnRefreshPrices.TabIndex = 6;
            btnRefreshPrices.Text = "Refresh Prices";
            btnRefreshPrices.UseVisualStyleBackColor = true;
            // 
            // gbFuelPrices
            // 
            gbFuelPrices.Controls.Add(lblHydrogenIsotopes);
            gbFuelPrices.Controls.Add(lblHeavyWater);
            gbFuelPrices.Controls.Add(lblStrontiumClathrates);
            gbFuelPrices.Controls.Add(lblEnrichedUranium);
            gbFuelPrices.Controls.Add(lblOxygen);
            gbFuelPrices.Controls.Add(lblCoolant);
            gbFuelPrices.Controls.Add(lblLiquidOzone);
            gbFuelPrices.Controls.Add(lblMechanicalParts);
            gbFuelPrices.Controls.Add(lblRobotics);
            gbFuelPrices.Controls.Add(lblNitrogenIsotopes);
            gbFuelPrices.Controls.Add(lblHeliumIsotopes);
            gbFuelPrices.Controls.Add(lblOxygenIsotopes);
            gbFuelPrices.Controls.Add(picHeliumIsotopes);
            gbFuelPrices.Controls.Add(txtMechanicalParts);
            gbFuelPrices.Controls.Add(txtNitrogenIsotopes);
            gbFuelPrices.Controls.Add(txtLiquidOzone);
            gbFuelPrices.Controls.Add(txtCoolant);
            gbFuelPrices.Controls.Add(txtOxygen);
            gbFuelPrices.Controls.Add(txtEnrichedUranium);
            gbFuelPrices.Controls.Add(txtStrontiumClathrates);
            gbFuelPrices.Controls.Add(picCoolant);
            gbFuelPrices.Controls.Add(picOxygen);
            gbFuelPrices.Controls.Add(txtHeavyWater);
            gbFuelPrices.Controls.Add(picNitrogenIsotopes);
            gbFuelPrices.Controls.Add(txtRobotics);
            gbFuelPrices.Controls.Add(picHydrogenIsotopes);
            gbFuelPrices.Controls.Add(picEnrichedUranium);
            gbFuelPrices.Controls.Add(picOxygenIsotopes);
            gbFuelPrices.Controls.Add(picMechanicalParts);
            gbFuelPrices.Controls.Add(picRobotics);
            gbFuelPrices.Controls.Add(picStrontiumClathrates);
            gbFuelPrices.Controls.Add(txtOxygenIsotopes);
            gbFuelPrices.Controls.Add(picLiquidOzone);
            gbFuelPrices.Controls.Add(picHeavyWater);
            gbFuelPrices.Controls.Add(txtHydrogenIsotopes);
            gbFuelPrices.Controls.Add(txtHeliumIsotopes);
            gbFuelPrices.Location = new Point(13, 219);
            gbFuelPrices.Name = "gbFuelPrices";
            gbFuelPrices.Size = new Size(420, 191);
            gbFuelPrices.TabIndex = 1;
            gbFuelPrices.TabStop = false;
            // 
            // lblHydrogenIsotopes
            // 
            lblHydrogenIsotopes.Location = new Point(174, 12);
            lblHydrogenIsotopes.Name = "lblHydrogenIsotopes";
            lblHydrogenIsotopes.Size = new Size(101, 16);
            lblHydrogenIsotopes.TabIndex = 2;
            lblHydrogenIsotopes.Text = "Hydrogen Isotopes";
            lblHydrogenIsotopes.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHeavyWater
            // 
            lblHeavyWater.Location = new Point(315, 12);
            lblHeavyWater.Name = "lblHeavyWater";
            lblHeavyWater.Size = new Size(93, 16);
            lblHeavyWater.TabIndex = 4;
            lblHeavyWater.Text = "Heavy Water";
            lblHeavyWater.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblStrontiumClathrates
            // 
            lblStrontiumClathrates.Location = new Point(311, 55);
            lblStrontiumClathrates.Name = "lblStrontiumClathrates";
            lblStrontiumClathrates.Size = new Size(101, 16);
            lblStrontiumClathrates.TabIndex = 10;
            lblStrontiumClathrates.Text = "Strontium Clathrates";
            lblStrontiumClathrates.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblEnrichedUranium
            // 
            lblEnrichedUranium.Location = new Point(43, 141);
            lblEnrichedUranium.Name = "lblEnrichedUranium";
            lblEnrichedUranium.Size = new Size(93, 16);
            lblEnrichedUranium.TabIndex = 18;
            lblEnrichedUranium.Text = "Enriched Uranium";
            lblEnrichedUranium.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblOxygen
            // 
            lblOxygen.Location = new Point(178, 141);
            lblOxygen.Name = "lblOxygen";
            lblOxygen.Size = new Size(93, 16);
            lblOxygen.TabIndex = 20;
            lblOxygen.Text = "Oxygen";
            lblOxygen.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCoolant
            // 
            lblCoolant.Location = new Point(315, 98);
            lblCoolant.Name = "lblCoolant";
            lblCoolant.Size = new Size(93, 16);
            lblCoolant.TabIndex = 16;
            lblCoolant.Text = "Coolant";
            lblCoolant.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblLiquidOzone
            // 
            lblLiquidOzone.Location = new Point(313, 141);
            lblLiquidOzone.Name = "lblLiquidOzone";
            lblLiquidOzone.Size = new Size(93, 16);
            lblLiquidOzone.TabIndex = 22;
            lblLiquidOzone.Text = "Liquid Ozone";
            lblLiquidOzone.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMechanicalParts
            // 
            lblMechanicalParts.Location = new Point(43, 98);
            lblMechanicalParts.Name = "lblMechanicalParts";
            lblMechanicalParts.Size = new Size(93, 16);
            lblMechanicalParts.TabIndex = 12;
            lblMechanicalParts.Text = "Mechanical Parts";
            lblMechanicalParts.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblRobotics
            // 
            lblRobotics.Location = new Point(178, 98);
            lblRobotics.Name = "lblRobotics";
            lblRobotics.Size = new Size(93, 16);
            lblRobotics.TabIndex = 14;
            lblRobotics.Text = "Robotics";
            lblRobotics.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNitrogenIsotopes
            // 
            lblNitrogenIsotopes.Location = new Point(43, 55);
            lblNitrogenIsotopes.Name = "lblNitrogenIsotopes";
            lblNitrogenIsotopes.Size = new Size(93, 16);
            lblNitrogenIsotopes.TabIndex = 6;
            lblNitrogenIsotopes.Text = "Nitrogen Isotopes";
            lblNitrogenIsotopes.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHeliumIsotopes
            // 
            lblHeliumIsotopes.Location = new Point(43, 12);
            lblHeliumIsotopes.Name = "lblHeliumIsotopes";
            lblHeliumIsotopes.Size = new Size(93, 16);
            lblHeliumIsotopes.TabIndex = 0;
            lblHeliumIsotopes.Text = "Helium Isotopes";
            lblHeliumIsotopes.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblOxygenIsotopes
            // 
            lblOxygenIsotopes.Location = new Point(178, 55);
            lblOxygenIsotopes.Name = "lblOxygenIsotopes";
            lblOxygenIsotopes.Size = new Size(93, 16);
            lblOxygenIsotopes.TabIndex = 8;
            lblOxygenIsotopes.Text = "Oxygen Isotopes";
            lblOxygenIsotopes.TextAlign = ContentAlignment.TopCenter;
            // 
            // picHeliumIsotopes
            // 
            picHeliumIsotopes.BackColor = Color.Transparent;
            picHeliumIsotopes.Location = new Point(8, 22);
            picHeliumIsotopes.Name = "picHeliumIsotopes";
            picHeliumIsotopes.Size = new Size(32, 32);
            picHeliumIsotopes.TabIndex = 290;
            picHeliumIsotopes.TabStop = false;
            // 
            // txtMechanicalParts
            // 
            txtMechanicalParts.Location = new Point(43, 114);
            txtMechanicalParts.Name = "txtMechanicalParts";
            txtMechanicalParts.Size = new Size(93, 20);
            txtMechanicalParts.TabIndex = 13;
            txtMechanicalParts.TextAlign = HorizontalAlignment.Right;
            // 
            // txtNitrogenIsotopes
            // 
            txtNitrogenIsotopes.Location = new Point(43, 71);
            txtNitrogenIsotopes.Name = "txtNitrogenIsotopes";
            txtNitrogenIsotopes.Size = new Size(93, 20);
            txtNitrogenIsotopes.TabIndex = 7;
            txtNitrogenIsotopes.TextAlign = HorizontalAlignment.Right;
            // 
            // txtLiquidOzone
            // 
            txtLiquidOzone.Location = new Point(313, 157);
            txtLiquidOzone.Name = "txtLiquidOzone";
            txtLiquidOzone.Size = new Size(93, 20);
            txtLiquidOzone.TabIndex = 23;
            txtLiquidOzone.TextAlign = HorizontalAlignment.Right;
            // 
            // txtCoolant
            // 
            txtCoolant.Location = new Point(315, 114);
            txtCoolant.Name = "txtCoolant";
            txtCoolant.Size = new Size(93, 20);
            txtCoolant.TabIndex = 17;
            txtCoolant.TextAlign = HorizontalAlignment.Right;
            // 
            // txtOxygen
            // 
            txtOxygen.Location = new Point(178, 157);
            txtOxygen.Name = "txtOxygen";
            txtOxygen.Size = new Size(93, 20);
            txtOxygen.TabIndex = 21;
            txtOxygen.TextAlign = HorizontalAlignment.Right;
            // 
            // txtEnrichedUranium
            // 
            txtEnrichedUranium.Location = new Point(43, 157);
            txtEnrichedUranium.Name = "txtEnrichedUranium";
            txtEnrichedUranium.Size = new Size(93, 20);
            txtEnrichedUranium.TabIndex = 19;
            txtEnrichedUranium.TextAlign = HorizontalAlignment.Right;
            // 
            // txtStrontiumClathrates
            // 
            txtStrontiumClathrates.Location = new Point(315, 71);
            txtStrontiumClathrates.Name = "txtStrontiumClathrates";
            txtStrontiumClathrates.Size = new Size(93, 20);
            txtStrontiumClathrates.TabIndex = 11;
            txtStrontiumClathrates.TextAlign = HorizontalAlignment.Right;
            // 
            // picCoolant
            // 
            picCoolant.BackColor = Color.Transparent;
            picCoolant.Location = new Point(277, 108);
            picCoolant.Name = "picCoolant";
            picCoolant.Size = new Size(32, 32);
            picCoolant.TabIndex = 291;
            picCoolant.TabStop = false;
            // 
            // picOxygen
            // 
            picOxygen.BackColor = Color.Transparent;
            picOxygen.Location = new Point(142, 151);
            picOxygen.Name = "picOxygen";
            picOxygen.Size = new Size(32, 32);
            picOxygen.TabIndex = 313;
            picOxygen.TabStop = false;
            // 
            // txtHeavyWater
            // 
            txtHeavyWater.Location = new Point(315, 28);
            txtHeavyWater.Name = "txtHeavyWater";
            txtHeavyWater.Size = new Size(93, 20);
            txtHeavyWater.TabIndex = 5;
            txtHeavyWater.TextAlign = HorizontalAlignment.Right;
            // 
            // picNitrogenIsotopes
            // 
            picNitrogenIsotopes.BackColor = Color.Transparent;
            picNitrogenIsotopes.Location = new Point(8, 65);
            picNitrogenIsotopes.Name = "picNitrogenIsotopes";
            picNitrogenIsotopes.Size = new Size(32, 32);
            picNitrogenIsotopes.TabIndex = 292;
            picNitrogenIsotopes.TabStop = false;
            // 
            // txtRobotics
            // 
            txtRobotics.Location = new Point(178, 114);
            txtRobotics.Name = "txtRobotics";
            txtRobotics.Size = new Size(93, 20);
            txtRobotics.TabIndex = 15;
            txtRobotics.TextAlign = HorizontalAlignment.Right;
            // 
            // picHydrogenIsotopes
            // 
            picHydrogenIsotopes.BackColor = Color.Transparent;
            picHydrogenIsotopes.Location = new Point(142, 22);
            picHydrogenIsotopes.Name = "picHydrogenIsotopes";
            picHydrogenIsotopes.Size = new Size(32, 32);
            picHydrogenIsotopes.TabIndex = 306;
            picHydrogenIsotopes.TabStop = false;
            // 
            // picEnrichedUranium
            // 
            picEnrichedUranium.BackColor = Color.Transparent;
            picEnrichedUranium.Location = new Point(9, 151);
            picEnrichedUranium.Name = "picEnrichedUranium";
            picEnrichedUranium.Size = new Size(32, 32);
            picEnrichedUranium.TabIndex = 293;
            picEnrichedUranium.TabStop = false;
            // 
            // picOxygenIsotopes
            // 
            picOxygenIsotopes.BackColor = Color.Transparent;
            picOxygenIsotopes.Location = new Point(142, 65);
            picOxygenIsotopes.Name = "picOxygenIsotopes";
            picOxygenIsotopes.Size = new Size(32, 32);
            picOxygenIsotopes.TabIndex = 307;
            picOxygenIsotopes.TabStop = false;
            // 
            // picMechanicalParts
            // 
            picMechanicalParts.BackColor = Color.Transparent;
            picMechanicalParts.Location = new Point(8, 108);
            picMechanicalParts.Name = "picMechanicalParts";
            picMechanicalParts.Size = new Size(32, 32);
            picMechanicalParts.TabIndex = 294;
            picMechanicalParts.TabStop = false;
            // 
            // picRobotics
            // 
            picRobotics.BackColor = Color.Transparent;
            picRobotics.Location = new Point(142, 108);
            picRobotics.Name = "picRobotics";
            picRobotics.Size = new Size(32, 32);
            picRobotics.TabIndex = 310;
            picRobotics.TabStop = false;
            // 
            // picStrontiumClathrates
            // 
            picStrontiumClathrates.BackColor = Color.Transparent;
            picStrontiumClathrates.Location = new Point(277, 65);
            picStrontiumClathrates.Name = "picStrontiumClathrates";
            picStrontiumClathrates.Size = new Size(32, 32);
            picStrontiumClathrates.TabIndex = 295;
            picStrontiumClathrates.TabStop = false;
            // 
            // txtOxygenIsotopes
            // 
            txtOxygenIsotopes.Location = new Point(178, 71);
            txtOxygenIsotopes.Name = "txtOxygenIsotopes";
            txtOxygenIsotopes.Size = new Size(93, 20);
            txtOxygenIsotopes.TabIndex = 9;
            txtOxygenIsotopes.TextAlign = HorizontalAlignment.Right;
            // 
            // picLiquidOzone
            // 
            picLiquidOzone.BackColor = Color.Transparent;
            picLiquidOzone.Location = new Point(277, 151);
            picLiquidOzone.Name = "picLiquidOzone";
            picLiquidOzone.Size = new Size(32, 32);
            picLiquidOzone.TabIndex = 296;
            picLiquidOzone.TabStop = false;
            // 
            // picHeavyWater
            // 
            picHeavyWater.BackColor = Color.Transparent;
            picHeavyWater.Location = new Point(277, 22);
            picHeavyWater.Name = "picHeavyWater";
            picHeavyWater.Size = new Size(32, 32);
            picHeavyWater.TabIndex = 297;
            picHeavyWater.TabStop = false;
            // 
            // txtHydrogenIsotopes
            // 
            txtHydrogenIsotopes.Location = new Point(178, 28);
            txtHydrogenIsotopes.Name = "txtHydrogenIsotopes";
            txtHydrogenIsotopes.Size = new Size(93, 20);
            txtHydrogenIsotopes.TabIndex = 3;
            txtHydrogenIsotopes.TextAlign = HorizontalAlignment.Right;
            // 
            // txtHeliumIsotopes
            // 
            txtHeliumIsotopes.Location = new Point(43, 28);
            txtHeliumIsotopes.Name = "txtHeliumIsotopes";
            txtHeliumIsotopes.Size = new Size(93, 20);
            txtHeliumIsotopes.TabIndex = 1;
            txtHeliumIsotopes.TextAlign = HorizontalAlignment.Right;
            // 
            // btnSaveFuelBlockInfo
            // 
            btnSaveFuelBlockInfo.Location = new Point(444, 133);
            btnSaveFuelBlockInfo.Name = "btnSaveFuelBlockInfo";
            btnSaveFuelBlockInfo.Size = new Size(125, 34);
            btnSaveFuelBlockInfo.TabIndex = 4;
            btnSaveFuelBlockInfo.Text = "Save Fuel Block Info";
            btnSaveFuelBlockInfo.UseVisualStyleBackColor = true;
            // 
            // gbFuelBlocks2
            // 
            gbFuelBlocks2.Controls.Add(picHeliumFuelBlock);
            gbFuelBlocks2.Controls.Add(lblHeliumFuelBlock);
            gbFuelBlocks2.Controls.Add(lblHeliumFuelBlockBPME);
            gbFuelBlocks2.Controls.Add(txtHeliumFuelBlockBPME);
            gbFuelBlocks2.Controls.Add(lblHeliumFuelBlockBuy);
            gbFuelBlocks2.Controls.Add(lblHeliumFuelBlockBuild);
            gbFuelBlocks2.Controls.Add(txtHeliumFuelBlockBuyPrice);
            gbFuelBlocks2.Controls.Add(lblHeliumFuelBlockBuildPrice);
            gbFuelBlocks2.Controls.Add(lblHydrogenFuelBlock);
            gbFuelBlocks2.Controls.Add(lblHydrogenFuelBlockBPME);
            gbFuelBlocks2.Controls.Add(picHydrogenFuelBlock);
            gbFuelBlocks2.Controls.Add(txtHydrogenFuelBlockBPME);
            gbFuelBlocks2.Controls.Add(lblHydrogenBlockBuy);
            gbFuelBlocks2.Controls.Add(lblHydrogenFuelBlockBuild);
            gbFuelBlocks2.Controls.Add(txtHydrogenFuelBlockBuyPrice);
            gbFuelBlocks2.Controls.Add(lblHydrogenFuelBlockBuildPrice);
            gbFuelBlocks2.Controls.Add(lblNitrogenFuelBlock);
            gbFuelBlocks2.Controls.Add(lblNitrogenFuelBlockBPME);
            gbFuelBlocks2.Controls.Add(picNitrogenFuelBlock);
            gbFuelBlocks2.Controls.Add(txtNitrogenFuelBlockBPME);
            gbFuelBlocks2.Controls.Add(lblNitrogenFuelBlockBuy);
            gbFuelBlocks2.Controls.Add(lblNitrogenFuelBlockBuild);
            gbFuelBlocks2.Controls.Add(txtNitrogenFuelBlockBuyPrice);
            gbFuelBlocks2.Controls.Add(lblNitrogenFuelBlockBuildPrice);
            gbFuelBlocks2.Controls.Add(lblOxygenFuelBlock);
            gbFuelBlocks2.Controls.Add(lblOxygenFuelBlockBPME);
            gbFuelBlocks2.Controls.Add(picOxygenFuelBlock);
            gbFuelBlocks2.Controls.Add(txtOxygenFuelBlockBPME);
            gbFuelBlocks2.Controls.Add(lblOxygenFuelBlockBuy);
            gbFuelBlocks2.Controls.Add(lblOxygenFuelBlockBuild);
            gbFuelBlocks2.Controls.Add(txtOxygenFuelBlockBuyPrice);
            gbFuelBlocks2.Controls.Add(lblOxygenFuelBlockBuildPrice);
            gbFuelBlocks2.Location = new Point(13, 14);
            gbFuelBlocks2.Name = "gbFuelBlocks2";
            gbFuelBlocks2.Size = new Size(420, 205);
            gbFuelBlocks2.TabIndex = 0;
            gbFuelBlocks2.TabStop = false;
            // 
            // picHeliumFuelBlock
            // 
            picHeliumFuelBlock.BackColor = Color.Transparent;
            picHeliumFuelBlock.Location = new Point(32, 32);
            picHeliumFuelBlock.Name = "picHeliumFuelBlock";
            picHeliumFuelBlock.Size = new Size(32, 32);
            picHeliumFuelBlock.TabIndex = 222;
            picHeliumFuelBlock.TabStop = false;
            // 
            // lblHeliumFuelBlock
            // 
            lblHeliumFuelBlock.Location = new Point(103, 18);
            lblHeliumFuelBlock.Name = "lblHeliumFuelBlock";
            lblHeliumFuelBlock.Size = new Size(76, 13);
            lblHeliumFuelBlock.TabIndex = 0;
            lblHeliumFuelBlock.Text = "Helium";
            lblHeliumFuelBlock.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHeliumFuelBlockBPME
            // 
            lblHeliumFuelBlockBPME.Location = new Point(38, 79);
            lblHeliumFuelBlockBPME.Name = "lblHeliumFuelBlockBPME";
            lblHeliumFuelBlockBPME.Size = new Size(97, 15);
            lblHeliumFuelBlockBPME.TabIndex = 5;
            lblHeliumFuelBlockBPME.Text = "Fuel Block BP ME:";
            // 
            // txtHeliumFuelBlockBPME
            // 
            txtHeliumFuelBlockBPME.Location = new Point(141, 76);
            txtHeliumFuelBlockBPME.Name = "txtHeliumFuelBlockBPME";
            txtHeliumFuelBlockBPME.Size = new Size(41, 20);
            txtHeliumFuelBlockBPME.TabIndex = 6;
            txtHeliumFuelBlockBPME.Text = "0";
            txtHeliumFuelBlockBPME.TextAlign = HorizontalAlignment.Right;
            // 
            // lblHeliumFuelBlockBuy
            // 
            lblHeliumFuelBlockBuy.AutoSize = true;
            lblHeliumFuelBlockBuy.Location = new Point(76, 36);
            lblHeliumFuelBlockBuy.Name = "lblHeliumFuelBlockBuy";
            lblHeliumFuelBlockBuy.Size = new Size(28, 13);
            lblHeliumFuelBlockBuy.TabIndex = 1;
            lblHeliumFuelBlockBuy.Text = "Buy:";
            lblHeliumFuelBlockBuy.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHeliumFuelBlockBuild
            // 
            lblHeliumFuelBlockBuild.AutoSize = true;
            lblHeliumFuelBlockBuild.Location = new Point(71, 57);
            lblHeliumFuelBlockBuild.Name = "lblHeliumFuelBlockBuild";
            lblHeliumFuelBlockBuild.Size = new Size(33, 13);
            lblHeliumFuelBlockBuild.TabIndex = 3;
            lblHeliumFuelBlockBuild.Text = "Build:";
            lblHeliumFuelBlockBuild.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtHeliumFuelBlockBuyPrice
            // 
            txtHeliumFuelBlockBuyPrice.Location = new Point(106, 32);
            txtHeliumFuelBlockBuyPrice.Name = "txtHeliumFuelBlockBuyPrice";
            txtHeliumFuelBlockBuyPrice.Size = new Size(76, 20);
            txtHeliumFuelBlockBuyPrice.TabIndex = 2;
            txtHeliumFuelBlockBuyPrice.Text = "0.00";
            txtHeliumFuelBlockBuyPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // lblHeliumFuelBlockBuildPrice
            // 
            lblHeliumFuelBlockBuildPrice.BorderStyle = BorderStyle.FixedSingle;
            lblHeliumFuelBlockBuildPrice.Location = new Point(106, 54);
            lblHeliumFuelBlockBuildPrice.Name = "lblHeliumFuelBlockBuildPrice";
            lblHeliumFuelBlockBuildPrice.Size = new Size(76, 20);
            lblHeliumFuelBlockBuildPrice.TabIndex = 4;
            lblHeliumFuelBlockBuildPrice.Text = "0.00";
            lblHeliumFuelBlockBuildPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHydrogenFuelBlock
            // 
            lblHydrogenFuelBlock.Location = new Point(310, 18);
            lblHydrogenFuelBlock.Name = "lblHydrogenFuelBlock";
            lblHydrogenFuelBlock.Size = new Size(76, 13);
            lblHydrogenFuelBlock.TabIndex = 7;
            lblHydrogenFuelBlock.Text = "Hydrogen";
            lblHydrogenFuelBlock.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHydrogenFuelBlockBPME
            // 
            lblHydrogenFuelBlockBPME.Location = new Point(245, 79);
            lblHydrogenFuelBlockBPME.Name = "lblHydrogenFuelBlockBPME";
            lblHydrogenFuelBlockBPME.Size = new Size(97, 15);
            lblHydrogenFuelBlockBPME.TabIndex = 12;
            lblHydrogenFuelBlockBPME.Text = "Fuel Block BP ME:";
            // 
            // picHydrogenFuelBlock
            // 
            picHydrogenFuelBlock.BackColor = Color.Transparent;
            picHydrogenFuelBlock.Location = new Point(240, 32);
            picHydrogenFuelBlock.Name = "picHydrogenFuelBlock";
            picHydrogenFuelBlock.Size = new Size(32, 32);
            picHydrogenFuelBlock.TabIndex = 247;
            picHydrogenFuelBlock.TabStop = false;
            // 
            // txtHydrogenFuelBlockBPME
            // 
            txtHydrogenFuelBlockBPME.Location = new Point(348, 76);
            txtHydrogenFuelBlockBPME.Name = "txtHydrogenFuelBlockBPME";
            txtHydrogenFuelBlockBPME.Size = new Size(41, 20);
            txtHydrogenFuelBlockBPME.TabIndex = 13;
            txtHydrogenFuelBlockBPME.Text = "0";
            txtHydrogenFuelBlockBPME.TextAlign = HorizontalAlignment.Right;
            // 
            // lblHydrogenBlockBuy
            // 
            lblHydrogenBlockBuy.AutoSize = true;
            lblHydrogenBlockBuy.Location = new Point(283, 36);
            lblHydrogenBlockBuy.Name = "lblHydrogenBlockBuy";
            lblHydrogenBlockBuy.Size = new Size(28, 13);
            lblHydrogenBlockBuy.TabIndex = 8;
            lblHydrogenBlockBuy.Text = "Buy:";
            lblHydrogenBlockBuy.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHydrogenFuelBlockBuild
            // 
            lblHydrogenFuelBlockBuild.AutoSize = true;
            lblHydrogenFuelBlockBuild.Location = new Point(278, 57);
            lblHydrogenFuelBlockBuild.Name = "lblHydrogenFuelBlockBuild";
            lblHydrogenFuelBlockBuild.Size = new Size(33, 13);
            lblHydrogenFuelBlockBuild.TabIndex = 10;
            lblHydrogenFuelBlockBuild.Text = "Build:";
            lblHydrogenFuelBlockBuild.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtHydrogenFuelBlockBuyPrice
            // 
            txtHydrogenFuelBlockBuyPrice.Location = new Point(313, 32);
            txtHydrogenFuelBlockBuyPrice.Name = "txtHydrogenFuelBlockBuyPrice";
            txtHydrogenFuelBlockBuyPrice.Size = new Size(76, 20);
            txtHydrogenFuelBlockBuyPrice.TabIndex = 9;
            txtHydrogenFuelBlockBuyPrice.Text = "0.00";
            txtHydrogenFuelBlockBuyPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // lblHydrogenFuelBlockBuildPrice
            // 
            lblHydrogenFuelBlockBuildPrice.BorderStyle = BorderStyle.FixedSingle;
            lblHydrogenFuelBlockBuildPrice.Location = new Point(313, 54);
            lblHydrogenFuelBlockBuildPrice.Name = "lblHydrogenFuelBlockBuildPrice";
            lblHydrogenFuelBlockBuildPrice.Size = new Size(76, 20);
            lblHydrogenFuelBlockBuildPrice.TabIndex = 11;
            lblHydrogenFuelBlockBuildPrice.Text = "0.00";
            lblHydrogenFuelBlockBuildPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNitrogenFuelBlock
            // 
            lblNitrogenFuelBlock.Location = new Point(102, 108);
            lblNitrogenFuelBlock.Name = "lblNitrogenFuelBlock";
            lblNitrogenFuelBlock.Size = new Size(76, 13);
            lblNitrogenFuelBlock.TabIndex = 14;
            lblNitrogenFuelBlock.Text = "Nitrogen";
            lblNitrogenFuelBlock.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNitrogenFuelBlockBPME
            // 
            lblNitrogenFuelBlockBPME.Location = new Point(37, 169);
            lblNitrogenFuelBlockBPME.Name = "lblNitrogenFuelBlockBPME";
            lblNitrogenFuelBlockBPME.Size = new Size(97, 15);
            lblNitrogenFuelBlockBPME.TabIndex = 19;
            lblNitrogenFuelBlockBPME.Text = "Fuel Block BP ME:";
            // 
            // picNitrogenFuelBlock
            // 
            picNitrogenFuelBlock.BackColor = Color.Transparent;
            picNitrogenFuelBlock.Location = new Point(32, 122);
            picNitrogenFuelBlock.Name = "picNitrogenFuelBlock";
            picNitrogenFuelBlock.Size = new Size(32, 32);
            picNitrogenFuelBlock.TabIndex = 258;
            picNitrogenFuelBlock.TabStop = false;
            // 
            // txtNitrogenFuelBlockBPME
            // 
            txtNitrogenFuelBlockBPME.Location = new Point(140, 166);
            txtNitrogenFuelBlockBPME.Name = "txtNitrogenFuelBlockBPME";
            txtNitrogenFuelBlockBPME.Size = new Size(41, 20);
            txtNitrogenFuelBlockBPME.TabIndex = 20;
            txtNitrogenFuelBlockBPME.Text = "0";
            txtNitrogenFuelBlockBPME.TextAlign = HorizontalAlignment.Right;
            // 
            // lblNitrogenFuelBlockBuy
            // 
            lblNitrogenFuelBlockBuy.AutoSize = true;
            lblNitrogenFuelBlockBuy.Location = new Point(75, 126);
            lblNitrogenFuelBlockBuy.Name = "lblNitrogenFuelBlockBuy";
            lblNitrogenFuelBlockBuy.Size = new Size(28, 13);
            lblNitrogenFuelBlockBuy.TabIndex = 15;
            lblNitrogenFuelBlockBuy.Text = "Buy:";
            lblNitrogenFuelBlockBuy.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNitrogenFuelBlockBuild
            // 
            lblNitrogenFuelBlockBuild.AutoSize = true;
            lblNitrogenFuelBlockBuild.Location = new Point(70, 147);
            lblNitrogenFuelBlockBuild.Name = "lblNitrogenFuelBlockBuild";
            lblNitrogenFuelBlockBuild.Size = new Size(33, 13);
            lblNitrogenFuelBlockBuild.TabIndex = 17;
            lblNitrogenFuelBlockBuild.Text = "Build:";
            lblNitrogenFuelBlockBuild.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNitrogenFuelBlockBuyPrice
            // 
            txtNitrogenFuelBlockBuyPrice.Location = new Point(105, 122);
            txtNitrogenFuelBlockBuyPrice.Name = "txtNitrogenFuelBlockBuyPrice";
            txtNitrogenFuelBlockBuyPrice.Size = new Size(76, 20);
            txtNitrogenFuelBlockBuyPrice.TabIndex = 16;
            txtNitrogenFuelBlockBuyPrice.Text = "0.00";
            txtNitrogenFuelBlockBuyPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // lblNitrogenFuelBlockBuildPrice
            // 
            lblNitrogenFuelBlockBuildPrice.BorderStyle = BorderStyle.FixedSingle;
            lblNitrogenFuelBlockBuildPrice.Location = new Point(105, 144);
            lblNitrogenFuelBlockBuildPrice.Name = "lblNitrogenFuelBlockBuildPrice";
            lblNitrogenFuelBlockBuildPrice.Size = new Size(76, 20);
            lblNitrogenFuelBlockBuildPrice.TabIndex = 18;
            lblNitrogenFuelBlockBuildPrice.Text = "0.00";
            lblNitrogenFuelBlockBuildPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOxygenFuelBlock
            // 
            lblOxygenFuelBlock.Location = new Point(310, 108);
            lblOxygenFuelBlock.Name = "lblOxygenFuelBlock";
            lblOxygenFuelBlock.Size = new Size(76, 13);
            lblOxygenFuelBlock.TabIndex = 21;
            lblOxygenFuelBlock.Text = "Oxygen";
            lblOxygenFuelBlock.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblOxygenFuelBlockBPME
            // 
            lblOxygenFuelBlockBPME.Location = new Point(245, 169);
            lblOxygenFuelBlockBPME.Name = "lblOxygenFuelBlockBPME";
            lblOxygenFuelBlockBPME.Size = new Size(97, 15);
            lblOxygenFuelBlockBPME.TabIndex = 26;
            lblOxygenFuelBlockBPME.Text = "Fuel Block BP ME:";
            // 
            // picOxygenFuelBlock
            // 
            picOxygenFuelBlock.BackColor = Color.Transparent;
            picOxygenFuelBlock.Location = new Point(240, 122);
            picOxygenFuelBlock.Name = "picOxygenFuelBlock";
            picOxygenFuelBlock.Size = new Size(32, 32);
            picOxygenFuelBlock.TabIndex = 269;
            picOxygenFuelBlock.TabStop = false;
            // 
            // txtOxygenFuelBlockBPME
            // 
            txtOxygenFuelBlockBPME.Location = new Point(348, 166);
            txtOxygenFuelBlockBPME.Name = "txtOxygenFuelBlockBPME";
            txtOxygenFuelBlockBPME.Size = new Size(41, 20);
            txtOxygenFuelBlockBPME.TabIndex = 27;
            txtOxygenFuelBlockBPME.Text = "0";
            txtOxygenFuelBlockBPME.TextAlign = HorizontalAlignment.Right;
            // 
            // lblOxygenFuelBlockBuy
            // 
            lblOxygenFuelBlockBuy.AutoSize = true;
            lblOxygenFuelBlockBuy.Location = new Point(283, 126);
            lblOxygenFuelBlockBuy.Name = "lblOxygenFuelBlockBuy";
            lblOxygenFuelBlockBuy.Size = new Size(28, 13);
            lblOxygenFuelBlockBuy.TabIndex = 22;
            lblOxygenFuelBlockBuy.Text = "Buy:";
            lblOxygenFuelBlockBuy.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblOxygenFuelBlockBuild
            // 
            lblOxygenFuelBlockBuild.AutoSize = true;
            lblOxygenFuelBlockBuild.Location = new Point(278, 147);
            lblOxygenFuelBlockBuild.Name = "lblOxygenFuelBlockBuild";
            lblOxygenFuelBlockBuild.Size = new Size(33, 13);
            lblOxygenFuelBlockBuild.TabIndex = 24;
            lblOxygenFuelBlockBuild.Text = "Build:";
            lblOxygenFuelBlockBuild.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtOxygenFuelBlockBuyPrice
            // 
            txtOxygenFuelBlockBuyPrice.Location = new Point(313, 122);
            txtOxygenFuelBlockBuyPrice.Name = "txtOxygenFuelBlockBuyPrice";
            txtOxygenFuelBlockBuyPrice.Size = new Size(76, 20);
            txtOxygenFuelBlockBuyPrice.TabIndex = 23;
            txtOxygenFuelBlockBuyPrice.Text = "0.00";
            txtOxygenFuelBlockBuyPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // lblOxygenFuelBlockBuildPrice
            // 
            lblOxygenFuelBlockBuildPrice.BorderStyle = BorderStyle.FixedSingle;
            lblOxygenFuelBlockBuildPrice.Location = new Point(313, 144);
            lblOxygenFuelBlockBuildPrice.Name = "lblOxygenFuelBlockBuildPrice";
            lblOxygenFuelBlockBuildPrice.Size = new Size(76, 20);
            lblOxygenFuelBlockBuildPrice.TabIndex = 25;
            lblOxygenFuelBlockBuildPrice.Text = "0.00";
            lblOxygenFuelBlockBuildPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbFuelBlockOptions
            // 
            gbFuelBlockOptions.Controls.Add(rbtnBuyBlocks);
            gbFuelBlockOptions.Controls.Add(rbtnBuildBlocks);
            gbFuelBlockOptions.Controls.Add(chkAutoUpdateFuelPrice);
            gbFuelBlockOptions.Location = new Point(444, 173);
            gbFuelBlockOptions.Name = "gbFuelBlockOptions";
            gbFuelBlockOptions.Size = new Size(125, 64);
            gbFuelBlockOptions.TabIndex = 5;
            gbFuelBlockOptions.TabStop = false;
            gbFuelBlockOptions.Text = "Options";
            // 
            // rbtnBuyBlocks
            // 
            rbtnBuyBlocks.AutoSize = true;
            rbtnBuyBlocks.Location = new Point(15, 18);
            rbtnBuyBlocks.Name = "rbtnBuyBlocks";
            rbtnBuyBlocks.Size = new Size(78, 17);
            rbtnBuyBlocks.TabIndex = 0;
            rbtnBuyBlocks.TabStop = true;
            rbtnBuyBlocks.Text = "Buy Blocks";
            rbtnBuyBlocks.UseVisualStyleBackColor = true;
            // 
            // rbtnBuildBlocks
            // 
            rbtnBuildBlocks.AutoSize = true;
            rbtnBuildBlocks.Location = new Point(15, 39);
            rbtnBuildBlocks.Name = "rbtnBuildBlocks";
            rbtnBuildBlocks.Size = new Size(83, 17);
            rbtnBuildBlocks.TabIndex = 1;
            rbtnBuildBlocks.TabStop = true;
            rbtnBuildBlocks.Text = "Build Blocks";
            rbtnBuildBlocks.UseVisualStyleBackColor = true;
            // 
            // chkAutoUpdateFuelPrice
            // 
            chkAutoUpdateFuelPrice.AutoSize = true;
            chkAutoUpdateFuelPrice.Location = new Point(15, 63);
            chkAutoUpdateFuelPrice.Name = "chkAutoUpdateFuelPrice";
            chkAutoUpdateFuelPrice.Size = new Size(86, 17);
            chkAutoUpdateFuelPrice.TabIndex = 2;
            chkAutoUpdateFuelPrice.Text = "Auto Update";
            chkAutoUpdateFuelPrice.UseVisualStyleBackColor = true;
            chkAutoUpdateFuelPrice.Visible = false;
            // 
            // btnSavePrices
            // 
            btnSavePrices.Location = new Point(444, 57);
            btnSavePrices.Name = "btnSavePrices";
            btnSavePrices.Size = new Size(125, 34);
            btnSavePrices.TabIndex = 3;
            btnSavePrices.Text = "Save Prices";
            btnSavePrices.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBuildCost
            // 
            btnUpdateBuildCost.Location = new Point(444, 95);
            btnUpdateBuildCost.Name = "btnUpdateBuildCost";
            btnUpdateBuildCost.Size = new Size(125, 34);
            btnUpdateBuildCost.TabIndex = 2;
            btnUpdateBuildCost.Text = "Update Build Cost";
            btnUpdateBuildCost.UseVisualStyleBackColor = true;
            // 
            // lblLauncherSlots
            // 
            lblLauncherSlots.BorderStyle = BorderStyle.FixedSingle;
            lblLauncherSlots.Location = new Point(6, 169);
            lblLauncherSlots.Name = "lblLauncherSlots";
            lblLauncherSlots.Size = new Size(155, 18);
            lblLauncherSlots.TabIndex = 8;
            lblLauncherSlots.Text = "Launcher Slots:";
            lblLauncherSlots.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbFilterOptions
            // 
            gbFilterOptions.Controls.Add(chkRigTypeViewDrilling);
            gbFilterOptions.Controls.Add(chkRigTypeViewReaction);
            gbFilterOptions.Controls.Add(chkRigTypeViewCombat);
            gbFilterOptions.Controls.Add(chkRigTypeViewReprocessing);
            gbFilterOptions.Controls.Add(chkRigTypeViewEngineering);
            gbFilterOptions.Controls.Add(chkItemViewTypeLow);
            gbFilterOptions.Controls.Add(chkItemViewTypeMedium);
            gbFilterOptions.Controls.Add(chkItemViewTypeHigh);
            gbFilterOptions.Controls.Add(chkItemViewTypeServices);
            gbFilterOptions.Location = new Point(6, 72);
            gbFilterOptions.Name = "gbFilterOptions";
            gbFilterOptions.Size = new Size(342, 85);
            gbFilterOptions.TabIndex = 6;
            gbFilterOptions.TabStop = false;
            gbFilterOptions.Text = "Item View Type:";
            // 
            // chkRigTypeViewDrilling
            // 
            chkRigTypeViewDrilling.AutoSize = true;
            chkRigTypeViewDrilling.Location = new Point(219, 62);
            chkRigTypeViewDrilling.Name = "chkRigTypeViewDrilling";
            chkRigTypeViewDrilling.Size = new Size(81, 17);
            chkRigTypeViewDrilling.TabIndex = 8;
            chkRigTypeViewDrilling.Text = "Drilling Rigs";
            chkRigTypeViewDrilling.UseVisualStyleBackColor = true;
            // 
            // chkRigTypeViewReaction
            // 
            chkRigTypeViewReaction.AutoSize = true;
            chkRigTypeViewReaction.Location = new Point(109, 62);
            chkRigTypeViewReaction.Name = "chkRigTypeViewReaction";
            chkRigTypeViewReaction.Size = new Size(93, 17);
            chkRigTypeViewReaction.TabIndex = 7;
            chkRigTypeViewReaction.Text = "Reaction Rigs";
            chkRigTypeViewReaction.UseVisualStyleBackColor = true;
            // 
            // chkRigTypeViewCombat
            // 
            chkRigTypeViewCombat.AutoSize = true;
            chkRigTypeViewCombat.Location = new Point(17, 62);
            chkRigTypeViewCombat.Name = "chkRigTypeViewCombat";
            chkRigTypeViewCombat.Size = new Size(86, 17);
            chkRigTypeViewCombat.TabIndex = 6;
            chkRigTypeViewCombat.Text = "Combat Rigs";
            chkRigTypeViewCombat.UseVisualStyleBackColor = true;
            // 
            // chkRigTypeViewReprocessing
            // 
            chkRigTypeViewReprocessing.AutoSize = true;
            chkRigTypeViewReprocessing.Location = new Point(219, 40);
            chkRigTypeViewReprocessing.Name = "chkRigTypeViewReprocessing";
            chkRigTypeViewReprocessing.Size = new Size(115, 17);
            chkRigTypeViewReprocessing.TabIndex = 5;
            chkRigTypeViewReprocessing.Text = "Reprocessing Rigs";
            chkRigTypeViewReprocessing.UseVisualStyleBackColor = true;
            // 
            // chkRigTypeViewEngineering
            // 
            chkRigTypeViewEngineering.AutoSize = true;
            chkRigTypeViewEngineering.Location = new Point(109, 40);
            chkRigTypeViewEngineering.Name = "chkRigTypeViewEngineering";
            chkRigTypeViewEngineering.Size = new Size(106, 17);
            chkRigTypeViewEngineering.TabIndex = 4;
            chkRigTypeViewEngineering.Text = "Engineering Rigs";
            chkRigTypeViewEngineering.UseVisualStyleBackColor = true;
            // 
            // chkItemViewTypeLow
            // 
            chkItemViewTypeLow.AutoSize = true;
            chkItemViewTypeLow.Location = new Point(219, 18);
            chkItemViewTypeLow.Name = "chkItemViewTypeLow";
            chkItemViewTypeLow.Size = new Size(72, 17);
            chkItemViewTypeLow.TabIndex = 2;
            chkItemViewTypeLow.Text = "Low Slots";
            chkItemViewTypeLow.UseVisualStyleBackColor = true;
            // 
            // chkItemViewTypeMedium
            // 
            chkItemViewTypeMedium.AutoSize = true;
            chkItemViewTypeMedium.Location = new Point(109, 18);
            chkItemViewTypeMedium.Name = "chkItemViewTypeMedium";
            chkItemViewTypeMedium.Size = new Size(89, 17);
            chkItemViewTypeMedium.TabIndex = 1;
            chkItemViewTypeMedium.Text = "Medium Slots";
            chkItemViewTypeMedium.UseVisualStyleBackColor = true;
            // 
            // chkItemViewTypeHigh
            // 
            chkItemViewTypeHigh.AutoSize = true;
            chkItemViewTypeHigh.Location = new Point(17, 18);
            chkItemViewTypeHigh.Name = "chkItemViewTypeHigh";
            chkItemViewTypeHigh.Size = new Size(74, 17);
            chkItemViewTypeHigh.TabIndex = 0;
            chkItemViewTypeHigh.Text = "High Slots";
            chkItemViewTypeHigh.UseVisualStyleBackColor = true;
            // 
            // chkItemViewTypeServices
            // 
            chkItemViewTypeServices.AutoSize = true;
            chkItemViewTypeServices.Location = new Point(17, 40);
            chkItemViewTypeServices.Name = "chkItemViewTypeServices";
            chkItemViewTypeServices.Size = new Size(67, 17);
            chkItemViewTypeServices.TabIndex = 3;
            chkItemViewTypeServices.Text = "Services";
            chkItemViewTypeServices.UseVisualStyleBackColor = true;
            // 
            // gbStatsandOptions
            // 
            gbStatsandOptions.Controls.Add(chkIncludeFuelCosts);
            gbStatsandOptions.Controls.Add(gbOptions);
            gbStatsandOptions.Controls.Add(lblLauncherSlots);
            gbStatsandOptions.Controls.Add(gbIncludeFuelBlocks);
            gbStatsandOptions.Controls.Add(lblCapacitor);
            gbStatsandOptions.Controls.Add(lblCapacitor1);
            gbStatsandOptions.Controls.Add(lblCalibration);
            gbStatsandOptions.Controls.Add(lblCalibration1);
            gbStatsandOptions.Controls.Add(lblCPU);
            gbStatsandOptions.Controls.Add(lblPowerGrid);
            gbStatsandOptions.Controls.Add(lblCPU1);
            gbStatsandOptions.Controls.Add(lblPowerGrid1);
            gbStatsandOptions.Location = new Point(959, 18);
            gbStatsandOptions.Name = "gbStatsandOptions";
            gbStatsandOptions.Size = new Size(167, 589);
            gbStatsandOptions.TabIndex = 10;
            gbStatsandOptions.TabStop = false;
            // 
            // gbOptions
            // 
            gbOptions.Controls.Add(lblSystemSecurity);
            gbOptions.Controls.Add(chkNullSec);
            gbOptions.Controls.Add(chkLowSec);
            gbOptions.Controls.Add(chkHighSec);
            gbOptions.Location = new Point(6, 485);
            gbOptions.Name = "gbOptions";
            gbOptions.Size = new Size(155, 63);
            gbOptions.TabIndex = 11;
            gbOptions.TabStop = false;
            gbOptions.Text = "Options";
            // 
            // lblSystemSecurity
            // 
            lblSystemSecurity.AutoSize = true;
            lblSystemSecurity.Location = new Point(3, 18);
            lblSystemSecurity.Name = "lblSystemSecurity";
            lblSystemSecurity.Size = new Size(85, 13);
            lblSystemSecurity.TabIndex = 0;
            lblSystemSecurity.Text = "System Security:";
            // 
            // chkNullSec
            // 
            chkNullSec.AutoSize = true;
            chkNullSec.Location = new Point(103, 34);
            chkNullSec.Name = "chkNullSec";
            chkNullSec.Size = new Size(44, 17);
            chkNullSec.TabIndex = 3;
            chkNullSec.Text = "Null";
            chkNullSec.UseVisualStyleBackColor = true;
            // 
            // chkLowSec
            // 
            chkLowSec.AutoSize = true;
            chkLowSec.Location = new Point(56, 34);
            chkLowSec.Name = "chkLowSec";
            chkLowSec.Size = new Size(46, 17);
            chkLowSec.TabIndex = 2;
            chkLowSec.Text = "Low";
            chkLowSec.UseVisualStyleBackColor = true;
            // 
            // chkHighSec
            // 
            chkHighSec.AutoSize = true;
            chkHighSec.Location = new Point(7, 34);
            chkHighSec.Name = "chkHighSec";
            chkHighSec.Size = new Size(48, 17);
            chkHighSec.TabIndex = 1;
            chkHighSec.Text = "High";
            chkHighSec.UseVisualStyleBackColor = true;
            // 
            // gbIncludeFuelBlocks
            // 
            gbIncludeFuelBlocks.Controls.Add(lblServiceModuleBPD);
            gbIncludeFuelBlocks.Controls.Add(lblFuelBlocksperDay);
            gbIncludeFuelBlocks.Controls.Add(gbSelectedFuelBlock);
            gbIncludeFuelBlocks.Controls.Add(lblFuelReductionBonus);
            gbIncludeFuelBlocks.Controls.Add(lblServiceModuleOnlineAmt);
            gbIncludeFuelBlocks.Controls.Add(lblOnlineAmt);
            gbIncludeFuelBlocks.Controls.Add(lblFuelBPH);
            gbIncludeFuelBlocks.Controls.Add(lblServiceModuleBPH);
            gbIncludeFuelBlocks.Controls.Add(lblServiceModuleFCPH);
            gbIncludeFuelBlocks.Controls.Add(lblFuelCost);
            gbIncludeFuelBlocks.Enabled = false;
            gbIncludeFuelBlocks.Location = new Point(6, 195);
            gbIncludeFuelBlocks.Name = "gbIncludeFuelBlocks";
            gbIncludeFuelBlocks.Size = new Size(155, 284);
            gbIncludeFuelBlocks.TabIndex = 10;
            gbIncludeFuelBlocks.TabStop = false;
            // 
            // lblServiceModuleBPD
            // 
            lblServiceModuleBPD.BorderStyle = BorderStyle.FixedSingle;
            lblServiceModuleBPD.Location = new Point(7, 131);
            lblServiceModuleBPD.Name = "lblServiceModuleBPD";
            lblServiceModuleBPD.Size = new Size(140, 16);
            lblServiceModuleBPD.TabIndex = 13;
            lblServiceModuleBPD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFuelBlocksperDay
            // 
            lblFuelBlocksperDay.Location = new Point(7, 113);
            lblFuelBlocksperDay.Name = "lblFuelBlocksperDay";
            lblFuelBlocksperDay.Size = new Size(140, 16);
            lblFuelBlocksperDay.TabIndex = 12;
            lblFuelBlocksperDay.Text = "Fuel Blocks per Day";
            lblFuelBlocksperDay.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbSelectedFuelBlock
            // 
            gbSelectedFuelBlock.Controls.Add(rbtnHeliumFuelBlock);
            gbSelectedFuelBlock.Controls.Add(rbtnHydrogenFuelBlock);
            gbSelectedFuelBlock.Controls.Add(rbtnOxygenFuelBlock);
            gbSelectedFuelBlock.Controls.Add(rbtnNitrogenFuelBlock);
            gbSelectedFuelBlock.Location = new Point(7, 184);
            gbSelectedFuelBlock.Name = "gbSelectedFuelBlock";
            gbSelectedFuelBlock.Size = new Size(140, 93);
            gbSelectedFuelBlock.TabIndex = 11;
            gbSelectedFuelBlock.TabStop = false;
            // 
            // rbtnHeliumFuelBlock
            // 
            rbtnHeliumFuelBlock.AutoSize = true;
            rbtnHeliumFuelBlock.Location = new Point(12, 13);
            rbtnHeliumFuelBlock.Name = "rbtnHeliumFuelBlock";
            rbtnHeliumFuelBlock.Size = new Size(110, 17);
            rbtnHeliumFuelBlock.TabIndex = 6;
            rbtnHeliumFuelBlock.TabStop = true;
            rbtnHeliumFuelBlock.Text = "Helium Fuel Block";
            rbtnHeliumFuelBlock.UseVisualStyleBackColor = true;
            // 
            // rbtnHydrogenFuelBlock
            // 
            rbtnHydrogenFuelBlock.AutoSize = true;
            rbtnHydrogenFuelBlock.Location = new Point(12, 32);
            rbtnHydrogenFuelBlock.Name = "rbtnHydrogenFuelBlock";
            rbtnHydrogenFuelBlock.Size = new Size(124, 17);
            rbtnHydrogenFuelBlock.TabIndex = 7;
            rbtnHydrogenFuelBlock.TabStop = true;
            rbtnHydrogenFuelBlock.Text = "Hydrogen Fuel Block";
            rbtnHydrogenFuelBlock.UseVisualStyleBackColor = true;
            // 
            // rbtnOxygenFuelBlock
            // 
            rbtnOxygenFuelBlock.AutoSize = true;
            rbtnOxygenFuelBlock.Location = new Point(12, 70);
            rbtnOxygenFuelBlock.Name = "rbtnOxygenFuelBlock";
            rbtnOxygenFuelBlock.Size = new Size(114, 17);
            rbtnOxygenFuelBlock.TabIndex = 9;
            rbtnOxygenFuelBlock.TabStop = true;
            rbtnOxygenFuelBlock.Text = "Oxygen Fuel Block";
            rbtnOxygenFuelBlock.UseVisualStyleBackColor = true;
            // 
            // rbtnNitrogenFuelBlock
            // 
            rbtnNitrogenFuelBlock.AutoSize = true;
            rbtnNitrogenFuelBlock.Location = new Point(12, 51);
            rbtnNitrogenFuelBlock.Name = "rbtnNitrogenFuelBlock";
            rbtnNitrogenFuelBlock.Size = new Size(118, 17);
            rbtnNitrogenFuelBlock.TabIndex = 8;
            rbtnNitrogenFuelBlock.TabStop = true;
            rbtnNitrogenFuelBlock.Text = "Nitrogen Fuel Block";
            rbtnNitrogenFuelBlock.UseVisualStyleBackColor = true;
            // 
            // lblFuelReductionBonus
            // 
            lblFuelReductionBonus.BackColor = Color.WhiteSmoke;
            lblFuelReductionBonus.BorderStyle = BorderStyle.FixedSingle;
            lblFuelReductionBonus.Location = new Point(7, 18);
            lblFuelReductionBonus.Name = "lblFuelReductionBonus";
            lblFuelReductionBonus.Size = new Size(140, 20);
            lblFuelReductionBonus.TabIndex = 10;
            lblFuelReductionBonus.Text = "Fuel Reduction Bonus:";
            lblFuelReductionBonus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblServiceModuleOnlineAmt
            // 
            lblServiceModuleOnlineAmt.BorderStyle = BorderStyle.FixedSingle;
            lblServiceModuleOnlineAmt.Location = new Point(7, 165);
            lblServiceModuleOnlineAmt.Name = "lblServiceModuleOnlineAmt";
            lblServiceModuleOnlineAmt.Size = new Size(140, 16);
            lblServiceModuleOnlineAmt.TabIndex = 5;
            lblServiceModuleOnlineAmt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOnlineAmt
            // 
            lblOnlineAmt.Location = new Point(7, 149);
            lblOnlineAmt.Name = "lblOnlineAmt";
            lblOnlineAmt.Size = new Size(140, 16);
            lblOnlineAmt.TabIndex = 4;
            lblOnlineAmt.Text = "Online Fuel Amount";
            lblOnlineAmt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFuelBPH
            // 
            lblFuelBPH.Location = new Point(7, 47);
            lblFuelBPH.Name = "lblFuelBPH";
            lblFuelBPH.Size = new Size(140, 16);
            lblFuelBPH.TabIndex = 0;
            lblFuelBPH.Text = "Fuel Blocks per Hour";
            lblFuelBPH.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblServiceModuleBPH
            // 
            lblServiceModuleBPH.BorderStyle = BorderStyle.FixedSingle;
            lblServiceModuleBPH.Location = new Point(7, 63);
            lblServiceModuleBPH.Name = "lblServiceModuleBPH";
            lblServiceModuleBPH.Size = new Size(140, 16);
            lblServiceModuleBPH.TabIndex = 1;
            lblServiceModuleBPH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblServiceModuleFCPH
            // 
            lblServiceModuleFCPH.BorderStyle = BorderStyle.FixedSingle;
            lblServiceModuleFCPH.Location = new Point(7, 95);
            lblServiceModuleFCPH.Name = "lblServiceModuleFCPH";
            lblServiceModuleFCPH.Size = new Size(140, 16);
            lblServiceModuleFCPH.TabIndex = 3;
            lblServiceModuleFCPH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFuelCost
            // 
            lblFuelCost.Location = new Point(7, 79);
            lblFuelCost.Name = "lblFuelCost";
            lblFuelCost.Size = new Size(140, 16);
            lblFuelCost.TabIndex = 2;
            lblFuelCost.Text = "Fuel Cost per Hour";
            lblFuelCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapacitor
            // 
            lblCapacitor.BorderStyle = BorderStyle.FixedSingle;
            lblCapacitor.Location = new Point(6, 140);
            lblCapacitor.Name = "lblCapacitor";
            lblCapacitor.Size = new Size(155, 16);
            lblCapacitor.TabIndex = 7;
            lblCapacitor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCapacitor1
            // 
            lblCapacitor1.Location = new Point(6, 124);
            lblCapacitor1.Name = "lblCapacitor1";
            lblCapacitor1.Size = new Size(155, 16);
            lblCapacitor1.TabIndex = 6;
            lblCapacitor1.Text = "Capacitor:";
            lblCapacitor1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCalibration
            // 
            lblCalibration.BorderStyle = BorderStyle.FixedSingle;
            lblCalibration.Location = new Point(6, 101);
            lblCalibration.Name = "lblCalibration";
            lblCalibration.Size = new Size(155, 16);
            lblCalibration.TabIndex = 5;
            lblCalibration.Text = "400 / 400";
            lblCalibration.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCalibration1
            // 
            lblCalibration1.AutoSize = true;
            lblCalibration1.Location = new Point(6, 87);
            lblCalibration1.Name = "lblCalibration1";
            lblCalibration1.Size = new Size(59, 13);
            lblCalibration1.TabIndex = 4;
            lblCalibration1.Text = "Calibration:";
            // 
            // lblCPU
            // 
            lblCPU.BorderStyle = BorderStyle.FixedSingle;
            lblCPU.Location = new Point(6, 63);
            lblCPU.Name = "lblCPU";
            lblCPU.Size = new Size(155, 16);
            lblCPU.TabIndex = 3;
            lblCPU.Text = "15,000,000 / 15,000,000";
            lblCPU.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPowerGrid
            // 
            lblPowerGrid.BorderStyle = BorderStyle.FixedSingle;
            lblPowerGrid.Location = new Point(6, 25);
            lblPowerGrid.Name = "lblPowerGrid";
            lblPowerGrid.Size = new Size(155, 16);
            lblPowerGrid.TabIndex = 1;
            lblPowerGrid.Text = "15,000,000 / 15,000,000";
            lblPowerGrid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCPU1
            // 
            lblCPU1.AutoSize = true;
            lblCPU1.Location = new Point(6, 49);
            lblCPU1.Name = "lblCPU1";
            lblCPU1.Size = new Size(32, 13);
            lblCPU1.TabIndex = 2;
            lblCPU1.Text = "CPU:";
            // 
            // lblPowerGrid1
            // 
            lblPowerGrid1.AutoSize = true;
            lblPowerGrid1.Location = new Point(6, 11);
            lblPowerGrid1.Name = "lblPowerGrid1";
            lblPowerGrid1.Size = new Size(62, 13);
            lblPowerGrid1.TabIndex = 0;
            lblPowerGrid1.Text = "Power Grid:";
            // 
            // btnSaveFitting
            // 
            btnSaveFitting.Location = new Point(6, 35);
            btnSaveFitting.Name = "btnSaveFitting";
            btnSaveFitting.Size = new Size(81, 30);
            btnSaveFitting.TabIndex = 3;
            btnSaveFitting.Text = "Save Fitting";
            btnSaveFitting.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(180, 35);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(81, 30);
            btnSaveSettings.TabIndex = 4;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnCloseForm
            // 
            btnCloseForm.Location = new Point(267, 35);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(81, 30);
            btnCloseForm.TabIndex = 5;
            btnCloseForm.Text = "Close";
            btnCloseForm.UseVisualStyleBackColor = true;
            // 
            // gbTextFilter
            // 
            gbTextFilter.Controls.Add(btnItemFilter);
            gbTextFilter.Controls.Add(btnResetItemFilter);
            gbTextFilter.Controls.Add(txtItemFilter);
            gbTextFilter.Location = new Point(6, 159);
            gbTextFilter.Name = "gbTextFilter";
            gbTextFilter.Size = new Size(342, 45);
            gbTextFilter.TabIndex = 7;
            gbTextFilter.TabStop = false;
            gbTextFilter.Text = "Text Search:";
            // 
            // btnItemFilter
            // 
            btnItemFilter.Location = new Point(252, 17);
            btnItemFilter.Name = "btnItemFilter";
            btnItemFilter.Size = new Size(39, 21);
            btnItemFilter.TabIndex = 1;
            btnItemFilter.Text = "Filter";
            btnItemFilter.UseVisualStyleBackColor = true;
            // 
            // btnResetItemFilter
            // 
            btnResetItemFilter.Location = new Point(297, 17);
            btnResetItemFilter.Name = "btnResetItemFilter";
            btnResetItemFilter.Size = new Size(39, 21);
            btnResetItemFilter.TabIndex = 2;
            btnResetItemFilter.Text = "Clear";
            btnResetItemFilter.UseVisualStyleBackColor = true;
            // 
            // txtItemFilter
            // 
            txtItemFilter.Location = new Point(6, 17);
            txtItemFilter.Name = "txtItemFilter";
            txtItemFilter.Size = new Size(240, 20);
            txtItemFilter.TabIndex = 0;
            // 
            // EventLog1
            // 
            EventLog1.SynchronizingObject = this;
            // 
            // pbFloat
            // 
            pbFloat.BackColor = Color.White;
            pbFloat.InitialImage = null;
            pbFloat.Location = new Point(258, 457);
            pbFloat.Name = "pbFloat";
            pbFloat.Size = new Size(64, 64);
            pbFloat.SizeMode = PictureBoxSizeMode.CenterImage;
            pbFloat.TabIndex = 7;
            pbFloat.TabStop = false;
            pbFloat.Visible = false;
            // 
            // gbViewType
            // 
            gbViewType.Controls.Add(rbtnListView);
            gbViewType.Controls.Add(rbtnViewIcons);
            gbViewType.Location = new Point(93, 574);
            gbViewType.Name = "gbViewType";
            gbViewType.Size = new Size(168, 33);
            gbViewType.TabIndex = 8;
            gbViewType.TabStop = false;
            // 
            // rbtnListView
            // 
            rbtnListView.AutoSize = true;
            rbtnListView.Location = new Point(90, 10);
            rbtnListView.Name = "rbtnListView";
            rbtnListView.Size = new Size(67, 17);
            rbtnListView.TabIndex = 1;
            rbtnListView.TabStop = true;
            rbtnListView.Text = "List View";
            rbtnListView.UseVisualStyleBackColor = true;
            // 
            // rbtnViewIcons
            // 
            rbtnViewIcons.AutoSize = true;
            rbtnViewIcons.Location = new Point(12, 10);
            rbtnViewIcons.Name = "rbtnViewIcons";
            rbtnViewIcons.Size = new Size(72, 17);
            rbtnViewIcons.TabIndex = 0;
            rbtnViewIcons.TabStop = true;
            rbtnViewIcons.Text = "Icon View";
            rbtnViewIcons.UseVisualStyleBackColor = true;
            // 
            // FittingListViewDetails
            // 
            FittingListViewDetails.Columns.AddRange(new ColumnHeader[] { ModuleName, ModuleType, GroupTag, ModuleTypeID });
            FittingListViewDetails.FullRowSelect = true;
            FittingListViewDetails.GridLines = true;
            FittingListViewDetails.HideSelection = false;
            FittingListViewDetails.Location = new Point(6, 210);
            FittingListViewDetails.MultiSelect = false;
            FittingListViewDetails.Name = "FittingListViewDetails";
            FittingListViewDetails.Size = new Size(342, 363);
            FittingListViewDetails.TabIndex = 42;
            FittingListViewDetails.TabStop = false;
            FittingListViewDetails.UseCompatibleStateImageBehavior = false;
            FittingListViewDetails.View = View.Details;
            // 
            // ModuleName
            // 
            ModuleName.Text = "Module Name";
            ModuleName.Width = 225;
            // 
            // ModuleType
            // 
            ModuleType.Text = "Module Type";
            ModuleType.Width = 96;
            // 
            // GroupTag
            // 
            GroupTag.Width = 0;
            // 
            // ModuleTypeID
            // 
            ModuleTypeID.Text = "ModuleTypeID";
            ModuleTypeID.Width = 0;
            // 
            // frmUpwellStructureFitting
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1134, 611);
            Controls.Add(gbViewType);
            Controls.Add(gbTextFilter);
            Controls.Add(btnCloseForm);
            Controls.Add(btnSaveSettings);
            Controls.Add(pbFloat);
            Controls.Add(gbStatsandOptions);
            Controls.Add(gbFilterOptions);
            Controls.Add(tabUpwellStructure);
            Controls.Add(btnSaveFitting);
            Controls.Add(btnStripFitting);
            Controls.Add(cmbUpwellStructureName);
            Controls.Add(lblSelectedUpwellStructure);
            Controls.Add(FittingListViewDetails);
            Controls.Add(FittingListViewIcons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmUpwellStructureFitting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Upwell Structure Fitting";
            tabUpwellStructure.ResumeLayout(false);
            tabFitting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LowSlot3).EndInit();
            ((System.ComponentModel.ISupportInitialize)RigSlot2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot6).EndInit();
            ((System.ComponentModel.ISupportInitialize)RigSlot3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot2).EndInit();
            ((System.ComponentModel.ISupportInitialize)RigSlot1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot7).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot8).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot4).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot3).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot5).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LowSlot1).EndInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot8).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot5).EndInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot5).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServiceSlot6).EndInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot6).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot3).EndInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot4).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot4).EndInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot2).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot2).EndInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot3).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot1).EndInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot7).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot5).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot8).EndInit();
            ((System.ComponentModel.ISupportInitialize)HighSlot1).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot6).EndInit();
            ((System.ComponentModel.ISupportInitialize)MidSlot7).EndInit();
            ((System.ComponentModel.ISupportInitialize)StructurePicture).EndInit();
            tabFuelandBonuses.ResumeLayout(false);
            gbFacilityBonuses.ResumeLayout(false);
            gbFuelBlocks.ResumeLayout(false);
            gbFuelPrices.ResumeLayout(false);
            gbFuelPrices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeliumIsotopes).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCoolant).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOxygen).EndInit();
            ((System.ComponentModel.ISupportInitialize)picNitrogenIsotopes).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHydrogenIsotopes).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEnrichedUranium).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOxygenIsotopes).EndInit();
            ((System.ComponentModel.ISupportInitialize)picMechanicalParts).EndInit();
            ((System.ComponentModel.ISupportInitialize)picRobotics).EndInit();
            ((System.ComponentModel.ISupportInitialize)picStrontiumClathrates).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLiquidOzone).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHeavyWater).EndInit();
            gbFuelBlocks2.ResumeLayout(false);
            gbFuelBlocks2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeliumFuelBlock).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHydrogenFuelBlock).EndInit();
            ((System.ComponentModel.ISupportInitialize)picNitrogenFuelBlock).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOxygenFuelBlock).EndInit();
            gbFuelBlockOptions.ResumeLayout(false);
            gbFuelBlockOptions.PerformLayout();
            gbFilterOptions.ResumeLayout(false);
            gbFilterOptions.PerformLayout();
            gbStatsandOptions.ResumeLayout(false);
            gbStatsandOptions.PerformLayout();
            gbOptions.ResumeLayout(false);
            gbOptions.PerformLayout();
            gbIncludeFuelBlocks.ResumeLayout(false);
            gbSelectedFuelBlock.ResumeLayout(false);
            gbSelectedFuelBlock.PerformLayout();
            gbTextFilter.ResumeLayout(false);
            gbTextFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EventLog1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFloat).EndInit();
            gbViewType.ResumeLayout(false);
            gbViewType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        internal PictureBox RigSlot1;
        internal PictureBox HighSlot1;
        internal ImageList FittingImages;
        internal ListView FittingListViewIcons;
        internal PictureBox StructurePicture;
        internal PictureBox MidSlot1;
        internal PictureBox LowSlot1;
        internal PictureBox ServiceSlot1;
        internal PictureBox ServiceSlot2;
        internal PictureBox ServiceSlot3;
        internal PictureBox ServiceSlot4;
        internal PictureBox ServiceSlot5;
        internal PictureBox ServiceSlot6;
        internal PictureBox HighSlot7;
        internal PictureBox HighSlot3;
        internal PictureBox HighSlot2;
        internal PictureBox HighSlot4;
        internal PictureBox HighSlot6;
        internal PictureBox HighSlot5;
        internal PictureBox HighSlot8;
        internal PictureBox RigSlot3;
        internal PictureBox RigSlot2;
        internal PictureBox LowSlot5;
        internal PictureBox LowSlot4;
        internal PictureBox LowSlot8;
        internal PictureBox LowSlot7;
        internal PictureBox LowSlot2;
        internal PictureBox LowSlot6;
        internal PictureBox LowSlot3;
        internal PictureBox MidSlot8;
        internal PictureBox MidSlot7;
        internal PictureBox MidSlot6;
        internal PictureBox MidSlot5;
        internal PictureBox MidSlot2;
        internal PictureBox MidSlot4;
        internal PictureBox MidSlot3;
        internal PictureBox pbFloat;
        internal Label lblSelectedUpwellStructure;
        internal ComboBox cmbUpwellStructureName;
        internal CheckBox chkIncludeFuelCosts;
        internal Button btnStripFitting;
        internal TabControl tabUpwellStructure;
        internal TabPage tabFitting;
        internal TabPage tabFuelandBonuses;
        internal GroupBox gbFuelBlocks;
        internal Label lblHeliumFuelBlockBuildPrice;
        internal TextBox txtHeliumFuelBlockBuyPrice;
        internal Label lblHeliumFuelBlockBuild;
        internal Label lblHeliumFuelBlockBuy;
        internal TextBox txtHeliumFuelBlockBPME;
        internal Button btnSavePrices;
        internal Button btnUpdateBuildCost;
        internal PictureBox picHeliumFuelBlock;
        internal Label lblHeliumFuelBlockBPME;
        internal RadioButton rbtnBuildBlocks;
        internal RadioButton rbtnBuyBlocks;
        internal GroupBox gbFilterOptions;
        internal CheckBox chkItemViewTypeLow;
        internal CheckBox chkItemViewTypeMedium;
        internal CheckBox chkItemViewTypeHigh;
        internal CheckBox chkItemViewTypeServices;
        internal GroupBox gbStatsandOptions;
        internal Label lblCPU;
        internal Label lblPowerGrid;
        internal Label lblCPU1;
        internal Label lblPowerGrid1;
        internal Label lblCalibration;
        internal Label lblCalibration1;
        internal Label lblCapacitor;
        internal Label lblCapacitor1;
        internal Button btnSaveFitting;
        internal Button btnSaveSettings;
        internal CheckBox chkRigTypeViewCombat;
        internal CheckBox chkRigTypeViewReprocessing;
        internal CheckBox chkRigTypeViewEngineering;
        internal Label lblServiceModuleFCPH;
        internal Label lblFuelCost;
        internal Label lblServiceModuleBPH;
        internal Label lblFuelBPH;
        internal CheckBox chkAutoUpdateFuelPrice;
        internal Button btnCloseForm;
        internal Label lblOnlineAmt;
        internal GroupBox gbIncludeFuelBlocks;
        internal Label lblServiceModuleOnlineAmt;
        internal RadioButton rbtnOxygenFuelBlock;
        internal RadioButton rbtnNitrogenFuelBlock;
        internal RadioButton rbtnHydrogenFuelBlock;
        internal RadioButton rbtnHeliumFuelBlock;
        internal Label lblOxygenFuelBlockBuildPrice;
        internal TextBox txtOxygenFuelBlockBuyPrice;
        internal Label lblOxygenFuelBlockBuild;
        internal Label lblOxygenFuelBlockBuy;
        internal TextBox txtOxygenFuelBlockBPME;
        internal PictureBox picOxygenFuelBlock;
        internal Label lblOxygenFuelBlockBPME;
        internal Label lblNitrogenFuelBlockBuildPrice;
        internal TextBox txtNitrogenFuelBlockBuyPrice;
        internal Label lblNitrogenFuelBlockBuild;
        internal Label lblNitrogenFuelBlockBuy;
        internal TextBox txtNitrogenFuelBlockBPME;
        internal Label lblNitrogenFuelBlockBPME;
        internal Label lblHydrogenFuelBlockBuildPrice;
        internal TextBox txtHydrogenFuelBlockBuyPrice;
        internal Label lblHydrogenFuelBlockBuild;
        internal Label lblHydrogenBlockBuy;
        internal TextBox txtHydrogenFuelBlockBPME;
        internal PictureBox picHydrogenFuelBlock;
        internal Label lblHydrogenFuelBlockBPME;
        internal GroupBox gbFuelBlockOptions;
        internal GroupBox gbTextFilter;
        internal Button btnItemFilter;
        internal Button btnResetItemFilter;
        internal TextBox txtItemFilter;
        internal Label lblLauncherSlots;
        internal GroupBox gbOptions;
        internal Label lblSystemSecurity;
        internal CheckBox chkNullSec;
        internal CheckBox chkLowSec;
        internal CheckBox chkHighSec;
        internal ListView lstUpwellStructureBonuses;
        internal GroupBox gbFacilityBonuses;
        internal GroupBox gbFuelBlocks2;
        internal TextBox txtHeliumIsotopes;
        internal TextBox txtOxygen;
        internal PictureBox picHeliumIsotopes;
        internal Label lblOxygen;
        internal PictureBox picCoolant;
        internal PictureBox picOxygen;
        internal PictureBox picNitrogenIsotopes;
        internal TextBox txtRobotics;
        internal PictureBox picEnrichedUranium;
        internal Label lblRobotics;
        internal PictureBox picMechanicalParts;
        internal PictureBox picRobotics;
        internal PictureBox picStrontiumClathrates;
        internal TextBox txtOxygenIsotopes;
        internal PictureBox picLiquidOzone;
        internal TextBox txtHydrogenIsotopes;
        internal PictureBox picHeavyWater;
        internal Label lblOxygenIsotopes;
        internal Label lblHeliumIsotopes;
        internal Label lblHydrogenIsotopes;
        internal Label lblNitrogenIsotopes;
        internal PictureBox picOxygenIsotopes;
        internal Label lblMechanicalParts;
        internal PictureBox picHydrogenIsotopes;
        internal Label lblLiquidOzone;
        internal TextBox txtHeavyWater;
        internal Label lblCoolant;
        internal TextBox txtStrontiumClathrates;
        internal Label lblEnrichedUranium;
        internal TextBox txtEnrichedUranium;
        internal Label lblStrontiumClathrates;
        internal TextBox txtCoolant;
        internal Label lblHeavyWater;
        internal TextBox txtLiquidOzone;
        internal TextBox txtNitrogenIsotopes;
        internal TextBox txtMechanicalParts;
        internal PictureBox picNitrogenFuelBlock;
        internal Button btnSaveFuelBlockInfo;
        internal GroupBox gbFuelPrices;
        internal ColumnHeader BonusAppliesTo;
        internal ColumnHeader Bonuses;
        internal ColumnHeader Source;
        internal ColumnHeader Activity;
        internal CheckBox chkRigTypeViewReaction;
        internal CheckBox chkRigTypeViewDrilling;
        internal EventLog EventLog1;
        internal Button btnBonusPopout;
        internal Label lblHydrogenFuelBlock;
        internal Label lblOxygenFuelBlock;
        internal Label lblHeliumFuelBlock;
        internal Label lblNitrogenFuelBlock;
        internal Button btnRefreshPrices;
        internal ToolTip MainToolTip;
        internal ManufacturingListView FittingListViewDetails;
        internal GroupBox gbViewType;
        internal RadioButton rbtnListView;
        internal RadioButton rbtnViewIcons;
        internal Label lblFuelReductionBonus;
        internal Label lblServiceModuleBPD;
        internal Label lblFuelBlocksperDay;
        internal GroupBox gbSelectedFuelBlock;
        internal ColumnHeader ModuleName;
        internal ColumnHeader ModuleType;
        internal ColumnHeader GroupTag;
        internal ColumnHeader ModuleTypeID;
    }
}