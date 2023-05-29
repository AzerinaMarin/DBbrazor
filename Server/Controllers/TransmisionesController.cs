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
    [Route("api/transmisiones")]
    [ApiController]
    public class TransmisionesController : ControllerBase
    {
        private readonly BDPatrocinadorContext _context;

        public TransmisionesController(BDPatrocinadorContext context)
        {
            _context = context;
        }

        // GET: api/Transmisiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transmisiones>>> GetTransmisiones()
        {
          if (_context.Transmisiones == null)
          {
              return NotFound();
          }
            return await _context.Transmisiones.ToListAsync();
        }

        // GET: api/Transmisiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transmisiones>> GetTransmisiones(int id)
        {
          if (_context.Transmisiones == null)
          {
              return NotFound();
          }
            var transmisiones = await _context.Transmisiones.FindAsync(id);

            if (transmisiones == null)
            {
                return NotFound();
            }

            return transmisiones;
        }

        // PUT: api/Transmisiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransmisiones(int id, Transmisiones transmisiones)
        {
            if (id != transmisiones.Id)
            {
                return BadRequest();
            }

            _context.Entry(transmisiones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransmisionesExists(id))
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

        // POST: api/Transmisiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transmisiones>> PostTransmisiones(Transmisiones transmisiones)
        {
          if (_context.Transmisiones == null)
          {
              return Problem("Entity set 'BDPatrocinadorContext.Transmisiones'  is null.");
          }
            _context.Transmisiones.Add(transmisiones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransmisiones", new { id = transmisiones.Id }, transmisiones);
        }

        // DELETE: api/Transmisiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransmisiones(int id)
        {
            if (_context.Transmisiones == null)
            {
                return NotFound();
            }
            var transmisiones = await _context.Transmisiones.FindAsync(id);
            if (transmisiones == null)
            {
                return NotFound();
            }

            _context.Transmisiones.Remove(transmisiones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransmisionesExists(int id)
        {
            return (_context.Transmisiones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
