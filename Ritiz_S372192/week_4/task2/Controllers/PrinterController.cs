using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.DAL;

namespace BookStoreApp.Controllers
{
	public class PrinterController : Controller
	{
		private readonly EfDbContext _db;

		public PrinterController(EfDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			var printers = await _db.Printers.ToListAsync();
			return View(printers);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null) return NotFound();
			var printer = await _db.Printers.FirstOrDefaultAsync(b => b.ID == id);
			if (printer == null) return NotFound();
			return View(printer);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,Name,Model,Brand")] Printer printer)
		{
			if (!ModelState.IsValid) return View(printer);
			_db.Printers.Add(printer);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();
			var printer = await _db.Printers.FindAsync(id);
			if (printer == null) return NotFound();
			return View(printer);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Model,Brand")] Printer printer)
		{
			if (id != printer.ID) return NotFound();
			if (!ModelState.IsValid) return View(printer);
			try
			{
				_db.Update(printer);
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await _db.Printers.AnyAsync(e => e.ID == id)) return NotFound();
				throw;
			}
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) return NotFound();
			var printer = await _db.Printers.FirstOrDefaultAsync(m => m.ID == id);
			if (printer == null) return NotFound();
			return View(printer);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var printer = await _db.Printers.FindAsync(id);
			if (printer != null)
			{
				_db.Printers.Remove(printer);
				await _db.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
