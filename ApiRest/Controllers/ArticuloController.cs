using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticuloController : ControllerBase
    {
        private IListarAlfabeticamente _listarAlfabeticamente;

        public ArticuloController(IListarAlfabeticamente listarAlfabeticamente)
        {
            this._listarAlfabeticamente = listarAlfabeticamente;
        }

        [HttpGet(Name = "GetArticulos")]
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
    }
}
