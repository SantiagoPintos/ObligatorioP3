using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using Tienda.LogicaNegocio.Excepciones.Usuario;
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
        public void Login(UsuarioDTO usuario)
        { 
            if(usuario == null) throw new UsuarioNoValidoException("Email o contraseña incorrecta");

            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Clave)) throw new UsuarioNoValidoException("Email o contraseña incorrecta");

            if (this._repositorioUsuario.ExisteUsuario(usuario.Email))
            {
                var usuarioEncontrado = this._repositorioUsuario.EncontrarPorEmail(usuario.Email);
                if (this._repositorioUsuario.ClaveCoincide(usuarioEncontrado.Clave, usuario.Clave))
                {
                    return;
                }
            }
            throw new UsuarioNoValidoException("Email o contraseña incorrecta");
        }

    }
}
