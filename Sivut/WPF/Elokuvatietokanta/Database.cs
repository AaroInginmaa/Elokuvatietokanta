using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Controls;

namespace FromsElokuvaTK
{
    internal class Database
    {
        private string _Hostname;
        private string _Username;
        private string _Password;
        private string _Database;

        public MySqlConnection connection;

        public Database(string hostname, string username, string password, string database)
        {
            _Hostname = hostname;
            _Username = username;
            _Password = password;
            _Database = database;
        }

        public bool Connect()
        {
            try
            {
                string connectionString = $"server={_Hostname};uid={_Username};pwd={_Password};database={_Database}";
                connection = new MySqlConnection(connectionString);
                connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Close()
        {
            connection.Close();
        }

        // Queryt mitkä ei muuttaa/lisää tietoja kuten SELECT
        public int NonDestructiveQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            int firstRow = Convert.ToInt32(command.ExecuteScalar());

            // Käytä queryssä SELECT COUNT(*) FROM... saadaksesi rivien määrän
            return firstRow;
        }

        // Queryt mitkä muuttaa/lisää tietoja kuten INSERT ja DELETE
        public int DestructiveQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }

        public void FillDataGrid(DataGrid dg)
        {
            string sql = "SELECT idMovies as id, Name, Length, ReleaseYear, Genres, MainActors, Director, Rating FROM movies";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable("movies");

            dataAdapter.Fill(dataTable);
            dg.ItemsSource = dataTable.DefaultView;
            dataAdapter.Update(dataTable);

        }
    }
}

