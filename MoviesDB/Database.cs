using MoviesDB.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace MoviesDB
{
    public class Database
    {
        private readonly string _host;
        private readonly string _database;
        private readonly string _user;
        private readonly string _password;
        private readonly int _port;

        private MySqlConnection _connection;

        public Database()
        {
            _host = "10.146.4.49";
            _database = "moviedb";
            _user = "app";
            _password = "databaseApp!";
            _port = 3306;

            string connectionQuery = $"Server={_host};Port={_port};Database={_database};Uid={_user};Pwd={_password};";

            _connection = new MySqlConnection(connectionQuery);
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            string query = "SELECT * FROM moviedb.elokuvat;";

            OpenConnection();
            MySqlCommand mySqlCommand = new(query, _connection);

            MySqlDataAdapter mySqlDataAdapter = new(mySqlCommand);

            DataTable DataTable = new();

            mySqlDataAdapter.Fill(DataTable);
            CloseConnection();

            foreach (DataRow dataRow in DataTable.Rows)
            {
                movies.Add(new Movie
                    (
                    Convert.ToString(dataRow["Nimi"]),
                    Convert.ToInt32(dataRow["idElokuvat"]),
                    Convert.ToString(dataRow["Ohjaaja"]),
                    Convert.ToInt32(dataRow["Julkaistu"]),
                    Convert.ToInt32(dataRow["Pituus"]),
                    Convert.ToString(dataRow["Arvio"]),
                    Convert.ToString(dataRow["Genre"]),
                    Convert.ToString(dataRow["Päänäyttelijät"])
                    ));
            }

            return movies;
        }

        public void InsertMovie(Movie movie)
        {
            string query = $"INSERT INTO moviedb.elokuvat VALUES (" +
                $"{movie.IdElokuvat}," +
                $"\"{movie.Nimi}\"," +
                $"\"{movie.Ohjaaja}\"," +
                $"{movie.Julkaistu}," +
                $"{movie.Pituus}," +
                $"{movie.Arvio}," +
                $"\"{movie.Genre}\"," +
                $"\"{movie.Päänäyttelijät}\"" +
                $");";
            /*
             int IdElokuvat
        string Nimi
        string Ohjaaja
        int Julkaistu
        int Pituus
        string Arvio
        string Genre
        string Päänäyttelijät
             
             */
            OpenConnection();

            MySqlCommand mySqlCommand = new(query, _connection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            CloseConnection();
        }
        public bool CheckMovies(Movie movie)
        {
            string query = $"SELECT * FROM movies WHERE title = '{movie.Nimi}'";

            OpenConnection();

            MySqlCommand mySqlCommand = new MySqlCommand(query, _connection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            bool movieExists = mySqlDataReader.HasRows;

            mySqlDataReader.Close(); // Close the reader

            CloseConnection();

            return movieExists;
        }


        private void OpenConnection()
        {
            _connection.Open();
        }

        private void CloseConnection()
        {
            _connection.Close();
        }
    }
}
