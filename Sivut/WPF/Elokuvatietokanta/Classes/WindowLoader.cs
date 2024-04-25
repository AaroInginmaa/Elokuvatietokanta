using System.Windows;

namespace Elokuvatietokanta.Classes
{
    internal static class WindowLoader
    {
        private static Window? _currentActiveWindow;

        public static void LoadWindow(Window window)
        {
            _currentActiveWindow?.Close();
            _currentActiveWindow = window;
            window.Show();
        }
    }
}
