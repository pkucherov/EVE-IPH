using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmAPIError : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAPIError));
            btnOK = new Button();
            btnOK.Click += new EventHandler(btnOK_Click);
            lblMain = new Label();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(162, 57);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(96, 30);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // lblMain
            // 
            lblMain.Location = new Point(11, 9);
            lblMain.Name = "lblMain";
            lblMain.Size = new Size(399, 45);
            lblMain.TabIndex = 1;
            lblMain.Text = "Label1";
            lblMain.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmAPIError
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(421, 111);
            Controls.Add(lblMain);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAPIError";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAPIError";
            Shown += new EventHandler(frmAPIError_Shown);
            ResumeLayout(false);

        }
        internal Button btnOK;
        internal Label lblMain;
    }
}