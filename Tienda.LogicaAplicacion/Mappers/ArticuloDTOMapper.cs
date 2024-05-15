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
            ArticuloDTO articuloDTO = new ArticuloDTO();
            articuloDTO.Id = articulo.Id;
            articuloDTO.Nombre = articulo.Nombre;
            articuloDTO.Codigo = articulo.Codigo;
            articuloDTO.Descripcion = articulo.Descripcion;
            articuloDTO.stock = articulo.stock;
            articuloDTO.PrecioUnitario = articulo.PrecioUnitario;

            return articuloDTO;
        }

        public static Articulo FromDto(ArticuloDTO articuloDTO)
        {
            if (articuloDTO == null) throw new Exception();
            Articulo articulo = new Articulo();            
            articulo.Nombre = articuloDTO.Nombre;
            articulo.Codigo = articuloDTO.Codigo;                
            articulo.Descripcion = articuloDTO.Descripcion;
            articulo.stock = articuloDTO.stock;
            articulo.PrecioUnitario = articuloDTO.PrecioUnitario;
            return articulo;

        }
    }
}
