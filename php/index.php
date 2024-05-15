<!DOCTYPE html>
<html lang="fi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Register</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <form action="/Test/login.php">
            <button type="submit" class="btn">Log In</button>
        </form>
        <h2>Register</h2>
        <form action="/Test/register_user.php" method="POST">
            <div class="mb-3">
                <label for="name" class="form-label">User Käykää hei pojat ne teiän enkut ja äikät uusiks miks tässä on väli????? Name</label>
                <input type="text" class="form-control" id="name" name="name" autocomplete="off">
            </div>
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <input type="email" class="form-control" id="email" name="email" autocomplete="off">
            </div>
            <div class="mb-3">
                <label for="password" class="form-label">Password</label>
                <input type="password" class="form-control" id="password" name="password" autocomplete="off">
            </div>
            <button type="submit" class="btn btn-primary">Register</button>
        </form>

        
    </div>
</body>
</html>
