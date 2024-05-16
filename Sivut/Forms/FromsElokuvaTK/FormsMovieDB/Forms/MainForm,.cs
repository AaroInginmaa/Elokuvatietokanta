using FormsMovieDB.Forms;
using System;
using System.Windows.Forms;

namespace FormsMovieDB
{
    public partial class MainForm : Form
    {
        private readonly Client Client = Client.Instance();
        private Form _currentChildForm;
        public MainForm()
        {
            InitializeComponent();
            SignInForm.CreateAccountButtonClicked += ShowChildForm;
            SignInForm.SignInButtonClicked += ShowChildForm;
            RegisterForm.OnButtonClicked += ShowChildForm;
            HomeForm.MovieButtonClicked += ShowChildForm;
            MovieForm.BackButtonClicked += HandleMovieFormBackButtonClick;
            _menuButton.Visible = false;

            if (Client.UserLoggedIn() == false)
            {
                ShowChildForm(new SignInForm());
            }
            else
            {
                ShowChildForm(new HomeForm());
            }
        }

        public void HandleMovieFormBackButtonClick(Form senderForm)
        {
            if (senderForm is MovieForm)
            {
                ShowChildForm(new HomeForm());
            }
        }

        public void ShowChildForm(Form childForm)
        {
            if (childForm.Name != _currentChildForm?.Name)
            {
                if (Client.UserLoggedIn())
                {
                    _menuButton.Visible = true;
                }
                _currentChildForm?.Close();

                childForm.TopLevel = false;
                childForm.Dock = DockStyle.Fill;

                _parentPanel.Controls.Add(childForm);
                _parentPanel.Tag = childForm;

                _currentChildForm = childForm;
                childForm.Show();
            }
        }
        private void OnProfileButtonClick(object sender, EventArgs e)
        {
            if (Client.UserLoggedIn())
            {
                ShowChildForm(new SignInForm());
            }
            else
            {
                ShowChildForm(new SignInForm());
            }
        }

        private void OnMoviesButtonClick(object sender, EventArgs e)
        {
            ShowChildForm(new HomeForm());
        }
    }
}
