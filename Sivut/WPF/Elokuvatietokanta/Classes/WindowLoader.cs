using System.Windows;

namespace Elokuvatietokanta.Classes
{
    sealed class WindowLoader
    {
        private static WindowLoader? _instance;
        private static readonly object _lock = new object();
        private Window? _currentActiveWindow;

        private WindowLoader() { }

        public static WindowLoader GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = new WindowLoader();
                }
            }

            return _instance;
        }

        public void LoadWindow(Window window)
        {
            _currentActiveWindow?.Close();

            _currentActiveWindow = window;
            window.Show();
        }
    }
}
