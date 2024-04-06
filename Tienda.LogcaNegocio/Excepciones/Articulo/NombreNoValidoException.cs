using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Articulo
{
    public class NombreNoValidoException : Exception
    {
        public NombreNoValidoException()
        {
        }
        public NombreNoValidoException(string? message) : base(message)
        {
        }
        public NombreNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected NombreNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
