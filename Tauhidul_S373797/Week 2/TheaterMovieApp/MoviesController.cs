using Microsoft.AspNetCore.Mvc;

namespace TheaterMovieApp
{
    public class MoviesController : Controller
    {
        // GET: MoviesController
        public ActionResult Index()
        {
            return View();
        }

    }
}
