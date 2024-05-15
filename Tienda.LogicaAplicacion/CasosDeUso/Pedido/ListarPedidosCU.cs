using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Pedido
{
    public class ListarPedidosCU : IListarPedidos
    {
        private IRepositorioPedido _repositorioPedido;
        public ListarPedidosCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }


        public IEnumerable<PedidoDTO> ListarPedidos()
        {
            throw new NotImplementedException();
        }
    }
}
