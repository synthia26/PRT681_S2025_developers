using Microsoft.EntityFrameworkCore;
using CrudDemo.Models;

namespace CrudDemo.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();
    }
}
