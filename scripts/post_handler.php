<?php

require_once('Database.php');
require_once('Movie.php');

if ($_SERVER['REQUEST_METHOD'] != 'POST')
{
    echo "Incorrect request method.";
    die();
}
$validationRules = array(
    'year' => array(
        'filter' => FILTER_VALIDATE_INT,
        'options' => array(
            'min_range' => 1800,
            'max_range' => 2024
        )
    ),
    'length' => array(
        'filter' => FILTER_VALIDATE_INT,
        'options' => array(
            'min_range' => 1,
            'max_range' => 300
        )
    ),
    'rating' => array(
        'filter' => FILTER_VALIDATE_INT,
        'options' => array(
            'min_range' => 1,
            'max_range' => 10
        )
    )
);
$inputData = filter_input_array(INPUT_POST, $validationRules);
$query = "SELECT * FROM moviedb.movies WHERE Name = '" . $_POST['name'] . "'";
$database = new Database();

if (!$database->connect()) {
    echo "Database connection failed.<br>";
} else {
    $result = $database->connection->query($query);

    if ($result->num_rows > 0 || (in_array(false, $inputData, true))) {
        header("Location:/elokuvatietokanta/pages/addmovie.php");
        die();
    }
}
if (isset($_POST))
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
    
    if(!$database->connect())
    {
        echo "Database connection failed.<br>";
        die();
    }    

    if(!$database->insert_movie($movie, $name, $director, $year, $length, $genre, $main_actor, $rating))
    {
        echo "Failed to insert new record.<br>";
        $database->close();
        die();
    }

    header("Location:/elokuvatietokanta/pages/index.php");

    $database->close();
} 
else
{
    echo "No value given or value is NULL.";
    die();
}