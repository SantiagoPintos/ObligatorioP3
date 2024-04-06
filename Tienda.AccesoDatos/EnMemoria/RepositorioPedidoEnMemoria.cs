using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.AccesoDatos.EnMemoria
{
    public class RepositorioPedidoEnMemoria
    {
        public static List<Pedido> Pedidos = new List<Pedido>();
    }
}
