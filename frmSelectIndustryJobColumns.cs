using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{
    public partial class frmSelectIndustryJobColumns
    {

        private int MaxColumnNumber;
        private int SelectedIndex;

        public frmSelectIndustryJobColumns()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            MaxColumnNumber = 1;
            SelectedIndex = 0;

        }

        private void SetMaxColumnNumber(int InNumber)
        {
            if (InNumber > MaxColumnNumber)
            {
                MaxColumnNumber = InNumber;
            }
        }

        // Load all the current checks
        private void frmSelectIndustryJobColumns_Shown(object sender, EventArgs e)
        {
            ShowList();
        }

        private void ShowList()
        {
            {
                ref var withBlock = ref SettingsVariables.UserIndustryJobsColumnSettings;
                if (withBlock.JobState != 0)
                {
                    chkLstBoxColumns.SetItemChecked(0, true);
                    SetMaxColumnNumber(withBlock.JobState);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(0, false);
                }

                if (withBlock.InstallerName != 0)
                {
                    chkLstBoxColumns.SetItemChecked(1, true);
                    SetMaxColumnNumber(withBlock.InstallerName);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(1, false);
                }

                if (withBlock.TimeToComplete != 0)
                {
                    chkLstBoxColumns.SetItemChecked(2, true);
                    SetMaxColumnNumber(withBlock.TimeToComplete);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(2, false);
                }

                if (withBlock.Activity != 0)
                {
                    chkLstBoxColumns.SetItemChecked(3, true);
                    SetMaxColumnNumber(withBlock.Activity);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(3, false);
                }

                if (withBlock.Status != 0)
                {
                    chkLstBoxColumns.SetItemChecked(4, true);
                    SetMaxColumnNumber(withBlock.Status);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(4, false);
                }

                if (withBlock.StartTime != 0)
                {
                    chkLstBoxColumns.SetItemChecked(5, true);
                    SetMaxColumnNumber(withBlock.StartTime);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(5, false);
                }

                if (withBlock.EndTime != 0)
                {
                    chkLstBoxColumns.SetItemChecked(6, true);
                    SetMaxColumnNumber(withBlock.EndTime);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(6, false);
                }

                if (withBlock.CompletionTime != 0)
                {
                    chkLstBoxColumns.SetItemChecked(7, true);
                    SetMaxColumnNumber(withBlock.CompletionTime);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(7, false);
                }

                if (withBlock.Blueprint != 0)
                {
                    chkLstBoxColumns.SetItemChecked(8, true);
                    SetMaxColumnNumber(withBlock.Blueprint);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(8, false);
                }

                if (withBlock.OutputItem != 0)
                {
                    chkLstBoxColumns.SetItemChecked(9, true);
                    SetMaxColumnNumber(withBlock.OutputItem);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(9, false);
                }

                if (withBlock.OutputItemType != 0)
                {
                    chkLstBoxColumns.SetItemChecked(10, true);
                    SetMaxColumnNumber(withBlock.OutputItemType);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(10, false);
                }

                if (withBlock.InstallSystem != 0)
                {
                    chkLstBoxColumns.SetItemChecked(11, true);
                    SetMaxColumnNumber(withBlock.InstallSystem);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(11, false);
                }

                if (withBlock.InstallRegion != 0)
                {
                    chkLstBoxColumns.SetItemChecked(12, true);
                    SetMaxColumnNumber(withBlock.InstallRegion);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(12, false);
                }

                if (withBlock.LicensedRuns != 0)
                {
                    chkLstBoxColumns.SetItemChecked(13, true);
                    SetMaxColumnNumber(withBlock.LicensedRuns);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(13, false);
                }

                if (withBlock.Runs != 0)
                {
                    chkLstBoxColumns.SetItemChecked(14, true);
                    SetMaxColumnNumber(withBlock.Runs);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(14, false);
                }

                if (withBlock.SuccessfulRuns != 0)
                {
                    chkLstBoxColumns.SetItemChecked(15, true);
                    SetMaxColumnNumber(withBlock.SuccessfulRuns);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(15, false);
                }

                if (withBlock.BlueprintLocation != 0)
                {
                    chkLstBoxColumns.SetItemChecked(16, true);
                    SetMaxColumnNumber(withBlock.BlueprintLocation);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(16, false);
                }

                if (withBlock.OutputLocation != 0)
                {
                    chkLstBoxColumns.SetItemChecked(17, true);
                    SetMaxColumnNumber(withBlock.OutputLocation);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(17, false);
                }

                if (withBlock.JobType != 0)
                {
                    chkLstBoxColumns.SetItemChecked(18, true);
                    SetMaxColumnNumber(withBlock.JobType);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(18, false);
                }

                if (withBlock.LocalCompletionDateTime != 0)
                {
                    chkLstBoxColumns.SetItemChecked(19, true);
                    SetMaxColumnNumber(withBlock.LocalCompletionDateTime);
                }
                else
                {
                    chkLstBoxColumns.SetItemChecked(19, false);
                }

                chkLstBoxColumns.Update();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (chkLstBoxColumns.CheckedItems.Count == 0)
            {
                Interaction.MsgBox("You must select at least one Column", Constants.vbExclamation, Application.ProductName);
                return;
            }

            // Save the local settings and the user settings
            SaveLocalColumnSettings();

            // Save the data in the XML file
            SettingsVariables.AllSettings.SaveIndustryJobsColumnSettings(SettingsVariables.UserIndustryJobsColumnSettings);

            Interaction.MsgBox("Columns Saved", Constants.vbInformation, Application.ProductName);

            Hide();

        }

        // Save the items as viewed or not and order them from the last column
        public void SaveLocalColumnSettings()
        {
            CheckState chkstate;
            var ColumnPositions = new string[21];
            var TempColumns = new string[21];
            int ColumnCount = 0;
            int i = 1;
            int j = 1;

            {
                ref var withBlock = ref SettingsVariables.UserIndustryJobsColumnSettings;

                chkstate = chkLstBoxColumns.GetItemCheckState(0);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.JobState == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.JobState = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.JobState = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(1);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.InstallerName == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.InstallerName = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.InstallerName = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(2);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.TimeToComplete == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.TimeToComplete = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.TimeToComplete = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(3);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.Activity == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.Activity = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.Activity = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(4);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.Status == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.Status = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.Status = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(5);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.StartTime == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.StartTime = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.StartTime = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(6);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.EndTime == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.EndTime = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.EndTime = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(7);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.CompletionTime == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.CompletionTime = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.CompletionTime = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(8);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.Blueprint == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.Blueprint = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.Blueprint = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(9);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.OutputItem == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.OutputItem = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.OutputItem = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(10);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.OutputItemType == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.OutputItemType = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.OutputItemType = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(11);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.InstallSystem == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.InstallSystem = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.InstallSystem = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(12);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.InstallRegion == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.InstallRegion = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.InstallRegion = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(13);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.LicensedRuns == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.LicensedRuns = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.LicensedRuns = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(14);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.Runs == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.Runs = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.Runs = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(15);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.SuccessfulRuns == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.SuccessfulRuns = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.SuccessfulRuns = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(16);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.BlueprintLocation == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.BlueprintLocation = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.BlueprintLocation = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(17);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.OutputLocation == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.OutputLocation = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.OutputLocation = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(18);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.JobType == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.JobType = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.JobType = 0;
                }

                chkstate = chkLstBoxColumns.GetItemCheckState(19);
                // Change to max column order + 1 if checked and not already set
                if (withBlock.LocalCompletionDateTime == 0 & chkstate == CheckState.Checked)
                {
                    withBlock.LocalCompletionDateTime = MaxColumnNumber + 1;
                    MaxColumnNumber += 1;
                }
                else if (chkstate == CheckState.Unchecked)
                {
                    withBlock.LocalCompletionDateTime = 0;
                }

                // Now in case something was removed, we want to update the indicies
                var loopTo = ColumnPositions.Count() - 1;
                for (i = 0; i <= loopTo; i++)
                    ColumnPositions[i] = "";

                {
                    ref var withBlock1 = ref SettingsVariables.UserIndustryJobsColumnSettings;
                    ColumnPositions[withBlock1.JobState] = ProgramSettings.JobStateColumn;
                    ColumnPositions[withBlock1.InstallerName] = ProgramSettings.InstallerNameColumn;
                    ColumnPositions[withBlock1.TimeToComplete] = ProgramSettings.TimetoCompleteColumn;
                    ColumnPositions[withBlock1.Activity] = ProgramSettings.ActivityColumn;
                    ColumnPositions[withBlock1.Status] = ProgramSettings.StatusColumn;
                    ColumnPositions[withBlock1.StartTime] = ProgramSettings.StartTimeColumn;
                    ColumnPositions[withBlock1.EndTime] = ProgramSettings.EndTimeColumn;
                    ColumnPositions[withBlock1.CompletionTime] = ProgramSettings.CompletionTimeColumn;
                    ColumnPositions[withBlock1.Blueprint] = ProgramSettings.BlueprintColumn;
                    ColumnPositions[withBlock1.OutputItem] = ProgramSettings.OutputItemColumn;
                    ColumnPositions[withBlock1.OutputItemType] = ProgramSettings.OutputItemTypeColumn;
                    ColumnPositions[withBlock1.InstallSystem] = ProgramSettings.InstallSolarSystemColumn;
                    ColumnPositions[withBlock1.InstallRegion] = ProgramSettings.InstallRegionColumn;
                    ColumnPositions[withBlock1.LicensedRuns] = ProgramSettings.LicensedRunsColumn;
                    ColumnPositions[withBlock1.Runs] = ProgramSettings.RunsColumn;
                    ColumnPositions[withBlock1.SuccessfulRuns] = ProgramSettings.SuccessfulRunsColumn;
                    ColumnPositions[withBlock1.BlueprintLocation] = ProgramSettings.BlueprintLocationColumn;
                    ColumnPositions[withBlock1.OutputLocation] = ProgramSettings.OutputLocationColumn;
                    ColumnPositions[withBlock1.JobType] = ProgramSettings.JobTypeColumn;
                    ColumnPositions[withBlock1.LocalCompletionDateTime] = ProgramSettings.LocalCompletionDateTimeColumn;
                }

                // Reset the first one with nothing since the first column is empty
                ColumnPositions[0] = "";

                // Now get the total number of columns in the list we want to see
                var loopTo1 = ColumnPositions.Count() - 1;
                for (i = 1; i <= loopTo1; i++)
                {
                    if (!string.IsNullOrEmpty(ColumnPositions[i]))
                    {
                        ColumnCount += 1;
                    }
                }

                // Init temp
                var loopTo2 = TempColumns.Count() - 1;
                for (i = 0; i <= loopTo2; i++)
                    TempColumns[i] = "";

                // Now loop through the columns and update the positions
                var loopTo3 = ColumnPositions.Count() - 1;
                for (i = 1; i <= loopTo3; i++)
                {
                    if (!string.IsNullOrEmpty(ColumnPositions[i]))
                    {
                        TempColumns[j] = ColumnPositions[i];
                        j += 1;
                    }
                    else if (i == SettingsVariables.UserIndustryJobsColumnSettings.OrderByColumn)
                    {
                        // They removed the column they sorted, so default to the first column since you must have 1
                        SettingsVariables.UserIndustryJobsColumnSettings.OrderByColumn = 1;
                    }
                }

                ColumnPositions = TempColumns;

                // Finally save the columns based on the current order
                {
                    ref var withBlock2 = ref SettingsVariables.UserIndustryJobsColumnSettings;
                    var loopTo4 = ColumnPositions.Count() - 1;
                    for (i = 1; i <= loopTo4; i++)
                    {
                        switch (ColumnPositions[i] ?? "")
                        {
                            case ProgramSettings.JobStateColumn:
                                {
                                    withBlock2.JobState = i;
                                    break;
                                }
                            case ProgramSettings.InstallerNameColumn:
                                {
                                    withBlock2.InstallerName = i;
                                    break;
                                }
                            case ProgramSettings.TimetoCompleteColumn:
                                {
                                    withBlock2.TimeToComplete = i;
                                    break;
                                }
                            case ProgramSettings.ActivityColumn:
                                {
                                    withBlock2.Activity = i;
                                    break;
                                }
                            case ProgramSettings.StartTimeColumn:
                                {
                                    withBlock2.StartTime = i;
                                    break;
                                }
                            case ProgramSettings.EndTimeColumn:
                                {
                                    withBlock2.EndTime = i;
                                    break;
                                }
                            case ProgramSettings.CompletionTimeColumn:
                                {
                                    withBlock2.CompletionTime = i;
                                    break;
                                }
                            case ProgramSettings.BlueprintColumn:
                                {
                                    withBlock2.Blueprint = i;
                                    break;
                                }
                            case ProgramSettings.OutputItemColumn:
                                {
                                    withBlock2.OutputItem = i;
                                    break;
                                }
                            case ProgramSettings.OutputItemTypeColumn:
                                {
                                    withBlock2.OutputItemType = i;
                                    break;
                                }
                            case ProgramSettings.InstallSolarSystemColumn:
                                {
                                    withBlock2.InstallSystem = i;
                                    break;
                                }
                            case ProgramSettings.InstallRegionColumn:
                                {
                                    withBlock2.InstallRegion = i;
                                    break;
                                }
                            case ProgramSettings.LicensedRunsColumn:
                                {
                                    withBlock2.LicensedRuns = i;
                                    break;
                                }
                            case ProgramSettings.RunsColumn:
                                {
                                    withBlock2.Runs = i;
                                    break;
                                }
                            case ProgramSettings.SuccessfulRunsColumn:
                                {
                                    withBlock2.SuccessfulRuns = i;
                                    break;
                                }
                            case ProgramSettings.BlueprintLocationColumn:
                                {
                                    withBlock2.BlueprintLocation = i;
                                    break;
                                }
                            case ProgramSettings.OutputLocationColumn:
                                {
                                    withBlock2.OutputLocation = i;
                                    break;
                                }
                            case ProgramSettings.JobTypeColumn:
                                {
                                    withBlock2.JobType = i;
                                    break;
                                }
                            case ProgramSettings.LocalCompletionDateTimeColumn:
                                {
                                    withBlock2.LocalCompletionDateTime = i;
                                    break;
                                }
                        }
                    }
                }
            }

        }

        private void chkLstBoxColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SelectedIndex != chkLstBoxColumns.SelectedIndex)
            {
                SelectedIndex = chkLstBoxColumns.SelectedIndex;

                if (chkLstBoxColumns.GetItemChecked(chkLstBoxColumns.SelectedIndex))
                {
                    // Uncheckit
                    chkLstBoxColumns.SetItemChecked(chkLstBoxColumns.SelectedIndex, false);
                }
                else
                {
                    // Checkit
                    chkLstBoxColumns.SetItemChecked(chkLstBoxColumns.SelectedIndex, true);
                }

            }

        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            SettingsVariables.UserIndustryJobsColumnSettings = SettingsVariables.AllSettings.SetDefaultIndustryJobsColumnSettings();
            ShowList();
            chkLstBoxColumns.Update();
        }

    }
}