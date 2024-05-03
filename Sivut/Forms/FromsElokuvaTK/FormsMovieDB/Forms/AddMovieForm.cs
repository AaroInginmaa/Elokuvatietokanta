using System;
using System.Windows.Forms;

namespace FormsMovieDB.Forms
{
    public partial class AddMovieForm : Form
    {
        public AddMovieForm()
        {
            InitializeComponent();
        }

        private void AddMovieButton_Click(object sender, EventArgs e)
        {
            Movie newMovie = new Movie(
                MovieTextBox.Text.ToString(),
                Convert.ToInt32(LengthNumUpDown.Value),
                Convert.ToInt32(YearNumUpDown.Value),
                GenreTextBox.Text.ToString(),
                MovieStarsTextBox.Text.ToString(),
                DirectorTextBox.Text.ToString(),
                Convert.ToDecimal(RatingNumUpDown.Value),
                ImageURLText.Text.ToString()
            );

            Database database = new Database();
            database.InsertMovie(newMovie);

            MessageBox.Show("Movie added successfully!");
        }
    }
}