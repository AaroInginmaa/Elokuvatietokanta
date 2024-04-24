using FromsElokuvaTK;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Elokuvatietokanta
{
    /// <summary>
    /// Interaction logic for Elokuvat.xaml
    /// </summary>
    public partial class Elokuvat : Window
    {
        Database database = new Database("10.146.4.49", "dbuser", "Nakkikastike123!", "moviedb");

        public Elokuvat()
        {
            InitializeComponent();

            try
            {
                database.Connect();

                database.FillDataGrid(SQLdataGrid);

                //database.Close();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void KillMovie(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)SQLdataGrid.SelectedItem;
                int movieId = (int)dataRow.Row.ItemArray[0];
                string movieName = (string)dataRow.Row.ItemArray[1];
                //database.Connect();

                MessageBoxResult mbr = MessageBox.Show($"Are you sure you want to delete {movieName}", "Deletion", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (mbr == MessageBoxResult.Yes)
                {

                    database.DestructiveQuery($"DELETE FROM moviedb.movies WHERE idMovies = {movieId}");
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

            database.FillDataGrid(SQLdataGrid);
            //database.Close();
            BtnDelete.IsEnabled = false;
        }

        private void ToLogin(object sender, RoutedEventArgs e)
        {
            database.Close();
            Windows.LoadLogin();
            Close();
        }

        private void ToMain(object sender, RoutedEventArgs e)
        {
            Windows.LoadMain();
        }

        private void SQLdataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            database.FillDataGrid(SQLdataGrid);
            return;
        }
    }
}
