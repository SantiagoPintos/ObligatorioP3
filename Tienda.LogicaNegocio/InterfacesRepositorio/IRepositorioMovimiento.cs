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
        public IEnumerable<Movimiento> ObtenerMovimientos(int idArticulo, string tipoMovimiento, int pagina, int size);
        public IEnumerable<Articulo> ObtenerArticulosConMovimientosEntreFechas(DateTime fchInicial, DateTime fchFinal, int pag, int size);
        public IEnumerable<Movimiento> ObtenerMovimientosDeArticuloCompleto(int idArticulo, string tipoMovimientoCompleto);
        public IEnumerable<Articulo> ObtenerArticulosConMovimientosEntreFechasCompleto(DateTime fchInicial, DateTime fchFinal);
    }
}
