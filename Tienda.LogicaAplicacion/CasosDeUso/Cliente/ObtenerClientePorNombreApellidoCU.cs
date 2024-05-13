using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaAplicacion.Mappers;

namespace Tienda.LogicaAplicacion.CasosDeUso.Cliente
{
    public class ObtenerClientePorNombreApellidoCU : IObtenerClientePorNombreApellido
    {
        private IRepositorioCliente _repositorioCliente;

        public ObtenerClientePorNombreApellidoCU(IRepositorioCliente repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }
        IEnumerable<ClienteDTO> IObtenerClientePorNombreApellido.ObtenerClientePorNombreApellido(string nombre)
        {
            return this._repositorioCliente.FindAll().Where(cliente => cliente.NombreCompleto.Nombre == nombre || cliente.NombreCompleto.Apellido == nombre).Select(cliente => ClienteDTOMapper.toDto(cliente));
        }
    }
}
