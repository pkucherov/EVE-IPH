using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmMarketHistoryViewer
    {

        private bool FirstFormLoad;
        private long ItemID;
        private string ItemName;
        private long RegionID;
        private string RegionName;
        private int Days;

        public frmMarketHistoryViewer(long _ItemID, string _ItemName, long _RegionID, string _RegionName, int _Days)
        {

            FirstFormLoad = true;

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            ItemID = _ItemID;
            ItemName = _ItemName;
            RegionID = _RegionID;
            RegionName = _RegionName;
            Days = _Days;

            InitForm();

            FirstFormLoad = false;

        }

        private void frmMarketHistoryViewer_Shown(object sender, EventArgs e)
        {

            RefreshGraph();

        }

        private void InitForm()
        {

            {
                ref var withBlock = ref SettingsVariables.UserMHViewerSettings;
                chkMinMax.Checked = withBlock.MinMaxDayPrice;
                chkVolume.Checked = withBlock.Volume;

                chkLinearAverage.Checked = withBlock.LinearTrend;
                chkDonchianChannel.Checked = withBlock.DochianChannel;
                chk5DayAverage.Checked = withBlock.FiveDayAvg;
                chk20DayAverage.Checked = withBlock.TwentyDayAvg;

                if ((withBlock.DatePreference ?? "") == (rbtnByDays.Text ?? ""))
                {
                    rbtnByDays.Checked = true;
                }
                else
                {
                    rbtnByDate.Checked = true;
                }
            }

            // Dates are always set on what is sent to the constructor
            dtpStartDate.Value = DateAndTime.DateAdd(DateInterval.Day, -(Days + 1), DateTime.Now.Date);
            dtpEndDate.Value = DateTime.Now;

            cmbAvgPriceDuration.Text = Days.ToString();

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            MarketHistoryViewerSettings TempSettings = default;
            var Settings = new ProgramSettings();

            TempSettings.MinMaxDayPrice = chkMinMax.Checked;
            TempSettings.Volume = chkVolume.Checked;

            TempSettings.LinearTrend = chkLinearAverage.Checked;
            TempSettings.FiveDayAvg = chk5DayAverage.Checked;
            TempSettings.TwentyDayAvg = chk20DayAverage.Checked;
            TempSettings.DochianChannel = chkDonchianChannel.Checked;

            if (rbtnByDays.Checked)
            {
                TempSettings.DatePreference = rbtnByDays.Text;
            }
            else
            {
                TempSettings.DatePreference = rbtnByDate.Text;
            }

            // Save the data in the XML file
            Settings.SaveMarketHistoryViewerSettingsSettings(TempSettings);

            // Save the data to the local variable
            SettingsVariables.UserMHViewerSettings = TempSettings;

            Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

        }

        private struct DataPoint
        {
            public int XValue;
            public double YValue;
            public string XValueLabel;
            public int YVolume;
            public double YMinValue;
            public double YMaxValue;
        }

        private void RefreshGraph()
        {
            string SQL;
            SQLiteDataReader rsHistory;

            var AveragePrices = new List<double>();
            var Volumes = new List<int>();
            var MaxPrices = new List<double>();
            var MinPrices = new List<double>();
            var DonchianMin5 = new List<double>();
            var DonchianMax5 = new List<double>();

            int Count = 0;
            DateTime MinXDate;

            var AllData = new List<DataPoint>();
            var MainData = new List<DataPoint>();
            var _5DayData = new List<DataPoint>();
            var _20DayData = new List<DataPoint>();
            var DonchianData = new List<DataPoint>();

            int MainDataCount = 0;
            int _5DayCount = 0;
            int _20DayCount = 0;

            ToolStripProgressBar argSentPG = null;
            var MH = new MarketPriceInterface(ref argSentPG);

            // Determine dates and add 20 days (subtract) to it regardless to help build the different trend lines (they get cut off from the front)
            DateTime StartDate;
            DateTime EndDate;

            if (rbtnByDate.Checked)
            {
                StartDate = DateAndTime.DateAdd(DateInterval.Day, -20, dtpStartDate.Value);
                MinXDate = dtpStartDate.Value;
                EndDate = dtpEndDate.Value;
            }
            else
            {
                StartDate = DateAndTime.DateAdd(DateInterval.Day, -(Conversions.ToInteger(cmbAvgPriceDuration.Text) + 20), DateTime.UtcNow.Date);
                MinXDate = DateAndTime.DateAdd(DateInterval.Day, -(Conversions.ToInteger(cmbAvgPriceDuration.Text) + 1), DateTime.UtcNow.Date);
                EndDate = DateTime.Now;
            }

            var TypeID = new List<long>();
            TypeID.Add(ItemID);

            // Update the prices
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            if (!MH.UpdateESIPriceHistory(TypeID, RegionID))
            {
                Interaction.MsgBox("Some prices did not update. Please try again.", Constants.vbInformation, Application.ProductName);
            }
            Cursor = Cursors.Default;
            Application.DoEvents();

            // Set up the chart
            {
                var withBlock = chrtMarketHistory;
                withBlock.Titles["RegionName"].Text = RegionName + " Regional Market";
                withBlock.Titles["ItemName"].Text = ItemName;

                withBlock.Series.Clear();

                withBlock.Series.Add("Prices");
                withBlock.Series["Prices"].XAxisType = AxisType.Primary;
                withBlock.Series["Prices"].YAxisType = AxisType.Primary;
                if (chkMinMax.Checked)
                {
                    withBlock.Series["Prices"].ChartType = SeriesChartType.ErrorBar;
                }
                else
                {
                    withBlock.Series["Prices"].ChartType = SeriesChartType.Point;
                }
                withBlock.Series["Prices"].IsVisibleInLegend = false;
                withBlock.Series["Prices"].ChartArea = "Main";

                if (chkVolume.Checked)
                {
                    withBlock.Series.Add("Volume");
                    withBlock.Series["Volume"].XAxisType = AxisType.Primary;
                    withBlock.Series["Volume"].YAxisType = AxisType.Secondary;
                    withBlock.Series["Volume"].ChartType = SeriesChartType.Column;
                    withBlock.Series["Volume"].IsVisibleInLegend = false;
                    withBlock.Series["Volume"].ChartArea = "Main";
                }

                if (chkLinearAverage.Checked)
                {
                    withBlock.Series.Add("LinearTrend");
                    withBlock.Series["LinearTrend"].ChartType = SeriesChartType.Line;
                    withBlock.Series["LinearTrend"].XAxisType = AxisType.Primary;
                    withBlock.Series["LinearTrend"].YAxisType = AxisType.Primary;
                    withBlock.Series["LinearTrend"].BorderWidth = 1;
                    withBlock.Series["LinearTrend"].Color = Color.Crimson;
                    withBlock.Series["LinearTrend"].IsVisibleInLegend = false;
                    withBlock.Series["LinearTrend"].ChartArea = "Main";
                }

                if (chk5DayAverage.Checked)
                {
                    withBlock.Series.Add("5DayTrend");
                    withBlock.Series["5DayTrend"].ChartType = SeriesChartType.Line;
                    withBlock.Series["5DayTrend"].XAxisType = AxisType.Primary;
                    withBlock.Series["5DayTrend"].YAxisType = AxisType.Primary;
                    withBlock.Series["5DayTrend"].BorderWidth = 2;
                    withBlock.Series["5DayTrend"].Color = Color.SeaGreen;
                    withBlock.Series["5DayTrend"].IsVisibleInLegend = false;
                    withBlock.Series["5DayTrend"].ChartArea = "Main";
                }

                if (chk20DayAverage.Checked)
                {
                    withBlock.Series.Add("20DayTrend");
                    withBlock.Series["20DayTrend"].ChartType = SeriesChartType.Line;
                    withBlock.Series["20DayTrend"].XAxisType = AxisType.Primary;
                    withBlock.Series["20DayTrend"].YAxisType = AxisType.Primary;
                    withBlock.Series["20DayTrend"].BorderWidth = 2;
                    withBlock.Series["20DayTrend"].Color = Color.DarkOrange;
                    withBlock.Series["20DayTrend"].IsVisibleInLegend = false;
                    withBlock.Series["20DayTrend"].ChartArea = "Main";
                }

                if (chkDonchianChannel.Checked)
                {
                    withBlock.Series.Add("MinDonchian");
                    withBlock.Series["MinDonchian"].ChartType = SeriesChartType.Line;
                    withBlock.Series["MinDonchian"].XAxisType = AxisType.Primary;
                    withBlock.Series["MinDonchian"].YAxisType = AxisType.Primary;
                    withBlock.Series["MinDonchian"].BorderWidth = 1;
                    withBlock.Series["MinDonchian"].Color = Color.RoyalBlue;
                    withBlock.Series["MinDonchian"].IsVisibleInLegend = false;
                    withBlock.Series["MinDonchian"].ChartArea = "Main";

                    withBlock.Series.Add("MaxDonchian");
                    withBlock.Series["MaxDonchian"].ChartType = SeriesChartType.Line;
                    withBlock.Series["MaxDonchian"].XAxisType = AxisType.Primary;
                    withBlock.Series["MaxDonchian"].YAxisType = AxisType.Primary;
                    withBlock.Series["MaxDonchian"].BorderWidth = 1;
                    withBlock.Series["MaxDonchian"].Color = Color.RoyalBlue;
                    withBlock.Series["MaxDonchian"].IsVisibleInLegend = false;
                    withBlock.Series["MaxDonchian"].ChartArea = "Main";
                }
            }

            SQL = "SELECT PRICE_HISTORY_DATE, AVG_PRICE, LOW_PRICE, HIGH_PRICE, TOTAL_VOLUME_FILLED FROM MARKET_HISTORY ";
            SQL += "WHERE TYPE_ID = " + ItemID + " AND REGION_ID = " + RegionID + " ";
            SQL += "AND DATETIME(PRICE_HISTORY_DATE) >= " + " DateTime('" + Strings.Format(StartDate, Public_Variables.SQLiteDateFormat) + "') ";
            SQL += "AND DATETIME(PRICE_HISTORY_DATE) < " + " DateTime('" + Strings.Format(EndDate, Public_Variables.SQLiteDateFormat) + "') ";
            SQL += "AND TOTAL_VOLUME_FILLED IS NOT NULL ";
            SQL += "ORDER BY PRICE_HISTORY_DATE";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsHistory = Public_Variables.DBCommand.ExecuteReader();

            var DP = new DataPoint();
            var TempDP = new DataPoint();

            // Make all the series first, then add them after
            while (rsHistory.Read())
            {
                DP.XValue = Count;
                DP.XValueLabel = Strings.Format(DateAndTime.DateValue(rsHistory.GetString(0)), "dd-MMM");
                DP.YValue = rsHistory.GetDouble(1);
                DP.YMinValue = rsHistory.GetDouble(2);
                DP.YMaxValue = rsHistory.GetDouble(3);
                DP.YVolume = rsHistory.GetInt32(4);

                AveragePrices.Add(rsHistory.GetDouble(1));
                MinPrices.Add(rsHistory.GetDouble(2));
                MaxPrices.Add(rsHistory.GetDouble(3));
                Volumes.Add(rsHistory.GetInt32(4));

                // If it's within the range, add to the main data
                if (MinXDate < DateAndTime.DateValue(rsHistory.GetString(0)))
                {
                    int StartIndex = 0;

                    TempDP = DP;
                    TempDP.XValue = MainDataCount;

                    MainData.Add(TempDP);
                    MainDataCount += 1;

                    if (Count <= 4)
                    {
                        StartIndex = 0;
                    }
                    else
                    {
                        StartIndex = Count - 5;
                    }

                    // Get the 5 day average
                    TempDP.YValue = GetDayAverage(StartIndex, Count - 1, ref AllData);
                    _5DayData.Add(TempDP);

                    if (Count <= 19)
                    {
                        StartIndex = 0;
                    }
                    else
                    {
                        StartIndex = Count - 20;
                    }

                    // Now get the 20 day average
                    TempDP.YValue = GetDayAverage(StartIndex, Count - 1, ref AllData);
                    _20DayData.Add(TempDP);

                    // Set the Donchian channel 
                    DonchianMin5 = new List<double>();
                    DonchianMax5 = new List<double>();

                    if (Count > 4)
                    {
                        for (int i = Count - 4, loopTo = Count; i <= loopTo; i++)
                        {
                            // Get min and max values from the main data
                            DonchianMin5.Add(MinPrices[i]);
                            DonchianMax5.Add(MaxPrices[i]);
                        }

                        // Set the data
                        TempDP.YMinValue = DonchianMin5.Min();
                        TempDP.YMaxValue = DonchianMax5.Max();
                        TempDP.YValue = 0d;
                        // Add and reset
                        DonchianData.Add(TempDP);
                    }
                    else
                    {
                        // Set the data
                        TempDP.YMinValue = 0d;
                        TempDP.YMaxValue = 0d;
                        TempDP.YValue = 0d;
                        // Add and reset
                        DonchianData.Add(TempDP);
                    }

                }

                AllData.Add(DP);
                Count += 1;

            }

            rsHistory.Close();

            // Loop through and add all the series
            for (int i = 0, loopTo1 = MainData.Count - 1; i <= loopTo1; i++)
            {
                {
                    var withBlock1 = MainData[i];
                    if (chkMinMax.Checked)
                    {
                        // min/max
                        chrtMarketHistory.Series["Prices"].Points.AddXY(withBlock1.XValue, withBlock1.YValue, withBlock1.YMinValue, withBlock1.YMaxValue);
                        chrtMarketHistory.Series["Prices"].Points[i].AxisLabel = withBlock1.XValueLabel;
                        chrtMarketHistory.Series["Prices"].Points[i].Color = Color.DarkBlue;
                        chrtMarketHistory.Series["Prices"].Points[i].MarkerSize = 1;
                    }
                    else
                    {
                        chrtMarketHistory.Series["Prices"].Points.AddXY(withBlock1.XValue, withBlock1.YValue);
                        chrtMarketHistory.Series["Prices"].Points[i].AxisLabel = withBlock1.XValueLabel;
                        chrtMarketHistory.Series["Prices"].Points[i].Color = Color.DarkBlue;
                        chrtMarketHistory.Series["Prices"].Points[i].MarkerSize = 4;
                        chrtMarketHistory.Series["Prices"].Points[i].MarkerStyle = MarkerStyle.Circle;
                    }


                    // If they want volume, add it
                    if (chkVolume.Checked)
                    {
                        chrtMarketHistory.Series["Volume"].Points.AddY(withBlock1.YVolume);
                        chrtMarketHistory.Series["Volume"].Points[i].Color = Color.Maroon;
                        chrtMarketHistory.Series["Volume"].Points[i].MarkerSize = 1;
                    }

                }

                if (chk5DayAverage.Checked)
                {
                    chrtMarketHistory.Series["5DayTrend"].Points.AddXY(_5DayData[i].XValue, _5DayData[i].YValue);
                    chrtMarketHistory.Series["5DayTrend"].Points[i].AxisLabel = _5DayData[i].XValueLabel;
                }

                if (chk20DayAverage.Checked)
                {
                    chrtMarketHistory.Series["20DayTrend"].Points.AddXY(_20DayData[i].XValue, _20DayData[i].YValue);
                    chrtMarketHistory.Series["20DayTrend"].Points[i].AxisLabel = _20DayData[i].XValueLabel;
                }


                if (chkDonchianChannel.Checked)
                {
                    chrtMarketHistory.Series["MinDonchian"].Points.AddXY(DonchianData[i].XValue, DonchianData[i].YMinValue);
                    chrtMarketHistory.Series["MinDonchian"].Points[i].AxisLabel = DonchianData[i].XValueLabel;
                    chrtMarketHistory.Series["MaxDonchian"].Points.AddXY(DonchianData[i].XValue, DonchianData[i].YMaxValue);
                    chrtMarketHistory.Series["MaxDonchian"].Points[i].AxisLabel = DonchianData[i].XValueLabel;
                }

            }

            // Exit if no records
            if (Count == 0)
            {
                Interaction.MsgBox("No Data to show", Constants.vbInformation, Application.ProductName);
                return;
            }

            // Reset chart
            if (MaxPrices.Max() / 1000000000d > 1d)
            {
                // Billions
                chrtMarketHistory.ChartAreas["Main"].AxisY.LabelStyle.Format = "#,,," + "B";
            }
            else if (MaxPrices.Max() / 1000000d > 1d)
            {
                // Millions
                chrtMarketHistory.ChartAreas["Main"].AxisY.LabelStyle.Format = "#,," + "M";
            }
            else if (MaxPrices.Max() / 1000d > 1d)
            {
                // Thousands
                chrtMarketHistory.ChartAreas["Main"].AxisY.LabelStyle.Format = "#," + "K";
            }

            // Set up the chart to scale
            {
                var withBlock2 = chrtMarketHistory.ChartAreas["Main"];
                if (chkMinMax.Checked | chkDonchianChannel.Checked)
                {
                    withBlock2.AxisY.Minimum = MinPrices.Min() - MinPrices.Min() * 0.03d;
                    withBlock2.AxisY.Maximum = MaxPrices.Max() + MaxPrices.Max() * 0.03d;
                    withBlock2.AxisX.Interval = (int)Math.Round(Count / 7d);
                    withBlock2.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
                }
                else
                {
                    withBlock2.AxisY.Minimum = AveragePrices.Min() - AveragePrices.Min() * 0.03d;
                    withBlock2.AxisY.Maximum = AveragePrices.Max() + AveragePrices.Max() * 0.03d;
                    withBlock2.AxisX.Interval = (int)Math.Round(Count / 7d);
                    withBlock2.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
                }

                // For volume
                withBlock2.AxisY2.Minimum = 0d;
                withBlock2.AxisY2.Maximum = Volumes.Max() * 5;
                withBlock2.AxisY2.LabelStyle.Format = "#,##0";
                withBlock2.AxisX2.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            }

            if (MainData.Count > 1 & chkLinearAverage.Checked)
            {
                // Use the price series only for linear
                chrtMarketHistory.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear,1,false,false", chrtMarketHistory.Series["Prices"], chrtMarketHistory.Series["LinearTrend"]);
            }

        }

        private double GetDayAverage(int StartIndex, int EndIndex, ref List<DataPoint> Data)
        {
            double Sum = 0d;

            for (int i = StartIndex, loopTo = EndIndex; i <= loopTo; i++)
                Sum += Data[i].YValue;

            return Sum / (EndIndex - StartIndex + 1);

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                // For some reason, a > of two equal dates returns true when it should be false - so decrement by 1 second
                if (DateAndTime.DateAdd(DateInterval.Second, -1, dtpStartDate.Value) > dtpEndDate.Value)
                {
                    Interaction.MsgBox("The Start Date cannot be greater than the End Date", Constants.vbExclamation, Application.ProductName);
                    dtpStartDate.Value = DateAndTime.DateAdd(DateInterval.Day, -1, dtpEndDate.Value);
                    dtpStartDate.Focus();
                }
                else
                {
                    RefreshGraph();
                }
            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                if (dtpStartDate.Value > dtpEndDate.Value)
                {
                    Interaction.MsgBox("The End Date cannot be less than the Start Date", Constants.vbExclamation, Application.ProductName);
                    dtpEndDate.Value = DateAndTime.DateAdd(DateInterval.Day, 1d, dtpStartDate.Value);
                    dtpStartDate.Focus();
                }
                else
                {
                    RefreshGraph();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                RefreshGraph();
            }
        }

        private void chkMinMax_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                RefreshGraph();
            }
        }

        private void chkVolume_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                RefreshGraph();
            }
        }

        private void chkLinearAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                RefreshGraph();
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                RefreshGraph();
            }
        }

        private void chk5DayAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                RefreshGraph();
            }
        }

        private void chk20DayAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstFormLoad)
            {
                RefreshGraph();
            }
        }

        private void rbtnByDate_CheckedChanged(object sender, EventArgs e)
        {
            ToggleDateEntry();
        }

        private void rbtnByDays_CheckedChanged(object sender, EventArgs e)
        {
            ToggleDateEntry();
        }

        private void ToggleDateEntry()
        {
            if (rbtnByDate.Checked)
            {
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
                lblEndDate.Enabled = true;
                lblStartDate.Enabled = true;

                lblAvgPrice.Enabled = false;
                cmbAvgPriceDuration.Enabled = false;
                btnRefresh.Enabled = false;
            }
            else
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                lblEndDate.Enabled = false;
                lblStartDate.Enabled = false;

                lblAvgPrice.Enabled = true;
                cmbAvgPriceDuration.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void cmbAvgPriceDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedRunschars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGraph();
        }

    }
}