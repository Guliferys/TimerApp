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
    public partial class BackForm : Form
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BackForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BackForm";
            this.Opacity = 0.5D;
            this.Load += new System.EventHandler(this.BackForm_Load);
            this.Click += new System.EventHandler(this.showForm1_Click);
            this.ResumeLayout(false);

        }
    }
}
