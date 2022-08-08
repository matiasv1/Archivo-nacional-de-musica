using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppV1.Data;
using AppV1.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppV1
{
    [Authorize]
    public class HistorialBusquedasController : Controller
    {
        private readonly ArchMusicaContext _context;

        public HistorialBusquedasController(ArchMusicaContext context)
        {
            _context = context;
        }
        
        // GET: HistorialBusquedas
        public async Task<IActionResult> Index()
        {
            return View(await _context.HistorialBusquedas.ToListAsync());
        }

        // GET: HistorialBusquedas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialBusquedas = await _context.HistorialBusquedas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historialBusquedas == null)
            {
                return NotFound();
            }

            return View(historialBusquedas);
        }

        // GET: HistorialBusquedas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistorialBusquedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Peticion,Fecha,URL")] HistorialBusquedas historialBusquedas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialBusquedas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historialBusquedas);
        }

        // GET: HistorialBusquedas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialBusquedas = await _context.HistorialBusquedas.FindAsync(id);
            if (historialBusquedas == null)
            {
                return NotFound();
            }
            return View(historialBusquedas);
        }

        // POST: HistorialBusquedas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Peticion,Fecha,URL")] HistorialBusquedas historialBusquedas)
        {
            if (id != historialBusquedas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialBusquedas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialBusquedasExists(historialBusquedas.Id))
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
            return View(historialBusquedas);
        }

        // GET: HistorialBusquedas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialBusquedas = await _context.HistorialBusquedas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historialBusquedas == null)
            {
                return NotFound();
            }

            return View(historialBusquedas);
        }

        // POST: HistorialBusquedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialBusquedas = await _context.HistorialBusquedas.FindAsync(id);
            _context.HistorialBusquedas.Remove(historialBusquedas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialBusquedasExists(int id)
        {
            return _context.HistorialBusquedas.Any(e => e.Id == id);
        }
    }
}
