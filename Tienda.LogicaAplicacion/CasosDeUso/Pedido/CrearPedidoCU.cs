﻿using System;
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
        // se agrega para que se pueda modificar el stock de los articulos, invocando al CU de 
        // modificar stock
        private IRepositorioArticulo _repositorioArticulo;
        public CrearPedidoCU(IRepositorioPedido repositorioPedido, IRepositorioArticulo repositorioArticulo)
        {
            _repositorioPedido = repositorioPedido;
            _repositorioArticulo = repositorioArticulo;
        }

        public void CrearPedido(PedidoDTO pedido, int tipoPedido, decimal RecargoComun, decimal RecargoExpress, decimal RecargoExpressHoy)
        {
            try
            {
                Tienda.LogicaNegocio.Entidades.Cliente cliente = ClienteDTOMapper.FromDto(pedido.Cliente);

                if (tipoPedido == 0)
                {
                    throw new PedidoException("No se eligio un tipo de pedido");
                }
                if (tipoPedido == 1)
                {
                    Tienda.LogicaNegocio.Entidades.Comun comun = Tienda.LogicaAplicacion.Mappers.PedidoDTOMapper.FromDtoToComun(pedido);
                    comun.Fecha = DateTime.Today;
                    comun.EsValido();
                    comun.Cliente = cliente;
                    comun.PrecioTotal = comun.CalcularPrecio(RecargoComun, RecargoExpress, RecargoExpressHoy);
                    decimal iva = (comun.IVA/100);
                    comun.PrecioTotal = comun.PrecioTotal + (comun.PrecioTotal*iva);
                    comun.anulado = false;
                    foreach (Linea linea in comun.lineas)
                    {
                        ModificarStockCU modificarStockCU = new ModificarStockCU(_repositorioArticulo); 
                        modificarStockCU.ModificarStock(linea.Articulo, linea.Cantidad); 
                    }
                    this._repositorioPedido.Add(comun);
                }
                else if(tipoPedido == 2)
                {
                    Tienda.LogicaNegocio.Entidades.Express express = Tienda.LogicaAplicacion.Mappers.PedidoDTOMapper.FromDtoToExpress(pedido);
                    express.Fecha = DateTime.Today;
                    express.EsValido();
                    express.Cliente = cliente;
                    express.PrecioTotal = express.CalcularPrecio(RecargoComun, RecargoExpress, RecargoExpressHoy);
                    decimal iva = express.IVA / 100;
                    express.PrecioTotal = express.PrecioTotal + (express.PrecioTotal*iva);
                    express.anulado = false;
                    this._repositorioPedido.Add(express);
                }            

            } 
            catch (Exception e)
            {
                throw new PedidoException(e.Message);
            }
        }


    }
}
