using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMarketHistoryViewer : Form
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
            var ChartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            var Title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            var Title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarketHistoryViewer));
            chrtMarketHistory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chkVolume = new CheckBox();
            chkVolume.CheckedChanged += new EventHandler(chkVolume_CheckedChanged);
            chk5DayAverage = new CheckBox();
            chk5DayAverage.CheckedChanged += new EventHandler(chk5DayAverage_CheckedChanged);
            chk20DayAverage = new CheckBox();
            chk20DayAverage.CheckedChanged += new EventHandler(chk20DayAverage_CheckedChanged);
            chkMinMax = new CheckBox();
            chkMinMax.CheckedChanged += new EventHandler(chkMinMax_CheckedChanged);
            chkDonchianChannel = new CheckBox();
            chkDonchianChannel.CheckedChanged += new EventHandler(CheckBox2_CheckedChanged);
            gbDateSelect = new GroupBox();
            btnRefresh = new Button();
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            lblAvgPrice = new Label();
            cmbAvgPriceDuration = new ComboBox();
            cmbAvgPriceDuration.KeyPress += new KeyPressEventHandler(cmbAvgPriceDuration_KeyPress);
            rbtnByDays = new RadioButton();
            rbtnByDays.CheckedChanged += new EventHandler(rbtnByDays_CheckedChanged);
            rbtnByDate = new RadioButton();
            rbtnByDate.CheckedChanged += new EventHandler(rbtnByDate_CheckedChanged);
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            dtpStartDate.ValueChanged += new EventHandler(dtpStartDate_ValueChanged);
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            dtpEndDate.ValueChanged += new EventHandler(dtpEndDate_ValueChanged);
            gbDataOptions = new GroupBox();
            chkLinearAverage = new CheckBox();
            chkLinearAverage.CheckedChanged += new EventHandler(chkLinearAverage_CheckedChanged);
            gbTrendOptions = new GroupBox();
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            ((System.ComponentModel.ISupportInitialize)chrtMarketHistory).BeginInit();
            gbDateSelect.SuspendLayout();
            gbDataOptions.SuspendLayout();
            gbTrendOptions.SuspendLayout();
            SuspendLayout();
            // 
            // chrtMarketHistory
            // 
            chrtMarketHistory.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            ChartArea1.Name = "Main";
            chrtMarketHistory.ChartAreas.Add(ChartArea1);
            chrtMarketHistory.Location = new Point(12, 12);
            chrtMarketHistory.Name = "chrtMarketHistory";
            chrtMarketHistory.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            chrtMarketHistory.Size = new Size(860, 504);
            chrtMarketHistory.TabIndex = 0;
            Title1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Title1.Name = "RegionName";
            Title1.Text = "Name Here";
            Title2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title2.Name = "ItemName";
            Title2.Position.Auto = false;
            Title2.Position.Height = 5.271496f;
            Title2.Position.Width = 94.0f;
            Title2.Position.X = 3.0f;
            Title2.Position.Y = 8.0f;
            Title2.Text = "Name Here";
            chrtMarketHistory.Titles.Add(Title1);
            chrtMarketHistory.Titles.Add(Title2);
            // 
            // chkVolume
            // 
            chkVolume.AutoSize = true;
            chkVolume.Location = new Point(6, 36);
            chkVolume.Name = "chkVolume";
            chkVolume.Size = new Size(61, 17);
            chkVolume.TabIndex = 1;
            chkVolume.Text = "Volume";
            chkVolume.UseVisualStyleBackColor = true;
            // 
            // chk5DayAverage
            // 
            chk5DayAverage.AutoSize = true;
            chk5DayAverage.Location = new Point(6, 36);
            chk5DayAverage.Name = "chk5DayAverage";
            chk5DayAverage.Size = new Size(135, 17);
            chk5DayAverage.TabIndex = 2;
            chk5DayAverage.Text = "5 Day Moving Average";
            chk5DayAverage.UseVisualStyleBackColor = true;
            // 
            // chk20DayAverage
            // 
            chk20DayAverage.AutoSize = true;
            chk20DayAverage.Location = new Point(6, 54);
            chk20DayAverage.Name = "chk20DayAverage";
            chk20DayAverage.Size = new Size(141, 17);
            chk20DayAverage.TabIndex = 3;
            chk20DayAverage.Text = "20 Day Moving Average";
            chk20DayAverage.UseVisualStyleBackColor = true;
            // 
            // chkMinMax
            // 
            chkMinMax.AutoSize = true;
            chkMinMax.Location = new Point(6, 18);
            chkMinMax.Name = "chkMinMax";
            chkMinMax.Size = new Size(163, 17);
            chkMinMax.TabIndex = 5;
            chkMinMax.Text = "Minimum / Maxium Day Price";
            chkMinMax.UseVisualStyleBackColor = true;
            // 
            // chkDonchianChannel
            // 
            chkDonchianChannel.AutoSize = true;
            chkDonchianChannel.Location = new Point(67, 18);
            chkDonchianChannel.Name = "chkDonchianChannel";
            chkDonchianChannel.Size = new Size(114, 17);
            chkDonchianChannel.TabIndex = 7;
            chkDonchianChannel.Text = "Donchian Channel";
            chkDonchianChannel.UseVisualStyleBackColor = true;
            // 
            // gbDateSelect
            // 
            gbDateSelect.Controls.Add(btnRefresh);
            gbDateSelect.Controls.Add(lblAvgPrice);
            gbDateSelect.Controls.Add(cmbAvgPriceDuration);
            gbDateSelect.Controls.Add(rbtnByDays);
            gbDateSelect.Controls.Add(rbtnByDate);
            gbDateSelect.Controls.Add(lblStartDate);
            gbDateSelect.Controls.Add(dtpStartDate);
            gbDateSelect.Controls.Add(lblEndDate);
            gbDateSelect.Controls.Add(dtpEndDate);
            gbDateSelect.Location = new Point(12, 522);
            gbDateSelect.Name = "gbDateSelect";
            gbDateSelect.Size = new Size(368, 77);
            gbDateSelect.TabIndex = 68;
            gbDateSelect.TabStop = false;
            gbDateSelect.Text = "Select Date Range:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(277, 50);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(74, 21);
            btnRefresh.TabIndex = 73;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblAvgPrice
            // 
            lblAvgPrice.AutoSize = true;
            lblAvgPrice.Location = new Point(274, 11);
            lblAvgPrice.Name = "lblAvgPrice";
            lblAvgPrice.Size = new Size(77, 13);
            lblAvgPrice.TabIndex = 15;
            lblAvgPrice.Text = "Average Days:";
            lblAvgPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbAvgPriceDuration
            // 
            cmbAvgPriceDuration.FormattingEnabled = true;
            cmbAvgPriceDuration.Items.AddRange(new object[] { "7", "15", "30", "60", "90", "180", "365" });
            cmbAvgPriceDuration.Location = new Point(277, 27);
            cmbAvgPriceDuration.MaxLength = 3;
            cmbAvgPriceDuration.Name = "cmbAvgPriceDuration";
            cmbAvgPriceDuration.Size = new Size(74, 21);
            cmbAvgPriceDuration.TabIndex = 16;
            // 
            // rbtnByDays
            // 
            rbtnByDays.AutoSize = true;
            rbtnByDays.Location = new Point(14, 22);
            rbtnByDays.Name = "rbtnByDays";
            rbtnByDays.Size = new Size(64, 17);
            rbtnByDays.TabIndex = 14;
            rbtnByDays.TabStop = true;
            rbtnByDays.Text = "By Days";
            rbtnByDays.UseVisualStyleBackColor = true;
            // 
            // rbtnByDate
            // 
            rbtnByDate.AutoSize = true;
            rbtnByDate.Location = new Point(14, 45);
            rbtnByDate.Name = "rbtnByDate";
            rbtnByDate.Size = new Size(63, 17);
            rbtnByDate.TabIndex = 13;
            rbtnByDate.TabStop = true;
            rbtnByDate.Text = "By Date";
            rbtnByDate.UseVisualStyleBackColor = true;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(94, 24);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(58, 13);
            lblStartDate.TabIndex = 11;
            lblStartDate.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(158, 20);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(99, 20);
            dtpStartDate.TabIndex = 9;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(94, 48);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(55, 13);
            lblEndDate.TabIndex = 12;
            lblEndDate.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(158, 44);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(99, 20);
            dtpEndDate.TabIndex = 10;
            dtpEndDate.Value = new DateTime(2014, 1, 29, 21, 10, 0, 0);
            // 
            // gbDataOptions
            // 
            gbDataOptions.Controls.Add(chkMinMax);
            gbDataOptions.Controls.Add(chkVolume);
            gbDataOptions.Location = new Point(386, 522);
            gbDataOptions.Name = "gbDataOptions";
            gbDataOptions.Size = new Size(178, 77);
            gbDataOptions.TabIndex = 69;
            gbDataOptions.TabStop = false;
            gbDataOptions.Text = "Show Data:";
            // 
            // chkLinearAverage
            // 
            chkLinearAverage.AutoSize = true;
            chkLinearAverage.Location = new Point(6, 18);
            chkLinearAverage.Name = "chkLinearAverage";
            chkLinearAverage.Size = new Size(55, 17);
            chkLinearAverage.TabIndex = 4;
            chkLinearAverage.Text = "Linear";
            chkLinearAverage.UseVisualStyleBackColor = true;
            // 
            // gbTrendOptions
            // 
            gbTrendOptions.Controls.Add(chkLinearAverage);
            gbTrendOptions.Controls.Add(chkDonchianChannel);
            gbTrendOptions.Controls.Add(chk20DayAverage);
            gbTrendOptions.Controls.Add(chk5DayAverage);
            gbTrendOptions.Location = new Point(570, 522);
            gbTrendOptions.Name = "gbTrendOptions";
            gbTrendOptions.Size = new Size(184, 77);
            gbTrendOptions.TabIndex = 70;
            gbTrendOptions.TabStop = false;
            gbTrendOptions.Text = "Trendlines:";
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(760, 527);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(112, 33);
            btnSaveSettings.TabIndex = 71;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(760, 566);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 33);
            btnClose.TabIndex = 72;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // frmMarketHistoryViewer
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(884, 611);
            Controls.Add(btnSaveSettings);
            Controls.Add(btnClose);
            Controls.Add(gbTrendOptions);
            Controls.Add(gbDataOptions);
            Controls.Add(gbDateSelect);
            Controls.Add(chrtMarketHistory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmMarketHistoryViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Market Viewer";
            ((System.ComponentModel.ISupportInitialize)chrtMarketHistory).EndInit();
            gbDateSelect.ResumeLayout(false);
            gbDateSelect.PerformLayout();
            gbDataOptions.ResumeLayout(false);
            gbDataOptions.PerformLayout();
            gbTrendOptions.ResumeLayout(false);
            gbTrendOptions.PerformLayout();
            Shown += new EventHandler(frmMarketHistoryViewer_Shown);
            ResumeLayout(false);

        }
        internal System.Windows.Forms.DataVisualization.Charting.Chart chrtMarketHistory;
        internal CheckBox chkVolume;
        internal CheckBox chk5DayAverage;
        internal CheckBox chk20DayAverage;
        internal CheckBox chkMinMax;
        internal CheckBox chkDonchianChannel;
        internal GroupBox gbDateSelect;
        internal Label lblStartDate;
        internal DateTimePicker dtpStartDate;
        internal Label lblEndDate;
        internal DateTimePicker dtpEndDate;
        internal RadioButton rbtnByDays;
        internal RadioButton rbtnByDate;
        internal Label lblAvgPrice;
        internal ComboBox cmbAvgPriceDuration;
        internal GroupBox gbDataOptions;
        internal CheckBox chkLinearAverage;
        internal GroupBox gbTrendOptions;
        internal Button btnSaveSettings;
        internal Button btnClose;
        internal Button btnRefresh;
    }
}