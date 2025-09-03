using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        //    static private List<Game> games = new List<Game> {

        //    new Game { Id = 1, Name = "The Legend of Zelda: Breath of the Wild", Company = "Nintendo", ReleaseYear = 2017 },
        //new Game { Id = 2, Name = "God of War", Company = "Santa Monica Studio", ReleaseYear = 2018 },
        //new Game { Id = 3, Name = "Red Dead Redemption 2", Company = "Rockstar Games", ReleaseYear = 2018 },
        //new Game { Id = 4, Name = "Elden Ring", Company = "FromSoftware", ReleaseYear = 2022 },
        //new Game { Id = 5, Name = "Cyberpunk 2077", Company = "CD Projekt", ReleaseYear = 2020 }

        //    };
        private readonly FirstAPIContext _context;
        public GamesController(FirstAPIContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task< ActionResult<List<Game>>> GetGames()
        {
            return Ok(await _context.Games.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task< ActionResult<Game>> GetGameById(int id)
        {

            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            return Ok(game);

        }
        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game newGame)
        {
            if (newGame == null)
                return BadRequest();
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGameById), new { id = newGame.Id }, newGame);
        }
        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateGame(int id, Game updatedGame)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            game.Id = updatedGame.Id;
            game.Name = updatedGame.Name;
            game.ReleaseYear = updatedGame.ReleaseYear;
            game.Company = updatedGame.Company;


            await _context.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
