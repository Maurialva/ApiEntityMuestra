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
    public class EmpleadoesController : ControllerBase
    {
        private readonly UberViajesApiEntityContext _context;

        public EmpleadoesController(UberViajesApiEntityContext context)
        {
            _context = context;
        }

        // GET: api/Empleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            return await _context.Empleados
                 .Include(i => i.DatosPersonales)
                 .Include(i => i.Registro)
                 .ToListAsync();
        }

        // GET: api/Empleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.Where(e => e.E_id == id)
                 .Include(i => i.DatosPersonales)
                 .Include(i => i.Registro)
                 .ToListAsync();

            if (empleado.Count < 1 )
            {
                return NotFound();
            }

            return empleado[0];
        }

        // PUT: api/Empleadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.E_id)
            {
                return BadRequest();
            }

            //no funciona bien con state modified
            _context.Empleados.Update(empleado);
            try
            {
                await _context.SaveChangesAsync();
                var empleadoEditado = await _context.Empleados.FindAsync(id);
                return Ok(empleadoEditado);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.E_id }, empleado);
        }

        // DELETE: api/Empleadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.E_id == id);
        }
    }
}
