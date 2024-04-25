namespace FormsMovieDB.Forms
{
    partial class AddMovieForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MovieTextBox = new System.Windows.Forms.RichTextBox();
            this.AddMovieLable = new System.Windows.Forms.Label();
            this.MovieNameLable = new System.Windows.Forms.Label();
            this.GenreTextBox = new System.Windows.Forms.RichTextBox();
            this.YearNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LenghtNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ImageURlTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RatingNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.MovieStarsTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DirectorTextBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TrailerLinkTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DiscriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MoviePoster = new System.Windows.Forms.PictureBox();
            this.AddMovieButton = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YearNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LenghtNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatingNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoviePoster)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 517);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(540, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 517);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.AddMovieButton);
            this.panel3.Controls.Add(this.MoviePoster);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.DiscriptionTextBox);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.TrailerLinkTextBox);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.DirectorTextBox);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.MovieStarsTextBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.RatingNumUpDown);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.ImageURlTextBox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.LenghtNumUpDown);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.YearNumUpDown);
            this.panel3.Controls.Add(this.GenreTextBox);
            this.panel3.Controls.Add(this.MovieNameLable);
            this.panel3.Controls.Add(this.AddMovieLable);
            this.panel3.Controls.Add(this.MovieTextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 517);
            this.panel3.TabIndex = 2;
            // 
            // MovieTextBox
            // 
            this.MovieTextBox.Location = new System.Drawing.Point(64, 74);
            this.MovieTextBox.Name = "MovieTextBox";
            this.MovieTextBox.Size = new System.Drawing.Size(216, 23);
            this.MovieTextBox.TabIndex = 0;
            this.MovieTextBox.Text = "";
            // 
            // AddMovieLable
            // 
            this.AddMovieLable.AutoSize = true;
            this.AddMovieLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMovieLable.Location = new System.Drawing.Point(37, 22);
            this.AddMovieLable.Name = "AddMovieLable";
            this.AddMovieLable.Size = new System.Drawing.Size(127, 29);
            this.AddMovieLable.TabIndex = 1;
            this.AddMovieLable.Text = "Add Movie";
            // 
            // MovieNameLable
            // 
            this.MovieNameLable.AutoSize = true;
            this.MovieNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieNameLable.Location = new System.Drawing.Point(60, 51);
            this.MovieNameLable.Name = "MovieNameLable";
            this.MovieNameLable.Size = new System.Drawing.Size(38, 20);
            this.MovieNameLable.TabIndex = 2;
            this.MovieNameLable.Text = "Title";
            // 
            // GenreTextBox
            // 
            this.GenreTextBox.Location = new System.Drawing.Point(64, 200);
            this.GenreTextBox.Name = "GenreTextBox";
            this.GenreTextBox.Size = new System.Drawing.Size(216, 24);
            this.GenreTextBox.TabIndex = 3;
            this.GenreTextBox.Text = "";
            // 
            // YearNumUpDown
            // 
            this.YearNumUpDown.Location = new System.Drawing.Point(170, 159);
            this.YearNumUpDown.Maximum = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.YearNumUpDown.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.YearNumUpDown.Name = "YearNumUpDown";
            this.YearNumUpDown.Size = new System.Drawing.Size(110, 20);
            this.YearNumUpDown.TabIndex = 4;
            this.YearNumUpDown.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lenght (min)";
            // 
            // LenghtNumUpDown
            // 
            this.LenghtNumUpDown.Location = new System.Drawing.Point(64, 159);
            this.LenghtNumUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.LenghtNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LenghtNumUpDown.Name = "LenghtNumUpDown";
            this.LenghtNumUpDown.Size = new System.Drawing.Size(100, 20);
            this.LenghtNumUpDown.TabIndex = 7;
            this.LenghtNumUpDown.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Genre";
            // 
            // ImageURlTextBox
            // 
            this.ImageURlTextBox.Location = new System.Drawing.Point(126, 243);
            this.ImageURlTextBox.Name = "ImageURlTextBox";
            this.ImageURlTextBox.Size = new System.Drawing.Size(154, 27);
            this.ImageURlTextBox.TabIndex = 9;
            this.ImageURlTextBox.Text = "";
            this.ImageURlTextBox.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(123, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Image (URL)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // RatingNumUpDown
            // 
            this.RatingNumUpDown.Location = new System.Drawing.Point(64, 118);
            this.RatingNumUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RatingNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RatingNumUpDown.Name = "RatingNumUpDown";
            this.RatingNumUpDown.Size = new System.Drawing.Size(216, 20);
            this.RatingNumUpDown.TabIndex = 12;
            this.RatingNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(61, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Rating";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // MovieStarsTextBox
            // 
            this.MovieStarsTextBox.Location = new System.Drawing.Point(64, 337);
            this.MovieStarsTextBox.Name = "MovieStarsTextBox";
            this.MovieStarsTextBox.Size = new System.Drawing.Size(216, 24);
            this.MovieStarsTextBox.TabIndex = 14;
            this.MovieStarsTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Movie Star";
            // 
            // DirectorTextBox
            // 
            this.DirectorTextBox.Location = new System.Drawing.Point(64, 381);
            this.DirectorTextBox.Name = "DirectorTextBox";
            this.DirectorTextBox.Size = new System.Drawing.Size(216, 24);
            this.DirectorTextBox.TabIndex = 16;
            this.DirectorTextBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Director";
            // 
            // TrailerLinkTextBox
            // 
            this.TrailerLinkTextBox.Location = new System.Drawing.Point(126, 291);
            this.TrailerLinkTextBox.Name = "TrailerLinkTextBox";
            this.TrailerLinkTextBox.Size = new System.Drawing.Size(154, 25);
            this.TrailerLinkTextBox.TabIndex = 18;
            this.TrailerLinkTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(123, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Trailer link";
            // 
            // DiscriptionTextBox
            // 
            this.DiscriptionTextBox.Location = new System.Drawing.Point(64, 426);
            this.DiscriptionTextBox.Name = "DiscriptionTextBox";
            this.DiscriptionTextBox.Size = new System.Drawing.Size(216, 35);
            this.DiscriptionTextBox.TabIndex = 20;
            this.DiscriptionTextBox.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(61, 408);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Discription";
            // 
            // MoviePoster
            // 
            this.MoviePoster.Location = new System.Drawing.Point(64, 230);
            this.MoviePoster.Name = "MoviePoster";
            this.MoviePoster.Size = new System.Drawing.Size(56, 73);
            this.MoviePoster.TabIndex = 22;
            this.MoviePoster.TabStop = false;
            // 
            // AddMovieButton
            // 
            this.AddMovieButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(0)))));
            this.AddMovieButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddMovieButton.FlatAppearance.BorderSize = 0;
            this.AddMovieButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddMovieButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMovieButton.Location = new System.Drawing.Point(96, 467);
            this.AddMovieButton.Name = "AddMovieButton";
            this.AddMovieButton.Size = new System.Drawing.Size(155, 38);
            this.AddMovieButton.TabIndex = 23;
            this.AddMovieButton.Text = "Add movie";
            this.AddMovieButton.UseVisualStyleBackColor = false;
            // 
            // AddMovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 517);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "AddMovieForm";
            this.Text = "AddMovieForm";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YearNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LenghtNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatingNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoviePoster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label MovieNameLable;
        private System.Windows.Forms.Label AddMovieLable;
        private System.Windows.Forms.RichTextBox MovieTextBox;
        private System.Windows.Forms.NumericUpDown LenghtNumUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown YearNumUpDown;
        private System.Windows.Forms.RichTextBox GenreTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown RatingNumUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox ImageURlTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox DiscriptionTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox TrailerLinkTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox DirectorTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox MovieStarsTextBox;
        private System.Windows.Forms.PictureBox MoviePoster;
        private System.Windows.Forms.Button AddMovieButton;
    }
}