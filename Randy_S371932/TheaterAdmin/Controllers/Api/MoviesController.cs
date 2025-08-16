using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheaterAdmin.Data;
using TheaterAdmin.Dtos;

namespace TheaterAdmin.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController(ApplicationDbContext db) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll() =>
          await db.Movies.Include(m => m.Category)
            .Select(m => new MovieDto
            {
                Id = m.Id,
                Name = m.Name,
                ReleaseDate = m.ReleaseDate,
                Director = m.Director,
                ContactEmailAddress = m.ContactEmailAddress,
                Language = m.Language,
                CategoryId = m.CategoryId,
                CategoryName = m.Category!.Name
            }).ToListAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDto>> GetOne(int id)
        {
            var m = await db.Movies.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (m is null) return NotFound();
            return new MovieDto
            {
                Id = m.Id,
                Name = m.Name,
                ReleaseDate = m.ReleaseDate,
                Director = m.Director,
                ContactEmailAddress = m.ContactEmailAddress,
                Language = m.Language,
                CategoryId = m.CategoryId,
                CategoryName = m.Category?.Name
            };
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> Create(MovieDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var exists = await db.Categories.AnyAsync(c => c.Id == dto.CategoryId);
            if (!exists) return BadRequest("CategoryId not found.");
            var e = new Models.Movie
            {
                Name = dto.Name,
                ReleaseDate = dto.ReleaseDate,
                Director = dto.Director,
                ContactEmailAddress = dto.ContactEmailAddress,
                Language = dto.Language,
                CategoryId = dto.CategoryId
            };
            db.Add(e); await db.SaveChangesAsync();
            dto.Id = e.Id;
            return CreatedAtAction(nameof(GetOne), new { id = e.Id }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, MovieDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var e = await db.Movies.FindAsync(id);
            if (e is null) return NotFound();
            e.Name = dto.Name; e.ReleaseDate = dto.ReleaseDate; e.Director = dto.Director;
            e.ContactEmailAddress = dto.ContactEmailAddress; e.Language = dto.Language;
            e.CategoryId = dto.CategoryId;
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await db.Movies.FindAsync(id);
            if (e is null) return NotFound();
            db.Movies.Remove(e); await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
