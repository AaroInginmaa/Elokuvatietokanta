import tkinter as tk
from tkinter import *
import mysql.connector
from tkinter import ttk
from tkinter import messagebox
import re
import datetime


def loginRegisterPage():
    
    def contents():
        global registerButton,loginButton
        root.title("Elokuvatietokanta")
        root.geometry("500x500")
        
        registerButton = tk.Button(text="Register",command=clickRegister)
        loginButton = tk.Button(text="Log In",command=clickLogin)
        
        registerButton.place(relx=.5,rely=.40,anchor=CENTER)
        loginButton.place(relx=.5,rely=.60,anchor=CENTER)
    
    def clickRegister():
        listOfContents = [registerButton,loginButton]
        root.title("Rekisteröityminen")
        root.geometry("500x500")
        for i in listOfContents:
            i.destroy()
        RegisterPage()
    
    def clickLogin():
        listOfContents = [registerButton,loginButton]
        root.title("Kirjautuminen")
        root.geometry("500x500")
        for i in listOfContents:
            i.destroy()
            
        LogInPage()
    
    contents()
    
def LogInPage():
    def contents():
        global nameOrEmailText_LogInPage, passwordText_LogInPage, nameOrEmailTextEntry_LogInPage, passwordTextEntry_LogInPage, loginButton_LoginPage,backButton_LoginPage
        
        #Texts
        nameOrEmailText_LogInPage = tk.Label(text="Nimi/Sähköposti")
        passwordText_LogInPage = tk.Label(text="Salasana")
        
        #Entrys
        nameOrEmailTextEntry_LogInPage = tk.Entry()
        passwordTextEntry_LogInPage = tk.Entry()
        
        #Buttons
        loginButton_LoginPage = tk.Button(text="Kirjaudu",command=clickLogin)
        backButton_LoginPage = tk.Button(text="Palaa",command=clickBack)
        
        #Placements
        nameOrEmailText_LogInPage.place(relx=.5,rely=.1,anchor=CENTER)
        nameOrEmailTextEntry_LogInPage.place(relx=.5,rely=.2,anchor=CENTER)
        passwordText_LogInPage.place(relx=.5,rely=.3,anchor=CENTER)
        passwordTextEntry_LogInPage.place(relx=.5,rely=.4,anchor=CENTER)
        loginButton_LoginPage.place(relx=.5,rely=.5,anchor=CENTER)
        backButton_LoginPage.place(relx=.5,rely=.8,anchor=CENTER)
    
    def clickLogin():
        # otetaan valuet input fieldeistä
        nameOrEmailEntryContent = nameOrEmailTextEntry_LogInPage.get()
        passwordEntryContent = passwordTextEntry_LogInPage.get()

        # varmistetaan ettei ne oo tyhjiä
        if not nameOrEmailEntryContent or not passwordEntryContent:
            messagebox.showerror("Tyhjät kentät", "Täytä Nimi/Sähköposti ja Salasana kentät.")
            return

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
               
    def clickBack():
        listOfContents = [nameOrEmailText_LogInPage, passwordText_LogInPage, nameOrEmailTextEntry_LogInPage, passwordTextEntry_LogInPage, loginButton_LoginPage,backButton_LoginPage]
        root.title("Valitse")
        root.geometry("300x150")
        for i in listOfContents:
            i.destroy()  
        loginRegisterPage()
        
    contents()

