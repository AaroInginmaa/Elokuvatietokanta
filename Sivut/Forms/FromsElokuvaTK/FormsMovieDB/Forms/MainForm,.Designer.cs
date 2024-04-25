namespace FormsMovieDB
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._sideNavigationPanel = new System.Windows.Forms.Panel();
            this._panel1 = new System.Windows.Forms.Panel();
            this._menuButton = new System.Windows.Forms.Button();
            this._topSidePanel = new System.Windows.Forms.Panel();
            this._profileButton = new System.Windows.Forms.Button();
            this._parentPanel = new System.Windows.Forms.Panel();
            this._sideNavigationPanel.SuspendLayout();
            this._topSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _sideNavigationPanel
            // 
            this._sideNavigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(34)))));
            this._sideNavigationPanel.Controls.Add(this._panel1);
            this._sideNavigationPanel.Controls.Add(this._menuButton);
            this._sideNavigationPanel.Controls.Add(this._topSidePanel);
            this._sideNavigationPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._sideNavigationPanel.Location = new System.Drawing.Point(0, 0);
            this._sideNavigationPanel.Name = "_sideNavigationPanel";
            this._sideNavigationPanel.Size = new System.Drawing.Size(267, 1024);
            this._sideNavigationPanel.TabIndex = 0;
            // 
            // _panel1
            // 
            this._panel1.BackColor = System.Drawing.Color.Black;
            this._panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel1.Location = new System.Drawing.Point(0, 168);
            this._panel1.Name = "_panel1";
            this._panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._panel1.Size = new System.Drawing.Size(267, 856);
            this._panel1.TabIndex = 2;
            // 
            // _menuButton
            // 
            this._menuButton.BackColor = System.Drawing.Color.Black;
            this._menuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._menuButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._menuButton.FlatAppearance.BorderSize = 0;
            this._menuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(72)))), ((int)(((byte)(68)))));
            this._menuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(40)))));
            this._menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._menuButton.ForeColor = System.Drawing.Color.White;
            this._menuButton.Location = new System.Drawing.Point(0, 88);
            this._menuButton.Name = "_menuButton";
            this._menuButton.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this._menuButton.Size = new System.Drawing.Size(267, 80);
            this._menuButton.TabIndex = 1;
            this._menuButton.Text = "Movies";
            this._menuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._menuButton.UseVisualStyleBackColor = false;
            this._menuButton.Click += new System.EventHandler(this.OnMoviesButtonClick);
            // 
            // _topSidePanel
            // 
            this._topSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this._topSidePanel.Controls.Add(this._profileButton);
            this._topSidePanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._topSidePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._topSidePanel.Location = new System.Drawing.Point(0, 0);
            this._topSidePanel.Name = "_topSidePanel";
            this._topSidePanel.Size = new System.Drawing.Size(267, 88);
            this._topSidePanel.TabIndex = 0;
            // 
            // _profileButton
            // 
            this._profileButton.FlatAppearance.BorderSize = 0;
            this._profileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._profileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._profileButton.Location = new System.Drawing.Point(0, 0);
            this._profileButton.Name = "_profileButton";
            this._profileButton.Size = new System.Drawing.Size(267, 88);
            this._profileButton.TabIndex = 0;
            this._profileButton.Text = "Profile";
            this._profileButton.UseVisualStyleBackColor = true;
            this._profileButton.Click += new System.EventHandler(this.OnProfileButtonClick);
            // 
            // _parentPanel
            // 
            this._parentPanel.BackColor = System.Drawing.Color.White;
            this._parentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._parentPanel.Location = new System.Drawing.Point(267, 0);
            this._parentPanel.Name = "_parentPanel";
            this._parentPanel.Size = new System.Drawing.Size(1631, 1024);
            this._parentPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this._parentPanel);
            this.Controls.Add(this._sideNavigationPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.Text = "MoviesDB";
            this._sideNavigationPanel.ResumeLayout(false);
            this._topSidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _sideNavigationPanel;
        private System.Windows.Forms.Panel _topSidePanel;
        private System.Windows.Forms.Panel _panel1;
        private System.Windows.Forms.Button _menuButton;
        private System.Windows.Forms.Panel _parentPanel;
        private System.Windows.Forms.Button _profileButton;
    }
}