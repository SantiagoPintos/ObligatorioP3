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
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.Excepciones.Encargado;
using System.Security.Principal;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Token;
using Tienda.LogicaAplicacion.Mappers;

namespace Tienda.LogicaAplicacion.CasosDeUso.Encargado
{
    public class LoginEncargadoCU : ILoginEncargado
    {
        private IRepositorioEncargado _repositorioEncargado;
        private IRepositorioToken _repositorioToken;
        public LoginEncargadoCU(IRepositorioEncargado repositorioEncargado, 
                                IRepositorioToken repositorioToken)
        {
            this._repositorioEncargado = repositorioEncargado;
            this._repositorioToken = repositorioToken;
        }

        public string login(EncargadoDTO encargado)
        {
            if(string.IsNullOrEmpty(encargado.Email) || string.IsNullOrEmpty(encargado.Clave)) throw new EncargadoException("Datos incorrectos");
            this._repositorioEncargado.Login(encargado.Email, encargado.Clave);
            EncargadoDTO en = EncargadoDTOMapper.ToDTO(this._repositorioEncargado.FindByEmail(encargado.Email));
            //En caso de que ya exista un token para ese usuario se debe eliminar y crear uno nuevo
            this._repositorioToken.FindByEmailAndRemove(encargado.Email);
            string token = ManejadorJwt.GenerarToken(en);
            TokenDTO tokenNuevo = new TokenDTO
            {
                TokenUsuario = token,
                Encargado = en
            };           
            this._repositorioToken.Add(TokenDTOMapper.FromDto(tokenNuevo));
            return token;
        }
    }
}
