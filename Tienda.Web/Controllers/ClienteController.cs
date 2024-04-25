using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ClienteController(ICreateCliente createClienteCU, 
                                IObtenerClientes obtenerClientesCU)
        {
            this._createClienteCU = createClienteCU;
            this._obtenerClientesCU = obtenerClientesCU;
        }




        // GET: ClienteController
        public ActionResult Index()
        {
            // TEMPORAL
            return View(this._obtenerClientesCU.ObtenerClientes());
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
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
                catch
                {
                    ViewBag.Message = "No se pudo registrar";
                    return View();                    
                }
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
