using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioEncargadoEF : IRepositorioEncargado
    {
        private TiendaContext _context;
        public RepositorioEncargadoEF()
        {
            this._context = new TiendaContext();
        }
        public bool Add(Encargado aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Encargado> FindAll()
        {
            throw new NotImplementedException();
        }

        public Encargado FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Encargado aBorrar)
        {
            throw new NotImplementedException();
        }

        public bool Update(Encargado aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