def RegisterPage():
    
    def contents():
        
        global nameTextEntry_RegisterPage,emailTextEntry_RegisterPage,passwordTextEntry_RegisterPage,nameText_RegisterPage,emailText_RegisterPage,passwordText_RegisterPage,registerButton_RegisterPage,backButton_RegisterPage
        
        #Texts
        nameText_RegisterPage = tk.Label(text="Nimi")
        emailText_RegisterPage = tk.Label(text="Sähköposti")
        passwordText_RegisterPage = tk.Label(text="Salasana")
    
        #Entrys
        nameTextEntry_RegisterPage = tk.Entry()
        emailTextEntry_RegisterPage = tk.Entry()
        passwordTextEntry_RegisterPage = tk.Entry()
        
        #Buttons
        registerButton_RegisterPage = tk.Button(text="Rekisteröidy", command=clickRegister,)
        backButton_RegisterPage = tk.Button(text="Palaa",command=clickBack)

        #Placements
        nameText_RegisterPage.place(relx=.5, rely=.15, anchor=CENTER)
        nameTextEntry_RegisterPage.place(relx=.5, rely=.20, anchor=CENTER)
        emailText_RegisterPage.place(relx=.5, rely=.25, anchor=CENTER)
        emailTextEntry_RegisterPage.place(relx=.5, rely=.30, anchor=CENTER)
        passwordText_RegisterPage.place(relx=.5, rely=.35, anchor=CENTER)
        passwordTextEntry_RegisterPage.place(relx=.5, rely=.40, anchor=CENTER)
        registerButton_RegisterPage.place(relx=.5, rely=.50, anchor=CENTER)
        backButton_RegisterPage.place(relx=.5,rely=.8,anchor=CENTER)
    
    def clickRegister():
        
        global nameEntryContent,emailEntryContent,passwordEntryContent
        
        # otetaan input fieldien arvot
        nameEntryContent = nameTextEntry_RegisterPage.get()
        emailEntryContent = emailTextEntry_RegisterPage.get()
        passwordEntryContent = passwordTextEntry_RegisterPage.get()
    
        # käyttäjänimen tarkistus
        if len(nameEntryContent) < 4 or len(nameEntryContent) > 20:
            messagebox.showerror("Virheellinen käyttäjänimi", "Nimen täytyy olla 4 - 20 kirjainta.")
            return
        
        # kutsutaan sähköpostin formatin tarkistus
        if not validate_email(emailEntryContent):
            messagebox.showerror("Virheellinen sähköposti", "Syötä kelvollinen sähköposti.")
            return
        # kutsutaan salasanan tarkistus
        if not validate_password(passwordEntryContent):
            messagebox.showerror("Virheellinen salasana", "Salasanan täytyy olla vähintään 6 kirjaiminen, sisältää vähintään yksi isokirjain, ja yksi erikoismerkki (!#&%$€£@?).")
            return
    
        checkExistingUsers()
        
    def checkExistingUsers():
        
        db = mysql.connector.connect(host="localhost",user="root",database="elokuvatietokanta")
        mycursor = db.cursor()
        
        username = nameEntryContent
        email=emailEntryContent
        mycursor.execute('SELECT nimi FROM kayttajat WHERE nimi = %(username)s', { 'username' : username })
        checkUsername = mycursor.fetchall()
        isTakenname=False
        for row in checkUsername:
            if(row[0]==username):
                isTakenname=True
        
        mycursor.execute('SELECT sahkoposti FROM kayttajat WHERE sahkoposti = %(username)s', { 'username' : email })
        checkEmail=mycursor.fetchall()
        isTakenemail=False
        for row in checkEmail:
            if(row[0]==email):
                isTakenemail=True
        

        if isTakenemail == False and isTakenname==False:
            print('Käyttäjänimi ja sähköposti ovat käytettävissä')
            messagebox.showinfo("Rekisteröityminen onnistoi", "Käyttäjä rekisteröity onnistuneesti!")
            saveToDataBase()
            MainWindow()
        else:
            print('Sähköposti tai käyttäjänimi on jo käytössä')
        
    # sähköpostin formatin tarkistus
    def validate_email(email):
        # Format, jolla tarkistetaan emailin kelvollisuus
        pattern = r'^[\w\.-]+@[\w\.-]+\.\w{2,}$'
        
        # re.match() tarkistaa onko format oikea
        if re.match(pattern, email):
            return True
        else:
            return False
    
    # salasanan tarkistus
    def validate_password(password):
        if len(password) < 6:
            return False
        
        has_uppercase = any(char.isupper() for char in password)
        has_special = any(char in "!#&%$€£@?" for char in password)
        
        if not has_uppercase or not has_special:
            return False
        
        return True
    
    def saveToDataBase():
        db = mysql.connector.connect(host="localhost",user="root",database="elokuvatietokanta")
        cursor = db.cursor()
        sql = "INSERT INTO kayttajat (nimi,sahkoposti,salasana) VALUES (%s,%s,%s)"
        values = (nameEntryContent,emailEntryContent,passwordEntryContent)
        
        cursor.execute(sql,values)
        db.commit()
        db.close()
        
    def clickBack():
        listOfContents = [ nameTextEntry_RegisterPage,emailTextEntry_RegisterPage,passwordTextEntry_RegisterPage,nameText_RegisterPage,emailText_RegisterPage,passwordText_RegisterPage,registerButton_RegisterPage,backButton_RegisterPage]
        root.title("Valitse")
        root.geometry("300x150")
         
        for i in listOfContents:
            i.destroy()
        
        loginRegisterPage()
             
    contents()

