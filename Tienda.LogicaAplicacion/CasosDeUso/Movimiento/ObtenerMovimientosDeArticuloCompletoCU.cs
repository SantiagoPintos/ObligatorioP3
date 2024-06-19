using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaAplicacion.Mappers;

namespace Tienda.LogicaAplicacion.CasosDeUso.Movimiento
{
    public class ObtenerMovimientosDeArticuloCompletoCU : IObtenerMovimientosDeArticuloCompleto
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        private IRepositorioSettings _repositorioSettings;
        public ObtenerMovimientosDeArticuloCompletoCU(IRepositorioMovimiento repositorioMovimiento, IRepositorioSettings repositorioSettings)
        {
            _repositorioMovimiento = repositorioMovimiento;
            _repositorioSettings = repositorioSettings;
        }
        public IEnumerable<MovimientoDTO> ObtenerMovimientosDeArticuloCompleto(int idArticulo, string tipoMovimientoNombre)
        {
            return _repositorioMovimiento.ObtenerMovimientosDeArticuloCompleto(idArticulo, tipoMovimientoNombre).Select(a => MovimientoStockMapperDTO.toDto(a));
        }
    }
}
