using Elokuvatietokanta.Classes;
using System;
using System.Windows;


namespace Elokuvatietokanta
{
    public partial class LoginWindow : Window
    {
        private readonly Database _database = new Database();
        private readonly WindowLoader _windowLoader = WindowLoader.GetInstance();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OnSubmitClick(object sender, RoutedEventArgs e)
        {
            string login = _loginInputField.Text;
            string password = _passwordInputField.Password.ToString();

            try
            {
                _database.Connect();

                int sqlQueryResult = _database.NonDestructiveQuery($"SELECT COUNT(*) FROM usertable WHERE username = '{login}' AND password = '{password}' OR email = '{login}' AND password = '{password}';");

                if (sqlQueryResult == 1)
                {
                    _windowLoader.LoadWindow(new MoviesView());
                }
                else
                {
                    MessageBox.Show("Login is incorrect or user doesn't exist");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

            _database.Close();
        }

        private void OnSignUpClick(object sender, RoutedEventArgs e)
        {
            _windowLoader.LoadWindow(new SignupWindow());
        }
    }
}
