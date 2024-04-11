<?php

require_once('Database.php');

$query = "SELECT * FROM elokuvatietokanta.elokuvat;";
$database = new Database();
    
if(!$database->connect()) {
    echo "Database connection failed.<br>";
} else {
    $database->connect();

    if ($result = $database->connection->query($query)) {
        while ($row = $result->fetch_assoc()) {
            $id = $row["elokuva_id"];
            $name = $row["nimi"];
            $director = $row["ohjaaja"];
            $release_year = $row["julkaisuvuosi"];
            $length = $row["kesto"]; 
            $genre = $row["genre"]; 
            $star = $row["paa_nayttelija"]; 
            $rating = $row["arvostelu"]; 

            echo '<tr> 
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