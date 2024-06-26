﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Pedido
{
    public interface IListarPedidosNoEntregados
    {
        IEnumerable<PedidoDTO> ListarPedidosNoEntregados(DateTime fecha);
    }
}
