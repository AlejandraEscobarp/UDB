using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UDB.Data;
using UDB.Models;

namespace UDB.Controllers
{
    public class ContactanosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactanosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Contactanos
        public async Task<IActionResult> Index()
        {
            return View(await _context.contactanos.ToListAsync());
        }

        // GET: Contactanos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactanos = await _context.contactanos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactanos == null)
            {
                return NotFound();
            }

            return View(contactanos);
        }

        // GET: Contactanos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactanos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Correo,Consulta,Mensaje")] Contactanos contactanos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactanos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(contactanos);
        }

        // GET: Contactanos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactanos = await _context.contactanos.FindAsync(id);
            if (contactanos == null)
            {
                return NotFound();
            }
            return View(contactanos);
        }

        // POST: Contactanos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Correo,Consulta,Mensaje")] Contactanos contactanos)
        {
            if (id != contactanos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactanos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactanosExists(contactanos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactanos);
        }

        // GET: Contactanos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactanos = await _context.contactanos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactanos == null)
            {
                return NotFound();
            }

            return View(contactanos);
        }

        // POST: Contactanos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactanos = await _context.contactanos.FindAsync(id);
            _context.contactanos.Remove(contactanos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactanosExists(int id)
        {
            return _context.contactanos.Any(e => e.Id == id);
        }
    }
}
