using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaAplicacion.DTOs;
using Tienda.LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using Tienda.LogicaAplicacion.Mappers;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.LogicaAplicacion.CasosDeUso.Usuario
{
    public class EliminarUsuarioCU : IEliminarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public EliminarUsuarioCU(IRepositorioUsuario _repositorioUsuario)
        {
            this._repositorioUsuario = _repositorioUsuario;
        }
        public void EliminarUsuario(UsuarioDTO usuario)
        {            
            this._repositorioUsuario.Remove(UsuarioDtoMapper.FromDto(usuario));
        }
    }

}

