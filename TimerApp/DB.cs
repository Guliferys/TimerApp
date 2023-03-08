/*
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace TimerApp
{
    public class DB
    {
        private MySqlConnection connection = null;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;


        public DB()
        {
            server = "sql7.freemysqlhosting.net";
            database = "sql7602967";
            uid = "sql7602967";
            password = "IN98qzLZ8W";
            port = "3306";

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};PORT={port};";

            connection = new MySqlConnection(connectionString);
        }

        public bool openConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
*/

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

    }
}