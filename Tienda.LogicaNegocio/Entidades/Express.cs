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
        public Express(decimal Recargo, int Id, DateTime Fecha, Cliente Cliente, List<Linea> Lineas, decimal PrecioTotal, DateTime FechaEntrega, bool anulado ) : base(Recargo, Id, Fecha, Cliente, Lineas, PrecioTotal, FechaEntrega, anulado)
        {            
           
        }
        // Constructor vacio
        public Express():base() { }
        // Constructor sin id
        public Express(decimal Recargo, DateTime Fecha, Cliente Cliente, List<Linea> Lineas, decimal PrecioTotal, DateTime FechaEntrega, bool anulado) : base(Recargo, Fecha, Cliente, Lineas, PrecioTotal, FechaEntrega, anulado)
        {

        }

        public void EsValido()
        {
            base.EsValido();
            if (base.Fecha.AddDays(5) <= base.FechaEntrega)
            {
                throw new Exception("La fecha de entrega no puede ser mayor a 5 días de la fecha del pedido");
            }
            if (base.FechaEntrega < base.Fecha)
            {
                throw new Exception("La fecha no puede ser menor a hoy");
            }
        }

        public override decimal CalcularPrecio(decimal RecargoComun, decimal RecargoExpress, decimal RecargoExpressHoy)
        {
            base.Recargo = RecargoExpress/100;
            base.validarRecargos(RecargoComun, RecargoExpress, RecargoExpressHoy);
            foreach (Linea linea in base.lineas)
            {
                base.PrecioTotal = base.PrecioTotal + linea.Articulo.PrecioUnitario * linea.Cantidad;
            }
            if (base.FechaEntrega == base.Fecha)
            {
                base.Recargo = RecargoExpressHoy/100;
            }
            base.PrecioTotal = base.PrecioTotal + (base.PrecioTotal * base.Recargo);
            return base.PrecioTotal;

        }
    }
}
