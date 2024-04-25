using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente
{
    public interface IObtenerClientes
    {
        public IEnumerable<Tienda.LogicaNegocio.Entidades.Cliente> ObtenerClientes();
    }
}
