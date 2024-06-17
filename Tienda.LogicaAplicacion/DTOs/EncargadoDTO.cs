using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class EncargadoDTO
    {
        public int Id { get; set; }
        public string? Nombre     { get; set; }
        public string? Apellido { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string? ClaveSinEncriptar { get; set; }
    }
}
