using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/reset-password")]
[ApiController]
public class ResetPasswordController : ControllerBase
{
    private readonly AppDbContext _context;

    public ResetPasswordController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

        if (user == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        if (!string.IsNullOrEmpty(model.Password))
        {
            user.Password = model.Password; // Asegúrate de hash la contraseña
            await _context.SaveChangesAsync();
            return Ok("Su contraseña ha sido restablecida exitosamente.");
        }

        return Ok("Correo validado.");
    }
}

public class ResetPasswordModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
