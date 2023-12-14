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
    public class ProductorsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Productors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productors.ToListAsync());
        }

        // GET: Productors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productor = await _context.Productors
                .FirstOrDefaultAsync(m => m.ProductorId == id);
            if (productor == null)
            {
                return NotFound();
            }

            return View(productor);
        }

        // GET: Productors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductorId,Foto,Nombre,Biografia")] Productor productor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productor);
        }

        // GET: Productors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productor = await _context.Productors.FindAsync(id);
            if (productor == null)
            {
                return NotFound();
            }
            return View(productor);
        }

        // POST: Productors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductorId,Foto,Nombre,Biografia")] Productor productor)
        {
            if (id != productor.ProductorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductorExists(productor.ProductorId))
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
            return View(productor);
        }

        // GET: Productors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productor = await _context.Productors
                .FirstOrDefaultAsync(m => m.ProductorId == id);
            if (productor == null)
            {
                return NotFound();
            }

            return View(productor);
        }

        // POST: Productors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productor = await _context.Productors.FindAsync(id);
            _context.Productors.Remove(productor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductorExists(int id)
        {
            return _context.Productors.Any(e => e.ProductorId == id);
        }
    }
}
