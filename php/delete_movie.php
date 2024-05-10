<?php

require_once('Database.php');

if(isset($_POST['movie_name'])) {
    $movie_name = $_POST['movie_name'];

    $database = new Database();

    if(!$database->connect()) {
        echo "Database connection failed.<br>";
    } else {
        $database->connect();

        // Assuming 'Name' is the column storing movie names
        $query = "DELETE FROM moviedb.movies WHERE Name = '$movie_name'";

        if ($database->connection->query($query) === TRUE) {
            echo "Record deleted successfully";
        } else {
            echo "Error deleting record: " . $database->connection->error;
        }

        $database->connection->close();
    }
} else {
    echo "Invalid request.";
}
?>