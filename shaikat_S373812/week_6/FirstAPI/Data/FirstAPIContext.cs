using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data
{
    public class FirstAPIContext : DbContext

    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options):base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(

                new Game { Id = 1, Name = "The Legend of Zelda: Breath of the Wild", Company = "Nintendo", ReleaseYear = 2017 },
    new Game { Id = 2, Name = "God of War", Company = "Santa Monica Studio", ReleaseYear = 2018 },
    new Game { Id = 3, Name = "Red Dead Redemption 2", Company = "Rockstar Games", ReleaseYear = 2018 },
    new Game { Id = 4, Name = "Elden Ring", Company = "FromSoftware", ReleaseYear = 2022 },
    new Game { Id = 5, Name = "Cyberpunk 2077", Company = "CD Projekt", ReleaseYear = 2020 }

                );
        }

        public DbSet<Game> Games { get; set; }
    }
}
