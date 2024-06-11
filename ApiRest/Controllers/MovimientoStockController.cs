using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Tienda.LogicaNegocio.Excepciones.Movimiento;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoStockController : ControllerBase
    {
        private ICreateMovimientoStock _createMovimientoStock;
        public MovimientoStockController(ICreateMovimientoStock createMovimientoStock)
        {
            _createMovimientoStock = createMovimientoStock;
        }

        // POST api/<MovimientoStockController>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovimientoDTO> Post([FromBody] MovimientoDTO movimiento)
        {
            try
            {
                this._createMovimientoStock.CreateMovimientoStock(movimiento);
                return Ok();
            }
            catch(MovimientoNoValidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }

        }
    }
}
