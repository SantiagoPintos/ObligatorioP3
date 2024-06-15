using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private IListarPedidosAnulados _listarPedidosAnulados;

        public PedidoController(IListarPedidosAnulados listarPedidosAnulados)
        {
            this._listarPedidosAnulados = listarPedidosAnulados;
        }

        /// <summary>
        /// Retorna una lista de pedidos anulados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
