using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento
{
    public interface ICreateMovimientoStock
    {
        public void CreateMovimientoStock(MovimientoDTO movimiento);
    }
}
