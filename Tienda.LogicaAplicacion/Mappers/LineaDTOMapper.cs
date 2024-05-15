using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class LineaDTOMapper
    {
        public static LineaDTO toDto(Linea linea)
        {
            LineaDTO lineaDTO = new LineaDTO();
            lineaDTO.Articulo = ArticuloDTOMapper.toDto(linea.Articulo);
            lineaDTO.Cantidad = linea.Cantidad;
            return lineaDTO;
        }

        public static Linea FromDto(LineaDTO lineaDTO)
        {
            if (lineaDTO == null) throw new Exception();

            Linea linea = new Linea();
            linea.Articulo = ArticuloDTOMapper.FromDto(lineaDTO.Articulo);
            linea.Cantidad = lineaDTO.Cantidad;
            return linea;

        }
    }
}
