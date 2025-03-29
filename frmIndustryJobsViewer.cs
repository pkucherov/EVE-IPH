using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class frmIndustryJobsViewer
    {

        private string[] ColumnPositions = new string[22]; // For saving the column order
        private bool FirstLoad;
        private bool Updating;
        private bool AddingColumns;
        private int MovedColumn;
        private DateTime CurrentDateTime;
        private long UserIDToFind;
        private System.Threading.Timer myTimer;

        private List<IndyCharacter> LoadedCharacters = new List<IndyCharacter>(); // The list of characters to show in the industry jobs list

        private bool PauseScreenUpdate;

        private int JobListColumnClicked;
        private SortOrder JobListColumnSortOrder;
        private int AcctListColumnClicked;
        private SortOrder AcctListColumnSortOrder;

        private struct IndyCharacter
        {
            public SavedTokenData Token;
            public string Name;
            public string Corporation;
            public int IndustryLines;
            public int ResearchLines;
            public int ReactionLines;
            public int IndustryJobs;
            public int ResearchJobs;
            public int ReactionJobs;
        }

        private struct ColumnWidth
        {
            public string Name;
            public int Width;
        }

        public frmIndustryJobsViewer()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            FirstLoad = true;
            Updating = false;

            if (SettingsVariables.UserApplicationSettings.ShowToolTips)
            {
                ttMain.SetToolTip(btnSaveSettings, "Saves Column order and Sort Column");
            }

            CurrentDateTime = DateTime.UtcNow;

            PauseScreenUpdate = false;

            var myCallback = new TimerCallback(UpdateTimes);
            myTimer = new System.Threading.Timer(myCallback, lstIndustryJobs, 1000, 1000);

            // Width 725, 21 for scrollbar, 25 for check (679)
            lstCharacters.Columns.Add("", -2, HorizontalAlignment.Left);
            lstCharacters.Columns.Add("Character Name", 200, HorizontalAlignment.Left);
            lstCharacters.Columns.Add("Character Corporation", 230, HorizontalAlignment.Left);
            lstCharacters.Columns.Add("Industry Jobs", 83, HorizontalAlignment.Center);
            lstCharacters.Columns.Add("Research Jobs", 83, HorizontalAlignment.Center);
            lstCharacters.Columns.Add("Reaction Jobs", 83, HorizontalAlignment.Center);
            lstCharacters.Columns.Add("CharID", 0, HorizontalAlignment.Left); // Hidden

            chkAutoUpdate.Checked = SettingsVariables.UserIndustryJobsColumnSettings.AutoUpdateJobs;
            JobListColumnClicked = SettingsVariables.UserIndustryJobsColumnSettings.OrderByColumn;
            if (SettingsVariables.UserIndustryJobsColumnSettings.OrderType == "Ascending")
            {
                JobListColumnSortOrder = SortOrder.Ascending;
            }
            else
            {
                JobListColumnSortOrder = SortOrder.Descending;
            }

            FirstLoad = false;

        }

        private void frmIndustryJobsViewer_Shown(object sender, EventArgs e)
        {
            var fAccessError = new frmAPIError();

            FirstLoad = true;

            // See if they can load the jobs at all
            if (!Public_Variables.SelectedCharacter.IndustryJobsAccess)
            {
                fAccessError.ErrorText = "Industry Jobs cannot be loaded for this character." + Environment.NewLine + Environment.NewLine + "Please ensure to include ESI access to industry jobs.";
                fAccessError.Text = "ESI: No Industry Jobs Loaded";
                fAccessError.ErrorLink = "";
                fAccessError.ShowDialog();

                gbInventionJobs.Enabled = false;
                return;
            }

            if ((SettingsVariables.UserIndustryJobsColumnSettings.ViewJobType ?? "") == (rbtnPersonalJobs.Text ?? ""))
            {
                rbtnPersonalJobs.Checked = true;
            }
            else if ((SettingsVariables.UserIndustryJobsColumnSettings.ViewJobType ?? "") == (rbtnCorpJobs.Text ?? ""))
            {
                rbtnCorpJobs.Checked = true;
            }
            else if ((SettingsVariables.UserIndustryJobsColumnSettings.ViewJobType ?? "") == (rbtnBothJobs.Text ?? ""))
            {
                rbtnBothJobs.Checked = true;
            }
            else
            {
                rbtnPersonalJobs.Checked = true;
            }

            if ((SettingsVariables.UserIndustryJobsColumnSettings.JobTimes ?? "") == (rbtnCurrentJobs.Text ?? ""))
            {
                rbtnCurrentJobs.Checked = true;
            }
            else
            {
                rbtnJobHistory.Checked = true;
            }

            // Only update the API data if they selected it
            UpdateJobs(chkAutoUpdate.Checked);

            if (Public_Variables.FirstIndustryJobsViewerLoad)
            {
                // Don't run this if they reopen again, make them manually update
                Public_Variables.FirstIndustryJobsViewerLoad = false;
            }

            FirstLoad = false;

        }

        // Updates all the jobs
        private void UpdateJobs(bool RefreshAPI)
        {
            Updating = true;

            // Just refresh the char list and it will update from ESI
            RefreshCharacterList(RefreshAPI);
            RefreshGrid();

            if (RefreshAPI)
            {
                Interaction.MsgBox("Industry Jobs updated.", Constants.vbInformation, Application.ProductName);
            }

            Updating = false;

        }

        // Refreshes main grid with the industry jobs
        private void RefreshGrid()
        {
            string SQL;
            string CHAR_ID_SQL = "";
            SQLiteDataReader rsJobs;
            ListViewItem lstJobRow;
            string JobState;
            Color JobStateColor;

            DateTime StartDate;
            DateTime EndDate;

            string Status = "";

            if (rbtnCurrentJobs.Checked)
            {
                Text = "Current Industry Jobs";
            }
            else
            {
                Text = "Historical Industry Jobs";
            }

            Application.UseWaitCursor = true;
            Cursor = Cursors.WaitCursor;
            gbInventionJobs.Enabled = false;
            Application.DoEvents();

            // If they don't select a character, then just clear and exit
            if (lstCharacters.CheckedItems.Count == 0)
            {
                lstIndustryJobs.Items.Clear();
                goto ExitSub;
            }

            // Find out what characters we are querying for
            if (string.IsNullOrEmpty(SettingsVariables.UserIndustryJobsColumnSettings.SelectedCharacterIDs))
            {
                // Just load the selected character since the data is already refreshed
                CHAR_ID_SQL = CHAR_ID_SQL + "AND installerID = " + Public_Variables.SelectedCharacter.ID + " ";
            }
            else
            {
                // Format this for multiple character ids that were saved
                CHAR_ID_SQL = CHAR_ID_SQL + "AND installerID IN (";
                for (int j = 0, loopTo = LoadedCharacters.Count - 1; j <= loopTo; j++)
                {
                    if (SettingsVariables.UserIndustryJobsColumnSettings.SelectedCharacterIDs.Contains(LoadedCharacters[j].Token.CharacterID.ToString()))
                    {
                        CHAR_ID_SQL = CHAR_ID_SQL + LoadedCharacters[j].Token.CharacterID.ToString() + ",";
                    }
                }
                CHAR_ID_SQL = CHAR_ID_SQL.Substring(0, Strings.Len(CHAR_ID_SQL) - 1) + ")";
            }

            // Load up the charcters from the table (instead of objects) for speed and ease of loading
            SQL = "SELECT CHARACTER_NAME AS Installer, activityName AS Activity, ABS.BLUEPRINT_NAME as Blueprint, ";
            SQL += "ABS.ITEM_NAME AS 'Output Item', status, startDate, endDate, ABS.ITEM_GROUP AS 'Output Item Type', ";
            SQL += " CASE WHEN SOLAR_SYSTEMS.solarSystemName IS NOT NULL THEN SOLAR_SYSTEMS.solarSystemName ELSE 'Unknown System' END AS 'Install System', ";
            SQL += "CASE WHEN REGIONS.regionName Is Not NULL THEN REGIONS.regionName ELSE 'Unknown Region' END AS 'Install Region',";
            SQL += "licensedRuns, runs, successfulRuns, ";
            SQL += "CASE WHEN S1.STATION_NAME IS NOT NULL THEN S1.STATION_NAME ELSE ";
            SQL += "(CASE WHEN C1.STATION_NAME IS NOT NULL THEN C1.STATION_NAME || ' Container' ELSE ";
            SQL += "(CASE WHEN IT2.typeName IS NOT NULL THEN IT2.typeName ELSE ";
            SQL += "(CASE WHEN S3.STATION_NAME IS NOT NULL THEN S3.STATION_NAME ELSE 'Unknown' END) END) END) END AS 'Blueprint Location', ";
            SQL += "CASE WHEN S2.STATION_NAME IS NOT NULL THEN S2.STATION_NAME ELSE ";
            SQL += "(CASE WHEN C2.STATION_NAME IS NOT NULL THEN C2.STATION_NAME || ' Container' ELSE ";
            SQL += "(CASE WHEN IT3.typeName IS NOT NULL THEN IT3.typeName ELSE ";
            SQL += "(CASE WHEN S3.STATION_NAME IS NOT NULL THEN S3.STATION_NAME ELSE 'Unknown' END) END) END) END AS 'Output Location', ";
            SQL += "CASE WHEN jobType =1 THEN 'Corporation' ELSE 'Personal' END AS 'Job Type' ";
            SQL += "FROM INDUSTRY_JOBS, INDUSTRY_ACTIVITIES, ESI_CHARACTER_DATA, ALL_BLUEPRINTS AS ABS ";
            SQL += "LEFT JOIN STATIONS ON STATIONS.STATION_ID = INDUSTRY_JOBS.locationID ";
            SQL += "LEFT JOIN SOLAR_SYSTEMS ON STATIONS.SOLAR_SYSTEM_ID = SOLAR_SYSTEMS.solarSystemID ";
            SQL += "LEFT JOIN REGIONS ON SOLAR_SYSTEMS.regionID = REGIONS.regionID ";

            // Stations
            SQL += "LEFT OUTER JOIN (SELECT STATION_ID, STATION_NAME FROM STATIONS) AS S1 ON S1.STATION_ID = INDUSTRY_JOBS.blueprintLocationID ";
            SQL += "LEFT OUTER JOIN (SELECT STATION_ID, STATION_NAME FROM STATIONS) AS S2 ON S2.STATION_ID = INDUSTRY_JOBS.outputLocationID ";
            SQL += "LEFT OUTER JOIN (SELECT STATION_ID, STATION_NAME FROM STATIONS) AS S3 ON S3.STATION_ID = INDUSTRY_JOBS.locationID ";
            // Containers in stations
            SQL += "LEFT OUTER JOIN (SELECT STATION_ID, STATION_NAME, A1.ItemID FROM STATIONS LEFT OUTER JOIN (SELECT LocationID, ItemID FROM ASSETS WHERE ID = " + Public_Variables.SelectedCharacter.ID + ") ";
            SQL += "AS A1 ON A1.LocationID = STATION_ID) AS C1 ON C1.ItemID = INDUSTRY_JOBS.blueprintLocationID ";
            SQL += "LEFT OUTER JOIN (SELECT STATION_ID, STATION_NAME, A2.ItemID FROM STATIONS LEFT OUTER JOIN (SELECT LocationID, ItemID FROM ASSETS WHERE ID = " + Public_Variables.SelectedCharacter.ID + ") ";
            SQL += "AS A2 ON A2.LocationID = STATION_ID) AS C2 ON C2.ItemID = INDUSTRY_JOBS.blueprintLocationID ";
            // POS modules
            SQL += "LEFT OUTER JOIN (SELECT typeID, typeName FROM INVENTORY_TYPES) AS IT2 ON IT2.typeID = INDUSTRY_JOBS.blueprintLocationID ";
            SQL += "LEFT OUTER JOIN (SELECT typeID, typeName FROM INVENTORY_TYPES) AS IT3 ON IT3.typeID = INDUSTRY_JOBS.outputLocationID ";

            SQL += "WHERE INDUSTRY_JOBS.activityID = INDUSTRY_ACTIVITIES.activityID  ";
            SQL += "AND INDUSTRY_JOBS.blueprintTypeID = ABS.BLUEPRINT_ID ";
            SQL += "AND ESI_CHARACTER_DATA.CHARACTER_ID = INDUSTRY_JOBS.installerID ";

            if (rbtnCurrentJobs.Checked)
            {
                // Only check status for current jobs
                SQL += "AND status = 'active' ";
            }

            // Add the charids
            SQL += CHAR_ID_SQL;

            // For both just ignore the selections
            if (rbtnCorpJobs.Checked)
            {
                SQL += "AND JobType = " + ((int)Public_Variables.ScanType.Corporation).ToString() + " ";
            }
            else if (rbtnPersonalJobs.Checked)
            {
                SQL += CHAR_ID_SQL + "AND JobType = " + ((int)Public_Variables.ScanType.Personal).ToString() + " ";
            }

            // Add sorting options here
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsJobs = Public_Variables.DBCommand.ExecuteReader();

            lstIndustryJobs.BeginUpdate();
            RefreshColumns();

            while (rsJobs.Read())
            {
                Application.DoEvents();

                Status = rsJobs.GetString(4);
                StartDate = Conversions.ToDate(rsJobs.GetString(5));
                EndDate = Conversions.ToDate(rsJobs.GetString(6));

                // active, cancelled, delivered, paused, ready, reverted
                switch (Status ?? "")
                {
                    case "active":
                        {
                            // Job State Flag
                            if (EndDate <= CurrentDateTime)
                            {
                                // Job is done
                                JobState = "Complete";
                                JobStateColor = Color.Green;
                            }
                            else if (StartDate <= CurrentDateTime)
                            {
                                JobState = "In Progress";
                                JobStateColor = Color.DarkOrange;
                            }
                            else
                            {
                                JobState = "Pending";
                                JobStateColor = Color.Orange;
                            }

                            break;
                        }
                    case "delivered":
                        {
                            // This has been completed
                            JobState = "Completed";
                            JobStateColor = Color.DarkGray;
                            break;
                        }
                    case "cancelled":
                        {
                            JobState = "Cancelled";
                            JobStateColor = Color.Red;
                            break;
                        }
                    case "paused":
                        {
                            JobState = "Paused";
                            JobStateColor = Color.Gray;
                            break;
                        }
                    case "ready":
                        {
                            JobState = "Ready";
                            JobStateColor = Color.Blue;
                            break;
                        }
                    case "reverted":
                        {
                            JobState = "Reverted";
                            JobStateColor = Color.Purple;
                            break;
                        }

                    default:
                        {
                            JobState = "Unknown";
                            JobStateColor = Color.DarkRed;
                            break;
                        }
                }

                lstIndustryJobs.ListViewItemSorter = null;
                // Always add the end time to column 0 for sorting 
                lstJobRow = new ListViewItem(rsJobs.GetString(6));
                lstJobRow.UseItemStyleForSubItems = false;

                {
                    ref var withBlock = ref SettingsVariables.UserIndustryJobsColumnSettings;
                    for (int i = 1, loopTo1 = ColumnPositions.Count() - 1; i <= loopTo1; i++)
                    {
                        switch (ColumnPositions[i] ?? "")
                        {
                            case ProgramSettings.JobStateColumn:
                                {
                                    lstJobRow.SubItems.Add(JobState); // Job State
                                    lstJobRow.SubItems[Array.IndexOf(ColumnPositions, "Job State")].ForeColor = JobStateColor;
                                    break;
                                }
                            case ProgramSettings.InstallerNameColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(0));
                                    break;
                                }
                            case ProgramSettings.TimetoCompleteColumn:
                                {
                                    if (JobState != "Complete" & JobState != "Completed")
                                    {
                                        lstJobRow.SubItems.Add(GetTimeToComplete(EndDate, CurrentDateTime));
                                    }
                                    else
                                    {
                                        lstJobRow.SubItems.Add("");
                                    }

                                    break;
                                }
                            case ProgramSettings.LocalCompletionDateTimeColumn:
                                {
                                    if (JobState != "Complete" & JobState != "Completed")
                                    {
                                        lstJobRow.SubItems.Add("Calculating...");
                                    }
                                    else
                                    {
                                        lstJobRow.SubItems.Add("");
                                    }

                                    break;
                                }
                            case ProgramSettings.ActivityColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(1));
                                    break;
                                }
                            case ProgramSettings.StatusColumn:
                                {
                                    if (rsJobs.GetString(4) == "active")
                                    {
                                        lstJobRow.SubItems.Add("Delivered");
                                    }
                                    else if (JobState == "Completed")
                                    {
                                        lstJobRow.SubItems.Add("Ready for Delivery");
                                    }
                                    else
                                    {
                                        lstJobRow.SubItems.Add("In Progress");
                                    }

                                    break;
                                }
                            case ProgramSettings.StartTimeColumn:
                                {
                                    lstJobRow.SubItems.Add(Conversions.ToString(StartDate));
                                    break;
                                }
                            case ProgramSettings.EndTimeColumn:
                                {
                                    lstJobRow.SubItems.Add(Conversions.ToString(EndDate));
                                    break;
                                }
                            case ProgramSettings.CompletionTimeColumn:
                                {
                                    if (JobState == "Completed")
                                    {
                                        lstJobRow.SubItems.Add(rsJobs.GetString(4));
                                    }
                                    else
                                    {
                                        lstJobRow.SubItems.Add("");
                                    }

                                    break;
                                }
                            case ProgramSettings.BlueprintColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(2));
                                    break;
                                }
                            case ProgramSettings.OutputItemColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(3));
                                    break;
                                }
                            case ProgramSettings.OutputItemTypeColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(7));
                                    break;
                                }
                            case ProgramSettings.InstallSolarSystemColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(8));
                                    break;
                                }
                            case ProgramSettings.InstallRegionColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(9));
                                    break;
                                }
                            case ProgramSettings.LicensedRunsColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetInt32(10).ToString());
                                    break;
                                }
                            case ProgramSettings.RunsColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetInt32(11).ToString());
                                    break;
                                }
                            case ProgramSettings.SuccessfulRunsColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetInt32(12).ToString());
                                    break;
                                }
                            case ProgramSettings.BlueprintLocationColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(13));
                                    break;
                                }
                            case ProgramSettings.OutputLocationColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(14));
                                    break;
                                }
                            case ProgramSettings.JobTypeColumn:
                                {
                                    lstJobRow.SubItems.Add(rsJobs.GetString(15));
                                    break;
                                }
                        }
                    }
                }

                lstIndustryJobs.Items.Add(lstJobRow);

            }

            lstIndustryJobs.EndUpdate();

            // Force last sort order to switch to ascending and sort by the user column
            var argRefListView = lstIndustryJobs;
            Public_Variables.ListViewColumnSorter(SettingsVariables.UserIndustryJobsColumnSettings.OrderByColumn, ref argRefListView, ref JobListColumnClicked, ref JobListColumnSortOrder, true);
            lstIndustryJobs = argRefListView;

        ExitSub:
            ;

            Application.UseWaitCursor = false;
            gbInventionJobs.Enabled = true;
            Cursor = Cursors.Default;
            Application.DoEvents();

        }

        // Refreshes the user grid with all users in the DB
        private void RefreshCharacterList(bool UpdateAPIData)
        {
            ListViewItem lstCharacterRow;
            string SQL;
            SQLiteDataReader rsJobs;

            Application.UseWaitCursor = true;
            // Me.Cursor = Cursors.WaitCursor
            gbInventionJobs.Enabled = false;
            Application.DoEvents();

            // Update the data for each character first if selected
            if (UpdateAPIData)
            {
                UpdateLoadedCharacterData();
            }

            // Now jobs and skills should show correctly
            SQL = "SELECT CHARACTER_NAME, CORPORATION_NAME, ECD.CHARACTER_ID, ";
            SQL += "ACCESS_TOKEN, ACCESS_TOKEN_EXPIRE_DATE_TIME, REFRESH_TOKEN, TOKEN_TYPE, SCOPES, ";
            SQL += "CASE WHEN RESEARCH_JOBS IS NULL THEN 0 ELSE RESEARCH_JOBS END AS RESEARCH_JOBS, ";
            SQL += "CASE WHEN RESEARCH_LINES IS NULL THEN 1 ELSE RESEARCH_LINES END AS RESEARCH_LINES, ";
            SQL += "CASE WHEN JOB_COUNT IS NULL THEN 0 ELSE JOB_COUNT END AS JOB_COUNT, ";
            SQL += "CASE WHEN INDUSTRY_LINES IS NULL THEN 1 ELSE INDUSTRY_LINES END AS INDUSTRY_LINES, ";
            SQL += "CASE WHEN REACTION_JOBS IS NULL THEN 0 ELSE REACTION_JOBS END AS REACTION_JOBS, ";
            SQL += "CASE WHEN REACTION_LINES IS NULL THEN 1 ELSE REACTION_LINES END AS REACTION_LINES ";
            SQL += "FROM ESI_CHARACTER_DATA AS ECD, ESI_CORPORATION_DATA AS ECPD ";
            SQL += "LEFT JOIN (SELECT SUM({0}) + 1 AS RESEARCH_LINES, CHARACTER_ID FROM CHARACTER_SKILLS WHERE SKILL_TYPE_ID IN (3406,24624) GROUP BY CHARACTER_ID) AS I ON I.CHARACTER_ID = ECD.CHARACTER_ID ";
            SQL += "LEFT JOIN (SELECT installerID, COUNT(*) AS RESEARCH_JOBS FROM INDUSTRY_JOBS WHERE STATUS = 'active' AND activityID NOT IN (1,11) GROUP BY installerID) AS J ON J.installerID = ECD.CHARACTER_ID ";
            SQL += "LEFT JOIN (SELECT SUM({0}) + 1 AS INDUSTRY_LINES, CHARACTER_ID FROM CHARACTER_SKILLS WHERE SKILL_TYPE_ID IN (3387,24625) GROUP BY CHARACTER_ID) AS K ON K.CHARACTER_ID = ECD.CHARACTER_ID ";
            SQL += "LEFT JOIN (SELECT installerID, COUNT(*) AS JOB_COUNT FROM INDUSTRY_JOBS WHERE STATUS = 'active' AND activityID = 1 GROUP BY installerID) AS L ON L.installerID = ECD.CHARACTER_ID ";
            SQL += "LEFT JOIN (SELECT SUM({0}) + 1 AS REACTION_LINES, CHARACTER_ID FROM CHARACTER_SKILLS WHERE SKILL_TYPE_ID IN (45748,45749) GROUP BY CHARACTER_ID) AS M ON M.CHARACTER_ID = ECD.CHARACTER_ID ";
            SQL += "LEFT JOIN (SELECT installerID, COUNT(*) AS REACTION_JOBS FROM INDUSTRY_JOBS WHERE STATUS = 'active' AND activityID = 11 GROUP BY installerID) AS N ON N.installerID = ECD.CHARACTER_ID ";
            SQL += "WHERE ECD.CORPORATION_ID = ECPD.CORPORATION_ID AND ECD.CHARACTER_ID <> " + Public_Variables.DummyCharacterID.ToString();

            string SkillLevelField = "";
            if (SettingsVariables.UserApplicationSettings.UseActiveSkillLevels)
            {
                SkillLevelField = "ACTIVE_SKILL_LEVEL";
            }
            else
            {
                SkillLevelField = "TRAINED_SKILL_LEVEL";
            }

            SQL = string.Format(SQL, SkillLevelField);

            // Get all the characters and store them regardless so we only need to do one look up
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsJobs = Public_Variables.DBCommand.ExecuteReader();

            LoadedCharacters = new List<IndyCharacter>();

            while (rsJobs.Read())
            {
                // Load up the data for this character id in the list and check it
                var TempToken = new SavedTokenData();
                TempToken.CharacterID = rsJobs.GetInt32(2);
                TempToken.AccessToken = rsJobs.GetString(3);
                TempToken.TokenExpiration = Conversions.ToDate(rsJobs.GetString(4));
                TempToken.RefreshToken = rsJobs.GetString(5);
                TempToken.TokenType = rsJobs.GetString(6);
                TempToken.Scopes = rsJobs.GetString(7);

                IndyCharacter TempCharacter;

                TempCharacter.Token = TempToken;
                TempCharacter.Name = rsJobs.GetString(0);
                TempCharacter.Corporation = rsJobs.GetString(1);

                // Industry Runs and lines
                TempCharacter.ResearchJobs = rsJobs.GetInt32(8);
                TempCharacter.ResearchLines = rsJobs.GetInt32(9);
                TempCharacter.IndustryJobs = rsJobs.GetInt32(10);
                TempCharacter.IndustryLines = rsJobs.GetInt32(11);
                TempCharacter.ReactionJobs = rsJobs.GetInt32(12);
                TempCharacter.ReactionLines = rsJobs.GetInt32(13);

                // Add this to the list
                if (!LoadedCharacters.Contains(TempCharacter))
                {
                    LoadedCharacters.Add(TempCharacter);
                }

                Application.DoEvents();

            }

            lstCharacters.BeginUpdate();
            lstCharacters.Items.Clear();

            for (int i = 0, loopTo = LoadedCharacters.Count - 1; i <= loopTo; i++)
            {
                Application.DoEvents();
                {
                    var withBlock = LoadedCharacters[i];
                    lstCharacterRow = new ListViewItem(""); // Check
                    lstCharacterRow.SubItems.Add(withBlock.Name); // Name
                    lstCharacterRow.SubItems.Add(withBlock.Corporation);

                    // Add the jobs as part of lines i.e 4/10 = 4 jobs of 10 lines
                    lstCharacterRow.SubItems.Add(withBlock.IndustryJobs.ToString() + "/" + withBlock.IndustryLines.ToString());
                    lstCharacterRow.SubItems.Add(withBlock.ResearchJobs.ToString() + "/" + withBlock.ResearchLines.ToString());
                    lstCharacterRow.SubItems.Add(withBlock.ReactionJobs.ToString() + "/" + withBlock.ReactionLines.ToString());

                    // Add the hidden character ID
                    string CharacterID = withBlock.Token.CharacterID.ToString();
                    lstCharacterRow.SubItems.Add(CharacterID);

                    if (SettingsVariables.UserIndustryJobsColumnSettings.SelectedCharacterIDs.Contains(CharacterID))
                    {
                        // In the list so check it
                        lstCharacterRow.Checked = true;
                    }

                    else if (string.IsNullOrEmpty(SettingsVariables.UserIndustryJobsColumnSettings.SelectedCharacterIDs) & (withBlock.Name ?? "") == (Public_Variables.SelectedCharacter.Name ?? ""))
                    {
                        // Empty list of selected chars and this is the same as the one we pulled
                        lstCharacterRow.Checked = true;
                    }
                }

                lstCharacters.Items.Add(lstCharacterRow);

            }

            lstCharacters.EndUpdate();

            gbInventionJobs.Enabled = true;
            Application.UseWaitCursor = false;
            Application.DoEvents();

        }

        // Updates the industry jobs and skills for the characters in the list
        private void UpdateLoadedCharacterData()
        {
            var f1 = new frmStatus();
            string SQL;
            SQLiteDataReader rsCharacters;

            var TempCharacter = new Character();
            var TokenData = new SavedTokenData();

            f1.lblStatus.Text = "Updating Character data...";
            f1.Show();
            Application.UseWaitCursor = true;
            Application.DoEvents();

            // Pause updates if we are using the update jobs button
            PauseScreenUpdate = true;

            SQL = "SELECT CHARACTER_ID FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID <> " + Public_Variables.DummyCharacterID.ToString();
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsCharacters = Public_Variables.DBCommand.ExecuteReader();

            // Get all the character ids loaded and refresh them on skills and jobs
            while (rsCharacters.Read())
            {
                TempCharacter = new Character();
                TokenData.CharacterID = rsCharacters.GetInt32(0);
                // Loading a character will update the jobs and skills
                TempCharacter.LoadCharacterData(ref TokenData, false, false, true);
                Application.DoEvents();
            }

            PauseScreenUpdate = false;

            f1.Dispose();
            f1 = null;
            Select();
            Application.UseWaitCursor = false;
            Application.DoEvents();

        }

        private string GetCharIDs()
        {
            string CharIDs = "";

            for (int i = 0, loopTo = lstCharacters.CheckedItems.Count - 1; i <= loopTo; i++)
                CharIDs = CharIDs + lstCharacters.CheckedItems[i].SubItems[6].Text + ",";

            // Strip the last comma
            if (!string.IsNullOrEmpty(CharIDs))
            {
                CharIDs = CharIDs.Substring(0, Strings.Len(CharIDs) - 1);
            }

            return CharIDs;

        }

        private delegate void ListDelegate(ListView myJobList);

        private void UpdateTimes(object sentJobList)
        {
            string TimeToComplete;
            DateTime EndDate;

            if (PauseScreenUpdate)
            {
                return;
            }

            var myJobList = new ListView();
            myJobList = (ListView)sentJobList;

            if (myJobList.InvokeRequired)
            {
                myJobList.Invoke(new ListDelegate(UpdateTimes), myJobList);
                return;
            }

            try
            {
                // On each tick just update the time column manually
                {
                    ref var withBlock = ref SettingsVariables.UserIndustryJobsColumnSettings;
                    if (withBlock.TimeToComplete != 0 | withBlock.LocalCompletionDateTime != 0) // only if the time to complete column or local complete date column is visible
                    {
                        CurrentDateTime = DateAndTime.DateAdd(DateInterval.Second, 1d, CurrentDateTime);
                        Application.DoEvents();

                        for (int i = 0, loopTo = myJobList.Items.Count - 1; i <= loopTo; i++)
                        {
                            // Only update records with a time
                            if (myJobList.Items[i].SubItems[withBlock.JobState].Text != "Complete" & myJobList.Items[i].SubItems[withBlock.JobState].Text != "Completed")
                            {

                                EndDate = Conversions.ToDate(myJobList.Items[i].SubItems[0].Text);
                                TimeToComplete = GetTimeToComplete(EndDate, CurrentDateTime);

                                // If the time comes back negative, then switch it to blank and reset the job state to 'Complete'
                                if (string.IsNullOrEmpty(TimeToComplete))
                                {
                                    TimeToComplete = "0";
                                }

                                // Update time to complete
                                if (withBlock.TimeToComplete != 0)
                                {
                                    if (TimeToComplete.Substring(0, 1) == "-" | TimeToComplete == "0")
                                    {
                                        myJobList.Items[i].SubItems[withBlock.TimeToComplete].Text = "";
                                        myJobList.Items[i].SubItems[withBlock.JobState].Text = "Complete";
                                        myJobList.Items[i].SubItems[withBlock.JobState].ForeColor = Color.Green;
                                    }
                                    else
                                    {
                                        myJobList.Items[i].SubItems[withBlock.TimeToComplete].Text = TimeToComplete;
                                    }
                                }

                                // Update local completion time
                                if (withBlock.LocalCompletionDateTime != 0)
                                {
                                    if (TimeToComplete.Substring(0, 1) == "-" | TimeToComplete == "0")
                                    {
                                        myJobList.Items[i].SubItems[withBlock.LocalCompletionDateTime].Text = "";
                                    }
                                    else
                                    {
                                        myJobList.Items[i].SubItems[withBlock.LocalCompletionDateTime].Text = DateAndTime.DateAdd(DateInterval.Second, DateAndTime.DateDiff(DateInterval.Second, CurrentDateTime, EndDate), DateTime.Now).ToString();
                                    }
                                }

                                myJobList.Update();
                                Application.DoEvents();

                                if ((myJobList.Items[i].SubItems[withBlock.LocalCompletionDateTime].Text ?? "") == (TimeToComplete ?? ""))
                                {
                                    Application.DoEvents();
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                // Don't do anything, just let it update next go around
            }

            Application.DoEvents();

        }

        private string GetTimeToComplete(DateTime EndJobDate, DateTime CompareDate)
        {
            long SecondsDiff;

            SecondsDiff = DateAndTime.DateDiff(DateInterval.Second, CompareDate, EndJobDate);

            return Public_Variables.FormatTimeToComplete(SecondsDiff);

        }

        private void frmIndustryJobsViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                myTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            catch (Exception)
            {
            }
        }

        #region Click events

        // Clears the list and rebuilds it with columns they selected
        private void RefreshColumns()
        {

            LoadIndustryJobColumnPositions();

            lstIndustryJobs.Clear();
            AddingColumns = true;

            // Add an empty Column
            lstIndustryJobs.Columns.Add("");

            // Now load all the columns in order of the settings
            for (int i = 1, loopTo = ColumnPositions.Count() - 1; i <= loopTo; i++)
            {
                if (!string.IsNullOrEmpty(ColumnPositions[i]))
                {
                    lstIndustryJobs.Columns.Add(ColumnPositions[i], GetColumnWidth(ColumnPositions[i]), GetColumnAlignment(ColumnPositions[i]));
                }
            }

            // Empty Column not visible
            lstIndustryJobs.Columns[0].Width = 0;

            AddingColumns = false;

        }

        // Takes the column settings and saves the order to an array
        private void LoadIndustryJobColumnPositions()
        {

            for (int i = 0, loopTo = ColumnPositions.Count() - 1; i <= loopTo; i++)
                ColumnPositions[i] = "";

            {
                ref var withBlock = ref SettingsVariables.UserIndustryJobsColumnSettings;
                ColumnPositions[withBlock.JobState] = ProgramSettings.JobStateColumn;
                ColumnPositions[withBlock.InstallerName] = ProgramSettings.InstallerNameColumn;
                ColumnPositions[withBlock.TimeToComplete] = ProgramSettings.TimetoCompleteColumn;
                ColumnPositions[withBlock.Activity] = ProgramSettings.ActivityColumn;
                ColumnPositions[withBlock.Status] = ProgramSettings.StatusColumn;
                ColumnPositions[withBlock.StartTime] = ProgramSettings.StartTimeColumn;
                ColumnPositions[withBlock.EndTime] = ProgramSettings.EndTimeColumn;
                ColumnPositions[withBlock.CompletionTime] = ProgramSettings.CompletionTimeColumn;
                ColumnPositions[withBlock.Blueprint] = ProgramSettings.BlueprintColumn;
                ColumnPositions[withBlock.OutputItem] = ProgramSettings.OutputItemColumn;
                ColumnPositions[withBlock.OutputItemType] = ProgramSettings.OutputItemTypeColumn;
                ColumnPositions[withBlock.InstallSystem] = ProgramSettings.InstallSolarSystemColumn;
                ColumnPositions[withBlock.InstallRegion] = ProgramSettings.InstallRegionColumn;
                ColumnPositions[withBlock.LicensedRuns] = ProgramSettings.LicensedRunsColumn;
                ColumnPositions[withBlock.Runs] = ProgramSettings.RunsColumn;
                ColumnPositions[withBlock.SuccessfulRuns] = ProgramSettings.SuccessfulRunsColumn;
                ColumnPositions[withBlock.BlueprintLocation] = ProgramSettings.BlueprintLocationColumn;
                ColumnPositions[withBlock.OutputLocation] = ProgramSettings.OutputLocationColumn;
                ColumnPositions[withBlock.JobType] = ProgramSettings.JobTypeColumn;
                ColumnPositions[withBlock.LocalCompletionDateTime] = ProgramSettings.LocalCompletionDateTimeColumn;
            }

            // Reset the first one with nothing since the first column is empty
            ColumnPositions[0] = "";

        }

        // Returns the column Width for the sent column name
        private int GetColumnWidth(string ColumnName)
        {

            {
                ref var withBlock = ref SettingsVariables.UserIndustryJobsColumnSettings;
                switch (ColumnName ?? "")
                {
                    case ProgramSettings.JobStateColumn:
                        {
                            return withBlock.JobStateWidth;
                        }
                    case ProgramSettings.InstallerNameColumn:
                        {
                            return withBlock.InstallerNameWidth;
                        }
                    case ProgramSettings.TimetoCompleteColumn:
                        {
                            return withBlock.TimeToCompleteWidth;
                        }
                    case ProgramSettings.ActivityColumn:
                        {
                            return withBlock.ActivityWidth;
                        }
                    case ProgramSettings.StatusColumn:
                        {
                            return withBlock.StatusWidth;
                        }
                    case ProgramSettings.StartTimeColumn:
                        {
                            return withBlock.StartTimeWidth;
                        }
                    case ProgramSettings.EndTimeColumn:
                        {
                            return withBlock.EndTimeWidth;
                        }
                    case ProgramSettings.CompletionTimeColumn:
                        {
                            return withBlock.CompletionTimeWidth;
                        }
                    case ProgramSettings.BlueprintColumn:
                        {
                            return withBlock.BlueprintWidth;
                        }
                    case ProgramSettings.OutputItemColumn:
                        {
                            return withBlock.OutputItemWidth;
                        }
                    case ProgramSettings.OutputItemTypeColumn:
                        {
                            return withBlock.OutputItemTypeWidth;
                        }
                    case ProgramSettings.InstallSolarSystemColumn:
                        {
                            return withBlock.InstallSystemWidth;
                        }
                    case ProgramSettings.InstallRegionColumn:
                        {
                            return withBlock.InstallRegionWidth;
                        }
                    case ProgramSettings.LicensedRunsColumn:
                        {
                            return withBlock.LicensedRunsWidth;
                        }
                    case ProgramSettings.RunsColumn:
                        {
                            return withBlock.RunsWidth;
                        }
                    case ProgramSettings.SuccessfulRunsColumn:
                        {
                            return withBlock.SuccessfulRunsWidth;
                        }
                    case ProgramSettings.BlueprintLocationColumn:
                        {
                            return withBlock.BlueprintLocationWidth;
                        }
                    case ProgramSettings.OutputLocationColumn:
                        {
                            return withBlock.OutputLocationWidth;
                        }
                    case ProgramSettings.JobTypeColumn:
                        {
                            return withBlock.JobTypeWidth;
                        }
                    case ProgramSettings.LocalCompletionDateTimeColumn:
                        {
                            return withBlock.LocalCompletionDateTimeWidth;
                        }

                    default:
                        {
                            return 0;
                        }
                }
            }

        }

        // Returns the allignment for the column name sent
        private HorizontalAlignment GetColumnAlignment(string ColumnName)
        {

            switch (ColumnName ?? "")
            {
                case ProgramSettings.JobStateColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.InstallerNameColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.TimetoCompleteColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.ActivityColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.StartTimeColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.EndTimeColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.CompletionTimeColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.BlueprintColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.OutputItemColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.OutputItemTypeColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.InstallSolarSystemColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.InstallRegionColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.LicensedRunsColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.RunsColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.SuccessfulRunsColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.BlueprintLocationColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.OutputLocationColumn:
                    {
                        return HorizontalAlignment.Left;
                    }
                case ProgramSettings.JobTypeColumn:
                    {
                        return HorizontalAlignment.Left;
                    }

                default:
                    {
                        return 0;
                    }
            }

        }

        // Updates the column order when changed
        private void lstIndustryJobs_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            var TempArray = new string[22];
            bool Minus1 = false;

            e.Cancel = true; // Cancel the event so we can manually update the grid columns

            // First index is ""
            TempArray[0] = "";

            if (e.OldDisplayIndex > e.NewDisplayIndex)
            {
                // For all indices larger than the new index, need to move it to the next array
                for (int i = 1, loopTo = e.NewDisplayIndex - 1; i <= loopTo; i++)
                    TempArray[i] = ColumnPositions[i];

                // Insert the new column
                TempArray[e.NewDisplayIndex] = ColumnPositions[e.OldDisplayIndex];

                // Move all the rest of the items up one
                for (int i = e.NewDisplayIndex + 1, loopTo1 = TempArray.Count() - 1; i <= loopTo1; i++)
                {
                    if (i < e.OldDisplayIndex + 1)
                    {
                        TempArray[i] = ColumnPositions[i - 1];
                    }
                    else
                    {
                        TempArray[i] = ColumnPositions[i];
                    }
                }
            }
            else
            {
                // For all indices larger than the new index, need to move it to the next array
                for (int i = 1, loopTo2 = e.OldDisplayIndex - 1; i <= loopTo2; i++)
                    TempArray[i] = ColumnPositions[i];

                // Insert the new column
                TempArray[e.NewDisplayIndex] = ColumnPositions[e.OldDisplayIndex];

                // Back fill the array between the column we moved and the new location
                for (int i = e.OldDisplayIndex, loopTo3 = e.NewDisplayIndex - 1; i <= loopTo3; i++)
                    TempArray[i] = ColumnPositions[i + 1];

                // Replace all the items left
                for (int i = e.NewDisplayIndex + 1, loopTo4 = TempArray.Count() - 1; i <= loopTo4; i++)
                    TempArray[i] = ColumnPositions[i];

            }

            ColumnPositions = TempArray;

            // Savel the columns based on the current order
            {
                ref var withBlock = ref SettingsVariables.UserIndustryJobsColumnSettings;
                for (int i = 1, loopTo5 = ColumnPositions.Count() - 1; i <= loopTo5; i++)
                {
                    switch (ColumnPositions[i] ?? "")
                    {
                        case ProgramSettings.JobStateColumn:
                            {
                                withBlock.JobState = i;
                                break;
                            }
                        case ProgramSettings.InstallerNameColumn:
                            {
                                withBlock.InstallerName = i;
                                break;
                            }
                        case ProgramSettings.TimetoCompleteColumn:
                            {
                                withBlock.TimeToComplete = i;
                                break;
                            }
                        case ProgramSettings.ActivityColumn:
                            {
                                withBlock.Activity = i;
                                break;
                            }
                        case ProgramSettings.StatusColumn:
                            {
                                withBlock.Status = i;
                                break;
                            }
                        case ProgramSettings.StartTimeColumn:
                            {
                                withBlock.StartTime = i;
                                break;
                            }
                        case ProgramSettings.EndTimeColumn:
                            {
                                withBlock.EndTime = i;
                                break;
                            }
                        case ProgramSettings.CompletionTimeColumn:
                            {
                                withBlock.CompletionTime = i;
                                break;
                            }
                        case ProgramSettings.BlueprintColumn:
                            {
                                withBlock.Blueprint = i;
                                break;
                            }
                        case ProgramSettings.OutputItemColumn:
                            {
                                withBlock.OutputItem = i;
                                break;
                            }
                        case ProgramSettings.OutputItemTypeColumn:
                            {
                                withBlock.OutputItemType = i;
                                break;
                            }
                        case ProgramSettings.InstallSolarSystemColumn:
                            {
                                withBlock.InstallSystem = i;
                                break;
                            }
                        case ProgramSettings.InstallRegionColumn:
                            {
                                withBlock.InstallRegion = i;
                                break;
                            }
                        case ProgramSettings.LicensedRunsColumn:
                            {
                                withBlock.LicensedRuns = i;
                                break;
                            }
                        case ProgramSettings.RunsColumn:
                            {
                                withBlock.Runs = i;
                                break;
                            }
                        case ProgramSettings.SuccessfulRunsColumn:
                            {
                                withBlock.SuccessfulRuns = i;
                                break;
                            }
                        case ProgramSettings.BlueprintLocationColumn:
                            {
                                withBlock.BlueprintLocation = i;
                                break;
                            }
                        case ProgramSettings.OutputLocationColumn:
                            {
                                withBlock.OutputLocation = i;
                                break;
                            }
                        case ProgramSettings.JobTypeColumn:
                            {
                                withBlock.JobType = i;
                                break;
                            }
                        case ProgramSettings.LocalCompletionDateTimeColumn:
                            {
                                withBlock.LocalCompletionDateTime = i;
                                break;
                            }
                    }
                }
            }

            // Now Refresh the grid
            RefreshGrid();

        }

        // Updates the column sizes when changed
        private void lstIndustryJobs_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            int NewWidth = lstIndustryJobs.Columns[e.ColumnIndex].Width;

            if (!AddingColumns)
            {
                {
                    ref var withBlock = ref SettingsVariables.UserIndustryJobsColumnSettings;
                    switch (ColumnPositions[e.ColumnIndex] ?? "")
                    {
                        case ProgramSettings.JobStateColumn:
                            {
                                withBlock.JobStateWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.InstallerNameColumn:
                            {
                                withBlock.InstallerNameWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.TimetoCompleteColumn:
                            {
                                withBlock.TimeToCompleteWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.ActivityColumn:
                            {
                                withBlock.ActivityWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.StatusColumn:
                            {
                                withBlock.StatusWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.StartTimeColumn:
                            {
                                withBlock.StartTimeWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.EndTimeColumn:
                            {
                                withBlock.EndTimeWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.CompletionTimeColumn:
                            {
                                withBlock.CompletionTimeWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.BlueprintColumn:
                            {
                                withBlock.BlueprintWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.OutputItemColumn:
                            {
                                withBlock.OutputItemWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.OutputItemTypeColumn:
                            {
                                withBlock.OutputItemTypeWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.InstallSolarSystemColumn:
                            {
                                withBlock.InstallSystemWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.InstallRegionColumn:
                            {
                                withBlock.InstallRegionWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.LicensedRunsColumn:
                            {
                                withBlock.LicensedRunsWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.RunsColumn:
                            {
                                withBlock.RunsWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.SuccessfulRunsColumn:
                            {
                                withBlock.SuccessfulRunsWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.BlueprintLocationColumn:
                            {
                                withBlock.BlueprintLocationWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.OutputLocationColumn:
                            {
                                withBlock.OutputLocationWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.JobTypeColumn:
                            {
                                withBlock.JobTypeWidth = NewWidth;
                                break;
                            }
                        case ProgramSettings.LocalCompletionDateTimeColumn:
                            {
                                withBlock.LocalCompletionDateTimeWidth = NewWidth;
                                break;
                            }
                    }
                }
            }

        }

        // Determines if we display the sent colum
        private bool ShowColumn(string ColumnName)
        {
            if (Array.IndexOf(ColumnPositions, ColumnName) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Save the column order, the column size and the sort order
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {

            if (rbtnPersonalJobs.Checked)
            {
                SettingsVariables.UserIndustryJobsColumnSettings.ViewJobType = rbtnPersonalJobs.Text;
            }
            else if (rbtnCorpJobs.Checked)
            {
                SettingsVariables.UserIndustryJobsColumnSettings.ViewJobType = rbtnCorpJobs.Text;
            }
            else if (rbtnBothJobs.Checked)
            {
                SettingsVariables.UserIndustryJobsColumnSettings.ViewJobType = rbtnBothJobs.Text;
            }

            if (rbtnCurrentJobs.Checked)
            {
                SettingsVariables.UserIndustryJobsColumnSettings.JobTimes = rbtnCurrentJobs.Text;
            }
            else
            {
                SettingsVariables.UserIndustryJobsColumnSettings.JobTimes = rbtnJobHistory.Text;
            }

            SettingsVariables.UserIndustryJobsColumnSettings.SelectedCharacterIDs = GetCharIDs();
            SettingsVariables.UserIndustryJobsColumnSettings.AutoUpdateJobs = chkAutoUpdate.Checked;

            SettingsVariables.AllSettings.SaveIndustryJobsColumnSettings(SettingsVariables.UserIndustryJobsColumnSettings);

            Interaction.MsgBox("Settings saved", Constants.vbInformation, Application.ProductName);

        }

        private void btnSelectColumns_Click(object sender, EventArgs e)
        {
            var f1 = new frmSelectIndustryJobColumns();
            f1.ShowDialog();

            // And refresh the Grid
            RefreshGrid();

        }

        private void btnUpdateJobs_Click(object sender, EventArgs e)
        {

            // Always update the data when pushed
            UpdateJobs(true);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Timer1.Enabled = False
            Hide();
        }

        private void lstIndustryJobs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstIndustryJobs;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref JobListColumnClicked, ref JobListColumnSortOrder);
            lstIndustryJobs = argRefListView;
            SettingsVariables.UserIndustryJobsColumnSettings.OrderByColumn = JobListColumnClicked;
            if (JobListColumnSortOrder == SortOrder.Ascending)
            {
                SettingsVariables.UserIndustryJobsColumnSettings.OrderType = "Ascending";
            }
            else
            {
                SettingsVariables.UserIndustryJobsColumnSettings.OrderType = "Decending";
            }
        }

        private void lstCharacters_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView argRefListView = lstCharacters;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref AcctListColumnClicked, ref AcctListColumnSortOrder);
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void rbtnPersonalJobs_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                RefreshGrid();
            }
        }

        private void rbtnCorpJobs_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                RefreshGrid();
            }
        }

        private void rbtnBothJobs_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                RefreshGrid();
            }
        }

        private void rbtnCurrentJobs_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnCurrentJobs.Checked)
            {
                RefreshGrid();
            }
        }

        private void rbtnJobHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (!FirstLoad & rbtnJobHistory.Checked)
            {
                RefreshGrid();
            }
        }

        private void chkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            SettingsVariables.UserIndustryJobsColumnSettings.AutoUpdateJobs = chkAutoUpdate.Checked;
        }

        private void lstCharacters_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // Just set up the list of char ids
            if (!FirstLoad & !Updating)
            {
                SettingsVariables.UserIndustryJobsColumnSettings.SelectedCharacterIDs = GetCharIDs();
                // Now refresh the grid
                RefreshGrid();
            }

        }

        private void frmIndustryJobsViewer_Closing(object sender, CancelEventArgs e)
        {
            PauseScreenUpdate = true;
            myTimer.Dispose();
        }

        ~frmIndustryJobsViewer()
        {
            PauseScreenUpdate = true;
            myTimer.Dispose();
        }

        #endregion

    }
}