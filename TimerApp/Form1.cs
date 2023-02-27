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
    public partial class Form1 : Form
    {

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelTime = new System.Windows.Forms.Label();
            this.HidePictureBox = new System.Windows.Forms.PictureBox();
            this.ClosePictureBox = new System.Windows.Forms.PictureBox();
            this.StartPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HidePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(167, 213);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(174, 46);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "00:00:00";
            // 
            // HidePictureBox
            // 
            this.HidePictureBox.Location = new System.Drawing.Point(216, 278);
            this.HidePictureBox.Name = "HidePictureBox";
            this.HidePictureBox.Size = new System.Drawing.Size(34, 29);
            this.HidePictureBox.TabIndex = 4;
            this.HidePictureBox.TabStop = false;
            this.HidePictureBox.Visible = false;
            this.HidePictureBox.Click += new System.EventHandler(this.buttonHide_Click);
            this.HidePictureBox.MouseEnter += new System.EventHandler(this.onImage_MouseEnter);
            this.HidePictureBox.MouseLeave += new System.EventHandler(this.onImage_MouseLeave);
            // 
            // ClosePictureBox
            // 
            this.ClosePictureBox.Location = new System.Drawing.Point(265, 278);
            this.ClosePictureBox.Name = "ClosePictureBox";
            this.ClosePictureBox.Size = new System.Drawing.Size(34, 29);
            this.ClosePictureBox.TabIndex = 5;
            this.ClosePictureBox.TabStop = false;
            this.ClosePictureBox.Visible = false;
            this.ClosePictureBox.Click += new System.EventHandler(this.buttonExit_Click);
            this.ClosePictureBox.MouseEnter += new System.EventHandler(this.onImage_MouseEnter);
            this.ClosePictureBox.MouseLeave += new System.EventHandler(this.onImage_MouseLeave);
            // 
            // StartPictureBox
            // 
            this.StartPictureBox.Location = new System.Drawing.Point(232, 278);
            this.StartPictureBox.Name = "StartPictureBox";
            this.StartPictureBox.Size = new System.Drawing.Size(45, 41);
            this.StartPictureBox.TabIndex = 6;
            this.StartPictureBox.TabStop = false;
            this.StartPictureBox.Click += new System.EventHandler(this.buttonStart_Click);
            this.StartPictureBox.MouseEnter += new System.EventHandler(this.onImage_MouseEnter);
            this.StartPictureBox.MouseLeave += new System.EventHandler(this.onImage_MouseLeave);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(498, 462);
            this.Controls.Add(this.StartPictureBox);
            this.Controls.Add(this.ClosePictureBox);
            this.Controls.Add(this.HidePictureBox);
            this.Controls.Add(this.labelTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stopwatch";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.HidePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
