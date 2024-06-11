using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.ValueObjects;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class EncargadoDTOMapper
    {
        public static EncargadoDTO ToDTO(Encargado encargado)
        {
            EncargadoDTO encargadoDTO = new EncargadoDTO();
            encargadoDTO.Id = encargado.Id;
            encargadoDTO.Nombre = encargado.NombreCompleto.Nombre;
            encargadoDTO.Apellido = encargado.NombreCompleto.Apellido;
            encargadoDTO.Email = encargado.Email;
            encargadoDTO.Clave = encargado.Clave;
            return encargadoDTO;
        }

        public static Encargado FromDTO(EncargadoDTO encargadoDTO)
        {
            Encargado encargado = new Encargado();
            encargado.Id = encargadoDTO.Id;
            NombreCompleto nombreCompleto = new NombreCompleto(encargadoDTO.Nombre, encargadoDTO.Apellido);
            encargado.NombreCompleto = nombreCompleto;
            encargado.Email = encargadoDTO.Email;
            encargado.Clave = encargadoDTO.Clave;
            return encargado;
        }
    }
}
