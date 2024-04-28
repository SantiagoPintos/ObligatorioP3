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
    public class ListarUsuarioCU : IListarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public ListarUsuarioCU(IRepositorioUsuario _repositorioUsuario)
        {
            this._repositorioUsuario = _repositorioUsuario;
        }
        public IEnumerable<UsuarioDTO> ListarUsuarios()
        {
            return this._repositorioUsuario.FindAll().Select(usuario => UsuarioDtoMapper.toDto(usuario));
        }
    }
}
