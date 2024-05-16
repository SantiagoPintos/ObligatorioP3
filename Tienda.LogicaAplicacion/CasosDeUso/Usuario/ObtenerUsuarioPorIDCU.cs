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
    public class ObtenerUsuarioPorIDCU : IObtenerUsuarioPorID
    {
        private IRepositorioUsuario _repositorioUsuario;
        public ObtenerUsuarioPorIDCU(IRepositorioUsuario _repositorioUsuario)
        {
            this._repositorioUsuario = _repositorioUsuario;
        }
        UsuarioDTO IObtenerUsuarioPorID.ObtenerUsuarioPorID(int id)
        {
            return UsuarioDtoMapper.toDto(this._repositorioUsuario.EncontrarPorId(id));
        }
    }
}
