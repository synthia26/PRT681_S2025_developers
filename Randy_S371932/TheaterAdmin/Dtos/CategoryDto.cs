using System.ComponentModel.DataAnnotations;

namespace TheaterAdmin.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required, StringLength(64)] public string Name { get; set; } = string.Empty;
        [Required, StringLength(16)] public string Code { get; set; } = string.Empty;
    }
}