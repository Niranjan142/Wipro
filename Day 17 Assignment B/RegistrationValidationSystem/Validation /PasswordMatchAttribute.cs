using System.ComponentModel.DataAnnotations;

namespace RegistrationValidationSystem.Validation
{
    public class PasswordMatchAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid
        (
            object value,
            ValidationContext validationContext
        )
        {
            var user =
                (Models.UserRegistration)
                validationContext.ObjectInstance;

            if (user.Password != user.ConfirmPassword)
            {
                return new ValidationResult(
                    "Password and Confirm Password do not match"
                );
            }

            return ValidationResult.Success;
        }
    }
}
