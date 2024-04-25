using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Cliente
{
    public class ObtenerClientesCU : IObtenerClientes
    {
        private IRepositorioCliente _repositorioCliente;

        public ObtenerClientesCU(IRepositorioCliente repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }


        public IEnumerable<LogicaNegocio.Entidades.Cliente> ObtenerClientes()
        {
            return this._repositorioCliente.FindAll();
        }
    }
}
