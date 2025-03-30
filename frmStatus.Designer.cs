using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmStatus : Form
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
            pgStatus = new ProgressBar();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // pgStatus
            // 
            pgStatus.Location = new Point(10, 42);
            pgStatus.Name = "pgStatus";
            pgStatus.Size = new Size(254, 13);
            pgStatus.TabIndex = 3;
            pgStatus.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(13, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(249, 29);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmStatus
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(274, 66);
            ControlBox = false;
            Controls.Add(pgStatus);
            Controls.Add(lblStatus);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStatus";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += new EventHandler(frmESIStatus_Load);
            ResumeLayout(false);

        }
        internal ProgressBar pgStatus;
        internal Label lblStatus;

    }
}