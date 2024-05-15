<?php

require_once('Database.php');

$search_query = $_GET['query'];
$query = "SELECT * FROM movies WHERE Name LIKE '%" . $search_query . "%'";
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
                      <td>'.$name.'</td>
                      <td>'.$length.' min</td>
                      <td>'.$release_year.'</td>
                      <td>'.$genre.'</td>
                      <td>'.$star.'</td>
                      <td>'.$director.'</td>
                      <td>'.$rating.'</td>
                  </tr>';
        }
        $result->free();
    }
}
?>