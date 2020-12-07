using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InstelCore.Data;
using InstelCore.Models;

namespace InstelCore.Areas.Services.Controllers
{
    [Area("Service")]
    public class CategoryVMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryVMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Services/CategoryVMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Services/CategoryVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryVM = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryVM == null)
            {
                return NotFound();
            }

            return View(categoryVM);
        }

        // GET: Services/CategoryVMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/CategoryVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryVM);
        }

        // GET: Services/CategoryVMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryVM = await _context.Categories.FindAsync(id);
            if (categoryVM == null)
            {
                return NotFound();
            }
            return View(categoryVM);
        }

        // POST: Services/CategoryVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName")] CategoryVM categoryVM)
        {
            if (id != categoryVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryVMExists(categoryVM.Id))
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
            return View(categoryVM);
        }

        // GET: Services/CategoryVMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryVM = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryVM == null)
            {
                return NotFound();
            }

            return View(categoryVM);
        }

        // POST: Services/CategoryVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryVM = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categoryVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryVMExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
