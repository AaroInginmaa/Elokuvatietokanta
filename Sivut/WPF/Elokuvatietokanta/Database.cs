using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace FromsElokuvaTK
{
    internal class Database
    {
        private string hostname;
        private string username;
        private string password;
        private string database;

        public MySqlConnection connection;

        public Database(string hostname, string username, string password, string database)
        {
            this.hostname = hostname;
            this.username = username;
            this.password = password;
            this.database = database;
        }

        public bool Connect()
        {
            try
            {
                string connectionString = $"server={hostname};uid={username};pwd={password};database={database}";
                connection = new MySqlConnection(connectionString);
                connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Close()
        {
            connection.Close();
        }

        public int Select(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            return count;
        }

        public int Insert(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }

        /*public void FillDataSet(DataGridView dgw)
        {
            string query = "SELECT * FROM elokuvatietokanta.elokuvat;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);
            dgw.DataSource = dataSet.Tables[0];
        }*/
    }
}

