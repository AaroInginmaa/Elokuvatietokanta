﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Elokuvatietokanta.Classes
{
    internal class Database
    {
        private readonly string Host;
        private readonly string Username;
        private readonly string Password;
        private readonly string DatabaseName;

        private readonly MySqlConnection _connection;

        public Database()
        {
            Host = "mc.koudata.fi";
            Username = "dbuser";
            Password = "Nakkikastike123!";
            DatabaseName = "moviedb";

            string connectionString = $"server={Host};uid={Username};pwd={Password};database={DatabaseName}";
            _connection = new MySqlConnection(connectionString);
        }

        public bool Connect()
        {
            //Tässä katotaan että jos connection on open, jos ei nii laitetaa päälle
            //älä ota if elseä pois koska muuten se failaa jos yrittää avata connectionia kun se on jo auki
            try
            {
                if(_connection.State != ConnectionState.Open)
                {
                    _connection.Open();

                    return true;
                }
                else
                {
                    return true;
                }
                
            }
            catch
            {
                return false;
            }
        }

        public void Close()
        {
            _connection.Close();
        }

        // Queryt mitkä ei muuttaa/lisää tietoja kuten SELECT
        public int NonDestructiveQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, _connection);
            int firstRow = Convert.ToInt32(command.ExecuteScalar());

            // Käytä queryssä SELECT COUNT(*) FROM... saadaksesi rivien määrän
            return firstRow;
        }

        // Queryt mitkä muuttaa/lisää tietoja kuten INSERT ja DELETE
        public int DestructiveQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, _connection);
            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }

        public int DeleteMovie(string name)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("DELETE FROM movies WHERE Name = @name", _connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }

        public void FillDataGrid(DataGrid dg)
        {
            string sql = "SELECT Name as Name, Length, ReleaseYear, Genres, MainActors, Director, Rating FROM movies";
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            cmd.ExecuteNonQuery();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable("movies");

            dataAdapter.Fill(dataTable);
            dg.ItemsSource = dataTable.DefaultView;
            dataAdapter.Update(dataTable);

        }
    }
}

