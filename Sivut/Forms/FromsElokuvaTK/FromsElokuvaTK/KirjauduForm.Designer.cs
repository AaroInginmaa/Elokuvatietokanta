namespace FromsElokuvaTK
{
    partial class KirjauduForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_exít = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Käyttäjänimi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Salasana";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(293, 182);
            this.txt_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(296, 26);
            this.txt_username.TabIndex = 2;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(293, 255);
            this.txt_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(296, 26);
            this.txt_password.TabIndex = 3;
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.BlueViolet;
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_login.Location = new System.Drawing.Point(456, 303);
            this.button_login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(131, 80);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Kirjaudu";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.BlueViolet;
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_clear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_clear.Location = new System.Drawing.Point(293, 303);
            this.button_clear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(135, 80);
            this.button_clear.TabIndex = 5;
            this.button_clear.Text = "Tyhjennä";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_exít
            // 
            this.button_exít.BackColor = System.Drawing.Color.BlueViolet;
            this.button_exít.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_exít.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_exít.Location = new System.Drawing.Point(789, 13);
            this.button_exít.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_exít.Name = "button_exít";
            this.button_exít.Size = new System.Drawing.Size(99, 44);
            this.button_exít.TabIndex = 6;
            this.button_exít.Text = "Poistu";
            this.button_exít.UseVisualStyleBackColor = false;
            this.button_exít.Click += new System.EventHandler(this.button_exít_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.BlueViolet;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(663, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Takaisin";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // KirjauduForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_exít);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KirjauduForm";
            this.Text = "Kirjaudu";
            this.Load += new System.EventHandler(this.KirjauduForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.TextBox UsernameFLD;
        private System.Windows.Forms.TextBox ConfirmPWordFLD;
        private System.Windows.Forms.TextBox PWordFLD;
        private System.Windows.Forms.TextBox EmailFLD;
        private System.Windows.Forms.Button CreateUserBTN;
        private System.Windows.Forms.Label UserNameLBL;
        private System.Windows.Forms.Label EmailLBL;
        private System.Windows.Forms.Label PWordLBL;
        private System.Windows.Forms.Label ConfirmPWordLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_exít;
        private System.Windows.Forms.Button button1;
    }
}