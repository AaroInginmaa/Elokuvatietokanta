using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FormsMovieDB
{
    sealed class Database
    {
        private readonly Client Client;

        public event Action<User> UserLoggedIn;

        private MySqlConnection _connection;

        private string _host;
        private string _database;
        private string _user;
        private string _passsword;
        private string _port;

        public Database()
        {
            Initialize();

            Client = Client.Instance();

            if (Client.LoggedUser != null)
                Client.LoggedUser.WatchListUpdated += UpdateUserWatchList;
        }

        private void Initialize()
        {
            _host = "localhost";
            _database = "movies_db";
            _user = "admin";
            _passsword = "admin";
            _port = "3306";

            string connectionCommand = $"Server={_host}; Port={_port}; Database={_database}; Uid={_user}; Pwd={_passsword};";

            _connection = new MySqlConnection(connectionCommand);
        }

        public List<Movie> SelectMovies()
        {
            string selectQuery = "SELECT * FROM movies_db.movies;";

            List<Movie> movies = new List<Movie>();

            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(selectQuery, _connection);

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);

            DataTable dataTable = new DataTable();

            mySqlDataAdapter.Fill(dataTable);
            CloseConnection();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Movie movie = new Movie(
                    Convert.ToInt32(dataRow["movie_id"]),
                    Convert.ToString(dataRow["title"]),
                    Convert.ToString(dataRow["director"]),
                    Convert.ToInt32(dataRow["release_year"]),
                    Convert.ToString(dataRow["description"]),
                    Convert.ToString(dataRow["trailer_link"]),
                    Convert.ToInt32(dataRow["length"]),
                    Convert.ToString(dataRow["genre"]),
                    Convert.ToString(dataRow["star"]),
                    Convert.ToDouble(dataRow["rating"]),
                    Convert.ToString(dataRow["picture_link"]));

                movies.Add(movie);
            }

            return movies;
        }

        public void InsertMovie(Movie movie)
        {
            string insertQuery = $"INSERT INTO movies_db.movies (name, director, release_year, description, trailer_link, length, genre, star, rating) VALUES (" +
                $"\"{movie.Title}\"," +
                $"\"{movie.Director}\"," +
                $"{movie.ReleaseYear}," +
                $"{movie.Description}," +
                $"{movie.TrailerLink}," +
                $"{movie.Length}," +
                $"{movie.Genre}," +
                $"\"{movie.Star}\"," +
                $"\"{movie.Rating}\"" +
                $");";

            OpenConnection();

            MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, _connection);
            mySqlCommand.ExecuteNonQuery();

            CloseConnection();
        }

        public void RegisterUser(User user)
        {
            string insertQuery = $"INSERT INTO movies_db.users (user_id, name, email, password) VALUES (0, \"{user.Username}\", \"{user.Email}\", \"{user.Password}\")";

            OpenConnection();

            MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, _connection);
            mySqlCommand.ExecuteNonQuery();

            CloseConnection();
        }

        public void LoginUser(string login, string password)
        {
            string selectQuery = $"SELECT * FROM movies_db.users WHERE (name = '{login}' OR email = '{login}') AND password = '{password}';\r\n";

            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(selectQuery, _connection);

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);

            DataTable dataTable = new DataTable();

            mySqlDataAdapter.Fill(dataTable);
            CloseConnection();

            if (dataTable.Rows.Count <= 0)
                return;

            DataRow userDataRow = dataTable.Rows[0];

            User user = new User(
                Convert.ToInt32(userDataRow["user_id"]),
                Convert.ToString(userDataRow["name"]),
                Convert.ToString(userDataRow["email"]),
                DecryptWatchList(userDataRow["watchlist"].ToString()));

            Client.LogInUser(user);
        }

        public bool LoginIsAvailable(string username, string email)
        {
            string selectQuery = $"SELECT * FROM movies_db.users WHERE (name = \"{username}\" OR email = \"{email}\");";

            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(selectQuery, _connection);

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);

            DataTable dataTable = new DataTable();

            mySqlDataAdapter.Fill(dataTable);
            CloseConnection();

            if (dataTable.Rows.Count <= 0)
                return true;
            else
                return false;
        }

        public void UpdateUserWatchList()
        {
            string insertQuery = $"INSERT INTO movies_db.users WHERE user_id = {Client.LoggedUser.Id} (watchlist) VALUES (\"{EncryptUserWatchList()}\")";

            OpenConnection();

            MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, _connection);
            mySqlCommand.ExecuteNonQuery();

            CloseConnection();
        }

        private string EncryptUserWatchList()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Movie movie in Client.LoggedUser.WatchList)
            {
                stringBuilder.Append($"{movie.Id}$");
            }

            return stringBuilder.ToString();
        }

        private List<Movie> DecryptWatchList(string watchListString)
        {
            if (watchListString == string.Empty)
                return new List<Movie>();

            List<Movie> movies = new List<Movie>();

            string[] movieIds = watchListString.Split('$');

            foreach (string movieId in movieIds)
            {
                movies.Add(SelectMovieById(Convert.ToInt32(movieId)));
            }

            return movies;
        }

        public Movie SelectMovieById(int id)
        {
            string selectQuery = $"SELECT * FROM movies_db.movies WHERE movie_id = '{id}'";

            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(selectQuery, _connection);

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);

            DataTable dataTable = new DataTable();

            mySqlDataAdapter.Fill(dataTable);
            CloseConnection();

            if (dataTable.Rows.Count <= 0)
                throw new Exception("Movie wasn't found");
                
            DataRow movieDataRow = dataTable.Rows[0];

            Movie movie = new Movie(
                Convert.ToInt32(movieDataRow["movie_id"]),
                Convert.ToString(movieDataRow["title"]),
                Convert.ToString(movieDataRow["director"]),
                Convert.ToInt32(movieDataRow["release_year"]),
                Convert.ToString(movieDataRow["description"]),
                Convert.ToString(movieDataRow["trailer_link"]),
                Convert.ToInt32(movieDataRow["length"]),
                Convert.ToString(movieDataRow["genre"]),
                Convert.ToString(movieDataRow["star"]),
                Convert.ToDouble(movieDataRow["rating"]),
                Convert.ToString(movieDataRow["picture_link"]));

            return movie;
        }

        private void OpenConnection()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Failed to open connection.\n\n{exception.Message}");
            }
        }

        private void CloseConnection()
        {
            try
            {
                _connection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Failed to close connection.\n\n{exception.Message}");
            }
        }
    }
}
