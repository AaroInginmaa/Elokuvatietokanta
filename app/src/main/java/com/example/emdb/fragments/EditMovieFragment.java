package com.example.emdb.fragments;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.widget.AppCompatButton;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;

import com.example.emdb.R;
import com.example.emdb.activities.MainActivity;
import com.example.emdb.classes.Database;
import com.example.emdb.classes.InputValidator;
import com.example.emdb.models.Movie;

public class EditMovieFragment extends Fragment {
    private EditText titleInput;
    private EditText lengthInput;
    private EditText yearInput;
    private EditText genresInput;
    private EditText directorInput;
    private EditText starsInput;
    private EditText ratingInput;
    private EditText imageUrlInput;
    private Movie movie;

    private final Database database = Database.getInstance();
    private final InputValidator inputValidator = new InputValidator();

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_edit_movie, container, false);

        // Retrieve the movie object from the bundle
        Bundle arguments = getArguments();
        if (arguments != null) {
            Movie movie = arguments.getParcelable("movie");
            // Use the movie object as needed
        }

        return view;
    }

    private void initView(View view) {
        titleInput = view.findViewById(R.id.movieNameInput);
        lengthInput = view.findViewById(R.id.movieLengthInput);
        yearInput = view.findViewById(R.id.movieYearInput);
        genresInput = view.findViewById(R.id.movieGenresInput);
        directorInput = view.findViewById(R.id.movieDirectorInput);
        starsInput = view.findViewById(R.id.movieStarsInput);
        ratingInput = view.findViewById(R.id.movieRatingInput);
        imageUrlInput = view.findViewById(R.id.movieImageInput);
        AppCompatButton saveButton = view.findViewById(R.id.saveButton);
        saveButton.setOnClickListener(v -> onSaveButton());
    }

    private void populateFields(Movie movie) {
        titleInput.setText(movie.getTitle());
        lengthInput.setText(String.valueOf(movie.getLength()));
        yearInput.setText(movie.getReleaseYear());
        genresInput.setText(movie.getGenres());
        directorInput.setText(movie.getDirector());
        starsInput.setText(movie.getStars());
        ratingInput.setText(String.valueOf(movie.getRating()));
        imageUrlInput.setText(movie.getImage());
    }

    private void onSaveButton() {
        String title = titleInput.getText().toString();
        String lengthText = lengthInput.getText().toString();
        String year = yearInput.getText().toString();
        String genres = genresInput.getText().toString();
        String director = directorInput.getText().toString();
        String stars = starsInput.getText().toString();
        String ratingText = ratingInput.getText().toString();
        String imageUrl = imageUrlInput.getText().toString();

        boolean validTitle = inputValidator.validInput(title);
        boolean validLength = inputValidator.validLength(lengthText);
        boolean validYear = inputValidator.validReleaseYear(year);
        boolean validGenres = inputValidator.validInput(genres);
        boolean validDirector = inputValidator.validInput(director);
        boolean validStars = inputValidator.validInput(stars);
        boolean validRating = inputValidator.validRating(ratingText);

        FragmentActivity currentActivity = getActivity();

        if (validTitle && validLength && validYear && validGenres && validDirector && validStars && validRating) {
            int length = Integer.parseInt(lengthText);
            float rating = Float.parseFloat(ratingText);

            movie.setTitle(title);
            movie.setLength(length);
            movie.setReleaseYear(year);
            movie.setGenres(genres);
            movie.setDirector(director);
            movie.setStars(stars);
            movie.setRating(rating);
            movie.setImage(imageUrl);

            database.updateMovie(movie);

            Toast.makeText(currentActivity, "Movie updated", Toast.LENGTH_SHORT).show();

            startActivity(new Intent(currentActivity, MainActivity.class));
        } else {
            if (!validTitle) {
                Toast.makeText(currentActivity, "Invalid title input", Toast.LENGTH_SHORT).show();
            } else if (!validLength) {
                Toast.makeText(currentActivity, "Invalid length input", Toast.LENGTH_SHORT).show();
            } else if (!validYear) {
                Toast.makeText(currentActivity, "Invalid release year input", Toast.LENGTH_SHORT).show();
            } else if (!validGenres) {
                Toast.makeText(currentActivity, "Invalid genres input", Toast.LENGTH_SHORT).show();
            } else if (!validDirector) {
                Toast.makeText(currentActivity, "Invalid director input", Toast.LENGTH_SHORT).show();
            } else if (!validStars) {
                Toast.makeText(currentActivity, "Invalid stars input", Toast.LENGTH_SHORT).show();
            } else if (!validRating) {
                Toast.makeText(currentActivity, "Invalid rating input", Toast.LENGTH_SHORT).show();
            } else {
                Toast.makeText(currentActivity, "Invalid input", Toast.LENGTH_SHORT).show();
            }
        }
    }
}
