<?php

require_once("config.php");
require_once("User.php");

class Database
{
    public $connection;

    public function connect()
    {
        $this->connection = @new mysqli(DB_HOSTNAME, DB_USERNAME, DB_PASSWORD, DB_DATABASE);

        if ($this->connection->connect_error) {
            return false;
        }
        
        return true;
    }

    public function close()
    {
        mysqli_close($this->connection);
    }

    public function insert_movie($name, $director, $year, $length, $genre, $main_actor, $rating)
    {
        $name = $this->connection->real_escape_string($name);
        $director = $this->connection->real_escape_string($director);
        $genre = $this->connection->real_escape_string($genre);
        $main_actor = $this->connection->real_escape_string($main_actor);
        $rating = (int)$this->connection->real_escape_string($rating);

        $sql = "INSERT INTO movies (name, director, year, length, genre, main_actor, rating) 
                VALUES ('$name', '$director', '$year', '$length', '$genre', '$main_actor', '$rating')";

        if ($this->connection->query($sql) === TRUE) {
            return true;
        } else {
            echo $this->connection->error . "<br>";
            return false;
        }
    }
    public function insert_user(User $user)
    {
        $username = $this->connection->real_escape_string($user->username);
        $email = $this->connection->real_escape_string($user->email);
        $password = $this->connection->real_escape_string($user->password);

        $sql = "INSERT INTO usertable (username, email, password) VALUES ('$username', '$email', '$password')";

        if ($this->connection->query($sql) === TRUE) {
            return true;
        } else {
            echo $this->connection->error . "<br>";
            return false;
        }
    }

    public function get_User($identifier)
    {
        $identifier = $this->connection->real_escape_string($identifier);
        $sql = "SELECT * FROM usertable WHERE email = '$identifier' OR username = '$identifier'";
        $result = $this->connection->query($sql);

        if ($result && $result->num_rows > 0) {
            $user_data = $result->fetch_assoc();
            return new User($user_data['username'], $user_data['email'], $user_data['password']);
        } else {
            return null;
        }
    }
}
?>
