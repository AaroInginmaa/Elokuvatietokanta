<?php


class Database
{
    public $connection;

    public function connect($host, $username, $password)
    {
        $this->connection = new mysqli($host, $username, $password);

        if ($this->connection->connect_error)
        {
            echo "Datbase connection failed";
            return false;
        }
        
        echo "Connected succesfully";
        return true;
    }

    public function insert_movie(Movie $movie)
    {
        $sql = "INSERT INTO elokuvatietokanta.elokuvat (Nimi, Pituus, Julkaistu) VALUES ($movie->name, $movie->lenght, $movie->year)";

        if ($this->connection->query($sql) === TRUE)
        {
            echo "New movie created successfully";
        }
        else
        {
            echo "Error: " . $sql . "<br>" . $this->connection->error;
        }
        
    }

    public function close()
    {
        mysqli_close($this->connection);
    }
}