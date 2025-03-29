using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmPatchNotes : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatchNotes));
            OKButton = new Button();
            OKButton.Click += new EventHandler(OKButton_Click);
            txtPatchNotes = new TextBox();
            SuspendLayout();
            // 
            // OKButton
            // 
            resources.ApplyResources(OKButton, "OKButton");
            OKButton.DialogResult = DialogResult.Cancel;
            OKButton.Name = "OKButton";
            // 
            // txtPatchNotes
            // 
            txtPatchNotes.BackColor = SystemColors.Window;
            resources.ApplyResources(txtPatchNotes, "txtPatchNotes");
            txtPatchNotes.Name = "txtPatchNotes";
            txtPatchNotes.ReadOnly = true;
            // 
            // frmPatchNotes
            // 
            AutoScaleMode = AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            Controls.Add(txtPatchNotes);
            Controls.Add(OKButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPatchNotes";
            Shown += new EventHandler(frmPatchNotes_Shown);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button OKButton;
        internal TextBox txtPatchNotes;
    }
}