using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieTheatre.Data;
using movieTheatre.Models;

namespace movieTheatre.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ApplicationDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        var categories = await db.Categories
            .OrderBy(c => c.Name)
            .ToListAsync();
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await db.Categories.FindAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Create([FromBody] Category category)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        db.Categories.Add(category);
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException?.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase) == true)
            {
                ModelState.AddModelError(nameof(Category.Code), "Code must be unique.");
                return ValidationProblem(ModelState);
            }
            throw;
        }

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Category category)
    {
        if (id != category.Id)
        {
            ModelState.AddModelError(nameof(Category.Id), "URL id does not match body id.");
            return ValidationProblem(ModelState);
        }
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var existing = await db.Categories.FindAsync(id);
        if (existing == null) return NotFound();

        existing.Name = category.Name;
        existing.Code = category.Code;

        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException?.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase) == true)
            {
                ModelState.AddModelError(nameof(Category.Code), "Code must be unique.");
                return ValidationProblem(ModelState);
            }
            throw;
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await db.Categories.FindAsync(id);
        if (existing == null) return NotFound();

        // Prevent deleting a category if any movies reference it
        var isInUse = await db.Movies.AnyAsync(m => m.CategoryId == id);
        if (isInUse)
        {
            return Conflict(new ProblemDetails
            {
                Title = "Category in use",
                Detail = "Cannot delete a category assigned to one or more movies.",
                Status = StatusCodes.Status409Conflict
            });
        }

        db.Categories.Remove(existing);
        await db.SaveChangesAsync();
        return NoContent();
    }
}


