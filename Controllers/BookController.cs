using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[Route("api/Books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _context.Books.Include(b => b.Reviews).ToListAsync();

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve, // Manejar referencias circulares
            WriteIndented = true // Para un formato de JSON más legible (opcional)
        };

        return new JsonResult(books, options);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _context.Books.Include(b => b.Reviews).FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve, // Manejar referencias circulares
            WriteIndented = true // Para un formato de JSON más legible (opcional)
        };

        return new JsonResult(book, options);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }
}
