using Elokuvatietokanta.Classes;
using System;
using System.Windows;


namespace Elokuvatietokanta
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Database database = new Database();

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
                database.Connect();

                //SQL lauseke, joka vie tiedot tietokantaan oikeista laatikoista
                //Tällä katsotaan onko login tiedot oikein, ei pitäisi päästää ketään tunnuksetonta tai väärillä tunnuksilla sisään 
                int sql = database.NonDestructiveQuery($"SELECT COUNT(*) FROM usertable WHERE username = '{UserOrEmail}' AND password = '{Pword}' OR email = '{UserOrEmail}' AND password = '{Pword}';");

                //Varmistetaan, että SQL lauseke teki jotain
                if (sql == 1)
                {
                    //Jos kirjautuminen onnistuu, viedään käyttäjä elokuvan lisäys näkymään (MainWindow)
                    WindowLoader.LoadWindow(new MoviesView());
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
            database.Close();
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            WindowLoader.LoadWindow(new SignupWindow());
        }
    }
}
