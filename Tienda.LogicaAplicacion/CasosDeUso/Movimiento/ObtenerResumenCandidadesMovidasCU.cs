using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Movimiento
{
    public class ObtenerResumenCandidadesMovidasCU : IObtenerResumenCantidadesMovidas
    {
        private IRepositorioMovimiento repositorioMovimiento;
        public ObtenerResumenCandidadesMovidasCU(IRepositorioMovimiento repositorioMovimiento)
        {
            this.repositorioMovimiento = repositorioMovimiento;
        }
        public IEnumerable<ResumenDTO> ObtenerResumenCantidadesMovidas()
        {
            IEnumerable<MovimientoDTO> movimientos = this.repositorioMovimiento.FindAll().Select(m => MovimientoStockMapperDTO.toDto(m));

            return movimientos.GroupBy(m => m.Fecha.Year)
                      .Select(grupoDeMovimiento => new ResumenDTO
                      {
                          año = grupoDeMovimiento.Key,
                          tipoMovimiento = grupoDeMovimiento.Select(movimiento => new TipoMovimientoo
                          {
                              Nombre = movimiento.TipoMovimiento.Nombre,
                              cantidad = movimiento.Cantidad,
                          })
                           .GroupBy(tipo => tipo.Nombre)
                           .Select(grupoTipo => new TipoMovimientoo
                           {   
                                Nombre = grupoTipo.Key,
                                cantidad = grupoTipo.Sum(tipo => tipo.cantidad)
                           })
                           .ToArray(),
                          suma = grupoDeMovimiento.Sum(m => m.Cantidad)
                      })
                      .OrderBy(resumen => resumen.año);
        }
    }
}
