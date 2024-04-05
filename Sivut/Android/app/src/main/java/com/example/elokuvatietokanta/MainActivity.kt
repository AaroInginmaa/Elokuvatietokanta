package com.example.elokuvatietokanta

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.ComponentActivity

class MainActivity : ComponentActivity() {

    var vittu=0
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



        val username=findViewById<EditText>(R.id.usernameText)
        val password=findViewById<EditText>(R.id.passwordText)
        val email=findViewById<EditText>(R.id.emailText)



        chooseLoginButton.setOnClickListener {


            vittu=1
            setContentView(R.layout.login_screen)
            loginButtons()
        }

        choosesignUpButton.setOnClickListener {

            vittu=2
            setContentView(R.layout.signup_screen)
            loginButtons()

        }

        continueButton.setOnClickListener {

            if(vittu==1){
                if(username.text.isNotEmpty() && password.text.isNotEmpty()){
                    setContentView(R.layout.addorsearch)
                    menuButtons()
                }
                else{

                    Toast.makeText(this, "Täytä kaikki kohdat", Toast.LENGTH_SHORT).show()
                }
            }



            else{
                if(username.text.isNotEmpty() && password.text.isNotEmpty() && email.text.isNotEmpty()){
                    setContentView(R.layout.addorsearch)
                    menuButtons()
                }
                else{

                    Toast.makeText(this, "Täytä kaikki kohdat", Toast.LENGTH_SHORT).show()
                }
            }



        }
    }
}
