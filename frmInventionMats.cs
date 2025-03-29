using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{
    public partial class frmInventionMats
    {

        public Materials MaterialList;
        public int TotalInventedRuns;
        public long UserRuns;
        public string MatType;
        public string ListType;

        public frmInventionMats()
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

        }

        private void frmInventionREMats_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void frmInventionREMats_Shown(object sender, EventArgs e)
        {
            ListViewItem MatList;
            long Quantity;
            double MatCost;
            var TotalCost = default(double); // For summing up all the costs

            Application.UseWaitCursor = true;
            Application.DoEvents();

            Text = MatType;

            // Sort by quantity
            MaterialList.SortMaterialListByQuantity();

            // Just load the mats into the list
            lstMats.Columns.Add("Material", 253, HorizontalAlignment.Left);
            lstMats.Columns.Add("Cost per Item", 90, HorizontalAlignment.Right);
            lstMats.Columns.Add("Total Cost", 100, HorizontalAlignment.Right);
            lstMats.Columns.Add("Quantity", 75, HorizontalAlignment.Right);

            if (!(MaterialList.GetMaterialList() == null))
            {
                for (int i = 0, loopTo = MaterialList.GetMaterialList().Count - 1; i <= loopTo; i++)
                {
                    Application.DoEvents();
                    MatList = new ListViewItem(MaterialList.GetMaterialList()[i].GetMaterialName());
                    MatCost = MaterialList.GetMaterialList()[i].GetTotalCost();
                    Quantity = MaterialList.GetMaterialList()[i].GetQuantity();
                    MatList.SubItems.Add(Strings.FormatNumber(MatCost / Quantity, 2));
                    MatList.SubItems.Add(Strings.FormatNumber(MatCost, 2));
                    MatList.SubItems.Add(Strings.FormatNumber(Quantity, 0));
                    TotalCost += MatCost;
                    lstMats.Items.Add(MatList);
                }
            }

            // Add the total cost
            MatList = new ListViewItem("Total " + ListType + " Cost");
            // Color this last line grey
            MatList.BackColor = Color.WhiteSmoke;
            MatList.SubItems.Add("");
            MatList.SubItems.Add(Strings.FormatNumber(TotalCost, 2)); // Put in the Total Cost column
            MatList.SubItems.Add(Strings.FormatNumber(TotalInventedRuns, 0));

            if (ListType.Contains("Invention"))
            {
                // Finally add the cost per bp
                MatList = new ListViewItem("Total Invention Cost for " + UserRuns.ToString() + " Runs");
                // Color this last line grey
                MatList.BackColor = Color.LightGray;
                MatList.SubItems.Add("");
                MatList.SubItems.Add(Strings.FormatNumber(TotalCost / TotalInventedRuns * UserRuns, 2));
                MatList.SubItems.Add(Strings.FormatNumber(UserRuns, 0));
            }

            lstMats.Items.Add(MatList);

            Application.UseWaitCursor = false;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnCopyMats_Click(object sender, EventArgs e)
        {
            string TempExportType;

            if (rbtnExportCSV.Checked)
            {
                TempExportType = Public_Variables.CSVDataExport;
            }
            else if (rbtnExportSSV.Checked)
            {
                TempExportType = Public_Variables.SSVDataExport;
            }
            else if (rbtnExportSimple.Checked)
            {
                TempExportType = Public_Variables.MultiBuyDataExport;
            }
            else
            {
                TempExportType = Public_Variables.DefaultTextDataExport;
            }

            // Paste to clipboard
            Public_Variables.CopyTextToClipboard(MaterialList.GetClipboardList(TempExportType, true, false, false, SettingsVariables.UserApplicationSettings.IncludeInGameLinksinCopyText));
        }

    }
}