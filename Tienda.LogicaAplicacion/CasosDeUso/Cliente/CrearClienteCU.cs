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
    public class CrearClienteCU : ICreateCliente
    {

        private IRepositorioCliente _repositorioCliente;

        public CrearClienteCU(IRepositorioCliente repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }

        public void CrearCliente(ClienteDTO aCrear)
        {
            this._repositorioCliente.Add(ClienteDTOMapper.FromDto(aCrear));
        }





    }
}
