package com.example.elokuvatietokanta

import android.os.Bundle
import android.widget.Button
import androidx.activity.ComponentActivity

class MainActivity : ComponentActivity() {
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
    private fun loginButtons(){
        val chooseLoginButton = findViewById<Button>(R.id.loginButton)
        val choosesignUpButton = findViewById<Button>(R.id.signUpButton)
        val continueButton = findViewById<Button>(R.id.continueButton)

        chooseLoginButton.setOnClickListener {
            setContentView(R.layout.login_screen)
            loginButtons()
        }

        choosesignUpButton.setOnClickListener {
            setContentView(R.layout.signup_screen)
            loginButtons()
        }

        continueButton.setOnClickListener {
            setContentView(R.layout.addorsearch)
        }
    }
}
