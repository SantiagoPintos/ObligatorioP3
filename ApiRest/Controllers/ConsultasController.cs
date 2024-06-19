using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Tienda.LogicaNegocio.Excepciones.Articulo;
using Tienda.LogicaNegocio.Excepciones.Movimiento;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultasController : ControllerBase
    {
        private IObtenerMovimientosSobreArticulo obtenerMovimientosSobreArticulo;
        private IObtenerArticulosConMovimientosEntreFechas obtenerArticulosConMovimientosEntreFechas;
        private IObtenerResumenCantidadesMovidas obtenerResumenCantidadesMovidas;
        private IObtenerMovimientosDeArticuloCompleto obtenerMovimientosDeArticuloCompleto;
        private IObtenerArticulosConMovimientosEntreFechasCompleto obtenerArticulosConMovimientosEntreFechasCompleto;   
        public ConsultasController(IObtenerMovimientosSobreArticulo obtenerMovimientosSobreArticulo,
                                    IObtenerArticulosConMovimientosEntreFechas obtenerArticulosConMovimientosEntreFechas,
                                    IObtenerResumenCantidadesMovidas obtenerResumenCantidadesMovidas,
                                    IObtenerMovimientosDeArticuloCompleto obtenerMovimientosDeArticuloCompleto,
                                    IObtenerArticulosConMovimientosEntreFechasCompleto obtenerArticulosConMovimientosEntreFechasCompleto)
        {
            this.obtenerMovimientosSobreArticulo = obtenerMovimientosSobreArticulo;
            this.obtenerArticulosConMovimientosEntreFechas = obtenerArticulosConMovimientosEntreFechas;
            this.obtenerResumenCantidadesMovidas = obtenerResumenCantidadesMovidas;
            this.obtenerMovimientosDeArticuloCompleto = obtenerMovimientosDeArticuloCompleto;
            this.obtenerArticulosConMovimientosEntreFechasCompleto = obtenerArticulosConMovimientosEntreFechasCompleto;
        }


        /// <summary>
        /// RF-04 a - Obtiene los movimientos de un articulo en base a su id y tipo de movimiento
        /// </summary>
        /// <param name="idArticulo">Id de artículo</param>
        /// <param name="tipoMovimiento">Nombre del tipo de movimiento</param>
        /// <param name="pagina">Página</param>
        /// <returns>Retorna movimientos de artículo seleccionado</returns>
        [Route("MovimientosIdTipo/{idArticulo}/{tipoMovimiento}/{pagina}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<MovimientoDTO>> ObtenerMovimientos(int idArticulo, string tipoMovimiento, int pagina)
        {
            try
            {
                IEnumerable<MovimientoDTO> listaDeDTO = obtenerMovimientosSobreArticulo.ObtenerMovimientos(idArticulo, tipoMovimiento, pagina);
                if (listaDeDTO.Count() > 0)
                {
                    return Ok(listaDeDTO);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (MovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }

        [Route("MovimientosDeArticulo/{idArticulo}/{tipoMovimientoNombre}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // Metodo para obtener todos los movimientos de un articulo y poder hacer el paginado en el front
        public ActionResult<IEnumerable<MovimientoDTO>> ObtenerTodosLosMovimientos(int idArticulo, string tipoMovimientoNombre)
        {
            try
            {
                IEnumerable<MovimientoDTO> listaDeDTO = obtenerMovimientosDeArticuloCompleto.ObtenerMovimientosDeArticuloCompleto(idArticulo, tipoMovimientoNombre);
                if (listaDeDTO.Count() > 0)
                {
                    return Ok(listaDeDTO);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (MovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }





        /// <summary>
        /// RF-04 b - Obtiene los artículos que han tenido movimientos en un rango de fechas
        /// </summary>
        /// <param name="fchInicial">Fecha inicial</param>
        /// <param name="fchFinal">Fecha final</param>
        /// <param name="pagina">Pagina</param>
        /// <returns>Retorna una lista de artículos que han estado involucrados en movimientos entre las dos fechas indicadas</returns>
        [Route("MovimientosEntreFechas/{fechaInicial}/{fechaFinal}/{pagina}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ArticuloDTO>> ObtenerMovimientosEntreFechas(string fechaInicial, string fechaFinal, int pagina)
        {
            try
            {
                DateTime fchInicial = DateTime.Parse(fechaInicial);
                DateTime fchFinal = DateTime.Parse(fechaFinal);
                if (fchFinal == DateTime.MinValue || fchFinal == DateTime.MinValue ) throw new Exception("Las fechas no son válidas");
                IEnumerable<ArticuloDTO> listaDeDTO = obtenerArticulosConMovimientosEntreFechas.ObtenerArticulosConMovimientosEntreFechas(fchInicial, fchFinal, pagina);
                if (listaDeDTO.Count() > 0)
                {
                    return Ok(listaDeDTO);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArticuloNuloException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }
        // Metodo para obtener TODOS los articulos con movimiento entre fechas y poder hacer el paginado en el front
        /// <summary>
        /// RF-04 b - Obtiene los artículos que han tenido movimientos en un rango de fechas
        /// </summary>
        /// <param name="fchInicial">Fecha inicial</param>
        /// <param name="fchFinal">Fecha final</param>
        /// <param name="pagina">Pagina</param>
        /// <returns>Retorna una lista de artículos que han estado involucrados en movimientos entre las dos fechas indicadas</returns>
        [Route("MovimientosEntreFechasCompleto/{fechaInicial}/{fechaFinal}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ArticuloDTO>> ObtenerMovimientosEntreFechasCompleto(string fechaInicial, string fechaFinal)
        {
            try
            {
                DateTime fchInicial = DateTime.Parse(fechaInicial);
                DateTime fchFinal = DateTime.Parse(fechaFinal);
                IEnumerable<ArticuloDTO> listaDeDTO = obtenerArticulosConMovimientosEntreFechasCompleto.ObtenerArticulosConMovimientosEntreFechasCompleto(fchInicial, fchFinal);
                if (listaDeDTO.Count() > 0)
                {
                    return Ok(listaDeDTO);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArticuloNuloException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }

        /// <summary>
        /// RF04 C - Obtiene un resumen de las cantidades movidas agrupadas por año y dentro de año por tipo de movimiento
        /// </summary>
        /// <returns>Retorna un resumen de las cantidades movidas agrupadas por año y dentro de año por tipo de movimiento</returns>
        [Route("ResumenCantidades")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult <IEnumerable<ResumenDTO>> ResumenCantidadesMovidas()
        {
            try
            {
                IEnumerable<ResumenDTO> listaDeDTO = obtenerResumenCantidadesMovidas.ObtenerResumenCantidadesMovidas();
                if (listaDeDTO.Count() > 0)
                {
                    return Ok(listaDeDTO);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArticuloNuloException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }
    }
}
