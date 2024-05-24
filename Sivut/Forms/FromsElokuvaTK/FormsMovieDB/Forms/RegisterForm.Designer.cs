namespace FormsMovieDB
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this._returnButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._emailInputField = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._usernameInputField = new System.Windows.Forms.RichTextBox();
            this._submitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._passwordInputField = new System.Windows.Forms.TextBox();
            this._rePasswordInputField = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Location = new System.Drawing.Point(1152, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 783);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 783);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(300, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(852, 783);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this._rePasswordInputField);
            this.panel4.Controls.Add(this._passwordInputField);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this._returnButton);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this._emailInputField);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this._usernameInputField);
            this.panel4.Controls.Add(this._submitButton);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(223, 99);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(467, 561);
            this.panel4.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(191, 458);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = " - Or -";
            // 
            // _returnButton
            // 
            this._returnButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._returnButton.BackColor = System.Drawing.Color.White;
            this._returnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._returnButton.FlatAppearance.BorderSize = 0;
            this._returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._returnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._returnButton.Location = new System.Drawing.Point(121, 493);
            this._returnButton.Margin = new System.Windows.Forms.Padding(4);
            this._returnButton.Name = "_returnButton";
            this._returnButton.Size = new System.Drawing.Size(207, 44);
            this._returnButton.TabIndex = 6;
            this._returnButton.Text = "Back";
            this._returnButton.UseVisualStyleBackColor = false;
            this._returnButton.Click += new System.EventHandler(this.OnReturnButtonClick);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 44);
            this.label5.TabIndex = 11;
            this.label5.Text = "Create Account";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 304);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Re-enter Password";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 240);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // _emailInputField
            // 
            this._emailInputField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._emailInputField.Location = new System.Drawing.Point(59, 189);
            this._emailInputField.Margin = new System.Windows.Forms.Padding(4);
            this._emailInputField.Name = "_emailInputField";
            this._emailInputField.Size = new System.Drawing.Size(336, 36);
            this._emailInputField.TabIndex = 2;
            this._emailInputField.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 4;
            // 
            // _usernameInputField
            // 
            this._usernameInputField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._usernameInputField.Location = new System.Drawing.Point(59, 122);
            this._usernameInputField.Margin = new System.Windows.Forms.Padding(4);
            this._usernameInputField.Name = "_usernameInputField";
            this._usernameInputField.Size = new System.Drawing.Size(336, 36);
            this._usernameInputField.TabIndex = 1;
            this._usernameInputField.Text = "";
            // 
            // _submitButton
            // 
            this._submitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this._submitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._submitButton.FlatAppearance.BorderSize = 0;
            this._submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._submitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._submitButton.Location = new System.Drawing.Point(121, 391);
            this._submitButton.Margin = new System.Windows.Forms.Padding(4);
            this._submitButton.Name = "_submitButton";
            this._submitButton.Size = new System.Drawing.Size(207, 44);
            this._submitButton.TabIndex = 5;
            this._submitButton.Text = "Submit";
            this._submitButton.UseVisualStyleBackColor = false;
            this._submitButton.Click += new System.EventHandler(this.OnSubmitButtonClicked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // _passwordInputField
            // 
            this._passwordInputField.Location = new System.Drawing.Point(59, 263);
            this._passwordInputField.Name = "_passwordInputField";
            this._passwordInputField.PasswordChar = '*';
            this._passwordInputField.Size = new System.Drawing.Size(336, 26);
            this._passwordInputField.TabIndex = 3;
            // 
            // _rePasswordInputField
            // 
            this._rePasswordInputField.Location = new System.Drawing.Point(59, 327);
            this._rePasswordInputField.Name = "_rePasswordInputField";
            this._rePasswordInputField.PasswordChar = '*';
            this._rePasswordInputField.Size = new System.Drawing.Size(336, 26);
            this._rePasswordInputField.TabIndex = 4;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1452, 783);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox _emailInputField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox _usernameInputField;
        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.Button _returnButton;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _passwordInputField;
        private System.Windows.Forms.TextBox _rePasswordInputField;
    }
}