using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;
using Tienda.LogicaNegocio.ValueObjects;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public decimal distanciaDesdeTienda { get; set; } 
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public ClienteDTO() { }

        public ClienteDTO(Cliente cliente)
        {
            if(cliente == null) throw new Exception();

            this.Id = cliente.Id;
            this.Rut = cliente.Rut;
            this.RazonSocial = cliente.RazonSocial;
            this.Calle = cliente.Direccion.Calle;
            this.Numero = cliente.Direccion.Numero;
            this.Ciudad = cliente.Direccion.Ciudad;     
            this.distanciaDesdeTienda = cliente.Direccion.DistanciaDesdeTienda;
            this.Nombre = cliente.NombreCompleto.Nombre;
            this.Apellido = cliente.NombreCompleto.Apellido;
        }



    }
}
