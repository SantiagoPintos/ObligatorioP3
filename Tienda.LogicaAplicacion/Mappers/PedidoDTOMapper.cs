using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class PedidoDTOMapper
    {
        public static PedidoDTO toDto(Pedido pedido)
        {
            return new PedidoDTO(pedido);
        }

        public static Pedido FromDto(PedidoDTO pedidoDTO)
        {
            if (pedidoDTO == null) throw new Exception();
            return new Pedido(pedidoDTO.Recargo, pedidoDTO.Id, pedidoDTO.Fecha, pedidoDTO.Cliente, pedidoDTO.lineas, pedidoDTO.PrecioTotal);
        }
    }
}
