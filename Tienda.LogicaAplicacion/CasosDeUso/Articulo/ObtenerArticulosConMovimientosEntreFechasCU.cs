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
        private IRepositorioSettings _repositorioSettings;
        public ObtenerArticulosConMovimientosEntreFechasCU(IRepositorioMovimiento repositorioMovimiento, IRepositorioSettings repositorioSettings)
        {
            this.repositorioMovimiento = repositorioMovimiento;
            this._repositorioSettings = repositorioSettings;
        }
        public IEnumerable<ArticuloDTO> ObtenerArticulosConMovimientosEntreFechas(DateTime fchInicial, DateTime fchFinal, int pag)
        {
            if (pag < 0) throw new ArticuloNuloException("El valor de página no es válido");
            if(fchInicial == DateTime.MinValue || fchFinal == DateTime.MinValue) throw new ArticuloNuloException("Las fechas no son válidas");
            //Invertimos fecha en caso de que la inicial sea mayor a la final
            if (fchInicial > fchFinal)
            {
                DateTime aux = fchInicial;
                fchInicial = fchFinal;
                fchFinal = aux; 
            }
            int size = (int)this._repositorioSettings.GetSettingValueByName("PAGINADO");
            if(size <= 0) throw new ArticuloNuloException("El valor de paginado no es válido");

            return this.repositorioMovimiento.ObtenerArticulosConMovimientosEntreFechas(fchInicial, fchFinal, pag, size).Select(articulo => ArticuloDTOMapper.toDto(articulo));
        }
    }
}
