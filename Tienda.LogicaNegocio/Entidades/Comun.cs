﻿using System;
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
        public Comun(decimal Recargo, int Id, DateTime Fecha, Cliente Cliente, List<Linea> Lineas, decimal PrecioTotal, DateTime FechaEntrega) : base(Recargo, Id, Fecha, Cliente, Lineas, PrecioTotal, FechaEntrega)
        {

        }
        // Constructor vacio
        public Comun() : base() { }
        // Constructor sin id
        public Comun(decimal Recargo, DateTime Fecha, Cliente Cliente, List<Linea> Lineas, decimal PrecioTotal, DateTime FechaEntrega) : base(Recargo, Fecha, Cliente, Lineas, PrecioTotal, FechaEntrega)
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
    }
}
