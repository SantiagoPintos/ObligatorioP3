using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Express:Pedido,IValidable<Express> 
    {
        // Constructor con id
        public Express(decimal Recargo, int Id, DateTime Fecha, Cliente Cliente, List<Linea> Lineas, decimal PrecioTotal, DateTime FechaEntrega ) : base(Recargo, Id, Fecha, Cliente, Lineas, PrecioTotal, FechaEntrega)
        {            
           
        }
        // Constructor vacio
        public Express():base() { }
        // Constructor sin id
        public Express(decimal Recargo, DateTime Fecha, Cliente Cliente, List<Linea> Lineas, decimal PrecioTotal, DateTime FechaEntrega) : base(Recargo, Fecha, Cliente, Lineas, PrecioTotal, FechaEntrega)
        {

        }








        public void EsValido()
        {
            base.EsValido();
            if (base.Fecha.AddDays(5) <= base.FechaEntrega)
            {
                throw new Exception("La fecha de entrega no puede ser mayor a 5 días de la fecha del pedido");
            }
        }

    }
}
