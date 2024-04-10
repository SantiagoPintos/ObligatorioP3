using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Excepciones.Usuario;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreCompleto:IValidable<NombreCompleto>
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public NombreCompleto(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        protected NombreCompleto()
        {
            this.Nombre = "Sin nombre";
            this.Apellido = "Sin apellido";
        }

        public override bool Equals(object? obj)
        {
            try 
            {
                if (obj == null) return false;
                NombreCompleto otro = obj as NombreCompleto;
                return this.Nombre.Equals(otro.Nombre) && this.Apellido.Equals(otro.Apellido);
            } 
            catch (Exception e)
            {
                return false;
            }
        }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new UsuarioNoValidoException("El nombre no puede estar vacíos");
            if (string.IsNullOrEmpty(Apellido)) throw new UsuarioNoValidoException("El apellido no puede estar vacíos");
        }
    }
}
