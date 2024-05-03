import tkinter as tk # pip install tk

# pip install mysql.connector
# Jos saat errorin  Authentication plugin 'caching_sha2_password' is not supported
# Asenna mysql-connector ja mysql-connector-python pip:llä
import mysql.connector 

from tkinter import *
from tkinter import ttk
from tkinter import messagebox
import re
import datetime
import decimal

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
        global loginNameLabel, loginPWordLabel, loginName, loginPWord, checkBoxHideShow, loginButton, backButton, onOff
        
        loginNameLabel = tk.Label(text="Nimi/Sähköposti")
        loginPWordLabel = tk.Label(text="Salasana")
        loginName = tk.Entry()
        loginPWord = tk.Entry()
        loginPWord.configure(show="*")
        onOff = BooleanVar(value=False)
        checkBoxHideShow = tk.Checkbutton(text='Näytä salasana', variable=onOff, onvalue=True, offvalue=False, command=showHide)

            
        loginButton = tk.Button(text="Kirjaudu", command=clickLogin)
        backButton = tk.Button(text="Palaa", command=clickBack)
        
        loginNameLabel.place(relx=.5, rely=.1, anchor=CENTER)
        loginName.place(relx=.5, rely=.2, anchor=CENTER)
        loginPWordLabel.place(relx=.5, rely=.3, anchor=CENTER)
        checkBoxHideShow.place(relx=.8, rely=.4, anchor=CENTER)
        loginPWord.place(relx=.5, rely=.4, anchor=CENTER)
        loginButton.place(relx=.5, rely=.5, anchor=CENTER)
        backButton.place(relx=.5, rely=.8, anchor=CENTER)
    
    def showHide():
        if onOff.get() == False:
            loginPWord.configure(show="*")
        else:
            loginPWord.configure(show="")
    
    
    def clickLogin():
        nameEntry = loginName.get()
        pWordCheck = loginPWord.get()

        if not nameEntry or not pWordCheck:
            messagebox.showerror("Tyhjät kentät", "Täytä Nimi/Sähköposti ja password kentät.")
            return

        db = mysql.connector.connect(host="mc.koudata.fi", user="app", password="databaseApp!" , database="moviedb")
        cursor = db.cursor()

        sql = "SELECT * FROM usertable WHERE (username = %s OR email = %s) AND password = %s"
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
        loginComponents = [loginNameLabel, loginPWordLabel, loginName, loginPWord, checkBoxHideShow, loginButton, backButton]
        root.title("Valitse")
        root.geometry("300x150")
        for i in loginComponents:
            i.destroy()  
        loginRegisterPage()
        
    contents()

