<!DOCTYPE html>
<html lang="fi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <div class="container d-flex justify-content-center align-items-center">
        <div class="my-5 card w-25">
            <div class="card-header">
                <h5 class="card-title">Login</h5>
            </div>
            <div class="card-body">
                <form action="/php/login_user.php" method="POST">
                    <div class="mb-3">
                        <label for="email" class="form-label">Email</label>
                        <input type="email" class="form-control" id="email" name="email" autocomplete="off">
                    </div>
                    <div class="mb-3">
                        <label for="password" class="form-label">Password</label>
                        <input type="password" class="form-control" id="password" name="password" autocomplete="off">
                    </div>
                    <button class="btn btn-primary" type="submit">Login</button>
                    <a href="/php/index.php" class="btn btn-primary">Go Back</a>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
