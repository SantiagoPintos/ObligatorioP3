using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Articulo
{
    public class CodigoNoValidoException : Exception
    {
        public CodigoNoValidoException()
        {
        }
        public CodigoNoValidoException(string? message) : base(message)
        {
        }
        public CodigoNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected CodigoNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
