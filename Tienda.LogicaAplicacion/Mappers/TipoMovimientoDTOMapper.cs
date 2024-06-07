using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaAplicacion.DTOs;

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
            if (tipoMovimientoDTO == null) throw new Exception("Tipo de movimiento nulo");
            TipoMovimiento tipoMovimiento = new TipoMovimiento();
            tipoMovimiento.Id = tipoMovimientoDTO.Id;
            tipoMovimiento.Nombre = tipoMovimientoDTO.Nombre;
            tipoMovimiento.Signo = tipoMovimientoDTO.Signo;
            return tipoMovimiento;
        }
    }
}
