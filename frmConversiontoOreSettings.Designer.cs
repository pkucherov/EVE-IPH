using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmConversiontoOreSettings : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConversiontoOreSettings));
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            rbtnConversionNone = new RadioButton();
            rbtnConversionNone.CheckedChanged += new EventHandler(rbtnConversionNone_CheckedChanged);
            gbConversionType = new GroupBox();
            chkCompressedIce = new CheckBox();
            chkCompressedIce.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkCompressedOre = new CheckBox();
            chkCompressedOre.CheckedChanged += new EventHandler(CheckOption_Changed);
            rbtnConversionOre = new RadioButton();
            rbtnConversionOre.CheckedChanged += new EventHandler(rbtnConversionOre_CheckedChanged);
            rbtnConversionIce = new RadioButton();
            rbtnConversionIce.CheckedChanged += new EventHandler(rbtnConversionIce_CheckedChanged);
            rbtnConversionOreIce = new RadioButton();
            rbtnConversionOreIce.CheckedChanged += new EventHandler(rbtnConversionOreIce_CheckedChanged);
            gbMinimizeOn = new GroupBox();
            rbtnOrePrice = new RadioButton();
            rbtnOrePrice.CheckedChanged += new EventHandler(RadioOption_Changed);
            rbtnOreVolume = new RadioButton();
            rbtnOreVolume.CheckedChanged += new EventHandler(RadioOption_Changed);
            rbtnRefinePrice = new RadioButton();
            rbtnRefinePrice.CheckedChanged += new EventHandler(RadioOption_Changed);
            gbSystemSecurity = new GroupBox();
            gbOreVariants = new GroupBox();
            chkUse10percent = new CheckBox();
            chkUse10percent.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkUse5percent = new CheckBox();
            chkUse5percent.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkUseBaseOre = new CheckBox();
            chkUseBaseOre.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkLowSec = new CheckBox();
            chkLowSec.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkHighSec = new CheckBox();
            chkHighSec.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkNullSec = new CheckBox();
            chkNullSec.CheckedChanged += new EventHandler(chkNullSec_CheckedChanged);
            gbMineOreLoc = new GroupBox();
            chkTriglavian = new CheckBox();
            chkTriglavian.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkCaldari = new CheckBox();
            chkCaldari.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkWH = new CheckBox();
            chkWH.CheckedChanged += new EventHandler(chkWH_CheckedChanged);
            chkWH.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkMinmatar = new CheckBox();
            chkMinmatar.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkGallente = new CheckBox();
            chkGallente.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkAmarr = new CheckBox();
            chkAmarr.CheckedChanged += new EventHandler(CheckOption_Changed);
            gbWHClasses = new GroupBox();
            chkC6 = new CheckBox();
            chkC6.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkC5 = new CheckBox();
            chkC5.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkC4 = new CheckBox();
            chkC4.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkC3 = new CheckBox();
            chkC3.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkC2 = new CheckBox();
            chkC2.CheckedChanged += new EventHandler(CheckOption_Changed);
            chkC1 = new CheckBox();
            chkC1.CheckedChanged += new EventHandler(CheckOption_Changed);
            tabPageIce = new TabPage();
            chkOre35 = new CheckBox();
            chkOre35.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre32 = new CheckBox();
            chkOre32.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre34 = new CheckBox();
            chkOre34.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre36 = new CheckBox();
            chkOre36.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre31 = new CheckBox();
            chkOre31.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre29 = new CheckBox();
            chkOre29.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre30 = new CheckBox();
            chkOre30.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre27 = new CheckBox();
            chkOre27.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre26 = new CheckBox();
            chkOre26.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre33 = new CheckBox();
            chkOre33.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre28 = new CheckBox();
            chkOre28.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre25 = new CheckBox();
            chkOre25.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre29 = new Label();
            lblOre29.Click += new EventHandler(OreLabels_Click);
            lblOre26 = new Label();
            lblOre26.Click += new EventHandler(OreLabels_Click);
            lblOre27 = new Label();
            lblOre27.Click += new EventHandler(OreLabels_Click);
            lblOre28 = new Label();
            lblOre28.Click += new EventHandler(OreLabels_Click);
            lblOre33 = new Label();
            lblOre33.Click += new EventHandler(OreLabels_Click);
            lblOre25 = new Label();
            lblOre25.Click += new EventHandler(OreLabels_Click);
            lblOre35 = new Label();
            lblOre35.Click += new EventHandler(OreLabels_Click);
            lblOre32 = new Label();
            lblOre32.Click += new EventHandler(OreLabels_Click);
            lblOre34 = new Label();
            lblOre34.Click += new EventHandler(OreLabels_Click);
            lblOre36 = new Label();
            lblOre36.Click += new EventHandler(OreLabels_Click);
            lblOre31 = new Label();
            lblOre31.Click += new EventHandler(OreLabels_Click);
            lblOre30 = new Label();
            lblOre30.Click += new EventHandler(OreLabels_Click);
            tabPageOres = new TabPage();
            chkOre20 = new CheckBox();
            chkOre20.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre20 = new Label();
            lblOre20.Click += new EventHandler(OreLabels_Click);
            chkOre22 = new CheckBox();
            chkOre22.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre23 = new CheckBox();
            chkOre23.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre23 = new Label();
            lblOre23.Click += new EventHandler(OreLabels_Click);
            lblOre22 = new Label();
            lblOre22.Click += new EventHandler(OreLabels_Click);
            chkOre24 = new CheckBox();
            chkOre24.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre21 = new CheckBox();
            chkOre21.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre21 = new Label();
            lblOre21.Click += new EventHandler(OreLabels_Click);
            lblOre24 = new Label();
            lblOre24.Click += new EventHandler(OreLabels_Click);
            chkOre17 = new CheckBox();
            chkOre17.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre18 = new CheckBox();
            chkOre18.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre19 = new CheckBox();
            chkOre19.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre1 = new Label();
            lblOre1.Click += new EventHandler(OreLabels_Click);
            chkOre14 = new CheckBox();
            chkOre14.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre15 = new CheckBox();
            chkOre15.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre11 = new CheckBox();
            chkOre11.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre15 = new Label();
            lblOre15.Click += new EventHandler(OreLabels_Click);
            chkOre7 = new CheckBox();
            chkOre7.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre5 = new CheckBox();
            chkOre5.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre14 = new Label();
            lblOre14.Click += new EventHandler(OreLabels_Click);
            chkOre16 = new CheckBox();
            chkOre16.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre3 = new CheckBox();
            chkOre3.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre5 = new Label();
            lblOre5.Click += new EventHandler(OreLabels_Click);
            lblOre8 = new Label();
            lblOre8.Click += new EventHandler(OreLabels_Click);
            chkOre13 = new CheckBox();
            chkOre13.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre8 = new CheckBox();
            chkOre8.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre12 = new CheckBox();
            chkOre12.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre11 = new Label();
            lblOre11.Click += new EventHandler(OreLabels_Click);
            lblOre3 = new Label();
            lblOre3.Click += new EventHandler(OreLabels_Click);
            lblOre7 = new Label();
            lblOre7.Click += new EventHandler(OreLabels_Click);
            chkOre10 = new CheckBox();
            chkOre10.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre1 = new CheckBox();
            chkOre1.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre9 = new CheckBox();
            chkOre9.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            chkOre6 = new CheckBox();
            chkOre6.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre9 = new Label();
            lblOre9.Click += new EventHandler(OreLabels_Click);
            lblOre10 = new Label();
            lblOre10.Click += new EventHandler(OreLabels_Click);
            lblOre12 = new Label();
            lblOre12.Click += new EventHandler(OreLabels_Click);
            lblOre13 = new Label();
            lblOre13.Click += new EventHandler(OreLabels_Click);
            lblOre16 = new Label();
            lblOre16.Click += new EventHandler(OreLabels_Click);
            chkOre2 = new CheckBox();
            chkOre2.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre6 = new Label();
            lblOre6.Click += new EventHandler(OreLabels_Click);
            lblOre2 = new Label();
            lblOre2.Click += new EventHandler(OreLabels_Click);
            chkOre4 = new CheckBox();
            chkOre4.CheckedChanged += new EventHandler(OreIce_CheckedChanged);
            lblOre4 = new Label();
            lblOre4.Click += new EventHandler(OreLabels_Click);
            lblOre18 = new Label();
            lblOre18.Click += new EventHandler(OreLabels_Click);
            lblOre17 = new Label();
            lblOre17.Click += new EventHandler(OreLabels_Click);
            lblOre19 = new Label();
            lblOre19.Click += new EventHandler(OreLabels_Click);
            tabOreSkills = new TabControl();
            tabIgnoreList = new TabPage();
            gbIgnoreIceProducts = new GroupBox();
            chkIgnore12 = new CheckBox();
            chkIgnore12.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            chkIgnore10 = new CheckBox();
            chkIgnore10.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            chkIgnore14 = new CheckBox();
            chkIgnore14.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            lblIgnore10 = new Label();
            lblIgnore10.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore14 = new Label();
            lblIgnore14.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore12 = new Label();
            lblIgnore12.Click += new EventHandler(IgnoreLabels_Click);
            chkIgnore15 = new CheckBox();
            chkIgnore15.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            chkIgnore11 = new CheckBox();
            chkIgnore11.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            chkIgnore9 = new CheckBox();
            chkIgnore9.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            chkIgnore13 = new CheckBox();
            chkIgnore13.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            lblIgnore9 = new Label();
            lblIgnore9.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore13 = new Label();
            lblIgnore13.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore15 = new Label();
            lblIgnore15.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore11 = new Label();
            lblIgnore11.Click += new EventHandler(IgnoreLabels_Click);
            gbIgnoreMinerals = new GroupBox();
            chkIgnore6 = new CheckBox();
            chkIgnore6.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            chkIgnore4 = new CheckBox();
            chkIgnore4.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            chkIgnore2 = new CheckBox();
            chkIgnore2.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            lblIgnore1 = new Label();
            lblIgnore1.Click += new EventHandler(IgnoreLabels_Click);
            chkIgnore8 = new CheckBox();
            chkIgnore8.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            lblIgnore5 = new Label();
            lblIgnore5.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore7 = new Label();
            lblIgnore7.Click += new EventHandler(IgnoreLabels_Click);
            chkIgnore7 = new CheckBox();
            chkIgnore7.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            lblIgnore6 = new Label();
            lblIgnore6.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore8 = new Label();
            lblIgnore8.Click += new EventHandler(IgnoreLabels_Click);
            chkIgnore5 = new CheckBox();
            chkIgnore5.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            lblIgnore3 = new Label();
            lblIgnore3.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore2 = new Label();
            lblIgnore2.Click += new EventHandler(IgnoreLabels_Click);
            lblIgnore4 = new Label();
            lblIgnore4.Click += new EventHandler(IgnoreLabels_Click);
            chkIgnore1 = new CheckBox();
            chkIgnore1.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            chkIgnore3 = new CheckBox();
            chkIgnore3.CheckedChanged += new EventHandler(IgnoreChecks_CheckedChanged);
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            btnReset = new Button();
            btnReset.Click += new EventHandler(btnReset_Click);
            gbConversionType.SuspendLayout();
            gbMinimizeOn.SuspendLayout();
            gbSystemSecurity.SuspendLayout();
            gbOreVariants.SuspendLayout();
            gbMineOreLoc.SuspendLayout();
            gbWHClasses.SuspendLayout();
            tabPageIce.SuspendLayout();
            tabPageOres.SuspendLayout();
            tabOreSkills.SuspendLayout();
            tabIgnoreList.SuspendLayout();
            gbIgnoreIceProducts.SuspendLayout();
            gbIgnoreMinerals.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(52, 362);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(96, 30);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // rbtnConversionNone
            // 
            rbtnConversionNone.AutoSize = true;
            rbtnConversionNone.Location = new Point(9, 19);
            rbtnConversionNone.Name = "rbtnConversionNone";
            rbtnConversionNone.Size = new Size(51, 17);
            rbtnConversionNone.TabIndex = 0;
            rbtnConversionNone.Text = "None";
            rbtnConversionNone.UseVisualStyleBackColor = true;
            // 
            // gbConversionType
            // 
            gbConversionType.Controls.Add(chkCompressedIce);
            gbConversionType.Controls.Add(chkCompressedOre);
            gbConversionType.Controls.Add(rbtnConversionOre);
            gbConversionType.Controls.Add(rbtnConversionIce);
            gbConversionType.Controls.Add(rbtnConversionOreIce);
            gbConversionType.Controls.Add(rbtnConversionNone);
            gbConversionType.Location = new Point(12, 12);
            gbConversionType.Name = "gbConversionType";
            gbConversionType.Size = new Size(243, 65);
            gbConversionType.TabIndex = 0;
            gbConversionType.TabStop = false;
            gbConversionType.Text = "Conversion Type:";
            // 
            // chkCompressedIce
            // 
            chkCompressedIce.AutoSize = true;
            chkCompressedIce.Location = new Point(125, 42);
            chkCompressedIce.Name = "chkCompressedIce";
            chkCompressedIce.Size = new Size(102, 17);
            chkCompressedIce.TabIndex = 5;
            chkCompressedIce.Text = "Compressed Ice";
            chkCompressedIce.UseVisualStyleBackColor = true;
            // 
            // chkCompressedOre
            // 
            chkCompressedOre.AutoSize = true;
            chkCompressedOre.Location = new Point(9, 42);
            chkCompressedOre.Name = "chkCompressedOre";
            chkCompressedOre.Size = new Size(104, 17);
            chkCompressedOre.TabIndex = 4;
            chkCompressedOre.Text = "Compressed Ore";
            chkCompressedOre.UseVisualStyleBackColor = true;
            // 
            // rbtnConversionOre
            // 
            rbtnConversionOre.AutoSize = true;
            rbtnConversionOre.Location = new Point(67, 19);
            rbtnConversionOre.Name = "rbtnConversionOre";
            rbtnConversionOre.Size = new Size(42, 17);
            rbtnConversionOre.TabIndex = 1;
            rbtnConversionOre.Text = "Ore";
            rbtnConversionOre.UseVisualStyleBackColor = true;
            // 
            // rbtnConversionIce
            // 
            rbtnConversionIce.AutoSize = true;
            rbtnConversionIce.Location = new Point(116, 19);
            rbtnConversionIce.Name = "rbtnConversionIce";
            rbtnConversionIce.Size = new Size(40, 17);
            rbtnConversionIce.TabIndex = 2;
            rbtnConversionIce.Text = "Ice";
            rbtnConversionIce.UseVisualStyleBackColor = true;
            // 
            // rbtnConversionOreIce
            // 
            rbtnConversionOreIce.AutoSize = true;
            rbtnConversionOreIce.Location = new Point(163, 19);
            rbtnConversionOreIce.Name = "rbtnConversionOreIce";
            rbtnConversionOreIce.Size = new Size(69, 17);
            rbtnConversionOreIce.TabIndex = 3;
            rbtnConversionOreIce.Text = "Ore && Ice";
            rbtnConversionOreIce.UseVisualStyleBackColor = true;
            // 
            // gbMinimizeOn
            // 
            gbMinimizeOn.Controls.Add(rbtnOrePrice);
            gbMinimizeOn.Controls.Add(rbtnOreVolume);
            gbMinimizeOn.Controls.Add(rbtnRefinePrice);
            gbMinimizeOn.Location = new Point(261, 12);
            gbMinimizeOn.Name = "gbMinimizeOn";
            gbMinimizeOn.Size = new Size(142, 65);
            gbMinimizeOn.TabIndex = 1;
            gbMinimizeOn.TabStop = false;
            gbMinimizeOn.Text = "Minimize on:";
            // 
            // rbtnOrePrice
            // 
            rbtnOrePrice.AutoSize = true;
            rbtnOrePrice.Location = new Point(9, 29);
            rbtnOrePrice.Name = "rbtnOrePrice";
            rbtnOrePrice.Size = new Size(89, 17);
            rbtnOrePrice.TabIndex = 1;
            rbtnOrePrice.Text = "Ore/Ice Price";
            rbtnOrePrice.UseVisualStyleBackColor = true;
            // 
            // rbtnOreVolume
            // 
            rbtnOreVolume.AutoSize = true;
            rbtnOreVolume.Location = new Point(9, 45);
            rbtnOreVolume.Name = "rbtnOreVolume";
            rbtnOreVolume.Size = new Size(100, 17);
            rbtnOreVolume.TabIndex = 2;
            rbtnOreVolume.Text = "Ore/Ice Volume";
            rbtnOreVolume.UseVisualStyleBackColor = true;
            // 
            // rbtnRefinePrice
            // 
            rbtnRefinePrice.AutoSize = true;
            rbtnRefinePrice.Location = new Point(9, 13);
            rbtnRefinePrice.Name = "rbtnRefinePrice";
            rbtnRefinePrice.Size = new Size(83, 17);
            rbtnRefinePrice.TabIndex = 0;
            rbtnRefinePrice.Text = "Refine Price";
            rbtnRefinePrice.UseVisualStyleBackColor = true;
            // 
            // gbSystemSecurity
            // 
            gbSystemSecurity.Controls.Add(gbOreVariants);
            gbSystemSecurity.Controls.Add(chkLowSec);
            gbSystemSecurity.Controls.Add(chkHighSec);
            gbSystemSecurity.Controls.Add(chkNullSec);
            gbSystemSecurity.Location = new Point(12, 83);
            gbSystemSecurity.Name = "gbSystemSecurity";
            gbSystemSecurity.Size = new Size(144, 110);
            gbSystemSecurity.TabIndex = 2;
            gbSystemSecurity.TabStop = false;
            gbSystemSecurity.Text = "System Security:";
            // 
            // gbOreVariants
            // 
            gbOreVariants.Controls.Add(chkUse10percent);
            gbOreVariants.Controls.Add(chkUse5percent);
            gbOreVariants.Controls.Add(chkUseBaseOre);
            gbOreVariants.Location = new Point(5, 68);
            gbOreVariants.Name = "gbOreVariants";
            gbOreVariants.Size = new Size(134, 37);
            gbOreVariants.TabIndex = 5;
            gbOreVariants.TabStop = false;
            gbOreVariants.Text = "Ore Variants";
            // 
            // chkUse10percent
            // 
            chkUse10percent.AutoSize = true;
            chkUse10percent.Location = new Point(87, 14);
            chkUse10percent.Name = "chkUse10percent";
            chkUse10percent.Size = new Size(46, 17);
            chkUse10percent.TabIndex = 2;
            chkUse10percent.Text = "10%";
            chkUse10percent.UseVisualStyleBackColor = true;
            // 
            // chkUse5percent
            // 
            chkUse5percent.AutoSize = true;
            chkUse5percent.Location = new Point(46, 14);
            chkUse5percent.Name = "chkUse5percent";
            chkUse5percent.Size = new Size(40, 17);
            chkUse5percent.TabIndex = 1;
            chkUse5percent.Text = "5%";
            chkUse5percent.UseVisualStyleBackColor = true;
            // 
            // chkUseBaseOre
            // 
            chkUseBaseOre.AutoSize = true;
            chkUseBaseOre.Location = new Point(5, 14);
            chkUseBaseOre.Name = "chkUseBaseOre";
            chkUseBaseOre.Size = new Size(40, 17);
            chkUseBaseOre.TabIndex = 0;
            chkUseBaseOre.Text = "0%";
            chkUseBaseOre.UseVisualStyleBackColor = true;
            // 
            // chkLowSec
            // 
            chkLowSec.AutoSize = true;
            chkLowSec.Location = new Point(75, 18);
            chkLowSec.Name = "chkLowSec";
            chkLowSec.Size = new Size(68, 17);
            chkLowSec.TabIndex = 1;
            chkLowSec.Text = "Low Sec";
            chkLowSec.UseVisualStyleBackColor = true;
            // 
            // chkHighSec
            // 
            chkHighSec.AutoSize = true;
            chkHighSec.Location = new Point(9, 18);
            chkHighSec.Name = "chkHighSec";
            chkHighSec.Size = new Size(70, 17);
            chkHighSec.TabIndex = 0;
            chkHighSec.Text = "High Sec";
            chkHighSec.UseVisualStyleBackColor = true;
            // 
            // chkNullSec
            // 
            chkNullSec.AutoSize = true;
            chkNullSec.Location = new Point(9, 37);
            chkNullSec.Name = "chkNullSec";
            chkNullSec.Size = new Size(66, 17);
            chkNullSec.TabIndex = 2;
            chkNullSec.Text = "Null Sec";
            chkNullSec.UseVisualStyleBackColor = true;
            // 
            // gbMineOreLoc
            // 
            gbMineOreLoc.Controls.Add(chkTriglavian);
            gbMineOreLoc.Controls.Add(chkCaldari);
            gbMineOreLoc.Controls.Add(chkWH);
            gbMineOreLoc.Controls.Add(chkMinmatar);
            gbMineOreLoc.Controls.Add(chkGallente);
            gbMineOreLoc.Controls.Add(chkAmarr);
            gbMineOreLoc.Controls.Add(gbWHClasses);
            gbMineOreLoc.Location = new Point(162, 83);
            gbMineOreLoc.Name = "gbMineOreLoc";
            gbMineOreLoc.Size = new Size(240, 110);
            gbMineOreLoc.TabIndex = 3;
            gbMineOreLoc.TabStop = false;
            gbMineOreLoc.Text = "Ore Location:";
            // 
            // chkTriglavian
            // 
            chkTriglavian.AutoSize = true;
            chkTriglavian.Location = new Point(121, 56);
            chkTriglavian.Name = "chkTriglavian";
            chkTriglavian.Size = new Size(106, 17);
            chkTriglavian.TabIndex = 5;
            chkTriglavian.Text = "Triglavian Space";
            chkTriglavian.UseVisualStyleBackColor = true;
            // 
            // chkCaldari
            // 
            chkCaldari.AutoSize = true;
            chkCaldari.Location = new Point(121, 18);
            chkCaldari.Name = "chkCaldari";
            chkCaldari.Size = new Size(92, 17);
            chkCaldari.TabIndex = 1;
            chkCaldari.Text = "Caldari Space";
            chkCaldari.UseVisualStyleBackColor = true;
            // 
            // chkWH
            // 
            chkWH.AutoSize = true;
            chkWH.Location = new Point(11, 56);
            chkWH.Name = "chkWH";
            chkWH.Size = new Size(108, 17);
            chkWH.TabIndex = 4;
            chkWH.Text = "Wormhole Space";
            chkWH.UseVisualStyleBackColor = true;
            // 
            // chkMinmatar
            // 
            chkMinmatar.AutoSize = true;
            chkMinmatar.Location = new Point(121, 37);
            chkMinmatar.Name = "chkMinmatar";
            chkMinmatar.Size = new Size(103, 17);
            chkMinmatar.TabIndex = 3;
            chkMinmatar.Text = "Minmatar Space";
            chkMinmatar.UseVisualStyleBackColor = true;
            // 
            // chkGallente
            // 
            chkGallente.AutoSize = true;
            chkGallente.Location = new Point(11, 37);
            chkGallente.Name = "chkGallente";
            chkGallente.Size = new Size(99, 17);
            chkGallente.TabIndex = 2;
            chkGallente.Text = "Gallente Space";
            chkGallente.UseVisualStyleBackColor = true;
            // 
            // chkAmarr
            // 
            chkAmarr.AutoSize = true;
            chkAmarr.Location = new Point(11, 18);
            chkAmarr.Name = "chkAmarr";
            chkAmarr.Size = new Size(87, 17);
            chkAmarr.TabIndex = 0;
            chkAmarr.Text = "Amarr Space";
            chkAmarr.UseVisualStyleBackColor = true;
            // 
            // gbWHClasses
            // 
            gbWHClasses.Controls.Add(chkC6);
            gbWHClasses.Controls.Add(chkC5);
            gbWHClasses.Controls.Add(chkC4);
            gbWHClasses.Controls.Add(chkC3);
            gbWHClasses.Controls.Add(chkC2);
            gbWHClasses.Controls.Add(chkC1);
            gbWHClasses.Location = new Point(5, 68);
            gbWHClasses.Name = "gbWHClasses";
            gbWHClasses.Size = new Size(230, 37);
            gbWHClasses.TabIndex = 6;
            gbWHClasses.TabStop = false;
            // 
            // chkC6
            // 
            chkC6.AutoSize = true;
            chkC6.Location = new Point(190, 14);
            chkC6.Name = "chkC6";
            chkC6.Size = new Size(39, 17);
            chkC6.TabIndex = 5;
            chkC6.Text = "C6";
            chkC6.UseVisualStyleBackColor = true;
            // 
            // chkC5
            // 
            chkC5.AutoSize = true;
            chkC5.Location = new Point(153, 14);
            chkC5.Name = "chkC5";
            chkC5.Size = new Size(39, 17);
            chkC5.TabIndex = 4;
            chkC5.Text = "C5";
            chkC5.UseVisualStyleBackColor = true;
            // 
            // chkC4
            // 
            chkC4.AutoSize = true;
            chkC4.Location = new Point(116, 14);
            chkC4.Name = "chkC4";
            chkC4.Size = new Size(39, 17);
            chkC4.TabIndex = 3;
            chkC4.Text = "C4";
            chkC4.UseVisualStyleBackColor = true;
            // 
            // chkC3
            // 
            chkC3.AutoSize = true;
            chkC3.Location = new Point(79, 14);
            chkC3.Name = "chkC3";
            chkC3.Size = new Size(39, 17);
            chkC3.TabIndex = 2;
            chkC3.Text = "C3";
            chkC3.UseVisualStyleBackColor = true;
            // 
            // chkC2
            // 
            chkC2.AutoSize = true;
            chkC2.Location = new Point(43, 14);
            chkC2.Name = "chkC2";
            chkC2.Size = new Size(39, 17);
            chkC2.TabIndex = 1;
            chkC2.Text = "C2";
            chkC2.UseVisualStyleBackColor = true;
            // 
            // chkC1
            // 
            chkC1.AutoSize = true;
            chkC1.Location = new Point(6, 14);
            chkC1.Name = "chkC1";
            chkC1.Size = new Size(39, 17);
            chkC1.TabIndex = 0;
            chkC1.Text = "C1";
            chkC1.UseVisualStyleBackColor = true;
            // 
            // tabPageIce
            // 
            tabPageIce.Controls.Add(chkOre35);
            tabPageIce.Controls.Add(chkOre32);
            tabPageIce.Controls.Add(chkOre34);
            tabPageIce.Controls.Add(chkOre36);
            tabPageIce.Controls.Add(chkOre31);
            tabPageIce.Controls.Add(chkOre29);
            tabPageIce.Controls.Add(chkOre30);
            tabPageIce.Controls.Add(chkOre27);
            tabPageIce.Controls.Add(chkOre26);
            tabPageIce.Controls.Add(chkOre33);
            tabPageIce.Controls.Add(chkOre28);
            tabPageIce.Controls.Add(chkOre25);
            tabPageIce.Controls.Add(lblOre29);
            tabPageIce.Controls.Add(lblOre26);
            tabPageIce.Controls.Add(lblOre27);
            tabPageIce.Controls.Add(lblOre28);
            tabPageIce.Controls.Add(lblOre33);
            tabPageIce.Controls.Add(lblOre25);
            tabPageIce.Controls.Add(lblOre35);
            tabPageIce.Controls.Add(lblOre32);
            tabPageIce.Controls.Add(lblOre34);
            tabPageIce.Controls.Add(lblOre36);
            tabPageIce.Controls.Add(lblOre31);
            tabPageIce.Controls.Add(lblOre30);
            tabPageIce.Location = new Point(4, 22);
            tabPageIce.Name = "tabPageIce";
            tabPageIce.Padding = new Padding(3);
            tabPageIce.Size = new Size(383, 132);
            tabPageIce.TabIndex = 1;
            tabPageIce.Text = "Ice";
            tabPageIce.UseVisualStyleBackColor = true;
            // 
            // chkOre35
            // 
            chkOre35.AutoSize = true;
            chkOre35.Location = new Point(120, 68);
            chkOre35.Name = "chkOre35";
            chkOre35.Size = new Size(15, 14);
            chkOre35.TabIndex = 21;
            chkOre35.UseVisualStyleBackColor = true;
            // 
            // chkOre32
            // 
            chkOre32.AutoSize = true;
            chkOre32.Location = new Point(120, 49);
            chkOre32.Name = "chkOre32";
            chkOre32.Size = new Size(15, 14);
            chkOre32.TabIndex = 15;
            chkOre32.UseVisualStyleBackColor = true;
            // 
            // chkOre34
            // 
            chkOre34.AutoSize = true;
            chkOre34.Location = new Point(9, 68);
            chkOre34.Name = "chkOre34";
            chkOre34.Size = new Size(15, 14);
            chkOre34.TabIndex = 19;
            chkOre34.UseVisualStyleBackColor = true;
            // 
            // chkOre36
            // 
            chkOre36.AutoSize = true;
            chkOre36.Location = new Point(261, 67);
            chkOre36.Name = "chkOre36";
            chkOre36.Size = new Size(15, 14);
            chkOre36.TabIndex = 23;
            chkOre36.UseVisualStyleBackColor = true;
            // 
            // chkOre31
            // 
            chkOre31.AutoSize = true;
            chkOre31.Location = new Point(9, 49);
            chkOre31.Name = "chkOre31";
            chkOre31.Size = new Size(15, 14);
            chkOre31.TabIndex = 13;
            chkOre31.UseVisualStyleBackColor = true;
            // 
            // chkOre29
            // 
            chkOre29.AutoSize = true;
            chkOre29.Location = new Point(120, 30);
            chkOre29.Name = "chkOre29";
            chkOre29.Size = new Size(15, 14);
            chkOre29.TabIndex = 8;
            chkOre29.UseVisualStyleBackColor = true;
            // 
            // chkOre30
            // 
            chkOre30.AutoSize = true;
            chkOre30.Location = new Point(261, 30);
            chkOre30.Name = "chkOre30";
            chkOre30.Size = new Size(15, 14);
            chkOre30.TabIndex = 10;
            chkOre30.UseVisualStyleBackColor = true;
            // 
            // chkOre27
            // 
            chkOre27.AutoSize = true;
            chkOre27.Location = new Point(261, 11);
            chkOre27.Name = "chkOre27";
            chkOre27.Size = new Size(15, 14);
            chkOre27.TabIndex = 4;
            chkOre27.UseVisualStyleBackColor = true;
            // 
            // chkOre26
            // 
            chkOre26.AutoSize = true;
            chkOre26.Location = new Point(120, 11);
            chkOre26.Name = "chkOre26";
            chkOre26.Size = new Size(15, 14);
            chkOre26.TabIndex = 2;
            chkOre26.UseVisualStyleBackColor = true;
            // 
            // chkOre33
            // 
            chkOre33.AutoSize = true;
            chkOre33.Location = new Point(261, 48);
            chkOre33.Name = "chkOre33";
            chkOre33.Size = new Size(15, 14);
            chkOre33.TabIndex = 17;
            chkOre33.UseVisualStyleBackColor = true;
            // 
            // chkOre28
            // 
            chkOre28.AutoSize = true;
            chkOre28.Location = new Point(9, 30);
            chkOre28.Name = "chkOre28";
            chkOre28.Size = new Size(15, 14);
            chkOre28.TabIndex = 6;
            chkOre28.UseVisualStyleBackColor = true;
            // 
            // chkOre25
            // 
            chkOre25.AutoSize = true;
            chkOre25.Location = new Point(9, 11);
            chkOre25.Name = "chkOre25";
            chkOre25.Size = new Size(15, 14);
            chkOre25.TabIndex = 0;
            chkOre25.UseVisualStyleBackColor = true;
            // 
            // lblOre29
            // 
            lblOre29.Location = new Point(139, 30);
            lblOre29.Name = "lblOre29";
            lblOre29.Size = new Size(106, 13);
            lblOre29.TabIndex = 9;
            lblOre29.Text = "Smooth Glacial Mass";
            // 
            // lblOre26
            // 
            lblOre26.Location = new Point(139, 11);
            lblOre26.Name = "lblOre26";
            lblOre26.Size = new Size(106, 13);
            lblOre26.TabIndex = 3;
            lblOre26.Text = "Thick Blue Ice";
            // 
            // lblOre27
            // 
            lblOre27.Location = new Point(280, 11);
            lblOre27.Name = "lblOre27";
            lblOre27.Size = new Size(95, 13);
            lblOre27.TabIndex = 5;
            lblOre27.Text = "Glare Crust";
            // 
            // lblOre28
            // 
            lblOre28.Location = new Point(28, 30);
            lblOre28.Name = "lblOre28";
            lblOre28.Size = new Size(106, 13);
            lblOre28.TabIndex = 7;
            lblOre28.Text = "Glacial Mass";
            // 
            // lblOre33
            // 
            lblOre33.Location = new Point(280, 49);
            lblOre33.Name = "lblOre33";
            lblOre33.Size = new Size(95, 13);
            lblOre33.TabIndex = 18;
            lblOre33.Text = "Gelidus";
            // 
            // lblOre25
            // 
            lblOre25.Location = new Point(28, 11);
            lblOre25.Name = "lblOre25";
            lblOre25.Size = new Size(106, 13);
            lblOre25.TabIndex = 1;
            lblOre25.Text = "Blue Ice";
            // 
            // lblOre35
            // 
            lblOre35.Location = new Point(139, 68);
            lblOre35.Name = "lblOre35";
            lblOre35.Size = new Size(106, 13);
            lblOre35.TabIndex = 22;
            lblOre35.Text = "Pristine White Glaze";
            // 
            // lblOre32
            // 
            lblOre32.Location = new Point(139, 49);
            lblOre32.Name = "lblOre32";
            lblOre32.Size = new Size(106, 13);
            lblOre32.TabIndex = 16;
            lblOre32.Text = "Enriched Clear Icicle";
            // 
            // lblOre34
            // 
            lblOre34.Location = new Point(28, 68);
            lblOre34.Name = "lblOre34";
            lblOre34.Size = new Size(106, 13);
            lblOre34.TabIndex = 20;
            lblOre34.Text = "White Glaze";
            // 
            // lblOre36
            // 
            lblOre36.Location = new Point(280, 68);
            lblOre36.Name = "lblOre36";
            lblOre36.Size = new Size(95, 13);
            lblOre36.TabIndex = 24;
            lblOre36.Text = "Krystallos";
            // 
            // lblOre31
            // 
            lblOre31.Location = new Point(28, 49);
            lblOre31.Name = "lblOre31";
            lblOre31.Size = new Size(106, 13);
            lblOre31.TabIndex = 14;
            lblOre31.Text = "Clear Icicle";
            // 
            // lblOre30
            // 
            lblOre30.Location = new Point(280, 30);
            lblOre30.Name = "lblOre30";
            lblOre30.Size = new Size(95, 13);
            lblOre30.TabIndex = 11;
            lblOre30.Text = "Dark Glitter";
            // 
            // tabPageOres
            // 
            tabPageOres.Controls.Add(chkOre20);
            tabPageOres.Controls.Add(lblOre20);
            tabPageOres.Controls.Add(chkOre22);
            tabPageOres.Controls.Add(chkOre23);
            tabPageOres.Controls.Add(lblOre23);
            tabPageOres.Controls.Add(lblOre22);
            tabPageOres.Controls.Add(chkOre24);
            tabPageOres.Controls.Add(chkOre21);
            tabPageOres.Controls.Add(lblOre21);
            tabPageOres.Controls.Add(lblOre24);
            tabPageOres.Controls.Add(chkOre17);
            tabPageOres.Controls.Add(chkOre18);
            tabPageOres.Controls.Add(chkOre19);
            tabPageOres.Controls.Add(lblOre1);
            tabPageOres.Controls.Add(chkOre14);
            tabPageOres.Controls.Add(chkOre15);
            tabPageOres.Controls.Add(chkOre11);
            tabPageOres.Controls.Add(lblOre15);
            tabPageOres.Controls.Add(chkOre7);
            tabPageOres.Controls.Add(chkOre5);
            tabPageOres.Controls.Add(lblOre14);
            tabPageOres.Controls.Add(chkOre16);
            tabPageOres.Controls.Add(chkOre3);
            tabPageOres.Controls.Add(lblOre5);
            tabPageOres.Controls.Add(lblOre8);
            tabPageOres.Controls.Add(chkOre13);
            tabPageOres.Controls.Add(chkOre8);
            tabPageOres.Controls.Add(chkOre12);
            tabPageOres.Controls.Add(lblOre11);
            tabPageOres.Controls.Add(lblOre3);
            tabPageOres.Controls.Add(lblOre7);
            tabPageOres.Controls.Add(chkOre10);
            tabPageOres.Controls.Add(chkOre1);
            tabPageOres.Controls.Add(chkOre9);
            tabPageOres.Controls.Add(chkOre6);
            tabPageOres.Controls.Add(lblOre9);
            tabPageOres.Controls.Add(lblOre10);
            tabPageOres.Controls.Add(lblOre12);
            tabPageOres.Controls.Add(lblOre13);
            tabPageOres.Controls.Add(lblOre16);
            tabPageOres.Controls.Add(chkOre2);
            tabPageOres.Controls.Add(lblOre6);
            tabPageOres.Controls.Add(lblOre2);
            tabPageOres.Controls.Add(chkOre4);
            tabPageOres.Controls.Add(lblOre4);
            tabPageOres.Controls.Add(lblOre18);
            tabPageOres.Controls.Add(lblOre17);
            tabPageOres.Controls.Add(lblOre19);
            tabPageOres.Location = new Point(4, 22);
            tabPageOres.Name = "tabPageOres";
            tabPageOres.Padding = new Padding(3);
            tabPageOres.Size = new Size(383, 132);
            tabPageOres.TabIndex = 0;
            tabPageOres.Text = "Ore";
            tabPageOres.UseVisualStyleBackColor = true;
            // 
            // chkOre20
            // 
            chkOre20.AutoSize = true;
            chkOre20.Location = new Point(273, 88);
            chkOre20.Name = "chkOre20";
            chkOre20.Size = new Size(15, 14);
            chkOre20.TabIndex = 38;
            chkOre20.UseVisualStyleBackColor = true;
            // 
            // lblOre20
            // 
            lblOre20.Location = new Point(292, 89);
            lblOre20.Name = "lblOre20";
            lblOre20.Size = new Size(63, 13);
            lblOre20.TabIndex = 39;
            lblOre20.Text = "Griemeer";
            // 
            // chkOre22
            // 
            chkOre22.AutoSize = true;
            chkOre22.Location = new Point(97, 108);
            chkOre22.Name = "chkOre22";
            chkOre22.Size = new Size(15, 14);
            chkOre22.TabIndex = 42;
            chkOre22.UseVisualStyleBackColor = true;
            // 
            // chkOre23
            // 
            chkOre23.AutoSize = true;
            chkOre23.Location = new Point(185, 108);
            chkOre23.Name = "chkOre23";
            chkOre23.Size = new Size(15, 14);
            chkOre23.TabIndex = 44;
            chkOre23.UseVisualStyleBackColor = true;
            // 
            // lblOre23
            // 
            lblOre23.Location = new Point(204, 109);
            lblOre23.Name = "lblOre23";
            lblOre23.Size = new Size(63, 13);
            lblOre23.TabIndex = 45;
            lblOre23.Text = "Nocxite";
            // 
            // lblOre22
            // 
            lblOre22.Location = new Point(116, 109);
            lblOre22.Name = "lblOre22";
            lblOre22.Size = new Size(63, 13);
            lblOre22.TabIndex = 43;
            lblOre22.Text = "Kylixium";
            // 
            // chkOre24
            // 
            chkOre24.AutoSize = true;
            chkOre24.Location = new Point(273, 108);
            chkOre24.Name = "chkOre24";
            chkOre24.Size = new Size(15, 14);
            chkOre24.TabIndex = 46;
            chkOre24.UseVisualStyleBackColor = true;
            // 
            // chkOre21
            // 
            chkOre21.AutoSize = true;
            chkOre21.Location = new Point(9, 108);
            chkOre21.Name = "chkOre21";
            chkOre21.Size = new Size(15, 14);
            chkOre21.TabIndex = 40;
            chkOre21.UseVisualStyleBackColor = true;
            // 
            // lblOre21
            // 
            lblOre21.Location = new Point(28, 109);
            lblOre21.Name = "lblOre21";
            lblOre21.Size = new Size(63, 13);
            lblOre21.TabIndex = 41;
            lblOre21.Text = "Hezorime";
            // 
            // lblOre24
            // 
            lblOre24.Location = new Point(292, 109);
            lblOre24.Name = "lblOre24";
            lblOre24.Size = new Size(63, 13);
            lblOre24.TabIndex = 47;
            lblOre24.Text = "Ueganite";
            // 
            // chkOre17
            // 
            chkOre17.AutoSize = true;
            chkOre17.Location = new Point(9, 88);
            chkOre17.Name = "chkOre17";
            chkOre17.Size = new Size(15, 14);
            chkOre17.TabIndex = 32;
            chkOre17.UseVisualStyleBackColor = true;
            // 
            // chkOre18
            // 
            chkOre18.AutoSize = true;
            chkOre18.Location = new Point(97, 88);
            chkOre18.Name = "chkOre18";
            chkOre18.Size = new Size(15, 14);
            chkOre18.TabIndex = 34;
            chkOre18.UseVisualStyleBackColor = true;
            // 
            // chkOre19
            // 
            chkOre19.AutoSize = true;
            chkOre19.Location = new Point(185, 88);
            chkOre19.Name = "chkOre19";
            chkOre19.Size = new Size(15, 14);
            chkOre19.TabIndex = 36;
            chkOre19.UseVisualStyleBackColor = true;
            // 
            // lblOre1
            // 
            lblOre1.Location = new Point(28, 11);
            lblOre1.Name = "lblOre1";
            lblOre1.Size = new Size(63, 13);
            lblOre1.TabIndex = 1;
            lblOre1.Text = "Veldspar";
            // 
            // chkOre14
            // 
            chkOre14.AutoSize = true;
            chkOre14.Location = new Point(97, 68);
            chkOre14.Name = "chkOre14";
            chkOre14.Size = new Size(15, 14);
            chkOre14.TabIndex = 26;
            chkOre14.UseVisualStyleBackColor = true;
            // 
            // chkOre15
            // 
            chkOre15.AutoSize = true;
            chkOre15.Location = new Point(185, 68);
            chkOre15.Name = "chkOre15";
            chkOre15.Size = new Size(15, 14);
            chkOre15.TabIndex = 28;
            chkOre15.UseVisualStyleBackColor = true;
            // 
            // chkOre11
            // 
            chkOre11.AutoSize = true;
            chkOre11.Location = new Point(185, 49);
            chkOre11.Name = "chkOre11";
            chkOre11.Size = new Size(15, 14);
            chkOre11.TabIndex = 20;
            chkOre11.UseVisualStyleBackColor = true;
            // 
            // lblOre15
            // 
            lblOre15.Location = new Point(204, 69);
            lblOre15.Name = "lblOre15";
            lblOre15.Size = new Size(63, 13);
            lblOre15.TabIndex = 29;
            lblOre15.Text = "Arkonor";
            // 
            // chkOre7
            // 
            chkOre7.AutoSize = true;
            chkOre7.Location = new Point(185, 30);
            chkOre7.Name = "chkOre7";
            chkOre7.Size = new Size(15, 14);
            chkOre7.TabIndex = 12;
            chkOre7.UseVisualStyleBackColor = true;
            // 
            // chkOre5
            // 
            chkOre5.AutoSize = true;
            chkOre5.Location = new Point(9, 30);
            chkOre5.Name = "chkOre5";
            chkOre5.Size = new Size(15, 14);
            chkOre5.TabIndex = 8;
            chkOre5.UseVisualStyleBackColor = true;
            // 
            // lblOre14
            // 
            lblOre14.Location = new Point(116, 69);
            lblOre14.Name = "lblOre14";
            lblOre14.Size = new Size(63, 13);
            lblOre14.TabIndex = 27;
            lblOre14.Text = "Bistot";
            // 
            // chkOre16
            // 
            chkOre16.AutoSize = true;
            chkOre16.Location = new Point(273, 68);
            chkOre16.Name = "chkOre16";
            chkOre16.Size = new Size(15, 14);
            chkOre16.TabIndex = 30;
            chkOre16.UseVisualStyleBackColor = true;
            // 
            // chkOre3
            // 
            chkOre3.AutoSize = true;
            chkOre3.Location = new Point(185, 11);
            chkOre3.Name = "chkOre3";
            chkOre3.Size = new Size(15, 14);
            chkOre3.TabIndex = 4;
            chkOre3.UseVisualStyleBackColor = true;
            // 
            // lblOre5
            // 
            lblOre5.Location = new Point(28, 30);
            lblOre5.Name = "lblOre5";
            lblOre5.Size = new Size(63, 13);
            lblOre5.TabIndex = 9;
            lblOre5.Text = "Omber";
            // 
            // lblOre8
            // 
            lblOre8.Location = new Point(292, 30);
            lblOre8.Name = "lblOre8";
            lblOre8.Size = new Size(63, 13);
            lblOre8.TabIndex = 15;
            lblOre8.Text = "Hedbergite";
            // 
            // chkOre13
            // 
            chkOre13.AutoSize = true;
            chkOre13.Location = new Point(9, 68);
            chkOre13.Name = "chkOre13";
            chkOre13.Size = new Size(15, 14);
            chkOre13.TabIndex = 24;
            chkOre13.UseVisualStyleBackColor = true;
            // 
            // chkOre8
            // 
            chkOre8.AutoSize = true;
            chkOre8.Location = new Point(273, 30);
            chkOre8.Name = "chkOre8";
            chkOre8.Size = new Size(15, 14);
            chkOre8.TabIndex = 14;
            chkOre8.UseVisualStyleBackColor = true;
            // 
            // chkOre12
            // 
            chkOre12.AutoSize = true;
            chkOre12.Location = new Point(273, 49);
            chkOre12.Name = "chkOre12";
            chkOre12.Size = new Size(15, 14);
            chkOre12.TabIndex = 22;
            chkOre12.UseVisualStyleBackColor = true;
            // 
            // lblOre11
            // 
            lblOre11.Location = new Point(204, 49);
            lblOre11.Name = "lblOre11";
            lblOre11.Size = new Size(63, 13);
            lblOre11.TabIndex = 21;
            lblOre11.Text = "Dark Ochre";
            // 
            // lblOre3
            // 
            lblOre3.Location = new Point(204, 11);
            lblOre3.Name = "lblOre3";
            lblOre3.Size = new Size(63, 13);
            lblOre3.TabIndex = 5;
            lblOre3.Text = "Pyroxeres";
            // 
            // lblOre7
            // 
            lblOre7.Location = new Point(204, 30);
            lblOre7.Name = "lblOre7";
            lblOre7.Size = new Size(63, 13);
            lblOre7.TabIndex = 13;
            lblOre7.Text = "Hemorphite";
            // 
            // chkOre10
            // 
            chkOre10.AutoSize = true;
            chkOre10.Location = new Point(97, 49);
            chkOre10.Name = "chkOre10";
            chkOre10.Size = new Size(15, 14);
            chkOre10.TabIndex = 18;
            chkOre10.UseVisualStyleBackColor = true;
            // 
            // chkOre1
            // 
            chkOre1.AutoSize = true;
            chkOre1.Location = new Point(9, 11);
            chkOre1.Name = "chkOre1";
            chkOre1.Size = new Size(15, 14);
            chkOre1.TabIndex = 0;
            chkOre1.UseVisualStyleBackColor = true;
            // 
            // chkOre9
            // 
            chkOre9.AutoSize = true;
            chkOre9.Location = new Point(9, 49);
            chkOre9.Name = "chkOre9";
            chkOre9.Size = new Size(15, 14);
            chkOre9.TabIndex = 16;
            chkOre9.UseVisualStyleBackColor = true;
            // 
            // chkOre6
            // 
            chkOre6.AutoSize = true;
            chkOre6.Location = new Point(97, 30);
            chkOre6.Name = "chkOre6";
            chkOre6.Size = new Size(15, 14);
            chkOre6.TabIndex = 10;
            chkOre6.UseVisualStyleBackColor = true;
            // 
            // lblOre9
            // 
            lblOre9.Location = new Point(28, 49);
            lblOre9.Name = "lblOre9";
            lblOre9.Size = new Size(63, 13);
            lblOre9.TabIndex = 17;
            lblOre9.Text = "Jaspet";
            // 
            // lblOre10
            // 
            lblOre10.Location = new Point(116, 49);
            lblOre10.Name = "lblOre10";
            lblOre10.Size = new Size(63, 13);
            lblOre10.TabIndex = 19;
            lblOre10.Text = "Gneiss";
            // 
            // lblOre12
            // 
            lblOre12.Location = new Point(292, 49);
            lblOre12.Name = "lblOre12";
            lblOre12.Size = new Size(63, 13);
            lblOre12.TabIndex = 23;
            lblOre12.Text = "Spodumain";
            // 
            // lblOre13
            // 
            lblOre13.Location = new Point(28, 69);
            lblOre13.Name = "lblOre13";
            lblOre13.Size = new Size(63, 13);
            lblOre13.TabIndex = 25;
            lblOre13.Text = "Crokite";
            // 
            // lblOre16
            // 
            lblOre16.Location = new Point(292, 69);
            lblOre16.Name = "lblOre16";
            lblOre16.Size = new Size(63, 13);
            lblOre16.TabIndex = 31;
            lblOre16.Text = "Mercoxit";
            // 
            // chkOre2
            // 
            chkOre2.AutoSize = true;
            chkOre2.Location = new Point(97, 11);
            chkOre2.Name = "chkOre2";
            chkOre2.Size = new Size(15, 14);
            chkOre2.TabIndex = 2;
            chkOre2.UseVisualStyleBackColor = true;
            // 
            // lblOre6
            // 
            lblOre6.Location = new Point(116, 30);
            lblOre6.Name = "lblOre6";
            lblOre6.Size = new Size(63, 13);
            lblOre6.TabIndex = 11;
            lblOre6.Text = "Kernite";
            // 
            // lblOre2
            // 
            lblOre2.Location = new Point(116, 11);
            lblOre2.Name = "lblOre2";
            lblOre2.Size = new Size(63, 13);
            lblOre2.TabIndex = 3;
            lblOre2.Text = "Scordite";
            // 
            // chkOre4
            // 
            chkOre4.AutoSize = true;
            chkOre4.Location = new Point(273, 11);
            chkOre4.Name = "chkOre4";
            chkOre4.Size = new Size(15, 14);
            chkOre4.TabIndex = 6;
            chkOre4.UseVisualStyleBackColor = true;
            // 
            // lblOre4
            // 
            lblOre4.Location = new Point(292, 11);
            lblOre4.Name = "lblOre4";
            lblOre4.Size = new Size(63, 13);
            lblOre4.TabIndex = 7;
            lblOre4.Text = "Plagioclase";
            // 
            // lblOre18
            // 
            lblOre18.Location = new Point(116, 89);
            lblOre18.Name = "lblOre18";
            lblOre18.Size = new Size(63, 13);
            lblOre18.TabIndex = 35;
            lblOre18.Text = "Rakovene";
            // 
            // lblOre17
            // 
            lblOre17.Location = new Point(28, 89);
            lblOre17.Name = "lblOre17";
            lblOre17.Size = new Size(63, 13);
            lblOre17.TabIndex = 33;
            lblOre17.Text = "Talassonite";
            // 
            // lblOre19
            // 
            lblOre19.Location = new Point(204, 89);
            lblOre19.Name = "lblOre19";
            lblOre19.Size = new Size(63, 13);
            lblOre19.TabIndex = 37;
            lblOre19.Text = "Bezdnacine";
            // 
            // tabOreSkills
            // 
            tabOreSkills.Controls.Add(tabPageOres);
            tabOreSkills.Controls.Add(tabPageIce);
            tabOreSkills.Controls.Add(tabIgnoreList);
            tabOreSkills.Location = new Point(12, 198);
            tabOreSkills.Name = "tabOreSkills";
            tabOreSkills.SelectedIndex = 0;
            tabOreSkills.Size = new Size(391, 158);
            tabOreSkills.TabIndex = 0;
            // 
            // tabIgnoreList
            // 
            tabIgnoreList.Controls.Add(gbIgnoreIceProducts);
            tabIgnoreList.Controls.Add(gbIgnoreMinerals);
            tabIgnoreList.Location = new Point(4, 22);
            tabIgnoreList.Name = "tabIgnoreList";
            tabIgnoreList.Size = new Size(383, 132);
            tabIgnoreList.TabIndex = 2;
            tabIgnoreList.Text = "Ignore List";
            tabIgnoreList.UseVisualStyleBackColor = true;
            // 
            // gbIgnoreIceProducts
            // 
            gbIgnoreIceProducts.Controls.Add(chkIgnore12);
            gbIgnoreIceProducts.Controls.Add(chkIgnore10);
            gbIgnoreIceProducts.Controls.Add(chkIgnore14);
            gbIgnoreIceProducts.Controls.Add(lblIgnore10);
            gbIgnoreIceProducts.Controls.Add(lblIgnore14);
            gbIgnoreIceProducts.Controls.Add(lblIgnore12);
            gbIgnoreIceProducts.Controls.Add(chkIgnore15);
            gbIgnoreIceProducts.Controls.Add(chkIgnore11);
            gbIgnoreIceProducts.Controls.Add(chkIgnore9);
            gbIgnoreIceProducts.Controls.Add(chkIgnore13);
            gbIgnoreIceProducts.Controls.Add(lblIgnore9);
            gbIgnoreIceProducts.Controls.Add(lblIgnore13);
            gbIgnoreIceProducts.Controls.Add(lblIgnore15);
            gbIgnoreIceProducts.Controls.Add(lblIgnore11);
            gbIgnoreIceProducts.Location = new Point(162, 8);
            gbIgnoreIceProducts.Name = "gbIgnoreIceProducts";
            gbIgnoreIceProducts.Size = new Size(213, 96);
            gbIgnoreIceProducts.TabIndex = 1;
            gbIgnoreIceProducts.TabStop = false;
            gbIgnoreIceProducts.Text = "Ice Products";
            // 
            // chkIgnore12
            // 
            chkIgnore12.AutoSize = true;
            chkIgnore12.Location = new Point(119, 37);
            chkIgnore12.Name = "chkIgnore12";
            chkIgnore12.Size = new Size(15, 14);
            chkIgnore12.TabIndex = 6;
            chkIgnore12.UseVisualStyleBackColor = true;
            // 
            // chkIgnore10
            // 
            chkIgnore10.AutoSize = true;
            chkIgnore10.Location = new Point(119, 18);
            chkIgnore10.Name = "chkIgnore10";
            chkIgnore10.Size = new Size(15, 14);
            chkIgnore10.TabIndex = 2;
            chkIgnore10.UseVisualStyleBackColor = true;
            // 
            // chkIgnore14
            // 
            chkIgnore14.AutoSize = true;
            chkIgnore14.Location = new Point(119, 62);
            chkIgnore14.Name = "chkIgnore14";
            chkIgnore14.Size = new Size(15, 14);
            chkIgnore14.TabIndex = 10;
            chkIgnore14.UseVisualStyleBackColor = true;
            // 
            // lblIgnore10
            // 
            lblIgnore10.Location = new Point(133, 18);
            lblIgnore10.Name = "lblIgnore10";
            lblIgnore10.Size = new Size(96, 13);
            lblIgnore10.TabIndex = 3;
            lblIgnore10.Text = "Heavy Water";
            // 
            // lblIgnore14
            // 
            lblIgnore14.Location = new Point(133, 56);
            lblIgnore14.Name = "lblIgnore14";
            lblIgnore14.Size = new Size(96, 27);
            lblIgnore14.TabIndex = 11;
            lblIgnore14.Text = "Strontium Clathrates";
            // 
            // lblIgnore12
            // 
            lblIgnore12.Location = new Point(133, 37);
            lblIgnore12.Name = "lblIgnore12";
            lblIgnore12.Size = new Size(96, 13);
            lblIgnore12.TabIndex = 7;
            lblIgnore12.Text = "Liquid Ozone";
            // 
            // chkIgnore15
            // 
            chkIgnore15.AutoSize = true;
            chkIgnore15.Location = new Point(7, 74);
            chkIgnore15.Name = "chkIgnore15";
            chkIgnore15.Size = new Size(15, 14);
            chkIgnore15.TabIndex = 12;
            chkIgnore15.UseVisualStyleBackColor = true;
            // 
            // chkIgnore11
            // 
            chkIgnore11.AutoSize = true;
            chkIgnore11.Location = new Point(7, 37);
            chkIgnore11.Name = "chkIgnore11";
            chkIgnore11.Size = new Size(15, 14);
            chkIgnore11.TabIndex = 4;
            chkIgnore11.UseVisualStyleBackColor = true;
            // 
            // chkIgnore9
            // 
            chkIgnore9.AutoSize = true;
            chkIgnore9.Location = new Point(7, 18);
            chkIgnore9.Name = "chkIgnore9";
            chkIgnore9.Size = new Size(15, 14);
            chkIgnore9.TabIndex = 0;
            chkIgnore9.UseVisualStyleBackColor = true;
            // 
            // chkIgnore13
            // 
            chkIgnore13.AutoSize = true;
            chkIgnore13.Location = new Point(7, 55);
            chkIgnore13.Name = "chkIgnore13";
            chkIgnore13.Size = new Size(15, 14);
            chkIgnore13.TabIndex = 8;
            chkIgnore13.UseVisualStyleBackColor = true;
            // 
            // lblIgnore9
            // 
            lblIgnore9.Location = new Point(21, 18);
            lblIgnore9.Name = "lblIgnore9";
            lblIgnore9.Size = new Size(96, 13);
            lblIgnore9.TabIndex = 1;
            lblIgnore9.Text = "Helium Isotopes";
            // 
            // lblIgnore13
            // 
            lblIgnore13.Location = new Point(21, 56);
            lblIgnore13.Name = "lblIgnore13";
            lblIgnore13.Size = new Size(96, 13);
            lblIgnore13.TabIndex = 9;
            lblIgnore13.Text = "Nitrogen Isotopes";
            // 
            // lblIgnore15
            // 
            lblIgnore15.Location = new Point(21, 75);
            lblIgnore15.Name = "lblIgnore15";
            lblIgnore15.Size = new Size(96, 13);
            lblIgnore15.TabIndex = 13;
            lblIgnore15.Text = "Oxygen Isotopes";
            // 
            // lblIgnore11
            // 
            lblIgnore11.Location = new Point(21, 37);
            lblIgnore11.Name = "lblIgnore11";
            lblIgnore11.Size = new Size(96, 13);
            lblIgnore11.TabIndex = 5;
            lblIgnore11.Text = "Hydrogen Isotopes";
            // 
            // gbIgnoreMinerals
            // 
            gbIgnoreMinerals.Controls.Add(chkIgnore6);
            gbIgnoreMinerals.Controls.Add(chkIgnore4);
            gbIgnoreMinerals.Controls.Add(chkIgnore2);
            gbIgnoreMinerals.Controls.Add(lblIgnore1);
            gbIgnoreMinerals.Controls.Add(chkIgnore8);
            gbIgnoreMinerals.Controls.Add(lblIgnore5);
            gbIgnoreMinerals.Controls.Add(lblIgnore7);
            gbIgnoreMinerals.Controls.Add(chkIgnore7);
            gbIgnoreMinerals.Controls.Add(lblIgnore6);
            gbIgnoreMinerals.Controls.Add(lblIgnore8);
            gbIgnoreMinerals.Controls.Add(chkIgnore5);
            gbIgnoreMinerals.Controls.Add(lblIgnore3);
            gbIgnoreMinerals.Controls.Add(lblIgnore2);
            gbIgnoreMinerals.Controls.Add(lblIgnore4);
            gbIgnoreMinerals.Controls.Add(chkIgnore1);
            gbIgnoreMinerals.Controls.Add(chkIgnore3);
            gbIgnoreMinerals.Location = new Point(8, 8);
            gbIgnoreMinerals.Name = "gbIgnoreMinerals";
            gbIgnoreMinerals.Size = new Size(148, 96);
            gbIgnoreMinerals.TabIndex = 0;
            gbIgnoreMinerals.TabStop = false;
            gbIgnoreMinerals.Text = "Minerals";
            // 
            // chkIgnore6
            // 
            chkIgnore6.AutoSize = true;
            chkIgnore6.Location = new Point(72, 56);
            chkIgnore6.Name = "chkIgnore6";
            chkIgnore6.Size = new Size(15, 14);
            chkIgnore6.TabIndex = 10;
            chkIgnore6.UseVisualStyleBackColor = true;
            // 
            // chkIgnore4
            // 
            chkIgnore4.AutoSize = true;
            chkIgnore4.Location = new Point(72, 37);
            chkIgnore4.Name = "chkIgnore4";
            chkIgnore4.Size = new Size(15, 14);
            chkIgnore4.TabIndex = 6;
            chkIgnore4.UseVisualStyleBackColor = true;
            // 
            // chkIgnore2
            // 
            chkIgnore2.AutoSize = true;
            chkIgnore2.Location = new Point(72, 18);
            chkIgnore2.Name = "chkIgnore2";
            chkIgnore2.Size = new Size(15, 14);
            chkIgnore2.TabIndex = 2;
            chkIgnore2.UseVisualStyleBackColor = true;
            // 
            // lblIgnore1
            // 
            lblIgnore1.Location = new Point(21, 18);
            lblIgnore1.Name = "lblIgnore1";
            lblIgnore1.Size = new Size(55, 13);
            lblIgnore1.TabIndex = 1;
            lblIgnore1.Text = "Tritanium";
            // 
            // chkIgnore8
            // 
            chkIgnore8.AutoSize = true;
            chkIgnore8.Location = new Point(72, 75);
            chkIgnore8.Name = "chkIgnore8";
            chkIgnore8.Size = new Size(15, 14);
            chkIgnore8.TabIndex = 14;
            chkIgnore8.UseVisualStyleBackColor = true;
            // 
            // lblIgnore5
            // 
            lblIgnore5.Location = new Point(21, 56);
            lblIgnore5.Name = "lblIgnore5";
            lblIgnore5.Size = new Size(55, 13);
            lblIgnore5.TabIndex = 9;
            lblIgnore5.Text = "Mexallon";
            // 
            // lblIgnore7
            // 
            lblIgnore7.Location = new Point(21, 75);
            lblIgnore7.Name = "lblIgnore7";
            lblIgnore7.Size = new Size(55, 13);
            lblIgnore7.TabIndex = 13;
            lblIgnore7.Text = "Isogen";
            // 
            // chkIgnore7
            // 
            chkIgnore7.AutoSize = true;
            chkIgnore7.Location = new Point(7, 75);
            chkIgnore7.Name = "chkIgnore7";
            chkIgnore7.Size = new Size(15, 14);
            chkIgnore7.TabIndex = 12;
            chkIgnore7.UseVisualStyleBackColor = true;
            // 
            // lblIgnore6
            // 
            lblIgnore6.Location = new Point(86, 56);
            lblIgnore6.Name = "lblIgnore6";
            lblIgnore6.Size = new Size(55, 13);
            lblIgnore6.TabIndex = 11;
            lblIgnore6.Text = "Megacyte";
            // 
            // lblIgnore8
            // 
            lblIgnore8.Location = new Point(86, 75);
            lblIgnore8.Name = "lblIgnore8";
            lblIgnore8.Size = new Size(55, 13);
            lblIgnore8.TabIndex = 15;
            lblIgnore8.Text = "Morphite";
            // 
            // chkIgnore5
            // 
            chkIgnore5.AutoSize = true;
            chkIgnore5.Location = new Point(7, 56);
            chkIgnore5.Name = "chkIgnore5";
            chkIgnore5.Size = new Size(15, 14);
            chkIgnore5.TabIndex = 8;
            chkIgnore5.UseVisualStyleBackColor = true;
            // 
            // lblIgnore3
            // 
            lblIgnore3.Location = new Point(21, 37);
            lblIgnore3.Name = "lblIgnore3";
            lblIgnore3.Size = new Size(55, 13);
            lblIgnore3.TabIndex = 5;
            lblIgnore3.Text = "Pyerite";
            // 
            // lblIgnore2
            // 
            lblIgnore2.Location = new Point(86, 18);
            lblIgnore2.Name = "lblIgnore2";
            lblIgnore2.Size = new Size(55, 13);
            lblIgnore2.TabIndex = 3;
            lblIgnore2.Text = "Nocxium";
            // 
            // lblIgnore4
            // 
            lblIgnore4.Location = new Point(86, 37);
            lblIgnore4.Name = "lblIgnore4";
            lblIgnore4.Size = new Size(55, 13);
            lblIgnore4.TabIndex = 7;
            lblIgnore4.Text = "Zydrine";
            // 
            // chkIgnore1
            // 
            chkIgnore1.AutoSize = true;
            chkIgnore1.Location = new Point(7, 18);
            chkIgnore1.Name = "chkIgnore1";
            chkIgnore1.Size = new Size(15, 14);
            chkIgnore1.TabIndex = 0;
            chkIgnore1.UseVisualStyleBackColor = true;
            // 
            // chkIgnore3
            // 
            chkIgnore3.AutoSize = true;
            chkIgnore3.Location = new Point(7, 37);
            chkIgnore3.Name = "chkIgnore3";
            chkIgnore3.Size = new Size(15, 14);
            chkIgnore3.TabIndex = 4;
            chkIgnore3.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(159, 362);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(96, 30);
            btnSaveSettings.TabIndex = 8;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(266, 362);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(96, 30);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // frmConversiontoOreSettings
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 402);
            Controls.Add(btnReset);
            Controls.Add(btnSaveSettings);
            Controls.Add(tabOreSkills);
            Controls.Add(gbSystemSecurity);
            Controls.Add(gbMineOreLoc);
            Controls.Add(gbMinimizeOn);
            Controls.Add(gbConversionType);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConversiontoOreSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conversion to Ore Settings";
            gbConversionType.ResumeLayout(false);
            gbConversionType.PerformLayout();
            gbMinimizeOn.ResumeLayout(false);
            gbMinimizeOn.PerformLayout();
            gbSystemSecurity.ResumeLayout(false);
            gbSystemSecurity.PerformLayout();
            gbOreVariants.ResumeLayout(false);
            gbOreVariants.PerformLayout();
            gbMineOreLoc.ResumeLayout(false);
            gbMineOreLoc.PerformLayout();
            gbWHClasses.ResumeLayout(false);
            gbWHClasses.PerformLayout();
            tabPageIce.ResumeLayout(false);
            tabPageIce.PerformLayout();
            tabPageOres.ResumeLayout(false);
            tabPageOres.PerformLayout();
            tabOreSkills.ResumeLayout(false);
            tabIgnoreList.ResumeLayout(false);
            gbIgnoreIceProducts.ResumeLayout(false);
            gbIgnoreIceProducts.PerformLayout();
            gbIgnoreMinerals.ResumeLayout(false);
            gbIgnoreMinerals.PerformLayout();
            ResumeLayout(false);

        }
        internal Button btnClose;
        internal RadioButton rbtnConversionNone;
        internal GroupBox gbConversionType;
        internal CheckBox chkCompressedIce;
        internal CheckBox chkCompressedOre;
        internal RadioButton rbtnConversionOre;
        internal RadioButton rbtnConversionIce;
        internal RadioButton rbtnConversionOreIce;
        internal GroupBox gbMinimizeOn;
        internal GroupBox gbSystemSecurity;
        internal CheckBox chkHighSec;
        internal CheckBox chkNullSec;
        internal CheckBox chkLowSec;
        internal CheckBox chkUseBaseOre;
        internal GroupBox gbMineOreLoc;
        internal CheckBox chkTriglavian;
        internal CheckBox chkWH;
        internal GroupBox gbWHClasses;
        internal CheckBox chkC6;
        internal CheckBox chkC5;
        internal CheckBox chkC4;
        internal CheckBox chkC3;
        internal CheckBox chkC2;
        internal CheckBox chkC1;
        internal CheckBox chkCaldari;
        internal CheckBox chkMinmatar;
        internal CheckBox chkGallente;
        internal CheckBox chkAmarr;
        internal CheckBox chkUse5percent;
        internal CheckBox chkUse10percent;
        internal RadioButton rbtnOrePrice;
        internal RadioButton rbtnOreVolume;
        internal RadioButton rbtnRefinePrice;
        internal TabPage tabPageIce;
        internal TabPage tabPageOres;
        internal Label lblOre17;
        internal Label lblOre19;
        internal CheckBox chkOre17;
        internal CheckBox chkOre18;
        internal Label lblOre18;
        internal CheckBox chkOre19;
        internal Label lblOre1;
        internal CheckBox chkOre14;
        internal CheckBox chkOre15;
        internal CheckBox chkOre11;
        internal Label lblOre15;
        internal CheckBox chkOre7;
        internal CheckBox chkOre5;
        internal Label lblOre14;
        internal CheckBox chkOre16;
        internal CheckBox chkOre3;
        internal Label lblOre5;
        internal Label lblOre8;
        internal CheckBox chkOre13;
        internal CheckBox chkOre8;
        internal CheckBox chkOre12;
        internal Label lblOre11;
        internal Label lblOre3;
        internal Label lblOre7;
        internal CheckBox chkOre10;
        internal CheckBox chkOre1;
        internal CheckBox chkOre9;
        internal CheckBox chkOre6;
        internal Label lblOre9;
        internal Label lblOre10;
        internal Label lblOre12;
        internal Label lblOre13;
        internal Label lblOre16;
        internal CheckBox chkOre2;
        internal Label lblOre6;
        internal Label lblOre2;
        internal CheckBox chkOre4;
        internal Label lblOre4;
        internal TabControl tabOreSkills;
        internal Button btnSaveSettings;
        internal Label lblOre35;
        internal CheckBox chkOre35;
        internal Label lblOre32;
        internal CheckBox chkOre32;
        internal Label lblOre36;
        internal CheckBox chkOre36;
        internal Label lblOre30;
        internal CheckBox chkOre30;
        internal Label lblOre34;
        internal CheckBox chkOre34;
        internal Label lblOre31;
        internal CheckBox chkOre31;
        internal Label lblOre29;
        internal CheckBox chkOre29;
        internal Label lblOre26;
        internal CheckBox chkOre26;
        internal Label lblOre33;
        internal CheckBox chkOre33;
        internal Label lblOre27;
        internal CheckBox chkOre27;
        internal Label lblOre28;
        internal CheckBox chkOre28;
        internal Label lblOre25;
        internal CheckBox chkOre25;
        internal GroupBox gbOreVariants;
        internal TabPage tabIgnoreList;
        internal CheckBox chkIgnore8;
        internal CheckBox chkIgnore6;
        internal CheckBox chkIgnore7;
        internal CheckBox chkIgnore5;
        internal CheckBox chkIgnore4;
        internal CheckBox chkIgnore2;
        internal CheckBox chkIgnore3;
        internal CheckBox chkIgnore1;
        internal Label lblIgnore4;
        internal Label lblIgnore2;
        internal Label lblIgnore3;
        internal Label lblIgnore1;
        internal Label lblIgnore8;
        internal Label lblIgnore6;
        internal Label lblIgnore7;
        internal Label lblIgnore5;
        internal GroupBox gbIgnoreIceProducts;
        internal CheckBox chkIgnore12;
        internal CheckBox chkIgnore10;
        internal CheckBox chkIgnore14;
        internal Label lblIgnore10;
        internal Label lblIgnore14;
        internal Label lblIgnore12;
        internal CheckBox chkIgnore15;
        internal CheckBox chkIgnore11;
        internal CheckBox chkIgnore9;
        internal CheckBox chkIgnore13;
        internal Label lblIgnore9;
        internal Label lblIgnore13;
        internal Label lblIgnore15;
        internal Label lblIgnore11;
        internal GroupBox gbIgnoreMinerals;
        internal Button btnReset;
        internal CheckBox chkOre22;
        internal CheckBox chkOre23;
        internal Label lblOre23;
        internal Label lblOre22;
        internal CheckBox chkOre24;
        internal CheckBox chkOre21;
        internal Label lblOre21;
        internal Label lblOre24;
        internal CheckBox chkOre20;
        internal Label lblOre20;
    }
}