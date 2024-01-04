using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CricketApp.Pages.RegisterationFolder
{
    public class RegisterModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public RegisterModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the page with validation errors
                return Page();
            }

            string connectionString = _configuration.GetConnectionString("MySqlConnection");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the username or email already exists (you may want to add unique constraints in the database)
                    using (MySqlCommand checkCommand = new MySqlCommand("SELECT COUNT(*) FROM registration WHERE Username = @Username OR Email = @Email", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", Input.Username);
                        checkCommand.Parameters.AddWithValue("@Email", Input.Email);

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            // Username or email already exists, return with an error
                            ErrorMessage = "Username or email already exists.";
                            return Page();
                        }
                    }

                    // Insert data into the Users table
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO registration (Username, Password, Email) VALUES (@Username, @Password, @Email)", connection))
                    {
                        command.Parameters.AddWithValue("@Username", Input.Username);
                        command.Parameters.AddWithValue("@Password", Input.Password);
                        command.Parameters.AddWithValue("@Email", Input.Email);

                        command.ExecuteNonQuery();
                    }

                    // Redirect to the login page after successful registration
                    return RedirectToPage("/LoginFolder/Login");
                }
                catch (Exception ex)
                {
                    // Handle the exception, log it, or display an error message
                    ErrorMessage = $"Error: {ex.Message}";
                    return Page();
                }
            }
        }
    }

    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
