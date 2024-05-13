using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Pedido : IValidable<Pedido>
    {
        public decimal Recargo { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }

        public List<Linea> lineas = new List<Linea>();
        public decimal PrecioTotal { get; set; }

        // Constructor vacio para MVC y EF
        public Pedido() { }

        // Constructor con Id
        public Pedido(decimal recargo, int id, DateTime fecha, Cliente cliente, List<Linea> lineas, decimal precioTotal)
        {
            this.Recargo = recargo;
            this.Id = id;
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.lineas = lineas;
            this.PrecioTotal = precioTotal;
        }

        // Constructor sin Id
        public Pedido(decimal recargo, DateTime fecha, Cliente cliente, List<Linea> lineas, decimal precioTotal)
        {
            this.Recargo = recargo;
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.lineas = lineas;
            this.PrecioTotal = precioTotal;
        }

        public void EsValido()
        {
            if(this.Fecha == null ) throw new Exception("Fecha no puede ser nula");
        }
    }
}
