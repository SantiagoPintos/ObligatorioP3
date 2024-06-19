using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Articulo
{
    public class ObtenerArticulosConMovimientoEntreFechasCompletoCU : IObtenerArticulosConMovimientosEntreFechasCompleto
    {
        private IRepositorioMovimiento repositorioMovimiento;
        public ObtenerArticulosConMovimientoEntreFechasCompletoCU(IRepositorioMovimiento repositorioMovimiento, IRepositorioSettings repositorioSettings)
        {
            this.repositorioMovimiento = repositorioMovimiento;
        }
        public IEnumerable<ArticuloDTO> ObtenerArticulosConMovimientosEntreFechasCompleto(DateTime fchInicial, DateTime fchFinal)
        {
            return this.repositorioMovimiento.ObtenerArticulosConMovimientosEntreFechasCompleto(fchInicial, fchFinal).Select(articulo => ArticuloDTOMapper.toDto(articulo));
        }
    }
}
