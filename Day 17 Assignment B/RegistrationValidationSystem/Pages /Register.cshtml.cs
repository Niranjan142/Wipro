using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegistrationValidationSystem.Models;

namespace RegistrationValidationSystem.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistration UserRegistration { get; set; }
            = new UserRegistration();

        public string Message { get; set; } = "";

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Message = "Registration successful!";

            return Page();
        }
    }
}
