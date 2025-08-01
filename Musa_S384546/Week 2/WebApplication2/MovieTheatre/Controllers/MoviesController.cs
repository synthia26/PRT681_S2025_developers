using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTheatre.Data;
using MovieTheatre.Models;
using MovieTheatre.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;

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
        string? imagePath = null;
        if (viewModel.PosterFile != null)
        {
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var fileName = Guid.NewGuid() + Path.GetExtension(viewModel.PosterFile.FileName ?? string.Empty);
            var filePath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await viewModel.PosterFile.CopyToAsync(stream);
            }

            imagePath = "/uploads/" + fileName;
        }

        viewModel.Movie.PosterPath = imagePath ?? string.Empty;

        _context.Add(viewModel.Movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    
    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        
        var viewModel = new MovieFormViewModel
        {
            Movie = movie,
            Categories = _context.Categories.ToList()
        };
        
        return View(viewModel);
    }

    // POST: Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MovieFormViewModel viewModel)
    {
        if (id != viewModel.Movie.Id) return NotFound();
        
        if (!ModelState.IsValid)
        {
            viewModel.Categories = _context.Categories.ToList();
            return View(viewModel);
        }

        try
        {
            // Handle Image Upload if new file is provided
            if (viewModel.PosterFile != null)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var fileName = Guid.NewGuid() + Path.GetExtension(viewModel.PosterFile.FileName ?? string.Empty);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.PosterFile.CopyToAsync(stream);
                }

                viewModel.Movie.PosterPath = "/uploads/" + fileName;
            }

            _context.Update(viewModel.Movie);
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