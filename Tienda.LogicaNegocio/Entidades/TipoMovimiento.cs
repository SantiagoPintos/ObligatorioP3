using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.InterfacesEntidades;
using Tienda.LogicaNegocio.Excepciones.TipoMovimiento;
using Tienda.LogicaNegocio.Enums;

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
        [Range(-1, 1)]
        [Required]
        public SignoTipoMovimiento Signo { get; set; }

        public TipoMovimiento() { }
        public TipoMovimiento(string nombre, SignoTipoMovimiento signo)
        {
            Nombre = nombre;
            Signo = signo;
            this.EsValido();
        }
        public TipoMovimiento(int id, string nombre, SignoTipoMovimiento signo)
        {
            Id = id;
            Nombre = nombre;
            Signo = signo;
        }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new TipoMovimientoNoValidoException("El nombre no puede ser nulo o vacio");
            if (Nombre.Length > 50) throw new TipoMovimientoNoValidoException("El nombre no puede tener mas de 50 caracteres");
            if (Signo != SignoTipoMovimiento.Aumento && Signo != SignoTipoMovimiento.Reduccion) throw new TipoMovimientoNoValidoException("El signo solo puede ser 1 o -1");
        }
    }
}
