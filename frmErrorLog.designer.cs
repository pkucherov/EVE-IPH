using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmErrorLog : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmErrorLog));
            btnClose = new Button();
            btnClose.Click += new EventHandler(OKButton_Click);
            txtLog = new TextBox();
            btnCopyLog = new Button();
            btnCopyLog.Click += new EventHandler(btnCopyLog_Click);
            btnClearLog = new Button();
            btnClearLog.Click += new EventHandler(btnClearLog_Click);
            SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Name = "btnClose";
            // 
            // txtLog
            // 
            txtLog.BackColor = SystemColors.Window;
            resources.ApplyResources(txtLog, "txtLog");
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            // 
            // btnCopyLog
            // 
            resources.ApplyResources(btnCopyLog, "btnCopyLog");
            btnCopyLog.DialogResult = DialogResult.Cancel;
            btnCopyLog.Name = "btnCopyLog";
            // 
            // btnClearLog
            // 
            resources.ApplyResources(btnClearLog, "btnClearLog");
            btnClearLog.DialogResult = DialogResult.Cancel;
            btnClearLog.Name = "btnClearLog";
            // 
            // frmErrorLog
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(btnClearLog);
            Controls.Add(btnCopyLog);
            Controls.Add(txtLog);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmErrorLog";
            Shown += new EventHandler(frmPatchNotes_Shown);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button btnClose;
        internal TextBox txtLog;
        internal Button btnCopyLog;
        internal Button btnClearLog;
    }
}