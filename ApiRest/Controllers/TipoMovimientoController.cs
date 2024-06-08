using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.TipoMovimiento;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private IListarTipoMovimiento _listarTipoMovimiento;
        public TipoMovimientoController(IListarTipoMovimiento listarTipoMovimiento)
        {
            this._listarTipoMovimiento = listarTipoMovimiento;
        }

        // GET: api/<TipoMovimientoController>
        [HttpGet(Name = "GetTipoMovimiento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult <IEnumerable<TipoMovimientoDTO>> GetTipoMovimiento()
        {
            try
            {
                IEnumerable<TipoMovimientoDTO> listaDeDTO = _listarTipoMovimiento.ListarTipoMovimiento();
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
