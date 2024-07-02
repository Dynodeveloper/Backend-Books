using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/Categories")] // Route for the controller
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]  // Denotes this method handles GET requests
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _context.categories.ToListAsync(); // Get all categories
        return Ok(categories); // Return categories with status code 200 (OK)
    }
}
