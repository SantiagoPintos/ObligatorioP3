using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioTipoMovimientoEF : IRepositorioTipoMovimiento
    {
        private TiendaContext _context;
        public RepositorioTipoMovimientoEF()
        {
            this._context = new TiendaContext();
        }
        public bool Add(TipoMovimiento aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoMovimiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public TipoMovimiento FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TipoMovimiento aBorrar)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoMovimiento aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
