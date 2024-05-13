using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaAplicacion.Mappers;
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


        IEnumerable<ClienteDTO> IObtenerClientes.ObtenerClientes()
        {
            return this._repositorioCliente.FindAll().Select(cliente => ClienteDTOMapper.toDto(cliente));
        }
    }
}
