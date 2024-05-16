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
    public class ListarPedidosAnuladosCU : IListarPedidosAnulados
    {
        private IRepositorioPedido _repositorioPedido;
        public ListarPedidosAnuladosCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public IEnumerable<PedidoDTO> ListarPedidosAnulados()
        {
            return this._repositorioPedido.FindPedidosAnulados().Select(pedido => PedidoDTOMapper.toDto(pedido));
        }
    }
}
