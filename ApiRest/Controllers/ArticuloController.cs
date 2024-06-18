using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ArticuloController : ControllerBase
    {
        private IListarAlfabeticamente _listarAlfabeticamente;
        private IObtenerArticuloPorId _obtenerArticuloPorId;

        public ArticuloController(IListarAlfabeticamente listarAlfabeticamente, IObtenerArticuloPorId obtenerArticuloPorId)
        {
            this._listarAlfabeticamente = listarAlfabeticamente;
            _obtenerArticuloPorId = obtenerArticuloPorId;
        }

        /// <summary>
        /// Retorna una lista de articulos ordenados alfabeticamente
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetArticulos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ArticuloDTO>> Get()
        {
            try
            {
                IEnumerable<ArticuloDTO> listaDeDTO = _listarAlfabeticamente.ListarAlfabeticamente();
                if (listaDeDTO.Count()>0)
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


        /// <summary>
        /// Retorna un articulo buscado por id
        /// </summary>
        /// <returns></returns>

        [HttpGet("ObtenerArticuloPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ArticuloDTO> ObtenerArticuloPorId(int id)
        {
            try
            {
                ArticuloDTO articuloDTO = _obtenerArticuloPorId.ObtenerArticuloPorId(id);
                if (articuloDTO != null)
                {
                    return Ok(articuloDTO);
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
