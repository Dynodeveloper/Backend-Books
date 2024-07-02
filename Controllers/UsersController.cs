using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

[Route("api/Users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return new JsonResult(users);
    }

   [HttpPost]
public async Task<IActionResult> CreateUser([FromBody] User user)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetUserById", new { id = user.Id }, user);
}




}

// Data transfer object (optional)


