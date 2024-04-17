import tkinter as tk
from tkinter import *
import mysql.connector
from tkinter import ttk
from tkinter import messagebox
import re
import datetime

def loginRegisterPage():
    
    def contents():
        global registerButton, loginButton
        root.title("Elokuvatietokanta")
        root.geometry("500x500")
        
        registerButton = tk.Button(text="Rekisteröidy", command=clickRegister)
        loginButton = tk.Button(text="Kirjaudu", command=clickLogin)
        
        registerButton.place(relx=.5, rely=.40, anchor=CENTER)
        loginButton.place(relx=.5, rely=.60, anchor=CENTER)
    
    def clickRegister():
        buttons = [registerButton, loginButton]
        root.title("Rekisteröityminen")
        root.geometry("500x500")
        for i in buttons:
            i.destroy()
        registerPage()
    
    def clickLogin():
        buttons = [registerButton, loginButton]
        root.title("Kirjautuminen")
        root.geometry("500x500")
        for i in buttons:
            i.destroy()
        logInPage()
    
    contents()

def logInPage():
    def contents():
        global loginNameLabel, loginPWordLabel, loginName, loginPWord, loginButton, backButton
        
        loginNameLabel = tk.Label(text="Nimi/Sähköposti")
        loginPWordLabel = tk.Label(text="Salasana")
        loginName = tk.Entry()
        loginPWord = tk.Entry()
        loginButton = tk.Button(text="Kirjaudu", command=clickLogin)
        backButton = tk.Button(text="Palaa", command=clickBack)
        
        loginNameLabel.place(relx=.5, rely=.1, anchor=CENTER)
        loginName.place(relx=.5, rely=.2, anchor=CENTER)
        loginPWordLabel.place(relx=.5, rely=.3, anchor=CENTER)
        loginPWord.place(relx=.5, rely=.4, anchor=CENTER)
        loginButton.place(relx=.5, rely=.5, anchor=CENTER)
        backButton.place(relx=.5, rely=.8, anchor=CENTER)
    
    def clickLogin():
        nameEntry = loginName.get()
        pWordCheck = loginPWord.get()

        if not nameEntry or not pWordCheck:
            messagebox.showerror("Tyhjät kentät", "Täytä Nimi/Sähköposti ja Salasana kentät.")
            return

        db = mysql.connector.connect(host="localhost", user="root", database="elokuvatietokanta")
        cursor = db.cursor()

        sql = "SELECT * FROM kayttajat WHERE (nimi = %s OR sahkoposti = %s) AND salasana = %s"
        cursor.execute(sql, (nameEntry, nameEntry, pWordCheck))
        user = cursor.fetchone()

        if user:
            messagebox.showinfo("Kirjautuminen onnistui", "Tervetuloa!")
            mainWindow()
        else:
            messagebox.showerror("Virhe kirjautumisessa", "Virheelliset kirjautumistiedot. Yritä uudelleen.")

        cursor.close()
        db.close()
               
    def clickBack():
        loginComponents = [loginNameLabel, loginPWordLabel, loginName, loginPWord, loginButton, backButton]
        root.title("Valitse")
        root.geometry("300x150")
        for i in loginComponents:
            i.destroy()  
        loginRegisterPage()
        
    contents()

