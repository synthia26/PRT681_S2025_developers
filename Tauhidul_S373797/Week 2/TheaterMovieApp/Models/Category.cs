using System.ComponentModel.DataAnnotations;

namespace TheaterMovieApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category code is required")]
        [StringLength(10)]
        [Display(Name = "Category Code")]
        public string Code { get; set; }

        // This helps link movies to categories
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}