using System;
using System.Windows.Forms;

namespace FromsElokuvaTK
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void SignUpBTN_Click(object sender, EventArgs e)
        {
            Rekisterointi f2 = new Rekisterointi();
            this.Hide();
            f2.Show();
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            KirjauduForm f3 = new KirjauduForm();
            this.Hide();
            f3.Show();
        }
    }
}
