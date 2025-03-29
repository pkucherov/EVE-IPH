using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmAddCharacter
    {

        public frmAddCharacter()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            chkManagePlanets.Visible = false; // Not in use

            // Always check all
            Public_Variables.ESIScopesString = "";
            chkReadAgentsResearch.Checked = true;
            chkReadAssets.Checked = true;
            chkReadBlueprints.Checked = true;
            chkReadCharacterJobs.Checked = true;
            chkReadCorporationAssets.Checked = true;
            chkReadCorporationBlueprints.Checked = true;
            chkReadCorporationJobs.Checked = true;
            chkReadCorporationMembership.Checked = true;
            chkReadStandings.Checked = true;
            chkReadStructures.Checked = true;
            chkReadStructureMarkets.Checked = true;
            // chkManagePlanets.Checked = True

            // Set the tool tips for api
            {
                var withBlock = ttAPI;
                withBlock.SetToolTip(chkReadAgentsResearch, "Reads a list of research agents' information for a character");
                withBlock.SetToolTip(chkReadAssets, "Reads a list of the character's assets");
                withBlock.SetToolTip(chkReadBlueprints, "Reads a list of blueprints the character owns");
                withBlock.SetToolTip(chkReadCharacterJobs, "Reads a list of the character's industry jobs");
                withBlock.SetToolTip(chkReadStandings, "Reads a list of character standings from agents, NPC corporations, and factions");

                withBlock.SetToolTip(chkReadCorporationAssets, "Reads a list of the corporation assets");
                withBlock.SetToolTip(chkReadCorporationBlueprints, "Reads a list of blueprints the corporation owns");
                withBlock.SetToolTip(chkReadCorporationJobs, "List industry jobs run by a corporation");
                withBlock.SetToolTip(chkReadCorporationMembership, "List of the current members a corporation and titles (for corp roles)");

                withBlock.SetToolTip(chkReadStructures, "Reads information about specific structures");
                withBlock.SetToolTip(chkReadStructureMarkets, "Reads market orders from a specific structure");

                withBlock.SetToolTip(chkManagePlanets, "Reads a list of all planetary colonies and layouts owned by a character");
            }

        }

        private void btnEVESSOLogin_Click(object sender, EventArgs e)
        {
            var ESIConnection = new ESI();
            var CharacterData = new SavedTokenData();
            long CharCorpID = 0L;

            Cursor = Cursors.WaitCursor;
            EnableDisableForm(false); // Disable until we return
            Application.DoEvents();

            // Strip the last space
            Public_Variables.ESIScopesString = Public_Variables.ESIScopesString.Substring(0, Strings.Len(Public_Variables.ESIScopesString) - 1);

            // Set the final scopes string - always needs skills
            Public_Variables.ESIScopesString = "esi-skills.read_skills.v1 " + Public_Variables.ESIScopesString;

            // Set the new character data first. This will load the data in the table or update it if they choose a character already loaded
            if (ESIConnection.SetCharacterData(false, ref CharacterData, "", false, true, ref CharCorpID))
            {

                // Refresh the token data to get new scopes list if they added/removed
                if (CharacterData.CharacterID != Public_Variables.DummyCharacterID & CharacterData.CharacterID > 0L)
                {
                    Public_Variables.SelectedCharacter.RefreshTokenData(CharacterData.CharacterID, CharCorpID);
                }

                // If they loaded a character for the first time, set it from Dummy to this character as the default
                if (Public_Variables.SelectedCharacter.ID == Public_Variables.DummyCharacterID)
                {
                    // See if only one other character exists in db (the one we just added)
                    SQLiteDataReader rsCheck;
                    Public_Variables.DBCommand = new SQLiteCommand("SELECT COUNT(*) FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> " + Public_Variables.DummyCharacterID, Public_Variables.EVEDB.DBREf());
                    rsCheck = Public_Variables.DBCommand.ExecuteReader();
                    rsCheck.Read();

                    if (rsCheck.GetInt32(0) == 1)
                    {
                        // They only have one other character in the db and the selected is dummy, so set this to the default
                        rsCheck.Close();
                        Public_Variables.DBCommand = new SQLiteCommand("SELECT CHARACTER_NAME FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> " + Public_Variables.DummyCharacterID, Public_Variables.EVEDB.DBREf());
                        rsCheck = Public_Variables.DBCommand.ExecuteReader();
                        rsCheck.Read();
                        Cursor = Cursors.WaitCursor;
                        Application.DoEvents();
                        Public_Variables.SetDefaultCharacter(rsCheck.GetString(0));
                        Cursor = Cursors.Default;
                        Application.DoEvents();
                    }
                }
                else
                {
                    Interaction.MsgBox("Character successfully added to IPH", Constants.vbInformation, Application.ProductName);
                }
            }
            // Didn't load, so show the re-enter info button
            else if (!Public_Variables.CancelESISSOLogin)
            {
                Interaction.MsgBox("The Character failed to load. Please check application registration information.");
            }

            Cursor = Cursors.Default;
            EnableDisableForm(true);
            Application.DoEvents();

            // Close the form - users will have to select what one to set as default
            Hide();

        }

        private void UpdateScopesString(string AppendString, bool AddString)
        {
            if (AddString)
            {
                Public_Variables.ESIScopesString += AppendString + " ";
            }
            else
            {
                // Need to remove the string, parse and remove, then rebuild
                string[] Scopes;

                Scopes = Public_Variables.ESIScopesString.Split(new char[] { ' ' });
                Public_Variables.ESIScopesString = ""; // Reset

                for (int i = 0, loopTo = Scopes.Count() - 1; i <= loopTo; i++)
                {
                    if ((Scopes[i] ?? "") != (AppendString ?? "") & !string.IsNullOrEmpty(Strings.Trim(Scopes[i])))
                    {
                        Public_Variables.ESIScopesString += Scopes[i] + " ";
                    }
                }
            }

        }

        private void chkReadStandings_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadStandings;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadAgentsResearch_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadAgentsResearch;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadCharacterJobs_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadCharacterJobs;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadAssets_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadAssets;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadBlueprints;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkManagePlanets_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkManagePlanets;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadCorporationMembership_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadCorporationMembership;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadCorporationJobs_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadCorporationJobs;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadCorporationAssets_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadCorporationAssets;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadCorporationBlueprints_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadCorporationBlueprints;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadStructures_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadStructures;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void chkReadStructureMarkets_CheckedChanged(object sender, EventArgs e)
        {
            {
                var withBlock = chkReadStructureMarkets;
                UpdateScopesString(withBlock.Text, withBlock.Checked);
            }
        }

        private void EnableDisableForm(bool Setting)
        {
            btnEVESSOLogin.Enabled = false;
            chkManagePlanets.Enabled = Setting;
            chkReadAgentsResearch.Enabled = Setting;
            chkReadAssets.Enabled = Setting;
            chkReadBlueprints.Enabled = Setting;
            chkReadCharacterJobs.Enabled = Setting;
            chkReadCorporationAssets.Enabled = Setting;
            chkReadCorporationBlueprints.Enabled = Setting;
            chkReadCorporationJobs.Enabled = Setting;
            chkReadCorporationMembership.Enabled = Setting;
            chkReadStandings.Enabled = Setting;
            chkReadStructures.Enabled = Setting;
            chkReadStructureMarkets.Enabled = Setting;
        }
    }
}