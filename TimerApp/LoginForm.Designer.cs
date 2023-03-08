
namespace TimerApp
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLogin = new System.Windows.Forms.Button();
            this.loginTextbox = new System.Windows.Forms.TextBox();
            this.passTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(124, 216);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(147, 44);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "button1";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // loginTextbox
            // 
            this.loginTextbox.Location = new System.Drawing.Point(124, 130);
            this.loginTextbox.Name = "loginTextbox";
            this.loginTextbox.Size = new System.Drawing.Size(147, 22);
            this.loginTextbox.TabIndex = 1;
            // 
            // passTextbox
            // 
            this.passTextbox.Location = new System.Drawing.Point(124, 168);
            this.passTextbox.Name = "passTextbox";
            this.passTextbox.Size = new System.Drawing.Size(147, 22);
            this.passTextbox.TabIndex = 2;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 400);
            this.Controls.Add(this.passTextbox);
            this.Controls.Add(this.loginTextbox);
            this.Controls.Add(this.buttonLogin);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox loginTextbox;
        private System.Windows.Forms.TextBox passTextbox;
    }
}