using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private IListarPedidosAnulados _listarPedidosAnulados;

        public PedidoController(IListarPedidosAnulados listarPedidosAnulados)
        {
            this._listarPedidosAnulados = listarPedidosAnulados;
        }

        [HttpGet(Name = "GetPedidos")]
        public ActionResult<IEnumerable<ArticuloDTO>> GetPedidos()
        {
            return Ok(_listarPedidosAnulados.ListarPedidosAnulados());
        }
    }
}
