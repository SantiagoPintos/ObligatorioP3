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
            Tienda.LogicaNegocio.Entidades.TipoMovimiento tipoMovimiento = this._repositorio.FindByName(nombre);
            //Condicional ternario, funciona igual que en js/ts
            return tipoMovimiento == null
                ? throw new TipoMovimientoNoValidoException("No se encontró el tipo de movimiento")
                : TipoMovimientoDTOMapper.toDTO(tipoMovimiento);
        }
    }
}
