using FormsMovieDB.Classes;
using FormsMovieDB.Forms;
using System;
using System.Windows.Forms;

namespace FormsMovieDB
{
    public partial class SignInForm : Form
    {
        public static event Action<Form> CreateAccountButtonClicked;
        public static event Action<Form> SignInButtonClicked;
        private readonly Client Client = Client.Instance();
        private Database _database = new Database();
        private UserInputValidator _inputValidator = new UserInputValidator();
        public SignInForm()
        {
            InitializeComponent();
        }
        private void OnCreateAccountButtonClick(object sender, EventArgs e)
        {
            CreateAccountButtonClicked?.Invoke(new RegisterForm());
        }
        private void OnSignInButtonClicked(object sender, EventArgs e)
        {
            string login = _loginInputField.Text;
            string password = _passwordInputField.Text;
            if (!_inputValidator.ValidInput(login) && !_inputValidator.ValidInput(password))
                return;

            _database.LoginUser(login, password);
            if (Client.UserLoggedIn())
            {
                SignInButtonClicked?.Invoke(new ProfileForm());
            }
        }
    }
}
