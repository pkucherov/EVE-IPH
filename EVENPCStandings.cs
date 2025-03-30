using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace EVE_Isk_per_Hour
{

    public class EVENPCStandings
    {

        private List<NPCStanding> NPCStandings;
        private NPCStanding StandingToFind;

        private long IDtoFind;

        public class NPCStanding
        {
            public long NPCID;
            public string NPCType; // Agent, Faction, or Corporation
            public string NPCName;
            public double Standing; // Will be a base standing (no connections skill applied)
        }

        public EVENPCStandings()
        {
            NPCStandings = new List<NPCStanding>();
        }

        // Returns the standing of a sent NPC ID
        public double GetStanding(long NPCID)
        {

            // Find the Industry Skill level
            if (NPCStandings.Count != 0)
            {
                for (int i = 0, loopTo = NPCStandings.Count - 1; i <= loopTo; i++)
                {
                    if (NPCStandings[i].NPCID == NPCID)
                    {
                        return NPCStandings[i].Standing;
                    }
                }
            }

            // Got this far we didn't find it in the list
            return 0d;

        }

        // Returns the standing of a sent name
        public double GetStanding(string NPCName)
        {

            // Find the Industry Skill level
            if (NPCStandings.Count != 0)
            {
                for (int i = 0, loopTo = NPCStandings.Count - 1; i <= loopTo; i++)
                {
                    if ((NPCStandings[i].NPCName ?? "") == (NPCName ?? ""))
                    {
                        return NPCStandings[i].Standing;
                    }
                }
            }

            // Got this far we didn't find it in the list
            return 0d;

        }

        // Returns the effective standing of a sent NPC ID
        public double GetEffectiveStanding(long NPCID, int SentConnections, int SentDiplomacy)
        {

            // Find the Industry Skill level
            if (NPCStandings.Count != 0)
            {
                for (int i = 0, loopTo = NPCStandings.Count - 1; i <= loopTo; i++)
                {
                    if (NPCStandings[i].NPCID == NPCID)
                    {
                        return CalcEffectiveStanding(NPCStandings[i].Standing, SentConnections, SentDiplomacy);
                    }
                }
            }

            // Got this far we didn't find it in the list
            return 0d;

        }

        // Returns the effective standing of a sent name
        public double GetEffectiveStanding(string NPCName, int SentConnections, int SentDiplomacy)
        {

            // Find the Industry Skill level
            if (NPCStandings.Count != 0)
            {
                for (int i = 0, loopTo = NPCStandings.Count - 1; i <= loopTo; i++)
                {
                    if ((NPCStandings[i].NPCName ?? "") == (NPCName ?? ""))
                    {
                        return CalcEffectiveStanding(NPCStandings[i].Standing, SentConnections, SentDiplomacy);
                    }
                }
            }

            // Got this far we didn't find it in the list
            return 0d;

        }

        private double CalcEffectiveStanding(double BaseCorpStanding, int Connections, int Diplomacy)
        {
            double EffectiveStanding;

            if (BaseCorpStanding < 0d)
            {
                // Use Diplomacy
                EffectiveStanding = BaseCorpStanding + (10d - BaseCorpStanding) * (0.04d * Diplomacy);
            }
            else if (BaseCorpStanding > 0d)
            {
                // Use connections
                EffectiveStanding = BaseCorpStanding + (10d - BaseCorpStanding) * (0.04d * Connections);
            }
            else
            {
                EffectiveStanding = 0d;
            }

            return EffectiveStanding;

        }

        // Returns the list of standings
        public List<NPCStanding> GetStandingsList()
        {
            return NPCStandings;
        }

        // Returns the number of standings in the list
        public int NumStandings()
        {
            if (NPCStandings.Count != 0)
            {
                return NPCStandings.Count;
            }
            else
            {
                return 0;
            }
        }

        // Inserts standing with each value
        public void InsertStanding(long sentNPCID, string sentNPCType, string sentNPCName, double sentStanding)
        {
            var TempStanding = new NPCStanding();

            TempStanding.NPCID = sentNPCID;
            TempStanding.NPCName = sentNPCName;
            TempStanding.NPCType = sentNPCType;
            TempStanding.Standing = sentStanding;

            InsertStanding(TempStanding);

        }

        // Inserts a set of character skills into the current set
        public void InsertStanding(NPCStanding SentStanding)
        {
            NPCStanding FoundStanding;
            int i = 0;

            // See if the skill exists already
            StandingToFind = SentStanding;
            FoundStanding = NPCStandings.Find(FindStanding);

            if (FoundStanding is not null)
            {
                return;
            }
            else // add standing
            {
                NPCStandings.Add(SentStanding);
            }

        }

        // Predicate for finding the standing
        private bool FindStanding(NPCStanding SStanding)
        {

            if (SStanding.NPCID == StandingToFind.NPCID & (SStanding.NPCType ?? "") == (StandingToFind.NPCType ?? "") & (SStanding.NPCName ?? "") == (StandingToFind.NPCName ?? ""))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Updates and Loads the character's standings from DB
        public void LoadCharacterStandings(long CharacterID, SavedTokenData CharacterTokenData)
        {
            string SQL;
            SQLiteDataReader readerStandings;
            var Tempstandings = new EVENPCStandings();

            // Don't try to update/load dummy standings
            if (CharacterID == 0L)
            {
                return;
            }

            // First update the standings
            UpdateCharacterStandings(CharacterID, CharacterTokenData);

            // Load the standings
            SQL = "SELECT NPC_TYPE_ID, NPC_TYPE, NPC_NAME, STANDING FROM CHARACTER_STANDINGS WHERE CHARACTER_ID=" + CharacterID;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerStandings = Public_Variables.DBCommand.ExecuteReader();

            while (readerStandings.Read())
                // Insert standing
                InsertStanding(readerStandings.GetInt64(0), readerStandings.GetString(1), readerStandings.GetString(2), readerStandings.GetDouble(3));

            readerStandings.Close();

        }

        // Updates the Character Standings from ESI for the sent character and inserts them into the Database for later queries
        private void UpdateCharacterStandings(long ID, SavedTokenData CharacterTokenData)
        {
            string SQL;
            int i;
            EVENPCStandings TempStandings = null;
            var NonFactionIDs = new List<long>();
            var ReturnNameData = new List<ESINameData>();
            var ReturnFactionData = new List<ESIFactionData>();
            NPCStanding TempStanding;

            var ESIData = new ESI();
            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            // Get updated standings
            if (CB.DataUpdateable(CacheDateType.Standings, ID))
            {
                TempStandings = ESIData.GetCharacterStandings(ID, CharacterTokenData, ref CacheDate);

                if (!(TempStandings == null))
                {
                    if (TempStandings.GetStandingsList().Count > 0)
                    {
                        // Get all the standing names for corps and agents first
                        foreach (var entry in TempStandings.NPCStandings)
                        {
                            if (entry.NPCType != "Faction")
                            {
                                NonFactionIDs.Add(entry.NPCID);
                            }
                        }

                        if (NonFactionIDs.Count > 0)
                        {
                            // Get the faction names
                            ReturnFactionData = ESIData.GetFactionData();

                            foreach (var Record in ReturnFactionData)
                            {
                                // Update the Standings list with name
                                IDtoFind = Record.faction_id;
                                TempStanding = TempStandings.NPCStandings.Find(FindNPCID);
                                if (!(TempStanding == null))
                                {
                                    TempStandings.NPCStandings.Remove(TempStanding);
                                    TempStanding.NPCName = Record.name;
                                    TempStandings.NPCStandings.Add(TempStanding);
                                }
                            }

                            // Get the corp and agent names
                            ReturnNameData = ESIData.GetNameData(NonFactionIDs);

                            if (!(ReturnNameData == null))
                            {
                                foreach (var Record in ReturnNameData)
                                {
                                    // Update the Standings list with name
                                    IDtoFind = Record.id;
                                    TempStanding = TempStandings.NPCStandings.Find(FindNPCID);
                                    if (!(TempStanding == null))
                                    {
                                        TempStandings.NPCStandings.Remove(TempStanding);
                                        TempStanding.NPCName = Record.name;
                                        TempStandings.NPCStandings.Add(TempStanding);
                                    }
                                }
                            }

                            Public_Variables.EVEDB.BeginSQLiteTransaction();

                            // Delete the old standings data
                            SQL = "DELETE FROM CHARACTER_STANDINGS WHERE CHARACTER_ID = " + ID;
                            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                            // Insert new standings data
                            var loopTo = TempStandings.NumStandings() - 1;
                            for (i = 0; i <= loopTo; i++)
                            {
                                SQL = "INSERT INTO CHARACTER_STANDINGS (CHARACTER_ID, NPC_TYPE_ID, NPC_TYPE, NPC_NAME, STANDING) ";
                                SQL += " VALUES (" + ID + "," + TempStandings.GetStandingsList()[i].NPCID;
                                SQL += ",'" + TempStandings.GetStandingsList()[i].NPCType;
                                SQL += "','" + Public_Variables.FormatDBString(TempStandings.GetStandingsList()[i].NPCName);
                                SQL += "'," + TempStandings.GetStandingsList()[i].Standing + ")";
                                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                            }

                            Public_Variables.DBCommand = null;

                            Public_Variables.EVEDB.CommitSQLiteTransaction();
                        }
                    }
                    // Update cache date now that it's all set
                    CB.UpdateCacheDate(CacheDateType.Standings, CacheDate, ID);
                }
            }
        }

        // Predicate for finding an npc record
        private bool FindNPCID(NPCStanding Item)
        {
            if (Item.NPCID == IDtoFind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Predicate for finding an npc record
        private bool FindFactionID(ESIFactionData Item)
        {
            if (Item.faction_id == IDtoFind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}