using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaAplicacion.CasosDeUso.Cliente;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class PedidoDTOMapper
    {
        public static PedidoDTO toDto(Pedido pedido)
        {
            if (pedido == null) throw new Exception();
            PedidoDTO pedidoDTO = new PedidoDTO();        
            pedidoDTO.Id = pedido.Id;
            pedidoDTO.Fecha = pedido.Fecha;
            pedidoDTO.Cliente = (ClienteDTOMapper.toDto(pedido.Cliente));
            pedidoDTO.lineas = pedido.lineas.Select(linea => LineaDTOMapper.toDto(linea)).ToList();
            pedidoDTO.PrecioTotal = pedido.PrecioTotal;
            pedidoDTO.Recargo = pedido.Recargo;
            pedidoDTO.IVA = pedido.IVA;
            pedidoDTO.FechaEntrega = pedido.FechaEntrega;
            pedidoDTO.anulado = pedido.anulado;
            return pedidoDTO;
        }

        public static Express FromDtoToExpress(PedidoDTO pedidoDTO)
        {
            if (pedidoDTO == null) throw new Exception();
            Express express = new Express();
            express.Fecha = pedidoDTO.Fecha;
            express.Cliente = ClienteDTOMapper.FromDto(pedidoDTO.Cliente);
            express.lineas = pedidoDTO.lineas.Select(linea => LineaDTOMapper.FromDto(linea)).ToList();
            express.PrecioTotal = pedidoDTO.PrecioTotal;
            express.Recargo = pedidoDTO.Recargo;
            express.IVA = pedidoDTO.IVA;
            express.FechaEntrega = pedidoDTO.FechaEntrega;
            express.anulado = pedidoDTO.anulado;
            return express;
        }


        public static Comun FromDtoToComun(PedidoDTO pedidoDTO)
        {
            if (pedidoDTO == null) throw new Exception();
            Comun comun = new Comun();
            comun.Fecha = pedidoDTO.Fecha;
            comun.Cliente = new Cliente();
            comun.Cliente = ClienteDTOMapper.FromDto(pedidoDTO.Cliente);
            comun.lineas = pedidoDTO.lineas.Select(linea => LineaDTOMapper.FromDto(linea)).ToList();
            comun.PrecioTotal = pedidoDTO.PrecioTotal;
            comun.Recargo = pedidoDTO.Recargo;
            comun.IVA = pedidoDTO.IVA;
            comun.FechaEntrega = pedidoDTO.FechaEntrega;
            comun.anulado = pedidoDTO.anulado;
            return comun;            
        }






    }
}
