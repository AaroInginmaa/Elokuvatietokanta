    namespace MoviesDB.Models
{
    public class Movie
    {
        public Movie(string nimi = "", int idElokuvat = 0, string ohjaaja = "", int julkaistu = 0, int pituus = 0, double arvio = 0.0, string genre = "", string päänäyttelijät = "")
        {
            Nimi = nimi;
            IdElokuvat = idElokuvat;
            Ohjaaja = ohjaaja;
            Julkaistu = julkaistu;
            Pituus = pituus;
            Arvio = arvio;
            Genre = genre;
            Päänäyttelijät = päänäyttelijät;
        }
        public int IdElokuvat { get; private set; }
        public string Nimi { get; set; }
        public string Ohjaaja { get; set; }
        public int Julkaistu { get; set; }
        public int Pituus { get; set; }
        public double Arvio { get; set; }
        public string Genre { get; set; }
        public string Päänäyttelijät { get; set; }
    }

    public class User
        {
            public User(string name, int id = 0, string password = "", string confirmPassword = "", string email = "")
            {
                Name = name;
                Id = id;
                Password = password;
                ConfirmPassword = confirmPassword;
                Email = email;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Email { get; set; }
        }

    }
