using System.Windows.Forms;
using System;

namespace FormsMovieDB
{
    public partial class MovieForm : Form
    {
        private readonly Movie _movie;
        public static event Action<Form> BackButtonClicked;

        public MovieForm(Movie movie)
        {
            _movie = movie;
            InitializeComponent();
        }
        private void OnMovieFormLoad(object sender, EventArgs e)
        {
            LoadMovieData();
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this);
            LoadMovieData();

        }

        public void LoadMovieData()
        {
            _title.Text = _movie.Name;
            _rating.Text = _movie.Rating.ToString();

            if (_movie.Image != null && _movie.Image.Contains("."))
            {
                try
                {
                    _picture.Load(_movie.Image);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Jotain meni väärin kuvan " + _movie.Image + " kanssa. Virhe : " + ee.Message);
                }
            }
            _releaseYear.Text = _movie.ReleaseYear.ToString();
            _director.Text = _movie.Director.ToString();
            _genre.Text = _movie.Genres.ToString();
            _length.Text = $"{_movie.Length} minutes";
            _mainactors.Text = _movie.MainActors.ToString();
        }
        private void OnMovieFormShown(object sender, EventArgs e)
        {
            LoadMovieData();
        }
    }
}
