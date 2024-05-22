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

                if (ValidPassword(password) && ValidEmail(email))
                {
                    int insertQueryResult = Database.DestructiveQuery($"INSERT INTO usertable (username, email, password) VALUES ('{username}' , '{email} ' , '{password}')");

                    if (insertQueryResult > 0)
                    {
                        MessageBox.Show("User created successfully");
                        _windowLoader.LoadWindow(new MovieEditWindow());
                    }
                }
                else if (password != rePassword)
                {
                    MessageBox.Show("Passwords do not match");
                }
                else if (!ValidEmail (email))
                {
                    MessageBox.Show("Invalid email");
                }
                else if (!ValidPassword(password))
                {
                    MessageBox.Show("You need stronger password " +
                        "\n The password most be 6 or more letters long and most at least one contain uppercase, number and special character");
                }
                else
                {
                    MessageBox.Show("Something went wrong, try again with differnt values");
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

        private bool ValidPassword(string password)
        {
            Regex numbersRegex = new Regex(@"[0-9]+");
            Regex upperLettersRegex = new Regex(@"[A-Z]+");
            Regex minLengthRegex = new Regex(@".{6,}");
            Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (numbersRegex.IsMatch(password) && upperLettersRegex.IsMatch(password) && minLengthRegex.IsMatch(password) && hasSymbols.IsMatch(password))
            {
                return true;
            }

            return false;
        }
        private bool ValidEmail(string email)
        {
            Regex EmailValidator = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$");
                if (EmailValidator.IsMatch(email))
                return true;
            else
                return false;
        }
    }
}
