using Tienda.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations;
using Tienda.LogicaNegocio.Excepciones.Movimiento;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Movimiento : IValidable<Movimiento>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [ForeignKey("Articulo")]
        public Articulo Articulo { get; set; }
        [Required]
        //de acuerdo a la letra corresponde al email del usuario
        public string Usuario { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public TipoMovimiento TipoMovimiento { get; set; }

        public Movimiento() { }

        public Movimiento(DateTime fecha, int articulo, string usuario, int cantidad, TipoMovimiento tipo)
        {
            this.Fecha = fecha;
            this.ArticuloId = articulo;
            this.Usuario = usuario;
            this.Cantidad = cantidad;
            this.TipoMovimiento = tipo;
            EsValido();
        }

        public Movimiento(int id, DateTime fecha, int articulo, string usuario, int cantidad, TipoMovimiento tipo)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.ArticuloId = articulo;
            this.Usuario = usuario;
            this.Cantidad = cantidad;
            this.TipoMovimiento = tipo;
            EsValido();
        }

        public void EsValido()
        {
            if(this.Cantidad<0) throw new MovimientoNoValidoException("La cantidad no puede ser negativa");
        }
    }
}
