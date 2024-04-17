using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Elokuvatietokanta
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Nappia painaessa suorittaa tämän koodin
        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            //Määritetään yhteys tietokantaan !!Varmista, että on oikeat tiedot!!
            string connStr = "server=localhost;user=root;database=elokuvatietokanta;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            //Yrittää avata yhteyden tietokantaan
            try
            {
                conn.Open();
                if (string.IsNullOrWhiteSpace(EloNimi.Text))
                {
                    MessageBox.Show("et laittanut elokuviin mitään, merkitse edes elokuvan nimi.");
                }
                else
                {

                    //SQL lauseke, joka vie tiedot tietokantaan oikeista laatikoista
                    string sql = "INSERT INTO elokuvat (Nimi, Pituus, Julkaistu, Genre, Päänäyttelijät, Ohjaaja, Arvio) " +
                    "VALUES ('" + EloNimi.Text + "' , '" + EloPituus.Text + "' , '" + EloJulkaistu.Text + "' , '" + EloGenre.Text +
                    "' , '" + EloPäänäyttelijät.Text + "' , '" + EloOhjaaja.Text + "' , '" + EloArvio.Text + "');";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //Varmistetaan, että SQL lauseke teki jotain
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        //Jos SQL lauseke onnistui näytetään messagebox käyttäjälle
                        MessageBox.Show("Inserted to database successfully \n");
                    }
                }
            }

            //Jos yhteys tai SQL lauseke epäonnistuu
            catch (Exception ex)
            {
                //Jos elokuva on jo tietokannassa näytetään käyttäjälle messagebox
                if (ex.Message.ToLower().Contains("duplicate entry"))
                {
                    MessageBox.Show("This movie is already on the list");
                }
                //Kaikissa muissa epäonnistumisissa tulee käyttäjälle näkyviin messagebox, jossa lukee errorin syy
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            conn.Close();
        }

        private void ToDelete(object sender, RoutedEventArgs e)
        {
            Elokuvat elokuvat = new Elokuvat();
            elokuvat.Show();
            Close();
        }
    }
}

