using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmCharacterSkills : Form
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCharacterSkills));
            lblSkillName = new Label();
            lblCharacterName = new Label();
            SkillTree = new TreeView();
            SkillTree.MouseClick += new MouseEventHandler(SkillTree_MouseClick);
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnRefresh = new Button();
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            contextOverride = new ContextMenuStrip(components);
            mnuOrigLevel = new ToolStripMenuItem();
            mnuOrigLevel.Click += new EventHandler(mnuOrigLevel_Click);
            ToolStripSeparator1 = new ToolStripSeparator();
            mnuLevel0 = new ToolStripMenuItem();
            mnuLevel0.Click += new EventHandler(mnuLevel0_Click);
            mnuLevel1 = new ToolStripMenuItem();
            mnuLevel1.Click += new EventHandler(mnuLevel1_Click);
            mnuLevel2 = new ToolStripMenuItem();
            mnuLevel2.Click += new EventHandler(mnuLevel2_Click);
            mnuLevel3 = new ToolStripMenuItem();
            mnuLevel3.Click += new EventHandler(mnuLevel3_Click);
            mnuLevel4 = new ToolStripMenuItem();
            mnuLevel4.Click += new EventHandler(mnuLevel4_Click);
            mnuLevel5 = new ToolStripMenuItem();
            mnuLevel5.Click += new EventHandler(mnuLevel5_Click);
            gbOverride = new GroupBox();
            chkAllLevel5 = new CheckBox();
            chkAllLevel5.CheckedChanged += new EventHandler(chkAllLevel5_CheckedChanged);
            chkSkillOverride = new CheckBox();
            chkSkillOverride.CheckedChanged += new EventHandler(chkSkillOverride_CheckedChanged);
            gbCharName = new GroupBox();
            btnSave = new Button();
            btnSave.Click += new EventHandler(btnSave_Click);
            txtSkillNameFilter = new TextBox();
            txtSkillNameFilter.KeyDown += new KeyEventHandler(txtSkillNameFilter_KeyDown);
            lblSkillNameFilter = new Label();
            btnClearItemFilter = new Button();
            btnClearItemFilter.Click += new EventHandler(btnClearItemFilter_Click);
            contextOverride.SuspendLayout();
            gbOverride.SuspendLayout();
            gbCharName.SuspendLayout();
            SuspendLayout();
            // 
            // lblSkillName
            // 
            lblSkillName.AutoSize = true;
            lblSkillName.Location = new Point(11, 13);
            lblSkillName.Name = "lblSkillName";
            lblSkillName.Size = new Size(56, 13);
            lblSkillName.TabIndex = 0;
            lblSkillName.Text = "Character:";
            // 
            // lblCharacterName
            // 
            lblCharacterName.Location = new Point(64, 13);
            lblCharacterName.Name = "lblCharacterName";
            lblCharacterName.Size = new Size(268, 13);
            lblCharacterName.TabIndex = 1;
            // 
            // SkillTree
            // 
            SkillTree.Location = new Point(12, 80);
            SkillTree.Name = "SkillTree";
            SkillTree.Size = new Size(338, 359);
            SkillTree.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(234, 474);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 25);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(34, 474);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 25);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // contextOverride
            // 
            contextOverride.AutoSize = false;
            contextOverride.Items.AddRange(new ToolStripItem[] { mnuOrigLevel, ToolStripSeparator1, mnuLevel0, mnuLevel1, mnuLevel2, mnuLevel3, mnuLevel4, mnuLevel5 });
            contextOverride.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            contextOverride.Name = "contextOverride";
            contextOverride.ShowCheckMargin = true;
            contextOverride.ShowImageMargin = false;
            contextOverride.ShowItemToolTips = false;
            contextOverride.Size = new Size(125, 175);
            // 
            // mnuOrigLevel
            // 
            mnuOrigLevel.AutoSize = false;
            mnuOrigLevel.CheckOnClick = true;
            mnuOrigLevel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mnuOrigLevel.Name = "mnuOrigLevel";
            mnuOrigLevel.Size = new Size(125, 22);
            mnuOrigLevel.Text = "No Override";
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(121, 6);
            // 
            // mnuLevel0
            // 
            mnuLevel0.Name = "mnuLevel0";
            mnuLevel0.Size = new Size(138, 22);
            mnuLevel0.Text = "Level 0";
            // 
            // mnuLevel1
            // 
            mnuLevel1.AutoSize = false;
            mnuLevel1.CheckOnClick = true;
            mnuLevel1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mnuLevel1.Name = "mnuLevel1";
            mnuLevel1.Size = new Size(123, 22);
            mnuLevel1.Text = "Level 1";
            // 
            // mnuLevel2
            // 
            mnuLevel2.AutoSize = false;
            mnuLevel2.CheckOnClick = true;
            mnuLevel2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mnuLevel2.Name = "mnuLevel2";
            mnuLevel2.Size = new Size(123, 22);
            mnuLevel2.Text = "Level 2";
            // 
            // mnuLevel3
            // 
            mnuLevel3.AutoSize = false;
            mnuLevel3.CheckOnClick = true;
            mnuLevel3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mnuLevel3.Name = "mnuLevel3";
            mnuLevel3.Size = new Size(123, 22);
            mnuLevel3.Text = "Level 3";
            // 
            // mnuLevel4
            // 
            mnuLevel4.AutoSize = false;
            mnuLevel4.CheckOnClick = true;
            mnuLevel4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mnuLevel4.Name = "mnuLevel4";
            mnuLevel4.Size = new Size(123, 22);
            mnuLevel4.Text = "Level 4";
            // 
            // mnuLevel5
            // 
            mnuLevel5.AutoSize = false;
            mnuLevel5.CheckOnClick = true;
            mnuLevel5.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mnuLevel5.Name = "mnuLevel5";
            mnuLevel5.Size = new Size(123, 22);
            mnuLevel5.Text = "Level 5";
            // 
            // gbOverride
            // 
            gbOverride.Controls.Add(chkAllLevel5);
            gbOverride.Controls.Add(chkSkillOverride);
            gbOverride.Location = new Point(12, 40);
            gbOverride.Name = "gbOverride";
            gbOverride.Size = new Size(338, 34);
            gbOverride.TabIndex = 6;
            gbOverride.TabStop = false;
            // 
            // chkAllLevel5
            // 
            chkAllLevel5.AutoSize = true;
            chkAllLevel5.Location = new Point(184, 11);
            chkAllLevel5.Name = "chkAllLevel5";
            chkAllLevel5.Size = new Size(132, 17);
            chkAllLevel5.TabIndex = 0;
            chkAllLevel5.Text = "Set all Skills to Level 5";
            chkAllLevel5.UseVisualStyleBackColor = true;
            // 
            // chkSkillOverride
            // 
            chkSkillOverride.AutoSize = true;
            chkSkillOverride.Location = new Point(22, 11);
            chkSkillOverride.Name = "chkSkillOverride";
            chkSkillOverride.Size = new Size(93, 17);
            chkSkillOverride.TabIndex = 0;
            chkSkillOverride.Text = "Override Skills";
            chkSkillOverride.UseVisualStyleBackColor = true;
            // 
            // gbCharName
            // 
            gbCharName.Controls.Add(lblSkillName);
            gbCharName.Controls.Add(lblCharacterName);
            gbCharName.Location = new Point(12, 7);
            gbCharName.Name = "gbCharName";
            gbCharName.Size = new Size(338, 34);
            gbCharName.TabIndex = 7;
            gbCharName.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(134, 474);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 25);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save Settings";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtSkillNameFilter
            // 
            txtSkillNameFilter.Location = new Point(111, 445);
            txtSkillNameFilter.Name = "txtSkillNameFilter";
            txtSkillNameFilter.Size = new Size(166, 20);
            txtSkillNameFilter.TabIndex = 11;
            // 
            // lblSkillNameFilter
            // 
            lblSkillNameFilter.AutoSize = true;
            lblSkillNameFilter.Location = new Point(20, 448);
            lblSkillNameFilter.Name = "lblSkillNameFilter";
            lblSkillNameFilter.Size = new Size(85, 13);
            lblSkillNameFilter.TabIndex = 10;
            lblSkillNameFilter.Text = "Skill Name Filter:";
            // 
            // btnClearItemFilter
            // 
            btnClearItemFilter.Location = new Point(283, 444);
            btnClearItemFilter.Name = "btnClearItemFilter";
            btnClearItemFilter.Size = new Size(59, 21);
            btnClearItemFilter.TabIndex = 13;
            btnClearItemFilter.Text = "Clear";
            btnClearItemFilter.UseVisualStyleBackColor = true;
            // 
            // frmCharacterSkills
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(362, 511);
            Controls.Add(btnClearItemFilter);
            Controls.Add(txtSkillNameFilter);
            Controls.Add(lblSkillNameFilter);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(gbCharName);
            Controls.Add(SkillTree);
            Controls.Add(gbOverride);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCharacterSkills";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EVE Isk per Hour - Loaded Skills";
            contextOverride.ResumeLayout(false);
            gbOverride.ResumeLayout(false);
            gbOverride.PerformLayout();
            gbCharName.ResumeLayout(false);
            gbCharName.PerformLayout();
            Load += new EventHandler(frmCharacterSkills_Load);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Label lblSkillName;
        internal Label lblCharacterName;
        internal TreeView SkillTree;
        internal Button btnClose;
        internal Button btnRefresh;
        internal ContextMenuStrip contextOverride;
        internal ToolStripMenuItem mnuLevel1;
        internal ToolStripMenuItem mnuLevel2;
        internal ToolStripMenuItem mnuLevel3;
        internal ToolStripMenuItem mnuLevel4;
        internal ToolStripMenuItem mnuLevel5;
        internal GroupBox gbOverride;
        internal CheckBox chkSkillOverride;
        internal GroupBox gbCharName;
        internal Button btnSave;
        internal ToolStripMenuItem mnuOrigLevel;
        internal ToolStripSeparator ToolStripSeparator1;
        internal CheckBox chkAllLevel5;
        internal ToolStripMenuItem mnuLevel0;
        internal TextBox txtSkillNameFilter;
        internal Label lblSkillNameFilter;
        internal Button btnClearItemFilter;
    }
}