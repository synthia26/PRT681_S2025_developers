using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieTheatre.Models;

public enum MovieLanguage
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
    [DataType(DataType.Date)]
    public DateOnly ReleaseDate { get; set; }

    [Required]
    [StringLength(200)]
    public string Director { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string ContactEmail { get; set; } = string.Empty;

    [Required]
    public MovieLanguage Language { get; set; }

    [Required]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}


