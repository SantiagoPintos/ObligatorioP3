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
    public class AlmanecerTokenCU:IAlmacenarToken
    {
        private IRepositorioToken _repositorioToken;
        public AlmanecerTokenCU(IRepositorioToken repositorioToken)
        {
            this._repositorioToken = repositorioToken;
        }
        public void almacenarToken(TokenDTO token)
        {
            _repositorioToken.Add(TokenDTOMapper.FromDto(token));
        }
    }
}
