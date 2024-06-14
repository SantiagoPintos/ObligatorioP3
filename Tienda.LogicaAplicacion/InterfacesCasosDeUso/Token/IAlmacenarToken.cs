using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Token
{
    public interface IAlmacenarToken
    {
        public void almacenarToken(Tienda.LogicaAplicacion.DTOs.TokenDTO token);
    }
}
