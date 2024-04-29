using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.AccesoDatos.CrifradoClave;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.Excepciones.Usuario;
using Tienda.LogicaNegocio.InterfacesRepositorio;

namespace Tienda.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
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
                if (this.ExisteUsuario(aAgregar.Email)) throw new Exception("El usuario ya existe");
                aAgregar.ClaveSinEncriptar = aAgregar.Clave;
                aAgregar.EsValido();
                //la clave se encripta después de comprobar su validez
                aAgregar.Clave = Cifrado.EncriptarClave(aAgregar.Clave);
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
                aModificar.ClaveSinEncriptar = aModificar.Clave; 
                aModificar.EsValido();
                //antes de actualizar es necesario cifrar la contraseña nuevamente en caso de que la cambie
                aModificar.Clave = Cifrado.EncriptarClave(aModificar.ClaveSinEncriptar);
                this._context.Usuarios.Update(aModificar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //.Any() devuelve true si encuentra al menos un elemento que cumpla la condición
        // https://learn.microsoft.com/es-es/dotnet/api/system.linq.enumerable.any?view=net-8.0#definition
        public bool ExisteUsuario(string email)
        {
            return this._context.Usuarios.Where(usuario => usuario.Email == email).Any();
        }

        public Usuario EncontrarPorEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new EmailNoValidoException("El email no puede ser vacío");

            return this._context.Usuarios.Where(usuario => usuario.Email == email).FirstOrDefault();
        }

        public bool ClaveCoincide(string claveCifrada, string claveTextoPlano)
        {
            if (string.IsNullOrEmpty(claveCifrada) || string.IsNullOrEmpty(claveTextoPlano)) throw new ClaveNoValidaException("La clave no puede ser vacía");

            return Cifrado.DesencriptarClave(claveCifrada) == claveTextoPlano;
        }

        public Usuario EncontrarPorId(int id)
        {
            if(id == null ) throw new UsuarioNoValidoException("El id no puede ser nulo");

            Usuario encontrado = this._context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
            encontrado.Clave = Cifrado.DesencriptarClave(encontrado.Clave);
            return encontrado;
        }
    }
}
