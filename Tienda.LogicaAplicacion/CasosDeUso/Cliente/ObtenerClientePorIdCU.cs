using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Excepciones.Cliente;
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
            if( id == null || id < 0) throw new ClienteNoValidoException("Debe seleccionar un cliente");
            return ClienteDTOMapper.toDto(this._repositorioCliente.FindByID(id));
        }
    }
}
