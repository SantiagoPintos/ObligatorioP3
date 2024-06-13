using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.AccesoDatos.CrifradoClave;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.Excepciones.Encargado;
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

        public Encargado FindByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new EncargadoException();
            return this._context.Encargado.FirstOrDefault(e => e.Email == email);
        }

        public Encargado FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Login(string email, string clave)
        {
            Encargado e = this.FindByEmail(email);
            if(e.Email != email || Cifrado.DesencriptarClave(e.Clave) != clave) throw new EncargadoException("Datos incorrectos");
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
