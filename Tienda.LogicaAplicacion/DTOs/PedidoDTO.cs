using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class PedidoDTO
    {
        public decimal Recargo { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteDTO Cliente { get; set; }

        public List<LineaDTO> lineas = new List<LineaDTO>();
        public decimal PrecioTotal { get; set; }
        public decimal IVA { get; set; }
        public DateTime FechaEntrega { get; set; }

        public bool anulado { get; set; }

    }
}