def registerPage():
    
    def contents():
        global registerName, registerEmail, registerPWord, registerNameLabel, registerEmailLabel, registerPasswordLabel, registerButton, backButton
        
        registerNameLabel = tk.Label(text="Nimi")
        registerEmailLabel = tk.Label(text="Sähköposti")
        registerPasswordLabel = tk.Label(text="Salasana")
        registerName = tk.Entry()
        registerEmail = tk.Entry()
        registerPWord = tk.Entry()
        registerButton = tk.Button(text="Rekisteröidy", command=clickRegister)
        backButton = tk.Button(text="Palaa", command=clickBack)

        registerNameLabel.place(relx=.5, rely=.15, anchor=CENTER)
        registerName.place(relx=.5, rely=.20, anchor=CENTER)
        registerEmailLabel.place(relx=.5, rely=.25, anchor=CENTER)
        registerEmail.place(relx=.5, rely=.30, anchor=CENTER)
        registerPasswordLabel.place(relx=.5, rely=.35, anchor=CENTER)
        registerPWord.place(relx=.5, rely=.40, anchor=CENTER)
        registerButton.place(relx=.5, rely=.50, anchor=CENTER)
        backButton.place(relx=.5, rely=.8, anchor=CENTER)
    
    def clickRegister():
        global nameCheck, emailCheck, pWordCheck
        
        nameCheck = registerName.get()
        emailCheck = registerEmail.get()
        pWordCheck = registerPWord.get()

        if len(nameCheck) < 4 or len(nameCheck) > 20:
            messagebox.showerror("Virheellinen käyttäjänimi", "Nimen täytyy olla 4 - 20 kirjainta.")
            return

        if not validateEmail(emailCheck):
            messagebox.showerror("Virheellinen sähköposti", "Syötä kelvollinen sähköposti.")
            return

        if not validatePassword(pWordCheck):
            messagebox.showerror("Virheellinen salasana", "Salasanan täytyy olla vähintään 6 merkkiä pitkä, sisältää vähintään yhden ison kirjaimen, ja yhden erikoismerkin (!#&%$€£@?).")
            return

        checkExistingUsers()

    def checkExistingUsers():
        db = mysql.connector.connect(host="localhost", user="root", database="elokuvatietokanta")
        cursor = db.cursor()

        username = nameCheck
        email = emailCheck

        cursor.execute('SELECT nimi FROM kayttajat WHERE nimi = %(username)s', {'username': username})
        checkUsername = cursor.fetchall()
        isTakenname = False
        for row in checkUsername:
            if(row[0] == username):
                isTakenname = True

        cursor.execute('SELECT sahkoposti FROM kayttajat WHERE sahkoposti = %(email)s', {'email': email})
        checkEmail = cursor.fetchall()
        isEmailTaken = False
        for row in checkEmail:
            if(row[0] == email):
                isEmailTaken = True

        if not isEmailTaken and not isTakenname:
            messagebox.showinfo("Rekisteröityminen onnistui", "Käyttäjä rekisteröity onnistuneesti!")
            saveToDataBase()
            mainWindow()
        else:
            messagebox.showerror("Virheellinen käyttäjänimi tai sähköposti", "Käyttäjänimi tai sähköposti on jo käytössä.")

    def validateEmail(email):
        emailFormat = r'^[\w\.-]+@[\w\.-]+\.\w{2,}$'
        if re.match(emailFormat, email):
            return True
        else:
            return False

    def validatePassword(password):
        if len(password) < 6:
            return False
        hasUpper = any(char.isupper() for char in password)
        hasSpecial = any(char in "!#&%$€£@?" for char in password)
        if not hasUpper or not hasSpecial:
            return False
        return True

    def saveToDataBase():
        db = mysql.connector.connect(host="localhost", user="root", database="elokuvatietokanta")
        cursor = db.cursor()
        sql = "INSERT INTO kayttajat (nimi, sahkoposti, salasana) VALUES (%s, %s, %s)"
        values = (nameCheck, emailCheck, pWordCheck)
        cursor.execute(sql, values)
        db.commit()
        db.close()

    def clickBack():
        registerComponents = [registerName, registerEmail, registerPWord, registerNameLabel, registerEmailLabel, registerPasswordLabel, registerButton, backButton]
        root.title("Valitse")
        root.geometry("300x150")
        for i in registerComponents:
            i.destroy()
        loginRegisterPage()

    contents()

