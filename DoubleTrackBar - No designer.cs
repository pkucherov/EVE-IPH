using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{

    public class DoubleTrackBar : Control
    {

        public DoubleTrackBar()
        {
            DoubleBuffered = true;
            SetDefaults();
        }

        private void SetDefaults()
        {
            Orientation = Orientation.Horizontal;
            SmallChange = 1;
            Maximum = 10;
            Minimum = 0;
            ValueLeft = 0;
            ValueRight = 7;
        }

        #region  Private Fields 

        private System.Windows.Forms.VisualStyles.TrackBarThumbState leftThumbState;
        private System.Windows.Forms.VisualStyles.TrackBarThumbState rightThumbState;

        private bool draggingLeft, draggingRight;
        #endregion

        #region  Enums 

        public enum Thumbs
        {
            None = 0,
            Left = 1,
            Right = 2
        }

        #endregion

        #region  Properties 

        private Thumbs _SelectedThumb;
        /// <summary>
    /// Gets the thumb that had focus last.
    /// </summary>
    /// <returns>The thumb that had focus last.</returns>
        [Description("The thumb that had focus last.")]
        public Thumbs SelectedThumb
        {
            get
            {
                return _SelectedThumb;
            }
            private set
            {
                _SelectedThumb = value;
            }
        }

        private int _ValueLeft;
        /// <summary>
    /// Gets or sets the position of the left slider.
    /// </summary>
    /// <returns>The position of the left slider.</returns>
        [Description("The position of the left slider.")]
        public int ValueLeft
        {
            get
            {
                return _ValueLeft;
            }
            set
            {
                if (value < Minimum || value > Maximum)
                {
                    throw new ArgumentException(string.Format("Value of '{0}' is not valid for 'ValueLeft'. 'ValueLeft' should be between 'Minimum' and 'Maximum'.", value.ToString()), "ValueLeft");
                }
                if (value > ValueRight)
                {
                    throw new ArgumentException(string.Format("Value of '{0}' is not valid for 'ValueLeft'. 'ValueLeft' should be less than or equal to 'ValueRight'.", value.ToString()), "ValueLeft");
                }
                _ValueLeft = value;

                OnValueChanged(EventArgs.Empty);
                OnLeftValueChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        private int _ValueRight;
        /// <summary>
    /// Gets or sets the position of the right slider.
    /// </summary>
    /// <returns>The position of the right slider.</returns>
        [Description("The position of the right slider.")]
        public int ValueRight
        {
            get
            {
                return _ValueRight;
            }
            set
            {
                if (value < Minimum || value > Maximum)
                {
                    throw new ArgumentException(string.Format("Value of '{0}' is not valid for 'ValueRight'. 'ValueRight' should be between 'Minimum' and 'Maximum'.", value.ToString()), "ValueRight");
                }
                if (value < ValueLeft)
                {
                    throw new ArgumentException(string.Format("Value of '{0}' is not valid for 'ValueRight'. 'ValueRight' should be greater than or equal to 'ValueLeft'.", value.ToString()), "ValueLeft");
                }
                _ValueRight = value;

                OnValueChanged(EventArgs.Empty);
                OnRightValueChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        private int _Minimum;
        /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    /// <returns>The minimum value.</returns>
        [Description("The minimum value.")]
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value >= Maximum)
                {
                    throw new ArgumentException(string.Format("Value of '{0}' is not valid for 'Minimum'. 'Minimum' should be less than 'Maximum'.", value.ToString()), "Minimum");
                }
                _Minimum = value;
                Invalidate();
            }
        }

        private int _Maximum;
        /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    /// <returns>The maximum value.</returns>
        [Description("The maximum value.")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value <= Minimum)
                {
                    throw new ArgumentException(string.Format("Value of '{0}' is not valid for 'Maximum'. 'Maximum' should be greater than 'Minimum'.", value.ToString()), "Maximum");
                }
                _Maximum = value;
                Invalidate();
            }
        }

        private Orientation _Orientation;
        /// <summary>
    /// Gets or sets the orientation of the control.
    /// </summary>
    /// <returns>The orientation of the control.</returns>
        [Description("The orientation of the control.")]
        public Orientation Orientation
        {
            get
            {
                return _Orientation;
            }
            set
            {
                _Orientation = value;
            }
        }

        private int _SmallChange;
        /// <summary>
    /// Gets or sets the amount of positions the closest slider moves when the control is clicked.
    /// </summary>
    /// <returns>The amount of positions the closest slider moves when the control is clicked.</returns>
        [Description("The amount of positions the closest slider moves when the control is clicked.")]
        public int SmallChange
        {
            get
            {
                return _SmallChange;
            }
            set
            {
                _SmallChange = value;
            }
        }

        private double RelativeValueLeft
        {
            get
            {
                int diff = Maximum - Minimum;
                return diff == 0 ? ValueLeft : ValueLeft / (double)diff;
            }
        }

        private double RelativeValueRight
        {
            get
            {
                int diff = Maximum - Minimum;
                return diff == 0 ? ValueLeft : ValueRight / (double)diff;
            }
        }

        #endregion

        #region  Methods 

        public void IncrementLeft()
        {
            int newValue = Math.Min(ValueLeft + 1, Maximum);
            if (IsValidValueLeft(newValue))
            {
                ValueLeft = newValue;
            }
            Invalidate();
        }

        public void IncrementRight()
        {
            int newValue = Math.Min(ValueRight + 1, Maximum);
            if (IsValidValueRight(newValue))
            {
                ValueRight = newValue;
            }
            Invalidate();
        }

        public void DecrementLeft()
        {
            int newValue = Math.Max(ValueLeft - 1, Minimum);
            if (IsValidValueLeft(newValue))
            {
                ValueLeft = newValue;
            }
            Invalidate();
        }

        public void DecrementRight()
        {
            int newValue = Math.Max(ValueRight - 1, Minimum);
            if (IsValidValueRight(newValue))
            {
                ValueRight = newValue;
            }
            Invalidate();
        }

        private bool IsValidValueLeft(int value)
        {
            return value >= Minimum && value <= Maximum && value < ValueRight;
        }

        private bool IsValidValueRight(int value)
        {
            return value >= Minimum && value <= Maximum && value > ValueLeft;
        }

        private Rectangle GetLeftThumbRectangle(Graphics g = null)
        {
            bool shouldDispose = g is null;
            if (shouldDispose)
                g = CreateGraphics();

            var rect = GetThumbRectangle(RelativeValueLeft, g);
            if (shouldDispose)
                g.Dispose();

            return rect;
        }

        private Rectangle GetRightThumbRectangle(Graphics g = null)
        {
            bool shouldDispose = g is null;
            if (shouldDispose)
                g = CreateGraphics();

            var rect = GetThumbRectangle(RelativeValueRight, g);
            if (shouldDispose)
                g.Dispose();

            return rect;
        }

        private Rectangle GetThumbRectangle(double relativeValue, Graphics g)
        {
            var size = TrackBarRenderer.GetBottomPointingThumbSize(g, System.Windows.Forms.VisualStyles.TrackBarThumbState.Normal);
            int border = (int)Math.Round(size.Width / 2d);
            int w = GetTrackRectangle(border).Width;
            int x = (int)Math.Round(Math.Abs(Minimum) / (double)(Maximum - Minimum) * w + relativeValue * w);

            int y = (int)Math.Round((Height - size.Height) / 2d);
            return new Rectangle(new Point(x, y), size);
        }

        private Rectangle GetTrackRectangle(int border)
        {
            return new Rectangle(border, (int)Math.Round(Height / 2d) - 3, Width - 2 * border - 1, 4);
        }

        private Thumbs GetClosestSlider(Point point)
        {
            var leftThumbRect = GetLeftThumbRectangle();
            var rightThumbRect = GetRightThumbRectangle();
            if (Orientation == Orientation.Horizontal)
            {
                if (Math.Abs(leftThumbRect.X - point.X) > Math.Abs(rightThumbRect.X - point.X) && Math.Abs(leftThumbRect.Right - point.X) > Math.Abs(rightThumbRect.Right - point.X))
                {
                    return Thumbs.Right;
                }
                else
                {
                    return Thumbs.Left;
                }
            }
            else if (Math.Abs(leftThumbRect.Y - point.Y) > Math.Abs(rightThumbRect.Y - point.Y) && Math.Abs(leftThumbRect.Bottom - point.Y) > Math.Abs(rightThumbRect.Bottom - point.Y))
            {
                return Thumbs.Right;
            }
            else
            {
                return Thumbs.Left;
            }
        }

        private void SetThumbState(Point location, System.Windows.Forms.VisualStyles.TrackBarThumbState newState)
        {
            var leftThumbRect = GetLeftThumbRectangle();
            var rightThumbRect = GetRightThumbRectangle();

            if (leftThumbRect.Contains(location))
            {
                leftThumbState = newState;
            }
            else if (SelectedThumb == Thumbs.Left)
            {
                leftThumbState = System.Windows.Forms.VisualStyles.TrackBarThumbState.Hot;
            }
            else
            {
                leftThumbState = System.Windows.Forms.VisualStyles.TrackBarThumbState.Normal;
            }

            if (rightThumbRect.Contains(location))
            {
                rightThumbState = newState;
            }
            else if (SelectedThumb == Thumbs.Right)
            {
                rightThumbState = System.Windows.Forms.VisualStyles.TrackBarThumbState.Hot;
            }
            else
            {
                rightThumbState = System.Windows.Forms.VisualStyles.TrackBarThumbState.Normal;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            SetThumbState(e.Location, System.Windows.Forms.VisualStyles.TrackBarThumbState.Hot);

            int offset = (int)Math.Round(e.Location.X / (double)Width * (Maximum - Minimum));
            int newValue = Minimum + offset;
            if (draggingLeft)
            {
                if (IsValidValueLeft(newValue))
                    ValueLeft = newValue;
            }
            else if (draggingRight)
            {
                if (IsValidValueRight(newValue))
                    ValueRight = newValue;
            }

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            SetThumbState(e.Location, System.Windows.Forms.VisualStyles.TrackBarThumbState.Pressed);

            draggingLeft = leftThumbState == System.Windows.Forms.VisualStyles.TrackBarThumbState.Pressed;
            if (!draggingLeft)
                draggingRight = rightThumbState == System.Windows.Forms.VisualStyles.TrackBarThumbState.Pressed;

            if (draggingLeft)
            {
                SelectedThumb = Thumbs.Left;
            }
            else if (draggingRight)
            {
                SelectedThumb = Thumbs.Right;
            }

            if (!draggingLeft && !draggingRight)
            {
                if ((int)GetClosestSlider(e.Location) == 1)
                {
                    if (e.X < GetLeftThumbRectangle().X)
                    {
                        DecrementLeft();
                    }
                    else
                    {
                        IncrementLeft();
                    }
                    SelectedThumb = Thumbs.Left;
                }
                else
                {
                    if (e.X < GetRightThumbRectangle().X)
                    {
                        DecrementRight();
                    }
                    else
                    {
                        IncrementRight();
                    }
                    SelectedThumb = Thumbs.Right;
                }
            }

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            draggingLeft = false;
            draggingRight = false;
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta == 0)
                return;

            if ((int)SelectedThumb == 1)
            {
                if (e.Delta > 0)
                {
                    IncrementLeft();
                }
                else
                {
                    DecrementLeft();
                }
            }
            else if ((int)SelectedThumb == 2)
            {
                if (e.Delta > 0)
                {
                    IncrementRight();
                }
                else
                {
                    DecrementRight();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var thumbSize = GetThumbRectangle(0d, e.Graphics).Size;
            var trackRect = GetTrackRectangle((int)Math.Round(thumbSize.Width / 2d));
            var ticksRect = trackRect;
            ticksRect.Offset(0, 15);

            TrackBarRenderer.DrawVerticalTrack(e.Graphics, trackRect);
            TrackBarRenderer.DrawHorizontalTicks(e.Graphics, ticksRect, Maximum - Minimum + 1, System.Windows.Forms.VisualStyles.EdgeStyle.Etched);
            TrackBarRenderer.DrawBottomPointingThumb(e.Graphics, GetLeftThumbRectangle(e.Graphics), leftThumbState);
            TrackBarRenderer.DrawBottomPointingThumb(e.Graphics, GetRightThumbRectangle(e.Graphics), rightThumbState);
        }

        #endregion

        #region  Events 

        public event EventHandler ValueChanged;
        public event EventHandler LeftValueChanged;
        public event EventHandler RightValueChanged;

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        protected virtual void OnLeftValueChanged(EventArgs e)
        {
            LeftValueChanged?.Invoke(this, e);
        }

        protected virtual void OnRightValueChanged(EventArgs e)
        {
            RightValueChanged?.Invoke(this, e);
        }

        #endregion

    }
}