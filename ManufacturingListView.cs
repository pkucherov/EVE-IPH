using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public partial class ManufacturingListView : ListView
    {

        public event ProcMsgEventHandler ProcMsg;

        public delegate void ProcMsgEventHandler(Message m);
        public const int WM_VSCROLL = 277;

        public List<RowFormat> RowFormats;

        public int ListIDtoFind;

        public ManufacturingListView()
        {

            InitializeComponent();

            // Double buffer cuts down on screen flicker
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            RowFormats = new List<RowFormat>();

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

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
            e.DrawDefault = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        // Sends in the formats to set each row
        public void SetRowFormats(List<RowFormat> SentFormats)
        {
            RowFormats = SentFormats;
        }

        // Predicate for finding an item in a list EVE Market Data of items
        private bool FindRowFormat(RowFormat Item)
        {
            if (Item.ListID == ListIDtoFind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            base.OnDrawSubItem(e);
            // Draw everything
            e.DrawDefault = false;

            var CellRectangle = new RectangleF();
            int ExtraWidth = 0;

            var Format = new StringFormat();

            Brush RowBackgroundColor;
            Brush RowTextColor;

            // Get the background info and set
            ListIDtoFind = Conversions.ToInteger(e.Item.Text);
            var CurrentRowFormat = RowFormats.Find(FindRowFormat);

            if (CurrentRowFormat.BackColor == null)
            {
                // Set to default
                CurrentRowFormat.BackColor = Brushes.White;
            }

            if (CurrentRowFormat.ForeColor == null)
            {
                // Set to default
                CurrentRowFormat.ForeColor = Brushes.Black;
            }

            // Highlight the row if selected
            if (e.Item.Selected)
            {
                RowBackgroundColor = Brushes.DodgerBlue;
                RowTextColor = Brushes.White;
            }
            else
            {
                // Use the set background color
                RowBackgroundColor = CurrentRowFormat.BackColor;
                // Set the text color
                RowTextColor = CurrentRowFormat.ForeColor;
            }

            // Set the allignment from the headers, which are drawn already and aligned
            switch (e.Header.TextAlign)
            {
                case HorizontalAlignment.Center:
                    {
                        Format.Alignment = StringAlignment.Center;
                        break;
                    }
                case HorizontalAlignment.Right:
                    {
                        Format.Alignment = StringAlignment.Far; // Right
                        break;
                    }

                default:
                    {
                        Format.Alignment = StringAlignment.Near; // Left
                        break;
                    }
            }

            // Paint the background first before images
            e.Graphics.FillRectangle(RowBackgroundColor, e.Bounds);

            // Figure out if this is the price trend 
            if ((e.Header.Text ?? "") == ProgramSettings.PriceTrendColumnName)
            {
                int imageindex = 0;

                double TrendValue = Conversion.Val(e.SubItem.Text.Replace("%", ""));

                if (TrendValue < 0d)
                {
                    imageindex = 8; // down
                }
                else if (TrendValue > 0d) // 
                {
                    imageindex = 7; // up
                }
                else // Don't show for 0%
                {
                    imageindex = 6;
                } // Blank box

                // Draw the image
                e.Graphics.DrawImage(e.Item.ImageList.Images[imageindex], e.SubItem.Bounds.Location);
                // Save the width
                ExtraWidth = e.Item.ImageList.Images[imageindex].Width;
            }

            else if ((e.Header.Text ?? "") == ProgramSettings.TechColumnName)
            {
                int imageindex = 0;

                string TechValue = e.SubItem.Text;

                if (TechValue == "T2")
                {
                    imageindex = 2;
                }
                else if (TechValue == "T3")
                {
                    imageindex = 3;
                }
                else if (TechValue == "Storyline")
                {
                    imageindex = 4;
                }
                else if (TechValue == "Pirate" | TechValue == "Navy")
                {
                    imageindex = 5;
                }
                else // Don't show for T1 but use blank for formatting
                {
                    imageindex = 6;
                }

                // Draw the image
                e.Graphics.DrawImage(e.Item.ImageList.Images[imageindex], e.SubItem.Bounds.Location);
                ExtraWidth = e.Item.ImageList.Images[imageindex].Width;
            }
            else
            {
                ExtraWidth = 0;
            }

            if (Format.Alignment == StringAlignment.Far)
            {
                CellRectangle.X = e.SubItem.Bounds.Location.X - ExtraWidth;
                CellRectangle.Width = e.SubItem.Bounds.Width + ExtraWidth;
            }
            else
            {
                CellRectangle.X = e.SubItem.Bounds.Location.X + ExtraWidth;
                CellRectangle.Width = e.SubItem.Bounds.Width - ExtraWidth;
            }

            CellRectangle.Y = e.SubItem.Bounds.Location.Y;
            CellRectangle.Height = e.SubItem.Bounds.Height - 2;
            Format.LineAlignment = StringAlignment.Center;

            // Draw the column data
            e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, RowTextColor, CellRectangle, Format);

        }

    }

    public struct RowFormat
    {
        public int ListID;

        public Brush BackColor;
        public Brush ForeColor;

    }
}