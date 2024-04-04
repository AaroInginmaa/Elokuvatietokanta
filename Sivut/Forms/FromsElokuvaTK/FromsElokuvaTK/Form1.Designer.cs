namespace FromsElokuvaTK
{
    partial class Form1
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
            this.SignUpBTN.Location = new System.Drawing.Point(541, 176);
            this.SignUpBTN.Name = "SignUpBTN";
            this.SignUpBTN.Size = new System.Drawing.Size(186, 150);
            this.SignUpBTN.TabIndex = 3;
            this.SignUpBTN.Text = "Luo käyttäjä";
            this.SignUpBTN.UseVisualStyleBackColor = true;
            this.SignUpBTN.Click += new System.EventHandler(this.SignUpBTN_Click);
            // 
            // LoginBTN
            // 
            this.LoginBTN.Location = new System.Drawing.Point(229, 176);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(186, 150);
            this.LoginBTN.TabIndex = 4;
            this.LoginBTN.Text = "Kirjaudu";
            this.LoginBTN.UseVisualStyleBackColor = true;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 596);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.SignUpBTN);
            this.Name = "Form1";
            this.Text = "Elokuvatietokanta";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SignUpBTN;
        private System.Windows.Forms.Button LoginBTN;
    }
}

