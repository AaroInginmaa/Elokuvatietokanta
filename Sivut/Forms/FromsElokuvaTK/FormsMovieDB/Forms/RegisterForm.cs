using FormsMovieDB.Classes;
using System;
using System.Windows.Forms;

namespace FormsMovieDB
{
    public partial class RegisterForm : Form
    {
        public static event Action<Form> OnButtonClicked;
        readonly Database _database = new Database();
        readonly UserInputValidator _inputValidator = new UserInputValidator();

        public RegisterForm()
        {
            InitializeComponent();
        }
        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            string username = _usernameInputField.Text;
            string email = _emailInputField.Text;
            string password = _passwordInputField.Text;
            string rePassword = _rePasswordInputField.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rePassword))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (!_inputValidator.ValidUsername(username))
            {
                MessageBox.Show("Invalid username");
                return;
            }
            if (!_inputValidator.ValidEmail(email))
            {
                MessageBox.Show("Invalid email");
                return;
            }
            if (!_inputValidator.ValidPassword(password))
            {
                MessageBox.Show("Invalid password");
                return;
            }
            if (password != rePassword)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            if (_database.LoginIsAvailable(username, email) == false)
            {
                MessageBox.Show("User with this username and email already exists");
                return;
            }

            _database.RegisterUser(new User(username, email, password));
            OnButtonClicked?.Invoke(new SignInForm());
        }

        private void OnReturnButtonClick(object sender, EventArgs e)
        {
            OnButtonClicked?.Invoke(new SignInForm());
        }
    }
}
