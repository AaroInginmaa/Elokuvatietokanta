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
            RegisterForm.ReturnButtonClicked += ShowChildForm;
            HomeForm.MovieButtonClicked += ShowChildForm;
            if (Client.UserLoggedIn() == false)
            {
                ShowChildForm(new SignInForm());
            }
            else
            {
                ShowChildForm(new HomeForm());
            }
        }

        private void ShowChildForm(Form childForm)
        {
            if (childForm.Name != _currentChildForm?.Name)
            {
                if (_currentChildForm != null)
                {
                    _currentChildForm.Close();
                }

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
                ShowChildForm(new ProfileForm());
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
