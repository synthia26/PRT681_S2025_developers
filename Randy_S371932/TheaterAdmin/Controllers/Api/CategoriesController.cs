using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheaterAdmin.Data;
using TheaterAdmin.Dtos;
using TheaterAdmin.Models;

namespace TheaterAdmin.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(ApplicationDbContext db) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll() =>
          await db.Categories
            .Select(c => new CategoryDto { Id = c.Id, Name = c.Name, Code = c.Code })
            .ToListAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetOne(int id)
        {
            var c = await db.Categories.FindAsync(id);
            return c is null ? NotFound() : new CategoryDto { Id = c.Id, Name = c.Name, Code = c.Code };
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CategoryDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var entity = new Category { Name = dto.Name, Code = dto.Code };
            db.Add(entity);
            await db.SaveChangesAsync();
            dto.Id = entity.Id;
            return CreatedAtAction(nameof(GetOne), new { id = dto.Id }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CategoryDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var entity = await db.Categories.FindAsync(id);
            if (entity is null) return NotFound();
            entity.Name = dto.Name; entity.Code = dto.Code;
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await db.Categories.Include(c => c.Movies).FirstOrDefaultAsync(c => c.Id == id);
            if (entity is null) return NotFound();
            if (entity.Movies?.Any() == true) return Conflict("Cannot delete: category has movies.");
            db.Categories.Remove(entity);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
