using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CricketApp.Pages.RegisterationFolder
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // Handle GET request if needed
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the page with validation errors
                return Page();
            }

            // TODO: Add logic to save user registration details to the database
            // For example, you might want to use Entity Framework to interact with the database

            // Redirect to the login page after successful registration
            return RedirectToPage("/LoginFolder/Login");

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
