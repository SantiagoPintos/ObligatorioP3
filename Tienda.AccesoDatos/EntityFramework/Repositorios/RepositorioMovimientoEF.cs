using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioMovimientoEF : IRepositorioMovimiento
    {
        private TiendaContext _context;
        public RepositorioMovimientoEF()
        {
            this._context = new TiendaContext();
        }
        public bool Add(Movimiento aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                aAgregar.TipoMovimiento.EsValido();
                this._context.Movimientos.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Movimiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public Movimiento FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Movimiento aBorrar)
        {
            throw new NotImplementedException();
        }

        public bool Update(Movimiento aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
