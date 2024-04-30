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
    public class ListarArticuloCU : IListarArticulo
    {

        private IRepositorioArticulo _repositorioArticulo;
        public ListarArticuloCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }
        public IEnumerable<ArticuloDTO> ListarArticulos()
        {
            return this._repositorioArticulo.FindAll().Select(articulo => ArticuloDTOMapper.toDto(articulo));
        }
    }
}
