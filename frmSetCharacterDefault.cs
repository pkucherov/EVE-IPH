using System;
// Form just allows a user to select a default character

using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmSetCharacterDefault
    {

        public frmSetCharacterDefault()
        {

            // This call is required by the designer.
            InitializeComponent();

            Public_Variables.CancelESISSOLogin = false;

            // Add any initialization after the InitializeComponent() call.
            UpdateCharacterList();

        }

        // Updates the character list with a default character
        private void btnSelectDefault_Click(object sender, EventArgs e)
        {
            string SelectedCharacterName = "";
            int i = 0;
            ErrObject ErrorData = null;

            if (chkListDefaultChar.CheckedItems.Count == 0)
            {
                Interaction.MsgBox("Please select a default character", Constants.vbExclamation, Application.ProductName);
                return;
            }

            // Should only be one checked
            foreach (var item in chkListDefaultChar.CheckedItems)
                SelectedCharacterName = item.ToString();

            Cursor = Cursors.WaitCursor;
            Public_Variables.SetDefaultCharacter(SelectedCharacterName);
            Cursor = Cursors.Default;
            Close();

        }

        private void chkListDefaultChar_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx;

            if (e.NewValue == CheckState.Checked)
            {
                // Uncheck all others not sent
                var loopTo = chkListDefaultChar.Items.Count - 1;
                for (idx = 0; idx <= loopTo; idx++)
                {
                    if (idx != e.Index)
                    {
                        chkListDefaultChar.SetItemChecked(idx, false);
                    }
                }
            }

        }

        // Checks if the user selected a default or not. If not, verifies that they don't want to set a default and want to go with dummy
        private void btnCancel_Click(object sender, EventArgs e)
        {

            Public_Variables.CancelESISSOLogin = true;
            Hide();

        }

        private void frmSetCharacterDefault_Shown(object sender, EventArgs e)
        {
            Activate();
        }

        // Update the list with the current loaded characters in the table
        private void UpdateCharacterList()
        {
            SQLiteDataReader readerCharacters;
            string SQL;
            long numChars;
            int i = 0;

            // Load up the grid with characters on this computer
            Public_Variables.DefaultCharSelected = false;

            chkListDefaultChar.Items.Clear();

            SQL = "SELECT COUNT(*) FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> {0}";

            Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, Public_Variables.DummyCharacterID), Public_Variables.EVEDB.DBREf());
            numChars = Conversions.ToLong(Public_Variables.DBCommand.ExecuteScalar());

            SQL = "SELECT CHARACTER_NAME, IS_DEFAULT FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> {0}";

            Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, Public_Variables.DummyCharacterID), Public_Variables.EVEDB.DBREf());
            readerCharacters = Public_Variables.DBCommand.ExecuteReader();

            while (readerCharacters.Read())
            {
                chkListDefaultChar.Items.Add(readerCharacters.GetString(0));
                // If there is a default already, check it
                if (Conversions.ToInteger(readerCharacters.GetValue(1)) != 0)
                {
                    chkListDefaultChar.SetItemChecked(i, true);
                }
                i += 1;
            }

            // If only one character, then check it
            if (numChars == 1L)
            {
                chkListDefaultChar.SetItemChecked(0, true);
            }

            if (numChars >= 1L)
            {
                btnSelectDefault.Enabled = true;
            }
            else
            {
                // Disable select default button until they load one up
                btnSelectDefault.Enabled = false;
            }

            readerCharacters.Close();
            readerCharacters = null;
            Public_Variables.DBCommand = null;

        }

        ~frmSetCharacterDefault()
        {
            Public_Variables.CancelESISSOLogin = false; // Reset on close
        }
    }
}