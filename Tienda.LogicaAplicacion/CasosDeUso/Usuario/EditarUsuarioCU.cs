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
    public class EditarUsuarioCU : IEditarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public EditarUsuarioCU(IRepositorioUsuario _repositorioUsuario)
        {
            this._repositorioUsuario = _repositorioUsuario;
        }
        public void EditarUsuario(UsuarioDTO aEditar)
        {
            this._repositorioUsuario.Update(UsuarioDtoMapper.FromDto(aEditar));
        }
    }
}
