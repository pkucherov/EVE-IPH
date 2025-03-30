using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmAppRegistrationNotice : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppRegistrationNotice));
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            SuspendLayout();
            // 
            // Button1
            // 
            Button1.Location = new Point(173, 325);
            Button1.Name = "Button1";
            Button1.Size = new Size(110, 34);
            Button1.TabIndex = 0;
            Button1.Text = "OK";
            Button1.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label1.Location = new Point(12, 39);
            Label1.Name = "Label1";
            Label1.Size = new Size(429, 154);
            Label1.TabIndex = 1;
            Label1.Text = resources.GetString("Label1.Text");
            Label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // Label2
            // 
            Label2.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label2.Location = new Point(12, 195);
            Label2.Name = "Label2";
            Label2.Size = new Size(429, 67);
            Label2.TabIndex = 2;
            Label2.Text = "If you previously registered EVE IPH as through the developers site, you may dele" + "te any applications you may have created for EVE IPH as they are no longer neede" + "d.";
            Label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // Label3
            // 
            Label3.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label3.Location = new Point(12, 277);
            Label3.Name = "Label3";
            Label3.Size = new Size(429, 31);
            Label3.TabIndex = 3;
            Label3.Text = "Thank you.";
            Label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // Label4
            // 
            Label4.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            Label4.Location = new Point(12, 9);
            Label4.Name = "Label4";
            Label4.Size = new Size(429, 30);
            Label4.TabIndex = 4;
            Label4.Text = "Character Registration Notice";
            Label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmAppRegistrationNotice
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 381);
            ControlBox = false;
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(Button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAppRegistrationNotice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Character Registration Notice";
            ResumeLayout(false);

        }

        internal Button Button1;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
    }
}