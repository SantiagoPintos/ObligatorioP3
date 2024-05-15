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



    }
}
