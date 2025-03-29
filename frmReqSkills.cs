using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{

    public partial class frmReqSkills
    {

        private Public_Variables.SkillType SkillTypeDisplay;

        public frmReqSkills(Public_Variables.SkillType AllBPSkills)
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            SkillTypeDisplay = AllBPSkills;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        // Show the skills required in red if they don't have them, black if they do
        private void frmReqSkills_Shown(object sender, EventArgs e)
        {
            string SkillGroup = "";
            TreeNode CurrentNode = null;
            TreeNode CurrentSubNode = null;
            var DisplaySkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
            var TempReqComponentSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);

            if (Public_Variables.SelectedBlueprint == null)
            {
                SkillTree.Nodes.Clear();
                return;
            }

            if (Public_Variables.SelectedBlueprint.GetReqBPSkills().NumSkills() == 0 & SkillTypeDisplay == Public_Variables.SkillType.BPReqSkills)
            {
                SkillTree.Nodes.Clear();
                return;
            }

            if (Public_Variables.SelectedBlueprint.GetReqComponentSkills().NumSkills() == 0 & SkillTypeDisplay == Public_Variables.SkillType.BPComponentSkills)
            {
                SkillTree.Nodes.Clear();
                return;
            }

            if (Public_Variables.SelectedBlueprint.GetReqInventionSkills().NumSkills() == 0 & SkillTypeDisplay == Public_Variables.SkillType.InventionReqSkills)
            {
                SkillTree.Nodes.Clear();
                return;
            }

            // Fill the tree
            SkillTree.BeginUpdate();
            SkillTree.Nodes.Clear();

            switch (SkillTypeDisplay)
            {
                case Public_Variables.SkillType.BPReqSkills:
                    {
                        CurrentNode = SkillTree.Nodes.Add("BP Required Manufacturing Skills");
                        DisplaySkills = Public_Variables.SelectedBlueprint.GetReqBPSkills();
                        break;
                    }
                case Public_Variables.SkillType.BPComponentSkills:
                    {
                        // When there are no components for the object, show the base skills
                        if (Public_Variables.SelectedBlueprint.GetReqComponentSkills().GetSkillList() == null)
                        {
                            CurrentNode = SkillTree.Nodes.Add("BP Required Manufacturing Skills");
                            DisplaySkills = Public_Variables.SelectedBlueprint.GetReqBPSkills();
                        }
                        else
                        {
                            CurrentNode = SkillTree.Nodes.Add("Components Required Manufacturing Skills");
                            DisplaySkills = Public_Variables.SelectedBlueprint.GetReqComponentSkills();
                        }

                        break;
                    }
                case Public_Variables.SkillType.InventionReqSkills:
                case Public_Variables.SkillType.REReqSkills:
                    {
                        CurrentNode = SkillTree.Nodes.Add("Required Invention / RE Skills");
                        DisplaySkills = Public_Variables.SelectedBlueprint.GetReqInventionSkills();
                        break;
                    }
            }

            // Add the nodes
            if (DisplaySkills.NumSkills() != 0)
            {
                AddReqSkillNodes(ref CurrentNode, DisplaySkills);
            }
            else
            {
                CurrentNode = CurrentNode.Nodes.Add("No Skills Required");
            }

            SkillTree.EndUpdate();
            SkillTree.ExpandAll();
            SkillTree.SelectedNode = SkillTree.Nodes[0];

        }

        private void AddReqSkillNodes(ref TreeNode SentSubNode, EVESkillList PreReqSkills)
        {
            TreeNode PreReqNode = null;
            List<EVESkill> SkillList;
            int TempSkillLevel;

            if (PreReqSkills.NumSkills() == 0)
            {
                return;
            }

            SkillList = PreReqSkills.GetSkillList();

            // Loop through each skill and add to tree
            for (int i = 0, loopTo = SkillList.Count - 1; i <= loopTo; i++)
            {
                TempSkillLevel = Public_Variables.SelectedCharacter.Skills.GetSkillLevel(SkillList[i].TypeID);

                if (TempSkillLevel < SkillList[i].Level)
                {
                    PreReqNode = SentSubNode.Nodes.Add(SkillList[i].Name + " - " + SkillList[i].Level.ToString() + " (" + TempSkillLevel + ")");
                    PreReqNode.ForeColor = Color.Red;
                }
                else
                {
                    PreReqNode = SentSubNode.Nodes.Add(SkillList[i].Name + " - " + SkillList[i].Level.ToString());
                    PreReqNode.ForeColor = Color.Black;
                }

                // If this node has skills, add them too
                if (SkillList[i].PreReqSkills.NumSkills() != 0)
                {
                    AddReqSkillNodes(ref PreReqNode, SkillList[i].PreReqSkills);
                }

            }

        }

    }
}