import tkinter as tk
from tkinter import *
import mysql.connector
from tkinter import ttk
from tkinter import messagebox


def loginRegisterPage():
    
    def contents():
        global registerButton,loginButton
        
        #Buttons
        registerButton = tk.Button(text="Register",command=clickRegister)
        loginButton = tk.Button(text="Log In",command=clickLogin)
        
        #Placements
        registerButton.place(relx=.5,rely=.40,anchor=CENTER)
        loginButton.place(relx=.5,rely=.60,anchor=CENTER)
    
    def clickRegister():
        listOfContents = [registerButton,loginButton]
        root.title("Register Page")
        root.geometry("500x500")
        for i in listOfContents:
            i.destroy()
        RegisterPage()
    
    def clickLogin():
        listOfContents = [registerButton,loginButton]
        root.title("Log In")
        root.geometry("350x450")
        for i in listOfContents:
            i.destroy()
            
        LogInPage()
    
    contents()
    
def LogInPage():
    def contents():
        global nameOrEmailText_LogInPage, passwordText_LogInPage, nameOrEmailTextEntry_LogInPage, passwordTextEntry_LogInPage, loginButton_LoginPage,backButton_LoginPage
        
        #Texts
        nameOrEmailText_LogInPage = tk.Label(text="Name/Email")
        passwordText_LogInPage = tk.Label(text="Password")
        
        #Entrys
        nameOrEmailTextEntry_LogInPage = tk.Entry()
        passwordTextEntry_LogInPage = tk.Entry()
        
        #Buttons
        loginButton_LoginPage = tk.Button(text="Log In",command=clickLogin)
        backButton_LoginPage = tk.Button(text="Back",command=clickBack)
        
        #Placements
        nameOrEmailText_LogInPage.place(relx=.5,rely=.1,anchor=CENTER)
        nameOrEmailTextEntry_LogInPage.place(relx=.5,rely=.2,anchor=CENTER)
        passwordText_LogInPage.place(relx=.5,rely=.3,anchor=CENTER)
        passwordTextEntry_LogInPage.place(relx=.5,rely=.4,anchor=CENTER)
        loginButton_LoginPage.place(relx=.5,rely=.5,anchor=CENTER)
        backButton_LoginPage.place(relx=.5,rely=.8,anchor=CENTER)
    
    def clickLogin():
        nameOrEmailEntryContent = nameOrEmailTextEntry_LogInPage.get()
        passwordEntryContent = passwordTextEntry_LogInPage.get()
        
        db = mysql.connector.connect(host="localhost", user="root", database="elokuvatietokanta")
        cursor = db.cursor()

        sql = "SELECT * FROM kayttajat WHERE (nimi = %s OR sahkoposti = %s) AND salasana = %s"
        cursor.execute(sql, (nameOrEmailEntryContent, nameOrEmailEntryContent, passwordEntryContent))
        user = cursor.fetchone()

        if user:
            messagebox.showinfo("Login Successful", "Welcome!")
            MainWindow()
        else:
            messagebox.showerror("Login Error", "Invalid credentials. Please try again.")

        cursor.close()
        db.close()
        
        
    def clickBack():
        listOfContents = [nameOrEmailText_LogInPage, passwordText_LogInPage, nameOrEmailTextEntry_LogInPage, passwordTextEntry_LogInPage, loginButton_LoginPage,backButton_LoginPage]
        root.title("Select an option")
        root.geometry("300x150")
        for i in listOfContents:
            i.destroy()  
        loginRegisterPage()
        
    contents()

