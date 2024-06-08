using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.TipoMovimiento;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Excepciones.TipoMovimiento;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.TipoMovimiento
{
    public class EditarTipoMovimientoCU : IEditarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorio;
        private IRepositorioMovimiento _repositorioMovimiento;
        public EditarTipoMovimientoCU(IRepositorioTipoMovimiento repositorio, IRepositorioMovimiento repositorioMovimiento)
        {
            this._repositorio = repositorio;
            _repositorioMovimiento = repositorioMovimiento;
        }

        public void EditarTipoMovimiento(TipoMovimientoDTO aEditar)
        {
            //Se guarda nombre en mayus para evitar duplicados
            aEditar.Nombre = aEditar.Nombre.ToUpper().Trim();

            //SOLO se puede editar TipoMovimiento si este NO está incluído en un Movimiento
            if (_repositorioMovimiento.FindAll().Any(movimiento => movimiento.TipoMovimiento.Id == aEditar.Id))
            {
                throw new TipoMovimientoNoValidoException("No se puede editar el Tipo de Movimiento porque está uso");
            }

            this._repositorio.Update(TipoMovimientoDTOMapper.fromDTO(aEditar));
        }
    }
}
