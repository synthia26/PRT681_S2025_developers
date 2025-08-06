using System.ComponentModel.DataAnnotations;

namespace TheaterAdmin.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, StringLength(128)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        [Required, StringLength(64)]
        public string Director { get; set; } = string.Empty;
        [Display(Name = "Contact Email address"), EmailAddress, StringLength(128)]
        public string? ContactEmailAddress { get; set; }
        [Required]
        public Language Language { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}