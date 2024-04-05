<?php

define('DB_HOSTNAME', 'localhost');
define('DB_USERNAME', 'root'); // Muista vaihtaa oikeiksi
define('DB_PASSWORD', ''); // Muista vaihtaa oikeiksi
define('DB_DATABASE', 'elokuvatietokanta');

class Database
{
    public $connection;

    public function connect()
    {
        $this->connection = @new mysqli(DB_HOSTNAME, DB_USERNAME, DB_PASSWORD, DB_DATABASE); // @ Merkki poistaa turhat varoitukset.

        if ($this->connection->connect_error)
        {
            return false;
        }
        
        return true;
    }

    public function close()
    {
        mysqli_close($this->connection);
    }

    public function insert_movie(Movie $movie)
    {
        $sql = "INSERT INTO elokuvatietokanta.elokuvat (Nimi, Pituus, Julkaistu) VALUES ('$movie->name', $movie->lenght, $movie->year)";

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