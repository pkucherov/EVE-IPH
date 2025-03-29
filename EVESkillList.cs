using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class EVESkillList
    {

        private List<EVESkill> Skills;

        private EVESkill SkillToFind;
        protected bool CheckLevelofSkilltoFind;

        private bool UseActiveSkillType;

        public EVESkillList(bool UseActiveSkill)
        {
            Skills = new List<EVESkill>();
            SkillToFind = null;
            CheckLevelofSkilltoFind = false;
            UseActiveSkillType = UseActiveSkill;
        }

        // Loads all character skills into the local object
        public void LoadCharacterSkills(long ID, SavedTokenData CharacterTokenData, bool LoadAllSkillsforOverride = false, string SkillNameFilter = "")
        {
            string SQL;
            SQLiteDataReader rsData;

            // First, update the skills
            if (ID != Public_Variables.DummyCharacterID)
            {
                UpdateCharacterSkills(ID, CharacterTokenData);
            }

            Skills = new List<EVESkill>();

            // Get all skills and set skill to 0 if they don't have it
            SQL = "SELECT SKILLS.SKILL_TYPE_ID,";
            SQL += "CASE WHEN CHAR_SKILLS.TRAINED_SKILL_LEVEL IS NULL THEN 0 ELSE CHAR_SKILLS.TRAINED_SKILL_LEVEL END AS TRAINED_SKILL_LEVEL,";
            SQL += "CASE WHEN CHAR_SKILLS.ACTIVE_SKILL_LEVEL IS NULL THEN 0 ELSE CHAR_SKILLS.ACTIVE_SKILL_LEVEL END AS ACTIVE_SKILL_LEVEL,";
            SQL += "CASE WHEN CHAR_SKILLS.SKILL_POINTS IS NULL THEN 0 ELSE CHAR_SKILLS.SKILL_POINTS END AS SKILL_POINTS,";
            SQL += "CASE WHEN CHAR_SKILLS.OVERRIDE_SKILL IS NULL THEN 0 ELSE CHAR_SKILLS.OVERRIDE_SKILL END AS OVERRIDE_SKILL,";
            SQL += "CASE WHEN CHAR_SKILLS.OVERRIDE_LEVEL IS NULL THEN 0 ELSE CHAR_SKILLS.OVERRIDE_LEVEL END AS OVERRIDE_LEVEL ";
            SQL += "FROM SKILLS LEFT OUTER JOIN ";
            SQL += "(SELECT * FROM CHARACTER_SKILLS WHERE CHARACTER_SKILLS.CHARACTER_ID=" + ID + ") AS CHAR_SKILLS ";
            SQL += "ON (SKILLS.SKILL_TYPE_ID = CHAR_SKILLS.SKILL_TYPE_ID) ";
            if (!string.IsNullOrEmpty(SkillNameFilter))
            {
                SQL += " WHERE SKILLS.SKILL_TYPE_ID IN (SELECT SKILL_TYPE_ID FROM SKILLS WHERE SKILL_NAME LIKE '%" + Public_Variables.FormatDBString(SkillNameFilter) + "%') ";
            }
            SQL += "ORDER BY SKILLS.SKILL_GROUP, SKILLS.SKILL_NAME ";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsData = Public_Variables.DBCommand.ExecuteReader();

            int SelectedSkillLevel = 0;

            while (rsData.Read())
            {
                SelectedSkillLevel = 0;

                if (UseActiveSkillType)
                {
                    SelectedSkillLevel = rsData.GetInt32(2);
                }
                else
                {
                    SelectedSkillLevel = rsData.GetInt32(1);
                }

                // Insert skill
                if (SettingsVariables.UserApplicationSettings.AllowSkillOverride & Conversions.ToBoolean(rsData.GetInt32(4)) & LoadAllSkillsforOverride)
                {
                    // Use the override skill if set, save the old skill level in the override so we can reference it later if needed
                    InsertSkill(rsData.GetInt64(0), rsData.GetInt32(5), rsData.GetInt32(1), rsData.GetInt32(2), rsData.GetInt64(3), Conversions.ToBoolean(rsData.GetInt32(4)), SelectedSkillLevel);
                }
                else // Just normal skills
                {
                    InsertSkill(rsData.GetInt64(0), SelectedSkillLevel, rsData.GetInt32(1), rsData.GetInt32(2), rsData.GetInt64(3), Conversions.ToBoolean(rsData.GetInt32(4)), rsData.GetInt32(5));
                }

            }

            rsData.Close();

        }

        // Updates the character skills from ESI
        private void UpdateCharacterSkills(long ID, SavedTokenData CharacterTokenData, bool OpenTransaction = true)
        {
            string SQL = "";
            SQLiteDataReader readerCharacter;
            string SkillList = "";
            var TempCharacterSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);

            // Get the skills for this character first
            var ESIData = new ESI();
            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            if (CB.DataUpdateable(CacheDateType.Skills, ID))
            {
                TempCharacterSkills = ESIData.GetCharacterSkills(ID, CharacterTokenData, ref CacheDate);

                if (!(TempCharacterSkills == null))
                {
                    // Clean out any skills not in the temp skills, make this first. This will ignore any skills the person may have over-ridden and added
                    for (int i = 0, loopTo = TempCharacterSkills.GetSkillList().Count - 1; i <= loopTo; i++)
                        SkillList = SkillList + TempCharacterSkills.GetSkillList()[i].TypeID + ",";

                    // Strip comma
                    SkillList = SkillList.Substring(0, Strings.Len(SkillList) - 1);

                    // Delete the temp skills but not any that are overridden
                    SQL = "DELETE FROM CHARACTER_SKILLS WHERE SKILL_TYPE_ID IN (" + SkillList + ") AND CHARACTER_ID =" + ID.ToString();
                    SQL += " AND OVERRIDE_SKILL <> -1";
                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                    if (OpenTransaction)
                    {
                        Public_Variables.EVEDB.BeginSQLiteTransaction();
                    }

                    // Insert new skill data
                    for (int i = 0, loopTo1 = TempCharacterSkills.GetSkillList().Count - 1; i <= loopTo1; i++)
                    {

                        // Check for skill and update if there
                        SQL = "SELECT 'X' FROM CHARACTER_SKILLS WHERE SKILL_TYPE_ID = " + TempCharacterSkills.GetSkillList()[i].TypeID + " AND CHARACTER_ID =" + ID.ToString();

                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                        readerCharacter = Public_Variables.DBCommand.ExecuteReader();

                        if (!readerCharacter.HasRows)
                        {
                            // Insert skill data
                            SQL = "INSERT INTO CHARACTER_SKILLS (CHARACTER_ID, SKILL_TYPE_ID, SKILL_NAME, SKILL_POINTS, TRAINED_SKILL_LEVEL, ACTIVE_SKILL_LEVEL, OVERRIDE_SKILL, OVERRIDE_LEVEL) ";
                            SQL += " VALUES (" + ID + "," + TempCharacterSkills.GetSkillList()[i].TypeID + ",'" + TempCharacterSkills.GetSkillList()[i].Name + "',";
                            SQL += TempCharacterSkills.GetSkillList()[i].SkillPoints + "," + TempCharacterSkills.GetSkillList()[i].TrainedLevel + "," + TempCharacterSkills.GetSkillList()[i].ActiveLevel + ",0,0)";
                        }
                        else
                        {
                            // Update skill data
                            SQL = "UPDATE CHARACTER_SKILLS SET ";
                            SQL += "SKILL_TYPE_ID = " + TempCharacterSkills.GetSkillList()[i].TypeID + ", SKILL_NAME = '" + TempCharacterSkills.GetSkillList()[i].Name + "',";
                            SQL += "SKILL_POINTS = " + TempCharacterSkills.GetSkillList()[i].SkillPoints + ", TRAINED_SKILL_LEVEL = " + TempCharacterSkills.GetSkillList()[i].TrainedLevel + ", ";
                            SQL += "ACTIVE_SKILL_LEVEL = " + TempCharacterSkills.GetSkillList()[i].ActiveLevel + " ";
                            SQL += "WHERE CHARACTER_ID = " + ID + " AND SKILL_TYPE_ID = " + TempCharacterSkills.GetSkillList()[i].TypeID;
                        }

                        readerCharacter.Close();

                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                    }

                    Public_Variables.DBCommand = null;

                    // Update cache date now all entered
                    CB.UpdateCacheDate(CacheDateType.Skills, CacheDate, ID);

                    if (OpenTransaction)
                    {
                        Public_Variables.EVEDB.CommitSQLiteTransaction();
                    }

                }
            }

        }

        // Sets the flag for using active skills
        public void SetActiveSkillFlagValue(bool FlagValue)
        {
            UseActiveSkillType = FlagValue;
        }

        // Returns the skill type id for the name of the skill sent
        public long GetSkillTypeID(string SkillName)
        {
            int i = 0;

            if (!(Skills == null))
            {
                var loopTo = Skills.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if ((Skills[i].Name ?? "") == (SkillName ?? ""))
                    {
                        return Skills[i].TypeID;
                        return default;
                    }
                }
            }

            return 0L;

        }

        // Returns the skill for sent name
        public EVESkill GetSkill(string SkillName)
        {
            int i = 0;

            if (!(Skills == null))
            {
                var loopTo = Skills.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if ((Skills[i].Name ?? "") == (SkillName ?? ""))
                    {
                        return Skills[i];
                        return default;
                    }
                }
            }

            return null;

        }

        // Returns the level of a skill when sent the typeid of the skill
        public int GetSkillLevel(long SkillTypeID)
        {

            // Find the Industry Skill level
            if (!(Skills == null))
            {
                for (int i = 0, loopTo = Skills.Count - 1; i <= loopTo; i++)
                {
                    if (Skills[i].TypeID == SkillTypeID)
                    {
                        if (Skills[i].Overridden)
                        {
                            return Skills[i].OverriddenLevel;
                        }
                        else
                        {
                            return Skills[i].Level;
                        }
                    }
                }
            }

            // Got this far we didn't find it in the list
            return 0;

        }

        // Returns the level of a skill when sent the typeid of the skill
        public int GetSkillLevel(string SkillName)
        {

            // Find the Industry Skill level
            if (!(Skills == null))
            {
                for (int i = 0, loopTo = Skills.Count - 1; i <= loopTo; i++)
                {
                    if ((Skills[i].Name ?? "") == (SkillName ?? ""))
                    {
                        if (Skills[i].Overridden)
                        {
                            return Skills[i].OverriddenLevel;
                        }
                        else
                        {
                            return Skills[i].Level;
                        }
                    }
                }
            }

            // Got this far we didn't find it in the list
            return 0;

        }

        // Returns the total skill points of a skill when sent the typeid of the skill
        public long GetSkillPoints(long SkillTypeID)
        {

            // Find the Industry Skill level
            if (!(Skills == null))
            {
                for (int i = 0, loopTo = Skills.Count - 1; i <= loopTo; i++)
                {
                    if (Skills[i].TypeID == SkillTypeID)
                    {
                        return Skills[i].SkillPoints;
                        return default;
                    }
                }
            }

            // Got this far we didn't find it in the list
            return 0L;

        }

        // Returns the list of skills for the class
        public List<EVESkill> GetSkillList()
        {
            return Skills;
        }

        // Returns the count of skills
        public int NumSkills()
        {
            return Skills.Count;
        }

        // Internal Function to insert a skill
        private void InsertSkilltoList(EVESkill SentSkill, bool LoadPreReqs)
        {
            SQLiteDataReader readerSkills;
            var FoundSkill = new EVESkill();

            string SQL;

            // See if the skill exists already
            SkillToFind = SentSkill;
            CheckLevelofSkilltoFind = true;
            FoundSkill = Skills.Find(FindSkill);

            if (FoundSkill is not null)
            {
                // Already here or as a level greater than this skill exists
                return;
            }
            else
            {
                // No skill or need to update the skill level
                if (string.IsNullOrEmpty(SentSkill.Name))
                {
                    // Look up skill name
                    SQL = "SELECT typeName, groupName FROM INVENTORY_TYPES, INVENTORY_GROUPS ";
                    SQL += "WHERE INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID AND typeID = " + SentSkill.TypeID;

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerSkills = Public_Variables.DBCommand.ExecuteReader();

                    if (readerSkills.Read())
                    {
                        SentSkill.Name = readerSkills.GetString(0);
                        SentSkill.Group = readerSkills.GetString(1);
                    }
                    else
                    {
                        SentSkill.Name = "Unknown Skill";
                        SentSkill.Group = "Unknown Group";
                    }
                    readerSkills.Close();

                }

                // Check Pre-Reqs
                if (LoadPreReqs)
                {
                    SentSkill.SetPreReqSkills();
                }

                // Load Skill
                Skills.Add(SentSkill);

            }

        }

        // Allows inserting a skill by structure
        public void InsertSkill(EVESkill InsertSkill, bool LoadPreReqs = false)
        {
            // Set the Level based on skill type chosen
            if (UseActiveSkillType)
            {
                InsertSkill.Level = InsertSkill.ActiveLevel;
            }
            else
            {
                InsertSkill.Level = InsertSkill.TrainedLevel;
            }
            InsertSkilltoList(InsertSkill, LoadPreReqs);
        }

        // Inserts a skill into the list
        public void InsertSkill(long SkillTypeID, int Level, int TrainedSkillLevel, int ActiveSkillLevel, long SkillPoints, bool SkillOverriden, int SkillOverrideLevel, string SkillName = "", EVESkillList PreReqSkills = null, bool LoadPreReqs = false)
        {

            var InsertSkill = new EVESkill();

            InsertSkill.TypeID = SkillTypeID;
            InsertSkill.Level = Level;
            InsertSkill.TrainedLevel = TrainedSkillLevel;
            InsertSkill.ActiveLevel = ActiveSkillLevel;
            InsertSkill.Name = SkillName;
            InsertSkill.SkillPoints = SkillPoints;
            InsertSkill.Overridden = SkillOverriden;
            InsertSkill.OverriddenLevel = SkillOverrideLevel;

            if (!(PreReqSkills == null))
            {
                InsertSkill.PreReqSkills = PreReqSkills;
            }

            InsertSkilltoList(InsertSkill, LoadPreReqs);

        }

        // Inserts a set of character skills into the current set 
        public void InsertSkills(EVESkillList TempSkills, bool LoadPreReqSkills)
        {
            int i;

            if (!(TempSkills == null))
            {
                var loopTo = TempSkills.NumSkills() - 1;
                for (i = 0; i <= loopTo; i++)
                    InsertSkill(TempSkills.GetSkillList()[i], LoadPreReqSkills);
            }

        }

        // Will update the skill level for the skill name sent in the list - If it doesn't exist, it won't update anything
        public void UpdateSkill(EVESkill SkillUpdate)
        {
            int i;

            if (!(Skills == null))
            {
                var loopTo = Skills.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if ((Skills[i].Name ?? "") == (SkillUpdate.Name ?? ""))
                    {
                        // Update the skill
                        Skills[i] = SkillUpdate;
                    }
                }
            }

        }

        // Predicate for finding the skill
        private bool FindSkill(EVESkill SSkill)
        {

            if (SSkill.TypeID == SkillToFind.TypeID)
            {
                if (CheckLevelofSkilltoFind & SSkill.Level <= SkillToFind.Level)
                {
                    return true;
                }
                else if (!CheckLevelofSkilltoFind)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        // Save the overridden skills
        public void SaveOverRideSkills(EVESkillList OverRideSkills)
        {
            int i;
            SQLiteDataReader readerSkills;
            string SQL;

            // Loop through all the override skills and update as necessary, then set the character skills to these
            if (OverRideSkills.NumSkills() != 0)
            {

                Public_Variables.EVEDB.BeginSQLiteTransaction();

                // Update their user id to override skills
                SQL = "UPDATE ESI_CHARACTER_DATA SET OVERRIDE_SKILLS = 1 WHERE CHARACTER_ID = " + Public_Variables.SelectedCharacter.ID;
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                var loopTo = OverRideSkills.NumSkills() - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    // Two possiblities - the skill exists, which is where we update the override variables, it doesn't and we enter a new record
                    // or it's there but we want to remove it
                    // Check for skill and update if there

                    string SkillType;
                    if (SettingsVariables.UserApplicationSettings.UseActiveSkillLevels)
                    {
                        SkillType = "ACTIVE_SKILL_LEVEL";
                    }
                    else
                    {
                        SkillType = "TRAINED_SKILL_LEVEL";
                    }
                    SQL = "SELECT " + SkillType + " FROM CHARACTER_SKILLS WHERE SKILL_TYPE_ID = " + OverRideSkills.Skills[i].TypeID + " AND CHARACTER_ID =" + Public_Variables.SelectedCharacter.ID;

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    readerSkills = Public_Variables.DBCommand.ExecuteReader();

                    if (readerSkills.Read())
                    {
                        if (Conversions.ToInteger(readerSkills.GetValue(0)) == 0 & !(OverRideSkills.Skills[i].Level == 0))
                        {
                            // This user doesn't want to save this skill and we need to delete the old one
                            SQL = "DELETE FROM CHARACTER_SKILLS WHERE SKILL_TYPE_ID = " + OverRideSkills.Skills[i].TypeID + " AND CHARACTER_ID =" + Public_Variables.SelectedCharacter.ID;
                        }
                        else // It's here and we need to update it
                        {
                            SQL = "UPDATE CHARACTER_SKILLS SET ";
                            SQL += "OVERRIDE_SKILL = " + Conversions.ToInteger(OverRideSkills.Skills[i].Overridden) + ", OVERRIDE_LEVEL = " + OverRideSkills.Skills[i].OverriddenLevel + " ";
                            SQL += "WHERE SKILL_TYPE_ID = " + OverRideSkills.Skills[i].TypeID + " AND CHARACTER_ID =" + Public_Variables.SelectedCharacter.ID;
                        }
                    }
                    else
                    {
                        // Insert the skill but since the user didn't have this, set the skill level to 0
                        SQL = "INSERT INTO CHARACTER_SKILLS (CHARACTER_ID, SKILL_TYPE_ID, SKILL_NAME, SKILL_POINTS, TRAINED_SKILL_LEVEL, ACTIVE_SKILL_LEVEL, OVERRIDE_SKILL, OVERRIDE_LEVEL) ";
                        SQL += " VALUES (" + Public_Variables.SelectedCharacter.ID + "," + OverRideSkills.Skills[i].TypeID + ",'" + OverRideSkills.Skills[i].Name + "',";
                        SQL += OverRideSkills.Skills[i].SkillPoints + ",0,0," + Conversions.ToInteger(OverRideSkills.Skills[i].Overridden) + "," + OverRideSkills.Skills[i].OverriddenLevel + ")";
                    }

                    readerSkills.Close();

                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                    SettingsVariables.UserApplicationSettings.AllowSkillOverride = true;

                }

                Public_Variables.EVEDB.CommitSQLiteTransaction();

                // Just saved the skill updates so, only reload the skills from db
                Public_Variables.SelectedCharacter.Skills.LoadCharacterSkills(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, false);
            }

            else
            {
                // Clean up the skills because we are reverting to default API skills
                // Change their override user setting back to unchecked
                SQL = "UPDATE ESI_CHARACTER_DATA SET OVERRIDE_SKILLS = 0 WHERE CHARACTER_ID = " + Public_Variables.SelectedCharacter.ID;
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                // Delete any skills that aren't trained by the character
                SQL = "DELETE FROM CHARACTER_SKILLS WHERE CHARACTER_ID = " + Public_Variables.SelectedCharacter.ID + " AND TRAINED_SKILL_LEVEL = 0";
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                // Update all skills to base
                SQL = "UPDATE CHARACTER_SKILLS SET OVERRIDE_LEVEL = 0, OVERRIDE_SKILL = 0 WHERE CHARACTER_ID = " + Public_Variables.SelectedCharacter.ID;
                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                SettingsVariables.UserApplicationSettings.AllowSkillOverride = false;

            }

        }

        // Loads the skills for a 'Dummy Character' to this character
        public void LoadDummySkills()
        {
            string SQL;

            // Clean up any skills if they exist - account does not so load a fresh set
            SQL = "DELETE FROM CHARACTER_SKILLS WHERE CHARACTER_ID = " + Public_Variables.DummyCharacterID.ToString();
            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

            // Insert skill records for dummy
            SQL = "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3327,'Spaceship Command',8000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3380,'Industry',250,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3386,'Mining',1415,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3402,'Science',8000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",32918,'Mining Frigate',8000,2,2,0,0); ";
            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

            // Just saved the skill updates so, only reload the skills from db
            Public_Variables.SelectedCharacter.Skills.LoadCharacterSkills(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, false);

        }

        // Loads the max alpha skills for this character (option for dummy accounts)
        public void LoadMaxAlphaSkills()
        {
            string SQL;

            // Clean up any skills if they exist - account does not so load a fresh set
            SQL = "DELETE FROM CHARACTER_SKILLS WHERE CHARACTER_ID = " + Public_Variables.DummyCharacterID.ToString();
            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

            // Insert skill records for max alpha
            SQL = "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33078,'Armor Layering',750,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",22806,'EM Armor Compensation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",22807,'Explosive Armor Compensation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3394,'Hull Upgrades',512000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",22808,'Kinetic Armor Compensation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3392,'Mechanics',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",16069,'Remote Armor Repair Systems',16000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",27902,'Remote Hull Repair Systems',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3393,'Repair Systems',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",22809,'Thermal Armor Compensation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3363,'Corporation Management',250,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12484,'Amarr Drone Specialization',7071,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12487,'Caldari Drone Specialization',7071,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3437,'Drone Avionics',45255,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",23618,'Drone Durability',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3442,'Drone Interfacing',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12305,'Drone Navigation',45255,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",23606,'Drone Sharpshooting',45255,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3436,'Drones',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12486,'Gallente Drone Specialization',7071,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3441,'Heavy Drone Operation',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",24241,'Light Drone Operation',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33699,'Medium Drone Operation',512000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12485,'Minmatar Drone Specialization',7071,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3439,'Repair Drone Operation',4243,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3427,'Electronic Warfare',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3435,'Propulsion Jamming',135765,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3433,'Sensor Linking',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",19921,'Target Painting',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3434,'Weapon Disruption',135765,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",11207,'Advanced Weapon Upgrades',48000,6,6,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3423,'Capacitor Emission Systems',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3418,'Capacitor Management',135765,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3417,'Capacitor Systems Operation',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3426,'CPU Management',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3432,'Electronics Upgrades',512000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3424,'Energy Grid Upgrades',512000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3421,'Energy Pulse Weapons',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3413,'Power Grid Management',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",28164,'Thermodynamics',135765,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3318,'Weapon Upgrades',512000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3316,'Controlled Bursts',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3300,'Gunnery',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",25718,'Heavy Assault Missile Specialization',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",20211,'Heavy Missile Specialization',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3309,'Large Energy Turret',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3307,'Large Hybrid Turret',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3308,'Large Projectile Turret',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",20210,'Light Missile Specialization',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12202,'Medium Artillery Specialization',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12208,'Medium Autocannon Specialization',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12204,'Medium Beam Laser Specialization',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12211,'Medium Blaster Specialization',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3306,'Medium Energy Turret',768000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3304,'Medium Hybrid Turret',768000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3305,'Medium Projectile Turret',768000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12214,'Medium Pulse Laser Specialization',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12206,'Medium Railgun Specialization',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3312,'Motion Prediction',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3310,'Rapid Firing',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",20209,'Rocket Specialization',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3311,'Sharpshooter',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12201,'Small Artillery Specialization',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",11084,'Small Autocannon Specialization',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",11083,'Small Beam Laser Specialization',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12210,'Small Blaster Specialization',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3303,'Small Energy Turret',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3301,'Small Hybrid Turret',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3302,'Small Projectile Turret',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12213,'Small Pulse Laser Specialization',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",11082,'Small Railgun Specialization',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3315,'Surgical Strike',181019,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3317,'Trajectory Analysis',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3348,'Leadership',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3326,'Cruise Missiles',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",20312,'Guided Missile Precision',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",25719,'Heavy Assault Missiles',768000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3324,'Heavy Missiles',768000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3321,'Light Missiles',512000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12441,'Missile Bombardment',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3319,'Missile Launcher Operation',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12442,'Missile Projection',5657,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",21071,'Rapid Launch',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3320,'Rockets',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",20314,'Target Navigation Prediction',16000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3325,'Torpedoes',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",20315,'Warhead Upgrades',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3452,'Acceleration Control',32000,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3450,'Afterburner',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3453,'Evasive Maneuvering',16000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3454,'High Speed Maneuvering',40000,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3449,'Navigation',45255,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3455,'Warp Drive Operation',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3405,'Biology',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3411,'Cybernetics',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",24242,'Infomorph Psychology',250,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3380,'Industry',256000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3387,'Mass Production',16000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",25544,'Gas Cloud Harvesting',1414,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",16281,'Ice Harvesting',1414,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3386,'Mining',45255,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",22578,'Mining Upgrades',181019,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3385,'Reprocessing',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",25863,'Salvaging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26253,'Armor Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26254,'Astronautics Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26255,'Drones Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26256,'Electronic Superiority Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26258,'Energy Weapon Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26259,'Hybrid Weapon Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26252,'Jury Rigging',16000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26260,'Launcher Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26257,'Projectile Weapon Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",26261,'Shield Rigging',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",13278,'Archaeology',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",25811,'Astrometric Acquisition',7071,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",25739,'Astrometric Rangefinding',11314,8,8,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3412,'Astrometrics',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",21718,'Hacking',24000,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3551,'Survey',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3402,'Science',45255,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12365,'EM Shield Compensation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12367,'Explosive Shield Compensation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",12366,'Kinetic Shield Compensation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",21059,'Shield Compensation',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3422,'Shield Emission Systems',16000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3419,'Shield Management',135765,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3416,'Shield Operation',45255,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3425,'Shield Upgrades',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3420,'Tactical Shield Manipulation',181019,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",11566,'Thermal Shield Compensation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3359,'Connections',4243,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3361,'Criminal Connections',4243,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3357,'Diplomacy',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3894,'Distribution Connections',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3893,'Mining Connections',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3356,'Negotiation',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3895,'Security Connections',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3355,'Social',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33095,'Amarr Battlecruiser',271529,6,6,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3339,'Amarr Battleship',362309,8,8,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3335,'Amarr Cruiser',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33091,'Amarr Destroyer',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3331,'Amarr Frigate',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3343,'Amarr Industrial',1000,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33096,'Caldari Battlecruiser',271529,6,6,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3338,'Caldari Battleship',362309,8,8,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3334,'Caldari Cruiser',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33092,'Caldari Destroyer',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3330,'Caldari Frigate',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3342,'Caldari Industrial',1000,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33097,'Gallente Battlecruiser',271529,6,6,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3336,'Gallente Battleship',362309,8,8,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3332,'Gallente Cruiser',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33093,'Gallente Destroyer',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3328,'Gallente Frigate',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3340,'Gallente Industrial',1000,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",32918,'Mining Frigate',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33098,'Minmatar Battlecruiser',271529,6,6,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3337,'Minmatar Battleship',362309,8,8,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3333,'Minmatar Cruiser',226274,5,5,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",33094,'Minmatar Destroyer',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3329,'Minmatar Frigate',90510,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3341,'Minmatar Industrial',100,4,4,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3327,'Spaceship Command',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",11584,'Anchoring',750,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3428,'Long Range Targeting',16000,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3431,'Signature Analysis',8000,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3429,'Target Management',45255,1,1,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3446,'Broker Relations',2828,2,2,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",16598,'Marketing',4243,3,3,0,0); ";
            SQL += "INSERT INTO CHARACTER_SKILLS VALUES (" + Public_Variables.DummyCharacterID.ToString() + ",3443,'Trade',8000,1,1,0,0); ";

            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

            // Just saved the skill updates so, only reload the skills from db
            Public_Variables.SelectedCharacter.Skills.LoadCharacterSkills(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, false);

        }


    }

    public class EVESkill
    {
        public long TypeID;
        public string Name;
        public string Group;
        public long SkillPoints;
        public int TrainedLevel;
        public int ActiveLevel;
        public int Level; // What we use in IPH
        public bool Overridden;
        public int OverriddenLevel;
        public EVESkillList PreReqSkills;

        public EVESkill()
        {
            TypeID = 0L;
            Name = "";
            Group = "";
            SkillPoints = 0L;
            TrainedLevel = 0;
            ActiveLevel = 0;
            Level = 0;
            Overridden = false;
            OverriddenLevel = 0;
            PreReqSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
        }

        public void SetPreReqSkills()
        {
            string SQL;
            var PreReqs = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
            var TempSkill = new EVESkill();
            SQLiteDataReader readerSkills;

            SQL = "SELECT TYPE_ATTRIBUTES.value, INVENTORY_TYPES_1.typeName, INVENTORY_GROUPS.groupName, TYPE_ATTRIBUTES_1.value ";
            SQL += "FROM INVENTORY_TYPES, INVENTORY_GROUPS, INVENTORY_TYPES AS INVENTORY_TYPES_1, TYPE_ATTRIBUTES, TYPE_ATTRIBUTES AS TYPE_ATTRIBUTES_1, ATTRIBUTE_TYPES ";
            SQL += "WHERE INVENTORY_TYPES.typeID = TYPE_ATTRIBUTES.typeID ";
            SQL += "AND INVENTORY_TYPES.groupID = INVENTORY_GROUPS.groupID ";
            SQL += "AND TYPE_ATTRIBUTES.attributeID = ATTRIBUTE_TYPES.attributeID ";
            SQL += "AND INVENTORY_TYPES.typeID = TYPE_ATTRIBUTES_1.typeID ";
            SQL += "AND TYPE_ATTRIBUTES.value = INVENTORY_TYPES_1.typeID ";
            SQL += "AND TYPE_ATTRIBUTES.attributeID > 181 AND TYPE_ATTRIBUTES.attributeID < 185 AND TYPE_ATTRIBUTES_1.attributeID = TYPE_ATTRIBUTES.attributeID + 95 ";
            SQL += "AND INVENTORY_TYPES.typeID = " + TypeID.ToString();

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerSkills = Public_Variables.DBCommand.ExecuteReader();

            while (readerSkills.Read())
            {
                TempSkill.TypeID = (int)Math.Round(readerSkills.GetDouble(0));
                TempSkill.Name = readerSkills.GetString(1);
                TempSkill.Group = readerSkills.GetString(2);
                TempSkill.TrainedLevel = Conversions.ToInteger(readerSkills.GetValue(3));
                TempSkill.ActiveLevel = Conversions.ToInteger(readerSkills.GetValue(3));
                TempSkill.Level = Conversions.ToInteger(readerSkills.GetValue(3));
                TempSkill.SkillPoints = 0L;
                TempSkill.OverriddenLevel = 0;
                TempSkill.Overridden = false;
                TempSkill.SetPreReqSkills();

                // Set the local pre-reqs
                PreReqs.InsertSkill(TempSkill.TypeID, TempSkill.Level, TempSkill.TrainedLevel, TempSkill.ActiveLevel, TempSkill.SkillPoints, TempSkill.Overridden, TempSkill.OverriddenLevel, TempSkill.Name, TempSkill.PreReqSkills, true);
            }

            // Save the final set
            PreReqSkills = PreReqs;

            readerSkills.Close();

        }

    }
}