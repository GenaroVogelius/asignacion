using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asignacion.Data;
using asignacion.Models;

namespace asignacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class apiFacturasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public apiFacturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/apiFacturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facturas>>> GetFacturas()
        {
          if (_context.Facturas == null)
          {
              return NotFound();
          }
            return await _context.Facturas.ToListAsync();
        }

        // GET: api/apiFacturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facturas>> GetFacturas(Guid id)
        {
          if (_context.Facturas == null)
          {
              return NotFound();
          }
            var facturas = await _context.Facturas.FindAsync(id);

            if (facturas == null)
            {
                return NotFound();
            }

            return facturas;
        }

        // PUT: api/apiFacturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturas(Guid id, Facturas facturas)
        {
            if (id != facturas.Id)
            {
                return BadRequest();
            }

            _context.Entry(facturas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/apiFacturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facturas>> PostFacturas(Facturas facturas)
        {
          if (_context.Facturas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Facturas'  is null.");
          }
            _context.Facturas.Add(facturas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturas", new { id = facturas.Id }, facturas);
        }

        // DELETE: api/apiFacturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturas(Guid id)
        {
            if (_context.Facturas == null)
            {
                return NotFound();
            }
            var facturas = await _context.Facturas.FindAsync(id);
            if (facturas == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(facturas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturasExists(Guid id)
        {
            return (_context.Facturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
