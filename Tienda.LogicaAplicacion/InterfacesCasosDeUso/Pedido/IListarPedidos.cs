using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido
{
    public interface IListarPedidos
    {
        IEnumerable<Tienda.LogicaAplicacion.DTOs.PedidoDTO> ListarPedidos();
    }
}
