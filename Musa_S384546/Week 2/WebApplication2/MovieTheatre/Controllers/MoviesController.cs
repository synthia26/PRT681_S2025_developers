using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTheatre.Data;
using MovieTheatre.Models;
using MovieTheatre.Models.ViewModels;

namespace MovieTheatre.Controllers;

public class MoviesController : Controller
{
    private readonly ApplicationDbContext _context;
    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET: Movies
    public async Task<IActionResult> Index()
    {
        var movies = await _context.Movies.Include(m => m.Category).ToListAsync();
        return View(movies);
    }
    
    // GET: Movies/Create
    public IActionResult Create()
    {
        var viewModel = new MovieFormViewModel
        {
            Categories = _context.Categories.ToList(),
            Movie = new Movie()
        };
        return View(viewModel);
    }

    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MovieFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categories = _context.Categories.ToList();
            return View(viewModel);
        }

        // Handle Image Upload
        string imagePath = null;
        if (viewModel.PosterFile != null)
        {
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var fileName = Guid.NewGuid() + Path.GetExtension(viewModel.PosterFile.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await viewModel.PosterFile.CopyToAsync(stream);
            }

            imagePath = "/uploads/" + fileName;
        }

        viewModel.Movie.PosterPath = imagePath;

        _context.Add(viewModel.Movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    
    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int id, Movie movie)
    {
        if (id != movie.Id) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Movies.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
            
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(movie);
    }
    
    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}