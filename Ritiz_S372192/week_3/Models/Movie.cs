using System.ComponentModel.DataAnnotations;

namespace TheaterAdminAPI.Models
{
    public enum Language
    {
        English = 0,
        Japanese = 1,
        Chinese = 2
    }

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(150)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string ContactEmailAddress { get; set; } = string.Empty;

        [Required]
        public Language Language { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
