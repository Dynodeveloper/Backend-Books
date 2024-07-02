using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure database connection
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySQL(
                "Server=monorail.proxy.rlwy.net;Port=53742;Database=railway;User=root;Password=aOzaCoLTopmiCTtMHvBhJLPLDUHeIrPV;"));

        // Register controllers
        builder.Services.AddControllers();

        // Build the application
        var app = builder.Build();

        // Configure CORS
        app.UseCors(options =>
        {
            options.AllowAnyOrigin() // Permite cualquier origen
                   .AllowAnyMethod() // Permite cualquier método HTTP (GET, POST, etc.)
                   .AllowAnyHeader(); // Permite cualquier header HTTP
        });

        // Use middleware
        app.UseRouting();

        // Configure endpoints
        app.MapControllers();

        // Run the application
        app.Run();
    }
}
