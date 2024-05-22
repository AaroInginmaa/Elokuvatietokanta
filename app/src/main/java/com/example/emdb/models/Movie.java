package com.example.emdb.models;

import android.os.Parcel;
import android.os.Parcelable;

public class Movie implements Parcelable {
    public int Id;
    public String Title;
    public int Length;
    public String ReleaseYear;
    public String Genres;
    public String Stars;
    public String Director;
    public float Rating;
    public String Image;

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

    protected Movie(Parcel in) {
        Id = in.readInt();
        Title = in.readString();
        Length = in.readInt();
        ReleaseYear = in.readString();
        Genres = in.readString();
        Stars = in.readString();
        Director = in.readString();
        Rating = in.readFloat();
        Image = in.readString();
    }

    public static final Creator<Movie> CREATOR = new Creator<Movie>() {
        @Override
        public Movie createFromParcel(Parcel in) {
            return new Movie(in);
        }

        @Override
        public Movie[] newArray(int size) {
            return new Movie[size];
        }
    };

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(Id);
        dest.writeString(Title);
        dest.writeInt(Length);
        dest.writeString(ReleaseYear);
        dest.writeString(Genres);
        dest.writeString(Stars);
        dest.writeString(Director);
        dest.writeFloat(Rating);
        dest.writeString(Image);
    }

    // Getters and setters (unchanged)
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
