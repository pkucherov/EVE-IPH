using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmSelectIndustryJobColumns : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectIndustryJobColumns));
            btnCancel = new Button();
            btnCancel.Click += new EventHandler(btnClose_Click);
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            lblInstruction = new Label();
            lblTip = new Label();
            chkLstBoxColumns = new CheckedListBox();
            chkLstBoxColumns.SelectedIndexChanged += new EventHandler(chkLstBoxColumns_SelectedIndexChanged);
            btnDefaults = new Button();
            btnDefaults.Click += new EventHandler(btnDefaults_Click);
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(154, 387);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(97, 25);
            btnCancel.TabIndex = 67;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(35, 387);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(97, 25);
            btnSaveSettings.TabIndex = 69;
            btnSaveSettings.Text = "Save";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // lblInstruction
            // 
            lblInstruction.Location = new Point(12, 9);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(273, 19);
            lblInstruction.TabIndex = 70;
            lblInstruction.Text = "Select the Columns you want to view:";
            // 
            // lblTip
            // 
            lblTip.Location = new Point(12, 323);
            lblTip.Name = "lblTip";
            lblTip.Size = new Size(260, 30);
            lblTip.TabIndex = 71;
            lblTip.Text = "You can change the order of the columns by dragging them into location in the Ind" + "ustry Jobs list";
            // 
            // chkLstBoxColumns
            // 
            chkLstBoxColumns.FormattingEnabled = true;
            chkLstBoxColumns.Items.AddRange(new object[] { "Job State", "Installer", "Time to Complete", "Activity", "Status", "Start Time", "End Time", "Completed Time", "Blueprint", "Output Item", "Output Item Type", "Install Solar System", "Install Region", "Licensed Runs", "Runs", "Successful Runs", "Blueprint Location", "Output Location", "Job Type", "Local Completion Time" });
            chkLstBoxColumns.Location = new Point(15, 31);
            chkLstBoxColumns.Name = "chkLstBoxColumns";
            chkLstBoxColumns.Size = new Size(257, 289);
            chkLstBoxColumns.TabIndex = 72;
            // 
            // btnDefaults
            // 
            btnDefaults.Location = new Point(95, 356);
            btnDefaults.Name = "btnDefaults";
            btnDefaults.Size = new Size(97, 25);
            btnDefaults.TabIndex = 73;
            btnDefaults.Text = "Reset to Default";
            btnDefaults.UseVisualStyleBackColor = true;
            // 
            // frmSelectIndustryJobColumns
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(287, 423);
            Controls.Add(btnDefaults);
            Controls.Add(chkLstBoxColumns);
            Controls.Add(lblTip);
            Controls.Add(lblInstruction);
            Controls.Add(btnSaveSettings);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectIndustryJobColumns";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Columns";
            Shown += new EventHandler(frmSelectIndustryJobColumns_Shown);
            ResumeLayout(false);

        }
        internal Button btnCancel;
        internal Button btnSaveSettings;
        internal Label lblInstruction;
        internal Label lblTip;
        internal CheckedListBox chkLstBoxColumns;
        internal Button btnDefaults;
    }
}