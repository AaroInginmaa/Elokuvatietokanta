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

    $movie = new Movie($name, $length, $year);
    $database = new Database();
    
    if(!$database->connect("", "", "")) // Call the connect() fucntion to connect to a database. If connection fails, script stops executing.
    {
        die();
    }    

    if(!$database->insert_movie($movie)) // Tries to insert a new record to datbase, if it fails connection closes and script stops executing.
    {
        $database->close();
        die();
    }    

    $database->close(); // Close the datbase connection
} 
else
{
    echo "No value given or value is NULL.";
    die();
}