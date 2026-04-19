using Microsoft.EntityFrameworkCore;
using ProductsWebApiDemo.Models;

namespace ProductsWebApiDemo.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        // Create a table into the database
        public DbSet<Product> Products => Set<Product>();
    }
}
