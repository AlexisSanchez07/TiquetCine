using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiquetCine.Data;
using TiquetCine.Models;

namespace TiquetCine.Controllers
{
    public class CinesController : Controller
    {
        private readonly AppDbContext _context;

        public CinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cines.ToListAsync());
        }

        // GET: Cines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cine = await _context.Cines
                .FirstOrDefaultAsync(m => m.CineId == id);
            if (cine == null)
            {
                return NotFound();
            }

            return View(cine);
        }

        // GET: Cines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CineId,Foto,Nombre,Biografia")] Cine cine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cine);
        }

        // GET: Cines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cine = await _context.Cines.FindAsync(id);
            if (cine == null)
            {
                return NotFound();
            }
            return View(cine);
        }

        // POST: Cines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CineId,Foto,Nombre,Biografia")] Cine cine)
        {
            if (id != cine.CineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CineExists(cine.CineId))
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
            return View(cine);
        }

        // GET: Cines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cine = await _context.Cines
                .FirstOrDefaultAsync(m => m.CineId == id);
            if (cine == null)
            {
                return NotFound();
            }

            return View(cine);
        }

        // POST: Cines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cine = await _context.Cines.FindAsync(id);
            _context.Cines.Remove(cine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CineExists(int id)
        {
            return _context.Cines.Any(e => e.CineId == id);
        }
    }
}
