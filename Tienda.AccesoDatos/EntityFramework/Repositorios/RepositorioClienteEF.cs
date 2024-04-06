using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioClienteEF:IRepositorioCliente
    {
        private TiendaContext _context;
        public RepositorioClienteEF()
        {
            this._context = new TiendaContext();
        }
    }
}
