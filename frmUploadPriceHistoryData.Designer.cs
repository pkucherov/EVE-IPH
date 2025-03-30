using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmUploadPriceHistoryData : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadPriceHistoryData));
            txtPaste = new TextBox();
            txtPaste.KeyDown += new KeyEventHandler(txtPaste_KeyDown);
            txtPaste.KeyPress += new KeyPressEventHandler(txtPaste_KeyPress);
            txtPaste.TextChanged += new EventHandler(txtPaste_TextChanged);
            btnExit = new Button();
            btnExit.Click += new EventHandler(btnExit_Click);
            btnImport = new Button();
            btnImport.Click += new EventHandler(btnImport_Click);
            lblItemsSplitPrices = new Label();
            cmbItems = new ComboBox();
            cmbItems.DropDown += new EventHandler(cmbItems_DropDown);
            cmbItems.SelectedIndexChanged += new EventHandler(cmbItems_SelectedIndexChanged);
            Label1 = new Label();
            cmbItemGroup = new ComboBox();
            cmbItemGroup.DropDown += new EventHandler(cmbItemGroup_DropDown);
            cmbItemGroup.SelectedIndexChanged += new EventHandler(cmbItemGroup_SelectedIndexChanged);
            cmbItemGroup.DropDownClosed += new EventHandler(cmbItemGroup_DropDownClosed);
            cmbItemGroup.LostFocus += new EventHandler(cmbItemGroup_LostFocus);
            Label2 = new Label();
            cmbRegions = new ComboBox();
            cmbRegions.DropDown += new EventHandler(cmbRegions_DropDown);
            cmbRegions.LostFocus += new EventHandler(cmbRegions_LostFocus);
            cmbRegions.DropDownClosed += new EventHandler(cmbRegions_DropDownClosed);
            btnClear = new Button();
            btnClear.Click += new EventHandler(btnClear_Click);
            SuspendLayout();
            // 
            // txtPaste
            // 
            txtPaste.Location = new Point(4, 94);
            txtPaste.Multiline = true;
            txtPaste.Name = "txtPaste";
            txtPaste.ScrollBars = ScrollBars.Vertical;
            txtPaste.Size = new Size(749, 607);
            txtPaste.TabIndex = 2;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(666, 64);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(84, 24);
            btnExit.TabIndex = 4;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(486, 64);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(84, 24);
            btnImport.TabIndex = 3;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            // 
            // lblItemsSplitPrices
            // 
            lblItemsSplitPrices.AutoSize = true;
            lblItemsSplitPrices.Location = new Point(12, 51);
            lblItemsSplitPrices.Name = "lblItemsSplitPrices";
            lblItemsSplitPrices.Size = new Size(136, 13);
            lblItemsSplitPrices.TabIndex = 7;
            lblItemsSplitPrices.Text = "Select Item for Data Import:";
            // 
            // cmbItems
            // 
            cmbItems.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItems.FormattingEnabled = true;
            cmbItems.Location = new Point(15, 66);
            cmbItems.Name = "cmbItems";
            cmbItems.Size = new Size(465, 21);
            cmbItems.TabIndex = 8;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(12, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(95, 13);
            Label1.TabIndex = 9;
            Label1.Text = "Select Item Group:";
            // 
            // cmbItemGroup
            // 
            cmbItemGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItemGroup.FormattingEnabled = true;
            cmbItemGroup.Location = new Point(15, 25);
            cmbItemGroup.Name = "cmbItemGroup";
            cmbItemGroup.Size = new Size(337, 21);
            cmbItemGroup.TabIndex = 10;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(361, 9);
            Label2.Name = "Label2";
            Label2.Size = new Size(77, 13);
            Label2.TabIndex = 11;
            Label2.Text = "Select Region:";
            // 
            // cmbRegions
            // 
            cmbRegions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRegions.FormattingEnabled = true;
            cmbRegions.Location = new Point(364, 25);
            cmbRegions.Name = "cmbRegions";
            cmbRegions.Size = new Size(386, 21);
            cmbRegions.TabIndex = 125;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(576, 64);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(84, 24);
            btnClear.TabIndex = 126;
            btnClear.Text = "Clear Data";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // frmUploadPriceHistoryData
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 713);
            Controls.Add(btnClear);
            Controls.Add(cmbRegions);
            Controls.Add(Label2);
            Controls.Add(cmbItemGroup);
            Controls.Add(Label1);
            Controls.Add(cmbItems);
            Controls.Add(lblItemsSplitPrices);
            Controls.Add(btnExit);
            Controls.Add(btnImport);
            Controls.Add(txtPaste);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmUploadPriceHistoryData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Upload Price History Data";
            ResumeLayout(false);
            PerformLayout();

        }

        internal TextBox txtPaste;
        internal Button btnExit;
        internal Button btnImport;
        internal Label lblItemsSplitPrices;
        internal ComboBox cmbItems;
        internal Label Label1;
        internal ComboBox cmbItemGroup;
        internal Label Label2;
        internal ComboBox cmbRegions;
        internal Button btnClear;
    }
}