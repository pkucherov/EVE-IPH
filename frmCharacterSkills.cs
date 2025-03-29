using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmCharacterSkills
    {

        private bool AllowSkillOverride;
        private EVESkillList OverrideSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels); // To save all the skills we are working with here
        private EVESkillList UpdateSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels); // The list of the ones we want to update only
                                                                                                                              // Private SelectedNode As TreeNode
        private EVESkill SelectedSkill;

        private bool SkillOverridden; // If they make a change, and switch back ask them if they want to lose their work
        private bool CheckLoadsTree; // If hitting the check box will load the skills into the tree
        private bool FullOverrideChange; // If they change from just override, to not override, need to track for saving
        private bool CheckSaveBeforeExit;

        #region Object Functions

        private void mnuOrigLevel_Click(object sender, EventArgs e)
        {
            // Removes the skill from override and sets it back to the real level
            UpdateSkill(-1, SkillTree.SelectedNode);
        }

        private void mnuLevel0_Click(object sender, EventArgs e)
        {
            UpdateSkill(0, SkillTree.SelectedNode);
        }

        private void mnuLevel1_Click(object sender, EventArgs e)
        {
            UpdateSkill(1, SkillTree.SelectedNode);
        }

        private void mnuLevel2_Click(object sender, EventArgs e)
        {
            UpdateSkill(2, SkillTree.SelectedNode);
        }

        private void mnuLevel3_Click(object sender, EventArgs e)
        {
            UpdateSkill(3, SkillTree.SelectedNode);
        }

        private void mnuLevel4_Click(object sender, EventArgs e)
        {
            UpdateSkill(4, SkillTree.SelectedNode);
        }

        private void mnuLevel5_Click(object sender, EventArgs e)
        {
            UpdateSkill(5, SkillTree.SelectedNode);
        }

        // Sets the box check in the context menu
        private void SetCheck(int CheckIndex)
        {
            switch (CheckIndex)
            {
                case 0:
                    {
                        mnuOrigLevel.Checked = true;
                        mnuLevel1.Checked = false;
                        mnuLevel2.Checked = false;
                        mnuLevel3.Checked = false;
                        mnuLevel4.Checked = false;
                        mnuLevel5.Checked = false;
                        break;
                    }
                case 1:
                    {
                        mnuOrigLevel.Checked = false;
                        mnuLevel1.Checked = true;
                        mnuLevel2.Checked = false;
                        mnuLevel3.Checked = false;
                        mnuLevel4.Checked = false;
                        mnuLevel5.Checked = false;
                        break;
                    }
                case 2:
                    {
                        mnuOrigLevel.Checked = false;
                        mnuLevel1.Checked = false;
                        mnuLevel2.Checked = true;
                        mnuLevel3.Checked = false;
                        mnuLevel4.Checked = false;
                        mnuLevel5.Checked = false;
                        break;
                    }
                case 3:
                    {
                        mnuOrigLevel.Checked = false;
                        mnuLevel1.Checked = false;
                        mnuLevel2.Checked = false;
                        mnuLevel3.Checked = true;
                        mnuLevel4.Checked = false;
                        mnuLevel5.Checked = false;
                        break;
                    }
                case 4:
                    {
                        mnuOrigLevel.Checked = false;
                        mnuLevel1.Checked = false;
                        mnuLevel2.Checked = false;
                        mnuLevel3.Checked = false;
                        mnuLevel4.Checked = true;
                        mnuLevel5.Checked = false;
                        break;
                    }
                case 5:
                    {
                        mnuOrigLevel.Checked = false;
                        mnuLevel1.Checked = false;
                        mnuLevel2.Checked = false;
                        mnuLevel3.Checked = false;
                        mnuLevel4.Checked = false;
                        mnuLevel5.Checked = true;
                        break;
                    }
            }
        }

        // Selects the node selected if they choose a node and right click and shows the context menu
        private void SkillTree_MouseClick(object sender, MouseEventArgs e)
        {
            Point p;
            TreeNode ClickedNode;

            if (e.Button == MouseButtons.Right & AllowSkillOverride)
            {

                ClickedNode = SkillTree.GetNodeAt(e.X, e.Y);

                if (!(ClickedNode == null))
                {
                    SkillTree.SelectedNode = ClickedNode;
                }

                // Only allow right click context on the skills
                if (!(ClickedNode.Parent == null)) // if the node has no parent, we are at the top level
                {
                    p = new Point(e.X, e.Y);
                    // Get the skill name and look it up in the skills
                    SelectedSkill = OverrideSkills.GetSkill(ClickedNode.Text.Substring(0, Strings.InStr(ClickedNode.Text, "-") - 2));

                    if (SelectedSkill.Overridden)
                    {
                        // Set the top level to the base skill level
                        mnuOrigLevel.Text = "Stored Level: " + SelectedSkill.OverriddenLevel.ToString();
                    }
                    else
                    {
                        mnuOrigLevel.Text = "Not Overridden";
                    }

                    // Set the menu checked based on skill level
                    SetCheck(SelectedSkill.Level);

                    // Now show the context on the point
                    contextOverride.Show(SkillTree, p);
                }
            }
        }

        #endregion

        public frmCharacterSkills()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            AllowSkillOverride = SettingsVariables.UserApplicationSettings.AllowSkillOverride;
            FullOverrideChange = SettingsVariables.UserApplicationSettings.AllowSkillOverride; // Save this for checking

        }

        private void frmCharacterSkills_Load(object sender, EventArgs e)
        {
            Refresh();
            CheckLoadsTree = false;
            chkSkillOverride.Checked = SettingsVariables.UserApplicationSettings.AllowSkillOverride;
            CheckLoadsTree = true;
            LoadSkillsInTree(AllowSkillOverride);
            CheckSaveBeforeExit = false;
            SkillOverridden = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MsgBoxResult Response;

            if (CheckSaveBeforeExit)
            {
                // Mark a skill as overridden
                if (!SkillOverridden)
                {
                    SkillOverridden = true;
                }

                Response = CheckSave();

                if (Response != Constants.vbCancel)
                {
                    Hide();
                }
            }
            else
            {
                Hide();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void RefreshTree()
        {
            // Dim API As New EVEAPI
            var TempCharacter = new Character[1];
            MsgBoxResult Response = default;
            string TempKeyType = "";

            // Update the skills if they can be updated
            Cursor = Cursors.WaitCursor;
            // Just refresh the skills from API
            Public_Variables.SelectedCharacter.Skills.LoadCharacterSkills(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, false, Strings.Trim(txtSkillNameFilter.Text));
            // Refresh
            LoadSkillsInTree(chkSkillOverride.Checked);
            Cursor = Cursors.Default;

            if (SkillOverridden)
            {
                Response = CheckSave();
            }

            // If they didn't hit cancel, reload the skills
            if (Response != Constants.vbCancel)
            {
                LoadSkillsInTree(chkSkillOverride.Checked);
            }

            // If they are searching, then open all the nodes
            if (!string.IsNullOrEmpty(Strings.Trim(txtSkillNameFilter.Text)))
            {
                SkillTree.ExpandAll();
            }
            else
            {
                SkillTree.CollapseAll();
            }

        }

        // Saves the skills that get overridden
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSkills();
        }

        private void chkSkillOverride_CheckedChanged(object sender, EventArgs e)
        {
            CheckOverRide();
            RefreshTree();
        }

        private void chkAllLevel5_CheckedChanged(object sender, EventArgs e)
        {

            // As long as All Skills 5 checked, you can't uncheck override
            if (chkAllLevel5.Checked == true)
            {
                chkSkillOverride.Enabled = false;
            }
            else
            {
                chkSkillOverride.Enabled = true;
            }

            Application.DoEvents();

            if (chkAllLevel5.Checked == true & chkSkillOverride.Checked == false)
            {
                chkSkillOverride.Checked = true;
            }
            else
            {
                CheckOverRide();
            }
        }

        // Saves the skills that the user changed (overridden)
        private void SaveSkills()
        {

            // Save the updated skills list
            Public_Variables.SelectedCharacter.Skills.SaveOverRideSkills(UpdateSkills);
            Public_Variables.SkillsUpdated = true;

            FinalizeUpdate();

        }

        // Loads the tree with the skills
        private void LoadSkillsInTree(bool LoadAllSkillsforOverride)
        {
            var TempSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
            string SkillGroup = "";
            TreeNode CurrentNode = null;
            TreeNode CurrentSubNode = null;

            int TempSkillLevel;

            string SearchText = Strings.UCase(Strings.Trim(txtSkillNameFilter.Text));

            Cursor = Cursors.WaitCursor;

            // Reset these every new load
            OverrideSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
            UpdateSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);

            lblCharacterName.Text = Public_Variables.SelectedCharacter.Name;

            // If they want max alpha, load those skills into the selected character (dummy)

            // Load whatever is in the database
            Public_Variables.SelectedCharacter.Skills.LoadCharacterSkills(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, LoadAllSkillsforOverride);

            if (!(Public_Variables.SelectedCharacter.Skills == null))
            {
                // Fill the tree
                SkillTree.BeginUpdate();
                SkillTree.Nodes.Clear();

                for (int i = 0, loopTo = Public_Variables.SelectedCharacter.Skills.NumSkills() - 1; i <= loopTo; i++)
                {
                    {
                        var withBlock = Public_Variables.SelectedCharacter.Skills.GetSkillList()[i];
                        // Only add if the search bar is blank or the skills name is like the skill name
                        if (string.IsNullOrEmpty(SearchText) | Strings.UCase(withBlock.Name).Contains(SearchText))
                        {
                            Application.DoEvents();
                            if ((SkillGroup ?? "") != (withBlock.Group ?? ""))
                            {
                                // Save the skill group
                                SkillGroup = Public_Variables.SelectedCharacter.Skills.GetSkillList()[i].Group;
                                // Add the group to the tree
                                CurrentNode = SkillTree.Nodes.Add(SkillGroup);
                            }

                            // Add the skill and level
                            if (chkAllLevel5.Checked)
                            {
                                TempSkillLevel = 5;
                            }
                            else
                            {
                                TempSkillLevel = withBlock.Level;
                            }

                            if (TempSkillLevel != 0 | TempSkillLevel == 0 & chkSkillOverride.Checked == true)
                            {
                                CurrentSubNode = CurrentNode.Nodes.Add(withBlock.Name + " - " + TempSkillLevel.ToString());
                            }

                            // Save the current skills
                            OverrideSkills.InsertSkill(withBlock.TypeID, withBlock.Level, withBlock.TrainedLevel, withBlock.ActiveLevel, 0L, withBlock.Overridden, withBlock.OverriddenLevel);

                            // Save the skill here if it's level 5
                            if (chkAllLevel5.Checked)
                            {
                                // Set the selected skill since the user isn't clicking on these
                                SelectedSkill = OverrideSkills.GetSkill(withBlock.Name);
                                UpdateSkill(5, CurrentSubNode);
                                // They just changed a skill
                                SkillOverridden = true;
                            }
                        }
                    }
                }

                SkillTree.EndUpdate();
            }

            // If they are searching, then open all the nodes
            if (!string.IsNullOrEmpty(Strings.Trim(txtSkillNameFilter.Text)))
            {
                SkillTree.ExpandAll();
            }
            else
            {
                SkillTree.CollapseAll();
            }
            Cursor = Cursors.Default;

        }

        // Updates the sent node and inserts the override skill into the array
        private void UpdateSkill(int Level, TreeNode SentNode)
        {
            EVESkill CurrentSkill;

            // If they selected the same skill level, just exit
            if (Level == SelectedSkill.Level)
            {
                return;
            }

            // Get the user data if it exists
            CurrentSkill = Public_Variables.SelectedCharacter.Skills.GetSkill(SelectedSkill.Name);

            // Set the check to the level selected
            SetCheck(Level);

            // Update the text in the node to the new level
            SentNode.Text = SentNode.Text.Substring(0, Strings.InStr(SentNode.Text, "-")) + " " + Level.ToString();

            if (Level != -1)
            {
                // Need to set the Top label to the original level for reference
                mnuOrigLevel.Text = "Stored Level: " + SelectedSkill.Level.ToString();
                SelectedSkill.Overridden = true;
                SelectedSkill.Level = Level;
                SelectedSkill.OverriddenLevel = Level;
            }
            else
            {
                // Not overridden, so load in the original skill level from the character data
                mnuOrigLevel.Text = "Not Overridden";

                // If it returned nothing, then set the skill level to 0 because there is no saved skill
                if (CurrentSkill.TypeID == 0L)
                {
                    SelectedSkill.OverriddenLevel = 0;
                    SelectedSkill.Level = 0;
                    SelectedSkill.Overridden = false;
                }
                else
                {
                    // Just save the temp skill data back
                    SelectedSkill = CurrentSkill;
                }

            }

            // Now update the skill in the override list
            OverrideSkills.UpdateSkill(SelectedSkill);

            // Save it in the update list for later as we would insert it into the DB (so swap overridden and skill level)
            {
                ref var withBlock = ref SelectedSkill;
                UpdateSkills.InsertSkill(withBlock.TypeID, withBlock.Level, withBlock.TrainedLevel, withBlock.ActiveLevel, withBlock.SkillPoints, withBlock.Overridden, withBlock.OverriddenLevel);
            }

            // They just changed a skill
            SkillOverridden = true;

        }

        // Checks to see if they overrided any skills
        private void CheckOverRide()
        {
            MsgBoxResult Response;

            if ((FullOverrideChange != chkSkillOverride.Checked | FullOverrideChange != chkAllLevel5.Checked) & !SkillOverridden)
            {
                // They changed the original check for overriding skills but didn't update any skills
                CheckSaveBeforeExit = true;
            }

            if (CheckLoadsTree)
            {
                if (chkSkillOverride.Checked == true & chkAllLevel5.Checked == false)
                {
                    // They just want to override skills
                    AllowSkillOverride = true;
                    LoadSkillsInTree(true);
                }
                else if (chkAllLevel5.Checked == true)
                {
                    // They just set them all to level 5, but not new skills
                    AllowSkillOverride = true; // But they are overridden
                    LoadSkillsInTree(false);
                }
                else // They want normal skills
                {
                    Response = CheckSave();

                    // If they didn't hit cancel, reload the skills
                    if (!(Response == Constants.vbCancel))
                    {
                        AllowSkillOverride = false;
                        LoadSkillsInTree(false);
                    }
                    else
                    {
                        // Exit this sub and return to the screen and keep the check the same
                        CheckLoadsTree = false;
                        chkSkillOverride.Checked = true;
                        return;
                    }
                }

                // Reset this as they either save, disgard or they didn't check override
                SkillOverridden = false;
            }

            CheckLoadsTree = true;
        }

        // Checks if we need to ask the user if we save their changes and returns true for move on, or false for staying there
        private MsgBoxResult CheckSave()
        {
            MsgBoxResult CheckSaveRet = default;

            if (SkillOverridden)
            {
                // See if they want to do this or not if they made changes and didn't save
                CheckSaveRet = Interaction.MsgBox("You have unsaved skill changes. Do you want to save?", (MsgBoxStyle)((int)MsgBoxStyle.YesNoCancel + (int)MsgBoxStyle.Question), Application.ProductName);

                if (CheckSaveRet == Constants.vbYes)
                {
                    // Save the updated skills
                    SaveSkills();
                }
            }
            else
            {
                CheckSaveRet = Constants.vbYes;
            }

            return CheckSaveRet;

        }

        public void FinalizeUpdate()
        {

            // Saved skills, so this is now the default
            FullOverrideChange = chkSkillOverride.Checked;
            CheckSaveBeforeExit = false;
            SkillOverridden = false; // Reset change flag

            LoadSkillsInTree(chkSkillOverride.Checked);

            // Finally reload the skills for the program - whatever changes were done just load them from DB
            Public_Variables.SelectedCharacter.Skills.LoadCharacterSkills(Public_Variables.SelectedCharacter.ID, Public_Variables.SelectedCharacter.CharacterTokenData, false);

            Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);

        }

        private void btnClearItemFilter_Click(object sender, EventArgs e)
        {
            txtSkillNameFilter.Text = "";
            RefreshTree();
        }

        private void txtSkillNameFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshTree();
            }
        }

    }
}