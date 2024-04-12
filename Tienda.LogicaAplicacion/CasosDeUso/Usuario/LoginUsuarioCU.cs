using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Usuario
{
    public class LoginUsuarioCU : ILoginUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public LoginUsuarioCU(IRepositorioUsuario repositorioUsuario)
        {
            this._repositorioUsuario = repositorioUsuario;
        }
        public bool Login(UsuarioDTO usuario)
        { 
            if (this._repositorioUsuario.ExisteUsuario(usuario.Email))
            {
                var usuarioEncontrado = this._repositorioUsuario.EncontrarPorEmail(usuario.Email);
                //falta implementar el método de hasheo
                if (usuarioEncontrado.Clave == usuario.Clave)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
