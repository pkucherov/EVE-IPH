using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class frmESIStatus
    {
        public frmESIStatus()
        {
            InitializeComponent();
        }

        private void RefreshGrid()
        {
            string SQL;
            SQLiteDataReader rsStatus;
            ListViewItem lstViewrow;
            string[] ScopesList;
            string ScopesSQL = "";
            int EndLoc = 0;

            int StartLoc = 0;
            int Length = 0;

            lstStatus.Items.Clear();
            lstStatus.BeginUpdate();

            if (Public_Variables.SelectedCharacter.CharacterTokenData.Scopes == "No Scopes")
            {
                lstStatus.EndUpdate();
                return;
            }

            SQL = "SELECT scope, purpose, status FROM ESI_STATUS_ITEMS, ESI_ENDPOINT_ROUTE_TO_SCOPE WHERE route = endpoint_route ";
            ScopesList = Public_Variables.SelectedCharacter.CharacterTokenData.Scopes.Split(' ');

            foreach (var scope in ScopesList)
            {
                if (Strings.InStr(scope, ".") != 0)
                {
                    ScopesSQL += scope.Substring(0, Strings.InStr(Strings.InStr(scope, ".") + 1, scope, ".") - 1) + "','";
                }
            }

            ScopesSQL = ScopesSQL.Substring(0, Strings.Len(ScopesSQL) - 3);

            SQL += "AND scope IN ('" + ScopesSQL + "') ";
            SQL += "ORDER BY tag1";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsStatus = Public_Variables.DBCommand.ExecuteReader();

            while (rsStatus.Read())
            {
                lstViewrow = new ListViewItem(rsStatus.GetString(0));
                lstViewrow.SubItems.Add(rsStatus.GetString(1));
                switch (rsStatus.GetString(2) ?? "")
                {
                    case "green":
                        {
                            lstViewrow.SubItems.Add("Good");
                            lstViewrow.BackColor = Color.LightGreen;
                            break;
                        }
                    case "yellow":
                        {
                            lstViewrow.SubItems.Add("Degraded");
                            lstViewrow.BackColor = Color.Yellow;
                            break;
                        }

                    default:
                        {
                            lstViewrow.SubItems.Add("Down");
                            lstViewrow.BackColor = Color.IndianRed;
                            break;
                        }
                }

                lstStatus.Items.Add(lstViewrow);
                Application.DoEvents();
            }

            lstStatus.EndUpdate();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var ESIData = new ESI();

            Application.UseWaitCursor = true;
            Application.DoEvents();
            Label argUpdateLabel = null;
            ProgressBar argPB = null;
            ESIData.GetESIStatus(UpdateLabel: ref argUpdateLabel, PB: ref argPB);
            RefreshGrid();
            Application.UseWaitCursor = false;
            Application.DoEvents();

        }

        private void frmESIStatus_Shown(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            Application.DoEvents();
            RefreshGrid();
            Application.UseWaitCursor = false;
            Application.DoEvents();
        }

    }
}