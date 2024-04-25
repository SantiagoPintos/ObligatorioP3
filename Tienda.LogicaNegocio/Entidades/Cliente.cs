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
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public DireccionCliente Direccion { get; set; }
        // Constructor vacio para EF
        public Cliente() { }

        public Cliente(int id, string rut, string razonSocial, string calle, int numero, string ciudad, decimal distanciaDesdeTienda)
        {
            this.Id = id;
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.Direccion = new DireccionCliente(calle, numero, ciudad, distanciaDesdeTienda);
        }

        // Constructor sin id
        public Cliente(string rut, string razonSocial, string calle, int numero, string ciudad, decimal distanciaDesdeTienda)
        {            
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.Direccion = new DireccionCliente(calle, numero, ciudad, distanciaDesdeTienda);
        }


        public void EsValido()
        {
            if(Rut == null || Rut.Length!=12) throw new Exception("El rut debe tener 12 digitos");
                        
            if(RazonSocial == null) throw new Exception("La razon social no puede ser nula");

            Direccion.EsValido();
        }
    }
}
