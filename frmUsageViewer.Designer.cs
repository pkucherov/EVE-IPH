using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmUsageViewer : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsageViewer));
            btnOK = new Button();
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCopyMats = new Button();
            btnCopyMats.Click += new EventHandler(btnCopyMats_Click);
            lstCosts = new MyListView();
            gbExportOptions = new GroupBox();
            rbtnExportSSV = new RadioButton();
            rbtnExportCSV = new RadioButton();
            rbtnExportDefault = new RadioButton();
            gbExportOptions.SuspendLayout();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(47, 192);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(96, 30);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCopyMats
            // 
            btnCopyMats.Location = new Point(180, 192);
            btnCopyMats.Name = "btnCopyMats";
            btnCopyMats.Size = new Size(96, 30);
            btnCopyMats.TabIndex = 2;
            btnCopyMats.Text = "Copy List";
            btnCopyMats.UseVisualStyleBackColor = true;
            // 
            // lstCosts
            // 
            lstCosts.FullRowSelect = true;
            lstCosts.GridLines = true;
            lstCosts.Location = new Point(11, 9);
            lstCosts.MultiSelect = false;
            lstCosts.Name = "lstCosts";
            lstCosts.Size = new Size(305, 130);
            lstCosts.TabIndex = 40;
            lstCosts.TabStop = false;
            lstCosts.Tag = "20";
            lstCosts.UseCompatibleStateImageBehavior = false;
            lstCosts.View = View.Details;
            // 
            // gbExportOptions
            // 
            gbExportOptions.Controls.Add(rbtnExportSSV);
            gbExportOptions.Controls.Add(rbtnExportCSV);
            gbExportOptions.Controls.Add(rbtnExportDefault);
            gbExportOptions.Location = new Point(72, 145);
            gbExportOptions.Name = "gbExportOptions";
            gbExportOptions.Size = new Size(178, 41);
            gbExportOptions.TabIndex = 75;
            gbExportOptions.TabStop = false;
            gbExportOptions.Text = "Export Data in:";
            // 
            // rbtnExportSSV
            // 
            rbtnExportSSV.AutoSize = true;
            rbtnExportSSV.Location = new Point(125, 17);
            rbtnExportSSV.Name = "rbtnExportSSV";
            rbtnExportSSV.Size = new Size(46, 17);
            rbtnExportSSV.TabIndex = 2;
            rbtnExportSSV.TabStop = true;
            rbtnExportSSV.Text = "SSV";
            rbtnExportSSV.UseVisualStyleBackColor = true;
            // 
            // rbtnExportCSV
            // 
            rbtnExportCSV.AutoSize = true;
            rbtnExportCSV.Location = new Point(73, 17);
            rbtnExportCSV.Name = "rbtnExportCSV";
            rbtnExportCSV.Size = new Size(46, 17);
            rbtnExportCSV.TabIndex = 1;
            rbtnExportCSV.TabStop = true;
            rbtnExportCSV.Text = "CSV";
            rbtnExportCSV.UseVisualStyleBackColor = true;
            // 
            // rbtnExportDefault
            // 
            rbtnExportDefault.AutoSize = true;
            rbtnExportDefault.Location = new Point(8, 17);
            rbtnExportDefault.Name = "rbtnExportDefault";
            rbtnExportDefault.Size = new Size(59, 17);
            rbtnExportDefault.TabIndex = 0;
            rbtnExportDefault.TabStop = true;
            rbtnExportDefault.Text = "Default";
            rbtnExportDefault.UseVisualStyleBackColor = true;
            // 
            // frmUsageViewer
            // 
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(323, 230);
            Controls.Add(gbExportOptions);
            Controls.Add(lstCosts);
            Controls.Add(btnCopyMats);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUsageViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usage Viewer";
            gbExportOptions.ResumeLayout(false);
            gbExportOptions.PerformLayout();
            FormClosing += new FormClosingEventHandler(frmCostSplitViewer_FormClosing);
            Shown += new EventHandler(frmCostSplitViewer_Shown);
            ResumeLayout(false);

        }
        internal Button btnOK;
        internal Button btnCopyMats;
        internal MyListView lstCosts;
        internal GroupBox gbExportOptions;
        internal RadioButton rbtnExportSSV;
        internal RadioButton rbtnExportCSV;
        internal RadioButton rbtnExportDefault;
    }
}