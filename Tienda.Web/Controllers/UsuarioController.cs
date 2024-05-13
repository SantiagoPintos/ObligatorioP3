using Microsoft.AspNetCore.Components.Forms;
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
        private ICreateUsuario _createUsuarioCU;
        private ILoginUsuario _loginUsuarioCU;
        private IListarUsuario _listarUsuarioCU;
        private IObtenerUsuarioPorID _obtenerUsuarioPorID;
        private IEditarUsuario _editarUsuarioCU;
        private IEliminarUsuario _eliminarUsuarioCU;
        public UsuarioController(ICreateUsuario crearUsuario,             
            ILoginUsuario loginUsuarioCU,
            IListarUsuario listarUsuarioCU,
            IObtenerUsuarioPorID obtenerUsuarioPorID,
            IEditarUsuario editarUsuario,
            IEliminarUsuario eliminarUsuarioCU)
        {
            
            this._createUsuarioCU = crearUsuario;
            this._loginUsuarioCU = loginUsuarioCU;
            this._listarUsuarioCU = listarUsuarioCU;
            this._obtenerUsuarioPorID = obtenerUsuarioPorID;
            this._editarUsuarioCU = editarUsuario;
            this._eliminarUsuarioCU = eliminarUsuarioCU;
        }



        // GET: UsuarioController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("token") == null) return RedirectToAction("Login", "Usuario");

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

        public IActionResult ListarArticulos()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction("ListarAlfabeticamente", "Articulo");
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
                UsuarioDTO usuario = this._obtenerUsuarioPorID.ObtenerUsuarioPorID(id);
                return View(usuario);
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
                    return RedirectToAction(nameof(ListarUsuarios));
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
            UsuarioDTO usuario = this._obtenerUsuarioPorID.ObtenerUsuarioPorID(id);
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioDTO aEditar)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            try
            {
                this._editarUsuarioCU.EditarUsuario(aEditar);
                return RedirectToAction(nameof(ListarUsuarios));
            }
            catch
            {
                return View();
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
                UsuarioDTO usuario = this._obtenerUsuarioPorID.ObtenerUsuarioPorID(id);
                return View(usuario);
            }
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioDTO aBorrar)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction(nameof(Login));
            }
            try
            {
                if (HttpContext.Session.GetString("token") != aBorrar.Email)
                {
                    this._eliminarUsuarioCU.EliminarUsuario(aBorrar);
                    return RedirectToAction(nameof(ListarUsuarios));
                }
                else
                {
                    ViewBag.Message = "No te puedes eliminar a ti mismo";                                       
                }
                return View();
                           
            }
            catch
            {
                return View();
            }
        }
    }
}
