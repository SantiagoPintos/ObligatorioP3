using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.TipoMovimiento;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaNegocio.Excepciones.TipoMovimiento;

using Tienda.LogicaAplicacion.Mappers;

namespace Tienda.LogicaAplicacion.CasosDeUso.TipoMovimiento
{
    public class EncontrarPorNombreTipoMovimientoCU : IEncontrarPorNombreTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorio;
        public EncontrarPorNombreTipoMovimientoCU(IRepositorioTipoMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }

        public TipoMovimientoDTO EncontrarPorNombreTipoMovimiento(string nombre)
        {
            if(string.IsNullOrEmpty(nombre)) throw new TipoMovimientoNoValidoException("El nombre del movimiento no es válido");

            return TipoMovimientoDTOMapper.toDTO(this._repositorio.FindByName(nombre));
        }
    }
}
