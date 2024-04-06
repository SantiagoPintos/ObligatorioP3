using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Articulo
{
    public class DescripcionNoValidaException : Exception
    {
        public DescripcionNoValidaException()
        {
        }
        public DescripcionNoValidaException(string? message) : base(message)
        {
        }
        public DescripcionNoValidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected DescripcionNoValidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
