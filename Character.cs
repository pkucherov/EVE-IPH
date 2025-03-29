using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class Character
    {
        public long ID; // PK
        public string Name;
        public DateTime DOB;
        public string Gender;
        public int RaceID;
        public int BloodLineID;
        public int AncestryLineID;
        public string Descripton;

        // For ESI access, etc.
        public SavedTokenData CharacterTokenData;

        public bool OverrideSkills;
        public bool IsDefault;

        // Skill Tree - Required Scope
        public EVESkillList Skills;
        // Standings
        public bool StandingsAccess;
        public EVENPCStandings Standings; // Base Standings
                                          // Industry jobs
        public bool IndustryJobsAccess;
        public EVEIndustryJobs Jobs;
        // Research agents
        public bool ResearchAgentAccess;
        public EVEResearchAgents DatacoreAgents;
        // Assets
        public bool AssetsAccess;
        public EVEAssets Assets;
        // Blueprints
        public bool BlueprintsAccess;
        public EVEBlueprints Blueprints;
        // Structures
        public bool PublicStructuresAccess;
        public bool StructureMarketsAccess;

        // For maximum production and laboratory lines
        public int MaximumProductionLines;
        public int MaximumLaboratoryLines;

        // All corporation data stored here (assets, jobs, etc)
        public Corporation CharacterCorporation;

        public Character()
        {
            ID = 0L;
            Name = "";
            DOB = Public_Variables.NoDate;
            RaceID = 0;
            BloodLineID = 0;
            AncestryLineID = 0;
            Descripton = "";

            CharacterTokenData = new SavedTokenData();

            // To store the scope access they give us when registering
            StandingsAccess = false;
            AssetsAccess = false;
            IndustryJobsAccess = false;
            ResearchAgentAccess = false;
            BlueprintsAccess = false;
            PublicStructuresAccess = false;
            StructureMarketsAccess = false;

            Skills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
            Standings = new EVENPCStandings();
            Jobs = new EVEIndustryJobs();
            DatacoreAgents = new EVEResearchAgents();
            Assets = new EVEAssets();

            // Corporation Data for this character
            CharacterCorporation = new Corporation();

        }

        // Saves the dummy character for the program
        public TriState LoadDummyCharacter(bool IgnoreMessages, bool ReloadDummy = false)
        {
            var response = default(int);

            if (!IgnoreMessages)
            {
                response = (int)Interaction.MsgBox("If you do not load a character many features will not be available to you. Do you want to continue without loading a character?", Constants.vbYesNo, Application.ProductName);
            }

            if (response == (int)Constants.vbYes | IgnoreMessages)
            {
                string SQL;
                SQLiteDataReader rsCheck;

                SQL = string.Format("SELECT CHARACTER_NAME FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID = {0}", Public_Variables.DummyCharacterID.ToString());
                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsCheck = Public_Variables.DBCommand.ExecuteReader();

                // Double check to make sure the record doesn't already exist - user could update skills, etc for a dummy and don't want to overwrite, or if we want to reload
                if (!rsCheck.HasRows | ReloadDummy)
                {
                    // Now insert this data in the DB for using all the time and set to default"yyyy-MM-dd HH:mm:ss" since it doesn't exist
                    ID = Public_Variables.DummyCharacterID;
                    if (rsCheck.HasRows)
                    {
                        // Load the old name if they set it already and this is a reload
                        rsCheck.Read();
                        Name = rsCheck.GetString(0);
                    }
                    else
                    {
                        Name = "Dummy Character";
                    }

                    DOB = Public_Variables.NoDate;
                    Gender = Public_Variables.Male;
                    RaceID = 1;
                    BloodLineID = 8;
                    AncestryLineID = 9;
                    Descripton = Public_Variables.None;

                    CharacterTokenData.CharacterID = ID;
                    CharacterTokenData.AccessToken = "No Token";
                    CharacterTokenData.TokenExpiration = Public_Variables.NoExpiry;
                    CharacterTokenData.TokenType = Public_Variables.None;
                    CharacterTokenData.RefreshToken = "No Token";
                    CharacterTokenData.Scopes = "No Scopes";

                    string NoExpireDate = Strings.Format(Public_Variables.NoExpiry, Public_Variables.SQLiteDateFormat);

                    if (!rsCheck.HasRows)
                    {
                        {
                            ref var withBlock = ref CharacterTokenData;
                            SQL = "INSERT INTO ESI_CHARACTER_DATA VALUES ({0},'{1}',{2},'{3}','{4}',{5},{6},{7},'{8}','{9}','{10}','{11}','{12}','{13}',{14},'{15}','{16}','{17}','{18}','{19}','{20}','{21}',{22})";
                            SQL = string.Format(SQL, ID, Name, Public_Variables.DummyCorporationID, Strings.Format(DOB, Public_Variables.SQLiteDateFormat), Gender, RaceID, BloodLineID, AncestryLineID, Descripton, withBlock.AccessToken, Strings.Format(withBlock.TokenExpiration, Public_Variables.SQLiteDateFormat), withBlock.TokenType, withBlock.RefreshToken, withBlock.Scopes, 0, NoExpireDate, NoExpireDate, NoExpireDate, NoExpireDate, NoExpireDate, NoExpireDate, NoExpireDate, Public_Variables.DefaultCharacterCode); // Dummy is default
                        }
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    }

                    rsCheck.Close();

                    // Load dummy corp
                    CharacterCorporation = new Corporation();
                    CharacterCorporation.LoadDummyCorporationData();

                    // Load the skills depending on settings
                    if (SettingsVariables.UserApplicationSettings.LoadMaxAlphaSkills)
                    {
                        Skills.LoadMaxAlphaSkills();
                    }
                    else
                    {
                        Skills.LoadDummySkills();
                    }

                    // No standings
                    Standings = new EVENPCStandings();

                    // No agents
                    DatacoreAgents = new EVEResearchAgents();

                    // No Assets
                    Assets = new EVEAssets();

                    // No Jobs
                    Jobs = new EVEIndustryJobs();
                }

                else // There is a dummy already in the DB, so just set it to default and load like a normal char
                {
                    SQL = "UPDATE ESI_CHARACTER_DATA SET IS_DEFAULT = {0} WHERE CHARACTER_ID = {1}";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(SQL, Public_Variables.DefaultCharacterCode.ToString(), Public_Variables.DummyCharacterID.ToString()));
                    // Reset any others if there
                    SQL = "UPDATE ESI_CHARACTER_DATA SET IS_DEFAULT = 0 WHERE CHARACTER_ID <> {0}";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format(SQL, Public_Variables.DummyCharacterID.ToString()));
                    LoadDefaultCharacter(false, false, true);
                }
            }



            return TriState.UseDefault;

        }

        // Sets the default character for the program if no character ID sent, else it returns the character ID. If we can't find it in DB, then return false
        public bool LoadDefaultCharacter(bool LoadBPs = false, bool LoadAssets = false, bool LoadingDummy = false)
        {
            SQLiteDataReader rsCharacter;
            string SQL;

            // See if we have a character ID loaded
            SQL = "SELECT CHARACTER_ID FROM ESI_CHARACTER_DATA WHERE IS_DEFAULT <> 0";
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsCharacter = Public_Variables.DBCommand.ExecuteReader();

            if (rsCharacter.Read())
            {
                // Set the base data, character ID and access token data
                ID = rsCharacter.GetInt64(0);
                CharacterTokenData.CharacterID = ID;
                rsCharacter.Close();

                // Get the latest data for this character, update token through ref
                return LoadCharacterData(ref CharacterTokenData, LoadBPs, LoadAssets);
            }

            else // No record in DB
            {
                rsCharacter.Close();
                return false;
            }

        }

        // Load the latest data for the character sent or the default if no character sent from the DB - users may not want to load bps or assets 
        public bool LoadCharacterData(ref SavedTokenData TokenData, bool LoadBPs, bool LoadAssets, bool IndustryJobsUpdate = false)
        {
            SQLiteDataReader readerCharacter;
            string SQL;

            SQL = "SELECT CHARACTER_ID, CHARACTER_NAME, ";
            SQL += "CORPORATION_ID, BIRTHDAY, GENDER, RACE_ID, BLOODLINE_ID, ANCESTRY_ID, DESCRIPTION, ";
            SQL += "SCOPES, ACCESS_TOKEN, ACCESS_TOKEN_EXPIRE_DATE_TIME, TOKEN_TYPE, REFRESH_TOKEN, OVERRIDE_SKILLS, IS_DEFAULT ";
            SQL += "FROM ESI_CHARACTER_DATA ";
            SQL += "WHERE CHARACTER_ID = " + TokenData.CharacterID.ToString() + " ";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerCharacter = Public_Variables.DBCommand.ExecuteReader();

            if (readerCharacter.Read())
            {
                // Initialize the different character data classes
                Jobs = new EVEIndustryJobs();
                Standings = new EVENPCStandings();
                DatacoreAgents = new EVEResearchAgents();
                Blueprints = new EVEBlueprints();
                Assets = new EVEAssets(Public_Variables.ScanType.Personal);

                // Query the character data and store
                ID = readerCharacter.GetInt64(0);
                Name = readerCharacter.GetString(1);
                DOB = Conversions.ToDate(readerCharacter.GetString(3));
                Gender = readerCharacter.GetString(4);
                RaceID = readerCharacter.GetInt32(5);
                BloodLineID = readerCharacter.GetInt32(6);
                AncestryLineID = readerCharacter.GetInt32(7);
                Descripton = readerCharacter.GetString(8);

                // For ESI access, etc.
                CharacterTokenData.CharacterID = ID;
                CharacterTokenData.Scopes = readerCharacter.GetString(9);
                CharacterTokenData.AccessToken = readerCharacter.GetString(10);
                CharacterTokenData.TokenExpiration = Conversions.ToDate(readerCharacter.GetString(11));
                CharacterTokenData.TokenType = readerCharacter.GetString(12);
                CharacterTokenData.RefreshToken = readerCharacter.GetString(13);

                // Refresh the character data first
                if (ID != Public_Variables.DummyCharacterID)
                {
                    var TempESI = new ESI();
                    // Only ignore the cache date if we aren't updating industry jobs
                    long argCorporationID = -1L;
                    if (TempESI.SetCharacterData(false, ref CharacterTokenData, CorporationID: ref argCorporationID))
                    {
                        CharacterCorporation = new Corporation();
                        CharacterCorporation.LoadCorporationData(readerCharacter.GetInt64(2), CharacterTokenData, LoadAssets, LoadBPs);

                        SettingsVariables.UserApplicationSettings.AllowSkillOverride = Conversions.ToBoolean(readerCharacter.GetInt32(14));
                        IsDefault = Conversions.ToBoolean(readerCharacter.GetInt32(15));
                    }
                    else
                    {
                        // Check the error that caused this not to update
                        if (Public_Variables.ESIErrorHandler.ErrorResponse.Contains("Token missing/expired"))
                        {
                            // The refresh token expired - 30 days of no use
                            Interaction.MsgBox("Your refresh token has expired. To use updated account information you must update your tokens through re-authorizing them in Manage Accounts under the File Menu.", Constants.vbInformation, Application.ProductName);
                        }
                        else if (Public_Variables.ESIErrorHandler.ErrorResponse.Contains("token"))
                        {
                            // They have some issue with their token or log
                            Interaction.MsgBox("IPH is unable to refresh your character data - " + Public_Variables.ESIErrorHandler.ErrorResponse + Constants.vbCrLf + Constants.vbCrLf + "Please recheck your registration information and try again.", Constants.vbInformation, Application.ProductName);
                        }
                        // Now leave since everything below will fail
                        return true;
                    }

                }

                readerCharacter.Close();

                // Load the character skills - Reset first
                Skills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
                Skills.LoadCharacterSkills(ID, CharacterTokenData);

                if (!(Public_Variables.SelectedCharacter.Skills == null)) // 3387 mass production, 24625 adv mass production, 3406 laboratory efficiency, 24524 adv laboratory operation
                {
                    MaximumProductionLines = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3387L) + Public_Variables.SelectedCharacter.Skills.GetSkillLevel(24625L) + 1;
                    MaximumLaboratoryLines = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(3406L) + Public_Variables.SelectedCharacter.Skills.GetSkillLevel(24624L) + 1;
                }
                else
                {
                    MaximumProductionLines = 1;
                    MaximumLaboratoryLines = 1;
                }

                // Load the character's industry jobs
                if (CharacterTokenData.Scopes.Contains(ESI.ESICharacterIndustryJobsScope))
                {
                    IndustryJobsAccess = true;
                    Jobs.UpdateIndustryJobs(ID, CharacterTokenData, Public_Variables.ScanType.Personal);
                }

                if (IndustryJobsUpdate)
                {
                    // Only refresh skills and industry jobs for update calls from industry jobs
                    return true;
                }

                // Load the standings for this character
                if (CharacterTokenData.Scopes.Contains(ESI.ESICharacterStandingsScope))
                {
                    StandingsAccess = true;
                    Standings.LoadCharacterStandings(ID, CharacterTokenData);
                }

                // Load the character's research agents
                if (CharacterTokenData.Scopes.Contains(ESI.ESICharacterResearchAgentsScope))
                {
                    ResearchAgentAccess = true;
                    DatacoreAgents.LoadResearchAgents(ID, CharacterTokenData);
                }

                // Load the Blueprints but don't load if they don't have selected
                if (CharacterTokenData.Scopes.Contains(ESI.ESICharacterBlueprintsScope))
                {
                    BlueprintsAccess = true;
                    if (LoadBPs)
                    {
                        Blueprints.LoadBlueprints(ID, CharacterTokenData, Public_Variables.ScanType.Personal, LoadBPs);
                    }
                }

                // Load in the assets unless they don't want to update
                if (CharacterTokenData.Scopes.Contains(ESI.ESICharacterAssetScope))
                {
                    AssetsAccess = true;
                    if (LoadAssets)
                    {
                        Assets.LoadAssets(ID, CharacterTokenData, LoadAssets);
                    }
                }

                // Set the two structure tags
                if (CharacterTokenData.Scopes.Contains(ESI.ESIUniverseStructuresScope))
                {
                    PublicStructuresAccess = true;
                }
                if (CharacterTokenData.Scopes.Contains(ESI.ESIStructureMarketsScope))
                {
                    StructureMarketsAccess = true;
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public EVEIndustryJobs GetIndustryJobs()
        {
            return Jobs;
        }

        public EVEResearchAgents GetResearchAgents()
        {
            return DatacoreAgents;
        }

        public EVEAssets GetAssets()
        {
            return Assets;
        }

        public EVEBlueprints GetBlueprints()
        {
            return Blueprints;
        }

        public void RefreshTokenData(long CharID, long CorpID)
        {
            // Refresh the character token data if it's been updated
            string SQL;
            SQLiteDataReader rsToken;

            SQL = "SELECT ACCESS_TOKEN, ACCESS_TOKEN_EXPIRE_DATE_TIME, REFRESH_TOKEN, TOKEN_TYPE, SCOPES FROM ESI_CHARACTER_DATA ";
            SQL += "WHERE CHARACTER_ID = " + CharID.ToString();
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsToken = Public_Variables.DBCommand.ExecuteReader();

            if (rsToken.Read())
            {
                CharacterTokenData.CharacterID = CharID;
                CharacterTokenData.AccessToken = rsToken.GetString(0);
                CharacterTokenData.TokenExpiration = Conversions.ToDate(rsToken.GetString(1));
                CharacterTokenData.RefreshToken = rsToken.GetString(2);
                CharacterTokenData.TokenType = rsToken.GetString(3);
                CharacterTokenData.Scopes = rsToken.GetString(4);
            }

            rsToken.Close();

            // Reset the corporation data to set the role flags - set reset data flag to false and don't reload jobs, bps, and assets
            CharacterCorporation.LoadCorporationData(CorpID, CharacterTokenData, false, false, false);
            // Update roles as well
            CharacterCorporation.GetCorporationRoles(CorpID, CharacterTokenData);

        }

    }
}