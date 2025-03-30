using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmAbout : Form
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

        internal TableLayoutPanel TableLayoutPanel;
        internal Label LabelProductName;
        internal Label LabelVersion;
        internal Label LabelCompanyName;
        internal TextBox TextBoxDescription;
        internal Button OKButton;
        internal Label LabelCopyright;

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            TableLayoutPanel = new TableLayoutPanel();
            LabelProductName = new Label();
            LabelVersion = new Label();
            LabelCopyright = new Label();
            LabelCompanyName = new Label();
            TextBoxDescription = new TextBox();
            OKButton = new Button();
            OKButton.Click += new EventHandler(OKButton_Click);
            pbPaypal = new PictureBox();
            pbPaypal.Click += new EventHandler(pbPaypal_Click);
            pbPaypal.MouseEnter += new EventHandler(pbPaypal_MouseEnter);
            pbPaypal.MouseLeave += new EventHandler(pbPaypal_MouseLeave);
            LogoPictureBox = new PictureBox();
            pbPatreon = new PictureBox();
            pbPatreon.Click += new EventHandler(pbPatreon_Click);
            pbPatreon.MouseEnter += new EventHandler(pbPatreon_MouseEnter);
            pbPatreon.MouseLeave += new EventHandler(pbPatreon_MouseLeave);
            PictureBox1 = new PictureBox();
            TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPaypal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPatreon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            TableLayoutPanel.ColumnCount = 2;
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.0f));
            TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.0f));
            TableLayoutPanel.Controls.Add(LabelProductName, 1, 0);
            TableLayoutPanel.Controls.Add(LabelVersion, 1, 1);
            TableLayoutPanel.Controls.Add(LabelCopyright, 1, 2);
            TableLayoutPanel.Controls.Add(LabelCompanyName, 1, 3);
            TableLayoutPanel.Controls.Add(TextBoxDescription, 1, 4);
            TableLayoutPanel.Controls.Add(LogoPictureBox, 0, 0);
            TableLayoutPanel.Controls.Add(OKButton, 1, 6);
            TableLayoutPanel.Controls.Add(PictureBox1, 1, 7);
            TableLayoutPanel.Controls.Add(pbPatreon, 0, 7);
            TableLayoutPanel.Controls.Add(pbPaypal, 0, 6);
            TableLayoutPanel.Dock = DockStyle.Fill;
            TableLayoutPanel.Location = new Point(9, 9);
            TableLayoutPanel.Name = "TableLayoutPanel";
            TableLayoutPanel.RowCount = 8;
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.724996f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.452375f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.179757f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.81547f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50.97971f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.33392f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.51377f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            TableLayoutPanel.Size = new Size(396, 330);
            TableLayoutPanel.TabIndex = 0;
            // 
            // LabelProductName
            // 
            LabelProductName.Dock = DockStyle.Fill;
            LabelProductName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelProductName.Location = new Point(136, 0);
            LabelProductName.Margin = new Padding(6, 0, 3, 0);
            LabelProductName.MaximumSize = new Size(0, 17);
            LabelProductName.Name = "LabelProductName";
            LabelProductName.Size = new Size(257, 16);
            LabelProductName.TabIndex = 0;
            LabelProductName.Text = "Product Name";
            LabelProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelVersion
            // 
            LabelVersion.Dock = DockStyle.Fill;
            LabelVersion.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelVersion.Location = new Point(136, 16);
            LabelVersion.Margin = new Padding(6, 0, 3, 0);
            LabelVersion.MaximumSize = new Size(0, 17);
            LabelVersion.Name = "LabelVersion";
            LabelVersion.Size = new Size(257, 15);
            LabelVersion.TabIndex = 0;
            LabelVersion.Text = "Version";
            LabelVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelCopyright
            // 
            LabelCopyright.Dock = DockStyle.Fill;
            LabelCopyright.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelCopyright.Location = new Point(136, 31);
            LabelCopyright.Margin = new Padding(6, 0, 3, 0);
            LabelCopyright.MaximumSize = new Size(0, 17);
            LabelCopyright.Name = "LabelCopyright";
            LabelCopyright.Size = new Size(257, 15);
            LabelCopyright.TabIndex = 0;
            LabelCopyright.Text = "Copyright";
            LabelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelCompanyName
            // 
            LabelCompanyName.Dock = DockStyle.Fill;
            LabelCompanyName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelCompanyName.Location = new Point(136, 46);
            LabelCompanyName.Margin = new Padding(6, 0, 3, 0);
            LabelCompanyName.MaximumSize = new Size(0, 17);
            LabelCompanyName.Name = "LabelCompanyName";
            LabelCompanyName.Size = new Size(257, 17);
            LabelCompanyName.TabIndex = 0;
            LabelCompanyName.Text = "Company Name";
            LabelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBoxDescription
            // 
            TextBoxDescription.Dock = DockStyle.Fill;
            TextBoxDescription.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBoxDescription.Location = new Point(136, 68);
            TextBoxDescription.Margin = new Padding(6, 3, 3, 3);
            TextBoxDescription.Multiline = true;
            TextBoxDescription.Name = "TextBoxDescription";
            TextBoxDescription.ReadOnly = true;
            TableLayoutPanel.SetRowSpan(TextBoxDescription, 2);
            TextBoxDescription.ScrollBars = ScrollBars.Both;
            TextBoxDescription.Size = new Size(257, 183);
            TextBoxDescription.TabIndex = 0;
            TextBoxDescription.TabStop = false;
            TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text");
            // 
            // OKButton
            // 
            OKButton.Anchor = AnchorStyles.Right;
            OKButton.DialogResult = DialogResult.Cancel;
            OKButton.Location = new Point(318, 261);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 0;
            OKButton.Text = "&OK";
            // 
            // pbPaypal
            // 
            pbPaypal.BackColor = Color.Transparent;
            pbPaypal.Image = My.Resources.Resources.PayPalButton;
            pbPaypal.Location = new Point(3, 257);
            pbPaypal.Name = "pbPaypal";
            pbPaypal.Size = new Size(124, 32);
            pbPaypal.SizeMode = PictureBoxSizeMode.CenterImage;
            pbPaypal.TabIndex = 4;
            pbPaypal.TabStop = false;
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Image = (Image)resources.GetObject("LogoPictureBox.Image");
            LogoPictureBox.InitialImage = null;
            LogoPictureBox.Location = new Point(3, 3);
            LogoPictureBox.Name = "LogoPictureBox";
            TableLayoutPanel.SetRowSpan(LogoPictureBox, 5);
            LogoPictureBox.Size = new Size(124, 201);
            LogoPictureBox.TabIndex = 0;
            LogoPictureBox.TabStop = false;
            // 
            // pbPatreon
            // 
            pbPatreon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            pbPatreon.BackColor = Color.Transparent;
            pbPatreon.Image = My.Resources.Resources.Digital_Patreon_Wordmark_FieryCoral;
            pbPatreon.Location = new Point(3, 295);
            pbPatreon.Name = "pbPatreon";
            pbPatreon.Size = new Size(124, 32);
            pbPatreon.SizeMode = PictureBoxSizeMode.Zoom;
            pbPatreon.TabIndex = 5;
            pbPatreon.TabStop = false;
            // 
            // PictureBox1
            // 
            PictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            PictureBox1.BackColor = Color.Black;
            PictureBox1.Image = My.Resources.Resources.eve_partner1;
            PictureBox1.Location = new Point(133, 295);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(260, 32);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 6;
            PictureBox1.TabStop = false;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            CancelButton = OKButton;
            ClientSize = new Size(414, 348);
            Controls.Add(TableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            Padding = new Padding(9);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About EVE Isk per Hour";
            TableLayoutPanel.ResumeLayout(false);
            TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPaypal).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPatreon).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            Load += new EventHandler(frmAbout_Load);
            ResumeLayout(false);

        }

        internal PictureBox LogoPictureBox;
        internal PictureBox pbPaypal;
        internal PictureBox pbPatreon;
        internal PictureBox PictureBox1;
    }
}