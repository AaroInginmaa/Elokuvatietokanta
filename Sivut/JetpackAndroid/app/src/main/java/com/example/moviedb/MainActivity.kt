package com.example.moviedb

import android.content.Context
import android.os.Bundle
import android.widget.Toast
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.itemsIndexed
import androidx.compose.material3.Button
import androidx.compose.material3.Card
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.unit.dp
import coil.compose.AsyncImage


class MainActivity : ComponentActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            MovieDBApp(LocalContext.current)
        }
    }
}

//Tässä on pääruudun logiikka
@Composable
fun MovieDBApp(context: Context) {
    var isLoginScreen by remember { mutableStateOf(true) }
    var isSignedIn by remember { mutableStateOf(false) }
    var Addmovie by remember { mutableStateOf(false) }
    var ViewMovie by remember { mutableStateOf(false) }
    var username by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }
    var email by remember { mutableStateOf("") }

    Surface {
        if (isSignedIn) {
            if (Addmovie) {

                AddMovieScreen(
                    context = context,
                    onAddMovieButtonClick = { name, releaseDate, length, genre, director, rate, mainActors ->
                        Toast.makeText(context, "Adding Movie: $name", Toast.LENGTH_SHORT).show()
                    },
                    onBackButtonClick = { Addmovie = false }
                )
            } else if (ViewMovie) {
                ViewMoviesScreen()
            } else {
                MainScreen(
                    onAddMovieClick = { Addmovie = true },
                    onViewMoviesClick = {
                        ViewMovie = true
                        Toast.makeText(context, "View Movies clicked", Toast.LENGTH_SHORT).show()
                    }
                )
            }
        } else {
            if (isLoginScreen) {
                LoginScreen(
                    onLoginButtonClick = { user, pass ->
                        if (user.isNotEmpty() && pass.isNotEmpty()) {
                            Toast.makeText(context, "Welcome back $user", Toast.LENGTH_SHORT).show()
                            isSignedIn = true
                        } else {
                            Toast.makeText(context, "Please fill in all fields", Toast.LENGTH_SHORT).show()
                        }
                    },
                    onSignUpButtonClick = { isLoginScreen = false }
                )
            } else {
                SignUpScreen(
                    context = context,
                    onContinueButtonClick = { user, pass, mail ->
                        if (user.isNotEmpty() && pass.isNotEmpty() && mail.isNotEmpty()) {
                            Toast.makeText(context, "Nice to meet you $user", Toast.LENGTH_SHORT).show()
                            isSignedIn = true
                        } else {
                            Toast.makeText(context, "Please fill in all fields", Toast.LENGTH_SHORT).show()
                        }
                    },
                    onLoginButtonClick = { isLoginScreen = true }
                )
            }
        }
    }
}
@Composable
fun MainScreen(
    onAddMovieClick: () -> Unit,
    onViewMoviesClick: () -> Unit
) {
    Column(
        modifier = Modifier.fillMaxSize(),
        verticalArrangement = Arrangement.Center,
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        Text("Welcome to MovieDB")

        Spacer(modifier = Modifier.height(16.dp))

        Button(onClick = { onAddMovieClick() }) {
            Text("Add Movie")
        }

        Spacer(modifier = Modifier.height(8.dp))

        Button(onClick = { onViewMoviesClick() }) {
            Text("View Movies")
        }
    }
}


@Composable
fun LoginScreen(
    onLoginButtonClick: (String, String) -> Unit,
    onSignUpButtonClick: () -> Unit
) {
    var username by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }

    Column(
        modifier = Modifier.fillMaxSize(),
        verticalArrangement = Arrangement.Center,
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        Text("Login Screen")

        Spacer(modifier = Modifier.height(16.dp))

        TextField(
            value = username,
            onValueChange = { username = it },
            label = { Text("Username") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = password,
            onValueChange = { password = it },
            label = { Text("Password") },
            visualTransformation = PasswordVisualTransformation(),
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(16.dp))

        Button(onClick = { onLoginButtonClick(username, password) }) {
            Text("Login")
        }

        Spacer(modifier = Modifier.height(8.dp))

        Button(onClick = { onSignUpButtonClick() }) {
            Text("Sign Up")
        }
    }
}

