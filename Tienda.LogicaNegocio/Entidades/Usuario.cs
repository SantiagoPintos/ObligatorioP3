using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Excepciones.Usuario;
using Tienda.LogicaNegocio.InterfacesEntidades;
using Tienda.LogicaNegocio.ValueObjects;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Usuario:IValidable<Usuario>
    {
        public int Id { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        [Required]
        public string Email { get; set; }
        public string Clave { get; set; }
        //letra dice que se debe guardar una copia de la contraseña sin encriptar
        public string ClaveSinEncriptar { get; set; }

        //constructor vacío para MVC y EF
        public Usuario() { }

        //constructor sin id
        public Usuario(string nombre, string apellido, string email, string clave, string claveSinEncriptar) {
            this.NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Email = email;
            this.Clave = clave;
            this.ClaveSinEncriptar = claveSinEncriptar;
            EsValido();
        }

        public Usuario(int id, string nombre, string apellido, string email, string clave, string claveSinEncriptar) { 
            this.Id = id;
            this.NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Email = email;
            this.Clave = clave;
            this.ClaveSinEncriptar = claveSinEncriptar;
            EsValido();
        }

        public void EsValido()
        {
            try
            {
                EsValido(this);
            }
            catch (UsuarioNoValidoException e)
            {
                throw e;
            }
        }

        public void EsValido(Usuario usuario)
        {
            if(usuario == null) throw new UsuarioNuloException("El usuario no puede ser nulo");

            NombreCompleto.EsValido();

            if (string.IsNullOrEmpty(Email))
            {
                throw new EmailNoValidoException("El email no puede ser vacío");
            }
            if (!Email.Contains("@") || !Email.Contains("."))
            {
                throw new EmailNoValidoException("El email no tiene un formato válido");
            }
            if(string.IsNullOrEmpty(Clave) || Clave.Length<6)
            {
                throw new ClaveNoValidaException("La clave no es válida");
            }
            //comprueba si clave tiene al menos una letra mayuscula, una minuscula, un numero y un caracter de puntuacion
            //usando métodos de char: https://learn.microsoft.com/en-us/dotnet/api/system.char?view=net-8.0 
            if (!Clave.Any(char.IsUpper) || !Clave.Any(char.IsLower) || !Clave.Any(char.IsDigit) || !Clave.Any(char.IsPunctuation))
            {
                throw new ClaveNoValidaException("La clave no es válida");
            }
            //comprueba que Los caracteres no alfabéticos no estén ubicados al principio ni al final de la cadena.
            // https://learn.microsoft.com/es-es/dotnet/api/system.linq.enumerable.first
            // https://learn.microsoft.com/es-es/dotnet/api/system.linq.enumerable.last
            if (!char.IsLetterOrDigit(Clave.First()) || !char.IsLetterOrDigit(Clave.Last()))
            {
                throw new ClaveNoValidaException("La clave no es válida");
            }
        }
    }
}
