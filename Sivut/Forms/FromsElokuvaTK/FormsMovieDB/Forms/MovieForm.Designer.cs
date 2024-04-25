namespace FormsMovieDB
{
    partial class MovieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieForm));
            this.AddToWatchListButton = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this._length = new System.Windows.Forms.Label();
            this.LenghtLable = new System.Windows.Forms.Label();
            this._description = new System.Windows.Forms.Label();
            this.AboutLable = new System.Windows.Forms.Label();
            this._director = new System.Windows.Forms.Label();
            this.DirectorLable = new System.Windows.Forms.Label();
            this._genre = new System.Windows.Forms.Label();
            this.GenreLable = new System.Windows.Forms.Label();
            this.releaseYearLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._releaseYear = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this._rating = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._movieTrailerBrowser = new System.Windows.Forms.WebBrowser();
            this._title = new System.Windows.Forms.Label();
            this._picture = new System.Windows.Forms.PictureBox();
            this.InfoPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picture)).BeginInit();
            this.SuspendLayout();
            // 
            // AddToWatchListButton
            // 
            this.AddToWatchListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this.AddToWatchListButton.FlatAppearance.BorderSize = 0;
            this.AddToWatchListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToWatchListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToWatchListButton.Location = new System.Drawing.Point(763, 526);
            this.AddToWatchListButton.Name = "AddToWatchListButton";
            this.AddToWatchListButton.Size = new System.Drawing.Size(195, 43);
            this.AddToWatchListButton.TabIndex = 3;
            this.AddToWatchListButton.Text = "Add to Watchlist";
            this.AddToWatchListButton.UseVisualStyleBackColor = false;
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.White;
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InfoPanel.Controls.Add(this._length);
            this.InfoPanel.Controls.Add(this.LenghtLable);
            this.InfoPanel.Controls.Add(this._description);
            this.InfoPanel.Controls.Add(this.AboutLable);
            this.InfoPanel.Controls.Add(this._director);
            this.InfoPanel.Controls.Add(this.DirectorLable);
            this.InfoPanel.Controls.Add(this._genre);
            this.InfoPanel.Controls.Add(this.GenreLable);
            this.InfoPanel.Controls.Add(this.releaseYearLable);
            this.InfoPanel.Controls.Add(this.label1);
            this.InfoPanel.Controls.Add(this._releaseYear);
            this.InfoPanel.Location = new System.Drawing.Point(12, 512);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(728, 218);
            this.InfoPanel.TabIndex = 7;
            // 
            // _length
            // 
            this._length.AutoSize = true;
            this._length.BackColor = System.Drawing.Color.Transparent;
            this._length.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._length.ForeColor = System.Drawing.Color.Black;
            this._length.Location = new System.Drawing.Point(79, 93);
            this._length.Name = "_length";
            this._length.Size = new System.Drawing.Size(55, 17);
            this._length.TabIndex = 6;
            this._length.Text = "1h 58m";
            // 
            // LenghtLable
            // 
            this.LenghtLable.AutoSize = true;
            this.LenghtLable.BackColor = System.Drawing.Color.Transparent;
            this.LenghtLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LenghtLable.ForeColor = System.Drawing.Color.Black;
            this.LenghtLable.Location = new System.Drawing.Point(9, 93);
            this.LenghtLable.Name = "LenghtLable";
            this.LenghtLable.Size = new System.Drawing.Size(64, 17);
            this.LenghtLable.TabIndex = 9;
            this.LenghtLable.Text = "Lenght : ";
            // 
            // _description
            // 
            this._description.AutoSize = true;
            this._description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._description.ForeColor = System.Drawing.Color.Black;
            this._description.Location = new System.Drawing.Point(9, 187);
            this._description.Name = "_description";
            this._description.Size = new System.Drawing.Size(632, 15);
            this._description.TabIndex = 1;
            this._description.Text = "Four weeks after a mysterious, incurable virus spreads throughout the UK, a handf" +
    "ul of survivors try to find sanctuary.";
            // 
            // AboutLable
            // 
            this.AboutLable.AutoSize = true;
            this.AboutLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this.AboutLable.Location = new System.Drawing.Point(8, 148);
            this.AboutLable.Name = "AboutLable";
            this.AboutLable.Size = new System.Drawing.Size(62, 22);
            this.AboutLable.TabIndex = 0;
            this.AboutLable.Text = "About";
            // 
            // _director
            // 
            this._director.AutoSize = true;
            this._director.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._director.ForeColor = System.Drawing.Color.Black;
            this._director.Location = new System.Drawing.Point(80, 42);
            this._director.Name = "_director";
            this._director.Size = new System.Drawing.Size(88, 17);
            this._director.TabIndex = 11;
            this._director.Text = "Danny Boyle";
            // 
            // DirectorLable
            // 
            this.DirectorLable.AutoSize = true;
            this.DirectorLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectorLable.ForeColor = System.Drawing.Color.Black;
            this.DirectorLable.Location = new System.Drawing.Point(-2, 40);
            this.DirectorLable.Name = "DirectorLable";
            this.DirectorLable.Size = new System.Drawing.Size(70, 17);
            this.DirectorLable.TabIndex = 8;
            this.DirectorLable.Text = "Director : ";
            // 
            // _genre
            // 
            this._genre.AutoSize = true;
            this._genre.BackColor = System.Drawing.Color.Transparent;
            this._genre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._genre.ForeColor = System.Drawing.Color.Black;
            this._genre.Location = new System.Drawing.Point(79, 68);
            this._genre.Name = "_genre";
            this._genre.Size = new System.Drawing.Size(49, 17);
            this._genre.TabIndex = 14;
            this._genre.Text = "Horror";
            // 
            // GenreLable
            // 
            this.GenreLable.AutoSize = true;
            this.GenreLable.BackColor = System.Drawing.Color.Transparent;
            this.GenreLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreLable.ForeColor = System.Drawing.Color.Black;
            this.GenreLable.Location = new System.Drawing.Point(8, 68);
            this.GenreLable.Name = "GenreLable";
            this.GenreLable.Size = new System.Drawing.Size(60, 17);
            this.GenreLable.TabIndex = 13;
            this.GenreLable.Text = "Genre : ";
            // 
            // releaseYearLable
            // 
            this.releaseYearLable.AutoSize = true;
            this.releaseYearLable.BackColor = System.Drawing.Color.Transparent;
            this.releaseYearLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseYearLable.ForeColor = System.Drawing.Color.Black;
            this.releaseYearLable.Location = new System.Drawing.Point(18, 12);
            this.releaseYearLable.Name = "releaseYearLable";
            this.releaseYearLable.Size = new System.Drawing.Size(50, 17);
            this.releaseYearLable.TabIndex = 10;
            this.releaseYearLable.Text = "Year : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // _releaseYear
            // 
            this._releaseYear.AutoSize = true;
            this._releaseYear.BackColor = System.Drawing.Color.Transparent;
            this._releaseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._releaseYear.ForeColor = System.Drawing.Color.Black;
            this._releaseYear.Location = new System.Drawing.Point(80, 12);
            this._releaseYear.Name = "_releaseYear";
            this._releaseYear.Size = new System.Drawing.Size(40, 17);
            this._releaseYear.TabIndex = 5;
            this._releaseYear.Text = "2002";
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.White;
            this.BottomPanel.Controls.Add(this._rating);
            this.BottomPanel.Controls.Add(this.label2);
            this.BottomPanel.Controls.Add(this.InfoPanel);
            this.BottomPanel.Controls.Add(this.AddToWatchListButton);
            this.BottomPanel.Controls.Add(this._movieTrailerBrowser);
            this.BottomPanel.Controls.Add(this._title);
            this.BottomPanel.Controls.Add(this._picture);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(984, 733);
            this.BottomPanel.TabIndex = 0;
            // 
            // _rating
            // 
            this._rating.AutoSize = true;
            this._rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rating.Location = new System.Drawing.Point(805, 17);
            this._rating.Name = "_rating";
            this._rating.Size = new System.Drawing.Size(111, 20);
            this._rating.TabIndex = 10;
            this._rating.Text = "( rating 1 - 10 )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(729, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rating:";
            // 
            // _movieTrailerBrowser
            // 
            this._movieTrailerBrowser.Location = new System.Drawing.Point(310, 71);
            this._movieTrailerBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._movieTrailerBrowser.Name = "_movieTrailerBrowser";
            this._movieTrailerBrowser.Size = new System.Drawing.Size(648, 421);
            this._movieTrailerBrowser.TabIndex = 2;
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._title.Location = new System.Drawing.Point(12, 9);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(158, 29);
            this._title.TabIndex = 1;
            this._title.Text = "28 Days Later";
            // 
            // _picture
            // 
            this._picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture.Location = new System.Drawing.Point(15, 71);
            this._picture.Name = "_picture";
            this._picture.Size = new System.Drawing.Size(280, 421);
            this._picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture.TabIndex = 0;
            this._picture.TabStop = false;
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(984, 733);
            this.Controls.Add(this.BottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MovieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovieForm";
            this.Load += new System.EventHandler(this.OnMovieFormLoad);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddToWatchListButton;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label _genre;
        private System.Windows.Forms.Label GenreLable;
        private System.Windows.Forms.Label DirectorLable;
        private System.Windows.Forms.Label _director;
        private System.Windows.Forms.Label releaseYearLable;
        private System.Windows.Forms.Label LenghtLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _length;
        private System.Windows.Forms.Label _releaseYear;
        private System.Windows.Forms.Label _description;
        private System.Windows.Forms.Label AboutLable;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label _rating;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser _movieTrailerBrowser;
        private System.Windows.Forms.Label _title;
        private System.Windows.Forms.PictureBox _picture;
    }
}