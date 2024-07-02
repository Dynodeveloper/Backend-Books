using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// Replace with your project's namespace

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
        // Register controllers
        builder.Services.AddControllers();

        // Build the application
        var app = builder.Build();

        // Use middleware
        app.UseRouting();

        // Configure endpoints
        app.MapControllers();

        // Run the application
        app.Run();
    }
}
