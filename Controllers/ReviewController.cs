using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// Reemplaza con el nombre real de tu proyecto

[Route("api/review")]
[ApiController]
public class ReviewController : Controller
{
    private readonly AppDbContext _context;

    public ReviewController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviews = await _context.Review.Include(r => r.Book).ToListAsync();
        return Json(reviews);
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetReviewsByBookId(int bookId)
    {
        var reviews = await _context.Review.Where(r => r.BookId == bookId).Include(r => r.Book).ToListAsync();
        return Json(reviews);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] Review review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Review.Add(review);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReviewById", new { id = review.Id }, review);
    }

   


    // Agregar métodos para editar, eliminar reseñas, etc.
}

