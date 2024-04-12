import tkinter as tk
from tkinter import *
import mysql.connector
from tkinter import ttk
from tkinter import messagebox
import re
import datetime

# Määritellään funktio käyttöliittymän aloitusnäkymälle
def loginRegisterPage():
    
    # Määritellään sisäinen funktio käyttöliittymän komponenttien luomiselle ja sijoittamiselle
    def contents():
        global registerButton, loginButton
        root.title("Elokuvatietokanta")
        root.geometry("500x500")
        
        # Luodaan rekisteröinti- ja kirjautumispainikkeet
        registerButton = tk.Button(text="Rekisteröidy", command=clickRegister)
        loginButton = tk.Button(text="Kirjaudu", command=clickLogin)
        
        # Sijoitetaan painikkeet keskelle ikkunaa
        registerButton.place(relx=.5, rely=.40, anchor=CENTER)
        loginButton.place(relx=.5, rely=.60, anchor=CENTER)
    
    # Käsittelee rekisteröintipainikkeen klikkauksen
    def clickRegister():
        listOfContents = [registerButton, loginButton]
        root.title("Rekisteröityminen")
        root.geometry("500x500")
        for i in listOfContents:
            i.destroy()
        RegisterPage()
    
    # Käsittelee kirjautumispainikkeen klikkauksen
    def clickLogin():
        listOfContents = [registerButton, loginButton]
        root.title("Kirjautuminen")
        root.geometry("500x500")
        for i in listOfContents:
            i.destroy()
        LogInPage()
    
    # Kutsutaan sisäistä funktiota käyttöliittymän alkuasetusten luomiseksi
    contents()

# Käyttäjän kirjautumissivu
def LogInPage():
    def contents():
        global nameOrEmailText_LogInPage, passwordText_LogInPage, nameOrEmailTextEntry_LogInPage, passwordTextEntry_LogInPage, loginButton_LoginPage, backButton_LoginPage
        
        # Luodaan tekstikentät ja painikkeet kirjautumissivulle
        nameOrEmailText_LogInPage = tk.Label(text="Nimi/Sähköposti")
        passwordText_LogInPage = tk.Label(text="Salasana")
        nameOrEmailTextEntry_LogInPage = tk.Entry()
        passwordTextEntry_LogInPage = tk.Entry()
        loginButton_LoginPage = tk.Button(text="Kirjaudu", command=clickLogin)
        backButton_LoginPage = tk.Button(text="Palaa", command=clickBack)
        
        # Sijoitetaan komponentit ikkunaan
        nameOrEmailText_LogInPage.place(relx=.5, rely=.1, anchor=CENTER)
        nameOrEmailTextEntry_LogInPage.place(relx=.5, rely=.2, anchor=CENTER)
        passwordText_LogInPage.place(relx=.5, rely=.3, anchor=CENTER)
        passwordTextEntry_LogInPage.place(relx=.5, rely=.4, anchor=CENTER)
        loginButton_LoginPage.place(relx=.5, rely=.5, anchor=CENTER)
        backButton_LoginPage.place(relx=.5, rely=.8, anchor=CENTER)
    
    # Käsittelee kirjautumispainikkeen klikkauksen
    def clickLogin():
        # Otetaan tekstikenttien arvot
        nameOrEmailEntryContent = nameOrEmailTextEntry_LogInPage.get()
        passwordEntryContent = passwordTextEntry_LogInPage.get()

        # Tarkistetaan, etteivät kentät ole tyhjiä
        if not nameOrEmailEntryContent or not passwordEntryContent:
            messagebox.showerror("Tyhjät kentät", "Täytä Nimi/Sähköposti ja Salasana kentät.")
            return

        # Yhdistetään tietokantaan ja suoritetaan kysely käyttäjän tietojen tarkistamiseksi
        db = mysql.connector.connect(host="localhost", user="root", database="elokuvatietokanta")
        cursor = db.cursor()

        sql = "SELECT * FROM kayttajat WHERE (nimi = %s OR sahkoposti = %s) AND salasana = %s"
        cursor.execute(sql, (nameOrEmailEntryContent, nameOrEmailEntryContent, passwordEntryContent))
        user = cursor.fetchone()

        if user:
            messagebox.showinfo("Kirjautuminen onnistui", "Tervetuloa!")
            MainWindow()
        else:
            messagebox.showerror("Virhe kirjautumisessa", "Virheelliset kirjautumistiedot. Yritä uudelleen.")

        cursor.close()
        db.close()
               
    # Käsittelee palaa-painikkeen klikkauksen
    def clickBack():
        listOfContents = [nameOrEmailText_LogInPage, passwordText_LogInPage, nameOrEmailTextEntry_LogInPage, passwordTextEntry_LogInPage, loginButton_LoginPage, backButton_LoginPage]
        root.title("Valitse")
        root.geometry("300x150")
        for i in listOfContents:
            i.destroy()  
        loginRegisterPage()
        
    # Kutsutaan sisäistä funktiota käyttöliittymän luomiseksi
    contents()

