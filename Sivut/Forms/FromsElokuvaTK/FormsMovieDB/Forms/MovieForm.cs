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

            _title.Text = _movie.Name;
            _rating.Text = _movie.Rating.ToString();

            


            if (_movie.Image != null && _movie.Image.Length > 5)
            {
                try
                {
                    _picture.Load(_movie.Image);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("Jotain meni väärin kuvan " + _movie.Image + " kanssa. Virhe : " + ee.Message);
                }
            }




            _releaseYear.Text = _movie.ReleaseYear.ToString();
            _director.Text = _movie.Director.ToString();
            _genre.Text = _movie.Genres.ToString();
            _length.Text = $"{_movie.Length} minutes";
            _mainactors.Text=_movie.MainActors.ToString();
            
        }
	}
}
