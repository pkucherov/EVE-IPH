using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmEditDefaultRates : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditDefaultRates));
            btnReset = new Button();
            btnReset.Click += new EventHandler(btnReset_Click);
            btnSave = new Button();
            btnSave.Click += new EventHandler(btnSave_Click);
            btnExit = new Button();
            btnExit.Click += new EventHandler(btnCancel_Click);
            lblBaseSalesTax = new Label();
            txtBaseSalesTax = new TextBox();
            txtBaseSalesTax.KeyPress += new KeyPressEventHandler(txtEntries_KeyPress);
            txtBaseSalesTax.LostFocus += new EventHandler(txtEntries_LostFocus);
            txtBaseBrokerFee = new TextBox();
            txtBaseBrokerFee.KeyPress += new KeyPressEventHandler(txtEntries_KeyPress);
            txtBaseBrokerFee.LostFocus += new EventHandler(txtEntries_LostFocus);
            lblBaseBrokerFee = new Label();
            txtSCCBrokerFeeSurcharge = new TextBox();
            txtSCCBrokerFeeSurcharge.KeyPress += new KeyPressEventHandler(txtEntries_KeyPress);
            txtSCCBrokerFeeSurcharge.LostFocus += new EventHandler(txtEntries_LostFocus);
            lblSCCBrokerFeeSurcharge = new Label();
            txtSCCIndustryFeeSurcharge = new TextBox();
            txtSCCIndustryFeeSurcharge.KeyPress += new KeyPressEventHandler(txtEntries_KeyPress);
            txtSCCIndustryFeeSurcharge.LostFocus += new EventHandler(txtEntries_LostFocus);
            lblSCCIndustryFeeSurcharge = new Label();
            gbIndustryandTaxRates = new GroupBox();
            txtAlphaAccountTaxRate = new TextBox();
            txtAlphaAccountTaxRate.KeyPress += new KeyPressEventHandler(txtEntries_KeyPress);
            txtAlphaAccountTaxRate.LostFocus += new EventHandler(txtEntries_LostFocus);
            lblAlphaAccountTaxRate = new Label();
            gbStructureRates = new GroupBox();
            txtDefaultStationTaxRate = new TextBox();
            txtDefaultStationTaxRate.KeyPress += new KeyPressEventHandler(txtEntries_KeyPress);
            txtDefaultStationTaxRate.LostFocus += new EventHandler(txtEntries_LostFocus);
            lblDefaultStationTaxRate = new Label();
            txtDefaultStructureTaxRate = new TextBox();
            txtDefaultStructureTaxRate.KeyPress += new KeyPressEventHandler(txtEntries_KeyPress);
            txtDefaultStructureTaxRate.LostFocus += new EventHandler(txtEntries_LostFocus);
            lblDefaultStructureTaxRate = new Label();
            gbIndustryandTaxRates.SuspendLayout();
            gbStructureRates.SuspendLayout();
            SuspendLayout();
            // 
            // btnReset
            // 
            btnReset.Location = new Point(119, 246);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(101, 30);
            btnReset.TabIndex = 33;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(14, 246);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 30);
            btnSave.TabIndex = 32;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(67, 282);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(101, 30);
            btnExit.TabIndex = 34;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // lblBaseSalesTax
            // 
            lblBaseSalesTax.Location = new Point(7, 20);
            lblBaseSalesTax.Name = "lblBaseSalesTax";
            lblBaseSalesTax.Size = new Size(144, 13);
            lblBaseSalesTax.TabIndex = 35;
            lblBaseSalesTax.Text = "Base Sales Tax:";
            lblBaseSalesTax.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtBaseSalesTax
            // 
            txtBaseSalesTax.Location = new Point(157, 17);
            txtBaseSalesTax.Name = "txtBaseSalesTax";
            txtBaseSalesTax.Size = new Size(51, 20);
            txtBaseSalesTax.TabIndex = 36;
            // 
            // txtBaseBrokerFee
            // 
            txtBaseBrokerFee.Location = new Point(157, 43);
            txtBaseBrokerFee.Name = "txtBaseBrokerFee";
            txtBaseBrokerFee.Size = new Size(51, 20);
            txtBaseBrokerFee.TabIndex = 38;
            // 
            // lblBaseBrokerFee
            // 
            lblBaseBrokerFee.Location = new Point(7, 46);
            lblBaseBrokerFee.Name = "lblBaseBrokerFee";
            lblBaseBrokerFee.Size = new Size(144, 13);
            lblBaseBrokerFee.TabIndex = 37;
            lblBaseBrokerFee.Text = "Base Broker Fee:";
            lblBaseBrokerFee.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSCCBrokerFeeSurcharge
            // 
            txtSCCBrokerFeeSurcharge.Location = new Point(157, 69);
            txtSCCBrokerFeeSurcharge.Name = "txtSCCBrokerFeeSurcharge";
            txtSCCBrokerFeeSurcharge.Size = new Size(51, 20);
            txtSCCBrokerFeeSurcharge.TabIndex = 40;
            // 
            // lblSCCBrokerFeeSurcharge
            // 
            lblSCCBrokerFeeSurcharge.Location = new Point(7, 72);
            lblSCCBrokerFeeSurcharge.Name = "lblSCCBrokerFeeSurcharge";
            lblSCCBrokerFeeSurcharge.Size = new Size(144, 13);
            lblSCCBrokerFeeSurcharge.TabIndex = 39;
            lblSCCBrokerFeeSurcharge.Text = "SCC Broker Fee Surcharge:";
            lblSCCBrokerFeeSurcharge.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSCCIndustryFeeSurcharge
            // 
            txtSCCIndustryFeeSurcharge.Location = new Point(157, 95);
            txtSCCIndustryFeeSurcharge.Name = "txtSCCIndustryFeeSurcharge";
            txtSCCIndustryFeeSurcharge.Size = new Size(51, 20);
            txtSCCIndustryFeeSurcharge.TabIndex = 42;
            // 
            // lblSCCIndustryFeeSurcharge
            // 
            lblSCCIndustryFeeSurcharge.Location = new Point(7, 98);
            lblSCCIndustryFeeSurcharge.Name = "lblSCCIndustryFeeSurcharge";
            lblSCCIndustryFeeSurcharge.Size = new Size(144, 13);
            lblSCCIndustryFeeSurcharge.TabIndex = 41;
            lblSCCIndustryFeeSurcharge.Text = "SCC Industry Fee Surcharge:";
            lblSCCIndustryFeeSurcharge.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbIndustryandTaxRates
            // 
            gbIndustryandTaxRates.Controls.Add(txtAlphaAccountTaxRate);
            gbIndustryandTaxRates.Controls.Add(lblAlphaAccountTaxRate);
            gbIndustryandTaxRates.Controls.Add(lblBaseSalesTax);
            gbIndustryandTaxRates.Controls.Add(txtSCCIndustryFeeSurcharge);
            gbIndustryandTaxRates.Controls.Add(txtBaseSalesTax);
            gbIndustryandTaxRates.Controls.Add(lblSCCIndustryFeeSurcharge);
            gbIndustryandTaxRates.Controls.Add(lblBaseBrokerFee);
            gbIndustryandTaxRates.Controls.Add(txtSCCBrokerFeeSurcharge);
            gbIndustryandTaxRates.Controls.Add(txtBaseBrokerFee);
            gbIndustryandTaxRates.Controls.Add(lblSCCBrokerFeeSurcharge);
            gbIndustryandTaxRates.Location = new Point(10, 6);
            gbIndustryandTaxRates.Name = "gbIndustryandTaxRates";
            gbIndustryandTaxRates.Size = new Size(214, 151);
            gbIndustryandTaxRates.TabIndex = 43;
            gbIndustryandTaxRates.TabStop = false;
            gbIndustryandTaxRates.Text = "Industry && Tax Rates";
            // 
            // txtAlphaAccountTaxRate
            // 
            txtAlphaAccountTaxRate.Location = new Point(157, 121);
            txtAlphaAccountTaxRate.Name = "txtAlphaAccountTaxRate";
            txtAlphaAccountTaxRate.Size = new Size(51, 20);
            txtAlphaAccountTaxRate.TabIndex = 44;
            // 
            // lblAlphaAccountTaxRate
            // 
            lblAlphaAccountTaxRate.Location = new Point(7, 124);
            lblAlphaAccountTaxRate.Name = "lblAlphaAccountTaxRate";
            lblAlphaAccountTaxRate.Size = new Size(144, 13);
            lblAlphaAccountTaxRate.TabIndex = 43;
            lblAlphaAccountTaxRate.Text = "Alpha Account Tax Rate:";
            lblAlphaAccountTaxRate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbStructureRates
            // 
            gbStructureRates.Controls.Add(txtDefaultStationTaxRate);
            gbStructureRates.Controls.Add(lblDefaultStationTaxRate);
            gbStructureRates.Controls.Add(txtDefaultStructureTaxRate);
            gbStructureRates.Controls.Add(lblDefaultStructureTaxRate);
            gbStructureRates.Location = new Point(10, 163);
            gbStructureRates.Name = "gbStructureRates";
            gbStructureRates.Size = new Size(214, 79);
            gbStructureRates.TabIndex = 44;
            gbStructureRates.TabStop = false;
            gbStructureRates.Text = "Structure Default Rates:";
            // 
            // txtDefaultStationTaxRate
            // 
            txtDefaultStationTaxRate.Location = new Point(157, 45);
            txtDefaultStationTaxRate.Name = "txtDefaultStationTaxRate";
            txtDefaultStationTaxRate.Size = new Size(51, 20);
            txtDefaultStationTaxRate.TabIndex = 44;
            // 
            // lblDefaultStationTaxRate
            // 
            lblDefaultStationTaxRate.Location = new Point(7, 48);
            lblDefaultStationTaxRate.Name = "lblDefaultStationTaxRate";
            lblDefaultStationTaxRate.Size = new Size(144, 13);
            lblDefaultStationTaxRate.TabIndex = 43;
            lblDefaultStationTaxRate.Text = "Default Station Tax Rate:";
            lblDefaultStationTaxRate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDefaultStructureTaxRate
            // 
            txtDefaultStructureTaxRate.Location = new Point(157, 19);
            txtDefaultStructureTaxRate.Name = "txtDefaultStructureTaxRate";
            txtDefaultStructureTaxRate.Size = new Size(51, 20);
            txtDefaultStructureTaxRate.TabIndex = 42;
            // 
            // lblDefaultStructureTaxRate
            // 
            lblDefaultStructureTaxRate.Location = new Point(7, 22);
            lblDefaultStructureTaxRate.Name = "lblDefaultStructureTaxRate";
            lblDefaultStructureTaxRate.Size = new Size(144, 13);
            lblDefaultStructureTaxRate.TabIndex = 41;
            lblDefaultStructureTaxRate.Text = "Default Structure Tax Rate:";
            lblDefaultStructureTaxRate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmEditDefaultRates
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 319);
            Controls.Add(gbStructureRates);
            Controls.Add(gbIndustryandTaxRates);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditDefaultRates";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Default Rates";
            gbIndustryandTaxRates.ResumeLayout(false);
            gbIndustryandTaxRates.PerformLayout();
            gbStructureRates.ResumeLayout(false);
            gbStructureRates.PerformLayout();
            Load += new EventHandler(frmEditDefaultRates_Load);
            ResumeLayout(false);

        }

        internal Button btnReset;
        internal Button btnSave;
        internal Button btnExit;
        internal Label lblBaseSalesTax;
        internal TextBox txtBaseSalesTax;
        internal TextBox txtBaseBrokerFee;
        internal Label lblBaseBrokerFee;
        internal TextBox txtSCCBrokerFeeSurcharge;
        internal Label lblSCCBrokerFeeSurcharge;
        internal TextBox txtSCCIndustryFeeSurcharge;
        internal Label lblSCCIndustryFeeSurcharge;
        internal GroupBox gbIndustryandTaxRates;
        internal TextBox txtAlphaAccountTaxRate;
        internal Label lblAlphaAccountTaxRate;
        internal GroupBox gbStructureRates;
        internal TextBox txtDefaultStationTaxRate;
        internal Label lblDefaultStationTaxRate;
        internal TextBox txtDefaultStructureTaxRate;
        internal Label lblDefaultStructureTaxRate;
    }
}