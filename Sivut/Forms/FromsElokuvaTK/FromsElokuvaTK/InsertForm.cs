using System;
using System.Windows.Forms;

namespace FromsElokuvaTK
{
    public partial class InsertForm : Form
    {
        Database database = new Database("localhost", "root", "", "elokuvatietokanta");

        public InsertForm()
        {
            InitializeComponent();
        }

        private void insertbutton_Click(object sender, EventArgs e)
        {
            string name = nameInput.Text;
            string director = directorInput.Text;
            int year = (int)yearInput.Value;
            int length = (int)lengthInput.Value ;
            string genre = genreInput.Text;
            string mainActor = mainactorInput.Text;
            float rating = (float)ratingInput.Value;

            database.Connect();
            int rowsAffected = database.Insert($"INSERT INTO elokuvatietokanta.elokuvat (elokuva_id, nimi, ohjaaja, julkaisuvuosi, kesto, genre, paa_nayttelija, arvostelu) VALUES ('', '{name}', '{director}', {year}, {length}, '{genre}', '{mainActor}', {rating});");

            Console.WriteLine($"Rows Inserted: {rowsAffected}");
            MessageBox.Show("Movie inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            database.Close();
        }
    }
}
