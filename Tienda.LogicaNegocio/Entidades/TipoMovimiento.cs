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
        public void EsValido()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new TipoMovimientoNoValidoException("El nombre no puede ser nulo o vacio");
            if (Nombre.Length > 50) throw new TipoMovimientoNoValidoException("El nombre no puede tener mas de 50 caracteres");
        }
    }
}
