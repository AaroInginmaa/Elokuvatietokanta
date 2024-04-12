using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FromsElokuvaTK
{
    public partial class KirjauduForm : Form
    {
        Database database = new Database("localhost", "root", "", "elokuvatietokanta");

        public KirjauduForm()
        {
            InitializeComponent();
        }

        private void KirjauduForm_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;

            //TIETOJEN HAKEMINEN
            if(!database.Connect())
            {
                MessageBox.Show("Tietokantaan yhdistäminen epäonnistui.", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int resultCount = database.Select($"SELECT COUNT(*) FROM elokuvatietokanta.kayttajat WHERE nimi = '{username}' AND salasana = '{user_password}'");
            
            database.Close();

            if (resultCount == 1)
            {
                //seuraava page
                MainForm Menuform = new MainForm();
                Menuform.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Vääriä kirjautumis tietoja", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Clear();
                txt_password.Clear();

                //to focus username
                txt_username.Focus();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();

            txt_username.Focus();
        }

        private void button_exít_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Haluatko poistua", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Haluatko mennä takaisin", "Takaisin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                StartForm f1 = new StartForm();
                this.Hide();
                f1.Show();
            }
            else
            {
                this.Show();
            }
                
        }
    }
}
