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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // SignUpBTN
            // 
            this.SignUpBTN.BackColor = System.Drawing.Color.BlueViolet;
            this.SignUpBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.SignUpBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SignUpBTN.Location = new System.Drawing.Point(241, 201);
            this.SignUpBTN.Name = "SignUpBTN";
            this.SignUpBTN.Size = new System.Drawing.Size(186, 105);
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
            this.LoginBTN.Location = new System.Drawing.Point(537, 201);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(186, 105);
            this.LoginBTN.TabIndex = 4;
            this.LoginBTN.Text = "Kirjaudu";
            this.LoginBTN.UseVisualStyleBackColor = false;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
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
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SignUpBTN;
        private System.Windows.Forms.Button LoginBTN;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

