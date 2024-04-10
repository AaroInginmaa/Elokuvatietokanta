<?php

require_once('Database.php');
require_once('Movie.php');

// Varmista, että request on POST, jos ei ole, scripti pysähtyy.
if ($_SERVER['REQUEST_METHOD'] != 'POST')
{
    echo "Incorrect request method.";
    die();
}

if (isset($_POST)) // Varmista että POST requesti ei ole NULL
{
    $name = $_POST['name'];
    $director = $_POST['director'];
    $year = $_POST['year'];
    $length = $_POST['length'];
    $genre = $_POST['genre'];
    $main_actor = $_POST['main_actor'];
    $rating = $_POST['rating'];

    $movie = new Movie($name, $director, $year, $length, $genre, $main_actor, $rating);
    $database = new Database();
    
    if(!$database->connect()) // Yhditsää tietokantaan Kutsumalla connect() funktiota, jos yhteys epäonnistuu, scipti pysähtyy.
    {
        echo "Database connection failed.<br>";
        die();
    }    

    if(!$database->insert_movie($movie)) // Yrittää tehdä uuden elokuvan tietokantaan, jos epäonnistuu, scipti pysähtyy.
    {
        echo "Failed to insert new record.<br>";
        $database->close();
        die();
    }

    echo "New record created succesfully";

    $database->close(); // Sulkee tietokantayhteyden
} 
else
{
    echo "No value given or value is NULL.";
    die();
}