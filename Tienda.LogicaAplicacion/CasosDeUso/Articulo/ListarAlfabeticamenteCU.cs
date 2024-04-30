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
    public class ListarAlfabeticamenteCU : IListarAlfabeticamente
    {
        private IRepositorioArticulo _repositorioArticulo;
        public ListarAlfabeticamenteCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }
        public IEnumerable<ArticuloDTO> ListarAlfabeticamente()
        {
            return this._repositorioArticulo.FindAll().OrderBy(articulo => articulo.Nombre).Select(articulo => ArticuloDTOMapper.toDto(articulo));
        }
    }
}
