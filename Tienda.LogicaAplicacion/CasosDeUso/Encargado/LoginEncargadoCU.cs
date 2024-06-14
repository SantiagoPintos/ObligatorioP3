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
using System.Security.Principal;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Token;

namespace Tienda.LogicaAplicacion.CasosDeUso.Encargado
{
    public class LoginEncargadoCU : ILoginEncargado
    {
        private IRepositorioEncargado _repositorioEncargado;
        private IObtenerEncargadoPorEmail _obtenerEncargadoPorEmail;
        private IEncontrarTokenPorEmail _encontrarTokenPorEmail;
        private IEliminarToken _eliminarToken;
        private IAlmacenarToken _almacenarToken;
        public LoginEncargadoCU(IRepositorioEncargado repositorioEncargado, IObtenerEncargadoPorEmail encargadoPorEmail, IEncontrarTokenPorEmail encontrarTokenPorEmail, IEliminarToken eliminarToken, IAlmacenarToken almacenarToken)
        {
            this._repositorioEncargado = repositorioEncargado;
            this._obtenerEncargadoPorEmail = encargadoPorEmail;
            this._encontrarTokenPorEmail = encontrarTokenPorEmail;
            _eliminarToken = eliminarToken;
            _almacenarToken = almacenarToken;
        }
        public string login(EncargadoDTO encargado)
        {
            if(encargado == null) throw new EncargadoException("Datos incorrectos");
            if(string.IsNullOrEmpty(encargado.Email) || string.IsNullOrEmpty(encargado.Clave)) throw new EncargadoException("Datos incorrectos");
            this._repositorioEncargado.Login(encargado.Email, encargado.Clave);
            string token = ManejadorJwt.GenerarToken(_obtenerEncargadoPorEmail.ObtenerEncargadoPorEmail(encargado.Email));
            // Verificar que no exista un token para este usuario, si es asi, eliminarlo, guardar el generado y luego retornarlo
            TokenDTO tokenBuscado = this._encontrarTokenPorEmail.EncontrarTokenPorEmail(encargado.Email);
            if(tokenBuscado != null) this._eliminarToken.EliminarToken(tokenBuscado.TokenUsuario);
            // Creamos nuevo tokenDTO
            TokenDTO tokenNuevo = new TokenDTO
            {
                TokenUsuario = token,
                Encargado = encargado
            };           
            _almacenarToken.almacenarToken(tokenNuevo);
            return token;
        }
    }
}
