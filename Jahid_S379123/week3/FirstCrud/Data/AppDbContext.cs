using Microsoft.EntityFrameworkCore;
using FirstCrud.Models;

namespace FirstCrud.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}
