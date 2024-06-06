﻿using Tienda.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations;
using Tienda.LogicaNegocio.Excepciones.Movimiento;

namespace Tienda.LogicaNegocio.Entidades
{
    public class Movimiento : IValidable<Movimiento>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly Fecha { get; set; }
        [Required]
        public TimeOnly Hora { get; set; }
        [Required]
        public Articulo Articulo { get; set; }
        [Required]
        public Usuario Usuario { get; set; }
        [Required]
        public int Cantidad { get; set; }

        public Movimiento() { }

        public Movimiento(DateOnly fecha, TimeOnly hora, Articulo articulo, Usuario usuario, int cantidad)
        {
            this.Fecha = fecha;
            this.Hora = hora;
            this.Articulo = articulo;
            this.Usuario = usuario;
            this.Cantidad = cantidad;
            EsValido();
        }

        public Movimiento(int id, DateOnly fecha, TimeOnly hora, Articulo articulo, Usuario usuario, int cantidad)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Articulo = articulo;
            this.Usuario = usuario;
            this.Cantidad = cantidad;
            EsValido();
        }

        public void EsValido()
        {
            if(this.Cantidad<0) throw new MovimientoNoValidoException("La cantidad no puede ser negativa");
            if(this.Cantidad>this.Articulo.stock) throw new MovimientoNoValidoException("La cantidad no puede ser mayor al stock");
        }
    }
}
