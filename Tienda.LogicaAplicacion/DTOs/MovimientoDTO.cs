﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class MovimientoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } 
        public ArticuloDTO Articulo { get; set; }
        public string Usuario { get; set; }
        public int Cantidad { get; set; }
        public TipoMovimientoDTO TipoMovimiento { get; set; }
    }
}
