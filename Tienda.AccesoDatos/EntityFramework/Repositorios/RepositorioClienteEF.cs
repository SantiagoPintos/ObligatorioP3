using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
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

        public bool Add(Cliente aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> FindAll()
        {
            throw new NotImplementedException();
        }

        public Cliente FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
