using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRUEBATEC02LLVG2.Models;

namespace PRUEBATEC02LLVG2.Controllers
{
    public class FloresController : Controller
    {
        private readonly PRUEBATEC02LLVG2Context _context;

        public FloresController(PRUEBATEC02LLVG2Context context)
        {
            _context = context;
        }

        // GET: Flores
        public async Task<IActionResult> Index()
        {
            var pRUEBATEC02LLVG2Context = _context.Flores.Include(f => f.Tipo);
            return View(await pRUEBATEC02LLVG2Context.ToListAsync());
        }

        // GET: Flores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Flores == null)
            {
                return NotFound();
            }

            var flore = await _context.Flores
                .Include(f => f.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flore == null)
            {
                return NotFound();
            }

            return View(flore);
        }

        // GET: Flores/Create
        public IActionResult Create()
        {
            ViewData["TipoId"] = new SelectList(_context.Especies, "Id", "Nombre");
            return View();
        }

        // POST: Flores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,TipoId")] Flore flore, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    flore.Imagen = memoryStream.ToArray();

                }
            }

            _context.Add(flore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ////if (ModelState.IsValid)
            //{
            //}
            //ViewData["TipoId"] = new SelectList(_context.Especies, "Id", "Nombre", flore.TipoId);
            //return View(flore);
        }

        // GET: Flores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Flores == null)
            {
                return NotFound();
            }

            var flore = await _context.Flores.FindAsync(id);
            if (flore == null)
            {
                return NotFound();
            }
            ViewData["TipoId"] = new SelectList(_context.Especies, "Id", "Nombre", flore.TipoId);
            return View(flore);
        }

        // POST: Flores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,TipoId")] Flore flore, IFormFile imagen)
        {
            if (id != flore.Id)
            {
                return NotFound();
            }
            if (imagen != null && imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    flore.Imagen = memoryStream.ToArray();
                }
                _context.Update(flore);
                await _context.SaveChangesAsync();
            }
            else
            {
                var producFind = await _context.Flores.FirstOrDefaultAsync(s => s.Id == flore.Id);
                if (producFind?.Imagen?.Length > 0)
                    flore.Imagen = producFind.Imagen;
                producFind.Nombre = flore.Nombre;
                producFind.Descripcion= flore.Descripcion;
                producFind.Precio = flore.Precio;

                _context.Update(producFind);
                await _context.SaveChangesAsync();
            }


            //if (ModelState.IsValid)
            //{
            try
                {
                    _context.Update(flore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FloreExists(flore.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            //ViewData["TipoId"] = new SelectList(_context.Especies, "Id", "Nombre", flore.TipoId);
            //return View(flore);
        }

        // GET: Flores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Flores == null)
            {
                return NotFound();
            }

            var flore = await _context.Flores
                .Include(f => f.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flore == null)
            {
                return NotFound();
            }

            return View(flore);
        }

        // POST: Flores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Flores == null)
            {
                return Problem("Entity set 'PRUEBATEC02LLVG2Context.Flores'  is null.");
            }
            var flore = await _context.Flores.FindAsync(id);
            if (flore != null)
            {
                _context.Flores.Remove(flore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FloreExists(int id)
        {
          return (_context.Flores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
