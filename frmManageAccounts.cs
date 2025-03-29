using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmManageAccounts
    {

        private int ListColumnClicked;
        private SortOrder ListColumnSortOrder;

        public frmManageAccounts()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            ListColumnClicked = 0;
            ListColumnSortOrder = SortOrder.None;

            btnRefreshToken.Enabled = false;

        }

        private void lstAccounts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstAccounts;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ListColumnClicked, ref ListColumnSortOrder);
            lstAccounts = argRefListView;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmManageAccounts_Shown(object sender, EventArgs e)
        {
            LoadAccountGrid();
        }

        private void LoadAccountGrid()
        {
            SQLiteDataReader rsAccounts;
            string SQL;
            ListViewItem lstViewRow;
            string CharList = "";

            // Until there is a key able to set a default to, don't enable the select default button
            btnSelectDefaultChar.Enabled = false;

            Application.UseWaitCursor = true;

            SQL = "SELECT CHARACTER_ID, CHARACTER_NAME, CORPORATION_NAME, IS_DEFAULT, SCOPES, ACCESS_TOKEN, ACCESS_TOKEN_EXPIRE_DATE_TIME, TOKEN_TYPE, REFRESH_TOKEN, ECHD.CORPORATION_ID ";
            SQL += "FROM ESI_CHARACTER_DATA AS ECHD, ESI_CORPORATION_DATA AS ECRPD ";
            SQL += "WHERE ECHD.CORPORATION_ID = ECRPD.CORPORATION_ID ";
            SQL += "AND CHARACTER_ID <> " + Public_Variables.DummyCharacterID.ToString();

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsAccounts = Public_Variables.DBCommand.ExecuteReader();

            lstAccounts.Items.Clear();
            lstAccounts.BeginUpdate();

            while (rsAccounts.Read())
            {

                // Insert into table
                lstViewRow = new ListViewItem(rsAccounts.GetInt32(0).ToString()); // CHAR ID (Hidden)
                                                                                  // The remaining columns are subitems  
                lstViewRow.SubItems.Add(rsAccounts.GetString(1)); // NAME
                lstViewRow.SubItems.Add(rsAccounts.GetString(2)); // CORP NAME

                if (rsAccounts.GetInt32(3) != 0)
                {
                    lstViewRow.SubItems.Add("True");
                }
                else
                {
                    lstViewRow.SubItems.Add("False");
                }

                lstViewRow.SubItems.Add(rsAccounts.GetString(4)); // SCOPES (Hidden)
                lstViewRow.SubItems.Add(rsAccounts.GetString(5)); // Access Token (Hidden)
                lstViewRow.SubItems.Add(rsAccounts.GetString(8)); // Refresh Token (Hidden)
                lstViewRow.SubItems.Add(Convert.ToDateTime(rsAccounts.GetString(6)).ToString()); // Access Token expire date (Hidden)
                lstViewRow.SubItems.Add(rsAccounts.GetString(7)); // Token type
                lstViewRow.SubItems.Add(rsAccounts.GetInt64(9).ToString()); // Corporation ID

                lstAccounts.Items.Add(lstViewRow);

                CharList = "";

            }

            rsAccounts.Close();

            lstAccounts.EndUpdate();

            SQL = "SELECT COUNT(*) FROM ESI_CHARACTER_DATA";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsAccounts = Public_Variables.DBCommand.ExecuteReader();

            rsAccounts.Read();

            // Don't enable default setting if there aren't any new api keys
            if (Conversions.ToInteger(rsAccounts.GetValue(0)) == 0)
            {
                btnSelectDefaultChar.Enabled = false;
            }
            else
            {
                btnSelectDefaultChar.Enabled = true;
            }

            Application.UseWaitCursor = false;

        }

        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkDirector.Checked = false;
            chkFactoryManager.Checked = false;

            if (lstAccounts.SelectedItems.Count > 0)
            {
                // Load the scopes for the character (hidden in the list of the account)
                string ScopeList = lstAccounts.SelectedItems[0].SubItems[4].Text;

                LoadScopes(ScopeList);

                txtAccessToken.Text = lstAccounts.SelectedItems[0].SubItems[5].Text;
                txtAccessTokenExpDate.Text = lstAccounts.SelectedItems[0].SubItems[7].Text;
                txtRefreshToken.Text = lstAccounts.SelectedItems[0].SubItems[6].Text;
                txtCharacterID.Text = lstAccounts.SelectedItems[0].SubItems[0].Text;
                txtCorpID.Text = lstAccounts.SelectedItems[0].SubItems[9].Text;
                btnRefreshToken.Enabled = true;
                btnDeleteCharacter.Enabled = true;
                btnCopyAll.Enabled = true;

                // Get Director and Factory Manager roles.
                SQLiteDataReader rsRoles;
                string SQL = string.Format("SELECT ROLE FROM ESI_CORPORATION_ROLES WHERE CHARACTER_ID = {0} AND CORPORATION_ID = {1} AND ROLE IN ('Director','Factory_Manager')", Conversions.ToLong(txtCharacterID.Text), Conversions.ToLong(txtCorpID.Text));
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsRoles = Public_Variables.DBCommand.ExecuteReader();

                while (rsRoles.Read())
                {
                    switch (rsRoles.GetString(0) ?? "")
                    {
                        case "Director":
                            {
                                chkDirector.Checked = true;
                                break;
                            }
                        case "Factory_Manager":
                            {
                                chkFactoryManager.Checked = true;
                                break;
                            }
                    }
                }

                rsRoles.Close();
            }

            else
            {
                lstScopes.Items.Clear();
                txtAccessToken.Text = "";
                txtCharacterID.Text = "";
                txtAccessTokenExpDate.Text = "";
                txtAccessTokenExpDate.Text = "";
                btnRefreshToken.Enabled = false;
                btnDeleteCharacter.Enabled = false;
                btnCopyAll.Enabled = false;
            }
        }

        private void LoadScopes(string ScopeList)
        {
            // Parse it for entry
            string[] ParsedScopes;

            ParsedScopes = ScopeList.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Clear the list
            lstScopes.Items.Clear();

            foreach (var Scope in ParsedScopes)
                lstScopes.Items.Add(Scope);

        }

        private void btnDeleteKey_Click(object sender, EventArgs e)
        {
            string SQL;

            if (lstAccounts.SelectedItems.Count > 0)
            {
                int CharacterID = Conversions.ToInteger(lstAccounts.SelectedItems[0].SubItems[0].Text);

                Public_Variables.EVEDB.BeginSQLiteTransaction();

                // Delete all the information associated with this key FIX (SKILLS, STANDINGS, ASSETS, JOBS, AGENTS)
                SQL = "DELETE FROM CHARACTER_SKILLS WHERE CHARACTER_ID = " + CharacterID.ToString();
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                SQL = "DELETE FROM CHARACTER_STANDINGS WHERE CHARACTER_ID = " + CharacterID.ToString();

                SQL = "DELETE FROM CURRENT_RESEARCH_AGENTS WHERE CHARACTER_ID = " + CharacterID.ToString();
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                SQL = "DELETE FROM ASSETS WHERE ID = " + CharacterID.ToString();
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                SQL = "DELETE FROM INDUSTRY_JOBS WHERE installerID = " + CharacterID.ToString();
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                SQL = "DELETE FROM OWNED_BLUEPRINTS WHERE USER_ID = " + CharacterID.ToString();
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                SQL = "DELETE FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID = " + CharacterID.ToString();
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                // Finally see if we have more accounts that are not the dummy - if only the dummy exists, set it to default and load it
                SQL = "SELECT COUNT(*) FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> " + Public_Variables.DummyCharacterID.ToString();
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());

                if (Conversions.ToInteger(Public_Variables.DBCommand.ExecuteScalar()) == 0)
                {
                    // Only the dummy is loaded, so set it to default
                    Public_Variables.EVEDB.ExecuteNonQuerySQL("UPDATE ESI_CHARACTER_DATA SET IS_DEFAULT = " + Public_Variables.DefaultCharacterCode.ToString() + " WHERE CHARACTER_ID = " + Public_Variables.DummyCharacterID.ToString());
                }

                Public_Variables.EVEDB.CommitSQLiteTransaction();

                // Reload the characters - this will do the default selection, etc
                Public_Variables.LoadCharacter(SettingsVariables.UserApplicationSettings.LoadAssetsonStartup, SettingsVariables.UserApplicationSettings.LoadBPsonStartup);

                Interaction.MsgBox("Character Deleted", Constants.vbInformation, Application.ProductName);

            }

            // Reload accounts
            LoadAccountGrid();

            Cursor = Cursors.Default;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var fLoadAPI = new frmAddCharacter();
            fLoadAPI.ShowDialog();

            lstAccounts.Items.Clear();

            My.MyProject.Forms.frmMain.LoadCharacterNamesinMenu();

            // Reload accounts
            LoadAccountGrid();

        }

        private void btnSelectDefaultChar_Click(object sender, EventArgs e)
        {
            var fDefault = new frmSetCharacterDefault();

            fDefault.ShowDialog();

            LoadAccountGrid();

        }

        private void lstAccounts_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lstAccounts.SelectedItems.Count == 0)
            {
                btnDeleteCharacter.Enabled = false;
            }
            else
            {
                btnDeleteCharacter.Enabled = true;
            }
        }

        // For the selected character, refresh the token data again without regard to the cache date
        private void btnRefreshToken_Click(object sender, EventArgs e)
        {
            if (lstAccounts.SelectedItems.Count > 0)
            {
                // Get the token data from the grid since they can't edit them anyway
                var CharacterTokenData = new SavedTokenData();
                var ESIData = new ESI();

                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                CharacterTokenData.CharacterID = Conversions.ToLong(lstAccounts.SelectedItems[0].SubItems[0].Text);
                CharacterTokenData.Scopes = lstAccounts.SelectedItems[0].SubItems[4].Text;
                CharacterTokenData.AccessToken = lstAccounts.SelectedItems[0].SubItems[5].Text;
                CharacterTokenData.TokenExpiration = Conversions.ToDate(lstAccounts.SelectedItems[0].SubItems[7].Text);
                CharacterTokenData.TokenType = lstAccounts.SelectedItems[0].SubItems[8].Text;
                CharacterTokenData.RefreshToken = lstAccounts.SelectedItems[0].SubItems[6].Text;

                long argCorporationID = -1L;
                if (ESIData.SetCharacterData(true, ref CharacterTokenData, "", true, CorporationID: ref argCorporationID))
                {
                    // Need to reload the data and set access flags based on scopes
                    Application.UseWaitCursor = true;
                    int SelectedIndex = lstAccounts.SelectedIndices[0];
                    lstAccounts.SelectedIndices.Clear();
                    txtAccessToken.Text = "";
                    txtRefreshToken.Text = "";
                    txtAccessTokenExpDate.Text = "";
                    lstScopes.Items.Clear();
                    lstAccounts.Enabled = false;
                    lstScopes.Enabled = false;
                    Application.DoEvents();
                    Public_Variables.SelectedCharacter.LoadCharacterData(ref CharacterTokenData, false, false);
                    LoadAccountGrid();
                    Interaction.MsgBox("Token Data updated.", Constants.vbInformation, Application.ProductName);
                    Application.UseWaitCursor = false;
                    lstAccounts.Enabled = true;
                    lstScopes.Enabled = true;
                    lstAccounts.Items[SelectedIndex].Selected = true;
                    Cursor = Cursors.Default;
                    Application.DoEvents();
                }
                else
                {
                    Cursor = Cursors.Default;
                    Application.DoEvents();
                    Interaction.MsgBox("Unable to update Token Data.", Constants.vbInformation, Application.ProductName);
                }

            }
        }

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            var ClipboardData = new DataObject();
            string OutputText = "";

            OutputText = "Token Data for " + lstAccounts.SelectedItems[0].SubItems[1].Text + Constants.vbCrLf;
            OutputText += "Access Token: " + lstAccounts.SelectedItems[0].SubItems[5].Text + Constants.vbCrLf;
            OutputText += "Refresh Token: " + lstAccounts.SelectedItems[0].SubItems[6].Text + Constants.vbCrLf;
            OutputText += "Access Token Expires: " + lstAccounts.SelectedItems[0].SubItems[7].Text + Constants.vbCrLf + Constants.vbCrLf;
            OutputText += "Selected Scopes: " + lstAccounts.SelectedItems[0].SubItems[4].Text.Replace(" ", " " + Constants.vbCrLf);

            // Paste to clipboard
            Public_Variables.CopyTextToClipboard(OutputText);

        }

        private void btnCopyCharacterID_Click(object sender, EventArgs e)
        {
            // Paste to clipboard
            Public_Variables.CopyTextToClipboard(txtCharacterID.Text);
        }

        private void btnCopyCorpID_Click(object sender, EventArgs e)
        {
            // Paste to clipboard
            Public_Variables.CopyTextToClipboard(txtCorpID.Text);
        }

        private void btnCopyAccesToken_Click(object sender, EventArgs e)
        {
            // Paste to clipboard
            Public_Variables.CopyTextToClipboard(txtAccessToken.Text);
        }

        private void txtRefreshToken_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.C:
                    {
                        if (e.Modifiers == Keys.Control)
                        {
                            Application.DoEvents();
                        }
                        else
                        {
                            e.Handled = true;
                        }

                        break;
                    }

                default:
                    {
                        e.Handled = true;
                        break;
                    }
            }
        }

        private void txtAccessTokenExpDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.C:
                    {
                        if (e.Modifiers == Keys.Control)
                        {
                            Application.DoEvents();
                        }
                        else
                        {
                            e.Handled = true;
                        }

                        break;
                    }

                default:
                    {
                        e.Handled = true;
                        break;
                    }
            }
        }

        private void txtAccessToken_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.C:
                    {
                        if (e.Modifiers == Keys.Control)
                        {
                            Application.DoEvents();
                        }
                        else
                        {
                            e.Handled = true;
                        }

                        break;
                    }

                default:
                    {
                        e.Handled = true;
                        break;
                    }
            }
        }

    }
}