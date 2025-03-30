using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmBlueprintManagement : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBlueprintManagement));
            gbBPFilter = new GroupBox();
            gbBlueprintTech = new GroupBox();
            chkBPPirateFaction = new CheckBox();
            chkBPPirateFaction.CheckedChanged += new EventHandler(chkBPPirateFaction_CheckedChanged);
            chkBPStoryline = new CheckBox();
            chkBPStoryline.CheckedChanged += new EventHandler(chkBPStoryline_CheckedChanged);
            chkBPNavyFaction = new CheckBox();
            chkBPNavyFaction.CheckedChanged += new EventHandler(chkBPNavyFaction_CheckedChanged);
            chkBPT3 = new CheckBox();
            chkBPT3.CheckedChanged += new EventHandler(chkBPT3_CheckedChanged);
            chkBPT2 = new CheckBox();
            chkBPT2.CheckedChanged += new EventHandler(chkBPT2_CheckedChanged);
            chkBPT1 = new CheckBox();
            chkBPT1.CheckedChanged += new EventHandler(chkBPT1_CheckedChanged);
            gbBackup = new GroupBox();
            btnLoadBPs = new Button();
            btnLoadBPs.Click += new EventHandler(btnLoadBPs_Click);
            btnBackupBPs = new Button();
            btnBackupBPs.Click += new EventHandler(btnBackupBPs_Click);
            gbRace = new GroupBox();
            chkRacePirate = new CheckBox();
            chkRacePirate.CheckedChanged += new EventHandler(chkRacePirate_CheckedChanged);
            chkRaceOther = new CheckBox();
            chkRaceOther.CheckedChanged += new EventHandler(chkRaceOther_CheckedChanged);
            chkRaceGallente = new CheckBox();
            chkRaceGallente.CheckedChanged += new EventHandler(chkRaceGallente_CheckedChanged);
            chkRaceCaldari = new CheckBox();
            chkRaceCaldari.CheckedChanged += new EventHandler(chkRaceCaldari_CheckedChanged);
            chkRaceAmarr = new CheckBox();
            chkRaceAmarr.CheckedChanged += new EventHandler(chkRaceAmarr_CheckedChanged);
            chkRaceMinmatar = new CheckBox();
            chkRaceMinmatar.CheckedChanged += new EventHandler(chkRaceMinmatar_CheckedChanged);
            gbSize = new GroupBox();
            chkBPXL = new CheckBox();
            chkBPXL.CheckedChanged += new EventHandler(chkBPXL_CheckedChanged);
            chkBPLarge = new CheckBox();
            chkBPLarge.CheckedChanged += new EventHandler(chkBPLarge_CheckedChanged);
            chkBPMedium = new CheckBox();
            chkBPMedium.CheckedChanged += new EventHandler(chkBPMedium_CheckedChanged);
            chkBPSmall = new CheckBox();
            chkBPSmall.CheckedChanged += new EventHandler(chkBPSmall_CheckedChanged);
            gbBPCopyOptions = new GroupBox();
            rbtnOnlyInventedBPCs = new RadioButton();
            rbtnOnlyInventedBPCs.CheckedChanged += new EventHandler(rbtnOnlyInventedBPCs_CheckedChanged);
            rbtnOnlyBPO = new RadioButton();
            rbtnOnlyBPO.CheckedChanged += new EventHandler(rbtnBPOnlyBPO_CheckedChanged);
            rbtnOnlyCopies = new RadioButton();
            rbtnOnlyCopies.CheckedChanged += new EventHandler(rbtnBPOnlyCopies_CheckedChanged);
            rbtnShowAllBPtypes = new RadioButton();
            rbtnShowAllBPtypes.CheckedChanged += new EventHandler(rbtnBPAllBPtypes_CheckedChanged);
            gbBPTextSearch = new GroupBox();
            btnResetSearch = new Button();
            btnResetSearch.Click += new EventHandler(btnResetSearch_Click);
            txtBPSearch = new TextBox();
            txtBPSearch.GotFocus += new EventHandler(txtBPSearch_GotFocus);
            txtBPSearch.KeyDown += new KeyEventHandler(txtBPSearch_KeyDown);
            btnBPSearch = new Button();
            btnBPSearch.Click += new EventHandler(btnBPSearch_Click);
            grpScanAssets = new GroupBox();
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnReset = new Button();
            btnReset.Click += new EventHandler(btnReset_Click);
            btnScanCorpBPs = new Button();
            btnScanCorpBPs.Click += new EventHandler(btnScanCorpBPs_Click);
            btnResetAll = new Button();
            btnResetAll.Click += new EventHandler(btnResetAll_Click);
            btnScanPersonalBPs = new Button();
            btnScanPersonalBPs.Click += new EventHandler(btnScanPersonalBPs_Click);
            btnRefresh = new Button();
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            gbItemTypeFilter = new GroupBox();
            cmbBPTypeFilter = new ComboBox();
            cmbBPTypeFilter.DropDown += new EventHandler(cmbBPTypeFilter_DropDown);
            cmbBPTypeFilter.SelectedIndexChanged += new EventHandler(cmbBPTypeFilter_SelectedIndexChanged);
            lblBPCombo = new Label();
            gbBlueprintType = new GroupBox();
            rbtnReactionBlueprints = new RadioButton();
            rbtnReactionBlueprints.CheckedChanged += new EventHandler(rbtnReactionBlueprints_CheckedChanged);
            rbtnStructureBlueprints = new RadioButton();
            rbtnStructureBlueprints.CheckedChanged += new EventHandler(rbtnStructureBlueprints_CheckedChanged);
            rbtnCelestialsBlueprints = new RadioButton();
            rbtnCelestialsBlueprints.CheckedChanged += new EventHandler(rbtnCelestialBlueprints_CheckedChanged);
            rbtnStructureModulesBlueprints = new RadioButton();
            rbtnStructureModulesBlueprints.CheckedChanged += new EventHandler(rbtnStructureModulesBlueprints_CheckedChanged);
            rbtnAmmoChargeBlueprints = new RadioButton();
            rbtnAmmoChargeBlueprints.CheckedChanged += new EventHandler(rbtnAmmoChargeBlueprints_CheckedChanged);
            rbtnDeployableBlueprints = new RadioButton();
            rbtnDeployableBlueprints.CheckedChanged += new EventHandler(rbtnDeployableBlueprints_CheckedChanged);
            rbtnAllBPTypes = new RadioButton();
            rbtnAllBPTypes.CheckedChanged += new EventHandler(rbtnAllBPTypes_CheckedChanged);
            rbtnRigBlueprints = new RadioButton();
            rbtnRigBlueprints.CheckedChanged += new EventHandler(rbtnRigBlueprints_CheckedChanged);
            rbtnBoosterBlueprints = new RadioButton();
            rbtnBoosterBlueprints.CheckedChanged += new EventHandler(rbtnBoosterBlueprints_CheckedChanged);
            rbtnSubsystemBlueprints = new RadioButton();
            rbtnSubsystemBlueprints.CheckedChanged += new EventHandler(rbtnSubsystemBlueprints_CheckedChanged);
            rbtnModuleBlueprints = new RadioButton();
            rbtnModuleBlueprints.CheckedChanged += new EventHandler(rbtnModuleBlueprints_CheckedChanged);
            rbtnMiscBlueprints = new RadioButton();
            rbtnMiscBlueprints.CheckedChanged += new EventHandler(rbtnToolBlueprints_CheckedChanged);
            rbtnDroneBlueprints = new RadioButton();
            rbtnDroneBlueprints.CheckedChanged += new EventHandler(rbtnDroneBlueprints_CheckedChanged);
            rbtnComponentBlueprints = new RadioButton();
            rbtnComponentBlueprints.CheckedChanged += new EventHandler(rbtnComponentBlueprints_CheckedChanged);
            rbtnShipBlueprints = new RadioButton();
            rbtnShipBlueprints.CheckedChanged += new EventHandler(rbtnShipBlueprints_CheckedChanged);
            rbtnStructureRigsBlueprints = new RadioButton();
            rbtnStructureRigsBlueprints.CheckedChanged += new EventHandler(rbtnStationPartsBlueprints_CheckedChanged);
            gbBPSelect = new GroupBox();
            chkNotIgnored = new CheckBox();
            chkNotIgnored.CheckedChanged += new EventHandler(chkNotIgnored_CheckedChanged);
            chkNotOwned = new CheckBox();
            chkNotOwned.CheckedChanged += new EventHandler(chkNotOwned_CheckedChanged);
            lblScanCorpColor = new Label();
            rbtnIgnored = new RadioButton();
            rbtnIgnored.CheckedChanged += new EventHandler(rbtnIgnored_CheckedChanged);
            lblScanPersonalColor = new Label();
            rbtnScannedCorpBPs = new RadioButton();
            rbtnScannedCorpBPs.CheckedChanged += new EventHandler(rbtnScannedCorpBPs_CheckedChanged);
            rbtnScannedPersonalBPs = new RadioButton();
            rbtnScannedPersonalBPs.CheckedChanged += new EventHandler(rbtnScannedPersonalBPs_CheckedChanged);
            rbtnFavorites = new RadioButton();
            rbtnFavorites.CheckedChanged += new EventHandler(rbtnFavorites_CheckedChanged);
            rbtnAllBPs = new RadioButton();
            rbtnAllBPs.CheckedChanged += new EventHandler(rbtnAll_CheckedChanged);
            rbtnOwned = new RadioButton();
            rbtnOwned.CheckedChanged += new EventHandler(rbtnOwned_CheckedChanged);
            gbUpdateOptions = new GroupBox();
            rbtnRemoveAllSettings = new RadioButton();
            rbtnRemoveAllSettings.CheckedChanged += new EventHandler(rbtnRemoveAllSettings_CheckedChanged);
            chkMarkasIgnored = new CheckBox();
            chkMarkasFavorite = new CheckBox();
            chkEnableMETE = new CheckBox();
            chkEnableMETE.CheckedChanged += new EventHandler(chkEnableMETE_CheckedChanged);
            rbtnMarkasUnowned = new RadioButton();
            rbtnMarkasUnowned.CheckedChanged += new EventHandler(rbtnMarkasUnowned_CheckedChanged);
            btnUpdateSelected = new Button();
            btnUpdateSelected.Click += new EventHandler(btnUpdateSelected_Click);
            txtBPTE = new TextBox();
            txtBPTE.KeyPress += new KeyPressEventHandler(txtBPPE_KeyPress);
            txtBPTE.TextChanged += new EventHandler(txtBPTE_TextChanged);
            btnSelectAll = new Button();
            btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            rbtnMarkasOwned = new RadioButton();
            rbtnMarkasOwned.CheckedChanged += new EventHandler(rbtnMarkasOwned_CheckedChanged);
            lblBPTE = new Label();
            txtBPME = new TextBox();
            txtBPME.KeyPress += new KeyPressEventHandler(txtBPME_KeyPress);
            txtBPME.TextChanged += new EventHandler(txtBPME_TextChanged);
            lblBPME = new Label();
            txtBPEdit = new TextBox();
            txtBPEdit.GotFocus += new EventHandler(txtBPEdit_GotFocus);
            txtBPEdit.KeyDown += new KeyEventHandler(txtBPEdit_KeyDown);
            txtBPEdit.KeyPress += new KeyPressEventHandler(txtBPEdit_KeyPress);
            txtBPEdit.LostFocus += new EventHandler(txtBPEdit_LostFocus);
            txtBPEdit.TextChanged += new EventHandler(txtBPEdit_TextChanged);
            ttBPManage = new ToolTip(components);
            SaveFileDialog = new SaveFileDialog();
            OpenFileDialog = new OpenFileDialog();
            cmbEdit = new ComboBox();
            cmbEdit.LostFocus += new EventHandler(cmbEdit_LostFocus);
            cmbEdit.LostFocus += new EventHandler(cmbEdit_LostFocus);
            cmbEdit.SelectedIndexChanged += new EventHandler(cmbEdit_SelectedIndexChanged);
            lstBPs = new MyListView();
            lstBPs.ColumnClick += new ColumnClickEventHandler(lstBPs_ColumnClick);
            lstBPs.SelectedIndexChanged += new EventHandler(lstBPs_SelectedIndexChanged);
            lstBPs.MouseClick += new MouseEventHandler(lstBPs_MouseClick);
            lstBPs.ProcMsg += new MyListView.ProcMsgEventHandler(lstBPs_ProcMsg);
            gbBPFilter.SuspendLayout();
            gbBlueprintTech.SuspendLayout();
            gbBackup.SuspendLayout();
            gbRace.SuspendLayout();
            gbSize.SuspendLayout();
            gbBPCopyOptions.SuspendLayout();
            gbBPTextSearch.SuspendLayout();
            grpScanAssets.SuspendLayout();
            gbItemTypeFilter.SuspendLayout();
            gbBlueprintType.SuspendLayout();
            gbBPSelect.SuspendLayout();
            gbUpdateOptions.SuspendLayout();
            SuspendLayout();
            // 
            // gbBPFilter
            // 
            gbBPFilter.Controls.Add(gbBlueprintTech);
            gbBPFilter.Controls.Add(gbBackup);
            gbBPFilter.Controls.Add(gbRace);
            gbBPFilter.Controls.Add(gbSize);
            gbBPFilter.Controls.Add(gbBPCopyOptions);
            gbBPFilter.Controls.Add(gbBPTextSearch);
            gbBPFilter.Controls.Add(grpScanAssets);
            gbBPFilter.Controls.Add(gbItemTypeFilter);
            gbBPFilter.Controls.Add(gbBlueprintType);
            gbBPFilter.Controls.Add(gbBPSelect);
            gbBPFilter.Controls.Add(gbUpdateOptions);
            gbBPFilter.Location = new Point(6, 370);
            gbBPFilter.Name = "gbBPFilter";
            gbBPFilter.Size = new Size(1105, 240);
            gbBPFilter.TabIndex = 0;
            gbBPFilter.TabStop = false;
            gbBPFilter.Text = "Blueprint Filters";
            // 
            // gbBlueprintTech
            // 
            gbBlueprintTech.Controls.Add(chkBPPirateFaction);
            gbBlueprintTech.Controls.Add(chkBPStoryline);
            gbBlueprintTech.Controls.Add(chkBPNavyFaction);
            gbBlueprintTech.Controls.Add(chkBPT3);
            gbBlueprintTech.Controls.Add(chkBPT2);
            gbBlueprintTech.Controls.Add(chkBPT1);
            gbBlueprintTech.Location = new Point(333, 13);
            gbBlueprintTech.Name = "gbBlueprintTech";
            gbBlueprintTech.Size = new Size(101, 122);
            gbBlueprintTech.TabIndex = 2;
            gbBlueprintTech.TabStop = false;
            gbBlueprintTech.Text = "Tech";
            // 
            // chkBPPirateFaction
            // 
            chkBPPirateFaction.AutoSize = true;
            chkBPPirateFaction.Location = new Point(9, 100);
            chkBPPirateFaction.Name = "chkBPPirateFaction";
            chkBPPirateFaction.Size = new Size(91, 17);
            chkBPPirateFaction.TabIndex = 22;
            chkBPPirateFaction.Text = "Pirate Faction";
            chkBPPirateFaction.TextAlign = ContentAlignment.TopLeft;
            chkBPPirateFaction.UseVisualStyleBackColor = true;
            // 
            // chkBPStoryline
            // 
            chkBPStoryline.AutoSize = true;
            chkBPStoryline.Location = new Point(9, 66);
            chkBPStoryline.Name = "chkBPStoryline";
            chkBPStoryline.Size = new Size(66, 17);
            chkBPStoryline.TabIndex = 20;
            chkBPStoryline.Text = "Storyline";
            chkBPStoryline.UseVisualStyleBackColor = true;
            // 
            // chkBPNavyFaction
            // 
            chkBPNavyFaction.AutoSize = true;
            chkBPNavyFaction.Location = new Point(9, 83);
            chkBPNavyFaction.Name = "chkBPNavyFaction";
            chkBPNavyFaction.Size = new Size(89, 17);
            chkBPNavyFaction.TabIndex = 21;
            chkBPNavyFaction.Text = "Navy Faction";
            chkBPNavyFaction.TextAlign = ContentAlignment.TopLeft;
            chkBPNavyFaction.UseVisualStyleBackColor = true;
            // 
            // chkBPT3
            // 
            chkBPT3.AutoSize = true;
            chkBPT3.Location = new Point(9, 49);
            chkBPT3.Name = "chkBPT3";
            chkBPT3.Size = new Size(60, 17);
            chkBPT3.TabIndex = 19;
            chkBPT3.Text = "Tech 3";
            chkBPT3.UseVisualStyleBackColor = true;
            // 
            // chkBPT2
            // 
            chkBPT2.AutoSize = true;
            chkBPT2.Location = new Point(9, 32);
            chkBPT2.Name = "chkBPT2";
            chkBPT2.Size = new Size(60, 17);
            chkBPT2.TabIndex = 18;
            chkBPT2.Text = "Tech 2";
            chkBPT2.UseVisualStyleBackColor = true;
            // 
            // chkBPT1
            // 
            chkBPT1.AutoSize = true;
            chkBPT1.Location = new Point(9, 15);
            chkBPT1.Name = "chkBPT1";
            chkBPT1.Size = new Size(60, 17);
            chkBPT1.TabIndex = 17;
            chkBPT1.Text = "Tech 1";
            chkBPT1.UseVisualStyleBackColor = true;
            // 
            // gbBackup
            // 
            gbBackup.Controls.Add(btnLoadBPs);
            gbBackup.Controls.Add(btnBackupBPs);
            gbBackup.Location = new Point(804, 10);
            gbBackup.Name = "gbBackup";
            gbBackup.Size = new Size(132, 75);
            gbBackup.TabIndex = 44;
            gbBackup.TabStop = false;
            // 
            // btnLoadBPs
            // 
            btnLoadBPs.Location = new Point(6, 41);
            btnLoadBPs.Name = "btnLoadBPs";
            btnLoadBPs.Size = new Size(120, 29);
            btnLoadBPs.TabIndex = 42;
            btnLoadBPs.Text = "Load BPs from File";
            btnLoadBPs.UseVisualStyleBackColor = true;
            // 
            // btnBackupBPs
            // 
            btnBackupBPs.Location = new Point(6, 11);
            btnBackupBPs.Name = "btnBackupBPs";
            btnBackupBPs.Size = new Size(120, 29);
            btnBackupBPs.TabIndex = 41;
            btnBackupBPs.Text = "Backup BPs to File";
            btnBackupBPs.UseVisualStyleBackColor = true;
            // 
            // gbRace
            // 
            gbRace.Controls.Add(chkRacePirate);
            gbRace.Controls.Add(chkRaceOther);
            gbRace.Controls.Add(chkRaceGallente);
            gbRace.Controls.Add(chkRaceCaldari);
            gbRace.Controls.Add(chkRaceAmarr);
            gbRace.Controls.Add(chkRaceMinmatar);
            gbRace.Location = new Point(439, 13);
            gbRace.Name = "gbRace";
            gbRace.Size = new Size(76, 122);
            gbRace.TabIndex = 3;
            gbRace.TabStop = false;
            gbRace.Text = "BP Race";
            // 
            // chkRacePirate
            // 
            chkRacePirate.AutoSize = true;
            chkRacePirate.Location = new Point(6, 83);
            chkRacePirate.Name = "chkRacePirate";
            chkRacePirate.Size = new Size(53, 17);
            chkRacePirate.TabIndex = 27;
            chkRacePirate.Text = "Pirate";
            chkRacePirate.UseVisualStyleBackColor = true;
            // 
            // chkRaceOther
            // 
            chkRaceOther.AutoSize = true;
            chkRaceOther.Location = new Point(6, 100);
            chkRaceOther.Name = "chkRaceOther";
            chkRaceOther.Size = new Size(52, 17);
            chkRaceOther.TabIndex = 28;
            chkRaceOther.Text = "Other";
            chkRaceOther.UseVisualStyleBackColor = true;
            // 
            // chkRaceGallente
            // 
            chkRaceGallente.AutoSize = true;
            chkRaceGallente.Location = new Point(6, 49);
            chkRaceGallente.Name = "chkRaceGallente";
            chkRaceGallente.Size = new Size(65, 17);
            chkRaceGallente.TabIndex = 25;
            chkRaceGallente.Text = "Gallente";
            chkRaceGallente.UseVisualStyleBackColor = true;
            // 
            // chkRaceCaldari
            // 
            chkRaceCaldari.AutoSize = true;
            chkRaceCaldari.Location = new Point(6, 32);
            chkRaceCaldari.Name = "chkRaceCaldari";
            chkRaceCaldari.Size = new Size(58, 17);
            chkRaceCaldari.TabIndex = 24;
            chkRaceCaldari.Text = "Caldari";
            chkRaceCaldari.UseVisualStyleBackColor = true;
            // 
            // chkRaceAmarr
            // 
            chkRaceAmarr.AutoSize = true;
            chkRaceAmarr.Location = new Point(6, 15);
            chkRaceAmarr.Name = "chkRaceAmarr";
            chkRaceAmarr.Size = new Size(53, 17);
            chkRaceAmarr.TabIndex = 23;
            chkRaceAmarr.Text = "Amarr";
            chkRaceAmarr.UseVisualStyleBackColor = true;
            // 
            // chkRaceMinmatar
            // 
            chkRaceMinmatar.AutoSize = true;
            chkRaceMinmatar.Location = new Point(6, 66);
            chkRaceMinmatar.Name = "chkRaceMinmatar";
            chkRaceMinmatar.Size = new Size(69, 17);
            chkRaceMinmatar.TabIndex = 26;
            chkRaceMinmatar.Text = "Minmatar";
            chkRaceMinmatar.UseVisualStyleBackColor = true;
            // 
            // gbSize
            // 
            gbSize.Controls.Add(chkBPXL);
            gbSize.Controls.Add(chkBPLarge);
            gbSize.Controls.Add(chkBPMedium);
            gbSize.Controls.Add(chkBPSmall);
            gbSize.Location = new Point(521, 89);
            gbSize.Name = "gbSize";
            gbSize.Size = new Size(159, 45);
            gbSize.TabIndex = 43;
            gbSize.TabStop = false;
            gbSize.Text = "Size";
            // 
            // chkBPXL
            // 
            chkBPXL.AutoSize = true;
            chkBPXL.Location = new Point(119, 17);
            chkBPXL.Name = "chkBPXL";
            chkBPXL.Size = new Size(39, 17);
            chkBPXL.TabIndex = 4;
            chkBPXL.Text = "XL";
            chkBPXL.UseVisualStyleBackColor = true;
            // 
            // chkBPLarge
            // 
            chkBPLarge.AutoSize = true;
            chkBPLarge.Location = new Point(83, 17);
            chkBPLarge.Name = "chkBPLarge";
            chkBPLarge.Size = new Size(32, 17);
            chkBPLarge.TabIndex = 3;
            chkBPLarge.Text = "L";
            chkBPLarge.UseVisualStyleBackColor = true;
            // 
            // chkBPMedium
            // 
            chkBPMedium.AutoSize = true;
            chkBPMedium.Location = new Point(44, 17);
            chkBPMedium.Name = "chkBPMedium";
            chkBPMedium.Size = new Size(35, 17);
            chkBPMedium.TabIndex = 2;
            chkBPMedium.Text = "M";
            chkBPMedium.UseVisualStyleBackColor = true;
            // 
            // chkBPSmall
            // 
            chkBPSmall.AutoSize = true;
            chkBPSmall.Location = new Point(7, 17);
            chkBPSmall.Name = "chkBPSmall";
            chkBPSmall.Size = new Size(33, 17);
            chkBPSmall.TabIndex = 1;
            chkBPSmall.Text = "S";
            chkBPSmall.TextAlign = ContentAlignment.MiddleCenter;
            chkBPSmall.UseVisualStyleBackColor = true;
            // 
            // gbBPCopyOptions
            // 
            gbBPCopyOptions.Controls.Add(rbtnOnlyInventedBPCs);
            gbBPCopyOptions.Controls.Add(rbtnOnlyBPO);
            gbBPCopyOptions.Controls.Add(rbtnOnlyCopies);
            gbBPCopyOptions.Controls.Add(rbtnShowAllBPtypes);
            gbBPCopyOptions.Location = new Point(333, 136);
            gbBPCopyOptions.Name = "gbBPCopyOptions";
            gbBPCopyOptions.Size = new Size(347, 42);
            gbBPCopyOptions.TabIndex = 6;
            gbBPCopyOptions.TabStop = false;
            gbBPCopyOptions.Text = "Blueprint Type:";
            // 
            // rbtnOnlyInventedBPCs
            // 
            rbtnOnlyInventedBPCs.AutoSize = true;
            rbtnOnlyInventedBPCs.Location = new Point(229, 17);
            rbtnOnlyInventedBPCs.Name = "rbtnOnlyInventedBPCs";
            rbtnOnlyInventedBPCs.Size = new Size(96, 17);
            rbtnOnlyInventedBPCs.TabIndex = 37;
            rbtnOnlyInventedBPCs.TabStop = true;
            rbtnOnlyInventedBPCs.Text = "Invented BPCs";
            rbtnOnlyInventedBPCs.UseVisualStyleBackColor = true;
            // 
            // rbtnOnlyBPO
            // 
            rbtnOnlyBPO.AutoSize = true;
            rbtnOnlyBPO.Location = new Point(70, 17);
            rbtnOnlyBPO.Name = "rbtnOnlyBPO";
            rbtnOnlyBPO.Size = new Size(52, 17);
            rbtnOnlyBPO.TabIndex = 34;
            rbtnOnlyBPO.TabStop = true;
            rbtnOnlyBPO.Text = "BPOs";
            rbtnOnlyBPO.UseVisualStyleBackColor = true;
            // 
            // rbtnOnlyCopies
            // 
            rbtnOnlyCopies.AutoSize = true;
            rbtnOnlyCopies.Location = new Point(147, 17);
            rbtnOnlyCopies.Name = "rbtnOnlyCopies";
            rbtnOnlyCopies.Size = new Size(57, 17);
            rbtnOnlyCopies.TabIndex = 35;
            rbtnOnlyCopies.TabStop = true;
            rbtnOnlyCopies.Text = "Copies";
            rbtnOnlyCopies.UseVisualStyleBackColor = true;
            // 
            // rbtnShowAllBPtypes
            // 
            rbtnShowAllBPtypes.AutoSize = true;
            rbtnShowAllBPtypes.Location = new Point(9, 17);
            rbtnShowAllBPtypes.Name = "rbtnShowAllBPtypes";
            rbtnShowAllBPtypes.Size = new Size(36, 17);
            rbtnShowAllBPtypes.TabIndex = 36;
            rbtnShowAllBPtypes.TabStop = true;
            rbtnShowAllBPtypes.Text = "All";
            rbtnShowAllBPtypes.UseVisualStyleBackColor = true;
            // 
            // gbBPTextSearch
            // 
            gbBPTextSearch.Controls.Add(btnResetSearch);
            gbBPTextSearch.Controls.Add(txtBPSearch);
            gbBPTextSearch.Controls.Add(btnBPSearch);
            gbBPTextSearch.Location = new Point(521, 13);
            gbBPTextSearch.Name = "gbBPTextSearch";
            gbBPTextSearch.Size = new Size(277, 75);
            gbBPTextSearch.TabIndex = 5;
            gbBPTextSearch.TabStop = false;
            gbBPTextSearch.Text = "BP Search:";
            // 
            // btnResetSearch
            // 
            btnResetSearch.Location = new Point(138, 40);
            btnResetSearch.Name = "btnResetSearch";
            btnResetSearch.Size = new Size(106, 29);
            btnResetSearch.TabIndex = 33;
            btnResetSearch.Text = "Reset Search";
            btnResetSearch.UseVisualStyleBackColor = true;
            // 
            // txtBPSearch
            // 
            txtBPSearch.Location = new Point(7, 17);
            txtBPSearch.Name = "txtBPSearch";
            txtBPSearch.Size = new Size(263, 20);
            txtBPSearch.TabIndex = 30;
            // 
            // btnBPSearch
            // 
            btnBPSearch.Location = new Point(32, 41);
            btnBPSearch.Name = "btnBPSearch";
            btnBPSearch.Size = new Size(100, 28);
            btnBPSearch.TabIndex = 32;
            btnBPSearch.Text = "Search";
            btnBPSearch.UseVisualStyleBackColor = true;
            // 
            // grpScanAssets
            // 
            grpScanAssets.Controls.Add(btnClose);
            grpScanAssets.Controls.Add(btnReset);
            grpScanAssets.Controls.Add(btnScanCorpBPs);
            grpScanAssets.Controls.Add(btnResetAll);
            grpScanAssets.Controls.Add(btnScanPersonalBPs);
            grpScanAssets.Controls.Add(btnRefresh);
            grpScanAssets.Location = new Point(942, 10);
            grpScanAssets.Name = "grpScanAssets";
            grpScanAssets.Size = new Size(155, 220);
            grpScanAssets.TabIndex = 8;
            grpScanAssets.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(6, 46);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(143, 34);
            btnClose.TabIndex = 51;
            btnClose.Text = "Close Form";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(6, 80);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(143, 34);
            btnReset.TabIndex = 50;
            btnReset.Text = "Reset Form";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnScanCorpBPs
            // 
            btnScanCorpBPs.Location = new Point(6, 148);
            btnScanCorpBPs.Name = "btnScanCorpBPs";
            btnScanCorpBPs.Size = new Size(143, 34);
            btnScanCorpBPs.TabIndex = 38;
            btnScanCorpBPs.Text = "Scan Corp BPs";
            btnScanCorpBPs.UseVisualStyleBackColor = true;
            // 
            // btnResetAll
            // 
            btnResetAll.Location = new Point(6, 182);
            btnResetAll.Name = "btnResetAll";
            btnResetAll.Size = new Size(143, 34);
            btnResetAll.TabIndex = 40;
            btnResetAll.Text = "Reset All Stored BP Data";
            btnResetAll.UseVisualStyleBackColor = true;
            // 
            // btnScanPersonalBPs
            // 
            btnScanPersonalBPs.Location = new Point(6, 114);
            btnScanPersonalBPs.Name = "btnScanPersonalBPs";
            btnScanPersonalBPs.Size = new Size(143, 34);
            btnScanPersonalBPs.TabIndex = 37;
            btnScanPersonalBPs.Text = "Scan Personal BPs";
            btnScanPersonalBPs.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(6, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(143, 34);
            btnRefresh.TabIndex = 39;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // gbItemTypeFilter
            // 
            gbItemTypeFilter.Controls.Add(cmbBPTypeFilter);
            gbItemTypeFilter.Controls.Add(lblBPCombo);
            gbItemTypeFilter.Location = new Point(333, 175);
            gbItemTypeFilter.Name = "gbItemTypeFilter";
            gbItemTypeFilter.Size = new Size(347, 58);
            gbItemTypeFilter.TabIndex = 4;
            gbItemTypeFilter.TabStop = false;
            // 
            // cmbBPTypeFilter
            // 
            cmbBPTypeFilter.FormattingEnabled = true;
            cmbBPTypeFilter.Location = new Point(7, 29);
            cmbBPTypeFilter.Name = "cmbBPTypeFilter";
            cmbBPTypeFilter.Size = new Size(332, 21);
            cmbBPTypeFilter.TabIndex = 29;
            cmbBPTypeFilter.Text = "Select Type";
            // 
            // lblBPCombo
            // 
            lblBPCombo.AutoSize = true;
            lblBPCombo.Location = new Point(6, 13);
            lblBPCombo.Name = "lblBPCombo";
            lblBPCombo.Size = new Size(59, 13);
            lblBPCombo.TabIndex = 3;
            lblBPCombo.Text = "Type Filter:";
            // 
            // gbBlueprintType
            // 
            gbBlueprintType.Controls.Add(rbtnReactionBlueprints);
            gbBlueprintType.Controls.Add(rbtnStructureBlueprints);
            gbBlueprintType.Controls.Add(rbtnCelestialsBlueprints);
            gbBlueprintType.Controls.Add(rbtnStructureModulesBlueprints);
            gbBlueprintType.Controls.Add(rbtnAmmoChargeBlueprints);
            gbBlueprintType.Controls.Add(rbtnDeployableBlueprints);
            gbBlueprintType.Controls.Add(rbtnAllBPTypes);
            gbBlueprintType.Controls.Add(rbtnRigBlueprints);
            gbBlueprintType.Controls.Add(rbtnBoosterBlueprints);
            gbBlueprintType.Controls.Add(rbtnSubsystemBlueprints);
            gbBlueprintType.Controls.Add(rbtnModuleBlueprints);
            gbBlueprintType.Controls.Add(rbtnMiscBlueprints);
            gbBlueprintType.Controls.Add(rbtnDroneBlueprints);
            gbBlueprintType.Controls.Add(rbtnComponentBlueprints);
            gbBlueprintType.Controls.Add(rbtnShipBlueprints);
            gbBlueprintType.Controls.Add(rbtnStructureRigsBlueprints);
            gbBlueprintType.Location = new Point(6, 107);
            gbBlueprintType.Name = "gbBlueprintType";
            gbBlueprintType.Size = new Size(321, 126);
            gbBlueprintType.TabIndex = 1;
            gbBlueprintType.TabStop = false;
            gbBlueprintType.Text = "Item Type:";
            // 
            // rbtnReactionBlueprints
            // 
            rbtnReactionBlueprints.AutoSize = true;
            rbtnReactionBlueprints.Location = new Point(116, 70);
            rbtnReactionBlueprints.Name = "rbtnReactionBlueprints";
            rbtnReactionBlueprints.Size = new Size(73, 17);
            rbtnReactionBlueprints.TabIndex = 67;
            rbtnReactionBlueprints.TabStop = true;
            rbtnReactionBlueprints.Text = "Reactions";
            rbtnReactionBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnStructureBlueprints
            // 
            rbtnStructureBlueprints.AutoSize = true;
            rbtnStructureBlueprints.Location = new Point(6, 87);
            rbtnStructureBlueprints.Name = "rbtnStructureBlueprints";
            rbtnStructureBlueprints.Size = new Size(73, 17);
            rbtnStructureBlueprints.TabIndex = 14;
            rbtnStructureBlueprints.TabStop = true;
            rbtnStructureBlueprints.Text = "Structures";
            rbtnStructureBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnCelestialsBlueprints
            // 
            rbtnCelestialsBlueprints.AutoSize = true;
            rbtnCelestialsBlueprints.Location = new Point(227, 70);
            rbtnCelestialsBlueprints.Name = "rbtnCelestialsBlueprints";
            rbtnCelestialsBlueprints.Size = new Size(64, 17);
            rbtnCelestialsBlueprints.TabIndex = 19;
            rbtnCelestialsBlueprints.TabStop = true;
            rbtnCelestialsBlueprints.Text = "Celestial";
            rbtnCelestialsBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnStructureModulesBlueprints
            // 
            rbtnStructureModulesBlueprints.AutoSize = true;
            rbtnStructureModulesBlueprints.Location = new Point(116, 87);
            rbtnStructureModulesBlueprints.Name = "rbtnStructureModulesBlueprints";
            rbtnStructureModulesBlueprints.Size = new Size(111, 17);
            rbtnStructureModulesBlueprints.TabIndex = 66;
            rbtnStructureModulesBlueprints.TabStop = true;
            rbtnStructureModulesBlueprints.Text = "Structure Modules";
            rbtnStructureModulesBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnAmmoChargeBlueprints
            // 
            rbtnAmmoChargeBlueprints.AutoSize = true;
            rbtnAmmoChargeBlueprints.Location = new Point(6, 36);
            rbtnAmmoChargeBlueprints.Name = "rbtnAmmoChargeBlueprints";
            rbtnAmmoChargeBlueprints.Size = new Size(98, 17);
            rbtnAmmoChargeBlueprints.TabIndex = 11;
            rbtnAmmoChargeBlueprints.TabStop = true;
            rbtnAmmoChargeBlueprints.Text = "Ammo/Charges";
            rbtnAmmoChargeBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnDeployableBlueprints
            // 
            rbtnDeployableBlueprints.AutoSize = true;
            rbtnDeployableBlueprints.Location = new Point(116, 53);
            rbtnDeployableBlueprints.Name = "rbtnDeployableBlueprints";
            rbtnDeployableBlueprints.Size = new Size(78, 17);
            rbtnDeployableBlueprints.TabIndex = 17;
            rbtnDeployableBlueprints.TabStop = true;
            rbtnDeployableBlueprints.Text = "Deployable";
            rbtnDeployableBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnAllBPTypes
            // 
            rbtnAllBPTypes.AutoSize = true;
            rbtnAllBPTypes.Location = new Point(6, 19);
            rbtnAllBPTypes.Name = "rbtnAllBPTypes";
            rbtnAllBPTypes.Size = new Size(36, 17);
            rbtnAllBPTypes.TabIndex = 6;
            rbtnAllBPTypes.TabStop = true;
            rbtnAllBPTypes.Text = "All";
            rbtnAllBPTypes.UseVisualStyleBackColor = true;
            // 
            // rbtnRigBlueprints
            // 
            rbtnRigBlueprints.AutoSize = true;
            rbtnRigBlueprints.Location = new Point(227, 36);
            rbtnRigBlueprints.Name = "rbtnRigBlueprints";
            rbtnRigBlueprints.Size = new Size(46, 17);
            rbtnRigBlueprints.TabIndex = 10;
            rbtnRigBlueprints.TabStop = true;
            rbtnRigBlueprints.Text = "Rigs";
            rbtnRigBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBoosterBlueprints
            // 
            rbtnBoosterBlueprints.AutoSize = true;
            rbtnBoosterBlueprints.Location = new Point(6, 70);
            rbtnBoosterBlueprints.Name = "rbtnBoosterBlueprints";
            rbtnBoosterBlueprints.Size = new Size(66, 17);
            rbtnBoosterBlueprints.TabIndex = 15;
            rbtnBoosterBlueprints.TabStop = true;
            rbtnBoosterBlueprints.Text = "Boosters";
            rbtnBoosterBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnSubsystemBlueprints
            // 
            rbtnSubsystemBlueprints.AutoSize = true;
            rbtnSubsystemBlueprints.Location = new Point(6, 53);
            rbtnSubsystemBlueprints.Name = "rbtnSubsystemBlueprints";
            rbtnSubsystemBlueprints.Size = new Size(81, 17);
            rbtnSubsystemBlueprints.TabIndex = 13;
            rbtnSubsystemBlueprints.TabStop = true;
            rbtnSubsystemBlueprints.Text = "Subsystems";
            rbtnSubsystemBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnModuleBlueprints
            // 
            rbtnModuleBlueprints.AutoSize = true;
            rbtnModuleBlueprints.Location = new Point(227, 19);
            rbtnModuleBlueprints.Name = "rbtnModuleBlueprints";
            rbtnModuleBlueprints.Size = new Size(65, 17);
            rbtnModuleBlueprints.TabIndex = 8;
            rbtnModuleBlueprints.TabStop = true;
            rbtnModuleBlueprints.Text = "Modules";
            rbtnModuleBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnMiscBlueprints
            // 
            rbtnMiscBlueprints.AutoSize = true;
            rbtnMiscBlueprints.Location = new Point(6, 104);
            rbtnMiscBlueprints.Name = "rbtnMiscBlueprints";
            rbtnMiscBlueprints.Size = new Size(50, 17);
            rbtnMiscBlueprints.TabIndex = 16;
            rbtnMiscBlueprints.TabStop = true;
            rbtnMiscBlueprints.Text = "Misc.";
            rbtnMiscBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnDroneBlueprints
            // 
            rbtnDroneBlueprints.AutoSize = true;
            rbtnDroneBlueprints.Location = new Point(116, 36);
            rbtnDroneBlueprints.Name = "rbtnDroneBlueprints";
            rbtnDroneBlueprints.Size = new Size(59, 17);
            rbtnDroneBlueprints.TabIndex = 9;
            rbtnDroneBlueprints.TabStop = true;
            rbtnDroneBlueprints.Text = "Drones";
            rbtnDroneBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnComponentBlueprints
            // 
            rbtnComponentBlueprints.AutoSize = true;
            rbtnComponentBlueprints.Location = new Point(227, 53);
            rbtnComponentBlueprints.Name = "rbtnComponentBlueprints";
            rbtnComponentBlueprints.Size = new Size(84, 17);
            rbtnComponentBlueprints.TabIndex = 12;
            rbtnComponentBlueprints.TabStop = true;
            rbtnComponentBlueprints.Text = "Components";
            rbtnComponentBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnShipBlueprints
            // 
            rbtnShipBlueprints.AutoSize = true;
            rbtnShipBlueprints.Location = new Point(116, 19);
            rbtnShipBlueprints.Name = "rbtnShipBlueprints";
            rbtnShipBlueprints.Size = new Size(51, 17);
            rbtnShipBlueprints.TabIndex = 7;
            rbtnShipBlueprints.TabStop = true;
            rbtnShipBlueprints.Text = "Ships";
            rbtnShipBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnStructureRigsBlueprints
            // 
            rbtnStructureRigsBlueprints.AutoSize = true;
            rbtnStructureRigsBlueprints.Location = new Point(227, 87);
            rbtnStructureRigsBlueprints.Name = "rbtnStructureRigsBlueprints";
            rbtnStructureRigsBlueprints.Size = new Size(92, 17);
            rbtnStructureRigsBlueprints.TabIndex = 18;
            rbtnStructureRigsBlueprints.TabStop = true;
            rbtnStructureRigsBlueprints.Text = "Structure Rigs";
            rbtnStructureRigsBlueprints.UseVisualStyleBackColor = true;
            // 
            // gbBPSelect
            // 
            gbBPSelect.Controls.Add(chkNotIgnored);
            gbBPSelect.Controls.Add(chkNotOwned);
            gbBPSelect.Controls.Add(lblScanCorpColor);
            gbBPSelect.Controls.Add(rbtnIgnored);
            gbBPSelect.Controls.Add(lblScanPersonalColor);
            gbBPSelect.Controls.Add(rbtnScannedCorpBPs);
            gbBPSelect.Controls.Add(rbtnScannedPersonalBPs);
            gbBPSelect.Controls.Add(rbtnFavorites);
            gbBPSelect.Controls.Add(rbtnAllBPs);
            gbBPSelect.Controls.Add(rbtnOwned);
            gbBPSelect.Location = new Point(6, 13);
            gbBPSelect.Name = "gbBPSelect";
            gbBPSelect.Size = new Size(321, 93);
            gbBPSelect.TabIndex = 0;
            gbBPSelect.TabStop = false;
            // 
            // chkNotIgnored
            // 
            chkNotIgnored.AutoSize = true;
            chkNotIgnored.Location = new Point(230, 30);
            chkNotIgnored.Name = "chkNotIgnored";
            chkNotIgnored.Size = new Size(82, 17);
            chkNotIgnored.TabIndex = 63;
            chkNotIgnored.Text = "Not Ignored";
            chkNotIgnored.UseVisualStyleBackColor = true;
            // 
            // chkNotOwned
            // 
            chkNotOwned.AutoSize = true;
            chkNotOwned.Location = new Point(230, 13);
            chkNotOwned.Name = "chkNotOwned";
            chkNotOwned.Size = new Size(80, 17);
            chkNotOwned.TabIndex = 18;
            chkNotOwned.Text = "Not Owned";
            chkNotOwned.UseVisualStyleBackColor = true;
            // 
            // lblScanCorpColor
            // 
            lblScanCorpColor.BackColor = Color.LightGreen;
            lblScanCorpColor.BorderStyle = BorderStyle.FixedSingle;
            lblScanCorpColor.Location = new Point(143, 65);
            lblScanCorpColor.Name = "lblScanCorpColor";
            lblScanCorpColor.Size = new Size(46, 12);
            lblScanCorpColor.TabIndex = 6;
            lblScanCorpColor.TextAlign = ContentAlignment.TopCenter;
            // 
            // rbtnIgnored
            // 
            rbtnIgnored.AutoSize = true;
            rbtnIgnored.Location = new Point(143, 28);
            rbtnIgnored.Name = "rbtnIgnored";
            rbtnIgnored.Size = new Size(61, 17);
            rbtnIgnored.TabIndex = 62;
            rbtnIgnored.TabStop = true;
            rbtnIgnored.Text = "Ignored";
            rbtnIgnored.UseVisualStyleBackColor = true;
            // 
            // lblScanPersonalColor
            // 
            lblScanPersonalColor.BackColor = Color.BlanchedAlmond;
            lblScanPersonalColor.BorderStyle = BorderStyle.FixedSingle;
            lblScanPersonalColor.Location = new Point(143, 48);
            lblScanPersonalColor.Name = "lblScanPersonalColor";
            lblScanPersonalColor.Size = new Size(46, 12);
            lblScanPersonalColor.TabIndex = 5;
            // 
            // rbtnScannedCorpBPs
            // 
            rbtnScannedCorpBPs.AutoSize = true;
            rbtnScannedCorpBPs.Location = new Point(6, 63);
            rbtnScannedCorpBPs.Name = "rbtnScannedCorpBPs";
            rbtnScannedCorpBPs.Size = new Size(115, 17);
            rbtnScannedCorpBPs.TabIndex = 4;
            rbtnScannedCorpBPs.TabStop = true;
            rbtnScannedCorpBPs.Text = "Scanned Corp BPs";
            rbtnScannedCorpBPs.UseVisualStyleBackColor = true;
            // 
            // rbtnScannedPersonalBPs
            // 
            rbtnScannedPersonalBPs.AutoSize = true;
            rbtnScannedPersonalBPs.Location = new Point(6, 46);
            rbtnScannedPersonalBPs.Name = "rbtnScannedPersonalBPs";
            rbtnScannedPersonalBPs.Size = new Size(134, 17);
            rbtnScannedPersonalBPs.TabIndex = 3;
            rbtnScannedPersonalBPs.TabStop = true;
            rbtnScannedPersonalBPs.Text = "Scanned Personal BPs";
            rbtnScannedPersonalBPs.UseVisualStyleBackColor = true;
            // 
            // rbtnFavorites
            // 
            rbtnFavorites.AutoSize = true;
            rbtnFavorites.Location = new Point(143, 11);
            rbtnFavorites.Name = "rbtnFavorites";
            rbtnFavorites.Size = new Size(68, 17);
            rbtnFavorites.TabIndex = 2;
            rbtnFavorites.TabStop = true;
            rbtnFavorites.Text = "Favorites";
            rbtnFavorites.UseVisualStyleBackColor = true;
            // 
            // rbtnAllBPs
            // 
            rbtnAllBPs.AutoSize = true;
            rbtnAllBPs.Location = new Point(6, 12);
            rbtnAllBPs.Name = "rbtnAllBPs";
            rbtnAllBPs.Size = new Size(85, 17);
            rbtnAllBPs.TabIndex = 1;
            rbtnAllBPs.TabStop = true;
            rbtnAllBPs.Text = "All Blueprints";
            rbtnAllBPs.UseVisualStyleBackColor = true;
            // 
            // rbtnOwned
            // 
            rbtnOwned.AutoSize = true;
            rbtnOwned.ForeColor = Color.Blue;
            rbtnOwned.Location = new Point(6, 29);
            rbtnOwned.Name = "rbtnOwned";
            rbtnOwned.Size = new Size(81, 17);
            rbtnOwned.TabIndex = 5;
            rbtnOwned.TabStop = true;
            rbtnOwned.Text = "Owned BPs";
            rbtnOwned.UseVisualStyleBackColor = true;
            // 
            // gbUpdateOptions
            // 
            gbUpdateOptions.Controls.Add(rbtnRemoveAllSettings);
            gbUpdateOptions.Controls.Add(chkMarkasIgnored);
            gbUpdateOptions.Controls.Add(chkMarkasFavorite);
            gbUpdateOptions.Controls.Add(chkEnableMETE);
            gbUpdateOptions.Controls.Add(rbtnMarkasUnowned);
            gbUpdateOptions.Controls.Add(btnUpdateSelected);
            gbUpdateOptions.Controls.Add(txtBPTE);
            gbUpdateOptions.Controls.Add(btnSelectAll);
            gbUpdateOptions.Controls.Add(rbtnMarkasOwned);
            gbUpdateOptions.Controls.Add(lblBPTE);
            gbUpdateOptions.Controls.Add(txtBPME);
            gbUpdateOptions.Controls.Add(lblBPME);
            gbUpdateOptions.Location = new Point(686, 89);
            gbUpdateOptions.Name = "gbUpdateOptions";
            gbUpdateOptions.Size = new Size(250, 141);
            gbUpdateOptions.TabIndex = 7;
            gbUpdateOptions.TabStop = false;
            gbUpdateOptions.Text = "Update Options";
            // 
            // rbtnRemoveAllSettings
            // 
            rbtnRemoveAllSettings.AutoSize = true;
            rbtnRemoveAllSettings.Location = new Point(10, 55);
            rbtnRemoveAllSettings.Name = "rbtnRemoveAllSettings";
            rbtnRemoveAllSettings.Size = new Size(120, 17);
            rbtnRemoveAllSettings.TabIndex = 54;
            rbtnRemoveAllSettings.TabStop = true;
            rbtnRemoveAllSettings.Text = "Remove All Settings";
            rbtnRemoveAllSettings.UseVisualStyleBackColor = true;
            // 
            // chkMarkasIgnored
            // 
            chkMarkasIgnored.AutoSize = true;
            chkMarkasIgnored.Location = new Point(135, 38);
            chkMarkasIgnored.Name = "chkMarkasIgnored";
            chkMarkasIgnored.Size = new Size(104, 17);
            chkMarkasIgnored.TabIndex = 53;
            chkMarkasIgnored.Text = "Mark As Ignored";
            chkMarkasIgnored.TextAlign = ContentAlignment.TopLeft;
            chkMarkasIgnored.UseVisualStyleBackColor = true;
            // 
            // chkMarkasFavorite
            // 
            chkMarkasFavorite.AutoSize = true;
            chkMarkasFavorite.Location = new Point(135, 21);
            chkMarkasFavorite.Name = "chkMarkasFavorite";
            chkMarkasFavorite.Size = new Size(106, 17);
            chkMarkasFavorite.TabIndex = 51;
            chkMarkasFavorite.Text = "Mark As Favorite";
            chkMarkasFavorite.TextAlign = ContentAlignment.TopLeft;
            chkMarkasFavorite.UseVisualStyleBackColor = true;
            // 
            // chkEnableMETE
            // 
            chkEnableMETE.AutoSize = true;
            chkEnableMETE.Location = new Point(135, 79);
            chkEnableMETE.Name = "chkEnableMETE";
            chkEnableMETE.Size = new Size(103, 17);
            chkEnableMETE.TabIndex = 52;
            chkEnableMETE.Text = "Enable ME / TE";
            chkEnableMETE.TextAlign = ContentAlignment.TopLeft;
            chkEnableMETE.UseVisualStyleBackColor = true;
            // 
            // rbtnMarkasUnowned
            // 
            rbtnMarkasUnowned.AutoSize = true;
            rbtnMarkasUnowned.Location = new Point(10, 37);
            rbtnMarkasUnowned.Name = "rbtnMarkasUnowned";
            rbtnMarkasUnowned.Size = new Size(112, 17);
            rbtnMarkasUnowned.TabIndex = 46;
            rbtnMarkasUnowned.TabStop = true;
            rbtnMarkasUnowned.Text = "Mark as Unowned";
            rbtnMarkasUnowned.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSelected
            // 
            btnUpdateSelected.Location = new Point(129, 103);
            btnUpdateSelected.Name = "btnUpdateSelected";
            btnUpdateSelected.Size = new Size(112, 33);
            btnUpdateSelected.TabIndex = 50;
            btnUpdateSelected.Text = "Update Selected";
            btnUpdateSelected.UseVisualStyleBackColor = true;
            // 
            // txtBPTE
            // 
            txtBPTE.Location = new Point(91, 77);
            txtBPTE.MaxLength = 2;
            txtBPTE.Name = "txtBPTE";
            txtBPTE.Size = new Size(31, 20);
            txtBPTE.TabIndex = 44;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(9, 103);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(113, 33);
            btnSelectAll.TabIndex = 49;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // rbtnMarkasOwned
            // 
            rbtnMarkasOwned.AutoSize = true;
            rbtnMarkasOwned.Location = new Point(10, 20);
            rbtnMarkasOwned.Name = "rbtnMarkasOwned";
            rbtnMarkasOwned.Size = new Size(100, 17);
            rbtnMarkasOwned.TabIndex = 45;
            rbtnMarkasOwned.TabStop = true;
            rbtnMarkasOwned.Text = "Mark as Owned";
            rbtnMarkasOwned.UseVisualStyleBackColor = true;
            // 
            // lblBPTE
            // 
            lblBPTE.AutoSize = true;
            lblBPTE.Location = new Point(67, 80);
            lblBPTE.Name = "lblBPTE";
            lblBPTE.Size = new Size(24, 13);
            lblBPTE.TabIndex = 15;
            lblBPTE.Text = "TE:";
            // 
            // txtBPME
            // 
            txtBPME.Location = new Point(32, 77);
            txtBPME.MaxLength = 2;
            txtBPME.Name = "txtBPME";
            txtBPME.Size = new Size(31, 20);
            txtBPME.TabIndex = 43;
            // 
            // lblBPME
            // 
            lblBPME.Location = new Point(6, 80);
            lblBPME.Name = "lblBPME";
            lblBPME.Size = new Size(26, 13);
            lblBPME.TabIndex = 12;
            lblBPME.Text = "ME:";
            // 
            // txtBPEdit
            // 
            txtBPEdit.Location = new Point(802, 325);
            txtBPEdit.Name = "txtBPEdit";
            txtBPEdit.Size = new Size(48, 20);
            txtBPEdit.TabIndex = 58;
            txtBPEdit.TabStop = false;
            txtBPEdit.Visible = false;
            // 
            // ttBPManage
            // 
            ttBPManage.IsBalloon = true;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "Filename";
            // 
            // cmbEdit
            // 
            cmbEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdit.FormattingEnabled = true;
            cmbEdit.ItemHeight = 13;
            cmbEdit.Items.AddRange(new object[] { "Yes", "No" });
            cmbEdit.Location = new Point(802, 347);
            cmbEdit.Name = "cmbEdit";
            cmbEdit.Size = new Size(48, 21);
            cmbEdit.TabIndex = 61;
            cmbEdit.TabStop = false;
            // 
            // lstBPs
            // 
            lstBPs.CheckBoxes = true;
            lstBPs.FullRowSelect = true;
            lstBPs.GridLines = true;
            lstBPs.HideSelection = false;
            lstBPs.Location = new Point(6, 12);
            lstBPs.MultiSelect = false;
            lstBPs.Name = "lstBPs";
            lstBPs.Size = new Size(1105, 350);
            lstBPs.TabIndex = 60;
            lstBPs.TabStop = false;
            lstBPs.UseCompatibleStateImageBehavior = false;
            lstBPs.View = View.Details;
            // 
            // frmBlueprintManagement
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(1115, 614);
            Controls.Add(gbBPFilter);
            Controls.Add(cmbEdit);
            Controls.Add(txtBPEdit);
            Controls.Add(lstBPs);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmBlueprintManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blueprint Management";
            gbBPFilter.ResumeLayout(false);
            gbBlueprintTech.ResumeLayout(false);
            gbBlueprintTech.PerformLayout();
            gbBackup.ResumeLayout(false);
            gbRace.ResumeLayout(false);
            gbRace.PerformLayout();
            gbSize.ResumeLayout(false);
            gbSize.PerformLayout();
            gbBPCopyOptions.ResumeLayout(false);
            gbBPCopyOptions.PerformLayout();
            gbBPTextSearch.ResumeLayout(false);
            gbBPTextSearch.PerformLayout();
            grpScanAssets.ResumeLayout(false);
            gbItemTypeFilter.ResumeLayout(false);
            gbItemTypeFilter.PerformLayout();
            gbBlueprintType.ResumeLayout(false);
            gbBlueprintType.PerformLayout();
            gbBPSelect.ResumeLayout(false);
            gbBPSelect.PerformLayout();
            gbUpdateOptions.ResumeLayout(false);
            gbUpdateOptions.PerformLayout();
            Shown += new EventHandler(frmBlueprintManagement_Shown);
            ResumeLayout(false);
            PerformLayout();

        }
        internal GroupBox gbBPFilter;
        internal GroupBox gbBPTextSearch;
        internal TextBox txtBPSearch;
        internal GroupBox gbBPSelect;
        internal RadioButton rbtnAllBPs;
        internal RadioButton rbtnOwned;
        internal GroupBox gbBlueprintType;
        internal RadioButton rbtnRigBlueprints;
        internal RadioButton rbtnBoosterBlueprints;
        internal RadioButton rbtnStructureBlueprints;
        internal RadioButton rbtnSubsystemBlueprints;
        internal RadioButton rbtnModuleBlueprints;
        internal RadioButton rbtnMiscBlueprints;
        internal RadioButton rbtnAmmoChargeBlueprints;
        internal RadioButton rbtnDroneBlueprints;
        internal RadioButton rbtnComponentBlueprints;
        internal RadioButton rbtnShipBlueprints;
        internal GroupBox gbUpdateOptions;
        internal GroupBox gbItemTypeFilter;
        internal ComboBox cmbBPTypeFilter;
        internal Label lblBPCombo;
        internal RadioButton rbtnAllBPTypes;
        internal Button btnBPSearch;
        internal GroupBox gbBlueprintTech;
        internal CheckBox chkBPPirateFaction;
        internal CheckBox chkBPStoryline;
        internal CheckBox chkBPNavyFaction;
        internal CheckBox chkBPT3;
        internal CheckBox chkBPT2;
        internal CheckBox chkBPT1;
        internal RadioButton rbtnMarkasOwned;
        internal TextBox txtBPTE;
        internal Button btnUpdateSelected;
        internal Label lblBPTE;
        internal TextBox txtBPME;
        internal Label lblBPME;
        internal Button btnSelectAll;
        internal RadioButton rbtnMarkasUnowned;
        internal GroupBox grpScanAssets;
        internal Button btnScanPersonalBPs;
        internal Button btnClose;
        internal Button btnRefresh;
        internal Button btnReset;
        internal ToolTip ttBPManage;
        internal Button btnResetSearch;
        internal RadioButton rbtnScannedPersonalBPs;
        internal RadioButton rbtnScannedCorpBPs;
        internal Button btnScanCorpBPs;
        internal Label lblScanCorpColor;
        internal Label lblScanPersonalColor;
        internal Button btnResetAll;
        internal GroupBox gbBPCopyOptions;
        internal RadioButton rbtnOnlyBPO;
        internal RadioButton rbtnOnlyCopies;
        internal RadioButton rbtnShowAllBPtypes;
        internal GroupBox gbRace;
        internal CheckBox chkRaceMinmatar;
        internal CheckBox chkRacePirate;
        internal CheckBox chkRaceOther;
        internal CheckBox chkRaceGallente;
        internal CheckBox chkRaceCaldari;
        internal CheckBox chkRaceAmarr;
        internal Button btnLoadBPs;
        internal Button btnBackupBPs;
        internal SaveFileDialog SaveFileDialog;
        internal OpenFileDialog OpenFileDialog;
        internal TextBox txtBPEdit;
        internal RadioButton rbtnFavorites;
        internal CheckBox chkMarkasFavorite;
        internal MyListView lstBPs;
        internal ComboBox cmbEdit;
        internal CheckBox chkNotOwned;
        internal GroupBox gbSize;
        internal CheckBox chkBPXL;
        internal CheckBox chkBPLarge;
        internal CheckBox chkBPMedium;
        internal CheckBox chkBPSmall;
        internal RadioButton rbtnCelestialsBlueprints;
        internal RadioButton rbtnStructureRigsBlueprints;
        internal RadioButton rbtnDeployableBlueprints;
        internal CheckBox chkEnableMETE;
        internal GroupBox gbBackup;
        internal CheckBox chkMarkasIgnored;
        internal RadioButton rbtnIgnored;
        internal RadioButton rbtnOnlyInventedBPCs;
        internal CheckBox chkNotIgnored;
        internal RadioButton rbtnRemoveAllSettings;
        internal RadioButton rbtnStructureModulesBlueprints;
        internal RadioButton rbtnReactionBlueprints;
    }
}