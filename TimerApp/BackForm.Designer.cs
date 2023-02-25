using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;

namespace TimerApp
{
    public partial class BackForm : Form
    {
        private bool _closeBackForm = false; // variabila globala pentru a verifica daca este permisa inchiderea
        

        public BackForm()
        {

            InitializeComponent();
            BackFormSettings();       // Setarile ferestrei BackForm

        }


        private void BackFormSettings()
        {
            //First screen
            this.FormBorderStyle = FormBorderStyle.None;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }


        public void CloseBackForm()
        {
            _closeBackForm = true;
            this.Close();
        }

        private void showForm1_Click(object sender, EventArgs e)
        {
            Form1.form1Instance.Show();
            Form1.form1Instance.BringToFront();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_closeBackForm) // verificam daca este perima inchiderea
            {
                e.Cancel = true; // oprim inchiderea
            }
            base.OnFormClosing(e);
        }

    }
}