using System;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{

    public partial class frmAssetsViewer
    {

        public frmAssetsViewer(AssetWindow AssetType)
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

            // Init control and go from there
            mainAssetViewer.InitializeControl(AssetType, Public_Variables.SelectedCharacter);

        }

        private void frmAssetsViewerr_Load(object Sender, EventArgs e)
        {
            Show();
            Application.DoEvents();
            mainAssetViewer.RefreshTree();
        }
    }
}