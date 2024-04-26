package com.example.moviedb

import android.os.StrictMode
import android.os.StrictMode.ThreadPolicy
import java.sql.Connection
import java.sql.DriverManager

class Database {
    public fun CreateConnection() : Connection?
    {
        // ????????????????????????????????????????????????????????????????
        val policy = ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        // ????????????????????????????????????????????????????????????????
        val conStr = "jdbc:mysql://mc.koudata.fi:3306/moviedb?characterEncoding=latin1&useConfigs=maxPerformance";
        val user = "app";
        val pass = "databaseApp!";

        Class.forName("com.mysql.jdbc.Driver");
        try {
            val con = DriverManager.getConnection(conStr, user, pass);
            return con;
        } catch (ex : Exception) {
            return null;
        }
    }

    fun GetData(con: Connection?): MutableList<Array<Any>> {

        val stmt = con?.createStatement();
        val rs = stmt?.executeQuery("SELECT * FROM moviedb.movies WHERE 1");

        val data: MutableList<Array<Any>> = mutableListOf();

        if (rs != null) {
            while (rs.next())
            {
                val id = rs.getInt(1)
                val name = rs.getString(2)
                val length = rs.getInt(3)
                val releaseYear = rs.getInt(4)
                val genres = rs.getString(5)
                val actors = rs.getString(6)
                val director = rs.getString(7)
                val rating = rs.getFloat(8)
                val image = rs.getString(9)

                data.add(arrayOf(id.toString(), name, length.toString(), releaseYear.toString(), genres, actors, director, rating.toString(), image))
            }
        }
        return data;
    }
}