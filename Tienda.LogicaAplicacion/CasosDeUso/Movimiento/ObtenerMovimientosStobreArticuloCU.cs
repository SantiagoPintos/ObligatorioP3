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
        private IRepositorioSettings _repositorioSettings;
        public ObtenerMovimientosStobreArticuloCU(IRepositorioMovimiento repositorioMovimiento, IRepositorioSettings repositorioSettings)
        {
            _repositorioMovimiento = repositorioMovimiento;
            _repositorioSettings = repositorioSettings;
        }
        public IEnumerable<MovimientoDTO> ObtenerMovimientos(int idArticulo, string tipoMovimiento, int pag)
        {
            if (String.IsNullOrEmpty(tipoMovimiento)) throw new MovimientoNoValidoException("El tipo de movimiento no es válido");
            if (int.TryParse(tipoMovimiento, out int result)) throw new MovimientoNoValidoException("El tipo de movimiento no es válido");
            if (pag <= 0) throw new MovimientoNoValidoException("El número de página no es válido");
            if (idArticulo<0) throw new MovimientoNoValidoException("El id del artículo no es válido");
            //Los tipos de movimiento se guardan en mayus en la base de datos
            tipoMovimiento = tipoMovimiento.ToUpper();
            //Obtener paginado
            int paginado = (int)this._repositorioSettings.GetSettingValueByName("PAGINADO");
            if (paginado <= 0) throw new MovimientoNoValidoException("El valor del paginado no es válido");

            return this._repositorioMovimiento.ObtenerMovimientos(idArticulo, tipoMovimiento, pag, paginado).Select(a => MovimientoStockMapperDTO.toDto(a));
        }
    }
}
