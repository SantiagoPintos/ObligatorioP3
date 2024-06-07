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
    public class EliminarTipoMovimientoCU:IEliminarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorio;
        public EliminarTipoMovimientoCU(IRepositorioTipoMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }

        public void EliminarTipoMovimiento(TipoMovimientoDTO tipo)
        {
            if(tipo==null) throw new TipoMovimientoNoValidoException("El movimiento a eliminar no es válido");
            this._repositorio.Remove(TipoMovimientoDTOMapper.fromDTO(tipo));
        }
    }
}
