using System;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{

    public sealed partial class SplashScreen
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

            // Application title
            ApplicationTitle.Text = "EVE" + Environment.NewLine + "Isk per Hour";
            Version.Text = string.Format(Version.Text, My.MyProject.Application.Info.Version.Major, My.MyProject.Application.Info.Version.Minor);
            Copyright.Text = "";

        }

        // For updating the progress
        public void SetProgress(string progress)
        {
            lblUpdate.Text = progress;
            Application.DoEvents();
        }

    }
}