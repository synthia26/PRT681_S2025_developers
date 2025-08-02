using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public string Director { get; set; }

    [EmailAddress]
    [Display(Name = "Contact Email")]
    public string ContactEmail { get; set; }

    [Required]
    public Language Language { get; set; }

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    
    // public Category Category { get; set; }

    // New field for image path
    public string PosterPath { get; set; }
}