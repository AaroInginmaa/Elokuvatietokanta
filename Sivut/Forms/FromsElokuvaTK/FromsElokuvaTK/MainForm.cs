using System;
using System.Windows.Forms;

namespace FromsElokuvaTK
{
    public partial class MainForm : Form
    {
        Database database = new Database("localhost", "root", "", "elokuvatietokanta");

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetData();
        }   

        public bool GetData()
        {
            if (!database.Connect())
            {
                MessageBox.Show("Tietokantaan yhdistäminen epäonnistui.", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            database.FillDataSet(dataGridView1);

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            InsertForm insertForm = new InsertForm();
            insertForm.Show();
        }
    }
}
