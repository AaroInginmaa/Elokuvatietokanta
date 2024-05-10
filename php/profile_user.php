<?php
session_start();

if (!isset($_SESSION['logged_in']) || !$_SESSION['logged_in']) {
    header("Location: /elokuvatietokanta/Elokuvatietokanta/php/login.php");
    exit();
}

require_once("Database.php");
require_once("User.php");

$database = new Database();
if (!$database->connect()) {
    echo "<p style='color: red;'>Database connection failed.</p>";
    exit();
}

$user = $database->get_User($_SESSION['email']);

if (!$user) {
    echo "<p style='color: red;'>User not found.</p>";
    $database->close();
    exit();
}

$database->close();

$username = $user->username;
$email = $user->email;
?>