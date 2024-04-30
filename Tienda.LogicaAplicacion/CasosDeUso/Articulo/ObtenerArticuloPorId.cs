using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Articulo
{
    public class ObtenerArticuloPorId : IObtenerArticuloPorId
    {

        private IRepositorioArticulo _repositorioArticulo;
        public ObtenerArticuloPorId(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        ArticuloDTO IObtenerArticuloPorId.ObtenerArticuloPorId(int id)
        {
            return ArticuloDTOMapper.toDto(this._repositorioArticulo.EncontrarPorId(id));
        }
    }
}
