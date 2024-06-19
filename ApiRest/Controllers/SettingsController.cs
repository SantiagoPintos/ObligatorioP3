using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Settings;
using Tienda.LogicaNegocio.Excepciones.Movimiento;
using Tienda.LogicaNegocio.Excepciones.Setting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private IActualizarSetting _actualizarSetting;
        private IObtenerPaginado _obtenerPaginado;
        public SettingsController(IActualizarSetting actualizarSetting, IObtenerPaginado obtenerPaginado)
        {
            this._actualizarSetting = actualizarSetting;
            _obtenerPaginado = obtenerPaginado;
        }

        /// <summary>
        /// Actualiza un setting dado su nombre
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        // PUT api/<SettingsController>
        [HttpPut("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SettingDTO> Update([FromBody] SettingDTO setting)
        {
            try
            {
                this._actualizarSetting.ActualizarSetting(setting.Nombre, setting.Valor);
                return Ok();
            }
            catch (SettingsException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }

        [Route("ObtenerPaginado")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SettingDTO> ObtenerPaginado()
        {
            try
            {
                double paginado = _obtenerPaginado.obtenerPaginado();
                if (paginado!=null)
                {
                    return Ok(paginado);
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




    }
}
