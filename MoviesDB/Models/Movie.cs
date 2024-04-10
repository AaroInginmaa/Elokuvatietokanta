namespace MoviesDB.Models
{
    public class Movie
    {
        public Movie(string title, int id = 0, string director = "", int releaseYear = 0, int length = 0, int rating = 0, string genre = "", string image = "")
        {
            Title = title;
            Id = id;
            Director = director;
            ReleaseYear = releaseYear;
            Length = length;
            Rating = rating;
            Genre = genre;
            Image = image;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public int Length { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
    }
}
