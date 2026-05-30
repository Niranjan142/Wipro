using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    [Required]
    [MinLength(4)]
    public string Username { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }
}
