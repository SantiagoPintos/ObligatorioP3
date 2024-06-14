using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.AccesoDatos.CrifradoClave;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioTokenEF : IRepositorioToken
    {
        private TiendaContext _context;
        public RepositorioTokenEF()
        {
            this._context = new TiendaContext();
        }
        public bool Add(Token aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                this._context.Tokens.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Token> FindAll()
        {
            throw new NotImplementedException();
        }
        public Token FindByEmail(string email)
        {
            return this._context.Tokens.FirstOrDefault(t => t.Encargado.Email == email);
        }
        public Token FindByID(int id)
        {
            return this._context.Tokens.FirstOrDefault(t => t.Id == id);
        }

        public bool Remove(Token aBorrar)
        {
            try
            {
                this._context.Tokens.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Token aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
