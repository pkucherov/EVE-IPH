using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    // Form allows the user to manually update prices in the database
    // The update prices tab will override the prices set here if scheduled to be updated
    public partial class frmManualPriceUpdate
    {

        private ControlsCollection m_ControlsCollection;

        private TextBox[] MineralTextBoxes;
        private PictureBox[] MineralPictures;
        private Label[] MineralLabels;

        private TextBox[] MoonTextBoxes;
        private PictureBox[] MoonPictures;
        private Label[] MoonLabels;

        private bool MineralPricesUpdated;
        private bool MoonPricesUpdated;
        private bool POSPricesUpdated;

        public frmManualPriceUpdate()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            // Width is 382 for columns on manual update - add the columns
            lstPriceLookup.Columns.Add("Material", 261, HorizontalAlignment.Left);
            lstPriceLookup.Columns.Add("Price", 100, HorizontalAlignment.Right);

            // Create the controls collection class for text boxes
            m_ControlsCollection = new ControlsCollection(this);

            // Get controls (note index starts at 1)
            MineralTextBoxes = (TextBox[])ControlArrayUtils.getControlArray(this, MyControls, "txtMineral");
            MineralPictures = (PictureBox[])ControlArrayUtils.getControlArray(this, MyControls, "pictMineral");
            MineralLabels = (Label[])ControlArrayUtils.getControlArray(this, MyControls, "lblMineral");

            MoonTextBoxes = (TextBox[])ControlArrayUtils.getControlArray(this, MyControls, "txtMoon");
            MoonPictures = (PictureBox[])ControlArrayUtils.getControlArray(this, MyControls, "pictMoon");
            MoonLabels = (Label[])ControlArrayUtils.getControlArray(this, MyControls, "lblMoon");

            // POSTextBoxes = ControlArrayUtils.getControlArray(Me, Me.MyControls, "txtPOS")
            // POSPictures = ControlArrayUtils.getControlArray(Me, Me.MyControls, "pictPOS")
            // POSLabels = ControlArrayUtils.getControlArray(Me, Me.MyControls, "lblPOS")

            // Load the prices
            LoadMineralPrices();
            Application.DoEvents();

        }

        public Collection MyControls
        {
            get
            {
                return m_ControlsCollection.Controls;
            }
        }

        // Functions and procedures to update minerals
        #region Minerals Tab

        public void LoadMineralPrices()
        {
            string SQL;
            SQLiteDataReader readerMinerals;
            Cursor = Cursors.WaitCursor;

            SQL = "SELECT ITEM_PRICES.ITEM_NAME, ITEM_PRICES.PRICE ";
            SQL += "FROM ITEM_PRICES ";
            SQL += "WHERE ITEM_PRICES.ITEM_NAME IN ('Tritanium','Pyerite','Mexallon','Nocxium','Isogen','Zydrine','Megacyte','Morphite')";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerMinerals = Public_Variables.DBCommand.ExecuteReader();

            while (readerMinerals.Read())
            {
                // Update the textboxes and images
                for (int i = 1, loopTo = MineralTextBoxes.Count() - 1; i <= loopTo; i++)
                {
                    if ((MineralLabels[i].Text ?? "") == (readerMinerals.GetString(0) ?? ""))
                    {
                        MineralTextBoxes[i].Text = Strings.FormatNumber(readerMinerals.GetDouble(1), 2); // Price
                    }
                }
                Application.DoEvents();
            }

            Cursor = Cursors.Default;
            txtMineral1.Focus();

            readerMinerals.Close();
            readerMinerals = null;
            Public_Variables.DBCommand = null;

            MineralPricesUpdated = false;

        }

        // Updates all the prices if they are changed
        private void UpdateMineralPrices()
        {
            string SQL;
            int i;
            double[] Prices;

            if (MineralPricesUpdated)
            {
                Cursor = Cursors.WaitCursor;

                Prices = new double[(MineralTextBoxes.Count())];

                // Check the prices first
                var loopTo = MineralTextBoxes.Count() - 1;
                for (i = 1; i <= loopTo; i++)
                {
                    if (!Information.IsNumeric(MineralTextBoxes[i].Text))
                    {
                        Interaction.MsgBox("Invalid " + MineralLabels[i].Text + " Price", Constants.vbExclamation, Text);
                        MineralTextBoxes[i].Focus();
                        Cursor = Cursors.Default;
                        return;
                    }
                    else
                    {
                        Prices[i] = Conversions.ToDouble(MineralTextBoxes[i].Text);
                    }
                }

                // Update all the prices
                var loopTo1 = MineralTextBoxes.Count() - 1;
                for (i = 1; i <= loopTo1; i++)
                {
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Prices[i] + ", PRICE_TYPE = 'User' WHERE ITEM_ID = " + Public_Variables.GetTypeID(MineralLabels[i].Text);
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                }

                Interaction.MsgBox("Prices Updated", Constants.vbInformation, Text);
                Cursor = Cursors.Default;
            }
            else
            {
                Interaction.MsgBox("No Prices were Updated", Constants.vbInformation, Text);
            }

            // Finally update the Program prices
            Public_Variables.UpdateProgramPrices();

        }

        private void btnUpdateMineralPrices_Click(object sender, EventArgs e)
        {
            UpdateMineralPrices();
        }

        private void MineralTextBoxes_GotFocus(int index, ref EventArgs e)
        {
            MineralTextBoxes[index].SelectAll();
        }

        private void MineralTextBoxes_KeyPress(ref KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPriceChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void MineralTextBoxes_KeyDown(TextBox SentTextBox, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(SentTextBox, e);
            if (e.KeyCode == Keys.Enter)
            {
                UpdateMineralPrices();
            }
        }

        private void txtMineral1_GotFocus(object sender, EventArgs e)
        {
            MineralTextBoxes_GotFocus(1, ref e);
        }

        private void txtMineral1_KeyDown(object sender, KeyEventArgs e)
        {
            MineralTextBoxes_KeyDown(txtMineral1, e);
        }

        private void txtMineral1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MineralTextBoxes_KeyPress(ref e);
        }

        private void txtMineral1_TextChanged(object sender, EventArgs e)
        {
            MineralPricesUpdated = true;
        }

        private void txtMineral2_GotFocus(object sender, EventArgs e)
        {
            MineralTextBoxes_GotFocus(2, ref e);
        }

        private void txtMineral2_KeyDown(object sender, KeyEventArgs e)
        {
            MineralTextBoxes_KeyDown(txtMineral2, e);
        }

        private void txtMineral2_KeyPress(object sender, KeyPressEventArgs e)
        {
            MineralTextBoxes_KeyPress(ref e);
        }

        private void txtMineral2_TextChanged(object sender, EventArgs e)
        {
            MineralPricesUpdated = true;
        }

        private void txtMineral3_GotFocus(object sender, EventArgs e)
        {
            MineralTextBoxes_GotFocus(3, ref e);
        }

        private void txtMineral3_KeyDown(object sender, KeyEventArgs e)
        {
            MineralTextBoxes_KeyDown(txtMineral3, e);
        }

        private void txtMineral3_KeyPress(object sender, KeyPressEventArgs e)
        {
            MineralTextBoxes_KeyPress(ref e);
        }

        private void txtMineral3_TextChanged(object sender, EventArgs e)
        {
            MineralPricesUpdated = true;
        }

        private void txtMineral4_GotFocus(object sender, EventArgs e)
        {
            MineralTextBoxes_GotFocus(4, ref e);
        }

        private void txtMineral4_KeyDown(object sender, KeyEventArgs e)
        {
            MineralTextBoxes_KeyDown(txtMineral4, e);
        }

        private void txtMineral4_KeyPress(object sender, KeyPressEventArgs e)
        {
            MineralTextBoxes_KeyPress(ref e);
        }

        private void txtMineral4_TextChanged(object sender, EventArgs e)
        {
            MineralPricesUpdated = true;
        }

        private void txtMineral5_GotFocus(object sender, EventArgs e)
        {
            MineralTextBoxes_GotFocus(5, ref e);
        }

        private void txtMineral5_KeyDown(object sender, KeyEventArgs e)
        {
            MineralTextBoxes_KeyDown(txtMineral5, e);
        }

        private void txtMineral5_KeyPress(object sender, KeyPressEventArgs e)
        {
            MineralTextBoxes_KeyPress(ref e);
        }

        private void txtMineral5_TextChanged(object sender, EventArgs e)
        {
            MineralPricesUpdated = true;
        }

        private void txtMineral6_GotFocus(object sender, EventArgs e)
        {
            MineralTextBoxes_GotFocus(6, ref e);
        }

        private void txtMineral6_KeyDown(object sender, KeyEventArgs e)
        {
            MineralTextBoxes_KeyDown(txtMineral6, e);
        }

        private void txtMineral6_KeyPress(object sender, KeyPressEventArgs e)
        {
            MineralTextBoxes_KeyPress(ref e);
        }

        private void txtMineral6_TextChanged(object sender, EventArgs e)
        {
            MineralPricesUpdated = true;
        }

        private void txtMineral7_GotFocus(object sender, EventArgs e)
        {
            MineralTextBoxes_GotFocus(7, ref e);
        }

        private void txtMineral7_KeyDown(object sender, KeyEventArgs e)
        {
            MineralTextBoxes_KeyDown(txtMineral7, e);
        }

        private void txtMineral7_KeyPress(object sender, KeyPressEventArgs e)
        {
            MineralTextBoxes_KeyPress(ref e);
        }

        private void txtMineral7_TextChanged(object sender, EventArgs e)
        {
            MineralPricesUpdated = true;
        }

        private void txtMineral8_GotFocus(object sender, EventArgs e)
        {
            MineralTextBoxes_GotFocus(8, ref e);
        }

        private void txtMineral8_KeyDown(object sender, KeyEventArgs e)
        {
            MineralTextBoxes_KeyDown(txtMineral8, e);
        }

        private void txtMineral8_KeyPress(object sender, KeyPressEventArgs e)
        {
            MineralTextBoxes_KeyPress(ref e);
        }

        private void txtMineral8_TextChanged(object sender, EventArgs e)
        {
            MineralPricesUpdated = true;
        }

        private void btnCloseMinerals_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion

        // Functions and procedures to update moon materials
        #region Moon Materials Tab

        public void LoadMoonPrices()
        {
            string SQL;
            SQLiteDataReader readerMoon;

            Cursor = Cursors.WaitCursor;

            SQL = "SELECT ITEM_PRICES.ITEM_NAME, ITEM_PRICES.PRICE ";
            SQL += "FROM ITEM_PRICES ";
            SQL += "WHERE ITEM_PRICES.ITEM_NAME IN ";
            SQL += "('Ferrogel','Crystalline Carbonide','Fermionic Condensates','Titanium Carbide','Fullerides',";
            SQL += "'Hypersynaptic Fibers','Nanotransistors','Phenolic Composites','Tungsten Carbide','Sylramic Fibers','Fernite Carbide')";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerMoon = Public_Variables.DBCommand.ExecuteReader();

            while (readerMoon.Read())
            {
                // Update the textboxes and images
                for (int i = 1, loopTo = MoonTextBoxes.Count() - 1; i <= loopTo; i++)
                {
                    if ((MoonLabels[i].Text ?? "") == (readerMoon.GetString(0) ?? ""))
                    {
                        MoonTextBoxes[i].Text = Strings.FormatNumber(readerMoon.GetDouble(1), 2); // Price
                    }
                }
                Application.DoEvents();
            }

            Cursor = Cursors.Default;
            txtMoon1.Focus();

            readerMoon.Close();
            readerMoon = null;
            Public_Variables.DBCommand = null;

            MoonPricesUpdated = false;

        }

        private void UpdateMoonPrices()
        {
            string SQL;
            int i;
            double[] Prices;

            if (MoonPricesUpdated)
            {
                Cursor = Cursors.WaitCursor;

                Prices = new double[(MoonTextBoxes.Count())];

                // Check the prices first
                var loopTo = MoonTextBoxes.Count() - 1;
                for (i = 1; i <= loopTo; i++)
                {
                    if (!Information.IsNumeric(MoonTextBoxes[i].Text))
                    {
                        Interaction.MsgBox("Invalid " + MoonLabels[i].Text + " Price", Constants.vbExclamation, Text);
                        MoonTextBoxes[i].Focus();
                        Cursor = Cursors.Default;
                        return;
                    }
                    else
                    {
                        Prices[i] = Conversions.ToDouble(MoonTextBoxes[i].Text);
                    }
                }

                // Update all the prices
                var loopTo1 = MoonTextBoxes.Count() - 1;
                for (i = 1; i <= loopTo1; i++)
                {
                    SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Prices[i] + ", PRICE_TYPE = 'User' WHERE ITEM_ID = " + Public_Variables.GetTypeID(MoonLabels[i].Text);
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                }

                Interaction.MsgBox("Prices Updated", Constants.vbInformation, Text);
                Cursor = Cursors.Default;
            }
            else
            {
                Interaction.MsgBox("No Prices were Updated", Constants.vbInformation, Text);
            }

            // Finally update the Program prices
            Public_Variables.UpdateProgramPrices();

        }

        // Updates all the prices if they are changed
        private void btnUpdateMoonMatPrices_Click(object sender, EventArgs e)
        {
            UpdateMoonPrices();
        }

        private void MoonTextBoxes_GotFocus(int index, ref EventArgs e)
        {
            MoonTextBoxes[index].SelectAll();
        }

        private void MoonTextBoxes_KeyPress(ref KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPriceChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        private void MoonTextBoxes_KeyDown(TextBox SentTextBox, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(SentTextBox, e);
            if (e.KeyCode == Keys.Enter)
            {
                UpdateMoonPrices();
            }
        }

        private void txtMoon1_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(1, ref e);
        }

        private void txtMoon1_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon1, e);
        }

        private void txtMoon1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon1_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon2_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(2, ref e);
        }

        private void txtMoon2_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon2, e);
        }

        private void txtMoon2_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon2_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon3_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(3, ref e);
        }

        private void txtMoon3_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon3, e);
        }

        private void txtMoon3_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon3_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon4_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(4, ref e);
        }

        private void txtMoon4_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon4, e);
        }

        private void txtMoon4_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon4_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon5_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(5, ref e);
        }

        private void txtMoon5_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon5, e);
        }

        private void txtMoon5_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon5_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon6_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(6, ref e);
        }

        private void txtMoon6_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon6, e);
        }

        private void txtMoon6_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon6_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon7_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(7, ref e);
        }

        private void txtMoon7_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon7, e);
        }

        private void txtMoon7_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon7_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon8_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(8, ref e);
        }

        private void txtMoon8_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon8, e);
        }

        private void txtMoon8_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon8_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon9_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(9, ref e);
        }

        private void txtMoon9_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon9, e);
        }

        private void txtMoon9_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon9_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon10_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(10, ref e);
        }

        private void txtMoon10_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon10, e);
        }

        private void txtMoon10_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon10_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void txtMoon11_GotFocus(object sender, EventArgs e)
        {
            MoonTextBoxes_GotFocus(11, ref e);
        }

        private void txtMoon11_KeyDown(object sender, KeyEventArgs e)
        {
            MoonTextBoxes_KeyDown(txtMoon11, e);
        }

        private void txtMoon11_KeyPress(object sender, KeyPressEventArgs e)
        {
            MoonTextBoxes_KeyPress(ref e);
        }

        private void txtMoon11_TextChanged(object sender, EventArgs e)
        {
            MoonPricesUpdated = true;
        }

        private void btnCloseMoonMats_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion

        // Functions and procedures to update via manual search
        #region Search Update Tab

        // Function fills the list with items as defined in the search box
        public void FillSearchGrid(string ItemText)
        {
            string SQL;
            SQLiteDataReader readerLookup;
            ListViewItem matList;

            // Clear old data
            lstPriceLookup.Items.Clear();
            lstPriceLookup.Update();

            SQL = "SELECT ITEM_NAME, PRICE FROM ITEM_PRICES WHERE ITEM_NAME LIKE '%" + Public_Variables.FormatDBString(ItemText) + "%'";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerLookup = Public_Variables.DBCommand.ExecuteReader();

            while (readerLookup.Read())
            {
                // Add the items to the list
                matList = lstPriceLookup.Items.Add(readerLookup.GetString(0));
                // The remaining columns are subitems  
                matList.SubItems.Add(Strings.FormatNumber(readerLookup.GetDouble(1), 2));

            }

            readerLookup.Close();
            readerLookup = null;
            Public_Variables.DBCommand = null;

        }

        // Updates price on the form
        private void UpdateItemPrices()
        {
            string SQL;

            // Check the price first
            if (!Information.IsNumeric(txtItemPriceUpdate.Text))
            {
                Interaction.MsgBox("Invalid Price", Constants.vbExclamation, Text);
                txtItemPriceUpdate.Focus();
                return;
            }

            // Make sure they selected an item
            if (string.IsNullOrEmpty(Strings.Trim(lblSelectedItem.Text)))
            {
                Interaction.MsgBox("You must select an Item", Constants.vbExclamation, Text);
                txtItemSearch.Focus();
                return;
            }

            // Update the price
            SQL = "UPDATE ITEM_PRICES_FACT SET PRICE = " + Conversions.ToDouble(txtItemPriceUpdate.Text) + ", PRICE_TYPE = 'User' WHERE ITEM_ID = " + Public_Variables.GetTypeID(lblSelectedItem.Text);
            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

            // Finally update the Program prices
            Public_Variables.UpdateProgramPrices();

            // Done
            Interaction.MsgBox("Price updated", Constants.vbInformation, Text);

            // Clear the price
            txtItemPriceUpdate.Text = "";
            lblSelectedItem.Text = "";

            // Select the search box
            txtItemSearch.SelectAll();
            txtItemSearch.Focus();

        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            FillSearchGrid(txtItemSearch.Text);
        }

        private void btnSearchClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        // Updates the price based on the manual search for the item
        private void btnSearchUpdate_Click(object sender, EventArgs e)
        {
            UpdateItemPrices();
        }

        private void txtItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtItemSearch, e);
            if (e.KeyCode == Keys.Enter)
            {
                FillSearchGrid(txtItemSearch.Text);
            }
        }

        private void lstPriceLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When you unselect a row, the indexes are cleared and will error if referenced, so check
            if (lstPriceLookup.SelectedItems.Count > 0)
            {
                lblSelectedItem.Text = lstPriceLookup.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void tabPrices_Click(object sender, EventArgs e)
        {
            if (tabPrices.SelectedTab.Text == "Minerals")
            {
                LoadMineralPrices();
            }
            else if (tabPrices.SelectedTab.Text == "Advanced Composites")
            {
                LoadMoonPrices();
            }
            else if (tabPrices.SelectedTab.Text == "Item Search")
            {
                txtItemSearch.Focus();
            }
        }

        private void lstPriceLookup_Click(object sender, EventArgs e)
        {
            txtItemPriceUpdate.Focus();
        }

        private void txtItemPriceUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            Public_Variables.ProcessCutCopyPasteSelect(txtItemPriceUpdate, e);
            if (e.KeyCode == Keys.Enter)
            {
                UpdateItemPrices();
            }
        }

        private void txtItemPriceUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers or backspace
            if (e.KeyChar != ControlChars.Back)
            {
                if (Public_Variables.allowedPriceChars.IndexOf(e.KeyChar) == -1)
                {
                    // Invalid Character
                    e.Handled = true;
                }
            }
        }

        #endregion

    }
}