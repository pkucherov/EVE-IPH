using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class TimePicker
    {

        private Queue<string> _99SingleDigitList = new Queue<string>();
        private Queue<string> _99TwoDigitList = new Queue<string>();
        private Queue<string> _23List = new Queue<string>();
        private Queue<string> _59List = new Queue<string>();

        public bool ResetHours;
        public bool ResetMinutes;
        public bool ResetSeconds;
        public event TimeChangeEventHandler TimeChange;

        public delegate void TimeChangeEventHandler(object sender, EventArgs e);

        public TimePicker()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            // Build the two types of number lists
            for (int i = 0; i <= 99; i++)
            {
                _99SingleDigitList.Enqueue(i.ToString());
                _99TwoDigitList.Enqueue(Strings.Format(i, "00"));
            }

            for (int i = 0; i <= 23; i++)
                _23List.Enqueue(Strings.Format(i, "00"));

            for (int i = 0; i <= 59; i++)
                _59List.Enqueue(Strings.Format(i, "00"));

            // Add 99 days for each - maybe later I'll get fancy and limit the numbers based on 24:59:59
            Days.Items.Clear();
            Days.Items.AddRange(_99SingleDigitList);

            Hours.Items.Clear();
            Hours.Items.AddRange(_99TwoDigitList);

            Minutes.Items.Clear();
            Minutes.Items.AddRange(_99TwoDigitList);

            Seconds.Items.Clear();
            Seconds.Items.AddRange(_99TwoDigitList);

            // Default to 1 hour
            Days.Text = "0";
            Hours.Text = "01";
            Minutes.Text = "00";
            Seconds.Text = "00";

            ResetHours = true;
            ResetMinutes = true;
            ResetSeconds = true;
            Text = _Text;
            Text = _Text;
            Text = _Text;
            Text = _Text;
            Text = _Text;
            Text = _Text;
            Text = _Text;

        }

        public override string Text
        {
            get
            {
                string D = Strings.Trim(Days.Text);
                string H = Strings.Trim(Hours.Text);
                string M = Strings.Trim(Minutes.Text);
                string S = Strings.Trim(Seconds.Text);
                if (string.IsNullOrEmpty(D))
                {
                    D = "0";
                }
                if (string.IsNullOrEmpty(H))
                {
                    H = "00";
                }
                if (string.IsNullOrEmpty(M))
                {
                    M = "00";
                }
                if (string.IsNullOrEmpty(S))
                {
                    S = "00";
                }
                return D + " Days " + H + ":" + M + ":" + S;
            }

            set
            {
                try
                {
                    // Add the time from string - X Days
                    string[] strArr;
                    int count;

                    if (string.IsNullOrEmpty(value))
                    {
                        // Default to 1 hour
                        Days.Text = "0";
                        Hours.Text = "01";
                        Minutes.Text = "00";
                        Seconds.Text = "00";
                    }
                    else
                    {
                        // Make sure the sent string has no extra spaces that create a blank array entry
                        value = Strings.Trim(value);
                        // Strip off the days portion
                        string SentDays = value.Substring(0, Strings.InStr(Strings.UCase(value), "DAY") - 2);
                        Days.Text = SentDays;

                        string Time = value.Substring(Strings.InStr(Strings.UCase(value), "DAY") + 4);

                        // Break up the time sections
                        strArr = Time.Split(new char[] { ':' });

                        var loopTo = strArr.Count() - 1;
                        for (count = 0; count <= loopTo; count++)
                        {
                            switch (count)
                            {
                                case 0:
                                    {
                                        Hours.Text = Strings.Trim(strArr[count]);
                                        break;
                                    }
                                case 1:
                                    {
                                        Minutes.Text = Strings.Trim(strArr[count]);
                                        break;
                                    }
                                case 2:
                                    {
                                        Seconds.Text = Strings.Trim(strArr[count]);
                                        break;
                                    }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Default to 1 hour and exit
                    Days.Text = "0";
                    Hours.Text = "01";
                    Minutes.Text = "00";
                    Seconds.Text = "00";
                }

            }

        }

        private void Days_SelectedItemChanged(object sender, EventArgs e)
        {

            TimeChange?.Invoke(sender, e);

        }

        private void Hours_SelectedItemChanged(object sender, EventArgs e)
        {

            TimeChange?.Invoke(sender, e);

        }

        private void Minutes_SelectedItemChanged(object sender, EventArgs e)
        {

            TimeChange?.Invoke(sender, e);

        }

        private void Seconds_SelectedItemChanged(object sender, EventArgs e)
        {

            TimeChange?.Invoke(sender, e);

        }

        private void Days_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != (int)Keys.Delete & e.KeyValue != (int)Keys.Back & e.KeyValue != (int)Keys.Left & e.KeyValue != (int)Keys.Right & Strings.Len(Days.Text) >= 2)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void Hours_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != (int)Keys.Delete & e.KeyValue != (int)Keys.Back & e.KeyValue != (int)Keys.Left & e.KeyValue != (int)Keys.Right & Strings.Len(Hours.Text) >= 2)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void Minutes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != (int)Keys.Delete & e.KeyValue != (int)Keys.Back & e.KeyValue != (int)Keys.Left & e.KeyValue != (int)Keys.Right & Strings.Len(Minutes.Text) >= 2)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void Seconds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != (int)Keys.Delete & e.KeyValue != (int)Keys.Back & e.KeyValue != (int)Keys.Left & e.KeyValue != (int)Keys.Right & Strings.Len(Seconds.Text) >= 2)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        // Private Sub Days_SelectedItemChanged(sender As Object, e As System.EventArgs) Handles Days.SelectedItemChanged
        // Dim Oldvalue As String

        // If Days.Text = "0" Then
        // ' reset the hours to allow to go to 99 - save the old value and reset
        // Oldvalue = Hours.Text
        // Hours.Items.Clear()
        // Hours.Items.AddRange(_99TwoDigitList)
        // Hours.Text = Oldvalue
        // ResetHours = True
        // Else
        // ' Need to load hours back up - just one time
        // If ResetHours Then
        // If Val(Hours.Text) < 24 Then
        // Oldvalue = Hours.Text
        // Else
        // Oldvalue = "23"
        // End If
        // Hours.Items.Clear()
        // Hours.Items.AddRange(_23List)
        // Hours.Text = Oldvalue
        // ResetHours = False
        // End If
        // End If
        // End Sub

        // Private Sub Hours_SelectedItemChanged(sender As System.Object, e As System.EventArgs) Handles Hours.SelectedItemChanged
        // Dim Oldvalue As String

        // If Hours.Text = "00" Then
        // ' reset the hours to allow to go to 99 - save the old value and reset
        // Oldvalue = Minutes.Text
        // Minutes.Items.Clear()
        // Minutes.Items.AddRange(_99TwoDigitList)
        // Minutes.Text = Oldvalue
        // ResetMinutes = True
        // Else
        // ' Need to load hours back up - just one time
        // If ResetHours Then
        // If Val(Minutes.Text) < 59 Then
        // Oldvalue = Minutes.Text
        // Else
        // Oldvalue = "59"
        // End If
        // Minutes.Items.Clear()
        // Minutes.Items.AddRange(_59List)
        // Minutes.Text = Oldvalue
        // ResetMinutes = False
        // End If
        // End If
        // End Sub

    }
}