using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{


    public partial class MyDomainUpDown : DomainUpDown
    {

        public event ProcMsgEventHandler ProcMsg;

        public delegate void ProcMsgEventHandler(Message m);
        public const int WM_VSCROLL = 277;

        public MyDomainUpDown()
        {

            // Remove the up down arrow
            Controls[0].Visible = false;

            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(SystemColors.Window); // clear the color
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_VSCROLL:
                    {
                        ProcMsg?.Invoke(m);
                        break;
                    }
            }
            base.WndProc(ref m);
            DoubleBuffered = true;
        }

    }
}