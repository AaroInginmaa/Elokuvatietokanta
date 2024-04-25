using Elokuvatietokanta.Classes;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Elokuvatietokanta
{
    public partial class MoviesView : Window
    {
        private readonly Database _database = new Database();
        private readonly WindowLoader _windowLoader = WindowLoader.GetInstance();

        public MoviesView()
        {
            InitializeComponent();

            try
            {
                _database.Connect();

                _database.FillDataGrid(_sqlDataGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteMovie(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)_sqlDataGrid.SelectedItem;

                int movieId = Convert.ToInt32(dataRow.Row.ItemArray[0]);
                string movieName = dataRow.Row.ItemArray.ToString();

                MessageBoxResult messageBoxResult = MessageBox.Show($"Are you sure you want to delete {movieName}", "Deletion", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _database.DestructiveQuery($"DELETE FROM moviedb.movies WHERE idMovies = {movieId}");
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _database.FillDataGrid(_sqlDataGrid);
            _deleteMovieButton.IsEnabled = false;
        }

        private void OpenLoadWindow(object sender, RoutedEventArgs e)
        {
            _database.Close();
            _windowLoader.LoadWindow(new LoginWindow());
        }

        private void OpenMainWindow(object sender, RoutedEventArgs e)
        {
            _windowLoader.LoadWindow(new MovieEditWindow());
        }

        private void OnSQLDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_sqlDataGrid.SelectedIndex != -1)
            {
                _deleteMovieButton.IsEnabled = true;
            }
            else
            {
                _deleteMovieButton.IsEnabled = false;
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            _database.FillDataGrid(_sqlDataGrid);
            return;
        }
    }
}
