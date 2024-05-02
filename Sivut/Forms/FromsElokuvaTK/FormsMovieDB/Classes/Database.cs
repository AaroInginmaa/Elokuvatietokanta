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
            _host = "10.146.4.49";
            _database = "moviedb";
            _user = "dbuser";
            _passsword = "Nakkikastike123!";
            _port = "3306";

            string connectionCommand = $"Server={_host}; Port={_port}; Database={_database}; Uid={_user}; Pwd={_passsword};";

            _connection = new MySqlConnection(connectionCommand);
        }

        public List<Movie> SelectMovies()
        {
            string selectQuery = "SELECT * FROM moviedb.movies;";

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
                    Convert.ToInt32(dataRow["idmovies"]),
                    Convert.ToString(dataRow["Name"]),
                    Convert.ToInt32(dataRow["Length"]),
                    Convert.ToInt32(dataRow["ReleaseYear"]),
                    Convert.ToString(dataRow["Genres"]),
                    Convert.ToString(dataRow["MainActors"]),
                    Convert.ToString(dataRow["Director"]),
                    Convert.ToInt32(dataRow["Rating"]),
                    Convert.ToString(dataRow["Image"]));

                movies.Add(movie);
            }

            return movies;
        }

        public void InsertMovie(Movie movie)
        {
            string insertQuery = $"INSERT INTO moviedb.movies (Name, Length, ReleaseYear, Genres, MainActors, Director, Rating, Image) VALUES (" +
                $"\"{movie.Name}\"," +
                $"\"{movie.Length}\"," +
                $"{movie.ReleaseYear}," +
                $"{movie.Genres}," +
                $"{movie.MainActors}," +
                $"{movie.Director}," +
                $"{movie.Rating}," +
                $"\"{movie.Image}\"," +
                $");";

            OpenConnection();

            MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, _connection);
            mySqlCommand.ExecuteNonQuery();

            CloseConnection();
        }

        public void RegisterUser(User user)
        {
            string insertQuery = $"INSERT INTO moviedb.usertable (idUser, username, email, password) VALUES (0, \"{user.Username}\", \"{user.Email}\", \"{user.Password}\")";
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, _connection);
            mySqlCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public void LoginUser(string login, string password)
        {
            string selectQuery = $"SELECT * FROM moviedb.usertable WHERE (username = '{login}' OR email = '{login}') AND password = '{password}';\r\n";

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
                Convert.ToInt32(userDataRow["idUser"]),
                Convert.ToString(userDataRow["username"]),
                Convert.ToString(userDataRow["email"]),
                DecryptWatchList(userDataRow["watchlist"].ToString()));

            Client.LogInUser(user);
        }

        public bool LoginIsAvailable(string username, string email)
        {
            string selectQuery = $"SELECT * FROM moviedb.usertable WHERE (name = \"{username}\" OR email = \"{email}\");";

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
            string insertQuery = $"INSERT INTO moviedb.usertable WHERE idUser = {Client.LoggedUser.Id} (watchlist) VALUES (\"{EncryptUserWatchList()}\")";

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
            string selectQuery = "SELECT * FROM moviedb.movies WHERE idMovies = @Id";

            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(selectQuery, _connection);
            mySqlCommand.Parameters.AddWithValue("@Id", id);

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);

            DataTable dataTable = new DataTable();

            mySqlDataAdapter.Fill(dataTable);
            CloseConnection();

            if (dataTable.Rows.Count <= 0)
                throw new Exception("Movie wasn't found");

            DataRow movieDataRow = dataTable.Rows[0];

            Movie movie = new Movie(
                Convert.ToInt32(movieDataRow["idMovies"]),
                Convert.ToString(movieDataRow["Name"]),
                Convert.ToInt32(movieDataRow["Length"]),
                Convert.ToInt32(movieDataRow["ReleaseYear"]),
                Convert.ToString(movieDataRow["Genres"]),
                Convert.ToString(movieDataRow["MainActors"]),
                Convert.ToString(movieDataRow["Director"]),
                Convert.ToDecimal(movieDataRow["Rating"]),
                Convert.ToString(movieDataRow["Image"]));

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
