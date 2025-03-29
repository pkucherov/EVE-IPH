using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{

    public partial class MyListView : ListView
    {

        public event ProcMsgEventHandler ProcMsg;

        public delegate void ProcMsgEventHandler(Message m);
        public const int WM_VSCROLL = 277;

        public MyListView()
        {

            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
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