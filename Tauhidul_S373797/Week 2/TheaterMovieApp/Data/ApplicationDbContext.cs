using Microsoft.EntityFrameworkCore;
using TheaterMovieApp.Models;

namespace TheaterMovieApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // These represent our database tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add some starting categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Code = "ACT" },
                new Category { Id = 2, Name = "Drama", Code = "DRA" },
                new Category { Id = 3, Name = "Horror", Code = "HOR" },
                new Category { Id = 4, Name = "Comedy", Code = "COM" }
            );
        }
    }
}