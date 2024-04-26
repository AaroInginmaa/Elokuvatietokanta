<?php
session_start();

$_SESSION = array();

session_destroy();

header("Location: /elokuvatietokanta/pages/index.php");
exit();
?>
