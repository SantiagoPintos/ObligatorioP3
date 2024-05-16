using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.Web.Controllers
{
    public class ClienteController : Controller
    {       
        private ICreateCliente _createClienteCU;
        private IObtenerClientes _obtenerClientesCU;
        private IObtenerClientePorNombreApellido _obtenerClientesPorNombreApellidoCU;
        private IBuscarClientePorMontoPedido _buscarClientePorMontoPedido;
        public ClienteController(ICreateCliente createClienteCU, 
                                IObtenerClientes obtenerClientesCU,
                                IObtenerClientePorNombreApellido obtenerClientesPorNombreApellidoCU,
                                IBuscarClientePorMontoPedido buscarClientePorMontoPedido)
        {
            this._createClienteCU = createClienteCU;
            this._obtenerClientesCU = obtenerClientesCU;
            this._obtenerClientesPorNombreApellidoCU = obtenerClientesPorNombreApellidoCU;
            this._buscarClientePorMontoPedido = buscarClientePorMontoPedido;
        }


        // GET: ClienteController
        public ActionResult Index(string filtro, string msj, decimal valorDecimal)
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Index", "Usuario");

            IEnumerable<ClienteDTO> aMostrar = new List<ClienteDTO>();
            ViewBag.Message = msj;

            if (string.IsNullOrEmpty(filtro))
            {
                aMostrar = this._obtenerClientesCU.ObtenerClientes();
            }
            if(filtro == "NombreApellido")
            {
                string nombre = (string)TempData["nombreApellido"];
                aMostrar = this._obtenerClientesPorNombreApellidoCU.ObtenerClientePorNombreApellido(nombre);
            }
            if(filtro == "MontoPedidos")
            {                                                
                aMostrar = this._buscarClientePorMontoPedido.BuscarClientePorMontoPedido(valorDecimal);
            }

            return View(aMostrar);
        }

        [HttpPost]
        public ActionResult BuscarPorNombreApellido(string nombreApellido)
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Index", "Usuario");

            if(nombreApellido.IsNullOrEmpty()) return RedirectToAction("Index", new { msj = "El texto no puede ser vacío" });
            TempData["nombreApellido"] = nombreApellido;
            return RedirectToAction("Index", new { filtro = "NombreApellido" });
        }

        [HttpPost]
        public ActionResult BuscarPorMonto(string valor)
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Index", "Usuario");
            decimal nuevoValor = Convert.ToDecimal(valor);
            if(nuevoValor <= 0) return RedirectToAction("Index", new { msj = "El monto no puede ser cero ni negativo" });            
            return RedirectToAction("Index", new { filtro = "MontoPedidos", valorDecimal = nuevoValor });
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Index", "Usuario");
            }
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteDTO cliente)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                try
                {
                    this._createClienteCU.CrearCliente(cliente);
                    ViewBag.Message = "Cliente registrado correctamente";
                    return RedirectToAction(nameof(Index));                    
                }
                catch(Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();                    
                }
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if(HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Index", "Usuario");
            }
            else
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Index", "Usuario");
            }
            else
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

        public ActionResult ReturnToHome()
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Login", "Usuario");

            return RedirectToAction("Index", "Usuario");
        }
    }
}
