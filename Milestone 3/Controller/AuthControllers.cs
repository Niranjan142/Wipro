using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwtService;

    public AuthController(AppDbContext context,
                          JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool exists = await _context.Users
            .AnyAsync(u => u.Username == model.Username);

        if (exists)
            return BadRequest(new
            {
                message = "Username already exists"
            });

        var user = new User
        {
            Username = model.Username,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(model.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "User registered successfully. Please log in."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u =>
                u.Username == model.Username);

        if (user == null)
        {
            return Unauthorized(new
            {
                message = "Invalid username or password"
            });
        }

        bool validPassword =
            BCrypt.Net.BCrypt.Verify(
                model.Password,
                user.PasswordHash);

        if (!validPassword)
        {
            return Unauthorized(new
            {
                message = "Invalid username or password"
            });
        }

        string token = _jwtService.GenerateToken(user);

        return Ok(new
        {
            token,
            expires_in = 3600,
            user = new
            {
                username = user.Username
            }
        });
    }
}
