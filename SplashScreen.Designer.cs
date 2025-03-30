using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class SplashScreen : Form
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
        internal Label Version;
        internal Label Copyright;
        internal TableLayoutPanel MainLayoutPanel;
        internal TableLayoutPanel DetailsLayoutPanel;

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            MainLayoutPanel = new TableLayoutPanel();
            DetailsLayoutPanel = new TableLayoutPanel();
            Copyright = new Label();
            Version = new Label();
            ApplicationTitle = new Label();
            lblUpdate = new Label();
            MainLayoutPanel.SuspendLayout();
            DetailsLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            MainLayoutPanel.BackgroundImage = (Image)resources.GetObject("MainLayoutPanel.BackgroundImage");
            MainLayoutPanel.BackgroundImageLayout = ImageLayout.None;
            MainLayoutPanel.ColumnCount = 2;
            MainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.30137f));
            MainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.69863f));
            MainLayoutPanel.Controls.Add(DetailsLayoutPanel, 1, 2);
            MainLayoutPanel.Controls.Add(ApplicationTitle, 1, 0);
            MainLayoutPanel.Location = new Point(0, 12);
            MainLayoutPanel.Name = "MainLayoutPanel";
            MainLayoutPanel.RowCount = 1;
            MainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 56.46259f));
            MainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.031446f));
            MainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 38.77551f));
            MainLayoutPanel.Size = new Size(292, 147);
            MainLayoutPanel.TabIndex = 0;
            // 
            // DetailsLayoutPanel
            // 
            DetailsLayoutPanel.Anchor = AnchorStyles.None;
            DetailsLayoutPanel.BackColor = Color.Transparent;
            DetailsLayoutPanel.ColumnCount = 1;
            DetailsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 181.0f));
            DetailsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 142.0f));
            DetailsLayoutPanel.Controls.Add(Copyright, 0, 1);
            DetailsLayoutPanel.Controls.Add(Version, 0, 0);
            DetailsLayoutPanel.Location = new Point(108, 92);
            DetailsLayoutPanel.Name = "DetailsLayoutPanel";
            DetailsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.0f));
            DetailsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.0f));
            DetailsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20.0f));
            DetailsLayoutPanel.Size = new Size(181, 52);
            DetailsLayoutPanel.TabIndex = 1;
            // 
            // Copyright
            // 
            Copyright.Anchor = AnchorStyles.None;
            Copyright.BackColor = Color.Transparent;
            Copyright.Font = new Font("Microsoft Sans Serif", 8.0f);
            Copyright.Location = new Point(3, 32);
            Copyright.Name = "Copyright";
            Copyright.Size = new Size(175, 14);
            Copyright.TabIndex = 2;
            Copyright.Text = "Copyright";
            Copyright.TextAlign = ContentAlignment.TopCenter;
            // 
            // Version
            // 
            Version.Anchor = AnchorStyles.None;
            Version.BackColor = Color.Transparent;
            Version.Font = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Version.Location = new Point(9, 5);
            Version.Name = "Version";
            Version.Size = new Size(162, 16);
            Version.TabIndex = 1;
            Version.Text = "Version {0}.{1}";
            Version.TextAlign = ContentAlignment.TopCenter;
            // 
            // ApplicationTitle
            // 
            ApplicationTitle.Anchor = AnchorStyles.None;
            ApplicationTitle.BackColor = Color.Transparent;
            ApplicationTitle.Font = new Font("Microsoft Sans Serif", 18.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ApplicationTitle.Location = new Point(108, 0);
            ApplicationTitle.Name = "ApplicationTitle";
            ApplicationTitle.Size = new Size(181, 82);
            ApplicationTitle.TabIndex = 0;
            ApplicationTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblUpdate
            // 
            lblUpdate.Location = new Point(2, 138);
            lblUpdate.Name = "lblUpdate";
            lblUpdate.Size = new Size(289, 27);
            lblUpdate.TabIndex = 1;
            lblUpdate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(293, 174);
            ControlBox = false;
            Controls.Add(lblUpdate);
            Controls.Add(MainLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SplashScreen";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            MainLayoutPanel.ResumeLayout(false);
            DetailsLayoutPanel.ResumeLayout(false);
            Load += new EventHandler(SplashScreen_Load);
            ResumeLayout(false);

        }
        internal Label ApplicationTitle;
        internal Label lblUpdate;

    }
}