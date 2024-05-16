using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Excepciones.Cliente;

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
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ClienteNoValidoException("El nombre no puede ser vacio");                
            }
            return this._repositorioCliente.FindAll().Where(cliente => cliente.NombreCompleto.Nombre.Contains(nombre) || cliente.NombreCompleto.Apellido.Contains(nombre)).Select(cliente => ClienteDTOMapper.toDto(cliente));
        }
    }
}
