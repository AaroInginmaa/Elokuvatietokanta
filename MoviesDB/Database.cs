using MoviesDB.Models;
using MySql.Data.MySqlClient;
using System.Data;

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
            _host = "localhost";
            _database = "movies_db";
            _user = "admin";
            _password = "admin";
            _port = 3306;

            string connectionQuery = $"Server={_host};Port={_port};Database={_database};Uid={_user};Pwd={_password};";

            _connection = new MySqlConnection(connectionQuery);
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            string query = "SELECT * FROM movies_db.movies;";

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
                    Convert.ToString(dataRow["title"]),
                    Convert.ToInt32(dataRow["movie_id"]),
                    Convert.ToString(dataRow["director"]),
                    Convert.ToInt32(dataRow["release_year"]),
                    Convert.ToInt32(dataRow["length"]),
                    Convert.ToInt32(dataRow["rating"]),
                    Convert.ToString(dataRow["genre"]),
                    Convert.ToString(dataRow["image"])
                    ));
            }

            return movies;
        }

        public void InsertMovie(Movie movie)
        {
            string query = $"INSERT INTO movies_db.movies VALUES (" +
                $"{movie.Id}," +
                $"\"{movie.Title}\"," +
                $"\"{movie.Director}\"," +
                $"{movie.ReleaseYear}," +
                $"{movie.Length}," +
                $"{movie.Rating}," +
                $"\"{movie.Genre}\"," +
                $"\"{movie.Image}\"" +
                $");";

            OpenConnection();

            MySqlCommand mySqlCommand = new(query, _connection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            CloseConnection();
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
