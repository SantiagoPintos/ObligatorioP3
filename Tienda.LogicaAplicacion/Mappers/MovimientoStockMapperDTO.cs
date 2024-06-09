using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class MovimientoStockMapperDTO
    {
        public static MovimientoDTO toDto(Movimiento movimiento)
        {
            MovimientoDTO movimientoDTO = new MovimientoDTO();
            movimientoDTO.Id = movimiento.Id;
            movimientoDTO.Fecha = movimiento.Fecha;
            movimientoDTO.Cantidad = movimiento.Cantidad;
            movimientoDTO.Usuario = movimiento.Usuario;
            movimientoDTO.TipoMovimientoId = movimiento.TipoMovimiento.Id;
            movimientoDTO.TipoMovimientoNombre = movimiento.TipoMovimiento.Nombre;
            movimientoDTO.TipoMovimientoSigno = (int)movimiento.TipoMovimiento.Signo;
            movimientoDTO.ArticuloId = movimiento.ArticuloId;
            return movimientoDTO;
        }

        public static Movimiento FromDto(MovimientoDTO movimientoDTO)
        {
            if (movimientoDTO == null) throw new Exception();
            Movimiento movimiento = new Movimiento();
            movimiento.Id = movimientoDTO.Id;
            movimiento.Fecha = movimientoDTO.Fecha;
            movimiento.Cantidad = movimientoDTO.Cantidad;
            movimiento.Usuario = movimientoDTO.Usuario;
            movimiento.ArticuloId = movimientoDTO.ArticuloId;
            movimiento.TipoMovimiento.Id = movimientoDTO.TipoMovimientoId;
            movimiento.TipoMovimiento.Nombre = movimientoDTO.TipoMovimientoNombre;
            movimiento.TipoMovimiento.Signo = (LogicaNegocio.Enums.SignoTipoMovimiento)movimientoDTO.TipoMovimientoSigno;
            return movimiento;
        }
    }
}
