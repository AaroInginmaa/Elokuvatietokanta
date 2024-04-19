using FromsElokuvaTK;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Database database = new Database("10.146.4.49", "app", "databaseApp!", "moviedb");
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
                int sql = database.DestructiveQuery($"SELECT * FROM usertable WHERE username = '{UserOrEmail}' and password = '{Pword}'or email = '{ UserOrEmail}' and password = '{Pword}';");
                
                //Varmistetaan, että SQL lauseke teki jotain
                if (sql < 0)
                {
                    //Jos kirjautuminen onnistuu, viedään käyttäjä elokuvan lisäys näkymään (MainWindow)
                    Elokuvat elokuvat = new Elokuvat();
                    elokuvat.Show();
                    Close();
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

        //Vie SignUpWindow näkymään
        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            SignupWindow signupWindow = new SignupWindow();
            signupWindow.Show();
            Close();
        }
    }
}
