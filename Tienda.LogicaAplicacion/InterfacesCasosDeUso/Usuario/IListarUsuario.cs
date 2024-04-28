using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaAplicacion.InterfacesCasosDeUso.Usuario
{
    public interface IListarUsuario
    {
        IEnumerable<Tienda.LogicaAplicacion.DTOs.UsuarioDTO> ListarUsuarios();
    }
}
