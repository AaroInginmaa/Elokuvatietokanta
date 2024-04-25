<?php

require_once("Database.php");
require_once("User.php");

// Varmista, että request on POST, jos ei ole, scripti pysähtyy.
if ($_SERVER['REQUEST_METHOD'] != 'POST')
{
    echo "Incorrect request method.";
    die();
}

if (isset($_POST)) // Varmista että POST requesti ei ole NULL
{
    $name = $_POST['name'];
    $email = $_POST['email'];
    $password = $_POST['password'];

    $user = new User($name, $email, $password);
    $database = new Database();
    
    if(!$database->connect()) // Yhditsää tietokantaan Kutsumalla connect() funktiota, jos yhteys epäonnistuu, scipti pysähtyy.
    {
        echo "Database connection failed.<br>";
        die();
    }    

    if(!$database->insert_user($user)) // Yrittää tehdä uuden käyttäjän tietokantaan, jos epäonnistuu, scipti pysähtyy.
    {
        echo "Failed to create new user.<br>";
        $database->close();
        die();
    }

    header("Location:/elokuvatietokanta/pages/index.php");

    $database->close(); // Sulkee tietokantayhteyden
} 
else
{
    echo "No value given or value is NULL.";
    die();
}