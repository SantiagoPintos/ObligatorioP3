using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo
{
    public interface IListarAlfabeticamente
    {
        IEnumerable<Tienda.LogicaAplicacion.DTOs.ArticuloDTO> ListarAlfabeticamente();

    }
}
