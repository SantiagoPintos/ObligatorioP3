using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class MovimientoDTO
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public ArticuloDTO Articulo { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public int Cantidad { get; set; }
        //El tipo de movimiento se implementa de esta forma en vez de utilizar su DTO
        //Porque de lo contrario se generan problemas al mapear el DTO a la entidad
        public int TipoMovimientoId { get; set; }
        public string TipoMovimientoNombre { get; set; }
        public int TipoMovimientoSigno { get; set; }
    }
}
