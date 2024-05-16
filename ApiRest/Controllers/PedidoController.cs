using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
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
        public ActionResult<IEnumerable<PedidoDTO>> GetPedidos()
        {
            try
            {
                IEnumerable<PedidoDTO> listaDeDTO = _listarPedidosAnulados.ListarPedidosAnulados();
                if (listaDeDTO.Count() > 0)
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
