package com.example.elokuvatietokanta
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.ComponentActivity

class MainActivity : ComponentActivity() {


    //tällä katotaan että ollaanko login vai rekisteröinti ruudussa.
    var vittu=1


    
    private var isPressed = 1
    private var usernameValue: String = ""
    private var passwordValue: String = ""

    //kun ohjelma alkaa, mennään loginscreeniin
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.login_screen)
        loginButtons()
    }

    //hae ja lisää elokuva ruudun nappulat
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

    //login screenin napit
    private fun loginButtons() {

        //login screen tab nappi
        val chooseLoginButton = findViewById<Button>(R.id.loginButton)

        //rekisteröinti screen tab nappi
        val choosesignUpButton = findViewById<Button>(R.id.signUpButton)

        //kirjaudu/rekisteröidy nappi alhaalla
        val continueButton = findViewById<Button>(R.id.continueButton)

        //text fieldit kirjautumis/rekisteröinti ruuduissa
        val usernameEditText = findViewById<EditText>(R.id.usernameText)
        val passwordEditText = findViewById<EditText>(R.id.passwordText)
        val emailEditText = findViewById<EditText>(R.id.emailText)


        //jos painaa login tab nappia ylhäällä niin menee login ruutuun
        chooseLoginButton.setOnClickListener {
            //tämä settaa sen että ollaan login ruudussa (tiedetään että tarvitaan ottaa vain kahdesta text fieldistä eikä kolmesta
            isPressed = 1
            setContentView(R.layout.login_screen)
            loginButtons()
        }

        //jos painaa rekisteröidy tab nappia ylhäällä niin menee rekisteröidy ruutuun
        choosesignUpButton.setOnClickListener {
            //ollaan rekisteröinti ruudussa, otetaan kaikki kolme text fieldiä
            isPressed = 2
            setContentView(R.layout.signup_screen)
            loginButtons()
        }

        //login ja rekisteröinti nappi alhaalla joka checkaa onko kaikki kohdat täytetty ja onko salasana valid
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
                        Toast.makeText(this, "Salasana ei ole tarpeeksi vahva", Toast.LENGTH_SHORT).show()
                    }
                } else {
                    Toast.makeText(this, "Täytä kaikki kohdat", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }


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
}