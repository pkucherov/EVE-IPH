using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmViewSavedStructures : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewSavedStructures));
            btnExit = new Button();
            btnExit.Click += new EventHandler(btnExit_Click);
            btnRemove = new Button();
            btnRemove.Click += new EventHandler(btnRemove_Click);
            lstStructures = new MyListView();
            check = new ColumnHeader();
            chID = new ColumnHeader();
            chStructureName = new ColumnHeader();
            chSystem = new ColumnHeader();
            chRegion = new ColumnHeader();
            chStatus = new ColumnHeader();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(345, 338);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 25);
            btnExit.TabIndex = 101;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(239, 338);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(100, 25);
            btnRemove.TabIndex = 102;
            btnRemove.Text = "Remove Selected";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // lstStructures
            // 
            lstStructures.CheckBoxes = true;
            lstStructures.Columns.AddRange(new ColumnHeader[] { check, chID, chStructureName, chSystem, chRegion, chStatus });
            lstStructures.FullRowSelect = true;
            lstStructures.GridLines = true;
            lstStructures.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstStructures.HideSelection = false;
            lstStructures.Location = new Point(12, 12);
            lstStructures.MultiSelect = false;
            lstStructures.Name = "lstStructures";
            lstStructures.Size = new Size(660, 318);
            lstStructures.TabIndex = 1;
            lstStructures.UseCompatibleStateImageBehavior = false;
            lstStructures.View = View.Details;
            // 
            // check
            // 
            check.Text = "";
            check.Width = 13;
            // 
            // chID
            // 
            chID.Text = "ID";
            // 
            // chStructureName
            // 
            chStructureName.Text = "Structure Name";
            chStructureName.Width = 177;
            // 
            // chSystem
            // 
            chSystem.Text = "System";
            // 
            // chRegion
            // 
            chRegion.Text = "Region";
            // 
            // chStatus
            // 
            chStatus.Text = "Status";
            chStatus.Width = 115;
            // 
            // frmViewSavedStructures
            // 
            ClientSize = new Size(684, 375);
            Controls.Add(btnRemove);
            Controls.Add(btnExit);
            Controls.Add(lstStructures);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmViewSavedStructures";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Saved Structures";
            Shown += new EventHandler(frmViewSavedStructures_Shown);
            ResumeLayout(false);

        }

        internal MyListView lstStructures;
        internal Button btnExit;
        internal ColumnHeader chID;
        internal ColumnHeader chStructureName;
        internal ColumnHeader chSystem;
        internal ColumnHeader chRegion;
        internal Button btnRemove;
        internal ColumnHeader chStatus;
        internal ColumnHeader check;
    }
}