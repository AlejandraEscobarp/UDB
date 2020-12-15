using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UDB.Data;
using UDB.Models;

namespace UDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarrerasAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CarrerasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carreras>>> Getcarreras()
        {
            return await _context.carreras.ToListAsync();
        }

        // GET: api/CarrerasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carreras>> GetCarreras(int id)
        {
            var carreras = await _context.carreras.FindAsync(id);

            if (carreras == null)
            {
                return NotFound();
            }

            return carreras;
        }

        // PUT: api/CarrerasAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarreras(int id, Carreras carreras)
        {
            if (id != carreras.Id)
            {
                return BadRequest();
            }

            _context.Entry(carreras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrerasExists(id))
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

        // POST: api/CarrerasAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Carreras>> PostCarreras(Carreras carreras)
        {
            _context.carreras.Add(carreras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarreras", new { id = carreras.Id }, carreras);
        }

        // DELETE: api/CarrerasAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carreras>> DeleteCarreras(int id)
        {
            var carreras = await _context.carreras.FindAsync(id);
            if (carreras == null)
            {
                return NotFound();
            }

            _context.carreras.Remove(carreras);
            await _context.SaveChangesAsync();

            return carreras;
        }

        private bool CarrerasExists(int id)
        {
            return _context.carreras.Any(e => e.Id == id);
        }
    }
}
