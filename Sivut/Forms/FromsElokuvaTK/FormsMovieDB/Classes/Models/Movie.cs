namespace FormsMovieDB
{
    public class Movie
    {
        public Movie(
            string name = null,
            int length = 0,
            int releaseYear = 0,
            string genres = null,
            string mainActors = null,
            string director = null,
            decimal rating = 0,
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
            decimal rating = 0,
            string image = null)
        {
            Id = id;
            Name = name;
            Length = length;
            ReleaseYear = releaseYear;
            Genres = genres;
            MainActors = mainActors;
            Director = director;
            Rating = rating;
            Image = image;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int ReleaseYear { get; set; }
        public string Genres { get; set; }
        public string MainActors { get; set; }
        public string Director { get; set; }
        public decimal Rating { get; set; }
        public string Image { get; set; }

    }
}