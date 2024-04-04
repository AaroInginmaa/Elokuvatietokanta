using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FromsElokuvaTK
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;




        /*  string connectionString = "datasource=localhost; port=3306;username=root;password=;database=demouser";
            connection = new MySqlConnection(connectionString);*/
        //HUOM NÄÄ OON KOPIOITU SUORAAN AIKASEMMASTA FORMS HOMMASTA. En tiiä onko mistää hyötyä.
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void SignUpBTN_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            // hide the current form
            this.Hide();

            // use the `Show()` method to access the new non-modal form
            f2.Show();
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
