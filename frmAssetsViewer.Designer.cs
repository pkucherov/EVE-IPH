using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmAssetsViewer : Form
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssetsViewer));
            Timer1 = new Timer(components);
            ttMain = new ToolTip(components);
            chkRawMaterialPrices = new CheckBox();
            mainAssetViewer = new AssetViewer();
            SuspendLayout();
            // 
            // ttMain
            // 
            ttMain.IsBalloon = true;
            // 
            // chkRawMaterialPrices
            // 
            chkRawMaterialPrices.AutoSize = true;
            chkRawMaterialPrices.BackColor = Color.White;
            chkRawMaterialPrices.Location = new Point(6, 1);
            chkRawMaterialPrices.Name = "chkRawMaterialPrices";
            chkRawMaterialPrices.Size = new Size(93, 17);
            chkRawMaterialPrices.TabIndex = 18;
            chkRawMaterialPrices.Text = "Raw Materials";
            chkRawMaterialPrices.UseVisualStyleBackColor = false;
            // 
            // mainAssetViewer
            // 
            mainAssetViewer.Cursor = Cursors.Default;
            mainAssetViewer.Location = new Point(3, 2);
            mainAssetViewer.Name = "mainAssetViewer";
            mainAssetViewer.Size = new Size(637, 667);
            mainAssetViewer.TabIndex = 0;
            // 
            // frmAssetsViewer
            // 
            AutoScaleDimensions = new SizeF(96.0f, 96.0f);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(641, 671);
            Controls.Add(mainAssetViewer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAssetsViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Assets Viewer";
            Load += new EventHandler(frmAssetsViewerr_Load);
            ResumeLayout(false);

        }
        internal Timer Timer1;
        internal ToolTip ttMain;
        internal CheckBox chkRawMaterialPrices;
        internal AssetViewer mainAssetViewer;
    }
}