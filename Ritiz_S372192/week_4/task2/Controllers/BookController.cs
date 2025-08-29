using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.DAL;

namespace BookStoreApp.Controllers
{
	public class BookController : Controller
	{
		private readonly EfDbContext _db;

		public BookController(EfDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			var books = await _db.Books.ToListAsync();
			return View(books);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null) return NotFound();
			var book = await _db.Books.FirstOrDefaultAsync(b => b.ID == id);
			if (book == null) return NotFound();
			return View(book);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,Name")] Book book)
		{
			if (!ModelState.IsValid) return View(book);
			_db.Books.Add(book);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();
			var book = await _db.Books.FindAsync(id);
			if (book == null) return NotFound();
			return View(book);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Book book)
		{
			if (id != book.ID) return NotFound();
			if (!ModelState.IsValid) return View(book);
			try
			{
				_db.Update(book);
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _db.Books.AnyAsync(e => e.ID == id)) return NotFound();
				throw;
			}
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) return NotFound();
			var book = await _db.Books.FirstOrDefaultAsync(m => m.ID == id);
			if (book == null) return NotFound();
			return View(book);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var book = await _db.Books.FindAsync(id);
			if (book != null)
			{
				_db.Books.Remove(book);
				await _db.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
