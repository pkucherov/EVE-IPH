using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace EVE_Isk_per_Hour
{
    public partial class DBConnection
    {
        private SQLiteConnection CopyDBToMemory(SQLiteConnection physicalConnection)
        {
            var sandboxConnection = new SQLiteConnection("Data Source=:memory:");
            sandboxConnection.Open();
            var dbName = "main";
            physicalConnection.BackupDatabase(sandboxConnection, dbName, dbName, -1, null, -1);

            return sandboxConnection;
        }
    }
}
