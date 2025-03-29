using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmUploadPriceHistoryData
    {
        private bool KeyHandled;
        private bool ItemComboLoaded;
        private bool GroupComboLoaded;
        private bool RegionComboLoaded;

        public frmUploadPriceHistoryData()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            ItemComboLoaded = false;
            GroupComboLoaded = false;
            RegionComboLoaded = false;

            cmbItemGroup.Items.Add("All");
            cmbItemGroup.Text = "All";

            cmbRegions.Items.Add("The Forge");
            cmbRegions.Text = "The Forge";

            cmbItems.Items.Add("Select Item");
            cmbItems.Text = "Select Item";

            btnImport.Enabled = false;

        }

        private void txtPaste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control == true) // Select All
            {
                txtPaste.SelectAll();
                KeyHandled = true;
            }
            else
            {
                KeyHandled = false;
            }

        }

        private void txtPaste_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Special handling - if select all is pressed for some reason the notification sound happens
            e.Handled = KeyHandled;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Insert the data (should be tab separated) into the table
            // Get the item ID for the table
            if (string.IsNullOrEmpty(Strings.Trim(txtPaste.Text)))
            {
                Interaction.MsgBox("No data to import", Constants.vbExclamation, "No Data");
                return;
            }

            string ItemID = "";
            string RegionID = "";

            SQLiteDataReader rsItems;
            Public_Variables.DBCommand = new SQLiteCommand("SELECT ITEM_ID FROM ALL_BLUEPRINTS WHERE ITEM_NAME = '" + Public_Variables.FormatDBString(cmbItems.Text) + "'", Public_Variables.EVEDB.DBREf());
            rsItems = Public_Variables.DBCommand.ExecuteReader();

            if (rsItems.Read())
            {
                ItemID = rsItems.GetInt64(0).ToString();
            }
            else
            {
                Interaction.MsgBox("Invalid Item Name", Constants.vbExclamation, "Wrong Item Name");
                rsItems.Close();
                return;
            }

            // Get RegionID
            Public_Variables.DBCommand = new SQLiteCommand("SELECT regionID FROM REGIONS WHERE regionName = '" + cmbRegions.Text + "'", Public_Variables.EVEDB.DBREf());
            rsItems = Public_Variables.DBCommand.ExecuteReader();

            if (rsItems.Read())
            {
                RegionID = rsItems.GetInt64(0).ToString();
            }
            else
            {
                Interaction.MsgBox("Invalid Item Name", Constants.vbExclamation, "Wrong Item Name");
                rsItems.Close();
                return;
            }

            try
            {
                Public_Variables.EVEDB.BeginSQLiteTransaction();
                // Delete anything there for item selected
                Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format("DELETE FROM MARKET_HISTORY WHERE TYPE_ID = {0} AND REGION_ID = {1}", ItemID, RegionID));

                // Insert from the pasted data
                string Dataset = txtPaste.Text.Replace(Constants.vbCrLf, Constants.vbTab);
                Dataset = Dataset.Replace(Constants.vbLf, Constants.vbTab);
                string[] ItemData = Dataset.Split(ControlChars.Tab);

                string PriceDate = "";

                for (int i = 0, loopTo = ItemData.Count() - 1; i <= loopTo; i++)
                {
                    if (i % 6 == 0 & i != 0)
                    {
                        // Every 6th item, insert
                        PriceDate = ItemData[i - 6].Replace(".", "-");
                        string insertsql = string.Format("INSERT INTO MARKET_HISTORY VALUES({0},{1},'{2}',{3},{4},{5},{6},{7})", ItemID, RegionID, Strings.Format(DateAndTime.DateValue(PriceDate.Substring(0, 10)), Public_Variables.SQLiteDateFormat), Public_Variables.ConvertPriceHistoryEUDecimal(ItemData[i - 3].Replace(" ISK", "")), Public_Variables.ConvertPriceHistoryEUDecimal(ItemData[i - 2].Replace(" ISK", "")), Public_Variables.ConvertPriceHistoryEUDecimal(ItemData[i - 1].Replace(" ISK", "")), Public_Variables.ConvertPriceHistoryEUDecimal(ItemData[i - 5]), Public_Variables.ConvertPriceHistoryEUDecimal(ItemData[i - 4]));
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(insertsql);
                    }
                }

                Public_Variables.EVEDB.CommitSQLiteTransaction();
                Interaction.MsgBox("Data Imported!", Constants.vbInformation, "Success");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Data Import Failed", Constants.vbExclamation, "Error");
                Public_Variables.EVEDB.RollbackSQLiteTransaction();
            }

            rsItems.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtPaste_TextChanged(object sender, EventArgs e)
        {
            btnImport.Enabled = true;
        }

        private void cmbItems_DropDown(object sender, EventArgs e)
        {
            if (!ItemComboLoaded)
            {
                SQLiteDataReader rsItems;
                string SQL = "";
                cmbItems.Items.Clear();
                cmbItems.Items.Add("Select Item");
                SQL = "SELECT ITEM_NAME FROM ALL_BLUEPRINTS";

                if (cmbItemGroup.Text != "All")
                {
                    SQL += " WHERE ITEM_GROUP = '" + cmbItemGroup.Text + "'";
                }

                Public_Variables.DBCommand = new SQLiteCommand(SQL + " ORDER BY ITEM_NAME", Public_Variables.EVEDB.DBREf());
                rsItems = Public_Variables.DBCommand.ExecuteReader();

                while (rsItems.Read())
                    cmbItems.Items.Add(rsItems.GetString(0));
                ItemComboLoaded = true;
                rsItems.Close();
            }
        }
        private void cmbItemGroup_DropDown(object sender, EventArgs e)
        {
            if (!GroupComboLoaded)
            {
                SQLiteDataReader rsItems;
                cmbItemGroup.Items.Clear();

                Public_Variables.DBCommand = new SQLiteCommand("SELECT ITEM_GROUP FROM ALL_BLUEPRINTS GROUP BY ITEM_GROUP", Public_Variables.EVEDB.DBREf());
                rsItems = Public_Variables.DBCommand.ExecuteReader();
                cmbItemGroup.Items.Add("All");
                while (rsItems.Read())
                    cmbItemGroup.Items.Add(rsItems.GetString(0));
                GroupComboLoaded = true;
                rsItems.Close();
            }
        }

        private void cmbItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbItems.Text = "Select Item";
            btnImport.Enabled = false;
            ItemComboLoaded = false;
        }

        private void cmbRegions_DropDown(object sender, EventArgs e)
        {
            if (!RegionComboLoaded)
            {
                var argRegionCombo = cmbRegions;
                Public_Variables.LoadRegionCombo(ref argRegionCombo, "Jita");
                cmbRegions = argRegionCombo;
                RegionComboLoaded = true;
            }
        }

        private void cmbItemGroup_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Strings.Trim(cmbItemGroup.Text)))
            {
                cmbItemGroup.Text = "All";
            }
        }

        private void cmbItemGroup_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Strings.Trim(cmbItemGroup.Text)))
            {
                cmbItemGroup.Text = "All";
            }
        }

        private void cmbRegions_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Strings.Trim(cmbRegions.Text)))
            {
                cmbRegions.Text = "The Forge";
            }
        }

        private void cmbRegions_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Strings.Trim(cmbRegions.Text)))
            {
                cmbRegions.Text = "The Forge";
            }
        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnImport.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPaste.Text = "";
        }
    }
}