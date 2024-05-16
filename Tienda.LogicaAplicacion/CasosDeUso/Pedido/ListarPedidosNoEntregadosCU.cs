using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Pedido
{
    public class ListarPedidosNoEntregadosCU : IListarPedidosNoEntregados
    {
        private IRepositorioPedido _repositorioPedido;
        public ListarPedidosNoEntregadosCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }
        public IEnumerable<PedidoDTO> ListarPedidosNoEntregados(DateTime fecha)
        {
            if (fecha == null) throw new Exception("Fecha no puede ser nula");

            return this._repositorioPedido.ListarPedidosNoEntregados(fecha).Select(pedido => PedidoDTOMapper.toDto(pedido));
        }
    }
}
