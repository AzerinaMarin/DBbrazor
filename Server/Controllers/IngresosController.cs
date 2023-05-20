using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bdapis.Server.Data;
using Bdapis.Shared.Modelo;

namespace Bdapis.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly BDPatrocinadorContext _context;

        public IngresosController(BDPatrocinadorContext context)
        {
            _context = context;
        }

        // GET: api/Ingresos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingresos>>> GetIngresos()
        {
          if (_context.Ingresos == null)
          {
              return NotFound();
          }
            return await _context.Ingresos.ToListAsync();
        }

        // GET: api/Ingresos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingresos>> GetIngresos(int id)
        {
          if (_context.Ingresos == null)
          {
              return NotFound();
          }
            var ingresos = await _context.Ingresos.FindAsync(id);

            if (ingresos == null)
            {
                return NotFound();
            }

            return ingresos;
        }

        // PUT: api/Ingresos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngresos(int id, Ingresos ingresos)
        {
            if (id != ingresos.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingresos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresosExists(id))
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

        // POST: api/Ingresos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingresos>> PostIngresos(Ingresos ingresos)
        {
          if (_context.Ingresos == null)
          {
              return Problem("Entity set 'BDPatrocinadorContext.Ingresos'  is null.");
          }
            _context.Ingresos.Add(ingresos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngresos", new { id = ingresos.Id }, ingresos);
        }

        // DELETE: api/Ingresos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngresos(int id)
        {
            if (_context.Ingresos == null)
            {
                return NotFound();
            }
            var ingresos = await _context.Ingresos.FindAsync(id);
            if (ingresos == null)
            {
                return NotFound();
            }

            _context.Ingresos.Remove(ingresos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngresosExists(int id)
        {
            return (_context.Ingresos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
