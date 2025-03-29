using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMETE : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMETE));
            gbBPBlueprintType = new GroupBox();
            rbtnBPStructureModulesBlueprints = new RadioButton();
            rbtnBPCelestialsBlueprints = new RadioButton();
            rbtnBPMiscBlueprints = new RadioButton();
            rbtnBPStructureBlueprints = new RadioButton();
            rbtnBPStructureRigsBlueprints = new RadioButton();
            rbtnBPOwnedBlueprints = new RadioButton();
            rbtnBPRigBlueprints = new RadioButton();
            rbtnBPBoosterBlueprints = new RadioButton();
            rbtnBPModuleBlueprints = new RadioButton();
            rbtnBPAmmoChargeBlueprints = new RadioButton();
            rbtnBPDroneBlueprints = new RadioButton();
            rbtnBPComponentBlueprints = new RadioButton();
            rbtnBPAllBlueprints = new RadioButton();
            rbtnBPShipBlueprints = new RadioButton();
            rbtnBPDeployableBlueprints = new RadioButton();
            cmbBlueprintSelection = new ComboBox();
            lblSelectBlueprint = new Label();
            ResearchFacility = new ManufacturingFacility();
            gbBPBlueprintType.SuspendLayout();
            SuspendLayout();
            // 
            // gbBPBlueprintType
            // 
            gbBPBlueprintType.Controls.Add(rbtnBPStructureModulesBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPCelestialsBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPMiscBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPStructureBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPStructureRigsBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPOwnedBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPRigBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPBoosterBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPModuleBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPAmmoChargeBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPDroneBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPComponentBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPAllBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPShipBlueprints);
            gbBPBlueprintType.Controls.Add(rbtnBPDeployableBlueprints);
            gbBPBlueprintType.Location = new Point(24, 59);
            gbBPBlueprintType.Name = "gbBPBlueprintType";
            gbBPBlueprintType.Size = new Size(348, 125);
            gbBPBlueprintType.TabIndex = 74;
            gbBPBlueprintType.TabStop = false;
            gbBPBlueprintType.Text = "Blueprint Type";
            // 
            // rbtnBPStructureModulesBlueprints
            // 
            rbtnBPStructureModulesBlueprints.AutoSize = true;
            rbtnBPStructureModulesBlueprints.Location = new Point(208, 85);
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
            rbtnBPCelestialsBlueprints.Location = new Point(208, 51);
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
            rbtnBPMiscBlueprints.Location = new Point(208, 68);
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
            rbtnBPBoosterBlueprints.Location = new Point(208, 34);
            rbtnBPBoosterBlueprints.Name = "rbtnBPBoosterBlueprints";
            rbtnBPBoosterBlueprints.Size = new Size(66, 17);
            rbtnBPBoosterBlueprints.TabIndex = 11;
            rbtnBPBoosterBlueprints.TabStop = true;
            rbtnBPBoosterBlueprints.Text = "Boosters";
            rbtnBPBoosterBlueprints.UseVisualStyleBackColor = true;
            // 
            // rbtnBPModuleBlueprints
            // 
            rbtnBPModuleBlueprints.AutoSize = true;
            rbtnBPModuleBlueprints.Location = new Point(208, 17);
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
            // cmbBlueprintSelection
            // 
            cmbBlueprintSelection.Location = new Point(24, 35);
            cmbBlueprintSelection.Name = "cmbBlueprintSelection";
            cmbBlueprintSelection.Size = new Size(294, 21);
            cmbBlueprintSelection.TabIndex = 73;
            cmbBlueprintSelection.Text = "Select Blueprint";
            // 
            // lblSelectBlueprint
            // 
            lblSelectBlueprint.AutoSize = true;
            lblSelectBlueprint.Location = new Point(23, 20);
            lblSelectBlueprint.Name = "lblSelectBlueprint";
            lblSelectBlueprint.Size = new Size(93, 13);
            lblSelectBlueprint.TabIndex = 72;
            lblSelectBlueprint.Text = "Selected Blueprint";
            // 
            // ResearchFacility
            // 
            ResearchFacility.BackColor = SystemColors.ActiveCaption;
            ResearchFacility.Location = new Point(33, 207);
            ResearchFacility.Name = "ResearchFacility";
            ResearchFacility.Size = new Size(280, 142);
            ResearchFacility.TabIndex = 75;
            // 
            // frmMETE
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 483);
            Controls.Add(ResearchFacility);
            Controls.Add(gbBPBlueprintType);
            Controls.Add(cmbBlueprintSelection);
            Controls.Add(lblSelectBlueprint);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMETE";
            Text = "Blueprint Research Calculator";
            gbBPBlueprintType.ResumeLayout(false);
            gbBPBlueprintType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        internal GroupBox gbBPBlueprintType;
        internal RadioButton rbtnBPStructureModulesBlueprints;
        internal RadioButton rbtnBPCelestialsBlueprints;
        internal RadioButton rbtnBPMiscBlueprints;
        internal RadioButton rbtnBPStructureBlueprints;
        internal RadioButton rbtnBPStructureRigsBlueprints;
        internal RadioButton rbtnBPOwnedBlueprints;
        internal RadioButton rbtnBPRigBlueprints;
        internal RadioButton rbtnBPBoosterBlueprints;
        internal RadioButton rbtnBPModuleBlueprints;
        internal RadioButton rbtnBPAmmoChargeBlueprints;
        internal RadioButton rbtnBPDroneBlueprints;
        internal RadioButton rbtnBPComponentBlueprints;
        internal RadioButton rbtnBPAllBlueprints;
        internal RadioButton rbtnBPShipBlueprints;
        internal RadioButton rbtnBPDeployableBlueprints;
        internal ComboBox cmbBlueprintSelection;
        internal Label lblSelectBlueprint;
        internal ManufacturingFacility ResearchFacility;
    }
}