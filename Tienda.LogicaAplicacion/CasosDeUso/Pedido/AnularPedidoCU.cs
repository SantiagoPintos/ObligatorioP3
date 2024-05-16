using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Pedido
{
    public class AnularPedidoCU:IAnularPedido
    {
        private IRepositorioPedido _repositorioPedido;
        public AnularPedidoCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public void AnularPedido(int id)
        {
            this._repositorioPedido.AnularPedido(id);
        }
    }
}
