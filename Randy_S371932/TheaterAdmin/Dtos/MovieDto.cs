using System.ComponentModel.DataAnnotations;
using TheaterAdmin.Models;
namespace TheaterAdmin.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required, StringLength(128)] public string Name { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        [Required, StringLength(64)] public string Director { get; set; } = string.Empty;
        [EmailAddress, StringLength(128)] public string? ContactEmailAddress { get; set; }
        [Required] public Language Language { get; set; } = Language.English;
        [Required] public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
