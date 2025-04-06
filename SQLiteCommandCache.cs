using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace EVE_Isk_per_Hour
{
    internal class SQLiteCommandCache
    {
        // This class is used to cache SQLite commands for better performance
        // It wraps the SQLiteCommand class and provides a method to execute the command
        // and return a DbDataReader
        // The command is created with the provided SQL and connection
        // The ExecuteReader method executes the command and returns a DbDataReader

        public static ConcurrentDictionary<int, ConcurrentDictionary<object, object>> Dictionary { get; } = new ();


        SQLiteCommand command;
        public SQLiteCommandCache(string Sql, DbConnection connection, int MainCommandId)
        {
            //command = new SQLiteCommand(Sql, (SQLiteConnection)connection);
            
        }

        public DbDataReader ExecuteReader()
        {
            // Execute the command and return a DbDataReader
            return command.ExecuteReader();
        }
    }
}
