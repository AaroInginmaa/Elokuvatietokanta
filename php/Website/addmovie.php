<!DOCTYPE html>
<html lang="fi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Movie</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <div style="text-align:center;zoom:1.5">
        <h2>Elokuva</h2>
        <form action="post_handler.php" method="POST">
            <label for="name">Elokuvan nimi</label>
            <br>
            <input type="text" id="name" name="name" autocomplete="off">
            <br>
            <label for="length">Elokuvan kesto</label>
            <br>
            <input type="text" id="length" name="length" autocomplete="off">
            <br>
            <label for="year">Elokuvan julkaisuvuosi</label>
            <br>
            <input type="text" id="year" name="year" autocomplete="off" min="1800" max="2024">
            <br>
            <label for="genre">Elokuvan genre</label>
            <br>
            <input type="text" id="genre" name="genre" autocomplete="off">
            <br>
            <label for="main_actor">Elokuvan päänäyttelijä</label>
            <br>
            <input type="text" id="main_actor" name="main_actor" autocomplete="off">
            <br>
            <label for="director">Elokuvan ohjaaja</label>
            <br>
            <input type="text" id="director" name="director" autocomplete="off">
            <br>
            <label for="rating">Elokuvan arvostelu 1-10</label>
            <br>
            <input type="text" id="rating" name="rating" autocomplete="off">
            <br>
            <label for="image">Linkki kuvaan</label>
            <br>
            <input type="text" id="image" name="image" autocomplete="off">
            <br>
            <br>
            <input class="btn btn-primary" value="Lisää elokuva" type="submit">
        </form>
    </div>
</body>
</html>