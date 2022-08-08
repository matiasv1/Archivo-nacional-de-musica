using System;
using System.ComponentModel.DataAnnotations;

namespace AppV1.Models
{
    public class Formulario
    {
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string? Asunto { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}
