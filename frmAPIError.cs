using System;

namespace EVE_Isk_per_Hour
{
    public partial class frmAPIError
    {


        public string ErrorText;
        public string ErrorLink;


        public frmAPIError()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmAPIError_Shown(object sender, EventArgs e)
        {
            lblMain.Text = ErrorText;
        }
    }
}