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
    public class CrearUsuarioCU : ICreateUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public CrearUsuarioCU(IRepositorioUsuario repositorioUsuario)
        {
            this._repositorioUsuario = repositorioUsuario;
        }

        public void CrearUsuario(UsuarioDTO aCrear)
        {
            this._repositorioUsuario.Add(UsuarioDtoMapper.FromDto(aCrear));
        }
    }
}
