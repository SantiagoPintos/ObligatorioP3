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
    public class Pedido : IValidable<Pedido>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Recargo { get; set; }
        [Required]   
        public DateTime Fecha { get; set; }
        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> lineas = new List<Linea>();
        [Required]
        public decimal PrecioTotal { get; set; }
        [Required]
        public DateTime FechaEntrega { get; set; }
        [Required]
        public bool anulado { get; set; }
        [Required]
        public decimal IVA { get; set; }

        // Constructor vacio para MVC y EF
        public Pedido() { }

        // Constructor con Id
        public Pedido(decimal recargo, int id, DateTime fecha, Cliente cliente, List<Linea> lineas, decimal precioTotal, DateTime FechaEntrega, bool anulado)
        {
            this.Recargo = recargo;
            this.Id = id;
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.lineas = lineas;
            this.PrecioTotal = precioTotal;
            this.FechaEntrega = FechaEntrega;
            this.anulado = anulado;
        }

        // Constructor sin Id
        public Pedido(decimal recargo, DateTime fecha, Cliente cliente, List<Linea> lineas, decimal precioTotal, DateTime FechaEntrega, bool anulado)
        {
            this.Recargo = recargo;
            this.Fecha = fecha;
            this.Cliente = cliente;
            this.lineas = lineas;
            this.PrecioTotal = precioTotal;
            this.anulado = anulado;
        }
        public void EsValido()
        {
            if(this.Fecha == null ) throw new Exception("Fecha no puede ser nula");
            if(this.lineas.Count() == 0 || this.lineas == null) throw new Exception("El pedido debe tener al menos una linea");
            if (this.IVA < 0)  throw new Exception("El IVA no puede ser negativo");

        }


        public virtual decimal CalcularPrecio(decimal RecargoComun, decimal RecargoExpress, decimal RecargoExpressHoy)
        {
            decimal precioTotal = 0;
            return precioTotal;
        }

        public void validarRecargos(decimal RecargoComun, decimal RecargoExpress, decimal RecargoExpressHoy)
        {
            if (RecargoComun < 0 || RecargoExpress < 0 || RecargoExpressHoy < 0) throw new Exception("Los recargos no pueden ser negativos");
        }


    }
}
