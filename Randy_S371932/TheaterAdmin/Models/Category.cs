
using System.ComponentModel.DataAnnotations;

namespace TheaterAdmin.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(64)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(16)]
        public string Code { get; set; } = string.Empty;
        public ICollection<Movie> Movies { get; set; }
    }
}