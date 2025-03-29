using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ManufacturingFacility : UserControl
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
            lblInclude = new Label();
            chkFacilityIncludeUsage = new CheckBox();
            chkFacilityIncludeUsage.CheckedChanged += new EventHandler(chkFacilityIncludeUsage_CheckedChanged);
            chkFacilityIncludeTime = new CheckBox();
            chkFacilityIncludeTime.CheckedChanged += new EventHandler(chkFacilityIncludeTime_CheckedChanged);
            lblFacilityDefault = new Label();
            lblFacilityDefault.DoubleClick += new EventHandler(lblFacilityDefault_DoubleClick);
            chkFacilityIncludeCost = new CheckBox();
            chkFacilityIncludeCost.CheckedChanged += new EventHandler(chkFacilityIncludeCost_CheckedChanged);
            cmbFacility = new ComboBox();
            cmbFacility.SelectedIndexChanged += new EventHandler(cmbFacilityorArray_SelectedIndexChanged);
            cmbFacility.DropDown += new EventHandler(cmbFacilityorArray_DropDown);
            cmbFacility.GotFocus += new EventHandler(cmbFacilityorArray_GotFocus);
            cmbFacility.LostFocus += new EventHandler(cmbFacilityorArray_LostFocus);
            cmbFacility.KeyPress += new KeyPressEventHandler(cmbFacilityorArray_KeyPress);
            cmbFacilitySystem = new ComboBox();
            cmbFacilitySystem.SelectedIndexChanged += new EventHandler(cmbFacilitySystem_SelectedIndexChanged);
            cmbFacilitySystem.DropDown += new EventHandler(cmbFacilitySystem_DropDown);
            cmbFacilitySystem.GotFocus += new EventHandler(cmbFacilitySystem_GotFocus);
            cmbFacilitySystem.LostFocus += new EventHandler(cmbFacilitySystem_LostFocus);
            cmbFacilitySystem.KeyPress += new KeyPressEventHandler(cmbFacilitySystem_KeyPress);
            cmbFacilityRegion = new ComboBox();
            cmbFacilityRegion.SelectedIndexChanged += new EventHandler(cmbFacilityRegion_SelectedIndexChanged);
            cmbFacilityRegion.DropDown += new EventHandler(cmbFacilityRegion_DropDown);
            cmbFacilityRegion.GotFocus += new EventHandler(cmbFacilityRegion_GotFocus);
            cmbFacilityRegion.LostFocus += new EventHandler(cmbFacilityRegion_LostFocus);
            cmbFacilityRegion.KeyPress += new KeyPressEventHandler(cmbFacilityRegion_KeyPress);
            lblFacilityLocation = new Label();
            lblFacilityType = new Label();
            cmbFacilityType = new ComboBox();
            cmbFacilityType.SelectedIndexChanged += new EventHandler(cmbFacilityType_SelectedIndexChanged);
            cmbFacilityType.DropDown += new EventHandler(cmbFacilityType_DropDown);
            cmbFacilityType.GotFocus += new EventHandler(cmbFacilityType_GotFocus);
            cmbFacilityType.LostFocus += new EventHandler(cmbFacilityType_LostFocus);
            cmbFacilityType.KeyPress += new KeyPressEventHandler(cmbFacilityType_KeyPress);
            cmbLargeShips = new ComboBox();
            cmbLargeShips.SelectedIndexChanged += new EventHandler(POSCombos_SelectedIndexChanged);
            lblLargeShips = new Label();
            cmbFuelBlocks = new ComboBox();
            cmbFuelBlocks.SelectedIndexChanged += new EventHandler(POSCombos_SelectedIndexChanged);
            lblFuelBlocks = new Label();
            cmbModules = new ComboBox();
            cmbModules.SelectedIndexChanged += new EventHandler(POSCombos_SelectedIndexChanged);
            lblModules = new Label();
            btnFacilityFitting = new Button();
            btnFacilityFitting.Click += new EventHandler(btnFacilityFitting_Click);
            txtFacilityManualTax = new TextBox();
            txtFacilityManualTax.KeyPress += new KeyPressEventHandler(txtFacilityManualTax_KeyPress);
            txtFacilityManualTax.KeyDown += new KeyEventHandler(txtFacilityManualTax_KeyDown);
            txtFacilityManualTax.GotFocus += new EventHandler(txtFacilityManualTax_GotFocus);
            txtFacilityManualTax.LostFocus += new EventHandler(txtFacilityManualTax_LostFocus);
            lblFacilityManualTax = new Label();
            btnFacilitySave = new Button();
            btnFacilitySave.MouseHover += new EventHandler(btnFacilitySave_MouseHover);
            btnFacilitySave.MouseLeave += new EventHandler(btnFacilitySave_MouseLeave);
            btnFacilitySave.Click += new EventHandler(btnFacilitySave_Click);
            txtFacilityManualTE = new TextBox();
            txtFacilityManualTE.KeyPress += new KeyPressEventHandler(txtFacilityManualTE_KeyPress);
            txtFacilityManualTE.KeyDown += new KeyEventHandler(txtFacilityManualTE_KeyDown);
            txtFacilityManualTE.GotFocus += new EventHandler(txtFacilityManualTE_GotFocus);
            txtFacilityManualTE.LostFocus += new EventHandler(txtFacilityManualTE_LostFocus);
            txtFacilityManualME = new TextBox();
            txtFacilityManualME.KeyPress += new KeyPressEventHandler(txtFacilityManualME_KeyPress);
            txtFacilityManualME.KeyDown += new KeyEventHandler(txtFacilityManualME_KeyDown);
            txtFacilityManualME.GotFocus += new EventHandler(txtFacilityManualME_GotFocus);
            txtFacilityManualME.LostFocus += new EventHandler(txtFacilityManualME_LostFocus);
            lblFacilityManualTE = new Label();
            lblFacilityManualME = new Label();
            lblFacilityManualCost = new Label();
            txtFacilityManualCost = new TextBox();
            txtFacilityManualCost.KeyPress += new KeyPressEventHandler(txtFacilityManualCost_KeyPress);
            txtFacilityManualCost.KeyDown += new KeyEventHandler(txtFacilityManualCost_KeyDown);
            txtFacilityManualCost.GotFocus += new EventHandler(txtFacilityManualCost_GotFocus);
            txtFacilityManualCost.LostFocus += new EventHandler(txtFacilityManualCost_LostFocus);
            lblFacilityFWUpgrade = new Label();
            cmbFacilityFWUpgrade = new ComboBox();
            cmbFacilityFWUpgrade.SelectedIndexChanged += new EventHandler(cmbFWUpgrade_SelectedIndexChanged);
            cmbFacilityFWUpgrade.KeyPress += new KeyPressEventHandler(cmbFWUpgrade_KeyPress);
            chkFacilityToggle = new CheckBox();
            chkFacilityToggle.CheckedChanged += new EventHandler(chkFacilityToggle_CheckedChanged);
            lblFacilityUsage = new Label();
            lblFacilityUsage.DoubleClick += new EventHandler(lblFacilityUsage_DoubleClick);
            cmbFacilityActivities = new ComboBox();
            cmbFacilityActivities.SelectedIndexChanged += new EventHandler(cmbFacilityActivities_SelectedIndexChanged);
            cmbFacilityActivities.DropDown += new EventHandler(cmbFacilityActivities_DropDown);
            cmbFacilityActivities.GotFocus += new EventHandler(cmbFacilityActivities_GotFocus);
            cmbFacilityActivities.LostFocus += new EventHandler(cmbFacilityActivities_LostFocus);
            cmbFacilityActivities.KeyPress += new KeyPressEventHandler(cmbFacilityActivities_KeyPress);
            lblFacilityActivity = new Label();
            mainToolTip = new ToolTip(components);
            chkFacilityConvertToOre = new CheckBox();
            chkFacilityConvertToOre.CheckedChanged += new EventHandler(chkFacilityConvertToOre_CheckedChanged);
            btnConversiontoOreSettings = new Button();
            btnConversiontoOreSettings.Click += new EventHandler(btnConversiontoOreSettings_Click);
            SuspendLayout();
            // 
            // lblInclude
            // 
            lblInclude.AutoSize = true;
            lblInclude.Location = new Point(136, 4);
            lblInclude.Name = "lblInclude";
            lblInclude.Size = new Size(45, 13);
            lblInclude.TabIndex = 6;
            lblInclude.Text = "Include:";
            // 
            // chkFacilityIncludeUsage
            // 
            chkFacilityIncludeUsage.AutoSize = true;
            chkFacilityIncludeUsage.Location = new Point(139, 20);
            chkFacilityIncludeUsage.Name = "chkFacilityIncludeUsage";
            chkFacilityIncludeUsage.Size = new Size(57, 17);
            chkFacilityIncludeUsage.TabIndex = 7;
            chkFacilityIncludeUsage.Text = "Usage";
            chkFacilityIncludeUsage.UseVisualStyleBackColor = true;
            // 
            // chkFacilityIncludeTime
            // 
            chkFacilityIncludeTime.AutoSize = true;
            chkFacilityIncludeTime.Location = new Point(243, 20);
            chkFacilityIncludeTime.Name = "chkFacilityIncludeTime";
            chkFacilityIncludeTime.Size = new Size(49, 17);
            chkFacilityIncludeTime.TabIndex = 10;
            chkFacilityIncludeTime.Text = "Time";
            chkFacilityIncludeTime.UseVisualStyleBackColor = true;
            // 
            // lblFacilityDefault
            // 
            lblFacilityDefault.ForeColor = SystemColors.Highlight;
            lblFacilityDefault.Location = new Point(218, 3);
            lblFacilityDefault.Name = "lblFacilityDefault";
            lblFacilityDefault.Size = new Size(79, 20);
            lblFacilityDefault.TabIndex = 4;
            lblFacilityDefault.Text = "Default Facility";
            lblFacilityDefault.TextAlign = ContentAlignment.TopCenter;
            // 
            // chkFacilityIncludeCost
            // 
            chkFacilityIncludeCost.AutoSize = true;
            chkFacilityIncludeCost.Location = new Point(196, 20);
            chkFacilityIncludeCost.Name = "chkFacilityIncludeCost";
            chkFacilityIncludeCost.Size = new Size(47, 17);
            chkFacilityIncludeCost.TabIndex = 9;
            chkFacilityIncludeCost.Text = "Cost";
            chkFacilityIncludeCost.UseVisualStyleBackColor = true;
            // 
            // cmbFacility
            // 
            cmbFacility.FormattingEnabled = true;
            cmbFacility.ItemHeight = 13;
            cmbFacility.Location = new Point(5, 60);
            cmbFacility.Name = "cmbFacility";
            cmbFacility.Size = new Size(274, 21);
            cmbFacility.TabIndex = 14;
            cmbFacility.Text = "Select Facility";
            // 
            // cmbFacilitySystem
            // 
            cmbFacilitySystem.FormattingEnabled = true;
            cmbFacilitySystem.Location = new Point(139, 37);
            cmbFacilitySystem.Name = "cmbFacilitySystem";
            cmbFacilitySystem.Size = new Size(157, 21);
            cmbFacilitySystem.TabIndex = 13;
            cmbFacilitySystem.Text = "Select System";
            // 
            // cmbFacilityRegion
            // 
            cmbFacilityRegion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFacilityRegion.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbFacilityRegion.FormattingEnabled = true;
            cmbFacilityRegion.Location = new Point(5, 37);
            cmbFacilityRegion.Name = "cmbFacilityRegion";
            cmbFacilityRegion.Size = new Size(130, 21);
            cmbFacilityRegion.TabIndex = 12;
            cmbFacilityRegion.Text = "Select Region";
            // 
            // lblFacilityLocation
            // 
            lblFacilityLocation.AutoSize = true;
            lblFacilityLocation.Location = new Point(3, 22);
            lblFacilityLocation.Name = "lblFacilityLocation";
            lblFacilityLocation.Size = new Size(51, 13);
            lblFacilityLocation.TabIndex = 11;
            lblFacilityLocation.Text = "Location:";
            // 
            // lblFacilityType
            // 
            lblFacilityType.AutoSize = true;
            lblFacilityType.Location = new Point(1, 4);
            lblFacilityType.Name = "lblFacilityType";
            lblFacilityType.Size = new Size(69, 13);
            lblFacilityType.TabIndex = 2;
            lblFacilityType.Text = "Facility Type:";
            // 
            // cmbFacilityType
            // 
            cmbFacilityType.FormattingEnabled = true;
            cmbFacilityType.ItemHeight = 13;
            cmbFacilityType.Location = new Point(68, 1);
            cmbFacilityType.Name = "cmbFacilityType";
            cmbFacilityType.Size = new Size(65, 21);
            cmbFacilityType.TabIndex = 3;
            // 
            // cmbLargeShips
            // 
            cmbLargeShips.FormattingEnabled = true;
            cmbLargeShips.Items.AddRange(new object[] { "All", "Capital", "Large" });
            cmbLargeShips.Location = new Point(196, 229);
            cmbLargeShips.Name = "cmbLargeShips";
            cmbLargeShips.Size = new Size(78, 21);
            cmbLargeShips.TabIndex = 32;
            cmbLargeShips.Text = "All";
            // 
            // lblLargeShips
            // 
            lblLargeShips.AutoSize = true;
            lblLargeShips.Location = new Point(193, 213);
            lblLargeShips.Name = "lblLargeShips";
            lblLargeShips.Size = new Size(66, 13);
            lblLargeShips.TabIndex = 31;
            lblLargeShips.Text = "Large Ships:";
            // 
            // cmbFuelBlocks
            // 
            cmbFuelBlocks.FormattingEnabled = true;
            cmbFuelBlocks.Items.AddRange(new object[] { "All", "Ammunition", "Component" });
            cmbFuelBlocks.Location = new Point(102, 229);
            cmbFuelBlocks.Name = "cmbFuelBlocks";
            cmbFuelBlocks.Size = new Size(78, 21);
            cmbFuelBlocks.TabIndex = 30;
            cmbFuelBlocks.Text = "All";
            // 
            // lblFuelBlocks
            // 
            lblFuelBlocks.AutoSize = true;
            lblFuelBlocks.Location = new Point(99, 213);
            lblFuelBlocks.Name = "lblFuelBlocks";
            lblFuelBlocks.Size = new Size(65, 13);
            lblFuelBlocks.TabIndex = 29;
            lblFuelBlocks.Text = "Fuel Blocks:";
            // 
            // cmbModules
            // 
            cmbModules.FormattingEnabled = true;
            cmbModules.Items.AddRange(new object[] { "All", "Equipment", "Rapid" });
            cmbModules.Location = new Point(9, 229);
            cmbModules.Name = "cmbModules";
            cmbModules.Size = new Size(78, 21);
            cmbModules.TabIndex = 28;
            cmbModules.Text = "All";
            // 
            // lblModules
            // 
            lblModules.Location = new Point(6, 196);
            lblModules.Name = "lblModules";
            lblModules.Size = new Size(87, 30);
            lblModules.TabIndex = 27;
            lblModules.Text = "Assembly Arrays: Modules:";
            // 
            // btnFacilityFitting
            // 
            btnFacilityFitting.Location = new Point(209, 85);
            btnFacilityFitting.Name = "btnFacilityFitting";
            btnFacilityFitting.Size = new Size(43, 22);
            btnFacilityFitting.TabIndex = 23;
            btnFacilityFitting.Text = "Fitting";
            btnFacilityFitting.UseVisualStyleBackColor = true;
            // 
            // txtFacilityManualTax
            // 
            txtFacilityManualTax.Location = new Point(133, 106);
            txtFacilityManualTax.MaxLength = 7;
            txtFacilityManualTax.Name = "txtFacilityManualTax";
            txtFacilityManualTax.Size = new Size(50, 20);
            txtFacilityManualTax.TabIndex = 22;
            txtFacilityManualTax.TextAlign = HorizontalAlignment.Right;
            // 
            // lblFacilityManualTax
            // 
            lblFacilityManualTax.AutoSize = true;
            lblFacilityManualTax.Location = new Point(99, 109);
            lblFacilityManualTax.Name = "lblFacilityManualTax";
            lblFacilityManualTax.Size = new Size(28, 13);
            lblFacilityManualTax.TabIndex = 21;
            lblFacilityManualTax.Text = "Tax:";
            // 
            // btnFacilitySave
            // 
            btnFacilitySave.Location = new Point(255, 85);
            btnFacilitySave.Name = "btnFacilitySave";
            btnFacilitySave.Size = new Size(40, 22);
            btnFacilitySave.TabIndex = 24;
            btnFacilitySave.Text = "Save";
            btnFacilitySave.UseVisualStyleBackColor = true;
            // 
            // txtFacilityManualTE
            // 
            txtFacilityManualTE.Location = new Point(133, 85);
            txtFacilityManualTE.MaxLength = 7;
            txtFacilityManualTE.Name = "txtFacilityManualTE";
            txtFacilityManualTE.Size = new Size(50, 20);
            txtFacilityManualTE.TabIndex = 20;
            txtFacilityManualTE.TextAlign = HorizontalAlignment.Right;
            // 
            // txtFacilityManualME
            // 
            txtFacilityManualME.Location = new Point(68, 86);
            txtFacilityManualME.MaxLength = 7;
            txtFacilityManualME.Name = "txtFacilityManualME";
            txtFacilityManualME.Size = new Size(50, 20);
            txtFacilityManualME.TabIndex = 16;
            txtFacilityManualME.TextAlign = HorizontalAlignment.Right;
            // 
            // lblFacilityManualTE
            // 
            lblFacilityManualTE.AutoSize = true;
            lblFacilityManualTE.Location = new Point(103, 88);
            lblFacilityManualTE.Name = "lblFacilityManualTE";
            lblFacilityManualTE.Size = new Size(24, 13);
            lblFacilityManualTE.TabIndex = 19;
            lblFacilityManualTE.Text = "TE:";
            // 
            // lblFacilityManualME
            // 
            lblFacilityManualME.AutoSize = true;
            lblFacilityManualME.Location = new Point(6, 88);
            lblFacilityManualME.Name = "lblFacilityManualME";
            lblFacilityManualME.Size = new Size(53, 13);
            lblFacilityManualME.TabIndex = 15;
            lblFacilityManualME.Text = "Moon Eff:";
            // 
            // lblFacilityManualCost
            // 
            lblFacilityManualCost.AutoSize = true;
            lblFacilityManualCost.Location = new Point(6, 109);
            lblFacilityManualCost.Name = "lblFacilityManualCost";
            lblFacilityManualCost.Size = new Size(31, 13);
            lblFacilityManualCost.TabIndex = 17;
            lblFacilityManualCost.Text = "Cost:";
            // 
            // txtFacilityManualCost
            // 
            txtFacilityManualCost.Location = new Point(38, 105);
            txtFacilityManualCost.MaxLength = 7;
            txtFacilityManualCost.Name = "txtFacilityManualCost";
            txtFacilityManualCost.Size = new Size(50, 20);
            txtFacilityManualCost.TabIndex = 18;
            txtFacilityManualCost.TextAlign = HorizontalAlignment.Right;
            // 
            // lblFacilityFWUpgrade
            // 
            lblFacilityFWUpgrade.AutoSize = true;
            lblFacilityFWUpgrade.Location = new Point(177, 167);
            lblFacilityFWUpgrade.Name = "lblFacilityFWUpgrade";
            lblFacilityFWUpgrade.Size = new Size(56, 13);
            lblFacilityFWUpgrade.TabIndex = 25;
            lblFacilityFWUpgrade.Text = "FW Level:";
            // 
            // cmbFacilityFWUpgrade
            // 
            cmbFacilityFWUpgrade.FormattingEnabled = true;
            cmbFacilityFWUpgrade.Items.AddRange(new object[] { "None", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5" });
            cmbFacilityFWUpgrade.Location = new Point(231, 164);
            cmbFacilityFWUpgrade.Name = "cmbFacilityFWUpgrade";
            cmbFacilityFWUpgrade.Size = new Size(58, 21);
            cmbFacilityFWUpgrade.TabIndex = 26;
            cmbFacilityFWUpgrade.Text = "Level 5";
            // 
            // chkFacilityToggle
            // 
            chkFacilityToggle.AutoSize = true;
            chkFacilityToggle.Location = new Point(139, 3);
            chkFacilityToggle.Name = "chkFacilityToggle";
            chkFacilityToggle.Size = new Size(79, 17);
            chkFacilityToggle.TabIndex = 5;
            chkFacilityToggle.Text = "Dessy/Cap";
            chkFacilityToggle.UseVisualStyleBackColor = true;
            // 
            // lblFacilityUsage
            // 
            lblFacilityUsage.BorderStyle = BorderStyle.FixedSingle;
            lblFacilityUsage.Location = new Point(115, 141);
            lblFacilityUsage.Name = "lblFacilityUsage";
            lblFacilityUsage.Size = new Size(177, 17);
            lblFacilityUsage.TabIndex = 8;
            lblFacilityUsage.Text = "0.00";
            lblFacilityUsage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbFacilityActivities
            // 
            cmbFacilityActivities.FormattingEnabled = true;
            cmbFacilityActivities.Location = new Point(4, 161);
            cmbFacilityActivities.Name = "cmbFacilityActivities";
            cmbFacilityActivities.Size = new Size(170, 21);
            cmbFacilityActivities.TabIndex = 1;
            cmbFacilityActivities.Text = "Select Activity";
            // 
            // lblFacilityActivity
            // 
            lblFacilityActivity.AutoSize = true;
            lblFacilityActivity.Location = new Point(3, 145);
            lblFacilityActivity.Name = "lblFacilityActivity";
            lblFacilityActivity.Size = new Size(44, 13);
            lblFacilityActivity.TabIndex = 0;
            lblFacilityActivity.Text = "Activity:";
            // 
            // chkFacilityConvertToOre
            // 
            chkFacilityConvertToOre.AutoSize = true;
            chkFacilityConvertToOre.Location = new Point(33, 260);
            chkFacilityConvertToOre.Name = "chkFacilityConvertToOre";
            chkFacilityConvertToOre.Size = new Size(95, 17);
            chkFacilityConvertToOre.TabIndex = 33;
            chkFacilityConvertToOre.Text = "Convert to Ore";
            chkFacilityConvertToOre.UseVisualStyleBackColor = true;
            chkFacilityConvertToOre.Visible = false;
            // 
            // btnConversiontoOreSettings
            // 
            btnConversiontoOreSettings.Location = new Point(133, 256);
            btnConversiontoOreSettings.Name = "btnConversiontoOreSettings";
            btnConversiontoOreSettings.Size = new Size(56, 22);
            btnConversiontoOreSettings.TabIndex = 34;
            btnConversiontoOreSettings.Text = "Settings";
            btnConversiontoOreSettings.UseVisualStyleBackColor = true;
            // 
            // ManufacturingFacility
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnFacilityFitting);
            Controls.Add(btnFacilitySave);
            Controls.Add(btnConversiontoOreSettings);
            Controls.Add(chkFacilityConvertToOre);
            Controls.Add(lblModules);
            Controls.Add(lblFuelBlocks);
            Controls.Add(lblLargeShips);
            Controls.Add(cmbFacilityType);
            Controls.Add(cmbFacilityActivities);
            Controls.Add(lblFacilityActivity);
            Controls.Add(lblFacilityUsage);
            Controls.Add(chkFacilityToggle);
            Controls.Add(cmbFacilityFWUpgrade);
            Controls.Add(txtFacilityManualCost);
            Controls.Add(lblFacilityManualCost);
            Controls.Add(txtFacilityManualTax);
            Controls.Add(lblFacilityManualTax);
            Controls.Add(txtFacilityManualTE);
            Controls.Add(txtFacilityManualME);
            Controls.Add(lblFacilityManualTE);
            Controls.Add(lblFacilityManualME);
            Controls.Add(lblInclude);
            Controls.Add(chkFacilityIncludeUsage);
            Controls.Add(chkFacilityIncludeTime);
            Controls.Add(lblFacilityDefault);
            Controls.Add(chkFacilityIncludeCost);
            Controls.Add(cmbFacility);
            Controls.Add(cmbFacilitySystem);
            Controls.Add(cmbFacilityRegion);
            Controls.Add(lblFacilityLocation);
            Controls.Add(lblFacilityType);
            Controls.Add(cmbLargeShips);
            Controls.Add(cmbFuelBlocks);
            Controls.Add(cmbModules);
            Controls.Add(lblFacilityFWUpgrade);
            Name = "ManufacturingFacility";
            Size = new Size(330, 296);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Label lblInclude;
        internal CheckBox chkFacilityIncludeUsage;
        internal CheckBox chkFacilityIncludeTime;
        internal Label lblFacilityDefault;
        internal CheckBox chkFacilityIncludeCost;
        internal ComboBox cmbFacility;
        internal ComboBox cmbFacilitySystem;
        internal ComboBox cmbFacilityRegion;
        internal Label lblFacilityLocation;
        internal Label lblFacilityType;
        internal ComboBox cmbFacilityType;
        internal ComboBox cmbLargeShips;
        internal Label lblLargeShips;
        internal ComboBox cmbFuelBlocks;
        internal Label lblFuelBlocks;
        internal ComboBox cmbModules;
        internal Label lblModules;
        internal Button btnFacilityFitting;
        internal TextBox txtFacilityManualTax;
        internal Label lblFacilityManualTax;
        internal Button btnFacilitySave;
        internal TextBox txtFacilityManualTE;
        internal TextBox txtFacilityManualME;
        internal Label lblFacilityManualTE;
        internal Label lblFacilityManualME;
        internal Label lblFacilityManualCost;
        internal TextBox txtFacilityManualCost;
        internal Label lblFacilityFWUpgrade;
        internal ComboBox cmbFacilityFWUpgrade;
        internal CheckBox chkFacilityToggle;
        internal Label lblFacilityUsage;
        internal ComboBox cmbFacilityActivities;
        internal Label lblFacilityActivity;
        internal ToolTip mainToolTip;
        internal CheckBox chkFacilityConvertToOre;
        internal Button btnConversiontoOreSettings;
    }
}