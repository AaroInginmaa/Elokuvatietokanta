<!DOCTYPE html>
<html lang="fi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Redirected Page</title>
</head>
<body>
    <h1>Redirected Page</h1>

    <?php
    if (isset($_GET['cooldown']) && isset($_GET['message'])) {
        $cooldown = intval($_GET['cooldown']);
        $message = urldecode($_GET['message']);

        echo "<p>$message</p>";
        echo "<p>Redirecting back to the original site in <span id='cooldown'>$cooldown</span> seconds.</p>";

        echo "<script>
            var remainingTime = $cooldown;
            var cooldownInterval = setInterval(function() {
                remainingTime--;
                document.getElementById('cooldown').textContent = remainingTime;
                if (remainingTime <= 0) {
                    clearInterval(cooldownInterval);
                    window.location.replace('original_site_url_here');
                }
            }, 1000);
        </script>";
    }
    ?>

</body>
</html>
