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

        private readonly Database _database = new Database();
        private readonly UserInputValidator _inputValidator = new UserInputValidator();

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
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (!_inputValidator.ValidInput(login) && !_inputValidator.ValidInput(password))
                return;

            _database.LoginUser(login, password);
            if (Client.UserLoggedIn())
            {

                SignInButtonClicked?.Invoke(new HomeForm());
            }
            else
            {
                MessageBox.Show("Invalid user or password");
            }
        }
    }
}
