﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Cliente
{
    public interface IBuscarClientePorMontoPedido
    {
        public IEnumerable<ClienteDTO> BuscarClientePorMontoPedido(decimal monto);
    }
}
