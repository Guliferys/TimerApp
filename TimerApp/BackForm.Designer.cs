using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace TimerApp
{
    public partial class BackForm : Form
    {

        public static BackForm backFormInstance; // Variabila globala pnt instanta BackForm
        private bool _closingFromButton = false; // variabila globala pentru a verifica daca se inchide prin butonul Start din Form1
        

        public BackForm()
        {

            InitializeComponent();
            backFormInstance = this;  // Variabila globala pnt instanta BackForm
            BackFormSettings();       // Setarile ferestrei BackForm

        }

        private void BackForm_Load(object sender, EventArgs e)
        {
            AllScreens();             // Blocheaza toate monitoarele
        }


        private void BackFormSettings()
        {
            //First screen
            this.FormBorderStyle = FormBorderStyle.None;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }

        private void AllScreens()
        {
            if (Screen.AllScreens.Length > 1)
            {
                Rectangle bounds = new Rectangle(0, 0, 0, 0);
                foreach (Screen screen in Screen.AllScreens)
                {
                    bounds.Width += screen.Bounds.Width;
                    bounds.Height = Math.Max(bounds.Height, screen.Bounds.Height);
                }
                this.SetBounds(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
                this.WindowState = FormWindowState.Normal;
            }

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