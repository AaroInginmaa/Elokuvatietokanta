<?php

require_once('Database.php');
require_once('Movie.php');

// Validate request method, incase it isn't POST stop the script.
if ($_SERVER['REQUEST_METHOD'] != 'POST')
{
    echo "Incorrect request method.";
    die();
}


if (isset($_POST)) // Make sure POST has a value and is not NULL
{
    // Get the values from POST request made by a html form
    $name = $_POST['name'];
    $length = $_POST['length'];
    $year = $_POST['year'];

    $movie = new Movie($name, $length, $year); // Instantiate a new movie object with necessary values.

    $database = new Database(); // Instantiate a database object.
    
    if(!$database->connect("", "", "")) // Call the connect() fucntion to connect to a database.
        die();

    $database->insert_movie($movie); // insert_movie() takes an Movie object as paramater, removing the neccessity of having to manually pass each value, as it does that automatically.

    $database->close(); // Close the datbase connection
} 
else
{
    echo "No value given or value is NULL.";
    die();
}