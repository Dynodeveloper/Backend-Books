public class Book
{
    public int Id { get; set; } // Primary key
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }

    public virtual List<Review> Reviews { get; set; } // Navigation property
}
