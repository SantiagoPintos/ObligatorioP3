using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.AccesoDatos.CrifradoClave;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.Excepciones.Articulo;
using Tienda.LogicaNegocio.Excepciones.Usuario;
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
                if (this.ExisteArticulo(aAgregar.Codigo, aAgregar.Nombre)) throw new Exception("El articulo ya existe");
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
            return this._context.Articulos.Where(articulo => articulo.Id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Articulo aBorrar)
        {
            try
            {
                this._context.Articulos.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Articulo aModificar)
        {
            try
            {                
                aModificar.EsValido();               
                this._context.Articulos.Update(aModificar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool ExisteArticulo(long codigo, string nombre)
        {
            return this._context.Articulos.Where(articulo => articulo.Codigo == codigo || articulo.Nombre == nombre).Any();
        }

        public Articulo EncontrarPorId(int id)
        {
            if (id == null) throw new ArticuloNuloException("El id no puede ser nulo");
            Articulo encontrado = this._context.Articulos.Where(a => a.Id == id).FirstOrDefault();            
            return encontrado;
        }
    }
}
