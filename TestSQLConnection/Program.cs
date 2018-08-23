using System;
using System.Data.SqlClient;

namespace TestSQLConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = "Server=" + args[0] + ";Initial Catalog=master;Integrated Security=sspi;Persist Security Info=true";
            Console.WriteLine("Connecting to " + conString);
            using (var connection = new SqlConnection(conString))
            {
                var command = new SqlCommand("SELECT CURRENT_TIMESTAMP", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}");
                    }
                }
            }
        }
    }
}
