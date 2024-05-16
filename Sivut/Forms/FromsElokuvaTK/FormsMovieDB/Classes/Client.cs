using System.Runtime.Remoting.Messaging;

namespace FormsMovieDB
{
    sealed class Client
    {
        private Client() { }

        private static Client _instance;
        private static readonly object _lock = new object();
        private MainForm _mainForm;

        public User LoggedUser { get; private set; }

        public static Client Instance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = new Client();
                }
            }

            return _instance;
        }

        public void LogInUser(User user)
        {
            LoggedUser = user;
        }

        public void LogOutUser(User user)
        {
            LoggedUser = null;
        }

        public bool UserLoggedIn()
        {
            if (LoggedUser == null)
                return false;

            return true;
        }
    }
}
