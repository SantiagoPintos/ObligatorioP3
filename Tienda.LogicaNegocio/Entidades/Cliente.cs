using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;
using Tienda.LogicaNegocio.ValueObjects;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Cliente:IValidable<Cliente>
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public DireccionCliente Direccion { get; set; }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
