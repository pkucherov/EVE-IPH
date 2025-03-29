using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmPatchNotes
    {

        public frmPatchNotes()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmPatchNotes_Shown(object sender, EventArgs e)
        {
            string FilePath;
            string FileText = "";

            Refresh();

            // Download the patch notes from the server
            FilePath = Public_Variables.DownloadFileFromServer(Public_Variables.PatchNotesURL, Path.Combine(Public_Variables.DynamicFilePath, "Patch Notes.txt"));

            if (string.IsNullOrEmpty(FilePath))
            {
                return;
            }

            // Display in Text box
            FileText = File.ReadAllText(FilePath);

            // Strip off the beginning text 
            txtPatchNotes.Text = FileText.Substring(Strings.InStr(FileText, "Version") - 1);

            Application.UseWaitCursor = false;
            Application.DoEvents();

        }

    }
}