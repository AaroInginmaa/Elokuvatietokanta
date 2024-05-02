using System.Xml.Linq;

namespace FormsMovieDB
{
    public class Movie
    {
        public Movie(
            string name= null,
            int length = 0,
            int releaseYear = 0,
            string genres = null,
            string mainActors = null,
            string director = null,
            double rating = 0,
            string image = null)
        {
            Id = 0;
            Name = name;
            Length = length;
            ReleaseYear = releaseYear;
            Genres = genres;
            MainActors = mainActors;
            Director = director;
            Rating = rating;
            Image = image;
            
        }

        public Movie(
            int id = 0,
            string name = null,
            int length = 0,
            int releaseYear = 0,
            string genres = null,
            string mainActors = null,
            string director = null,
            double rating = 0,
            string image = null)
        {
            Id = 0;
            Name = name;
            Length = length;
            ReleaseYear = releaseYear;
            Genres = genres;
            MainActors = mainActors;
            Director = director;
            Rating = rating;
            Image = image;

        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Length { get; private set; }
        public int ReleaseYear { get; private set; }
        public string Genres { get; private set; }
        public string MainActors { get; private set; }
        public string Director { get; private set; }
        public double Rating { get; private set; }
        public string Image { get; private set; }
        
    }
}
