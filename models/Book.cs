
public class Book
{
    public int Id { get; set; } // Primary key (auto-incremented)
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }

    public string ImageUrl { get; set; }

    // (Opcional) Agregar propiedades adicionales si las necesitas)

    public virtual List<Review> Reviews { get; set; } // One-to-many relationship with reviews
}
