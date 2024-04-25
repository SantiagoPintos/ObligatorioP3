using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.ValueObjects
{
    [Owned]
    public class DireccionCliente : IValidable<DireccionCliente>
    {
        public string Calle { get; private set; }
        public int Numero { get; private set; }
        public string Ciudad { get; private set; }
        //Santiago: se agrega DistanciaDesdeTienda
        public decimal DistanciaDesdeTienda { get; private set; }


        public DireccionCliente(string calle, int numero, string ciudad, decimal distanciaDesdeTienda)
        {
            this.Calle = calle;
            this.Numero = numero;
            this.Ciudad = ciudad;
            this.DistanciaDesdeTienda = distanciaDesdeTienda;
            EsValido();
        }

        protected DireccionCliente()
        {
            this.Calle = "Sin nombre";
            this.Numero = 0;
            this.Ciudad = "Sin ciudad";
            this.DistanciaDesdeTienda = 0;
        }
        public void EsValido()
        {
            if(Calle == null) throw new Exception("La calle no puede ser nula");
            if(Numero < 0) throw new Exception("El numero no puede ser negativo");
            if(Ciudad == null) throw new Exception("La ciudad no puede ser nula");
            if(DistanciaDesdeTienda < 0) throw new Exception("La distancia no puede ser negativa");
        }
    }
}
