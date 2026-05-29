using System.ComponentModel.DataAnnotations;
using RegistrationValidationSystem.Validation;

namespace RegistrationValidationSystem.Models
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [PasswordMatch]
        public string ConfirmPassword { get; set; }
    }
}
