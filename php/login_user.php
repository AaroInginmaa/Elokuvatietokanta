<?php
require_once("Database.php");
require_once("User.php");

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    echo "<p style='color: red;'>Incorrect request method.</p>";
    exit();
}

if (!empty($_POST['email']) && !empty($_POST['password'])) {
    $identifier = $_POST['email'];

    if (!filter_var($identifier, FILTER_VALIDATE_EMAIL)) {
        $identifier = $_POST['username'];
    }

    $password = $_POST['password'];

    $database = new Database();
    if (!$database->connect()) {
        echo "<p style='color: red;'>Database connection failed.</p>";
        redirect();
        exit();
    }

    $user = $database->get_User($identifier);

    if (!$user) {
        echo "<p style='color: red;'>User not found.</p>";
        redirect();
        $database->close();
        exit();
    }

    if (!$user->verifyPassword($password)) {
        echo "<p style='color: red;'>Invalid password.</p>";
        redirect();
        $database->close();
        exit();
    }

    echo "<p style='color: green;'>Login successful.</p>";

    $database->close();
    session_start();
    $_SESSION['logged_in'] = true;
    $_SESSION['username'] = $user->username;
    $_SESSION['email'] = $user->email;

    header("Location: /php/Website/index.php");
    exit();
} else {
    echo "<p style='color: red;'>Email or password is missing.</p>";
    exit();
}


function redirect(){
    echo "<script>
        setTimeout(function() {
            window.location.href = '/php/login.php';
        }, 2000);
      </script>";
}
?>
