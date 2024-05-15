<?php

class Movie
{ 
    public string $name;
    public int $year;
    public int $length;
    public string $genre;
    public string $main_actor;
    public string $director;
    public float $rating;
    public string $image;

    function __construct($name, $year, $length, $genre, $main_actor, $director, $rating, $image)
    {
        $this->name = $name;
        $this->year = $year;
        $this->length = $length;
        $this->genre = $genre;
        $this->main_actor = $main_actor;
        $this->director = $director;
        $this->rating = $rating;
        $this->image = $image;
    }
}