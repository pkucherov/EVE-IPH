using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmsupportSplash : Form
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
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            pbPaypal = new PictureBox();
            pbPaypal.Click += new EventHandler(pbPaypal_Click);
            pbPaypal.MouseEnter += new EventHandler(pbPaypal_MouseEnter);
            pbPaypal.MouseLeave += new EventHandler(pbPaypal_MouseLeave);
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            pbPaetron = new PictureBox();
            pbPaetron.Click += new EventHandler(pbPaetron_Click);
            pbPaetron.MouseEnter += new EventHandler(pbPaetron_MouseEnter);
            pbPaetron.MouseLeave += new EventHandler(pbPaetron_MouseLeave);
            Label5 = new Label();
            Label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPaypal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPaetron).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(290, 267);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(86, 32);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // pbPaypal
            // 
            pbPaypal.BackColor = Color.Transparent;
            pbPaypal.Image = My.Resources.Resources.PayPalButton;
            pbPaypal.Location = new Point(132, 264);
            pbPaypal.Name = "pbPaypal";
            pbPaypal.Size = new Size(124, 35);
            pbPaypal.TabIndex = 6;
            pbPaypal.TabStop = false;
            // 
            // Label1
            // 
            Label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label1.Location = new Point(12, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(364, 89);
            Label1.TabIndex = 7;
            Label1.Text = "Are you Enjoying EVE IPH? Please support continued development by Donating!";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label2.Location = new Point(47, 98);
            Label2.Name = "Label2";
            Label2.Size = new Size(294, 54);
            Label2.TabIndex = 8;
            Label2.Text = "EVE IPH takes a lot of time to update and improve. If you can donate anything, it" + " would be much appreciated.";
            Label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label3.Location = new Point(47, 152);
            Label3.Name = "Label3";
            Label3.Size = new Size(294, 40);
            Label3.TabIndex = 9;
            Label3.Text = "Either donate to ZifrianEVE@gmail.com directly through Paypal or click the link b" + "elow.";
            Label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            Label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label4.Location = new Point(47, 192);
            Label4.Name = "Label4";
            Label4.Size = new Size(294, 23);
            Label4.TabIndex = 10;
            Label4.Text = "Thank you!";
            Label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbPaetron
            // 
            pbPaetron.BackColor = Color.Transparent;
            pbPaetron.Image = My.Resources.Resources.patreon_sm;
            pbPaetron.Location = new Point(132, 223);
            pbPaetron.Name = "pbPaetron";
            pbPaetron.Size = new Size(124, 35);
            pbPaetron.TabIndex = 11;
            pbPaetron.TabStop = false;
            // 
            // Label5
            // 
            Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label5.Location = new Point(47, 98);
            Label5.Name = "Label5";
            Label5.Size = new Size(294, 54);
            Label5.TabIndex = 8;
            Label5.Text = "EVE IPH takes a lot of time to update and improve. If you can donate anything, it" + " would be much appreciated.";
            Label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label6.Location = new Point(47, 152);
            Label6.Name = "Label6";
            Label6.Size = new Size(294, 40);
            Label6.TabIndex = 9;
            Label6.Text = "Either donate to ZifrianEVE@gmail.com directly through Paypal or click the link b" + "elow.";
            Label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmsupportSplash
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 311);
            ControlBox = false;
            Controls.Add(pbPaetron);
            Controls.Add(Label4);
            Controls.Add(Label6);
            Controls.Add(Label3);
            Controls.Add(Label5);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(pbPaypal);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmsupportSplash";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pbPaypal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPaetron).EndInit();
            ResumeLayout(false);

        }

        internal Button btnClose;
        internal PictureBox pbPaypal;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal PictureBox pbPaetron;
        internal Label Label5;
        internal Label Label6;
    }
}