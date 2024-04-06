using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioUsuarioEF:IRepositorioUsuario
    {
        private TiendaContext _context;
        public RepositorioUsuarioEF()
        {
            this._context = new TiendaContext();
        }
    }
}
