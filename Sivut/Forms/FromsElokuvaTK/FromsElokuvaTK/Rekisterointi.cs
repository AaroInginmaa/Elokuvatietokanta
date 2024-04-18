using System;
using System.Linq;
using System.Windows.Forms;

namespace FromsElokuvaTK
{
    public partial class Rekisterointi : Form
    {

        Database database = new Database("localhost", "root", "", "elokuvatietokanta");

        public Rekisterointi()
        {
            InitializeComponent();
        }

        private void SubmitData(string username, string email, string password)
        {
            if (!database.Connect())
            {
                MessageBox.Show("Tietokantaan yhdistäminen epäonnistui.", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int rowsAffected = database.Insert($"INSERT INTO elokuvatietokanta.kayttajat (kayttaja_id, nimi, sahkoposti, salasana) VALUES ('NULL', '{username}', '{email}', '{password}')");
            
            Console.WriteLine($"Rows Inserted: {rowsAffected}");
            MessageBox.Show("User data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameFLD.Text;
            string email = EmailFLD.Text;
            string password = PWordFLD.Text;
            string confirmPassword = ConfirmPWordFLD.Text;

            bool isPasswordValid = ValidatePassword(password);
            bool isUsernameValid = ValidateUsername(username);
            bool isEmailValid = ValidateEmail(email);


            if (password != confirmPassword)
            {
                MessageBox.Show("Salasanat eivät täsmää", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isPasswordValid && isUsernameValid && isEmailValid)
            {
                SubmitData(username, email, password);
            }
            else
            {
                MessageBox.Show("Salasana ei täytä monimutkaisuusvaatimuksia.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePassword(string password)
        {
            int n = password.Length;
            bool hasLower = false, hasUpper = false, hasDigit = false, hasSpecialChar = false;

            foreach (char ch in password)
            {
                if (char.IsLower(ch))
                    hasLower = true;
                if (char.IsUpper(ch))
                    hasUpper = true;
                if (char.IsDigit(ch))
                    hasDigit = true;
                if ("!@#$%^&*()-+=[]{};:,.<>?".Contains(ch))
                    hasSpecialChar = true;
            }

            return (hasLower && hasUpper && hasDigit && hasSpecialChar && n >= 6);
        }

        private bool ValidateUsername(string username)
        {
            if(!database.Connect())
            {
                MessageBox.Show("Tietokantaan yhdistäminen epäonnistui.", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int resultCount = database.Select($"SELECT COUNT(*) FROM elokuvatietokanta.kayttajat WHERE nimi = '{username}'");

            if (resultCount > 0)
            {
                MessageBox.Show("Käyttäjänimi on jo käytössä.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidateEmail(string email)
        {
            if (!database.Connect())
            {
                MessageBox.Show("Tietokantaan yhdistäminen epäonnistui.", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int resultCount = database.Select($"Select COUNT(*) From elokuvatietokanta.kayttajat where sahkoposti = '{email}'");

            if (resultCount > 0)
            {
                MessageBox.Show("Käyttäjänimi on jo käytössä.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void quitBTN_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Haluatko poistua", "Poistu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Haluatko mennä takaisin", "Takaisin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                StartForm f1 = new StartForm();
                f1.Show();
                this.Hide();
            }
        }
    }
}
