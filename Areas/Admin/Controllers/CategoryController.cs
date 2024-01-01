using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTree_MVC.Data;
using TechTree_MVC.Entities.Master;

namespace TechTree_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tT_M_Category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tT_M_Category == null)
            {
                return NotFound();
            }

            return View(tT_M_Category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ThumbnailImagePath")] TT_M_Category tT_M_Category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tT_M_Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tT_M_Category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tT_M_Category = await _context.Category.FindAsync(id);
            if (tT_M_Category == null)
            {
                return NotFound();
            }
            return View(tT_M_Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ThumbnailImagePath")] TT_M_Category tT_M_Category)
        {
            if (id != tT_M_Category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tT_M_Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TT_M_CategoryExists(tT_M_Category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tT_M_Category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tT_M_Category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tT_M_Category == null)
            {
                return NotFound();
            }

            return View(tT_M_Category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tT_M_Category = await _context.Category.FindAsync(id);
            if (tT_M_Category != null)
            {
                _context.Category.Remove(tT_M_Category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TT_M_CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
