using FormsMovieDB.Classes;
using System;
using System.Windows.Forms;

namespace FormsMovieDB
{
    public partial class RegisterForm : Form
    {
        public static event Action<Form> ReturnButtonClicked;

        Database _database = new Database();
        UserInputValidator _inputValidator = new UserInputValidator();

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

            if (!_inputValidator.ValidUsername(username) || !_inputValidator.ValidEmail(email) || !_inputValidator.ValidPassword(password))
                return;

            if (password != rePassword)
                return;

            if (_database.LoginIsAvailable(username, email) == false)
                return;

            _database.RegisterUser(new User(username, email, password));

            ReturnButtonClicked?.Invoke(new SignInForm());
        }

        private void OnReturnButtonClick(object sender, System.EventArgs e)
        {
            ReturnButtonClicked?.Invoke(new SignInForm());
        }
    }
}
