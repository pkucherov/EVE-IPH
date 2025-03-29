using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class EVEResearchAgents
    {

        private List<ResearchAgent> AgentList;

        public EVEResearchAgents()
        {

            AgentList = new List<ResearchAgent>();

        }

        public void LoadResearchAgents(long CharacterID, SavedTokenData TokenData)
        {
            SQLiteDataReader readerResearch;
            string SQL;
            ResearchAgent TempAgent;
            DateTime ResearchStartDate;
            TimeSpan Difference;
            double DateDifference;

            // Update them first
            UpdateResearchAgents(CharacterID, TokenData);

            // Load the data from the DB
            SQL = "SELECT AGENT_NAME, typeName AS RESEARCH_FIELD, RP_PER_DAY, LEVEL, STATION, RESEARCH_START_DATE, REMAINDER_POINTS ";
            SQL += "FROM RESEARCH_AGENTS, INVENTORY_TYPES, CURRENT_RESEARCH_AGENTS  ";
            SQL += "WHERE CURRENT_RESEARCH_AGENTS.AGENT_ID = RESEARCH_AGENTS.AGENT_ID ";
            SQL += "AND CURRENT_RESEARCH_AGENTS.SKILL_TYPE_ID= INVENTORY_TYPES.typeID ";
            SQL += "AND CHARACTER_ID = " + CharacterID.ToString() + " ";
            SQL += "GROUP BY AGENT_NAME, typeName, RP_PER_DAY, LEVEL, STATION, RESEARCH_START_DATE, REMAINDER_POINTS ";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerResearch = Public_Variables.DBCommand.ExecuteReader();

            // New list
            AgentList = new List<ResearchAgent>();

            while (readerResearch.Read())
            {
                TempAgent.Agent = readerResearch.GetString(0);
                TempAgent.Field = readerResearch.GetString(1);

                TempAgent.AgentLevel = readerResearch.GetInt32(3);
                TempAgent.Location = readerResearch.GetString(4);

                TempAgent.RPperDay = readerResearch.GetDouble(2);

                ResearchStartDate = DateTime.ParseExact(readerResearch.GetString(5), Public_Variables.SQLiteDateFormat, Public_Variables.LocalCulture);
                Difference = DateTime.Now.Subtract(ResearchStartDate);
                DateDifference = Difference.Days + Difference.Hours / 24d + Difference.Seconds / (double)(24 * 60);

                // Calculate the current rps - Diff of now from start date + remainder points
                TempAgent.CurrentRP = readerResearch.GetDouble(2) * DateDifference + readerResearch.GetDouble(6);

                // Add the agent to the list
                AgentList.Add(TempAgent);

            }

            readerResearch.Close();

        }

        private void UpdateResearchAgents(long CharacterID, SavedTokenData CharacterTokenData)
        {
            // Refresh the data from the API
            string SQL = "";
            List<ESIResearchAgent> CurrentAgents = null;

            var ESIData = new ESI();
            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            // Get the current list of agents updated
            if (CB.DataUpdateable(CacheDateType.ResearchAgents, CharacterID))
            {
                CurrentAgents = ESIData.GetCurrentResearchAgents(CharacterID, CharacterTokenData, ref CacheDate);

                if (!(CurrentAgents == null))
                {
                    if (CurrentAgents.Count > 0)
                    {
                        Public_Variables.EVEDB.BeginSQLiteTransaction();

                        // Delete all the current records and refresh them
                        SQL = "DELETE FROM CURRENT_RESEARCH_AGENTS WHERE CHARACTER_ID = " + CharacterID.ToString();
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);


                        // Insert new data
                        for (int i = 0, loopTo = CurrentAgents.Count - 1; i <= loopTo; i++)
                        {
                            {
                                var withBlock = CurrentAgents[i];
                                SQL = "INSERT INTO CURRENT_RESEARCH_AGENTS (AGENT_ID, SKILL_TYPE_ID, ";
                                SQL += "RP_PER_DAY, RESEARCH_START_DATE, REMAINDER_POINTS, CHARACTER_ID) VALUES ";
                                SQL += "(" + withBlock.agent_id.ToString() + "," + withBlock.skill_type_id.ToString() + "," + withBlock.points_per_day.ToString() + ",'";
                                SQL += Strings.Format(Conversions.ToDate(CurrentAgents[i].started_at.Replace("T", " ").Replace("Z", "")), Public_Variables.SQLiteDateFormat) + "',";
                                SQL += withBlock.remainder_points.ToString() + "," + CharacterID.ToString() + ")";
                            }

                            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                        }

                        Public_Variables.EVEDB.CommitSQLiteTransaction();
                    }
                    // All set, update cache date before leaving
                    CB.UpdateCacheDate(CacheDateType.ResearchAgents, CacheDate, CharacterID);
                }
            }

        }

        public List<ResearchAgent> GetResearchAgents()
        {
            return AgentList;
        }

    }

    public struct ResearchAgent
    {
        public string Agent;
        public string Field;
        public double CurrentRP;
        public double RPperDay;
        public int AgentLevel;
        public string Location;
    }
}