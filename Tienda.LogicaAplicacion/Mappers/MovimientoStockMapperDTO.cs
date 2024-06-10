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
            movimientoDTO.TipoMovimiento = TipoMovimientoDTOMapper.toDTO(movimiento.TipoMovimiento);
            movimientoDTO.Articulo = Tienda.LogicaAplicacion.Mappers.ArticuloDTOMapper.toDto(movimiento.Articulo);
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
            movimiento.Articulo = ArticuloDTOMapper.FromDto(movimientoDTO.Articulo);
            movimiento.TipoMovimiento = TipoMovimientoDTOMapper.fromDTO(movimientoDTO.TipoMovimiento);
            return movimiento;
        }
    }
}
