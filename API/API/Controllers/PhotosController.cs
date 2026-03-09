using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Photos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Photos.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photography = await _context.Photos
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photography == null)
            {
                return NotFound();
            }

            return View(photography);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            ViewData["CategoryFK"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,File,Date,Price,CategoryFK")] Photography photography)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photography);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryFK"] = new SelectList(_context.Categories, "Id", "Name", photography.CategoryFK);
            return View(photography);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photography = await _context.Photos.FindAsync(id);
            if (photography == null)
            {
                return NotFound();
            }
            ViewData["CategoryFK"] = new SelectList(_context.Categories, "Id", "Name", photography.CategoryFK);
            return View(photography);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,File,Date,Price,CategoryFK")] Photography photography)
        {
            if (id != photography.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photography);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotographyExists(photography.Id))
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
            ViewData["CategoryFK"] = new SelectList(_context.Categories, "Id", "Name", photography.CategoryFK);
            return View(photography);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photography = await _context.Photos
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photography == null)
            {
                return NotFound();
            }

            return View(photography);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photography = await _context.Photos.FindAsync(id);
            if (photography != null)
            {
                _context.Photos.Remove(photography);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotographyExists(int id)
        {
            return _context.Photos.Any(e => e.Id == id);
        }
    }
}
