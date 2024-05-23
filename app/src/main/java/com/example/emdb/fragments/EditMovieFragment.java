package com.example.emdb.fragments;

import android.os.Bundle;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.example.emdb.R;
import com.example.emdb.classes.Database;
import com.example.emdb.models.Movie;

public class EditMovieFragment extends Fragment {

    private EditText movieNameInput;
    private EditText movieLengthInput;
    private EditText movieYearInput;
    private EditText movieGenresInput;
    private EditText movieDirectorInput;
    private EditText movieStarsInput;
    private EditText movieRatingInput;
    private EditText movieImageInput;
    private Button saveButton;
    private ImageView backImage;

    private Movie currentMovie;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_edit_movie, container, false);

        movieNameInput = view.findViewById(R.id.movieNameInput);
        movieLengthInput = view.findViewById(R.id.movieLengthInput);
        movieYearInput = view.findViewById(R.id.movieYearInput);
        movieGenresInput = view.findViewById(R.id.movieGenresInput);
        movieDirectorInput = view.findViewById(R.id.movieDirectorInput);
        movieStarsInput = view.findViewById(R.id.movieStarsInput);
        movieRatingInput = view.findViewById(R.id.movieRatingInput);
        movieImageInput = view.findViewById(R.id.movieImageInput);
        saveButton = view.findViewById(R.id.saveButton);

        if (getArguments() != null) {
            currentMovie = getArguments().getParcelable("movie");
            populateFields(currentMovie);
        }

        saveButton.setOnClickListener(v -> onSaveButtonClicked());

        backImage = view.findViewById(R.id.backImage);

        backImage.setOnClickListener(v -> {
            assert getFragmentManager() != null;
            getFragmentManager().popBackStack();
        });

        return view;
    }

    private void populateFields(Movie movie) {
        if (movie != null) {
            movieNameInput.setText(movie.getTitle());
            movieLengthInput.setText(String.valueOf(movie.getLength()));
            movieYearInput.setText(movie.getReleaseYear());
            movieGenresInput.setText(movie.getGenres());
            movieDirectorInput.setText(movie.getDirector());
            movieStarsInput.setText(movie.getStars());
            movieRatingInput.setText(String.valueOf(movie.getRating()));
            movieImageInput.setText(movie.getImage());
        }
    }

    private void onSaveButtonClicked() {
        // Validate and save the updated movie details
        String title = movieNameInput.getText().toString();
        String length = movieLengthInput.getText().toString();
        String year = movieYearInput.getText().toString();
        String genres = movieGenresInput.getText().toString();
        String director = movieDirectorInput.getText().toString();
        String stars = movieStarsInput.getText().toString();
        String rating = movieRatingInput.getText().toString();
        String image = movieImageInput.getText().toString();

        if (validateInputs(title, length, year, genres, director, stars, rating)) {
            currentMovie.setTitle(title);
            currentMovie.setLength(Integer.parseInt(length));
            currentMovie.setReleaseYear(year);
            currentMovie.setGenres(genres);
            currentMovie.setDirector(director);
            currentMovie.setStars(stars);
            currentMovie.setRating(Float.parseFloat(rating));
            currentMovie.setImage(image);

            Database.getInstance().updateMovie(currentMovie);
            Toast.makeText(getContext(), "Movie updated successfully", Toast.LENGTH_SHORT).show();
        }
    }

    private boolean validateInputs(String title, String length, String year, String genres, String director, String stars, String rating) {
        if (TextUtils.isEmpty(title) || TextUtils.isEmpty(length) || TextUtils.isEmpty(year) || TextUtils.isEmpty(genres) || TextUtils.isEmpty(director) || TextUtils.isEmpty(stars) || TextUtils.isEmpty(rating)) {
            Toast.makeText(getContext(), "Please fill all required fields", Toast.LENGTH_SHORT).show();
            return false;
        }
        return true;
    }
}
