using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace CricketApp.Pages.Terms
{
    public class TermsAndServicePageModel : PageModel
    {
        public string CurrentYear { get; set; }

        public void OnGet()
        {
            

            // Simple logic example: Get the current year and store it in CurrentYear property
            CurrentYear = DateTime.Now.Year.ToString();
        }
    }
}
