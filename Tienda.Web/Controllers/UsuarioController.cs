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
        private IListarUsuario _listarUsuarioCU;


        public UsuarioController(ICreateUsuario crearUsuario, 
            IRepositorioUsuario repositorioUsuarios,
            ILoginUsuario loginUsuarioCU,
            IListarUsuario listarUsuarioCU)
        {
            this._repositorioUsuario = repositorioUsuarios;
            this._createUsuarioCU = crearUsuario;
            this._loginUsuarioCU = loginUsuarioCU;
            this._listarUsuarioCU = listarUsuarioCU;
        }



        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarUsuarios()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            return View(this._listarUsuarioCU.ListarUsuarios());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                return RedirectToAction(nameof(Index));
            } else 
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioDTO usuario)
        {
            if(HttpContext.Session.GetString("token") != null)
            {
                return RedirectToAction(nameof(Index));
            } else
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
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO usuario)
        {
            //El administrador debe estar logueado para registrar usuarios, por lo tanto nos interesa verificar si
            //la variable de sesión NO es nula para permitir el registro
            if (HttpContext.Session.GetString("token") != null)
            {
                try
                {
                    this._createUsuarioCU.CrearUsuario(usuario);
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
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }


        // GET: CreateCliente
        public ActionResult RedirectToCliente()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction("Index", "Cliente");
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return View();
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return View();
            }
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
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
    }
}
