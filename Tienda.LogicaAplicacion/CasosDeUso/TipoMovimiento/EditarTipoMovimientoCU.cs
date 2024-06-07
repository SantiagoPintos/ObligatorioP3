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
    public class EditarTipoMovimientoCU : IEditarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorio;
        public EditarTipoMovimientoCU(IRepositorioTipoMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }

        public void EditarTipoMovimiento(TipoMovimientoDTO aEditar)
        {
            this._repositorio.Update(TipoMovimientoDTOMapper.fromDTO(aEditar));
        }
    }
}
