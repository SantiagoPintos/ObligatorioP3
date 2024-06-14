using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Token;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaAplicacion.DTOs;

namespace Tienda.LogicaAplicacion.CasosDeUso.Token
{
    public class EliminarTokenCU:IEliminarToken
    {
        private IRepositorioToken _repositorioToken;
        public EliminarTokenCU(IRepositorioToken repositorioToken)
        {
            this._repositorioToken = repositorioToken;
        }

        void IEliminarToken.EliminarToken(string email)
        {            
            _repositorioToken.Remove(_repositorioToken.FindByEmail(email));
        }
    }
}
