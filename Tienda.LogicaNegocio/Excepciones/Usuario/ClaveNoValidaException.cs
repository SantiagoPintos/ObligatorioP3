using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.LogicaNegocio.Excepciones.Usuario
{
    public class ClaveNoValidaException : Exception
    {
        public ClaveNoValidaException()
        {
        }
        public ClaveNoValidaException(string? message) : base(message)
        {
        }
        public ClaveNoValidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected ClaveNoValidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
