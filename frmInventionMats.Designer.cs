using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmInventionMats : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventionMats));
            btnOK = new Button();
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCopyMats = new Button();
            btnCopyMats.Click += new EventHandler(btnCopyMats_Click);
            lstMats = new MyListView();
            gbExportOptions = new GroupBox();
            rbtnExportSSV = new RadioButton();
            rbtnExportCSV = new RadioButton();
            rbtnExportDefault = new RadioButton();
            rbtnExportSimple = new RadioButton();
            gbExportOptions.SuspendLayout();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(168, 193);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(96, 30);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCopyMats
            // 
            btnCopyMats.Location = new Point(301, 193);
            btnCopyMats.Name = "btnCopyMats";
            btnCopyMats.Size = new Size(96, 30);
            btnCopyMats.TabIndex = 2;
            btnCopyMats.Text = "Copy List";
            btnCopyMats.UseVisualStyleBackColor = true;
            // 
            // lstMats
            // 
            lstMats.FullRowSelect = true;
            lstMats.GridLines = true;
            lstMats.Location = new Point(12, 9);
            lstMats.Name = "lstMats";
            lstMats.Size = new Size(539, 130);
            lstMats.TabIndex = 40;
            lstMats.TabStop = false;
            lstMats.Tag = "20";
            lstMats.UseCompatibleStateImageBehavior = false;
            lstMats.View = View.Details;
            // 
            // gbExportOptions
            // 
            gbExportOptions.Controls.Add(rbtnExportSimple);
            gbExportOptions.Controls.Add(rbtnExportSSV);
            gbExportOptions.Controls.Add(rbtnExportCSV);
            gbExportOptions.Controls.Add(rbtnExportDefault);
            gbExportOptions.Location = new Point(155, 146);
            gbExportOptions.Name = "gbExportOptions";
            gbExportOptions.Size = new Size(254, 41);
            gbExportOptions.TabIndex = 75;
            gbExportOptions.TabStop = false;
            gbExportOptions.Text = "Export Data in:";
            // 
            // rbtnExportSSV
            // 
            rbtnExportSSV.AutoSize = true;
            rbtnExportSSV.Location = new Point(132, 17);
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
            rbtnExportCSV.Location = new Point(80, 17);
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
            rbtnExportDefault.Location = new Point(15, 17);
            rbtnExportDefault.Name = "rbtnExportDefault";
            rbtnExportDefault.Size = new Size(59, 17);
            rbtnExportDefault.TabIndex = 0;
            rbtnExportDefault.TabStop = true;
            rbtnExportDefault.Text = "Default";
            rbtnExportDefault.UseVisualStyleBackColor = true;
            // 
            // rbtnExportSimple
            // 
            rbtnExportSimple.AutoSize = true;
            rbtnExportSimple.Location = new Point(184, 17);
            rbtnExportSimple.Name = "rbtnExportSimple";
            rbtnExportSimple.Size = new Size(56, 17);
            rbtnExportSimple.TabIndex = 3;
            rbtnExportSimple.TabStop = true;
            rbtnExportSimple.Text = "Simple";
            rbtnExportSimple.UseVisualStyleBackColor = true;
            // 
            // frmInventionMats
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(564, 230);
            Controls.Add(gbExportOptions);
            Controls.Add(lstMats);
            Controls.Add(btnCopyMats);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInventionMats";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmInventionREMats";
            gbExportOptions.ResumeLayout(false);
            gbExportOptions.PerformLayout();
            FormClosing += new FormClosingEventHandler(frmInventionREMats_FormClosing);
            Shown += new EventHandler(frmInventionREMats_Shown);
            ResumeLayout(false);

        }
        internal Button btnOK;
        internal Button btnCopyMats;
        internal MyListView lstMats;
        internal GroupBox gbExportOptions;
        internal RadioButton rbtnExportSSV;
        internal RadioButton rbtnExportCSV;
        internal RadioButton rbtnExportDefault;
        internal RadioButton rbtnExportSimple;
    }
}