using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente
{
    public interface IObtenerClientePorNombreApellido
    {
        public IEnumerable<Tienda.LogicaAplicacion.DTOs.ClienteDTO> ObtenerClientePorNombreApellido(string nombre);
    }
}
