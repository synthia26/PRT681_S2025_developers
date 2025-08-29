using System.ComponentModel.DataAnnotations;

namespace TheaterMovieApp.Models
{
    public enum Language
    {
        English = 1,
        Japanese = 2,
        Chinese = 3
    }

    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie name is required")]
        [StringLength(200)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Director name is required")]
        [StringLength(150)]
        public string Director { get; set; }

        [Required(ErrorMessage = "Contact email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Please select a language")]
        public Language Language { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        // This links the movie to its category
        public Category Category { get; set; }
    }
}