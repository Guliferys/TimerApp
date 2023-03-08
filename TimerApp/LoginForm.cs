using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            string loginUser = loginTextbox.Text;
            string passUser = passTextbox.Text;

            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
            else { MessageBox.Show("Account does not exist!"); }

        }

    }
}