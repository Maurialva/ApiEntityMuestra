using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberViajesApiEntity.Data;
using UberViajesApiEntity.Models;

namespace UberViajesApiEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseDeRegistroesController : ControllerBase
    {
        private readonly UberViajesApiEntityContext _context;

        public ClaseDeRegistroesController(UberViajesApiEntityContext context)
        {
            _context = context;
        }

        // GET: api/ClaseDeRegistroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaseDeRegistro>>> GetClasesRegistros()
        {
            return await _context.ClasesRegistros.ToListAsync();
        }

        // GET: api/ClaseDeRegistroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaseDeRegistro>> GetClaseDeRegistro(int id)
        {
            var claseDeRegistro = await _context.ClasesRegistros.FindAsync(id);

            if (claseDeRegistro == null)
            {
                return NotFound();
            }

            return claseDeRegistro;
        }

        // PUT: api/ClaseDeRegistroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaseDeRegistro(int id, ClaseDeRegistro claseDeRegistro)
        {
            if (id != claseDeRegistro.Clase_id)
            {
                return BadRequest();
            }

            _context.Entry(claseDeRegistro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseDeRegistroExists(id))
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

        // POST: api/ClaseDeRegistroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClaseDeRegistro>> PostClaseDeRegistro(ClaseDeRegistro claseDeRegistro)
        {
            _context.ClasesRegistros.Add(claseDeRegistro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaseDeRegistro", new { id = claseDeRegistro.Clase_id }, claseDeRegistro);
        }

        // DELETE: api/ClaseDeRegistroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaseDeRegistro(int id)
        {
            var claseDeRegistro = await _context.ClasesRegistros.FindAsync(id);
            if (claseDeRegistro == null)
            {
                return NotFound();
            }

            _context.ClasesRegistros.Remove(claseDeRegistro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaseDeRegistroExists(int id)
        {
            return _context.ClasesRegistros.Any(e => e.Clase_id == id);
        }
    }
}
