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

        public MoviesView()
        {
            InitializeComponent();

            try
            {
                _database.Connect();

                _database.FillDataGrid(SQLdataGrid);

                //database.Close();
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
                DataRowView dataRow = (DataRowView)SQLdataGrid.SelectedItem;

                int movieId = Convert.ToInt32(dataRow.Row.ItemArray[0]);
                string movieName = Convert.ToString(dataRow.Row.ItemArray[1]);

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

            _database.FillDataGrid(SQLdataGrid);
            BtnDelete.IsEnabled = false;
        }

        private void OpenLoadWindow(object sender, RoutedEventArgs e)
        {
            _database.Close();
            WindowLoader.LoadWindow(new LoginWindow());
            Close();
        }

        private void OpenMainWindow(object sender, RoutedEventArgs e)
        {
            WindowLoader.LoadWindow(new MovieEditWindow());
        }

        private void OnSQLDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SQLdataGrid.SelectedIndex != -1)
            {
                BtnDelete.IsEnabled = true;
            }
            else
            {
                BtnDelete.IsEnabled = false;
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            _database.FillDataGrid(SQLdataGrid);
            return;
        }
    }
}