def mainWindow():
    
    mydb = mysql.connector.connect(host="localhost", user="root", password="", database="elokuvatietokanta")
    mycursor = mydb.cursor()
    
    def contents():
        global combo, listbox
        
        combo = ttk.Combobox(values=["Nimi ↑", "Pituus ↑", "Julkaistu ↑", "Nimi ↓", "Pituus ↓", "Julkaistu ↓"])
        combo.place(x=50, y=50)
        
        monospaced_font = ("Courier", 12)
        listbox = Listbox(root, width=90, height=30, font=monospaced_font) 
        scrollbar = Scrollbar(root) 
        scrollbar.pack(side=RIGHT, fill=BOTH)    
        listbox.pack(side=RIGHT, fill=BOTH)     
        listbox.config(yscrollcommand=scrollbar.set)    
        scrollbar.config(command=listbox.yview) 

        searchButton = ttk.Button(text="Elokuvalista", command=movieList).place(x=70, y=45)

        nameLabel = ttk.Label(text="Nimi").place(x=70, y=100)
        nameAdd = ttk.Entry(width=30)
        nameAdd.place(x=70, y=120)
        
        directorLabel = ttk.Label(text="Ohjaaja").place(x=70, y=145)
        directorAdd = ttk.Entry(width=30)
        directorAdd.place(x=70, y=165)
        
        publishLabel = ttk.Label(text="Julkaisuvuosi").place(x=70, y=190)
        publishAdd = ttk.Entry(width=30)
        publishAdd.place(x=70, y=210)
        
        lenghtLabel = ttk.Label(text="Pituus").place(x=70, y=235)
        lenghtAdd = ttk.Entry(width=30)
        lenghtAdd.place(x=70, y=255)
        
        genreLabel = ttk.Label(text="Genre").place(x=70, y=280)
        genreAdd = ttk.Entry(width=30)
        genreAdd.place(x=70, y=300)
        
        actorLabel = ttk.Label(text="Päänäyttelijä").place(x=70, y=325)
        actorAdd = ttk.Entry(width=30)
        actorAdd.place(x=70, y=345)
        
        reviewLabel = ttk.Label(text="Arvostelu").place(x=70, y=370)
        reviewAdd = ttk.Entry(width=30)
        reviewAdd.place(x=70, y=390)
        
        addButton = ttk.Button(text="Lisää elokuva", command=lambda: addData((str(nameAdd.get()), directorAdd.get(), str(publishAdd.get()), str(lenghtAdd.get()), genreAdd.get(), actorAdd.get(), str(reviewAdd.get()))))
        addButton.place(x=70, y=420)

        deleteButton = ttk.Button(text="Poista elokuva", command=lambda: deleteData((str(nameAdd.get()), directorAdd.get(), str(publishAdd.get()), str(lenghtAdd.get()), genreAdd.get(), actorAdd.get(), str(reviewAdd.get()))))
        deleteButton.place(x=170, y=420)
    
    def addData(val):
        publish = val[2]
    
        if not validateYear(publish):
            messagebox.showerror("Virheellinen publish", "Syötä kelvollinen publish.")
            return
        
        if all(val) and validateYear(publish):
            try:
                sql = "INSERT INTO elokuvat (nimi, ohjaaja, publish, kesto, genre, paa_nayttelija, arvostelu) VALUES (%s, %s, %s, %s, %s, %s, %s)"
                mycursor.execute(sql, val)
                mydb.commit()
                print(mycursor.rowcount, " elokuva lisätty.")
            except mysql.connector.errors.IntegrityError as e:
                print("Elokuva on jo tietokannassa")
                messagebox.showerror("Virhe!", "Elokuva on jo tietokannassa.")
            
    def validateYear(year):
        try:
            year = int(year)
            currentYear = datetime.datetime.now().year
            if 1888 <= year <= currentYear:
                return True
            else:
                return False
        except ValueError:
            return False
    
    def movieList():
        listbox.delete(0, END)
        tiedot = searchData()
        for row in tiedot:
            values = f"{row[0]:<45} {row[1]:<4} {row[2]}"
            listbox.insert(END, values) 
    
    def searchData(): 
        if combo.get()[-1:] == "V":
            order = f" ORDER BY {combo.get()[:-2]} DESC"
        elif combo.get()[-1:] == "^":
            order = f" ORDER BY {combo.get()[:-2]} ASC"
        else:
            order = ""
        mycursor.execute(f"SELECT * FROM elokuvat{order}")
        myresult = mycursor.fetchall()
        return myresult
    
    def deleteData(val):
        try:
            sql = f'DELETE FROM elokuvat WHERE nimi="{val[0]}" and ohjaaja="{val[1]}" and publish="{val[2]}" and kesto="{val[3]}" and genre="{val[4]}" and paa_nayttelija="{val[5]}" and arvostelu="{val[6]}"'
            mycursor.execute(sql)
            mydb.commit()
            print(mycursor.rowcount, " record(s) deleted")
        except mysql.connector.errors.IntegrityError as e:
            print("Elokuva ei ole tietokannassa")
            messagebox.showerror("Virhe!", "Elokuva ei ole tietokannassa.")

    contents()

root = tk.Tk()
root.title("Valitse")
root.geometry("300x150")

loginRegisterPage()

root.mainloop()
