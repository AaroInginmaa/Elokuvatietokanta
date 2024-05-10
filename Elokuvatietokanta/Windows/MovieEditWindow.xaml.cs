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

        private bool IsTextValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        private bool IsReleaseYearValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^\d{4}$"))
            {
                int year = int.Parse(input);
                return 1800 <= year && year <= 2024;
            }
            return false;
        }

        private bool IsLengthValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int length;
                if (int.TryParse(input, out length))
                {
                    return 1 <= length && length <= 500;
                }
            }
            return false;
        }

        private bool IsRatingValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                decimal rating;
                if (decimal.TryParse(input, out rating))
                {
                    return 1 <= rating && rating <= 10;
                }
            }
            return false;
        }

        private string ValidateInputs()
        {
            if (!IsTextValid(_movieNameInputField.Text))
            {
                return "Please enter a valid movie name.";
            }

            if (!IsTextValid(_movieStartInputField.Text))
            {
                return "Please provide information about the movie start.";
            }

            if (!IsTextValid(_movieGenreInputField.Text))
            {
                return "Please specify the genre of the movie.";
            }

            if (!IsReleaseYearValid(_movieReleaseYearInputField.Text))
            {
                return "Invalid release year. Please enter a year between 1800 and 2024.";
            }

            if (!IsLengthValid(_movieLengthInputField.Text))
            {
                return "Invalid movie length. Please enter a length between 1 and 500 minutes.";
            }

            if (!IsTextValid(_movieDirectorInputField.Text))
            {
                return "Please specify the director of the movie.";
            }

            if (!IsRatingValid(_movieRatingInputField.Text))
            {
                return "Invalid rating. Please enter a rating between 1 and 10.";
            }

            // No validation errors
            return string.Empty;
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

            string errorMessage = ValidateInputs();
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
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
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
        }

        private void OnReturn(object sender, RoutedEventArgs e)
        {
            _windowLoader.LoadWindow(new MoviesView());
        }
    }
}
 