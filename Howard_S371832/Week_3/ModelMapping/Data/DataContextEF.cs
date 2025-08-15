using ModelMapping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ModelMapping.Data
{
  public class DataContextEF(IConfiguration config) : DbContext
  {
    private readonly string _connectionString = config.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    public DbSet<Computer>? Computer { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      if (!options.IsConfigured)
      {
        options.UseSqlServer(_connectionString, options => options.EnableRetryOnFailure());
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("TutorialAppSchema");

      modelBuilder.Entity<Computer>();
      // .ToTable("Computer", "TutorialSchema");
    }
  }
}