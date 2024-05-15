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
        public static PedidoDTO toDtoFromComun(Comun comun)
        {
            if (comun == null) throw new Exception();
            PedidoDTO pedidoDTO = new PedidoDTO();                  
            pedidoDTO.Fecha = comun.Fecha;
            pedidoDTO.Cliente = (ClienteDTOMapper.toDto(comun.Cliente));
            pedidoDTO.lineas = comun.lineas.Select(linea => LineaDTOMapper.toDto(linea)).ToList();
            pedidoDTO.PrecioTotal = comun.PrecioTotal;
            pedidoDTO.Recargo = comun.Recargo;
            pedidoDTO.IVA = comun.IVA;
            pedidoDTO.FechaEntrega = comun.FechaEntrega;
            pedidoDTO.anulado = comun.anulado;
            return pedidoDTO;
        }
        public static PedidoDTO toDtoFromExpress(Express express)
        {
            if (express == null) throw new Exception();
            PedidoDTO pedidoDTO = new PedidoDTO();
            pedidoDTO.Id = express.Id;
            pedidoDTO.Fecha = express.Fecha;
            pedidoDTO.Cliente = (ClienteDTOMapper.toDto(express.Cliente));
            pedidoDTO.lineas = express.lineas.Select(linea => LineaDTOMapper.toDto(linea)).ToList();
            pedidoDTO.PrecioTotal = express.PrecioTotal;
            pedidoDTO.Recargo = express.Recargo;
            pedidoDTO.IVA = express.IVA;
            pedidoDTO.FechaEntrega = express.FechaEntrega;
            pedidoDTO.anulado = express.anulado;
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
