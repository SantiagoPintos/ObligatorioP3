using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.ValueObjects;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class ClienteDTOMapper
    {

        public static ClienteDTO toDto(Cliente cliente)
        {
            return new ClienteDTO(cliente);
        }

        public static Cliente FromDto(ClienteDTO clienteDTO)
        {
            if(clienteDTO == null) throw new Exception();            
            return new Cliente(clienteDTO.Id, clienteDTO.Rut, clienteDTO.RazonSocial, clienteDTO.Calle, clienteDTO.Numero, clienteDTO.Ciudad, clienteDTO.distanciaDesdeTienda, clienteDTO.Nombre, clienteDTO.Apellido);
        }


    }
}
