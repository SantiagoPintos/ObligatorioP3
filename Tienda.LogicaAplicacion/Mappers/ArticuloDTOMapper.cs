using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class ArticuloDTOMapper
    {
        public static ArticuloDTO toDto(Articulo articulo)
        {
            return new ArticuloDTO(articulo);
        }

        public static Articulo FromDto(ArticuloDTO articuloDTO)
        {
            return new Articulo(articuloDTO.Id, articuloDTO.Nombre, articuloDTO.Codigo, articuloDTO.Descripcion, articuloDTO.stock, articuloDTO.PrecioUnitario);
        }
    }
}
