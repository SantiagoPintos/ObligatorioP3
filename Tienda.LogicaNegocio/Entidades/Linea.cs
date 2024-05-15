using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Linea : IValidable<Linea>
    {
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }

        // Constructor vacio
        public Linea() { }

        // Constructor con parametros
        public Linea(Articulo articulo, int cantidad)
        {
            this.Articulo = articulo;
            this.Cantidad = cantidad;
        }



        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
