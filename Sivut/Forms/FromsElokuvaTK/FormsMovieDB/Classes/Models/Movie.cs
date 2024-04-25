namespace FormsMovieDB
{
    public class Movie
    {
        public Movie(
            string title,
            string director = null,
            int releaseYear = 0,
            string description = null,
            string trailerLink = null,
            int length = 0,
            string genre = null,
            string star = null,
            double rating = 0,
            string imageUrl = null)
        {
            Id = 0;
            Title = title;
            Director = director;
            Description = description;
            TrailerLink = trailerLink;
            ReleaseYear = releaseYear;
            Length = length;
            Genre = genre;
            Star = star;
            Rating = rating;
            ImageUrl = imageUrl;
        }

        public Movie(
            int id,
            string title,
            string director = null,
            int releaseYear = 0,
            string description = null,
            string trailerLink = null,
            int length = 0,
            string genre = null,
            string star = null,
            double rating = 0,
            string imageUrl = null)
        {
            Id = id;
            Title = title;
            Director = director;
            Description = description;
            TrailerLink = trailerLink;
            ReleaseYear = releaseYear;
            Length = length;
            Genre = genre;
            Star = star;
            Rating = rating;
            ImageUrl = imageUrl;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Director { get; private set; }
        public string Description { get; private set; }
        public string TrailerLink { get; private set; }
        public int ReleaseYear { get; private set; }
        public int Length { get; private set; }
        public string Genre { get; private set; }
        public string Star { get; private set; }
        public double Rating { get; private set; }
        public string ImageUrl { get; private set; }
    }
}
