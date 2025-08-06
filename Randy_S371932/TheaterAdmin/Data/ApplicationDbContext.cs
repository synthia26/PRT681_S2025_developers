using Microsoft.EntityFrameworkCore;
using TheaterAdmin.Models;

namespace TheaterAdmin.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Movie>()
               .HasOne(m => m.Category)
               .WithMany(c => c.Movies)
               .HasForeignKey(m => m.CategoryId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}