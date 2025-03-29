using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{
    public partial class frmAddStructureIDs
    {

        private bool UpdatingStructureIDText;
        private const string InvalidName = "Invalid Name";

        public frmAddStructureIDs()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            // Set the structure instructions for importing prices from structures
            lblStructurePriceInstructions.Text = "Some structures may not be 'public' and IPH cannot download prices from them. However, if you have access to a market (e.g Nullsec Trade Hub), follow these steps to import prices for specific structures:";
            lblStructurePriceInstructions.Text += Constants.vbCrLf + Constants.vbCrLf;
            lblStructurePriceInstructions.Text += "1. Make a link of the market hub in the EVE Chat window. You can drag the station name from assets or type the name and select auto-link and then search for 'Station' and hit enter to put it in chat. Note, if you do not have access search will not work.";
            lblStructurePriceInstructions.Text += Constants.vbCrLf;
            lblStructurePriceInstructions.Text += "2. Right click the link and select Copy after entering the chat link.";
            lblStructurePriceInstructions.Text += Constants.vbCrLf;
            lblStructurePriceInstructions.Text += "3. Paste the text into the structure ID textbox - it will format the number for you.";
            lblStructurePriceInstructions.Text += Constants.vbCrLf;
            lblStructurePriceInstructions.Text += "4. Click check for Market. If there is no market available or you do not have access, the Structure ID will not be added.";

            UpdatingStructureIDText = false;

            for (int i = 1; i <= 10; i++)
                UpdateControls(i, false);

        }

        // Will run an ESI query to see if the index they gave has market data
        private void CheckIDforMarketData(int Index)
        {
            var ESIData = new ESI();
            var StructureTextbox = GetTextBox(Index);
            var StructureLabel = GetLabel(Index);

            if ((GetTextBox(Index).Text ?? "") != InvalidName)
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();

                if (!string.IsNullOrEmpty(StructureTextbox.Text))
                {
                    if (ESIData.CheckStructureMarketData(Conversions.ToLong(StructureTextbox.Text), Public_Variables.SelectedCharacter.CharacterTokenData, true))
                    {
                        StructureLabel.ForeColor = Color.Green;
                        StructureLabel.Text = "OK";
                    }
                    else
                    {
                        StructureLabel.ForeColor = Color.Red;
                        StructureLabel.Text = "Market Access Denied";
                    }
                }
                else
                {
                    Interaction.MsgBox("You must enter an ID", Constants.vbInformation, Application.ProductName);
                    StructureTextbox.Focus();
                }

                Application.UseWaitCursor = false;
                Application.DoEvents();
            }
            else
            {
                Interaction.MsgBox("Structure number is invalid", Constants.vbInformation, Application.ProductName);
                StructureTextbox.SelectAll();
                StructureTextbox.Focus();
            }
        }

        // Save all the structure IDs they entered, if they didn't check it, then run the check of the data and don't add if it comes back false
        private void btnSaveStuctureIDs_Click(object sender, EventArgs e)
        {
            var ESIData = new ESI();
            var CheckedIDs = new List<int>();
            TextBox StructureTextBox;
            int AddedCount = 0;
            var StructureIDList = new List<long>();

            Application.UseWaitCursor = true;
            Application.DoEvents();

            CheckedIDs = GetCheckedIDs();

            foreach (var index in CheckedIDs)
            {
                StructureTextBox = GetTextBox(index);

                // Check the structure for ability to add data
                if (ESIData.CheckStructureMarketData(Conversions.ToLong(StructureTextBox.Text), Public_Variables.SelectedCharacter.CharacterTokenData, true))
                {
                    // They can add it
                    StructureIDList.Add(Conversions.ToLong(StructureTextBox.Text));
                    AddedCount += 1;
                }
            }

            // Add the data
            var SP = new StructureProcessor();
            foreach (var StructureID in StructureIDList)
                SP.UpdateStructureData(StructureID, Public_Variables.SelectedCharacter.CharacterTokenData, true, false, true);

            // Refresh the view saved screen if open
            if (Public_Variables.frmViewStructures.Visible)
            {
                Public_Variables.frmViewStructures.LoadStructureGrid();
            }

            if (AddedCount == 0)
            {
                Interaction.MsgBox("Could not add selected items. Please check information and try again.", Constants.vbInformation, Application.ProductName);
            }
            else if (AddedCount == CheckedIDs.Count)
            {
                Interaction.MsgBox("Selected Structures added.", Constants.vbInformation, Application.ProductName);
            }
            else
            {
                Interaction.MsgBox("Added " + AddedCount.ToString() + " out of " + CheckedIDs.Count + " selected. Please double check information and try again.", Constants.vbInformation, Application.ProductName);
            }

            Application.UseWaitCursor = false;
            Application.DoEvents();


        }

        private List<int> GetCheckedIDs()
        {
            var TempList = new List<int>();

            if (CheckBox1.Checked)
                TempList.Add(1);
            if (CheckBox2.Checked)
                TempList.Add(2);
            if (CheckBox3.Checked)
                TempList.Add(3);
            if (CheckBox4.Checked)
                TempList.Add(4);
            if (CheckBox5.Checked)
                TempList.Add(5);
            if (CheckBox6.Checked)
                TempList.Add(6);
            if (CheckBox7.Checked)
                TempList.Add(7);
            if (CheckBox8.Checked)
                TempList.Add(8);
            if (CheckBox9.Checked)
                TempList.Add(9);
            if (CheckBox10.Checked)
                TempList.Add(10);

            return TempList;

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Format the text to just show the number, if it doesn't contain the correct text, show 'Invalid Name'
            string FormattedText = "";
            TextBox textID = (TextBox)sender;

            if (!UpdatingStructureIDText & (textID.Text ?? "") != InvalidName)
            {
                try
                {
                    if (textID.Text.Contains("//"))
                    {
                        // Find the ID after it - [0054:36] Zifrian > <url=showinfo:35835//1027907881953>Tamo</url>
                        int IDStart = textID.Text.IndexOf("//") + 2;
                        int IDEnd = textID.Text.IndexOf(">", IDStart);
                        FormattedText = textID.Text.Substring(IDStart, IDEnd - IDStart);
                    }
                    else if (Information.IsNumeric(textID.Text))
                    {
                        FormattedText = Strings.Trim(textID.Text);
                    }
                    else
                    {
                        // Not formatted correctly
                        FormattedText = InvalidName;
                    }
                }
                catch
                {
                    FormattedText = InvalidName;
                }
                UpdatingStructureIDText = true;
                textID.Text = FormattedText;
                textID.SelectAll();
                UpdatingStructureIDText = false;
            }

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                UpdatingStructureIDText = true;
            }
            else
            {
                UpdatingStructureIDText = false;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ControlChars.Back)
            {
                UpdatingStructureIDText = true;
            }
            else
            {
                UpdatingStructureIDText = false;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox tempcheck = (CheckBox)sender;
            UpdateControls(GetControlIndex(tempcheck.Name), tempcheck.Checked);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button tempButton = (Button)sender;
            CheckIDforMarketData(GetControlIndex(tempButton.Name));
        }

        public int GetControlIndex(string Name)
        {
            int i = Conversions.ToInteger(Name.Substring(Strings.Len(Name) - 1));
            if (i == 0)
            {
                i = Conversions.ToInteger(Name.Substring(Strings.Len(Name) - 2));
            }
            return i;
        }

        private void UpdateControls(int index, bool value)
        {
            switch (index)
            {
                case 1:
                    {
                        TextBox1.Enabled = value;
                        Button1.Enabled = value;
                        Label1.Text = "";
                        break;
                    }
                case 2:
                    {
                        TextBox2.Enabled = value;
                        Button2.Enabled = value;
                        Label2.Text = "";
                        break;
                    }
                case 3:
                    {
                        TextBox3.Enabled = value;
                        Button3.Enabled = value;
                        Label3.Text = "";
                        break;
                    }
                case 4:
                    {
                        TextBox4.Enabled = value;
                        Button4.Enabled = value;
                        Label4.Text = "";
                        break;
                    }
                case 5:
                    {
                        TextBox5.Enabled = value;
                        Button5.Enabled = value;
                        Label5.Text = "";
                        break;
                    }
                case 6:
                    {
                        TextBox6.Enabled = value;
                        Button6.Enabled = value;
                        Label6.Text = "";
                        break;
                    }
                case 7:
                    {
                        TextBox7.Enabled = value;
                        Button7.Enabled = value;
                        Label7.Text = "";
                        break;
                    }
                case 8:
                    {
                        TextBox8.Enabled = value;
                        Button8.Enabled = value;
                        Label8.Text = "";
                        break;
                    }
                case 9:
                    {
                        TextBox9.Enabled = value;
                        Button9.Enabled = value;
                        Label9.Text = "";
                        break;
                    }
                case 10:
                    {
                        TextBox10.Enabled = value;
                        Button10.Enabled = value;
                        Label10.Text = "";
                        break;
                    }
            }
        }

        private TextBox GetTextBox(int Index)
        {
            switch (Index)
            {
                case 1:
                    {
                        return TextBox1;
                    }
                case 2:
                    {
                        return TextBox2;
                    }
                case 3:
                    {
                        return TextBox3;
                    }
                case 4:
                    {
                        return TextBox4;
                    }
                case 5:
                    {
                        return TextBox5;
                    }
                case 6:
                    {
                        return TextBox6;
                    }
                case 7:
                    {
                        return TextBox7;
                    }
                case 8:
                    {
                        return TextBox8;
                    }
                case 9:
                    {
                        return TextBox9;
                    }
                case 10:
                    {
                        return TextBox10;
                    }
            }

            return null;

        }

        private Label GetLabel(int Index)
        {
            switch (Index)
            {
                case 1:
                    {
                        return Label1;
                    }
                case 2:
                    {
                        return Label2;
                    }
                case 3:
                    {
                        return Label3;
                    }
                case 4:
                    {
                        return Label4;
                    }
                case 5:
                    {
                        return Label5;
                    }
                case 6:
                    {
                        return Label6;
                    }
                case 7:
                    {
                        return Label7;
                    }
                case 8:
                    {
                        return Label8;
                    }
                case 9:
                    {
                        return Label9;
                    }
                case 10:
                    {
                        return Label10;
                    }
            }

            return null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnViewSavedStructures_Click(object sender, EventArgs e)
        {
            if (Public_Variables.frmViewStructures.Visible == false)
            {
                Public_Variables.frmViewStructures = new frmViewSavedStructures();
                Public_Variables.frmViewStructures.Show();
            }
        }

    }
}