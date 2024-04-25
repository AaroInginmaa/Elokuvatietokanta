using Elokuvatietokanta.Classes;
using System;
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
                    Close();
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

            _database.Close();
        }

        private void OnReturn(object sender, RoutedEventArgs e)
        {
            _windowLoader.LoadWindow(new MoviesView());
        }
    }
}
