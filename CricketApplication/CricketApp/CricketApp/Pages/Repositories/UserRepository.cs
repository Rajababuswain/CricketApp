using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;

public class UserRepository
{
    public static bool ValidateCredentials(string username, string password)
    {
        // Implement logic to validate user credentials against a database
        // Use secure password hashing methods
        // Example: Query the database
        // For demo purposes, using a simple example
        return username == "IAmRajababu" && password == "MyPassword";
    }

    public static string GetUserRole(string username)
    {
        // Implement logic to retrieve user role from a database
        // Example: Query the database
        // For demo purposes, returning a hardcoded value
        return "Admin";
    }

    public static bool ValidateUserCredentials(string username, string password)
    {
        string connectionString = "Server = localhost; Port = 3306; Database = cricketapp; Uid = root; Pwd = admin;";
        //Server = localhost; Port = 3306; Database = cricketapp; Uid = root; Pwd = admin;

        // Credentials retrieval query (replace with your actual query)
        string query = "SELECT COUNT(*) FROM registration WHERE username = @Username AND password = @Password";

        try
        {
            // Connect to the MySQL database and execute the query
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    // ExecuteScalar returns the count of rows that match the criteria
                    int userCount = Convert.ToInt32(command.ExecuteScalar());

                    // If there is a match, the credentials are valid
                    return userCount > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception (log it, throw it, etc.)
            Console.WriteLine($"Error: {ex.Message}");
            return false; // Indicate that an error occurred during validation
        }
    }
}