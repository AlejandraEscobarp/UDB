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
    public class ContactanosAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactanosAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactanosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contactanos>>> Getcontactanos()
        {
            return await _context.contactanos.ToListAsync();
        }

        // GET: api/ContactanosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contactanos>> GetContactanos(int id)
        {
            var contactanos = await _context.contactanos.FindAsync(id);

            if (contactanos == null)
            {
                return NotFound();
            }

            return contactanos;
        }

        // PUT: api/ContactanosAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactanos(int id, Contactanos contactanos)
        {
            if (id != contactanos.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactanos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactanosExists(id))
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

        // POST: api/ContactanosAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contactanos>> PostContactanos(Contactanos contactanos)
        {
            _context.contactanos.Add(contactanos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactanos", new { id = contactanos.Id }, contactanos);
        }

        // DELETE: api/ContactanosAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contactanos>> DeleteContactanos(int id)
        {
            var contactanos = await _context.contactanos.FindAsync(id);
            if (contactanos == null)
            {
                return NotFound();
            }

            _context.contactanos.Remove(contactanos);
            await _context.SaveChangesAsync();

            return contactanos;
        }

        private bool ContactanosExists(int id)
        {
            return _context.contactanos.Any(e => e.Id == id);
        }
    }
}
