using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    
    public partial class frmSelectManufacturingTabColumns : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectManufacturingTabColumns));
            btnCancel = new Button();
            btnCancel.Click += new EventHandler(btnClose_Click);
            btnSaveSettings = new Button();
            btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            lblInstruction = new Label();
            lblTip = new Label();
            chkLstBoxColumns = new CheckedListBox();
            chkLstBoxColumns.SelectedIndexChanged += new EventHandler(chkLstBoxColumns_SelectedIndexChanged);
            btnDefaults = new Button();
            btnDefaults.Click += new EventHandler(btnDefaults_Click);
            btnToggleAll = new Button();
            btnToggleAll.Click += new EventHandler(btnToggleAll_Click);
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(160, 535);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(97, 25);
            btnCancel.TabIndex = 67;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(41, 535);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(97, 25);
            btnSaveSettings.TabIndex = 69;
            btnSaveSettings.Text = "Save";
            btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // lblInstruction
            // 
            lblInstruction.Location = new Point(12, 9);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(273, 19);
            lblInstruction.TabIndex = 70;
            lblInstruction.Text = "Select the Columns you want to view:";
            // 
            // lblTip
            // 
            lblTip.Location = new Point(18, 473);
            lblTip.Name = "lblTip";
            lblTip.Size = new Size(260, 30);
            lblTip.TabIndex = 71;
            lblTip.Text = "Change the order of the columns by dragging them to desired location on the Manuf" + "acturing Tab list.";
            lblTip.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkLstBoxColumns
            // 
            chkLstBoxColumns.FormattingEnabled = true;
            chkLstBoxColumns.Items.AddRange(new object[] { "Item Category", "Item Group", "Item Name", "Owned", "Tech", "ME", "TE", "Inputs", "Compared", "Total Runs", "Single Invented BPC Runs", "Production Lines", "Laboratory Lines", "Total Invention Cost", "Total Copy Cost", "Taxes", "Broker Fees", "BP Production Time", "Total Production Time", "Copy Time", "Invention Time", "Item Market Price", "Profit", "Profit Percentage", "Isk per Hour", "SVR", "SVR * IPH", "Price Trend", "Total Items Sold", "Total Orders Filled", "Average Items Per Order", "Current Sell Orders", "Current Buy Orders", "Items in Production", "Items in Stock", "Material Cost", "Total Cost", "Base Job Cost", "Num BPs", "Invention Chance", "BP Type", "Race", "Volume per Item", "Total Volume", "Sell Excess Amount", "Return on Investment", "Portion Size", "Manufacturing Job Fee", "Manufacturing Facility Name", "Manufacturing Facility System", "Manufacturing Facility Region", "Manufacturing Facility System Index", "Manufacturing Facility Tax", "Manufacturing Facility ME Bonus", "Manufacturing Facility TE Bonus", "Manufacturing Facility Usage", "Manufacturing Facility FW System Level", "Component Facility Name", "Component Facility System", "Component Facility Region", "Component Facility System Index", "Component Facility Tax", "Component Facility ME Bonus", "Component Facility TE Bonus", "Component Facility Usage", "Component Facility FW System Level", "Capital Component Facility Name", "Capital Component Facility System", "Capital Component Facility Region", "Capital Component Facility SystemIndex", "Capital Component Facility Tax", "Capital Component Facility ME Bonus", "Capital Component Facility TE Bonus", "Capital Component Facility Usage", "Capital Component Facility FW System Level", "Copying Facility Name", "Copying Facility System", "Copying Facility Region", "Copying Facility System Index", "Copying Facility Tax", "Copying Facility ME Bonus", "Copying Facility TE Bonus", "Copying Facility Usage", "Copying Facility FW System Level", "Invention Facility Name", "Invention Facility System", "Invention Facility Region", "Invention Facility SystemIndex", "Invention Facility Tax", "Invention Facility ME Bonus", "Invention Facility TE Bonus", "Invention Facility Usage", "Invention Facility FW System Level", "Reaction Facility Name", "Reaction Facility System", "Reaction Facility Region", "Reaction Facility SystemIndex", "Reaction Facility Tax", "Reaction Facility ME Bonus", "Reaction Facility TE Bonus", "Reaction Facility Usage", "Reaction Facility FW System Level", "Reprocessing Facility Name", "Reprocessing Facility System", "Reprocessing Facility Region", "Reprocessing Facility Tax", "Reprocessing Facility Usage", "Reprocessing Facility Ore Efficiency Rate", "Reprocessing Facility Ice Efficiency Rate", "Reprocessing Facility Moon Efficiency Rate" });
            chkLstBoxColumns.Location = new Point(15, 31);
            chkLstBoxColumns.Name = "chkLstBoxColumns";
            chkLstBoxColumns.Size = new Size(273, 439);
            chkLstBoxColumns.TabIndex = 72;
            // 
            // btnDefaults
            // 
            btnDefaults.Location = new Point(41, 504);
            btnDefaults.Name = "btnDefaults";
            btnDefaults.Size = new Size(97, 25);
            btnDefaults.TabIndex = 73;
            btnDefaults.Text = "Reset to Default";
            btnDefaults.UseVisualStyleBackColor = true;
            // 
            // btnToggleAll
            // 
            btnToggleAll.Location = new Point(160, 504);
            btnToggleAll.Name = "btnToggleAll";
            btnToggleAll.Size = new Size(97, 25);
            btnToggleAll.TabIndex = 74;
            btnToggleAll.Text = "Toggle All";
            btnToggleAll.UseVisualStyleBackColor = true;
            // 
            // frmSelectManufacturingTabColumns
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(297, 572);
            Controls.Add(btnToggleAll);
            Controls.Add(btnDefaults);
            Controls.Add(chkLstBoxColumns);
            Controls.Add(lblTip);
            Controls.Add(lblInstruction);
            Controls.Add(btnSaveSettings);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectManufacturingTabColumns";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Columns";
            Shown += new EventHandler(frmSelectIndustryJobColumns_Shown);
            ResumeLayout(false);

        }
        internal Button btnCancel;
        internal Button btnSaveSettings;
        internal Label lblInstruction;
        internal Label lblTip;
        internal CheckedListBox chkLstBoxColumns;
        internal Button btnDefaults;
        internal Button btnToggleAll;
    }
}