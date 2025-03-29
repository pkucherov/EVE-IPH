using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmResearchAgents
    {

        private int ListColumnClicked;
        private SortOrder ListColumnSortOrder;

        public frmResearchAgents()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            lstAgents.Columns.Add("Agent", 130, HorizontalAlignment.Left);
            lstAgents.Columns.Add("Field", 150, HorizontalAlignment.Left);
            lstAgents.Columns.Add("Current RP", 80, HorizontalAlignment.Right);
            lstAgents.Columns.Add("Number of Cores", 95, HorizontalAlignment.Right);
            lstAgents.Columns.Add("Current Value", 90, HorizontalAlignment.Right);
            lstAgents.Columns.Add("RP/Day", 60, HorizontalAlignment.Right);
            lstAgents.Columns.Add("Level", 50, HorizontalAlignment.Center);
            lstAgents.Columns.Add("Location", 265, HorizontalAlignment.Left);

            ListColumnClicked = 0;
            ListColumnSortOrder = SortOrder.None;

        }

        private void frmResearchAgents_Shown(object sender, EventArgs e)
        {
            // Reload the agents and update from API if necessary
            Public_Variables.SelectedCharacter.GetResearchAgents().LoadResearchAgents(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData);

            LoadGrid();

        }

        // Sort columns
        private void lstAgents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstAgents;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ListColumnClicked, ref ListColumnSortOrder);
            lstAgents = argRefListView;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void LoadGrid()
        {
            ListViewItem lstViewRow;
            var fAccessError = new frmAPIError();

            SQLiteDataReader readerPriceLookup;
            string SQL;
            double CurrentValue;
            long CurrentNumberofCores;
            double TotalValue = 0d;

            lstAgents.Items.Clear();

            Application.UseWaitCursor = true;

            lstAgents.BeginUpdate();

            {
                var withBlock = Public_Variables.SelectedCharacter.GetResearchAgents();
                for (int i = 0, loopTo = withBlock.GetResearchAgents().Count - 1; i <= loopTo; i++)
                {
                    // Get the total value of the datacores if I were to cash them in today - Price minus the DataCoreRedeemCost
                    if (withBlock.GetResearchAgents()[i].Field.Contains("Gallente Starship"))
                    {
                        SQL = "SELECT PRICE FROM ITEM_PRICES WHERE ITEM_NAME ='Datacore - Gallentean Starship Engineering'";
                    }
                    else if (withBlock.GetResearchAgents()[i].Field.Contains("Amarr Starship"))
                    {
                        SQL = "SELECT PRICE FROM ITEM_PRICES WHERE ITEM_NAME ='Datacore - Amarian Starship Engineering'";
                    }
                    else
                    {
                        SQL = "SELECT PRICE FROM ITEM_PRICES WHERE ITEM_NAME ='Datacore - " + withBlock.GetResearchAgents()[i].Field + "'";
                    }

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerPriceLookup = Public_Variables.DBCommand.ExecuteReader();

                    if (readerPriceLookup.Read())
                    {
                        // Get the number of cores we would get, minus the redeem cost from each 
                        CurrentNumberofCores = (long)Math.Round(Math.Floor(withBlock.GetResearchAgents()[i].CurrentRP / 100d));
                        CurrentValue = Math.Floor(withBlock.GetResearchAgents()[i].CurrentRP / 100d) * (readerPriceLookup.GetDouble(0) - Public_Variables.DataCoreRedeemCost);
                    }
                    else
                    {
                        CurrentNumberofCores = 0L;
                        CurrentValue = 0d;
                    }

                    // Load the current data
                    lstViewRow = lstAgents.Items.Add(withBlock.GetResearchAgents()[i].Agent); // Agent Name
                                                                                              // The remaining columns are subitems  
                    lstViewRow.SubItems.Add(withBlock.GetResearchAgents()[i].Field); // Field
                    lstViewRow.SubItems.Add(Strings.FormatNumber(withBlock.GetResearchAgents()[i].CurrentRP, 2)); // Current RP
                    lstViewRow.SubItems.Add(Strings.FormatNumber(CurrentNumberofCores, 0)); // Current number of cores
                    lstViewRow.SubItems.Add(Strings.FormatNumber(CurrentValue, 2)); // Current Value
                    lstViewRow.SubItems.Add(Strings.FormatNumber(withBlock.GetResearchAgents()[i].RPperDay, 2)); // RP/Day
                    lstViewRow.SubItems.Add(withBlock.GetResearchAgents()[i].AgentLevel.ToString()); // Level
                    lstViewRow.SubItems.Add(withBlock.GetResearchAgents()[i].Location); // Location
                    TotalValue = TotalValue + CurrentValue;
                }
            }

            // Set total isk
            lblTotalDCValue.Text = Strings.FormatNumber(TotalValue, 2) + " ISK";

            // Make sure the refresh button is enabled
            btnRefresh.Enabled = true;
            lstAgents.EndUpdate();
            Application.UseWaitCursor = false;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;

            // Reload the agents and update from API if necessary
            Public_Variables.SelectedCharacter.GetResearchAgents().LoadResearchAgents(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData);

            // Refresh the data
            LoadGrid();

            Application.UseWaitCursor = false;
            Interaction.MsgBox("Records Refreshed", Constants.vbInformation, Application.ProductName);

        }

    }
}