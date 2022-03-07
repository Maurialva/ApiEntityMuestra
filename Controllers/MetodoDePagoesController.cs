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
    public class MetodoDePagoesController : ControllerBase
    {
        private readonly UberViajesApiEntityContext _context;

        public MetodoDePagoesController(UberViajesApiEntityContext context)
        {
            _context = context;
        }

        // GET: api/MetodoDePagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoDePago>>> GetMetodosDePago()
        {
            return await _context.MetodosDePago.ToListAsync();
        }

        // GET: api/MetodoDePagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetodoDePago>> GetMetodoDePago(int id)
        {
            var metodoDePago = await _context.MetodosDePago.FindAsync(id);

            if (metodoDePago == null)
            {
                return NotFound();
            }

            return metodoDePago;
        }

        // PUT: api/MetodoDePagoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoDePago(int id, MetodoDePago metodoDePago)
        {
            if (id != metodoDePago.M_id)
            {
                return BadRequest();
            }

            _context.Entry(metodoDePago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetodoDePagoExists(id))
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

        // POST: api/MetodoDePagoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetodoDePago>> PostMetodoDePago(MetodoDePago metodoDePago)
        {
            _context.MetodosDePago.Add(metodoDePago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetodoDePago", new { id = metodoDePago.M_id }, metodoDePago);
        }

        // DELETE: api/MetodoDePagoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoDePago(int id)
        {
            var metodoDePago = await _context.MetodosDePago.FindAsync(id);
            if (metodoDePago == null)
            {
                return NotFound();
            }

            _context.MetodosDePago.Remove(metodoDePago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetodoDePagoExists(int id)
        {
            return _context.MetodosDePago.Any(e => e.M_id == id);
        }
    }
}
