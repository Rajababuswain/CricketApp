using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
//using YourProjectName.Repositories; // Adjust this based on your project's structure

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public LoginModel(ILogger<LoginModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        // Handle GET requests
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Use UserRepository for authentication
        bool isValidLogin = UserRepository.ValidateCredentials(Username, Password);

        if (isValidLogin)
        {
            // Use UserRepository to get user role
            string role = UserRepository.GetUserRole(Username);

            if (role == "Admin")
            {
                return RedirectToPage("/Admin/AdminDashboard");
            }
            else if (role == "User")
            {
                return RedirectToPage("/User/UserDashboard");
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid user role";
                _logger.LogWarning($"Invalid role for username: {Username}");
            }
        }
        else
        {
            bool isValidUserLogin = UserRepository.ValidateUserCredentials(Username, Password);

            if (isValidUserLogin)
            {
                return RedirectToPage("/User/UserDashboard");
            }
            ViewData["ErrorMessage"] = "Invalid username or password.";
            _logger.LogWarning($"Failed login attempt for username: {Username}");
        }

        return Page();
    }
}