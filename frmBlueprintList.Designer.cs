using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmBlueprintList : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBlueprintList));
            treBlueprintTreeView = new TreeView();
            treBlueprintTreeView.BeforeExpand += new TreeViewCancelEventHandler(treBlueprintTreeView_BeforeExpand);
            treBlueprintTreeView.AfterSelect += new TreeViewEventHandler(treBlueprintTreeView_AfterSelect);
            lblIntro = new Label();
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            grpBPType = new GroupBox();
            chkBPNPCBPOs = new CheckBox();
            chkBPNPCBPOs.CheckedChanged += new EventHandler(chkBPNPCBPOs_CheckedChanged);
            rbtnBPMiscBlueprints = new RadioButton();
            rbtnBPMiscBlueprints.CheckedChanged += new EventHandler(rbtnToolBlueprints_CheckedChanged);
            rbtnBPReactionBlueprints = new RadioButton();
            rbtnBPStructureModuleBlueprints = new RadioButton();
            rbtnBPStructureModuleBlueprints.CheckedChanged += new EventHandler(rbtnBPStationModulesBlueprints_CheckedChanged);
            rbtnBPFavoriteBlueprints = new RadioButton();
            rbtnBPFavoriteBlueprints.CheckedChanged += new EventHandler(rbtnBPFavoriteBlueprints_CheckedChanged);
            rbtnBPStructureRigsBlueprints = new RadioButton();
            rbtnBPStructureRigsBlueprints.CheckedChanged += new EventHandler(rbtnBPStationPartsBlueprints_CheckedChanged);
            rbtnBPComponentBlueprints = new RadioButton();
            rbtnBPComponentBlueprints.CheckedChanged += new EventHandler(rbtnComponentBlueprints_CheckedChanged);
            rbtnBPDeployableBlueprints = new RadioButton();
            rbtnBPDeployableBlueprints.CheckedChanged += new EventHandler(rbtnBPDeployableBlueprints_CheckedChanged);
            rbtnBPCelestialsBlueprints = new RadioButton();
            rbtnBPCelestialsBlueprints.CheckedChanged += new EventHandler(rbtnBPCelestialBlueprints_CheckedChanged);
            rbtnBPOwnedBlueprints = new RadioButton();
            rbtnBPOwnedBlueprints.CheckedChanged += new EventHandler(rbBPOwned_CheckedChanged);
            rbtnBPSubsystemBlueprints = new RadioButton();
            rbtnBPSubsystemBlueprints.CheckedChanged += new EventHandler(rbtnSubsystemBlueprints_CheckedChanged);
            rbtnBPBoosterBlueprints = new RadioButton();
            rbtnBPBoosterBlueprints.CheckedChanged += new EventHandler(rbtnBoosterBlueprints_CheckedChanged);
            rbtnBPModuleBlueprints = new RadioButton();
            rbtnBPModuleBlueprints.CheckedChanged += new EventHandler(rbtnModuleBlueprints_CheckedChanged);
            rbtnBPRigBlueprints = new RadioButton();
            rbtnBPRigBlueprints.CheckedChanged += new EventHandler(rbtnRigBlueprints_CheckedChanged);
            rbtnBPStructureBlueprints = new RadioButton();
            rbtnBPStructureBlueprints.CheckedChanged += new EventHandler(rbtnStructureBlueprints_CheckedChanged);
            rbtnBPDroneBlueprints = new RadioButton();
            rbtnBPDroneBlueprints.CheckedChanged += new EventHandler(rbtnDroneBlueprints_CheckedChanged);
            rbtnBPAmmoChargeBlueprints = new RadioButton();
            rbtnBPAmmoChargeBlueprints.CheckedChanged += new EventHandler(rbtnAmmoChargeBlueprints_CheckedChanged);
            rbtnBPShipBlueprints = new RadioButton();
            rbtnBPShipBlueprints.CheckedChanged += new EventHandler(rbtnShipBlueprints_CheckedChanged);
            rbtnBPAll = new RadioButton();
            rbtnBPAll.CheckedChanged += new EventHandler(rbtnAll_CheckedChanged);
            btnRefresh = new Button();
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            grpBPSize = new GroupBox();
            chkBPXLarge = new CheckBox();
            chkBPXLarge.CheckedChanged += new EventHandler(chkBPXLarge_CheckedChanged);
            chkBPLarge = new CheckBox();
            chkBPLarge.CheckedChanged += new EventHandler(chkBPLarge_CheckedChanged);
            chkBPMedium = new CheckBox();
            chkBPMedium.CheckedChanged += new EventHandler(chkBPMedium_CheckedChanged);
            chkBPSmall = new CheckBox();
            chkBPSmall.CheckedChanged += new EventHandler(chkBPSmall_CheckedChanged);
            grpBPTechLevel = new GroupBox();
            chkBPPirate = new CheckBox();
            chkBPPirate.CheckedChanged += new EventHandler(chkBPPirate_CheckedChanged);
            chkBPNavy = new CheckBox();
            chkBPNavy.CheckedChanged += new EventHandler(chkBPNavy_CheckedChanged);
            chkBPStory = new CheckBox();
            chkBPStory.CheckedChanged += new EventHandler(chkBPStory_CheckedChanged);
            chkBPTech3 = new CheckBox();
            chkBPTech3.CheckedChanged += new EventHandler(chkbpTech3_CheckedChanged);
            chkBPTech2 = new CheckBox();
            chkBPTech2.CheckedChanged += new EventHandler(chkbpTech2_CheckedChanged);
            chkBPTech1 = new CheckBox();
            chkBPTech1.CheckedChanged += new EventHandler(chkbpTech1_CheckedChanged);
            btnReactionsSaveSettings = new Button();
            btnReactionsSaveSettings.Click += new EventHandler(btnReactionsSaveSettings_Click);
            txtBPItemFilter = new TextBox();
            btnClearItemFilter = new Button();
            btnClearItemFilter.Click += new EventHandler(btnClearItemFilter_Click);
            lblBPFilter = new Label();
            grpBPType.SuspendLayout();
            grpBPSize.SuspendLayout();
            grpBPTechLevel.SuspendLayout();
            SuspendLayout();
            // 
            // treBlueprintTreeView
            // 
            treBlueprintTreeView.Location = new Point(12, 56);
            treBlueprintTreeView.Name = "treBlueprintTreeView";
            treBlueprintTreeView.Size = new Size(368, 372);
            treBlueprintTreeView.TabIndex = 0;
            // 
            // lblIntro
            // 
            lblIntro.AutoSize = true;
            lblIntro.Location = new Point(12, 9);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(0, 13);
            lblIntro.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(242, 654);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 27);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // grpBPType
            // 
            grpBPType.Controls.Add(chkBPNPCBPOs);
            grpBPType.Controls.Add(rbtnBPMiscBlueprints);
            grpBPType.Controls.Add(rbtnBPReactionBlueprints);
            grpBPType.Controls.Add(rbtnBPStructureModuleBlueprints);
            grpBPType.Controls.Add(rbtnBPFavoriteBlueprints);
            grpBPType.Controls.Add(rbtnBPStructureRigsBlueprints);
            grpBPType.Controls.Add(rbtnBPComponentBlueprints);
            grpBPType.Controls.Add(rbtnBPDeployableBlueprints);
            grpBPType.Controls.Add(rbtnBPCelestialsBlueprints);
            grpBPType.Controls.Add(rbtnBPOwnedBlueprints);
            grpBPType.Controls.Add(rbtnBPSubsystemBlueprints);
            grpBPType.Controls.Add(rbtnBPBoosterBlueprints);
            grpBPType.Controls.Add(rbtnBPModuleBlueprints);
            grpBPType.Controls.Add(rbtnBPRigBlueprints);
            grpBPType.Controls.Add(rbtnBPStructureBlueprints);
            grpBPType.Controls.Add(rbtnBPDroneBlueprints);
            grpBPType.Controls.Add(rbtnBPAmmoChargeBlueprints);
            grpBPType.Controls.Add(rbtnBPShipBlueprints);
            grpBPType.Controls.Add(rbtnBPAll);
            grpBPType.Location = new Point(12, 434);
            grpBPType.Name = "grpBPType";
            grpBPType.Size = new Size(236, 187);
            grpBPType.TabIndex = 3;
            grpBPType.TabStop = false;
            grpBPType.Text = "Blueprint Type";
            // 
            // chkBPNPCBPOs
            // 
            chkBPNPCBPOs.Location = new Point(141, 162);
            chkBPNPCBPOs.Name = "chkBPNPCBPOs";
            chkBPNPCBPOs.Size = new Size(81, 17);
            chkBPNPCBPOs.TabIndex = 6;
            chkBPNPCBPOs.Text = "NPC BPOs";
            chkBPNPCBPOs.UseVisualStyleBackColor = true;
            // 
            // rbtnBPMiscBlueprints
            // 
            rbtnBPMiscBlueprints.AutoSize = true;
            rbtnBPMiscBlueprints.Location = new Point(185, 54);
            rbtnBPMiscBlueprints.Name = "rbtnBPMiscBlueprints";
            rbtnBPMiscBlueprints.Size = new Size(50, 17);
            rbtnBPMiscBlueprints.TabIndex = 13;
            rbtnBPMiscBlueprints.Text = "Misc.";
            rbtnBPMiscBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPReactionBlueprints
            // 
            rbtnBPReactionBlueprints.AutoSize = true;
            rbtnBPReactionBlueprints.Location = new Point(141, 126);
            rbtnBPReactionBlueprints.Name = "rbtnBPReactionBlueprints";
            rbtnBPReactionBlueprints.Size = new Size(73, 17);
            rbtnBPReactionBlueprints.TabIndex = 17;
            rbtnBPReactionBlueprints.Text = "Reactions";
            rbtnBPReactionBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPStructureModuleBlueprints
            // 
            rbtnBPStructureModuleBlueprints.AutoSize = true;
            rbtnBPStructureModuleBlueprints.Location = new Point(13, 144);
            rbtnBPStructureModuleBlueprints.Name = "rbtnBPStructureModuleBlueprints";
            rbtnBPStructureModuleBlueprints.Size = new Size(111, 17);
            rbtnBPStructureModuleBlueprints.TabIndex = 16;
            rbtnBPStructureModuleBlueprints.Text = "Structure Modules";
            rbtnBPStructureModuleBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPFavoriteBlueprints
            // 
            rbtnBPFavoriteBlueprints.AutoSize = true;
            rbtnBPFavoriteBlueprints.Location = new Point(141, 144);
            rbtnBPFavoriteBlueprints.Name = "rbtnBPFavoriteBlueprints";
            rbtnBPFavoriteBlueprints.Size = new Size(68, 17);
            rbtnBPFavoriteBlueprints.TabIndex = 15;
            rbtnBPFavoriteBlueprints.Text = "Favorites";
            rbtnBPFavoriteBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPStructureRigsBlueprints
            // 
            rbtnBPStructureRigsBlueprints.AutoSize = true;
            rbtnBPStructureRigsBlueprints.Location = new Point(13, 162);
            rbtnBPStructureRigsBlueprints.Name = "rbtnBPStructureRigsBlueprints";
            rbtnBPStructureRigsBlueprints.Size = new Size(92, 17);
            rbtnBPStructureRigsBlueprints.TabIndex = 14;
            rbtnBPStructureRigsBlueprints.Text = "Structure Rigs";
            rbtnBPStructureRigsBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPComponentBlueprints
            // 
            rbtnBPComponentBlueprints.AutoSize = true;
            rbtnBPComponentBlueprints.Location = new Point(13, 126);
            rbtnBPComponentBlueprints.Name = "rbtnBPComponentBlueprints";
            rbtnBPComponentBlueprints.Size = new Size(84, 17);
            rbtnBPComponentBlueprints.TabIndex = 12;
            rbtnBPComponentBlueprints.Text = "Components";
            rbtnBPComponentBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPDeployableBlueprints
            // 
            rbtnBPDeployableBlueprints.AutoSize = true;
            rbtnBPDeployableBlueprints.Location = new Point(141, 108);
            rbtnBPDeployableBlueprints.Name = "rbtnBPDeployableBlueprints";
            rbtnBPDeployableBlueprints.Size = new Size(78, 17);
            rbtnBPDeployableBlueprints.TabIndex = 11;
            rbtnBPDeployableBlueprints.Text = "Deployable";
            rbtnBPDeployableBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPCelestialsBlueprints
            // 
            rbtnBPCelestialsBlueprints.AutoSize = true;
            rbtnBPCelestialsBlueprints.Location = new Point(13, 108);
            rbtnBPCelestialsBlueprints.Name = "rbtnBPCelestialsBlueprints";
            rbtnBPCelestialsBlueprints.Size = new Size(69, 17);
            rbtnBPCelestialsBlueprints.TabIndex = 10;
            rbtnBPCelestialsBlueprints.Text = "Celestials";
            rbtnBPCelestialsBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPOwnedBlueprints
            // 
            rbtnBPOwnedBlueprints.AutoSize = true;
            rbtnBPOwnedBlueprints.Location = new Point(141, 18);
            rbtnBPOwnedBlueprints.Name = "rbtnBPOwnedBlueprints";
            rbtnBPOwnedBlueprints.Size = new Size(59, 17);
            rbtnBPOwnedBlueprints.TabIndex = 9;
            rbtnBPOwnedBlueprints.Text = "Owned";
            rbtnBPOwnedBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPSubsystemBlueprints
            // 
            rbtnBPSubsystemBlueprints.AutoSize = true;
            rbtnBPSubsystemBlueprints.Location = new Point(141, 90);
            rbtnBPSubsystemBlueprints.Name = "rbtnBPSubsystemBlueprints";
            rbtnBPSubsystemBlueprints.Size = new Size(81, 17);
            rbtnBPSubsystemBlueprints.TabIndex = 8;
            rbtnBPSubsystemBlueprints.Text = "Subsystems";
            rbtnBPSubsystemBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPBoosterBlueprints
            // 
            rbtnBPBoosterBlueprints.AutoSize = true;
            rbtnBPBoosterBlueprints.Location = new Point(13, 72);
            rbtnBPBoosterBlueprints.Name = "rbtnBPBoosterBlueprints";
            rbtnBPBoosterBlueprints.Size = new Size(66, 17);
            rbtnBPBoosterBlueprints.TabIndex = 7;
            rbtnBPBoosterBlueprints.Text = "Boosters";
            rbtnBPBoosterBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPModuleBlueprints
            // 
            rbtnBPModuleBlueprints.AutoSize = true;
            rbtnBPModuleBlueprints.Location = new Point(141, 36);
            rbtnBPModuleBlueprints.Name = "rbtnBPModuleBlueprints";
            rbtnBPModuleBlueprints.Size = new Size(65, 17);
            rbtnBPModuleBlueprints.TabIndex = 6;
            rbtnBPModuleBlueprints.Text = "Modules";
            rbtnBPModuleBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPRigBlueprints
            // 
            rbtnBPRigBlueprints.AutoSize = true;
            rbtnBPRigBlueprints.Location = new Point(141, 54);
            rbtnBPRigBlueprints.Name = "rbtnBPRigBlueprints";
            rbtnBPRigBlueprints.Size = new Size(46, 17);
            rbtnBPRigBlueprints.TabIndex = 5;
            rbtnBPRigBlueprints.Text = "Rigs";
            rbtnBPRigBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPStructureBlueprints
            // 
            rbtnBPStructureBlueprints.AutoSize = true;
            rbtnBPStructureBlueprints.Location = new Point(13, 90);
            rbtnBPStructureBlueprints.Name = "rbtnBPStructureBlueprints";
            rbtnBPStructureBlueprints.Size = new Size(73, 17);
            rbtnBPStructureBlueprints.TabIndex = 4;
            rbtnBPStructureBlueprints.Text = "Structures";
            rbtnBPStructureBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPDroneBlueprints
            // 
            rbtnBPDroneBlueprints.AutoSize = true;
            rbtnBPDroneBlueprints.Location = new Point(141, 72);
            rbtnBPDroneBlueprints.Name = "rbtnBPDroneBlueprints";
            rbtnBPDroneBlueprints.Size = new Size(59, 17);
            rbtnBPDroneBlueprints.TabIndex = 3;
            rbtnBPDroneBlueprints.Text = "Drones";
            rbtnBPDroneBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPAmmoChargeBlueprints
            // 
            rbtnBPAmmoChargeBlueprints.AutoSize = true;
            rbtnBPAmmoChargeBlueprints.Location = new Point(13, 54);
            rbtnBPAmmoChargeBlueprints.Name = "rbtnBPAmmoChargeBlueprints";
            rbtnBPAmmoChargeBlueprints.Size = new Size(123, 17);
            rbtnBPAmmoChargeBlueprints.TabIndex = 2;
            rbtnBPAmmoChargeBlueprints.Text = "Ammunition/Charges";
            rbtnBPAmmoChargeBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPShipBlueprints
            // 
            rbtnBPShipBlueprints.AutoSize = true;
            rbtnBPShipBlueprints.Location = new Point(13, 36);
            rbtnBPShipBlueprints.Name = "rbtnBPShipBlueprints";
            rbtnBPShipBlueprints.Size = new Size(51, 17);
            rbtnBPShipBlueprints.TabIndex = 1;
            rbtnBPShipBlueprints.Text = "Ships";
            rbtnBPShipBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPAll
            // 
            rbtnBPAll.AutoSize = true;
            rbtnBPAll.Location = new Point(13, 18);
            rbtnBPAll.Name = "rbtnBPAll";
            rbtnBPAll.Size = new Size(36, 17);
            rbtnBPAll.TabIndex = 0;
            rbtnBPAll.Text = "All";
            rbtnBPAll.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(156, 654);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(81, 27);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // grpBPSize
            // 
            grpBPSize.Controls.Add(chkBPXLarge);
            grpBPSize.Controls.Add(chkBPLarge);
            grpBPSize.Controls.Add(chkBPMedium);
            grpBPSize.Controls.Add(chkBPSmall);
            grpBPSize.Location = new Point(255, 434);
            grpBPSize.Name = "grpBPSize";
            grpBPSize.Size = new Size(125, 55);
            grpBPSize.TabIndex = 5;
            grpBPSize.TabStop = false;
            grpBPSize.Text = "Size Limit";
            // 
            // chkBPXLarge
            // 
            chkBPXLarge.AutoSize = true;
            chkBPXLarge.Location = new Point(68, 33);
            chkBPXLarge.Name = "chkBPXLarge";
            chkBPXLarge.Size = new Size(39, 17);
            chkBPXLarge.TabIndex = 3;
            chkBPXLarge.Text = "XL";
            chkBPXLarge.UseVisualStyleBackColor = true;
            // 
            // chkBPLarge
            // 
            chkBPLarge.AutoSize = true;
            chkBPLarge.Location = new Point(68, 15);
            chkBPLarge.Name = "chkBPLarge";
            chkBPLarge.Size = new Size(32, 17);
            chkBPLarge.TabIndex = 2;
            chkBPLarge.Text = "L";
            chkBPLarge.UseVisualStyleBackColor = true;
            // 
            // chkBPMedium
            // 
            chkBPMedium.AutoSize = true;
            chkBPMedium.Location = new Point(19, 33);
            chkBPMedium.Name = "chkBPMedium";
            chkBPMedium.Size = new Size(35, 17);
            chkBPMedium.TabIndex = 1;
            chkBPMedium.Text = "M";
            chkBPMedium.UseVisualStyleBackColor = true;
            // 
            // chkBPSmall
            // 
            chkBPSmall.AutoSize = true;
            chkBPSmall.Location = new Point(19, 15);
            chkBPSmall.Name = "chkBPSmall";
            chkBPSmall.Size = new Size(33, 17);
            chkBPSmall.TabIndex = 0;
            chkBPSmall.Text = "S";
            chkBPSmall.UseVisualStyleBackColor = true;
            // 
            // grpBPTechLevel
            // 
            grpBPTechLevel.Controls.Add(chkBPPirate);
            grpBPTechLevel.Controls.Add(chkBPNavy);
            grpBPTechLevel.Controls.Add(chkBPStory);
            grpBPTechLevel.Controls.Add(chkBPTech3);
            grpBPTechLevel.Controls.Add(chkBPTech2);
            grpBPTechLevel.Controls.Add(chkBPTech1);
            grpBPTechLevel.Location = new Point(255, 495);
            grpBPTechLevel.Name = "grpBPTechLevel";
            grpBPTechLevel.Size = new Size(125, 126);
            grpBPTechLevel.TabIndex = 6;
            grpBPTechLevel.TabStop = false;
            grpBPTechLevel.Text = "Tech Level";
            // 
            // chkBPPirate
            // 
            chkBPPirate.AutoSize = true;
            chkBPPirate.Checked = true;
            chkBPPirate.CheckState = CheckState.Checked;
            chkBPPirate.Location = new Point(19, 105);
            chkBPPirate.Name = "chkBPPirate";
            chkBPPirate.Size = new Size(53, 17);
            chkBPPirate.TabIndex = 5;
            chkBPPirate.Text = "Pirate";
            chkBPPirate.UseVisualStyleBackColor = true;
            // 
            // chkBPNavy
            // 
            chkBPNavy.AutoSize = true;
            chkBPNavy.Checked = true;
            chkBPNavy.CheckState = CheckState.Checked;
            chkBPNavy.Location = new Point(19, 87);
            chkBPNavy.Name = "chkBPNavy";
            chkBPNavy.Size = new Size(51, 17);
            chkBPNavy.TabIndex = 4;
            chkBPNavy.Text = "Navy";
            chkBPNavy.UseVisualStyleBackColor = true;
            // 
            // chkBPStory
            // 
            chkBPStory.AutoSize = true;
            chkBPStory.Checked = true;
            chkBPStory.CheckState = CheckState.Checked;
            chkBPStory.Location = new Point(19, 69);
            chkBPStory.Name = "chkBPStory";
            chkBPStory.Size = new Size(66, 17);
            chkBPStory.TabIndex = 3;
            chkBPStory.Text = "Storyline";
            chkBPStory.UseVisualStyleBackColor = true;
            // 
            // chkBPTech3
            // 
            chkBPTech3.AutoSize = true;
            chkBPTech3.Checked = true;
            chkBPTech3.CheckState = CheckState.Checked;
            chkBPTech3.Location = new Point(19, 51);
            chkBPTech3.Name = "chkBPTech3";
            chkBPTech3.Size = new Size(60, 17);
            chkBPTech3.TabIndex = 2;
            chkBPTech3.Text = "Tech 3";
            chkBPTech3.UseVisualStyleBackColor = true;
            // 
            // chkBPTech2
            // 
            chkBPTech2.AutoSize = true;
            chkBPTech2.Checked = true;
            chkBPTech2.CheckState = CheckState.Checked;
            chkBPTech2.Location = new Point(19, 33);
            chkBPTech2.Name = "chkBPTech2";
            chkBPTech2.Size = new Size(60, 17);
            chkBPTech2.TabIndex = 1;
            chkBPTech2.Text = "Tech 2";
            chkBPTech2.UseVisualStyleBackColor = true;
            // 
            // chkBPTech1
            // 
            chkBPTech1.Checked = true;
            chkBPTech1.CheckState = CheckState.Checked;
            chkBPTech1.Location = new Point(19, 15);
            chkBPTech1.Name = "chkBPTech1";
            chkBPTech1.Size = new Size(81, 17);
            chkBPTech1.TabIndex = 0;
            chkBPTech1.Text = "Tech 1";
            chkBPTech1.UseVisualStyleBackColor = true;
            // 
            // btnReactionsSaveSettings
            // 
            btnReactionsSaveSettings.Location = new Point(70, 654);
            btnReactionsSaveSettings.Name = "btnReactionsSaveSettings";
            btnReactionsSaveSettings.Size = new Size(81, 27);
            btnReactionsSaveSettings.TabIndex = 17;
            btnReactionsSaveSettings.Text = "Save Settings";
            btnReactionsSaveSettings.UseVisualStyleBackColor = true;
            // 
            // txtBPItemFilter
            // 
            txtBPItemFilter.Location = new Point(70, 627);
            txtBPItemFilter.Name = "txtBPItemFilter";
            txtBPItemFilter.Size = new Size(253, 20);
            txtBPItemFilter.TabIndex = 18;
            // 
            // btnClearItemFilter
            // 
            btnClearItemFilter.Location = new Point(329, 627);
            btnClearItemFilter.Name = "btnClearItemFilter";
            btnClearItemFilter.Size = new Size(51, 21);
            btnClearItemFilter.TabIndex = 19;
            btnClearItemFilter.Text = "Clear";
            btnClearItemFilter.UseVisualStyleBackColor = true;
            // 
            // lblBPFilter
            // 
            lblBPFilter.AutoSize = true;
            lblBPFilter.Location = new Point(15, 630);
            lblBPFilter.Name = "lblBPFilter";
            lblBPFilter.Size = new Size(49, 13);
            lblBPFilter.TabIndex = 20;
            lblBPFilter.Text = "BP Filter:";
            // 
            // frmBlueprintList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 692);
            Controls.Add(txtBPItemFilter);
            Controls.Add(btnClearItemFilter);
            Controls.Add(lblBPFilter);
            Controls.Add(btnReactionsSaveSettings);
            Controls.Add(grpBPTechLevel);
            Controls.Add(grpBPSize);
            Controls.Add(btnRefresh);
            Controls.Add(grpBPType);
            Controls.Add(btnClose);
            Controls.Add(lblIntro);
            Controls.Add(treBlueprintTreeView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBlueprintList";
            Text = "Blueprint List";
            grpBPType.ResumeLayout(false);
            grpBPType.PerformLayout();
            grpBPSize.ResumeLayout(false);
            grpBPSize.PerformLayout();
            grpBPTechLevel.ResumeLayout(false);
            grpBPTechLevel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        internal TreeView treBlueprintTreeView;
        internal Label lblIntro;
        internal Button btnClose;
        internal GroupBox grpBPType;
        internal RadioButton rbtnBPOwnedBlueprints;
        internal RadioButton rbtnBPSubsystemBlueprints;
        internal RadioButton rbtnBPBoosterBlueprints;
        internal RadioButton rbtnBPModuleBlueprints;
        internal RadioButton rbtnBPRigBlueprints;
        internal RadioButton rbtnBPStructureBlueprints;
        internal RadioButton rbtnBPDroneBlueprints;
        internal RadioButton rbtnBPAmmoChargeBlueprints;
        internal RadioButton rbtnBPShipBlueprints;
        internal RadioButton rbtnBPAll;
        internal Button btnRefresh;
        internal RadioButton rbtnBPDeployableBlueprints;
        internal RadioButton rbtnBPCelestialsBlueprints;
        internal RadioButton rbtnBPMiscBlueprints;
        internal RadioButton rbtnBPComponentBlueprints;
        internal RadioButton rbtnBPStructureRigsBlueprints;
        internal RadioButton rbtnBPFavoriteBlueprints;
        internal GroupBox grpBPSize;
        internal CheckBox chkBPXLarge;
        internal CheckBox chkBPLarge;
        internal CheckBox chkBPMedium;
        internal CheckBox chkBPSmall;
        internal GroupBox grpBPTechLevel;
        internal CheckBox chkBPPirate;
        internal CheckBox chkBPNavy;
        internal CheckBox chkBPStory;
        internal CheckBox chkBPTech3;
        internal CheckBox chkBPTech2;
        internal CheckBox chkBPTech1;
        internal RadioButton rbtnBPStructureModuleBlueprints;
        internal Button btnReactionsSaveSettings;
        internal TextBox txtBPItemFilter;
        internal Button btnClearItemFilter;
        internal Label lblBPFilter;
        internal RadioButton rbtnBPReactionBlueprints;
        internal CheckBox chkBPNPCBPOs;
    }
}