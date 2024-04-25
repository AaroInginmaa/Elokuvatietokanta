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

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string UserOrEmail = UsernameOrEmail.Text;
            string Pword = passWordBox.Password.ToString();

            //Yrittää avata yhteyden tietokantaan
            try
            {
                _database.Connect();

                //SQL lauseke, joka vie tiedot tietokantaan oikeista laatikoista
                //Tällä katsotaan onko login tiedot oikein, ei pitäisi päästää ketään tunnuksetonta tai väärillä tunnuksilla sisään 
                int sql = _database.NonDestructiveQuery($"SELECT COUNT(*) FROM usertable WHERE username = '{UserOrEmail}' AND password = '{Pword}' OR email = '{UserOrEmail}' AND password = '{Pword}';");

                //Varmistetaan, että SQL lauseke teki jotain
                if (sql == 1)
                {
                    //Jos kirjautuminen onnistuu, viedään käyttäjä elokuvan lisäys näkymään (MainWindow)
                    _windowLoader.LoadWindow(new MoviesView());
                }
                else
                {
                    //Jos login on väärin
                    MessageBox.Show("Login is incorrect or user doesn't exist");
                }
            }
            //Jos yhteys tai SQL lauseke epäonnistuu
            catch (Exception ex)
            {
                //Error viesti käyttäjälle
                MessageBox.Show(ex.ToString());
            }
            _database.Close();
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            _windowLoader.LoadWindow(new SignupWindow());
        }
    }
}
