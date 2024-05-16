namespace FormsMovieDB
{
    partial class SignInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.SignInPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._createAccountButton = new System.Windows.Forms.Button();
            this._signInButtonClicked = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._loginInputField = new System.Windows.Forms.RichTextBox();
            this.SignInLable = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._passwordInputField = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.SignInPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.SignInPanel);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel3.Location = new System.Drawing.Point(300, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(852, 783);
            this.panel3.TabIndex = 2;
            // 
            // SignInPanel
            // 
            this.SignInPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SignInPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SignInPanel.Controls.Add(this._passwordInputField);
            this.SignInPanel.Controls.Add(this.label3);
            this.SignInPanel.Controls.Add(this.label2);
            this.SignInPanel.Controls.Add(this._createAccountButton);
            this.SignInPanel.Controls.Add(this._signInButtonClicked);
            this.SignInPanel.Controls.Add(this.label1);
            this.SignInPanel.Controls.Add(this._loginInputField);
            this.SignInPanel.Controls.Add(this.SignInLable);
            this.SignInPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SignInPanel.Location = new System.Drawing.Point(208, 110);
            this.SignInPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SignInPanel.Name = "SignInPanel";
            this.SignInPanel.Size = new System.Drawing.Size(492, 526);
            this.SignInPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 386);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = " - Or -";
            // 
            // _createAccountButton
            // 
            this._createAccountButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._createAccountButton.BackColor = System.Drawing.Color.White;
            this._createAccountButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._createAccountButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this._createAccountButton.FlatAppearance.BorderSize = 0;
            this._createAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._createAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._createAccountButton.ForeColor = System.Drawing.Color.Black;
            this._createAccountButton.Location = new System.Drawing.Point(78, 428);
            this._createAccountButton.Margin = new System.Windows.Forms.Padding(4);
            this._createAccountButton.Name = "_createAccountButton";
            this._createAccountButton.Size = new System.Drawing.Size(334, 50);
            this._createAccountButton.TabIndex = 4;
            this._createAccountButton.Text = "Create account";
            this._createAccountButton.UseVisualStyleBackColor = false;
            this._createAccountButton.Click += new System.EventHandler(this.OnCreateAccountButtonClick);
            // 
            // _signInButtonClicked
            // 
            this._signInButtonClicked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this._signInButtonClicked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._signInButtonClicked.Cursor = System.Windows.Forms.Cursors.Hand;
            this._signInButtonClicked.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this._signInButtonClicked.FlatAppearance.BorderSize = 0;
            this._signInButtonClicked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._signInButtonClicked.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._signInButtonClicked.Location = new System.Drawing.Point(74, 314);
            this._signInButtonClicked.Margin = new System.Windows.Forms.Padding(4);
            this._signInButtonClicked.Name = "_signInButtonClicked";
            this._signInButtonClicked.Size = new System.Drawing.Size(342, 56);
            this._signInButtonClicked.TabIndex = 3;
            this._signInButtonClicked.Text = "Sign In";
            this._signInButtonClicked.UseVisualStyleBackColor = false;
            this._signInButtonClicked.Click += new System.EventHandler(this.OnSignInButtonClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username or Email";
            // 
            // _loginInputField
            // 
            this._loginInputField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._loginInputField.Location = new System.Drawing.Point(75, 129);
            this._loginInputField.Margin = new System.Windows.Forms.Padding(4);
            this._loginInputField.Name = "_loginInputField";
            this._loginInputField.Size = new System.Drawing.Size(340, 38);
            this._loginInputField.TabIndex = 1;
            this._loginInputField.Text = "";
            // 
            // SignInLable
            // 
            this.SignInLable.AutoSize = true;
            this.SignInLable.Cursor = System.Windows.Forms.Cursors.Default;
            this.SignInLable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignInLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInLable.Location = new System.Drawing.Point(68, 27);
            this.SignInLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SignInLable.Name = "SignInLable";
            this.SignInLable.Size = new System.Drawing.Size(136, 44);
            this.SignInLable.TabIndex = 0;
            this.SignInLable.Text = "Sign In";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 783);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Location = new System.Drawing.Point(1152, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 783);
            this.panel2.TabIndex = 1;
            // 
            // _passwordInputField
            // 
            this._passwordInputField.Location = new System.Drawing.Point(74, 227);
            this._passwordInputField.Name = "_passwordInputField";
            this._passwordInputField.PasswordChar = '*';
            this._passwordInputField.Size = new System.Drawing.Size(342, 26);
            this._passwordInputField.TabIndex = 2;
            // 
            // SignInForm
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
            this.Name = "SignInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign In";
            this.panel3.ResumeLayout(false);
            this.SignInPanel.ResumeLayout(false);
            this.SignInPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel SignInPanel;
        private System.Windows.Forms.Button _createAccountButton;
        private System.Windows.Forms.Button _signInButtonClicked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox _loginInputField;
        private System.Windows.Forms.Label SignInLable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _passwordInputField;
    }
}