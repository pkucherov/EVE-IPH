using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmSetCharacterDefault : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetCharacterDefault));
            chkListDefaultChar = new CheckedListBox();
            chkListDefaultChar.ItemCheck += new ItemCheckEventHandler(chkListDefaultChar_ItemCheck);
            btnSelectDefault = new Button();
            btnSelectDefault.Click += new EventHandler(btnSelectDefault_Click);
            btnCancel = new Button();
            btnCancel.Click += new EventHandler(btnCancel_Click);
            lblKeyType = new Label();
            SuspendLayout();
            // 
            // chkListDefaultChar
            // 
            chkListDefaultChar.CheckOnClick = true;
            chkListDefaultChar.FormattingEnabled = true;
            chkListDefaultChar.Location = new Point(20, 68);
            chkListDefaultChar.Name = "chkListDefaultChar";
            chkListDefaultChar.Size = new Size(270, 259);
            chkListDefaultChar.TabIndex = 0;
            chkListDefaultChar.ThreeDCheckBoxes = true;
            // 
            // btnSelectDefault
            // 
            btnSelectDefault.Location = new Point(53, 334);
            btnSelectDefault.Name = "btnSelectDefault";
            btnSelectDefault.Size = new Size(99, 26);
            btnSelectDefault.TabIndex = 4;
            btnSelectDefault.Text = "Select Default";
            btnSelectDefault.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(158, 334);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 26);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblKeyType
            // 
            lblKeyType.Location = new Point(20, 9);
            lblKeyType.Name = "lblKeyType";
            lblKeyType.Size = new Size(270, 56);
            lblKeyType.TabIndex = 12;
            lblKeyType.Text = "Select the default character from the list below. If there are no characters sele" + "cted, then choose Add Character from the File Menu in the main program and add y" + "our characters via ESI.";
            // 
            // frmSetCharacterDefault
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(311, 372);
            ControlBox = false;
            Controls.Add(lblKeyType);
            Controls.Add(btnCancel);
            Controls.Add(btnSelectDefault);
            Controls.Add(chkListDefaultChar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSetCharacterDefault";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Choose Default Character";
            Shown += new EventHandler(frmSetCharacterDefault_Shown);
            ResumeLayout(false);

        }
        internal CheckedListBox chkListDefaultChar;
        internal Button btnSelectDefault;
        internal Button btnCancel;
        internal Label lblKeyType;
    }
}