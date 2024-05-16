<?php

require_once('Database.php');

if(isset($_POST['movie_name'])) {
    $movie_name = $_POST['movie_name'];

    $database = new Database();

    if(!$database->connect()) {
        echo "Database connection failed.<br>";
    } else {
        $database->connect();

        $query = "DELETE FROM movies WHERE Name = '$movie_name'";

        if ($database->connection->query($query) === TRUE) {
            echo "Record deleted successfully";
            header("Location: /php/Website/index.php");
        } else {
            echo "Error deleting record: " . $database->connection->error;
        }

        $database->connection->close();
    }
} else {
    echo "Invalid request.";
}
?>