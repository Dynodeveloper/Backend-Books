using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
    {
        // Buscar el usuario por email y contraseña
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

        if (user == null)
        {
            return BadRequest("Credenciales inválidas"); // Retorna un error si las credenciales no son válidas
        }

        // Simulación de generación de token (debes implementar tu propia lógica de autenticación)
        var token = "JWT_TOKEN_GENERADO";

        // Aquí podrías devolver más información del usuario si lo deseas
        return Ok(new { Token = token, user.Id, user.Email }); // Retorna el token y otros datos relevantes
    }
}

// DTO (Data Transfer Object) para el login
public class UserLoginDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
