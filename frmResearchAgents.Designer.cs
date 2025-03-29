using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmResearchAgents : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResearchAgents));
            lstAgents = new ListView();
            lstAgents.ColumnClick += new ColumnClickEventHandler(lstAgents_ColumnClick);
            btnClose = new Button();
            btnClose.Click += new EventHandler(btnClose_Click);
            btnRefresh = new Button();
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            lblTotalDCValue = new Label();
            lblBPMarketCost1 = new Label();
            SuspendLayout();
            // 
            // lstAgents
            // 
            lstAgents.FullRowSelect = true;
            lstAgents.HideSelection = false;
            lstAgents.Location = new Point(10, 12);
            lstAgents.MultiSelect = false;
            lstAgents.Name = "lstAgents";
            lstAgents.Size = new Size(925, 131);
            lstAgents.TabIndex = 8;
            lstAgents.UseCompatibleStateImageBehavior = false;
            lstAgents.View = View.Details;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(488, 149);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(86, 28);
            btnClose.TabIndex = 33;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(370, 149);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(86, 28);
            btnRefresh.TabIndex = 34;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblTotalDCValue
            // 
            lblTotalDCValue.BorderStyle = BorderStyle.FixedSingle;
            lblTotalDCValue.Location = new Point(757, 155);
            lblTotalDCValue.Name = "lblTotalDCValue";
            lblTotalDCValue.Size = new Size(175, 17);
            lblTotalDCValue.TabIndex = 36;
            lblTotalDCValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBPMarketCost1
            // 
            lblBPMarketCost1.AutoSize = true;
            lblBPMarketCost1.Location = new Point(640, 157);
            lblBPMarketCost1.Name = "lblBPMarketCost1";
            lblBPMarketCost1.Size = new Size(111, 13);
            lblBPMarketCost1.TabIndex = 35;
            lblBPMarketCost1.Text = "Total Datacore Value:";
            // 
            // frmResearchAgents
            // 
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(944, 183);
            Controls.Add(lblTotalDCValue);
            Controls.Add(lblBPMarketCost1);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(lstAgents);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmResearchAgents";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Current Research Agents";
            Shown += new EventHandler(frmResearchAgents_Shown);
            ResumeLayout(false);
            PerformLayout();

        }
        internal ListView lstAgents;
        internal Button btnClose;
        internal Button btnRefresh;
        internal Label lblTotalDCValue;
        internal Label lblBPMarketCost1;
    }
}