using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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

    public void OnGet()
    {
        // Handle GET requests
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        bool isValidLogin = IsValidLogin(Username, Password);

        if (isValidLogin)
        {
            if (Username == "IAmRajababu")
            {
                return RedirectToPage("/Admin/AdminDashboard"); // Redirect to admin dashboard
            }
            else
            {
                return RedirectToPage("/User/Index"); // Redirect to user dashboard
            }
        }
        else
        {
            ViewData["ErrorMessage"] = "Invalid username or password.";
            _logger.LogWarning($"Failed login attempt for username: {Username}");
        }

        return Page();
    }

    private bool IsValidLogin(string username, string password)
    {
        // Implement your authentication logic here
        // For example, check against a database or external service
        // DO NOT store passwords in plain text in production code

        // Example: Check for a predefined username and password
        return username == "IAmRajababu" && password == "MyPassword";
    }
}
