<?php

class Movie
{ 
    public string $name;
    public string $director;
    public int $year;
    public int $length;
    public string $genre;
    public string $main_actor;
    public int $rating;

    function __construct($name, $director, $year, $length, $genre, $main_actor, $rating)
    {
        $this->name = $name;
        $this->director = $director;
        $this->year = $year;
        $this->length = $length;
        $this->genre = $genre;
        $this->main_actor = $main_actor;
        $this->rating = $rating;
    }
}