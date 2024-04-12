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

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string UserOrEmail = UsernameOrEmail.Text;
            string Pword = passWordBox.Password.ToString();
            //Määritetään yhteys tietokantaan !!Varmista, että on oikeat tiedot!!
            string connStr = "server=localhost;user=root;database=elokuvatietokanta;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            //Yrittää avata yhteyden tietokantaan
            try
            {
                conn.Open();

                //SQL lauseke, joka vie tiedot tietokantaan oikeista laatikoista
                //Tällä katsotaan onko login tiedot oikein, ei pitäisi päästää ketään tunnuksetonta tai väärillä tunnuksilla sisään 
                string sql = $"SELECT * FROM usertable WHERE username = '{UserOrEmail}' and password = '{Pword}'or email = '{ UserOrEmail}' and password = '{Pword}';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                //Varmistetaan, että SQL lauseke teki jotain
                if (reader.HasRows)
                {
                    //Jos kirjautuminen onnistuu, viedään käyttäjä elokuvan lisäys näkymään (MainWindow)
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
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
            conn.Close();
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
