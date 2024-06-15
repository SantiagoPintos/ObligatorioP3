using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class ResumenDTO
    {
        public int año { get; set; }
        public TipoMovimientoo[] tipoMovimiento { get; set; }
        public int suma { get; set; }

    }

    public class TipoMovimientoo 
    {
        public string Nombre { get; set; }
        public int cantidad { get; set; }
    }
}
