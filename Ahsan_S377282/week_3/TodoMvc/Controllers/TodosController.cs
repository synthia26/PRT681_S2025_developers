using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoMvc.Data;
using TodoMvc.Models;

namespace TodoMvc.Controllers;

public class TodosController : Controller
{
    private readonly AppDbContext _db;
    public TodosController(AppDbContext db) => _db = db;

    // GET: /Todos
    public async Task<IActionResult> Index()
    {
        var items = await _db.Todos
            .OrderByDescending(t => t.Id)
            .ToListAsync();
        return View(items);
    }

    // GET: /Todos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        var todo = await _db.Todos.FindAsync(id);
        return todo is null ? NotFound() : View(todo);
    }

    // GET: /Todos/Create
    public IActionResult Create() => View();

    // POST: /Todos/Create
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Text,Done")] Todo todo)
    {
        if (!ModelState.IsValid) return View(todo);
        _db.Add(todo);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: /Todos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        var todo = await _db.Todos.FindAsync(id);
        return todo is null ? NotFound() : View(todo);
    }

    // POST: /Todos/Edit/5
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Text,Done,CreatedUtc")] Todo todo)
    {
        if (id != todo.Id) return NotFound();
        if (!ModelState.IsValid) return View(todo);

        try
        {
            _db.Update(todo);
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_db.Todos.Any(e => e.Id == id)) return NotFound();
            throw;
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: /Todos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var todo = await _db.Todos.FindAsync(id);
        return todo is null ? NotFound() : View(todo);
    }

    // POST: /Todos/Delete/5
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo is not null)
        {
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
