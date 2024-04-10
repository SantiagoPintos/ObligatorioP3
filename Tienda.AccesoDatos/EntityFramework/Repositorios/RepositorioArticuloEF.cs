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

        public bool Add(Articulo aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                this._context.Articulos.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Articulo> FindAll()
        {
            return this._context.Articulos;
        }

        public Articulo FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Articulo aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
