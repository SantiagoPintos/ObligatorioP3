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
    public class CrearTipoMovimientoCU : ICreateTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public CrearTipoMovimientoCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            this._repositorioTipoMovimiento = repositorioTipoMovimiento;
        }

        public void CrearTipoMovimiento(TipoMovimientoDTO aCrear)
        {
            //Se guardan nombres en mayúsculas para evitar duplicados
            aCrear.Nombre = aCrear.Nombre.ToUpper().Trim();
            this._repositorioTipoMovimiento.Add(TipoMovimientoDTOMapper.fromDTO(aCrear));
        }
    }
}
