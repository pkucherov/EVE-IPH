using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    public sealed partial class frmAbout
    {

        public frmAbout()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            // Set the title of the form.
            string ApplicationTitle;
            if (!string.IsNullOrEmpty(My.MyProject.Application.Info.Title))
            {
                ApplicationTitle = My.MyProject.Application.Info.Title;
            }
            else
            {
                ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.MyProject.Application.Info.AssemblyName);
            }
            Text = string.Format("About {0}", ApplicationTitle);
            // Initialize all of the text displayed on the About Box.
            // TODO: Customize the application's assembly information in the "Application" pane of the project 
            // properties dialog (under the "Project" menu).
            LabelProductName.Text = My.MyProject.Application.Info.ProductName;
            LabelVersion.Text = string.Format("Version {0}", My.MyProject.Application.Info.Version.ToString());
            LabelCopyright.Text = My.MyProject.Application.Info.Copyright;
            LabelCompanyName.Text = "Created by: Zifrian";
            TextBoxDescription.Text = My.MyProject.Application.Info.Description;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbPaypal_Click(object sender, EventArgs e)
        {
            // Take them to the donation page
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=HSZKRQYTX5HR6&source=url");
        }

        private void pbPaypal_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pbPaypal_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pbPatreon_Click(object sender, EventArgs e)
        {
            // Take them to the donation page
            Process.Start("https://www.patreon.com/user?u=51064427&fan_landing=true");
        }

        private void pbPatreon_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pbPatreon_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}