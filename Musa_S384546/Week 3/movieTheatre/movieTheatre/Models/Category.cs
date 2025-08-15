using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace movieTheatre.Models;

[Index(nameof(Code), IsUnique = true)]
public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string Code { get; set; } = string.Empty;
}


