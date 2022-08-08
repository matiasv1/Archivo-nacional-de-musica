using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppV1.Models
{
    public class Peticion
    {
        public int PeticionID { get; set; }
        public string Estado { get; set; }
        public string? Asunto { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        public string Emisor { get; set; }
        public string EmailEmisor { get; set; }

        public ICollection<HistorialBusquedas> HistorialBusquedas { get; set; }
    }
}
