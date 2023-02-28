﻿using System;
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
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace TimerApp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

        }
































































































































































































































































































































































































































































































































































































































































































        private void btnSetInterval_Click(object sender, EventArgs e)
        {
            int interval;
            if (int.TryParse(logDomain.Text, out interval))
            {
                TimerInterval = interval;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid interval value!");
            }
        }


        private DomainUpDown logDomain;
        private Button button1;

        public int TimerInterval { get; set; }

    }
}