using System;
using System.ComponentModel.DataAnnotations;

namespace AppV1.Models
{
    public class HistorialBusquedas
    {
        public int Id { get; set; }
        public int Peticion { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        public string URL { get; set; }
    }
}
