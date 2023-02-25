using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using System.Diagnostics;

namespace TimerApp
{
    public partial class Form1 : Form
    {

        private List<BackForm> _forms = new List<BackForm>();             // Lista cu instantele BackForm
        private Timer inactivityTimer = new Timer();
        private Timer inactivityTimer2 = new Timer();
        private Timer logTimer = new Timer();
        private Timer stopwatchTimer = new Timer();
        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        private StreamWriter logFile;                                     // Fisierul cu loguri
        WindowsIdentity identity = WindowsIdentity.GetCurrent();          // Numele utilizatorului 
        private const string password = "parola";                         // Parola pnt Auth
        public static Form1 form1Instance;                                // Instanta Form1
        private Point lastCursorPosition;                                 // Ultima pozitie mouse
        private bool _closeFrom1 = false;                                 // Verifica daca este permisa inchiderea app

        ///////////// Mouse TRACK ///////////////
        [DllImport("user32.dll")]                                                                    
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int SW_RESTORE = 9;

        //////////// KeyBoard BLOCK  /////////////
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);



        public Form1()
        {
            InitializeComponent();

            form1Instance = this;                                  // Instanta form1 (pentru BackForm)
            lastCursorPosition = Cursor.Position;                  // Inițializăm ultimele coordonate ale mouse-ului cu poziția curentă
            FormClosing += Form1_FormClosing;                      // 'Form1_FormClosing' sa fie apelat la inchiderea aplicatiei

            Form1_Design();
            Timer_Settings();
            AllScreenCover();
            SetHook();
            //MessageBox.Show("Numele utilizatorului curent este: " + username);

        }



        public void Form1_Design()
        {
            //this.Bounds = Screen.PrimaryScreen.WorkingArea;
            SetForegroundWindow(this.Handle);                        // Menține fereastra aplicației în prim-plan
            this.FormBorderStyle = FormBorderStyle.None;             // Redimensionează fereastra aplicației
            this.TopMost = true;

            //Elements Design
            labelTime.Left = (ClientSize.Width - labelTime.Width) / 2;
            labelTime.Top = (ClientSize.Height - labelTime.Height) / 4;
            btn_start.Left = (ClientSize.Width - btn_start.Width) / 2;
            btn_start.Top = (ClientSize.Height - btn_start.Height) / 2;
            btn_hide.Left = (ClientSize.Width - btn_hide.Width) / 2;
            btn_hide.Top = (ClientSize.Height - btn_hide.Height) / 2;
            btn_exit.Left = (ClientSize.Width - btn_exit.Width) / 2;
            btn_exit.Top = (ClientSize.Height - btn_exit.Height) * 3 / 4;
        }
        

        ///////////////////////////////////////////////////////////////////
        ////////////////////////    TIMER    //////////////////////////////
        ///////////////////////////////////////////////////////////////////

        public void Timer_Settings()
        {
            // CRONOMETRU TIMER
            stopwatchTimer.Interval = 1000;
            stopwatchTimer.Tick += Timer_Tick;

            // LOG TIMER
            logTimer.Interval = 10000; // 10 sec do log
            logTimer.Tick += LogTimer_Tick;

            // MOUSE TIMER
            inactivityTimer.Interval = 1000; // Interval de 1 secundă
            inactivityTimer.Tick += inactivityTimer_Tick;

            inactivityTimer2.Interval = 10000; // Interval de 10 secundă pentru avertizare
            inactivityTimer2.Tick += inactivityTimer2_Tick;
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
            stopwatchTimer.Stop();
            // Afișăm un mesaj de avertizare cu MessageBox
            DialogResult result = MessageBox.Show(
                "Confirmați că sunteți pe loc!",
                "Inactivitate detectată",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.OK)
            {
                inactivityTimer.Start();
                inactivityTimer2.Start();
                stopwatchTimer.Start();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void LogTimer_Tick(object sender, EventArgs e)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} Cronometrul arata: {hours:00}:{minutes:00}:{seconds:00}";
            logFile.WriteLine(logMessage);
            logFile.Flush();
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

        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////





        ///////////////////////////////////////////////////////////////////
        //////////////////////  ALL SCREEN COVER  /////////////////////////
        ///////////////////////////////////////////////////////////////////

        public void AllScreenCover()
                    {
                        // acoperă toate monitoarele la pornirea aplicației
                        Screen[] screens = Screen.AllScreens;
                        foreach (Screen screen in screens)
                        {
                            BackForm form2 = new BackForm();
                            form2.StartPosition = FormStartPosition.Manual;
                            form2.Location = screen.Bounds.Location;
                            form2.Size = screen.Bounds.Size;
                            form2.Show();
                            _forms.Add(form2);
                        }

                        // verifică dacă se adaugă sau se elimină monitoare
                        SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
                    }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            // elimină formularul pentru monitoarele eliminate
            foreach (BackForm form2 in _forms)
            {
                if (!Screen.AllScreens.Any(s => s.Bounds == form2.Bounds))
                {
                    form2.CloseBackForm();
                    _forms.Remove(form2);
                    break;
                }
            }

            // adaugă formularul pentru monitoarele noi
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                if (!_forms.Any(f => f.Bounds == screen.Bounds))
                {
                    BackForm form2 = new BackForm();
                    form2.StartPosition = FormStartPosition.Manual;
                    form2.Location = screen.Bounds.Location;
                    form2.Size = screen.Bounds.Size;
                    form2.Show();
                    _forms.Add(form2);
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////





        ///////////////////////////////////////////////////////////////////
        ///////////////////////    BUTTONS    /////////////////////////////
        ///////////////////////////////////////////////////////////////////

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Creem fisier-ul log
            string logFileName = $"cronometru-log-{DateTime.Now:yyyyMMdd-HHmmss}.txt";
            logFile = new StreamWriter(logFileName, append: true);

            string username = identity.Name;
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {username} a pornit cronometru!";
            logFile.WriteLine(logMessage);
            logFile.Flush();

            stopwatchTimer.Start();
            logTimer.Start();
            inactivityTimer.Start();
            inactivityTimer2.Start();

            btn_start.Visible = false;
            btn_hide.Visible = true;
            btn_exit.Visible = true;

            this.WindowState = FormWindowState.Minimized;
            Unhook(); // Deblocheaza tastatura

            foreach (BackForm form2 in _forms)
            {
                //BackForm.backFormInstance.ClosingFromButton(); //Inchide BackForm dupa butonul Start
                //form2.Close();
                form2.CloseBackForm();
            }
         }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            using (var authForm = new AuthForm(password))
            {
                var result = authForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CloseBackForm();
                    Application.Exit();
                }
            }
        }

        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////
        




        ///////////////////////////////////////////////////////////////////
        ////////////////////    KeyBoard BLOCK    /////////////////////////
        ///////////////////////////////////////////////////////////////////

        // Functionalul dezactivarii tastaturii
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                // interziceți tasta apăsată
                return (IntPtr)1;
            }

            // apelați următoarea metodă din lanțul de hook-uri
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        
        private static void SetHook()  // Dezactiveaza tastatura
        {
            _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
        }

        private static void Unhook()  // Activeaza Tastatura
        {
            UnhookWindowsHookEx(_hookID);
        }

        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////


        public void CloseBackForm()
        {
            logFile.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} Aplicatia sa oprit!");
            logFile.Flush();
            logFile.Close();

            _closeFrom1 = true;
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!_closeFrom1) // verificam daca este permisa inchiderea
                {
                    e.Cancel = true; // nu permitem inchiderea
                }
            }
        }


        private Label labelTime;
        private Button btn_start;
        private Button btn_hide;
        private Button btn_exit;
    }
}
