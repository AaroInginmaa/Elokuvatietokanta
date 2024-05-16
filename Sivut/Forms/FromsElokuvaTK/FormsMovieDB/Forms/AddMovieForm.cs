using System;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

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
            if (string.IsNullOrWhiteSpace(MovieTextBox.Text) ||
                LengthNumUpDown.Value == 0 ||
                YearNumUpDown.Value == 0 ||
                string.IsNullOrWhiteSpace(GenreTextBox.Text) ||
                string.IsNullOrWhiteSpace(MovieStarsTextBox.Text) ||
                string.IsNullOrWhiteSpace(DirectorTextBox.Text) ||
                RatingNumUpDown.Value == 0 ||
                string.IsNullOrWhiteSpace(ImageURLText.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (!Uri.TryCreate(ImageURLText.Text, UriKind.Absolute, out _))
            {
                MessageBox.Show("Please give valid URL as image link");
                return;
            }
            int enteredYear = Convert.ToInt32(YearNumUpDown.Value);
            if (enteredYear < 1888 && enteredYear > 2024)
            {
                MessageBox.Show("Year cannot be earlier than 1888 or later than 2024!");
                return;
            }

            Movie movie = new Movie(
                MovieTextBox.Text.ToString(),
                Convert.ToInt32(LengthNumUpDown.Value),
                enteredYear,
                GenreTextBox.Text.ToString(),
                MovieStarsTextBox.Text.ToString(),
                DirectorTextBox.Text.ToString(),
                Convert.ToDecimal(RatingNumUpDown.Value),
                ImageURLText.Text.ToString()
            );
            Database database = new Database();
            database.InsertMovie(movie);
            AddMovieForm form = new AddMovieForm();
            form.Hide();
        }
    }
}