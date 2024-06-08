using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.TipoMovimiento;
using Tienda.LogicaNegocio.Excepciones.TipoMovimiento;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.TipoMovimiento
{
    public class EliminarTipoMovimientoCU:IEliminarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorio;
        private IRepositorioMovimiento _repositorioMovimiento;
        public EliminarTipoMovimientoCU(IRepositorioTipoMovimiento repositorio, IRepositorioMovimiento repositorioMovimiento)
        {
            this._repositorio = repositorio;
            _repositorioMovimiento = repositorioMovimiento;
        }

        public void EliminarTipoMovimiento(int tipo)
        {
            if(tipo==null) throw new TipoMovimientoNoValidoException("El movimiento a eliminar no es válido");
            Tienda.LogicaNegocio.Entidades.TipoMovimiento movimiento = this._repositorio.FindByID(tipo);
            if (movimiento == null) throw new TipoMovimientoNoValidoException("El movimiento a eliminar no existe");
            //SOLO se puede editar TipoMovimiento si este NO está incluído en un Movimiento
            if (_repositorioMovimiento.FindAll().Any(movimiento => movimiento.TipoMovimiento.Id == tipo))
            {
                throw new TipoMovimientoNoValidoException("No se puede eliminar el Tipo de Movimiento porque está en uso");
            }
            this._repositorio.Remove(movimiento);
        }
    }
}
