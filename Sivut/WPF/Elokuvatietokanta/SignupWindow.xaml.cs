using FromsElokuvaTK;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Elokuvatietokanta
{
    //!! Sähköposti seuraavaksi !!
    public partial class SignupWindow : Window
    {

        Database database = new Database("localhost", "root", "", "elokuvatietokanta");
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
                //Katsotaan tehtävän annonmukaiseksi salasana
                if(Pword.Length >= 6 & Pword.Any(char.IsUpper) & Pword.Any(ch => ! char.IsLetterOrDigit(ch)))
                {
                    ValidPassword = true;
                }

                //Suoritetaan, kun salasana on halutunlainen
                if (ValidPassword == true)
                {
                    //SQL lauseke, joka vie tiedot tietokantaan oikeista laatikoista
                    int sql = database.Insert($"INSERT INTO usertable (username, email, password) VALUES ('{User}' , '{email} ' , '{Pword}')");
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

        private void ToLogin(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }
    }
}
