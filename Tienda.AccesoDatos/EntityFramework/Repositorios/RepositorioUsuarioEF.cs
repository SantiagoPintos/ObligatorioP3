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
            try
            {
                aAgregar.EsValido();
                this._context.Usuarios.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return this._context.Usuarios;
        }

        public Usuario FindByID(int id)
        {
            return this._context.Usuarios.Where(usuario => usuario.Id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                Usuario aBorrar = new Usuario { Id = id };
                this._context.Usuarios.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Usuario aModificar)
        {
            try
            {
                aModificar.EsValido();
                this._context.Usuarios.Update(aModificar);
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
