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
        public EliminarTipoMovimientoCU(IRepositorioTipoMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }

        public void EliminarTipoMovimiento(int tipo)
        {
            if(tipo==null) throw new TipoMovimientoNoValidoException("El movimiento a eliminar no es válido");
            Tienda.LogicaNegocio.Entidades.TipoMovimiento movimiento = this._repositorio.FindByID(tipo);
            if (movimiento == null) throw new TipoMovimientoNoValidoException("El movimiento a eliminar no existe");
            this._repositorio.Remove(movimiento);
        }
    }
}
