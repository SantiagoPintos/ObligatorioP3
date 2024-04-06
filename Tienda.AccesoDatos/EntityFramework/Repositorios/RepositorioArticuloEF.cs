using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioArticuloEF:IRepositorioArticulo
    {
        private TiendaContext _context;
        public RepositorioArticuloEF()
        {
            this._context = new TiendaContext();
        }
    }
}
