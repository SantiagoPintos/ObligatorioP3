using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Articulo
{
    public class PrecioUnitarioNoValidoException : Exception
    {
        public PrecioUnitarioNoValidoException()
        {
        }
        public PrecioUnitarioNoValidoException(string? message) : base(message)
        {
        }
        public PrecioUnitarioNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected PrecioUnitarioNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
