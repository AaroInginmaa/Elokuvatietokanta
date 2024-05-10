using Elokuvatietokanta.Classes;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Elokuvatietokanta
{
    public partial class MovieEditWindow : Window
    {
        private readonly Database _database = new Database();
        private readonly WindowLoader _windowLoader = WindowLoader.GetInstance();

        public MovieEditWindow()
        {
            InitializeComponent();
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            if (!_database.Connect())
            {
                MessageBox.Show("Tietokantaan yhdistäminen epäonnistui.", "Virhe!");
                return;
            }

            string movieName = _movieNameInputField.Text;
            int resultCount = _database.NonDestructiveQuery($"SELECT COUNT(*) FROM movies WHERE Name = '{movieName}'");

            if (resultCount != 0)
            {
                MessageBox.Show("There is a movie by this name already", "error");
                return;
            } 
            try
            {
                if (!string.IsNullOrWhiteSpace(_movieNameInputField.Text) && Regex.IsMatch(_movieNameInputField.Text, @"^[A-Za-z\s]+$") &&
                !string.IsNullOrWhiteSpace(_movieStartInputField.Text) && Regex.IsMatch(_movieStartInputField.Text, @"^[A-Za-z\s]+$") &&
                !string.IsNullOrWhiteSpace(_movieGenreInputField.Text) && Regex.IsMatch(_movieGenreInputField.Text, @"^[A-Za-z\s]+$") &&
                !string.IsNullOrWhiteSpace(_movieReleaseYearInputField.Text) && Regex.IsMatch(_movieReleaseYearInputField.Text, @"^\d{4}$") && 1799 < int.Parse(_movieReleaseYearInputField.Text) && int.Parse(_movieReleaseYearInputField.Text) <= 2024 &&
                !string.IsNullOrWhiteSpace(_movieLengthInputField.Text) && Regex.IsMatch(_movieLengthInputField.Text, @"^\d+$") && 0 < int.Parse(_movieLengthInputField.Text) && int.Parse(_movieLengthInputField.Text) <= 500 &&
                !string.IsNullOrWhiteSpace(_movieDirectorInputField.Text) && Regex.IsMatch(_movieDirectorInputField.Text, @"^[A-Za-z\s]+$") &&
                !string.IsNullOrWhiteSpace(_movieRatingInputField.Text) && 0 < int.Parse(_movieRatingInputField.Text) && int.Parse(_movieRatingInputField.Text) <= 10)
                {
                    string sqlQuery = $"INSERT INTO movies (Name, Length, ReleaseYear, Genres, MainActors, Director, Rating)" +
                    $"VALUES ('{_movieNameInputField.Text}'," +
                    $"'{_movieLengthInputField.Text}'," +
                    $"'{_movieReleaseYearInputField.Text}'," +
                    $"'{_movieGenreInputField.Text}'," +
                    $"'{_movieStartInputField.Text}'," +
                    $"'{_movieDirectorInputField.Text}'," +
                    $"'{_movieRatingInputField.Text}')";

                    int rowsAffected = _database.DestructiveQuery(sqlQuery);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie inserted successfully!");
                        _windowLoader.LoadWindow(new MoviesView());
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert movie.");
                    }
                }
                else
                {
                    MessageBox.Show("Data is not sufficient");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            _database.Close();  
        }

        private void OnReturn(object sender, RoutedEventArgs e)
        {
            _windowLoader.LoadWindow(new MoviesView());
        }

    }
}
