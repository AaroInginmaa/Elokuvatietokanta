<?php

require_once('Database.php');
require_once('Movie.php');

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
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

if (in_array(false, $inputData, true)) {
    echo "Invalid input data.";
    die();
}


$database = new Database();

if (!$database->connect()) {
    echo "Database connection failed.<br>";
    die();
}

if (!isset($_POST['name'], $_POST['year'], $_POST['length'], $_POST['genre'], $_POST['main_actor'], $_POST['director'], $_POST['rating'], $_POST['image'])) {
    echo "Incomplete form data.";
    die();
}

$name = $_POST['name'];
$year = $_POST['year'];
$length = $_POST['length'];
$genre = $_POST['genre'];
$main_actor = $_POST['main_actor'];
$director = $_POST['director'];
$rating = $_POST['rating'];
$image = $_POST['image'];

if (!$database->insert_movie($name, $year, $length, $genre, $main_actor, $director, $rating, $image)) {
    echo "Failed to insert new record.<br>";
    $database->close();
    die();
}

header("Location: /elokuvatietokanta/php/index.php");
exit();
