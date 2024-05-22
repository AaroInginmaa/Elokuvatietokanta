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

        Bundle args = getArguments();
        if (args != null) {
            movie = (Movie) args.getSerializable("movie");
            if (movie != null) {
                initView(view);
                populateFields(movie);
            } else {
                Toast.makeText(getActivity(), "Movie data is missing", Toast.LENGTH_SHORT).show();
            }
        } else {
            Toast.makeText(getActivity(), "Arguments are missing", Toast.LENGTH_SHORT).show();
        }

        return view;
    }

    private void initView(View view) {
        titleInput = view.findViewById(R.id.movieNameInput1);
        lengthInput = view.findViewById(R.id.movieLengthInput1);
        yearInput = view.findViewById(R.id.movieYearInput1);
        genresInput = view.findViewById(R.id.movieGenresInput1);
        directorInput = view.findViewById(R.id.movieDirectorInput1);
        starsInput = view.findViewById(R.id.movieStarsInput1);
        ratingInput = view.findViewById(R.id.movieRatingInput1);
        imageUrlInput = view.findViewById(R.id.movieImageInput1);
        AppCompatButton saveButton = view.findViewById(R.id.saveButton);

        saveButton.setOnClickListener(v -> {
            Toast.makeText(getActivity(), "Save button clicked", Toast.LENGTH_SHORT).show();
            onSaveButton();
        });
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

            Intent intent = new Intent(currentActivity, MainActivity.class);
            startActivity(intent);
        } else {
            String errorMessage = "Invalid input: ";
            if (!validTitle) errorMessage += "Title, ";
            if (!validLength) errorMessage += "Length, ";
            if (!validYear) errorMessage += "Year, ";
            if (!validGenres) errorMessage += "Genres, ";
            if (!validDirector) errorMessage += "Director, ";
            if (!validStars) errorMessage += "Stars, ";
            if (!validRating) errorMessage += "Rating, ";
            Toast.makeText(currentActivity, errorMessage.substring(0, errorMessage.length() - 2), Toast.LENGTH_SHORT).show();
        }
    }
}