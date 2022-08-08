using System;
using System.ComponentModel.DataAnnotations;

namespace AppV1.Models
{
    public class Busqueda
    {
        public string keywords { get; set; }
        public string autor { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime desde { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime hasta { get; set; }
    }
}
