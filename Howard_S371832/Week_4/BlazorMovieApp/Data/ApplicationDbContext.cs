using BlazorMovieApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovieApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}