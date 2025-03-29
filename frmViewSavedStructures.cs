using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmViewSavedStructures
    {

        public frmViewSavedStructures()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            // Total is 660, minus 25 for check, and 21 for scroll = 614
            lstStructures.Columns[0].Width = -2;
            lstStructures.Columns[1].Width = 100;
            lstStructures.Columns[2].Width = 195;
            lstStructures.Columns[3].Width = 90;
            lstStructures.Columns[4].Width = 90;
            lstStructures.Columns[5].Width = 139;

        }

        // Load up the structures
        private void frmViewSavedStructures_Shown(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            Enabled = false;
            btnExit.Enabled = false;
            btnRemove.Enabled = false;
            lstStructures.Enabled = false;
            Application.DoEvents();

            LoadStructureGrid();

            btnExit.Enabled = true;
            btnRemove.Enabled = true;
            lstStructures.Enabled = true;
            Enabled = true;
            Application.UseWaitCursor = false;
            Application.DoEvents();

        }

        public void LoadStructureGrid()
        {
            string SQL;
            SQLiteDataReader rsList;
            var ESIData = new ESI();
            var lstViewRow = new ListViewItem();

            SQL = "SELECT STATION_ID, STATION_NAME, solarSystemName, regionName FROM STATIONS, SOLAR_SYSTEMS, REGIONS ";
            SQL += "WHERE STATIONS.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID ";
            SQL += "AND STATIONS.REGION_ID = REGIONS.regionID AND MANUAL_ENTRY <> 0 ";
            SQL += "ORDER BY regionName, solarSystemName, STATION_NAME";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsList = Public_Variables.DBCommand.ExecuteReader();

            lstStructures.Items.Clear();
            lstStructures.BeginUpdate();

            while (rsList.Read())
            {
                lstViewRow = new ListViewItem(""); // Check
                lstViewRow.SubItems.Add(rsList.GetInt64(0).ToString()); // ID
                lstViewRow.SubItems.Add(rsList.GetString(1)); // Name
                lstViewRow.SubItems.Add(rsList.GetString(2)); // System
                lstViewRow.SubItems.Add(rsList.GetString(3)); // Region

                // For each one, look up the market status and set
                if (ESIData.CheckStructureMarketData(rsList.GetInt64(0), Public_Variables.SelectedCharacter.CharacterTokenData, true))
                {
                    lstViewRow.SubItems.Add("OK"); // Status
                }
                else
                {
                    lstViewRow.SubItems.Add("Market Access Denied");
                } // Status

                lstStructures.Items.Add(lstViewRow);
                Application.DoEvents();

            }

            lstStructures.EndUpdate();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkeditems;
            string SQL = "DELETE FROM STATIONS WHERE STATION_ID = {0}";

            checkeditems = lstStructures.CheckedItems;

            for (int i = 0, loopTo = checkeditems.Count - 1; i <= loopTo; i++)
                Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(SQL, checkeditems[i].SubItems[1].Text));

            LoadStructureGrid();

            Interaction.MsgBox("Selected Structures removed.", Constants.vbInformation, Application.ProductName);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

    }
}