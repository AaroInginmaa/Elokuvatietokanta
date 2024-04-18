using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Elokuvatietokanta
{
    /// <summary>
    /// Interaction logic for Elokuvat.xaml
    /// </summary>
    public partial class Elokuvat : Window
    {
        public Elokuvat()
        {
            InitializeComponent();

            string connStr = "server=localhost;user=root;database=elokuvatietokanta;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "SELECT Nimi, Pituus, Julkaistu, Genre, Päänäyttelijät, Ohjaaja, Arvio FROM elokuvat";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("elokuvat");
                dataAdapter.Fill(dataTable);
                SQLdataGrid.ItemsSource = dataTable.DefaultView;
                dataAdapter.Update(dataTable);

                conn.Close();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void KillMovie(object sender, RoutedEventArgs e)
        {
            string connStr = "server=localhost;user=root;database=elokuvatietokanta;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql2 = "DELETE FROM elokuvat WHERE Nimi = '" + EloPoisto.Text + "';";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string sql = "SELECT Nimi, Pituus, Julkaistu, Genre, Päänäyttelijät, Ohjaaja, Arvio FROM elokuvat";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable("elokuvat");
            dataAdapter.Fill(dataTable);
            SQLdataGrid.ItemsSource = dataTable.DefaultView;
            dataAdapter.Update(dataTable);

            conn.Close();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }
    }
}
