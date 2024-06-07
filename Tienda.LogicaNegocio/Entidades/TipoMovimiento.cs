using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;
using Tienda.LogicaNegocio.Excepciones.TipoMovimiento;

namespace Tienda.LogicaNegocio.Entidades
{
    public class TipoMovimiento : IValidable<TipoMovimiento>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        // 1 para aumento de stock, -1 para reducción
        // de esa forma se puede calcular el stock con la siguiente fórmula: 
        // stock = stock + cantidad * signo 
        [Required]
        public int Signo { get; set; }

        public TipoMovimiento() { }
        public TipoMovimiento(string nombre, int signo)
        {
            Nombre = nombre;
            Signo = signo;
            this.EsValido();
        }
        public TipoMovimiento(int id, string nombre, int signo)
        {
            Id = id;
            Nombre = nombre;
            Signo = signo;
        }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new TipoMovimientoNoValidoException("El nombre no puede ser nulo o vacio");
            if (Nombre.Length > 50) throw new TipoMovimientoNoValidoException("El nombre no puede tener mas de 50 caracteres");
            if (Signo != 1 && Signo != -1) throw new TipoMovimientoNoValidoException("Tipo de movimiento no válido");
        }
    }
}
