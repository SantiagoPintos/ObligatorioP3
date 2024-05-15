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
    public class UsuarioDtoMapper
    {
        public static UsuarioDTO toDto(Usuario usuario)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();  
            usuarioDTO.Id = usuario.Id;
            usuarioDTO.Nombre = usuario.NombreCompleto.Nombre;
            usuarioDTO.Apellido = usuario.NombreCompleto.Apellido;
            usuarioDTO.Email = usuario.Email;
            usuarioDTO.Clave = usuario.Clave;                
            usuarioDTO.ClaveSinEncriptar = usuario.ClaveSinEncriptar;            
            return usuarioDTO;
        }

        public static Usuario FromDto(UsuarioDTO usuarioDTO)
        {
            if(usuarioDTO == null) throw new Exception();
            Usuario usuario = new Usuario();
            NombreCompleto nombreCompleto = new NombreCompleto(usuarioDTO.Nombre, usuarioDTO.Apellido);
            usuario.NombreCompleto = nombreCompleto;
            usuario.Email = usuarioDTO.Email;
            usuario.Clave = usuarioDTO.Clave;
            return usuario;
        }
    }
}
