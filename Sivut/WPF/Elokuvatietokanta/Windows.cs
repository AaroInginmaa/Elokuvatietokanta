using System;
using System.Windows;

namespace Elokuvatietokanta
{
    internal static class Windows
    {
        public static void LoadMain()
        {
            MainWindow window = new MainWindow();
            window.Show();
        }

        public static void LoadMovies()
        {
            Elokuvat window = new Elokuvat();
            window.Show();
        }

        public static void LoadLogin()
        {
            LoginWindow window = new LoginWindow();
            window.Show();
        }

        public static void LoadSignUp()
        {
            SignupWindow window = new SignupWindow();
            window.Show();
        }
    }
}
