using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
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

        public bool Add(Usuario aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
