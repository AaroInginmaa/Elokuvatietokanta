using FormsMovieDB.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsMovieDB
{
    public partial class HomeForm : Form
    {
        public static event Action<Form> MovieButtonClicked;
        private MovieForm _movieForm;
        private readonly Database _database = new Database();

        public HomeForm()
        {
            InitializeComponent();
        }

        public void OnHomeFormLoad(object sender, EventArgs e)
        {
            foreach (Movie movie in _database.SelectMovies())
            {
                DisplayMovie(movie);
            }
        }
        private void DisplayMovie(Movie movie)
        {
            Panel panel = CreateMoviePanel(movie);
            flowLayoutPanel1.Controls.Add(panel);
            
        }
        private Panel CreateMoviePanel(Movie movie)
        {
            Panel panel = new Panel
            {
                Name = string.Format("PnlMovie{0}", movie.Id),
                BackColor = Color.White,
                Size = new Size(125, 205),
                Margin = new Padding(10),
                Tag = movie.Id
            };

            PictureBox pictureBox = new PictureBox
            {
                Name = string.Format("MovieImage{0}", movie.Id),
                Size = new Size(100, 148),
                Location = new Point(12, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            if (movie.Image != null && movie.Image.Length > 5)
            {
                try
                {
                    pictureBox.Load(movie.Image);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Jotain meni väärin kuvan "+movie.Image+" kanssa. Virhe : "+e.Message);
                }
            }
            pictureBox.Tag = movie.Id;

            Label lableTitle = new Label
            {
                Name = string.Format("LabelMovieName{0}", movie.Id),
                Text = movie.Name,
                Location = new Point(12, 165),
                ForeColor = Color.Black,
                Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                AutoSize = true,
                Tag = movie.Id
            };

            Label labelYear = new Label
            {
                Name = string.Format("LabelMovieYear{0}", movie.Id),
                Text = movie.ReleaseYear.ToString(),
                Location = new Point(12, 185),
                ForeColor = Color.Gray,
                Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                Tag = movie.Id
            };

            panel.Click += (sender, e) => OnMovieClicked((Panel)sender);
            pictureBox.Click += (sender, e) => OnMovieClicked((Panel)((PictureBox)sender).Parent);
            lableTitle.Click += (sender, e) => OnMovieClicked((Panel)((Label)sender).Parent);
            labelYear.Click += (sender, e) => OnMovieClicked((Panel)((Label)sender).Parent);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(lableTitle);
            panel.Controls.Add(labelYear);

            return panel;
        }

        private void OnAddMovieButtonClick(object sender, EventArgs e)
        {
            AddMovieForm form = new AddMovieForm();
            form.ShowDialog();
        }

        private void OnMovieClicked(Panel panel)
        {
            if (_movieForm == null)
            {
                _movieForm = new MovieForm(_database.SelectMovieById((int)panel.Tag));
                _movieForm.FormClosed += (s, e) => _movieForm = null; // Reset the movie form reference when it's closed
                _movieForm.Show();
                MovieButtonClicked?.Invoke(_movieForm);
            }
            else
            {
                _movieForm.LoadMovieData();
                _movieForm.Show();
            }
        }
    }
}
