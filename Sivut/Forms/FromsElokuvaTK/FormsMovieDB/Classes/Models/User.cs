using System;
using System.Collections.Generic;

namespace FormsMovieDB
{
    sealed class User
    {
        public event Action WatchListUpdated;

        private List<Movie> _watchList;

        public User(string username, string email, string password)
        {
            Id = 0;
            Username = username;
            Email = email;
            Password = password;
            _watchList = new List<Movie>();
        }

        public User(int id, string username, string email, List<Movie> watchList)
        {
            Id = id;
            Username = username;
            Email = email;
            _watchList = watchList;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public List<Movie> WatchList => _watchList;

        public void AddMovieToWatchList(Movie movie)
        {
            _watchList.Add(movie);

            WatchListUpdated?.Invoke();
        }

        public void RemoveMovieFromWatchList(Movie movie)
        {
            _watchList?.Remove(movie);

            WatchListUpdated?.Invoke();
        }
    }
}
