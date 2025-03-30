using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmESIStatus : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmESIStatus));
            lstStatus = new MyListView();
            colScope = new ColumnHeader();
            colPurpose = new ColumnHeader();
            colStatus = new ColumnHeader();
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnRefresh = new Button();
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            SuspendLayout();
            // 
            // lstStatus
            // 
            lstStatus.Columns.AddRange(new ColumnHeader[] { colScope, colPurpose, colStatus });
            lstStatus.FullRowSelect = true;
            lstStatus.GridLines = true;
            lstStatus.HideSelection = false;
            lstStatus.Location = new Point(16, 12);
            lstStatus.MultiSelect = false;
            lstStatus.Name = "lstStatus";
            lstStatus.Size = new Size(536, 402);
            lstStatus.TabIndex = 36;
            lstStatus.TabStop = false;
            lstStatus.UseCompatibleStateImageBehavior = false;
            lstStatus.View = View.Details;
            // 
            // colScope
            // 
            colScope.Text = "Scope";
            colScope.Width = 205;
            // 
            // colPurpose
            // 
            colPurpose.Text = "Purpose";
            colPurpose.Width = 250;
            // 
            // colStatus
            // 
            colStatus.Text = "Status";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(285, 420);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(82, 30);
            btnClose.TabIndex = 37;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(197, 420);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(82, 30);
            btnRefresh.TabIndex = 38;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // frmESIStatus
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 457);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(lstStatus);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmESIStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ESI Status Viewer";
            Shown += new EventHandler(frmESIStatus_Shown);
            ResumeLayout(false);

        }

        internal MyListView lstStatus;
        internal Button btnClose;
        internal Button btnRefresh;
        internal ColumnHeader colScope;
        internal ColumnHeader colPurpose;
        internal ColumnHeader colStatus;
    }
}