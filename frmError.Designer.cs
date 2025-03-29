using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmError : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmError));
            btnOK = new Button();
            btnOK.Click += new EventHandler(btnOK_Click);
            txtError = new TextBox();
            btnCopy = new Button();
            btnCopy.Click += new EventHandler(btnCopy_Click);
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(274, 426);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(97, 30);
            btnOK.TabIndex = 0;
            btnOK.Text = "Close";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // txtError
            // 
            txtError.Location = new Point(12, 5);
            txtError.Multiline = true;
            txtError.Name = "txtError";
            txtError.ScrollBars = ScrollBars.Vertical;
            txtError.Size = new Size(505, 415);
            txtError.TabIndex = 1;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(157, 426);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(97, 30);
            btnCopy.TabIndex = 2;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // frmError
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(529, 468);
            Controls.Add(btnCopy);
            Controls.Add(txtError);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmError";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EVE Isk per Hour - Unhandled Error";
            Shown += new EventHandler(frmError_Shown);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button btnOK;
        internal TextBox txtError;
        internal Button btnCopy;
    }
}