﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRUEBATEC02LLVG2.Models;

namespace PRUEBATEC02LLVG2.Controllers
{
    public class EspeciesController : Controller
    {
        private readonly PRUEBATEC02LLVG2Context _context;

        public EspeciesController(PRUEBATEC02LLVG2Context context)
        {
            _context = context;
        }

        // GET: Especies
        public async Task<IActionResult> Index()
        {
              return _context.Especies != null ? 
                          View(await _context.Especies.ToListAsync()) :
                          Problem("Entity set 'PRUEBATEC02LLVG2Context.Especies'  is null.");
        }

        // GET: Especies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Especies == null)
            {
                return NotFound();
            }

            var especy = await _context.Especies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especy == null)
            {
                return NotFound();
            }

            return View(especy);
        }

        // GET: Especies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Especy especy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especy);
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Especies == null)
            {
                return NotFound();
            }

            var especy = await _context.Especies.FindAsync(id);
            if (especy == null)
            {
                return NotFound();
            }
            return View(especy);
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Especy especy)
        {
            if (id != especy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecyExists(especy.Id))
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
            return View(especy);
        }

        // GET: Especies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Especies == null)
            {
                return NotFound();
            }

            var especy = await _context.Especies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especy == null)
            {
                return NotFound();
            }

            return View(especy);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Especies == null)
            {
                return Problem("Entity set 'PRUEBATEC02LLVG2Context.Especies'  is null.");
            }
            var especy = await _context.Especies.FindAsync(id);
            if (especy != null)
            {
                _context.Especies.Remove(especy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecyExists(int id)
        {
          return (_context.Especies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