@Composable
fun SignUpScreen(
    context: Context,
    onContinueButtonClick: (String, String, String) -> Unit,
    onLoginButtonClick: () -> Unit
) {
    var username by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }
    var email by remember { mutableStateOf("") }

    Column(
        modifier = Modifier.fillMaxSize(),
        verticalArrangement = Arrangement.Center,
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        Text("Sign Up Screen")

        Spacer(modifier = Modifier.height(16.dp))

        TextField(
            value = username,
            onValueChange = { username = it },
            label = { Text("Username") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = password,
            onValueChange = { password = it },
            label = { Text("Password") },
            visualTransformation = PasswordVisualTransformation(),
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = email,
            onValueChange = { email = it },
            label = { Text("Email") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(16.dp))

        Button(onClick = {
            if (username.isNotBlank() && password.isNotBlank() && email.isNotBlank()) {
                if (isPasswordValid(password)) {
                    onContinueButtonClick(username, password, email)
                } else {
                    Toast.makeText(context, "Password is not strong enough", Toast.LENGTH_SHORT).show()
                }
            } else {
                Toast.makeText(context, "Please fill in all fields", Toast.LENGTH_SHORT).show()
            }
        }) {
            Text("Continue")
        }

        Spacer(modifier = Modifier.height(8.dp))

        Button(onClick = { onLoginButtonClick() }) {
            Text("Back to Login")
        }
    }
}

@Composable
fun AddMovieScreen(
    context: Context,
    onAddMovieButtonClick: (String, String, String, String, String, String, String) -> Unit,
    onBackButtonClick: () -> Unit
) {
    var name by remember { mutableStateOf("") }
    var releaseDate by remember { mutableStateOf("") }
    var length by remember { mutableStateOf("") }
    var genre by remember { mutableStateOf("") }
    var director by remember { mutableStateOf("") }
    var mainActors by remember { mutableStateOf("") }
    var rate by remember { mutableStateOf("") }


    Column(
        modifier = Modifier.fillMaxSize(),
        verticalArrangement = Arrangement.Center,
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        Text("Add a Movie")

        Spacer(modifier = Modifier.height(16.dp))

        TextField(
            value = name,
            onValueChange = { name = it },
            label = { Text("Movie Name") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = releaseDate,
            onValueChange = { releaseDate = it },
            label = { Text("Year of Release") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = length,
            onValueChange = { length = it },
            label = { Text("Length (min)") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = genre,
            onValueChange = { genre = it },
            label = { Text("Genre") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = director,
            onValueChange = { director = it },
            label = { Text("Director") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(8.dp))
        TextField(
            value = mainActors,
            onValueChange = { mainActors = it },
            label = { Text("Main Actors") },
            modifier = Modifier.fillMaxWidth()
        )


        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = rate,
            onValueChange = { rate = it },
            label = { Text("Rate") },
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(16.dp))

        Row(
            horizontalArrangement = Arrangement.SpaceEvenly,
            modifier = Modifier.fillMaxWidth()
        ) {
            Button(onClick = { onBackButtonClick() }) {
                Text("Back")
            }

            Button(onClick = {
                //Tarkistaa, että kaikki on täytetty
                if (name.isNotBlank() && releaseDate.isNotBlank() && length.isNotBlank() &&
                    genre.isNotBlank() && director.isNotBlank() && rate.isNotBlank() &&
                    mainActors.isNotBlank()
                ) {
                    // Lähettää tiedot eteenpäin
                    onAddMovieButtonClick(name, releaseDate, length, genre, director, rate, mainActors)
                } else {
                    Toast.makeText(context, "Please fill in all fields", Toast.LENGTH_SHORT).show()
                }
            }) {
                Text("Add Movie")
            }
        }
    }
}

@Composable
fun ViewMoviesScreen() {
    val db = Database()
    val con = db.CreateConnection()

    val arr = db.GetData(con)

    LazyColumn {
        itemsIndexed(arr) {index, _ ->
            Card (
                modifier = Modifier.padding(8.dp),
            ) {
                Column (
                    modifier = Modifier
                        .padding(8.dp)
                        .fillMaxWidth(),
                    horizontalAlignment = Alignment.Start,
                    verticalArrangement = Arrangement.Center
                ) {
                    AsyncImage(
                        arr[index][8], null,
                        modifier = Modifier

                    )

                    Text(
                        text = "ID: " + arr[index][0].toString()
                    )

                    Text(
                        text = "NAME: " + arr[index][1].toString()
                    )

                    Text(
                        text = "LENGTH: " + arr[index][2].toString()
                    )

                    Text(
                        text = "RELEASE YEAR: " + arr[index][3].toString()
                    )

                    Text(
                        text = "GENRES: " + arr[index][4].toString()
                    )

                    Text(
                        text = "MAIN ACTORS: " + arr[index][5].toString()
                    )

                    Text(
                        text = "DIRECTOR: " + arr[index][6].toString()
                    )

                    Text(
                        text = "RATING: " + arr[index][7].toString()
                    )

                }
            }
        }
    }
}

//HUOM! TÄSSÄ KAIKKI MENEE STRING MUUTTUJINA EIKÄ INTTINÄ ESIM: JULKAISU VUOSI.

//onko password tarpeeksi vahva
private fun isPasswordValid(password: String): Boolean {
    if (password.length < 6) {
        return false
    }

    val containsUpperCase = password.any { it.isUpperCase() }
    if (!containsUpperCase) {
        return false
    }

    val specialCharacters = setOf('!', '#', '?', '&', '%', '$', '€', '£', '@')
    return password.any { specialCharacters.contains(it) }
}
