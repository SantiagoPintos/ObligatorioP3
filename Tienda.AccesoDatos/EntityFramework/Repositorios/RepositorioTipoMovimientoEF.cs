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
            try
            {
                aAgregar.EsValido();
                _context.TiposMovimiento.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TipoMovimiento> FindAll()
        {
            return this._context.TiposMovimiento;
        }

        public TipoMovimiento FindByID(int id)
        {
            return this._context.TiposMovimiento.Where(t => t.Id == id).FirstOrDefault();
        }

        public bool Remove(TipoMovimiento aBorrar)
        {
            try
            {
                this._context.TiposMovimiento.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(TipoMovimiento aModificar)
        {
            try
            {
                aModificar.EsValido();
                this._context.TiposMovimiento.Update(aModificar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
