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
    public class PeliculasController : Controller
    {
        private readonly AppDbContext _context;

        public PeliculasController(AppDbContext context)
        {
            _context = context;
        }


        // GET: Peliculas
        public async Task<IActionResult> Index(string Filtro)
        {
            List<Pelicula> peliculasDelSistema;
            if (Filtro != null)
            {
                peliculasDelSistema = await _context.Peliculas.Where(p => p.Nombre.Contains(Filtro))
                    .Include(p => p.Productor).ToListAsync();
            }
            else
            {
                peliculasDelSistema = await _context.Peliculas.Include(p => p.Cine).Include(p => p.Productor).ToListAsync();
            }

            return View(peliculasDelSistema);
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .Include(p => p.Cine)
                .Include(p => p.Productor)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            ViewData["CineId"] = new SelectList(_context.Cines, "CineId", "CineId");
            ViewData["ProductorId"] = new SelectList(_context.Productors, "ProductorId", "ProductorId");
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeliculaId,Nombre,Descripcion,Precio,ImageURL,FechaInicio,FechaFinal,Categoria,CineId,ProductorId")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelicula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CineId"] = new SelectList(_context.Cines, "CineId", "CineId", pelicula.CineId);
            ViewData["ProductorId"] = new SelectList(_context.Productors, "ProductorId", "ProductorId", pelicula.ProductorId);
            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            ViewData["CineId"] = new SelectList(_context.Cines, "CineId", "CineId", pelicula.CineId);
            ViewData["ProductorId"] = new SelectList(_context.Productors, "ProductorId", "ProductorId", pelicula.ProductorId);
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PeliculaId,Nombre,Descripcion,Precio,ImageURL,FechaInicio,FechaFinal,Categoria,CineId,ProductorId")] Pelicula pelicula)
        {
            if (id != pelicula.PeliculaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.PeliculaId))
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
            ViewData["CineId"] = new SelectList(_context.Cines, "CineId", "CineId", pelicula.CineId);
            ViewData["ProductorId"] = new SelectList(_context.Productors, "ProductorId", "ProductorId", pelicula.ProductorId);
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .Include(p => p.Cine)
                .Include(p => p.Productor)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            return _context.Peliculas.Any(e => e.PeliculaId == id);
        }

       
    }
}   
