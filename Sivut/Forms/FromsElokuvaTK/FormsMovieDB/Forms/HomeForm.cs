using FormsMovieDB.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async void OnHomeFormLoad(object sender, EventArgs e)
        {
            List<Movie> movies = await Task.Run(() => _database.SelectMovies());
            DisplayMovies(movies);
        }

        private void DisplayMovies(List<Movie> movies)
        {

            flowLayoutPanel1.SuspendLayout();

            foreach (var movie in movies)
            {
                DisplayMovie(movie);
            }

            flowLayoutPanel1.ResumeLayout();
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
                Name = $"PnlMovie{movie.Id}",
                BackColor = Color.White,
                Size = new Size(125, 205),
                Margin = new Padding(10),
                Tag = movie.Id
            };

            PictureBox pictureBox = new PictureBox
            {
                Name = $"MovieImage{movie.Id}",
                Size = new Size(100, 148),
                Location = new Point(12, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            if (!string.IsNullOrEmpty(movie.Image) && movie.Image.Length > 5)
            {
                LoadImageAsync(pictureBox, movie.Image);
            }

            pictureBox.Tag = movie.Id;

            Label labelTitle = new Label
            {
                Name = $"LabelMovieName{movie.Id}",
                Text = movie.Name,
                Location = new Point(12, 165),
                ForeColor = Color.Black,
                Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                AutoSize = true,
                Tag = movie.Id
            };

            Label labelYear = new Label
            {
                Name = $"LabelMovieYear{movie.Id}",
                Text = movie.ReleaseYear.ToString(),
                Location = new Point(12, 185),
                ForeColor = Color.Gray,
                Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular),
                Tag = movie.Id
            };

            panel.Click += (sender, e) => OnMovieClicked(panel);
            pictureBox.Click += (sender, e) => OnMovieClicked(panel);
            labelTitle.Click += (sender, e) => OnMovieClicked(panel);
            labelYear.Click += (sender, e) => OnMovieClicked(panel);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(labelTitle);
            panel.Controls.Add(labelYear);

            return panel;
        }

        private async void LoadImageAsync(PictureBox pictureBox, string imageUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var imageBytes = await client.GetByteArrayAsync(imageUrl);
                    using (var stream = new System.IO.MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(stream);
                        pictureBox.Invoke((MethodInvoker)(() => pictureBox.Image = image));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading image {imageUrl}: {e.Message}");
            }
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
                _movieForm.FormClosed += (s, e) => _movieForm = null;
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
