﻿using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.TipoMovimiento;
using Tienda.LogicaNegocio.Excepciones.TipoMovimiento;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private IListarTipoMovimiento _listarTipoMovimiento;
        private IEncontrarPorNombreTipoMovimiento _listarTipoMovimientoPorNombre;
        private ICreateTipoMovimiento _crearTipoMovimiento;
        private IEliminarTipoMovimiento _eliminarTipoMovimiento;
        private IEditarTipoMovimiento _editarTipoMovimiento;
        public TipoMovimientoController(IListarTipoMovimiento listarTipoMovimiento,
                                        ICreateTipoMovimiento crearTipoMovimiento,
                                        IEliminarTipoMovimiento eliminarTipoMovimiento,
                                        IEditarTipoMovimiento editarTipoMovimiento,
                                        IEncontrarPorNombreTipoMovimiento listarTipoMovimientoPorNombre)
        {
            this._listarTipoMovimiento = listarTipoMovimiento;
            this._crearTipoMovimiento = crearTipoMovimiento;
            this._eliminarTipoMovimiento = eliminarTipoMovimiento;
            this._editarTipoMovimiento = editarTipoMovimiento;
            this._listarTipoMovimientoPorNombre = listarTipoMovimientoPorNombre;
        }

        /// <summary>
        /// RF01 - Listar todos los tipos de movimientos
        /// </summary>
        /// <returns></returns>
        // GET: api/<TipoMovimientoController>
        [HttpGet(Name = "GetTipoMovimiento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }

        /// <summary>
        /// RF01 - Obtener un tipo de moivmiento según su nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        // GET: api/<TipoMovimientoController>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult <TipoMovimientoDTO> GetTipoMovimientoByName(string name)
        {
            try
            {
                TipoMovimientoDTO tipoMovimiento = _listarTipoMovimientoPorNombre.EncontrarPorNombreTipoMovimiento(name);
                if (tipoMovimiento != null)
                {
                    return Ok(tipoMovimiento);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }

        /// <summary>
        /// RF01 - Crear un tipo de movimiento
        /// </summary>
        /// <param name="tipoMovimiento"></param>
        /// <returns></returns>
        // POST api/<TipoMovimientoController>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipoMovimientoDTO> Create([FromBody] TipoMovimientoDTO tipoMovimiento)
        {
            try
            {
                this._crearTipoMovimiento.CrearTipoMovimiento(tipoMovimiento);
                return Created("api/TipoMovimiento", tipoMovimiento);
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }

        /// <summary>
        /// RF01 - Eliminar un tipo de movimiento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<TipoMovimientoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            try
            {
                this._eliminarTipoMovimiento.EliminarTipoMovimiento(id);
                return Ok();
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }


        /// <summary>
        /// RF01 - Editar un tipo de movimiento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoMovimiento"></param>
        /// <returns></returns>
        // PUT api/<TipoMovimientoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipoMovimientoDTO> Update(int id, [FromBody] TipoMovimientoDTO tipoMovimiento)
        {
            try
            {
                //Evita que id de DTO sea distinto al id de la URL y/o que tenga id 0
                tipoMovimiento.Id = id;
                this._editarTipoMovimiento.EditarTipoMovimiento(tipoMovimiento);
                return Ok();
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Algo salió mal");
            }
        }


    }
}
