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
    public class CrearArticuloCU : ICrearArticulo
    {
        private IRepositorioArticulo _repositorioArticulo;
        public CrearArticuloCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void CrearArticulo(ArticuloDTO aCrear)
        {
            this._repositorioArticulo.Add(ArticuloDTOMapper.FromDto(aCrear));
        }
    }
}
