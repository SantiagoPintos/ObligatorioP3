using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Cliente
{
    public class ObtenerClientePorIdCU:IObtenerClientePorId
    {
        private IRepositorioCliente _repositorioCliente;

        public ObtenerClientePorIdCU(IRepositorioCliente repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }


        public Tienda.LogicaAplicacion.DTOs.ClienteDTO ObtenerClientePorId(int id)
        {
            return ClienteDTOMapper.toDto(this._repositorioCliente.FindByID(id));
        }
    }
}
