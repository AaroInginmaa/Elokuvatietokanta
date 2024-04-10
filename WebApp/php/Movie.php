<?php

class Movie
{ 
    private $actors_arr = array();

    public string $name;
    public string $director;
    public int $year;
    public int $lenght;
    public string $actors_str;

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
            array_push($this->actors_arr, $actor_name);
            $this->actors_str = implode(", ", $this->actors_arr);
        }
        catch(Exception $exception)
        {
            return false;
        }
        return true;
    }
}