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
    public partial class SettingsForm : Form
    {
        private void InitializeComponent()
        {
            this.logDomain = new System.Windows.Forms.DomainUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logDomain
            // 
            this.logDomain.Location = new System.Drawing.Point(127, 51);
            this.logDomain.Name = "logDomain";
            this.logDomain.Size = new System.Drawing.Size(59, 20);
            this.logDomain.TabIndex = 0;
            this.logDomain.Text = "10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Set Time Log";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(413, 379);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logDomain);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);

        }
    }
}
