<?php


class Database
{
    public $connection;

    public function connect($host, $username, $password)
    {
        $this->connection = new mysqli($host, $username, $password);

        if ($this->connection->connect_error)
        {
            echo "Datbase connection failed<br>";
            return false;
        }
        
        echo "Connected succesfully<br>";
        return true;
    }

    public function insert_movie(Movie $movie)
    {
        $sql = "INSERT INTO elokuvatietokanta.elokuvat (Nimi, Pituus, Julkaistu) VALUES ('$movie->name', $movie->lenght, $movie->year)";

        if ($this->connection->query($sql) === TRUE)
        {
            echo "New record created successfully<br>";
            return true;
        }
        else
        {
            echo "Error creating new record" . $this->connection->error . "<br>";
            return false;
        }
        
    }

    public function close()
    {
        mysqli_close($this->connection);
    }
}