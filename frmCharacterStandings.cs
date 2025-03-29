using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmCharacterStandings
    {

        public frmCharacterStandings()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            lstStandings.Columns.Add("NPC Type", 75, HorizontalAlignment.Left);
            lstStandings.Columns.Add("NPC Name", 184, HorizontalAlignment.Left);
            lstStandings.Columns.Add("Standing", 70, HorizontalAlignment.Right);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        // Load the skills
        private void frmCharacterStandings_Shown(object sender, EventArgs e)
        {
            Refresh();
            Application.DoEvents();

            lblCharacterName.Text = Public_Variables.SelectedCharacter.Name;

            LoadStandings();

        }

        private void LoadStandings()
        {
            string SQL;
            SQLiteDataReader readerStandings;

            ListViewItem lstViewRow;

            SQL = "SELECT NPC_TYPE, NPC_NAME, STANDING FROM CHARACTER_STANDINGS ";
            SQL += "WHERE CHARACTER_ID = " + Public_Variables.SelectedCharacter.ID + " ";
            if (rbtnNegative.Checked)
            {
                SQL += "AND STANDING < 0 ";
            }
            else if (rbtnPostive.Checked)
            {
                SQL += "AND STANDING >= 0 ";
            }

            if (rbtnSortName.Checked)
            {
                SQL += "ORDER BY NPC_TYPE DESC, NPC_NAME";
            }
            else if (rbtnSortStanding.Checked)
            {
                SQL += "ORDER BY NPC_TYPE DESC, STANDING DESC";
            }

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerStandings = Public_Variables.DBCommand.ExecuteReader();

            if (readerStandings.HasRows)
            {
                lstStandings.BeginUpdate();
                lstStandings.Items.Clear();

                while (readerStandings.Read())
                {
                    Application.DoEvents();

                    lstViewRow = new ListViewItem(readerStandings.GetString(0));
                    // The remaining columns are subitems  
                    lstViewRow.SubItems.Add(readerStandings.GetString(1));
                    lstViewRow.SubItems.Add(Strings.FormatNumber(readerStandings.GetDouble(2), 2));
                    lstStandings.Items.Add(lstViewRow);
                }

                lstStandings.EndUpdate();
            }

            readerStandings.Close();
            readerStandings = null;
            Public_Variables.DBCommand = null;

        }

        private void rbtnPostive_CheckedChanged(object sender, EventArgs e)
        {
            LoadStandings();
        }

        private void rbtnNegative_CheckedChanged(object sender, EventArgs e)
        {
            LoadStandings();
        }

        private void rbtnBoth_CheckedChanged(object sender, EventArgs e)
        {
            LoadStandings();
        }

        private void rbtnSortName_CheckedChanged(object sender, EventArgs e)
        {
            LoadStandings();
        }

        private void rbtnSortStanding_CheckedChanged(object sender, EventArgs e)
        {
            LoadStandings();
        }
    }
}