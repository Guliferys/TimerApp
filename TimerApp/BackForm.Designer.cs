using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices;

namespace TimerApp
{
    public partial class BackForm : Form
    {
        public static BackForm backFormInstance;

        private bool _closingFromButton = false; // variabila globala pentru a verifica daca se inchide prin butonul din Form1
        public BackForm()
        {
            InitializeComponent();
            backFormInstance = this;
            //First screen
            this.FormBorderStyle = FormBorderStyle.None;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

        }

        public void ClosingFromButton()
        {
            _closingFromButton = true;
            this.Close();
        }

        private void showForm1_Click(object sender, EventArgs e)
        {
            Form1.Instance.Show();
            Form1.Instance.BringToFront();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_closingFromButton) // verificam daca formularul este inchis prin butonul din Form1
            {
                e.Cancel = true; // oprim inchiderea
            }
            base.OnFormClosing(e);
        }
    }
}