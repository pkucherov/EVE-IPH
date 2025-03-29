using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class ListViewItemComparer : IComparer, IComparer<ListViewItem>
    {

        private int ColumnIndex;
        private SortOrder OrderOfSort;

        public ListViewItemComparer(int SentColumnIndex, SortOrder SortType)
        {
            ColumnIndex = SentColumnIndex;
            OrderOfSort = SortType;
        }

        public int Compare(object x, object y)
        {
            return CompareCore((ListViewItem)x, (ListViewItem)y);
        }

        private int CompareCore(ListViewItem x, ListViewItem y)
        {
            int result;

            try
            {
                // Get the values
                string StrX = x.SubItems[ColumnIndex].Text;
                string StrY = y.SubItems[ColumnIndex].Text;

                if (x.ListView.Columns[ColumnIndex].Text.Contains("Time") & y.ListView.Columns[ColumnIndex].Text.Contains("Time"))
                {
                    // This is a special case to sort by converting the values back to seconds then sending on
                    StrX = Public_Variables.ConvertDHMSTimetoSeconds(StrX).ToString();
                    StrY = Public_Variables.ConvertDHMSTimetoSeconds(StrY).ToString();
                }

                // Strip out any percentages
                StrX = Strings.Trim(StrX.Replace("%", ""));
                StrY = Strings.Trim(StrY.Replace("%", ""));

                // Sort numbers
                if (Information.IsNumeric(StrX) & Information.IsNumeric(StrY))
                {

                    result = Conversions.ToDouble(StrX).CompareTo(Conversions.ToDouble(StrY));
                }

                else if (Information.IsDate(StrX) & Information.IsDate(StrY))
                {
                    // Compare the dates
                    result = Conversions.ToDate(StrX).CompareTo(DateTime.Parse(StrY));
                }

                else if (Public_Variables.IsStringdate(StrX) & Public_Variables.IsStringdate(StrY))
                {
                    // This is a date sorted as a string like 2d 14:23:22
                    result = ((double)Public_Variables.FormatStringdate(StrX)).CompareTo(Public_Variables.FormatStringdate(StrY));
                }
                else // Strings or any other object
                {
                    // Compare the two items.
                    result = StrX.CompareTo(StrY);
                }

                // Calculate the correct return value based on the object 
                // comparison.
                if (OrderOfSort == SortOrder.Ascending)
                {
                    return result;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of 
                    // compare operation.
                    return -result;
                }
                else
                {
                    // Return '0' to indicate that they are equal.
                    return 0;
                }

                return result;
            }

            catch (Exception ex)
            {
                return 0; // Something happened so just assume equal for now
            }

        }

        int IComparer<ListViewItem>.Compare(ListViewItem x, ListViewItem y) => CompareCore(x, y);

    }
}