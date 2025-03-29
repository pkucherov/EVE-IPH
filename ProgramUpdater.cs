using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public enum UpdateCheckResult
    {
        UpdateError = -1,
        UpToDate = 0,
        UpdateAvailable = 1
    }

    // Class for checking for updates and storing data for comparision
    public class ProgramUpdater
    {

        // XML Temp file path for server file
        public string ServerXMLLastUpdatePath;

        // When constructed, it will load the settings XML file into the class
        public ProgramUpdater()
        {

            // Create the updates folder
            if (Directory.Exists(Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath)))
            {
                // Delete what is there and replace
                var ImageDir = new DirectoryInfo(Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath));
                ImageDir.Delete(true);
            }

            Directory.CreateDirectory(Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath));

            // Get the newest updatefile from server
            if (Public_Variables.TestingVersion)
            {
                ServerXMLLastUpdatePath = Public_Variables.DownloadFileFromServer(Public_Variables.XMLUpdateTestFileURL, Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath, Public_Variables.XMLLatestVersionTest));
            }
            else
            {
                ServerXMLLastUpdatePath = Public_Variables.DownloadFileFromServer(Public_Variables.XMLUpdateFileURL, Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath, Public_Variables.XMLLatestVersionFileName));
            }

        }

        // Just deletes the files and directory for updates
        public void CleanUpFiles()
        {
            // Delete the updates folder (new one will be made in updater)
            try
            {
                var ImageDir = new DirectoryInfo(Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath));
                ImageDir.Delete(true);
            }
            catch (Exception)
            {
            }
        }

        private struct MD5FileInfo
        {
            public string MD5;
            public string URL;
            public string FileName;
        }

        // Checks the updater file to see if it needs to be updated, updates it if needed, then shells to the updater and closes this application
        public void RunUpdate()
        {
            var m_xmld = new XmlDocument();
            XmlNodeList m_nodelist;

            var UpdateFiles = new List<MD5FileInfo>();
            var TempUpdateFile = new MD5FileInfo();

            string UpdaterServerFileURL = "";
            string UpdaterServerFileMD5 = "";

            bool LaunchSQLiteDLLUpdater = false;

            FileInfo fi;
            try
            {

                // Wait for a second before running - might solve the problem with incorrectly suggesting an update
                System.Threading.Thread.Sleep(2000);

                // Load the server XML file
                m_xmld.Load(ServerXMLLastUpdatePath);
                m_nodelist = m_xmld.SelectNodes("/EVEIPH/result/rowset/row");

                // Loop through the nodes and find the MD5 and download URL for the updater and any other files necessary to load and run the updater program
                // Below for the dll updates, if I push new ones, put in this fix to launch a small copy program to copy the files over since it will error if they are used by the applications
                foreach (XmlNode m_node in m_nodelist)
                {
                    switch (m_node.Attributes.GetNamedItem("Name").Value ?? "")
                    {
                        case Public_Variables.UpdaterFileName:
                            {
                                // Add the file to the update list 
                                TempUpdateFile.MD5 = m_node.Attributes.GetNamedItem("MD5").Value;
                                TempUpdateFile.URL = m_node.Attributes.GetNamedItem("URL").Value;
                                TempUpdateFile.FileName = m_node.Attributes.GetNamedItem("Name").Value;
                                UpdateFiles.Add(TempUpdateFile);
                                break;
                            }
                            // Case "System.Data.SQLite.dll", "SQLite.Interop.dll"
                            // ' These require a quick copy over first before launching the updater (which presumably will use the same libraries)
                            // ' Check MD5 hash and if different, copy
                            // If m_node.Attributes.GetNamedItem("MD5").Value <> MD5CalcFile(Path.Combine(DynamicFilePath, m_node.Attributes.GetNamedItem("Name").Value)) Then
                            // ' If either or doesn't match, update both because they are dependent files
                            // LaunchSQLiteDLLUpdater = True
                            // End If
                    }
                }

                // Download the updater file if needed
                foreach (var UpdateFile in UpdateFiles)
                {
                    if (DownloadUpdatedFile(UpdateFile.MD5, UpdateFile.URL, UpdateFile.FileName) == "Download Error")
                    {
                        throw new Exception("Download error");
                    }
                }

                // Don't delete the update file or folder (it will get deleted on startup of this or updater anyway
                // Perserve the old XML file until we finish the updater - if only the updater needs to be updated, 
                // then it will copy over the new xml file when it closes

                var Proc = new Process();

                if (LaunchSQLiteDLLUpdater)
                {
                    // Need to launch the DLL copy process first, then it will launch the updater - this is needed if the file is locked by the programs using it
                    Proc.StartInfo.FileName = Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.SQLiteDLLUpdater);
                }
                else
                {
                    // Launch the updater process only
                    Proc.StartInfo.FileName = Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdaterFileName);
                }

                Proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                Proc.StartInfo.Arguments = Path.GetDirectoryName(Application.ExecutablePath);
                Proc.Start();

                // Close this program
                Environment.Exit(0);
            }
            catch
            {
            }


            // Some sort of problem, we will just update the whole thing and download the new XML file
            if (!string.IsNullOrEmpty(Information.Err().Description))
            {
                Interaction.MsgBox("Unable to download updates at this time. Please try again later." + Environment.NewLine + "Error: " + Information.Err().Description, Constants.vbCritical, Application.ProductName);
            }
            else
            {
                Interaction.MsgBox("Unable to download updates at this time. Please try again later.", Constants.vbCritical, Application.ProductName);
            }

            return;

        }

        private string DownloadUpdatedFile(string ServerFileMD5, string ServerFileURL, string Filename)
        {
            string LocalFileMD5 = "";
            string ServerFilePath = "";
            FileInfo fi;

            try
            {

                // Get the local updater MD5, if not found, we run update anyway
                LocalFileMD5 = Public_Variables.MD5CalcFile(Path.Combine(Public_Variables.DynamicFilePath, Filename));

                if ((LocalFileMD5 ?? "") != (ServerFileMD5 ?? ""))
                {
                    // Update the file, download the new file first
                    ServerFilePath = Public_Variables.DownloadFileFromServer(ServerFileURL, Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath, Filename));

                    if ((Public_Variables.MD5CalcFile(ServerFilePath) ?? "") != (ServerFileMD5 ?? ""))
                    {
                        // Try again
                        ServerFilePath = Public_Variables.DownloadFileFromServer(ServerFileURL, Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath, Filename));

                        if ((Public_Variables.MD5CalcFile(ServerFilePath) ?? "") != (ServerFileMD5 ?? "") | string.IsNullOrEmpty(ServerFilePath))
                        {
                            // Download error, just leave because we want this update to go through before running
                            return "Download Error";
                        }
                    }

                    // Delete the old file, rename the new
                    if (File.Exists(Path.Combine(Public_Variables.DynamicFilePath, Filename)))
                    {
                        File.Delete(Path.Combine(Public_Variables.DynamicFilePath, Filename));
                    }

                    // Move the downloaded file
                    fi = new FileInfo(ServerFilePath);
                    fi.MoveTo(Path.Combine(Public_Variables.DynamicFilePath, Filename));
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }

            return "";

        }

        // Function just takes the download date of the current XML file and compares to one on server. If date is newer, then runs update
        public UpdateCheckResult IsProgramUpdatable()
        {
            string LocalMD5 = "";
            string ServerMD5 = "";
            string XMLFile = "";

            try
            {
                if (Public_Variables.TestingVersion)
                {
                    XMLFile = Public_Variables.XMLLatestVersionTest;
                }
                else
                {
                    XMLFile = Public_Variables.XMLLatestVersionFileName;
                }

                // Get the hash of the local XML
                LocalMD5 = Public_Variables.MD5CalcFile(Path.Combine(Public_Variables.DynamicFilePath, XMLFile));

                if (!string.IsNullOrEmpty(ServerXMLLastUpdatePath))
                {
                    // Get the hash of the server XML
                    ServerMD5 = Public_Variables.MD5CalcFile(Path.Combine(Public_Variables.DynamicFilePath, Public_Variables.UpdatePath, XMLFile));
                }
                else
                {
                    return UpdateCheckResult.UpdateError;
                }

                // If the hashes are not equal, then we want to run the update
                if ((LocalMD5 ?? "") != (ServerMD5 ?? ""))
                {
                    return UpdateCheckResult.UpdateAvailable;
                }
                else // No update needed
                {
                    return UpdateCheckResult.UpToDate;
                }
            }

            catch (Exception ex)
            {
                // File didn't download, so either try again later or some other error that is unhandled
                Interaction.MsgBox(ex.Message);
                Public_Variables.WriteMsgToLog("IsProgramUpdatable" + ex.Message);
                return UpdateCheckResult.UpdateError;
            }
        }

    }
}