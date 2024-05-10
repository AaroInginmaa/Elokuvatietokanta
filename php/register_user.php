<?php
require_once("Database.php");
require_once("User.php");

// Ensure it's a POST request
if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    echo "<p style='color: red;'>Incorrect request method.</p>";
    die();
}

// Check if POST data is not empty
if (!empty($_POST['name']) && !empty($_POST['email']) && !empty($_POST['password'])) {
    $name = $_POST['name'];
    $email = $_POST['email'];
    $password = $_POST['password'];

    // Username length check
    if (strlen($name) > 20) {
        echo "<p style='color: red;'>Username must be 20 characters or less.</p>";
        redirect();
        die();
    }

    // Password complexity check
    if (strlen($password) < 6 || !preg_match('/[A-ZÅÄÖ]/', $password) || !preg_match('/[!#?&%$€£@]/', $password)) {
        echo "<p style='color: red;'>Password must be at least 6 characters long and contain at least one uppercase letter and one special character (!#?&%€£$@).</p>";
        redirect();
        die();
    }

    // Email format validation
    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        echo "<p style='color: red;'>Invalid email format.</p>";
        redirect();
        die();
    }

    // Create new User object
    $user = new User($name, $email, $password);
    $database = new Database();
    
    if (!$database->connect()) {
        echo "<p style='color: red;'>Database connection failed.</p>";
        redirect();
        die();
    }    

    // Attempt to insert user into the database
    if (!$database->insert_user($user)) {
        echo "<p style='color: red;'>Failed to create new user.</p>";
        redirect();
        $database->close();
        die();
    }

    // Registration successful
    echo "<p id='registrationMessage' style='color: green;'>User registered successfully.</p>";

    $database->close();

    // Redirect to index.php after successful registration
    echo "<script>
            setTimeout(function() {
                window.location.href = '/elokuvatietokanta/Elokuvatietokanta/php/index.php';
            }, 2000);
          </script>";

} else {
    echo "<p style='color: red;'>No value given or value is NULL.</p>";
    die();
}

    function redirect(){
        echo "<script>
            setTimeout(function() {
                window.location.href = '/elokuvatietokanta/Elokuvatietokanta/php/register.php';
            }, 2000);
          </script>";
    }
?>
