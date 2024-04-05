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
    public partial class Form2 : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;
        public Form2()
        {
            InitializeComponent();

            string connectionString = "datasource=localhost; port=3306;username=root;password=;database=demoElokuva";
            connection = new MySqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = UsernameFLD.Text;
            string email = EmailFLD.Text;
            string Pword = PWordFLD.Text;
            string ConfirmPWord = ConfirmPWordFLD.Text;

            //salasanan matchaus chechk
            

        }

    }
}
