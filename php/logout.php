<?php
session_start();

$_SESSION = array();

session_destroy();

header("Location: /elokuvatietokanta/Elokuvatietokanta/php/index.php");
exit();
?>
