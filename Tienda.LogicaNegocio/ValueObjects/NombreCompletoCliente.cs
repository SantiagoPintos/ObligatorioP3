using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Excepciones.Cliente;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreCompletoCliente : IValidable<NombreCompleto>
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public NombreCompletoCliente(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        protected NombreCompletoCliente()
        {
            this.Nombre = "Sin nombre";
            this.Apellido = "Sin apellido";
        }

        public override bool Equals(object? obj)
        {
            try
            {
                if (obj == null) return false;
                NombreCompletoCliente otro = obj as NombreCompletoCliente;
                return this.Nombre.Equals(otro.Nombre) && this.Apellido.Equals(otro.Apellido);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new ClienteNoValidoException("El nombre no puede estar vacíos");
            if (string.IsNullOrEmpty(Apellido)) throw new ClienteNoValidoException("El apellido no puede estar vacíos");
        }
    }
}
