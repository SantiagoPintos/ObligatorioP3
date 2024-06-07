using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.TipoMovimiento;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.TipoMovimiento
{
    public class ListarTipoMovimientoCU:IListarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public ListarTipoMovimientoCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            this._repositorioTipoMovimiento = repositorioTipoMovimiento;
        }

        public IEnumerable<TipoMovimientoDTO> ListarTipoMovimiento()
        {
            return this._repositorioTipoMovimiento.FindAll().Select(tipo => TipoMovimientoDTOMapper.toDTO(tipo));
        }
    }
}
