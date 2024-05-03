using FormsMovieDB.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsMovieDB
{
    public partial class HomeForm : Form
    {
        public static event Action<Form> MovieButtonClicked;

        private Database _database = new Database();

        public HomeForm()
        {
            InitializeComponent();
        }

        private void OnHomeFormLoad(object sender, EventArgs e)
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
            Panel panel = new Panel();
            panel.Name = string.Format("PnlMovie{0}", movie.Id);
            panel.BackColor = Color.White;
            panel.Size = new Size(125, 205);
            panel.Margin = new Padding(10);
            panel.Tag = movie.Id;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = string.Format("MovieImage{0}", movie.Id);
            pictureBox.Size = new Size(100, 148);
            pictureBox.Location = new Point(12, 10);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            if (movie.Image != null && movie.Image.Length > 5)
            {
                try
                {
                    pictureBox.Load(movie.Image);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            pictureBox.Tag = movie.Id;

            Label lableTitle = new Label();
            lableTitle.Name = string.Format("LabelMovieName{0}", movie.Id);
            lableTitle.Text = movie.Name;
            lableTitle.Location = new Point(12, 165);
            lableTitle.ForeColor = Color.Black;
            lableTitle.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            lableTitle.AutoSize = true;
            lableTitle.Tag = movie.Id;

            Label labelYear = new Label();
            labelYear.Name = string.Format("LabelMovieYear{0}", movie.Id);
            labelYear.Text = movie.ReleaseYear.ToString();
            labelYear.Location = new Point(12, 185);
            labelYear.ForeColor = Color.Gray;
            labelYear.Font = new Font(this.Font.FontFamily, 9.5f, FontStyle.Regular);
            labelYear.Tag = movie.Id;

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
            MovieButtonClicked?.Invoke(new MovieForm(_database.SelectMovieById((int)panel.Tag)));
        }
    }
}
