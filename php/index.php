<?php
session_start();

if (isset($_SESSION['logged_in']) && $_SESSION['logged_in'] === true) {
    $profileButton = '<a class="nav-link active me-3" aria-current="page" href="/elokuvatietokanta/Elokuvatietokanta/php/profile.php">Profile</a>';
} else {
    $profileButton = '<a class="nav-link active me-3" aria-current="page" href="/elokuvatietokanta/Elokuvatietokanta/php/login.php">Login</a>
                     <a class="nav-link active me-3" aria-current="page" href="/elokuvatietokanta/Elokuvatietokanta/php/register.php">Register</a>';
}
?>

<!DOCTYPE html>
<html lang="fi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Elokuvatietokanta</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
<nav class="navbar navbar-light navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <a class="navbar-brand" href="/elokuvatietokanta/Elokuvatietokanta/php/index.php"><strong>Elokuvatietokanta</strong></a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="/elokuvatietokanta/Elokuvatietokanta/php/addmovie.php">Add Movie</a>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Genre
          </a>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#">Drama</a></li>
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Comedy</a></li>
            <li><a class="dropdown-item" href="#">Horror</a></li>
          </ul>
        </li>
      </ul>
      <?php echo $profileButton; ?>
      <form class="d-flex" action="" method="GET">
        <input class="form-control me-2" type="search" name="query" placeholder="Elokuvan nimi" aria-label="Search">
        <button class="btn btn-outline-success" type="submit">Hae</button>
      </form>
    </div>
  </div>
</nav>

<div class="container">
    <table class="table">
        <thead>
          <tr>
            <th scope="col">Kuva</th>
            <th scope="col">Nimi</th>
            <th scope="col">Kesto</th>
            <th scope="col">Vuosi</th>
            <th scope="col">Genre</th>
            <th scope="col">Päänäyttelijä</th>
            <th scope="col">Ohjaaja</th>
            <th scope="col">Arvostelu</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <?php
            if(isset($_GET["query"])) {
              require_once("C:/xampp/htdocs/elokuvatietokanta/Elokuvatietokanta/php/search.php");
            }
            else
            {
              require_once("C:/xampp/htdocs/elokuvatietokanta/Elokuvatietokanta/php/movies_view.php");
            }
            ?>
          </tr>
        </tbody>
    </table>
</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
