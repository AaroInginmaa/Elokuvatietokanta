using Elokuvatietokanta.Classes;
using System.Windows;

namespace Elokuvatietokanta
{
    public partial class App : Application
    {
        private readonly WindowLoader WindowLoader = WindowLoader.GetInstance();

        public App()
        {
            InitializeComponent();
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            WindowLoader.LoadWindow(new LoginWindow());
        }
    }
}