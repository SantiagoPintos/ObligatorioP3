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
                this._context.Entry(aAgregar.Encargado).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                this._context.Set<Token>().Add(aAgregar);
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

        //Método usado para eliminar token en caso de que ya exista uno para ese usuario
        public void FindByEmailAndRemove(string email)
        {
            try
            {
                Token tokenBuscado = this._context.Tokens.FirstOrDefault(t => t.Encargado.Email == email);
                if (tokenBuscado != null) this._context.Tokens.Remove(tokenBuscado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
