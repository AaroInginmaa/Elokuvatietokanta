<?php

require_once('Database.php');

$query = "SELECT * FROM moviedb.movies;";
$database = new Database();
    
if(!$database->connect()) {
    echo "Database connection failed.<br>";
} else {
    $database->connect();

    if ($result = $database->connection->query($query)) {
        while ($row = $result->fetch_assoc()) {
            
            $id = $row["idMovies"];
            $name = $row["Name"];
            $length = $row["Length"];
            $release_year = $row["ReleaseYear"];
            $genre = $row["Genres"];
            $star = $row["MainActors"];
            $director = $row["Director"];
            $rating = $row["Rating"]; 
            $image= $row["Image"];
            echo '<tr> 
                      <td><img src="'.$image.'" alt="" width="200" height="200"></td>
                      <td>'.$name.'</td>
                      <td>'.$length.' min</td>
                      <td>'.$release_year.'</td>
                      <td>'.$genre.'</td>
                      <td>'.$star.'</td>
                      <td>'.$director.'</td>
                      <td>'.$rating.'</td>
                      <td><form action="delete_movie.php" method="POST">
                      <input type="hidden" name="movie_name" value="'.$name.'">
                      <button type="submit">Poista</button>
                  </form></td>
                  </tr>';
        }
        $result->free();
    }
}
?>