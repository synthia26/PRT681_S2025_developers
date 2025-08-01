using System.ComponentModel.DataAnnotations;

namespace MovieTheatre.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
    }
}