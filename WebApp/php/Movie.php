<?php

class Movie
{ 
    public string $name;
    public string $director;
    public int $year;
    public int $lenght;
    public $actors = array();

    function __construct($name, $lenght, $year)
    {
        $this->name = $name;
        $this->lenght = $lenght;
        $this->year= $year;
    }

    public function add_actor($actor_name)
    {
        try
        {
            array_push($this->actors, $actor_name);
        }
        catch(Exception $exception)
        {
            echo("Error adding new actor. | $exception");

            return false;
        }

        echo("Succesfully added new actor.");

        return true;
    }
}