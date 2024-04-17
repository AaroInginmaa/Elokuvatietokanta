using FromsElokuvaTK;
using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace Elokuvatietokanta
{
    public partial class MainWindow : Window
    {
        Database database = new Database("localhost", "root", "", "elokuvatietokanta");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            if (!database.Connect())
            {
                MessageBox.Show("Tietokantaan yhdistäminen epäonnistui.", "Virhe!");
                return;
            }

            string movieName = EloNimi.Text;

            int resultCount = database.Select($"SELECT COUNT(*) FROM elokuvat WHERE Nimi = '{movieName}'");

            if (resultCount == 0)
            {
                try
                {
                    database.Connect();

                    string sql = $"INSERT INTO elokuvat (Nimi, Pituus, Julkaistu, Genre, Päänäyttelijät, Ohjaaja, Arvio) " +
                        $"VALUES ('{EloNimi.Text}', '{EloPituus.Text}', '{EloJulkaistu.Text}', '{EloGenre.Text}', " +
                        $"'{EloPäänäyttelijät.Text}', '{EloOhjaaja.Text}', '{EloArvio.Text}')";

                    int rowsAffected = database.Insert(sql);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Movie inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert movie.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                database.Close();
            }
            else
            {
                MessageBox.Show("There is a movie by this name already", "error");
 
            }
            database.Close();
        }

        private void ToDelete(object sender, RoutedEventArgs e)
        {
            
            Elokuvat elokuvat = new Elokuvat();
            elokuvat.Show();
            this.Close();
        }
    }
}

