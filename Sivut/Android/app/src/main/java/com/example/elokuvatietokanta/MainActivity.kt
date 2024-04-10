package com.example.elokuvatietokanta

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.ComponentActivity

class MainActivity : ComponentActivity() {

    var vittu=1
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.login_screen)
        loginButtons()
    }
    private fun menuButtons(){
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

        val username = findViewById<EditText>(R.id.usernameText)
        val password = findViewById<EditText>(R.id.passwordText)
        val email = findViewById<EditText>(R.id.emailText)

        chooseLoginButton.setOnClickListener {
            vittu = 1
            setContentView(R.layout.login_screen)
            loginButtons()
        }

        choosesignUpButton.setOnClickListener {
            vittu = 2
            setContentView(R.layout.signup_screen)
            loginButtons()
        }

        continueButton.setOnClickListener {
            if (vittu == 1 || vittu == 2) {
                // Check if username, password, and email (if applicable) are not empty
                if (username.text.isNotEmpty() && password.text.isNotEmpty() && (vittu == 1 || email.text.isNotEmpty())) {
                    // Password validation
                    val passwordStr = password.text.toString()
                    if (isPasswordValid(passwordStr)) {
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
        // Password must be at least 6 characters long
        if (password.length < 6) {
            return false
        }

        // Check for at least 1 uppercase character
        val containsUpperCase = password.any { it.isUpperCase() }
        if (!containsUpperCase) {
            return false
        }

        // Check for at least 1 special character from specified set
        val specialCharacters = setOf('!', '#', '?', '&', '%', '$', '€', '£', '@')
        val containsSpecialChar = password.any { specialCharacters.contains(it) }
        if (!containsSpecialChar) {
            return false
        }

        return true
    }
}
