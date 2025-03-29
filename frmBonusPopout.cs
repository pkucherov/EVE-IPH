using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmBonusPopout
    {
        private int ColumnClicked;
        private SortOrder ColumnSortType;

        public frmBonusPopout()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            // Set up all the sizes
            Height = SettingsVariables.StructureBonusPopoutViewerSettings.FormHeight;
            Width = SettingsVariables.StructureBonusPopoutViewerSettings.FormWidth;

            lstUpwellStructureBonuses.Columns[0].Width = SettingsVariables.StructureBonusPopoutViewerSettings.BonusAppliesColumnWidth;
            lstUpwellStructureBonuses.Columns[1].Width = SettingsVariables.StructureBonusPopoutViewerSettings.ActivityColumnWidth;
            lstUpwellStructureBonuses.Columns[2].Width = SettingsVariables.StructureBonusPopoutViewerSettings.BonusesColumnWidth;
            lstUpwellStructureBonuses.Columns[3].Width = SettingsVariables.StructureBonusPopoutViewerSettings.BonusSourceColumnWidth;

        }

        private void frmBonusPopout_Layout(object sender, LayoutEventArgs e)
        {

            // Resize the grid
            lstUpwellStructureBonuses.Height = Height - 94;
            lstUpwellStructureBonuses.Width = Width - 38;

            // Move the buttons
            btnSaveSettings.Left = (int)Math.Round(Width / 2d) - btnSaveSettings.Width - 10; // middle of form minus half spacing and button width
            btnSaveSettings.Top = Height - 73;

            btnClose.Left = (int)Math.Round(Width / 2d) + 10; // middle of form plus half spacing
            btnClose.Top = Height - 73;

            Application.DoEvents();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            StructureBonusPopoutSettings TempSettings = default;

            // Save the height, width, and column sizes for later
            try
            {
                TempSettings.FormHeight = Height;
                TempSettings.FormWidth = Width;

                TempSettings.BonusAppliesColumnWidth = lstUpwellStructureBonuses.Columns[0].Width;
                TempSettings.ActivityColumnWidth = lstUpwellStructureBonuses.Columns[1].Width;
                TempSettings.BonusesColumnWidth = lstUpwellStructureBonuses.Columns[2].Width;

                TempSettings.BonusSourceColumnWidth = lstUpwellStructureBonuses.Columns[3].Width;

                SettingsVariables.AllSettings.SaveStructureBonusPopoutViewerSettings(TempSettings);
                SettingsVariables.StructureBonusPopoutViewerSettings = TempSettings;

                Interaction.MsgBox("Settings Saved", Constants.vbInformation, Application.ProductName);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("Settings failed to save: " + ex.Message, Constants.vbExclamation, Application.ProductName);
            }

            Application.DoEvents();

        }

        private void lstUpwellStructureBonuses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var argRefListView = lstUpwellStructureBonuses;
            Public_Variables.ListViewColumnSorter(e.Column, ref argRefListView, ref ColumnClicked, ref ColumnSortType);
        }
    }
}