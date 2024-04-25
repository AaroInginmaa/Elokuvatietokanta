<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Register</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <div>
        <h2>Register</h2>
        <form action="/elokuvatietokanta/scripts/register_user.php" method="POST">
            <label for="name">User Name</label>
            <br>
            <input type="text" id="name" name="name" autocomplete="off">
            <br>
            <label for="email">Email</label>
            <br>
            <input type="text" id="email" name="email" autocomplete="off">
            <br>
            <label for="password">Password</label>
            <br>
            <input type="password" id="password" name="password" autocomplete="off">
            <br>
            <br>
            <input class="btn btn-primary" type="submit">
    </form>
    </div>
</body>
</html>