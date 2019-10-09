using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   class Conn
    {
        public static MySqlConnection conection()
        {
            MySqlConnectionStringBuilder db = new MySqlConnectionStringBuilder();
            db.Server = "92.249.44.12";
            db.UserID = "u175491821_couPT";
            db.Password = "kmTZd9AERK";
            db.Database = "u175491821_w80wl";
            MySqlConnection con = new MySqlConnection(db.ToString());
            return con;

        }
        public static int insert(string name)
        {
            MySqlConnection con = Conn.conection();
            MySqlCommand com = new MySqlCommand(string.Format("insert into test(ewe) values ('{0}');", name), con);

            con.Open();
            int result = com.ExecuteNonQuery();
            return result;
        }




    }
}