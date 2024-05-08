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
                PopupNotifier popup = new PopupNotifier
                {
                    ContentFont = new Font("Tahoma", 8F),
                    HeaderHeight = 20,
                    BodyColor = Color.Red,
                    ShowCloseButton = false,
                    TitleColor = Color.White,
                    TitleText = "Error",
                    ContentText = "Please fill out all the fields!"
                };
                popup.Popup();
                return;
            }

            if (!Uri.TryCreate(ImageURLText.Text, UriKind.Absolute, out _))
            {
                PopupNotifier popup = new PopupNotifier
                {
                    ContentFont = new Font("Tahoma", 8F),
                    HeaderHeight = 20,
                    BodyColor = Color.Red,
                    ShowCloseButton = false,
                    TitleColor = Color.White,
                    TitleText = "Error",
                    ContentText = "Please enter a valid URL!"
                };
                popup.Popup();
                return;
            }
            int enteredYear = Convert.ToInt32(YearNumUpDown.Value);
            if (enteredYear < 1888)
            {
                PopupNotifier popup = new PopupNotifier
                {
                    ContentFont = new Font("Tahoma", 8F),
                    HeaderHeight = 20,
                    BodyColor = Color.Red,
                    ShowCloseButton = false,
                    TitleColor = Color.White,
                    TitleText = "Error",
                    ContentText = "Year cannot be earlier than 1888!"
                };
                popup.Popup();
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