<?php

require_once('Database.php');
require_once('Movie.php');

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    echo "Incorrect request method.";
    die();
}

$validateYearFilter = FILTER_VALIDATE_INT;
$validateYearOptions = array(
    'options' => array(
        'min_range' => 1800,
        'max_range' => 2024
    )
);

$validateLengthFilter = FILTER_VALIDATE_INT;
$validateLengthOptions = array(
    'options' => array(
        'min_range' => 1,
        'max_range' => 600
    )
);

$validateRatingFilter = FILTER_CALLBACK;
$validateRatingOptions = array(
    'options' => function ($value) {
        return str_replace(',', '.', $value);
    }
);

$inputLength = filter_input(INPUT_POST, 'length', $validateLengthFilter, $validateLengthOptions);
$inputYear = filter_input(INPUT_POST, 'year', $validateYearFilter, $validateYearOptions);
$inputRating = filter_input(INPUT_POST, 'rating', $validateRatingFilter, $validateRatingOptions);

$inputRating = (float) $inputRating;
$inputRating = round($inputRating, 1);

if ($inputLength === false) {
    echo "Invalid length";
    die();
} else if ($inputYear === false) {
    echo "Invalid year";
    die();
}
if ($inputRating < 0 || $inputRating > 10) {
    echo "Invalid rating, please give value between 0 and 10";
    die();
}

$database = new Database();

if (!$database->connect()) {
    echo "Database connection failed.<br>";
    die();
}

if (!isset($_POST['name'], $_POST['length'], $_POST['year'], $_POST['genre'], $_POST['main_actor'], $_POST['director'], $inputRating, $_POST['image'])) {
    echo "Incomplete form data.";
    die();
}



$name = $_POST['name'];
$year = $_POST['year'];
$length = $_POST['length'];
$genre = $_POST['genre'];
$main_actor = $_POST['main_actor'];
$director = $_POST['director'];
$image = $_POST['image'];



if (!$database->insert_movie($name, $length, $year, $genre, $main_actor, $director, $inputRating , $image)) {
    echo "Failed to insert new record.<br>";
    $database->close();

}
if ("movie with these values already exists") {
    echo "This movie is already in the database";
    header("Location: /Test/Website/index.php");
    die();
}

//  exit();
