using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmCharacterStandings : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCharacterStandings));
            lblSkillName = new Label();
            lblCharacterName = new Label();
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            lstStandings = new ListView();
            rbtnPostive = new RadioButton();
            rbtnPostive.CheckedChanged += new EventHandler(rbtnPostive_CheckedChanged);
            rbtnNegative = new RadioButton();
            rbtnNegative.CheckedChanged += new EventHandler(rbtnNegative_CheckedChanged);
            rbtnBoth = new RadioButton();
            rbtnBoth.CheckedChanged += new EventHandler(rbtnBoth_CheckedChanged);
            gbStandingType = new GroupBox();
            gbSort = new GroupBox();
            rbtnSortName = new RadioButton();
            rbtnSortName.CheckedChanged += new EventHandler(rbtnSortName_CheckedChanged);
            rbtnSortStanding = new RadioButton();
            rbtnSortStanding.CheckedChanged += new EventHandler(rbtnSortStanding_CheckedChanged);
            gbStandingType.SuspendLayout();
            gbSort.SuspendLayout();
            SuspendLayout();
            // 
            // lblSkillName
            // 
            lblSkillName.AutoSize = true;
            lblSkillName.Location = new Point(12, 21);
            lblSkillName.Name = "lblSkillName";
            lblSkillName.Size = new Size(121, 13);
            lblSkillName.TabIndex = 0;
            lblSkillName.Text = "Character Standings for:";
            // 
            // lblCharacterName
            // 
            lblCharacterName.Location = new Point(134, 21);
            lblCharacterName.Name = "lblCharacterName";
            lblCharacterName.Size = new Size(216, 13);
            lblCharacterName.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(142, 400);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 25);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lstStandings
            // 
            lstStandings.FullRowSelect = true;
            lstStandings.GridLines = true;
            lstStandings.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstStandings.HideSelection = false;
            lstStandings.Location = new Point(15, 37);
            lstStandings.MultiSelect = false;
            lstStandings.Name = "lstStandings";
            lstStandings.Size = new Size(350, 310);
            lstStandings.TabIndex = 4;
            lstStandings.UseCompatibleStateImageBehavior = false;
            lstStandings.View = View.Details;
            // 
            // rbtnPostive
            // 
            rbtnPostive.AutoSize = true;
            rbtnPostive.Location = new Point(68, 16);
            rbtnPostive.Name = "rbtnPostive";
            rbtnPostive.Size = new Size(62, 17);
            rbtnPostive.TabIndex = 5;
            rbtnPostive.Text = "Positive";
            rbtnPostive.UseVisualStyleBackColor = true;
            // 
            // rbtnNegative
            // 
            rbtnNegative.AutoSize = true;
            rbtnNegative.Location = new Point(136, 16);
            rbtnNegative.Name = "rbtnNegative";
            rbtnNegative.Size = new Size(68, 17);
            rbtnNegative.TabIndex = 6;
            rbtnNegative.Text = "Negative";
            rbtnNegative.UseVisualStyleBackColor = true;
            // 
            // rbtnBoth
            // 
            rbtnBoth.AutoSize = true;
            rbtnBoth.Checked = true;
            rbtnBoth.Location = new Point(15, 16);
            rbtnBoth.Name = "rbtnBoth";
            rbtnBoth.Size = new Size(47, 17);
            rbtnBoth.TabIndex = 7;
            rbtnBoth.TabStop = true;
            rbtnBoth.Text = "Both";
            rbtnBoth.UseVisualStyleBackColor = true;
            // 
            // gbStandingType
            // 
            gbStandingType.Controls.Add(rbtnBoth);
            gbStandingType.Controls.Add(rbtnPostive);
            gbStandingType.Controls.Add(rbtnNegative);
            gbStandingType.Location = new Point(15, 353);
            gbStandingType.Name = "gbStandingType";
            gbStandingType.Size = new Size(210, 41);
            gbStandingType.TabIndex = 8;
            gbStandingType.TabStop = false;
            gbStandingType.Text = "Standing:";
            // 
            // gbSort
            // 
            gbSort.Controls.Add(rbtnSortName);
            gbSort.Controls.Add(rbtnSortStanding);
            gbSort.Location = new Point(231, 353);
            gbSort.Name = "gbSort";
            gbSort.Size = new Size(134, 41);
            gbSort.TabIndex = 9;
            gbSort.TabStop = false;
            gbSort.Text = "Sort by:";
            // 
            // rbtnSortName
            // 
            rbtnSortName.AutoSize = true;
            rbtnSortName.Location = new Point(75, 16);
            rbtnSortName.Name = "rbtnSortName";
            rbtnSortName.Size = new Size(53, 17);
            rbtnSortName.TabIndex = 5;
            rbtnSortName.Text = "Name";
            rbtnSortName.UseVisualStyleBackColor = true;
            // 
            // rbtnSortStanding
            // 
            rbtnSortStanding.AutoSize = true;
            rbtnSortStanding.Checked = true;
            rbtnSortStanding.Location = new Point(6, 16);
            rbtnSortStanding.Name = "rbtnSortStanding";
            rbtnSortStanding.Size = new Size(67, 17);
            rbtnSortStanding.TabIndex = 6;
            rbtnSortStanding.TabStop = true;
            rbtnSortStanding.Text = "Standing";
            rbtnSortStanding.UseVisualStyleBackColor = true;
            // 
            // frmCharacterStandings
            // 
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(378, 435);
            Controls.Add(gbSort);
            Controls.Add(gbStandingType);
            Controls.Add(lstStandings);
            Controls.Add(btnClose);
            Controls.Add(lblCharacterName);
            Controls.Add(lblSkillName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCharacterStandings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EVE Isk per Hour - Loaded Skills";
            gbStandingType.ResumeLayout(false);
            gbStandingType.PerformLayout();
            gbSort.ResumeLayout(false);
            gbSort.PerformLayout();
            Shown += new EventHandler(frmCharacterStandings_Shown);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Label lblSkillName;
        internal Label lblCharacterName;
        internal Button btnClose;
        internal ListView lstStandings;
        internal RadioButton rbtnPostive;
        internal RadioButton rbtnNegative;
        internal RadioButton rbtnBoth;
        internal GroupBox gbStandingType;
        internal GroupBox gbSort;
        internal RadioButton rbtnSortName;
        internal RadioButton rbtnSortStanding;
    }
}