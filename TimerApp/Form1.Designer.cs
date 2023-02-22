using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

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
            DialogResult result = MessageBox.Show("Are you here?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                inactivityTimer.Start();
                inactivityTimer2.Start();
                userTimer.Start();
            }
        }


        private void LogTimer_Tick(object sender, EventArgs e)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Cronometrul arata: {hours:00}:{minutes:00}:{seconds:00}";
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
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Cronometru sa pornit!";
            logFile.WriteLine(logMessage);

            inactivityTimer.Start();
            inactivityTimer2.Start();
            userTimer.Start();
            button1.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            logFile.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Aplicatia sa oprit!");
            logFile.Close();
        }

        private Button button1;
        private Label labelTime;
    }
}
