using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp
{
    public class DB
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;database=timerapp;uid=root;password=root;port=8889;");
        /*
            "Server = 192.168.3.71;" +
            //"Server = sql7.freemysqlhosting.net;" +
            "UserID = admin;"+
            //"UserID = sql7602967;" +
            "Password = password;"+
            //"Password = IN98qzLZ8W;" +
            "Database = timerapp");
           // "Database = sql7602967");*/

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }

        public static void ExecuteCommand(string commandText)
        {
                DB db = new DB();
                db.openConnection();
                using (MySqlCommand command = new MySqlCommand(commandText, db.getConnection()))
                {
                    command.ExecuteNonQuery();
                }
            
        }

    }
}