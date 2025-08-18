using Microsoft.EntityFrameworkCore;
using MovieApplication.Models.Entities;

namespace MovieApplication.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
