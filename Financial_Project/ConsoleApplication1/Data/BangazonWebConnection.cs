using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace FinancialReports.Data
{
    public class BangazonWebConnection
    {
        private string _connectionString = $"Data Source = {Environment.GetEnvironmentVariable("NTABangazonWeb_Db_Path")}";


        //Method Name: execute
        //Purpose of the Method: This method queries the database for the desired information and stages it to be formatted by the factory.
        //Arguments in Method: query, SqliteDataReader handler

        public void execute(string query, Action<SqliteDataReader> handler)
        {

            SqliteConnection dbcon = new SqliteConnection(_connectionString);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            // clean up
            dbcmd.Dispose();
            dbcon.Close();
        }
    }
}
