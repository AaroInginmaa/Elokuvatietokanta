<?php

require_once("config.php"); // Tietokannan tiedot

class Database
{
    public $connection;

    // Tekee yhteyden mysql tietokantaan
    public function connect()
    {
        $this->connection = @new mysqli(DB_HOSTNAME, DB_USERNAME, DB_PASSWORD, DB_DATABASE); // @ Merkki poistaa turhat varoitukset.

        if ($this->connection->connect_error)
        {
            return false;
        }
        
        return true;
    }

    // Sulkee yhteyden tietokantaan
    public function close()
    {
        mysqli_close($this->connection);
    }

    // Tekee uuden elokuvan tietokantaan)
    public function insert_movie(Movie $movie)
    {
        $sql = "INSERT INTO moviedb.movies (idMovies, Name, Director, ReleaseYear, Length, Genres, MainActors, Rating) VALUES (0, '$movie->name', '$movie->director', $movie->year, $movie->length, '$movie->genre', '$movie->main_actor', $movie->rating)";

        if ($this->connection->query($sql) === TRUE)
        {
            return true;
        }
        else
        {
            echo $this->connection->error . "<br>";
            return false;
        }
    }

    public function insert_user(User $user)
    {
        $sql = "INSERT INTO moviedb.usertable (idUser, username, email, password) VALUES (0, '$user->name', '$user->email', '$user->password')";

        if ($this->connection->query($sql) === TRUE)
        {
            return true;
        }
        else
        {
            echo $this->connection->error . "<br>";
            return false;
        }
    }
}