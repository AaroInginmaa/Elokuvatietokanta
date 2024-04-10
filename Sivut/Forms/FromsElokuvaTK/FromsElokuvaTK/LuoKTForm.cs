using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FromsElokuvaTK
{
    public partial class LuoKTForm : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;

        public LuoKTForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "datasource=localhost;port=3306;username=test;password=test;database=elokuvatietokanta"; //Vaihtakaa tähän ne oikeat login credentiaalit
            connection = new MySqlConnection(connectionString);
        }

        private void SubmitData(string username, string email, string password)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO users (Käyttäjänimi, sposti, Salasana) VALUES (@Username, @Email, @Password)";

                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows Inserted: {rowsAffected}");

                MessageBox.Show("User data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameFLD.Text;
            string email = EmailFLD.Text;
            string password = PWordFLD.Text;
            string confirmPassword = ConfirmPWordFLD.Text;

            bool isPasswordValid = ValidatePassword(password);

            if (password != confirmPassword)
            {
                MessageBox.Show("Salasanat eivät täsmää", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isPasswordValid)
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
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
        }
    }
}
