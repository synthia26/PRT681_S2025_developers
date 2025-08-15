using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieTheatre.Data;
using movieTheatre.Models;

namespace movieTheatre.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(ApplicationDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
    {
        var movies = await db.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Name)
            .ToListAsync();
        return Ok(movies);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Movie>> GetById(int id)
    {
        var movie = await db.Movies.Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> Create([FromBody] Movie movie)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var categoryExists = await db.Categories.AnyAsync(c => c.Id == movie.CategoryId);
        if (!categoryExists)
        {
            ModelState.AddModelError(nameof(Movie.CategoryId), "CategoryId does not reference an existing category.");
            return ValidationProblem(ModelState);
        }

        db.Movies.Add(movie);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Movie movie)
    {
        if (id != movie.Id)
        {
            ModelState.AddModelError(nameof(Movie.Id), "URL id does not match body id.");
            return ValidationProblem(ModelState);
        }
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var existing = await db.Movies.FindAsync(id);
        if (existing == null) return NotFound();

        var categoryExists = await db.Categories.AnyAsync(c => c.Id == movie.CategoryId);
        if (!categoryExists)
        {
            ModelState.AddModelError(nameof(Movie.CategoryId), "CategoryId does not reference an existing category.");
            return ValidationProblem(ModelState);
        }

        existing.Name = movie.Name;
        existing.ReleaseDate = movie.ReleaseDate;
        existing.Director = movie.Director;
        existing.ContactEmail = movie.ContactEmail;
        existing.Language = movie.Language;
        existing.CategoryId = movie.CategoryId;

        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await db.Movies.FindAsync(id);
        if (existing == null) return NotFound();

        db.Movies.Remove(existing);
        await db.SaveChangesAsync();
        return NoContent();
    }
}


