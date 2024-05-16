using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Linea : IValidable<Linea>
    {
        [ForeignKey(nameof(Articulo))] public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        [Range(1, int.MaxValue)]
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