# Käyttäjän rekisteröintisivu
def RegisterPage():
    
    def contents():
        global nameTextEntry_RegisterPage, emailTextEntry_RegisterPage, passwordTextEntry_RegisterPage, nameText_RegisterPage, emailText_RegisterPage, passwordText_RegisterPage, registerButton_RegisterPage, backButton_RegisterPage
        
        # Luodaan tekstikentät, painikkeet ja niiden sijoittaminen rekisteröintisivulle
        nameText_RegisterPage = tk.Label(text="Nimi")
        emailText_RegisterPage = tk.Label(text="Sähköposti")
        passwordText_RegisterPage = tk.Label(text="Salasana")
        nameTextEntry_RegisterPage = tk.Entry()
        emailTextEntry_RegisterPage = tk.Entry()
        passwordTextEntry_RegisterPage = tk.Entry()
        registerButton_RegisterPage = tk.Button(text="Rekisteröidy", command=clickRegister)
        backButton_RegisterPage = tk.Button(text="Palaa", command=clickBack)

        # Sijoitetaan komponentit ikkunaan
        nameText_RegisterPage.place(relx=.5, rely=.15, anchor=CENTER)
        nameTextEntry_RegisterPage.place(relx=.5, rely=.20, anchor=CENTER)
        emailText_RegisterPage.place(relx=.5, rely=.25, anchor=CENTER)
        emailTextEntry_RegisterPage.place(relx=.5, rely=.30, anchor=CENTER)
        passwordText_RegisterPage.place(relx=.5, rely=.35, anchor=CENTER)
        passwordTextEntry_RegisterPage.place(relx=.5, rely=.40, anchor=CENTER)
        registerButton_RegisterPage.place(relx=.5, rely=.50, anchor=CENTER)
        backButton_RegisterPage.place(relx=.5, rely=.8, anchor=CENTER)
    
    # Käsittelee rekisteröintipainikkeen klikkauksen
    def clickRegister():
        global nameEntryContent, emailEntryContent, passwordEntryContent
        
        # Otetaan tekstikenttien arvot
        nameEntryContent = nameTextEntry_RegisterPage.get()
        emailEntryContent = emailTextEntry_RegisterPage.get()
        passwordEntryContent = passwordTextEntry_RegisterPage.get()
    
        # Tarkistetaan käyttäjänimi
        if len(nameEntryContent) < 4 or len(nameEntryContent) > 20:
            messagebox.showerror("Virheellinen käyttäjänimi", "Nimen täytyy olla 4 - 20 kirjainta.")
            return
        
        # Tarkistetaan sähköpostin muoto
        if not validate_email(emailEntryContent):
            messagebox.showerror("Virheellinen sähköposti", "Syötä kelvollinen sähköposti.")
            return
        
        # Tarkistetaan salasanan muoto
        if not validate_password(passwordEntryContent):
            messagebox.showerror("Virheellinen salasana", "Salasanan täytyy olla vähintään 6 merkkiä pitkä, sisältää vähintään yhden ison kirjaimen, ja yhden erikoismerkin (!#&%$€£@?).")
            return
    
        # Tarkistetaan onko käyttäjänimi tai sähköposti jo käytössä
        checkExistingUsers()
        
    # Tarkistaa onko käyttäjänimi tai sähköposti jo käytössä tietokannassa
    def checkExistingUsers():
        db = mysql.connector.connect(host="localhost", user="root", database="elokuvatietokanta")
        cursor = db.cursor()
        
        username = nameEntryContent
        email = emailEntryContent
        
        # Tarkistetaan käyttäjänimi
        cursor.execute('SELECT nimi FROM kayttajat WHERE nimi = %(username)s', {'username': username})
        checkUsername = cursor.fetchall()
        isTakenname = False
        for row in checkUsername:
            if(row[0] == username):
                isTakenname = True
        
        # Tarkistetaan sähköposti
        cursor.execute('SELECT sahkoposti FROM kayttajat WHERE sahkoposti = %(email)s', {'email': email})
        checkEmail = cursor.fetchall()
        isTakenemail = False
        for row in checkEmail:
            if(row[0] == email):
                isTakenemail = True
        
        # Jos käyttäjänimi ja sähköposti ovat vapaana, rekisteröidään käyttäjä
        if not isTakenemail and not isTakenname:
            messagebox.showinfo("Rekisteröityminen onnistui", "Käyttäjä rekisteröity onnistuneesti!")
            saveToDataBase()
            MainWindow()
        else:
            messagebox.showerror("Virheellinen käyttäjänimi tai sähköposti", "Käyttäjänimi tai sähköposti on jo käytössä.")
        
    # Tarkistaa sähköpostin muodon
    def validate_email(email):
        pattern = r'^[\w\.-]+@[\w\.-]+\.\w{2,}$'
        if re.match(pattern, email):
            return True
        else:
            return False
    
    # Tarkistaa salasanan muodon
    def validate_password(password):
        if len(password) < 6:
            return False
        has_uppercase = any(char.isupper() for char in password)
        has_special = any(char in "!#&%$€£@?" for char in password)
        if not has_uppercase or not has_special:
            return False
        return True
    
    # Tallentaa rekisteröityneen käyttäjän tiedot tietokantaan
    def saveToDataBase():
        db = mysql.connector.connect(host="localhost", user="root", database="elokuvatietokanta")
        cursor = db.cursor()
        sql = "INSERT INTO kayttajat (nimi, sahkoposti, salasana) VALUES (%s, %s, %s)"
        values = (nameEntryContent, emailEntryContent, passwordEntryContent)
        cursor.execute(sql, values)
        db.commit()
        db.close()
        
    # Käsittelee palaa-painikkeen klikkauksen
    def clickBack():
        listOfContents = [nameTextEntry_RegisterPage, emailTextEntry_RegisterPage, passwordTextEntry_RegisterPage, nameText_RegisterPage, emailText_RegisterPage, passwordText_RegisterPage, registerButton_RegisterPage, backButton_RegisterPage]
        root.title("Valitse")
        root.geometry("300x150")
        for i in listOfContents:
            i.destroy()
        loginRegisterPage()
             
    # Kutsutaan sisäistä funktiota käyttöliittymän luomiseksi
    contents()

