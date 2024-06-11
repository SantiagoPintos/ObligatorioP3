using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Encargado;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Excepciones.Encargado;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncargadoController : ControllerBase
    {
        private ILoginEncargado _login;
        public EncargadoController(ILoginEncargado login)
        {
            _login = login;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] EncargadoDTO encargado)
        {
            try
            {
                _login.login(encargado);
                return Ok("Logueado con éxito");
            }
            catch (EncargadoException e)
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
