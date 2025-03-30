using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmMaterialListViewer : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialListViewer));
            lstMaterials = new MyListView();
            lstMaterials.ColumnClick += new ColumnClickEventHandler(lstMaterials_ColumnClick);
            Material = new ColumnHeader();
            Quantity = new ColumnHeader();
            TotalCost = new ColumnHeader();
            btnOK = new Button();
            btnOK.Click += new EventHandler(btnOK_Click);
            SuspendLayout();
            // 
            // lstMaterials
            // 
            lstMaterials.Columns.AddRange(new ColumnHeader[] { Material, Quantity, TotalCost });
            lstMaterials.FullRowSelect = true;
            lstMaterials.GridLines = true;
            lstMaterials.Location = new Point(11, 12);
            lstMaterials.MultiSelect = false;
            lstMaterials.Name = "lstMaterials";
            lstMaterials.Size = new Size(351, 231);
            lstMaterials.TabIndex = 42;
            lstMaterials.TabStop = false;
            lstMaterials.Tag = "20";
            lstMaterials.UseCompatibleStateImageBehavior = false;
            lstMaterials.View = View.Details;
            // 
            // Material
            // 
            Material.Text = "Material";
            Material.Width = 170;
            // 
            // Quantity
            // 
            Quantity.Text = "Quantity";
            Quantity.TextAlign = HorizontalAlignment.Right;
            // 
            // TotalCost
            // 
            TotalCost.Text = "Total Sell Cost";
            TotalCost.TextAlign = HorizontalAlignment.Right;
            TotalCost.Width = 100;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(138, 249);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(96, 30);
            btnOK.TabIndex = 41;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // frmMaterialListViewer
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(372, 287);
            Controls.Add(lstMaterials);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMaterialListViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Excess Materials List";
            ResumeLayout(false);

        }

        internal MyListView lstMaterials;
        internal Button btnOK;
        internal ColumnHeader Material;
        internal ColumnHeader Quantity;
        internal ColumnHeader TotalCost;
    }
}