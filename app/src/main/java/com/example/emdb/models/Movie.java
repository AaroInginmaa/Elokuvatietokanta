package com.example.emdb.models;

public class Movie {
    public Movie(int id, String title, int length, String releaseYear, String genres, String stars, String director, float rating, String image) {
        Id = id;
        Title = title;
        Length = length;
        ReleaseYear = releaseYear;
        Genres = genres;
        Stars = stars;
        Director = director;
        Rating = rating;
        Image = image;
    }

    public int Id;
    public String Title;
    public int Length;
    public String ReleaseYear;
    public String Genres;
    public String Stars;
    public String Director;
    public float Rating;
    public String Image;

    public int getId() {
        return Id;
    }

    private void setId(int id) {
        Id = id;
    }

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public int getLength() {
        return Length;
    }

    public void setLength(int length) {
        Length = length;
    }

    public String getReleaseYear() {
        return ReleaseYear;
    }

    public void setReleaseYear(String releaseYear) {
        ReleaseYear = releaseYear;
    }

    public String getGenres() {
        return Genres;
    }

    public void setGenres(String genres) {
        Genres = genres;
    }

    public String getStars() {
        return Stars;
    }

    public void setStars(String stars) {
        Stars = stars;
    }

    public String getDirector() {
        return Director;
    }

    public void setDirector(String director) {
        Director = director;
    }

    public float getRating() {
        return Rating;
    }

    public void setRating(float rating) {
        Rating = rating;
    }

    public String getImage() {
        return Image;
    }

    public void setImage(String image) { Image = image; }
}
