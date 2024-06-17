using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Encargado;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Excepciones.Encargado;
using Microsoft.AspNetCore.Authorization;
using Tienda.LogicaNegocio.Entidades;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using NuGet.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginEncargado _login;
        public LoginController(ILoginEncargado login)
        {
            _login = login;
        }

        /// <summary>
        /// RF02 - Login
        /// </summary>
        /// <param name="encargado"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Login([FromBody] EncargadoDTO encargado)
        {
            try
            {
                string token = _login.login(encargado);
                return Ok(new
                {
                    Token = token,
                    Usuario = encargado
                });
            }
            catch (EncargadoException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }

        }
    }
}
