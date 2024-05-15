using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Codigo { get; set; }
        public string Descripcion { get; set; }
        public int stock { get; set; }
        public decimal PrecioUnitario { get; set; }

    }
}
