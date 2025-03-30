using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmChangeDummyCharacter : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeDummyCharacter));
            btnSave = new Button();
            btnSave.Click += new EventHandler(btnSave_Click);
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            txtName = new TextBox();
            txtName.KeyDown += new KeyEventHandler(txtName_KeyDown);
            lblName = new Label();
            lableCurrentName1 = new Label();
            lblCurrentName = new Label();
            Label1 = new Label();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(74, 93);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 25);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(155, 93);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 25);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(93, 36);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 20);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(24, 39);
            lblName.Name = "lblName";
            lblName.Size = new Size(63, 13);
            lblName.TabIndex = 2;
            lblName.Text = "New Name:";
            // 
            // lableCurrentName1
            // 
            lableCurrentName1.AutoSize = true;
            lableCurrentName1.Location = new Point(12, 17);
            lableCurrentName1.Name = "lableCurrentName1";
            lableCurrentName1.Size = new Size(75, 13);
            lableCurrentName1.TabIndex = 0;
            lableCurrentName1.Text = "Current Name:";
            // 
            // lblCurrentName
            // 
            lblCurrentName.BorderStyle = BorderStyle.FixedSingle;
            lblCurrentName.Location = new Point(93, 13);
            lblCurrentName.Name = "lblCurrentName";
            lblCurrentName.Size = new Size(200, 20);
            lblCurrentName.TabIndex = 1;
            lblCurrentName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            Label1.Location = new Point(47, 59);
            Label1.Name = "Label1";
            Label1.Size = new Size(211, 31);
            Label1.TabIndex = 4;
            Label1.Text = "An asterisk will be added to the name entered to signify dummy account";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmChangeDummyCharacter
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 126);
            Controls.Add(Label1);
            Controls.Add(lblCurrentName);
            Controls.Add(lableCurrentName1);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChangeDummyCharacter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Dummy Character Name";
            Shown += new EventHandler(frmChangeDummyCharacter_Shown);
            ResumeLayout(false);
            PerformLayout();

        }

        internal Button btnSave;
        internal Button btnClose;
        internal TextBox txtName;
        internal Label lblName;
        internal Label lableCurrentName1;
        internal Label lblCurrentName;
        internal Label Label1;
    }
}