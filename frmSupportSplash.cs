using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    public sealed partial class frmsupportSplash
    {
        public frmsupportSplash()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pbPaypal_Click(object sender, EventArgs e)
        {
            // Take them to the donation page
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=HSZKRQYTX5HR6&source=url");
        }

        private void pbPaetron_Click(object sender, EventArgs e)
        {
            // Take them to the donation page
            Process.Start("https://www.patreon.com/user?u=51064427&fan_landing=true");
        }

        private void pbPaetron_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pbPaetron_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pbPaypal_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pbPaypal_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}