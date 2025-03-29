using System;

namespace EVE_Isk_per_Hour
{

    public partial class frmError
    {

        private void btnOK_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public frmError()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

        }

        private void frmError_Shown(object sender, EventArgs e)
        {
            txtError.Text = Public_Variables.frmErrorText;
            Activate();
            TopMost = true;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Public_Variables.CopyTextToClipboard(txtError.Text);
        }
    }
}