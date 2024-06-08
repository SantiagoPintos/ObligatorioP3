using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Settings;
using Tienda.LogicaNegocio.Excepciones.Setting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private IActualizarSetting _actualizarSetting;
        public SettingsController(IActualizarSetting actualizarSetting)
        {
            this._actualizarSetting = actualizarSetting;
        }
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
    }
}
