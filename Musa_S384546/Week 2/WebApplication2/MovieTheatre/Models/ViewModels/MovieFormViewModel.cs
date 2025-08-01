using System.ComponentModel.DataAnnotations;

namespace MovieTheatre.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        [Display(Name = "Poster Image")]
        public IFormFile PosterFile { get; set; }
    }
}