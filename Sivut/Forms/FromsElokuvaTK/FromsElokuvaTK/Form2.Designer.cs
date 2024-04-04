namespace FromsElokuvaTK
{
    partial class Form2
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
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ConfirmPWord = new System.Windows.Forms.TextBox();
            this.PWord = new System.Windows.Forms.TextBox();
            this.emailLBL = new System.Windows.Forms.Label();
            this.RegisterBTN = new System.Windows.Forms.Button();
            this.passwordLBL = new System.Windows.Forms.Label();
            this.confirmLabel = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(285, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 26);
            this.textBox1.TabIndex = 0;
            // 
            // ConfirmPWord
            // 
            this.ConfirmPWord.Location = new System.Drawing.Point(285, 191);
            this.ConfirmPWord.Name = "ConfirmPWord";
            this.ConfirmPWord.PasswordChar = '*';
            this.ConfirmPWord.Size = new System.Drawing.Size(164, 26);
            this.ConfirmPWord.TabIndex = 1;
            // 
            // PWord
            // 
            this.PWord.Location = new System.Drawing.Point(286, 143);
            this.PWord.Name = "PWord";
            this.PWord.PasswordChar = '*';
            this.PWord.Size = new System.Drawing.Size(164, 26);
            this.PWord.TabIndex = 2;
            // 
            // emailLBL
            // 
            this.emailLBL.AutoSize = true;
            this.emailLBL.Location = new System.Drawing.Point(228, 98);
            this.emailLBL.Name = "emailLBL";
            this.emailLBL.Size = new System.Drawing.Size(52, 20);
            this.emailLBL.TabIndex = 3;
            this.emailLBL.Text = "Email:";
            // 
            // RegisterBTN
            // 
            this.RegisterBTN.Location = new System.Drawing.Point(286, 289);
            this.RegisterBTN.Name = "RegisterBTN";
            this.RegisterBTN.Size = new System.Drawing.Size(164, 49);
            this.RegisterBTN.TabIndex = 4;
            this.RegisterBTN.Text = "Rekisteröidy";
            this.RegisterBTN.UseVisualStyleBackColor = true;
            // 
            // passwordLBL
            // 
            this.passwordLBL.AutoSize = true;
            this.passwordLBL.Location = new System.Drawing.Point(152, 146);
            this.passwordLBL.Name = "passwordLBL";
            this.passwordLBL.Size = new System.Drawing.Size(128, 20);
            this.passwordLBL.TabIndex = 5;
            this.passwordLBL.Text = "Kirjoita salasana:";
            // 
            // confirmLabel
            // 
            this.confirmLabel.AutoSize = true;
            this.confirmLabel.Location = new System.Drawing.Point(138, 197);
            this.confirmLabel.Name = "confirmLabel";
            this.confirmLabel.Size = new System.Drawing.Size(142, 20);
            this.confirmLabel.TabIndex = 6;
            this.confirmLabel.Text = "Vahvista salasana:";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(209, 59);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(70, 20);
            this.Username.TabIndex = 7;
            this.Username.Text = "Käyttäjä:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(285, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 26);
            this.textBox2.TabIndex = 8;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.confirmLabel);
            this.Controls.Add(this.passwordLBL);
            this.Controls.Add(this.RegisterBTN);
            this.Controls.Add(this.emailLBL);
            this.Controls.Add(this.PWord);
            this.Controls.Add(this.ConfirmPWord);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox ConfirmPWord;
        private System.Windows.Forms.TextBox PWord;
        private System.Windows.Forms.Label emailLBL;
        private System.Windows.Forms.Button RegisterBTN;
        private System.Windows.Forms.Label passwordLBL;
        private System.Windows.Forms.Label confirmLabel;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.TextBox textBox2;
    }
}