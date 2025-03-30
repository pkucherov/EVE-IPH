using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmBonusPopout : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBonusPopout));
            lstUpwellStructureBonuses = new ListView();
            lstUpwellStructureBonuses.ColumnClick += new ColumnClickEventHandler(lstUpwellStructureBonuses_ColumnClick);
            BonusAppliesTo = new ColumnHeader();
            Activity = new ColumnHeader();
            Bonuses = new ColumnHeader();
            Source = new ColumnHeader();
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            SuspendLayout();
            // 
            // lstUpwellStructureBonuses
            // 
            lstUpwellStructureBonuses.Columns.AddRange(new ColumnHeader[] { BonusAppliesTo, Activity, Bonuses, Source });
            lstUpwellStructureBonuses.FullRowSelect = true;
            lstUpwellStructureBonuses.GridLines = true;
            lstUpwellStructureBonuses.HideSelection = false;
            lstUpwellStructureBonuses.Location = new Point(11, 15);
            lstUpwellStructureBonuses.MultiSelect = false;
            lstUpwellStructureBonuses.Name = "lstUpwellStructureBonuses";
            lstUpwellStructureBonuses.Size = new Size(712, 181);
            lstUpwellStructureBonuses.TabIndex = 83;
            lstUpwellStructureBonuses.TabStop = false;
            lstUpwellStructureBonuses.UseCompatibleStateImageBehavior = false;
            lstUpwellStructureBonuses.View = View.Details;
            // 
            // BonusAppliesTo
            // 
            BonusAppliesTo.Text = "Bonus Applies to";
            BonusAppliesTo.Width = 150;
            // 
            // Activity
            // 
            Activity.Text = "Activity";
            Activity.Width = 125;
            // 
            // Bonuses
            // 
            Bonuses.Text = "Bonuses";
            Bonuses.Width = 250;
            // 
            // Source
            // 
            Source.Text = "Bonus Source";
            Source.Width = 165;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(271, 202);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(86, 28);
            btnSaveSettings.TabIndex = 84;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(377, 202);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(86, 28);
            btnClose.TabIndex = 85;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // frmBonusPopout
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 236);
            Controls.Add(btnClose);
            Controls.Add(btnSaveSettings);
            Controls.Add(lstUpwellStructureBonuses);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(750, 275);
            Name = "frmBonusPopout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Facility Bonuses";
            Layout += new LayoutEventHandler(frmBonusPopout_Layout);
            ResumeLayout(false);

        }

        internal ListView lstUpwellStructureBonuses;
        internal ColumnHeader BonusAppliesTo;
        internal ColumnHeader Activity;
        internal ColumnHeader Bonuses;
        internal ColumnHeader Source;
        internal Button btnSaveSettings;
        internal Button btnClose;
    }
}