namespace FromsElokuvaTK
{
    partial class StartForm
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
            this.SignUpBTN = new System.Windows.Forms.Button();
            this.LoginBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SignUpBTN
            // 
            this.SignUpBTN.BackColor = System.Drawing.Color.BlueViolet;
            this.SignUpBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.SignUpBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SignUpBTN.Location = new System.Drawing.Point(214, 161);
            this.SignUpBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SignUpBTN.Name = "SignUpBTN";
            this.SignUpBTN.Size = new System.Drawing.Size(165, 84);
            this.SignUpBTN.TabIndex = 3;
            this.SignUpBTN.Text = "Luo käyttäjä";
            this.SignUpBTN.UseVisualStyleBackColor = false;
            this.SignUpBTN.Click += new System.EventHandler(this.SignUpBTN_Click);
            // 
            // LoginBTN
            // 
            this.LoginBTN.BackColor = System.Drawing.Color.BlueViolet;
            this.LoginBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LoginBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoginBTN.Location = new System.Drawing.Point(477, 161);
            this.LoginBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(165, 84);
            this.LoginBTN.TabIndex = 4;
            this.LoginBTN.Text = "Kirjaudu";
            this.LoginBTN.UseVisualStyleBackColor = false;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 477);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.SignUpBTN);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StartForm";
            this.Text = "Elokuvatietokanta";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SignUpBTN;
        private System.Windows.Forms.Button LoginBTN;
    }
}

