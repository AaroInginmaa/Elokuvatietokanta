using Elokuvatietokanta.Classes;
using System;
using System.Windows;

namespace Elokuvatietokanta
{
    public partial class MovieEditWindow : Window
    {
        private readonly Database _database = new Database();

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

            string movieName = EloNimi.Text;

            int resultCount = _database.NonDestructiveQuery($"SELECT COUNT(*) FROM movies WHERE Name = '{movieName}'");

            if (resultCount != 0)
            {
                MessageBox.Show("There is a movie by this name already", "error");
                return;
            }

            try
            {
                string sql = $"INSERT INTO movies (Name, Length, ReleaseYear, Genres, MainActors, Director, Rating) " +
                    $"VALUES ('{EloNimi.Text}', '{EloPituus.Text}', '{EloJulkaistu.Text}', '{EloGenre.Text}', " +
                    $"'{EloPäänäyttelijät.Text}', '{EloOhjaaja.Text}', '{EloArvio.Text}')";

                int rowsAffected = _database.DestructiveQuery(sql);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Movie inserted successfully!");
                    Close();
                }
                else MessageBox.Show("Failed to insert movie.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            _database.Close();
        }


        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
