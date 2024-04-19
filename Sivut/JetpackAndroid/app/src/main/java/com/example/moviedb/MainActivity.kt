package com.example.moviedb

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
        setContent {
            MovieDBApp()
        }
    }
}

@Composable
fun MovieDBApp() {
    var isLoginScreen by remember { mutableStateOf(true) }
    var username by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }
    var email by remember { mutableStateOf("") }

    Surface {
        if (isLoginScreen) {
            LoginScreen(
                onLoginButtonClick = { username, password ->
                    // Handle login logic here
                    /*if (username.isNotEmpty() && password.isNotEmpty()) {
                        // Perform login action
                        Toast.makeText(LocalContext.current, "Performing login for $username",
                            Toast.LENGTH_SHORT
                        ).show()
                    } else {
                        Toast.makeText(LocalContext.current, "Please fill in all fields",
                            Toast.LENGTH_SHORT
                        ).show()
                    }*/
                },
                onSignUpButtonClick = { isLoginScreen = false }
            )
        } else {
            SignUpScreen(
                onContinueButtonClick = { username, password, email ->
                    // Handle signup logic here
                    /*if (username.isNotEmpty() && password.isNotEmpty() && email.isNotEmpty()) {
                        // Perform signup action
                        Toast.makeText(
                            LocalContext.current,
                            "Performing sign up for $username with $email",
                            Toast.LENGTH_SHORT
                        ).show()
                    } else {
                        Toast.makeText(
                            LocalContext.current,
                            "Please fill in all fields",
                            Toast.LENGTH_SHORT
                        ).show()
                    }*/
                },
                onLoginButtonClick = { isLoginScreen = true }
            )
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
            Text("Back to Login")
        }
    }
}