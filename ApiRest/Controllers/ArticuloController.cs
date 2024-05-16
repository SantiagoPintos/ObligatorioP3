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
        public IEnumerable<ArticuloDTO> Get()
        {
            return _listarAlfabeticamente.ListarAlfabeticamente();
        }
    }
}
