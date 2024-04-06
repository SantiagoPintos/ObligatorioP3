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

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