def registerPage():
    
    def contents():
        global registerName, registerEmail, registerPWord, registerNameLabel, registerEmailLabel, registerPasswordLabel, registerButton, backButton, checkBoxHideShow, onOff
        
        registerNameLabel = tk.Label(text="Nimi")
        registerEmailLabel = tk.Label(text="Sähköposti")
        registerPasswordLabel = tk.Label(text="password")
        registerName = tk.Entry()
        registerEmail = tk.Entry()
        registerPWord = tk.Entry()
        registerButton = tk.Button(text="Rekisteröidy", command=clickRegister)
        backButton = tk.Button(text="Palaa", command=clickBack)
        onOff = BooleanVar(value=False)
        checkBoxHideShow = tk.Checkbutton(text='Näytä salasana', variable=onOff, onvalue=True, offvalue=False, command=showHide)
        
        registerNameLabel.place(relx=.5, rely=.15, anchor=CENTER)
        registerName.place(relx=.5, rely=.20, anchor=CENTER)
        registerEmailLabel.place(relx=.5, rely=.25, anchor=CENTER)
        registerEmail.place(relx=.5, rely=.30, anchor=CENTER)
        registerPasswordLabel.place(relx=.5, rely=.35, anchor=CENTER)
        checkBoxHideShow.place(relx=.8, rely=.40, anchor=CENTER)
        registerPWord.place(relx=.5, rely=.40, anchor=CENTER)
        registerButton.place(relx=.5, rely=.50, anchor=CENTER)
        backButton.place(relx=.5, rely=.8, anchor=CENTER)
        
        showHide()
    
    def showHide():
        if onOff.get() == False:
            registerPWord.configure(show="*")
        else:
            registerPWord.configure(show="")
    


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
            messagebox.showerror("Virheellinen password", "Salasanan täytyy olla vähintään 6 merkkiä pitkä, sisältää vähintään yhden ison kirjaimen, ja yhden erikoismerkin (!#&%$€£@?).")
            return

        checkExistingUsers()

    def checkExistingUsers():
        db = mysql.connector.connect(host="mc.koudata.fi", user="app", password="databaseApp!" , database="moviedb")
        cursor = db.cursor()
        
        
        username = nameCheck
        email = emailCheck

        cursor.execute('SELECT username FROM usertable WHERE username = %(username)s', {'username': username})
        checkUsername = cursor.fetchall()
        isTakenname = False
        for row in checkUsername:
            if(row[0] == username):
                isTakenname = True

        cursor.execute('SELECT email FROM usertable WHERE email = %(email)s', {'email': email})
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
        db = mysql.connector.connect(host="mc.koudata.fi", user="app", password="databaseApp!" , database="moviedb")
        cursor = db.cursor()
        sql = "INSERT INTO usertable (username, email, password) VALUES (%s, %s, %s)"
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
    
    mydb = mysql.connector.connect(host="mc.koudata.fi", user="app", password="databaseApp!" , database="moviedb")
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

        movieListButton = ttk.Button(text="Elokuvalista", command=showMovieList)
        movieListButton.place(x=70, y=45)
        
        searchMovie = ttk.Entry(width=30)
        searchMovie.place(x=250, y=70)
        
        SearchMovieButton = ttk.Button(text="Hae elokuvaa", command=lambda: searchMovieList((str(searchMovie.get()))))
        SearchMovieButton.place(x=250, y=45)

        
        nameLabel = ttk.Label(text="Nimi").place(x=70, y=100)
        nameAdd = ttk.Entry(width=30)
        nameAdd.place(x=70, y=120)
        
        directorLabel = ttk.Label(text="Pituus").place(x=70, y=145)
        directorAdd = ttk.Entry(width=30)
        directorAdd.place(x=70, y=165)
        
        publishLabel = ttk.Label(text="Julkaistu").place(x=70, y=190)
        publishAdd = ttk.Entry(width=30)
        publishAdd.place(x=70, y=210)
        
        lenghtLabel = ttk.Label(text="Genre").place(x=70, y=235)
        lenghtAdd = ttk.Entry(width=30)
        lenghtAdd.place(x=70, y=255)
        
        genreLabel = ttk.Label(text="Päänäyttelijät").place(x=70, y=280)
        genreAdd = ttk.Entry(width=30)
        genreAdd.place(x=70, y=300)
        
        actorLabel = ttk.Label(text="Ohjaaja").place(x=70, y=325)
        actorAdd = ttk.Entry(width=30)
        actorAdd.place(x=70, y=345)
        
        reviewLabel = ttk.Label(text="Arvio (0-10)").place(x=70, y=370)
        reviewAdd = ttk.Entry(width=30)
        reviewAdd.place(x=70, y=390)
        
        addButton = ttk.Button(text="Lisää elokuva", command=lambda: addData((str(nameAdd.get()), directorAdd.get(), str(publishAdd.get()), str(lenghtAdd.get()), genreAdd.get(), actorAdd.get(), str(reviewAdd.get()))))
        addButton.place(x=70, y=420)

        deleteButton = ttk.Button(text="Poista elokuva", command=lambda: deleteData((str(nameAdd.get()), directorAdd.get(), str(publishAdd.get()), str(lenghtAdd.get()), genreAdd.get(), actorAdd.get(), str(reviewAdd.get()))))
        deleteButton.place(x=170, y=420)
    
    def addData(val):
        name = val[0]
        length = val[1]
        realeseYear = val[2]
        genre = val[3]
        actor = val[4]
        director = val[5]
        rating = val[6]
        
        if len(name) == 0:
            messagebox.showerror("Virheellinen nimi", "Syötä kelvollinen nimi")
            return
            
        if not validateLength(length):
            messagebox.showerror("Virheellinen pituus", "Syötä kelvollinen pituus")
            return
        
        if not validateYear(realeseYear):
            messagebox.showerror("Virheellinen julkaisuvuosi", "Syötä kelvollinen julkaisuvuosi.")
            return
        
        if not validateGenre(genre):
            messagebox.showerror("Virheellinen genre", "Syötä kelvollinen genre")
            return
        
        if not validateActor(actor):
            messagebox.showerror("Virheellinen päänäyttelijä", "Syötä kelvollinen päänäyttelijä")
            return
        
        if not validateDirector(director):
            messagebox.showerror("Virheellinen ohjaaja", "Syötä kelvollinen ohjaaja")
            return
        
        if (all(val) and validateYear(realeseYear) and validateLength(length) and validateGenre(genre)
            and validateActor(actor) and validateDirector(director) and validateRating(rating)):
            try:
                CheckDuplicate = f"SELECT * FROM movies WHERE Name = '{name}' and ReleaseYear = '{realeseYear}'"
                mycursor.execute(CheckDuplicate)
                result = mycursor.fetchall()
                if result:
                    messagebox.showerror("Virhe!", "Elokuva on jo tietokannasaa")
                elif not result:
                    sql = "INSERT INTO movies (Name, Length, ReleaseYear, Genres, MainActors, Director, Rating) VALUES (%s, %s, %s, %s, %s, %s, %s)"
                    mycursor.execute(sql, val)
                    mydb.commit()
                    print(mycursor.rowcount, " elokuva lisätty.")
                else:
                    messagebox.showerror("Virhe tapahtui lisätessä elokuvaa")
            except mysql.connector.errors.IntegrityError as e:
                print(e)
                messagebox.showerror("Virhe!", e)
        else:
            messagebox.showerror("Virhe!", "Jokin tieto on väärin")
            
    def validateLength(Length):
        try:
            if Length.isdigit() == True:
                return True
            else:
                return False
        except ValueError:
            return False        
    
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
    
    def validateGenre(Genre):
        res = bool(re.match(r'[a-zA-Z\s]+$', Genre))
        try:
            if res == True:
                return True
            else:
                return False
        except ValueError:
            return False
        
    def validateActor(Actor):
        res = bool(re.match(r'[a-zA-Z\s]+$', Actor))
        try:
            if res == True:
                return True
            else:
                return False
        except ValueError:
            return False
        
    def validateDirector(Director):
        res = bool(re.match(r'[a-zA-Z\s]+$', Director))
        try:
            if res == True:
                return True
            else:
                return False
        except ValueError:
            return False
        
    def validateRating(Rating):
        try:
            Rating = float(Rating)
            if 0 <= Rating <= 10:
                return True
            else:
                return False
        except ValueError:
            return False
    
    def showMovieList():
        movie_list_window = tk.Toplevel(root)
        movie_list_window.title("Elokuvalista")
        
        my_canvas = Canvas(movie_list_window)
        my_canvas.pack(side=LEFT, fill=BOTH, expand=1)
        
        scrollbar = Scrollbar(movie_list_window, orient=VERTICAL, command=my_canvas.yview)
        scrollbar.pack(side=RIGHT, fill=Y)

        
        my_canvas.configure(yscrollcommand=scrollbar.set)
        my_canvas.bind('<Configure>', lambda e: my_canvas.configure(scrollregion=my_canvas.bbox("all")))
        
        def _on_mousewheel(event):
            my_canvas.yview_scroll(int(-1*(event.delta/120)), "units")
        def _bind_to_mousewheel(event):
            my_canvas.bind_all("<MouseWheel>", _on_mousewheel)
        def _unbind_from_mousewheel(event):
            my_canvas.unbind_all("<MouseWheel>")
            
        my_canvas.bind('<Enter>', _bind_to_mousewheel)
        my_canvas.bind('<Leave>', _unbind_from_mousewheel)

        second_frame = Frame(my_canvas)
        my_canvas.create_window((0, 0), window=second_frame, anchor="nw")

        order = ""
        if combo.get().endswith("V"):
            order = f" ORDER BY {combo.get()[:-2]} DESC"
        elif combo.get().endswith("^"):
            order = f" ORDER BY {combo.get()[:-2]} ASC"

        mycursor.execute(f"SELECT * FROM movies{order}")
        myresult = mycursor.fetchall()

        for idx, movie in enumerate(myresult, start=1):
            movie_frame = ttk.LabelFrame(second_frame, text=f"Elokuva {idx}", width=500)
            movie_frame.pack(fill="x", padx=10, pady=5, anchor="w")

            movie_info = f"Nimi: {movie[1]}\nPituus: {movie[2]}\nJulkaistu: {movie[3]}\nGenre: {movie[4]}\nPäänäyttelijät: {movie[5]}\nOhjaaja: {movie[6]}\nArvio: {movie[7]}"
            movie_label = ttk.Label(movie_frame, text=movie_info, wraplength=400, justify="left")
            movie_label.pack(padx=10, pady=5, anchor="w")

        
    def searchMovieList(val):
        search = val
        mycursor.execute(f"SELECT * FROM movies WHERE Name LIKE '%{search}%'")
        searchResult = mycursor.fetchall()
        
        
        movie_list_window = tk.Toplevel(root)
        movie_list_window.title("Elokuvalista")

        for idx, movie in enumerate(searchResult, start=1):
            movie_frame = ttk.LabelFrame(movie_list_window, text=f"Elokuva {idx}", width=500)
            movie_frame.pack(fill="x", padx=10, pady=5, anchor="w")

            movie_info = f"Nimi: {movie[1]}\nPituus: {movie[2]}\nJulkaistu: {movie[3]}\nGenre: {movie[4]}\nPäänäyttelijät: {movie[5]}\nOhjaaja: {movie[6]}\nArvio: {movie[7]}"
            movie_label = ttk.Label(movie_frame, text=movie_info, wraplength=400, justify="left")
            movie_label.pack(padx=10, pady=5, anchor="w")
        
    def deleteData(val):
        try:
            sql = f'DELETE FROM movies WHERE Name="{val[0]}"'
            mycursor.execute(sql)
            mydb.commit()
            print(mycursor.rowcount, " elokuva poistettu")
        except mysql.connector.errors.IntegrityError as e:
            print("Elokuva ei ole tietokannassa")
            messagebox.showerror("Virhe!", "Elokuva ei ole tietokannassa.")

    contents()

root = tk.Tk()
root.title("Valitse")
root.geometry("300x150")
root.resizable(False, False)

loginRegisterPage()

root.mainloop()