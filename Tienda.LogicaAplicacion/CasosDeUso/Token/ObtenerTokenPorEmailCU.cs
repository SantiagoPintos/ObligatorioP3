using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Token;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Token
{
    public class ObtenerTokenPorEmailCU : IEncontrarTokenPorEmail
    {
        private IRepositorioToken _repositorioToken;
        public ObtenerTokenPorEmailCU(IRepositorioToken repositorioToken)
        {
            this._repositorioToken = repositorioToken;
        }
        public TokenDTO EncontrarTokenPorEmail(string email)
        {
            return TokenDTOMapper.toDto(this._repositorioToken.FindByEmail(email));
        }
    }
}
