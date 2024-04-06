using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    internal class Express:Pedido,IValidable<Express> 
    {
        public DateTime FechaEntrega { get; set; }
    }
}
