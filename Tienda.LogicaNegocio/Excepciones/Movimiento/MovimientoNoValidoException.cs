using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Movimiento
{
    public class MovimientoNoValidoException : Exception
    {
        public MovimientoNoValidoException() { }
        public MovimientoNoValidoException(string mensaje) : base(mensaje) { }

        public MovimientoNoValidoException(string? mensaje, Exception? inner) : base(mensaje, inner) { }

        protected MovimientoNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
