using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IObtenerMovimientosSobreArticulo obtenerMovimientosSobreArticulo;
        public ConsultasController(IObtenerMovimientosSobreArticulo obtenerMovimientosSobreArticulo)
        {
            this.obtenerMovimientosSobreArticulo = obtenerMovimientosSobreArticulo;
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
    }
}
