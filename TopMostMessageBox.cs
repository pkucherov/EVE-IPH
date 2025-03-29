using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    public sealed class TopMostMessageBox
    {

        public static DialogResult Show(string message)
        {
            return Show(message, string.Empty, MessageBoxButtons.OK, null);
        }

        public static DialogResult Show(string message, string title)
        {
            return Show(message, title, MessageBoxButtons.OK, null);
        }

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, Icon ProgramIcon)
        {
            // Create a host form that is a TopMost window which will be the 
            // parent of the MessageBox.

            var topmostForm = new Form();
            // We do not want anyone to see this window so position it off the 

            // visible screen and make it as small as possible
            topmostForm.Size = new Size(1, 1);
            topmostForm.StartPosition = FormStartPosition.Manual;
            if (!(ProgramIcon == null))
            {
                topmostForm.Icon = ProgramIcon;
            }

            var rect = SystemInformation.VirtualScreen;

            topmostForm.Location = new Point(rect.Bottom + 10, rect.Right + 10);
            topmostForm.Show();

            // Make this form the active form and make it TopMost
            topmostForm.Focus();
            topmostForm.BringToFront();
            topmostForm.TopMost = true;
            // Finally show the MessageBox with the form just created as its owner

            var result = MessageBox.Show(topmostForm, message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            topmostForm.Dispose();
            // clean it up all the way

            return result;
        }
    }
}