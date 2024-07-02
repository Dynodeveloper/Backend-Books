using Microsoft.EntityFrameworkCore;


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Review { get; set; }

        // Configura las relaciones entre entidades si es necesario
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .HasMany(b => b.Reviews) // Navigation property name
            .WithOne(r => r.Book);

            // Configura las relaciones restantes entre entidades (si las hay)

            base.OnModelCreating(modelBuilder);
        }
    }

