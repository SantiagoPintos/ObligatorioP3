using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.Mappers
{
    public class UsuarioDtoMapper
    {
        public static UsuarioDTO toDto(Usuario usuario)
        {
            return new UsuarioDTO(usuario);
        }

        public static Usuario FromDto(UsuarioDTO usuarioDTO)
        {
            if(usuarioDTO == null) throw new Exception();

            return new Usuario(usuarioDTO.Id, usuarioDTO.Nombre, usuarioDTO.Apellido, usuarioDTO.Email, usuarioDTO.Clave, usuarioDTO.ClaveSinEncriptar);
        }
    }
}
