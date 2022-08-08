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
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace AppV1.Controllers
{
    public class BuscadorController : Controller
    {
        
        private readonly ArchMusicaContext _context;
        public BuscadorController(ArchMusicaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Guardar(int s, string url)
        {
            var hb = new HistorialBusquedas();
            hb.Fecha = DateTime.Now;
            hb.Fecha = DateTime.SpecifyKind(hb.Fecha, DateTimeKind.Utc);
            hb.URL = url;
            hb.Peticion = s;
            _context.HistorialBusquedas.Add(hb);
            await _context.SaveChangesAsync();
            return View("Index");
        }
        public async Task<IActionResult> Resultados(int id, [Bind("keywords,autor,desde,hasta")] Busqueda busqueda)
        {
            
            string url = "https://neuma.utalca.cl/index.php/neuma/search/search?query=";
              
            if (busqueda.keywords is not null)
            {
                url+= busqueda.keywords;
            }
            url += "&searchJournal=2";
            url += "&authors=";
            if (busqueda.autor is not null)
            {
                url += busqueda.autor;
            }
            url += "&title=&abstract=&galleyFullText=&discipline=&subject=&type=&coverage=";
            if (!busqueda.desde.ToString("MM-dd-yyyy").Equals("01-01-0001"))
            {
                url += "&dateFromMonth="+busqueda.desde.ToString("MM");
                url += "&dateFromDay="+busqueda.desde.ToString("dd");
                url += "&dateFromYear"+busqueda.desde.ToString("yyyy");
            }
            if (!busqueda.hasta.ToString("MM-dd-yyyy").Equals("01-01-0001"))
            {
                url += "&dateToMonth=" + busqueda.hasta.ToString("MM");
                url += "&dateToDay=" + busqueda.hasta.ToString("dd");
                url += "&dateToYear" + busqueda.hasta.ToString("yyyy");
            }
            url += "&orderBy=score&orderDir=desc&searchPage=";
            HtmlWeb hw = new HtmlWeb();
            List<string> list = new List<string>();
            List<string> links = new List<string>();
            Dictionary<string,string> lista = new Dictionary<string, string>();
            int cont = 1;
            bool opcion = true;
            while (opcion)
            {
                HtmlDocument doc = hw.Load(url + cont);
                if (doc.DocumentNode.CssSelect(".article-summary").FirstOrDefault() is not null)
                {
                    foreach (var Nodo in doc.DocumentNode.CssSelect(".article-summary"))
                    {
                        list.Add(Nodo.InnerHtml);
                    }
                    foreach (var Nodo in doc.DocumentNode.CssSelect(".article-summary-title a"))
                    {
                        links.Add(Nodo.GetAttributeValue("href"));
                    }
                    cont++;
                }
                else
                {
                    opcion = false;
                }
            }
            if (list is null)
            {
                list.Add("No hay Resultados");
            }
            int c = 0;
            while (c < list.Count())
            {
                lista[list.ElementAt(c)] = links.ElementAt(c);
                c++;
            }
            ViewBag.largo = list.Count().ToString();
            ViewBag.Peticion = id;
            return View("Index",lista);
        }
        private bool PeticionExists(int id)
        {
            return _context.Peticiones.Any(e => e.PeticionID == id);
        }
        public async Task<IActionResult> Consulta(int? id)
        {
            var peticion = await _context.Peticiones.FindAsync(id);
            if (peticion == null)
            {
                return NotFound();
            }
            if (!peticion.Estado.Equals("Terminado"))
            {
                peticion.Estado = "En progreso";
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
            ViewBag.id = id;
            return View("Index");
        }
    }
}
