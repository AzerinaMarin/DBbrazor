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
    public class AnunciosController : ControllerBase
    {
        private readonly BDPatrocinadorContext _context;

        public AnunciosController(BDPatrocinadorContext context)
        {
            _context = context;
        }

        // GET: api/Anuncios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anuncios>>> GetAnuncios()
        {
          if (_context.Anuncios == null)
          {
              return NotFound();
          }
            return await _context.Anuncios.ToListAsync();
        }

        // GET: api/Anuncios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncios>> GetAnuncios(int id)
        {
          if (_context.Anuncios == null)
          {
              return NotFound();
          }
            var anuncios = await _context.Anuncios.FindAsync(id);

            if (anuncios == null)
            {
                return NotFound();
            }

            return anuncios;
        }

        // PUT: api/Anuncios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnuncios(int id, Anuncios anuncios)
        {
            if (id != anuncios.Id)
            {
                return BadRequest();
            }

            _context.Entry(anuncios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnunciosExists(id))
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

        // POST: api/Anuncios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anuncios>> PostAnuncios(Anuncios anuncios)
        {
          if (_context.Anuncios == null)
          {
              return Problem("Entity set 'BDPatrocinadorContext.Anuncios'  is null.");
          }
            _context.Anuncios.Add(anuncios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnuncios", new { id = anuncios.Id }, anuncios);
        }

        // DELETE: api/Anuncios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnuncios(int id)
        {
            if (_context.Anuncios == null)
            {
                return NotFound();
            }
            var anuncios = await _context.Anuncios.FindAsync(id);
            if (anuncios == null)
            {
                return NotFound();
            }

            _context.Anuncios.Remove(anuncios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnunciosExists(int id)
        {
            return (_context.Anuncios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
