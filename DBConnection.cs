using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public partial class DBConnection
    {

        private SQLiteConnection DB;
        private object Lock = new object();

        public DBConnection(string DBFilePath, string DBName)
        {
            string DBFileName = Path.Combine(DBFilePath, DBName);

            DB = new SQLiteConnection();
            DB.ConnectionString = "Data Source=" + DBFileName + ";Version=3;";
            if (DB.State == ConnectionState.Open)
            {
                DB.Close(); // Check if the DB is open and will lock on re-connection
                DB.Dispose();
                GC.Collect();
                System.Threading.Thread.Sleep(5000);
                DB.ConnectionString = "Data Source=" + DBFileName + ";Version=3;";
            }

            try
            {
                OpenDB();
                DB = CopyDBToMemory(DB);
            }
            catch (Exception ex)
            {
                DisplayDBException(ex);
                Environment.Exit(0); // Close program
            }

        }

        // Before opening, delete any shm and wal files that might be in the folder
        private void OpenDB()
        {

            try
            {
                File.Delete("EVEIPH DB.sqlite-shm");
            }
            catch (Exception)
            {
            }
            try
            {
                File.Delete("EVEIPH DB.sqlite-wal");
            }
            catch (Exception)
            {
            }
            try
            {
                DB.Open();
                ExecuteNonQuerySQL("PRAGMA auto_vacuum = FULL; PRAGMA synchronous = NORMAL; PRAGMA locking_mode = NORMAL; PRAGMA cache_size = -1000000; PRAGMA page_size = 4096; PRAGMA temp_store = DEFAULT; PRAGMA journal_mode = WAL; PRAGMA count_changes = OFF; pragma journal_size_limit = 6144000;");
            }
            catch (Exception)
            {
            }
        }

        private void DisplayDBException(Exception ThrownException)
        {
            Interaction.MsgBox("IPH was unable to open the primary database and will now close." + Constants.vbCrLf + Constants.vbCrLf + "Error message: " + ThrownException.Message, Constants.vbCritical);
            Public_Variables.WriteMsgToLog(ThrownException.ToString());
        }

        public void CloseDB()
        {
            DB.Close();
            DB.Dispose();
            GC.Collect();
        }

        public SQLiteConnection DBREf()
        {
            return DB;
        }

        public void ExecuteNonQuerySQL(string SQL)
        {
            SQLiteCommand DBExecuteCmd;

            Public_Variables.ErrorTracker = SQL;
            lock (Lock)
            {
                DBExecuteCmd = DB.CreateCommand();
                DBExecuteCmd.CommandText = SQL;
                DBExecuteCmd.ExecuteNonQuery();
                DBExecuteCmd.Dispose();
                DBExecuteCmd = null;
            }

            Public_Variables.ErrorTracker = "";

        }

        public void BeginSQLiteTransaction()
        {
            ExecuteNonQuerySQL("BEGIN;");
        }

        public void CommitSQLiteTransaction()
        {
            ExecuteNonQuerySQL("END;");
        }

        public void RollbackSQLiteTransaction()
        {
            ExecuteNonQuerySQL("ROLLBACK;");
        }

        public bool TransactionActive()
        {
            if (DB.AutoCommit)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}