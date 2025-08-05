using Microsoft.EntityFrameworkCore;

namespace MovieApplication.Models
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
       : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
