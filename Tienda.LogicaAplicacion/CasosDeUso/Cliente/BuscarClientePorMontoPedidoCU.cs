using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente;

namespace Tienda.LogicaAplicacion.CasosDeUso.Cliente
{
    public class BuscarClientePorMontoPedidoCU : IBuscarClientePorMontoPedido
    {
        private IRepositorioPedido _repositorioPedido;
        public BuscarClientePorMontoPedidoCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public IEnumerable<ClienteDTO> BuscarClientePorMontoPedido(decimal monto)
        {
            return this._repositorioPedido.FindByMonto(monto).Select(cliente => ClienteDTOMapper.toDto(cliente));
        }
    }
}
