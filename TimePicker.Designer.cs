using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Isk_per_Hour
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class TimePicker : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            lblDays = new Label();
            lblHourMinColon = new Label();
            lblMinSecColon = new Label();
            Seconds = new MyDomainUpDown();
            Seconds.SelectedItemChanged += new EventHandler(Seconds_SelectedItemChanged);
            Seconds.KeyDown += new KeyEventHandler(Seconds_KeyDown);
            Minutes = new MyDomainUpDown();
            Minutes.SelectedItemChanged += new EventHandler(Minutes_SelectedItemChanged);
            Minutes.KeyDown += new KeyEventHandler(Minutes_KeyDown);
            Hours = new MyDomainUpDown();
            Hours.SelectedItemChanged += new EventHandler(Hours_SelectedItemChanged);
            Hours.KeyDown += new KeyEventHandler(Hours_KeyDown);
            Days = new MyDomainUpDown();
            Days.SelectedItemChanged += new EventHandler(Days_SelectedItemChanged);
            Days.KeyDown += new KeyEventHandler(Days_KeyDown);
            SuspendLayout();
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.BackColor = SystemColors.Window;
            lblDays.Location = new Point(18, 3);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(31, 13);
            lblDays.TabIndex = 77;
            lblDays.Text = "Days";
            // 
            // lblHourMinColon
            // 
            lblHourMinColon.AutoSize = true;
            lblHourMinColon.BackColor = SystemColors.Window;
            lblHourMinColon.Location = new Point(60, 2);
            lblHourMinColon.Name = "lblHourMinColon";
            lblHourMinColon.Size = new Size(10, 13);
            lblHourMinColon.TabIndex = 80;
            lblHourMinColon.Text = ":";
            // 
            // lblMinSecColon
            // 
            lblMinSecColon.AutoSize = true;
            lblMinSecColon.BackColor = SystemColors.Window;
            lblMinSecColon.Location = new Point(82, 2);
            lblMinSecColon.Name = "lblMinSecColon";
            lblMinSecColon.Size = new Size(10, 13);
            lblMinSecColon.TabIndex = 83;
            lblMinSecColon.Text = ":";
            // 
            // Seconds
            // 
            Seconds.BorderStyle = BorderStyle.None;
            Seconds.Location = new Point(92, 3);
            Seconds.Name = "Seconds";
            Seconds.Size = new Size(30, 16);
            Seconds.TabIndex = 86;
            Seconds.Text = "00";
            // 
            // Minutes
            // 
            Minutes.BorderStyle = BorderStyle.None;
            Minutes.Location = new Point(70, 3);
            Minutes.Name = "Minutes";
            Minutes.Size = new Size(30, 16);
            Minutes.TabIndex = 84;
            Minutes.Text = "00";
            // 
            // Hours
            // 
            Hours.BorderStyle = BorderStyle.None;
            Hours.Location = new Point(48, 3);
            Hours.Name = "Hours";
            Hours.Size = new Size(30, 16);
            Hours.TabIndex = 82;
            Hours.Text = "01";
            // 
            // Days
            // 
            Days.BackColor = SystemColors.Window;
            Days.BorderStyle = BorderStyle.None;
            Days.Location = new Point(-17, 3);
            Days.Name = "Days";
            Days.Size = new Size(34, 16);
            Days.TabIndex = 81;
            Days.Text = "0";
            Days.TextAlign = HorizontalAlignment.Right;
            Days.UpDownAlign = LeftRightAlignment.Left;
            // 
            // TimePicker
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMinSecColon);
            Controls.Add(lblHourMinColon);
            Controls.Add(Seconds);
            Controls.Add(Minutes);
            Controls.Add(Hours);
            Controls.Add(lblDays);
            Controls.Add(Days);
            Name = "TimePicker";
            Size = new Size(110, 19);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Label lblDays;
        internal Label lblHourMinColon;
        internal MyDomainUpDown Days;
        internal MyDomainUpDown Hours;
        internal Label lblMinSecColon;
        internal MyDomainUpDown Minutes;
        internal MyDomainUpDown Seconds;

    }
}