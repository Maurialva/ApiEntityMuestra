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
    public class EntregasController : ControllerBase
    {
        private readonly UberViajesApiEntityContext _context;

        public EntregasController(UberViajesApiEntityContext context)
        {
            _context = context;
        }

        // GET: api/Entregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrega>>> Getentregas()
        {
            return await _context.entregas.ToListAsync();

        }

        // GET: api/Entregas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrega>> GetEntrega(int id)
        {
            var entrega = await _context.entregas.FindAsync(id);

            if (entrega == null)
            {
                return NotFound();
            }

            return entrega;
        }

        // PUT: api/Entregas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrega(int id, Entrega entrega)
        {
            if (id != entrega.Ent_id)
            {
                return BadRequest();
            }

            _context.Entry(entrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaExists(id))
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

        // POST: api/Entregas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entrega>> PostEntrega(Entrega entrega)
        {
            _context.entregas.Add(entrega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntrega", new { id = entrega.Ent_id }, entrega);
        }

        // DELETE: api/Entregas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrega(int id)
        {
            var entrega = await _context.entregas.FindAsync(id);
            if (entrega == null)
            {
                return NotFound();
            }

            _context.entregas.Remove(entrega);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntregaExists(int id)
        {
            return _context.entregas.Any(e => e.Ent_id == id);
        }
    }
}
