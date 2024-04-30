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
    public class EditarArticuloCU : IEditarArticulo
    {

        private IRepositorioArticulo _repositorioArticulo;
        public EditarArticuloCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }
        public void EditarArticulo(ArticuloDTO aEditar)
        {
            this._repositorioArticulo.Update(ArticuloDTOMapper.FromDto(aEditar));
        }
    }
}
