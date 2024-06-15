using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.Excepciones.Articulo;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Articulo
{
    public class ObtenerArticulosConMovimientosEntreFechasCU : IObtenerArticulosConMovimientosEntreFechas
    {
        private IRepositorioMovimiento repositorioMovimiento;
        public ObtenerArticulosConMovimientosEntreFechasCU(IRepositorioMovimiento repositorioMovimiento)
        {
            this.repositorioMovimiento = repositorioMovimiento;
        }
        public IEnumerable<ArticuloDTO> ObtenerArticulosConMovimientosEntreFechas(DateTime fchInicial, DateTime fchFinal)
        {
            if(fchInicial == DateTime.MinValue || fchFinal == DateTime.MinValue) throw new ArticuloNuloException("Las fechas no son válidas");
            return this.repositorioMovimiento.ObtenerArticulosConMovimientosEntreFechas(fchInicial, fchFinal).Select(articulo => ArticuloDTOMapper.toDto(articulo));
        }
    }
}
