using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class LineaDTO
    {
        public ArticuloDTO Articulo { get; set; }
        public int Cantidad { get; set; }



    }
}
