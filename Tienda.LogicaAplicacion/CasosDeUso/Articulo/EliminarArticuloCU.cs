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
    public class EliminarArticuloCU : IEliminarArticulo
    {
        private IRepositorioArticulo _repositorioArticulo;
        public EliminarArticuloCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }
        public void EliminarArticulo(ArticuloDTO aBorrar)
        {
            this._repositorioArticulo.Remove(ArticuloDTOMapper.FromDto(aBorrar));
        }
    }
}
