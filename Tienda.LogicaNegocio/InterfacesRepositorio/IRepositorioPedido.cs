using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPedido:IRepositorio<Pedido>
    {
        public IEnumerable<Pedido> FindByMonto(decimal monto);
        public IEnumerable<Pedido> ListarPedidosNoEntregados(DateTime fecha);
        public void AnularPedido(int id);
    }
}
