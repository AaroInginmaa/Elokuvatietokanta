@echo Poistetaan vanhoja tiedostoja . . .
rmdir /s/q C:\xampp\htdocs\php

@echo Kopioidaan tiedostoja . . .
xcopy /s /I /Y c:\repos\Elokuvatietokanta\php C:\xampp\htdocs\php

@echo Valmis