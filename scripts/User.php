<?php

class User
{
    public string $name;
    public string $email;
    public string $password;

    function __construct($name, $email, $password)
    {
        $this->name = $name;
        $this->email = $email;
        $this->password = $password;
    }
}