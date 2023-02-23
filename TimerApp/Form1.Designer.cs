using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices;


namespace TimerApp
{
    public partial class Form1 : Form
    {
        private Point lastCursorPosition;
        private Timer inactivityTimer = new Timer();
        private Timer inactivityTimer2 = new Timer();
        private Timer userTimer = new Timer();
        private Timer logTimer = new Timer();
        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        private StreamWriter logFile;
        WindowsIdentity identity = WindowsIdentity.GetCurrent();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;



        public Form1()
        {
            InitializeComponent();

            // Inițializăm ultimele coordonate ale mouse-ului cu poziția curentă
            lastCursorPosition = Cursor.Position;


            userTimer.Interval = 1000;
            userTimer.Tick += Timer_Tick;


            // Creem fisier-ul log
            string logFileName = $"cronometru-log-{DateTime.Now:yyyyMMdd-HHmmss}.txt";
            logFile = new StreamWriter(logFileName, append: true);

            logTimer.Interval = 10000; // 10 sec do log
            logTimer.Tick += LogTimer_Tick;
            logTimer.Start();


            inactivityTimer.Interval = 1000; // Interval de 1 secundă
            inactivityTimer.Tick += inactivityTimer_Tick;

            inactivityTimer2.Interval = 5000; // Interval de 10 secundă pentru avertizare
            inactivityTimer2.Tick += inactivityTimer2_Tick;


            //Windows user
            //MessageBox.Show("Numele utilizatorului curent este: " + username);

            // Menține fereastra aplicației în prim-plan
            SetForegroundWindow(this.Handle);

            // Redimensionează fereastra aplicației
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;


            // Setare pozitie elemente pe centru
            labelTime.Left = (ClientSize.Width - labelTime.Width) / 2;
            labelTime.Top = (ClientSize.Height - labelTime.Height) / 4;
            button1.Left = (ClientSize.Width - button1.Width) / 2;
            button1.Top = (ClientSize.Height - button1.Height) / 2;


            FormClosing += Form1_FormClosing;
        }
     
        private void inactivityTimer_Tick(object sender, EventArgs e)
        {
            {
                // Verificăm dacă poziția mouse-ului s-a schimbat față de ultima poziție
                if (lastCursorPosition != Cursor.Position)
                {
                    // Actualizăm ultimele coordonate ale mouse-ului
                    lastCursorPosition = Cursor.Position;
                    //timerul se reporneste
                    inactivityTimer2.Stop();
                    inactivityTimer2.Start();
                }

            }
        }
        private void inactivityTimer2_Tick(object sender, EventArgs e)
        {
            inactivityTimer.Stop();
            inactivityTimer2.Stop();
            userTimer.Stop();
            // Afișăm un mesaj de avertizare cu MessageBox
            DialogResult result = MessageBox.Show("Confirmați că sunteți pe loc!", "Inactivitate detectată", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly);
            //MessageBox.Show("Mesaj important!", "Titlu", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.OK)
            {
                inactivityTimer.Start();
                inactivityTimer2.Start();
                userTimer.Start();
            }
        }


        private void LogTimer_Tick(object sender, EventArgs e)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} Cronometrul arata: {hours:00}:{minutes:00}:{seconds:00}";
            logFile.WriteLine(logMessage);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;
                }
            }

            labelTime.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string username = identity.Name;
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {username} a pornit cronometru!";
            logFile.WriteLine(logMessage);

            inactivityTimer.Start();
            inactivityTimer2.Start();
            userTimer.Start();
            button1.Visible = false;
            this.WindowState = FormWindowState.Minimized;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            logFile.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} Aplicatia sa oprit!");
            logFile.Close();
        }

        private Button button1;
        private Label labelTime;
    }
}
