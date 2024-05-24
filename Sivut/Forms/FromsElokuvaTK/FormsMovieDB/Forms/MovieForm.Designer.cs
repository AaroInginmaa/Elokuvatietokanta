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
            this.InfoPanel = new System.Windows.Forms.Panel();
            this._mainactors = new System.Windows.Forms.Label();
            this._rating = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._length = new System.Windows.Forms.Label();
            this.LenghtLable = new System.Windows.Forms.Label();
            this._director = new System.Windows.Forms.Label();
            this.DirectorLable = new System.Windows.Forms.Label();
            this._genre = new System.Windows.Forms.Label();
            this.GenreLable = new System.Windows.Forms.Label();
            this.releaseYearLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._releaseYear = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this._title = new System.Windows.Forms.Label();
            this._picture = new System.Windows.Forms.PictureBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.InfoPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picture)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.White;
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InfoPanel.Controls.Add(this._mainactors);
            this.InfoPanel.Controls.Add(this._rating);
            this.InfoPanel.Controls.Add(this.label3);
            this.InfoPanel.Controls.Add(this.label2);
            this.InfoPanel.Controls.Add(this._length);
            this.InfoPanel.Controls.Add(this.LenghtLable);
            this.InfoPanel.Controls.Add(this._director);
            this.InfoPanel.Controls.Add(this.DirectorLable);
            this.InfoPanel.Controls.Add(this._genre);
            this.InfoPanel.Controls.Add(this.GenreLable);
            this.InfoPanel.Controls.Add(this.releaseYearLable);
            this.InfoPanel.Controls.Add(this.label1);
            this.InfoPanel.Controls.Add(this._releaseYear);
            this.InfoPanel.Location = new System.Drawing.Point(549, 155);
            this.InfoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(764, 583);
            this.InfoPanel.TabIndex = 7;
            // 
            // _mainactors
            // 
            this._mainactors.AutoSize = true;
            this._mainactors.BackColor = System.Drawing.Color.Transparent;
            this._mainactors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._mainactors.ForeColor = System.Drawing.Color.Black;
            this._mainactors.Location = new System.Drawing.Point(133, 185);
            this._mainactors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._mainactors.Name = "_mainactors";
            this._mainactors.Size = new System.Drawing.Size(112, 25);
            this._mainactors.TabIndex = 16;
            this._mainactors.Text = "Actors here";
            // 
            // _rating
            // 
            this._rating.AutoSize = true;
            this._rating.BackColor = System.Drawing.Color.Transparent;
            this._rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rating.Location = new System.Drawing.Point(120, 230);
            this._rating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._rating.Name = "_rating";
            this._rating.Size = new System.Drawing.Size(153, 29);
            this._rating.TabIndex = 9;
            this._rating.Text = "Rating 1 - 10 ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(-2, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Main Actors :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 230);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rating:";
            // 
            // _length
            // 
            this._length.AutoSize = true;
            this._length.BackColor = System.Drawing.Color.Transparent;
            this._length.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._length.ForeColor = System.Drawing.Color.Black;
            this._length.Location = new System.Drawing.Point(118, 140);
            this._length.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._length.Name = "_length";
            this._length.Size = new System.Drawing.Size(77, 25);
            this._length.TabIndex = 6;
            this._length.Text = "1h 58m";
            // 
            // LenghtLable
            // 
            this.LenghtLable.AutoSize = true;
            this.LenghtLable.BackColor = System.Drawing.Color.Transparent;
            this.LenghtLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LenghtLable.ForeColor = System.Drawing.Color.Black;
            this.LenghtLable.Location = new System.Drawing.Point(14, 140);
            this.LenghtLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LenghtLable.Name = "LenghtLable";
            this.LenghtLable.Size = new System.Drawing.Size(88, 25);
            this.LenghtLable.TabIndex = 9;
            this.LenghtLable.Text = "Length : ";
            // 
            // _director
            // 
            this._director.AutoSize = true;
            this._director.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._director.ForeColor = System.Drawing.Color.Black;
            this._director.Location = new System.Drawing.Point(120, 63);
            this._director.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._director.Name = "_director";
            this._director.Size = new System.Drawing.Size(123, 25);
            this._director.TabIndex = 11;
            this._director.Text = "Danny Boyle";
            // 
            // DirectorLable
            // 
            this.DirectorLable.AutoSize = true;
            this.DirectorLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectorLable.ForeColor = System.Drawing.Color.Black;
            this.DirectorLable.Location = new System.Drawing.Point(-3, 60);
            this.DirectorLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DirectorLable.Name = "DirectorLable";
            this.DirectorLable.Size = new System.Drawing.Size(95, 25);
            this.DirectorLable.TabIndex = 8;
            this.DirectorLable.Text = "Director : ";
            // 
            // _genre
            // 
            this._genre.AutoSize = true;
            this._genre.BackColor = System.Drawing.Color.Transparent;
            this._genre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._genre.ForeColor = System.Drawing.Color.Black;
            this._genre.Location = new System.Drawing.Point(118, 102);
            this._genre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._genre.Name = "_genre";
            this._genre.Size = new System.Drawing.Size(66, 25);
            this._genre.TabIndex = 14;
            this._genre.Text = "Horror";
            // 
            // GenreLable
            // 
            this.GenreLable.AutoSize = true;
            this.GenreLable.BackColor = System.Drawing.Color.Transparent;
            this.GenreLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreLable.ForeColor = System.Drawing.Color.Black;
            this.GenreLable.Location = new System.Drawing.Point(12, 102);
            this.GenreLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GenreLable.Name = "GenreLable";
            this.GenreLable.Size = new System.Drawing.Size(82, 25);
            this.GenreLable.TabIndex = 13;
            this.GenreLable.Text = "Genre : ";
            // 
            // releaseYearLable
            // 
            this.releaseYearLable.AutoSize = true;
            this.releaseYearLable.BackColor = System.Drawing.Color.Transparent;
            this.releaseYearLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseYearLable.ForeColor = System.Drawing.Color.Black;
            this.releaseYearLable.Location = new System.Drawing.Point(27, 18);
            this.releaseYearLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.releaseYearLable.Name = "releaseYearLable";
            this.releaseYearLable.Size = new System.Drawing.Size(69, 25);
            this.releaseYearLable.TabIndex = 10;
            this.releaseYearLable.Text = "Year : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 7;
            // 
            // _releaseYear
            // 
            this._releaseYear.AutoSize = true;
            this._releaseYear.BackColor = System.Drawing.Color.Transparent;
            this._releaseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._releaseYear.ForeColor = System.Drawing.Color.Black;
            this._releaseYear.Location = new System.Drawing.Point(120, 18);
            this._releaseYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._releaseYear.Name = "_releaseYear";
            this._releaseYear.Size = new System.Drawing.Size(56, 25);
            this._releaseYear.TabIndex = 5;
            this._releaseYear.Text = "2002";
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.White;
            this.BottomPanel.Controls.Add(this.BackButton);
            this.BottomPanel.Controls.Add(this.InfoPanel);
            this.BottomPanel.Controls.Add(this._title);
            this.BottomPanel.Controls.Add(this._picture);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(4);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1500, 1200);
            this.BottomPanel.TabIndex = 0;
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._title.Location = new System.Drawing.Point(18, 14);
            this._title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(241, 40);
            this._title.TabIndex = 1;
            this._title.Text = "28 Days Later";
            // 
            // _picture
            // 
            this._picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._picture.Location = new System.Drawing.Point(22, 106);
            this._picture.Margin = new System.Windows.Forms.Padding(4);
            this._picture.Name = "_picture";
            this._picture.Size = new System.Drawing.Size(420, 632);
            this._picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._picture.TabIndex = 0;
            this._picture.TabStop = false;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Gold;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BackButton.Location = new System.Drawing.Point(1202, 23);
            this.BackButton.Name = "BackButton";
            this.BackButton.Padding = new System.Windows.Forms.Padding(2);
            this.BackButton.Size = new System.Drawing.Size(220, 79);
            this.BackButton.TabIndex = 8;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.OnBackButtonClick);
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1500, 1200);
            this.Controls.Add(this.BottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label _rating;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _title;
        private System.Windows.Forms.PictureBox _picture;
        private System.Windows.Forms.Label _mainactors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BackButton;
    }
}