using System;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    public partial class frmCopyandPaste
    {

        private bool KeyHandled;
        private Public_Variables.CopyPasteWindowType SentWindowType;
        private Public_Variables.CopyPasteWindowLocation SentLocation;

        public frmCopyandPaste(Public_Variables.CopyPasteWindowType WindowType, Public_Variables.CopyPasteWindowLocation Location)
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            SentWindowType = WindowType;
            SentLocation = Location;

        }

        private void txtPaste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control == true) // Select All
            {
                txtPaste.SelectAll();
                KeyHandled = true;
            }
            else
            {
                KeyHandled = false;
            }

        }

        private void txtPaste_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Special handling - if select all is pressed for some reason the notification sound happens
            e.Handled = KeyHandled;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (SentWindowType == Public_Variables.CopyPasteWindowType.Materials)
            {
                if (SentLocation == Public_Variables.CopyPasteWindowLocation.Assets)
                {
                    Public_Variables.frmShop.CopyPasteMaterialText = txtPaste.Text;
                }
                else
                {
                    Public_Variables.CopyPasteRefineryMaterialText = txtPaste.Text;
                }
            }
            else if (SentWindowType == Public_Variables.CopyPasteWindowType.Blueprints)
            {
                // TODO
            }

            // Close the form
            Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtPaste_TextChanged(object sender, EventArgs e)
        {
            btnImport.Enabled = true;
        }
    }
}