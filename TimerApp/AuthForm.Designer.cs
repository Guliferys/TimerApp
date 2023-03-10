using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices;


namespace TimerApp
{
    public partial class AuthForm : Form
    {
        private readonly string password;

        public AuthForm(string password)
        {
            InitializeComponent();
            this.password = password;
            //First screen
            //this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == password)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Parola incorecta!", "Eroare de autentificare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtPassword.Text == password)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Parola incorecta!", "Eroare de autentificare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Label label1;
        private TextBox txtPassword;
        private Button button1;
    }
}