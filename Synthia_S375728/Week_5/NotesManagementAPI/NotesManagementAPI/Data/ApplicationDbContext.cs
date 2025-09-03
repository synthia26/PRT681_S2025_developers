using Microsoft.EntityFrameworkCore;
using NotesManagementAPI.Models;

namespace NotesManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
    }
}
