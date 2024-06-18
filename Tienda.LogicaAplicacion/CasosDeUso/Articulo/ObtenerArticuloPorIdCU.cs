using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.Excepciones.Articulo;

namespace Tienda.LogicaAplicacion.CasosDeUso.Articulo
{
    public class ObtenerArticuloPorIdCU : IObtenerArticuloPorId
    {

        private IRepositorioArticulo _repositorioArticulo;
        public ObtenerArticuloPorIdCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public ArticuloDTO ObtenerArticuloPorId(int id)
        {
            Tienda.LogicaNegocio.Entidades.Articulo articulo = this._repositorioArticulo.EncontrarPorId(id);
            if (articulo==null)
            {
                throw new ArticuloNuloException();
            }
            return ArticuloDTOMapper.toDto(articulo);
        }
    }
}
