using FromsElokuvaTK;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Elokuvatietokanta
{
    //!! Sähköposti seuraavaksi !!
    public partial class SignupWindow : Window
    {

        Database database = new Database("10.146.4.49", "app", "databaseApp!", "moviedb");
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            //Määritetään yhteys tietokantaan !!Varmista, että on oikeat tiedot!!
            //Yrittää avata yhteyden tietokantaan
            string Pword = passWordBox.Password.ToString();
            string User = Username.Text;
            string email = Email.Text;
            bool ValidPassword = false;
            
            try
            {
                database.Connect();

                ValidPassword = ValidatePassword(Pword);

                //Suoritetaan, kun salasana on halutunlainen
                if (ValidPassword)
                {
                    //SQL lauseke, joka vie tiedot tietokantaan oikeista laatikoista
                    int sql = database.DestructiveQuery($"INSERT INTO usertable (username, email, password) VALUES ('{User}' , '{email} ' , '{Pword}')");
                    if (sql > 0)
                    {
                        //Jos SQL lauseke onnistui näytetään messagebox käyttäjälle
                        MessageBox.Show("User created successfully");
                        //Jos kirjautuminen onnistuu, viedään käyttäjä elokuvan lisäys näkymään (MainWindow)
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Close();
                    }
                }
                else if(Pword != PasswordAgain.Password.ToString())
                {
                    //Jos salasanat eivät ole sama
                    MessageBox.Show("Passwords do not match");
                }
                else
                {
                    //Jos Signup ei ole oikein
                    MessageBox.Show("Invalid signup information");
                }
            }
            //Jos yhteys tai SQL lauseke epäonnistuu
            catch (Exception ex)
            {
                //Jos käyttäjä tai sähköposti on jo tietokannassa näytetään käyttäjälle messagebox
                if (ex.Message.ToLower().Contains("duplicate entry"))
                {
                    MessageBox.Show("User with this name or email already exists");
                }
                //Kaikissa muissa epäonnistumisissa tulee käyttäjälle näkyviin messagebox, jossa lukee errorin syy
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            database.Close();
        }

        private void ToMovies(object sender, RoutedEventArgs e)
        {
            Windows.LoadMovies();
            Close();
        }

        private bool ValidatePassword(string password)
        {
            // Regexiä salasanan varmistamiseen
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{6,}");

            //Katsotaan tehtävän annonmukaiseksi salasana
            if (hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password))
            {
                return true;
            }
            else return false;
        }
    }
}
