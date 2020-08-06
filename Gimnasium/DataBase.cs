using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasium
{
    class DataBase
    {
        static SQLiteConnection dbConnect = new SQLiteConnection("Data Source=MyDB.sqlite;Version=3;");
        public static DataSet getDS()
        {
            dbConnect.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from Bells", dbConnect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dbConnect.Close();

            return ds;

            
        }

        public static void getAllTime()
        {
            Bell.bellList.Clear();
            dbConnect.Open();

            
            SQLiteCommand cmd = dbConnect.CreateCommand();
            cmd.CommandText = "SELECT * from Bells";
            SQLiteDataReader sql = cmd.ExecuteReader();
            
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * from Bells", dbConnect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            while (sql.Read())
            {
                Bell.bellList.Add(new Bell(sql["time"].ToString(),sql["comment"].ToString()));
            }
            dbConnect.Close();
        }
    }

}
