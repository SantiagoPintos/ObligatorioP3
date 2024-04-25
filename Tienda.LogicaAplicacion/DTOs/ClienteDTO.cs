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
        public string Numero { get; set; }
        public string Ciudad { get; set; }

        public ClienteDTO() { }

        public ClienteDTO(Cliente cliente)
        {
            if(cliente == null) throw new Exception();

            this.Id = cliente.Id;
            this.Rut = cliente.Rut;
            this.RazonSocial = cliente.RazonSocial;
            this.Calle = cliente.Direccion.Calle;
            this.Numero = cliente.Direccion.Numero.ToString();
            this.Ciudad = cliente.Direccion.Ciudad;            
        }



    }
}
