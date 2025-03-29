using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmCopyandPaste : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopyandPaste));
            btnImport = new Button();
            btnImport.Click += new EventHandler(btnImport_Click);
            txtPaste = new TextBox();
            txtPaste.KeyDown += new KeyEventHandler(txtPaste_KeyDown);
            txtPaste.KeyPress += new KeyPressEventHandler(txtPaste_KeyPress);
            txtPaste.TextChanged += new EventHandler(txtPaste_TextChanged);
            btnExit = new Button();
            btnExit.Click += new EventHandler(btnExit_Click);
            SuspendLayout();
            // 
            // btnImport
            // 
            btnImport.Enabled = false;
            btnImport.Location = new Point(117, 378);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(84, 24);
            btnImport.TabIndex = 0;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            // 
            // txtPaste
            // 
            txtPaste.Location = new Point(12, 5);
            txtPaste.Multiline = true;
            txtPaste.Name = "txtPaste";
            txtPaste.ScrollBars = ScrollBars.Vertical;
            txtPaste.Size = new Size(403, 356);
            txtPaste.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(225, 378);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(84, 24);
            btnExit.TabIndex = 2;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // frmCopyandPaste
            // 
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(427, 420);
            Controls.Add(btnExit);
            Controls.Add(txtPaste);
            Controls.Add(btnImport);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCopyandPaste";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EVE Isk per Hour - Import Text";
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button btnImport;
        internal TextBox txtPaste;
        internal Button btnExit;
    }
}