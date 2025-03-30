using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmReprocessingPlant : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReprocessingPlant));
            btnReprocess = new Button();
            btnReprocess.Click += new EventHandler(btnReprocess_Click);
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnShowAssets = new Button();
            btnShowAssets.Click += new EventHandler(btnShowAssets_Click);
            btnCopyPasteAssets = new Button();
            btnCopyPasteAssets.Click += new EventHandler(btnCopyPasteAssets_Click);
            btnSelectAssets = new Button();
            btnSelectAssets.Click += new EventHandler(btnSelectAssets_Click);
            cmbReprocessing = new ComboBox();
            cmbReprocessing.SelectedIndexChanged += new EventHandler(cmbRefining_SelectedIndexChanged);
            lblRefining = new Label();
            cmbReprocessingEff = new ComboBox();
            cmbReprocessingEff.SelectedIndexChanged += new EventHandler(cmbRefineryEff_SelectedIndexChanged);
            lblRefineryEfficiency = new Label();
            gbRefineYields = new GroupBox();
            lblScrapRate = new Label();
            lblIceRate = new Label();
            lblIce = new Label();
            lblScrap = new Label();
            lblOreRate = new Label();
            lblMoonRate = new Label();
            lblOre = new Label();
            lblMoonOre = new Label();
            cmbScrapMetalProcessing = new ComboBox();
            lblScrapMetalProcessing = new Label();
            lblReprocessingOutput = new Label();
            lblItemList = new Label();
            lblItemSelect = new Label();
            GroupBox1 = new GroupBox();
            tabRefinery = new TabControl();
            tabpMain = new TabPage();
            chkRecursiveRefine = new CheckBox();
            chkRecursiveRefine.CheckedChanged += new EventHandler(chkRecursiveRefine_CheckedChanged);
            btnClear = new Button();
            btnClear.Click += new EventHandler(btnClear_Click);
            btnCopyOutput = new Button();
            btnCopyOutput.Click += new EventHandler(btnCopyOutput_Click);
            Label1 = new Label();
            cmbBeanCounterRefining = new ComboBox();
            tabpSkills = new TabPage();
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
            btnClear2 = new Button();
            btnClear2.Click += new EventHandler(btnClear2_Click);
            btnCopyOutput2 = new Button();
            btnCopyOutput2.Click += new EventHandler(btnCopyOutput2_Click);
            btnReprocess2 = new Button();
            btnReprocess2.Click += new EventHandler(btnReprocess2_Click);
            btnClose2 = new Button();
            btnClose2.Click += new EventHandler(btnClose2_Click);
            chkToggle = new CheckBox();
            chkToggle.CheckedChanged += new EventHandler(chkToggle_CheckedChanged);
            lblTotalItemList = new Label();
            lblReprocessingVolumeTotal = new Label();
            lblReprocessingTotalRate = new Label();
            lblReprocessingTotal = new Label();
            lblListTotalValueOutput = new Label();
            lblReturnRatePercentOutput = new Label();
            lblReprocessingValueOutput = new Label();
            lblReprocessingVolumeOutput = new Label();
            ReprocessingFacility = new ManufacturingFacility();
            lstItemstoRefine = new MyListView();
            lstItemstoRefine.ColumnClick += new ColumnClickEventHandler(lstItemstoRefine_ColumnClick);
            lstItemstoRefine.ItemChecked += new ItemCheckedEventHandler(lstItemstoRefine_ItemChecked);
            lstRefineOutput = new MyListView();
            lstRefineOutput.ColumnClick += new ColumnClickEventHandler(lstRefineOutput_ColumnClick);
            gbRefineYields.SuspendLayout();
            GroupBox1.SuspendLayout();
            tabRefinery.SuspendLayout();
            tabpMain.SuspendLayout();
            tabpSkills.SuspendLayout();
            tabMiningProcessingSkills.SuspendLayout();
            tabPageOres.SuspendLayout();
            tabPageMoonOres.SuspendLayout();
            tabPageIce.SuspendLayout();
            SuspendLayout();
            // 
            // btnReprocess
            // 
            btnReprocess.Location = new Point(259, 128);
            btnReprocess.Name = "btnReprocess";
            btnReprocess.Size = new Size(74, 30);
            btnReprocess.TabIndex = 36;
            btnReprocess.Text = "Reprocess";
            btnReprocess.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.ForeColor = SystemColors.ControlText;
            btnClose.Location = new Point(481, 128);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(74, 30);
            btnClose.TabIndex = 38;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnShowAssets
            // 
            btnShowAssets.Image = (Image)resources.GetObject("btnShowAssets.Image");
            btnShowAssets.Location = new Point(373, 25);
            btnShowAssets.Name = "btnShowAssets";
            btnShowAssets.Size = new Size(48, 48);
            btnShowAssets.TabIndex = 44;
            btnShowAssets.UseVisualStyleBackColor = true;
            // 
            // btnCopyPasteAssets
            // 
            btnCopyPasteAssets.Location = new Point(315, 76);
            btnCopyPasteAssets.Name = "btnCopyPasteAssets";
            btnCopyPasteAssets.Size = new Size(106, 35);
            btnCopyPasteAssets.TabIndex = 46;
            btnCopyPasteAssets.Text = "Copy and Paste";
            btnCopyPasteAssets.UseVisualStyleBackColor = true;
            // 
            // btnSelectAssets
            // 
            btnSelectAssets.Location = new Point(315, 25);
            btnSelectAssets.Name = "btnSelectAssets";
            btnSelectAssets.Size = new Size(52, 48);
            btnSelectAssets.TabIndex = 45;
            btnSelectAssets.Text = "Select from Assets";
            btnSelectAssets.UseVisualStyleBackColor = true;
            // 
            // cmbReprocessing
            // 
            cmbReprocessing.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReprocessing.FormattingEnabled = true;
            cmbReprocessing.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbReprocessing.Location = new Point(95, 14);
            cmbReprocessing.Name = "cmbReprocessing";
            cmbReprocessing.Size = new Size(30, 21);
            cmbReprocessing.TabIndex = 110;
            // 
            // lblRefining
            // 
            lblRefining.AutoSize = true;
            lblRefining.Location = new Point(14, 18);
            lblRefining.Name = "lblRefining";
            lblRefining.Size = new Size(75, 13);
            lblRefining.TabIndex = 112;
            lblRefining.Text = "Reprocessing:";
            // 
            // cmbReprocessingEff
            // 
            cmbReprocessingEff.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReprocessingEff.FormattingEnabled = true;
            cmbReprocessingEff.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbReprocessingEff.Location = new Point(95, 46);
            cmbReprocessingEff.Name = "cmbReprocessingEff";
            cmbReprocessingEff.Size = new Size(30, 21);
            cmbReprocessingEff.TabIndex = 111;
            // 
            // lblRefineryEfficiency
            // 
            lblRefineryEfficiency.Location = new Point(6, 41);
            lblRefineryEfficiency.Name = "lblRefineryEfficiency";
            lblRefineryEfficiency.Size = new Size(80, 26);
            lblRefineryEfficiency.TabIndex = 113;
            lblRefineryEfficiency.Text = "Reprocessing  Efficiency:";
            lblRefineryEfficiency.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbRefineYields
            // 
            gbRefineYields.Controls.Add(lblScrapRate);
            gbRefineYields.Controls.Add(lblIceRate);
            gbRefineYields.Controls.Add(lblIce);
            gbRefineYields.Controls.Add(lblScrap);
            gbRefineYields.Controls.Add(lblOreRate);
            gbRefineYields.Controls.Add(lblMoonRate);
            gbRefineYields.Controls.Add(lblOre);
            gbRefineYields.Controls.Add(lblMoonOre);
            gbRefineYields.Location = new Point(434, 10);
            gbRefineYields.Name = "gbRefineYields";
            gbRefineYields.Size = new Size(121, 101);
            gbRefineYields.TabIndex = 122;
            gbRefineYields.TabStop = false;
            gbRefineYields.Text = "Facility Refine Yields:";
            // 
            // lblScrapRate
            // 
            lblScrapRate.BorderStyle = BorderStyle.FixedSingle;
            lblScrapRate.Location = new Point(53, 76);
            lblScrapRate.Name = "lblScrapRate";
            lblScrapRate.Size = new Size(50, 18);
            lblScrapRate.TabIndex = 141;
            lblScrapRate.Text = "100.00%";
            lblScrapRate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIceRate
            // 
            lblIceRate.BorderStyle = BorderStyle.FixedSingle;
            lblIceRate.Location = new Point(53, 38);
            lblIceRate.Name = "lblIceRate";
            lblIceRate.Size = new Size(50, 18);
            lblIceRate.TabIndex = 140;
            lblIceRate.Text = "100.00%";
            lblIceRate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIce
            // 
            lblIce.AutoSize = true;
            lblIce.Location = new Point(22, 41);
            lblIce.Name = "lblIce";
            lblIce.Size = new Size(25, 13);
            lblIce.TabIndex = 139;
            lblIce.Text = "Ice:";
            // 
            // lblScrap
            // 
            lblScrap.AutoSize = true;
            lblScrap.Location = new Point(9, 79);
            lblScrap.Name = "lblScrap";
            lblScrap.Size = new Size(38, 13);
            lblScrap.TabIndex = 138;
            lblScrap.Text = "Scrap:";
            // 
            // lblOreRate
            // 
            lblOreRate.BorderStyle = BorderStyle.FixedSingle;
            lblOreRate.Location = new Point(53, 18);
            lblOreRate.Name = "lblOreRate";
            lblOreRate.Size = new Size(50, 18);
            lblOreRate.TabIndex = 136;
            lblOreRate.Text = "100.00%";
            lblOreRate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMoonRate
            // 
            lblMoonRate.BorderStyle = BorderStyle.FixedSingle;
            lblMoonRate.Location = new Point(53, 57);
            lblMoonRate.Name = "lblMoonRate";
            lblMoonRate.Size = new Size(50, 18);
            lblMoonRate.TabIndex = 137;
            lblMoonRate.Text = "100.00%";
            lblMoonRate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOre
            // 
            lblOre.AutoSize = true;
            lblOre.Location = new Point(20, 21);
            lblOre.Name = "lblOre";
            lblOre.Size = new Size(27, 13);
            lblOre.TabIndex = 123;
            lblOre.Text = "Ore:";
            // 
            // lblMoonOre
            // 
            lblMoonOre.AutoSize = true;
            lblMoonOre.Location = new Point(10, 60);
            lblMoonOre.Name = "lblMoonOre";
            lblMoonOre.Size = new Size(37, 13);
            lblMoonOre.TabIndex = 125;
            lblMoonOre.Text = "Moon:";
            // 
            // cmbScrapMetalProcessing
            // 
            cmbScrapMetalProcessing.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbScrapMetalProcessing.FormattingEnabled = true;
            cmbScrapMetalProcessing.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            cmbScrapMetalProcessing.Location = new Point(95, 79);
            cmbScrapMetalProcessing.Name = "cmbScrapMetalProcessing";
            cmbScrapMetalProcessing.Size = new Size(30, 21);
            cmbScrapMetalProcessing.TabIndex = 124;
            // 
            // lblScrapMetalProcessing
            // 
            lblScrapMetalProcessing.Location = new Point(6, 74);
            lblScrapMetalProcessing.Name = "lblScrapMetalProcessing";
            lblScrapMetalProcessing.Size = new Size(80, 26);
            lblScrapMetalProcessing.TabIndex = 125;
            lblScrapMetalProcessing.Text = "Scrapmetal  Processing:";
            lblScrapMetalProcessing.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblReprocessingOutput
            // 
            lblReprocessingOutput.AutoSize = true;
            lblReprocessingOutput.Location = new Point(239, 416);
            lblReprocessingOutput.Name = "lblReprocessingOutput";
            lblReprocessingOutput.Size = new Size(107, 13);
            lblReprocessingOutput.TabIndex = 126;
            lblReprocessingOutput.Text = "Reprocessing Output";
            lblReprocessingOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblItemList
            // 
            lblItemList.AutoSize = true;
            lblItemList.Location = new Point(269, 222);
            lblItemList.Name = "lblItemList";
            lblItemList.Size = new Size(46, 13);
            lblItemList.TabIndex = 127;
            lblItemList.Text = "Item List";
            lblItemList.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblItemSelect
            // 
            lblItemSelect.AutoSize = true;
            lblItemSelect.Location = new Point(319, 10);
            lblItemSelect.Name = "lblItemSelect";
            lblItemSelect.Size = new Size(102, 13);
            lblItemSelect.TabIndex = 128;
            lblItemSelect.Text = "Select Refine Items:";
            lblItemSelect.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(cmbReprocessingEff);
            GroupBox1.Controls.Add(lblRefineryEfficiency);
            GroupBox1.Controls.Add(cmbScrapMetalProcessing);
            GroupBox1.Controls.Add(lblRefining);
            GroupBox1.Controls.Add(lblScrapMetalProcessing);
            GroupBox1.Controls.Add(cmbReprocessing);
            GroupBox1.Location = new Point(6, -2);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(143, 114);
            GroupBox1.TabIndex = 129;
            GroupBox1.TabStop = false;
            // 
            // tabRefinery
            // 
            tabRefinery.Controls.Add(tabpMain);
            tabRefinery.Controls.Add(tabpSkills);
            tabRefinery.Location = new Point(7, 7);
            tabRefinery.Name = "tabRefinery";
            tabRefinery.SelectedIndex = 0;
            tabRefinery.Size = new Size(570, 205);
            tabRefinery.TabIndex = 130;
            // 
            // tabpMain
            // 
            tabpMain.Controls.Add(chkRecursiveRefine);
            tabpMain.Controls.Add(btnClear);
            tabpMain.Controls.Add(btnCopyOutput);
            tabpMain.Controls.Add(Label1);
            tabpMain.Controls.Add(cmbBeanCounterRefining);
            tabpMain.Controls.Add(ReprocessingFacility);
            tabpMain.Controls.Add(lblItemSelect);
            tabpMain.Controls.Add(btnCopyPasteAssets);
            tabpMain.Controls.Add(btnShowAssets);
            tabpMain.Controls.Add(btnReprocess);
            tabpMain.Controls.Add(btnSelectAssets);
            tabpMain.Controls.Add(btnClose);
            tabpMain.Controls.Add(gbRefineYields);
            tabpMain.Location = new Point(4, 22);
            tabpMain.Name = "tabpMain";
            tabpMain.Padding = new Padding(3);
            tabpMain.Size = new Size(562, 179);
            tabpMain.TabIndex = 0;
            tabpMain.Text = "Main";
            tabpMain.UseVisualStyleBackColor = true;
            // 
            // chkRecursiveRefine
            // 
            chkRecursiveRefine.AutoSize = true;
            chkRecursiveRefine.Location = new Point(62, 157);
            chkRecursiveRefine.Name = "chkRecursiveRefine";
            chkRecursiveRefine.Size = new Size(128, 17);
            chkRecursiveRefine.TabIndex = 132;
            chkRecursiveRefine.Text = "Drill Down Reprocess";
            chkRecursiveRefine.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(333, 128);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(74, 30);
            btnClear.TabIndex = 133;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCopyOutput
            // 
            btnCopyOutput.Location = new Point(407, 128);
            btnCopyOutput.Name = "btnCopyOutput";
            btnCopyOutput.Size = new Size(74, 30);
            btnCopyOutput.TabIndex = 132;
            btnCopyOutput.Text = "Copy Output";
            btnCopyOutput.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(6, 114);
            Label1.Name = "Label1";
            Label1.Size = new Size(176, 13);
            Label1.TabIndex = 131;
            Label1.Text = "Reprocessing Beancounter Implant:";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbBeanCounterRefining
            // 
            cmbBeanCounterRefining.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBeanCounterRefining.FormattingEnabled = true;
            cmbBeanCounterRefining.Items.AddRange(new object[] { "None", "Zainou 'Beancounter' Reprocessing RX-801", "Zainou 'Beancounter' Reprocessing RX-802", "Zainou 'Beancounter' Reprocessing RX-804" });
            cmbBeanCounterRefining.Location = new Point(9, 130);
            cmbBeanCounterRefining.Name = "cmbBeanCounterRefining";
            cmbBeanCounterRefining.Size = new Size(235, 21);
            cmbBeanCounterRefining.TabIndex = 130;
            // 
            // tabpSkills
            // 
            tabpSkills.Controls.Add(tabMiningProcessingSkills);
            tabpSkills.Controls.Add(btnClear2);
            tabpSkills.Controls.Add(btnCopyOutput2);
            tabpSkills.Controls.Add(btnReprocess2);
            tabpSkills.Controls.Add(btnClose2);
            tabpSkills.Controls.Add(GroupBox1);
            tabpSkills.Location = new Point(4, 22);
            tabpSkills.Name = "tabpSkills";
            tabpSkills.Padding = new Padding(3);
            tabpSkills.Size = new Size(562, 179);
            tabpSkills.TabIndex = 1;
            tabpSkills.Text = "Skills";
            tabpSkills.UseVisualStyleBackColor = true;
            // 
            // tabMiningProcessingSkills
            // 
            tabMiningProcessingSkills.Controls.Add(tabPageOres);
            tabMiningProcessingSkills.Controls.Add(tabPageMoonOres);
            tabMiningProcessingSkills.Controls.Add(tabPageIce);
            tabMiningProcessingSkills.Location = new Point(157, 4);
            tabMiningProcessingSkills.Name = "tabMiningProcessingSkills";
            tabMiningProcessingSkills.SelectedIndex = 0;
            tabMiningProcessingSkills.Size = new Size(318, 170);
            tabMiningProcessingSkills.TabIndex = 138;
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
            // btnClear2
            // 
            btnClear2.Location = new Point(77, 113);
            btnClear2.Name = "btnClear2";
            btnClear2.Size = new Size(74, 30);
            btnClear2.TabIndex = 137;
            btnClear2.Text = "Clear";
            btnClear2.UseVisualStyleBackColor = true;
            // 
            // btnCopyOutput2
            // 
            btnCopyOutput2.Location = new Point(4, 143);
            btnCopyOutput2.Name = "btnCopyOutput2";
            btnCopyOutput2.Size = new Size(74, 30);
            btnCopyOutput2.TabIndex = 136;
            btnCopyOutput2.Text = "Copy Output";
            btnCopyOutput2.UseVisualStyleBackColor = true;
            // 
            // btnReprocess2
            // 
            btnReprocess2.Location = new Point(4, 113);
            btnReprocess2.Name = "btnReprocess2";
            btnReprocess2.Size = new Size(74, 30);
            btnReprocess2.TabIndex = 134;
            btnReprocess2.Text = "Reprocess";
            btnReprocess2.UseVisualStyleBackColor = true;
            // 
            // btnClose2
            // 
            btnClose2.ForeColor = SystemColors.ControlText;
            btnClose2.Location = new Point(77, 143);
            btnClose2.Name = "btnClose2";
            btnClose2.Size = new Size(74, 30);
            btnClose2.TabIndex = 135;
            btnClose2.Text = "Close";
            btnClose2.UseVisualStyleBackColor = true;
            // 
            // chkToggle
            // 
            chkToggle.AutoSize = true;
            chkToggle.BackColor = Color.Transparent;
            chkToggle.Location = new Point(444, 221);
            chkToggle.Name = "chkToggle";
            chkToggle.Size = new Size(99, 17);
            chkToggle.TabIndex = 255;
            chkToggle.Text = "Check All Items";
            chkToggle.UseVisualStyleBackColor = false;
            // 
            // lblTotalItemList
            // 
            lblTotalItemList.AutoSize = true;
            lblTotalItemList.Location = new Point(27, 615);
            lblTotalItemList.Name = "lblTotalItemList";
            lblTotalItemList.Size = new Size(106, 13);
            lblTotalItemList.TabIndex = 256;
            lblTotalItemList.Text = "Item List Total Value:";
            lblTotalItemList.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblReprocessingVolumeTotal
            // 
            lblReprocessingVolumeTotal.AutoSize = true;
            lblReprocessingVolumeTotal.Location = new Point(279, 637);
            lblReprocessingVolumeTotal.Name = "lblReprocessingVolumeTotal";
            lblReprocessingVolumeTotal.Size = new Size(148, 13);
            lblReprocessingVolumeTotal.TabIndex = 257;
            lblReprocessingVolumeTotal.Text = "Reprocessing Output Volume:";
            lblReprocessingVolumeTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReprocessingTotalRate
            // 
            lblReprocessingTotalRate.AutoSize = true;
            lblReprocessingTotalRate.Location = new Point(25, 637);
            lblReprocessingTotalRate.Name = "lblReprocessingTotalRate";
            lblReprocessingTotalRate.Size = new Size(108, 13);
            lblReprocessingTotalRate.TabIndex = 258;
            lblReprocessingTotalRate.Text = "Return Rate Percent:";
            lblReprocessingTotalRate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblReprocessingTotal
            // 
            lblReprocessingTotal.AutoSize = true;
            lblReprocessingTotal.Location = new Point(287, 615);
            lblReprocessingTotal.Name = "lblReprocessingTotal";
            lblReprocessingTotal.Size = new Size(140, 13);
            lblReprocessingTotal.TabIndex = 259;
            lblReprocessingTotal.Text = "Reprocessing Output Value:";
            lblReprocessingTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblListTotalValueOutput
            // 
            lblListTotalValueOutput.BorderStyle = BorderStyle.FixedSingle;
            lblListTotalValueOutput.Location = new Point(139, 612);
            lblListTotalValueOutput.Name = "lblListTotalValueOutput";
            lblListTotalValueOutput.Size = new Size(127, 18);
            lblListTotalValueOutput.TabIndex = 260;
            lblListTotalValueOutput.Text = "-";
            lblListTotalValueOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReturnRatePercentOutput
            // 
            lblReturnRatePercentOutput.BorderStyle = BorderStyle.FixedSingle;
            lblReturnRatePercentOutput.Location = new Point(139, 634);
            lblReturnRatePercentOutput.Name = "lblReturnRatePercentOutput";
            lblReturnRatePercentOutput.Size = new Size(127, 18);
            lblReturnRatePercentOutput.TabIndex = 261;
            lblReturnRatePercentOutput.Text = "-";
            lblReturnRatePercentOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReprocessingValueOutput
            // 
            lblReprocessingValueOutput.BorderStyle = BorderStyle.FixedSingle;
            lblReprocessingValueOutput.Location = new Point(433, 612);
            lblReprocessingValueOutput.Name = "lblReprocessingValueOutput";
            lblReprocessingValueOutput.Size = new Size(127, 18);
            lblReprocessingValueOutput.TabIndex = 262;
            lblReprocessingValueOutput.Text = "-";
            lblReprocessingValueOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReprocessingVolumeOutput
            // 
            lblReprocessingVolumeOutput.BorderStyle = BorderStyle.FixedSingle;
            lblReprocessingVolumeOutput.Location = new Point(433, 634);
            lblReprocessingVolumeOutput.Name = "lblReprocessingVolumeOutput";
            lblReprocessingVolumeOutput.Size = new Size(127, 18);
            lblReprocessingVolumeOutput.TabIndex = 263;
            lblReprocessingVolumeOutput.Text = "-";
            lblReprocessingVolumeOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReprocessingFacility
            // 
            ReprocessingFacility.BackColor = Color.Transparent;
            ReprocessingFacility.Location = new Point(6, 6);
            ReprocessingFacility.Name = "ReprocessingFacility";
            ReprocessingFacility.Size = new Size(303, 105);
            ReprocessingFacility.TabIndex = 43;
            // 
            // lstItemstoRefine
            // 
            lstItemstoRefine.CheckBoxes = true;
            lstItemstoRefine.FullRowSelect = true;
            lstItemstoRefine.GridLines = true;
            lstItemstoRefine.HideSelection = false;
            lstItemstoRefine.Location = new Point(7, 239);
            lstItemstoRefine.MultiSelect = false;
            lstItemstoRefine.Name = "lstItemstoRefine";
            lstItemstoRefine.Size = new Size(570, 165);
            lstItemstoRefine.TabIndex = 42;
            lstItemstoRefine.TabStop = false;
            lstItemstoRefine.UseCompatibleStateImageBehavior = false;
            lstItemstoRefine.View = View.Details;
            // 
            // lstRefineOutput
            // 
            lstRefineOutput.FullRowSelect = true;
            lstRefineOutput.GridLines = true;
            lstRefineOutput.HideSelection = false;
            lstRefineOutput.Location = new Point(7, 433);
            lstRefineOutput.MultiSelect = false;
            lstRefineOutput.Name = "lstRefineOutput";
            lstRefineOutput.Size = new Size(570, 165);
            lstRefineOutput.TabIndex = 41;
            lstRefineOutput.TabStop = false;
            lstRefineOutput.UseCompatibleStateImageBehavior = false;
            lstRefineOutput.View = View.Details;
            // 
            // frmReprocessingPlant
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(584, 661);
            Controls.Add(lblReprocessingVolumeOutput);
            Controls.Add(lblReprocessingValueOutput);
            Controls.Add(lblReturnRatePercentOutput);
            Controls.Add(lblListTotalValueOutput);
            Controls.Add(lblReprocessingVolumeTotal);
            Controls.Add(lblReprocessingTotal);
            Controls.Add(lblReprocessingTotalRate);
            Controls.Add(chkToggle);
            Controls.Add(tabRefinery);
            Controls.Add(lblTotalItemList);
            Controls.Add(lblItemList);
            Controls.Add(lblReprocessingOutput);
            Controls.Add(lstItemstoRefine);
            Controls.Add(lstRefineOutput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReprocessingPlant";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reprocessing Plant";
            gbRefineYields.ResumeLayout(false);
            gbRefineYields.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            tabRefinery.ResumeLayout(false);
            tabpMain.ResumeLayout(false);
            tabpMain.PerformLayout();
            tabpSkills.ResumeLayout(false);
            tabMiningProcessingSkills.ResumeLayout(false);
            tabPageOres.ResumeLayout(false);
            tabPageOres.PerformLayout();
            tabPageMoonOres.ResumeLayout(false);
            tabPageMoonOres.PerformLayout();
            tabPageIce.ResumeLayout(false);
            tabPageIce.PerformLayout();
            Disposed += new EventHandler(frmReprocessingPlant_Disposed);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button btnReprocess;
        internal Button btnClose;
        internal MyListView lstRefineOutput;
        internal MyListView lstItemstoRefine;
        internal ManufacturingFacility ReprocessingFacility;
        internal Button btnShowAssets;
        internal Button btnCopyPasteAssets;
        internal Button btnSelectAssets;
        internal ComboBox cmbReprocessing;
        internal Label lblRefining;
        internal ComboBox cmbReprocessingEff;
        internal Label lblRefineryEfficiency;
        internal GroupBox gbRefineYields;
        internal Label lblIce;
        internal Label lblScrap;
        internal Label lblOreRate;
        internal Label lblMoonRate;
        internal Label lblOre;
        internal Label lblMoonOre;
        internal ComboBox cmbScrapMetalProcessing;
        internal Label lblScrapMetalProcessing;
        internal Label lblReprocessingOutput;
        internal Label lblItemList;
        internal Label lblScrapRate;
        internal Label lblIceRate;
        internal Label lblItemSelect;
        internal GroupBox GroupBox1;
        internal TabControl tabRefinery;
        internal TabPage tabpMain;
        internal TabPage tabpSkills;
        internal Label Label1;
        internal ComboBox cmbBeanCounterRefining;
        internal Button btnCopyOutput;
        internal CheckBox chkRecursiveRefine;
        internal CheckBox chkToggle;
        internal Label lblTotalItemList;
        internal Label lblReprocessingVolumeTotal;
        internal Label lblReprocessingTotalRate;
        internal Label lblReprocessingTotal;
        internal Label lblListTotalValueOutput;
        internal Label lblReturnRatePercentOutput;
        internal Label lblReprocessingValueOutput;
        internal Label lblReprocessingVolumeOutput;
        internal Button btnClear;
        internal Button btnClear2;
        internal Button btnCopyOutput2;
        internal Button btnReprocess2;
        internal Button btnClose2;
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
    }
}