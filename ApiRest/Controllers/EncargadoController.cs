﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Encargado;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Excepciones.Encargado;
using Microsoft.AspNetCore.Authorization;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using NuGet.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        ///<summary>
        /// Metodo para permitir inicio de sesion y obtener un jwt para uso de la api
        /// </summary>
        /// <param name = "encargado" > nombre de usuario y contraseña</param>
        /// <returns>Token y datos del usuario</returns>
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] EncargadoDTO encargado)
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
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }

        }
    }
}