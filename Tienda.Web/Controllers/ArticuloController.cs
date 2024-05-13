using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.Web.Controllers
{
    public class ArticuloController : Controller
    {
        private ICrearArticulo _crearArticulo;
        private IListarArticulo _listarArticulos;
        private IListarAlfabeticamente _listarAlfabeticamente;
        private IEliminarArticulo _eliminarArticulo;
        private IObtenerArticuloPorId _obtenerArticuloPorId;
        private IEditarArticulo _editarArticulo;

        public ArticuloController(IListarArticulo listarArticulos, 
                                  ICrearArticulo crearArticulo,
                                  IListarAlfabeticamente listarAlfabeticamente,
                                  IEliminarArticulo eliminarArticulo,
                                  IObtenerArticuloPorId obtenerArticuloPorId,
                                  IEditarArticulo editarArticulo)
        {
            this._listarArticulos = listarArticulos;
            this._crearArticulo = crearArticulo;
            this._listarAlfabeticamente = listarAlfabeticamente;
            this._eliminarArticulo = eliminarArticulo;
            this._obtenerArticuloPorId = obtenerArticuloPorId;
            this._editarArticulo = editarArticulo;
        }


        // GET: ArticuloController
        public ActionResult Index()
        {
            return RedirectToAction("ListarAlfabeticamente");
        }

        // GET: ArticuloController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                ArticuloDTO articulo = this._obtenerArticuloPorId.ObtenerArticuloPorId(id);
                return View(articulo);
            }
            
        }

        public ActionResult VolverAlInicio()
        {
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult ListarArticulos()
        {
            return View(this._listarArticulos.ListarArticulos());
        }


        public IActionResult ListarAlfabeticamente()
        {
            return View(this._listarAlfabeticamente.ListarAlfabeticamente());
        }


        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloDTO aCrear)
        {
            try
            {
                this._crearArticulo.CrearArticulo(aCrear);
                ViewBag.Message = "Articulo agregado correctamente";
                return RedirectToAction(nameof(ListarAlfabeticamente));
            }
            catch (Exception ex)
            {                
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            ArticuloDTO articulo = this._obtenerArticuloPorId.ObtenerArticuloPorId(id);
            return View(articulo);
        }        

        // POST: ArticuloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticuloDTO aEditar)
        {
           
           if (HttpContext.Session.GetString("token") == null)
                {
                    return RedirectToAction(nameof(Login));
                }
                try
                {
                    this._editarArticulo.EditarArticulo(aEditar);
                    return RedirectToAction(nameof(ListarAlfabeticamente));
                }
                catch
                {
                    return View();
                }
            
        }

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            ArticuloDTO articulo = this._obtenerArticuloPorId.ObtenerArticuloPorId(id);
            return View(articulo);
        }

        // POST: ArticuloController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ArticuloDTO aBorrar)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            try
            {                
                this._eliminarArticulo.EliminarArticulo(aBorrar);
                return RedirectToAction(nameof(ListarAlfabeticamente));                
            }
            catch
            {
                return View();
            }
        }
    }
}
