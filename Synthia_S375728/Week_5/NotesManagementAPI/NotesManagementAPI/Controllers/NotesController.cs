using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesManagementAPI.Data;
using NotesManagementAPI.DTOs;
using NotesManagementAPI.Models;
using System;

namespace NotesManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController(ApplicationDbContext db) : ControllerBase
    {
        // GET: api/notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetAll()
        {
            var notes = await db.Notes
                .OrderByDescending(n => n.UpdatedAt)
                .ToListAsync();

            return Ok(notes);
        }

        // GET: api/notes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Note>> GetOne(int id)
        {
            var note = await db.Notes.FindAsync(id);
            return note is null ? NotFound() : Ok(note);
        }

        // POST: api/notes
        [HttpPost]
        public async Task<ActionResult<Note>> Create([FromBody] CreateNoteDto dto)
        {
            var now = DateTimeOffset.UtcNow;
            var note = new Note
            {
                Title = dto.Title?.Trim() ?? "",
                Content = dto.Content?.Trim() ?? "",
                CreatedAt = now,
                UpdatedAt = now
            };

            db.Notes.Add(note);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOne), new { id = note.Id }, note);
        }

        // PUT: api/notes/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Note>> Update(int id, [FromBody] UpdateNoteDto dto)
        {
            var note = await db.Notes.FindAsync(id);
            if (note is null) return NotFound();

            if (dto.Title is not null) note.Title = dto.Title.Trim();
            if (dto.Content is not null) note.Content = dto.Content.Trim();
            note.UpdatedAt = DateTimeOffset.UtcNow;

            await db.SaveChangesAsync();
            return Ok(note);
        }

        // DELETE: api/notes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await db.Notes.FindAsync(id);
            if (note is null) return NotFound();

            db.Notes.Remove(note);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
