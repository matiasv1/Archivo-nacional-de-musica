using AppV1.Data;
using AppV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArchMusicaContext _context;

        public HomeController(ILogger<HomeController> logger, ArchMusicaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> Form_consulta(Formulario formulario)
        {
            await _context.SaveChangesAsync();
            var b = new Peticion();
            b.Emisor = formulario.NombreUsuario;
            b.Estado = "Pendiente";
            b.EmailEmisor = formulario.Email;
            b.Asunto = formulario.Asunto;
            b.Description = formulario.Description;
            b.Fecha = DateTime.Now;
            b.Fecha = DateTime.SpecifyKind(b.Fecha, DateTimeKind.Utc);

            _context.Peticiones.Add(b);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
