using System;
using System.Windows.Forms;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace FormsMovieDB
{
    public partial class MovieForm : Form
    {
        private Movie _movie;

        public MovieForm(Movie movie)
        {
            _movie = movie;
            InitializeComponent();
        }

        private void OnMovieFormLoad(object sender, EventArgs e)
        {
            string embedHTML = "<html>" +
                "<head>" +
                "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                "</head>" +
                "<body>" +
                "<iframe width=\"620\" height=\"400\" src=\"{0}\"" +
                "frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                "</body>" +
                "</html>";

            _movieTrailerBrowser.DocumentText = string.Format(embedHTML, _movie.TrailerLink);

            _title.Text = _movie.Title;
            _rating.Text = _movie.Rating.ToString();

            _picture.Load(_movie.ImageUrl);
            _picture.BackgroundImageLayout = ImageLayout.Zoom;

            _releaseYear.Text = _movie.ReleaseYear.ToString();
            _director.Text = _movie.Director.ToString();
            _genre.Text = _movie.Genre.ToString();
            _length.Text = $"{_movie.Length} minutes";
            _description.Text = _movie.Description.ToString();
        }
	}
}
