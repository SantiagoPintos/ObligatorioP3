using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Excepciones.TipoMovimiento;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class TipoMovimientoDTOMapper
    {
        public static TipoMovimientoDTO toDTO(TipoMovimiento tipoMovimiento)
        {
            TipoMovimientoDTO tipoMovimientoDTO = new TipoMovimientoDTO();
            tipoMovimientoDTO.Id = tipoMovimiento.Id;
            tipoMovimientoDTO.Nombre = tipoMovimiento.Nombre;
            tipoMovimientoDTO.Signo = tipoMovimiento.Signo;
            return tipoMovimientoDTO;
        }

        public static TipoMovimiento fromDTO(TipoMovimientoDTO tipoMovimientoDTO)
        {
            if (tipoMovimientoDTO == null) throw new TipoMovimientoNoValidoException("El tipo de movimiento no es válido");
            TipoMovimiento tipoMovimiento = new TipoMovimiento();
            tipoMovimiento.Id = tipoMovimientoDTO.Id;
            tipoMovimiento.Nombre = tipoMovimientoDTO.Nombre;
            tipoMovimiento.Signo = tipoMovimientoDTO.Signo;
            return tipoMovimiento;
        }
    }
}
