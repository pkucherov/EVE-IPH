using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{
    public partial class frmMaterialListViewer
    {

        private int ItemListColumnClicked;
        private SortOrder ItemListColumnSortOrder;

        public frmMaterialListViewer(Materials MaterialList, bool IncludeTaxes, Public_Variables.BrokerFeeInfo BrokerFeeData)
        {

            // This call is required by the designer.
            InitializeComponent();

            ItemListColumnClicked = 0;
            ItemListColumnSortOrder = SortOrder.None;

            // Add any initialization after the InitializeComponent() call.
            ListViewItem matLine;
            double TotalCost = 0d;

            MaterialList.SortMaterialListByQuantity();

            foreach (var Mat in MaterialList.GetMaterialList())
            {
                // Add all the mats to the grid
                matLine = new ListViewItem(Mat.GetMaterialName());
                matLine.SubItems.Add(Strings.FormatNumber(Mat.GetQuantity(), 0));
                matLine.SubItems.Add(Strings.FormatNumber(Mat.GetTotalCost(), 2));
                lstMaterials.Items.Add(matLine);
                TotalCost += Mat.GetTotalCost();
            }

            // Add the tax, fees, and final cost cost
            if (TotalCost > 0d)
            {
                double Taxes = 0d;
                double BrokerFees = 0d;

                matLine = new ListViewItem("Taxes");
                matLine.SubItems.Add("");
                if (IncludeTaxes)
                {
                    Taxes = Public_Variables.GetSalesTax(TotalCost);
                    matLine.SubItems.Add("-" + Strings.FormatNumber(Taxes, 2));
                }
                else
                {
                    matLine.SubItems.Add("0.00");
                }
                lstMaterials.Items.Add(matLine);

                matLine = new ListViewItem("Broker Fees");
                matLine.SubItems.Add("");
                if (BrokerFeeData.IncludeFee != Public_Variables.BrokerFeeType.NoFee)
                {
                    BrokerFees = Public_Variables.GetSalesBrokerFee(TotalCost, BrokerFeeData);
                    matLine.SubItems.Add("-" + Strings.FormatNumber(BrokerFees, 2));
                }
                else
                {
                    matLine.SubItems.Add("0.00");
                }
                lstMaterials.Items.Add(matLine);

                matLine = new ListViewItem("Total Sold Value");
                matLine.SubItems.Add("");
                matLine.SubItems.Add(Strings.FormatNumber(TotalCost - Taxes - BrokerFees, 2));
                lstMaterials.Items.Add(matLine);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstMaterials_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = lstMaterials;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ItemListColumnClicked, ref ItemListColumnSortOrder);
        }
    }
}