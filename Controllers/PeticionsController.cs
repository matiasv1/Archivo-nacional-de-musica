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
using Microsoft.AspNetCore.Http;

namespace AppV1
{
    [Authorize]
    public class PeticionsController : Controller
    {
        private readonly ArchMusicaContext _context;
        public PeticionsController(ArchMusicaContext context)
        {
            _context = context;
        }

        // GET: Peticions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peticiones.ToListAsync());
        }

        // GET: Peticions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peticion = await _context.Peticiones
                .FirstOrDefaultAsync(m => m.PeticionID == id);
            if (peticion == null)
            {
                return NotFound();
            }
            List<HistorialBusquedas> busqueda = _context.HistorialBusquedas.Where(s => s.Peticion == id).ToList();

            peticion.HistorialBusquedas = busqueda;

            return View(peticion);
        }

        // GET: Peticions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peticions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeticionID,Estado,Asunto,Description,Fecha,Emisor,EmailEmisor")] Peticion peticion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peticion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peticion);
        }

        // GET: Peticions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peticion = await _context.Peticiones.FindAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            return View(peticion);
        }
       

        // POST: Peticions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PeticionID,Estado,Asunto,Description,Fecha,Emisor,EmailEmisor")] Peticion peticion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peticion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeticionExists(peticion.PeticionID))
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
            return View(peticion);
        }

        // GET: Peticions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peticion = await _context.Peticiones
                .FirstOrDefaultAsync(m => m.PeticionID == id);
            if (peticion == null)
            {
                return NotFound();
            }

            return View(peticion);
        }

        // POST: Peticions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peticion = await _context.Peticiones.FindAsync(id);
            _context.Peticiones.Remove(peticion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeticionExists(int id)
        {
            return _context.Peticiones.Any(e => e.PeticionID == id);
        }
           
        public async Task<IActionResult> Finalizar(int id)
        {
            var peticion = await _context.Peticiones.FindAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            if (!peticion.Estado.Equals("Terminado"))
            {
                peticion.Estado = "Finalizado";
                try
                {
                    _context.Update(peticion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeticionExists(peticion.PeticionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> FiltrarAsync(string x, bool P, bool EP, bool F, string estado)
        {

            ViewBag.Filtro = x; 
            ViewBag.P = P;
            ViewBag.Ep = EP;
            ViewBag.F = F;
            ViewBag.Estado = estado;
            return View("Index", await _context.Peticiones.ToListAsync());
        }
    }
}
