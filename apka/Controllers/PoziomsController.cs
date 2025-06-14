using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apka.Models;

namespace apka.Controllers
{
    public class PoziomsController : Controller
    {
        private readonly AppDbContext _context;

        public PoziomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pozioms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Poziomy.ToListAsync());
        }

        // GET: Pozioms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poziom = await _context.Poziomy
                .FirstOrDefaultAsync(m => m.IdPoziom == id);
            if (poziom == null)
            {
                return NotFound();
            }

            return View(poziom);
        }

        // GET: Pozioms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pozioms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPoziom,Nazwa")] Poziom poziom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poziom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poziom);
        }

        // GET: Pozioms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poziom = await _context.Poziomy.FindAsync(id);
            if (poziom == null)
            {
                return NotFound();
            }
            return View(poziom);
        }

        // POST: Pozioms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPoziom,Nazwa")] Poziom poziom)
        {
            if (id != poziom.IdPoziom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poziom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoziomExists(poziom.IdPoziom))
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
            return View(poziom);
        }

        // GET: Pozioms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poziom = await _context.Poziomy
                .FirstOrDefaultAsync(m => m.IdPoziom == id);
            if (poziom == null)
            {
                return NotFound();
            }

            return View(poziom);
        }

        // POST: Pozioms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poziom = await _context.Poziomy.FindAsync(id);
            if (poziom != null)
            {
                _context.Poziomy.Remove(poziom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoziomExists(int id)
        {
            return _context.Poziomy.Any(e => e.IdPoziom == id);
        }
    }
}
