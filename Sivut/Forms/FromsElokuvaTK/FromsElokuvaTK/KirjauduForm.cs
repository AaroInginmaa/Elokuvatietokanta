using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FromsElokuvaTK
{
    public partial class KirjauduForm : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;

        public KirjauduForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "datasource=localhost;port=3306;username=/**/;password=/**/;database=elokuvatietokanta"; //Vaihtakaa tähän ne oikeat login credentiaalit
            connection = new MySqlConnection(connectionString);
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
            try
            {
                connection.Open();
                string query = $"SELECT COUNT(*) FROM users WHERE Käyttäjänimi = '{username}' AND Salasana = '{user_password}'";
                command = new MySqlCommand(query, connection);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 1)
                {
                    //seuraava page
                    Menuform Menuform = new Menuform();
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
            catch
            {
                MessageBox.Show("Virhe");
            }
            finally
            {
                connection.Close();
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
                Form1 f1 = new Form1();
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
