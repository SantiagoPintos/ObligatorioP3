using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Tienda.LogicaNegocio.Excepciones.Pedido;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaAplicacion.CasosDeUso.Cliente;
using Tienda.LogicaAplicacion.Mappers;

namespace Tienda.Web.Controllers
{
    public class PedidoController : Controller
    {
        // GET: PedidoController

        private static PedidoDTO tempPedido;

        private IObtenerClientes _obtenerClientes;
        private IListarPedidos _listarPedidos;
        private IListarAlfabeticamente _listarAlfabeticamente;
        private IObtenerArticuloPorId   _obtenerArticuloPorId;
        private ICrearPedido _crearPedido;
        private IObtenerClientePorId _obtenerClientePorId;
        private ICalcularStock  _calcularStock;
        public PedidoController(IObtenerClientes obtenerClientes,
            IListarPedidos _listarPedidos,
            IListarAlfabeticamente _listaAlfabeticamente,
            IObtenerArticuloPorId obtenerArticuloPorId,
            ICrearPedido crearPedido,
            IObtenerClientePorId obtenerClientePorId,
            ICalcularStock calcularStock)
        {
            this._obtenerClientes = obtenerClientes;
            this._listarPedidos = _listarPedidos;
            this._listarAlfabeticamente = _listaAlfabeticamente;
            this._obtenerArticuloPorId = obtenerArticuloPorId;
            this._crearPedido = crearPedido;
            this._obtenerClientePorId = obtenerClientePorId;
            _calcularStock = calcularStock;

        }

        public ActionResult Index(string mensaje)
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Login", "Usuario");
            ViewBag.Mensaje = mensaje;

            return View();
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Login", "Usuario");

            return View();
        }        




        // GET: PedidoController/Create
        public ActionResult Create(string error)
        {
            ViewBag.error = error; 
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Login", "Usuario");
            ViewBag.clientes = _obtenerClientes.ObtenerClientes();      
            ViewBag.articulos = _listarAlfabeticamente.ListarAlfabeticamente();
            if (tempPedido!=null)
            {
                ViewBag.lineas = tempPedido.lineas; 
            }
            
            return View();
        }


        // POST : PedidoController/AgregarLinea
        [HttpPost]
        public ActionResult AgregarLinea(int idArticulo, int cantidad)
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Login", "Usuario");
            //valor por defecto en vista es -1
            if (idArticulo == -1 || cantidad == 0)
            {
                return RedirectToAction(nameof(Create), new { error = "Debe seleccionar un articulo y una cantidad" });
            }
            try
            {
                ArticuloDTO articulo = _obtenerArticuloPorId.ObtenerArticuloPorId(idArticulo);
                _calcularStock.CalcularStock(articulo, cantidad);
                LineaDTO linea = new LineaDTO { Articulo = articulo, Cantidad = cantidad };
                if (tempPedido == null)
                {
                    tempPedido = new PedidoDTO { lineas = new List<LineaDTO>() };
                }
                tempPedido.lineas.Add(linea);
                return RedirectToAction(nameof(Create));
            }
            catch(Exception e)
            {                
                return RedirectToAction(nameof(Create), new { error = e.Message });
            }
                
            
            
        }
        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDTO pedido, int tipoPedido, int idCliente)
        {
            try
            {
                
                if (tempPedido!=null && tempPedido.lineas.Count > 0 )
                {
                    pedido.lineas = tempPedido.lineas;
                }
                ClienteDTO cliente = this._obtenerClientePorId.ObtenerClientePorId(idCliente);
                pedido.Cliente = cliente;
                this._crearPedido.CrearPedido(pedido, tipoPedido);
                tempPedido = null;                
                return RedirectToAction(nameof(Index), new {mensaje = "Pedido creado correctamente"}); 
            }catch (PedidoException e)
            {
                return RedirectToAction(nameof(Create), new {error = e.Message});
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Create), new {error = e.Message});
                
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
