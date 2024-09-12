using System;
using System.Data.SqlClient;

namespace DatabaseConnectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=; Port=3308; Database=filmlist;User Id=demo;Password=demo;";

            string query = "SELECT TOP 5 * FROM YourTable";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection Open!");

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    Console.WriteLine("Connection Closed.");
                }
            }
        }
    }
}
