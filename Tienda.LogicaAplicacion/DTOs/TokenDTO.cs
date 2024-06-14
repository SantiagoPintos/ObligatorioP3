using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.LogicaNegocio.Entidades;

namespace Tienda.LogicaAplicacion.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public string TokenUsuario { get; set; }
        public EncargadoDTO Encargado { get; set; }
    }
}
