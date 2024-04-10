package com.example.elokuvatietokanta
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.ComponentActivity

class MainActivity : ComponentActivity() {

    private var isPressed = 1
    private var usernameValue: String = ""
    private var passwordValue: String = ""

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.login_screen)
        loginButtons()
    }

    private fun menuButtons() {
        val searchButton = findViewById<Button>(R.id.searchButton)
        val addButton = findViewById<Button>(R.id.addButton)

        searchButton.setOnClickListener {
            setContentView(R.layout.searchmovie)
        }
        addButton.setOnClickListener {
            setContentView(R.layout.addmovie)
        }
    }

    private fun loginButtons() {
        val chooseLoginButton = findViewById<Button>(R.id.loginButton)
        val choosesignUpButton = findViewById<Button>(R.id.signUpButton)
        val continueButton = findViewById<Button>(R.id.continueButton)

        val usernameEditText = findViewById<EditText>(R.id.usernameText)
        val passwordEditText = findViewById<EditText>(R.id.passwordText)
        val emailEditText = findViewById<EditText>(R.id.emailText)

        chooseLoginButton.setOnClickListener {
            isPressed = 1
            setContentView(R.layout.login_screen)
            loginButtons()
        }

        choosesignUpButton.setOnClickListener {
            isPressed = 2
            setContentView(R.layout.signup_screen)
            loginButtons()
        }

        continueButton.setOnClickListener {
            if (isPressed == 1 || isPressed == 2) {
                if (usernameEditText.text.isNotEmpty() && passwordEditText.text.isNotEmpty() && (isPressed == 1 || emailEditText.text.isNotEmpty())) {
                    val passwordStr = passwordEditText.text.toString()
                    if (isPasswordValid(passwordStr)) {
                        usernameValue = usernameEditText.text.toString()
                        passwordValue = passwordStr
                        setContentView(R.layout.addorsearch)
                        menuButtons()
                    } else {
                        Toast.makeText(this, "Password is not valid", Toast.LENGTH_SHORT).show()
                    }
                } else {
                    Toast.makeText(this, "Fill in all required fields", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

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
}