using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Encargado;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaNegocio.Excepciones;
using Tienda.LogicaNegocio.Excepciones.Encargado;

namespace Tienda.LogicaAplicacion.CasosDeUso.Encargado
{
    public class LoginEncargadoCU : ILoginEncargado
    {
        private IRepositorioEncargado _repositorioEncargado;
        public LoginEncargadoCU(IRepositorioEncargado repositorioEncargado)
        {
            this._repositorioEncargado = repositorioEncargado;
        }
        public void login(EncargadoDTO encargado)
        {
            if(encargado == null) throw new EncargadoException("Datos incorrectos");
            if(string.IsNullOrEmpty(encargado.Email) || string.IsNullOrEmpty(encargado.Clave)) throw new EncargadoException("Datos incorrectos");
            this._repositorioEncargado.Login(encargado.Email, encargado.Clave);
        }
    }
}
