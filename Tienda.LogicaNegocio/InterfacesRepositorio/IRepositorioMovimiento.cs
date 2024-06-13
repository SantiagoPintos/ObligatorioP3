using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioMovimiento : IRepositorio<Movimiento>
    {
        public IEnumerable<Movimiento> ObtenerMovimientos(int idArticulo, string tipoMovimiento);
    }
}