# Pääikkuna, joka näyttää elokuvatiedot ja mahdollistaa elokuvien lisäämisen ja poistamisen
def MainWindow():
    
    # Yhdistetään tietokantaan ja määritellään tietokantakursori
    mydb = mysql.connector.connect(host="localhost", user="root", password="", database="elokuvatietokanta")
    mycursor = mydb.cursor()
    
    # Määritellään sisäinen funktio käyttöliittymän komponenttien luomiselle ja sijoittamiselle
    def contents():
        global combo, listbox
        
        # Luodaan combobox lajittelulle ja listbox elokuvien näyttämiseen
        combo = ttk.Combobox(values=["Nimi ↑", "Pituus ↑", "Julkaistu ↑", "Nimi ↓", "Pituus ↓", "Julkaistu ↓"])
        combo.place(x=50, y=50)
        
        # Luodaan listbox ja siihen liittyvä scrollbar
        monospaced_font = ("Courier", 12)
        listbox = Listbox(root, width=90, height=30, font=monospaced_font) 
        scrollbar = Scrollbar(root) 
        scrollbar.pack(side=RIGHT, fill=BOTH)    
        listbox.pack(side=RIGHT, fill=BOTH)     
        listbox.config(yscrollcommand=scrollbar.set)    
        scrollbar.config(command=listbox.yview) 

        # Lisää-nappi elokuvien hakemiseen tietokannasta
        hae_button = ttk.Button(text="Elokuvalista", command=Lista).place(x=70, y=45)

        # Lisää-nimi-kenttä ja -label
        lisaa_nimi_label = ttk.Label(text="Nimi").place(x=70, y=100)
        lisaa_nimi = ttk.Entry(width=30)
        lisaa_nimi.place(x=70, y=120)
        
        # Lisää-ohjaaja-kenttä ja -label
        lisaa_ohjaaja_label = ttk.Label(text="Ohjaaja").place(x=70, y=145)
        lisaa_ohjaaja = ttk.Entry(width=30)
        lisaa_ohjaaja.place(x=70, y=165)
        
        # Lisää-julkaisu-kenttä ja -label
        lisaa_julkaisu_label = ttk.Label(text="Julkaisuvuosi").place(x=70, y=190)
        lisaa_julkaisu = ttk.Entry(width=30)
        lisaa_julkaisu.place(x=70, y=210)
        
        # Lisää-pituus-kenttä ja -label
        lisaa_pituus_label = ttk.Label(text="Pituus").place(x=70, y=235)
        lisaa_pituus = ttk.Entry(width=30)
        lisaa_pituus.place(x=70, y=255)
        
        # Lisää-genre-kenttä ja -label
        lisaa_genre_label = ttk.Label(text="Genre").place(x=70, y=280)
        lisaa_genre = ttk.Entry(width=30)
        lisaa_genre.place(x=70, y=300)
        
        # Lisää-näyttelijä-kenttä ja -label
        lisaa_nayttelija_label = ttk.Label(text="Päänäyttelijä").place(x=70, y=325)
        lisaa_nayttelija = ttk.Entry(width=30)
        lisaa_nayttelija.place(x=70, y=345)
        
        # Lisää-arvostelu-kenttä ja -label
        lisaa_arvostelu_label = ttk.Label(text="Arvostelu").place(x=70, y=370)
        lisaa_arvostelu = ttk.Entry(width=30)
        lisaa_arvostelu.place(x=70, y=390)
        
        # Lisää-nappi elokuvien lisäämiseen tietokantaan
        lisaa_button = ttk.Button(text="Lisää elokuva", command=lambda: Lisataan_Dataa((str(lisaa_nimi.get()), lisaa_ohjaaja.get(), str(lisaa_julkaisu.get()), str(lisaa_pituus.get()), lisaa_genre.get(), lisaa_nayttelija.get(), str(lisaa_arvostelu.get()))))
        lisaa_button.place(x=70, y=420)

        # Poista-nappi elokuvien poistamiseen tietokannasta
        poista_button = ttk.Button(text="Poista elokuva", command=lambda: Poistetaan_Dataa((str(lisaa_nimi.get()), lisaa_ohjaaja.get(), str(lisaa_julkaisu.get()), str(lisaa_pituus.get()), lisaa_genre.get(), lisaa_nayttelija.get(), str(lisaa_arvostelu.get()))))
        poista_button.place(x=170, y=420)
    
    # Lisää elokuvan tiedot tietokantaan
    def Lisataan_Dataa(val):
        julkaisuvuosi = val
    
        # Tarkistetaan julkaisuvuosi
        if not validate_publication_year(julkaisuvuosi):
            messagebox.showerror("Virheellinen julkaisuvuosi", "Syötä kelvollinen julkaisuvuosi.")
            return
        
        # Yritetään lisätä elokuva tietokantaan
        if all(val) and validate_publication_year(julkaisuvuosi):
            try:
                sql = "INSERT INTO elokuvat (nimi, ohjaaja, julkaisuvuosi, kesto, genre, paa_nayttelija, arvostelu) VALUES (%s, %s, %s, %s, %s, %s, %s)"
                mycursor.execute(sql, val)
                mydb.commit()
                print(mycursor.rowcount, " elokuva lisätty.")
            except mysql.connector.errors.IntegrityError as e:
                print("Elokuva on jo tietokannassa")
                messagebox.showerror("Virhe!", "Elokuva on jo tietokannassa.")
            
    # Tarkistaa julkaisuvuoden kelvollisuuden
    def validate_publication_year(year):
        try:
            year = int(year)
            current_year = datetime.datetime.now().year
            if 1888 <= year <= current_year:
                return True
            else:
                return False
        except ValueError:
            return False
    
    # Hakee elokuvien tiedot tietokannasta ja listaa ne
    def Lista():
        # Tyhjentää listan
        listbox.delete(0, END)
        # Hakee elokuvien tiedot
        tiedot = Haetaan_Dataa()
        # Lisää tiedot listaan
        for row in tiedot:
            values = f"{row[0]:<45} {row[1]:<4} {row[2]}"
            listbox.insert(END, values) 
    
    # Hakee elokuvien tiedot tietokannasta
    def Haetaan_Dataa(): 
        # Tarkistaa lajittelun perusteella
        if combo.get()[-1:] == "V":
            thing = f" ORDER BY {combo.get()[:-2]} DESC"
        elif combo.get()[-1:] == "^":
            thing = f" ORDER BY {combo.get()[:-2]} ASC"
        else:
            thing = ""
        # Hakee tiedot tietokannasta
        mycursor.execute(f"SELECT * FROM elokuvat{thing}")
        myresult = mycursor.fetchall()
        return myresult
    
    # Poistaa elokuvan tiedot tietokannasta
    def Poistetaan_Dataa(val):
        try:
            sql = f'DELETE FROM elokuvat WHERE nimi="{val[0]}" and ohjaaja="{val[1]}" and julkaisuvuosi="{val[2]}" and kesto="{val[3]}" and genre="{val[4]}" and paa_nayttelija="{val(5)}" and arvostelu="{val[6]}"'
            mycursor.execute(sql)
            mydb.commit()
            print(mycursor.rowcount, " record(s) deleted")
        except mysql.connector.errors.IntegrityError as e:
            print("Elokuva ei ole tietokannassa")
            messagebox.showerror("Virhe!", "Elokuva ei ole tietokannassa.")

    # Pääohjelma
    contents()

# Luo uusi ikkuna
root = tk.Tk()
root.title("Valitse")
root.geometry("300x150")

# Käyttöliittymän aloitusnäkymä
loginRegisterPage()

# Käynnistetään pääsilmukka
root.mainloop()
