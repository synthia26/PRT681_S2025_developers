using Microsoft.EntityFrameworkCore;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<MovieTheater.Models.Movie> Movie { get; set; } = default!;
    public DbSet<MovieTheater.Models.Category> Category { get; set; } = default!;
}
