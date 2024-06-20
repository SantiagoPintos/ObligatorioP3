using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using Tienda.LogicaNegocio.Excepciones.Usuario;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ILoginUsuario _login;
        public UsuarioController(ILoginUsuario login)
        {
            _login = login;
        }
        // POST api/<UsuarioController>
        /// <summary>
        /// Login de usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] UsuarioDTO usuario)
        {
            try
            {
                _login.Login(usuario);
                return Ok("Logueado con éxito");
            }
            catch (UsuarioNoValidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                //preguntar por 500 acá
                return BadRequest();
            }
        }
    }
}
