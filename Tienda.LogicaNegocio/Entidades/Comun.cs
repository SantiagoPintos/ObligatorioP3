using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Comun:Pedido, IValidable<Comun>
    {
        // Constructor con id
        public Comun(decimal Recargo, int Id, DateTime Fecha, Cliente Cliente, List<Linea> Lineas, decimal PrecioTotal, DateTime FechaEntrega, bool anulado) : base(Recargo, Id, Fecha, Cliente, Lineas, PrecioTotal, FechaEntrega, anulado)
        {

        }
        // Constructor vacio
        public Comun() : base() { }
        // Constructor sin id
        public Comun(decimal Recargo, DateTime Fecha, Cliente Cliente, List<Linea> Lineas, decimal PrecioTotal, DateTime FechaEntrega, bool anulado) : base(Recargo, Fecha, Cliente, Lineas, PrecioTotal, FechaEntrega, anulado)
        {

        }



        public void EsValido()
        {
            base.EsValido();
            if (base.FechaEntrega < base.Fecha.AddDays(7)) 
            {
                throw new Exception("La fecha de entrega no puede ser menor a 7 días de la fecha del pedido");
            }
        }

        public override decimal CalcularPrecio(decimal RecargoComun, decimal RecargoExpress, decimal RecargoExpressHoy)
        {
            base.validarRecargos(RecargoComun, RecargoExpress, RecargoExpressHoy);
            base.Recargo = (RecargoComun / 100);            
            foreach (Linea linea in base.lineas)
            {
                base.PrecioTotal = base.PrecioTotal + linea.Articulo.PrecioUnitario * linea.Cantidad;
            }
            if (base.Cliente.Direccion.DistanciaDesdeTienda > 100)
            {
                base.PrecioTotal = base.PrecioTotal + (base.PrecioTotal * base.Recargo);
            }
            return PrecioTotal;
        }
    }
}
