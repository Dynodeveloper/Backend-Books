using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

[Route("api/register")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly AppDbContext _context;

    public RegistrationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
    {
        // Verificar si ya existe un usuario con el mismo email
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);
        if (existingUser != null)
        {
            return BadRequest("El correo electrónico ya está registrado."); // Retorna un error si el usuario ya existe
        }

        // Crear un nuevo usuario con los datos proporcionados
        var newUser = new User
        {
            Username = registerDto.Username,
            Email = registerDto.Email,
            Password = registerDto.Password // Aquí deberías hashear la contraseña para almacenarla de manera segura
            // Otros campos del usuario si es necesario
        };

        try
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserById", new { id = newUser.Id }, newUser); // Retorna el usuario creado
        }
        catch (Exception ex)
        {
            // Manejo de excepciones si ocurre algún error al guardar en la base de datos
            return StatusCode(500, $"Error interno al registrar usuario: {ex.Message}");
        }
    }
}

// DTO (Data Transfer Object) para el registro de usuario
public class UserRegisterDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    // Otros campos necesarios para el registro
}
