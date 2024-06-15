﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IObtenerMovimientosSobreArticulo obtenerMovimientosSobreArticulo;
        private IObtenerArticulosConMovimientosEntreFechas obtenerArticulosConMovimientosEntreFechas;
        public ConsultasController(IObtenerMovimientosSobreArticulo obtenerMovimientosSobreArticulo,
                                    IObtenerArticulosConMovimientosEntreFechas obtenerArticulosConMovimientosEntreFechas)
        {
            this.obtenerMovimientosSobreArticulo = obtenerMovimientosSobreArticulo;
            this.obtenerArticulosConMovimientosEntreFechas = obtenerArticulosConMovimientosEntreFechas;
        }


        /// <summary>
        /// RF-04 a - Obtiene los movimientos de un articulo en base a su id y tipo de movimiento
        /// </summary>
        /// <param name="idArticulo"></param>
        /// <param name="tipoMovimiento"></param>
        /// <returns></returns>
        [Route("MovimientosIdTipo/{idArticulo}/{tipoMovimiento}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<MovimientoDTO>> ObtenerMovimientos(int idArticulo, string tipoMovimiento)
        {
            try
            {
                IEnumerable<MovimientoDTO> listaDeDTO = obtenerMovimientosSobreArticulo.ObtenerMovimientos(idArticulo, tipoMovimiento);
                if (listaDeDTO.Count() > 0)
                {
                    return Ok(listaDeDTO);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// RF-04 b - Obtiene los artículos que han tenido movimientos en un rango de fechas
        /// </summary>
        /// <param name="fchInicial"></param>
        /// <param name="fchFinal"></param>
        /// <returns></returns>
        [Route("MovimientosEntreFechas/{fchInicial}/{fchFinal}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ArticuloDTO>> ObtenerMovimientosEntreFechas(string fchInicial, string fchFinal)
        {
            try
            {
                if (String.IsNullOrEmpty(fchInicial) || String.IsNullOrEmpty(fchFinal)) throw new Exception("Las fechas no son válidas");
                DateTime fechaInicial = DateTime.Parse(fchInicial);
                DateTime fechaFinal = DateTime.Parse(fchFinal);
                IEnumerable<ArticuloDTO> listaDeDTO = obtenerArticulosConMovimientosEntreFechas.ObtenerArticulosConMovimientosEntreFechas(fechaInicial, fechaFinal);
                if (listaDeDTO.Count() > 0)
                {
                    return Ok(listaDeDTO);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
