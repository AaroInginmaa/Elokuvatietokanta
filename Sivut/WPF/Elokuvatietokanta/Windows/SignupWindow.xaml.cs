using Elokuvatietokanta.Classes;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Elokuvatietokanta
{
    public partial class SignupWindow : Window
    {
        private readonly Database Database = new Database();
        private readonly WindowLoader _windowLoader = WindowLoader.GetInstance();

        public SignupWindow()
        {
            InitializeComponent();
        }

        private void OnSubmitClick(object sender, RoutedEventArgs e)
        {
            string username = _usernameInputField.Text;
            string email = _emailInputField.Text;
            string password = _passwordInputField.Password.ToString();
            string rePassword = _rePasswordInputField.Password.ToString();

            try
            {
                Database.Connect();

                if (ValidPassword(password))
                {
                    int insertQueryResult = Database.DestructiveQuery($"INSERT INTO usertable (username, email, password) VALUES ('{username}' , '{email} ' , '{password}')");

                    if (insertQueryResult > 0)
                    {
                        MessageBox.Show("User created successfully");
                    }
                }
                else if (password != rePassword)
                {
                    MessageBox.Show("Passwords do not match");
                }
                else
                {
                    MessageBox.Show("Invalid signup information");
                }
            }
            catch (Exception excepetion)
            {
                if (excepetion.Message.ToLower().Contains("duplicate entry"))
                {
                    MessageBox.Show("User with this name or email already exists");
                }
                else
                {
                    MessageBox.Show(excepetion.ToString());
                }
            }

            Database.Close();
        }

        public void RedirectToMoviesWindow(object sender, RoutedEventArgs e)
        {
            _windowLoader.LoadWindow(new MovieEditWindow());
        }

        private bool ValidPassword(string password)
        {
            Regex numbersRegex = new Regex(@"[0-9]+");
            Regex upperLettersRegex = new Regex(@"[A-Z]+");
            Regex minLengthRegex = new Regex(@".{6,}");

            if (numbersRegex.IsMatch(password) && upperLettersRegex.IsMatch(password) && minLengthRegex.IsMatch(password))
            {
                return true;
            }

            return false;
        }
    }
}
