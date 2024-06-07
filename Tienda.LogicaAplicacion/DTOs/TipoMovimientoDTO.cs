using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Enums;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class TipoMovimientoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public SignoTipoMovimiento Signo { get; set; }
    }
}