def RegisterPage():
    
    def contents():
        
        global nameTextEntry_RegisterPage,emailTextEntry_RegisterPage,passwordTextEntry_RegisterPage,nameText_RegisterPage,emailText_RegisterPage,passwordText_RegisterPage,registerButton_RegisterPage,backButton_RegisterPage
        
        #Texts
        nameText_RegisterPage = tk.Label(text="Name")
        emailText_RegisterPage = tk.Label(text="Email")
        passwordText_RegisterPage = tk.Label(text="Password")
    
        #Entrys
        nameTextEntry_RegisterPage = tk.Entry()
        emailTextEntry_RegisterPage = tk.Entry()
        passwordTextEntry_RegisterPage = tk.Entry()
        
        #Buttons
        registerButton_RegisterPage = tk.Button(text="Register", command=clickRegister,)
        backButton_RegisterPage = tk.Button(text="Back",command=clickBack)

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
        
        #Take inputs from Entryboxes
        nameEntryContent = nameTextEntry_RegisterPage.get()
        emailEntryContent = emailTextEntry_RegisterPage.get()
        passwordEntryContent = passwordTextEntry_RegisterPage.get()
    
        #Print the inputs
        print(f"Content of nameTextEntry:{nameEntryContent}" )
        print(f"Content of emailTextEntry:{emailEntryContent}")
        print(f"Content of passwordTextEntry:{ passwordEntryContent}")
        
        
        #täs pitäs tarkistaa onko sil nimel tai sähköpostil jo käyttäjää
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
            print('Username and email do not exist')
            messagebox.showinfo("Registration Successful", "User registered successfully!")
            saveToDataBase()
        else:
            print('sähköposti tai käyttäjä on jo käytetty')
        
        
        
     
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
        root.title("Select an option")
        root.geometry("300x150")
         
        for i in listOfContents:
            i.destroy()
        
        loginRegisterPage()
             
    contents()


def MainWindow():
    
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
        hae_button = ttk.Button(text="Hae Data", command=lambda: Lista()).place(x=70, y=90)

        # Lisaa nimi label ja input box
        lisaa_nimi_label =ttk.Label(text="Elokuvan nimi").place(x=70,y=130)
        lisaa_nimi = ttk.Entry(width=30)
        lisaa_nimi.place(x=70,y=150)

        # Lisaa pituus label ja input box
        lisaa_pituus_label =ttk.Label(text="Elokuvan Pituus").place(x=70,y=175)
        lisaa_pituus = ttk.Entry(width=30)
        lisaa_pituus.place(x=70,y=195)

        # Lisaa Julkaisu label ja input box
        lisaa_julkaisu_label =ttk.Label(text="Elokuvan Julkaisu").place(x=70,y=220)
        lisaa_julkaisu = ttk.Entry(width=30)
        lisaa_julkaisu.place(x=70,y=240)


        lisaa_button = ttk.Button(text="Lisää Data", command=lambda: Lisataan_Dataa((str(lisaa_nimi.get()),lisaa_pituus.get(),str(lisaa_julkaisu.get()))))
        lisaa_button.place(x=70, y=265)

        poista_button = ttk.Button(text="Poista Data", command=lambda: Poistetaan_Dataa((str(lisaa_nimi.get()),lisaa_pituus.get(),str(lisaa_julkaisu.get()))))
        poista_button.place(x=170, y=265)
    mydb = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database="elokuvatietokanta"
    )
    mycursor = mydb.cursor()
    
    def Lisataan_Dataa(val):
        # Functio jolle annetaan nimi, pituus ja julkaisu ja se heittää ne data basee 
        # ja jos tulee error ilmoittaa siitä käyttäjälle
        if val[0] != "" and val[1] and val[2]:
            try:
                sql = "INSERT INTO elokuvat (nimi, ohjaaja, julkaisuvuosi, kesto, genre, paa_nayttelija, arvostelu) VALUES (%s, %s, %s)"
                mycursor.execute(sql, val)
                mydb.commit()
                print(mycursor.rowcount, "record(s) inserted.")
            except mysql.connector.errors.IntegrityError as e:
                print("Sisältää jo kyseisen asian")
                messagebox.showerror("Error", "Some records were not inserted due to duplicates.")        
        else:
            print(f"Jotain on vikana seuraavissa\n{val[0]}\n{val[1]}\n{val[2]}")
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
            print(mycursor.rowcount, "record(s) inserted.")
        except mysql.connector.errors.IntegrityError as e:
            print("Sisältää jo kyseisen asian")
            messagebox.showerror("Error", "Some records were not inserted due to duplicates.")

    def dropdown_opened():
        print("The drop-down has been opened!")
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
root.title("Select an option")
root.geometry("300x150")
root.resizable(width=False, height=False)
root.attributes('-topmost', True)

#First window
loginRegisterPage()

root.mainloop()