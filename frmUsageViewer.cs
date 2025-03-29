using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmUsageViewer
    {

        public List<UsageSplit> UsageSplits;

        public frmUsageViewer()
        {

            AutoScaleMode = AutoScaleMode.Dpi;

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            if ((rbtnExportCSV.Text ?? "") == (SettingsVariables.UserApplicationSettings.DataExportFormat ?? ""))
            {
                rbtnExportCSV.Checked = true;
            }
            else if ((rbtnExportSSV.Text ?? "") == (SettingsVariables.UserApplicationSettings.DataExportFormat ?? ""))
            {
                rbtnExportSSV.Checked = true;
            }
            else if ((rbtnExportDefault.Text ?? "") == (SettingsVariables.UserApplicationSettings.DataExportFormat ?? ""))
            {
                rbtnExportDefault.Checked = true;
            }

            UsageSplits = new List<UsageSplit>();

        }

        private void frmCostSplitViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void frmCostSplitViewer_Shown(object sender, EventArgs e)
        {
            ListViewItem MatList;
            var TotalCost = default(double); // For summing up all the costs

            Application.UseWaitCursor = true;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            lstCosts.Clear();
            lstCosts.BeginUpdate();

            // Just load the mats into the list
            lstCosts.Columns.Add("Usage Type", 175, HorizontalAlignment.Left);
            lstCosts.Columns.Add("Usage Cost", 125, HorizontalAlignment.Right);

            if (!(UsageSplits == null))
            {
                for (int i = 0, loopTo = UsageSplits.Count - 1; i <= loopTo; i++)
                {
                    Application.DoEvents();
                    MatList = lstCosts.Items.Add(UsageSplits[i].UsageName);
                    MatList.SubItems.Add(Strings.FormatNumber(UsageSplits[i].UsageValue, 2));
                    TotalCost += UsageSplits[i].UsageValue;
                }
            }

            // Finally add the usage cost
            MatList = lstCosts.Items.Add("Total Usage");
            // Color this last line grey
            MatList.BackColor = Color.LightGray;
            MatList.SubItems.Add(Strings.FormatNumber(TotalCost, 2));

            lstCosts.EndUpdate();
            Application.UseWaitCursor = false;
            Cursor = Cursors.Default;
            Application.DoEvents();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnCopyMats_Click(object sender, EventArgs e)
        {
            string Separator;
            string ClipboardText = "";
            ListView.ListViewItemCollection Items;

            if (rbtnExportCSV.Checked)
            {
                Separator = ",";
            }
            else if (rbtnExportSSV.Checked)
            {
                Separator = ";";
            }
            else
            {
                Separator = " ";
            }

            // Add the top row
            ClipboardText = "Usage Name" + Separator + "Usage Cost" + Constants.vbCrLf;

            Items = lstCosts.Items;

            foreach (ListViewItem ListItem in Items)
            {
                ClipboardText = ClipboardText + ListItem.SubItems[0].Text + Separator;
                if (rbtnExportCSV.Checked)
                {
                    // No commas in number
                    ClipboardText = ClipboardText + Strings.Format(ListItem.SubItems[1].Text, "Fixed") + Constants.vbCrLf;
                }
                else if (rbtnExportSSV.Checked)
                {
                    // Switch commas and periods
                    ClipboardText = ClipboardText + Public_Variables.ConvertUStoEUDecimal(ListItem.SubItems[1].Text) + Constants.vbCrLf;
                }
                else
                {
                    ClipboardText = ClipboardText + ListItem.SubItems[1].Text + Constants.vbCrLf;
                }
            }

            // Paste to clipboard
            Public_Variables.CopyTextToClipboard(ClipboardText);

        }

    }

    public struct UsageSplit
    {
        public string UsageName;
        public double UsageValue;
    }
}