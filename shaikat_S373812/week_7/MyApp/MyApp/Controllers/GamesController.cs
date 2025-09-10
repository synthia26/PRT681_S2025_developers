using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Overview()
        {
            var game = new Game() { Title="Hades", Genre="Roguelike Action", ReleaseYear=2020};
            return View(game);
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id); 
        }
    }
}
