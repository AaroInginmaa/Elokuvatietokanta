package com.example.moviedb

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.*
import androidx.compose.material3.Button
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.unit.dp

class MainActivity : ComponentActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        // Set the content of the activity using Jetpack Compose
        setContent {
            // Pass the current context to the MovieDBApp composable function
            MovieDBApp(LocalContext.current)
        }
    }
}

// Main entry point of the application, controls the login and signup screens
@Composable
fun MovieDBApp(context: Context) {
    var isLoginScreen by remember { mutableStateOf(true) }
    var isSignedIn by remember { mutableStateOf(false) }
    var username by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }
    var email by remember { mutableStateOf("") }

    Surface {
        if (isSignedIn) {
            MainScreen(
                onAddMovieClick = {
                    Toast.makeText(context, "Add Movie clicked", Toast.LENGTH_SHORT).show()
                },
                onViewMoviesClick = {
                    Toast.makeText(context, "View Movie clicked", Toast.LENGTH_SHORT).show()
                }
            )
        } else {
            // Näytä joko login screen tai signup
            if (isLoginScreen) {
                LoginScreen(
                    onLoginButtonClick = { username, password ->
                        // Handle login button click
                        if (username.isNotEmpty() && password.isNotEmpty()) {
                            // Perform login action (e.g., authenticate user)
                            Toast.makeText(context, "Performing login for $username", Toast.LENGTH_SHORT).show()
                            isSignedIn = true
                        } else {
                            Toast.makeText(context, "Please fill in all fields", Toast.LENGTH_SHORT).show()
                        }
                    },
                    onSignUpButtonClick = { isLoginScreen = false } // Switch to SignUpScreen
                )
            } else {
                SignUpScreen(
                    onContinueButtonClick = { username, password, email ->
                        // Handle continue button click on SignUpScreen
                        if (username.isNotEmpty() && password.isNotEmpty() && email.isNotEmpty()) {
                            // Tähän tulis
                            Toast.makeText(context, "Performing sign up for $username with $email", Toast.LENGTH_SHORT).show()
                            isSignedIn = true
                        } else {
                            Toast.makeText(context, "Please fill in all fields", Toast.LENGTH_SHORT).show()
                        }
                    },
                    onLoginButtonClick = { isLoginScreen = true } // Switch back to LoginScreen
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

// Composable function for the Login screen UI
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

// Composable function for the SignUp screen UI
@Composable
fun SignUpScreen(
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

        Button(onClick = { onContinueButtonClick(username, password, email) }) {
            Text("Continue")
        }

        Spacer(modifier = Modifier.height(8.dp))

        Button(onClick = { onLoginButtonClick() }) {
            Text("Back to Login") //Takasin alkuun
        }
    }
}
