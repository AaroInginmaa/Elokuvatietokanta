using System;
using System.Collections.Generic;

namespace FormsMovieDB
{
    sealed class User
    {
        public User(string username, string email, string password)
        {
            Id = 0;
            Username = username;
            Email = email;
            Password = password;
        }

        public User(int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

    }
}
