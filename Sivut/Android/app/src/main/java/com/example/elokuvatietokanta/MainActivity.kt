package com.example.elokuvatietokanta

import android.os.Bundle
import android.widget.Button
import androidx.activity.ComponentActivity

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.login_screen)
        buttons()
    }
    private fun buttons(){
        val loginButton = findViewById<Button>(R.id.loginButton)
        val signUpButton = findViewById<Button>(R.id.signUpButton)

        loginButton.setOnClickListener {
            setContentView(R.layout.login_screen)
            buttons()
        }

        signUpButton.setOnClickListener {
            setContentView(R.layout.signup_screen)
            buttons()
        }
    }
}