def MainWindow():
    
    mydb = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database="elokuvatietokanta"
    )
    mycursor = mydb.cursor()
    
    def contents():
        global combo, listbox
        
        combo = ttk.Combobox(
        values=["Nimi ^","Pituus ^","Julkaistu ^",
                "Nimi V","Pituus V","Julkaistu V"],
        postcommand=dropdown_opened 
        )
        combo.place(x=50, y=50)
        # Luodaan fontti jota käytetään
        monospaced_font = ("Courier", 12)
        # Luodaan lista ja sille scrollbar
        listbox = Listbox(root, width=90, height=30, font=monospaced_font) 
        scrollbar = Scrollbar(root) 
        scrollbar.pack(side=RIGHT, fill=BOTH)    
        listbox.pack(side=RIGHT, fill=BOTH)     
        listbox.config(yscrollcommand=scrollbar.set)    
        scrollbar.config(command=listbox.yview) 

        # Hae data nappi luonti
        hae_button = ttk.Button(text="Hae Elokuva", command=lambda: Lista()).place(x=70, y=45)

        # Lisaa nimi label ja input box
        lisaa_nimi_label =ttk.Label(text="Nimi").place(x=70,y=100)
        lisaa_nimi = ttk.Entry(width=30)
        lisaa_nimi.place(x=70,y=120)
        
        # Lisaa ohjaaja label ja input box
        lisaa_ohjaaja_label =ttk.Label(text="Ohjaaja").place(x=70,y=145)
        lisaa_ohjaaja = ttk.Entry(width=30)
        lisaa_ohjaaja.place(x=70,y=165)
        
        # Lisaa Julkaisu label ja input box
        lisaa_julkaisu_label =ttk.Label(text="Julkaisuvuosi").place(x=70,y=190)
        lisaa_julkaisu = ttk.Entry(width=30)
        lisaa_julkaisu.place(x=70,y=210)
        
        # Lisaa pituus label ja input box
        lisaa_pituus_label =ttk.Label(text="Pituus").place(x=70,y=235)
        lisaa_pituus = ttk.Entry(width=30)
        lisaa_pituus.place(x=70,y=255)
        
        # Lisaa genre label ja input box
        lisaa_genre_label =ttk.Label(text="Genre").place(x=70,y=280)
        lisaa_genre = ttk.Entry(width=30)
        lisaa_genre.place(x=70,y=300)
        
        # Lisaa nayttelija label ja input box
        lisaa_nayttelija_label =ttk.Label(text="Päänäyttelijä").place(x=70,y=325)
        lisaa_nayttelija = ttk.Entry(width=30)
        lisaa_nayttelija.place(x=70,y=345)
        
        # Lisaa arvostelu label ja input box
        lisaa_arvostelu_label =ttk.Label(text="Arvostelu").place(x=70,y=370)
        lisaa_arvostelu = ttk.Entry(width=30)
        lisaa_arvostelu.place(x=70,y=390)
        lisaa_button = ttk.Button(text="Lisää elokuva", command=lambda: Lisataan_Dataa((str(lisaa_nimi.get()),lisaa_ohjaaja.get(),str(lisaa_julkaisu.get()),str(lisaa_pituus.get()),lisaa_genre.get(),lisaa_nayttelija.get(),str(lisaa_arvostelu.get()))))
        lisaa_button.place(x=70, y=420)

        poista_button = ttk.Button(text="Poista elokuva", command=lambda: Poistetaan_Dataa((str(lisaa_nimi.get()),lisaa_ohjaaja.get(),str(lisaa_julkaisu.get()),str(lisaa_pituus.get()),lisaa_genre.get(),lisaa_nayttelija.get(),str(lisaa_arvostelu.get()))))
        poista_button.place(x=170, y=420)
        
    def Lisataan_Dataa(val):
        nimi, ohjaaja, julkaisuvuosi, kesto, genre, paa_nayttelija, arvostelu = val
    
    # Validate the publication year
        if not validate_publication_year(julkaisuvuosi):
            messagebox.showerror("Virheellinen julkaisuvuosi", "Syötä kelvollinen julkaisuvuosi.")
            return
        # Funktio jolle annetaan nimi, pituus ja julkaisu ja se heittää ne databasee 
        # ja jos tulee error ilmoittaa siitä käyttäjälle
        if all(val) and validate_publication_year(julkaisuvuosi):
            try:
                sql = "INSERT INTO elokuvat (nimi, ohjaaja, julkaisuvuosi, kesto, genre, paa_nayttelija, arvostelu) VALUES (%s, %s, %s, %s, %s, %s, %s)"
                mycursor.execute(sql, val)
                mydb.commit()
                print(mycursor.rowcount, " elokuva syötetty.")
            except mysql.connector.errors.IntegrityError as e:
                print("Elokuva on jo tietokannassa")
                messagebox.showerror("Virhe!", "Some records were not inserted due to duplicates in the database.")        
        else:
            print(f"Jotain on vikana seuraavissa\n{val[0]}\n{val[1]}\n{val[2]}")
            
            
    def validate_publication_year(year):
        try:
            year = int(year)
            current_year = datetime.datetime.now().year
            # järkevä julkaisuvuosi
            if 1888 <= year <= current_year:
                return True
            else:
                return False
        except ValueError:
            return False
    
    
    def Haetaan_Dataa(): 
        # Tarkistetaan dropdown menun value
        if combo.get()[-1:] == "V":
            thing = f" ORDER BY {combo.get()[:-2]} DESC"
            print(f"{thing}")
        elif combo.get()[-1:] == "^":
            thing = f" ORDER BY {combo.get()[:-2]} ASC"
            print(f"{thing}")
        else:
            thing = ""
        # Haetaan databasesta tiedot muuttujan thing mukaisella ehdolla
        mycursor.execute(f"SELECT * FROM elokuvat{thing}")
        myresult = mycursor.fetchall()
        i = 0
        # Näytetään debug mielessä ne myös concoliin
        while i < len(myresult):
            print(f"{myresult[i][0]:<45} {myresult[i][1]:<4} {myresult[i][2]}")
            i = i + 1
        # Palautetaan taulukko
        return myresult

    def Poistetaan_Dataa(val):
        # Poistaminen ole tehty
        try:
            sql = f" DELETE FROM elokuvat WHERE {val}"
            mycursor.execute(sql)
            mydb.commit()
            print(mycursor.rowcount, " elokuva poistettu.")
        except mysql.connector.errors.IntegrityError as e:
            print("Ei ole olemassa")
            messagebox.showerror("Virhe", "Elokuvaa ei ole olemassa.")

    def dropdown_opened():
        print("Drop-down menu on avattu!")
        print(f"{combo.get()}")
        
    def Lista():
        # Tyhjätään lista varulta
        listbox.delete(0, END)
        # Haetaan datat
        tiedot = Haetaan_Dataa()
        # Lisätään ne listaan jossa ne näytetään loppujen lopuksi
        for row in tiedot:
            values = f"{row[0]:<45} {row[1]:<4} {row[2]}"
            listbox.insert(END, values) 
    # Luodaan dropdown menu jolla valitaan lajittelu järjestys

    contents()

#Window
root = tk.Tk()
root.title("Valitse")
root.geometry("300x150")
root.resizable(width=False, height=False)
root.attributes('-topmost', True)

#First window
loginRegisterPage()

root.mainloop()