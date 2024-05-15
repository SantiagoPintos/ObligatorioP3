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
            ClienteDTO clienteDTO = new ClienteDTO();
            clienteDTO.Id = cliente.Id;
            clienteDTO.Rut = cliente.Rut;
            clienteDTO.RazonSocial = cliente.RazonSocial;            
            clienteDTO.Calle = cliente.Direccion.Calle;  
            clienteDTO.Numero = cliente.Direccion.Numero;
            clienteDTO.Ciudad = cliente.Direccion.Ciudad;
            clienteDTO.distanciaDesdeTienda = cliente.Direccion.DistanciaDesdeTienda;
            clienteDTO.Nombre = cliente.NombreCompleto.Nombre;
            clienteDTO.Apellido = cliente.NombreCompleto.Apellido;
            return clienteDTO;

        }

        public static Cliente FromDto(ClienteDTO clienteDTO)
        {
            if(clienteDTO == null) throw new Exception();
            Cliente cliente = new Cliente();
            cliente.Id = clienteDTO.Id;
            cliente.Rut = clienteDTO.Rut;
            cliente.RazonSocial = clienteDTO.RazonSocial;
            DireccionCliente direccion = new DireccionCliente(clienteDTO.Calle, clienteDTO.Numero, clienteDTO.Ciudad, clienteDTO.distanciaDesdeTienda);
            cliente.Direccion = direccion;
            NombreCompletoCliente nombreCompleto = new NombreCompletoCliente(clienteDTO.Nombre, clienteDTO.Apellido);
            cliente.NombreCompleto = nombreCompleto;
            return cliente;
        }


    }
}
