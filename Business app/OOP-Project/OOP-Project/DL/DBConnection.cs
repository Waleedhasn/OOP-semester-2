using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace OOP_Project.DL
{
    internal class DBConnection
    {
        private static DBConnection instance;
        private MySqlConnection connection;

        // Private constructor to prevent multiple instances
        private DBConnection()
        {
            string connectionString = "server=Localhost;database=oop_final;user=root;password=1234567890;";
            connection = new MySqlConnection(connectionString);
        }

        // Public method to retrieve the single instance
        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }

        // Open database connection
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Close database connection
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
        // Execute query and return results
        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
    }
}
