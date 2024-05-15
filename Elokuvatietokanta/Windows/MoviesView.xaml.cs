using Elokuvatietokanta.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
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

                if (dataRow == null)
                {
                    MessageBox.Show("Please select a movie to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string name = Convert.ToString(dataRow.Row.ItemArray[0]);

                MessageBoxResult messageBoxResult = MessageBox.Show($"Are you sure you want to delete {name}?", "Deletion", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int rowsAffected = _database.DeleteMovie(name);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No movie found with the given name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
