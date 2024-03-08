
using System;
using System.Data.SqlClient;

namespace BadCodeExample
    {
        public class BadAdoNetExample
        {
        // hard coded connection string
            private static string connectionString = "Data Source=.;Initial Catalog=BadDatabase;Integrated Security=True";
            private static SqlConnection connection;

            public static void Main()
            {
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                //The query is a simple SELECT *, which is generally considered bad practice
                string query = "SELECT * FROM Users";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("Name: " + reader["Name"] + ", Age: " + reader["Age"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
            {   //The SqlCommand and SqlDataReader objects are not disposed of properly.
                if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    //The connection object is not disposed of properly in the finally block.
                }
                //There's no error handling for the connection.Open() method, which could fail.
            }
        }
        }
    }

    
 