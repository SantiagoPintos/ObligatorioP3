using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class PedidoDTO
    {
        public decimal Recargo { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }

        public List<Linea> lineas = new List<Linea>();
        public decimal PrecioTotal { get; set; }

        public PedidoDTO() { }

        public PedidoDTO(Pedido pedido)
        {
            if (pedido == null) throw new Exception();
            this.Recargo = pedido.Recargo;
            this.Id = pedido.Id;
            this.Fecha = pedido.Fecha;
            this.Cliente = pedido.Cliente;
            this.lineas = pedido.lineas;
            this.PrecioTotal = pedido.PrecioTotal;

        }



    }
}
