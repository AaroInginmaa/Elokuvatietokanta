using MoviesDB.Models;
using MySql.Data.MySqlClient;

public class Database
{
    private readonly string _connectionString;

    public Database(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Movie> GetAllMovies()
    {
        List<Movie> movies = new List<Movie>();

        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM elokuvat;";
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            IdElokuvat = Convert.ToInt32(reader["idElokuvat"]),
                            Nimi = reader["Nimi"].ToString(),
                            Ohjaaja = reader["Ohjaaja"].ToString(),
                            Julkaistu = Convert.ToInt32(reader["Julkaistu"]),
                            Pituus = Convert.ToInt32(reader["Pituus"]),
                            Arvio = reader["Arvio"].ToString(),
                            Genre = reader["Genre"].ToString(),
                            Päänäyttelijät = reader["Päänäyttelijät"].ToString()
                        });
                    }
                }
            }
        }

        return movies;
    }

    public void InsertMovie(Movie movie)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "INSERT INTO elokuvat (Nimi, Ohjaaja, Julkaistu, Pituus, Arvio, Genre, Päänäyttelijät) " +
                           "VALUES (@Nimi, @Ohjaaja, @Julkaistu, @Pituus, @Arvio, @Genre, @Päänäyttelijät);";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nimi", movie.Nimi);
                command.Parameters.AddWithValue("@Ohjaaja", movie.Ohjaaja);
                command.Parameters.AddWithValue("@Julkaistu", movie.Julkaistu);
                command.Parameters.AddWithValue("@Pituus", movie.Pituus);
                command.Parameters.AddWithValue("@Arvio", movie.Arvio);
                command.Parameters.AddWithValue("@Genre", movie.Genre);
                command.Parameters.AddWithValue("@Päänäyttelijät", movie.Päänäyttelijät);

                command.ExecuteNonQuery();
            }
        }
    }

    public bool CheckMovies(Movie movie)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM elokuvat WHERE Nimi = @Nimi;";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nimi", movie.Nimi);
                using (var reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }
}