using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.Excepciones.Pedido;
using Tienda.LogicaAplicacion.CasosDeUso.Cliente;
using Tienda.LogicaAplicacion.CasosDeUso.Articulo;

namespace Tienda.LogicaAplicacion.CasosDeUso.Pedido
{
    public class CrearPedidoCU:ICrearPedido
    {
        private IRepositorioPedido _repositorioPedido;
        public CrearPedidoCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }


        public void CrearPedido(PedidoDTO pedido, int tipoPedido)
        {
            Tienda.LogicaNegocio.Entidades.Cliente cliente = ClienteDTOMapper.FromDto(pedido.Cliente);


            if (tipoPedido == 0)
            {
                throw new Exception("No se eligio un tipo de pedido");
            }
            if (tipoPedido == 1)
            {
                Tienda.LogicaNegocio.Entidades.Comun comun = Tienda.LogicaAplicacion.Mappers.PedidoDTOMapper.FromDtoToComun(pedido);         
                comun.EsValido();
                
                DateTime fecha = DateTime.Now;
                comun.Fecha = fecha;
                comun.Cliente = cliente;
                comun.PrecioTotal = comun.CalcularPrecio();                                             
                comun.PrecioTotal = comun.PrecioTotal + (comun.PrecioTotal * comun.IVA / 100);
                this._repositorioPedido.Add(comun);
            }
            else if(tipoPedido == 2)
            {
                Tienda.LogicaNegocio.Entidades.Express express = Tienda.LogicaAplicacion.Mappers.PedidoDTOMapper.FromDtoToExpress(pedido);
                express.EsValido();                
                express.Fecha = DateTime.Now;
                express.Cliente = cliente;                      
                express.PrecioTotal = express.PrecioTotal + (express.PrecioTotal * express.Recargo / 100);
                express.PrecioTotal = express.PrecioTotal + (express.PrecioTotal * express.IVA / 100);
                this._repositorioPedido.Add(express);
            }            
        }


    }
}
