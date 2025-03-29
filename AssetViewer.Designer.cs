using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class AssetViewer : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetViewer));
            tabMain = new TabControl();
            tabAssetMain = new TabPage();
            btnSaveMainSettings = new Button();
            btnSaveMainSettings.Click += new EventHandler(btnSaveMainSettings_Click);
            gbAssetTypes = new GroupBox();
            rbtnAllAssets = new RadioButton();
            rbtnAllAssets.CheckedChanged += new EventHandler(btnAllAssets_CheckedChanged);
            rbtnCorpAssets = new RadioButton();
            rbtnCorpAssets.CheckedChanged += new EventHandler(rbtnCorpAssets_CheckedChanged);
            rbtnPersonalAssets = new RadioButton();
            rbtnPersonalAssets.CheckedChanged += new EventHandler(rbtnPersonalAssets_CheckedChanged);
            GroupBox1 = new GroupBox();
            lblReloadCorpAssets = new Label();
            lblReloadPersonalAssets = new Label();
            btnScanCorpAssets = new Button();
            btnScanCorpAssets.Click += new EventHandler(btnScanCorpBPs_Click);
            lblReloadCorpAssets2 = new Label();
            btnScanPersonalAssets = new Button();
            btnScanPersonalAssets.Click += new EventHandler(btnScanPersonalBPs_Click);
            lblReloadPersonalAssets1 = new Label();
            gbSortOptions = new GroupBox();
            rbtnSortQuantity = new RadioButton();
            rbtnSortQuantity.CheckedChanged += new EventHandler(rbtnSortQuantity_CheckedChanged);
            rbtnSortName = new RadioButton();
            rbtnSortName.CheckedChanged += new EventHandler(rbtnSortName_CheckedChanged);
            picSpaceFiller = new PictureBox();
            btnCloseAssets = new Button();
            btnCloseAssets.Click += new EventHandler(btnCloseAssets_Click);
            tabSearchSettings = new TabPage();
            rbtnBPMats = new RadioButton();
            rbtnBPMats.CheckedChanged += new EventHandler(rbtnBPMats_CheckedChanged);
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            btnSearchRefresh = new Button();
            btnSearchRefresh.Click += new EventHandler(btnSearchRefresh_Click);
            rbtnAllItems = new RadioButton();
            rbtnAllItems.CheckedChanged += new EventHandler(rbtnAllItems_CheckedChanged);
            lblItemFilter = new Label();
            gbRawMaterials = new GroupBox();
            gbResearchEquipment = new GroupBox();
            chkRDb = new CheckBox();
            chkAncientRelics = new CheckBox();
            chkDecryptors = new CheckBox();
            chkDatacores = new CheckBox();
            gbReactionMaterials = new GroupBox();
            chkAdvancedMats = new CheckBox();
            chkMolecularForgedMaterials = new CheckBox();
            chkProcessedMats = new CheckBox();
            chkBoosterMats = new CheckBox();
            chkPolymers = new CheckBox();
            chkRawMoonMats = new CheckBox();
            chkFactionMaterials = new CheckBox();
            chkMolecularForgingTools = new CheckBox();
            chkAdvancedProtectiveTechnology = new CheckBox();
            chkBPCs = new CheckBox();
            chkMisc = new CheckBox();
            chkRawMaterials = new CheckBox();
            chkMaterialResearchEqPrices = new CheckBox();
            chkMaterialResearchEqPrices.CheckedChanged += new EventHandler(chkRawMaterialItems_CheckedChanged);
            chkPlanetary = new CheckBox();
            chkNamedComponents = new CheckBox();
            chkGas = new CheckBox();
            chkSalvage = new CheckBox();
            chkIceProducts = new CheckBox();
            chkMinerals = new CheckBox();
            gbManufacturedItems = new GroupBox();
            gbComponents = new GroupBox();
            chkRAM = new CheckBox();
            chkStructureComponents = new CheckBox();
            chkProtectiveComponents = new CheckBox();
            chkFuelBlocks = new CheckBox();
            chkSubsystemComponents = new CheckBox();
            chkAdvancedComponents = new CheckBox();
            chkCapitalShipComponents = new CheckBox();
            chkCapT2Components = new CheckBox();
            gbItems = new GroupBox();
            chkNobuild = new CheckBox();
            chkImplants = new CheckBox();
            chkBoosters = new CheckBox();
            chkBoosters.CheckedChanged += new EventHandler(chkBoosters_CheckedChanged);
            chkDeployables = new CheckBox();
            chkStructureModules = new CheckBox();
            chkCelestials = new CheckBox();
            chkStructures = new CheckBox();
            chkStructures.CheckedChanged += new EventHandler(chkStructures_CheckedChanged);
            chkStructureRigs = new CheckBox();
            chkSubsystems = new CheckBox();
            chkSubsystems.CheckedChanged += new EventHandler(chkSubsystems_CheckedChanged);
            chkRigs = new CheckBox();
            chkRigs.CheckedChanged += new EventHandler(chkRigs_CheckedChanged);
            cmbPriceChargeTypes = new ComboBox();
            cmbPriceChargeTypes.DropDown += new EventHandler(cmbPriceChargeTypes_DropDown);
            chkCharges = new CheckBox();
            chkCharges.CheckedChanged += new EventHandler(chkCharges_CheckedChanged);
            cmbPriceShipTypes = new ComboBox();
            cmbPriceShipTypes.DropDown += new EventHandler(cmbPriceShipTypes_DropDown);
            chkDrones = new CheckBox();
            chkDrones.CheckedChanged += new EventHandler(chkDrones_CheckedChanged);
            chkModules = new CheckBox();
            chkModules.CheckedChanged += new EventHandler(chkModules_CheckedChanged);
            chkShips = new CheckBox();
            chkShips.CheckedChanged += new EventHandler(chkShips_CheckedChanged);
            chkManufacturedItems = new CheckBox();
            chkManufacturedItems.CheckedChanged += new EventHandler(chkManufacturedItems_CheckedChanged);
            gbPricesTech = new GroupBox();
            chkItemsT4 = new CheckBox();
            chkItemsT6 = new CheckBox();
            chkItemsT5 = new CheckBox();
            chkItemsT3 = new CheckBox();
            chkItemsT2 = new CheckBox();
            chkItemsT1 = new CheckBox();
            btnResetItemFilter = new Button();
            btnResetItemFilter.Click += new EventHandler(btnResetItemFilter_Click);
            txtItemFilter = new TextBox();
            txtItemFilter.KeyDown += new KeyEventHandler(txtItemFilter_KeyDown);
            AssetTree = new TreeView();
            AssetTree.DrawNode += new DrawTreeNodeEventHandler(AssetTree_DrawNode);
            Timer1 = new Timer(components);
            Timer1.Tick += new EventHandler(Timer1_Tick);
            ttMain = new ToolTip(components);
            chkToggle = new CheckBox();
            btnToggleRetract = new Button();
            btnToggleRetract.Click += new EventHandler(btnToggleRetract_Click);
            btnCheckToggle = new Button();
            btnToggleExpand = new Button();
            btnToggleExpand.Click += new EventHandler(btnToggleExpand_Click);
            tabMain.SuspendLayout();
            tabAssetMain.SuspendLayout();
            gbAssetTypes.SuspendLayout();
            GroupBox1.SuspendLayout();
            gbSortOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSpaceFiller).BeginInit();
            tabSearchSettings.SuspendLayout();
            gbRawMaterials.SuspendLayout();
            gbResearchEquipment.SuspendLayout();
            gbReactionMaterials.SuspendLayout();
            gbManufacturedItems.SuspendLayout();
            gbComponents.SuspendLayout();
            gbItems.SuspendLayout();
            gbPricesTech.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabAssetMain);
            tabMain.Controls.Add(tabSearchSettings);
            tabMain.Location = new Point(355, 3);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(284, 662);
            tabMain.TabIndex = 251;
            // 
            // tabAssetMain
            // 
            tabAssetMain.Controls.Add(btnSaveMainSettings);
            tabAssetMain.Controls.Add(gbAssetTypes);
            tabAssetMain.Controls.Add(GroupBox1);
            tabAssetMain.Controls.Add(gbSortOptions);
            tabAssetMain.Controls.Add(picSpaceFiller);
            tabAssetMain.Controls.Add(btnCloseAssets);
            tabAssetMain.Location = new Point(4, 22);
            tabAssetMain.Name = "tabAssetMain";
            tabAssetMain.Padding = new Padding(3);
            tabAssetMain.Size = new Size(276, 636);
            tabAssetMain.TabIndex = 0;
            tabAssetMain.Text = "Main Search";
            tabAssetMain.UseVisualStyleBackColor = true;
            // 
            // btnSaveMainSettings
            // 
            btnSaveMainSettings.Location = new Point(32, 274);
            btnSaveMainSettings.Name = "btnSaveMainSettings";
            btnSaveMainSettings.Size = new Size(102, 27);
            btnSaveMainSettings.TabIndex = 6;
            btnSaveMainSettings.Text = "Save Settings";
            btnSaveMainSettings.UseVisualStyleBackColor = true;
            // 
            // gbAssetTypes
            // 
            gbAssetTypes.Controls.Add(rbtnAllAssets);
            gbAssetTypes.Controls.Add(rbtnCorpAssets);
            gbAssetTypes.Controls.Add(rbtnPersonalAssets);
            gbAssetTypes.Location = new Point(6, 6);
            gbAssetTypes.Name = "gbAssetTypes";
            gbAssetTypes.Size = new Size(263, 45);
            gbAssetTypes.TabIndex = 238;
            gbAssetTypes.TabStop = false;
            gbAssetTypes.Text = "Asset Types:";
            // 
            // rbtnAllAssets
            // 
            rbtnAllAssets.AutoSize = true;
            rbtnAllAssets.Location = new Point(10, 18);
            rbtnAllAssets.Name = "rbtnAllAssets";
            rbtnAllAssets.Size = new Size(47, 17);
            rbtnAllAssets.TabIndex = 0;
            rbtnAllAssets.TabStop = true;
            rbtnAllAssets.Text = "Both";
            rbtnAllAssets.UseVisualStyleBackColor = true;
            // 
            // rbtnCorpAssets
            // 
            rbtnCorpAssets.AutoSize = true;
            rbtnCorpAssets.Location = new Point(172, 18);
            rbtnCorpAssets.Name = "rbtnCorpAssets";
            rbtnCorpAssets.Size = new Size(79, 17);
            rbtnCorpAssets.TabIndex = 2;
            rbtnCorpAssets.TabStop = true;
            rbtnCorpAssets.Text = "Corporation";
            rbtnCorpAssets.UseVisualStyleBackColor = true;
            // 
            // rbtnPersonalAssets
            // 
            rbtnPersonalAssets.AutoSize = true;
            rbtnPersonalAssets.Location = new Point(86, 18);
            rbtnPersonalAssets.Name = "rbtnPersonalAssets";
            rbtnPersonalAssets.Size = new Size(66, 17);
            rbtnPersonalAssets.TabIndex = 1;
            rbtnPersonalAssets.TabStop = true;
            rbtnPersonalAssets.Text = "Personal";
            rbtnPersonalAssets.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(lblReloadCorpAssets);
            GroupBox1.Controls.Add(lblReloadPersonalAssets);
            GroupBox1.Controls.Add(btnScanCorpAssets);
            GroupBox1.Controls.Add(lblReloadCorpAssets2);
            GroupBox1.Controls.Add(btnScanPersonalAssets);
            GroupBox1.Controls.Add(lblReloadPersonalAssets1);
            GroupBox1.Location = new Point(6, 127);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(263, 139);
            GroupBox1.TabIndex = 240;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Assets from API:";
            // 
            // lblReloadCorpAssets
            // 
            lblReloadCorpAssets.BorderStyle = BorderStyle.FixedSingle;
            lblReloadCorpAssets.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReloadCorpAssets.Location = new Point(158, 79);
            lblReloadCorpAssets.Name = "lblReloadCorpAssets";
            lblReloadCorpAssets.Size = new Size(94, 17);
            lblReloadCorpAssets.TabIndex = 60;
            lblReloadCorpAssets.Text = "99h 99m 99s";
            lblReloadCorpAssets.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReloadPersonalAssets
            // 
            lblReloadPersonalAssets.BorderStyle = BorderStyle.FixedSingle;
            lblReloadPersonalAssets.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReloadPersonalAssets.Location = new Point(158, 21);
            lblReloadPersonalAssets.Name = "lblReloadPersonalAssets";
            lblReloadPersonalAssets.Size = new Size(94, 17);
            lblReloadPersonalAssets.TabIndex = 57;
            lblReloadPersonalAssets.Text = "99h 99m 99s";
            lblReloadPersonalAssets.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnScanCorpAssets
            // 
            btnScanCorpAssets.Location = new Point(66, 103);
            btnScanCorpAssets.Name = "btnScanCorpAssets";
            btnScanCorpAssets.Size = new Size(126, 26);
            btnScanCorpAssets.TabIndex = 5;
            btnScanCorpAssets.Text = "Scan Corp Assets";
            btnScanCorpAssets.UseVisualStyleBackColor = true;
            // 
            // lblReloadCorpAssets2
            // 
            lblReloadCorpAssets2.AutoSize = true;
            lblReloadCorpAssets2.Location = new Point(6, 81);
            lblReloadCorpAssets2.Name = "lblReloadCorpAssets2";
            lblReloadCorpAssets2.Size = new Size(136, 13);
            lblReloadCorpAssets2.TabIndex = 59;
            lblReloadCorpAssets2.Text = "Can Reload Corp Assets in:";
            // 
            // btnScanPersonalAssets
            // 
            btnScanPersonalAssets.Location = new Point(66, 45);
            btnScanPersonalAssets.Name = "btnScanPersonalAssets";
            btnScanPersonalAssets.Size = new Size(126, 26);
            btnScanPersonalAssets.TabIndex = 4;
            btnScanPersonalAssets.Text = "Scan Personal Assets";
            btnScanPersonalAssets.UseVisualStyleBackColor = true;
            // 
            // lblReloadPersonalAssets1
            // 
            lblReloadPersonalAssets1.AutoSize = true;
            lblReloadPersonalAssets1.Location = new Point(4, 23);
            lblReloadPersonalAssets1.Name = "lblReloadPersonalAssets1";
            lblReloadPersonalAssets1.Size = new Size(155, 13);
            lblReloadPersonalAssets1.TabIndex = 58;
            lblReloadPersonalAssets1.Text = "Can Reload Personal Assets in:";
            // 
            // gbSortOptions
            // 
            gbSortOptions.Controls.Add(rbtnSortQuantity);
            gbSortOptions.Controls.Add(rbtnSortName);
            gbSortOptions.Location = new Point(6, 66);
            gbSortOptions.Name = "gbSortOptions";
            gbSortOptions.Size = new Size(171, 45);
            gbSortOptions.TabIndex = 236;
            gbSortOptions.TabStop = false;
            gbSortOptions.Text = "Sort Items By:";
            // 
            // rbtnSortQuantity
            // 
            rbtnSortQuantity.AutoSize = true;
            rbtnSortQuantity.Location = new Point(86, 19);
            rbtnSortQuantity.Name = "rbtnSortQuantity";
            rbtnSortQuantity.Size = new Size(64, 17);
            rbtnSortQuantity.TabIndex = 4;
            rbtnSortQuantity.TabStop = true;
            rbtnSortQuantity.Text = "Quantity";
            rbtnSortQuantity.UseVisualStyleBackColor = true;
            // 
            // rbtnSortName
            // 
            rbtnSortName.AutoSize = true;
            rbtnSortName.Location = new Point(10, 19);
            rbtnSortName.Name = "rbtnSortName";
            rbtnSortName.Size = new Size(53, 17);
            rbtnSortName.TabIndex = 3;
            rbtnSortName.TabStop = true;
            rbtnSortName.Text = "Name";
            rbtnSortName.UseVisualStyleBackColor = true;
            // 
            // picSpaceFiller
            // 
            picSpaceFiller.Image = (Image)resources.GetObject("picSpaceFiller.Image");
            picSpaceFiller.Location = new Point(193, 57);
            picSpaceFiller.Name = "picSpaceFiller";
            picSpaceFiller.Size = new Size(64, 64);
            picSpaceFiller.TabIndex = 61;
            picSpaceFiller.TabStop = false;
            // 
            // btnCloseAssets
            // 
            btnCloseAssets.Location = new Point(140, 274);
            btnCloseAssets.Name = "btnCloseAssets";
            btnCloseAssets.Size = new Size(102, 27);
            btnCloseAssets.TabIndex = 7;
            btnCloseAssets.Text = "Close";
            btnCloseAssets.UseVisualStyleBackColor = true;
            // 
            // tabSearchSettings
            // 
            tabSearchSettings.Controls.Add(rbtnBPMats);
            tabSearchSettings.Controls.Add(btnSaveSettings);
            tabSearchSettings.Controls.Add(btnSearchRefresh);
            tabSearchSettings.Controls.Add(rbtnAllItems);
            tabSearchSettings.Controls.Add(lblItemFilter);
            tabSearchSettings.Controls.Add(gbRawMaterials);
            tabSearchSettings.Controls.Add(gbManufacturedItems);
            tabSearchSettings.Controls.Add(btnResetItemFilter);
            tabSearchSettings.Controls.Add(txtItemFilter);
            tabSearchSettings.Location = new Point(4, 22);
            tabSearchSettings.Name = "tabSearchSettings";
            tabSearchSettings.Padding = new Padding(3);
            tabSearchSettings.Size = new Size(276, 636);
            tabSearchSettings.TabIndex = 1;
            tabSearchSettings.Text = "Selected Material Settings";
            tabSearchSettings.UseVisualStyleBackColor = true;
            // 
            // rbtnBPMats
            // 
            rbtnBPMats.AutoSize = true;
            rbtnBPMats.Location = new Point(122, 10);
            rbtnBPMats.Name = "rbtnBPMats";
            rbtnBPMats.Size = new Size(111, 17);
            rbtnBPMats.TabIndex = 249;
            rbtnBPMats.Text = "Blueprint Materials";
            rbtnBPMats.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(185, 62);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(86, 24);
            btnSaveSettings.TabIndex = 247;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnSearchRefresh
            // 
            btnSearchRefresh.Location = new Point(5, 62);
            btnSearchRefresh.Name = "btnSearchRefresh";
            btnSearchRefresh.Size = new Size(86, 24);
            btnSearchRefresh.TabIndex = 246;
            btnSearchRefresh.Text = "Refresh";
            btnSearchRefresh.UseVisualStyleBackColor = true;
            // 
            // rbtnAllItems
            // 
            rbtnAllItems.AutoSize = true;
            rbtnAllItems.Location = new Point(41, 10);
            rbtnAllItems.Name = "rbtnAllItems";
            rbtnAllItems.Size = new Size(64, 17);
            rbtnAllItems.TabIndex = 248;
            rbtnAllItems.Text = "All Items";
            rbtnAllItems.UseVisualStyleBackColor = true;
            // 
            // lblItemFilter
            // 
            lblItemFilter.AutoSize = true;
            lblItemFilter.Location = new Point(7, 39);
            lblItemFilter.Name = "lblItemFilter";
            lblItemFilter.Size = new Size(55, 13);
            lblItemFilter.TabIndex = 242;
            lblItemFilter.Text = "Item Filter:";
            // 
            // gbRawMaterials
            // 
            gbRawMaterials.Controls.Add(gbResearchEquipment);
            gbRawMaterials.Controls.Add(gbReactionMaterials);
            gbRawMaterials.Controls.Add(chkFactionMaterials);
            gbRawMaterials.Controls.Add(chkMolecularForgingTools);
            gbRawMaterials.Controls.Add(chkAdvancedProtectiveTechnology);
            gbRawMaterials.Controls.Add(chkBPCs);
            gbRawMaterials.Controls.Add(chkMisc);
            gbRawMaterials.Controls.Add(chkRawMaterials);
            gbRawMaterials.Controls.Add(chkMaterialResearchEqPrices);
            gbRawMaterials.Controls.Add(chkPlanetary);
            gbRawMaterials.Controls.Add(chkNamedComponents);
            gbRawMaterials.Controls.Add(chkGas);
            gbRawMaterials.Controls.Add(chkSalvage);
            gbRawMaterials.Controls.Add(chkIceProducts);
            gbRawMaterials.Controls.Add(chkMinerals);
            gbRawMaterials.Location = new Point(3, 92);
            gbRawMaterials.Name = "gbRawMaterials";
            gbRawMaterials.Size = new Size(269, 246);
            gbRawMaterials.TabIndex = 5;
            gbRawMaterials.TabStop = false;
            // 
            // gbResearchEquipment
            // 
            gbResearchEquipment.Controls.Add(chkRDb);
            gbResearchEquipment.Controls.Add(chkAncientRelics);
            gbResearchEquipment.Controls.Add(chkDecryptors);
            gbResearchEquipment.Controls.Add(chkDatacores);
            gbResearchEquipment.Location = new Point(7, 202);
            gbResearchEquipment.Name = "gbResearchEquipment";
            gbResearchEquipment.Size = new Size(254, 37);
            gbResearchEquipment.TabIndex = 29;
            gbResearchEquipment.TabStop = false;
            gbResearchEquipment.Text = "Research Equipment";
            // 
            // chkRDb
            // 
            chkRDb.AutoSize = true;
            chkRDb.Location = new Point(203, 16);
            chkRDb.Name = "chkRDb";
            chkRDb.Size = new Size(51, 17);
            chkRDb.TabIndex = 24;
            chkRDb.Text = "R.Db";
            chkRDb.UseVisualStyleBackColor = true;
            // 
            // chkAncientRelics
            // 
            chkAncientRelics.AutoSize = true;
            chkAncientRelics.Location = new Point(151, 16);
            chkAncientRelics.Name = "chkAncientRelics";
            chkAncientRelics.Size = new Size(55, 17);
            chkAncientRelics.TabIndex = 7;
            chkAncientRelics.Text = "Relics";
            chkAncientRelics.UseVisualStyleBackColor = true;
            // 
            // chkDecryptors
            // 
            chkDecryptors.AutoSize = true;
            chkDecryptors.Location = new Point(78, 16);
            chkDecryptors.Name = "chkDecryptors";
            chkDecryptors.Size = new Size(77, 17);
            chkDecryptors.TabIndex = 4;
            chkDecryptors.Text = "Decryptors";
            chkDecryptors.UseVisualStyleBackColor = true;
            // 
            // chkDatacores
            // 
            chkDatacores.AutoSize = true;
            chkDatacores.Location = new Point(6, 16);
            chkDatacores.Name = "chkDatacores";
            chkDatacores.Size = new Size(75, 17);
            chkDatacores.TabIndex = 2;
            chkDatacores.Text = "Datacores";
            chkDatacores.UseVisualStyleBackColor = true;
            // 
            // gbReactionMaterials
            // 
            gbReactionMaterials.Controls.Add(chkAdvancedMats);
            gbReactionMaterials.Controls.Add(chkMolecularForgedMaterials);
            gbReactionMaterials.Controls.Add(chkProcessedMats);
            gbReactionMaterials.Controls.Add(chkBoosterMats);
            gbReactionMaterials.Controls.Add(chkPolymers);
            gbReactionMaterials.Controls.Add(chkRawMoonMats);
            gbReactionMaterials.Location = new Point(7, 132);
            gbReactionMaterials.Name = "gbReactionMaterials";
            gbReactionMaterials.Size = new Size(254, 68);
            gbReactionMaterials.TabIndex = 28;
            gbReactionMaterials.TabStop = false;
            gbReactionMaterials.Text = "Reaction Materials";
            // 
            // chkAdvancedMats
            // 
            chkAdvancedMats.AutoSize = true;
            chkAdvancedMats.Location = new Point(6, 15);
            chkAdvancedMats.Name = "chkAdvancedMats";
            chkAdvancedMats.Size = new Size(105, 17);
            chkAdvancedMats.TabIndex = 12;
            chkAdvancedMats.Text = "Advanced Moon";
            chkAdvancedMats.UseVisualStyleBackColor = true;
            // 
            // chkMolecularForgedMaterials
            // 
            chkMolecularForgedMaterials.AutoSize = true;
            chkMolecularForgedMaterials.Location = new Point(6, 32);
            chkMolecularForgedMaterials.Name = "chkMolecularForgedMaterials";
            chkMolecularForgedMaterials.Size = new Size(108, 17);
            chkMolecularForgedMaterials.TabIndex = 27;
            chkMolecularForgedMaterials.Text = "Molecular-Forged";
            chkMolecularForgedMaterials.UseVisualStyleBackColor = true;
            // 
            // chkProcessedMats
            // 
            chkProcessedMats.AutoSize = true;
            chkProcessedMats.Location = new Point(6, 49);
            chkProcessedMats.Name = "chkProcessedMats";
            chkProcessedMats.Size = new Size(106, 17);
            chkProcessedMats.TabIndex = 11;
            chkProcessedMats.Text = "Processed Moon";
            chkProcessedMats.UseVisualStyleBackColor = true;
            // 
            // chkBoosterMats
            // 
            chkBoosterMats.AutoSize = true;
            chkBoosterMats.Location = new Point(127, 15);
            chkBoosterMats.Name = "chkBoosterMats";
            chkBoosterMats.Size = new Size(107, 17);
            chkBoosterMats.TabIndex = 15;
            chkBoosterMats.Text = "Booster Materials";
            chkBoosterMats.UseVisualStyleBackColor = true;
            // 
            // chkPolymers
            // 
            chkPolymers.AutoSize = true;
            chkPolymers.Location = new Point(127, 32);
            chkPolymers.Name = "chkPolymers";
            chkPolymers.Size = new Size(108, 17);
            chkPolymers.TabIndex = 8;
            chkPolymers.Text = "Polymer Materials";
            chkPolymers.UseVisualStyleBackColor = true;
            // 
            // chkRawMoonMats
            // 
            chkRawMoonMats.AutoSize = true;
            chkRawMoonMats.Location = new Point(127, 49);
            chkRawMoonMats.Name = "chkRawMoonMats";
            chkRawMoonMats.Size = new Size(123, 17);
            chkRawMoonMats.TabIndex = 10;
            chkRawMoonMats.Text = "Raw Moon Materials";
            chkRawMoonMats.UseVisualStyleBackColor = true;
            // 
            // chkFactionMaterials
            // 
            chkFactionMaterials.AutoSize = true;
            chkFactionMaterials.Location = new Point(155, 58);
            chkFactionMaterials.Name = "chkFactionMaterials";
            chkFactionMaterials.Size = new Size(106, 17);
            chkFactionMaterials.TabIndex = 26;
            chkFactionMaterials.Text = "Faction Materials";
            chkFactionMaterials.UseVisualStyleBackColor = true;
            // 
            // chkMolecularForgingTools
            // 
            chkMolecularForgingTools.AutoSize = true;
            chkMolecularForgingTools.Location = new Point(13, 58);
            chkMolecularForgingTools.Name = "chkMolecularForgingTools";
            chkMolecularForgingTools.Size = new Size(139, 17);
            chkMolecularForgingTools.TabIndex = 25;
            chkMolecularForgingTools.Text = "Molecular-Forging Tools";
            chkMolecularForgingTools.UseVisualStyleBackColor = true;
            // 
            // chkAdvancedProtectiveTechnology
            // 
            chkAdvancedProtectiveTechnology.AutoSize = true;
            chkAdvancedProtectiveTechnology.Location = new Point(13, 24);
            chkAdvancedProtectiveTechnology.Name = "chkAdvancedProtectiveTechnology";
            chkAdvancedProtectiveTechnology.Size = new Size(185, 17);
            chkAdvancedProtectiveTechnology.TabIndex = 23;
            chkAdvancedProtectiveTechnology.Text = "Advanced Protective Technology";
            chkAdvancedProtectiveTechnology.UseVisualStyleBackColor = true;
            // 
            // chkBPCs
            // 
            chkBPCs.AutoSize = true;
            chkBPCs.Location = new Point(155, 109);
            chkBPCs.Name = "chkBPCs";
            chkBPCs.Size = new Size(102, 17);
            chkBPCs.TabIndex = 21;
            chkBPCs.Text = "Blueprint Copies";
            chkBPCs.UseVisualStyleBackColor = true;
            // 
            // chkMisc
            // 
            chkMisc.AutoSize = true;
            chkMisc.Location = new Point(87, 109);
            chkMisc.Name = "chkMisc";
            chkMisc.Size = new Size(51, 17);
            chkMisc.TabIndex = 20;
            chkMisc.Text = "Misc.";
            chkMisc.UseVisualStyleBackColor = true;
            // 
            // chkRawMaterials
            // 
            chkRawMaterials.AutoSize = true;
            chkRawMaterials.Location = new Point(155, 92);
            chkRawMaterials.Name = "chkRawMaterials";
            chkRawMaterials.Size = new Size(93, 17);
            chkRawMaterials.TabIndex = 19;
            chkRawMaterials.Text = "Raw Materials";
            chkRawMaterials.UseVisualStyleBackColor = true;
            // 
            // chkMaterialResearchEqPrices
            // 
            chkMaterialResearchEqPrices.AutoSize = true;
            chkMaterialResearchEqPrices.BackColor = Color.White;
            chkMaterialResearchEqPrices.Location = new Point(6, 1);
            chkMaterialResearchEqPrices.Name = "chkMaterialResearchEqPrices";
            chkMaterialResearchEqPrices.Size = new Size(179, 17);
            chkMaterialResearchEqPrices.TabIndex = 18;
            chkMaterialResearchEqPrices.Text = "Materials && Research Equipment";
            chkMaterialResearchEqPrices.UseVisualStyleBackColor = false;
            // 
            // chkPlanetary
            // 
            chkPlanetary.AutoSize = true;
            chkPlanetary.Location = new Point(13, 92);
            chkPlanetary.Name = "chkPlanetary";
            chkPlanetary.Size = new Size(115, 17);
            chkPlanetary.TabIndex = 17;
            chkPlanetary.Text = "Planetary Materials";
            chkPlanetary.UseVisualStyleBackColor = true;
            // 
            // chkNamedComponents
            // 
            chkNamedComponents.AutoSize = true;
            chkNamedComponents.Location = new Point(13, 75);
            chkNamedComponents.Name = "chkNamedComponents";
            chkNamedComponents.Size = new Size(122, 17);
            chkNamedComponents.TabIndex = 13;
            chkNamedComponents.Text = "Named Components";
            chkNamedComponents.UseVisualStyleBackColor = true;
            // 
            // chkGas
            // 
            chkGas.AutoSize = true;
            chkGas.Location = new Point(13, 41);
            chkGas.Name = "chkGas";
            chkGas.Size = new Size(120, 17);
            chkGas.TabIndex = 9;
            chkGas.Text = "Gas Cloud Materials";
            chkGas.UseVisualStyleBackColor = true;
            // 
            // chkSalvage
            // 
            chkSalvage.AutoSize = true;
            chkSalvage.Location = new Point(13, 109);
            chkSalvage.Name = "chkSalvage";
            chkSalvage.Size = new Size(65, 17);
            chkSalvage.TabIndex = 5;
            chkSalvage.Text = "Salvage";
            chkSalvage.UseVisualStyleBackColor = true;
            // 
            // chkIceProducts
            // 
            chkIceProducts.AutoSize = true;
            chkIceProducts.Location = new Point(155, 41);
            chkIceProducts.Name = "chkIceProducts";
            chkIceProducts.Size = new Size(86, 17);
            chkIceProducts.TabIndex = 1;
            chkIceProducts.Text = "Ice Products";
            chkIceProducts.UseVisualStyleBackColor = true;
            // 
            // chkMinerals
            // 
            chkMinerals.AutoSize = true;
            chkMinerals.Location = new Point(155, 75);
            chkMinerals.Name = "chkMinerals";
            chkMinerals.Size = new Size(65, 17);
            chkMinerals.TabIndex = 0;
            chkMinerals.Text = "Minerals";
            chkMinerals.UseVisualStyleBackColor = true;
            // 
            // gbManufacturedItems
            // 
            gbManufacturedItems.Controls.Add(gbComponents);
            gbManufacturedItems.Controls.Add(gbItems);
            gbManufacturedItems.Controls.Add(chkManufacturedItems);
            gbManufacturedItems.Controls.Add(gbPricesTech);
            gbManufacturedItems.Location = new Point(3, 338);
            gbManufacturedItems.Name = "gbManufacturedItems";
            gbManufacturedItems.Size = new Size(269, 308);
            gbManufacturedItems.TabIndex = 6;
            gbManufacturedItems.TabStop = false;
            // 
            // gbComponents
            // 
            gbComponents.Controls.Add(chkRAM);
            gbComponents.Controls.Add(chkStructureComponents);
            gbComponents.Controls.Add(chkProtectiveComponents);
            gbComponents.Controls.Add(chkFuelBlocks);
            gbComponents.Controls.Add(chkSubsystemComponents);
            gbComponents.Controls.Add(chkAdvancedComponents);
            gbComponents.Controls.Add(chkCapitalShipComponents);
            gbComponents.Controls.Add(chkCapT2Components);
            gbComponents.Location = new Point(6, 154);
            gbComponents.Name = "gbComponents";
            gbComponents.Size = new Size(159, 140);
            gbComponents.TabIndex = 1;
            gbComponents.TabStop = false;
            gbComponents.Text = "Components";
            // 
            // chkRAM
            // 
            chkRAM.AutoSize = true;
            chkRAM.Location = new Point(87, 118);
            chkRAM.Name = "chkRAM";
            chkRAM.Size = new Size(64, 17);
            chkRAM.TabIndex = 1;
            chkRAM.Text = "R.A.M.s";
            chkRAM.UseVisualStyleBackColor = true;
            // 
            // chkStructureComponents
            // 
            chkStructureComponents.AutoSize = true;
            chkStructureComponents.Location = new Point(8, 84);
            chkStructureComponents.Name = "chkStructureComponents";
            chkStructureComponents.Size = new Size(131, 17);
            chkStructureComponents.TabIndex = 18;
            chkStructureComponents.Text = "Structure Components";
            chkStructureComponents.UseVisualStyleBackColor = true;
            // 
            // chkProtectiveComponents
            // 
            chkProtectiveComponents.AutoSize = true;
            chkProtectiveComponents.Location = new Point(8, 101);
            chkProtectiveComponents.Name = "chkProtectiveComponents";
            chkProtectiveComponents.Size = new Size(136, 17);
            chkProtectiveComponents.TabIndex = 20;
            chkProtectiveComponents.Text = "Protective Components";
            chkProtectiveComponents.UseVisualStyleBackColor = true;
            // 
            // chkFuelBlocks
            // 
            chkFuelBlocks.AutoSize = true;
            chkFuelBlocks.Location = new Point(8, 118);
            chkFuelBlocks.Name = "chkFuelBlocks";
            chkFuelBlocks.Size = new Size(81, 17);
            chkFuelBlocks.TabIndex = 3;
            chkFuelBlocks.Text = "Fuel Blocks";
            chkFuelBlocks.UseVisualStyleBackColor = true;
            // 
            // chkSubsystemComponents
            // 
            chkSubsystemComponents.AutoSize = true;
            chkSubsystemComponents.Location = new Point(8, 67);
            chkSubsystemComponents.Name = "chkSubsystemComponents";
            chkSubsystemComponents.Size = new Size(139, 17);
            chkSubsystemComponents.TabIndex = 5;
            chkSubsystemComponents.Text = "Subsystem Components";
            chkSubsystemComponents.UseVisualStyleBackColor = true;
            // 
            // chkAdvancedComponents
            // 
            chkAdvancedComponents.AutoSize = true;
            chkAdvancedComponents.Location = new Point(8, 50);
            chkAdvancedComponents.Name = "chkAdvancedComponents";
            chkAdvancedComponents.Size = new Size(137, 17);
            chkAdvancedComponents.TabIndex = 4;
            chkAdvancedComponents.Text = "Advanced Components";
            chkAdvancedComponents.UseVisualStyleBackColor = true;
            // 
            // chkCapitalShipComponents
            // 
            chkCapitalShipComponents.AutoSize = true;
            chkCapitalShipComponents.Location = new Point(8, 33);
            chkCapitalShipComponents.Name = "chkCapitalShipComponents";
            chkCapitalShipComponents.Size = new Size(144, 17);
            chkCapitalShipComponents.TabIndex = 3;
            chkCapitalShipComponents.Text = "Capital Ship Components";
            chkCapitalShipComponents.UseVisualStyleBackColor = true;
            // 
            // chkCapT2Components
            // 
            chkCapT2Components.AutoSize = true;
            chkCapT2Components.Location = new Point(8, 16);
            chkCapT2Components.Name = "chkCapT2Components";
            chkCapT2Components.Size = new Size(145, 17);
            chkCapT2Components.TabIndex = 2;
            chkCapT2Components.Text = "Adv. Capital Components";
            chkCapT2Components.UseVisualStyleBackColor = true;
            // 
            // gbItems
            // 
            gbItems.Controls.Add(chkNobuild);
            gbItems.Controls.Add(chkImplants);
            gbItems.Controls.Add(chkBoosters);
            gbItems.Controls.Add(chkDeployables);
            gbItems.Controls.Add(chkStructureModules);
            gbItems.Controls.Add(chkCelestials);
            gbItems.Controls.Add(chkStructures);
            gbItems.Controls.Add(chkStructureRigs);
            gbItems.Controls.Add(chkSubsystems);
            gbItems.Controls.Add(chkRigs);
            gbItems.Controls.Add(cmbPriceChargeTypes);
            gbItems.Controls.Add(chkCharges);
            gbItems.Controls.Add(cmbPriceShipTypes);
            gbItems.Controls.Add(chkDrones);
            gbItems.Controls.Add(chkModules);
            gbItems.Controls.Add(chkShips);
            gbItems.Location = new Point(6, 19);
            gbItems.Name = "gbItems";
            gbItems.Size = new Size(255, 133);
            gbItems.TabIndex = 0;
            gbItems.TabStop = false;
            gbItems.Text = "Items";
            // 
            // chkNobuild
            // 
            chkNobuild.AutoSize = true;
            chkNobuild.Location = new Point(182, 111);
            chkNobuild.Name = "chkNobuild";
            chkNobuild.Size = new Size(66, 17);
            chkNobuild.TabIndex = 21;
            chkNobuild.Text = "No Build";
            chkNobuild.UseVisualStyleBackColor = true;
            // 
            // chkImplants
            // 
            chkImplants.AutoSize = true;
            chkImplants.Location = new Point(119, 111);
            chkImplants.Name = "chkImplants";
            chkImplants.Size = new Size(65, 17);
            chkImplants.TabIndex = 251;
            chkImplants.Text = "Implants";
            chkImplants.UseVisualStyleBackColor = true;
            // 
            // chkBoosters
            // 
            chkBoosters.AutoSize = true;
            chkBoosters.Location = new Point(182, 77);
            chkBoosters.Name = "chkBoosters";
            chkBoosters.Size = new Size(67, 17);
            chkBoosters.TabIndex = 6;
            chkBoosters.Text = "Boosters";
            chkBoosters.UseVisualStyleBackColor = true;
            // 
            // chkDeployables
            // 
            chkDeployables.AutoSize = true;
            chkDeployables.Location = new Point(91, 77);
            chkDeployables.Name = "chkDeployables";
            chkDeployables.Size = new Size(84, 17);
            chkDeployables.TabIndex = 253;
            chkDeployables.Text = "Deployables";
            chkDeployables.UseVisualStyleBackColor = true;
            // 
            // chkStructureModules
            // 
            chkStructureModules.AutoSize = true;
            chkStructureModules.Location = new Point(9, 111);
            chkStructureModules.Name = "chkStructureModules";
            chkStructureModules.Size = new Size(112, 17);
            chkStructureModules.TabIndex = 254;
            chkStructureModules.Text = "Structure Modules";
            chkStructureModules.UseVisualStyleBackColor = true;
            // 
            // chkCelestials
            // 
            chkCelestials.AutoSize = true;
            chkCelestials.Location = new Point(182, 94);
            chkCelestials.Name = "chkCelestials";
            chkCelestials.Size = new Size(70, 17);
            chkCelestials.TabIndex = 252;
            chkCelestials.Text = "Celestials";
            chkCelestials.UseVisualStyleBackColor = true;
            // 
            // chkStructures
            // 
            chkStructures.AutoSize = true;
            chkStructures.Location = new Point(9, 94);
            chkStructures.Name = "chkStructures";
            chkStructures.Size = new Size(74, 17);
            chkStructures.TabIndex = 7;
            chkStructures.Text = "Structures";
            chkStructures.UseVisualStyleBackColor = true;
            // 
            // chkStructureRigs
            // 
            chkStructureRigs.AutoSize = true;
            chkStructureRigs.Location = new Point(91, 94);
            chkStructureRigs.Name = "chkStructureRigs";
            chkStructureRigs.Size = new Size(93, 17);
            chkStructureRigs.TabIndex = 16;
            chkStructureRigs.Text = "Structure Rigs";
            chkStructureRigs.UseVisualStyleBackColor = true;
            // 
            // chkSubsystems
            // 
            chkSubsystems.AutoSize = true;
            chkSubsystems.Location = new Point(9, 77);
            chkSubsystems.Name = "chkSubsystems";
            chkSubsystems.Size = new Size(82, 17);
            chkSubsystems.TabIndex = 3;
            chkSubsystems.Text = "Subsystems";
            chkSubsystems.UseVisualStyleBackColor = true;
            // 
            // chkRigs
            // 
            chkRigs.AutoSize = true;
            chkRigs.Location = new Point(182, 60);
            chkRigs.Name = "chkRigs";
            chkRigs.Size = new Size(47, 17);
            chkRigs.TabIndex = 5;
            chkRigs.Text = "Rigs";
            chkRigs.UseVisualStyleBackColor = true;
            // 
            // cmbPriceChargeTypes
            // 
            cmbPriceChargeTypes.FormattingEnabled = true;
            cmbPriceChargeTypes.Location = new Point(70, 35);
            cmbPriceChargeTypes.Name = "cmbPriceChargeTypes";
            cmbPriceChargeTypes.Size = new Size(178, 21);
            cmbPriceChargeTypes.TabIndex = 10;
            cmbPriceChargeTypes.Text = "All Charge Types";
            // 
            // chkCharges
            // 
            chkCharges.AutoSize = true;
            chkCharges.Location = new Point(10, 37);
            chkCharges.Name = "chkCharges";
            chkCharges.Size = new Size(65, 17);
            chkCharges.TabIndex = 8;
            chkCharges.Text = "Charges";
            chkCharges.UseVisualStyleBackColor = true;
            // 
            // cmbPriceShipTypes
            // 
            cmbPriceShipTypes.FormattingEnabled = true;
            cmbPriceShipTypes.Location = new Point(70, 12);
            cmbPriceShipTypes.Name = "cmbPriceShipTypes";
            cmbPriceShipTypes.Size = new Size(178, 21);
            cmbPriceShipTypes.TabIndex = 9;
            cmbPriceShipTypes.Text = "All Ship Types";
            // 
            // chkDrones
            // 
            chkDrones.AutoSize = true;
            chkDrones.Location = new Point(91, 60);
            chkDrones.Name = "chkDrones";
            chkDrones.Size = new Size(60, 17);
            chkDrones.TabIndex = 2;
            chkDrones.Text = "Drones";
            chkDrones.UseVisualStyleBackColor = true;
            // 
            // chkModules
            // 
            chkModules.AutoSize = true;
            chkModules.Location = new Point(9, 60);
            chkModules.Name = "chkModules";
            chkModules.Size = new Size(66, 17);
            chkModules.TabIndex = 1;
            chkModules.Text = "Modules";
            chkModules.UseVisualStyleBackColor = true;
            // 
            // chkShips
            // 
            chkShips.AutoSize = true;
            chkShips.Location = new Point(10, 14);
            chkShips.Name = "chkShips";
            chkShips.Size = new Size(52, 17);
            chkShips.TabIndex = 4;
            chkShips.Text = "Ships";
            chkShips.UseVisualStyleBackColor = true;
            // 
            // chkManufacturedItems
            // 
            chkManufacturedItems.AutoSize = true;
            chkManufacturedItems.BackColor = Color.White;
            chkManufacturedItems.Location = new Point(6, 1);
            chkManufacturedItems.Name = "chkManufacturedItems";
            chkManufacturedItems.Size = new Size(120, 17);
            chkManufacturedItems.TabIndex = 19;
            chkManufacturedItems.Text = "Manufactured Items";
            chkManufacturedItems.UseVisualStyleBackColor = false;
            // 
            // gbPricesTech
            // 
            gbPricesTech.Controls.Add(chkItemsT4);
            gbPricesTech.Controls.Add(chkItemsT6);
            gbPricesTech.Controls.Add(chkItemsT5);
            gbPricesTech.Controls.Add(chkItemsT3);
            gbPricesTech.Controls.Add(chkItemsT2);
            gbPricesTech.Controls.Add(chkItemsT1);
            gbPricesTech.Location = new Point(167, 154);
            gbPricesTech.Name = "gbPricesTech";
            gbPricesTech.Size = new Size(94, 140);
            gbPricesTech.TabIndex = 0;
            gbPricesTech.TabStop = false;
            // 
            // chkItemsT4
            // 
            chkItemsT4.AutoSize = true;
            chkItemsT4.Enabled = false;
            chkItemsT4.Location = new Point(6, 67);
            chkItemsT4.Name = "chkItemsT4";
            chkItemsT4.Size = new Size(66, 17);
            chkItemsT4.TabIndex = 3;
            chkItemsT4.Text = "Storyline";
            chkItemsT4.TextAlign = ContentAlignment.TopLeft;
            chkItemsT4.UseVisualStyleBackColor = true;
            // 
            // chkItemsT6
            // 
            chkItemsT6.AutoSize = true;
            chkItemsT6.Enabled = false;
            chkItemsT6.Location = new Point(6, 101);
            chkItemsT6.Name = "chkItemsT6";
            chkItemsT6.Size = new Size(91, 17);
            chkItemsT6.TabIndex = 9;
            chkItemsT6.Text = "Pirate Faction";
            chkItemsT6.TextAlign = ContentAlignment.TopLeft;
            chkItemsT6.UseVisualStyleBackColor = true;
            // 
            // chkItemsT5
            // 
            chkItemsT5.AutoSize = true;
            chkItemsT5.Enabled = false;
            chkItemsT5.Location = new Point(6, 84);
            chkItemsT5.Name = "chkItemsT5";
            chkItemsT5.Size = new Size(89, 17);
            chkItemsT5.TabIndex = 8;
            chkItemsT5.Text = "Navy Faction";
            chkItemsT5.TextAlign = ContentAlignment.TopLeft;
            chkItemsT5.UseVisualStyleBackColor = true;
            // 
            // chkItemsT3
            // 
            chkItemsT3.AutoSize = true;
            chkItemsT3.Enabled = false;
            chkItemsT3.Location = new Point(6, 50);
            chkItemsT3.Name = "chkItemsT3";
            chkItemsT3.Size = new Size(60, 17);
            chkItemsT3.TabIndex = 2;
            chkItemsT3.Text = "Tech 3";
            chkItemsT3.UseVisualStyleBackColor = true;
            // 
            // chkItemsT2
            // 
            chkItemsT2.AutoSize = true;
            chkItemsT2.Enabled = false;
            chkItemsT2.Location = new Point(6, 33);
            chkItemsT2.Name = "chkItemsT2";
            chkItemsT2.Size = new Size(60, 17);
            chkItemsT2.TabIndex = 1;
            chkItemsT2.Text = "Tech 2";
            chkItemsT2.UseVisualStyleBackColor = true;
            // 
            // chkItemsT1
            // 
            chkItemsT1.AutoSize = true;
            chkItemsT1.Enabled = false;
            chkItemsT1.Location = new Point(6, 16);
            chkItemsT1.Name = "chkItemsT1";
            chkItemsT1.Size = new Size(60, 17);
            chkItemsT1.TabIndex = 0;
            chkItemsT1.Text = "Tech 1";
            chkItemsT1.UseVisualStyleBackColor = true;
            // 
            // btnResetItemFilter
            // 
            btnResetItemFilter.Location = new Point(95, 62);
            btnResetItemFilter.Name = "btnResetItemFilter";
            btnResetItemFilter.Size = new Size(86, 24);
            btnResetItemFilter.TabIndex = 244;
            btnResetItemFilter.Text = "Reset";
            btnResetItemFilter.UseVisualStyleBackColor = true;
            // 
            // txtItemFilter
            // 
            txtItemFilter.Location = new Point(63, 36);
            txtItemFilter.Name = "txtItemFilter";
            txtItemFilter.Size = new Size(208, 20);
            txtItemFilter.TabIndex = 243;
            // 
            // AssetTree
            // 
            AssetTree.CheckBoxes = true;
            AssetTree.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            AssetTree.Location = new Point(3, 3);
            AssetTree.Name = "AssetTree";
            AssetTree.Size = new Size(346, 660);
            AssetTree.TabIndex = 252;
            // 
            // Timer1
            // 
            // 
            // ttMain
            // 
            ttMain.IsBalloon = true;
            // 
            // chkToggle
            // 
            chkToggle.AutoSize = true;
            chkToggle.BackColor = Color.Transparent;
            chkToggle.Location = new Point(306, 9);
            chkToggle.Name = "chkToggle";
            chkToggle.Size = new Size(15, 14);
            chkToggle.TabIndex = 254;
            chkToggle.UseVisualStyleBackColor = false;
            // 
            // btnToggleRetract
            // 
            btnToggleRetract.FlatStyle = FlatStyle.Flat;
            btnToggleRetract.ForeColor = SystemColors.AppWorkspace;
            btnToggleRetract.Image = (Image)resources.GetObject("btnToggleRetract.Image");
            btnToggleRetract.Location = new Point(324, 3);
            btnToggleRetract.Name = "btnToggleRetract";
            btnToggleRetract.Size = new Size(25, 25);
            btnToggleRetract.TabIndex = 253;
            btnToggleRetract.UseVisualStyleBackColor = false;
            // 
            // btnCheckToggle
            // 
            btnCheckToggle.Enabled = false;
            btnCheckToggle.FlatStyle = FlatStyle.Flat;
            btnCheckToggle.ForeColor = SystemColors.AppWorkspace;
            btnCheckToggle.Location = new Point(300, 3);
            btnCheckToggle.Name = "btnCheckToggle";
            btnCheckToggle.Size = new Size(25, 25);
            btnCheckToggle.TabIndex = 250;
            btnCheckToggle.UseVisualStyleBackColor = false;
            // 
            // btnToggleExpand
            // 
            btnToggleExpand.FlatStyle = FlatStyle.Flat;
            btnToggleExpand.ForeColor = SystemColors.AppWorkspace;
            btnToggleExpand.Image = (Image)resources.GetObject("btnToggleExpand.Image");
            btnToggleExpand.Location = new Point(324, 3);
            btnToggleExpand.Name = "btnToggleExpand";
            btnToggleExpand.Size = new Size(25, 25);
            btnToggleExpand.TabIndex = 255;
            btnToggleExpand.UseVisualStyleBackColor = false;
            // 
            // AssetViewer
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnToggleExpand);
            Controls.Add(chkToggle);
            Controls.Add(btnCheckToggle);
            Controls.Add(btnToggleRetract);
            Controls.Add(tabMain);
            Controls.Add(AssetTree);
            Name = "AssetViewer";
            Size = new Size(640, 667);
            tabMain.ResumeLayout(false);
            tabAssetMain.ResumeLayout(false);
            gbAssetTypes.ResumeLayout(false);
            gbAssetTypes.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            gbSortOptions.ResumeLayout(false);
            gbSortOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSpaceFiller).EndInit();
            tabSearchSettings.ResumeLayout(false);
            tabSearchSettings.PerformLayout();
            gbRawMaterials.ResumeLayout(false);
            gbRawMaterials.PerformLayout();
            gbResearchEquipment.ResumeLayout(false);
            gbResearchEquipment.PerformLayout();
            gbReactionMaterials.ResumeLayout(false);
            gbReactionMaterials.PerformLayout();
            gbManufacturedItems.ResumeLayout(false);
            gbManufacturedItems.PerformLayout();
            gbComponents.ResumeLayout(false);
            gbComponents.PerformLayout();
            gbItems.ResumeLayout(false);
            gbItems.PerformLayout();
            gbPricesTech.ResumeLayout(false);
            gbPricesTech.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        internal TabControl tabMain;
        internal TabPage tabAssetMain;
        internal Button btnSaveMainSettings;
        internal GroupBox gbAssetTypes;
        internal RadioButton rbtnAllAssets;
        internal RadioButton rbtnCorpAssets;
        internal RadioButton rbtnPersonalAssets;
        internal GroupBox GroupBox1;
        internal Label lblReloadCorpAssets;
        internal Label lblReloadPersonalAssets;
        internal Button btnScanCorpAssets;
        internal Label lblReloadCorpAssets2;
        internal Button btnScanPersonalAssets;
        internal Label lblReloadPersonalAssets1;
        internal GroupBox gbSortOptions;
        internal RadioButton rbtnSortQuantity;
        internal RadioButton rbtnSortName;
        internal PictureBox picSpaceFiller;
        internal Button btnCloseAssets;
        internal TabPage tabSearchSettings;
        internal RadioButton rbtnBPMats;
        internal Button btnSaveSettings;
        internal Button btnSearchRefresh;
        internal RadioButton rbtnAllItems;
        internal Label lblItemFilter;
        internal Button btnResetItemFilter;
        internal TextBox txtItemFilter;
        internal GroupBox gbManufacturedItems;
        internal GroupBox gbItems;
        internal CheckBox chkStructureModules;
        internal CheckBox chkImplants;
        internal CheckBox chkCelestials;
        internal CheckBox chkRAM;
        internal CheckBox chkFuelBlocks;
        internal CheckBox chkStructureRigs;
        internal ComboBox cmbPriceChargeTypes;
        internal CheckBox chkCharges;
        internal CheckBox chkStructures;
        internal CheckBox chkBoosters;
        internal CheckBox chkRigs;
        internal ComboBox cmbPriceShipTypes;
        internal CheckBox chkSubsystems;
        internal CheckBox chkDrones;
        internal CheckBox chkModules;
        internal CheckBox chkShips;
        internal CheckBox chkDeployables;
        internal GroupBox gbPricesTech;
        internal CheckBox chkItemsT4;
        internal CheckBox chkItemsT6;
        internal CheckBox chkItemsT5;
        internal CheckBox chkItemsT3;
        internal CheckBox chkItemsT2;
        internal CheckBox chkItemsT1;
        internal CheckBox chkManufacturedItems;
        internal GroupBox gbComponents;
        internal CheckBox chkStructureComponents;
        internal CheckBox chkSubsystemComponents;
        internal CheckBox chkAdvancedComponents;
        internal CheckBox chkCapitalShipComponents;
        internal CheckBox chkCapT2Components;
        internal GroupBox gbRawMaterials;
        internal CheckBox chkBPCs;
        internal CheckBox chkMisc;
        internal CheckBox chkRawMaterials;
        internal CheckBox chkMaterialResearchEqPrices;
        internal CheckBox chkPlanetary;
        internal CheckBox chkBoosterMats;
        internal CheckBox chkNamedComponents;
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
        internal TreeView AssetTree;
        internal Timer Timer1;
        internal ToolTip ttMain;
        internal CheckBox chkToggle;
        internal Button btnToggleRetract;
        internal Button btnCheckToggle;
        internal Button btnToggleExpand;
        internal CheckBox chkAdvancedProtectiveTechnology;
        internal CheckBox chkRDb;
        internal CheckBox chkMolecularForgingTools;
        internal CheckBox chkFactionMaterials;
        internal CheckBox chkMolecularForgedMaterials;
        internal GroupBox gbResearchEquipment;
        internal GroupBox gbReactionMaterials;
        internal CheckBox chkProtectiveComponents;
        internal CheckBox chkNobuild;
    }
}