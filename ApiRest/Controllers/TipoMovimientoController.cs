using Microsoft.AspNetCore.Mvc;
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
        private ICreateTipoMovimiento _crearTipoMovimiento;
        private IEliminarTipoMovimiento _eliminarTipoMovimiento;
        private IEditarTipoMovimiento _editarTipoMovimiento;
        public TipoMovimientoController(IListarTipoMovimiento listarTipoMovimiento,
                                        ICreateTipoMovimiento crearTipoMovimiento,
                                        IEliminarTipoMovimiento eliminarTipoMovimiento,
                                        IEditarTipoMovimiento editarTipoMovimiento)
        {
            this._listarTipoMovimiento = listarTipoMovimiento;
            this._crearTipoMovimiento = crearTipoMovimiento;
            _eliminarTipoMovimiento = eliminarTipoMovimiento;
            this._editarTipoMovimiento = editarTipoMovimiento;
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
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception e)
            {
                return BadRequest("Algo salió mal");
            }
        }

        // POST api/<TipoMovimientoController>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
                return BadRequest("Algo salió mal");
            }
        }

        // DELETE api/<TipoMovimientoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(int id)
        {
            try
            {
                //Falta verificar que no se estén utilizando en algún movimiento antes de ser eliminados
                this._eliminarTipoMovimiento.EliminarTipoMovimiento(id);
                return Ok();
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Algo salió mal");
            }
        }


        // PUT api/<TipoMovimientoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Update(int id, [FromBody] TipoMovimientoDTO tipoMovimiento)
        {
            //Falta verificar que no se estén utilizando en algún movimiento antes de ser actualizados
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
                return BadRequest("Algo salió mal");
            }
        }


    }
}
