using Microsoft.EntityFrameworkCore;
using AppV1.Models;
using System.Collections.Generic;

namespace AppV1.Data
{
    public class ArchMusicaContext : DbContext
    {
        public ArchMusicaContext(DbContextOptions<ArchMusicaContext> options) : base(options)
        {

        }
        public DbSet<Peticion> Peticiones { get; set; }
        public DbSet<HistorialBusquedas> HistorialBusquedas { get; set; }
    }
}
    
