using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;
using Tienda.LogicaNegocio.ValueObjects;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Cliente:IValidable<Cliente>
    {
        [Key]
        public int Id { get; set; }        
        [Required]
        [StringLength(12)]
        public string Rut { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public DireccionCliente Direccion { get; set; }
        [Required]
        public NombreCompletoCliente NombreCompleto {  get; set;}

        // Constructor vacio para EF
        public Cliente() { }

        public Cliente(int id, string rut, string razonSocial, string calle, int numero, string ciudad, decimal distanciaDesdeTienda, string nombre, string apellido)
        {
            this.Id = id;
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.Direccion = new DireccionCliente(calle, numero, ciudad, distanciaDesdeTienda);
            this.NombreCompleto = new NombreCompletoCliente(nombre, apellido);
        }

        // Constructor sin id
        public Cliente(string rut, string razonSocial, string calle, int numero, string ciudad, decimal distanciaDesdeTienda, string nombre, string apellido)
        {            
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.Direccion = new DireccionCliente(calle, numero, ciudad, distanciaDesdeTienda);
            this.NombreCompleto = new NombreCompletoCliente(nombre, apellido);
        }


        public void EsValido()
        {
            if(Rut == null || Rut.Length!=12) throw new Exception("El rut debe tener 12 digitos");
                        
            if(RazonSocial == null) throw new Exception("La razon social no puede ser nula");
            NombreCompleto.EsValido();
            Direccion.EsValido();
        }
    }
}
