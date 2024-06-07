using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.TipoMovimiento
{
    public interface IEncontrarPorNombreTipoMovimiento
    {
        public TipoMovimientoDTO EncontrarPorNombreTipoMovimiento(string nombre);
    }
}
