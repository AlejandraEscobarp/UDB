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
    public class NoticiasAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NoticiasAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NoticiasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Noticias>>> Getnoticias()
        {
            return await _context.noticias.ToListAsync();
        }

        // GET: api/NoticiasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Noticias>> GetNoticias(int id)
        {
            var noticias = await _context.noticias.FindAsync(id);

            if (noticias == null)
            {
                return NotFound();
            }

            return noticias;
        }

        // PUT: api/NoticiasAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticias(int id, Noticias noticias)
        {
            if (id != noticias.Id)
            {
                return BadRequest();
            }

            _context.Entry(noticias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiasExists(id))
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

        // POST: api/NoticiasAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Noticias>> PostNoticias(Noticias noticias)
        {
            _context.noticias.Add(noticias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoticias", new { id = noticias.Id }, noticias);
        }

        // DELETE: api/NoticiasAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Noticias>> DeleteNoticias(int id)
        {
            var noticias = await _context.noticias.FindAsync(id);
            if (noticias == null)
            {
                return NotFound();
            }

            _context.noticias.Remove(noticias);
            await _context.SaveChangesAsync();

            return noticias;
        }

        private bool NoticiasExists(int id)
        {
            return _context.noticias.Any(e => e.Id == id);
        }
    }
}
