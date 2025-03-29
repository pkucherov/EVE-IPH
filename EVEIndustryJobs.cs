using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public class EVEIndustryJobs
    {

        private List<IndustryJob> JobList;

        public EVEIndustryJobs()
        {

            JobList = new List<IndustryJob>();

        }

        // Loads all the Industry Assets from the DB for the ID sent - I'm not using this locally so don't load anything
        public void LoadIndustryJobs(long ID, SavedTokenData TokenData, Public_Variables.ScanType JobType)
        {
            // Dim SQL As String
            // Dim readerJobs As SQLiteDataReader
            // Dim TempJob As IndustryJob
            // Dim Jobs As New List(Of IndustryJob)

            // Update Industry jobs first
            UpdateIndustryJobs(ID, TokenData, JobType);

            // DBCommand = New SQLiteCommand(SQL, EVEDB.DBREf)
            // readerJobs = DBCommand.ExecuteReader

            // While readerJobs.Read

            // End While

            // readerJobs.Close()
            // DBCommand = Nothing
            // readerJobs = Nothing

            // JobList = Jobs

        }

        // Updates the Industry Jobs from ESI for the character/corp and inserts them into the Database for later queries
        public void UpdateIndustryJobs(long ID, SavedTokenData CharacterTokenData, Public_Variables.ScanType JobType)
        {
            string SQL;
            var IndyJobs = new List<ESIIndustryJob>();
            var ESIData = new ESI();
            var CB = new CacheBox();
            var CacheDate = default(DateTime);
            long LocationID = 0L;
            DateTime TempDate;
            var CorpCharIDs = new List<long>();

            CacheDateType CDType;

            if (JobType == Public_Variables.ScanType.Personal)
            {
                CDType = CacheDateType.PersonalIndyJobs;
            }
            else
            {
                CDType = CacheDateType.CorporateIndyJobs;
            }

            // Look up the industry Blueprints cache date first      
            if (CB.DataUpdateable(CDType, ID))
            {
                IndyJobs = ESIData.GetIndustryJobs(ID, CharacterTokenData, JobType, ref CacheDate);

                if (!(IndyJobs == null))
                {
                    if (IndyJobs.Count > 0)
                    {
                        Public_Variables.EVEDB.BeginSQLiteTransaction();

                        // Clear out all the industry jobs for the user if not a corp lookup
                        if (JobType == Public_Variables.ScanType.Personal)
                        {
                            SQL = "DELETE FROM INDUSTRY_JOBS WHERE InstallerID = " + CharacterTokenData.CharacterID + " AND JobType = " + ((int)JobType).ToString();
                        }
                        else
                        {
                            // Delete all jobs and reload for corp
                            SQL = "DELETE FROM INDUSTRY_JOBS WHERE JobType = " + ((int)JobType).ToString();

                            // Also, get the list of character IDs stored in the DB with this corporation and only load those jobs
                            SQLiteDataReader rsIDs;
                            Public_Variables.DBCommand = new SQLiteCommand("SELECT CHARACTER_ID FROM ESI_CHARACTER_DATA WHERE CORPORATION_ID = " + ID.ToString(), Public_Variables.EVEDB.DBREf());
                            rsIDs = Public_Variables.DBCommand.ExecuteReader();

                            while (rsIDs.Read())
                                CorpCharIDs.Add(rsIDs.GetInt64(0));

                            rsIDs.Close();

                        }

                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                        // Insert industry data
                        for (int i = 0, loopTo = IndyJobs.Count - 1; i <= loopTo; i++)
                        {
                            // First make sure it's not already in there
                            {
                                var withBlock = IndyJobs[i];
                                // Insert it
                                if (withBlock.location_id == 0L)
                                {
                                    LocationID = withBlock.station_id;
                                }
                                else
                                {
                                    LocationID = withBlock.location_id;
                                }

                                if (JobType == Public_Variables.ScanType.Personal | CorpCharIDs.Contains(withBlock.installer_id) & JobType == Public_Variables.ScanType.Corporation) // update fields
                                {
                                    SQL = "INSERT INTO INDUSTRY_JOBS (jobID, installerID, facilityID, locationID, activityID, ";
                                    SQL += "blueprintID, blueprintTypeID, blueprintLocationID, outputLocationID, ";
                                    SQL += "runs, cost, licensedRuns, probability, productTypeID, status, duration, ";
                                    SQL += "startDate, endDate, pauseDate, completedDate, completedCharacterID, successfulRuns, JobType) VALUES (";
                                    SQL += withBlock.job_id + "," + withBlock.installer_id + "," + withBlock.facility_id + "," + LocationID + ",";
                                    // Bug fix until a decision is made to update SDE or ESI
                                    if (withBlock.activity_id == 9)
                                    {
                                        withBlock.activity_id = 11;
                                    }
                                    SQL += withBlock.activity_id + "," + withBlock.blueprint_id + "," + withBlock.blueprint_type_id + "," + withBlock.blueprint_location_id + "," + withBlock.output_location_id + ",";
                                    SQL += withBlock.runs + "," + withBlock.cost + "," + withBlock.licensed_runs + "," + withBlock.probability + "," + withBlock.product_type_id + ",'" + withBlock.status + "'," + withBlock.duration + ",";
                                    TempDate = ESIData.FormatESIDate(withBlock.start_date);
                                    if (TempDate != Public_Variables.NoDate)
                                    {
                                        SQL += "'" + Strings.Format(TempDate, Public_Variables.SQLiteDateFormat) + "',";
                                    }
                                    else
                                    {
                                        SQL += "NULL,";
                                    }
                                    TempDate = ESIData.FormatESIDate(withBlock.end_date);
                                    if (TempDate != Public_Variables.NoDate)
                                    {
                                        SQL += "'" + Strings.Format(TempDate, Public_Variables.SQLiteDateFormat) + "',";
                                    }
                                    else
                                    {
                                        SQL += "NULL,";
                                    }
                                    TempDate = ESIData.FormatESIDate(withBlock.pause_date);
                                    if (TempDate != Public_Variables.NoDate)
                                    {
                                        SQL += "'" + Strings.Format(TempDate, Public_Variables.SQLiteDateFormat) + "',";
                                    }
                                    else
                                    {
                                        SQL += "NULL,";
                                    }
                                    TempDate = ESIData.FormatESIDate(withBlock.completed_date);
                                    if (TempDate != Public_Variables.NoDate)
                                    {
                                        SQL += "'" + Strings.Format(TempDate, Public_Variables.SQLiteDateFormat) + "',";
                                    }
                                    else
                                    {
                                        SQL += "NULL,";
                                    }

                                    SQL += withBlock.completed_character_id + "," + withBlock.successful_runs + "," + ((int)JobType).ToString() + ")";

                                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                                }
                            }
                        }

                        // Now look up distinct location ids to find any public upwell structures to update
                        SQLiteDataReader rsStructure;
                        var StructureIDList = new List<long>();

                        // Select facilties only for this character, since others may not have the same rights to this token
                        SQL = "SELECT DISTINCT facilityID FROM INDUSTRY_JOBS WHERE installerID = " + ID.ToString();
                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                        rsStructure = Public_Variables.DBCommand.ExecuteReader();

                        while (rsStructure.Read())
                            StructureIDList.Add(rsStructure.GetInt64(0));

                        rsStructure.Close();

                        // Update all the structures we don't have names for
                        // Add the data
                        var SP = new StructureProcessor();
                        foreach (var StructureID in StructureIDList)
                            SP.UpdateStructureData(StructureID, Public_Variables.SelectedCharacter.CharacterTokenData, false, true);

                        Public_Variables.EVEDB.CommitSQLiteTransaction();

                    }

                    // Update cache date now that it's all set
                    CB.UpdateCacheDate(CDType, CacheDate, ID);
                }
            }

        }

    }

    public struct IndustryJob
    {
        public int JobID;
        public int InstallerID;
        public int FacilityID;
        public int LocationID;
        public int ActivityID;
        public int BlueprintID;
        public int BlueprintTypeID;
        public int BlueprintLocationID;
        public int OutputlocationID;
        public int Runs;
        public double Cost;
        public int Licensedruns;
        public double Probability;
        public int ProductTypeID;
        public int Status;
        public int Duration;
        public DateTime StartDate;
        public DateTime EndDate;
        public DateTime PauseDate;
        public DateTime CompletedDate;
        public int CompletedCharacterID;
        public int SuccessfulRuns;
        public int JobType;
    }
}