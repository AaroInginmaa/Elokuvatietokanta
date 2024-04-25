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
            $director = $row["Director"];
            $release_year = $row["ReleaseYear"];
            $length = $row["Length"]; 
            $genre = $row["Genres"]; 
            $star = $row["MainActors"]; 
            $rating = $row["Rating"]; 
            $image= $row["Image"];
            

            echo '<tr> 
                      <td><img src="'.$image.'" alt="" width="200" height="200"></td>
                      <td>'.$id.'</td> 
                      <td>'.$name.'</td> 
                      <td>'.$director.'</td> 
                      <td>'.$release_year.'</td> 
                      <td>'.$length.' min</td> 
                      <td>'.$genre.'</td> 
                      <td>'.$star.'</td> 
                      <td>'.$rating.'</td> 

                      
                  </tr>';

            
        }
        $result->free();
    }
}
?>