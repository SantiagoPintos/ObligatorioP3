using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IRepositorioUsuario _repositorioUsuario;
        private ICreateUsuario _createUsuarioCU;
        private ILoginUsuario _loginUsuarioCU;
        

        public UsuarioController(ICreateUsuario crearUsuario, 
            IRepositorioUsuario repositorioUsuarios,
            ILoginUsuario loginUsuarioCU)
        {
            this._repositorioUsuario = repositorioUsuarios;
            this._createUsuarioCU = crearUsuario;
            this._loginUsuarioCU = loginUsuarioCU;
        }



        // GET: UsuarioController
        public ActionResult Index()
        {
            return View(this._repositorioUsuario.FindAll());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioDTO usuario)
        {
            try
            {
                if (this._loginUsuarioCU.Login(usuario))
                {
                    HttpContext.Session.SetString("token", usuario.Email);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Mensaje = "Usuario o contraseña incorrectos";
                }
            }
            catch
            {
                ViewBag.Mensaje = "No se pudo iniciar sesión";
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO usuario)
        {
            try
            {
                this._createUsuarioCU.CrearUsuario(usuario);
                //si el usuario se registró correctamente, se debe almacenar el inicio sesión antes de redirigir a la pag. principal
                ViewBag.Message = "Usuario registrado correctamente";
                HttpContext.Session.SetString("token", usuario.Email);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //se muestra un mensaje de error en caso de que no se haya podido registrar el usuario
                ViewBag.Message = "No se pudo registrar el usuario";
            }
            return View();
        }


        // GET: CreateCliente
        public ActionResult RedirectToCliente()
        {
            return RedirectToAction("Index", "Cliente");
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
