using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmErrorLog
    {

        private string LogFilePath;

        public frmErrorLog()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            LogFilePath = Path.Combine(Public_Variables.DynamicFilePath, "EVEIPH.log");

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmPatchNotes_Shown(object sender, EventArgs e)
        {

            Refresh();
            Application.DoEvents();

            if (File.Exists(LogFilePath))
            {
                Application.UseWaitCursor = true;

                // Load the text
                txtLog.Text = File.ReadAllText(LogFilePath);

                Application.UseWaitCursor = false;
                Application.DoEvents();
            }
            else
            {
                Interaction.MsgBox("Unable to locate an EVEIPH.log file", Constants.vbInformation, Application.ProductName);
            }

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            // Just delete the file and clear the screen
            File.Delete(LogFilePath);
            txtLog.Text = "";
            Interaction.MsgBox("The EVEIPH Error Log has been reset.", Constants.vbInformation, Application.ProductName);

        }

        private void btnCopyLog_Click(object sender, EventArgs e)
        {
            Public_Variables.CopyTextToClipboard(txtLog.Text);
        }

    }
}