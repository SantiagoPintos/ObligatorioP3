using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.Excepciones.Movimiento;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Movimiento
{
    public class ObtenerMovimientosStobreArticuloCU : IObtenerMovimientosSobreArticulo
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        public ObtenerMovimientosStobreArticuloCU(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }
        public IEnumerable<MovimientoDTO> ObtenerMovimientos(int idArticulo, string tipoMovimiento)
        {
            if (String.IsNullOrEmpty(tipoMovimiento)) throw new MovimientoNoValidoException("El tipo de movimiento no es válido");
            if(idArticulo<0) throw new MovimientoNoValidoException("El id del artículo no es válido");
            //Los tipos de movimiento se guardan en mayus
            tipoMovimiento = tipoMovimiento.ToUpper();
            return this._repositorioMovimiento.ObtenerMovimientos(idArticulo, tipoMovimiento).Select(a => MovimientoStockMapperDTO.toDto(a));
        }
    }
}
