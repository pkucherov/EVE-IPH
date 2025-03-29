using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmIndustryJobsViewer : Form
    {

        // Form overrides dispose to clean up the component list.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "myTimer")]
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndustryJobsViewer));
            lstIndustryJobs = new ListView();
            lstIndustryJobs.ColumnReordered += new ColumnReorderedEventHandler(lstIndustryJobs_ColumnReordered);
            lstIndustryJobs.ColumnWidthChanged += new ColumnWidthChangedEventHandler(lstIndustryJobs_ColumnWidthChanged);
            lstIndustryJobs.ColumnClick += new ColumnClickEventHandler(lstIndustryJobs_ColumnClick);
            gbIndustryJobType = new GroupBox();
            rbtnBothJobs = new RadioButton();
            rbtnBothJobs.CheckedChanged += new EventHandler(rbtnBothJobs_CheckedChanged);
            rbtnCorpJobs = new RadioButton();
            rbtnCorpJobs.CheckedChanged += new EventHandler(rbtnCorpJobs_CheckedChanged);
            rbtnPersonalJobs = new RadioButton();
            rbtnPersonalJobs.CheckedChanged += new EventHandler(rbtnPersonalJobs_CheckedChanged);
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnUpdateJobs = new Button();
            btnUpdateJobs.Click += new EventHandler(btnUpdateJobs_Click);
            btnSelectColumns = new Button();
            btnSelectColumns.Click += new EventHandler(btnSelectColumns_Click);
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            ttMain = new ToolTip(components);
            gbInventionJobs = new GroupBox();
            gbJobTimes = new GroupBox();
            rbtnJobHistory = new RadioButton();
            rbtnJobHistory.CheckedChanged += new EventHandler(rbtnJobHistory_CheckedChanged);
            rbtnCurrentJobs = new RadioButton();
            rbtnCurrentJobs.CheckedChanged += new EventHandler(rbtnCurrentJobs_CheckedChanged);
            gbButtons = new GroupBox();
            chkAutoUpdate = new CheckBox();
            chkAutoUpdate.CheckedChanged += new EventHandler(chkAutoUpdate_CheckedChanged);
            btnRefreshList = new Button();
            btnRefreshList.Click += new EventHandler(btnRefreshList_Click);
            lstCharacters = new MyListView();
            lstCharacters.ColumnClick += new ColumnClickEventHandler(lstCharacters_ColumnClick);
            lstCharacters.ItemChecked += new ItemCheckedEventHandler(lstCharacters_ItemChecked);
            gbIndustryJobType.SuspendLayout();
            gbInventionJobs.SuspendLayout();
            gbJobTimes.SuspendLayout();
            gbButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lstIndustryJobs
            // 
            lstIndustryJobs.AllowColumnReorder = true;
            lstIndustryJobs.FullRowSelect = true;
            lstIndustryJobs.HideSelection = false;
            lstIndustryJobs.Location = new Point(12, 11);
            lstIndustryJobs.MultiSelect = false;
            lstIndustryJobs.Name = "lstIndustryJobs";
            lstIndustryJobs.Size = new Size(1068, 489);
            lstIndustryJobs.TabIndex = 9;
            lstIndustryJobs.UseCompatibleStateImageBehavior = false;
            lstIndustryJobs.View = View.Details;
            // 
            // gbIndustryJobType
            // 
            gbIndustryJobType.Controls.Add(rbtnBothJobs);
            gbIndustryJobType.Controls.Add(rbtnCorpJobs);
            gbIndustryJobType.Controls.Add(rbtnPersonalJobs);
            gbIndustryJobType.Location = new Point(12, 506);
            gbIndustryJobType.Name = "gbIndustryJobType";
            gbIndustryJobType.Size = new Size(108, 76);
            gbIndustryJobType.TabIndex = 64;
            gbIndustryJobType.TabStop = false;
            gbIndustryJobType.Text = "Industry Job Type:";
            // 
            // rbtnBothJobs
            // 
            rbtnBothJobs.AutoSize = true;
            rbtnBothJobs.Location = new Point(11, 51);
            rbtnBothJobs.Name = "rbtnBothJobs";
            rbtnBothJobs.Size = new Size(47, 17);
            rbtnBothJobs.TabIndex = 2;
            rbtnBothJobs.TabStop = true;
            rbtnBothJobs.Text = "Both";
            rbtnBothJobs.UseVisualStyleBackColor = true;
            // 
            // rbtnCorpJobs
            // 
            rbtnCorpJobs.AutoSize = true;
            rbtnCorpJobs.Location = new Point(11, 34);
            rbtnCorpJobs.Name = "rbtnCorpJobs";
            rbtnCorpJobs.Size = new Size(79, 17);
            rbtnCorpJobs.TabIndex = 1;
            rbtnCorpJobs.TabStop = true;
            rbtnCorpJobs.Text = "Corporation";
            rbtnCorpJobs.UseVisualStyleBackColor = true;
            // 
            // rbtnPersonalJobs
            // 
            rbtnPersonalJobs.AutoSize = true;
            rbtnPersonalJobs.Location = new Point(11, 17);
            rbtnPersonalJobs.Name = "rbtnPersonalJobs";
            rbtnPersonalJobs.Size = new Size(66, 17);
            rbtnPersonalJobs.TabIndex = 0;
            rbtnPersonalJobs.TabStop = true;
            rbtnPersonalJobs.Text = "Personal";
            rbtnPersonalJobs.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(112, 56);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 65;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnUpdateJobs
            // 
            btnUpdateJobs.Location = new Point(6, 56);
            btnUpdateJobs.Name = "btnUpdateJobs";
            btnUpdateJobs.Size = new Size(100, 40);
            btnUpdateJobs.TabIndex = 66;
            btnUpdateJobs.Text = "Update Jobs";
            btnUpdateJobs.UseVisualStyleBackColor = true;
            // 
            // btnSelectColumns
            // 
            btnSelectColumns.Location = new Point(6, 101);
            btnSelectColumns.Name = "btnSelectColumns";
            btnSelectColumns.Size = new Size(100, 40);
            btnSelectColumns.TabIndex = 67;
            btnSelectColumns.Text = "Select Columns";
            btnSelectColumns.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(112, 11);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(100, 40);
            btnSaveSettings.TabIndex = 68;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // ttMain
            // 
            ttMain.IsBalloon = true;
            // 
            // gbInventionJobs
            // 
            gbInventionJobs.Controls.Add(gbIndustryJobType);
            gbInventionJobs.Controls.Add(lstCharacters);
            gbInventionJobs.Controls.Add(gbJobTimes);
            gbInventionJobs.Controls.Add(gbButtons);
            gbInventionJobs.Controls.Add(lstIndustryJobs);
            gbInventionJobs.Location = new Point(7, 1);
            gbInventionJobs.Name = "gbInventionJobs";
            gbInventionJobs.Size = new Size(1080, 659);
            gbInventionJobs.TabIndex = 69;
            gbInventionJobs.TabStop = false;
            // 
            // gbJobTimes
            // 
            gbJobTimes.Controls.Add(rbtnJobHistory);
            gbJobTimes.Controls.Add(rbtnCurrentJobs);
            gbJobTimes.Location = new Point(12, 588);
            gbJobTimes.Name = "gbJobTimes";
            gbJobTimes.Size = new Size(108, 64);
            gbJobTimes.TabIndex = 65;
            gbJobTimes.TabStop = false;
            gbJobTimes.Text = "Job Display Type:";
            // 
            // rbtnJobHistory
            // 
            rbtnJobHistory.AutoSize = true;
            rbtnJobHistory.Location = new Point(12, 39);
            rbtnJobHistory.Name = "rbtnJobHistory";
            rbtnJobHistory.Size = new Size(77, 17);
            rbtnJobHistory.TabIndex = 1;
            rbtnJobHistory.TabStop = true;
            rbtnJobHistory.Text = "Job History";
            rbtnJobHistory.UseVisualStyleBackColor = true;
            // 
            // rbtnCurrentJobs
            // 
            rbtnCurrentJobs.AutoSize = true;
            rbtnCurrentJobs.Location = new Point(12, 21);
            rbtnCurrentJobs.Name = "rbtnCurrentJobs";
            rbtnCurrentJobs.Size = new Size(84, 17);
            rbtnCurrentJobs.TabIndex = 0;
            rbtnCurrentJobs.TabStop = true;
            rbtnCurrentJobs.Text = "Current Jobs";
            rbtnCurrentJobs.UseVisualStyleBackColor = true;
            // 
            // gbButtons
            // 
            gbButtons.Controls.Add(chkAutoUpdate);
            gbButtons.Controls.Add(btnRefreshList);
            gbButtons.Controls.Add(btnClose);
            gbButtons.Controls.Add(btnUpdateJobs);
            gbButtons.Controls.Add(btnSelectColumns);
            gbButtons.Controls.Add(btnSaveSettings);
            gbButtons.Location = new Point(126, 506);
            gbButtons.Name = "gbButtons";
            gbButtons.Size = new Size(217, 146);
            gbButtons.TabIndex = 69;
            gbButtons.TabStop = false;
            // 
            // chkAutoUpdate
            // 
            chkAutoUpdate.Location = new Point(117, 100);
            chkAutoUpdate.Name = "chkAutoUpdate";
            chkAutoUpdate.Size = new Size(94, 43);
            chkAutoUpdate.TabIndex = 0;
            chkAutoUpdate.Text = "Automatically Update Jobs on Startup";
            chkAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // btnRefreshList
            // 
            btnRefreshList.Location = new Point(6, 11);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(100, 40);
            btnRefreshList.TabIndex = 70;
            btnRefreshList.Text = "Refresh";
            btnRefreshList.UseVisualStyleBackColor = true;
            // 
            // lstCharacters
            // 
            lstCharacters.CheckBoxes = true;
            lstCharacters.FullRowSelect = true;
            lstCharacters.GridLines = true;
            lstCharacters.Location = new Point(349, 512);
            lstCharacters.MultiSelect = false;
            lstCharacters.Name = "lstCharacters";
            lstCharacters.Size = new Size(725, 140);
            lstCharacters.TabIndex = 70;
            lstCharacters.TabStop = false;
            lstCharacters.Tag = "20";
            lstCharacters.UseCompatibleStateImageBehavior = false;
            lstCharacters.View = View.Details;
            // 
            // frmIndustryJobsViewer
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(1094, 665);
            Controls.Add(gbInventionJobs);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmIndustryJobsViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Current Industry Jobs";
            gbIndustryJobType.ResumeLayout(false);
            gbIndustryJobType.PerformLayout();
            gbInventionJobs.ResumeLayout(false);
            gbJobTimes.ResumeLayout(false);
            gbJobTimes.PerformLayout();
            gbButtons.ResumeLayout(false);
            Shown += new EventHandler(frmIndustryJobsViewer_Shown);
            Closing += new System.ComponentModel.CancelEventHandler(frmIndustryJobsViewer_Closing);
            FormClosing += new FormClosingEventHandler(frmIndustryJobsViewer_FormClosing);
            ResumeLayout(false);

        }
        internal ListView lstIndustryJobs;
        internal GroupBox gbIndustryJobType;
        internal RadioButton rbtnBothJobs;
        internal RadioButton rbtnCorpJobs;
        internal RadioButton rbtnPersonalJobs;
        internal Button btnClose;
        internal Button btnUpdateJobs;
        internal Button btnSelectColumns;
        internal Button btnSaveSettings;
        internal ToolTip ttMain;
        internal GroupBox gbInventionJobs;
        internal GroupBox gbButtons;
        internal Button btnRefreshList;
        internal GroupBox gbJobTimes;
        internal RadioButton rbtnJobHistory;
        internal RadioButton rbtnCurrentJobs;
        internal MyListView lstCharacters;
        internal CheckBox chkAutoUpdate;
    }
}