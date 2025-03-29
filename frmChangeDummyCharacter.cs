using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmChangeDummyCharacter
    {
        public frmChangeDummyCharacter()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveName();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChangeDummyCharacter_Shown(object sender, EventArgs e)
        {
            SQLiteDataReader rsData;

            Public_Variables.DBCommand = new SQLiteCommand("SELECT CHARACTER_NAME FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID = " + Public_Variables.DummyCharacterID.ToString(), Public_Variables.EVEDB.DBREf());
            rsData = Public_Variables.DBCommand.ExecuteReader();
            rsData.Read();

            lblCurrentName.Text = rsData.GetString(0);

            rsData.Close();

            txtName.Focus();

        }

        private void SaveName()
        {

            if (string.IsNullOrEmpty(Strings.Trim(txtName.Text)))
            {
                Interaction.MsgBox("You cannot enter a blank name.", Constants.vbInformation, Application.ProductName);
                return;
            }

            // Just save what they enter and put a asterisk on the end to singify it's a dummy account
            try
            {
                Public_Variables.EVEDB.ExecuteNonQuerySQL("UPDATE ESI_CHARACTER_DATA SET CHARACTER_NAME = '" + Public_Variables.FormatDBString(Strings.Trim(txtName.Text)) + "*' WHERE CHARACTER_ID = " + Public_Variables.DummyCharacterID.ToString());

                Interaction.MsgBox("Dummy Character Name updated.", Constants.vbInformation, Application.ProductName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("Could not save name. Error: " + ex.Message);
            }

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveName();
            }
        }
    }
}