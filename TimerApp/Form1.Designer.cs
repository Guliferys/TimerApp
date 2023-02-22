using System;
using System.IO;
using System.Windows.Forms;

namespace TimerApp
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        private StreamWriter logFile;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            string logFileName = $"cronometru-log-{DateTime.Now:yyyyMMdd-HHmmss}.txt";
            logFile = new StreamWriter(logFileName, append: true);

            Timer logTimer = new Timer();
            logTimer.Interval = 10000; //la cite ms sa faca loguri in fisier (10 sec)
            logTimer.Tick += LogTimer_Tick;


            FormClosing += Form1_FormClosing;
        }

        private void LogTimer_Tick(object sender, EventArgs e)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Timpul curent este {hours:00}:{minutes:00}:{seconds:00}";
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
            logTimer.Start();

            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Aplicatia a pornit!";
            logFile.WriteLine(logMessage);

            timer.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            logFile.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Aplicatia sa oprit!");
            logFile.Close();
        }

        private Button button1;
        private Label labelTime;
        private System.ComponentModel.IContainer components;
    }
}
