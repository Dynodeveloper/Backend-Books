public class Review
{
    public int Id { get; set; } // Primary key
    public int Rating { get; set; } // Rating from 1 to 5 (or as appropriate)
    public string Content { get; set; }

    public int BookId { get; set; } // Foreign key referencing the Book table
    public Book Book { get; set; } // Navigation property to the related Book

    // (Opcional) Agregar propiedades adicionales si las necesitas)
}
