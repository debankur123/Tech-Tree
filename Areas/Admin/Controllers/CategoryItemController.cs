using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechTree_MVC.Data;
using TechTree_MVC.Entities.Master;

namespace TechTree_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Int32 categoryId)
        {
            List<TT_M_CategoryItem> response = await (
                    from catItem in _context.CategoryItem
                    where catItem.CategoryId == categoryId
                    select new TT_M_CategoryItem
                    {
                        Id = catItem.CategoryId,
                        Title = catItem.Title,
                        Description = catItem.Description,
                        DateTimeItemReleased = catItem.DateTimeItemReleased,
                        MediaTypeId = catItem.MediaTypeId,
                        CategoryId = categoryId
                    }
                ).ToListAsync();

            return View(response);
        }

        // GET: Admin/CategoryItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tT_M_CategoryItem = await _context.CategoryItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tT_M_CategoryItem == null)
            {
                return NotFound();
            }

            return View(tT_M_CategoryItem);
        }

        // GET: Admin/CategoryItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CategoryId,MediaTypeId,DateTimeItemReleased")] TT_M_CategoryItem tT_M_CategoryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tT_M_CategoryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tT_M_CategoryItem);
        }

        // GET: Admin/CategoryItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tT_M_CategoryItem = await _context.CategoryItem.FindAsync(id);
            if (tT_M_CategoryItem == null)
            {
                return NotFound();
            }
            return View(tT_M_CategoryItem);
        }

        // POST: Admin/CategoryItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CategoryId,MediaTypeId,DateTimeItemReleased")] TT_M_CategoryItem tT_M_CategoryItem)
        {
            if (id != tT_M_CategoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tT_M_CategoryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TT_M_CategoryItemExists(tT_M_CategoryItem.Id))
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
            return View(tT_M_CategoryItem);
        }

        // GET: Admin/CategoryItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tT_M_CategoryItem = await _context.CategoryItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tT_M_CategoryItem == null)
            {
                return NotFound();
            }

            return View(tT_M_CategoryItem);
        }

        // POST: Admin/CategoryItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tT_M_CategoryItem = await _context.CategoryItem.FindAsync(id);
            if (tT_M_CategoryItem != null)
            {
                _context.CategoryItem.Remove(tT_M_CategoryItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TT_M_CategoryItemExists(int id)
        {
            return _context.CategoryItem.Any(e => e.Id == id);
        }
    }
}
