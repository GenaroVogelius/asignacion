using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asignacion.Data;
using asignacion.Models;
using Microsoft.AspNetCore.Authorization;

namespace asignacion.Controllers
{
    [Authorize]
    public class CiudadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CiudadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ciudades
        public async Task<IActionResult> Index()
        {
              return _context.Ciudades != null ? 
                          View(await _context.Ciudades.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Ciudades'  is null.");
        }

        // GET: Ciudades/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Ciudades == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return View(ciudades);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ciudad")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                ciudades.Id = Guid.NewGuid();
                _context.Add(ciudades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Ciudades == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return NotFound();
            }
            return View(ciudades);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Ciudad")] Ciudades ciudades)
        {
            if (id != ciudades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadesExists(ciudades.Id))
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
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Ciudades == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return View(ciudades);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Ciudades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ciudades'  is null.");
            }
            var ciudades = await _context.Ciudades.FindAsync(id);
            if (ciudades != null)
            {
                _context.Ciudades.Remove(ciudades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadesExists(Guid id)
        {
          return (_context.Ciudades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
