using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmShoppingList : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShoppingList));
            lblTotalCost = new Label();
            lblTC = new Label();
            lblTV = new Label();
            lblTotalVolume = new Label();
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnClear = new Button();
            btnClear.Click += new EventHandler(btnClear_Click);
            btnCopy = new Button();
            btnCopy.Click += new EventHandler(btnCopy_Click);
            DeleteBuildStrip = new ContextMenuStrip(components);
            DeleteBuildStrip.Opening += new System.ComponentModel.CancelEventHandler(DeleteBuildStrip_Opening);
            DeleteBuildItem = new ToolStripMenuItem();
            DeleteBuildItem.Click += new EventHandler(DeleteBuildStrip_Click);
            DeleteItemStrip = new ContextMenuStrip(components);
            DeleteItemStrip.Opening += new System.ComponentModel.CancelEventHandler(DeleteItemStrip_Opening);
            DeleteItem = new ToolStripMenuItem();
            DeleteItem.Click += new EventHandler(DeleteItemStrip_Click);
            lblTotalProfit1 = new Label();
            lblTotalProfit = new Label();
            lblAvgIPH = new Label();
            lblAvgIPH1 = new Label();
            lblTotalBuiltVolume = new Label();
            lblTotalBuiltVolume1 = new Label();
            ttMain = new ToolTip(components);
            btnUpdateListwithAssets = new Button();
            btnUpdateListwithAssets.Click += new EventHandler(btnUpdateListwithAssets_Click);
            btnMineThis = new Button();
            chkUpdateAssetsWhenUsed = new CheckBox();
            txtListEdit = new TextBox();
            txtListEdit.GotFocus += new EventHandler(txtListEdit_GotFocus);
            txtListEdit.KeyDown += new KeyEventHandler(txtListEdit_KeyDown);
            txtListEdit.KeyPress += new KeyPressEventHandler(txtListEdit_KeyPress);
            txtListEdit.LostFocus += new EventHandler(txtListEdit_LostFocus);
            DeleteMaterialStrip = new ContextMenuStrip(components);
            DeleteMaterialStrip.Opening += new System.ComponentModel.CancelEventHandler(DeleteMaterialStrip_Opening);
            DeleteMaterial = new ToolStripMenuItem();
            DeleteMaterial.Click += new EventHandler(DeleteMaterialStrip_Click);
            btnSaveListToFile = new Button();
            btnSaveListToFile.Click += new EventHandler(btnSaveListToFile_Click);
            btnLoadListFromFile = new Button();
            btnLoadListFromFile.Click += new EventHandler(btnLoadListFromFile_Click);
            gbOptions = new GroupBox();
            lblFeeRate = new Label();
            chkBuyorBuyOrder = new CheckBox();
            chkBuyorBuyOrder.Click += new EventHandler(chkBuyorBuyOrder_Click);
            txtBrokerFeeRate = new TextBox();
            txtBrokerFeeRate.KeyDown += new KeyEventHandler(txtBrokerFeeRate_KeyDown);
            txtBrokerFeeRate.KeyPress += new KeyPressEventHandler(txtBrokerFeeRate_KeyPress);
            txtBrokerFeeRate.GotFocus += new EventHandler(txtBrokerFeeRate_GotFocus);
            txtBrokerFeeRate.LostFocus += new EventHandler(txtBrokerFeeRate_LostFocus);
            chkAlwaysOnTop = new CheckBox();
            chkAlwaysOnTop.CheckedChanged += new EventHandler(chkAlwaysOnTop_CheckedChanged);
            lblUsage = new Label();
            chkUsage = new CheckBox();
            chkUsage.CheckedChanged += new EventHandler(chkUsage_CheckedChanged);
            lblFees = new Label();
            gbExportOptions = new GroupBox();
            rbtnExportMulitBuy = new RadioButton();
            rbtnExportSSV = new RadioButton();
            rbtnExportCSV = new RadioButton();
            rbtnExportDefault = new RadioButton();
            txtAddlCosts = new TextBox();
            txtAddlCosts.GotFocus += new EventHandler(txtAddlCosts_GotFocus);
            txtAddlCosts.KeyDown += new KeyEventHandler(txtAddlCosts_KeyDown);
            txtAddlCosts.KeyPress += new KeyPressEventHandler(txtAddlCosts_KeyPress);
            txtAddlCosts.LostFocus += new EventHandler(txtAddlCosts_LostFocus);
            chkFees = new CheckBox();
            chkFees.CheckedChanged += new EventHandler(chkFees_CheckedChanged);
            chkFees.Click += new EventHandler(chkFees_Click);
            lblAddlCosts = new Label();
            chkRebuildItemsfromList = new CheckBox();
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            SaveFileDialog = new SaveFileDialog();
            OpenFileDialog = new OpenFileDialog();
            lblItemstoBuy = new Label();
            lblItemstoBuild = new Label();
            lblComponentstoBuild = new Label();
            btnCopyPasteAssets = new Button();
            btnCopyPasteAssets.Click += new EventHandler(btnCopyPasteAssets_Click);
            btnShowAssets = new Button();
            btnShowAssets.Click += new EventHandler(btnShowAssets_Click);
            gbUpdateList = new GroupBox();
            lblTotalInventionCost = new Label();
            lblTotalCopyCost = new Label();
            lblTIC = new Label();
            lblTCC = new Label();
            lblTotalItemsInList = new Label();
            lstBuy = new MyListView();
            lstBuy.ColumnClick += new ColumnClickEventHandler(lstBuy_ColumnClick);
            lstBuy.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lstBuy_ColumnWidthChanging);
            lstBuy.KeyDown += new KeyEventHandler(lstBuy_KeyDown);
            lstBuy.MouseClick += new MouseEventHandler(lstBuy_MouseClick);
            lstBuy.ProcMsg += new MyListView.ProcMsgEventHandler(lstBuy_ProcMsg);
            lstItems = new MyListView();
            lstItems.ColumnClick += new ColumnClickEventHandler(lstItems_ColumnClick);
            lstItems.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lstItems_ColumnWidthChanging);
            lstItems.DoubleClick += new EventHandler(lstItems_DoubleClick);
            lstItems.KeyDown += new KeyEventHandler(lstItems_KeyDown);
            lstItems.MouseClick += new MouseEventHandler(lstItems_MouseClick);
            lstItems.ProcMsg += new MyListView.ProcMsgEventHandler(lstItems_ProcMsg);
            lstBuild = new MyListView();
            lstBuild.ColumnClick += new ColumnClickEventHandler(lstBuild_ColumnClick);
            lstBuild.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lstBuild_ColumnWidthChanging);
            lstBuild.DoubleClick += new EventHandler(lstBuild_DoubleClick);
            lstBuild.KeyDown += new KeyEventHandler(lstBuild_KeyDown);
            lstBuild.MouseClick += new MouseEventHandler(lstBuild_MouseClick);
            lstBuild.ProcMsg += new MyListView.ProcMsgEventHandler(lstBuild_ProcMsg);
            DeleteBuildStrip.SuspendLayout();
            DeleteItemStrip.SuspendLayout();
            DeleteMaterialStrip.SuspendLayout();
            gbOptions.SuspendLayout();
            gbExportOptions.SuspendLayout();
            gbUpdateList.SuspendLayout();
            SuspendLayout();
            // 
            // lblTotalCost
            // 
            lblTotalCost.BorderStyle = BorderStyle.Fixed3D;
            lblTotalCost.Location = new Point(925, 547);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(163, 16);
            lblTotalCost.TabIndex = 23;
            lblTotalCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTC
            // 
            lblTC.AutoSize = true;
            lblTC.Location = new Point(866, 549);
            lblTC.Name = "lblTC";
            lblTC.Size = new Size(58, 13);
            lblTC.TabIndex = 22;
            lblTC.Text = "Total Cost:";
            lblTC.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTV
            // 
            lblTV.AutoSize = true;
            lblTV.Location = new Point(852, 606);
            lblTV.Name = "lblTV";
            lblTV.Size = new Size(72, 13);
            lblTV.TabIndex = 28;
            lblTV.Text = "Total Volume:";
            lblTV.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalVolume
            // 
            lblTotalVolume.BorderStyle = BorderStyle.Fixed3D;
            lblTotalVolume.Location = new Point(925, 604);
            lblTotalVolume.Name = "lblTotalVolume";
            lblTotalVolume.Size = new Size(163, 16);
            lblTotalVolume.TabIndex = 29;
            lblTotalVolume.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(107, 645);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 32);
            btnClose.TabIndex = 7;
            btnClose.Text = "Exit";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(7, 645);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 32);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear List";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(7, 543);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(94, 32);
            btnCopy.TabIndex = 0;
            btnCopy.Text = "Copy List";
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // DeleteBuildStrip
            // 
            DeleteBuildStrip.Items.AddRange(new ToolStripItem[] { DeleteBuildItem });
            DeleteBuildStrip.Name = "ContextMenuStrip1";
            DeleteBuildStrip.Size = new Size(165, 26);
            // 
            // DeleteBuildItem
            // 
            DeleteBuildItem.Name = "DeleteBuildItem";
            DeleteBuildItem.Size = new Size(164, 22);
            DeleteBuildItem.Text = "Delete Build Item";
            // 
            // DeleteItemStrip
            // 
            DeleteItemStrip.Items.AddRange(new ToolStripItem[] { DeleteItem });
            DeleteItemStrip.Name = "ContextMenuStrip1";
            DeleteItemStrip.Size = new Size(135, 26);
            // 
            // DeleteItem
            // 
            DeleteItem.Name = "DeleteItem";
            DeleteItem.Size = new Size(134, 22);
            DeleteItem.Text = "Delete Item";
            // 
            // lblTotalProfit1
            // 
            lblTotalProfit1.AutoSize = true;
            lblTotalProfit1.Location = new Point(824, 663);
            lblTotalProfit1.Name = "lblTotalProfit1";
            lblTotalProfit1.Size = new Size(100, 13);
            lblTotalProfit1.TabIndex = 34;
            lblTotalProfit1.Text = "Approx. Total Profit:";
            lblTotalProfit1.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalProfit
            // 
            lblTotalProfit.BorderStyle = BorderStyle.Fixed3D;
            lblTotalProfit.Location = new Point(925, 661);
            lblTotalProfit.Name = "lblTotalProfit";
            lblTotalProfit.Size = new Size(163, 16);
            lblTotalProfit.TabIndex = 35;
            lblTotalProfit.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAvgIPH
            // 
            lblAvgIPH.BorderStyle = BorderStyle.Fixed3D;
            lblAvgIPH.Location = new Point(925, 642);
            lblAvgIPH.Name = "lblAvgIPH";
            lblAvgIPH.Size = new Size(163, 16);
            lblAvgIPH.TabIndex = 33;
            lblAvgIPH.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAvgIPH1
            // 
            lblAvgIPH1.AutoSize = true;
            lblAvgIPH1.Location = new Point(832, 644);
            lblAvgIPH1.Name = "lblAvgIPH1";
            lblAvgIPH1.Size = new Size(92, 13);
            lblAvgIPH1.TabIndex = 32;
            lblAvgIPH1.Text = "Approx. Avg. IPH:";
            lblAvgIPH1.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalBuiltVolume
            // 
            lblTotalBuiltVolume.BorderStyle = BorderStyle.Fixed3D;
            lblTotalBuiltVolume.Location = new Point(925, 623);
            lblTotalBuiltVolume.Name = "lblTotalBuiltVolume";
            lblTotalBuiltVolume.Size = new Size(163, 16);
            lblTotalBuiltVolume.TabIndex = 31;
            lblTotalBuiltVolume.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBuiltVolume1
            // 
            lblTotalBuiltVolume1.AutoSize = true;
            lblTotalBuiltVolume1.Location = new Point(795, 625);
            lblTotalBuiltVolume1.Name = "lblTotalBuiltVolume1";
            lblTotalBuiltVolume1.Size = new Size(129, 13);
            lblTotalBuiltVolume1.TabIndex = 30;
            lblTotalBuiltVolume1.Text = "Total Built Item(s) Volume:";
            lblTotalBuiltVolume1.TextAlign = ContentAlignment.TopRight;
            // 
            // ttMain
            // 
            ttMain.IsBalloon = true;
            // 
            // btnUpdateListwithAssets
            // 
            btnUpdateListwithAssets.Location = new Point(8, 15);
            btnUpdateListwithAssets.Name = "btnUpdateListwithAssets";
            btnUpdateListwithAssets.Size = new Size(116, 48);
            btnUpdateListwithAssets.TabIndex = 19;
            btnUpdateListwithAssets.Text = "Update with Selected Assets";
            btnUpdateListwithAssets.UseVisualStyleBackColor = true;
            // 
            // btnMineThis
            // 
            btnMineThis.ForeColor = Color.Red;
            btnMineThis.Location = new Point(107, 577);
            btnMineThis.Name = "btnMineThis";
            btnMineThis.Size = new Size(94, 32);
            btnMineThis.TabIndex = 1;
            btnMineThis.Text = "Mine This!";
            btnMineThis.UseVisualStyleBackColor = true;
            btnMineThis.Visible = false;
            // 
            // chkUpdateAssetsWhenUsed
            // 
            chkUpdateAssetsWhenUsed.AutoSize = true;
            chkUpdateAssetsWhenUsed.Checked = true;
            chkUpdateAssetsWhenUsed.CheckState = CheckState.Checked;
            chkUpdateAssetsWhenUsed.Location = new Point(6, 99);
            chkUpdateAssetsWhenUsed.Name = "chkUpdateAssetsWhenUsed";
            chkUpdateAssetsWhenUsed.Size = new Size(155, 17);
            chkUpdateAssetsWhenUsed.TabIndex = 10;
            chkUpdateAssetsWhenUsed.Text = "Update Assets When Used";
            chkUpdateAssetsWhenUsed.UseVisualStyleBackColor = true;
            // 
            // txtListEdit
            // 
            txtListEdit.Location = new Point(792, 295);
            txtListEdit.Name = "txtListEdit";
            txtListEdit.Size = new Size(48, 20);
            txtListEdit.TabIndex = 40;
            txtListEdit.TabStop = false;
            txtListEdit.Visible = false;
            // 
            // DeleteMaterialStrip
            // 
            DeleteMaterialStrip.Items.AddRange(new ToolStripItem[] { DeleteMaterial });
            DeleteMaterialStrip.Name = "ContextMenuStrip1";
            DeleteMaterialStrip.Size = new Size(154, 26);
            // 
            // DeleteMaterial
            // 
            DeleteMaterial.Name = "DeleteMaterial";
            DeleteMaterial.Size = new Size(153, 22);
            DeleteMaterial.Text = "Delete Material";
            // 
            // btnSaveListToFile
            // 
            btnSaveListToFile.ForeColor = SystemColors.ControlText;
            btnSaveListToFile.Location = new Point(7, 577);
            btnSaveListToFile.Name = "btnSaveListToFile";
            btnSaveListToFile.Size = new Size(94, 32);
            btnSaveListToFile.TabIndex = 2;
            btnSaveListToFile.Text = "Save List";
            btnSaveListToFile.UseVisualStyleBackColor = true;
            // 
            // btnLoadListFromFile
            // 
            btnLoadListFromFile.ForeColor = SystemColors.ControlText;
            btnLoadListFromFile.Location = new Point(7, 611);
            btnLoadListFromFile.Name = "btnLoadListFromFile";
            btnLoadListFromFile.Size = new Size(94, 32);
            btnLoadListFromFile.TabIndex = 4;
            btnLoadListFromFile.Text = "Load List";
            btnLoadListFromFile.UseVisualStyleBackColor = true;
            // 
            // gbOptions
            // 
            gbOptions.Controls.Add(lblFeeRate);
            gbOptions.Controls.Add(chkBuyorBuyOrder);
            gbOptions.Controls.Add(txtBrokerFeeRate);
            gbOptions.Controls.Add(chkAlwaysOnTop);
            gbOptions.Controls.Add(lblUsage);
            gbOptions.Controls.Add(chkUsage);
            gbOptions.Controls.Add(lblFees);
            gbOptions.Controls.Add(gbExportOptions);
            gbOptions.Controls.Add(txtAddlCosts);
            gbOptions.Controls.Add(chkFees);
            gbOptions.Controls.Add(chkUpdateAssetsWhenUsed);
            gbOptions.Controls.Add(lblAddlCosts);
            gbOptions.Location = new Point(214, 538);
            gbOptions.Name = "gbOptions";
            gbOptions.Size = new Size(321, 141);
            gbOptions.TabIndex = 8;
            gbOptions.TabStop = false;
            gbOptions.Text = "Options:";
            // 
            // lblFeeRate
            // 
            lblFeeRate.AutoSize = true;
            lblFeeRate.Location = new Point(189, 17);
            lblFeeRate.Name = "lblFeeRate";
            lblFeeRate.Size = new Size(54, 13);
            lblFeeRate.TabIndex = 80;
            lblFeeRate.Text = "Fee Rate:";
            lblFeeRate.TextAlign = ContentAlignment.TopRight;
            // 
            // chkBuyorBuyOrder
            // 
            chkBuyorBuyOrder.AutoSize = true;
            chkBuyorBuyOrder.Checked = true;
            chkBuyorBuyOrder.CheckState = CheckState.Checked;
            chkBuyorBuyOrder.Location = new Point(6, 35);
            chkBuyorBuyOrder.Name = "chkBuyorBuyOrder";
            chkBuyorBuyOrder.Size = new Size(185, 17);
            chkBuyorBuyOrder.TabIndex = 13;
            chkBuyorBuyOrder.Text = "Calculate Buy Order / Buy Market";
            chkBuyorBuyOrder.ThreeState = true;
            chkBuyorBuyOrder.UseVisualStyleBackColor = true;
            // 
            // txtBrokerFeeRate
            // 
            txtBrokerFeeRate.Location = new Point(249, 13);
            txtBrokerFeeRate.Name = "txtBrokerFeeRate";
            txtBrokerFeeRate.Size = new Size(48, 20);
            txtBrokerFeeRate.TabIndex = 79;
            txtBrokerFeeRate.TabStop = false;
            txtBrokerFeeRate.Visible = false;
            // 
            // chkAlwaysOnTop
            // 
            chkAlwaysOnTop.AutoSize = true;
            chkAlwaysOnTop.Location = new Point(6, 117);
            chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            chkAlwaysOnTop.Size = new Size(96, 17);
            chkAlwaysOnTop.TabIndex = 9;
            chkAlwaysOnTop.Text = "Always on Top";
            chkAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // lblUsage
            // 
            lblUsage.BorderStyle = BorderStyle.FixedSingle;
            lblUsage.Location = new Point(63, 55);
            lblUsage.Name = "lblUsage";
            lblUsage.Size = new Size(112, 17);
            lblUsage.TabIndex = 15;
            lblUsage.Text = "0.00";
            lblUsage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkUsage
            // 
            chkUsage.AutoSize = true;
            chkUsage.Checked = true;
            chkUsage.CheckState = CheckState.Checked;
            chkUsage.Location = new Point(6, 55);
            chkUsage.Name = "chkUsage";
            chkUsage.Size = new Size(60, 17);
            chkUsage.TabIndex = 14;
            chkUsage.Text = "Usage:";
            chkUsage.UseVisualStyleBackColor = true;
            // 
            // lblFees
            // 
            lblFees.BorderStyle = BorderStyle.FixedSingle;
            lblFees.Location = new Point(62, 15);
            lblFees.Name = "lblFees";
            lblFees.Size = new Size(113, 17);
            lblFees.TabIndex = 12;
            lblFees.Text = "0.00";
            lblFees.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbExportOptions
            // 
            gbExportOptions.Controls.Add(rbtnExportMulitBuy);
            gbExportOptions.Controls.Add(rbtnExportSSV);
            gbExportOptions.Controls.Add(rbtnExportCSV);
            gbExportOptions.Controls.Add(rbtnExportDefault);
            gbExportOptions.Location = new Point(192, 50);
            gbExportOptions.Name = "gbExportOptions";
            gbExportOptions.Size = new Size(123, 86);
            gbExportOptions.TabIndex = 74;
            gbExportOptions.TabStop = false;
            gbExportOptions.Text = "Export Data in:";
            // 
            // rbtnExportMulitBuy
            // 
            rbtnExportMulitBuy.AutoSize = true;
            rbtnExportMulitBuy.Location = new Point(8, 15);
            rbtnExportMulitBuy.Name = "rbtnExportMulitBuy";
            rbtnExportMulitBuy.Size = new Size(114, 17);
            rbtnExportMulitBuy.TabIndex = 3;
            rbtnExportMulitBuy.TabStop = true;
            rbtnExportMulitBuy.Text = "Multi-Buy (Buy List)";
            rbtnExportMulitBuy.UseVisualStyleBackColor = true;
            // 
            // rbtnExportSSV
            // 
            rbtnExportSSV.AutoSize = true;
            rbtnExportSSV.Location = new Point(8, 66);
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
            rbtnExportCSV.Location = new Point(8, 49);
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
            rbtnExportDefault.Location = new Point(8, 32);
            rbtnExportDefault.Name = "rbtnExportDefault";
            rbtnExportDefault.Size = new Size(59, 17);
            rbtnExportDefault.TabIndex = 0;
            rbtnExportDefault.TabStop = true;
            rbtnExportDefault.Text = "Default";
            rbtnExportDefault.UseVisualStyleBackColor = true;
            // 
            // txtAddlCosts
            // 
            txtAddlCosts.Location = new Point(63, 75);
            txtAddlCosts.MaxLength = 15;
            txtAddlCosts.Name = "txtAddlCosts";
            txtAddlCosts.Size = new Size(112, 20);
            txtAddlCosts.TabIndex = 17;
            txtAddlCosts.Text = "0.00";
            txtAddlCosts.TextAlign = HorizontalAlignment.Right;
            // 
            // chkFees
            // 
            chkFees.AutoSize = true;
            chkFees.Checked = true;
            chkFees.CheckState = CheckState.Checked;
            chkFees.Location = new Point(6, 15);
            chkFees.Name = "chkFees";
            chkFees.Size = new Size(52, 17);
            chkFees.TabIndex = 11;
            chkFees.Text = "Fees:";
            chkFees.ThreeState = true;
            chkFees.UseVisualStyleBackColor = true;
            // 
            // lblAddlCosts
            // 
            lblAddlCosts.AutoSize = true;
            lblAddlCosts.Location = new Point(4, 79);
            lblAddlCosts.Name = "lblAddlCosts";
            lblAddlCosts.Size = new Size(62, 13);
            lblAddlCosts.TabIndex = 16;
            lblAddlCosts.Text = "Add'l Costs:";
            // 
            // chkRebuildItemsfromList
            // 
            chkRebuildItemsfromList.AutoSize = true;
            chkRebuildItemsfromList.Location = new Point(546, 641);
            chkRebuildItemsfromList.Name = "chkRebuildItemsfromList";
            chkRebuildItemsfromList.Size = new Size(179, 17);
            chkRebuildItemsfromList.TabIndex = 79;
            chkRebuildItemsfromList.Text = "Rebuild Items when Loading List";
            chkRebuildItemsfromList.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.ForeColor = SystemColors.ControlText;
            btnSaveSettings.Location = new Point(107, 611);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(94, 32);
            btnSaveSettings.TabIndex = 5;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "OpenFileDialog1";
            // 
            // lblItemstoBuy
            // 
            lblItemstoBuy.Location = new Point(7, 4);
            lblItemstoBuy.Name = "lblItemstoBuy";
            lblItemstoBuy.Size = new Size(1081, 13);
            lblItemstoBuy.TabIndex = 71;
            lblItemstoBuy.Text = "Items to Buy";
            lblItemstoBuy.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblItemstoBuild
            // 
            lblItemstoBuild.Location = new Point(6, 322);
            lblItemstoBuild.Name = "lblItemstoBuild";
            lblItemstoBuild.Size = new Size(708, 14);
            lblItemstoBuild.TabIndex = 72;
            lblItemstoBuild.Text = "Items to Build";
            lblItemstoBuild.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblComponentstoBuild
            // 
            lblComponentstoBuild.Location = new Point(720, 323);
            lblComponentstoBuild.Name = "lblComponentstoBuild";
            lblComponentstoBuild.Size = new Size(368, 14);
            lblComponentstoBuild.TabIndex = 73;
            lblComponentstoBuild.Text = "Components to Build";
            lblComponentstoBuild.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCopyPasteAssets
            // 
            btnCopyPasteAssets.Location = new Point(8, 65);
            btnCopyPasteAssets.Name = "btnCopyPasteAssets";
            btnCopyPasteAssets.Size = new Size(168, 28);
            btnCopyPasteAssets.TabIndex = 21;
            btnCopyPasteAssets.Text = "Copy and Paste Assets";
            btnCopyPasteAssets.UseVisualStyleBackColor = true;
            // 
            // btnShowAssets
            // 
            btnShowAssets.Image = (Image)resources.GetObject("btnShowAssets.Image");
            btnShowAssets.Location = new Point(128, 15);
            btnShowAssets.Name = "btnShowAssets";
            btnShowAssets.Size = new Size(48, 48);
            btnShowAssets.TabIndex = 20;
            btnShowAssets.UseVisualStyleBackColor = true;
            // 
            // gbUpdateList
            // 
            gbUpdateList.Controls.Add(btnCopyPasteAssets);
            gbUpdateList.Controls.Add(btnUpdateListwithAssets);
            gbUpdateList.Controls.Add(btnShowAssets);
            gbUpdateList.Location = new Point(541, 538);
            gbUpdateList.Name = "gbUpdateList";
            gbUpdateList.Size = new Size(184, 99);
            gbUpdateList.TabIndex = 18;
            gbUpdateList.TabStop = false;
            gbUpdateList.Text = "Update List Options:";
            // 
            // lblTotalInventionCost
            // 
            lblTotalInventionCost.BorderStyle = BorderStyle.Fixed3D;
            lblTotalInventionCost.Location = new Point(925, 566);
            lblTotalInventionCost.Name = "lblTotalInventionCost";
            lblTotalInventionCost.Size = new Size(163, 16);
            lblTotalInventionCost.TabIndex = 25;
            lblTotalInventionCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalCopyCost
            // 
            lblTotalCopyCost.BorderStyle = BorderStyle.Fixed3D;
            lblTotalCopyCost.Location = new Point(925, 585);
            lblTotalCopyCost.Name = "lblTotalCopyCost";
            lblTotalCopyCost.Size = new Size(163, 16);
            lblTotalCopyCost.TabIndex = 27;
            lblTotalCopyCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTIC
            // 
            lblTIC.AutoSize = true;
            lblTIC.Location = new Point(819, 568);
            lblTIC.Name = "lblTIC";
            lblTIC.Size = new Size(105, 13);
            lblTIC.TabIndex = 75;
            lblTIC.Text = "Total Invention Cost:";
            lblTIC.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTCC
            // 
            lblTCC.AutoSize = true;
            lblTCC.Location = new Point(839, 587);
            lblTCC.Name = "lblTCC";
            lblTCC.Size = new Size(85, 13);
            lblTCC.TabIndex = 76;
            lblTCC.Text = "Total Copy Cost:";
            lblTCC.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalItemsInList
            // 
            lblTotalItemsInList.BorderStyle = BorderStyle.FixedSingle;
            lblTotalItemsInList.Location = new Point(107, 543);
            lblTotalItemsInList.Name = "lblTotalItemsInList";
            lblTotalItemsInList.Size = new Size(94, 32);
            lblTotalItemsInList.TabIndex = 77;
            lblTotalItemsInList.Text = "9,999 Items to Build";
            lblTotalItemsInList.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstBuy
            // 
            lstBuy.ContextMenuStrip = DeleteMaterialStrip;
            lstBuy.FullRowSelect = true;
            lstBuy.GridLines = true;
            lstBuy.HideSelection = false;
            lstBuy.Location = new Point(7, 20);
            lstBuy.Name = "lstBuy";
            lstBuy.Size = new Size(1081, 300);
            lstBuy.TabIndex = 37;
            lstBuy.TabStop = false;
            lstBuy.UseCompatibleStateImageBehavior = false;
            lstBuy.View = View.Details;
            // 
            // lstItems
            // 
            lstItems.ContextMenuStrip = DeleteItemStrip;
            lstItems.FullRowSelect = true;
            lstItems.HideSelection = false;
            lstItems.Location = new Point(6, 339);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(711, 198);
            lstItems.TabIndex = 38;
            lstItems.TabStop = false;
            lstItems.UseCompatibleStateImageBehavior = false;
            lstItems.View = View.Details;
            // 
            // lstBuild
            // 
            lstBuild.ContextMenuStrip = DeleteBuildStrip;
            lstBuild.FullRowSelect = true;
            lstBuild.HideSelection = false;
            lstBuild.Location = new Point(720, 339);
            lstBuild.Name = "lstBuild";
            lstBuild.Size = new Size(368, 198);
            lstBuild.TabIndex = 39;
            lstBuild.TabStop = false;
            lstBuild.Tag = "20";
            lstBuild.UseCompatibleStateImageBehavior = false;
            lstBuild.View = View.Details;
            // 
            // frmShoppingList
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(1094, 682);
            Controls.Add(chkRebuildItemsfromList);
            Controls.Add(lblTotalItemsInList);
            Controls.Add(lblTCC);
            Controls.Add(lblTIC);
            Controls.Add(lblTotalCopyCost);
            Controls.Add(lblTotalInventionCost);
            Controls.Add(gbUpdateList);
            Controls.Add(txtListEdit);
            Controls.Add(lblItemstoBuild);
            Controls.Add(lblItemstoBuy);
            Controls.Add(lstBuy);
            Controls.Add(lblTV);
            Controls.Add(lblTotalCost);
            Controls.Add(gbOptions);
            Controls.Add(lblTotalVolume);
            Controls.Add(lblTotalBuiltVolume);
            Controls.Add(lblComponentstoBuild);
            Controls.Add(lblTotalBuiltVolume1);
            Controls.Add(lblAvgIPH);
            Controls.Add(lstItems);
            Controls.Add(btnSaveSettings);
            Controls.Add(btnClose);
            Controls.Add(lblTC);
            Controls.Add(lblTotalProfit);
            Controls.Add(btnMineThis);
            Controls.Add(lblTotalProfit1);
            Controls.Add(lblAvgIPH1);
            Controls.Add(btnClear);
            Controls.Add(btnCopy);
            Controls.Add(btnLoadListFromFile);
            Controls.Add(btnSaveListToFile);
            Controls.Add(lstBuild);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmShoppingList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shopping List";
            DeleteBuildStrip.ResumeLayout(false);
            DeleteItemStrip.ResumeLayout(false);
            DeleteMaterialStrip.ResumeLayout(false);
            gbOptions.ResumeLayout(false);
            gbOptions.PerformLayout();
            gbExportOptions.ResumeLayout(false);
            gbExportOptions.PerformLayout();
            gbUpdateList.ResumeLayout(false);
            Shown += new EventHandler(frmShoppingList_Shown);
            FormClosing += new FormClosingEventHandler(frmShoppingList_FormClosing);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Label lblTotalCost;
        internal Label lblTC;
        internal Label lblTV;
        internal Label lblTotalVolume;
        internal Button btnClose;
        internal Button btnClear;
        internal Button btnCopy;
        internal Label lblTotalProfit1;
        internal Label lblTotalProfit;
        internal Label lblAvgIPH;
        internal Label lblAvgIPH1;
        internal Label lblTotalBuiltVolume;
        internal Label lblTotalBuiltVolume1;
        internal Button btnShowAssets;
        internal ToolTip ttMain;
        internal Button btnUpdateListwithAssets;
        internal Button btnMineThis;
        internal CheckBox chkUpdateAssetsWhenUsed;
        internal TextBox txtListEdit;
        internal ContextMenuStrip DeleteItemStrip;
        internal ToolStripMenuItem DeleteItem;
        internal ContextMenuStrip DeleteMaterialStrip;
        internal ToolStripMenuItem DeleteMaterial;
        internal Button btnSaveListToFile;
        internal Button btnLoadListFromFile;
        internal GroupBox gbOptions;
        internal CheckBox chkFees;
        internal Label lblFees;
        internal Button btnSaveSettings;
        internal ContextMenuStrip DeleteBuildStrip;
        internal ToolStripMenuItem DeleteBuildItem;
        internal SaveFileDialog SaveFileDialog;
        internal OpenFileDialog OpenFileDialog;
        internal TextBox txtAddlCosts;
        internal MyListView lstBuy;
        internal MyListView lstItems;
        internal MyListView lstBuild;
        internal Label lblItemstoBuy;
        internal Label lblItemstoBuild;
        internal Label lblComponentstoBuild;
        internal Label lblAddlCosts;
        internal Label lblUsage;
        internal CheckBox chkUsage;
        internal CheckBox chkAlwaysOnTop;
        internal Button btnCopyPasteAssets;
        internal CheckBox chkBuyorBuyOrder;
        internal GroupBox gbUpdateList;
        internal Label lblTotalInventionCost;
        internal Label lblTotalCopyCost;
        internal GroupBox gbExportOptions;
        internal RadioButton rbtnExportSSV;
        internal RadioButton rbtnExportCSV;
        internal RadioButton rbtnExportDefault;
        internal Label lblTIC;
        internal Label lblTCC;
        internal Label lblTotalItemsInList;
        internal CheckBox chkRebuildItemsfromList;
        internal RadioButton rbtnExportMulitBuy;
        internal TextBox txtBrokerFeeRate;
        internal Label lblFeeRate;
    }
}