namespace FromsElokuvaTK
{
    partial class Rekisterointi
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
            this.UsernameFLD = new System.Windows.Forms.TextBox();
            this.ConfirmPWordFLD = new System.Windows.Forms.TextBox();
            this.PWordFLD = new System.Windows.Forms.TextBox();
            this.EmailFLD = new System.Windows.Forms.TextBox();
            this.CreateUserBTN = new System.Windows.Forms.Button();
            this.UserNameLBL = new System.Windows.Forms.Label();
            this.EmailLBL = new System.Windows.Forms.Label();
            this.PWordLBL = new System.Windows.Forms.Label();
            this.ConfirmPWordLBL = new System.Windows.Forms.Label();
            this.quitBTN = new System.Windows.Forms.Button();
            this.BackBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameFLD
            // 
            this.UsernameFLD.Location = new System.Drawing.Point(324, 166);
            this.UsernameFLD.Name = "UsernameFLD";
            this.UsernameFLD.Size = new System.Drawing.Size(266, 26);
            this.UsernameFLD.TabIndex = 0;
            // 
            // ConfirmPWordFLD
            // 
            this.ConfirmPWordFLD.Location = new System.Drawing.Point(324, 330);
            this.ConfirmPWordFLD.Name = "ConfirmPWordFLD";
            this.ConfirmPWordFLD.PasswordChar = '*';
            this.ConfirmPWordFLD.Size = new System.Drawing.Size(266, 26);
            this.ConfirmPWordFLD.TabIndex = 3;
            // 
            // PWordFLD
            // 
            this.PWordFLD.Location = new System.Drawing.Point(324, 274);
            this.PWordFLD.Name = "PWordFLD";
            this.PWordFLD.PasswordChar = '*';
            this.PWordFLD.Size = new System.Drawing.Size(266, 26);
            this.PWordFLD.TabIndex = 2;
            // 
            // EmailFLD
            // 
            this.EmailFLD.Location = new System.Drawing.Point(324, 216);
            this.EmailFLD.Name = "EmailFLD";
            this.EmailFLD.Size = new System.Drawing.Size(266, 26);
            this.EmailFLD.TabIndex = 1;
            // 
            // CreateUserBTN
            // 
            this.CreateUserBTN.BackColor = System.Drawing.Color.BlueViolet;
            this.CreateUserBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CreateUserBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.CreateUserBTN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateUserBTN.Location = new System.Drawing.Point(359, 395);
            this.CreateUserBTN.Name = "CreateUserBTN";
            this.CreateUserBTN.Size = new System.Drawing.Size(197, 89);
            this.CreateUserBTN.TabIndex = 4;
            this.CreateUserBTN.Text = "Luo Käyttäjä";
            this.CreateUserBTN.UseVisualStyleBackColor = false;
            this.CreateUserBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserNameLBL
            // 
            this.UserNameLBL.AutoSize = true;
            this.UserNameLBL.Location = new System.Drawing.Point(220, 169);
            this.UserNameLBL.Name = "UserNameLBL";
            this.UserNameLBL.Size = new System.Drawing.Size(98, 20);
            this.UserNameLBL.TabIndex = 5;
            this.UserNameLBL.Text = "Käyttäjänimi:";
            // 
            // EmailLBL
            // 
            this.EmailLBL.AutoSize = true;
            this.EmailLBL.Location = new System.Drawing.Point(225, 222);
            this.EmailLBL.Name = "EmailLBL";
            this.EmailLBL.Size = new System.Drawing.Size(93, 20);
            this.EmailLBL.TabIndex = 6;
            this.EmailLBL.Text = "Sähköposti:";
            // 
            // PWordLBL
            // 
            this.PWordLBL.AutoSize = true;
            this.PWordLBL.Location = new System.Drawing.Point(238, 280);
            this.PWordLBL.Name = "PWordLBL";
            this.PWordLBL.Size = new System.Drawing.Size(80, 20);
            this.PWordLBL.TabIndex = 7;
            this.PWordLBL.Text = "Salasana:";
            // 
            // ConfirmPWordLBL
            // 
            this.ConfirmPWordLBL.AutoSize = true;
            this.ConfirmPWordLBL.Location = new System.Drawing.Point(173, 333);
            this.ConfirmPWordLBL.Name = "ConfirmPWordLBL";
            this.ConfirmPWordLBL.Size = new System.Drawing.Size(145, 20);
            this.ConfirmPWordLBL.TabIndex = 8;
            this.ConfirmPWordLBL.Text = "Vahvista Salasana:";
            // 
            // quitBTN
            // 
            this.quitBTN.BackColor = System.Drawing.Color.BlueViolet;
            this.quitBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.quitBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBTN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.quitBTN.Location = new System.Drawing.Point(808, 12);
            this.quitBTN.Name = "quitBTN";
            this.quitBTN.Size = new System.Drawing.Size(94, 47);
            this.quitBTN.TabIndex = 10;
            this.quitBTN.Text = "Poistu";
            this.quitBTN.UseVisualStyleBackColor = false;
            this.quitBTN.Click += new System.EventHandler(this.quitBTN_Click);
            // 
            // BackBTN
            // 
            this.BackBTN.BackColor = System.Drawing.Color.BlueViolet;
            this.BackBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBTN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BackBTN.Location = new System.Drawing.Point(686, 12);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(116, 47);
            this.BackBTN.TabIndex = 11;
            this.BackBTN.Text = "Takaisin";
            this.BackBTN.UseVisualStyleBackColor = false;
            this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
            // 
            // LuoKTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 695);
            this.Controls.Add(this.BackBTN);
            this.Controls.Add(this.quitBTN);
            this.Controls.Add(this.ConfirmPWordLBL);
            this.Controls.Add(this.PWordLBL);
            this.Controls.Add(this.EmailLBL);
            this.Controls.Add(this.UserNameLBL);
            this.Controls.Add(this.CreateUserBTN);
            this.Controls.Add(this.EmailFLD);
            this.Controls.Add(this.PWordFLD);
            this.Controls.Add(this.ConfirmPWordFLD);
            this.Controls.Add(this.UsernameFLD);
            this.Name = "LuoKTForm";
            this.Text = "Form2";
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
        private System.Windows.Forms.Button quitBTN;
        private System.Windows.Forms.Button BackBTN;
    }
}