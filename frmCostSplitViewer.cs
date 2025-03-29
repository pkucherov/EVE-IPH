using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmCostSplitViewer
    {

        public List<CostSplit> CostSplits;
        public string CostSplitType;

        public frmCostSplitViewer()
        {

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

            CostSplits = new List<CostSplit>();

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

            Text = CostSplitType;
            lstCosts.Clear();
            lstCosts.BeginUpdate();

            // Just load the mats into the list
            lstCosts.Columns.Add("Cost Split", 200, HorizontalAlignment.Left);
            lstCosts.Columns.Add("Total Cost", 100, HorizontalAlignment.Right);

            if (!(CostSplits == null))
            {
                for (int i = 0, loopTo = CostSplits.Count - 1; i <= loopTo; i++)
                {
                    Application.DoEvents();
                    MatList = new ListViewItem(CostSplits[i].SplitName);
                    MatList.SubItems.Add(Strings.FormatNumber(CostSplits[i].SplitValue, 2));
                    TotalCost += CostSplits[i].SplitValue;
                    lstCosts.Items.Add(MatList);
                }
            }

            // Finally add the total cost
            MatList = new ListViewItem("Total Cost");
            // Color this last line grey
            MatList.BackColor = Color.LightGray;
            MatList.SubItems.Add(Strings.FormatNumber(TotalCost, 2));
            lstCosts.Items.Add(MatList);

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
            ClipboardText = "Cost Split" + Separator + "Total Cost" + Constants.vbCrLf;

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

    public struct CostSplit
    {
        public string SplitName;
        public double SplitValue;
    }
}