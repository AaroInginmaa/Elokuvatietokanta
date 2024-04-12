namespace FromsElokuvaTK
{
    partial class InsertForm
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
            this.nameInput = new System.Windows.Forms.TextBox();
            this.nameInputLabel = new System.Windows.Forms.Label();
            this.directorInputLabel = new System.Windows.Forms.Label();
            this.directorInput = new System.Windows.Forms.TextBox();
            this.yearInputLabel = new System.Windows.Forms.Label();
            this.lengthInputLabel = new System.Windows.Forms.Label();
            this.genreInputLabel = new System.Windows.Forms.Label();
            this.genreInput = new System.Windows.Forms.TextBox();
            this.insertbutton = new System.Windows.Forms.Button();
            this.lengthInput = new System.Windows.Forms.NumericUpDown();
            this.ratingInput = new System.Windows.Forms.NumericUpDown();
            this.ratingInputLabel = new System.Windows.Forms.Label();
            this.mainactorInputLabel = new System.Windows.Forms.Label();
            this.mainactorInput = new System.Windows.Forms.TextBox();
            this.yearInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.lengthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearInput)).BeginInit();
            this.SuspendLayout();
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(15, 28);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(150, 22);
            this.nameInput.TabIndex = 0;
            // 
            // nameInputLabel
            // 
            this.nameInputLabel.AutoSize = true;
            this.nameInputLabel.Location = new System.Drawing.Point(12, 9);
            this.nameInputLabel.Name = "nameInputLabel";
            this.nameInputLabel.Size = new System.Drawing.Size(34, 16);
            this.nameInputLabel.TabIndex = 1;
            this.nameInputLabel.Text = "Nimi";
            // 
            // directorInputLabel
            // 
            this.directorInputLabel.AutoSize = true;
            this.directorInputLabel.Location = new System.Drawing.Point(12, 53);
            this.directorInputLabel.Name = "directorInputLabel";
            this.directorInputLabel.Size = new System.Drawing.Size(54, 16);
            this.directorInputLabel.TabIndex = 3;
            this.directorInputLabel.Text = "Ohjaaja";
            // 
            // directorInput
            // 
            this.directorInput.Location = new System.Drawing.Point(15, 72);
            this.directorInput.Name = "directorInput";
            this.directorInput.Size = new System.Drawing.Size(150, 22);
            this.directorInput.TabIndex = 2;
            // 
            // yearInputLabel
            // 
            this.yearInputLabel.AutoSize = true;
            this.yearInputLabel.Location = new System.Drawing.Point(12, 97);
            this.yearInputLabel.Name = "yearInputLabel";
            this.yearInputLabel.Size = new System.Drawing.Size(88, 16);
            this.yearInputLabel.TabIndex = 5;
            this.yearInputLabel.Text = "Julkaisuvuosi";
            // 
            // lengthInputLabel
            // 
            this.lengthInputLabel.AutoSize = true;
            this.lengthInputLabel.Location = new System.Drawing.Point(12, 141);
            this.lengthInputLabel.Name = "lengthInputLabel";
            this.lengthInputLabel.Size = new System.Drawing.Size(73, 16);
            this.lengthInputLabel.TabIndex = 7;
            this.lengthInputLabel.Text = "Kesto (min)";
            // 
            // genreInputLabel
            // 
            this.genreInputLabel.AutoSize = true;
            this.genreInputLabel.Location = new System.Drawing.Point(12, 185);
            this.genreInputLabel.Name = "genreInputLabel";
            this.genreInputLabel.Size = new System.Drawing.Size(44, 16);
            this.genreInputLabel.TabIndex = 9;
            this.genreInputLabel.Text = "Genre";
            // 
            // genreInput
            // 
            this.genreInput.Location = new System.Drawing.Point(15, 204);
            this.genreInput.Name = "genreInput";
            this.genreInput.Size = new System.Drawing.Size(150, 22);
            this.genreInput.TabIndex = 8;
            // 
            // insertbutton
            // 
            this.insertbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insertbutton.Location = new System.Drawing.Point(15, 320);
            this.insertbutton.Name = "insertbutton";
            this.insertbutton.Size = new System.Drawing.Size(355, 41);
            this.insertbutton.TabIndex = 10;
            this.insertbutton.Text = "Create";
            this.insertbutton.UseVisualStyleBackColor = true;
            this.insertbutton.Click += new System.EventHandler(this.insertbutton_Click);
            // 
            // lengthInput
            // 
            this.lengthInput.Location = new System.Drawing.Point(15, 160);
            this.lengthInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.lengthInput.Name = "lengthInput";
            this.lengthInput.Size = new System.Drawing.Size(150, 22);
            this.lengthInput.TabIndex = 11;
            // 
            // ratingInput
            // 
            this.ratingInput.Location = new System.Drawing.Point(15, 292);
            this.ratingInput.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ratingInput.Name = "ratingInput";
            this.ratingInput.Size = new System.Drawing.Size(150, 22);
            this.ratingInput.TabIndex = 12;
            // 
            // ratingInputLabel
            // 
            this.ratingInputLabel.AutoSize = true;
            this.ratingInputLabel.Location = new System.Drawing.Point(12, 273);
            this.ratingInputLabel.Name = "ratingInputLabel";
            this.ratingInputLabel.Size = new System.Drawing.Size(99, 16);
            this.ratingInputLabel.TabIndex = 13;
            this.ratingInputLabel.Text = "Arvostelu (1-10)";
            // 
            // mainactorInputLabel
            // 
            this.mainactorInputLabel.AutoSize = true;
            this.mainactorInputLabel.Location = new System.Drawing.Point(12, 229);
            this.mainactorInputLabel.Name = "mainactorInputLabel";
            this.mainactorInputLabel.Size = new System.Drawing.Size(91, 16);
            this.mainactorInputLabel.TabIndex = 15;
            this.mainactorInputLabel.Text = "Pää Näyttelijä";
            // 
            // mainactorInput
            // 
            this.mainactorInput.Location = new System.Drawing.Point(15, 248);
            this.mainactorInput.Name = "mainactorInput";
            this.mainactorInput.Size = new System.Drawing.Size(150, 22);
            this.mainactorInput.TabIndex = 14;
            // 
            // yearInput
            // 
            this.yearInput.Location = new System.Drawing.Point(15, 116);
            this.yearInput.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.yearInput.Minimum = new decimal(new int[] {
            1888,
            0,
            0,
            0});
            this.yearInput.Name = "yearInput";
            this.yearInput.Size = new System.Drawing.Size(150, 22);
            this.yearInput.TabIndex = 16;
            this.yearInput.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 373);
            this.Controls.Add(this.yearInput);
            this.Controls.Add(this.mainactorInputLabel);
            this.Controls.Add(this.mainactorInput);
            this.Controls.Add(this.ratingInputLabel);
            this.Controls.Add(this.ratingInput);
            this.Controls.Add(this.lengthInput);
            this.Controls.Add(this.insertbutton);
            this.Controls.Add(this.genreInputLabel);
            this.Controls.Add(this.genreInput);
            this.Controls.Add(this.lengthInputLabel);
            this.Controls.Add(this.yearInputLabel);
            this.Controls.Add(this.directorInputLabel);
            this.Controls.Add(this.directorInput);
            this.Controls.Add(this.nameInputLabel);
            this.Controls.Add(this.nameInput);
            this.MaximumSize = new System.Drawing.Size(400, 420);
            this.MinimumSize = new System.Drawing.Size(250, 420);
            this.Name = "InsertForm";
            this.Text = "InsertForm";
            ((System.ComponentModel.ISupportInitialize)(this.lengthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label nameInputLabel;
        private System.Windows.Forms.Label directorInputLabel;
        private System.Windows.Forms.TextBox directorInput;
        private System.Windows.Forms.Label yearInputLabel;
        private System.Windows.Forms.Label lengthInputLabel;
        private System.Windows.Forms.Label genreInputLabel;
        private System.Windows.Forms.TextBox genreInput;
        private System.Windows.Forms.Button insertbutton;
        private System.Windows.Forms.NumericUpDown lengthInput;
        private System.Windows.Forms.NumericUpDown ratingInput;
        private System.Windows.Forms.Label ratingInputLabel;
        private System.Windows.Forms.Label mainactorInputLabel;
        private System.Windows.Forms.TextBox mainactorInput;
        private System.Windows.Forms.NumericUpDown yearInput;
    }
}